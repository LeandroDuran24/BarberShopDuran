using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarbershopTech.UI.Reportes;
using Entidades;

namespace BarbershopTech.Consultas
{
    public partial class ConsultaFactura : Form
    {
        public List<Facturas> lista { get; set; }
        public ConsultaFactura()
        {
            InitializeComponent();
            LLenarCombo();
        }

        public void LLenarCombo()
        {
            comboBox1.Items.Insert(0, "Todos");
            comboBox1.Items.Insert(1, "Nombre");
            comboBox1.Items.Insert(2, "Id");
            comboBox1.DataSource = comboBox1.Items;
            comboBox1.DisplayMember = "Todos";

            if (comboBox1.Items.Count >= 1)
            {
                comboBox1.SelectedIndex = -1;
            }
        }

        public bool ValidarTextBox()
        {
            if (string.IsNullOrEmpty(BuscartextBox.Text))
            {
                errorProvider1.SetError(BuscartextBox, "Favor llenar");
                return false;
            }
            return true;
        }

        public void SeleccionarCombo()
        {

            if (comboBox1.SelectedIndex == 0)
            {
                lista = BLL.FacturaBLL.GetListTodo();
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                if (!ValidarTextBox())
                {
                    MessageBox.Show("Favor Llenar");
                }
                else
                {
                    lista = BLL.FacturaBLL.GetList(p => p.NombreCliente == BuscartextBox.Text);
                }

            }

            else if (comboBox1.SelectedIndex == 2)
            {
                if (!ValidarTextBox())
                {
                    MessageBox.Show("Favor Llenar");
                }
                else
                {
                    int id = Utilidades.TOINT(BuscartextBox.Text);
                    lista = BLL.FacturaBLL.GetList(p => p.FacturaId ==id);
                }
            }
            dataGridView1.DataSource = lista;
        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                BuscartextBox.Enabled = false;
            }

            else if (comboBox1.SelectedIndex == 1)
            {


                BuscartextBox.Enabled = true;

            }

            else if (comboBox1.SelectedIndex == 2)
            {


                BuscartextBox.Enabled = true;

            }
            dataGridView1.DataSource = lista;
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            RFacturas factura = new RFacturas(lista);
            factura.Show();
        }

        private void BuscartextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SeleccionarCombo();
            }
        }
    }
}
