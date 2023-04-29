using EventControl.Shared.Entities;
using System.Collections.Generic;

namespace EventControl.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTickets();
        }

        public async Task CheckTickets()
        {
            List<EventTicket> Tickets = new List<EventTicket>();

            for (int i = 1; i <= 50000; i++)
            {  
                Tickets.Add(new EventTicket { UsedDate = null, Used = false, Location = null });
            }
            _context.eventTickets.AddRange(Tickets);
            await _context.SaveChangesAsync();
        }

        
}
}

