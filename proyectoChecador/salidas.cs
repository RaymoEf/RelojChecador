using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaN;

namespace proyectoChecador
{
    public partial class salidas : Form
    {
        public salidas()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = Nsalida.Mostrar();
            lblTolal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void salidas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
