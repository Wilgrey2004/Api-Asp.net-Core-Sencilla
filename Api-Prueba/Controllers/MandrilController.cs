using Api_Prueba.Models;
using Api_Prueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles(){

        return MandrilDataStore.Instance.Mandrils;
    }
    //Para Acceder a Ete metodo la ruta que debemos usar es la siguiente = http://localhost:5287/Api/Mandril/1
    [HttpGet("{MandrilId}")]
    public ActionResult<Mandril> GetMandril(int MandrilId){
        
        var mandrril = MandrilDataStore.Instance.Mandrils.Find(mandril => mandril.Id == MandrilId); 

        if (mandrril == null){
            return NotFound("El Mandril Solicitado No existe");
        }
        return Ok(mandrril);

    }

    [HttpPost]
    public ActionResult PostMandril(MandrilInsert mandrilInsert){
        var maxIDmadnril = MandrilDataStore.Instance.Mandrils.Max(mandril => mandril.Id);

        var mandril = new Mandril
        {
            Id = maxIDmadnril + 1,
            Nombre = mandrilInsert.Nombre,
            Apellido = mandrilInsert.Apellido,
        };

        MandrilDataStore.Instance.Mandrils.Add(mandril);

        // return Ok("Mandril Creado Correctamente");

        return CreatedAtAction(nameof(GetMandril),
        new {mandrilId=mandril.Id}, mandril);
    }

    [HttpPut("{MandrilId}")]
    public ActionResult<Mandril> PutMandril([FromRoute]int MandrilId, [FromBody]MandrilInsert maninsert){
         var mandrril = MandrilDataStore.Instance.Mandrils.Find(mandril => mandril.Id == MandrilId); 

        if (mandrril == null){
            return NotFound("El Mandril Solicitado No existe");
        }
        mandrril.Nombre = maninsert.Nombre;
        mandrril.Apellido = maninsert.Apellido;
        return Ok("Se ham echo los cambios correctamente...");
    }

    [HttpDelete("{MandrilId}")]
    public ActionResult<Mandril> DeleteMandril(int MandrilId){

        var mandril = MandrilDataStore.Instance.Mandrils.Find(mandril => mandril.Id == MandrilId);

        if (mandril == null){
            return NotFound("El Mandril Solicitado No existe");
        }

        MandrilDataStore.Instance.Mandrils.Remove(mandril);

        return Ok("Mandril Eliminado Correctamente");

    }
}