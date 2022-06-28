using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace SO_Proyecto
{
    public partial class Juego : Form
    {

        Random rand = new Random();
        Socket server;

        // numero de form de la partida
        int nForm;

        // numero que identifica la partida 
        int idpartida;

        // nombre jugador que esta usando el cliente
        string user;

        // numero del jugador en la partida
        int idjugador;

        // nombre 4 jugadores 
        string user1;
        string user2;
        string user3;
        string user4;

        // casillas jugadores
        int casilla1;
        int casilla2;
        int casilla3;
        int casilla4;

        // dinero 4 jugadores
        int dinero1 = 5000;
        int dinero2 = 5000;
        int dinero3 = 5000;
        int dinero4 = 5000;

        // numero del turno actual
        int turno;

        // numero de propiedades compradas
        int num_propiedades;


        // PRECIOS (0 a 39, 40 en total):
        int[] Precios = { 0, 60, 60, 65, 65, 0, 100, 100, 120, 120, 0, 140, 140, 150, 160, 0, 180, 180, 200, 200, 0, 220, 220, 240, 240, 0, 260, 260, 280, 280, 0, 300, 300, 320, 320, 0, 350, 350, 400, 500 };

        //Pagos
        int[] Pagos = { 0, 20, 20, 20, 20, 0, 20, 20, 20, 20, 0, 30, 30, 30, 30, 0, 30, 30, 30, 30, 0, 40, 40, 40, 40, 0, 40, 40, 40, 40, 0, 50, 50, 50, 50, 0, 50, 50, 50, 50 };
        //Lo que pagara un jugador que cae en una casilla con propietario


        // PROPIETARIOS (0 a 39, 40 en total), al empezar vacíos:
        string[] Propietario = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        // SALIDA, CÁRCEL, "MERCADONA", SEGURATA, NO PUEDEN TENER PROPIETARIOS:


        // NOMBRES DE LAS CASILLAS:
        string[] NombreCarrera = { "Salida", "Ed.Infantil", "Filosofía", "ADE", "Humanidades", "Florida", "B.Artes", "Ed.Social", "Cinematografía", "Turismo", "Biblio", "Periodismo", "Filología Hispánica", "Comunicación Audiovisual", "Psicología", "Castefa", "Economia", "Criminología", "Arqueología", "Diseño", "Merca/Playa", "Lingüística", "Fisioterapia", "Geografía", "Geología", "Diagonal", "Odontología", "Derecho", "Enfermería", "Química", "Poli", "Medicina", "Arquitectura", "Ingeniería de Telecos", "Ingeniería de Aeros", "SantCugat", "Matemáticas", "Física", "Doble Grado Informática y Matemáticas", "Doble Grado Matemáticas y Física" };

        // VECTOR QUE NOS DICE SI UNA CASILLA ES UNA MATERIA O NO:
        bool[] Carrera = { false, true, true, true, true, false, true, true, true, true, false, true, true, true, true, false, true, true, true, true, false, true, true, true, true, false, true, true, true, true, false, true, true, true, true, false, true, true, true, true };

        // VECTOR QUE NOS DICE SI UNA CASILLA ES DE ESTACION:
        bool[] CasillasEstacion = { false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false };

        // VECTOR QUE NOs DICE SI HEMOS CAIDO EN LA CASILLA MERCADONA/PLAYA
        bool[] CasillaDescanso = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        // VECTOR QUE NOs DICE SI HEMOS CAIDO EN LA CASILLA POLICIA
        bool[] CasillaPolicia = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false };

        // VECTOR QUE NOs DICE SI HEMOS CAIDO EN LA CASILLA BIBLIO
        bool[] CasillaBiblio = { false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        // resultados de la partida finalizada

        string nomP1; int dineroP1;
        string nomP2; int dineroP2;
        string nomP3; int dineroP3;
        string nomP4; int dineroP4;

        int finalizar;
        public Juego(Socket server, int nForm, int idpartida, string user, string user1, string user2, string user3, string user4, int idjugador)
        {
            InitializeComponent();
            this.server = server;
            this.nForm = nForm;
            this.idpartida = idpartida;
            this.user = user;
            this.user1 = user1;
            this.user2 = user2;
            this.user3 = user3;
            this.user4 = user4;
            this.idjugador = idjugador;

        }

        private void Juego_Load(object sender, EventArgs e)
        {
            // declaracion de las variables globales, intervalos de los timers, dinero inicial de los jugadores.....

            


           
            panel11.Visible = false;
            mensa_salida.Visible = false;
            mensaj_salida.Visible = false;
            ganadores.Visible = false;
            primero.Visible = false;
            segundo.Visible = false;
            tercero.Visible = false;


            gametime.Interval = 1000;
            gametime.Start();


            num_propiedades = 0;

            casilla1 = 0;
            casilla2 = 0;
            casilla3 = 0;
            casilla4 = 0;


            money1.Text = Convert.ToString(dinero1);
            money2.Text = Convert.ToString(dinero2);
            money3.Text = Convert.ToString(dinero3);
            money4.Text = Convert.ToString(dinero4);


            this.Invoke(new Action(() =>
            {
                jugador.Text = user;

                player1.Text = user1;
                player2.Text = user2;
                player3.Text = user3;
                player4.Text = user4;

                if (user == user1)
                {
                    money.Text = Convert.ToString(dinero1);
                }
                else if (user == user2)
                {
                    money.Text = Convert.ToString(dinero2);
                }
                else if (user == user3)
                {
                    money.Text = Convert.ToString(dinero3);
                }
                else if (user == user4)
                {
                    money.Text = Convert.ToString(dinero4);
                }




                if (idjugador == 1)
                {
                    dado.Enabled = true;
                }

                else
                {
                    dado.Enabled = false;
                }

                turno = 1;
                flecha1.Visible = true;
                flecha2.Visible = false;
                flecha3.Visible = false;
                flecha4.Visible = false;

            }));



        }


        private void send_Click(object sender, EventArgs e)

        // enviar el nuevo mensaje que se mostrara en el chat

        {
            try
            {
                if (hablar.TextLength > 0)
                {
                    string v = "9/" + nForm + "/" + idpartida + "/" + user + "/" + hablar.Text;
                    string mensaje = v;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    hablar.Clear();

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

        public void Chatear(string nombre, string texto)

        // muestra los nuevos mensajes en el chat

        {
            this.Invoke(new Action(() =>
            {
                Chat.Items.Add(nombre + ": " + texto);
            }));
        }

        public void CasillaNueva(int nC, int idUser) // nC: numCasilla.
        {
            int preciodecompra = Precios[nC];
            string propietario = Propietario[nC];


            //CASILLA DEL TIPO RENFE:

            if (CasillasEstacion[nC] == true) // Si estamos en una casilla del tipo Renfe:
            {

                if (nC == 5)  // parada de metro la florida
                {
                  
                    MessageBox.Show("¡¡¡¡Te roban todo lo que llevas!!!!", "Florida");


                    if (idjugador == 1)
                    {
                        dinero1 = dinero1 - 400;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero1;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 2)
                    {
                        dinero2 = dinero2 - 400;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero2;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 3)
                    {
                        dinero3 = dinero3 - 400;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero3;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 4)
                    {
                        dinero4 = dinero4 - 400;

                        //// Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero4;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                }

                if (nC == 15) // parada de metro la castefa
                {
                    MessageBox.Show("Te roban el portátil", "Castelldefels");

                    if (idjugador == 1)
                    {
                        dinero1 = dinero1 - 200;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero1;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 2)
                    {
                        dinero2 = dinero2 - 200;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero2;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 3)
                    {
                        dinero3 = dinero3 - 200;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero3;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 4)
                    {
                        dinero4 = dinero4 - 200;

                        //// Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero4;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                }


                if (nC == 25) // parada de metro diagonal
                {
                    MessageBox.Show("Te encuentras dinero en el suelo", "Diagonal");

                    if (idjugador == 1)
                    {
                        dinero1 = dinero1 + 200;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero1;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 2)
                    {
                        dinero2 = dinero2 + 200;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero2;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 3)
                    {
                        dinero3 = dinero3 + 200;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero3;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 4)
                    {
                        dinero4 = dinero4 + 200;

                        //// Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero4;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                }


                if (nC == 35) // parada de metro santcugat
                {
                    MessageBox.Show("Te donan dinero para invertir", "Sant Cugat");

                    if (idjugador == 1)
                    {
                        dinero1 = dinero1 + 400;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero1;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 2)
                    {
                        dinero2 = dinero2 + 400;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero2;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 3)
                    {
                        dinero3 = dinero3 + 400;

                        // Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero3;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                    else if (idjugador == 4)
                    {
                        dinero4 = dinero4 + 400;

                        //// Mensaje para actualizar el dinero:

                        string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero4;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);

                    }
                }

            }

            // CASILLA DEL TIPO Mercadona/Playa:

            if (CasillaDescanso[nC] == true) // Si estamos en la casilla:
            {
                MessageBox.Show("Recibes un merecido descanso", "Mercadona/Playa");
            }

            // CASILLA DEL TIPO BIBLIO

            if (CasillaBiblio[nC] == true) // Si estamos en la casilla:
            {
                MessageBox.Show("¡¡A estudiar!!", "Biblioteca");
            }

            // CASILLA DEL TIPO POLI

            if (CasillaPolicia[nC] == true) // Si estamos en la casilla:
            {
                MessageBox.Show("Te arrestan por no aprobar", "Policia");
            }

            // CASILLAS CARRERAS

            if (Carrera[nC] == true)
            {
                if (propietario == "") // no tiene propietario
                {
                    if (idjugador == 1)
                    {
                        if (Precios[nC] <= dinero1)
                        {
                            DialogResult pregunta = MessageBox.Show("Te gustaria comprar " + NombreCarrera[nC] + " que tiene un precio de: " + Precios[nC], "?", MessageBoxButtons.YesNo);
                            if (pregunta == DialogResult.Yes)
                            {
                                dinero1 = dinero1 - Precios[nC];

                                string missatge = "13/" + idpartida + "/" + idjugador + "/" + dinero1 + "/" + nC + "/" + user1;
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                                server.Send(msg);
                            }
                            else if (pregunta == DialogResult.No)
                            {

                            }
                        }
                    }

                    if (idjugador == 2)
                    {
                        if (Precios[nC] <= dinero2)
                        {
                            DialogResult pregunta = MessageBox.Show("Te gustaria comprar " + NombreCarrera[nC] + " que tiene un precio de: " + Precios[nC], "?", MessageBoxButtons.YesNo);
                            if (pregunta == DialogResult.Yes)
                            {
                                dinero2 = dinero2 - Precios[nC];

                                string missatge = "13/" + idpartida + "/" + idjugador + "/" + dinero2 + "/" + nC + "/" + user2;
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                                server.Send(msg);
                            }
                            else if (pregunta == DialogResult.No)
                            {

                            }
                        }
                    }

                    if (idjugador == 3)
                    {
                        if (Precios[nC] <= dinero3)
                        {
                            DialogResult pregunta = MessageBox.Show("Te gustaria comprar " + NombreCarrera[nC] + " que tiene un precio de: " + Precios[nC], "?", MessageBoxButtons.YesNo);
                            if (pregunta == DialogResult.Yes)
                            {
                                dinero3 = dinero3 - Precios[nC];

                                string missatge = "13/" + idpartida + "/" + idjugador + "/" + dinero3 + "/" + nC + "/" + user3;
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                                server.Send(msg);
                            }
                            else if (pregunta == DialogResult.No)
                            {

                            }
                        }
                    }

                    if (idjugador == 4)
                    {
                        if (Precios[nC] <= dinero4)
                        {
                            DialogResult pregunta = MessageBox.Show("Te gustaria comprar " + NombreCarrera[nC] + " que tiene un precio de: " + Precios[nC], "?", MessageBoxButtons.YesNo);
                            if (pregunta == DialogResult.Yes)
                            {
                                dinero4 = dinero4 - Precios[nC];

                                string missatge = "13/" + idpartida + "/" + idjugador + "/" + dinero4 + "/" + nC + "/" + user4;
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                                server.Send(msg);
                            }
                            else if (pregunta == DialogResult.No)
                            {

                            }
                        }
                    }

                }
                else //tiene propietario
                {
                    string owner = Propietario[nC];
                    int preciocasilla = Pagos[nC];


                    if (idjugador == 1)
                    {
                        MessageBox.Show("Esta casilla tiene propietario. Lo siento.");

                        string missatge = "14/" + idpartida + "/" + idjugador + "/" + preciocasilla + "/" + nC + "/" + user1 + "/" + owner;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);
                    }

                    if (idjugador == 2)
                    {
                        MessageBox.Show("Esta casilla tiene propietario. Lo siento.");

                        string missatge = "14/" + idpartida + "/" + idjugador + "/" + preciocasilla + "/" + nC + "/" + user2 + "/" + owner;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);
                    }

                    if (idjugador == 3)
                    {
                        MessageBox.Show("Esta casilla tiene propietario. Lo siento.");

                        string missatge = "14/" + idpartida + "/" + idjugador + "/" + preciocasilla + "/" + nC + "/" + user3 + "/" + owner;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);
                    }

                    if (idjugador == 4)
                    {
                        MessageBox.Show("Esta casilla tiene propietario. Lo siento.");

                        string missatge = "14/" + idpartida + "/" + idjugador + "/" + preciocasilla + "/" + nC + "/" + user4 + "/" + owner;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(missatge);
                        server.Send(msg);
                    }
                }

            }


        }
        public void Turnos(int turno)
        {
            if (turno == idjugador) // Es nuestro turno...
            {

                dado.Enabled = true;

                if (idjugador == 1)
                {

                    flecha1.Visible = true;
                    flecha2.Visible = false;
                    flecha3.Visible = false;
                    flecha4.Visible = false;

                }

                else if (idjugador == 2)
                {

                    flecha1.Visible = false;
                    flecha2.Visible = true;
                    flecha3.Visible = false;
                    flecha4.Visible = false;
                }

                else if (idjugador == 3)
                {

                    flecha1.Visible = false;
                    flecha2.Visible = false;
                    flecha3.Visible = true;
                    flecha4.Visible = false;

                }

                else if (idjugador == 4)
                {

                    flecha1.Visible = false;
                    flecha2.Visible = false;
                    flecha3.Visible = false;
                    flecha4.Visible = true;

                }
            }
            else // Si no es nuestro turno ...
            {

                dado.Enabled = false;

                if (turno == 1)
                {

                    flecha1.Visible = true;
                    flecha2.Visible = false;
                    flecha3.Visible = false;
                    flecha4.Visible = false;

                }

                else if (turno == 2)
                {

                    flecha1.Visible = false;
                    flecha2.Visible = true;
                    flecha3.Visible = false;
                    flecha4.Visible = false;
                }

                else if (turno == 3)
                {
                    flecha1.Visible = false;
                    flecha2.Visible = false;
                    flecha3.Visible = true;
                    flecha4.Visible = false;
                }

                else if (turno == 4)
                {
                    flecha1.Visible = false;
                    flecha2.Visible = false;
                    flecha3.Visible = false;
                    flecha4.Visible = true;
                }
            }

        }
        int getCoordinate(string name)

            // nos da las coordenadas de la nueva posoicion dependiendo del jugador y la casilla
        {

            // Vector con todas las coordenadas.
            int[] listaCoordenadas = { 617, 615, 561, 615, 511, 615, 454, 615, 396, 612, 342, 615, 286, 615, 230, 615, 173, 615, 116, 615, 41, 621, 70, 564, 70, 506, 70, 452, 70, 394, 70, 341, 70, 284, 70, 226, 70, 168, 70, 115, 63, 46, 117, 70, 173, 70, 229, 70, 285, 70, 345, 70, 400, 70, 455, 70, 510, 70, 565, 70, 632, 70, 617, 115, 617, 171, 617, 227, 617, 285, 617, 342, 617, 400, 617, 452, 617, 506, 617, 565, 660, 615, 566, 632, 510, 632, 454, 632, 400, 632, 342, 632, 284, 632, 228, 632, 173, 632, 116, 632, 20, 626, 45, 562, 45, 509, 45, 453, 45, 395, 45, 340, 45, 284, 45, 227, 45, 171, 45, 120, 45, 25, 115, 45, 173, 45, 230, 45, 285, 45, 344, 41, 400, 45, 455, 45, 510, 45, 565, 45, 660, 50, 640, 120, 640, 172, 640, 230, 640, 285, 640, 345, 640, 400, 640, 450, 640, 506, 640, 563, 617, 655, 565, 655, 510, 655, 454, 655, 400, 655, 342, 655, 286, 655, 230, 655, 173, 655, 116, 655, 20, 655, 30, 564, 30, 506, 30, 452, 30, 394, 30, 341, 30, 284, 30, 226, 30, 168, 30, 115, 30, 25, 120, 30, 173, 30, 229, 30, 285, 30, 345, 30, 400, 30, 455, 30, 510, 30, 565, 30, 632, 30, 660, 120, 660, 172, 660, 230, 660, 285, 660, 345, 660, 400, 660, 450, 660, 506, 660, 563, 660, 650, 565, 650, 510, 650, 454, 650, 400, 650, 342, 650, 286, 650, 230, 650, 173, 650, 116, 650, 60, 650, 15, 562, 15, 509, 15, 453, 15, 395, 15, 340, 15, 284, 15, 227, 15, 171, 15, 120, 15, 65, 115, 15, 173, 15, 229, 15, 285, 15, 345, 15, 400, 15, 455, 15, 510, 15, 565, 15, 666, 20, 675, 115, 675, 172, 675, 230, 675, 285, 675, 345, 675, 400, 675, 450, 675, 506, 675, 563 };
            // Vector con los nombres de las coordenadas.
            string[] listaNombres = { "j1c0_X", "j1c0_Y", "j1c1_X", "j1c1_Y", "j1c2_X", "j1c2_Y", "j1c3_X", "j1c3_Y", "j1c4_X", "j1c4_Y", "j1c5_X", "j1c5_Y", "j1c6_X", "j1c6_Y", "j1c7_X", "j1c7_Y", "j1c8_X", "j1c8_Y", "j1c9_X", "j1c9_Y", "j1c10_X", "j1c10_Y", "j1c11_X", "j1c11_Y", "j1c12_X", "j1c12_Y", "j1c13_X", "j1c13_Y", "j1c14_X", "j1c14_Y", "j1c15_X", "j1c15_Y", "j1c16_X", "j1c16_Y", "j1c17_X", "j1c17_Y", "j1c18_X", "j1c18_Y", "j1c19_X", "j1c19_Y", "j1c20_X", "j1c20_Y", "j1c21_X", "j1c21_Y", "j1c22_X", "j1c22_Y", "j1c23_X", "j1c23_Y", "j1c24_X", "j1c24_Y", "j1c25_X", "j1c25_Y", "j1c26_X", "j1c26_Y", "j1c27_X", "j1c27_Y", "j1c28_X", "j1c28_Y", "j1c29_X", "j1c29_Y", "j1c30_X", "j1c30_Y", "j1c31_X", "j1c31_Y", "j1c32_X", "j1c32_Y", "j1c33_X", "j1c33_Y", "j1c34_X", "j1c34_Y", "j1c35_X", "j1c35_Y", "j1c36_X", "j1c36_Y", "j1c37_X", "j1c37_Y", "j1c38_X", "j1c38_Y", "j1c39_X", "j1c39_Y", "j2c0_X", "j2c0_Y", "j2c1_X", "j2c1_Y", "j2c2_X", "j2c2_Y", "j2c3_X", "j2c3_Y", "j2c4_X", "j2c4_Y", "j2c5_X", "j2c5_Y", "j2c6_X", "j2c6_Y", "j2c7_X", "j2c7_Y", "j2c8_X", "j2c8_Y", "j2c9_X", "j2c9_Y", "j2c10_X", "j2c10_Y", "j2c11_X", "j2c11_Y", "j2c12_X", "j2c12_Y", "j2c13_X", "j2c13_Y", "j2c14_X", "j2c14_Y", "j2c15_X", "j2c15_Y", "j2c16_X", "j2c16_Y", "j2c17_X", "j2c17_Y", "j2c18_X", "j2c18_Y", "j2c19_X", "j2c19_Y", "j2c20_X", "j2c20_Y", "j2c21_X", "j2c21_Y", "j2c22_X", "j2c22_Y", "j2c23_X", "j2c23_Y", "j2c24_X", "j2c24_Y", "j2c25_X", "j2c25_Y", "j2c26_X", "j2c26_Y", "j2c27_X", "j2c27_Y", "j2c28_X", "j2c28_Y", "j2c29_X", "j2c29_Y", "j2c30_X", "j2c30_Y", "j2c31_X", "j2c31_Y", "j2c32_X", "j2c32_Y", "j2c33_X", "j2c33_Y", "j2c34_X", "j2c34_Y", "j2c35_X", "j2c35_Y", "j2c36_X", "j2c36_Y", "j2c37_X", "j2c37_Y", "j2c38_X", "j2c38_Y", "j2c39_X", "j2c39_Y", "j3c0_X", "j3c0_Y", "j3c1_X", "j3c1_Y", "j3c2_X", "j3c2_Y", "j3c3_X", "j3c3_Y", "j3c4_X", "j3c4_Y", "j3c5_X", "j3c5_Y", "j3c6_X", "j3c6_Y", "j3c7_X", "j3c7_Y", "j3c8_X", "j3c8_Y", "j3c9_X", "j3c9_Y", "j3c10_X", "j3c10_Y", "j3c11_X", "j3c11_Y", "j3c12_X", "j3c12_Y", "j3c13_X", "j3c13_Y", "j3c14_X", "j3c14_Y", "j3c15_X", "j3c15_Y", "j3c16_X", "j3c16_Y", "j3c17_X", "j3c17_Y", "j3c18_X", "j3c18_Y", "j3c19_X", "j3c19_Y", "j3c20_X", "j3c20_Y", "j3c21_X", "j3c21_Y", "j3c22_X", "j3c22_Y", "j3c23_X", "j3c23_Y", "j3c24_X", "j3c24_Y", "j3c25_X", "j3c25_Y", "j3c26_X", "j3c26_Y", "j3c27_X", "j3c27_Y", "j3c28_X", "j3c28_Y", "j3c29_X", "j3c29_Y", "j3c30_X", "j3c30_Y", "j3c31_X", "j3c31_Y", "j3c32_X", "j3c32_Y", "j3c33_X", "j3c33_Y", "j3c34_X", "j3c34_Y", "j3c35_X", "j3c35_Y", "j3c36_X", "j3c36_Y", "j3c37_X", "j3c37_Y", "j3c38_X", "j3c38_Y", "j3c39_X", "j3c39_Y", "j4c0_X", "j4c0_Y", "j4c1_X", "j4c1_Y", "j4c2_X", "j4c2_Y", "j4c3_X", "j4c3_Y", "j4c4_X", "j4c4_Y", "j4c5_X", "j4c5_Y", "j4c6_X", "j4c6_Y", "j4c7_X", "j4c7_Y", "j4c8_X", "j4c8_Y", "j4c9_X", "j4c9_Y", "j4c10_X", "j4c10_Y", "j4c11_X", "j4c11_Y", "j4c12_X", "j4c12_Y", "j4c13_X", "j4c13_Y", "j4c14_X", "j4c14_Y", "j4c15_X", "j4c15_Y", "j4c16_X", "j4c16_Y", "j4c17_X", "j4c17_Y", "j4c18_X", "j4c18_Y", "j4c19_X", "j4c19_Y", "j4c20_X", "j4c20_Y", "j4c21_X", "j4c21_Y", "j4c22_X", "j4c22_Y", "j4c23_X", "j4c23_Y", "j4c24_X", "j4c24_Y", "j4c25_X", "j4c25_Y", "j4c26_X", "j4c26_Y", "j4c27_X", "j4c27_Y", "j4c28_X", "j4c28_Y", "j4c29_X", "j4c29_Y", "j4c30_X", "j4c30_Y", "j4c31_X", "j4c31_Y", "j4c32_X", "j4c32_Y", "j4c33_X", "j4c33_Y", "j4c34_X", "j4c34_Y", "j4c35_X", "j4c35_Y", "j4c36_X", "j4c36_Y", "j4c37_X", "j4c37_Y", "j4c38_X", "j4c38_Y", "j4c39_X", "j4c39_Y" };

            int coordinate = 0;

            for (int i = 0; i < listaNombres.Length; i++)
            {
                if (name == listaNombres[i])
                {
                    coordinate = listaCoordenadas[i];
                    break;
                }
            }

            return coordinate;
        }

        public void ActualizarDinero(int idjuga, int dinero)

        // acutaliza el dinero de los labels del tablero de los jugadores

        {
            if (idjuga == 1)
            {
                dinero1 = dinero;
                money1.Text = Convert.ToString(dinero);
            }
            else if (idjuga == 2)
            {
                dinero2 = dinero;
                money2.Text = Convert.ToString(dinero);

            }
            else if (idjuga == 3)
            {
                dinero3 = dinero;
                money3.Text = Convert.ToString(dinero);
            }
            else if (idjuga == 4)
            {
                dinero4 = dinero;
                money4.Text = Convert.ToString(dinero);
            }

            if (idjuga == idjugador)
            {
                money.Text = Convert.ToString(dinero);
            }
        }

        public void ComprarCasilla(int idj, int dinero, int casilla, string jugador)

            // assignar un propietario a la casilla comprada y actualizar dinero del comprador

        {
            ActualizarDinero(idj, dinero);
            Propietario[casilla] = jugador;
            num_propiedades = num_propiedades + 1;

            if (num_propiedades == 32)

                // si todas las casillas estan compradas, se acabara la partida automaticamente y se enviaran los datos
            {
                MessageBox.Show("Partida finaliza por la compra de todas las propiedades, se mostraran los resultados");
                gametime.Stop();
                gameturn.Stop();
                dado.Enabled = false;

                if (idjugador == 1) // solo el primer jugador de la partida, guarda los datos y los envia
                {
                    GuradarDatos();
                }
               
            }

            else
            {
                if (jugador == user)
                {
                    this.Invoke(new Action(() =>
                    {
                        ActualizaTablaPropiedades(jugador);
                    }));
                }

            }

        }

        public void Pagar_Propietario(int idj, int preciocasilla, int casilla, string jugador, string owner)
        {
            // Actualizar el dinero del jugador que ha caido en la casilla con propietario
            if (idj == 1)
            {
                dinero1 = dinero1 - preciocasilla;
                ActualizarDinero(idj, dinero1);
            }

            if (idj == 2)
            {
                dinero2 = dinero2 - preciocasilla;
                ActualizarDinero(idj, dinero2);
            }

            if (idj == 3)
            {
                dinero3 = dinero3 - preciocasilla;
                ActualizarDinero(idj, dinero3);
            }

            if (idj == 4)
            {
                dinero4 = dinero4 - preciocasilla;
                ActualizarDinero(idj, dinero4);
            }

            // Actualizar el  dinero del propietario de la casilla
            int jugad;

            if (user1 == owner)
            {
                jugad = 1;
                dinero1 = dinero1 + preciocasilla;
                ActualizarDinero(jugad, dinero1);
            }

            else if (user2 == owner)
            {
                jugad = 2;
                dinero2 = dinero2 + preciocasilla;
                ActualizarDinero(jugad, dinero2);
            }

            else if (user3 == owner)
            {
                jugad = 3;
                dinero3 = dinero3 + preciocasilla;
                ActualizarDinero(jugad, dinero3);
            }

            else if (user4 == owner)
            {
                jugad = 4;
                dinero4 = dinero4 + preciocasilla;
                ActualizarDinero(jugad, dinero4);
            }



        }

        public void moverFicha(int desplazamiento)
        {

            int numMov = desplazamiento; // AQUÍ PONEMOS CUANTAS CASILLAS SE DESPLAZA.
            string PosX = ""; // Por ejemplo, 'j1c38_X'.
            string PosY = ""; // Por ejemplo, 'j1c38_Y'.

            if (idjugador == 1)
            {
                casilla1 = casilla1 + numMov;

                if (casilla1 >= 40) //Casilla Salida
                {
                    casilla1 = casilla1 - 40;
                    dinero1 = dinero1 + 200; // pasar por casilla de salida

                    //// Mensaje para actualizar el dinero:

                    string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero1;
                    byte[] msgd = System.Text.Encoding.ASCII.GetBytes(missatge);
                    server.Send(msgd);

                }

                else if (casilla1 == 30) // Casilla Policia
                {
                    casilla1 = 10; // vas a la biblio
                }


                PosX = $"j{idjugador}c{casilla1}_X";
                PosY = $"j{idjugador}c{casilla1}_Y";
            }
            else if (idjugador == 2)
            {
                casilla2 = casilla2 + numMov;

                if (casilla2 >= 40) //Casilla Salida
                {
                    casilla2 = casilla2 - 40;
                    dinero2 = dinero2 + 200; // pasar por casilla de salida

                    //// Mensaje para actualizar el dinero:

                    string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero2;
                    byte[] msgd = System.Text.Encoding.ASCII.GetBytes(missatge);
                    server.Send(msgd);

                }

                else if (casilla2 == 30) // Casilla Policia
                {
                    casilla2 = 10; // vas a la biblio
                }

                PosX = $"j{idjugador}c{casilla2}_X";
                PosY = $"j{idjugador}c{casilla2}_Y";

            }
            else if (idjugador == 3)
            {
                casilla3 = casilla3 + numMov;

                if (casilla3 >= 40) //Casilla Salida
                {
                    casilla3 = casilla3 - 40;
                    dinero3 = dinero3 + 200; // pasar por casilla de salida

                    //// Mensaje para actualizar el dinero:

                    string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero3;
                    byte[] msgd = System.Text.Encoding.ASCII.GetBytes(missatge);
                    server.Send(msgd);

                }

                else if (casilla3 == 30) // Casilla Policia
                {
                    casilla3 = 10; // vas a la biblio
                }

                PosX = $"j{idjugador}c{casilla3}_X";
                PosY = $"j{idjugador}c{casilla3}_Y";
            }
            else if (idjugador == 4)
            {
                casilla4 = casilla4 + numMov;

                if (casilla4 >= 40) //Casilla Salida
                {
                    casilla4 = casilla4 - 40;
                    dinero4 = dinero4 + 200; // pasar por casilla de salida

                    //// Mensaje para actualizar el dinero:

                    string missatge = "12/" + idpartida + "/" + idjugador + "/" + dinero4;
                    byte[] msgd = System.Text.Encoding.ASCII.GetBytes(missatge);
                    server.Send(msgd);

                }

                else if (casilla4 == 30) // Casilla Policia
                {
                    casilla4 = 10; // vas a la biblio
                }

                PosX = $"j{idjugador}c{casilla4}_X";
                PosY = $"j{idjugador}c{casilla4}_Y";

            }

            int posX = getCoordinate(PosX);
            int posY = getCoordinate(PosY);

            //enviar la nueva posicion a los demas jugadores 
            string movimiento = "10/" + idpartida + "/" + idjugador + "/" + posX + "/" + posY + "/" + turno;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimiento);
            server.Send(msg);

        }

        public void PasarMovimiento(int idjugador, int posX, int posY, int turno_actual)
        {
            // recibe la nueva posicion del jugador
            // mueve la ficha y avisa de inicio de un nuevo turno

            turno = turno_actual;

            if (idjugador == 1)
            {
                Fitxa1.Location = new Point(posX, posY);
                CasillaNueva(casilla1, idjugador);
            }
            else if (idjugador == 2)
            {
                Fitxa2.Location = new Point(posX, posY);
                CasillaNueva(casilla2, idjugador);
            }
            else if (idjugador == 3)
            {
                Fitxa3.Location = new Point(posX, posY);
                CasillaNueva(casilla3, idjugador);
            }
            else if (idjugador == 4)
            {
                Fitxa4.Location = new Point(posX, posY);
                CasillaNueva(casilla4, idjugador);
            }


            Turnos(turno);

        }



        private void dado_Click(object sender, EventArgs e)

        // tirar el dado y avisar a l funcion para mover la ficha las casillas correspondientes
        {
            
            Random myObject = new Random();

            int Num = myObject.Next(1, 7);

            //t_inicio = hora.Text.Split(':');

            if (turno == 4)
            {
                turno = 1;
            }
            else
            {
                turno = turno + 1;
            }


            if (Num == 1)
            {
                dado.BackgroundImage = Properties.Resources.Dado1;
                moverFicha(1);
            }
            else if (Num == 2)
            {
                dado.BackgroundImage = Properties.Resources.Dado2;
                moverFicha(2);
            }
            else if (Num == 3)
            {
                dado.BackgroundImage = Properties.Resources.Dado3;
                moverFicha(3);
            }
            else if (Num == 4)
            {
                dado.BackgroundImage = Properties.Resources.Dado4;
                moverFicha(4);
            }
            else if (Num == 5)
            {
                dado.BackgroundImage = Properties.Resources.Dado5;
                moverFicha(5);
            }
            else
            {
                dado.BackgroundImage = Properties.Resources.Dado6;
                moverFicha(6);
            }

            // Desactivamos el dado (solo se puede usar una vez) ...
            dado.Enabled = false;

        }

        public void ActualizaTablaPropiedades(string jugador)

        // mostrar la tabla con tus propiedades compradas
        {

            TablaPropiedades.Rows.Clear();
            TablaPropiedades.ColumnCount = 1;
            TablaPropiedades.Columns[0].HeaderText = "Propiedades";
            TablaPropiedades.RowHeadersVisible = false;
            TablaPropiedades.BackgroundColor = Color.White;
            TablaPropiedades.DefaultCellStyle.SelectionBackColor = TablaPropiedades.DefaultCellStyle.BackColor;
            TablaPropiedades.DefaultCellStyle.SelectionForeColor = TablaPropiedades.DefaultCellStyle.ForeColor;
            TablaPropiedades.EnableHeadersVisualStyles = false;
            TablaPropiedades.Columns[0].HeaderCell.Style.BackColor = Color.LightBlue;

            int i = 0;

            while (i < Propietario.Length)
            {
                if (Propietario[i] == jugador)
                {
                    TablaPropiedades.Rows.Add(NombreCarrera[i]);
                }

                i++;
            }


            TablaPropiedades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        public void GuradarDatos()

           // enviar los puntos de cada jugador y el timepo de partida al servidor para guardar la partida
        {
            BuscarGanador();
           
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");

            string finalpartida = "17/" + idpartida + "/" + nomP1 + "/" + dineroP1 + "/" + nomP2 + "/" + dineroP2 + "/" + nomP3 + "/" + dineroP3 + "/" + nomP4 + "/" + dineroP4 + "/" + fecha;

            byte[] finpartida = System.Text.Encoding.ASCII.GetBytes(finalpartida);
            server.Send(finpartida);
        }

        public void BuscarGanador()

            // mirar quin es el jugador con mas puntos para determinar el ganador de la partida
        {

            if (idjugador == 1)
            {
                nomP1 = user1; dineroP1 = dinero1;

                if (dinero2 > dineroP1)
                {
                    nomP1 = user2; dineroP1 = dinero2;
                    nomP2 = user1; dineroP2 = dinero1;
                }
                else
                {
                    nomP2 = user2; dineroP2 = dinero2;
                }

                if (dinero3 > dineroP1)
                {

                    nomP3 = nomP2; dineroP3 = dineroP2;
                    nomP2 = nomP1; dineroP2 = dineroP1;
                    nomP1 = user3; dineroP1 = dinero3;
                }
                else
                {

                    if (dinero3 > dineroP2)
                    {
                        nomP3 = nomP2; dineroP3 = dineroP2;
                        nomP2 = user3; dineroP2 = dinero3;
                    }
                    else
                    {
                        nomP3 = user3; dineroP3 = dinero3;
                    }
                }

                if (dinero4 > dineroP1)
                {

                    nomP4 = nomP3; dineroP4 = dineroP3;
                    nomP3 = nomP2; dineroP3 = dineroP2;
                    nomP2 = nomP1; dineroP2 = dineroP1;
                    nomP1 = user4; dineroP1 = dinero4;
                }
                else
                {

                    if (dinero4 > dineroP2)
                    {
                        nomP4 = nomP3; dineroP4 = dineroP3;
                        nomP3 = nomP2; dineroP3 = dineroP2;
                        nomP2 = user4; dineroP2 = dinero4;
                    }

                    else
                    {

                        if (dinero4 > dineroP3)
                        {
                            nomP4 = nomP3; dineroP4 = dineroP3;
                            nomP3 = user4; dineroP3 = dinero4;
                        }
                        else
                        {
                            nomP4 = user4; dineroP4 = dinero4;
                        }
                    }
                }
            }

        }


        private void gametime_Tick(object sender, EventArgs e)

            // reloj en tiempo real
        {
            hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        


        // timers para activar y desactivar los mensajes de las estaciones al caer


        public void AvisarFinPartida()
        {
            panel11.Visible = true;
            mensa_salida.Visible = true;
            mensaj_salida.Visible = true;
            finalizar = 1;
        }

        public void MostrarResultados(string player1, string player2, string player3)
        {
            primero.Text = player1;
            segundo.Text = player2;
            tercero.Text = player3;
            ganadores.Visible = true;
            primero.Visible = true;
            segundo.Visible = true;
            tercero.Visible = true;

        }

        private void salir_Click(object sender, EventArgs e)

            // se acaba la partida si uno de los cuatro cierra el tablero y los datos no se guardan (partida no finalizada)
        {
            if (num_propiedades == 32)
            {
                ganadores.Visible = false;
                primero.Visible = false;
                segundo.Visible = false;
                tercero.Visible = false;
                Close();
            }
            else if(finalizar == 1)
            {
                panel11.Visible = false;
                mensa_salida.Visible = false;
                mensaj_salida.Visible = false;
                Close();
            }
            else
            {
                gametime.Stop();
                gameturn.Stop();
                string salir = "15/" + idpartida;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(salir);
                server.Send(msg);
            }
            
        }

        
    }
}
