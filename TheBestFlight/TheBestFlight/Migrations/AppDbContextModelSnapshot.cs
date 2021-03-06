// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheBestFlight.Data;

namespace TheBestFlight.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("TheBestFlight.Models.Associazione", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ID_Tratta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username_Utente")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("eleAssociazioni");
                });

            modelBuilder.Entity("TheBestFlight.Models.Tratta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IATA_destinazione")
                        .HasColumnType("TEXT");

                    b.Property<string>("IATA_partenza")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("eleTratte");
                });
#pragma warning restore 612, 618
        }
    }
}
