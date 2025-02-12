using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("ProcessTime")]
[Index("type", "client", "user", Name = "<ProcessTime_06012022, IndexBuilderProposed>")]
public partial class ProcessTime
{
    [Key]
    public int id { get; set; }

    public int type { get; set; }

    public int client { get; set; }

    public int user { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime start { get; set; }

    public int time { get; set; }

    public int numberOfArticles { get; set; }

    public int? numberOfOrders { get; set; }

    public int? referenceID { get; set; }
}
