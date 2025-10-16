using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.DAL.Data;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chambres> Chambres { get; set; }

    public virtual DbSet<Dossierpatients> Dossierpatients { get; set; }

    public virtual DbSet<Employes> Employes { get; set; }

    public virtual DbSet<Factures> Factures { get; set; }

    public virtual DbSet<Hospitalisations> Hospitalisations { get; set; }

    public virtual DbSet<Ordonnances> Ordonnances { get; set; }

    public virtual DbSet<Patients> Patients { get; set; }

    public virtual DbSet<Rendezvous> Rendezvous { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chambres>(entity =>
        {
            entity.HasKey(e => e.Idchambre).HasName("chambres_pkey");

            entity.Property(e => e.Etat).HasDefaultValueSql("'libre'::character varying");
        });

        modelBuilder.Entity<Dossierpatients>(entity =>
        {
            entity.HasKey(e => e.Iddossier).HasName("dossierpatients_pkey");

            entity.HasOne(d => d.Patient).WithOne(p => p.Dossierpatients).HasConstraintName("dossierpatients_patientid_fkey");
        });

        modelBuilder.Entity<Employes>(entity =>
        {
            entity.HasKey(e => e.Idemploye).HasName("employes_pkey");
        });

        modelBuilder.Entity<Factures>(entity =>
        {
            entity.HasKey(e => e.Idfacture).HasName("factures_pkey");

            entity.Property(e => e.Statut).HasDefaultValueSql("'en attente'::character varying");

            entity.HasOne(d => d.Patient).WithMany(p => p.Factures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factures_patientid_fkey");
        });

        modelBuilder.Entity<Hospitalisations>(entity =>
        {
            entity.HasKey(e => e.Idhospitalisation).HasName("hospitalisations_pkey");

            entity.HasOne(d => d.Chambre).WithMany(p => p.Hospitalisations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hospitalisations_chambreid_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Hospitalisations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hospitalisations_patientid_fkey");
        });

        modelBuilder.Entity<Ordonnances>(entity =>
        {
            entity.HasKey(e => e.Idordonnance).HasName("ordonnances_pkey");

            entity.HasOne(d => d.Medecin).WithMany(p => p.Ordonnances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordonnances_medecinid_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Ordonnances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordonnances_patientid_fkey");
        });

        modelBuilder.Entity<Patients>(entity =>
        {
            entity.HasKey(e => e.Idpatient).HasName("patients_pkey");
        });

        modelBuilder.Entity<Rendezvous>(entity =>
        {
            entity.HasKey(e => e.Idrdv).HasName("rendezvous_pkey");

            entity.HasOne(d => d.Medecin).WithMany(p => p.Rendezvous)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rendezvous_medecinid_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Rendezvous)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rendezvous_patientid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
