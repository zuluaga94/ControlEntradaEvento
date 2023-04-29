using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventControl.Share.Entities
{
    internal class EventTicket
    {
        public int Id { get; set; }
        public DateTime UseDate { get; set; }
        public bool Used { get; set; }
        public string Location { get; set; }
    }
}
