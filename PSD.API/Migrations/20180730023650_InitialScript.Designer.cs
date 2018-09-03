using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PSD.API.Models;

namespace PSD.API.Migrations
{
    [DbContext(typeof(PSDContext))]
    [Migration("20180730023650_InitialScript")]
    partial class InitialScript
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSD.API.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Clients");

                    b.Property<string>("Comments");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("Pincode");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });
        }
    }
}
