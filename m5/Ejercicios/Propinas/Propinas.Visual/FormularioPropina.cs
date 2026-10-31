using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Propinas.Core;

namespace Propinas.Visual
{
    public partial class FormularioPropina : Form
    {
        public FormularioPropina()
        {
            InitializeComponent();
        }

        private void BotonLimpiar_Click(object sender, EventArgs e)
        {
            campoMonto.Value = 0;
            campoPorcentaje.Value = 10;
            valorPropina.Text = string.Empty;
            valorTotal.Text = string.Empty;
        }

        private void BotonCalcular_Click(object sender, EventArgs e)
        {
            // El usuario escribe el porcentaje de 0 a 100; la calculadora trabaja de 0 a 1.
            decimal porcentaje = campoPorcentaje.Value / 100m;
            CalculadoraPropina calculadora = new CalculadoraPropina(porcentaje);
            DetallePropina detalle = calculadora.Calcular(campoMonto.Value);


            // ToString("C") da formato de moneda según la configuración regional del equipo.
            valorPropina.Text = detalle.Propina.ToString("C");
            valorTotal.Text = detalle.Total.ToString("C");
        }
    }
}
