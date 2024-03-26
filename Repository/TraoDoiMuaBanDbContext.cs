using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WPF_Market.Repository.Models;

namespace WPF_Market.Repository;

public partial class TraoDoiMuaBanDbContext : DbContext
{
    public TraoDoiMuaBanDbContext()
    {
    }

    public TraoDoiMuaBanDbContext(DbContextOptions<TraoDoiMuaBanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<ImageLink> ImageLinks { get; set; }

    public virtual DbSet<Iventory> Iventories { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TraoDoiMuaBan;Integrated Security=True;Trust Server Certificate=False;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.IdCart).HasName("PK__Cart__72140ECF58F14122");

            entity.Property(e => e.IdCart).ValueGeneratedNever();
        });

        modelBuilder.Entity<ImageLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image_li__3214EC07F5B1FC79");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Iventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Iventory__3214EC075DDE3D32");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.IdSanpham).HasName("PK__Kho__0BC662851DC71AC6");

            entity.Property(e => e.IdSanpham).ValueGeneratedNever();
            entity.Property(e => e.DoMoi).IsFixedLength();
            entity.Property(e => e.NumberSold).IsFixedLength();
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdShop }).HasName("PK__Owner__3CA78C9ED5DC9FA2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__522DE496D03E9FE4");

            entity.Property(e => e.IdProduct).ValueGeneratedNever();
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.IdShop).HasName("PK__tmp_ms_x__EB360B91AD8C4FCF");

            entity.Property(e => e.IdShop).ValueGeneratedNever();
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC07855BFBBF");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07F5BFA233");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdFavProduct).IsFixedLength();
            entity.Property(e => e.IdFavShop).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
