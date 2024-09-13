using System;
using System.Data;
using System.Windows.Forms;

namespace COMPRAS
{
    public partial class FormDetalle : Form
    {
        public FormDetalle(string fecha, string proveedor, DataTable articulos)
        {
            InitializeComponent();
            lblFecha.Text += " " + fecha;
            lblProveedor.Text += " " + proveedor;
            DisplayArticulos(articulos);
        }

        private void DisplayArticulos(DataTable articulos)
        {
            // Crear un DataGridView para mostrar los artículos
            DataGridView dgvArticulos = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                DataSource = articulos,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            // Crear un Panel para el DataGridView
            Panel panelArticulos = new Panel
            {
                Dock = DockStyle.Fill
            };
            panelArticulos.Controls.Add(dgvArticulos);

            // Agregar el Panel al formulario
            Controls.Add(panelArticulos);

            // Ajustar la disposición
            panelArticulos.BringToFront();
        }

        private void FormDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}