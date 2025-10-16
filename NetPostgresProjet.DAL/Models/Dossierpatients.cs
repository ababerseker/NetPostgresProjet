using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetPostgresProjet.DAL.Models;

[Table("dossierpatients")]
[Index("Patientid", Name = "dossierpatients_patientid_key", IsUnique = true)]
public partial class Dossierpatients
{
    [Key]
    [Column("iddossier")]
    public int Iddossier { get; set; }

    [Column("historiquemedical")]
    public string? Historiquemedical { get; set; }

    [Column("patientid")]
    public int Patientid { get; set; }

    [ForeignKey("Patientid")]
    [InverseProperty("Dossierpatients")]
    public virtual Patients Patient { get; set; } = null!;
}
