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
   
    public class Productos : Controller
    {
        
       private readonly DbContext _contexto;

        public Productos (DbContext contexto)
        {
            _contexto = contexto;
        }

         public ActionResult InsertProductos (ProductoModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_contexto.Valor))
                    {
                        using (SqlCommand cmd = new("sp_InsertProduct", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = u.Nombre;
                            cmd.Parameters.Add("@CantidadExistente", SqlDbType.Int).Value = u.CantidadExistente;
                            cmd.Parameters.Add("@CantidadEntrante", SqlDbType.Int).Value = u.CantidadEntrante;
                            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = u.Precio;
                            cmd.Parameters.Add("@Detalle", SqlDbType.VarChar).Value = u.Detalle;
                            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = u.Codigo;
                            
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
                return View("InsertProductos");
            }
            ViewData["error"] = "Error de credenciales";
            return View("InsertProductos");
        }
    }
}
                                            
                          
                            
                           
            
        
    
        
        
        
        
    
    


      





