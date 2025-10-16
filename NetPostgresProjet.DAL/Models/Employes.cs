using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("employes")]
public partial class Employes
{
    [Key]
    [Column("idemploye")]
    public int Idemploye { get; set; }

    [Column("nom")]
    [StringLength(100)]
    public string Nom { get; set; } = null!;

    [Column("prenom")]
    [StringLength(100)]
    public string Prenom { get; set; } = null!;

    [Column("contrat")]
    [StringLength(100)]
    public string? Contrat { get; set; }

    [Column("salaire")]
    [Precision(10, 2)]
    public decimal? Salaire { get; set; }

    [Column("typeemploye")]
    [StringLength(50)]
    public string Typeemploye { get; set; } = null!;

    [Column("specialite")]
    [StringLength(100)]
    public string? Specialite { get; set; }

    [Column("service")]
    [StringLength(100)]
    public string? Service { get; set; }

    [InverseProperty("Medecin")]
    public virtual ICollection<Ordonnances> Ordonnances { get; set; } = new List<Ordonnances>();

    [InverseProperty("Medecin")]
    public virtual ICollection<Rendezvous> Rendezvous { get; set; } = new List<Rendezvous>();
}
