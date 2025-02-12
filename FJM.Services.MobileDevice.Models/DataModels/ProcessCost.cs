using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class ProcessCost
{
    [Key]
    public int id { get; set; }

    public int? type { get; set; }

    public int client { get; set; }

    public int user { get; set; }

    [StringLength(10)]
    public string? area { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? start { get; set; }

    public int? time { get; set; }

    public int? articleQuantity { get; set; }

    public int? picklist { get; set; }

    public int? order { get; set; }

    [StringLength(50)]
    public string? packlist { get; set; }

    public int? article { get; set; }

    public int? orderQuantity { get; set; }

    public int? mark { get; set; }
}
