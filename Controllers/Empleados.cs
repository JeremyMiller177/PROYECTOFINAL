using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Data;
using System.Data.SqlClient;
using PROYECTOFINAL.Models;
using System.Data;

namespace PROYECTOFINAL.Controllers
{
   
    public class Empleados : Controller
    {
      
       private readonly DbContext _contexto;

        public Empleados (DbContext contexto)
        {
            _contexto = contexto;
        }

        public ActionResult InsertEmpleados (EmpleadosModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_contexto.Valor))
                    {
                        using (SqlCommand cmd = new("sp_InsertEmpleado", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = u.Nombre;                         
                            cmd.Parameters.Add("@Puesto", SqlDbType.VarChar).Value = u.Puesto;
                            
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();                         



                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return View("InsertEmpleados");
            }
            ViewData["error"] = "Error de credenciales";
            return View("InsertEmpleados");
        }






    }
}