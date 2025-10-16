using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("patients")]
public partial class Patients
{
    [Key]
    [Column("idpatient")]
    public int Idpatient { get; set; }

    [Column("nom")]
    [StringLength(100)]
    public string Nom { get; set; } = null!;

    [Column("prenom")]
    [StringLength(100)]
    public string Prenom { get; set; } = null!;

    [Column("datenaissance")]
    public DateOnly Datenaissance { get; set; }

    [InverseProperty("Patient")]
    public virtual Dossierpatients? Dossierpatients { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Factures> Factures { get; set; } = new List<Factures>();

    [InverseProperty("Patient")]
    public virtual ICollection<Hospitalisations> Hospitalisations { get; set; } = new List<Hospitalisations>();

    [InverseProperty("Patient")]
    public virtual ICollection<Ordonnances> Ordonnances { get; set; } = new List<Ordonnances>();

    [InverseProperty("Patient")]
    public virtual ICollection<Rendezvous> Rendezvous { get; set; } = new List<Rendezvous>();
}
