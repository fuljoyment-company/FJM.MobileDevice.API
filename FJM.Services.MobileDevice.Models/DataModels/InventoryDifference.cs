using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class InventoryDifference
{
    [Key]
    public int id { get; set; }

    public int inventoryScanId { get; set; }

    public int articleId { get; set; }

    public int inventoryAmount { get; set; }

    public int firstScanAmount { get; set; }

    public int? ControlScanAmount { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? boxIds { get; set; }

    [ForeignKey("articleId")]
    [InverseProperty("InventoryDifferences")]
    public virtual Article article { get; set; } = null!;

    [ForeignKey("inventoryScanId")]
    [InverseProperty("InventoryDifferences")]
    public virtual InventoryScanDetail inventoryScan { get; set; } = null!;
}
