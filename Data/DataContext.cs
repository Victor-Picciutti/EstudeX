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
        public DbSet<RespostaDuvida> TBL_RESPOSTADUVIDA { get; set; }
        public DbSet<Serie> TBL_SERIE { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Utilizador>().HasData
            (
            new Utilizador(){IdUtilizador = 1, Nome = "João Silva", CPF = "123.456.789-00", Cidade = "São Paulo", UF = "SP", Foto = new byte[] { 0 }, Senha = System.Text.Encoding.UTF8.GetBytes("senha123")}
            );


            modelBuilder.Entity<Utilizador>().ToTable("TBL_UTILIZADOR");
            modelBuilder.Entity<Duvida>().ToTable("TBL_DUVIDA");
            modelBuilder.Entity<Aluno>().ToTable("TBL_ALUNO");
            modelBuilder.Entity<RespostaDuvida>().ToTable("TBL_RESPOSTADUVIDA");
            modelBuilder.Entity<Serie>().ToTable("TBL_SERIE");
            modelBuilder.Entity<TipoUtilizador>().ToTable("TBL_TIPOUTILIZADOR");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Utilizador>().HasKey(x => x.IdUtilizador); 
            modelBuilder.Entity<Utilizador>().Property(x => x.Nome).HasColumnName("Nome");
            modelBuilder.Entity<Utilizador>().Property(x => x.CPF).HasColumnName("CPF");
            modelBuilder.Entity<Utilizador>().Property(x => x.Cidade).HasColumnName("Cidade");
            modelBuilder.Entity<Utilizador>().Property(x => x.UF).HasColumnName("UF");
            modelBuilder.Entity<Utilizador>().Property(x => x.Foto).HasColumnName("Foto");
            modelBuilder.Entity<Utilizador>().Property(x => x.Senha).HasColumnName("Senha");
            modelBuilder.Entity<Utilizador>().Property(x => x.IdTipoUtilizador).HasColumnName("IdTipoUtilizador");

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Duvida>().HasKey(x => x.IdDuvida);
            modelBuilder.Entity<Duvida>().Property(x => x.Titulo).HasColumnName("Titulo");
            modelBuilder.Entity<Duvida>().Property(x => x.Descricao).HasColumnName("Descricao");
            modelBuilder.Entity<Duvida>().Property(x => x.Momento).HasColumnName("Momento");
            modelBuilder.Entity<Duvida>().Property(x => x.statusDuvida).HasColumnName("StatusDuvida");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<RespostaDuvida>().HasKey(x => x.IdDuvida);
            modelBuilder.Entity<RespostaDuvida>().Property(x => x.IdDuvida).HasColumnName("idDuvida");
            modelBuilder.Entity<RespostaDuvida>().Property(x => x.IdUtilizador).HasColumnName("idUtilizador");
            modelBuilder.Entity<RespostaDuvida>().Property(x => x.Momento).HasColumnName("Momento");
            modelBuilder.Entity<RespostaDuvida>().Property(x => x.ConteudoResposta).HasColumnName("ConteudoResposta");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Aluno>().Property(x => x.idSerie).HasColumnName("idSerie");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Serie>().HasKey(x => x.idSerie);
            modelBuilder.Entity<Serie>().Property(x => x.Ano).HasColumnName("Ano");
            modelBuilder.Entity<Serie>().Property(x => x.Inicio).HasColumnName("Inicio");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<TipoUtilizador>().HasKey(x => x.IdTipoUtilizador);
            modelBuilder.Entity<TipoUtilizador>().Property(x => x.Cargo).HasColumnName("cargo");

            

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

            modelBuilder.Entity<Duvida>()
                .HasOne(x => x.RespostaDuvida)
                .WithOne(x => x.Duvida)
                .HasForeignKey<RespostaDuvida>(x => x.IdDuvida);

            modelBuilder.Entity<Aluno>()
                .HasOne(x => x.Serie)
                .WithMany(x => x.Alunos)
                .HasForeignKey(x => x.idSerie)
                .IsRequired(true);  

            modelBuilder.Entity<Utilizador>()
                .HasOne(u => u.TipoUtilizador)       
                .WithMany(u=> u.Utilizadores)                          
                .HasForeignKey(u => u.IdTipoUtilizador)  
                .IsRequired(false);              

            modelBuilder.Entity<Utilizador>()
                .Property(u => u.IdTipoUtilizador)
                .HasColumnName("IdTipoUtilizador"); 
   

               


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