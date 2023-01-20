using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyTasksAPI.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string IdUsuario { get; set; }
        public IdentityUser Usuario { get; set; }
        public int Prioridade { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public int IdTipoTask { get; set; }
        public TipoTask TipoTask { get; set; }
    }
}