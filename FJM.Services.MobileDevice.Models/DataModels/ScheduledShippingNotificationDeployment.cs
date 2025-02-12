using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class ScheduledShippingNotificationDeployment
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string trackingCode { get; set; } = null!;

    public bool processed { get; set; }

    public bool success { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime processingDate { get; set; }

    public int user { get; set; }

    [ForeignKey("user")]
    [InverseProperty("ScheduledShippingNotificationDeployments")]
    public virtual User userNavigation { get; set; } = null!;
}
