using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using FormGenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormGenerator.Repository.Migrations
{
    [DbContext(typeof(FormGeneratorDbContext))]
    [Migration("00000000000000_CreateFormGeneratorSchema")]
    partial class CreateFormGeneratorSchema
    {
        public void BuildModel(ModelBuilder modelBuilder)
        {
            BuildTargetModel(modelBuilder);
        }
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Form>(x =>
            {
                x.ToTable("Form");
                x.Property(y => y.Id).ValueGeneratedOnAdd();
                x.HasKey(y => y.Id);
                x.Property(y => y.Code);
                x.Property(y => y.Description);
            });
            modelBuilder.Entity<FormField>(x =>
            {
                x.ToTable("FormField");
                x.Property(y => y.Id).ValueGeneratedOnAdd();
                x.HasKey(y => y.Id);
                x.Property(y => y.Apperance);
                x.Property(y => y.Code);
                x.Property(y => y.Label);
                x.Property(y => y.Style);
            });
            modelBuilder.Entity<FormFieldValidationRule>(x =>
            {
                x.ToTable("FormFieldValidationRule");
                x.Property(y => y.Id).ValueGeneratedOnAdd();
                x.HasKey(y => y.Id);
                x.Property(y => y.Code);
                x.Property(y => y.Description);
                x.Property(y => y.FormFieldId);
                x.Property(y => y.FormConfigurationId);
                x.HasOne(y => y.FormConfiguration)
                    .WithMany(y => y.ValidationRules)
                    .HasForeignKey(y => y.FormConfigurationId);
            });
            modelBuilder.Entity<ControlType>(x =>
            {
                x.ToTable("ControlType");
                x.Property(y => y.Id).ValueGeneratedOnAdd();
                x.HasKey(y => y.Id);
                x.Property(y => y.Code);
                x.Property(y => y.Description);
            });
            modelBuilder.Entity<FormConfiguration>(x =>
            {
                x.ToTable("FormConfiguration");
                x.Property(y => y.Id).ValueGeneratedOnAdd();
                x.HasKey(y => y.Id);
                x.Property(y => y.ControlTypeId);
                x.Property(y => y.FormId);
                x.Property(y => y.FormFieldId);
                x.Property(y => y.Order);
                x.HasOne(y => y.ControlType).WithMany().HasForeignKey(y => y.ControlTypeId);
                x.HasOne(y => y.Form).WithMany(y => y.FormConfigurations).HasForeignKey(y => y.FormId);
                x.HasOne(y => y.FormField).WithMany().HasForeignKey(y => y.FormFieldId);
            });
            modelBuilder.Entity<FormReferenceData>(x =>
            {
                x.Property(y => y.Id);
                x.Property(y => y.TableName);
                x.Property(y => y.WhereClause);
                x.Property(y => y.Code);
                x.Property(y => y.Description);
                x.Property(y => y.FormFieldId);
            });
            modelBuilder.Entity<FormFieldBranching>(x =>
            {
                x.Property(y => y.Id);
                x.Property(y => y.ChildFieldId);
                x.Property(y => y.ParentFieldId);
                x.Property(y => y.FormId);
                x.Property(y => y.BranchingValue);
                x.HasOne(y => y.ParentField).WithMany().HasForeignKey(y => y.ParentFieldId);
                x.HasOne(y => y.ChildField).WithMany().HasForeignKey(y => y.ChildFieldId);
                x.HasOne(y => y.Form).WithMany(y => y.FormFieldBranchings).HasForeignKey(y => y.FormId);
            });
        }
    }
}