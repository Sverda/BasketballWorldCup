﻿// <auto-generated />
using BasketballWorldCup.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasketballWorldCup.Database.Migrations
{
    [DbContext(typeof(BasketballContext))]
    partial class BasketballContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketballWorldCup.Model.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Draws");
                });

            modelBuilder.Entity("BasketballWorldCup.Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrawId")
                        .HasColumnType("int");

                    b.Property<string>("Letter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrawId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BasketballWorldCup.Model.Pot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrawId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrawId");

                    b.ToTable("Pots");
                });

            modelBuilder.Entity("BasketballWorldCup.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QualificationZone")
                        .HasColumnType("int");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BasketballWorldCup.Model.TeamGroup", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("TeamGroup");
                });

            modelBuilder.Entity("BasketballWorldCup.Model.TeamPot", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("PotId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "PotId");

                    b.HasIndex("PotId");

                    b.ToTable("TeamPot");
                });

            modelBuilder.Entity("BasketballWorldCup.Model.Group", b =>
                {
                    b.HasOne("BasketballWorldCup.Model.Draw", "Draw")
                        .WithMany()
                        .HasForeignKey("DrawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BasketballWorldCup.Model.Pot", b =>
                {
                    b.HasOne("BasketballWorldCup.Model.Draw", "Draw")
                        .WithMany("Pots")
                        .HasForeignKey("DrawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BasketballWorldCup.Model.TeamGroup", b =>
                {
                    b.HasOne("BasketballWorldCup.Model.Group", "Group")
                        .WithMany("TeamGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballWorldCup.Model.Team", "Team")
                        .WithMany("TeamGroups")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BasketballWorldCup.Model.TeamPot", b =>
                {
                    b.HasOne("BasketballWorldCup.Model.Pot", "Pot")
                        .WithMany("TeamPots")
                        .HasForeignKey("PotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballWorldCup.Model.Team", "Team")
                        .WithMany("TeamPots")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
