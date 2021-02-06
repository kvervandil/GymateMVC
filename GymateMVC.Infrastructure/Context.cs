﻿using GymateMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymateMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Exercise> Exercises{ get; set; }
        public DbSet<Routine> Routines{ get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<DayOfWeek> DaysOfWeek { get; set; }
        public DbSet<ExerciseRoutine> ExerciseRoutine { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Routine>()
                .HasOne(a => a.DayOfWeek).WithOne(b => b.Routine)
                .HasForeignKey<DayOfWeek>(e => e.RoutineId);

            builder.Entity<ExerciseRoutine>()
                .HasKey(er => new { er.ExerciseId, er.RoutineId });

            builder.Entity<ExerciseRoutine>()
                .HasOne<Exercise>(er => er.Exercise)
                .WithMany(e => e.ExerciseRoutines)
                .HasForeignKey(er => er.ExerciseId);


            builder.Entity<ExerciseRoutine>()
                .HasOne<Routine>(er => er.Routine)
                .WithMany(r => r.ExerciseRoutines)
                .HasForeignKey(er => er.RoutineId);
        }
    }
}
