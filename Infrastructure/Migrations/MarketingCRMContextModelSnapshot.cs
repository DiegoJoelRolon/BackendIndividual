﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MarketingCRMContext))]
    partial class MarketingCRMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CampaignTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("CampaignTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SEO"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PPC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Social Media"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Email Marketing"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Clients", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients", (string)null);

                    b.HasData(
                        new
                        {
                            ClientID = 1,
                            Address = "Buenos Aires, Quilmes, Av.Mitre 682",
                            Company = "Mercado Independiente",
                            CreateDate = new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4317),
                            Email = "JhonDoe@Outlook.com",
                            Name = "Julian Dogas",
                            Phone = "12345678"
                        },
                        new
                        {
                            ClientID = 2,
                            Address = "Buenos Aires, Florencio Varela, Bartolomé Mitre 103",
                            Company = "Textiles TelaBuena",
                            CreateDate = new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4330),
                            Email = "RoldanThiago92@Hotmail.com",
                            Name = "Thiago Roldan",
                            Phone = "87654321"
                        },
                        new
                        {
                            ClientID = 3,
                            Address = "Buenos Aires, Parque Patricios, Uspallata 2700",
                            Company = "CompuFast",
                            CreateDate = new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4331),
                            Email = "MariaRamallo@Outlook.com",
                            Name = "Mariana Ramallo",
                            Phone = "11223344"
                        },
                        new
                        {
                            ClientID = 4,
                            Address = "Buenos Aires, Wilde, Zeballos 5869",
                            Company = "English Horizons ",
                            CreateDate = new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4333),
                            Email = "Karioficial@hotmail.com",
                            Name = "Karina Rolón",
                            Phone = "11115678"
                        },
                        new
                        {
                            ClientID = 5,
                            Address = "Buenos Aires, Palermo, Godoy Cruz 2347",
                            Company = "Lo de Hugo",
                            CreateDate = new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4334),
                            Email = "Lodehugo@Outlook.com",
                            Name = "Hugo Escobar",
                            Phone = "8877665544"
                        });
                });

            modelBuilder.Entity("Domain.Entities.InteractionTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("InteractionTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Initial Meeting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone call"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Email"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Presentation of Results"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Interactions", b =>
                {
                    b.Property<Guid>("InteractionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InteractionType")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InteractionID");

                    b.HasIndex("InteractionType");

                    b.HasIndex("ProjectID");

                    b.ToTable("Interactions", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.Property<Guid>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CampaignType")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.HasIndex("CampaignType");

                    b.HasIndex("ClientID");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blocked"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Done"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cancel"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Tasks", b =>
                {
                    b.Property<Guid>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskID");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("ProjectID");

                    b.HasIndex("Status");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "jdone@marketing.com",
                            Name = "Joe Done"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "namstrong@marketing.com",
                            Name = "Nill Amstrong"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "mmorales@marketing.com",
                            Name = "Marlyn Morales"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "aorue@marketing.com",
                            Name = "Antony Orué"
                        },
                        new
                        {
                            UserID = 5,
                            Email = "jfernandez@marketing.com",
                            Name = "Jazmin Fernandez"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Interactions", b =>
                {
                    b.HasOne("Domain.Entities.InteractionTypes", "InteractionTypes")
                        .WithMany("Interactions")
                        .HasForeignKey("InteractionType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Projects", "Project")
                        .WithMany("Interactions")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InteractionTypes");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.HasOne("Domain.Entities.CampaignTypes", "CampaignTypes")
                        .WithMany("Projects")
                        .HasForeignKey("CampaignType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Clients", "Clients")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampaignTypes");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Entities.Tasks", b =>
                {
                    b.HasOne("Domain.Entities.Users", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("AssignedTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Projects", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TaskStatus", "TaskStatus")
                        .WithMany("Tasks")
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("TaskStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CampaignTypes", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Clients", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.InteractionTypes", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("Domain.Entities.Projects", b =>
                {
                    b.Navigation("Interactions");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.TaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}