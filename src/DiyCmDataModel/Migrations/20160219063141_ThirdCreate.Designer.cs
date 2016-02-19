using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DiyCmDataModel.Construction;

namespace DiyCmDataModel.Migrations
{
    [DbContext(typeof(DiyCmContext))]
    [Migration("20160219063141_ThirdCreate")]
    partial class ThirdCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("DiyCmDataModel.Construction.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("DocumentType")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Hyperlink");

                    b.HasKey("DocumentId");
                });
        }
    }
}
