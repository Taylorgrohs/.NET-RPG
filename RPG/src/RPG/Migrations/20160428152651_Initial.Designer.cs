using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using RPG.Models;

namespace RPG.Migrations
{
    [DbContext(typeof(RPGContext))]
    [Migration("20160428152651_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RPG.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Health");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("CharacterId");

                    b.HasAnnotation("Relational:TableName", "Characters");
                });

            modelBuilder.Entity("RPG.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("ItemName");

                    b.HasKey("ItemId");

                    b.HasAnnotation("Relational:TableName", "Items");
                });

            modelBuilder.Entity("RPG.Models.Item", b =>
                {
                    b.HasOne("RPG.Models.Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");
                });
        }
    }
}
