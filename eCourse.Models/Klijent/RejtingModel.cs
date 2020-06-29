using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.Klijent
{
    public class RejtingModel
    {
        [Required]
        public int InstancaId { get; set; }
        [Required]
        public int Rejting { get; set; }
    }
}
