using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Microsoft.Reporting.WinForms;

namespace BarbershopTech.UI.Reportes
{
    public partial class RUsuarios : Form
    {
        public List<Usuarios> Lista = new List<Usuarios>();
        public RUsuarios(List<Usuarios> lista)
        {
            InitializeComponent();
            Lista = lista;
        }

        private void RUsuarios_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            reportViewer1.LocalReport.ReportPath = @"C:\Users\Leandro\Desktop\BarberShop - copia\BarbershopTech\UI\Reportes\Usuarios.rdlc";

            ReportDataSource source = new ReportDataSource("DataSetUsuarios", Lista);

            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
