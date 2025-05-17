using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CW_ChvalyukVA2307cb1;

public partial class ChvalyukCwDbContext : DbContext
{
    public ChvalyukCwDbContext()
    {
    }

    public ChvalyukCwDbContext(DbContextOptions<ChvalyukCwDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Заявка> Заявкаs { get; set; }

    public virtual DbSet<ОпцииСтатуса> ОпцииСтатусаs { get; set; }

    public virtual DbSet<Пользователь> Пользовательs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dbsrv\\YAR2024;Database=CHvalyuk_CW_db;Trusted_Connection=True;Integrated Security=True;Trust Server Certificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Заявка>(entity =>
        {
            entity.HasKey(e => e.ЗаявкаId).HasName("PK__Заявка__16F3A1BB72ED8857");

            entity.ToTable("Заявка");

            entity.Property(e => e.ЗаявкаId).HasColumnName("Заявка_id");
            entity.Property(e => e.ДатаРегистрацииЗаявки)
                .HasColumnType("datetime")
                .HasColumnName("Дата_регистрации_заявки");
            entity.Property(e => e.ИсполнительЗаявки).HasColumnName("Исполнитель_заявки");
            entity.Property(e => e.Описание).HasMaxLength(250);
            entity.Property(e => e.ОписаниеЗаявки)
                .HasMaxLength(250)
                .HasColumnName("Описание_заявки");
            entity.Property(e => e.СтатусЗаявки).HasColumnName("Статус_Заявки");
            entity.Property(e => e.Тип).HasMaxLength(250);

            entity.HasOne(d => d.ИсполнительЗаявкиNavigation).WithMany(p => p.Заявкаs)
                .HasForeignKey(d => d.ИсполнительЗаявки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Заявка__Исполнит__3C69FB99");

            entity.HasOne(d => d.СтатусЗаявкиNavigation).WithMany(p => p.Заявкаs)
                .HasForeignKey(d => d.СтатусЗаявки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Заявка__Статус_З__3B75D760");
        });

        modelBuilder.Entity<ОпцииСтатуса>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Опции_Ст__3214EC2797F81A8E");

            entity.ToTable("Опции_Статуса");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Names)
                .HasMaxLength(250)
                .HasColumnName("names");
        });

        modelBuilder.Entity<Пользователь>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__Пользова__EB6B2D4549AC0123");

            entity.ToTable("Пользователь");

            entity.Property(e => e.UsersId).HasColumnName("Users_id");
            entity.Property(e => e.ДатаРегистрация)
                .HasColumnType("datetime")
                .HasColumnName("Дата_регистрация");
            entity.Property(e => e.Логин).HasMaxLength(250);
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(250)
                .HasColumnName("Номер_телефона");
            entity.Property(e => e.Пароль).HasMaxLength(250);
            entity.Property(e => e.Фио)
                .HasMaxLength(250)
                .HasColumnName("ФИО");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
