using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceCRUDTokaMVC.Models;
using WebServiceCRUDTokaMVC.Models.Request;
using WebServiceCRUDTokaMVC.Models.Response;

namespace WebServiceCRUDTokaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonasController : ControllerBase
    {



        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<TbPersonasFisica>> oRespuesta = new Respuesta<List<TbPersonasFisica>>();
            try
            {
                using (PersonasFisicasContext db = new PersonasFisicasContext())
                {
                    var lst = db.TbPersonasFisicas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }




            return Ok(oRespuesta);
        }

        //Método para agregar nuevas personas
        [HttpPost]
        public IActionResult Add(PersonaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (PersonasFisicasContext db = new PersonasFisicasContext())
                {

                    TbPersonasFisica oPersonas = new TbPersonasFisica();
                    oPersonas.Nombre = model.Nombre;
                    oPersonas.ApellidoPaterno = model.ApellidoPaterno;
                    oPersonas.ApellidoMaterno = model.ApellidoMaterno;
                    oPersonas.Rfc = model.RFC;
                    oPersonas.FechaNacimiento = model.FechaNacimiento;
                    oPersonas.UsuarioAgrega = 1;

                    db.TbPersonasFisicas.Add(oPersonas);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }




            return Ok(oRespuesta);
        }


        [HttpPut]
        public IActionResult Edit(PersonaRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (PersonasFisicasContext db = new PersonasFisicasContext())
                {
                    TbPersonasFisica oPersonas = db.TbPersonasFisicas.Find(model.IdPersonaFisica);
                    oPersonas.Nombre = model.Nombre;
                    oPersonas.ApellidoPaterno = model.ApellidoPaterno;
                    oPersonas.ApellidoMaterno = model.ApellidoMaterno;
                    oPersonas.Rfc = model.RFC;
                    oPersonas.FechaNacimiento = model.FechaNacimiento;
                    oPersonas.UsuarioAgrega = 1;

                    db.Entry(oPersonas).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }




            return Ok(oRespuesta);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                using (PersonasFisicasContext db = new PersonasFisicasContext())
                {
                    TbPersonasFisica oPersonas = db.TbPersonasFisicas.Find(Id);
                    db.Remove(oPersonas);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }




            return Ok(oRespuesta);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<TbPersonasFisica> oRespuesta = new Respuesta<TbPersonasFisica>();
            try
            {
                using (PersonasFisicasContext db = new PersonasFisicasContext())
                {
                    var lst = db.TbPersonasFisicas.Find(Id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }




            return Ok(oRespuesta);
        }




    }
}