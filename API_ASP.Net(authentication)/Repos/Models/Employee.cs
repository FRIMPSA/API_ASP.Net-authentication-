using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.Net_authentication_.Repos.Models;

[Table("EMPLOYEES")]
public partial class Employee
{
    [Key]
    public int EmpId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }
}
