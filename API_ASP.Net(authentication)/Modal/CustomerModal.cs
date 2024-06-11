using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_ASP.Net_authentication_.Modal
{
    public class CustomerModal
    {
        public int Code { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public string? CreditLimit { get; set; }

        public bool? IsActive { get; set; }

        public bool? Statusname { get; set; }
       // public bool? Taxcode { get; set; }
    }
}
