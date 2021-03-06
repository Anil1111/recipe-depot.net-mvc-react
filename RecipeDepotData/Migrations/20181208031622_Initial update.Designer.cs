﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeDepotData;

namespace RecipeDepotData.Migrations
{
    [DbContext(typeof(RecipeDepotContext))]
    [Migration("20181208031622_Initial update")]
    partial class Initialupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeDepotData.Models.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook");

                    b.Property<string>("Instagram");

                    b.Property<DateTime>("Modified");

                    b.Property<bool>("Online");

                    b.Property<string>("Passwd")
                        .IsRequired();

                    b.Property<string>("Pinterest");

                    b.Property<string>("Twitter");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("RecipeDepotData.Models.DishType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DishTypes");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeDepotData.Models.MainIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ingredient")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("MainIngredients");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Patron", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Email");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CookTime");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DishType")
                        .HasMaxLength(25);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("MainIngredient")
                        .HasMaxLength(25);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("PatronEmail");

                    b.Property<int>("PrepTime");

                    b.Property<string>("Seasons")
                        .HasMaxLength(25);

                    b.Property<bool>("Shared");

                    b.Property<string>("Steps")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("RecipeId");

                    b.HasIndex("PatronEmail");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Rating");

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("RecipeId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Access", b =>
                {
                    b.HasOne("RecipeDepotData.Models.Patron")
                        .WithOne("Access")
                        .HasForeignKey("RecipeDepotData.Models.Access", "Email");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Ingredient", b =>
                {
                    b.HasOne("RecipeDepotData.Models.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecipeDepotData.Models.Recipe", b =>
                {
                    b.HasOne("RecipeDepotData.Models.Patron", "Patron")
                        .WithMany()
                        .HasForeignKey("PatronEmail");
                });

            modelBuilder.Entity("RecipeDepotData.Models.Review", b =>
                {
                    b.HasOne("RecipeDepotData.Models.Patron", "Patron")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecipeDepotData.Models.Recipe")
                        .WithMany("Reviews")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
