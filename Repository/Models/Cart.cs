using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Cart")]
public partial class Cart
{
    [Key]
    [Column("ID_Cart")]
    public int IdCart { get; set; }

    [Column("ID_User")]
    public int? IdUser { get; set; }

    [Column("ID_Shop")]
    public int? IdShop { get; set; }

    [Column("ID_Product")]
    public int? IdProduct { get; set; }

    public int? Number { get; set; }
}
