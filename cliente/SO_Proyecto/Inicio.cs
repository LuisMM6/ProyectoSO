using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SO_Proyecto
{
    public partial class Inicio : Form
    {

        //Declaracio de variables globales

        Socket server;
        Thread atender;
        Thread partida;
        int id_partida;
        int nform;
        string jug1;
        string jug2;
        string jug3;
        string jug4;
        int idjugador;

        List<Juego> formularios = new List<Juego>();

        List<string> conectados = new List<string>();
        List<string> invitados = new List<string>();

        public Inicio()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                desconectar.Visible = false;
                usuario.Visible = false;
                label3.Visible = false;
                partidas_ganadas.Visible = false;
                partidas_jugados.Visible = false;
                podio.Visible = false;
                invitacion.Visible = false;
                Tablaconectados.Visible = false;
                conectado.Visible = true;
                conectado.BackColor = Color.Gray;
                conectado.ForeColor = Color.Black;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                eliminarusuario.Visible = false;
            }));
        }

        //Recibimos mensajes del servidor
        private void AtenderServidor()
        {
            while (true)
            {
                
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);


                switch (codigo)
                {
                    case 0: // desconexion correcta



                        break;

                    case 1:
                        //respuesta a si el sigin se ha realizado correctamente

                        if (trozos[1] == "Correcto")
                        {
                            this.Invoke(new Action(() =>
                            {
                                //this.BackColor = Color.Green;
                            }));
                            MessageBox.Show("SignIn correcto!");
                        }

                        else
                        {
                            MessageBox.Show("Este usuario ya esta creado, busca otro nombre");
                        }
                        break;

                    case 2:
                        //respuesta a si ha realizado el login correctamente

                        if (trozos[1] == "Correcto")
                        {
                            MessageBox.Show("Login correcto!");
                            this.Invoke(new Action(() =>
                            {
                                // this.BackColor = Color.Green;
                                conectado.BackColor = Color.Green;
                                conectado.ForeColor = Color.Black;

                                desconectar.Visible = true;
                                usuario.Visible = true;
                                label3.Visible = true;
                                partidas_ganadas.Visible = true;
                                partidas_jugados.Visible = true;
                                podio.Visible = true;
                                invitacion.Visible = true;
                                Tablaconectados.Visible = true;
                                conectado.Visible = true;
                                textBox1.Visible = true;
                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                eliminarusuario.Visible = true;
                                username.Enabled = false;
                                password.Enabled = false;
                            }));
                            //enviamos mensaje al servidor parar realziar notificaion lista conectados

                            string v = "8/";
                            string correcto = v;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(correcto);
                            server.Send(msg);
                        }

                        else if (trozos[1] == "Incorrecto")
                        {
                            MessageBox.Show("No tienes un usuario creado");
                        }

                        else if (trozos[1] == "Logueado")
                        {
                            MessageBox.Show("Ya estás logueado!");
                        }

                        else
                            MessageBox.Show("No se pueden conectar mas usaurios, intentelo mas tarde");
                        break;

                    case 3:
                        //me da las veces que ha quedado en el podio

                        MessageBox.Show(trozos[1]);
                        break;

                    case 4:
                        //me da el numero de partidas

                        MessageBox.Show(trozos[1]);
                        break;

                    case 5:
                        //me da vector con los jugadores que ha ganado

                        MessageBox.Show(trozos[1]);
                        break;


                    case 6:

                        // añadir conectados al datagridview

                        this.Invoke(new Action(() =>
                        {
                            Tablaconectados.Rows.Clear();
                            Tablaconectados.ColumnCount = 1;
                            Tablaconectados.Columns[0].HeaderText = "Conectados";
                            Tablaconectados.BackgroundColor = Color.White;
                            Tablaconectados.RowHeadersVisible = false;
                            Tablaconectados.DefaultCellStyle.SelectionBackColor = Tablaconectados.DefaultCellStyle.BackColor;
                            Tablaconectados.DefaultCellStyle.SelectionForeColor = Tablaconectados.DefaultCellStyle.ForeColor;
                            Tablaconectados.EnableHeadersVisualStyles = false;
                            Tablaconectados.Columns[0].HeaderCell.Style.BackColor = Color.LightBlue;


                            int numconectados = Convert.ToInt32(trozos[1]);
                            int i = 0;
                            int j = 2;

                            while (i < numconectados)
                            {

                                Tablaconectados.Rows.Add(trozos[j]);


                                j++;
                                i++;
                            }

                            Tablaconectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }));

                        break;

                    case 7:

                        // invitacion de partida al invitado
                        // si acepta --> enviamos un Si
                        // sino acpeta --> enviamos un No

                        if (trozos[1] == "No")
                        {
                            MessageBox.Show("El jugador invitado no esta conectado, busca en la tabla de conectados");
                        }
                        else
                        {
                            id_partida = Convert.ToInt32(trozos[2]);
                            string juga1 = trozos[3];
                            string juga2 = trozos[4];
                            string juga3 = trozos[5];
                            string juga4 = trozos[6];

                            DialogResult invitar = MessageBox.Show(username.Text + " Quieres aceptar la invitacion de " + trozos[3], "Invitación", MessageBoxButtons.YesNo);
                            if (invitar == DialogResult.Yes)
                            {
                                string respuesta = "Si";
                                string v = "7/" + respuesta + "/" + id_partida + "/" + juga1 + "/" + juga2 + "/" + juga3 + "/" + juga4 + "/";
                                string partida = v;

                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(partida);
                                server.Send(msg);
                            }
                            else if (invitar == DialogResult.No)
                            {
                                string respuesta = "No";
                                string v = "7/" + respuesta + "/" + id_partida + "/" + juga1 + "/" + juga2 + "/" + juga3 + "/" + juga4 + "/";
                                string partida = v;

                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(partida);
                                server.Send(msg);
                            }
                        }

                        break;

                    case 8:

                        // si ha aceptado --> empezamos juego
                        // sino --> avisamos al que ha invitado


                        if (trozos[1] == "No")
                        {
                            MessageBox.Show("Todos los jugadores no han aceptado la invitacion, minimo 4 jugadores");
                        }

                        else
                        {
                            jug1 = trozos[2];
                            jug2 = trozos[3];
                            jug3 = trozos[4];
                            jug4 = trozos[5];

                            if (jug1 == username.Text)
                            {
                                idjugador = 1;

                            }
                            else if (jug2 == username.Text)
                            {
                                idjugador = 2;
                            }
                            else if (jug3 == username.Text)
                            {
                                idjugador = 3;
                            }
                            else if (jug4 == username.Text)
                            {
                                idjugador = 4;
                            }

                            ThreadStart ts = delegate { PonerEnMarchaJuego(); };
                            partida = new Thread(ts);
                            partida.Start();
                        }

                        break;

                    case 9:

                        // recibir los mensajes del chat entre jugadores

                        nform = Convert.ToInt32(trozos[1]);
                        string nombre = trozos[2];
                        string texto = trozos[3];
                        formularios[nform].Chatear(nombre, texto);

                        break;

                    case 10:

                        //recibir datos de la posicion del movimiento de una ficha

                        int idj = Convert.ToInt32(trozos[1]);
                        int posX = Convert.ToInt32(trozos[2]);
                        int posY = Convert.ToInt32(trozos[3]);
                        int turno = Convert.ToInt32(trozos[4]);

                        formularios[nform].PasarMovimiento(idj, posX, posY, turno);

                        break;

                    case 11:

                        //recibir el numero del turno siguiente cuando se pasa el turno por tiempo

                        int turn = Convert.ToInt32(trozos[1]);

                        formularios[nform].Turnos(turn);

                        break;

                    case 12:

                        //guardar el nuevo valor de dinero

                        int idjug = Convert.ToInt32(trozos[1]);
                        int dinero = Convert.ToInt32(trozos[2]);

                        formularios[nform].ActualizarDinero(idjug, dinero);

                        break;

                    case 13:

                        //recibir informacion de la compra de una carrera universitaria

                        int idpl = Convert.ToInt32(trozos[1]);
                        int money = Convert.ToInt32(trozos[2]);
                        int casilla = Convert.ToInt32(trozos[3]);
                        string jugador = Convert.ToString(trozos[4]);

                        formularios[nform].ComprarCasilla(idpl, money, casilla, jugador);

                        break;

                    case 14:

                        //recibir informacion de pagar a un propietario de una casilla

                        int idplay = Convert.ToInt32(trozos[1]);
                        int money1 = Convert.ToInt32(trozos[2]);
                        int casilla1 = Convert.ToInt32(trozos[3]);
                        string jugador1 = trozos[4];
                        string owner = trozos[5];

                        formularios[nform].Pagar_Propietario(idplay, money1, casilla1, jugador1, owner);
                        break;

                    case 15:

                        //si un jugador decide abandonar la partida, se cierra automaticamente a todos
                        
                        formularios[nform].AvisarFinPartida();
                        break;

                    case 16:


                        if (trozos[1] == "Correcto")
                        {
                            MessageBox.Show("¡Eliminación de usuario correcta!");
                            


                        }

                        else if (trozos[1] == "Incorrecto")
                        {
                            MessageBox.Show("No se ha podido eliminar al usuario");
                        }

                        break;

                    case 17:

                        string player1 = Convert.ToString(trozos[1]);
                        string player2 = Convert.ToString(trozos[2]);
                        string player3 = Convert.ToString(trozos[3]);   
                                             
                        
                        formularios[nform].MostrarResultados(player1,player2,player3);

                        break;


                }
            }
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9600);
            
            
            //Entorno de Producción
            // IPAddress direc = IPAddress.Parse("147.83.117.22");
           // IPEndPoint ipep = new IPEndPoint(direc, 50053);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                if (username.TextLength > 0 && password.TextLength > 0)
                {

                    string v = "1/" + username.Text + "/" + password.Text;
                    string mensaje = v;

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }
                else
                {
                    MessageBox.Show(" Parametros no escritos ");
                }
            }

            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9700);

            //Entorno de Producción
            //IPAddress direc = IPAddress.Parse("147.83.117.22");
           // IPEndPoint ipep = new IPEndPoint(direc, 50053);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                if (username.TextLength > 0 && password.TextLength > 0)
                {
                    string v = "2/" + username.Text + "/" + password.Text;
                    string mensaje = v;

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show(" Parametros no escritos ");
                }

            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        private void podio_Click(object sender, EventArgs e)

            // enviar la consulta de veces en el podio
        {
            if (usuario.TextLength > 0)
            {

                string v = "3/" + usuario.Text;
                string mensaje = v;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }

        private void partidas_ganadas_Click(object sender, EventArgs e)

         // enviar la consulta de partidas ganadas por jugador
        {
            if (usuario.TextLength > 0)
            {

                string v = "4/" + usuario.Text;
                string mensaje = v;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }

        private void partidas_jugadas_Click(object sender, EventArgs e)

            // enviar la consulta de partidas jugadas por un jugador
        {
            if (usuario.TextLength > 0)
            {

                string v = "5/" + usuario.Text;
                string mensaje = v;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }
       

        private void PonerEnMarchaJuego()
        {
            //abrir formulario juego
            int num = formularios.Count;
            Juego juego = new Juego(server, num, id_partida, username.Text, jug1, jug2, jug3, jug4, idjugador);
            formularios.Add(juego);
            juego.ShowDialog();

        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            DesconectarUsuario();
        }

        private void invitacion_Click(object sender, EventArgs e)
        {
            // invitar a los demas jugadores a la partida


            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0)
            {
                string v = "6/" + username.Text + "/" + textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text;
                string mensaje = v;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Minimo invitar 3 jugadores");

            }
        }


       public void DesconectarUsuario()
        {
            string v = "0/";
            string mensaje = v;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            atender.Abort();

            server.Shutdown(SocketShutdown.Both);
            server.Close();

            this.Invoke(new Action(() =>
            {
                //this.BackColor = Color.Gray;
                conectado.BackColor = Color.Gray;
                conectado.ForeColor = Color.Black;
                desconectar.Visible = false;
                usuario.Visible = false;
                label3.Visible = false;
                partidas_ganadas.Visible = false;
                partidas_jugados.Visible = false;
                podio.Visible = false;
                invitacion.Visible = false;
                Tablaconectados.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                eliminarusuario.Visible = false;
                username.Enabled = true;
                password.Enabled = true;
                username.Clear();
                password.Clear();
            }));

        }

       

        private void eliminarusuario_Click(object sender, EventArgs e)
        {
            // eiminar tu usuario de la base de datos del juego 


            string mensaje = "16/" + username.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // dejamos tiempo para los cambios en la base de datos
            Thread.Sleep(200);

            // desconexion
            atender.Abort();
            string mensaje2 = "0/";
            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
            server.Send(msg2);
            server.Shutdown(SocketShutdown.Both);
            server.Close();



            this.Invoke(new Action(() =>
            {
                //this.BackColor = Color.Gray;
                conectado.BackColor = Color.Gray;
                conectado.ForeColor = Color.Black;
                desconectar.Visible = false;
                usuario.Visible = false;
                label3.Visible = false;
                partidas_ganadas.Visible = false;
                partidas_jugados.Visible = false;
                podio.Visible = false;
                invitacion.Visible = false;
                Tablaconectados.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                username.Enabled = true;
                password.Enabled = true;
                username.Clear();
                password.Clear();
            }));

        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Close();
            Application.Exit();
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }
    }
}
