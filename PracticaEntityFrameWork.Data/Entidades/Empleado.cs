using System;
using System.Collections.Generic;

namespace PracticaEntityFrameWork.Data.Entidades
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdDepartamento { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
    }
}
