namespace COMPRAS
{
    partial class FormDetalle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblFecha = new Label();
            lblProveedor = new Label();
            lblArticulos = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblFecha, 0, 0);
            tableLayoutPanel1.Controls.Add(lblProveedor, 0, 1);
            tableLayoutPanel1.Controls.Add(lblArticulos, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.Size = new Size(473, 133);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(20, 17);
            lblFecha.Margin = new Padding(5, 0, 5, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(61, 25);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;

            lblProveedor.Margin = new Padding(5, 0, 5, 0);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(98, 25);
            lblProveedor.TabIndex = 1;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblArticulos
            // 
            lblArticulos.AutoSize = true;
            lblArticulos.Location = new Point(20, 106);
            lblArticulos.Margin = new Padding(5, 0, 5, 0);
            lblArticulos.Name = "lblArticulos";
            lblArticulos.Size = new Size(85, 25);
            lblArticulos.TabIndex = 2;
            lblArticulos.Text = "Artículos:";
            // 
            // FormDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormDetalle";
            Text = "Detalles de Compra";
            Load += FormDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblArticulos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}