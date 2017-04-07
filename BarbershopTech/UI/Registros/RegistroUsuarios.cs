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
    public partial class RegistroUsuarios : Form
    {
        Usuarios usuario;
        public RegistroUsuarios()
        {
            InitializeComponent();
            LlenarCombo();
        }

        private void RegistroUsuarios_Load(object sender, EventArgs e)
        {
            ContraseñamaskedTextBox.MaxLength = 14;
            ConfirmarmaskedTextBox.MaxLength = 14;
            Limpiar();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Favor de LLenar");
                return false;
            }

            if (string.IsNullOrEmpty(EmailtextBox.Text))
            {
                errorProvider1.SetError(EmailtextBox, "Favor de LLenar");
                return false;
            }
            if (string.IsNullOrEmpty(ContraseñamaskedTextBox.Text))
            {
                errorProvider1.SetError(ContraseñamaskedTextBox, "Favor de LLenar");
                return false;
            }

            if (string.IsNullOrEmpty(ConfirmarmaskedTextBox.Text))
            {
                errorProvider1.SetError(ConfirmarmaskedTextBox, "Favor Llenar");
                return false;
            }
            return true;
        }

        public void Limpiar()
        {
            NombretextBox.Clear();
            EmailtextBox.Clear();
            ContraseñamaskedTextBox.Clear();
            ConfirmarmaskedTextBox.Clear();
            textBoxId.Clear();
            comboBox1.Text = null;
            errorProvider1.Clear();

            usuario = new Usuarios();

        }

        public Usuarios LlenarCampos()
        {

            usuario.UsuarioId = Utilidades.TOINT(textBoxId.Text);
            usuario.Nombres = NombretextBox.Text;
            usuario.Email = EmailtextBox.Text;
            usuario.Contrasena = Convert.ToString(ContraseñamaskedTextBox.Text);
            usuario.Confirmar = Convert.ToString(ConfirmarmaskedTextBox.Text);
            if (comboBox1.SelectedIndex == 0)
            {
                usuario.Tipo = "Admin";
            }
            else
            {
                usuario.Tipo = "Empleado";
            }
            return usuario;


        }

        public void LlenarCombo()
        {
            comboBox1.Items.Insert(0, "Admin");
            comboBox1.Items.Insert(1, "Empleado");
            comboBox1.DataSource = comboBox1.Items;
            comboBox1.DisplayMember = "Admin";
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = -1;

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

        private void Eliminarbutton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxId.Text))
            {
                errorProvider1.SetError(textBoxId, "Favor Llenar");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Seguro que desea eliminar?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    int id = int.Parse(textBoxId.Text);
                    usuario = BLL.UsuarioBLL.Buscar(p => p.UsuarioId == id);

                    if (usuario != null)
                    {
                        if (usuario.UsuarioId == 1)
                        {
                            MessageBox.Show("No se Puede Eliminar este Usuario");
                        }
                        else
                        {
                            BLL.UsuarioBLL.Eliminar(usuario);
                            MessageBox.Show("Correcto");
                        }


                    }
                    else
                    {
                        MessageBox.Show("No existe");

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

        private void Registrarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
            {

                MessageBox.Show("Favor Llenar");
            }
            else
            {

                usuario = LlenarCampos();
                if (usuario.UsuarioId != 0)
                {
                    BLL.UsuarioBLL.Mofidicar(usuario);
                    MessageBox.Show("Se ha Modificado");
                }
                else
                {
                    if (ContraseñamaskedTextBox.Text != ConfirmarmaskedTextBox.Text)
                    {
                        ConfirmarmaskedTextBox.Clear();
                        MessageBox.Show("No coinciden las Clave");

                    }
                    else
                    {
                        BLL.UsuarioBLL.Guardar(usuario);
                        MessageBox.Show("Se ha Guardado Correctamente..."); ;
                    }
                }
                Limpiar();
                NombretextBox.Focus();

            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxId.Text))
            {
                errorProvider1.SetError(textBoxId, "Favor Llenar");
            }
            else
            {
                int id = int.Parse(textBoxId.Text);
                usuario = BLL.UsuarioBLL.Buscar(p => p.UsuarioId == id);

                if (usuario != null)
                {
                    EmailtextBox.Text = usuario.Email;
                    NombretextBox.Text = usuario.Nombres;
                    ContraseñamaskedTextBox.Text = Convert.ToString(usuario.Contrasena);
                    ConfirmarmaskedTextBox.Text = Convert.ToString(usuario.Confirmar);
                    comboBox1.Text = usuario.Tipo;

                }
                else
                {
                    MessageBox.Show("No existe");
                    Limpiar();
                }
            }


        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBoxId.Text))
                {
                    errorProvider1.SetError(textBoxId, "Favor Llenar");
                }
                else
                {
                    int id = int.Parse(textBoxId.Text);
                    usuario = BLL.UsuarioBLL.Buscar(p => p.UsuarioId == id);

                    if (usuario != null)
                    {
                        EmailtextBox.Text = usuario.Email;
                        NombretextBox.Text = usuario.Nombres;
                        ContraseñamaskedTextBox.Text = Convert.ToString(usuario.Contrasena);
                        ConfirmarmaskedTextBox.Text = Convert.ToString(usuario.Confirmar);
                        comboBox1.Text = usuario.Tipo;

                    }
                    else
                    {
                        MessageBox.Show("No existe");
                        Limpiar();
                    }
                }

            }
        }

        private void EmailtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void ContraseñamaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void ConfirmarmaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

                    usuario = LlenarCampos();
                    if (usuario.UsuarioId != 0)
                    {
                        BLL.UsuarioBLL.Mofidicar(usuario);
                        MessageBox.Show("Se ha Modificado");
                    }
                    else
                    {
                        if (ContraseñamaskedTextBox.Text != ConfirmarmaskedTextBox.Text)
                        {
                            ConfirmarmaskedTextBox.Clear();
                            MessageBox.Show("No coinciden las Clave");

                        }
                        else
                        {
                            BLL.UsuarioBLL.Guardar(usuario);
                            MessageBox.Show("Se ha Guardado Correctamente..."); ;
                        }
                    }
                    Limpiar();
                }
            }
        }
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
