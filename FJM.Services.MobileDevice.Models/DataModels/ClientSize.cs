using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class ClientSize
{
    [Key]
    public int id { get; set; }

    public int client { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string code { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string name { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    [InverseProperty("sizeNavigation")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("sizeNavigation")]
    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();

    [InverseProperty("sizeNavigation")]
    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();

    [ForeignKey("client")]
    [InverseProperty("ClientSizes")]
    public virtual Client clientNavigation { get; set; } = null!;

    [ForeignKey("user")]
    [InverseProperty("ClientSizes")]
    public virtual User userNavigation { get; set; } = null!;
}
