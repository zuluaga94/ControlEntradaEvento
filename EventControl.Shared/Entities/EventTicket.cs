using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EventControl.Shared.Entities
{
    public class EventTicket
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Fecha Uso")]
        public DateTime? UsedDate { get; set; }
        [Display(Name = "Es Usada")]
        public bool Used { get; set; }
        [Display(Name = "Porteria")]
        public string? Location { get; set; }
    }
}
