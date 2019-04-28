﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectGram.Models.Data;

namespace ProjectGram.Migrations
{
    [DbContext(typeof(GramDbContext))]
    [Migration("20190420173239_identityServerAdded")]
    partial class identityServerAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjectGram.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjectGram.Models.Archive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FotoId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Archives");
                });

            modelBuilder.Entity("ProjectGram.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_at");

                    b.Property<int?>("FotoId");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ProjectGram.Models.CommentLikes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentId");

                    b.Property<int?>("CommentLikeId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("CommentLikeId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("ProjectGram.Models.Followed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Followed");
                });

            modelBuilder.Entity("ProjectGram.Models.Follows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int?>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("UserId1");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("ProjectGram.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Ruta");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("ProjectGram.Models.Likes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FotoId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("ProjectGram.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("Avatar");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("FNacimiento");

                    b.Property<string>("NickName")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjectGram.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectGram.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectGram.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjectGram.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectGram.Models.Archive", b =>
                {
                    b.HasOne("ProjectGram.Models.Foto", "Foto")
                        .WithMany("Archives")
                        .HasForeignKey("FotoId");

                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany("Archives")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectGram.Models.Comment", b =>
                {
                    b.HasOne("ProjectGram.Models.Foto", "Foto")
                        .WithMany("Comments")
                        .HasForeignKey("FotoId");

                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectGram.Models.CommentLikes", b =>
                {
                    b.HasOne("ProjectGram.Models.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId");

                    b.HasOne("ProjectGram.Models.CommentLikes", "CommentLike")
                        .WithMany()
                        .HasForeignKey("CommentLikeId");

                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectGram.Models.Followed", b =>
                {
                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany("FollowedList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectGram.Models.Follows", b =>
                {
                    b.HasOne("ProjectGram.Models.Followed", "Followed")
                        .WithOne("Follows")
                        .HasForeignKey("ProjectGram.Models.Follows", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany("Follows")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("ProjectGram.Models.Foto", b =>
                {
                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany("Foto")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectGram.Models.Likes", b =>
                {
                    b.HasOne("ProjectGram.Models.Foto", "Foto")
                        .WithMany("Likes")
                        .HasForeignKey("FotoId");

                    b.HasOne("ProjectGram.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
