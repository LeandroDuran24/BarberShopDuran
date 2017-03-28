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
    public partial class RegistroServicios : Form
    {
        TipoServicios servicio;

        public RegistroServicios()
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

            if (string.IsNullOrEmpty(CostoTexBox.Text))
            {
                errorProvider1.SetError(CostoTexBox, "Favor de LLenar");
                return false;
            }

            return true;
        }

        public void Limpiar()
        {
            nombretextBox3.Clear();
            idSeriviciotextBox.Clear();
            CostoTexBox.Clear();
            errorProvider1.Clear();

            servicio = new TipoServicios();

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

                servicio.ServicioId = Utilidades.TOINT(idSeriviciotextBox.Text);
                servicio.Nombre = nombretextBox3.Text;
                servicio.Costo = Convert.ToInt32(CostoTexBox.Text);
                if (servicio.ServicioId != 0)
                {
                    BLL.TipoServicioBLL.Mofidicar(servicio);
                    MessageBox.Show("Se ha modificado");
                }
                else
                {
                    BLL.TipoServicioBLL.Guardar(servicio);
                    MessageBox.Show("Se ha Guardado Correctamente...");
                }

                Limpiar();
            }

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idSeriviciotextBox.Text);
            servicio = BLL.TipoServicioBLL.Buscar((p => p.ServicioId == id));

            if (servicio != null)
            {
                BLL.TipoServicioBLL.Eliminar(servicio);
                MessageBox.Show("Se ha eliminado Correctamente");
            }
            else
            {
                MessageBox.Show("No existe");

            }
            Limpiar();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idSeriviciotextBox.Text);
            servicio = BLL.TipoServicioBLL.Buscar((p => p.ServicioId == id));

            if (servicio != null)
            {
                nombretextBox3.Text = servicio.Nombre;
                CostoTexBox.Text = Convert.ToString(servicio.Costo);

               
            }
            else
            {
                MessageBox.Show("No existe");

            }
        }

        private void idSeriviciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void nombretextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void nombretextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CostoButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!Validar())
                {

                    MessageBox.Show("Favor Llenar");
                }
                else
                {

                    servicio.ServicioId = Utilidades.TOINT(idSeriviciotextBox.Text);
                    servicio.Nombre = nombretextBox3.Text;
                    servicio.Costo = Convert.ToInt32(CostoTexBox.Text);
                    if (servicio.ServicioId != 0)
                    {
                        BLL.TipoServicioBLL.Mofidicar(servicio);
                        MessageBox.Show("Se ha modificado");
                    }
                    else
                    {
                        BLL.TipoServicioBLL.Guardar(servicio);
                        MessageBox.Show("Se ha Guardado Correctamente...");
                    }

                    Limpiar();
                }
            }
        }

        private void RegistroServicios_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
