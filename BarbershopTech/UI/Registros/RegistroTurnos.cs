using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace BarbershopTech.Registros
{
    public partial class RegistroTurnos : Form
    {
        Turnos turno;
        public RegistroTurnos()
        {
            InitializeComponent();

        }

        private void RegistroTurnos_Load(object sender, EventArgs e)
        {
            LlenarComboNombre();
            LlenarComboPeluquero();
            Limpiar();
            dateTimePickerDesde.Enabled = false;
            ActualizarHoraturno();

        }

        public void Limpiar()
        {
            Peluqueros peluquero = new Peluqueros();
            NombrecomboBox.Text = null;
            dateTimePickerHasta.Value = DateTime.Now;
            IdtextBox.Clear();
            ActualizarHoraturno();
            errorProvider1.Clear();
            turno = new Turnos();

        }

        public void LlenarComboNombre()
        {
            List<Entidades.Clientes> lista = BLL.ClienteBLL.GetListTodo();
            NombrecomboBox.DataSource = lista;
            NombrecomboBox.DisplayMember = "Nombres";
            NombrecomboBox.ValueMember = "ClienteId";

            if (NombrecomboBox.Items.Count >= 1)
            {
                NombrecomboBox.SelectedIndex = -1;
            }


        }

        public void LlenarComboPeluquero()
        {
            List<Entidades.Peluqueros> lista = BLL.PeluqueroBLL.GetListTodo();
            PeluquerocomboBox.DataSource = lista;
            PeluquerocomboBox.DisplayMember = "Nombre";
            PeluquerocomboBox.ValueMember = "PeluqueroId";

            /*if (PeluquerocomboBox.Items.Count >= 1)
            {
                PeluquerocomboBox.SelectedIndex = -1;
            }*/
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(NombrecomboBox.Text))
            {
                errorProvider1.SetError(NombrecomboBox, "Favor Llenar");
                return false;
            }


            if (string.IsNullOrEmpty(PeluquerocomboBox.Text))
            {
                errorProvider1.SetError(PeluquerocomboBox, "Favor Llenar");
                return false;
            }

            if (string.IsNullOrEmpty(dateTimePickerHasta.Text))
            {
                errorProvider1.SetError(dateTimePickerHasta, "Favor Llenar");
                return false;
            }
            return true;
        }

        public Turnos LlenarCampos()
        {
            ActualizarHoraturno();

            turno.ClienteId = Utilidades.TOINT(NombrecomboBox.SelectedValue.ToString());
            turno.PeluqueroId = Utilidades.TOINT(PeluquerocomboBox.SelectedValue.ToString());
            turno.NombreCliente = NombrecomboBox.Text;
            turno.NombrePeluquero = PeluquerocomboBox.Text;
            turno.FechaDesde = dateTimePickerDesde.Value;
            turno.FechaHasta = dateTimePickerHasta.Value;

            return turno;
        }

        public void ActualizarHoraturno()
        {

            Peluqueros peluquero = (Peluqueros)PeluquerocomboBox.SelectedItem;

            if (peluquero != null)
            {
                dateTimePickerDesde.Value = peluquero.HoraOcupadoHasta;
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        public static void ValidarNumero(KeyPressEventArgs pE)

        {
            if (char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
                if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;

            }
            else
            {
                pE.Handled = true;
            }
        }

        public static void ValidarLetras(KeyPressEventArgs pE)
        {
            if (char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
               if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;

            }
            else
                if (char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
            {
                MessageBox.Show("Favor Llenar");

            }
            else
            {

                turno = LlenarCampos();
                BLL.TurnoBLL.Guardar(turno);
                MessageBox.Show("Se guardo correctamente");

                Peluqueros peluquero = (Peluqueros)PeluquerocomboBox.SelectedItem;

                if (peluquero != null)
                {
                    peluquero.HoraOcupadoHasta = dateTimePickerHasta.Value;
                    dateTimePickerDesde.Value = peluquero.HoraOcupadoHasta;
                    BLL.PeluqueroBLL.Mofidicar(peluquero);

                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            Limpiar();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IdtextBox.Text);
            turno = BLL.TurnoBLL.Buscar((p => p.TurnosId == id));

            if (turno != null)
            {
                BLL.TurnoBLL.Eliminar(turno);
                MessageBox.Show("Se ha eliminado Correctamente");
            }
            else
            {
                MessageBox.Show("No se ha Eliminado");

            }
            Limpiar();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IdtextBox.Text);
            turno = BLL.TurnoBLL.Buscar((p => p.TurnosId == id));

            if (turno != null)
            {
                NombrecomboBox.Text = turno.NombreCliente;
                PeluquerocomboBox.Text = turno.NombrePeluquero;
                dateTimePickerHasta.Text = Convert.ToString(turno.FechaHasta);
                MessageBox.Show("Se ha encontrado Correctamente");
            }
            else
            {
                MessageBox.Show("No se ha Eliminado");

            }
        }

        private void NombrecomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void PeluquerocomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void PeluquerocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarHoraturno();
        }

        private void dateTimePickerHasta_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!Validar())
                {
                    MessageBox.Show("Favor Llenar");

                }
                else
                {

                    turno = LlenarCampos();
                    BLL.TurnoBLL.Guardar(turno);
                    MessageBox.Show("Se guardo correctamente");

                    Peluqueros peluquero = (Peluqueros)PeluquerocomboBox.SelectedItem;

                    if (peluquero != null)
                    {
                        peluquero.HoraOcupadoHasta = dateTimePickerHasta.Value;
                        dateTimePickerDesde.Value = peluquero.HoraOcupadoHasta;
                        BLL.PeluqueroBLL.Mofidicar(peluquero);

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                }
                Limpiar();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
