using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public int Id_Usuario { get; set; }
        public Usuario Usuario { get; set; }
        public int Prioridade { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Finalizacao { get; set; }
        public int Id_Tipo_Task { get; set; }
        public TipoTask Tipo_Task { get; set; }
    }
}