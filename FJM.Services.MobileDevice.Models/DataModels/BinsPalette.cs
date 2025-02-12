using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("BinsPalette")]
public partial class BinsPalette
{
    [Key]
    public int id { get; set; }

    public bool isActive { get; set; }

    public int bin_id { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string palette { get; set; } = null!;

    public int quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    [ForeignKey("bin_id")]
    [InverseProperty("BinsPalettes")]
    public virtual BinLocationReference bin { get; set; } = null!;

    [ForeignKey("user")]
    [InverseProperty("BinsPalettes")]
    public virtual User userNavigation { get; set; } = null!;
}
