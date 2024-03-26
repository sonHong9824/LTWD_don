using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[PrimaryKey("Id", "IdShop")]
[Table("Owner")]
public partial class Owner
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("ID_Shop")]
    public int IdShop { get; set; }

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
}
