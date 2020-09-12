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
      if (listAlumnos.Count<0){
        return NotFound(); 
      }
      return listAlumnos;
    }

    private async Task<List<Alumno>> GetListAlumnos()
    {
      var listAlumnos = new List<Alumno>()
      {
        new Alumno(){Id = 1, Nombre="Raúl Valdivia", Direccion="Coop VAB i3", Password="1234", FNacimiento="1991", Telefono="992233554"},
        new Alumno(){Id = 2, Nombre="Arturo Cruz", Direccion="Coop VAB i3", Password="5678", FNacimiento="1991", Telefono="923557053"},
      };
      return listAlumnos;
    }
  }
}
