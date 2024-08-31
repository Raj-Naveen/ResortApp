using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortApp.Domain.Entities
{
    public class VillaNumber
    {
        //This is how to have a primary key without the default identity column.
        [Key/*to mention this is primary key of the table.*/, DatabaseGenerated(DatabaseGeneratedOption.None)] // But we want to set the villa number.So so disaple the primary key fnction
        [Display(Name ="Villa Number")]
        public int Villa_Number { get; set; }
        [ForeignKey("Villa")]
        public int VillaID { get; set; }
        [ValidateNever]  //this is the another way
        public Villa Villa{ get; set; } //Navigation property

        public string? SpecialDetails { get; set; }
    }
}
