// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webbsida.Data;

#nullable disable

namespace webbsida.Data.Migrations.Portfolio
{
    [DbContext(typeof(PortfolioDbContext))]
    [Migration("20220304180600_FirstUpdate")]
    partial class FirstUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("webbsida.Models.Course", b =>
                {
                    b.Property<int>("courseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("courseEnddate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("courseStartdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("courseTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("programsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("courseId");

                    b.HasIndex("programsId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("webbsida.Models.Framework", b =>
                {
                    b.Property<int>("frameworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("frameworkTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("languageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("frameworkId");

                    b.HasIndex("languageId");

                    b.ToTable("Framework");
                });

            modelBuilder.Entity("webbsida.Models.Language", b =>
                {
                    b.Property<int>("languageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("languageTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("languageId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("webbsida.Models.Programs", b =>
                {
                    b.Property<int>("programsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("programsDegree")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("programsEnddate")
                        .HasColumnType("TEXT");

                    b.Property<string>("programsSchool")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("programsStartdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("programsTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("programsId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("webbsida.Models.Website", b =>
                {
                    b.Property<int>("websiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("websiteDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("websitePicture")
                        .HasColumnType("TEXT");

                    b.Property<string>("websiteTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("websiteUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("websiteId");

                    b.ToTable("Website");
                });

            modelBuilder.Entity("webbsida.Models.WebsiteFramework", b =>
                {
                    b.Property<int>("websiteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("frameworkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("websiteId", "frameworkId");

                    b.HasIndex("frameworkId");

                    b.ToTable("WebsiteFramework");
                });

            modelBuilder.Entity("webbsida.Models.WebsiteLanguage", b =>
                {
                    b.Property<int>("websiteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("languageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("websiteId", "languageId");

                    b.HasIndex("languageId");

                    b.ToTable("WebsiteLanguage");
                });

            modelBuilder.Entity("webbsida.Models.Course", b =>
                {
                    b.HasOne("webbsida.Models.Programs", "programs")
                        .WithMany()
                        .HasForeignKey("programsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("programs");
                });

            modelBuilder.Entity("webbsida.Models.Framework", b =>
                {
                    b.HasOne("webbsida.Models.Language", "language")
                        .WithMany()
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("language");
                });

            modelBuilder.Entity("webbsida.Models.WebsiteFramework", b =>
                {
                    b.HasOne("webbsida.Models.Framework", "framework")
                        .WithMany("websiteFrameworks")
                        .HasForeignKey("frameworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbsida.Models.Website", "website")
                        .WithMany("websiteFrameworks")
                        .HasForeignKey("websiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("framework");

                    b.Navigation("website");
                });

            modelBuilder.Entity("webbsida.Models.WebsiteLanguage", b =>
                {
                    b.HasOne("webbsida.Models.Language", "language")
                        .WithMany("websiteLanguages")
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbsida.Models.Website", "website")
                        .WithMany("websiteLanguages")
                        .HasForeignKey("websiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("language");

                    b.Navigation("website");
                });

            modelBuilder.Entity("webbsida.Models.Framework", b =>
                {
                    b.Navigation("websiteFrameworks");
                });

            modelBuilder.Entity("webbsida.Models.Language", b =>
                {
                    b.Navigation("websiteLanguages");
                });

            modelBuilder.Entity("webbsida.Models.Website", b =>
                {
                    b.Navigation("websiteFrameworks");

                    b.Navigation("websiteLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
