﻿// <auto-generated />
using System;
using BaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BaseModels.Migrations
{
    [DbContext(typeof(GwDbContext))]
    [Migration("20210106130550_GizmosVendorsSetNullable")]
    partial class GizmosVendorsSetNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("BaseModels.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("APIKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BaseModels.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Defense")
                        .HasColumnType("integer");

                    b.Property<string>("StatChoices")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WeightClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("BaseModels.BackItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("StatChoices")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BackItems");
                });

            modelBuilder.Entity("BaseModels.Consumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ApplyCount")
                        .HasColumnType("integer");

                    b.Property<int>("ColorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DurationMs")
                        .HasColumnType("integer");

                    b.Property<string>("ExtraRecipeIds")
                        .HasColumnType("text");

                    b.Property<int>("GuildUpgradeIds")
                        .HasColumnType("integer");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("Skins")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnlockType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("BaseModels.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("BaseModels.GatheringTool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GatheringTools");
                });

            modelBuilder.Entity("BaseModels.Gizmo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("GuildUpgradeId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VendorIds")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gizmos");
                });

            modelBuilder.Entity("BaseModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("ArmorId")
                        .HasColumnType("integer");

                    b.Property<int?>("BackItemId")
                        .HasColumnType("integer");

                    b.Property<string>("ChatLink")
                        .HasColumnType("text");

                    b.Property<int?>("ConsumableId")
                        .HasColumnType("integer");

                    b.Property<int?>("ContainerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Flags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GameTypes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("GatheringToolId")
                        .HasColumnType("integer");

                    b.Property<int?>("GizmoId")
                        .HasColumnType("integer");

                    b.Property<string>("IconURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int?>("MiniatureId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Restrictions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SalvageKitId")
                        .HasColumnType("integer");

                    b.Property<int?>("SkinId")
                        .HasColumnType("integer");

                    b.Property<int?>("TrinketId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UpgradeComponentId")
                        .HasColumnType("integer");

                    b.Property<int>("VendorValue")
                        .HasColumnType("integer");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("BackItemId");

                    b.HasIndex("ConsumableId");

                    b.HasIndex("ContainerId");

                    b.HasIndex("GatheringToolId");

                    b.HasIndex("GizmoId");

                    b.HasIndex("MiniatureId");

                    b.HasIndex("SalvageKitId");

                    b.HasIndex("SkinId");

                    b.HasIndex("TrinketId");

                    b.HasIndex("UpgradeComponentId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("BaseModels.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("BuyListing")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("SellListing")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("BaseModels.Miniature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("MinipetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Miniatures");
                });

            modelBuilder.Entity("BaseModels.SalvageKit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Charges")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SalvageKits");
                });

            modelBuilder.Entity("BaseModels.Skin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Flags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Restrictions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skins");
                });

            modelBuilder.Entity("BaseModels.TPListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TPListings");
                });

            modelBuilder.Entity("BaseModels.Trinket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("SecondarySuffixItemId")
                        .HasColumnType("text");

                    b.Property<string>("StatChoices")
                        .HasColumnType("text");

                    b.Property<int>("SuffixItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trinkets");
                });

            modelBuilder.Entity("BaseModels.UpgradeComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Bonuses")
                        .HasColumnType("text");

                    b.Property<string>("Flags")
                        .HasColumnType("text");

                    b.Property<string>("InfusionUpgradeFlags")
                        .HasColumnType("text");

                    b.Property<string>("Suffix")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UpgradeComponents");
                });

            modelBuilder.Entity("BaseModels.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DamageType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Defense")
                        .HasColumnType("integer");

                    b.Property<int>("MaxPower")
                        .HasColumnType("integer");

                    b.Property<int>("MinPower")
                        .HasColumnType("integer");

                    b.Property<string>("StatChoices")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("BaseModels.Item", b =>
                {
                    b.HasOne("BaseModels.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("BaseModels.BackItem", "BackItem")
                        .WithMany()
                        .HasForeignKey("BackItemId");

                    b.HasOne("BaseModels.Consumable", "Consumable")
                        .WithMany()
                        .HasForeignKey("ConsumableId");

                    b.HasOne("BaseModels.Container", "Container")
                        .WithMany()
                        .HasForeignKey("ContainerId");

                    b.HasOne("BaseModels.GatheringTool", "GatheringTool")
                        .WithMany()
                        .HasForeignKey("GatheringToolId");

                    b.HasOne("BaseModels.Gizmo", "Gizmo")
                        .WithMany()
                        .HasForeignKey("GizmoId");

                    b.HasOne("BaseModels.Miniature", "Miniature")
                        .WithMany()
                        .HasForeignKey("MiniatureId");

                    b.HasOne("BaseModels.SalvageKit", "SalvageKit")
                        .WithMany()
                        .HasForeignKey("SalvageKitId");

                    b.HasOne("BaseModels.Skin", "Skin")
                        .WithMany()
                        .HasForeignKey("SkinId");

                    b.HasOne("BaseModels.Trinket", "Trinket")
                        .WithMany()
                        .HasForeignKey("TrinketId");

                    b.HasOne("BaseModels.UpgradeComponent", "UpgradeComponent")
                        .WithMany()
                        .HasForeignKey("UpgradeComponentId");

                    b.HasOne("BaseModels.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("BackItem");

                    b.Navigation("Consumable");

                    b.Navigation("Container");

                    b.Navigation("GatheringTool");

                    b.Navigation("Gizmo");

                    b.Navigation("Miniature");

                    b.Navigation("SalvageKit");

                    b.Navigation("Skin");

                    b.Navigation("Trinket");

                    b.Navigation("UpgradeComponent");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("BaseModels.Listing", b =>
                {
                    b.HasOne("BaseModels.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
