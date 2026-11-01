using System;
using System.Collections.Generic;
using System.Text;

namespace Propinas.Core
{
    // Guarda el resultado de un cálculo de propina: es lo que cada pantalla le muestra al usuario.
    public class DetallePropina
    {
        // Importe de la cuenta, antes de sumar la propina.
        public decimal Monto { get; }

        // Porcentaje aplicado, expresado de 0 a 1 (0,10 equivale a 10 %).
        public decimal Porcentaje { get; }

        // Importe de la propina.
        public decimal Propina { get; }

        // Monto más propina: lo que se paga en total.
        public decimal Total { get; }

        public DetallePropina(decimal monto, decimal porcentaje, decimal propina, decimal total)
        {
            Monto = monto;
            Porcentaje = porcentaje;
            Propina = propina;
            Total = total;
        }
    }
}
