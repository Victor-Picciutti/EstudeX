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
    public class RespostaDuvidaController : ControllerBase
    {
        private readonly DataContext _context;

        public RespostaDuvidaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<RespostaDuvida> lista = await _context.TBL_RESPOSTADUVIDA.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RespostaDuvida novaRespostDuvida)
        {
            try
            {

                await _context.TBL_RESPOSTADUVIDA.AddAsync(novaRespostDuvida);
                await _context.SaveChangesAsync();

                return Ok(novaRespostDuvida.IdDuvida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RespostaDuvida novaRespostaDuvida)
        {
            try
            {
                _context.TBL_RESPOSTADUVIDA.Update(novaRespostaDuvida);
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
                RespostaDuvida rdRemover = await _context.TBL_RESPOSTADUVIDA.FirstOrDefaultAsync(p => p.IdDuvida == id);

                _context.TBL_RESPOSTADUVIDA.Remove(rdRemover);
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