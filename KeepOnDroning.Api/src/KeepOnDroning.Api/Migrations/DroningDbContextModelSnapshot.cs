using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using KeepOnDroning.Api.Data;

namespace KeepOnDroning.Api.Migrations
{
    [DbContext(typeof(DroningDbContext))]
    partial class DroningDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KeepOnDroning.Api.Domain.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Altitude");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Dst");

                    b.Property<string>("Iata");

                    b.Property<string>("Icao");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Name");

                    b.Property<decimal>("Timezone");

                    b.Property<string>("Tz");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Airports");
                });

            modelBuilder.Entity("KeepOnDroning.Api.Domain.Ooi", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CurrentLat");

                    b.Property<double>("CurrentLng");

                    b.Property<double>("DestinationLat");

                    b.Property<double>("DestinationLng");

                    b.Property<string>("Name");

                    b.Property<double>("Speed");

                    b.Property<int>("Type");

                    b.Property<string>("UniqueIdentifier");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Oois");
                });
        }
    }
}
