using System.Reflection.Metadata.Ecma335;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTasksAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyTasksAPI.Context
{
    public class MyTaskContext: IdentityDbContext<IdentityUser>
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
            builder.Entity<IdentityUser>().Property(p => p.Email).IsRequired();
            builder.Entity<IdentityUser>().HasIndex(p => p.Email).IsUnique();
            builder.Entity<Usuario>().Property(p => p.Email).IsRequired().HasMaxLength(256);
            builder.Entity<Usuario>().Property(p => p.Nome).HasMaxLength(200);
            builder.Entity<Tarefa>().Property(p => p.DataCriacao).IsRequired();
            builder.Entity<Tarefa>().Property(p => p.Descricao).IsRequired().HasMaxLength(300);
            builder.Entity<Tarefa>().Property(p => p.Prioridade).IsRequired();
            builder.Entity<TipoTask>().Property(p => p.Nome).IsRequired();
            
            
        }
        
    }
}