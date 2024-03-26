using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Kho")]
public partial class Kho
{
    [Key]
    [Column("Id_sanpham")]
    public int IdSanpham { get; set; }

    [Column("Id_shop")]
    public int IdShop { get; set; }

    public string? Ten { get; set; }

    public float? Gia { get; set; }

    public float? Discount { get; set; }

    [StringLength(10)]
    public string? DoMoi { get; set; }

    [StringLength(50)]
    public string? Type { get; set; }

    public float? Rate { get; set; }

    public int? Number { get; set; }

    [StringLength(10)]
    public string? NumberSold { get; set; }
}
