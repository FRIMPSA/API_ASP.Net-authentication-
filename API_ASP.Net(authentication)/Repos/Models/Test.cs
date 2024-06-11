using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.Net_authentication_.Repos.Models;

[Table("test")]
public partial class Test
{
    [Key]
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

    public bool? Taxcode { get; set; }
}
