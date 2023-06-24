using PracticaEntityFrameWork.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEntityFrameWork.Logica;

public interface IDepartamentoServicio
{
    List<Departamento> ObtenerTodos();
    void Agregar(Departamento departamento);
    void Modificar(Departamento departamento);
    void Eliminar(int id);
}
public class DepartamentoServicio : IDepartamentoServicio
{
    private PracticaEntityFrameWorkContext _context;

    public DepartamentoServicio(PracticaEntityFrameWorkContext contexto)
    {
        _context = contexto;
    }
    public void Agregar(Departamento departamento)
    {
        _context.Departamentos.Add(departamento);
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var departamento = _context.Departamentos.Find(id);
        _context.Departamentos.Remove(departamento);
        _context.SaveChanges();
    }

    public void Modificar(Departamento departamento)
    {
        var departamentoBDD = _context.Departamentos.Find(departamento.Id);
        departamentoBDD.Descripcion = departamento.Descripcion;
        _context.SaveChanges(); 
    }

    public List<Departamento> ObtenerTodos()
    {
        return _context.Departamentos.OrderBy(d => d.Descripcion).ToList();
    }
}
