using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace BarbershopTech.Consultas
{
    public partial class ConsultaServicios : Form
    {
        public List<TipoServicios> lista { get; set; }
        public ConsultaServicios()
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
                lista = BLL.TipoServicioBLL.GetListTodo();
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                if (!ValidarTextBox())
                {
                    MessageBox.Show("Favor Llenar");
                }
                else
                {
                    lista = BLL.TipoServicioBLL.GetList(p => p.Nombre == BuscartextBox.Text);
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
                    lista = BLL.TipoServicioBLL.GetList(p => p.ServicioId == id);
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

        private void BuscartextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SeleccionarCombo();
            }
        }
    }
}
