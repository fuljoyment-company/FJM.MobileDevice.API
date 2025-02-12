using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class Warehouse
{
    [Key]
    public int id { get; set; }

    public int code { get; set; }

    public int branch { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string name { get; set; } = null!;

    public int address { get; set; }

    public int client { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    public bool isExternal { get; set; }

    [StringLength(250)]
    public string warehouseName { get; set; } = null!;

    public bool? isActive { get; set; }

    public bool? isMainWarehouse { get; set; }

    [InverseProperty("warehouseReferenceNavigation")]
    public virtual ICollection<BinLocationReference> BinLocationReferences { get; set; } = new List<BinLocationReference>();

    [InverseProperty("lastWarehouseNavigation")]
    public virtual ICollection<User> UserlastWarehouseNavigations { get; set; } = new List<User>();

    [InverseProperty("warehouseNavigation")]
    public virtual ICollection<User> UserwarehouseNavigations { get; set; } = new List<User>();

    [InverseProperty("warehouseNavigation")]
    public virtual ICollection<WarehouseActionLog> WarehouseActionLogs { get; set; } = new List<WarehouseActionLog>();

    [ForeignKey("branch")]
    [InverseProperty("Warehouses")]
    public virtual Branch branchNavigation { get; set; } = null!;

    [ForeignKey("client")]
    [InverseProperty("Warehouses")]
    public virtual Client clientNavigation { get; set; } = null!;

    [ForeignKey("user")]
    [InverseProperty("Warehouses")]
    public virtual User userNavigation { get; set; } = null!;
}
