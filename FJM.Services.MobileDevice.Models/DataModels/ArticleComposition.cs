using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class ArticleComposition
{
    [Key]
    public int id { get; set; }

    public int composedProduct { get; set; }

    public int compositionLineProduct { get; set; }

    public int quantity { get; set; }

    [ForeignKey("composedProduct")]
    [InverseProperty("ArticleCompositioncomposedProductNavigations")]
    public virtual Article composedProductNavigation { get; set; } = null!;

    [ForeignKey("compositionLineProduct")]
    [InverseProperty("ArticleCompositioncompositionLineProductNavigations")]
    public virtual Article compositionLineProductNavigation { get; set; } = null!;
}
