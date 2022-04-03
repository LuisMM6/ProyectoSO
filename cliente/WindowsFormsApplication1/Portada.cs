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
        public Portada()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9555);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
            }

            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }



            if (username.TextLength > 0 && password.TextLength > 0)
            {
                string v = "2/"+username.Text+"/"+password.Text;
                string mensaje = v;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "Correcto")
                    MessageBox.Show("Login correcto!");
              
                else
                    MessageBox.Show("No tienes un usuario creado");
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
            }
        }

        private void Signin_Click_1(object sender, EventArgs e)
        {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9555);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
            }

            catch (SocketException )
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
         
            
            if (username.TextLength > 0 && password.TextLength > 0)
            {
              
                string v = "1/"+username.Text+"/"+password.Text;
                string mensaje = v;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "Correcto")
                    MessageBox.Show("SignIn correcto!");
                else
                    MessageBox.Show ("No se ha podido hacer el SignIn");
            }
            else
            {
                MessageBox.Show(" Parametros no escritos ");
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

        

      

    }
}
