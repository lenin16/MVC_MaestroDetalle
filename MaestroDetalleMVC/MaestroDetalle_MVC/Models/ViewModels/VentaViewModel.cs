using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaestroDetalle_MVC.Models.ViewModels
{
    public class VentaViewModel
    {
        public string Cliente { get; set; }
        public List<concepto> Conceptos { get; set; }
    }

    public class concepto
    {
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario{get;set;}
    }
}