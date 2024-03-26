using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [Column("CMND")]
    [StringLength(50)]
    public string? Cmnd { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Address { get; set; }

    [StringLength(50)]
    public string? Sex { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DoB { get; set; }

    [Column("Avatar_Source")]
    public string? AvatarSource { get; set; }

    [Column("Phone_Number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    public float? Budget { get; set; }

    [Column("Id_shop")]
    public int? IdShop { get; set; }

    [Column("Id_fav_product")]
    [StringLength(10)]
    public string? IdFavProduct { get; set; }

    [Column("id_fav_shop")]
    [StringLength(10)]
    public string? IdFavShop { get; set; }
}
