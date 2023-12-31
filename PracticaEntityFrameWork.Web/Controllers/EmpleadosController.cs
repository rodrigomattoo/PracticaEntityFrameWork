﻿using Microsoft.AspNetCore.Mvc;
using PracticaEntityFrameWork.Data.Entidades;
using PracticaEntityFrameWork.Logica;

namespace PracticaEntityFrameWork.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private IEmpleadoServicio _empleadoServicio;
        private IDepartamentoServicio _departamentoServicio;

        public EmpleadosController(IEmpleadoServicio empleadoServicio, IDepartamentoServicio departamentoServicio)
        {
            _empleadoServicio = empleadoServicio;
            _departamentoServicio = departamentoServicio;
        }
        public IActionResult Index()
        {
            ViewBag.Departamentos = _departamentoServicio.ObtenerTodos();
            List<Empleado> empleados = _empleadoServicio.ObtenerTodos();
            return View(empleados);
        }

        public IActionResult Eliminar(int id)
        {
            _empleadoServicio.Eliminar(id);
            return RedirectToAction("Index");
        }
        public IActionResult Modificar(int id)
        {
            ViewBag.Departamentos = _departamentoServicio.ObtenerTodos();
            return View(_empleadoServicio.BuscarEmpleado(id));
        }
        [HttpPost]
        public IActionResult Modificar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _empleadoServicio.Modificar(empleado);
                return RedirectToAction("Index");
            }
            ViewBag.Departamentos = _departamentoServicio.ObtenerTodos();
            return View(empleado);
        }
        public IActionResult Crear()
        {
            ViewBag.Departamentos = _departamentoServicio.ObtenerTodos();
            return View(new Empleado());
        }
        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            if(ModelState.IsValid)
            {
                _empleadoServicio.Modificar(empleado);
                return RedirectToAction("Index");
            }
            ViewBag.Departamentos = _departamentoServicio.ObtenerTodos();
            return View(empleado);
        }
        [HttpPost]
        public IActionResult Filtrar(int IdDepartamento)
        {
            List<Empleado> empleados = _empleadoServicio.BuscarEmpleadosPorDepartamento(IdDepartamento);
            ViewBag.DepartamentoSeleccionado = IdDepartamento;
            ViewBag.Departamentos = _departamentoServicio.ObtenerTodos();
            return View("Index", empleados);
        }
    }
}
