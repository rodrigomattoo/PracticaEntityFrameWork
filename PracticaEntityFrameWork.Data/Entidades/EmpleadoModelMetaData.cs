using System.ComponentModel.DataAnnotations;

namespace PracticaEntityFrameWork.Data.Entidades
{
    public class EmpleadoModelMetaData
    {
        [Required(ErrorMessage = "Debe Ingresar un Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un Departamento")]
        public int IdDepartamento { get; set; }
    }
}