using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarbershopTech.UI.Reportes;
using DAL;
using Entidades;

namespace BarbershopTech.Registros
{
    public partial class RegistroFactura : Form
    {
        Facturas factura;
        int fila;
        public RegistroFactura()
        {
            InitializeComponent();
            Limpiar();
            LlenarComboNombre();
            LlenarLabel();
            LlenarComboPago();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegistroFactura_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void LlenarLabel()
        {
            labelAtendido.Text = InicioSesion.Label().Nombres;

        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(comboBoxNombre.Text))
            {
                errorProvider1.SetError(comboBoxNombre, "Favor Llenar");
                return false;
            }
            if (string.IsNullOrEmpty(ProductoIdtextBox.Text))
            {
                errorProvider1.SetError(ProductoIdtextBox, "Favor Llenar");
                return false;
            }


            return true;
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

        public void Limpiar()
        {

            comboBoxNombre.Text = null;
            textBoxComentario.Clear();
            textBoxPorcientoDescuento.Clear();
            textBoxImpuesto.Clear();
            textBoxTotal.Clear();
            textBoxSub.Clear();
            textBoxfacturaId.Clear();
            comboBoxPago.Text = null;
            ProductoIdtextBox.Clear();
            NombreProductotextBox.Clear();
            PrecioProductotextBox.Clear();
            dateTimePickerDesde.Value = DateTime.Now;
            dataGridView1.DataSource = null;
            errorProvider1.Clear();
            ProductoIdtextBox.Clear();

            factura = new Facturas();
        }

        public void LlenarComboNombre()
        {
            List<Clientes> lista = BLL.ClienteBLL.GetListTodo();
            comboBoxNombre.DataSource = lista;
            comboBoxNombre.DisplayMember = "Nombres";
            comboBoxNombre.ValueMember = "ClienteId";

            if (comboBoxNombre.Items.Count > 0)
                comboBoxNombre.SelectedIndex = -1;
        }

        public void LlenarComboPago()
        {

            comboBoxPago.Items.Insert(0, "Contado");
            comboBoxPago.DataSource = comboBoxPago.Items;
            comboBoxPago.DisplayMember = "Contado";

            if (comboBoxPago.Items.Count > 0)
                comboBoxPago.SelectedIndex = -1;
        }

        public Facturas LlenarCampos()
        {

            factura.NombreCliente = comboBoxNombre.Text;
            factura.FacturaId = Utilidades.TOINT(textBoxfacturaId.Text);
            factura.Comentario = textBoxComentario.Text;
            factura.ServicioId = Utilidades.TOINT(ProductoIdtextBox.Text);
            factura.Fecha = dateTimePickerDesde.Value;
            factura.DescuentoPorciento = Utilidades.TOINT(textBoxPorcientoDescuento.Text);
            factura.Impuesto = Utilidades.TOINT(textBoxImpuesto.Text);
            factura.SubTotal = Utilidades.TOINT(textBoxSub.Text);
            factura.Total = Utilidades.TOINT(textBoxTotal.Text);
            factura.TipoPago = comboBoxPago.Text;

            factura.TipoPago = "Contado";

            return factura;
        }

        public void LlenarDataGrid(Facturas nueva)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = nueva.ServicioList;
            //this.dataGridView1.Columns["ServicioId"].Visible = false;
        }


        public void SacarCuenta()
        {
            decimal Subtotal = 0;
            decimal Total = 0;
            const int COLUMNAPRECIO = 2;


            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow precio in dataGridView1.Rows)
                {

                    Subtotal += (int)precio.Cells[COLUMNAPRECIO].Value;
                    textBoxSub.Text = Subtotal.ToString();

                }

                if (textBoxPorcientoDescuento.Text != null)
                {
                    decimal TotalDesc = Convert.ToDecimal((Utilidades.TOINT(textBoxPorcientoDescuento.Text) * Convert.ToDecimal(Subtotal) / 100));
                    Total = Subtotal - TotalDesc;
                    Subtotal = Subtotal - TotalDesc;
                    textBoxSub.Text = Subtotal.ToString();
                    textBoxTotal.Text = Total.ToString();

                }

