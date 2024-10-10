﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project.Infrastructure.Data;

#nullable disable

namespace Project.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241004004537_UserAndRole")]
    partial class UserAndRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Project.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("PK_ROLEID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TX_NAME");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("T_ROLE", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                            CreatedAt = new DateTime(2024, 10, 4, 0, 45, 37, 193, DateTimeKind.Utc).AddTicks(1470),
                            IsDeleted = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                            CreatedAt = new DateTime(2024, 10, 4, 0, 45, 37, 193, DateTimeKind.Utc).AddTicks(1476),
                            IsDeleted = false,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Project.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("PK_USERID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TX_EMAIL");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TX_PASSWORD");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TX_USERNAME");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("T_USER", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0ea3c5e-3d1b-4e39-87d6-662ec97f6dc5"),
                            CreatedAt = new DateTime(2024, 10, 4, 0, 45, 37, 193, DateTimeKind.Utc).AddTicks(1736),
                            Email = "admin@system.com",
                            HashedPassword = "$2a$11$HDSfiDwyjW0948KqxfDP7OaNM6Cc8x1yll7nliNNqLcVqR3cisyZm",
                            IsDeleted = false,
                            RoleId = new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                            Username = "administrator"
                        });
                });

            modelBuilder.Entity("Project.Domain.Entities.User", b =>
                {
                    b.HasOne("Project.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_USER_ROLE");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Project.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
