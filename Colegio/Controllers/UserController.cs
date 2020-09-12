using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colegio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult<List<Alumno>>> Get()
    {
      var listAlumnos = await GetListAlumnos();
      if (listAlumnos.Count<0)
        return NotFound(); 
      
      return listAlumnos;
    }

    [HttpGet("findAlumno")]
    public async Task<ActionResult<Alumno>> GetByIdPassword(AlumnModel alumn)
    {
      var listAlumnos = await GetListAlumnos();
      if (listAlumnos.Count < 0)
        return NotFound();

      var alumno = listAlumnos.FirstOrDefault(
        u=>u.Id == alumn.id && u.Password == alumn.password
      );

      if (alumno == null)
        return NotFound();

      return alumno;
    }

    [HttpPost]
    public async Task<ActionResult<List<Alumno>>> PostAlumno(Alumno alumn)
    {
      var listAlumnos = await GetListAlumnos();

      listAlumnos.Add(new Alumno()
      {
        Id = listAlumnos.Count +1,
        Nombre = alumn.Nombre,
        Direccion = alumn.Direccion,
        Password = alumn.Password,
        FNacimiento = alumn.FNacimiento,
        Telefono = alumn.Telefono
      });

      return listAlumnos;
    }

    private async Task<List<Alumno>> GetListAlumnos()
    {
      var listAlumnos = new List<Alumno>()
      {
        new Alumno(){
          Id = 1,
          Nombre="Raúl Valdivia",
          Direccion="Coop VAB i3",
          Password="1234",
          FNacimiento="1991",
          Telefono="992233554"
        },
        new Alumno(){Id = 2, Nombre="Arturo Cruz", Direccion="Coop VAB i3", Password="5678", FNacimiento="1991", Telefono="923557053"},
      };
      return listAlumnos;
    }

    public class AlumnModel
    {
      public int id { get; set;}
      public string password { get; set;}
    }
  }
}
