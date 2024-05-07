
using CPTWorkouts.Data;
using CPTWorkouts.Models;
using static CPTWorkouts.Data.CPTWorkoutsContext;

namespace CPTWorkouts.Services
{
    public class Rotina : BackgroundService
    {
        private readonly CPTWorkoutsContext _context;
        private readonly TimeSpan timeSpan = TimeSpan.FromMinutes(5);
        private DateTime tempoInicial;

        public Rotina(CPTWorkoutsContext context)
        {
            _context = context;
            this.tempoInicial = DateTime.Now;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(timeSpan);
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                
                List<MBWay> listaPendente = _context.MBWay.Where(mb => mb.EstadoMbWay == EstadoMbWay.Pendente).ToList();

                foreach(MBWay mbWay in listaPendente)
                {
                    if (tempoInicial.Subtract(mbWay.DateTime).Minutes <= 0)
                    {
                        mbWay.EstadoMbWay = EstadoMbWay.Recusado;
                    }
                }
                this.tempoInicial = DateTime.Now;
            }

        }
    }

}
