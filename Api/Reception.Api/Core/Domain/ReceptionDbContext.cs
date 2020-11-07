using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Domain
{
    public class ReceptionDbContext : DbContext
    {
        //public ReceptionDbContext()
        //{
        //}

        public ReceptionDbContext(DbContextOptions<ReceptionDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=WIN-9VK2HMR6END\MSSQLSERVER15;Database=ReceptionDb;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            optionsBuilder.UseLazyLoadingProxies(true);
        }

        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PartOrderItem> PartOrderItems { get; set; }
        public DbSet<Complectation> Complectations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SparePart>(entityBuilder =>
            {
                entityBuilder.ToTable("SparePart");
                entityBuilder.HasKey(c => c.Id).HasName("PK_SparePart").IsClustered(true);

                entityBuilder.Property(c => c.Id);
                entityBuilder.Property(c => c.Name).IsRequired(true).IsUnicode(false).HasMaxLength(2000);
                entityBuilder.Property(c => c.ParentId).IsRequired(false);
                entityBuilder.Property(c => c.IsNode);
                entityBuilder.Property(c => c.Price).HasColumnType("decimal(18,2)");
                entityBuilder.HasOne(c => c.Parent).WithMany(c => c.SpareParts).HasForeignKey(c => c.ParentId).HasConstraintName("FK_SparePart_SparePart__ParentId");
                entityBuilder.HasMany(c => c.OrderItems).WithOne(c => c.SparePart).HasForeignKey(c => c.SparePartId).HasConstraintName("FK_OrderItem_SparePart__SparePartId");

                entityBuilder.HasIndex(c => c.IsNode).HasName("IX_SparePart__IsNode");
                entityBuilder.HasIndex(c => c.ParentId).HasName("IXF_SparePart__ParentId").HasFilter("ParentId IS NOT NULL");
            });

            modelBuilder.Entity<Client>(entityBuilder =>
            {
                entityBuilder.ToTable("Client");
                entityBuilder.HasKey(c => c.Id).HasName("PK_Client").IsClustered(true);

                entityBuilder.Property(c => c.Inn).HasMaxLength(22).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.Kpp).HasMaxLength(9).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.LastName).HasMaxLength(500).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.MiddleName).HasMaxLength(500).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.Name).HasMaxLength(500).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.Email).HasMaxLength(36).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.FirstName).HasMaxLength(500).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.Phone).HasMaxLength(22).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.ClientTypeId).IsRequired(true);
                entityBuilder.HasMany(c => c.Orders).WithOne(c => c.Client).HasForeignKey(c => c.ClientId).HasConstraintName("FK_Order_Client__ClientId");

                entityBuilder.HasIndex(c => c.Name).HasName("IX_Client__Name").HasFilter("Name IS NOT NULL");
                entityBuilder.HasIndex(c => c.FirstName).HasName("IXF_Client__FirstName").HasFilter("FirstName IS NOT NULL");
            });

            modelBuilder.Entity<ClientType>(entityBuilder =>
            {
                entityBuilder.ToTable("ClientType");
                entityBuilder.HasKey(c => c.Id).HasName("PK_ClientType").IsClustered(true);

                entityBuilder.Property(c => c.Name).IsRequired(true).IsUnicode(false).HasMaxLength(200);
                entityBuilder.HasMany(c => c.Clients).WithOne(c => c.ClientType).HasForeignKey(c => c.ClientTypeId).HasConstraintName("FK_Client_ClientType__ClientTypeId");
            });

            modelBuilder.Entity<Equipment>(entityBuilder =>
            {
                entityBuilder.ToTable("Equipment");
                entityBuilder.HasKey(c => c.Id).HasName("PK_Equipment").IsClustered(true);

                entityBuilder.Property(c => c.IsNode).IsRequired(true);
                entityBuilder.Property(c => c.Name).IsRequired(true).HasMaxLength(200).IsUnicode(false);
                entityBuilder.Property(c => c.ParentId).IsRequired(false);
                entityBuilder.HasMany(c => c.Orders).WithOne(c => c.Equipment).HasForeignKey(c => c.EquipmentId).HasConstraintName("FK_Order_Equipment__EquipmentId");
                entityBuilder.HasMany(c => c.Complectations).WithOne(c => c.Equipment).HasForeignKey(c => c.EquipmentId).HasConstraintName("FK_Complectation_Equipment__EquipmentId");

                entityBuilder.HasIndex(c => c.IsNode).HasName("IX_Equipment__IsNode");
                entityBuilder.HasIndex(c => c.Name).HasName("IX_Equipment__Name");
                entityBuilder.HasIndex(c => c.ParentId).HasName("IXF_Equipment__ParentId").HasFilter("ParentId IS NOT NULL");
            });

            modelBuilder.Entity<Order>(entityBuilder =>
            {
                entityBuilder.ToTable("Order");
                entityBuilder.HasKey(c => c.Id).HasName("PK_Order").IsClustered(true);

                entityBuilder.Property(c => c.Complectation).HasMaxLength(500).IsRequired(true).IsUnicode(false);
                entityBuilder.Property(c => c.CreationDate).HasDefaultValueSql("getutcdate()").IsRequired(true);
                entityBuilder.Property(c => c.DefectDescription).HasMaxLength(500).IsRequired(true).IsUnicode(false);
                entityBuilder.Property(c => c.DiagnosticResult).HasMaxLength(200).IsRequired(false).IsUnicode(false);
                entityBuilder.Property(c => c.ExternalStateDescription).HasMaxLength(500).IsRequired(true).IsUnicode(false);
                entityBuilder.HasMany(c => c.Parts).WithOne(c => c.Order).HasForeignKey(c => c.OrderId).HasConstraintName("FK_PartOrderItem_Order__OrderId"); ;
                entityBuilder.Property(c => c.RepairCost).IsRequired(false).HasColumnType("decimal(18,3)");
                entityBuilder.Property(c => c.StatusId).IsRequired(true);

                entityBuilder.HasIndex(c => c.StatusId).HasName("IX_Order__StatusId");
            });

            modelBuilder.Entity<OrderStatus>(entityBuilder =>
            {
                entityBuilder.ToTable("OrderStatus");
                entityBuilder.HasKey(c => c.Id).HasName("PK_OrderStatus").IsClustered(true);
                entityBuilder.Property(c => c.Name).IsRequired(true).IsUnicode(false).HasMaxLength(200);
                entityBuilder.HasMany(c => c.Orders).WithOne(c => c.Status).HasForeignKey(c => c.StatusId).HasConstraintName("FK_Order_OrderStatus__StatusId");
            });

            modelBuilder.Entity<PartOrderItem>(entityBuilder =>
            {
                entityBuilder.ToTable("PartOrderItem");
                entityBuilder.HasKey(c => c.Id).HasName("PK_PartOrderItem").IsClustered(true);

                entityBuilder.Property(c => c.Charges).HasColumnType("decimal(18,2)").IsRequired(false);
                entityBuilder.Property(c => c.OrderId).IsRequired(true);
                entityBuilder.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired(true);
                entityBuilder.Property(c => c.Quantity).IsRequired(true);
                entityBuilder.Property(c => c.SparePartId).IsRequired(true);
                entityBuilder.HasIndex(c => c.OrderId).HasName("IX_PartOrderItem__OrderId");
            });

            modelBuilder.Entity<Complectation>(entityBuilder => 
            {
                entityBuilder.ToTable("Complectation");
                entityBuilder.HasKey(c => c.Id).HasName("PK_Complectation");

                entityBuilder.Property(c => c.Name).IsRequired(true).HasMaxLength(200).IsUnicode(false);
                entityBuilder.HasIndex(c => c.EquipmentId).HasName("IX_Complectation__EquipmentId");
            });
        }
    }
}
