using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class InventoryScanDetail
{
    [Key]
    public int id { get; set; }

    public int binID { get; set; }

    public int inventory { get; set; }

    public int inventoryAmount { get; set; }

    public int? FirstScanAmount { get; set; }

    public int? FirstScanUser { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FirstScanTime { get; set; }

    public int? ControlScanAmount { get; set; }

    public int? controlScanUser { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? controlScanTime { get; set; }

    [ForeignKey("FirstScanUser")]
    [InverseProperty("InventoryScanDetailFirstScanUserNavigations")]
    public virtual User? FirstScanUserNavigation { get; set; }

    [InverseProperty("inventoryScan")]
    public virtual ICollection<InventoryDifference> InventoryDifferences { get; set; } = new List<InventoryDifference>();

    [ForeignKey("binID")]
    [InverseProperty("InventoryScanDetails")]
    public virtual BinLocationReference bin { get; set; } = null!;

    [ForeignKey("controlScanUser")]
    [InverseProperty("InventoryScanDetailcontrolScanUserNavigations")]
    public virtual User? controlScanUserNavigation { get; set; }

    [ForeignKey("inventory")]
    [InverseProperty("InventoryScanDetails")]
    public virtual Inventory inventoryNavigation { get; set; } = null!;
}
