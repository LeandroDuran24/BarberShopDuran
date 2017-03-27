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
    public partial class RServicios : Form
    {
        public List<TipoServicios> Lista = new List<TipoServicios>();
        public RServicios(List<TipoServicios> lista)
        {
            InitializeComponent();
            Lista = lista;
        }

        private void RServicios_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            reportViewer1.LocalReport.ReportPath = @"C:\Users\Leandro\Desktop\BarberShop-master\BarbershopTech\UI\Reportes\Servicios.rdlc";

            ReportDataSource source = new ReportDataSource("DataSetServicios", Lista);

            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
