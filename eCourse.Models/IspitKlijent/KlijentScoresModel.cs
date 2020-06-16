using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.IspitKlijent
{
    public class KlijentScoresModel
    {
        [Required]
        public int IspitId { get; set; }
        [Required]
        public List<KlijentIspitScore> KlijentPrisustvoScoreList { get; set; }
    }
}
