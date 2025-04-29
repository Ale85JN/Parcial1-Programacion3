using System.ComponentModel.DataAnnotations;

namespace Competencia_Deportiva.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
