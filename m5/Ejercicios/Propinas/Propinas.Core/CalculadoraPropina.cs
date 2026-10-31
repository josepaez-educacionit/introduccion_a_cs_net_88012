using System;
using System.Collections.Generic;
using System.Text;

namespace Propinas.Core
{
    public class CalculadoraPropina
    {
        // Porcentaje de esta calculadora, de 0 a 1 (0,10 equivale a 10 %).
        // Se puede leer desde afuera, pero solo se asigna en el constructor.
        public decimal Porcentaje { get; }

        // El constructor valida el dato para que nunca exista una calculadora con un porcentaje inválido.
        public CalculadoraPropina(decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 1)
            {
                throw new ArgumentException("El porcentaje debe estar entre 0 y 1.");
            }

            Porcentaje = porcentaje;
        }

        public decimal CalcularPropina(decimal monto)
        {
            if (monto < 0)
            {
                throw new ArgumentException("El monto no puede ser negativo.");
            }

            // Se redondea a 2 decimales (centavos). Ejemplo: 12,825 pasa a 12,83.
            return Math.Round(monto * Porcentaje, 2, MidpointRounding.AwayFromZero);
        }

        public decimal CalcularTotal(decimal monto)
        {
            return monto + CalcularPropina(monto);
        }

        // Calcula todo junto y devuelve el detalle completo.
        public DetallePropina Calcular(decimal monto)
        {
            decimal propina = CalcularPropina(monto);
            decimal total = monto + propina;

            return new DetallePropina(monto, Porcentaje, propina, total);
        }
    }
}
