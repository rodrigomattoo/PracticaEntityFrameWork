using System;
using System.Collections.Generic;

namespace PracticaEntityFrameWork.Data.Entidades
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
