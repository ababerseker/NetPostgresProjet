using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("rendezvous")]
public partial class Rendezvous
{
    [Key]
    [Column("idrdv")]
    public int Idrdv { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("heure")]
    public TimeOnly Heure { get; set; }

    [Column("patientid")]
    public int Patientid { get; set; }

    [Column("medecinid")]
    public int Medecinid { get; set; }

    [ForeignKey("Medecinid")]
    [InverseProperty("Rendezvous")]
    public virtual Employes Medecin { get; set; } = null!;

    [ForeignKey("Patientid")]
    [InverseProperty("Rendezvous")]
    public virtual Patients Patient { get; set; } = null!;
}
