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
    public class UtilizadorController : ControllerBase
    {
        private readonly DataContext _context;

        public UtilizadorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Utilizador> lista = await _context.TBL_UTILIZADOR.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Utilizador novoUtilizador)
        {
            try
            {

                await _context.TBL_UTILIZADOR.AddAsync(novoUtilizador);
                await _context.SaveChangesAsync();

                return Ok(novoUtilizador.IdUtilizador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Utilizador novoUtilizador)
        {
            try
            {
                _context.TBL_UTILIZADOR.Update(novoUtilizador);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Utilizador uRemover = await _context.TBL_UTILIZADOR.FirstOrDefaultAsync(p => p.IdUtilizador == id);

                _context.TBL_UTILIZADOR.Remove(uRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
