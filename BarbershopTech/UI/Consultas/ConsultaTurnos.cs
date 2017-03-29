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
    public partial class ConsultaTurnos : Form
    {
        public List<Turnos> lista { get; set; }
        public ConsultaTurnos()
        {
            InitializeComponent();
            LLenarCombo();
        }

        public void LLenarCombo()
        {
            comboBox1.Items.Insert(0, "Todos");
            comboBox1.Items.Insert(1, "Cliente");
            comboBox1.Items.Insert(2, "Peluquero");
            comboBox1.Items.Insert(3, "Id");
            comboBox1.Items.Insert(4, "Fecha");
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
               
                lista = BLL.TurnoBLL.GetListTodo();
                
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                if (!ValidarTextBox())
                {
                    MessageBox.Show("Favor Llenar");
                }
                else
                {
                    lista = BLL.TurnoBLL.GetList(p => p.NombreCliente == BuscartextBox.Text);
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
                    lista = BLL.TurnoBLL.GetList(p => p.NombrePeluquero == BuscartextBox.Text);
                }

            }

            else if (comboBox1.SelectedIndex == 3)
            {
                if (!ValidarTextBox())
                {
                    MessageBox.Show("Favor Llenar");
                }
                else
                {
                    int id = Utilidades.TOINT(BuscartextBox.Text);
                    lista = BLL.TurnoBLL.GetList(p => p.TurnosId == id);
                }

            }

            else if (comboBox1.SelectedIndex == 4)
            {
               
                if (desdedateTimePicker.Value.Date <= hastadateTimePicker.Value.Date)
                {
                    lista = BLL.TurnoBLL.GetList(p => p.FechaDesde >= desdedateTimePicker.Value.Date && p.FechaHasta < hastadateTimePicker.Value.Date);
                }
            }

            dataGridView1.DataSource = lista;

        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }

        private void ConsultaTurnos_Load(object sender, EventArgs e)
        {

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
                desdedateTimePicker.Enabled = false;
                hastadateTimePicker.Enabled = false;
            }

            else if (comboBox1.SelectedIndex == 1)
            {

               
                BuscartextBox.Enabled = true;
                desdedateTimePicker.Enabled = false;
            }

            else if (comboBox1.SelectedIndex == 2)
            {

                
                BuscartextBox.Enabled = true;
                desdedateTimePicker.Enabled = false;
                hastadateTimePicker.Enabled = false;

            }

            else if (comboBox1.SelectedIndex == 3)
            {
               
                BuscartextBox.Enabled = true;
                desdedateTimePicker.Enabled = false;
                hastadateTimePicker.Enabled = false;
            }

            else if (comboBox1.SelectedIndex == 4)
            {
                BuscartextBox.Enabled = false;
                desdedateTimePicker.Enabled = true;
                hastadateTimePicker.Enabled = true;
               
            }
            dataGridView1.DataSource = lista;
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            RTurnos turno = new RTurnos(lista);
            turno.Show();
        }

        private void BuscartextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SeleccionarCombo();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
