﻿// <auto-generated />
using System;
using CloudFavs.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudFavs.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200502113732_Add_ParentFolder_Attribute_To_Folder_Model")]
    partial class Add_ParentFolder_Attribute_To_Folder_Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudFavs.Shared.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Favorites");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"),
                            Created = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FolderId = new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                            IsPinned = true,
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "BBC News",
                            OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"),
                            Uri = "http://www.bbcnews.com"
                        });
                });

            modelBuilder.Entity("CloudFavs.Shared.Folder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentFolderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"),
                            Created = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Learning",
                            OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34")
                        },
                        new
                        {
                            Id = new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                            Created = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "News",
                            OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34")
                        },
                        new
                        {
                            Id = new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"),
                            Created = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModified = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Games",
                            OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34")
                        });
                });

            modelBuilder.Entity("CloudFavs.Shared.Favorite", b =>
                {
                    b.HasOne("CloudFavs.Shared.Folder", "Folder")
                        .WithMany()
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CloudFavs.Shared.Folder", b =>
                {
                    b.HasOne("CloudFavs.Shared.Folder", "ParentFolder")
                        .WithMany()
                        .HasForeignKey("ParentFolderId");
                });
#pragma warning restore 612, 618
        }
    }
}