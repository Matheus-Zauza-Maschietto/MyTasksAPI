using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Models;

namespace MyTasksAPI.Dto.TaskDto
{
    public class TaskDtoResponse
    {
        public Guid? TaskId { get; set; }
        public int? Prioridade { get; set; }
        public string Descricao { get; set; }
        public string TipoTask { get; set; }
        public List<string> Erros { get; set; }

        public TaskDtoResponse(List<string> erros)
        {       
            TaskId = null;
            Prioridade = null;
            Descricao = null;
            TipoTask = null;
            Erros = erros;
        }

        public TaskDtoResponse(Tarefa task)
        {
            TaskId = task.Id;
            Prioridade = task.Prioridade;
            Descricao = task.Descricao;
            TipoTask = task.TipoTask;
            Erros = new List<string>();
        }
    }
}