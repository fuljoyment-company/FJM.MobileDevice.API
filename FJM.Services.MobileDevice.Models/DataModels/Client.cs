using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class Client
{
    [Key]
    public int id { get; set; }

    public int accessID { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string clientNumber { get; set; } = null!;

    public int clientAddress { get; set; }

    public int currency { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? codAmount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string bankAccountOwner { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string bankAccountNumber { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string bankCode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string bankName { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? iban { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? bic { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? separateBankAccountIdentifier { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? separateBankCodeIdentifier { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? separateBankIBANIdentifier { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? separateBankBICIdentifier { get; set; }

    public int shipperAddress { get; set; }

    public int customerServiceCenterAddress { get; set; }

    public int vatRate { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? mailServerAddress { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? mailServerAccount { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? mailServerUsername { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? mailServerPassword { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string notificationSender { get; set; } = null!;

    public bool sendOrderNotification { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? newsletterSender { get; set; }

    public bool webservice { get; set; }

    public bool ftpGet { get; set; }

    public bool ftpPost { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? accessUsername { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? accessPassword { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? fpPath { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? ftpUsername { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? ftpPassword { get; set; }

    public bool voucherIncludedInPositions { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F01 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F02 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F03 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F04 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F05 { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    public bool isActive { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? name { get; set; }

    public int sorting { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? fullName { get; set; }

    public int? clientGroup { get; set; }

    [InverseProperty("clientNavigation")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<ClientColorCode> ClientColorCodes { get; set; } = new List<ClientColorCode>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<ClientSize> ClientSizes { get; set; } = new List<ClientSize>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<DeliveryReceipt> DeliveryReceipts { get; set; } = new List<DeliveryReceipt>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<PartnerStore> PartnerStores { get; set; } = new List<PartnerStore>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<Preference> Preferences { get; set; } = new List<Preference>();

    [InverseProperty("clientNavigation")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    [ForeignKey("user")]
    [InverseProperty("Clients")]
    public virtual User userNavigation { get; set; } = null!;
}
