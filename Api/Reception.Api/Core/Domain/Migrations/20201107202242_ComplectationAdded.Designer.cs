﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(ReceptionDbContext))]
    [Migration("20201107202242_ComplectationAdded")]
    partial class ComplectationAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(36)")
                        .HasMaxLength(36)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Inn")
                        .HasColumnType("varchar(22)")
                        .HasMaxLength(22)
                        .IsUnicode(false);

                    b.Property<string>("Kpp")
                        .HasColumnType("varchar(9)")
                        .HasMaxLength(9)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(22)")
                        .HasMaxLength(22)
                        .IsUnicode(false);

                    b.HasKey("Id")
                        .HasName("PK_Client")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ClientTypeId");

                    b.HasIndex("FirstName")
                        .HasName("IXF_Client__FirstName")
                        .HasFilter("FirstName IS NOT NULL");

                    b.HasIndex("Name")
                        .HasName("IX_Client__Name")
                        .HasFilter("Name IS NOT NULL");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Domain.Entities.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id")
                        .HasName("PK_ClientType")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("ClientType");
                });

            modelBuilder.Entity("Domain.Entities.Complectation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id")
                        .HasName("PK_Complectation");

                    b.HasIndex("EquipmentId")
                        .HasName("IX_Complectation__EquipmentId");

                    b.ToTable("Complectation");
                });

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNode")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Equipment")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("IsNode")
                        .HasName("IX_Equipment__IsNode");

                    b.HasIndex("Name")
                        .HasName("IX_Equipment__Name");

                    b.HasIndex("ParentId")
                        .HasName("IXF_Equipment__ParentId")
                        .HasFilter("ParentId IS NOT NULL");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Complectation")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("DefectDescription")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("DiagnosticResult")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("ExternalStateDescription")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<decimal?>("RepairCost")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Order")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ClientId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("StatusId")
                        .HasName("IX_Order__StatusId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Domain.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id")
                        .HasName("PK_OrderStatus")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Domain.Entities.PartOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Charges")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SparePartId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PartOrderItem")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("OrderId")
                        .HasName("IX_PartOrderItem__OrderId");

                    b.HasIndex("SparePartId");

                    b.ToTable("PartOrderItem");
                });

            modelBuilder.Entity("Domain.Entities.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNode")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id")
                        .HasName("PK_SparePart")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("IsNode")
                        .HasName("IX_SparePart__IsNode");

                    b.HasIndex("ParentId")
                        .HasName("IXF_SparePart__ParentId")
                        .HasFilter("ParentId IS NOT NULL");

                    b.ToTable("SparePart");
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.HasOne("Domain.Entities.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .HasConstraintName("FK_Client_ClientType__ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Complectation", b =>
                {
                    b.HasOne("Domain.Entities.Equipment", "Equipment")
                        .WithMany("Complectations")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("FK_Complectation_Equipment__EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Order_Client__ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Equipment", "Equipment")
                        .WithMany("Orders")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("FK_Order_Equipment__EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_Order_OrderStatus__StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.PartOrderItem", b =>
                {
                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany("Parts")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_PartOrderItem_Order__OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SparePart", "SparePart")
                        .WithMany("OrderItems")
                        .HasForeignKey("SparePartId")
                        .HasConstraintName("FK_OrderItem_SparePart__SparePartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.SparePart", b =>
                {
                    b.HasOne("Domain.Entities.SparePart", "Parent")
                        .WithMany("SpareParts")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_SparePart_SparePart__ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
