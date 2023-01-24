using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Models;

namespace MyTasksAPI.Dto.TaskDto
{
    public class TaskDto
    {

        public int Prioridade { get; set; }
        public string Descricao { get; set; }
        public string TipoTask { get; set; }

        public TaskDto()
        {       
            
        }

        public TaskDto(Tarefa task)
        {
            Prioridade = task.Prioridade;
            Descricao = task.Descricao;
            TipoTask = task.TipoTask;
        }
    }
}