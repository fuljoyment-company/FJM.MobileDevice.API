using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class User
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string nickname { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? firstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? middleName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? lastName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? address { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? postalCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? city { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string email { get; set; } = null!;

    public int warehouse { get; set; }

    public bool useWarehouseAsDefault { get; set; }

    public int lastWarehouse { get; set; }

    public int labelPrinter1 { get; set; }

    public int labelPrinter2 { get; set; }

    public int inlayPrinter { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? applicationName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? comment { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? passwordQuestion { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? passwordAnswer { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? lastActivityDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? lastLoginDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? lastPasswordChangedDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? lastLockedOutDate { get; set; }

    public int? failedPasswordAttemptCount { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? failedPasswordAttemptWindowStart { get; set; }

    public int? failedPasswordAnswerAttemptCount { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? failedPasswordAnswerAttemptWindowStart { get; set; }

    public bool? isApproved { get; set; }

    public bool? isOnline { get; set; }

    public bool? isLockedOut { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? preferredStyle { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? mobilePassword { get; set; }

    public bool isActive { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? salt { get; set; }

    public int? role { get; set; }

    public bool rememberLastReturnReason { get; set; }

    [StringLength(50)]
    public string? identCardNumber { get; set; }

    [InverseProperty("userNavigation")]
    public virtual ICollection<Art_x_Bin> Art_x_Bins { get; set; } = new List<Art_x_Bin>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<ArticleSwap> ArticleSwaps { get; set; } = new List<ArticleSwap>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<BinsPalette> BinsPalettes { get; set; } = new List<BinsPalette>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<ClientSize> ClientSizes { get; set; } = new List<ClientSize>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<DeliveryReceiptBoxContent> DeliveryReceiptBoxContents { get; set; } = new List<DeliveryReceiptBoxContent>();

    [InverseProperty("FirstScanUserNavigation")]
    public virtual ICollection<InventoryScanDetail> InventoryScanDetailFirstScanUserNavigations { get; set; } = new List<InventoryScanDetail>();

    [InverseProperty("controlScanUserNavigation")]
    public virtual ICollection<InventoryScanDetail> InventoryScanDetailcontrolScanUserNavigations { get; set; } = new List<InventoryScanDetail>();

    [InverseProperty("firstScanUserNavigation")]
    public virtual ICollection<OrderPosition> OrderPositionfirstScanUserNavigations { get; set; } = new List<OrderPosition>();

    [InverseProperty("secondScanUserNavigation")]
    public virtual ICollection<OrderPosition> OrderPositionsecondScanUserNavigations { get; set; } = new List<OrderPosition>();

    [InverseProperty("firstScanUserNavigation")]
    public virtual ICollection<OrderReturn> OrderReturnfirstScanUserNavigations { get; set; } = new List<OrderReturn>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<OrderReturn> OrderReturnuserNavigations { get; set; } = new List<OrderReturn>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<OrderStatusChange> OrderStatusChanges { get; set; } = new List<OrderStatusChange>();

    [InverseProperty("thirdScanUserNavigation")]
    public virtual ICollection<Order> OrderthirdScanUserNavigations { get; set; } = new List<Order>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<Order> OrderuserNavigations { get; set; } = new List<Order>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<ScheduledShippingNotificationDeployment> ScheduledShippingNotificationDeployments { get; set; } = new List<ScheduledShippingNotificationDeployment>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<WarehouseActionLog> WarehouseActionLogs { get; set; } = new List<WarehouseActionLog>();

    [InverseProperty("userNavigation")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    [ForeignKey("lastWarehouse")]
    [InverseProperty("UserlastWarehouseNavigations")]
    public virtual Warehouse lastWarehouseNavigation { get; set; } = null!;

    [ForeignKey("warehouse")]
    [InverseProperty("UserwarehouseNavigations")]
    public virtual Warehouse warehouseNavigation { get; set; } = null!;
}