                if (textBoxImpuesto.Text != null)
                {
                    decimal TotalImp = Convert.ToDecimal((Utilidades.TOINT(textBoxImpuesto.Text) * Convert.ToDecimal(Subtotal) / 100));
                    Total = Subtotal + TotalImp;
                    textBoxSub.Text = Subtotal.ToString();
                    textBoxTotal.Text = Total.ToString();

                }

            }
            else
            {
                MessageBox.Show("Error");
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
                factura = LlenarCampos();

                if (factura.FacturaId != 0)
                {
                    BLL.FacturaBLL.Mofidicar(factura);

                    MessageBox.Show("Se ha Modificado");
                    // dataGridView1.Rows.RemoveAt(fila);
                }
                else
                {
                    BLL.FacturaBLL.Guardar(factura);
                    MessageBox.Show("Se ha Guardado Correctamente");
                }

            }
            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxfacturaId.Text);
            factura = BLL.FacturaBLL.Buscar(p => p.FacturaId == id);
            if (factura != null)
            {
                comboBoxNombre.Text = factura.NombreCliente;
                textBoxComentario.Text = factura.Comentario;
                textBoxPorcientoDescuento.Text = Convert.ToString(factura.DescuentoPorciento.ToString());
                textBoxImpuesto.Text = Convert.ToString(factura.Impuesto.ToString());
                comboBoxPago.Text = factura.TipoPago;
                textBoxSub.Text = Convert.ToString(factura.SubTotal.ToString());
                textBoxTotal.Text = Convert.ToString(factura.Total.ToString());
                LlenarDataGrid(factura);

            }
            else
            {
                MessageBox.Show("No existe");
            }
        }


        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxfacturaId.Text);
            factura = BLL.FacturaBLL.Buscar(p => p.FacturaId == id);
            if (factura != null)
            {
                BLL.FacturaBLL.Eliminar(factura);
                MessageBox.Show("Se ha eliminado");

            }
            else
            {
                MessageBox.Show("Error");
            }
            Limpiar();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductoIdtextBox.Text))
            {
                errorProvider1.SetError(ProductoIdtextBox, "Favor Llenar");
            }
            else
            {
                int id = Utilidades.TOINT(ProductoIdtextBox.Text);
                TipoServicios servicios = BLL.TipoServicioBLL.Buscar(p => p.ServicioId == id);
                bool anadido = false;

                if (servicios != null)
                {
                    foreach (var service in factura.ServicioList)
                    {
                        if (service.ServicioId == servicios.ServicioId)
                        {
                            anadido = true;
                        }
                    }
                }


                if (servicios != null && anadido == false)
                {

                    factura.ServicioList.Add(servicios);
                    LlenarDataGrid(factura);
                    SacarCuenta();

                }

            }
        }

        private void comboBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ProductoIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int id = Utilidades.TOINT(ProductoIdtextBox.Text);
            ValidarNumero(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                TipoServicios producto = BLL.TipoServicioBLL.Buscar(p => p.ServicioId == id);

                if (producto != null)
                {
                    NombreProductotextBox.Text = producto.Nombre;
                    PrecioProductotextBox.Text = producto.Costo.ToString();

                }
                else
                {
                    MessageBox.Show("No existe");
                }
            }

        }

        private void textBoxForma_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void textBoxComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void textBoxPorcientoDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void textBoxImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void textBoxfacturaId_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
        }

        private void textBoxMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Utilidades.TOINT(textBoxMonto.Text) < Utilidades.TOINT(textBoxTotal.Text))
                {
                    MessageBox.Show("El Monto es menor que el total, Favor Completar");
                    textBoxMonto.Clear();
                }
                else
                {
                    decimal devuelta = Convert.ToDecimal(Utilidades.TOINT(textBoxMonto.Text) - Utilidades.TOINT(textBoxTotal.Text));
                    textBoxDevuelta.Text = devuelta.ToString();
                }

            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            RegistroClientes cliente = new RegistroClientes();
            cliente.Show();

        }

        private void comboBoxNombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPorcientoDescuento_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxImpuesto_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxComentario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPorcientoDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dataGridView1.CurrentRow.Index;

            ProductoIdtextBox.Text = dataGridView1[0, fila].Value.ToString();
            NombreProductotextBox.Text = dataGridView1[1, fila].Value.ToString();
            PrecioProductotextBox.Text = dataGridView1[2, fila].Value.ToString();
            buttonBuscar.Enabled = false;
            Eliminarbutton.Enabled = false;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }



    }
}
