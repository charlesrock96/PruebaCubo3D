using Matriz3D.Models.DTO;
using Matriz3D.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matriz3D.Controllers
{
    public class PrincipalController : Controller        
    {
        Validaciones v = new Validaciones();
        Calculos c = new Calculos();

        public ActionResult Index()
        {
            Session["msg"] = new Mensaje { code = 3, msg = "El período se encuentra cerrado." };

            return View();
        }

        public PartialViewResult Paso1()
        {            
            return PartialView("_Paso1");
        }

        public PartialViewResult Paso2(int? t)
        {
            string error = v.validarT(t);

            if (String.IsNullOrEmpty(error))
            {
                Session["T"] = t;

                return PartialView("_Paso2");
            }

            Session["msg"] = new Mensaje { code = 3, msg = error };

            return PartialView("_Paso1");
        }

        public PartialViewResult Paso3(int? n, int? m)
        {
            string error = v.validarNM(n, m);

            if (String.IsNullOrEmpty(error))
            {
                Session["N"] = n;
                Session["M"] = m;
                Session["Matriz3D"] = c.crearMatriz3D((int)n);

                return PartialView("_Paso3");
            }

            Session["msg"] = new Mensaje { code = 3, msg = error };

            return PartialView("_Paso2");
        }

        public PartialViewResult Query(string q)
        {
            int N = int.Parse(Session["N"].ToString()); // Se carga el valor de N

            string error = v.validarQuery(q.Trim(), N);

            if (String.IsNullOrEmpty(error))
            {
                var matriz3D = (int[,,])Session["Matriz3D"]; // Se carga la matriz 3D

                string result = c.ejecutarConsulta(matriz3D, q.Trim(), N);

                Session["msg"] = new Mensaje { code = 1, msg = result };

                Session["M"] = ((int)Session["M"] - 1); // Descuento la consulta ejecutada del contador

                if (Session["M"].ToString() == "0")
                {
                    Session["T"] = ((int)Session["T"] - 1); // Descuento el caso de prueba del contador

                    if (Session["T"].ToString() == "0")
                    {
                        return PartialView("_Paso1");
                    }

                    return PartialView("_Paso2");
                }

                return PartialView("_Paso3");
            }

            Session["msg"] = new Mensaje { code = 3, msg = error };

            return PartialView("_Paso3");
        }
    }
}