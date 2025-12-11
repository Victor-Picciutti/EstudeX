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

        [HttpPost]
        public async Task<IActionResult> Add(Duvida novaDuvida)
        {
            try
            {

                await _context.TBL_DUVIDA.AddAsync(novaDuvida);
                await _context.SaveChangesAsync();

                return Ok(novaDuvida.IdDuvida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Duvida novaDuvida)
        {
            try
            {
                _context.TBL_DUVIDA.Update(novaDuvida);
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
                Duvida uRemover = await _context.TBL_DUVIDA.FirstOrDefaultAsync(p => p.IdDuvida == id);

                _context.TBL_DUVIDA.Remove(uRemover);
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