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



namespace WindowsFormsApplication1
{
    public partial class Portada : Form
    {
        Socket server;
        Thread atender;
        DataTable Tabla = new DataTable();
        

        public Portada()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fecha.Visible = false;
            usuario.Visible = false;
            NºPartida.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            posicion_jugador.Visible = false;
            num_partidas.Visible = false;
            GanadorPartida.Visible = false;
            //Conectados.Visible = false;
            desconectar.Visible = false;
            Tablaconectados.Visible = false;
            Tabla.Columns.Add("Nombre del jugador", typeof(string));
        }


        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string [] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);

                
                switch (codigo)
                {
                    case 0: // desconexion correcta

                        

                        break;

                    case 1: //respuesta a si el login se ha realizado correctamente

                        if (trozos[1] == "Correcto")
                        {
                            this.BackColor = Color.Green;
                            MessageBox.Show("SignIn correcto!");
                        }

                        else
                        {
                            MessageBox.Show("No se ha podido hacer el SignIn");
                        }
                        break;

                    case 2: //respuesta a si ha realizado el login correctamente

                        if (trozos[1] == "Correcto")
                        {
                            this.BackColor = Color.Green;
                            MessageBox.Show("Login correcto!");
                            fecha.Visible = true;
                            usuario.Visible = true;
                            NºPartida.Visible = true;
                            label6.Visible = true;
                            label5.Visible = true;
                            label7.Visible = true;
                            posicion_jugador.Visible = true;
                            num_partidas.Visible = true;
                            GanadorPartida.Visible = true;
                            desconectar.Visible = true;

                            string v = "8/";
                            string correcto = v;
                            // Enviamos al servidor el nombre tecleado
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(correcto);
                            server.Send(msg);
                        }

                        else if (trozos[1] == "LLeno")
                            MessageBox.Show("No se pueden conectar mas usaurios, intentelo mas tarde");

                        else
                            MessageBox.Show("No tienes un usuario creado");
                        break;

                    case 3://me da la posicion del jugador

                        MessageBox.Show(trozos[1]);
                        break;

                    case 4://me da el numero de partidas

                        MessageBox.Show(trozos[1]);
                        break;

                    case 5: //posicion jugador

                        MessageBox.Show(trozos[1]);
                        break;

                    
                    case 6:
                        int i = 0;
                        int j = 2;

                        Tabla.Rows.Clear();
                        Tablaconectados.Visible = true;

                        int numconectados = Convert.ToInt32(trozos[1]);
                        

                        while (i < numconectados)
                        {
                            Tabla.Rows.Add(trozos[j]);
                            Tablaconectados.DataSource = Tabla;
                            j++;
                            i++;
                        }
                       
                        Tablaconectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        break;
                }

            }


        }




        private void Signin_Click_1(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50053);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                if (username.TextLength > 0 && password.TextLength > 0)
                {

                    string v = "1/" + username.Text + "/" + password.Text;
                    string mensaje = v;
                    // Enviamos al servidor el nombre tecleado
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

        private void Login_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50053);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                if (username.TextLength > 0 && password.TextLength > 0)
                {
                    string v = "2/" + username.Text + "/" + password.Text;
                    string mensaje = v;
                    // Enviamos al servidor el nombre tecleado
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
                // Enviamos al servidor el nombre tecleado
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
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
            
        }
        private void desconectar_Click(object sender, EventArgs e)
        {
            string v = "0/";
            string mensaje = v;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            atender.Abort();
            this.BackColor = Color.Gray;
            fecha.Visible = false;
            usuario.Visible = false;
            NºPartida.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            posicion_jugador.Visible = false;
            num_partidas.Visible = false;
            GanadorPartida.Visible = false;
            //Conectados.Visible = false;
            desconectar.Visible = false;
            Tablaconectados.Visible = false;


        }

        private void GanadorPartida_Click(object sender, EventArgs e)
        {
            if (NºPartida.TextLength > 0)
            {

                string v = "5/" + NºPartida.Text;
                string mensaje = v;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
            
        }

    }
}
