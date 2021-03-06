﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projetoEntity.Models;

namespace projetoEntity.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200220214307_ProdutosInicial")]
    partial class ProdutosInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("projetoEntity.Models.Produto", b =>
                {
                    b.Property<int>("produtoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("preco")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("produtoId");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
