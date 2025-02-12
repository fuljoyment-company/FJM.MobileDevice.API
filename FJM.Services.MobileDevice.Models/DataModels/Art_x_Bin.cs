using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("Art_x_Bin")]
[Index("art_id", "bin_id", Name = "_dta_index_Art_x_Bin_6_121871601__K2_K3_1_4_5_6_7_8_9_10")]
public partial class Art_x_Bin
{
    [Key]
    public int id { get; set; }

    public int art_id { get; set; }

    public int bin_id { get; set; }

    public int stored_amount { get; set; }

    public int declared_amount { get; set; }

    public DateOnly? dateOfExpiry { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? batchNumber { get; set; }

    public int storageType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime creationDate { get; set; }

    public int user { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? lastChange { get; set; }

    [ForeignKey("art_id")]
    [InverseProperty("Art_x_Bins")]
    public virtual Article art { get; set; } = null!;

    [ForeignKey("bin_id")]
    [InverseProperty("Art_x_Bins")]
    public virtual BinLocationReference bin { get; set; } = null!;

    [ForeignKey("user")]
    [InverseProperty("Art_x_Bins")]
    public virtual User userNavigation { get; set; } = null!;
}
