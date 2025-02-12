using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class Role
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string name { get; set; } = null!;

    [StringLength(500)]
    public string? description { get; set; }

    public int permissionNumber { get; set; }
}
