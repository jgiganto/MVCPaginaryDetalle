using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPaginaryDetalle.Models;

namespace MVCPaginaryDetalle.Controllers
{
    public class HospitalController : Controller
    {
        ModeloHospital modelo;
        public HospitalController()
        {
            modelo = new ModeloHospital();
        }
        // GET: Hospital
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MaestroDetalle(int? posicion,String hospitalcod)
        {
            if (posicion == null)
            {
                posicion = 1;
            }
            int ultimo = modelo.GetNumeroHospitales();
            int siguiente = posicion.GetValueOrDefault() + 1;
            if (siguiente > ultimo)
            {
                siguiente = ultimo;
            }
            int anterior = posicion.GetValueOrDefault() - 1;
            if (anterior < 1) { anterior = 1; }
            PAGINARHOSPITAL_Result hospital = modelo.GetHospitalPaginado(posicion.GetValueOrDefault());
            List<DOCTOR> lista =
                modelo.GetDoctoresHospital(hospital.HOSPITAL_COD);
            ViewBag.Doctores = lista;
            ViewBag.Ultimo = ultimo;
            ViewBag.Siguiente = siguiente;
            ViewBag.Anterior = anterior;

            return View(hospital);




        }
    }
}