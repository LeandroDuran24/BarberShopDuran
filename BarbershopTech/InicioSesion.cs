using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarbershopTech.Registros;
using Entidades;

namespace BarbershopTech
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private static Usuarios usuarioLabel = null;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                errorProvider1.SetError(textBoxEmail, "Favor llenar");
                return false;
            }

            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                errorProvider1.SetError(maskedTextBox1, "Favor llenar");
                return false;
            }
            return true;
        }

        public void Limpiar()
        {
            textBoxEmail.Clear();
            maskedTextBox1.Clear();
            errorProvider1.Clear();

        }

        public static Usuarios Label()
        {
            return usuarioLabel;
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

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                Usuarios usuario = null;
                usuario = BLL.UsuarioBLL.Buscar(p => p.Email == textBoxEmail.Text);
                usuarioLabel = usuario;

                if (!Validar())
                {
                    MessageBox.Show("Favor Llenar");
                }
                else
                {
                    if (usuario != null)
                    {
                        if (usuario.Contrasena == maskedTextBox1.Text)
                        {
                            MenuPrincipal menu = new MenuPrincipal();

                            menu.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("La Clave no Coincide con el Email");
                            Limpiar();
                            textBoxEmail.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe ese Usuario");
                        Limpiar();
                        textBoxEmail.Focus();
                    }
                }
            }
        }

        private void Entrarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = null;
            usuario = BLL.UsuarioBLL.Buscar(p => p.Email == textBoxEmail.Text);
            usuarioLabel = usuario;

            if (!Validar())
            {
                MessageBox.Show("Favor Llenar");
            }
            else
            {
                if (usuario != null)
                {
                    if (usuario.Contrasena == maskedTextBox1.Text)
                    {
                        MenuPrincipal menu = new MenuPrincipal();

                        menu.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("La Clave no Coincide con el Email");
                        Limpiar();
                        textBoxEmail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No existe ese Usuario");
                    Limpiar();
                    textBoxEmail.Focus();
                }
            }
        }

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
