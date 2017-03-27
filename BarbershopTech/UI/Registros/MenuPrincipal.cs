using System;
using System.Windows.Forms;
using BarbershopTech.Consultas;
using BarbershopTech.UI.Reportes;

namespace BarbershopTech.Registros
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            LlenarLabel();
        }

        private RegistroClientes cliente = null;
        private RegistroPeluqueros peluquero = null;
        private RegistroServicios servicio = null;
        private RegistroUsuarios usuario = null;
        private RegistroTurnos turno = null;

        private RegistroFactura factura = null;
        private ConsultaClientes cCliente = null;
        private ConsultaFactura cFactura = null;
        private ConsultaPeluqueros cPeluqueros = null;
        private ConsultaServicios cServicios = null;
        private ConsultaTurnos cTurnos = null;
        private ConsultaUsuarios cUsuario = null;

        private RegistroClientes FormInstanceCliente
        {
            get
            {
                if (cliente == null)
                {
                    cliente = new RegistroClientes();
                    cliente.Disposed += new EventHandler(form_Disposed);
                }

                return cliente;
            }
        }

        private RegistroTurnos FormInstanceTurnos
        {
            get
            {
                if (turno == null)
                {
                    turno = new RegistroTurnos();
                    turno.Disposed += new EventHandler(form_Disposed);
                }

                return turno;
            }
        }

        private RegistroUsuarios FormInstanceUsuarios
        {
            get
            {
                if (usuario == null)
                {
                    usuario = new RegistroUsuarios();
                    usuario.Disposed += new EventHandler(form_Disposed);
                }

                return usuario;
            }
        }

        private RegistroServicios FormInstanceServicio
        {
            get
            {
                if (servicio == null)
                {
                    servicio = new RegistroServicios();
                    servicio.Disposed += new EventHandler(form_Disposed);
                }

                return servicio;
            }
        }

        private RegistroPeluqueros FormInstancePeluquero
        {
            get
            {
                if (peluquero == null)
                {
                    peluquero = new RegistroPeluqueros();
                    peluquero.Disposed += new EventHandler(form_Disposed);
                }

                return peluquero;
            }
        }

        private RegistroFactura FormInstanceFactura
        {
            get
            {
                if (factura == null)
                {
                    factura = new RegistroFactura();
                    factura.Disposed += new EventHandler(form_Disposed);
                }

                return factura;
            }
        }

        private ConsultaClientes InstanceConsultaClientes
        {
            get
            {
                if (cCliente == null)
                {
                    cCliente = new ConsultaClientes();
                    cCliente.Disposed += new EventHandler(form_Disposed);
                }

                return cCliente;
            }
        }

        private ConsultaUsuarios InstanceConsultaUsuarios
        {
            get
            {
                if (cUsuario == null)
                {
                    cUsuario = new ConsultaUsuarios();
                    cUsuario.Disposed += new EventHandler(form_Disposed);
                }

                return cUsuario;
            }
        }

        private ConsultaServicios InstanceConsultaServicio
        {
            get
            {
                if (cServicios == null)
                {
                    cServicios = new ConsultaServicios();
                    cServicios.Disposed += new EventHandler(form_Disposed);
                }

                return cServicios;
            }
        }

        private ConsultaTurnos InstanceConsultaTurnos
        {
            get
            {
                if (cTurnos == null)
                {
                    cTurnos = new ConsultaTurnos();
                    cTurnos.Disposed += new EventHandler(form_Disposed);
                }

                return cTurnos;
            }
        }

        private ConsultaPeluqueros InstanceConsultaPeluqueros

        {
            get
            {
                if (cPeluqueros == null)
                {
                    cPeluqueros = new ConsultaPeluqueros();
                    cPeluqueros.Disposed += new EventHandler(form_Disposed);
                }

                return cPeluqueros;
            }
        }

        private ConsultaFactura InstanceConsultaFactura

        {
            get
            {
                if (cFactura == null)
                {
                    cFactura = new ConsultaFactura();
                    cFactura.Disposed += new EventHandler(form_Disposed);
                }

                return cFactura;
            }
        }

        void form_Disposed(object sender, EventArgs e)
        {
            cliente = null;
            peluquero = null;
            servicio = null;
            usuario = null;
            turno = null;
            factura = null;
            cCliente = null;
            cFactura = null;
            cUsuario = null;
            cPeluqueros = null;
            cServicios = null;
            cTurnos = null;


        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        public void LlenarLabel()
        {
            labelUsuarios.Text = InicioSesion.Label().Tipo;

        }

        public void Permisos()
        {
            if (InicioSesion.Label().Tipo != "Admin")
                registrarUsuariosToolStripMenuItem.Enabled = false;
            else
                registrarUsuariosToolStripMenuItem.Enabled = true;
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroUsuarios r = this.FormInstanceUsuarios;
            r.Show();
            r.BringToFront();

        }

        private void registroClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroClientes r = this.FormInstanceCliente;
            r.Show();
            r.BringToFront();

        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPeluqueros r = this.FormInstancePeluquero;
            r.Show();
            r.BringToFront();

        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroServicios r = this.FormInstanceServicio;
            r.Show();
            r.BringToFront();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroTurnos r = this.FormInstanceTurnos;
            r.Show();
            r.BringToFront();
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroFactura r = this.FormInstanceFactura;
            r.Show();
            r.BringToFront();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //consultas

        private void consultaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaUsuarios c = this.InstanceConsultaUsuarios;
            c.Show();
            c.BringToFront();
        }

        private void consultaEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaClientes c = this.InstanceConsultaClientes;
            c.Show();
            c.BringToFront();
        }

        private void consultaDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaTurnos c = this.InstanceConsultaTurnos;
            c.Show();
            c.BringToFront();
        }

        private void consultaDePeluquerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaPeluqueros c = this.InstanceConsultaPeluqueros;
            c.Show();
            c.BringToFront();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaFactura cf = this.InstanceConsultaFactura;
            cf.Show();
            cf.BringToFront();
        }

        private void serviciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaServicios c = this.InstanceConsultaServicio;
            c.Show();
            c.BringToFront();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cambiarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioSesion l = new InicioSesion();
            l.Show();
        }

        private void labelUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_VisibleChanged(object sender, EventArgs e)
        {
            Permisos();
        }
    }
}
