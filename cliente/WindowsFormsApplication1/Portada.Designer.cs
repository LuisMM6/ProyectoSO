namespace WindowsFormsApplication1
{
    partial class Portada
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
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.Signin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.posicion_jugador = new System.Windows.Forms.Button();
            this.num_partidas = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.TextBox();
            this.desconectar = new System.Windows.Forms.Button();
            this.GanadorPartida = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NºPartida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(185, 162);
            this.username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(123, 22);
            this.username.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(185, 240);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(123, 22);
            this.password.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(413, 225);
            this.Login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(105, 50);
            this.Login.TabIndex = 5;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Signin
            // 
            this.Signin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signin.Location = new System.Drawing.Point(413, 151);
            this.Signin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Signin.Name = "Signin";
            this.Signin.Size = new System.Drawing.Size(105, 48);
            this.Signin.TabIndex = 6;
            this.Signin.Text = "Sign in";
            this.Signin.UseVisualStyleBackColor = true;
            this.Signin.Click += new System.EventHandler(this.Signin_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(597, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 43);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bienvenido";
            // 
            // posicion_jugador
            // 
            this.posicion_jugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posicion_jugador.Location = new System.Drawing.Point(39, 431);
            this.posicion_jugador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.posicion_jugador.Name = "posicion_jugador";
            this.posicion_jugador.Size = new System.Drawing.Size(281, 97);
            this.posicion_jugador.TabIndex = 10;
            this.posicion_jugador.Text = "Posicion jugador en una partida concreta";
            this.posicion_jugador.UseVisualStyleBackColor = true;
            this.posicion_jugador.Click += new System.EventHandler(this.posicion_jugador_Click);
            // 
            // num_partidas
            // 
            this.num_partidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_partidas.Location = new System.Drawing.Point(36, 564);
            this.num_partidas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num_partidas.Name = "num_partidas";
            this.num_partidas.Size = new System.Drawing.Size(281, 98);
            this.num_partidas.TabIndex = 11;
            this.num_partidas.Text = "Num partidas ganadas por jugador";
            this.num_partidas.UseVisualStyleBackColor = true;
            this.num_partidas.Click += new System.EventHandler(this.num_partidas_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 725);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 790);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(177, 725);
            this.usuario.Margin = new System.Windows.Forms.Padding(4);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(132, 22);
            this.usuario.TabIndex = 14;
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(176, 789);
            this.fecha.Margin = new System.Windows.Forms.Padding(4);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(132, 22);
            this.fecha.TabIndex = 15;
            // 
            // desconectar
            // 
            this.desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectar.Location = new System.Drawing.Point(1247, 837);
            this.desconectar.Margin = new System.Windows.Forms.Padding(4);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(128, 44);
            this.desconectar.TabIndex = 17;
            this.desconectar.Text = "Desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // GanadorPartida
            // 
            this.GanadorPartida.Location = new System.Drawing.Point(364, 505);
            this.GanadorPartida.Name = "GanadorPartida";
            this.GanadorPartida.Size = new System.Drawing.Size(203, 103);
            this.GanadorPartida.TabIndex = 18;
            this.GanadorPartida.Text = "Nombre del ganador de la partida indicada";
            this.GanadorPartida.UseVisualStyleBackColor = true;
            this.GanadorPartida.Click += new System.EventHandler(this.GanadorPartida_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 761);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Nº Partida";
            // 
            // NºPartida
            // 
            this.NºPartida.Location = new System.Drawing.Point(443, 758);
            this.NºPartida.Name = "NºPartida";
            this.NºPartida.Size = new System.Drawing.Size(75, 22);
            this.NºPartida.TabIndex = 20;
            // 
            // Portada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 897);
            this.Controls.Add(this.NºPartida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GanadorPartida);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num_partidas);
            this.Controls.Add(this.posicion_jugador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Signin);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Portada";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Signin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button posicion_jugador;
        private System.Windows.Forms.Button num_partidas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox fecha;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.Button GanadorPartida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NºPartida;
    }
}