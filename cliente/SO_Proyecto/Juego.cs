using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace SO_Proyecto
{
    public partial class Juego : Form
    {
        Socket server;
        public Juego( Socket server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void Juego_Load(object sender, EventArgs e)
        {

        }
    }
}
