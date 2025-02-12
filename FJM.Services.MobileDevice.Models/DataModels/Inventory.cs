using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("Inventory")]
public partial class Inventory
{
    [Key]
    public int id { get; set; }

    public int client { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string inventoryNumber { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? finishDate { get; set; }

    public bool isActive { get; set; }

    [InverseProperty("inventoryNavigation")]
    public virtual ICollection<InventoryScanDetail> InventoryScanDetails { get; set; } = new List<InventoryScanDetail>();

    [ForeignKey("client")]
    [InverseProperty("Inventories")]
    public virtual Client clientNavigation { get; set; } = null!;
}
