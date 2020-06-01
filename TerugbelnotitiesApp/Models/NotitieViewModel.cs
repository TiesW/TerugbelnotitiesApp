using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerugbelnotitiesApp.Models
{
    public class NotitieViewModel
    {
        [StringLength(150)]
        public string Notitie { get; set; }
        public string AssigningUserId { get; set; }
        [StringLength(40)]
        public string AssigningUserName { get; set; }
        public DateTime Timestamp { get; set; }
        [StringLength(25)]
        public string Category { get; set; }
        public bool Processed { get; set; }
        [Required (ErrorMessage = "Voer een telefoonnummer in.")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required (ErrorMessage = "Voer een contactpersoon in.")]
        [StringLength(20)]
        public string PersonToCallName { get; set; }
        public string AssignedUserId { get; set; }
        [Required]
        [StringLength(40)]
        public string AssignedUserName { get; set; }
    }
}
