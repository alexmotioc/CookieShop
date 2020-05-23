﻿// <auto-generated />
using System;
using CookieShop.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CookieShop.EntityFramework.Migrations
{
    [DbContext(typeof(CookieShopDbContext))]
    partial class CookieShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CookieShop.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountHolderId");

                    b.Property<double>("Balance");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.Cookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<int>("StockID");

                    b.Property<int>("Sweeteners");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("StockID")
                        .IsUnique();

                    b.ToTable("Cookies");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.CookieRating", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("CookieID");

                    b.Property<int>("Id");

                    b.Property<int>("Rating");

                    b.HasKey("UserID", "CookieID");

                    b.HasAlternateKey("CookieID", "UserID");

                    b.ToTable("CookieRatings");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.FavoriteCookies", b =>
                {
                    b.Property<int>("AccountID");

                    b.Property<int>("CookieID");

                    b.HasKey("AccountID", "CookieID");

                    b.HasIndex("CookieID");

                    b.ToTable("FavoriteCookies");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.PurchaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<int>("Amount");

                    b.Property<int?>("CookieId");

                    b.Property<DateTime>("DateProcessed");

                    b.Property<bool>("IsPurchase");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CookieId");

                    b.ToTable("PurchaseHistory");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateJoined");

                    b.Property<string>("Email");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.Account", b =>
                {
                    b.HasOne("CookieShop.Domain.Models.User", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");
                });

            modelBuilder.Entity("CookieShop.Domain.Models.Cookie", b =>
                {
                    b.HasOne("CookieShop.Domain.Models.Stock", "Stock")
                        .WithOne("Cookie")
                        .HasForeignKey("CookieShop.Domain.Models.Cookie", "StockID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CookieShop.Domain.Models.CookieRating", b =>
                {
                    b.HasOne("CookieShop.Domain.Models.Cookie", "Cookie")
                        .WithMany("Ratings")
                        .HasForeignKey("CookieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CookieShop.Domain.Models.Account", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CookieShop.Domain.Models.FavoriteCookies", b =>
                {
                    b.HasOne("CookieShop.Domain.Models.Account", "Account")
                        .WithMany("FavoriteCookies")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CookieShop.Domain.Models.Cookie", "Cookie")
                        .WithMany("AccountsIsFavouredBy")
                        .HasForeignKey("CookieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CookieShop.Domain.Models.PurchaseHistory", b =>
                {
                    b.HasOne("CookieShop.Domain.Models.Account", "Account")
                        .WithMany("PurchaseHistory")
                        .HasForeignKey("AccountId");

                    b.HasOne("CookieShop.Domain.Models.Cookie", "Cookie")
                        .WithMany()
                        .HasForeignKey("CookieId");
                });
#pragma warning restore 612, 618
        }
    }
}
