using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("id", Name = "_dta_index_ClientColorCodes_6_176823792__K1_4")]
[Index("name", "id", "client", Name = "_dta_index_ClientColorCodes_6_176823792__K4_K1_K2_3_5_6_7_8_9_10")]
public partial class ClientColorCode
{
    [Key]
    public int id { get; set; }

    public int client { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string code { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? name { get; set; }

    public short? redValue { get; set; }

    public short? greenValue { get; set; }

    public short? blueValue { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    [InverseProperty("color")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("colorNavigation")]
    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();

    [InverseProperty("colorNavigation")]
    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();

    [ForeignKey("client")]
    [InverseProperty("ClientColorCodes")]
    public virtual Client clientNavigation { get; set; } = null!;
}
