using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventControl.Shared.Entities
{
    public class EventTicket
    {
        public int Id { get; set; }
        public DateTime? UsedDate { get; set; }
        public bool Used { get; set; }
        public string? Location { get; set; }
    }
}
