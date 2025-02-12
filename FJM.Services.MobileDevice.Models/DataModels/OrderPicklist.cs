using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class OrderPicklist
{
    [Key]
    public int id { get; set; }

    public bool isActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime creationDate { get; set; }

    public int? type { get; set; }

    public int? mainType { get; set; }

    public bool secondScanActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? secondScanTime { get; set; }

    public int? pooledPicklistNumber { get; set; }

    [StringLength(10)]
    public string? pooledPicklistID { get; set; }

    public int? job { get; set; }

    [InverseProperty("picklistNavigation")]
    public virtual ICollection<ArticleSwap> ArticleSwaps { get; set; } = new List<ArticleSwap>();

    [InverseProperty("picklistNavigation")]
    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();

    [InverseProperty("picklistNavigation")]
    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();
}
