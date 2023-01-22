using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Models
{
    public class TipoTask
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public TipoTask(string nome)
        {
            Nome = nome;
        }
    }
}