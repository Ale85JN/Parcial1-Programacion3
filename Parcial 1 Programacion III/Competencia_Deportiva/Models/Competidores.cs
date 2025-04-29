using System.ComponentModel.DataAnnotations;

namespace Competencia_Deportiva.Models
{
    public class Competidores
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe ingresar un Nombre")]
        public string Nombre { get; set; }
        [Range(0,100, ErrorMessage= "El valor debe ser mayor o igual a 0.")]
        public int Edad { get; set; }
        [Required(ErrorMessage ="Debe ingresar una Ciudad de Residencia")]
        public string CiudadResidencia { get; set; }
        [Required(ErrorMessage ="Debe seleccionar una Opción")]
        public int IdDisciplina { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
