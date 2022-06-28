namespace SO_Proyecto
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gametime = new System.Windows.Forms.Timer(this.components);
            this.gameturn = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.Tablero = new System.Windows.Forms.Panel();
            this.ganadores = new System.Windows.Forms.Panel();
            this.tercero = new System.Windows.Forms.Label();
            this.primero = new System.Windows.Forms.Label();
            this.segundo = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.mensaj_salida = new System.Windows.Forms.Label();
            this.mensa_salida = new System.Windows.Forms.Label();
            this.flecha2 = new System.Windows.Forms.Panel();
            this.salir = new System.Windows.Forms.Button();
            this.TablaPropiedades = new System.Windows.Forms.DataGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.money = new System.Windows.Forms.Label();
            this.money4 = new System.Windows.Forms.Label();
            this.money3 = new System.Windows.Forms.Label();
            this.money2 = new System.Windows.Forms.Label();
            this.money1 = new System.Windows.Forms.Label();
            this.flecha1 = new System.Windows.Forms.Panel();
            this.flecha3 = new System.Windows.Forms.Panel();
            this.flecha4 = new System.Windows.Forms.Panel();
            this.hora = new System.Windows.Forms.Label();
            this.Fitxa3 = new System.Windows.Forms.Panel();
            this.player4 = new System.Windows.Forms.Label();
            this.player3 = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.Label();
            this.player1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jugador = new System.Windows.Forms.Label();
            this.hablar = new System.Windows.Forms.TextBox();
            this.Fitxa4 = new System.Windows.Forms.Panel();
            this.Fitxa2 = new System.Windows.Forms.Panel();
            this.Chat = new System.Windows.Forms.ListBox();
            this.send = new System.Windows.Forms.Button();
            this.Fitxa1 = new System.Windows.Forms.Panel();
            this.dado = new System.Windows.Forms.Panel();
            this.numeroLbl = new System.Windows.Forms.Label();
            this.Tablero.SuspendLayout();
            this.ganadores.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaPropiedades)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1911, 1046);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gametime
            // 
            this.gametime.Tick += new System.EventHandler(this.gametime_Tick);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 0);
            this.panel5.TabIndex = 1;
            // 
            // Tablero
            // 
            this.Tablero.AutoSize = true;
            this.Tablero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Tablero.BackgroundImage = global::SO_Proyecto.Properties.Resources.MonopolyBueno;
            this.Tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tablero.Controls.Add(this.ganadores);
            this.Tablero.Controls.Add(this.panel11);
            this.Tablero.Controls.Add(this.flecha2);
            this.Tablero.Controls.Add(this.salir);
            this.Tablero.Controls.Add(this.TablaPropiedades);
            this.Tablero.Controls.Add(this.panel10);
            this.Tablero.Controls.Add(this.panel9);
            this.Tablero.Controls.Add(this.panel8);
            this.Tablero.Controls.Add(this.panel7);
            this.Tablero.Controls.Add(this.panel6);
            this.Tablero.Controls.Add(this.money);
            this.Tablero.Controls.Add(this.money4);
            this.Tablero.Controls.Add(this.money3);
            this.Tablero.Controls.Add(this.money2);
            this.Tablero.Controls.Add(this.money1);
            this.Tablero.Controls.Add(this.flecha1);
            this.Tablero.Controls.Add(this.flecha3);
            this.Tablero.Controls.Add(this.flecha4);
            this.Tablero.Controls.Add(this.hora);
            this.Tablero.Controls.Add(this.Fitxa3);
            this.Tablero.Controls.Add(this.player4);
            this.Tablero.Controls.Add(this.player3);
            this.Tablero.Controls.Add(this.player2);
            this.Tablero.Controls.Add(this.player1);
            this.Tablero.Controls.Add(this.panel4);
            this.Tablero.Controls.Add(this.panel3);
            this.Tablero.Controls.Add(this.panel2);
            this.Tablero.Controls.Add(this.panel1);
            this.Tablero.Controls.Add(this.jugador);
            this.Tablero.Controls.Add(this.hablar);
            this.Tablero.Controls.Add(this.Fitxa4);
            this.Tablero.Controls.Add(this.Fitxa2);
            this.Tablero.Controls.Add(this.Chat);
            this.Tablero.Controls.Add(this.send);
            this.Tablero.Controls.Add(this.Fitxa1);
            this.Tablero.Controls.Add(this.dado);
            this.Tablero.Controls.Add(this.numeroLbl);
            this.Tablero.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tablero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tablero.Location = new System.Drawing.Point(0, 0);
            this.Tablero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(1137, 684);
            this.Tablero.TabIndex = 0;
            // 
            // ganadores
            // 
            this.ganadores.BackgroundImage = global::SO_Proyecto.Properties.Resources.podio;
            this.ganadores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ganadores.Controls.Add(this.tercero);
            this.ganadores.Controls.Add(this.primero);
            this.ganadores.Controls.Add(this.segundo);
            this.ganadores.Location = new System.Drawing.Point(75, 123);
            this.ganadores.Name = "ganadores";
            this.ganadores.Size = new System.Drawing.Size(520, 430);
            this.ganadores.TabIndex = 52;
            // 
            // tercero
            // 
            this.tercero.AutoSize = true;
            this.tercero.BackColor = System.Drawing.Color.Transparent;
            this.tercero.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tercero.Location = new System.Drawing.Point(348, 160);
            this.tercero.Name = "tercero";
            this.tercero.Size = new System.Drawing.Size(129, 52);
            this.tercero.TabIndex = 2;
            this.tercero.Text = "label3";
            // 
            // primero
            // 
            this.primero.AutoSize = true;
            this.primero.BackColor = System.Drawing.Color.Transparent;
            this.primero.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primero.Location = new System.Drawing.Point(190, 91);
            this.primero.Name = "primero";
            this.primero.Size = new System.Drawing.Size(129, 52);
            this.primero.TabIndex = 1;
            this.primero.Text = "label2";
            // 
            // segundo
            // 
            this.segundo.AutoSize = true;
            this.segundo.BackColor = System.Drawing.Color.Transparent;
            this.segundo.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.segundo.Location = new System.Drawing.Point(63, 151);
            this.segundo.Name = "segundo";
            this.segundo.Size = new System.Drawing.Size(118, 52);
            this.segundo.TabIndex = 0;
            this.segundo.Text = "label1";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel11.Controls.Add(this.mensaj_salida);
            this.panel11.Controls.Add(this.mensa_salida);
            this.panel11.Location = new System.Drawing.Point(99, 262);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(496, 156);
            this.panel11.TabIndex = 0;
            // 
            // mensaj_salida
            // 
            this.mensaj_salida.AutoSize = true;
            this.mensaj_salida.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaj_salida.Location = new System.Drawing.Point(-4, 80);
            this.mensaj_salida.Name = "mensaj_salida";
            this.mensaj_salida.Size = new System.Drawing.Size(482, 26);
            this.mensaj_salida.TabIndex = 2;
            this.mensaj_salida.Text = "Pulse el boton Exit para volver al menu principal";
            // 
            // mensa_salida
            // 
            this.mensa_salida.AutoSize = true;
            this.mensa_salida.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensa_salida.Location = new System.Drawing.Point(-5, 41);
            this.mensa_salida.Name = "mensa_salida";
            this.mensa_salida.Size = new System.Drawing.Size(441, 26);
            this.mensa_salida.TabIndex = 0;
            this.mensa_salida.Text = "Uno de los jugadores ha salido de la partida ";
            // 
            // flecha2
            // 
            this.flecha2.BackColor = System.Drawing.Color.Transparent;
            this.flecha2.BackgroundImage = global::SO_Proyecto.Properties.Resources.flecha;
            this.flecha2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha2.Location = new System.Drawing.Point(719, 386);
            this.flecha2.Name = "flecha2";
            this.flecha2.Size = new System.Drawing.Size(35, 36);
            this.flecha2.TabIndex = 24;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.Salmon;
            this.salir.Cursor = System.Windows.Forms.Cursors.No;
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.Location = new System.Drawing.Point(759, 242);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(73, 33);
            this.salir.TabIndex = 51;
            this.salir.Text = "Exit";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // TablaPropiedades
            // 
            this.TablaPropiedades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.TablaPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablaPropiedades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TablaPropiedades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaPropiedades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaPropiedades.Location = new System.Drawing.Point(900, 132);
            this.TablaPropiedades.Name = "TablaPropiedades";
            this.TablaPropiedades.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TablaPropiedades.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaPropiedades.RowTemplate.Height = 24;
            this.TablaPropiedades.Size = new System.Drawing.Size(223, 154);
            this.TablaPropiedades.TabIndex = 50;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BackgroundImage = global::SO_Proyecto.Properties.Resources.logo_Euro;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(1068, 454);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(36, 26);
            this.panel10.TabIndex = 49;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BackgroundImage = global::SO_Proyecto.Properties.Resources.logo_Euro;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(1068, 423);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(36, 26);
            this.panel9.TabIndex = 49;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BackgroundImage = global::SO_Proyecto.Properties.Resources.logo_Euro;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Location = new System.Drawing.Point(1068, 390);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(36, 26);
            this.panel8.TabIndex = 49;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BackgroundImage = global::SO_Proyecto.Properties.Resources.logo_Euro;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Location = new System.Drawing.Point(1068, 358);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(36, 26);
            this.panel7.TabIndex = 49;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::SO_Proyecto.Properties.Resources.logo_Euro;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(835, 182);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(50, 28);
            this.panel6.TabIndex = 48;
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.BackColor = System.Drawing.Color.Transparent;
            this.money.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money.Location = new System.Drawing.Point(752, 179);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(107, 40);
            this.money.TabIndex = 31;
            this.money.Text = "money";
            // 
            // money4
            // 
            this.money4.AutoSize = true;
            this.money4.BackColor = System.Drawing.Color.Transparent;
            this.money4.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money4.Location = new System.Drawing.Point(979, 454);
            this.money4.Name = "money4";
            this.money4.Size = new System.Drawing.Size(73, 31);
            this.money4.TabIndex = 30;
            this.money4.Text = "label1";
            // 
            // money3
            // 
            this.money3.AutoSize = true;
            this.money3.BackColor = System.Drawing.Color.Transparent;
            this.money3.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money3.Location = new System.Drawing.Point(979, 423);
            this.money3.Name = "money3";
            this.money3.Size = new System.Drawing.Size(73, 31);
            this.money3.TabIndex = 29;
            this.money3.Text = "label1";
            // 
            // money2
            // 
            this.money2.AutoSize = true;
            this.money2.BackColor = System.Drawing.Color.Transparent;
            this.money2.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money2.Location = new System.Drawing.Point(979, 391);
            this.money2.Name = "money2";
            this.money2.Size = new System.Drawing.Size(73, 31);
            this.money2.TabIndex = 28;
            this.money2.Text = "label1";
            // 
            // money1
            // 
            this.money1.AutoSize = true;
            this.money1.BackColor = System.Drawing.Color.Transparent;
            this.money1.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money1.Location = new System.Drawing.Point(979, 358);
            this.money1.Name = "money1";
            this.money1.Size = new System.Drawing.Size(73, 31);
            this.money1.TabIndex = 27;
            this.money1.Text = "label1";
            // 
            // flecha1
            // 
            this.flecha1.BackColor = System.Drawing.Color.Transparent;
            this.flecha1.BackgroundImage = global::SO_Proyecto.Properties.Resources.flecha;
            this.flecha1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha1.Location = new System.Drawing.Point(719, 351);
            this.flecha1.Name = "flecha1";
            this.flecha1.Size = new System.Drawing.Size(35, 36);
            this.flecha1.TabIndex = 25;
            // 
            // flecha3
            // 
            this.flecha3.BackColor = System.Drawing.Color.Transparent;
            this.flecha3.BackgroundImage = global::SO_Proyecto.Properties.Resources.flecha;
            this.flecha3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha3.Location = new System.Drawing.Point(719, 423);
            this.flecha3.Name = "flecha3";
            this.flecha3.Size = new System.Drawing.Size(35, 36);
            this.flecha3.TabIndex = 23;
            // 
            // flecha4
            // 
            this.flecha4.BackColor = System.Drawing.Color.Transparent;
            this.flecha4.BackgroundImage = global::SO_Proyecto.Properties.Resources.flecha;
            this.flecha4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha4.Location = new System.Drawing.Point(719, 458);
            this.flecha4.Name = "flecha4";
            this.flecha4.Size = new System.Drawing.Size(35, 36);
            this.flecha4.TabIndex = 22;
            // 
            // hora
            // 
            this.hora.AutoSize = true;
            this.hora.BackColor = System.Drawing.Color.Transparent;
            this.hora.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hora.Location = new System.Drawing.Point(979, 495);
            this.hora.Name = "hora";
            this.hora.Size = new System.Drawing.Size(149, 34);
            this.hora.TabIndex = 21;
            this.hora.Text = "00:00:00";
            // 
            // Fitxa3
            // 
            this.Fitxa3.BackColor = System.Drawing.Color.Transparent;
            this.Fitxa3.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha3;
            this.Fitxa3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fitxa3.Location = new System.Drawing.Point(603, 641);
            this.Fitxa3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fitxa3.Name = "Fitxa3";
            this.Fitxa3.Size = new System.Drawing.Size(32, 32);
            this.Fitxa3.TabIndex = 9;
            // 
            // player4
            // 
            this.player4.AutoSize = true;
            this.player4.BackColor = System.Drawing.Color.Transparent;
            this.player4.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4.Location = new System.Drawing.Point(848, 458);
            this.player4.Name = "player4";
            this.player4.Size = new System.Drawing.Size(97, 31);
            this.player4.TabIndex = 20;
            this.player4.Text = "player4";
            // 
            // player3
            // 
            this.player3.AutoSize = true;
            this.player3.BackColor = System.Drawing.Color.Transparent;
            this.player3.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3.Location = new System.Drawing.Point(848, 423);
            this.player3.Name = "player3";
            this.player3.Size = new System.Drawing.Size(97, 31);
            this.player3.TabIndex = 19;
            this.player3.Text = "player3";
            // 
            // player2
            // 
            this.player2.AutoSize = true;
            this.player2.BackColor = System.Drawing.Color.Transparent;
            this.player2.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2.Location = new System.Drawing.Point(848, 386);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(97, 31);
            this.player2.TabIndex = 18;
            this.player2.Text = "player2";
            // 
            // player1
            // 
            this.player1.AutoSize = true;
            this.player1.BackColor = System.Drawing.Color.Transparent;
            this.player1.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1.Location = new System.Drawing.Point(853, 351);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(91, 31);
            this.player1.TabIndex = 17;
            this.player1.Text = "player1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha4;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(791, 458);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 32);
            this.panel4.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha3;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(791, 422);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 32);
            this.panel3.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(791, 386);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 32);
            this.panel2.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(791, 351);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 32);
            this.panel1.TabIndex = 13;
            // 
            // jugador
            // 
            this.jugador.AutoSize = true;
            this.jugador.BackColor = System.Drawing.Color.Transparent;
            this.jugador.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugador.Location = new System.Drawing.Point(752, 114);
            this.jugador.Name = "jugador";
            this.jugador.Size = new System.Drawing.Size(116, 40);
            this.jugador.TabIndex = 12;
            this.jugador.Text = "jugador";
            // 
            // hablar
            // 
            this.hablar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.hablar.Location = new System.Drawing.Point(907, 540);
            this.hablar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hablar.Name = "hablar";
            this.hablar.Size = new System.Drawing.Size(158, 22);
            this.hablar.TabIndex = 11;
            // 
            // Fitxa4
            // 
            this.Fitxa4.BackColor = System.Drawing.Color.Transparent;
            this.Fitxa4.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha4;
            this.Fitxa4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fitxa4.Location = new System.Drawing.Point(646, 641);
            this.Fitxa4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fitxa4.Name = "Fitxa4";
            this.Fitxa4.Size = new System.Drawing.Size(32, 32);
            this.Fitxa4.TabIndex = 10;
            // 
            // Fitxa2
            // 
            this.Fitxa2.BackColor = System.Drawing.Color.Transparent;
            this.Fitxa2.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha2;
            this.Fitxa2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fitxa2.Location = new System.Drawing.Point(646, 600);
            this.Fitxa2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fitxa2.Name = "Fitxa2";
            this.Fitxa2.Size = new System.Drawing.Size(32, 32);
            this.Fitxa2.TabIndex = 8;
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Chat.FormattingEnabled = true;
            this.Chat.ItemHeight = 16;
            this.Chat.Location = new System.Drawing.Point(902, 563);
            this.Chat.Margin = new System.Windows.Forms.Padding(4);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(221, 100);
            this.Chat.TabIndex = 7;
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.send.Location = new System.Drawing.Point(1062, 540);
            this.send.Margin = new System.Windows.Forms.Padding(4);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(61, 25);
            this.send.TabIndex = 5;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // Fitxa1
            // 
            this.Fitxa1.BackColor = System.Drawing.Color.Transparent;
            this.Fitxa1.BackgroundImage = global::SO_Proyecto.Properties.Resources.ficha1;
            this.Fitxa1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fitxa1.Location = new System.Drawing.Point(603, 600);
            this.Fitxa1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fitxa1.Name = "Fitxa1";
            this.Fitxa1.Size = new System.Drawing.Size(32, 32);
            this.Fitxa1.TabIndex = 3;
            // 
            // dado
            // 
            this.dado.BackColor = System.Drawing.Color.Transparent;
            this.dado.BackgroundImage = global::SO_Proyecto.Properties.Resources.tirardado;
            this.dado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dado.Location = new System.Drawing.Point(708, 579);
            this.dado.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dado.Name = "dado";
            this.dado.Size = new System.Drawing.Size(95, 87);
            this.dado.TabIndex = 2;
            this.dado.Click += new System.EventHandler(this.dado_Click);
            // 
            // numeroLbl
            // 
            this.numeroLbl.AutoSize = true;
            this.numeroLbl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.numeroLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroLbl.Location = new System.Drawing.Point(699, 668);
            this.numeroLbl.Name = "numeroLbl";
            this.numeroLbl.Size = new System.Drawing.Size(0, 54);
            this.numeroLbl.TabIndex = 1;
            this.numeroLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Juego
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1137, 684);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.Tablero);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monopoly";
            this.Load += new System.EventHandler(this.Juego_Load);
            this.Tablero.ResumeLayout(false);
            this.Tablero.PerformLayout();
            this.ganadores.ResumeLayout(false);
            this.ganadores.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaPropiedades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel Tablero;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label numeroLbl;
        private System.Windows.Forms.Panel dado;
        private System.Windows.Forms.Panel Fitxa1;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.ListBox Chat;
        private System.Windows.Forms.Panel Fitxa2;
        private System.Windows.Forms.Panel Fitxa3;
        private System.Windows.Forms.Panel Fitxa4;
        private System.Windows.Forms.TextBox hablar;
        private System.Windows.Forms.Label jugador;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label player4;
        private System.Windows.Forms.Label player3;
        private System.Windows.Forms.Label player2;
        private System.Windows.Forms.Label player1;
        private System.Windows.Forms.Label hora;
        private System.Windows.Forms.Timer gametime;
        private System.Windows.Forms.Timer gameturn;
        private System.Windows.Forms.Panel flecha2;
        private System.Windows.Forms.Panel flecha3;
        private System.Windows.Forms.Panel flecha4;
        private System.Windows.Forms.Panel flecha1;
        private System.Windows.Forms.Label money1;
        private System.Windows.Forms.Label money4;
        private System.Windows.Forms.Label money3;
        private System.Windows.Forms.Label money2;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView TablaPropiedades;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label mensaj_salida;
        private System.Windows.Forms.Label mensa_salida;
        private System.Windows.Forms.Panel ganadores;
        private System.Windows.Forms.Label tercero;
        private System.Windows.Forms.Label primero;
        private System.Windows.Forms.Label segundo;
    }
}