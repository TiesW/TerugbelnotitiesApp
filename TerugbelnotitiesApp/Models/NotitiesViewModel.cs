using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerugbelnotitiesApp.Models
{
    public class NotitiesViewModel
    {
        public List<Notities> notes { get; set; }
        public string editedNote { get; set; }
        public bool editedProcessed { get; set; }
    }
}
