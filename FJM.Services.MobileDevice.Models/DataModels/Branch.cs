using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class Branch
{
    [Key]
    public int id { get; set; }

    public bool active { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string branchID { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? accessPassword { get; set; }

    public int address { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? name { get; set; }

    public bool useSSL { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string currentIPAddress { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string endpointWebserverPath { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? basicAuthUsername { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? basicAuthPassword { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastUpdate { get; set; }

    public int user { get; set; }

    [InverseProperty("branchNavigation")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    [ForeignKey("user")]
    [InverseProperty("Branches")]
    public virtual User userNavigation { get; set; } = null!;
}
