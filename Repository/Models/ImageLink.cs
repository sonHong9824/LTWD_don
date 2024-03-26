using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Image_link")]
public partial class ImageLink
{
    [Key]
    public int Id { get; set; }

    [Column("Image_link")]
    public string? ImageLink1 { get; set; }
}
