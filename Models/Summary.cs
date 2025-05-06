using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Personal_Finance_Manager.Models;

[Table("Summary")]
[Index("UserId", Name = "UQ__Summary__1788CC4D59AE2B4F", IsUnique = true)]
public partial class Summary
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalIncome { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Expenses { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal NetBalance { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Summary")]
    public virtual User User { get; set; } = null!;
}
