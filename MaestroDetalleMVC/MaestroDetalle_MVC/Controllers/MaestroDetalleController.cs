using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaestroDetalle_MVC.Models.ViewModels;
using MaestroDetalle_MVC.Models;

namespace MaestroDetalle_MVC.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(VentaViewModel model)
        {
            try
            {
                using (BD_MaestroDetalleEntities db = new BD_MaestroDetalleEntities())
                {
                    Venta oVenta = new Venta();
                    oVenta.Fecha = DateTime.Now;
                    oVenta.Cliente = model.Cliente;
                    db.Venta.Add(oVenta);
                    db.SaveChanges();

                    foreach (var oC in model.Conceptos)
                    {
                        Concepto oConcepto = new Concepto();
                        oConcepto.Cantidad = oC.Cantidad;
                        oConcepto.Nombre = oC.Nombre;
                        oConcepto.PrecioUnitario = oC.PrecioUnitario;
                        oConcepto.Total = oC.Cantidad * oC.PrecioUnitario;
                        oConcepto.IdVenta = oVenta.IdVenta;
                        db.Concepto.Add(oConcepto);
                    }

                    db.SaveChanges();
                }
                ViewBag.Mesage = "Registro insertado";
                return View();
            }
            catch (Exception)
            {
                return View(model);
            }
        }
    }
}