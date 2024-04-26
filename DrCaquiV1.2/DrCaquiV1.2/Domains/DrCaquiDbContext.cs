using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrCaquiV1._2.Domains;

public partial class DrCaquiDbContext : DbContext
{
    public DrCaquiDbContext()
    {
    }

    public DrCaquiDbContext(DbContextOptions<DrCaquiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Crianca> Criancas { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Exame> Exames { get; set; }

    public virtual DbSet<Mae> Maes { get; set; }

    public virtual DbSet<MarcoCrianca> MarcoCriancas { get; set; }

    public virtual DbSet<Mchat> Mchats { get; set; }

    public virtual DbSet<MedAntropometrica> MedAntropometricas { get; set; }

    public virtual DbSet<Nutricao> Nutricaos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Raca> Racas { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=DESKTOP-KMDT2N9;Database=DR_CAQUI_DB;Uid=CaioSdk;Pwd=caiosdkdev2005;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crianca>(entity =>
        {
            entity.HasKey(e => e.IdCrianca).HasName("PK__crianca__EB3CE86005A4B681");

            entity.ToTable("crianca");

            entity.HasIndex(e => e.CpfCrianca, "UQ__crianca__6FF172A9516DADCD").IsUnique();

            entity.Property(e => e.IdCrianca).HasColumnName("idCrianca");
            entity.Property(e => e.CpfCrianca)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("cpfCrianca");
            entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
            entity.Property(e => e.IdMae).HasColumnName("idMae");
            entity.Property(e => e.IdPai).HasColumnName("idPai");
            entity.Property(e => e.IdRaca).HasColumnName("idRaca");
            entity.Property(e => e.MunicipioNascimento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("municipioNascimento");
            entity.Property(e => e.NomeCrianca)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nomeCrianca");
            entity.Property(e => e.Ortolani)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ortolani");
            entity.Property(e => e.Pezinho)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pezinho");
            entity.Property(e => e.ReflexoVermelho)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("reflexoVermelho");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.TriagemAuditiva)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("triagemAuditiva");

            entity.HasOne(d => d.IdMaeNavigation).WithMany(p => p.Criancas)
                .HasForeignKey(d => d.IdMae)
                .HasConstraintName("FK__crianca__idMae__5070F446");

            entity.HasOne(d => d.IdPaiNavigation).WithMany(p => p.Criancas)
                .HasForeignKey(d => d.IdPai)
                .HasConstraintName("FK__crianca__idPai__5165187F");

            entity.HasOne(d => d.IdRacaNavigation).WithMany(p => p.Criancas)
                .HasForeignKey(d => d.IdRaca)
                .HasConstraintName("FK__crianca__idRaca__52593CB8");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__endereco__E45B8B2731EB31A3");

            entity.ToTable("endereco");

            entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");
            entity.Property(e => e.Bairro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("bairro");
            entity.Property(e => e.Cidade)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("cidade");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Exame>(entity =>
        {
            entity.HasKey(e => e.IdExame).HasName("PK__exame__784EA7DE4CC0B446");

            entity.ToTable("exame");

            entity.Property(e => e.IdExame).HasColumnName("idExame");
            entity.Property(e => e.DescricaoExame)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("descricaoExame");
            entity.Property(e => e.IdCrianca).HasColumnName("idCrianca");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.TituloExame)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tituloExame");

            entity.HasOne(d => d.IdCriancaNavigation).WithMany(p => p.Exames)
                .HasForeignKey(d => d.IdCrianca)
                .HasConstraintName("FK__exame__idCrianca__5CD6CB2B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Exames)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__exame__idUsuario__5DCAEF64");
        });

        modelBuilder.Entity<Mae>(entity =>
        {
            entity.HasKey(e => e.IdMae).HasName("PK__mae__3DC6CB0D565B525A");

            entity.ToTable("mae");

            entity.Property(e => e.IdMae).HasColumnName("idMae");
            entity.Property(e => e.A53)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("a53");
            entity.Property(e => e.B18)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("b18");
            entity.Property(e => e.B58)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("b58");
            entity.Property(e => e.CpfMae)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("cpfMae");
            entity.Property(e => e.Gravidez)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("gravidez");
            entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Zs1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("zs1");

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.Maes)
                .HasForeignKey(d => d.IdEndereco)
                .HasConstraintName("FK__mae__idEndereco__4CA06362");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Maes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__mae__idUsuario__4BAC3F29");
        });

        modelBuilder.Entity<MarcoCrianca>(entity =>
        {
            entity.HasKey(e => e.IdMarcoCrianca).HasName("PK__marcoCri__4B5928C635488C53");

            entity.ToTable("marcoCrianca");

            entity.HasIndex(e => new { e.IdCrianca, e.IdMchat, e.IdadeCrianca }, "marcoUnico").IsUnique();

            entity.Property(e => e.IdMarcoCrianca).HasColumnName("idMarcoCrianca");
            entity.Property(e => e.IdCrianca).HasColumnName("idCrianca");
            entity.Property(e => e.IdMchat).HasColumnName("idMchat");
            entity.Property(e => e.IdadeCrianca).HasColumnName("idadeCrianca");

            entity.HasOne(d => d.IdCriancaNavigation).WithMany(p => p.MarcoCriancas)
                .HasForeignKey(d => d.IdCrianca)
                .HasConstraintName("FK__marcoCria__idCri__59063A47");

            entity.HasOne(d => d.IdMchatNavigation).WithMany(p => p.MarcoCriancas)
                .HasForeignKey(d => d.IdMchat)
                .HasConstraintName("FK__marcoCria__idMch__59FA5E80");
        });

        modelBuilder.Entity<Mchat>(entity =>
        {
            entity.HasKey(e => e.IdMchat).HasName("PK__mchat__B868FE73F86210B1");

            entity.ToTable("mchat");

            entity.HasIndex(e => e.Marco, "UQ__mchat__0B62C6E057032773").IsUnique();

            entity.Property(e => e.IdMchat)
                .ValueGeneratedOnAdd()
                .HasColumnName("idMchat");
            entity.Property(e => e.Descricao)
                .HasMaxLength(700)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IdadeLimit).HasColumnName("idadeLimit");
            entity.Property(e => e.Marco)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("marco");
        });

        modelBuilder.Entity<MedAntropometrica>(entity =>
        {
            entity.HasKey(e => e.IdMed).HasName("PK__medAntro__3DC6EB89FB482A7D");

            entity.ToTable("medAntropometrica");

            entity.Property(e => e.IdMed).HasColumnName("idMed");
            entity.Property(e => e.DataMed).HasColumnName("dataMed");
            entity.Property(e => e.Estatura)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("estatura");
            entity.Property(e => e.IdCrianca).HasColumnName("idCrianca");
            entity.Property(e => e.Idade).HasColumnName("idade");
            entity.Property(e => e.Imc)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("imc");
            entity.Property(e => e.PerimetroCefalico)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("perimetroCefalico");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("peso");

            entity.HasOne(d => d.IdCriancaNavigation).WithMany(p => p.MedAntropometricas)
                .HasForeignKey(d => d.IdCrianca)
                .HasConstraintName("FK__medAntrop__idCri__60A75C0F");
        });

        modelBuilder.Entity<Nutricao>(entity =>
        {
            entity.HasKey(e => e.IdCrianca).HasName("PK__nutricao__EB3CE860053BE257");

            entity.ToTable("nutricao");

            entity.Property(e => e.IdCrianca).HasColumnName("idCrianca");
            entity.Property(e => e.IdMae).HasColumnName("idMae");
            entity.Property(e => e.Suplemento)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("suplemento");

            entity.HasOne(d => d.IdMaeNavigation).WithMany(p => p.Nutricaos)
                .HasForeignKey(d => d.IdMae)
                .HasConstraintName("FK__nutricao__idMae__5535A963");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPai).HasName("PK__pai__3D783E9A82D545EC");

            entity.ToTable("pai");

            entity.HasIndex(e => e.CpfPai, "UQ__pai__B8CF11F6CADFE544").IsUnique();

            entity.Property(e => e.IdPai).HasColumnName("idPai");
            entity.Property(e => e.CpfPai)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("cpfPai");
            entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.Pais)
                .HasForeignKey(d => d.IdEndereco)
                .HasConstraintName("FK__pai__idEndereco__48CFD27E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pais)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__pai__idUsuario__47DBAE45");
        });

        modelBuilder.Entity<Raca>(entity =>
        {
            entity.HasKey(e => e.IdRaca).HasName("PK__raca__E1222B022DF9C67D");

            entity.ToTable("raca");

            entity.HasIndex(e => e.Raca1, "UQ__raca__CAA9B79ECED85573").IsUnique();

            entity.Property(e => e.IdRaca)
                .ValueGeneratedOnAdd()
                .HasColumnName("idRaca");
            entity.Property(e => e.Raca1)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("raca");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__tipoUsua__03006BFFB8275EEB");

            entity.ToTable("tipoUsuario");

            entity.HasIndex(e => e.NomeTipo, "UQ__tipoUsua__46BB826040D8E33A").IsUnique();

            entity.Property(e => e.IdTipoUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("idTipoUsuario");
            entity.Property(e => e.NomeTipo)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("nomeTipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A687EC5E40");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Login, "UQ__usuario__7838F27227CAB0E8").IsUnique();

            entity.HasIndex(e => e.NomeUsuario, "UQ__usuario__8C9D1DE56A5B464B").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");
            entity.Property(e => e.Login)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.NomeUsuario)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nomeUsuario");
            entity.Property(e => e.Senha)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("senha");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__usuario__idTipoU__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
