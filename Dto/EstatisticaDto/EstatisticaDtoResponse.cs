using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Dto.EstatisticaDto
{
    public class EstatisticaDtoResponse
    {
        public string Type { get; set; }
        public Dictionary<string, double> Data { get; set; }
        public List<string> Erros { get; set; }

        public EstatisticaDtoResponse(string type)
        {   
            this.Type = type;
        }
    }
}