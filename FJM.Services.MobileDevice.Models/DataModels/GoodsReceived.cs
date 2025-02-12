using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("GoodsReceived")]
public partial class GoodsReceived
{
    [Key]
    public int id { get; set; }

    public int? deliveryReceipt { get; set; }

    public int? art_X_Delivery { get; set; }

    public int quantity { get; set; }

    public int user { get; set; }

    public DateTime? scanDate { get; set; }
}
