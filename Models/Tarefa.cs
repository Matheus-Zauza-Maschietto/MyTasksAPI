using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyTasksAPI.Dto.TaskDto;

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
        public string TipoTask { get; set; }

        public Tarefa()
        {
            
        }
        public Tarefa(TaskDto dto, string email)
        {
            IdUsuario = email;
            Prioridade = dto.Prioridade;
            Descricao = dto.Descricao;
            TipoTask = dto.TipoTask;
        }
        public void MapearResponseTarefa(TaskDto dto)
        {
            Prioridade = dto.Prioridade;
            Descricao = dto.Descricao;
            TipoTask = dto.TipoTask;
        }
    }
}