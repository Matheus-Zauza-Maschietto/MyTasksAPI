using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Dto.EstatisticaDto;

namespace MyTasksAPI.Repository
{
    public class EstatisticaRepository
    {
        private readonly UserManager<IdentityUser> _context;
        public EstatisticaRepository(UserManager<IdentityUser> context)
        {
            _context = context;
        }
        
        public EstatisticaDtoResponse WeeklyChart()
        {
            EstatisticaDtoResponse dto = new EstatisticaDtoResponse("WeeklyChart");
            
        }
    }
}