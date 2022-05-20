
namespace SO_Proyecto
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.log_in = new System.Windows.Forms.Button();
            this.sign_in = new System.Windows.Forms.Button();
            this.posicion_jugador = new System.Windows.Forms.Button();
            this.num_partidas = new System.Windows.Forms.Button();
            this.Jugadores_ganados = new System.Windows.Forms.Button();
            this.invitacion = new System.Windows.Forms.Button();
            this.desconectar = new System.Windows.Forms.Button();
            this.boton_chat = new System.Windows.Forms.Button();
            this.Tablaconectados = new System.Windows.Forms.DataGridView();
            this.Chat = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.TextBox();
            this.chatear = new System.Windows.Forms.TextBox();
            this.jugador2 = new System.Windows.Forms.TextBox();
            this.jugador3 = new System.Windows.Forms.TextBox();
            this.jugador4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tablaconectados)).BeginInit();
            this.SuspendLayout();
            // 
            // log_in
            // 
            this.log_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_in.Location = new System.Drawing.Point(303, 56);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(97, 57);
            this.log_in.TabIndex = 0;
            this.log_in.Text = "Log in";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // sign_in
            // 
            this.sign_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in.Location = new System.Drawing.Point(303, 144);
            this.sign_in.Name = "sign_in";
            this.sign_in.Size = new System.Drawing.Size(97, 57);
            this.sign_in.TabIndex = 1;
            this.sign_in.Text = "Sign in";
            this.sign_in.UseVisualStyleBackColor = true;
            this.sign_in.Click += new System.EventHandler(this.sign_in_Click);
            // 
            // posicion_jugador
            // 
            this.posicion_jugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posicion_jugador.Location = new System.Drawing.Point(254, 372);
            this.posicion_jugador.Name = "posicion_jugador";
            this.posicion_jugador.Size = new System.Drawing.Size(203, 68);
            this.posicion_jugador.TabIndex = 2;
            this.posicion_jugador.Text = "Posicion jugador en una partida concreta";
            this.posicion_jugador.UseVisualStyleBackColor = true;
            this.posicion_jugador.Click += new System.EventHandler(this.posicion_jugador_Click);
            // 
            // num_partidas
            // 
            this.num_partidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_partidas.Location = new System.Drawing.Point(254, 514);
            this.num_partidas.Name = "num_partidas";
            this.num_partidas.Size = new System.Drawing.Size(203, 68);
            this.num_partidas.TabIndex = 3;
            this.num_partidas.Text = "Partidas ganadas por un jugador";
            this.num_partidas.UseVisualStyleBackColor = true;
            this.num_partidas.Click += new System.EventHandler(this.num_partidas_Click);
            // 
            // Jugadores_ganados
            // 
            this.Jugadores_ganados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugadores_ganados.Location = new System.Drawing.Point(20, 506);
            this.Jugadores_ganados.Name = "Jugadores_ganados";
            this.Jugadores_ganados.Size = new System.Drawing.Size(203, 72);
            this.Jugadores_ganados.TabIndex = 4;
            this.Jugadores_ganados.Text = "Jugadores ganados por jugador";
            this.Jugadores_ganados.UseVisualStyleBackColor = true;
            this.Jugadores_ganados.Click += new System.EventHandler(this.Jugadores_ganados_Click);
            // 
            // invitacion
            // 
            this.invitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invitacion.Location = new System.Drawing.Point(671, 125);
            this.invitacion.Name = "invitacion";
            this.invitacion.Size = new System.Drawing.Size(110, 60);
            this.invitacion.TabIndex = 5;
            this.invitacion.Text = "Invitar";
            this.invitacion.UseVisualStyleBackColor = true;
            this.invitacion.Click += new System.EventHandler(this.invitacion_Click);
            // 
            // desconectar
            // 
            this.desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectar.Location = new System.Drawing.Point(20, 658);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(151, 38);
            this.desconectar.TabIndex = 6;
            this.desconectar.Text = "Desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // boton_chat
            // 
            this.boton_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_chat.Location = new System.Drawing.Point(671, 465);
            this.boton_chat.Name = "boton_chat";
            this.boton_chat.Size = new System.Drawing.Size(110, 60);
            this.boton_chat.TabIndex = 7;
            this.boton_chat.Text = "Chat";
            this.boton_chat.UseVisualStyleBackColor = true;
            this.boton_chat.Click += new System.EventHandler(this.boton_chat_Click);
            // 
            // Tablaconectados
            // 
            this.Tablaconectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tablaconectados.Location = new System.Drawing.Point(882, 26);
            this.Tablaconectados.Name = "Tablaconectados";
            this.Tablaconectados.RowHeadersWidth = 62;
            this.Tablaconectados.RowTemplate.Height = 28;
            this.Tablaconectados.Size = new System.Drawing.Size(378, 311);
            this.Tablaconectados.TabIndex = 8;
            // 
            // Chat
            // 
            this.Chat.FormattingEnabled = true;
            this.Chat.ItemHeight = 20;
            this.Chat.Location = new System.Drawing.Point(882, 358);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(378, 304);
            this.Chat.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(538, 557);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mensaje";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(520, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Jugadores";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(164, 76);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 26);
            this.username.TabIndex = 16;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(164, 159);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 26);
            this.password.TabIndex = 17;
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(123, 358);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 26);
            this.usuario.TabIndex = 18;
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(123, 433);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(100, 26);
            this.fecha.TabIndex = 19;
            // 
            // chatear
            // 
            this.chatear.Location = new System.Drawing.Point(671, 556);
            this.chatear.Name = "chatear";
            this.chatear.Size = new System.Drawing.Size(110, 26);
            this.chatear.TabIndex = 20;
            // 
            // jugador2
            // 
            this.jugador2.Location = new System.Drawing.Point(671, 213);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(110, 26);
            this.jugador2.TabIndex = 21;
            // 
            // jugador3
            // 
            this.jugador3.Location = new System.Drawing.Point(671, 259);
            this.jugador3.Name = "jugador3";
            this.jugador3.Size = new System.Drawing.Size(110, 26);
            this.jugador3.TabIndex = 22;
            // 
            // jugador4
            // 
            this.jugador4.Location = new System.Drawing.Point(671, 311);
            this.jugador4.Name = "jugador4";
            this.jugador4.Size = new System.Drawing.Size(110, 26);
            this.jugador4.TabIndex = 23;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 719);
            this.Controls.Add(this.jugador4);
            this.Controls.Add(this.jugador3);
            this.Controls.Add(this.jugador2);
            this.Controls.Add(this.chatear);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.Tablaconectados);
            this.Controls.Add(this.boton_chat);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.invitacion);
            this.Controls.Add(this.Jugadores_ganados);
            this.Controls.Add(this.num_partidas);
            this.Controls.Add(this.posicion_jugador);
            this.Controls.Add(this.sign_in);
            this.Controls.Add(this.log_in);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tablaconectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.Button sign_in;
        private System.Windows.Forms.Button posicion_jugador;
        private System.Windows.Forms.Button num_partidas;
        private System.Windows.Forms.Button Jugadores_ganados;
        private System.Windows.Forms.Button invitacion;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.Button boton_chat;
        private System.Windows.Forms.DataGridView Tablaconectados;
        private System.Windows.Forms.ListBox Chat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox fecha;
        private System.Windows.Forms.TextBox chatear;
        private System.Windows.Forms.TextBox jugador2;
        private System.Windows.Forms.TextBox jugador3;
        private System.Windows.Forms.TextBox jugador4;
    }
}

