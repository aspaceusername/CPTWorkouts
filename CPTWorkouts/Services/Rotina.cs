
using CPTWorkouts.Data;
using CPTWorkouts.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using static CPTWorkouts.Data.CPTWorkoutsContext;

namespace CPTWorkouts.Services
{
    public class Rotina : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan timeSpan = TimeSpan.FromSeconds(10);
        private DateTime tempoInicial;
        private int counter;
        private ILogger<Rotina> _logger;
        
        public Rotina(ILogger<Rotina> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.tempoInicial = DateTime.Now;
            counter = 0;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(timeSpan);
            // Create a scope to resolve scoped services
            using (var scope = _serviceProvider.CreateScope())
            {
                // recebemos o contexto diretamente para corrigir um erro
                // Resolve the scoped context within the scope
                CPTWorkoutsContext dbContext = scope.ServiceProvider.GetRequiredService<CPTWorkoutsContext>();                 

                // Now you can use dbContext within this method
                while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
                {

                    _logger.LogWarning("Inicio de processamento de pagamentos");

                        this.tempoInicial = DateTime.Now;
                        _logger.LogWarning("Tempo inicial " + this.tempoInicial);
                    
                    List<MBWay> listaPendente = dbContext.MBWay.Where(mb => mb.EstadoMbWay == EstadoMbWay.Pendente).ToList();

                    foreach (MBWay mbWay in listaPendente)
                    {
                        _logger.LogWarning("Pagamento " + mbWay.reference);


                        var aux = tempoInicial.Subtract(mbWay.DateTime);

                        // ver o estado na api

                        /*if (aux.Minutes > 5 && )
                        {
                            mbWay.EstadoMbWay = EstadoMbWay.Recusado;
                        }else if (resposta.true){

                        }
                        */

                    }
                    counter++;
                }
            }


           

        }
    }

}
