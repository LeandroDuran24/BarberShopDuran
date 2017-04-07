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
    public partial class RegistroClientes : Form
    {
        Clientes cliente;
        public RegistroClientes()
        {
            InitializeComponent();
        }

        private void RegistroClientes_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(nombretextBox.Text))
            {
                errorProvider1.SetError(nombretextBox, "Favor de LLenar");
                return false;
            }
            if (string.IsNullOrEmpty(apellidotextBox.Text))
            {
                errorProvider1.SetError(apellidotextBox, "Favor de LLenar");
                return false;
            }


            return true;
        }

        public void Limpiar()
        {
            IdtextBox.Clear();
            nombretextBox.Clear();
            direcciontextBox1.Clear();
            apellidotextBox.Clear();
            IdtextBox.Clear();
            cedmaskedTextBox.Clear();
            FechadateTimePicker1.Value = DateTime.Today;
            emailextBox.Clear();
            errorProvider1.Clear();

            cliente = new Clientes();
        }

        public Clientes LlenarCampos()
        {

            cliente.ClienteId = Utilidades.TOINT(IdtextBox.Text);
            cliente.Nombres = nombretextBox.Text;
            cliente.Apellidos = apellidotextBox.Text;
            cliente.Direccion = direcciontextBox1.Text;
            cliente.Email = emailextBox.Text;
            cliente.Cedula = cedmaskedTextBox.Text;
            cliente.Fecha = FechadateTimePicker1.Value;
            return cliente;
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
            if (string.IsNullOrEmpty(IdtextBox.Text))
            {
                errorProvider1.SetError(IdtextBox, "Favor Llenar");

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Seguro que desea eliminar?", "¡Advertencia!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(IdtextBox.Text);
                    Clientes conn = BLL.ClienteBLL.Buscar((p => p.ClienteId == id));

                    if (conn != null)
                    {
                        BLL.ClienteBLL.Eliminar(conn);
                        MessageBox.Show("Se ha eliminado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha Eliminado");

                    }
                    Limpiar();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Cancelado...");
                    Limpiar();
                }

            }

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {


            if (!Validar())
            {

                MessageBox.Show("Ha Ocurrido Error...");
            }
            else
            {

                cliente = LlenarCampos();
                if (cliente.ClienteId != 0)
                {
                    BLL.ClienteBLL.Mofidicar(cliente);
                    MessageBox.Show("Se ha modificado");
                }
                else
                {
                    BLL.ClienteBLL.Guardar(cliente);
                    MessageBox.Show("Se ha Guardado Correctamente...");
                }

                Limpiar();
                nombretextBox.Focus();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdtextBox.Text))
            {
                errorProvider1.SetError(IdtextBox, "Favor Llenar");

            }
            else
            {
                int id = int.Parse(IdtextBox.Text);
                cliente = BLL.ClienteBLL.Buscar((p => p.ClienteId == id));

                if (cliente != null)
                {
                    nombretextBox.Text = cliente.Nombres;
                    direcciontextBox1.Text = cliente.Direccion;
                    apellidotextBox.Text = cliente.Apellidos;
                    emailextBox.Text = cliente.Email;
                    cedmaskedTextBox.Text = cliente.Cedula;
                    FechadateTimePicker1.Value = cliente.Fecha;


                }
                else
                {
                    MessageBox.Show("No existe");
                    Limpiar();

                }
            }


        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void IdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(IdtextBox.Text))
                {
                    errorProvider1.SetError(IdtextBox, "Favor Llenar");

                }
                else
                {
                    int id = int.Parse(IdtextBox.Text);
                    cliente = BLL.ClienteBLL.Buscar((p => p.ClienteId == id));

                    if (cliente != null)
                    {
                        nombretextBox.Text = cliente.Nombres;
                        direcciontextBox1.Text = cliente.Direccion;
                        apellidotextBox.Text = cliente.Apellidos;
                        emailextBox.Text = cliente.Email;
                        cedmaskedTextBox.Text = cliente.Cedula;
                        FechadateTimePicker1.Value = cliente.Fecha;


                    }
                    else
                    {
                        MessageBox.Show("No existe");
                        Limpiar();

                    }
                }

            }
        }

        private void nombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void apellidotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void direcciontextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void FechadateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!Validar())
                {

                    MessageBox.Show("Ha Ocurrido Error...");
                }
                else
                {

                    cliente = LlenarCampos();
                    if (cliente.ClienteId != 0)
                    {
                        BLL.ClienteBLL.Mofidicar(cliente);
                        MessageBox.Show("Se ha modificado");
                    }
                    else
                    {
                        BLL.ClienteBLL.Guardar(cliente);
                        MessageBox.Show("Se ha Guardado Correctamente...");
                    }

                    Limpiar();
                }
            }
        }
    }
}
