using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Table")]
public partial class Table
{
    [Key]
    public int Id { get; set; }

    [Column("Image_link")]
    public string? ImageLink { get; set; }
}
