using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using NinjaLab.Azure.Domain;

namespace NinjaLab.Azure.Domain.Migrations
{
    [DbContext(typeof(FutbolModel))]
    [Migration("20160213055201_MigracionInicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NinjaLab.Azure.Domain.Equipo", b =>
                {
                    b.Property<int>("IdEquipo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apodo");

                    b.Property<string>("Entrenador");

                    b.Property<string>("Estadio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Presidente");

                    b.HasKey("IdEquipo");
                });

            modelBuilder.Entity("NinjaLab.Azure.Domain.Jugador", b =>
                {
                    b.Property<int>("IdJugador")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apodo");

                    b.Property<decimal>("Estatura");

                    b.Property<int>("IdEquipo");

                    b.Property<string>("Nacionalidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("Peso");

                    b.Property<string>("Posicion");

                    b.HasKey("IdJugador");
                });

            modelBuilder.Entity("NinjaLab.Azure.Domain.Jugador", b =>
                {
                    b.HasOne("NinjaLab.Azure.Domain.Equipo")
                        .WithMany()
                        .HasForeignKey("IdEquipo");
                });
        }
    }
}
