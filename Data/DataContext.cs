using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstudeX.Models;
using EstudeX.Utils;

namespace EstudeX.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Utilizador> TBL_UTILIZADOR { get; set; }
        public DbSet<Duvida> TBL_DUVIDA { get; set; }
        public DbSet<Aluno> TBL_ALUNO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>().ToTable("TBL_UTILIZADOR");
            modelBuilder.Entity<Duvida>().ToTable("TBL_DUVIDA");
            modelBuilder.Entity<Aluno>().ToTable("TBL_ALUNO");

            modelBuilder.Entity<Utilizador>().HasKey(x => x.IdUtilizador);
            modelBuilder.Entity<Utilizador>().Property(x => x.Nome).HasColumnName("nome");
            modelBuilder.Entity<Utilizador>().Property(x => x.CPF).HasColumnName("cpf");
            modelBuilder.Entity<Utilizador>().Property(x => x.UF).HasColumnName("uf");
            modelBuilder.Entity<Utilizador>().Property(x => x.Cidade).HasColumnName("cidade");
            modelBuilder.Entity<Utilizador>().Property(x => x.TipoUtilizador).HasColumnName("tipoUtilizador");

            modelBuilder.Entity<Duvida>().HasKey(x => x.IdDuvida);
            modelBuilder.Entity<Duvida>().Property(x => x.Descricao).HasColumnName("descricao");
            modelBuilder.Entity<Duvida>().Property(x => x.Titulo).HasColumnName("titulo");
            modelBuilder.Entity<Duvida>().Property(x => x.Momento).HasColumnName("momento");
            modelBuilder.Entity<Duvida>().Property(x => x.statusDuvida).HasColumnName("statusDuvida");

            modelBuilder.Entity<Aluno>().HasKey(x => x.IdUtilizador);
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).HasColumnName("nome");
            modelBuilder.Entity<Aluno>().Property(x => x.CPF).HasColumnName("cpf");
            modelBuilder.Entity<Aluno>().Property(x => x.UF).HasColumnName("uf");
            modelBuilder.Entity<Aluno>().Property(x => x.Cidade).HasColumnName("cidade");
            modelBuilder.Entity<Aluno>().Property(x => x.tipoUtilizador).HasColumnName("tipoUtilizador");
            modelBuilder.Entity<Aluno>().Property(x => x.Serie).HasColumnName("serie");
            

            modelBuilder.Entity<Utilizador>()
                .HasMany(x => x.Duvidas)
                .WithOne(x => x.Utilizador)
                .HasForeignKey(x => x.IdUtilizador)
                .IsRequired(false);

            // Relacionamento Utilizador -> Aluno (1:1)
            modelBuilder.Entity<Aluno>()
                .HasOne(x => x.Utilizador)
                .WithOne()
                .HasForeignKey<Aluno>(x => x.IdUtilizador)
                .IsRequired(true);  
   

               


            /* Início da criação do usuário padrão.
            Utilizador utilizador = new Utilizador();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            utilizador.IdUtilizador = 1;
            utilizador.Nome = "UsuarioAdmin";
            utilizador.PasswordString = string.Empty;
            utilizador.PasswordHash = hash;
            utilizador.PasswordSalt = salt;
            utilizador.Perfil = "Admin";
            utilizador.Email = "seuemail@gmail.com";
            utilizador.Latitude = -23.5200241;
            utilizador.Longitude = -46.5964988;

           
            modelBuilder.Entity<Utilizador>()
                .Property(u => u.Perfil)
                .HasDefaultValue("Aluno");*/
    
        }
    }
}