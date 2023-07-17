
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TipoDocumentoController : BaseApiController
{
    private readonly CitasContext _context;
   
    public TipoDocumentoController(CitasContext context){
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get(){
        var tipoDocumentos = await _context.TipoDocumentos.ToListAsync();
        return Ok(tipoDocumentos);
    }
}
