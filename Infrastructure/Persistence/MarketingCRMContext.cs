using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MarketingCRMContext : DbContext
    {
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<InteractionTypes> InteractionTypes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatuses { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<CampaignTypes> CampaignTypes { get; set; }
        public DbSet<Clients> Clients { get; set; }

        public MarketingCRMContext(DbContextOptions<MarketingCRMContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interactions>(entity =>
            {
                entity.ToTable("Interactions");
                entity.HasKey(i => i.InteractionID);
                entity.Property(i => i.InteractionID).ValueGeneratedOnAdd();

                entity.Property(i => i.Date).IsRequired();
                entity.Property(i => i.Notes).IsRequired();

                entity.HasOne(i => i.InteractionTypes)
                      .WithMany(it => it.Interactions)
                      .HasForeignKey(i => i.InteractionType);

                entity.HasOne(i => i.Project)
                      .WithMany(p => p.Interactions)
                      .HasForeignKey(i => i.ProjectID);
            });

            modelBuilder.Entity<InteractionTypes>(entity =>
            {
                entity.ToTable("InteractionTypes");
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).ValueGeneratedOnAdd();

                entity.Property(it => it.Name).HasMaxLength(25).IsRequired();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(us => us.UserID);
                entity.Property(us => us.UserID).ValueGeneratedOnAdd();

                entity.Property(us => us.Name).HasMaxLength(255).IsRequired();
                entity.Property(us => us.Email).HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");
                entity.HasKey(ts => ts.Id);
                entity.Property(ts => ts.Id).ValueGeneratedOnAdd();

                entity.Property(ts => ts.Name).HasMaxLength(25).IsRequired();
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(t => t.TaskID);
                entity.Property(t => t.TaskID).ValueGeneratedOnAdd();

                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.DueDate).IsRequired();
                entity.Property(t => t.CreateDate).IsRequired();
                entity.Property(t => t.UpdateDate).IsRequired();


                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.ProjectID);

                entity.HasOne(t => t.User)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.AssignedTo);

                entity.HasOne(t => t.TaskStatus)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.Status);

            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("Projects");
                entity.HasKey(p => p.ProjectID);
                entity.Property(p => p.ProjectID).ValueGeneratedOnAdd();

                entity.Property(p => p.ProjectName).HasMaxLength(255).IsRequired();
                entity.Property(p => p.StartDate).IsRequired();
                entity.Property(p => p.EndDate).IsRequired();
                entity.Property(p => p.CreateDate).IsRequired();
                entity.Property(p => p.UpdateDate).IsRequired();

                entity.HasOne(p => p.CampaignTypes)
                      .WithMany(ct => ct.Projects)
                      .HasForeignKey(p => p.CampaignType);

                entity.HasOne(p => p.Clients)
                      .WithMany(ct => ct.Projects)
                      .HasForeignKey(p => p.ClientID);


            });

            modelBuilder.Entity<CampaignTypes>(entity =>
            {
                entity.ToTable("CampaignTypes");
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Id).ValueGeneratedOnAdd();
                entity.Property(ct => ct.Name).HasMaxLength(25).IsRequired();

            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.ClientID).ValueGeneratedOnAdd();

                entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Email).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Phone).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Company).HasMaxLength(100).IsRequired();
                entity.Property(c=>c.Address).IsRequired();
                entity.Property(c => c.CreateDate).IsRequired();
            });


            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserID = 1,
                    Name = "Joe Done",
                    Email = "jdone@marketing.com",
                },
                new Users
                {
                    UserID = 2,
                    Name = "Nill Amstrong",
                    Email = "namstrong@marketing.com",
                },
                new Users
                {
                    UserID = 3,
                    Name = "Marlyn Morales",
                    Email = "mmorales@marketing.com",
                },
                new Users
                {
                    UserID = 4,
                    Name = "Antony Orué",
                    Email = "aorue@marketing.com",
                },
                new Users
                {
                    UserID = 5,
                    Name = "Jazmin Fernandez",
                    Email = "jfernandez@marketing.com",
                }
                );

            modelBuilder.Entity<InteractionTypes>().HasData(
                new InteractionTypes
                {
                    Id = 1,
                    Name = "Initial Meeting"
                },
                new InteractionTypes
                {
                    Id = 2,
                    Name = "Phone call"
                },
                new InteractionTypes
                {
                    Id = 3,
                    Name = "Email"
                },
                new InteractionTypes
                {
                    Id = 4,
                    Name = "Presentation of Results"
                }

                );

            modelBuilder.Entity<Domain.Entities.TaskStatus>().HasData(
                new Domain.Entities.TaskStatus
                {
                    Id = 1,
                    Name = "Pending"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 2,
                    Name = "In Progress"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 3,
                    Name = "Blocked"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 4,
                    Name = "Done"
                },
                new Domain.Entities.TaskStatus
                {
                    Id = 5,
                    Name = "Cancel"
                }
                );
            modelBuilder.Entity<CampaignTypes>().HasData(
                new CampaignTypes
                {
                    Id = 1,
                    Name = "SEO"
                },
                new CampaignTypes
                {
                    Id = 2,
                    Name = "PPC"
                },
                new CampaignTypes
                {
                    Id = 3,
                    Name = "Social Media"
                },
                new CampaignTypes
                {
                    Id = 4,
                    Name = "Email Marketing"
                }
                );
            modelBuilder.Entity<Clients>().HasData(
                new Clients
                {
                    Address="Buenos Aires, Quilmes, Av.Mitre 682",
                    ClientID=1,
                    CreateDate=DateTime.Now,
                    Company = "Mercado Independiente",
                    Email="JhonDoe@Outlook.com",
                    Name="Julian Dogas",
                    Phone = "12345678",
                },
                new Clients
                {
                    Address = "Buenos Aires, Florencio Varela, Bartolomé Mitre 103",
                    ClientID = 2,
                    CreateDate = DateTime.Now,
                    Company = "Textiles TelaBuena",
                    Email = "RoldanThiago92@Hotmail.com",
                    Name = "Thiago Roldan",
                    Phone = "87654321",
                }, 
                new Clients
                {
                    Address = "Buenos Aires, Parque Patricios, Uspallata 2700",
                    ClientID = 3,
                    CreateDate = DateTime.Now,
                    Company = "CompuFast",
                    Email = "MariaRamallo@Outlook.com",
                    Name = "Mariana Ramallo",
                    Phone = "11223344",
                },
                new Clients
                {
                    Address = "Buenos Aires, Wilde, Zeballos 5869",
                    ClientID = 4,
                    CreateDate = DateTime.Now,
                    Company = "English Horizons ",
                    Email = "Karioficial@hotmail.com",
                    Name = "Karina Rolón",
                    Phone = "11115678",
                },
                new Clients
                {
                    Address = "Buenos Aires, Palermo, Godoy Cruz 2347",
                    ClientID = 5,
                    CreateDate = DateTime.Now,
                    Company = "Lo de Hugo",
                    Email = "Lodehugo@Outlook.com",
                    Name = "Hugo Escobar",
                    Phone = "8877665544",
                }

                );

        }
    }
}
