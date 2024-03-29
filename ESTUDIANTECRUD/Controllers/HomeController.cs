﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESTUDIANTECRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ESTUDIANTECRUD.Models.ViewModels;

namespace ESTUDIANTECRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBINSTITUCIONContext _DBContext;

        public HomeController(DBINSTITUCIONContext context)
        {
            _DBContext = context;
        }
        
        public IActionResult Index()
        {
            List<Estudiante> lista = _DBContext.Estudiantes.Include(c=> c.oMateria).ToList();
            return View(lista);
        }

        [HttpGet]
        //Permite mostrar los detalles de un solo estudiante, teniendo como parametro el id que se envia desde el index
        public IActionResult Estudiante_Detalle(int idEstudiante)
        {
            EstudianteVM oEstudianteVM = new EstudianteVM()
            {
                oEstudiante = new Estudiante(),
                oListaMateria = _DBContext.Materia.Select(cargo => new SelectListItem()
                {
                    Text = cargo.NombreMateria,
                    Value = cargo.IdMateria.ToString()
                }).ToList()
            };

            if (idEstudiante != 0)
            {
                oEstudianteVM.oEstudiante = _DBContext.Estudiantes.Find(idEstudiante);
            }


            return View(oEstudianteVM);
        }

        [HttpPost]
        //Realiza a insercion de un nuevo estudiante en la base de datos 
        public IActionResult Estudiante_Detalle(EstudianteVM oEstudianteVM)
        {
            if (oEstudianteVM.oEstudiante.IdEstudiante == 0)
            {
                _DBContext.Estudiantes.Add(oEstudianteVM.oEstudiante);
            }
            else
            {
                _DBContext.Estudiantes.Update(oEstudianteVM.oEstudiante);
            }
            _DBContext.SaveChanges();
            //redirecciona a la pagina de inicio

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        //Muestra el estudiante con sus respetivos datos y solicita de parametro el id del mismo 
        public IActionResult Eliminar(int idEstudiante)
        {
            Estudiante oEstudiante = _DBContext.Estudiantes.Include(c => c.oMateria).Where(e => e.IdEstudiante == idEstudiante).FirstOrDefault();


            return View(oEstudiante);
        }

        [HttpPost]
        //Eliminamos al estudiante 
        public IActionResult Eliminar(Estudiante oEstudiante)
        {
            _DBContext.Estudiantes.Remove(oEstudiante);
            _DBContext.SaveChanges();
            //redirigmos a la pagina de inidio el index 
            return RedirectToAction("Index", "Home");
        }

    }
}