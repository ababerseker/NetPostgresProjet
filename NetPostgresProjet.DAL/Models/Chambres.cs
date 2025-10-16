using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("chambres")]
[Index("Numero", Name = "chambres_numero_key", IsUnique = true)]
public partial class Chambres
{
    [Key]
    [Column("idchambre")]
    public int Idchambre { get; set; }

    [Column("numero")]
    public int Numero { get; set; }

    [Column("etat")]
    [StringLength(50)]
    public string? Etat { get; set; }

    [Column("type")]
    [StringLength(50)]
    public string Type { get; set; } = null!;

    [InverseProperty("Chambre")]
    public virtual ICollection<Hospitalisations> Hospitalisations { get; set; } = new List<Hospitalisations>();
}
