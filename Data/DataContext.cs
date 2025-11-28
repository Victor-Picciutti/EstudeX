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
        public DbSet<Aluno> TBL_ALUNO { get; set; }
        public DbSet<Duvida> TBL_DUVIDA { get; set; }
        public DbSet<RespostaDuvida> TBL_CONTEUDO { get; set; }
        public DbSet<RespostaDuvida> TBL_RESPOSTADUVIDA { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>().ToTable("TBL_UTILIZADOR");
            modelBuilder.Entity<Duvida>().ToTable("TBL_DUVIDA");
            modelBuilder.Entity<Aluno>().ToTable("TBL_ALUNO");
            modelBuilder.Entity<RespostaDuvida>().ToTable("TBL_RESPOSTADUVIDA");
            modelBuilder.Entity<Conteudo>().ToTable("TBL_CONTEUDO");

            modelBuilder.Entity<Utilizador>().HasKey(x => x.IdUtilizador); 
            modelBuilder.Entity<Utilizador>().Property(x => x.Nome).HasColumnName("Nome");
            modelBuilder.Entity<Utilizador>().Property(x => x.CPF).HasColumnName("CPF");
            modelBuilder.Entity<Utilizador>().Property(x => x.UF).HasColumnName("UF");
            modelBuilder.Entity<Utilizador>().Property(x => x.Cidade).HasColumnName("Cidade");
            modelBuilder.Entity<Utilizador>().Property(x => x.Foto).HasColumnName("Foto");
            modelBuilder.Entity<Utilizador>().Property(x => x.Senha).HasColumnName("Senha");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Duvida>().HasKey(x => x.IdDuvida);
            modelBuilder.Entity<Duvida>().Property(x => x.Descricao).HasColumnName("Descricao");
            modelBuilder.Entity<Duvida>().Property(x => x.Titulo).HasColumnName("Titulo");
            modelBuilder.Entity<Duvida>().Property(x => x.Momento).HasColumnName("Momento");
            modelBuilder.Entity<Duvida>().Property(x => x.statusDuvida).HasColumnName("StatusDuvida");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<RespostaDuvida>().HasKey(x => x.IdRespostaDuvida);
            modelBuilder.Entity<RespostaDuvida>().Property(x => x.Momento).HasColumnName("momento");
            modelBuilder.Entity<RespostaDuvida>().Property(x => x.ConteudoResposta).HasColumnName("ConteudoResposta");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Aluno>().HasKey(x => x.IdUtilizador);
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).HasColumnName("nome");
            modelBuilder.Entity<Aluno>().Property(x => x.CPF).HasColumnName("cpf");
            modelBuilder.Entity<Aluno>().Property(x => x.UF).HasColumnName("uf");
            modelBuilder.Entity<Aluno>().Property(x => x.Cidade).HasColumnName("cidade");
           // modelBuilder.Entity<Aluno>().Property(x => x.tipoUtilizador).HasColumnName("tipoUtilizador");
            modelBuilder.Entity<Aluno>().Property(x => x.Serie).HasColumnName("serie");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            

            modelBuilder.Entity<Utilizador>()
                .HasMany(x => x.Duvida)
                .WithOne(x => x.Utilizador)
                .HasForeignKey(x => x.IdUtilizador)
                .IsRequired(false);

            modelBuilder.Entity<Utilizador>()
                .HasMany(x => x.RespostaDuvida)
                .WithOne(x => x.Utilizador)
                .HasForeignKey(x => x.IdUtilizador)
                .IsRequired(false);    

            // Relacionamento Utilizador -> Aluno (1:1)
            modelBuilder.Entity<Aluno>()
                .HasOne(x => x.Utilizador)
                .WithOne()
                .HasForeignKey<Aluno>(x => x.IdUtilizador)
                .IsRequired(false);

            modelBuilder.Entity<Duvida>()
                .HasOne(x => x.RespostaDuvida)
                .WithOne(x => x.Duvida)
                .HasForeignKey<RespostaDuvida>(x => x.IdDuvida);
   

               


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