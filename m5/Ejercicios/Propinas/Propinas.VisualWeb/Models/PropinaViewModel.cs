using Propinas.Core;
using System.ComponentModel.DataAnnotations;

namespace Propinas.VisualWeb.Models
{
    public class PropinaViewModel
    {
        [Required(ErrorMessage = "Ingrese el monto de la cuenta.")]
        [Range(0, 10000000, ErrorMessage = "El monto debe estar entre 0 y 10.000.000.")]
        [Display(Name = "Monto de la cuenta")]
        public decimal? Monto { get; set; }

        [Required(ErrorMessage = "Ingrese el porcentaje de propina.")]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        [Display(Name = "Porcentaje de propina")]
        public decimal? Porcentaje { get; set; } = 10;
        public DetallePropina? Detalle { get; set; }
    }
}
