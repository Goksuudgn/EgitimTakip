using EgitimTakip.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingSubject> TrainingSubjects { get; set; }
        public virtual DbSet<TrainingsSubjectsMap> TrainingsSubjectsMaps { get; set; }
        public virtual DbSet<TrainingCategory> TrainingCategories { get; set; }



        //FLUENT API
        //TrainingsSubjectsMapte bir ıd ihtiyacımı< oldu ud vermeemk için burda hallettik. İki tane foreign key yaptık iki tane primary keye izin verilmiyor Yani ikisininde primary key olmasını sağlayan komut bu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingsSubjectsMap>().HasKey(x => new { x.TrainingId, x.TrainingSubjectId });
        }
    }
}
