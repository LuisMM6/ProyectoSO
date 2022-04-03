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


namespace WindowsFormsApplication1
{
    public partial class Portada : Form
    {
        Socket server;
        DataTable Tabla = new DataTable();
        public Portada()
        {
            InitializeComponent();
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
            Conectados.Visible = false;
            desconectar.Visible = false;
            Tablaconectados.Visible = false;
        }

       

        private void Signin_Click_1(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9000);

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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    if (mensaje == "Correcto")
                    {
                        this.BackColor = Color.Green;
                        MessageBox.Show("SignIn correcto!");
                    }

                    else 
                        MessageBox.Show("No se ha podido hacer el SignIn");

                }
                else
                {
                    MessageBox.Show(" Parametros no escritos ");
                }
            }

            catch (SocketException )
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
         
            
            
        }


        private void Login_Click(object sender, EventArgs e)
        {
   


            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9000);


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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    if (mensaje == "Correcto")
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
                        Conectados.Visible = true;
                        desconectar.Visible = true;
                    }

                    else if (mensaje == "LLeno")
                        MessageBox.Show("No se pueden conectar mas usaurios, intentelo mas tarde");

                    else
                        MessageBox.Show("No tienes un usuario creado");
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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show(mensaje);
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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show(mensaje);

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
            Conectados.Visible = false;
            desconectar.Visible = false;
            Tablaconectados.Visible = false;

            if (mensaje == "No encontrado")
            {
                MessageBox.Show(" No estaba conectado ");
            }

            else
            {

            }

        }

        private void GanadorPartida_Click(object sender, EventArgs e)
        {
             if (NºPartida.TextLength > 0)
            {

                string v = "5/" + NºPartida.Text ;
                string mensaje = v;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }

        private void Conectados_Click(object sender, EventArgs e)
        {
            
            Tablaconectados.Visible = true;
            Tabla.Columns.Add("Nombre del jugador", typeof(string));

            string v = "6/";
            string mensaje = v;
            //Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            

            int i = 0;
            int j = 1;
            string[] vect = mensaje.Split('/');
            int numconectados = Convert.ToInt32(vect[0]);

            while (i < numconectados)
            {
                Tabla.Rows.Add(vect[j]);
                Tablaconectados.DataSource = Tabla;
                j++;
                i++;
            }
            Tablaconectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
