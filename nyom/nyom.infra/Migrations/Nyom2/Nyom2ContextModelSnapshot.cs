﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Migrations.Nyom2
{
    [DbContext(typeof(Nyom2Context))]
    partial class Nyom2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nyom.domain.Nyom.Campanha.Campanha", b =>
                {
                    b.Property<Guid>("CampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CampanhaId");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Status");

                    b.Property<Guid>("TemplateId");

                    b.HasKey("CampanhaId");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("nyom.domain.Nyom2.Workflow.Workflow", b =>
                {
                    b.Property<Guid>("WorkflowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WorkflowId");

                    b.Property<Guid>("CampanhaId");

                    b.Property<bool>("Status");

                    b.Property<Guid>("TemplateId");

                    b.HasKey("WorkflowId");

                    b.ToTable("Workflows");
                });
        }
    }
}
