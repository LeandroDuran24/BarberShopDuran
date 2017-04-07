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
    public partial class RegistroPeluqueros : Form
    {
        Peluqueros peluquero;
        public RegistroPeluqueros()
        {
            InitializeComponent();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(nombretextBox3.Text))
            {
                errorProvider1.SetError(nombretextBox3, "Favor de LLenar");
                return false;
            }

            return true;
        }

        public void Limpiar()
        {
            nombretextBox3.Clear();
            PeluqueroidtextBox.Clear();
            peluquero = new Peluqueros();

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

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PeluqueroidtextBox.Text))
            {
                errorProvider1.SetError(PeluqueroidtextBox, "Favor Llenar");
            }
            else
            {
                int id = int.Parse(PeluqueroidtextBox.Text);
                peluquero = BLL.PeluqueroBLL.Buscar((p => p.PeluqueroId == id));

                if (peluquero != null)
                {

                    BLL.PeluqueroBLL.Eliminar(peluquero);
                    MessageBox.Show("Se ha Eliminado correctamente");

                }
                else
                {
                    MessageBox.Show("No se ha Eliminado");

                }
                Limpiar();
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

                peluquero.PeluqueroId = Utilidades.TOINT(PeluqueroidtextBox.Text);
                peluquero.Nombre = nombretextBox3.Text;
                peluquero.HoraOcupadoHasta = DateTime.Now;

                if (peluquero.PeluqueroId != 0)
                {
                    BLL.PeluqueroBLL.Mofidicar(peluquero);
                    MessageBox.Show("Se ha modificado");
                }
                else
                {
                    BLL.PeluqueroBLL.Guardar(peluquero);
                    MessageBox.Show("Se ha Guardado Correctamente...");
                }

                Limpiar();
                nombretextBox3.Focus();
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PeluqueroidtextBox.Text))
            {
                errorProvider1.SetError(PeluqueroidtextBox, "Favor Llenar");
            }
            else
            {
                int id = int.Parse(PeluqueroidtextBox.Text);
                peluquero = BLL.PeluqueroBLL.Buscar((p => p.PeluqueroId == id));

                if (peluquero != null)
                {
                    nombretextBox3.Text = peluquero.Nombre;

                }
                else
                {
                    MessageBox.Show("No existe");
                    Limpiar();

                }
            }


        }

        private void nombretextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!Validar())
                {

                    MessageBox.Show("Favor Llenar");
                }
                else
                {

                    peluquero.PeluqueroId = Utilidades.TOINT(PeluqueroidtextBox.Text);
                    peluquero.Nombre = nombretextBox3.Text;
                    peluquero.HoraOcupadoHasta = DateTime.Now;

                    if (peluquero.PeluqueroId != 0)
                    {
                        BLL.PeluqueroBLL.Mofidicar(peluquero);
                        MessageBox.Show("Se ha modificado");
                    }
                    else
                    {
                        BLL.PeluqueroBLL.Guardar(peluquero);
                        MessageBox.Show("Se ha Guardado Correctamente...");
                    }

                    Limpiar();
                }
            }
        }

        private void RegistroPeluqueros_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void PeluqueroidtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(PeluqueroidtextBox.Text))
                {
                    errorProvider1.SetError(PeluqueroidtextBox, "Favor Llenar");
                }
                else
                {
                    int id = int.Parse(PeluqueroidtextBox.Text);
                    peluquero = BLL.PeluqueroBLL.Buscar((p => p.PeluqueroId == id));

                    if (peluquero != null)
                    {
                        nombretextBox3.Text = peluquero.Nombre;

                    }
                    else
                    {
                        MessageBox.Show("No existe");
                        Limpiar();

                    }
                }

            }
        }
    }
}
