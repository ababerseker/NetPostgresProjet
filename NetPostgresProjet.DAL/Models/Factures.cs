using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("factures")]
public partial class Factures
{
    [Key]
    [Column("idfacture")]
    public int Idfacture { get; set; }

    [Column("montant")]
    [Precision(10, 2)]
    public decimal Montant { get; set; }

    [Column("statut")]
    [StringLength(50)]
    public string? Statut { get; set; }

    [Column("patientid")]
    public int Patientid { get; set; }

    [ForeignKey("Patientid")]
    [InverseProperty("Factures")]
    public virtual Patients Patient { get; set; } = null!;
}
