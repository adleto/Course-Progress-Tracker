using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class KlijentSearchRequestModel :UserSearchRequestModel
    {
        public int? KursInstancaId { get; set; }
    }
}
