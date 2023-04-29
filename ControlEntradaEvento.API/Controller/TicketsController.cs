
using EventControl.API.Data;
using EventControl.API.Helpers;
using EventControl.Shared.DTOs;
using EventControl.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventControl.API.Controller
{
    [ApiController]
    [Route("/api/eventTicket")]
    public class TicketsController : ControllerBase
    {

        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.eventTickets.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.eventTickets
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Id.ToString().Contains(pagination.Filter.ToLower()));
            }

            return Ok(await queryable
                .OrderBy(x => x.Id)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.eventTickets.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Id.ToString().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("full")]
        public async Task<IActionResult> GetFullAsync()
        {
            return Ok(await _context.eventTickets
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var eventTickets = await _context.eventTickets

                .FirstOrDefaultAsync(x => x.Id == id);
            if (eventTickets == null)
            {
                return NotFound();
            }
            return Ok(eventTickets);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(TicketsController eventTickets)
        {
            try
            {
                _context.Update(eventTickets);
                await _context.SaveChangesAsync();
                return Ok(eventTickets);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un ticket con el mismo código");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        
    }
}