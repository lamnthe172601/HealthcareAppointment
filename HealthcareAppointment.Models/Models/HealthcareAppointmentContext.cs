﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointment.Models.Models;

public partial class HealthcareAppointmentContext : DbContext
{
    public HealthcareAppointmentContext(DbContextOptions<HealthcareAppointmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DoctorId)
                .IsRequired()
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PatientId)
                .IsRequired()
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Doctor).WithMany(p => p.AppointmentDoctors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_User1");

            entity.HasOne(d => d.Patient).WithMany(p => p.AppointmentPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Specialization)
                .IsRequired()
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
        SeedData(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User {  Name = "John Doe", Email = "john@example.com", DateOfBirth = new DateTime(1980, 1, 1), Password = "Password123!", Role = 0, Specialization = "Patient" },
            new User {  Name = "Jane Smith", Email = "jane@example.com", DateOfBirth = new DateTime(1985, 5, 15), Password = "Password123!", Role = 1, Specialization = "Cardiology" },
            new User {  Name = "Bob Johnson", Email = "bob@example.com", DateOfBirth = new DateTime(1990, 10, 20), Password = "Password123!", Role = 0, Specialization = "Patient" },
            new User {  Name = "Alice Brown", Email = "alice@example.com", DateOfBirth = new DateTime(1975, 3, 30), Password = "Password123!", Role = 1, Specialization = "Neurology" },
            new User {  Name = "Charlie Wilson", Email = "charlie@example.com", DateOfBirth = new DateTime(1988, 7, 7), Password = "Password123!", Role = 0, Specialization = "Patient" }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment {  PatientId = "1", DoctorId = "2", Date = DateTime.Now.AddDays(1), Status = 0 },
            new Appointment {  PatientId = "3", DoctorId = "4", Date = DateTime.Now.AddDays(2), Status = 0 },
            new Appointment {  PatientId = "5", DoctorId = "2", Date = DateTime.Now.AddDays(3), Status = 0 },
            new Appointment { PatientId = "1", DoctorId = "4", Date = DateTime.Now.AddDays(4), Status = 0 },
            new Appointment {  PatientId = "3", DoctorId = "2", Date = DateTime.Now.AddDays(5), Status = 0 }
        );
    }
}