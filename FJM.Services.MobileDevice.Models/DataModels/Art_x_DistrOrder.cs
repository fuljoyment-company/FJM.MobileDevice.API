using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class Art_x_DistrOrder
{
    [Key]
    public int id { get; set; }

    public int art_id { get; set; }

    public int distrOrder_id { get; set; }

    public int quantity { get; set; }

    [ForeignKey("art_id")]
    [InverseProperty("Art_x_DistrOrders")]
    public virtual Article art { get; set; } = null!;
}
