using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Group17_iCAREAPP.Models;

public partial class Group17ICaredbContext : DbContext
{
    public Group17ICaredbContext()
    {
    }

    public Group17ICaredbContext(DbContextOptions<Group17ICaredbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocumentMetadatum> DocumentMetadata { get; set; }

    public virtual DbSet<DrugsDictionary> DrugsDictionaries { get; set; }

    public virtual DbSet<GeoCode> GeoCodes { get; set; }

    public virtual DbSet<ICareadmin> ICareadmins { get; set; }

    public virtual DbSet<ICareuser> ICareusers { get; set; }

    public virtual DbSet<ICareworker> ICareworkers { get; set; }

    public virtual DbSet<ModificationHistory> ModificationHistories { get; set; }

    public virtual DbSet<PatientRecord> PatientRecords { get; set; }

    public virtual DbSet<TreatmentRecord> TreatmentRecords { get; set; }

    public virtual DbSet<UserPassword> UserPasswords { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:group17.database.windows.net,1433;Initial Catalog=Group17_iCAREDB;Persist Security Info=False;User ID=group17;Password=Ihatesql!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentMetadatum>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK_Table_1");

            entity.Property(e => e.DocId)
                .HasMaxLength(255)
                .HasColumnName("docID");
            entity.Property(e => e.DateOfCreation).HasColumnName("dateOfCreation");
            entity.Property(e => e.DocName)
                .HasMaxLength(255)
                .HasColumnName("docName");
            entity.Property(e => e.PatientId)
                .HasMaxLength(255)
                .HasColumnName("patientID");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("userID");
            entity.Property(e => e.Version).HasColumnName("version");

            entity.HasOne(d => d.Patient).WithMany(p => p.DocumentMetadata)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Table_1_PatientRecord");

            entity.HasOne(d => d.User).WithMany(p => p.DocumentMetadata)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Table_1_iCAREWorker");
        });

        modelBuilder.Entity<DrugsDictionary>(entity =>
        {
            entity.ToTable("DrugsDictionary");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GeoCode>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<ICareadmin>(entity =>
        {
            entity.ToTable("iCAREAdmin");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(255)
                .HasColumnName("adminEmail");
            entity.Property(e => e.DateFinished).HasColumnName("dateFinished");
            entity.Property(e => e.DateHired).HasColumnName("dateHired");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ICareadmin)
                .HasForeignKey<ICareadmin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iCAREAdmin_iCAREUser");
        });

        modelBuilder.Entity<ICareuser>(entity =>
        {
            entity.ToTable("iCAREUser");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ICareworker>(entity =>
        {
            entity.ToTable("iCAREWorker");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.Creator)
                .HasMaxLength(255)
                .HasColumnName("creator");
            entity.Property(e => e.Profession)
                .HasMaxLength(255)
                .HasColumnName("profession");
            entity.Property(e => e.UserPermission)
                .HasMaxLength(255)
                .HasColumnName("userPermission");

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.ICareworkers)
                .HasForeignKey(d => d.Creator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iCAREWorker_iCAREAdmin");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ICareworker)
                .HasForeignKey<ICareworker>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iCAREWorker_iCAREUser");

            entity.HasOne(d => d.UserPermissionNavigation).WithMany(p => p.ICareworkers)
                .HasForeignKey(d => d.UserPermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iCAREWorker_UserRole");
        });

        modelBuilder.Entity<ModificationHistory>(entity =>
        {
            entity.ToTable("ModificationHistory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DatOfModification).HasColumnName("datOfModification");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DocId)
                .HasMaxLength(255)
                .HasColumnName("docID");
            entity.Property(e => e.ModifiedByUserId)
                .HasMaxLength(255)
                .HasColumnName("modifiedByUserID");

            entity.HasOne(d => d.Doc).WithMany(p => p.ModificationHistories)
                .HasForeignKey(d => d.DocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModificationHistory_Table_1");

            entity.HasOne(d => d.ModifiedByUser).WithMany(p => p.ModificationHistories)
                .HasForeignKey(d => d.ModifiedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModificationHistory_iCAREUser");
        });

        modelBuilder.Entity<PatientRecord>(entity =>
        {
            entity.ToTable("PatientRecord");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.BedId)
                .HasMaxLength(255)
                .HasColumnName("bedID");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .HasColumnName("bloodGroup");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.GeographicalUnit)
                .HasMaxLength(255)
                .HasColumnName("geographicalUnit");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.ModifierId)
                .HasMaxLength(255)
                .HasColumnName("modifierID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TreatmentArea)
                .HasMaxLength(255)
                .HasColumnName("treatmentArea");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PatientRecord)
                .HasForeignKey<PatientRecord>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientRecord_GeoCodes");

            entity.HasOne(d => d.Modifier).WithMany(p => p.PatientRecords)
                .HasForeignKey(d => d.ModifierId)
                .HasConstraintName("FK_PatientRecord_iCAREWorker");
        });

        modelBuilder.Entity<TreatmentRecord>(entity =>
        {
            entity.HasKey(e => e.TreatmentId);

            entity.ToTable("TreatmentRecord");

            entity.Property(e => e.TreatmentId)
                .HasMaxLength(255)
                .HasColumnName("treatmentID");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.PatientId)
                .HasMaxLength(255)
                .HasColumnName("patientID");
            entity.Property(e => e.TreatmentDate).HasColumnName("treatmentDate");
            entity.Property(e => e.WorkerId)
                .HasMaxLength(255)
                .HasColumnName("workerID");

            entity.HasOne(d => d.Patient).WithMany(p => p.TreatmentRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TreatmentRecord_PatientRecord");

            entity.HasOne(d => d.Worker).WithMany(p => p.TreatmentRecords)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TreatmentRecord_iCAREWorker");
        });

        modelBuilder.Entity<UserPassword>(entity =>
        {
            entity.ToTable("UserPassword");

            entity.HasIndex(e => e.Id, "IX_UserPassword").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.EncryptedPassword)
                .HasMaxLength(255)
                .HasColumnName("encryptedPassword");
            entity.Property(e => e.PasswordExpiryTime).HasColumnName("passwordExpiryTime");
            entity.Property(e => e.UserAccountExpiryDate).HasColumnName("userAccountExpiryDate");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("userName");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.UserPassword)
                .HasForeignKey<UserPassword>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPassword_iCAREUser");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("roleName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
