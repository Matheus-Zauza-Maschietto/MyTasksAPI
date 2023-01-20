using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTasksAPI.Models;

namespace MyTasksAPI.Context
{
    public class MyTaskContext: DbContext
    {
        public DbSet<Usuario> User { get; set; }
        public DbSet<TipoTask> TipoTask { get; set; }
        public DbSet<Tarefa> Tasks { get; set; }

        public MyTaskContext(DbContextOptions<MyTaskContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>().Property(p => p.Email).IsRequired().HasMaxLength(256);
            builder.Entity<Usuario>().Property(p => p.Nome).HasMaxLength(200);
            builder.Entity<Tarefa>().Property(p => p.Data_Criacao).IsRequired();
            builder.Entity<Tarefa>().Property(p => p.Descricao).IsRequired().HasMaxLength(300);
            builder.Entity<Tarefa>().Property(p => p.Prioridade).IsRequired();
            builder.Entity<TipoTask>().Property(p => p.Nome).IsRequired();
        }
        
    }
}