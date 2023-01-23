using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Models;

namespace MyTasksAPI.Dto.TaskDto
{
    public class TaskDtoResponse
    {
        public Guid TaskId { get; set; }
        public string EmailUsuario { get; set; }
        public int Prioridade { get; set; }
        public string Descricao { get; set; }
        public string TipoTask { get; set; }

        public TaskDtoResponse()
        {       
            
        }

        public TaskDtoResponse(Tarefa task)
        {
            TaskId = task.Id;
            EmailUsuario = task.IdUsuario;
            Prioridade = task.Prioridade;
            Descricao = task.Descricao;
            TipoTask = task.TipoTask;
        }
    }
}