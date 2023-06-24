using Microsoft.AspNetCore.Mvc;
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
            _empleadoServicio.Modificar(empleado);
            return RedirectToAction("Index");
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
    }
}
