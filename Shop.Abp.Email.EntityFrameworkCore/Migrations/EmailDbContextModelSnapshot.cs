﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.EntityFrameworkCore.Repositories;

namespace Shop.Migrations
{
    [DbContext(typeof(EmailDbContext))]
    partial class EmailDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Shop.EmailNotifyProducts.EmailNotifyProduct", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Account")
                        .HasColumnName("account")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NotifyDate")
                        .HasColumnName("notify_date")
                        .HasColumnType("datetime");

                    b.Property<string>("OrderID")
                        .HasColumnName("order_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("ProductID")
                        .HasColumnName("product_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("ProductName")
                        .HasColumnName("product_name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ReceiveEmail")
                        .HasColumnName("receive_email")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("SendFailureCount")
                        .HasColumnName("send_failure_count")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("t_email_notify_product");
                });

            modelBuilder.Entity("Shop.Emails.Email", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Account")
                        .HasColumnName("account")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("deletion_time")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnName("end_time")
                        .HasColumnType("datetime");

                    b.Property<int>("Flag")
                        .HasColumnName("flag")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("last_modification_time")
                        .HasColumnType("datetime");

                    b.Property<string>("NewEmail")
                        .HasColumnName("email")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("StartTime")
                        .HasColumnName("start_time")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4")
                        .HasMaxLength(1);

                    b.Property<bool>("Suc")
                        .HasColumnName("suc")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("t_mail");
                });
#pragma warning restore 612, 618
        }
    }
}
