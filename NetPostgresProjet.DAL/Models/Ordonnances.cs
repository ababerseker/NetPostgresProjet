using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("ordonnances")]
public partial class Ordonnances
{
    [Key]
    [Column("idordonnance")]
    public int Idordonnance { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("medicament")]
    public string Medicament { get; set; } = null!;

    [Column("patientid")]
    public int Patientid { get; set; }

    [Column("medecinid")]
    public int Medecinid { get; set; }

    [ForeignKey("Medecinid")]
    [InverseProperty("Ordonnances")]
    public virtual Employes Medecin { get; set; } = null!;

    [ForeignKey("Patientid")]
    [InverseProperty("Ordonnances")]
    public virtual Patients Patient { get; set; } = null!;
}
