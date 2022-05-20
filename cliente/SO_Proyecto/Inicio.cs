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
                fecha.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                num_partidas.Visible = false;
                Jugadores_ganados.Visible = false;
                posicion_jugador.Visible = false;
                invitacion.Visible = false;
                boton_chat.Visible = false;
                Tablaconectados.Visible = false;
                jugador2.Visible = false;
                jugador3.Visible = false;
                jugador4.Visible = false;
                Chat.Visible = false;
                chatear.Visible = false;
            }));
        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
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
                                this.BackColor = Color.Green;
                            }));
                            MessageBox.Show("SignIn correcto!");
                        }

                        else
                        {
                            MessageBox.Show("No se ha podido hacer el SignIn");
                        }
                        break;

                    case 2:
                        //respuesta a si ha realizado el login correctamente

                        if (trozos[1] == "Correcto")
                        {
                            MessageBox.Show("Login correcto!");
                            this.Invoke(new Action(() =>
                            {
                                this.BackColor = Color.Green;
                                desconectar.Visible = true;
                                usuario.Visible = true;
                                fecha.Visible = true;
                                label3.Visible = true;
                                label4.Visible = true;
                                label5.Visible = false;
                                label6.Visible = true;
                                num_partidas.Visible = true;
                                Jugadores_ganados.Visible = true;
                                posicion_jugador.Visible = true;
                                invitacion.Visible = true;
                                boton_chat.Visible = false;
                                Tablaconectados.Visible = true;
                                jugador2.Visible = true;
                                jugador3.Visible = true;
                                jugador4.Visible = true;
                                Chat.Visible = false;
                                chatear.Visible = false;
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

                        else
                            MessageBox.Show("No se pueden conectar mas usaurios, intentelo mas tarde");
                        break;

                    case 3:
                        //me da la posicion del jugador

                        MessageBox.Show(trozos[1]);
                        break;

                    case 4:
                        //me da el numero de partidas

                        MessageBox.Show(trozos[1]);
                        break;

                    case 5:
                        //me da vector con los jugadores que ha ganado

                        if (trozos[1] == "Error")
                        {
                            MessageBox.Show("El jugador no esta en la base de datos");
                        }

                        else
                        {
                            MessageBox.Show("Ha ganado a " + trozos[1]);
                        }


                        break;


                    case 6:
                        this.Invoke(new Action(() =>
                        {
                            Tablaconectados.Rows.Clear();
                            Tablaconectados.ColumnCount = 1;
                            Tablaconectados.Columns[0].HeaderText = "User";


                            int numconectados = Convert.ToInt32(trozos[1]);
                            int i = 0;
                            int j = 2;
                            // bucle para escribir los nombres de los conectados en el datagridview

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


                            DialogResult invitar = MessageBox.Show(username.Text + " Quieres aceptar la invitacion de " + trozos[3], "Invitación", MessageBoxButtons.YesNo);
                            if (invitar == DialogResult.Yes)
                            {
                                string respuesta = "Si";
                                string v = "7/" + respuesta + "/" + id_partida;
                                string partida = v;

                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(partida);
                                server.Send(msg);
                            }
                            else if (invitar == DialogResult.No)
                            {
                                string respuesta = "No";
                                string v = "7/" + respuesta + "/" + id_partida;
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
                            ThreadStart ts = delegate { AbrirJuego(); };
                            partida = new Thread(ts);
                            partida.Start();

                            this.Invoke(new Action(() =>
                            {
                                label5.Visible = true;
                                Chat.Visible = true;
                                chatear.Visible = true;
                                boton_chat.Visible = true;
                            }));

                        }


                        break;

                    case 9:

                        this.Invoke(new Action(() =>
                        {
                            Chat.Items.Add(trozos[1] + ": " + trozos[2]);
                        }));
                        break;
                }
            }
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9200);

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
            IPEndPoint ipep = new IPEndPoint(direc, 9300);

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

        private void posicion_jugador_Click(object sender, EventArgs e)
        {
            if (usuario.TextLength > 0 && fecha.TextLength > 0)
            {

                string v = "3/" + usuario.Text + "/" + fecha.Text;
                string mensaje = v;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }

        private void num_partidas_Click(object sender, EventArgs e)
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

        private void Jugadores_ganados_Click(object sender, EventArgs e)
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

        public void AbrirJuego()
        {
            //abrir formulario juego
            Juego juego = new Juego(server);
            juego.ShowDialog();

        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            string v = "0/";
            string mensaje = v;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            atender.Abort();
            this.Invoke(new Action(() =>
            {
                this.BackColor = Color.Gray;
                desconectar.Visible = false;
                usuario.Visible = false;
                fecha.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                num_partidas.Visible = false;
                Jugadores_ganados.Visible = false;
                posicion_jugador.Visible = false;
                invitacion.Visible = false;
                boton_chat.Visible = false;
                Tablaconectados.Visible = false;
                jugador2.Visible = false;
                jugador3.Visible = false;
                jugador4.Visible = false;
                Chat.Visible = false;
                chatear.Visible = false;
                username.Clear();
                password.Clear();
            }));
        }

        private void invitacion_Click(object sender, EventArgs e)
        {
            if (jugador2.TextLength > 0 && jugador3.TextLength > 0 && jugador4.TextLength > 0)
            {

                string v = "6/" + username.Text + "/" + jugador2.Text + "/" + jugador3.Text + "/" + jugador4.Text;
                string mensaje = v;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }

        private void boton_chat_Click(object sender, EventArgs e)
        {
            try
            {
                if (chatear.TextLength > 0)
                {
                    string v = "9/" + id_partida + "/" + username.Text + "/" + chatear.Text;
                    string mensaje = v;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    chatear.Clear();

                }

                else
                {
                    MessageBox.Show(" No ha escrito ningun mensaje o no se ha iniciado ninguna partida");
                }
            }

            catch
            {
                MessageBox.Show("Error al enviar mensaje");
            }
        }
    }
}
