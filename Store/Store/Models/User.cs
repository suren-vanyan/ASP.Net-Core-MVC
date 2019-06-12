using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public enum Cities
    {
        None,
        London,
        Paris,
        Erevan,

    }

    public enum QualificationLevels
    {
        None,
        Basic,
        Advanced
    }

    public class User : IdentityUser
    {
        public int Year { get; set; }
        public Cities City { get; set; }
        public QualificationLevels Qualifications { get; set; }
    }
}
