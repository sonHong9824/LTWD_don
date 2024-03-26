using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Shop")]
public partial class Shop
{
    [Key]
    [Column("ID_Shop")]
    public int IdShop { get; set; }

    [Column("Name_Shop")]
    [StringLength(50)]
    public string? NameShop { get; set; }

    [StringLength(50)]
    public string? Address { get; set; }

    [Column("Shop_Avatar")]
    public string? ShopAvatar { get; set; }

    [Column("Phone_Number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }
}
