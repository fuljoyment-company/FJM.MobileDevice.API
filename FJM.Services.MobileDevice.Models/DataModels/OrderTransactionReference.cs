using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("identifier", Name = "<OrderTransactionReferences_06012022, IndexBuilderProposed>")]
[Index("transactionReference", "order", Name = "_dta_index_OrderTransactionReferences_5_767341798__K4_K2")]
[Index("order", Name = "_dta_index_OrderTransactionReferences_6_767341798__K2_1_3_4")]
public partial class OrderTransactionReference
{
    [Key]
    public int id { get; set; }

    public int order { get; set; }

    public int identifier { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string transactionReference { get; set; } = null!;
}
