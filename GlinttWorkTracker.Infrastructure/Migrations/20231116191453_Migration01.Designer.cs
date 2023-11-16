﻿// <auto-generated />
using System;
using GlinttWorkTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GlinttWorkTracker.Infrastructure.Migrations
{
    [DbContext(typeof(GlinttWorkTrackerDbContext))]
    [Migration("20231116191453_Migration01")]
    partial class Migration01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.CodeChanges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuxProject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GlinttApp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdWork")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("CodeChanges", (string)null);
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.DataBaseChanges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdWork")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPwd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("DataBaseChanges", (string)null);
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.DBScripts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdWork")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserPwd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("DBScripts", (string)null);
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Issues", (string)null);
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.NuGetUpdates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdWork")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NuGet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Where")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("NuGetUpdates", (string)null);
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Epic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GlinttApp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdIssue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdWork")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Works", (string)null);
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.CodeChanges", b =>
                {
                    b.HasOne("GlinttWorkTracker.Domain.Models.Work", null)
                        .WithMany("CodeChanges")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.DataBaseChanges", b =>
                {
                    b.HasOne("GlinttWorkTracker.Domain.Models.Work", null)
                        .WithMany("DataBaseChanges")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.DBScripts", b =>
                {
                    b.HasOne("GlinttWorkTracker.Domain.Models.Work", null)
                        .WithMany("DBScripts")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.NuGetUpdates", b =>
                {
                    b.HasOne("GlinttWorkTracker.Domain.Models.Work", null)
                        .WithMany("NuGetUpdates")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("GlinttWorkTracker.Domain.Models.Work", b =>
                {
                    b.Navigation("CodeChanges");

                    b.Navigation("DBScripts");

                    b.Navigation("DataBaseChanges");

                    b.Navigation("NuGetUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}