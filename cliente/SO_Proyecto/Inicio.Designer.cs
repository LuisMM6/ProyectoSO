
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.log_in = new System.Windows.Forms.Button();
            this.sign_in = new System.Windows.Forms.Button();
            this.podio = new System.Windows.Forms.Button();
            this.partidas_ganadas = new System.Windows.Forms.Button();
            this.partidas_jugados = new System.Windows.Forms.Button();
            this.invitacion = new System.Windows.Forms.Button();
            this.desconectar = new System.Windows.Forms.Button();
            this.Tablaconectados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.conectado = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.eliminarusuario = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tablaconectados)).BeginInit();
            this.SuspendLayout();
            // 
            // log_in
            // 
            this.log_in.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.log_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_in.Location = new System.Drawing.Point(290, 46);
            this.log_in.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(85, 46);
            this.log_in.TabIndex = 0;
            this.log_in.Text = "Log in";
            this.log_in.UseVisualStyleBackColor = false;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // sign_in
            // 
            this.sign_in.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sign_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in.Location = new System.Drawing.Point(290, 114);
            this.sign_in.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sign_in.Name = "sign_in";
            this.sign_in.Size = new System.Drawing.Size(85, 46);
            this.sign_in.TabIndex = 1;
            this.sign_in.Text = "Sign in";
            this.sign_in.UseVisualStyleBackColor = false;
            this.sign_in.Click += new System.EventHandler(this.sign_in_Click);
            // 
            // podio
            // 
            this.podio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.podio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podio.Location = new System.Drawing.Point(276, 390);
            this.podio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.podio.Name = "podio";
            this.podio.Size = new System.Drawing.Size(231, 54);
            this.podio.TabIndex = 2;
            this.podio.Text = "Podio";
            this.podio.UseVisualStyleBackColor = false;
            this.podio.Click += new System.EventHandler(this.podio_Click);
            // 
            // partidas_ganadas
            // 
            this.partidas_ganadas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.partidas_ganadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidas_ganadas.Location = new System.Drawing.Point(276, 450);
            this.partidas_ganadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partidas_ganadas.Name = "partidas_ganadas";
            this.partidas_ganadas.Size = new System.Drawing.Size(231, 54);
            this.partidas_ganadas.TabIndex = 3;
            this.partidas_ganadas.Text = "Partidas ganadas por un jugador";
            this.partidas_ganadas.UseVisualStyleBackColor = false;
            this.partidas_ganadas.Click += new System.EventHandler(this.partidas_ganadas_Click);
            // 
            // partidas_jugados
            // 
            this.partidas_jugados.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.partidas_jugados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partidas_jugados.Location = new System.Drawing.Point(276, 507);
            this.partidas_jugados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partidas_jugados.Name = "partidas_jugados";
            this.partidas_jugados.Size = new System.Drawing.Size(231, 58);
            this.partidas_jugados.TabIndex = 4;
            this.partidas_jugados.Text = "Partidas jugadas por un jugador";
            this.partidas_jugados.UseVisualStyleBackColor = false;
            this.partidas_jugados.Click += new System.EventHandler(this.partidas_jugadas_Click);
            // 
            // invitacion
            // 
            this.invitacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.invitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invitacion.Location = new System.Drawing.Point(805, 180);
            this.invitacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.invitacion.Name = "invitacion";
            this.invitacion.Size = new System.Drawing.Size(118, 48);
            this.invitacion.TabIndex = 5;
            this.invitacion.Text = "Invitar";
            this.invitacion.UseVisualStyleBackColor = false;
            this.invitacion.Click += new System.EventHandler(this.invitacion_Click);
            // 
            // desconectar
            // 
            this.desconectar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectar.Location = new System.Drawing.Point(1015, 521);
            this.desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(133, 41);
            this.desconectar.TabIndex = 6;
            this.desconectar.Text = "Desconectar";
            this.desconectar.UseVisualStyleBackColor = false;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // Tablaconectados
            // 
            this.Tablaconectados.AllowUserToAddRows = false;
            this.Tablaconectados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tablaconectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Tablaconectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tablaconectados.Location = new System.Drawing.Point(942, 46);
            this.Tablaconectados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablaconectados.Name = "Tablaconectados";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tablaconectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Tablaconectados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tablaconectados.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Tablaconectados.RowTemplate.Height = 28;
            this.Tablaconectados.Size = new System.Drawing.Size(205, 208);
            this.Tablaconectados.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Usuario";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(147, 62);
            this.username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(89, 22);
            this.username.TabIndex = 16;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(147, 126);
            this.password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(89, 22);
            this.password.TabIndex = 17;
            this.password.UseSystemPasswordChar = true;
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(164, 467);
            this.usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(89, 22);
            this.usuario.TabIndex = 18;
            // 
            // conectado
            // 
            this.conectado.AutoSize = true;
            this.conectado.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectado.Location = new System.Drawing.Point(878, 532);
            this.conectado.Name = "conectado";
            this.conectado.Size = new System.Drawing.Size(130, 29);
            this.conectado.TabIndex = 26;
            this.conectado.Text = "Conectado";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(805, 62);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 22);
            this.textBox1.TabIndex = 27;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(805, 98);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 22);
            this.textBox2.TabIndex = 28;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(805, 138);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(119, 22);
            this.textBox3.TabIndex = 29;
            // 
            // eliminarusuario
            // 
            this.eliminarusuario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.eliminarusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.eliminarusuario.Location = new System.Drawing.Point(13, 180);
            this.eliminarusuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eliminarusuario.Name = "eliminarusuario";
            this.eliminarusuario.Size = new System.Drawing.Size(131, 58);
            this.eliminarusuario.TabIndex = 30;
            this.eliminarusuario.Text = "Eliminar Usuario";
            this.eliminarusuario.UseVisualStyleBackColor = false;
            this.eliminarusuario.Click += new System.EventHandler(this.eliminarusuario_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(257, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SO_Proyecto.Properties.Resources._0db41409c10b46ae99b710427a1d7913;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1163, 574);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.eliminarusuario);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.conectado);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tablaconectados);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.invitacion);
            this.Controls.Add(this.partidas_jugados);
            this.Controls.Add(this.partidas_ganadas);
            this.Controls.Add(this.podio);
            this.Controls.Add(this.sign_in);
            this.Controls.Add(this.log_in);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button podio;
        private System.Windows.Forms.Button partidas_ganadas;
        private System.Windows.Forms.Button partidas_jugados;
        private System.Windows.Forms.Button invitacion;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.DataGridView Tablaconectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label conectado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button eliminarusuario;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

