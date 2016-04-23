using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using KeepOnDroning.Api.Data;

namespace KeepOnDroning.Api.Migrations
{
    [DbContext(typeof(DroningDbContext))]
    [Migration("20160423175747_AddIcao")]
    partial class AddIcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
        }
    }
}
