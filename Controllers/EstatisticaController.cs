using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTasksAPI.Repository;

namespace MyTasksAPI.Controllers
{
    [ApiController]
    [Route("/estatistica")]
    public class EstatisticaController : ControllerBase
    {
        private readonly EstatisticaRepository _repository;

        public EstatisticaController(EstatisticaRepository repository)
        {
            _repository = repository;
        }
        
        
    }
}