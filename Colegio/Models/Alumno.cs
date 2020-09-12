using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Models
{
  public class Alumno
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(120)")]
    public string Nombre { get; set; }

    [Required]
    [Column(TypeName = "varchar(18)")]
    public string FNacimiento { get; set; }

    [Required]
    [Column(TypeName = "varchar(16)")]
    public string Password { get; set; }

    [Required]
    [Column(TypeName = "varchar(180)")]
    public string Direccion { get; set; }

    [Required]
    [Column(TypeName = "varchar(12)")]
    public string Telefono { get; set; }
  }
}
