using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace COMPRAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregar columna de botones al DataGridView
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Acciones";
            btnColumn.Text = "Abrir";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnColumn);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos Firebird
            string connectionString = "User=SYSDBA;Password=masterkey;Database=\"C:\\Microsip datos\\SUPER CARQUIN.FDB\";DataSource=server;Port=3050;Dialect=3;Charset=UTF8;";

            // Consulta SQL para obtener el detalle de la compra con el folio especificado y tipo de documento 'C'
            string query = @"SELECT
                FECHA,
                G.NOMBRE AS PROVEEDOR,
                LIST(
                    B.NOMBRE
                    || ', '
                ) AS ARTICULOS
            FROM (
                SELECT 
                    FECHA,
                    PROVEEDOR_ID,
                    ARTICULO_ID
                FROM GET_MOVTOS_COMPRA_ART_CM(
                    DATEADD(-1 MONTH TO CURRENT_DATE), 'TODAY',
                    '01-01-1000', '01-01-1000', 'N'
                )
            ) A
            JOIN ARTICULOS B ON B.ARTICULO_ID = A.ARTICULO_ID
            JOIN PROVEEDORES G ON G.PROVEEDOR_ID = A.PROVEEDOR_ID
            GROUP BY FECHA, PROVEEDOR
            ORDER BY FECHA;";

            // Crear una conexión a la base de datos
            using (FbConnection connection = new FbConnection(connectionString))
            {
                // Crear un comando para ejecutar la consulta
                using (FbCommand command = new FbCommand(query, connection))
                {
                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta y llenar un DataTable
                        using (FbDataAdapter adapter = new FbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda clickeada es de tipo botón
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    // Obtener datos de la fila seleccionada
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string fecha = row.Cells["FECHA"].Value?.ToString();
                    string proveedor = row.Cells["PROVEEDOR"].Value?.ToString();

                    // Crear un DataTable para los artículos
                    DataTable articulos = new DataTable();
                    articulos.Columns.Add("Articulo", typeof(string));

                    // Agregar cada artículo a la tabla
                    string[] articulosArray = row.Cells["ARTICULOS"].Value?.ToString().Split(',');
                    foreach (string articulo in articulosArray)
                    {
                        articulos.Rows.Add(articulo.Trim());
                    }

                    // Abrir nueva ventana con los detalles
                    FormDetalle formDetalle = new FormDetalle(fecha, proveedor, articulos);
                    formDetalle.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la ventana de detalles: " + ex.Message);
                }
            }
        }
    }
}
