using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPF_Market.Repository.Models;

[Table("Iventory")]
public partial class Iventory
{
    [Key]
    public int Id { get; set; }
}
