using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("hospitalisations")]
public partial class Hospitalisations
{
    [Key]
    [Column("idhospitalisation")]
    public int Idhospitalisation { get; set; }

    [Column("dateentree")]
    public DateOnly Dateentree { get; set; }

    [Column("datesortie")]
    public DateOnly? Datesortie { get; set; }

    [Column("patientid")]
    public int Patientid { get; set; }

    [Column("chambreid")]
    public int Chambreid { get; set; }

    [ForeignKey("Chambreid")]
    [InverseProperty("Hospitalisations")]
    public virtual Chambres Chambre { get; set; } = null!;

    [ForeignKey("Patientid")]
    [InverseProperty("Hospitalisations")]
    public virtual Patients Patient { get; set; } = null!;
}
