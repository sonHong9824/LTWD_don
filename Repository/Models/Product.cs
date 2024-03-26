using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("ID_Product")]
    public int IdProduct { get; set; }

    [Column("Name_Product")]
    public float? NameProduct { get; set; }

    [Column("Avatar_Product")]
    public string? AvatarProduct { get; set; }

    [Column("Name_Producer")]
    public float? NameProducer { get; set; }
}
