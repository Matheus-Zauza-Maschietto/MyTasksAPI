using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Dto.TaskDto
{
    public class TaskDto
    {
        public string EmailUsuario { get; set; }
        public int Prioridade { get; set; }
        public string Descricao { get; set; }
        public int IdTipoTask { get; set; }
    }
}