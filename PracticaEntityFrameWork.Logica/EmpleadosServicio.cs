using Microsoft.EntityFrameworkCore;
using PracticaEntityFrameWork.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEntityFrameWork.Logica;

public interface IEmpleadoServicio
{
    List<Empleado> ObtenerTodos();
    void Agregar(Empleado empleado);
    void Modificar(Empleado empleado);
    void Eliminar(int id);
    Empleado BuscarEmpleado(int id);
}
public class EmpleadosServicio : IEmpleadoServicio
{
    private PracticaEntityFrameWorkContext _context;

    public EmpleadosServicio(PracticaEntityFrameWorkContext contexto)
    {
        _context = contexto;
    }
    public void Agregar(Empleado empleado)
    {
        _context.Empleados.Add(empleado);
        _context.SaveChanges();
    }

    public Empleado BuscarEmpleado(int id)
    {
        Empleado empleado = _context.Empleados.Find(id);
        return empleado;
    }

    public void Eliminar(int id)
    {
        var empleadoBDd = _context.Empleados.Find(id);
        _context.Empleados.Remove(empleadoBDd);
        _context.SaveChanges();
    }

    public void Modificar(Empleado empleado)
    {
        var empleadoBDd = _context.Empleados.Find(empleado.Id);
        empleadoBDd.Nombre = empleado.Nombre;
        empleadoBDd.Apellido = empleado.Apellido;
        empleadoBDd.IdDepartamento = empleado.IdDepartamento;
        _context.Update(empleadoBDd);
        _context.SaveChanges();
    }

    public List<Empleado> ObtenerTodos()
    {
        //return _context.Empleados
        //    .Include("IdDepartamentoNavigation")
        //    .ToList();
        return _context.Empleados
            .Include(e => e.IdDepartamentoNavigation).OrderBy(e => e.Nombre)
            .ToList();
    }
}
