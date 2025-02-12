using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("order", "_event", Name = "IndexOpenOrdersMissingArticle2")]
[Index("_event", Name = "manIndexOrderStatusChanges")]
public partial class OrderStatusChange
{
    [Key]
    public int id { get; set; }

    public int order { get; set; }

    [Column("event")]
    public int _event { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime time { get; set; }

    public int? user { get; set; }

    public bool shopUpdateSuccessful { get; set; }

    [ForeignKey("user")]
    [InverseProperty("OrderStatusChanges")]
    public virtual User? userNavigation { get; set; }
}
