using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EstudeX.Data;
using EstudeX.Models;
using Microsoft.EntityFrameworkCore;


namespace EstudeX.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class DuvidaController : ControllerBase
    {
        private readonly DataContext _context;

        public DuvidaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Duvida> lista = await _context.TBL_DUVIDA.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}