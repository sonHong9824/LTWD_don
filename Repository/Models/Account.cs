using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Account")]
public partial class Account
{
    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Key]
    [Column("user_name")]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string? Password { get; set; }
}
