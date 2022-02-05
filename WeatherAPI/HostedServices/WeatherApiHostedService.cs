using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.HostedServices;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Requests;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.HostedServices
{
    //public class WeatherApiHostedService : BackgroundService
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ICommandDispatcher _commandDispatcher;
    //    private readonly IRequestExecutor _requestExecutor;
    //    private readonly TimeSpan _timeSpanTask = TimeSpan.FromSeconds(20);
    //    public WeatherApiHostedService(IUnitOfWork unitOfWork, ICommandDispatcher commandDispatcher, IRequestExecutor requestExecutor)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _commandDispatcher = commandDispatcher;
    //        _requestExecutor = requestExecutor;
    //    }
    //    public WeatherApiHostedService(IRequestExecutor requestExecutor)
    //    {
    //        _requestExecutor = requestExecutor;
    //    }
    //    public async Task GetDataFromWeatherApi()
    //    {
    //        try
    //        {
    //            var request = new GetByCityNameRequest("Florianopolis");

    //            var response = await _requestExecutor.ExecuteRequest<GetByCityNameRequest, CurrentLocalWeatherDto>(request).ConfigureAwait(true);

    //            var command = new GetByCityNameCurrentWeatherCommand(response.AsBusiness());

    //            _commandDispatcher.Dispatch(command);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        while (!stoppingToken.IsCancellationRequested) 
    //        {
    //            await GetDataFromWeatherApi();
    //            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
    //        }
    //    }
    //}
    public class WeatherApiHostedService : IWeatherApiHostedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IRequestExecutor _requestExecutor;
        private readonly string[] _citiesToSearch = new string[] { "Abdon Batista",
                                                "Abelardo Luz",
                                                "Agrolândia",
                                                "Agronômica",
                                                "Água Doce",
                                                "Águas de Chapecó",
                                                "Águas Frias",
                                                "Águas Mornas",
                                                "Alfredo Wagner",
                                                "Alto Bela Vista",
                                                "Anchieta",
                                                "Angelina",
                                                "Anita Garibaldi",
                                                "Anitápolis",
                                                "Antônio Carlos",
                                                "Apiúna",
                                                "Arabutã",
                                                "Araquari",
                                                "Araranguá",
                                                "Armazém",
                                                "Arroio Trinta",
                                                "Arvoredo",
                                                "Ascurra",
                                                "Atalanta",
                                                "Aurora",
                                                "Balneário Arroio do Silva",
                                                "Balneário Camboriú",
                                                "Balneário Gaivota",
                                                "Bandeirante",
                                                "Barra Bonita",
                                                "Barra Velha",
                                                "Bela Vista do Toldo",
                                                "Belmonte",
                                                "Benedito Novo",
                                                "Biguaçu",
                                                "Blumenau",
                                                "Bombinhas",
                                                "Bom Jardim da Serra",
                                                "Bom Jesus",
                                                "Bom Jesus do Oeste",
                                                "Bom Retiro",
                                                "Botuverá",
                                                "Braço do Norte",
                                                "Braço do Trombudo",
                                                "Brusque",
                                                "Caçador",
                                                "Caibi",
                                                "Calmon",
                                                "Camboriú",
                                                "Capão Alto",
                                                "Campo Alegre",
                                                "Campo Belo do Sul",
                                                "Campo Erê",
                                                "Campos Novos",
                                                "Canelinha",
                                                "Canoinhas",
                                                "Capinzal",
                                                "Capivari de Baixo",
                                                "Catanduvas",
                                                "Caxambu do Sul",
                                                "Celso Ramos",
                                                "Cerro Negro",
                                                "Chapecó",
                                                "Cocal do Sul",
                                                "Concórdia",
                                                "Cordilheira Alta",
                                                "Coronel Freitas",
                                                "Coronel Martins",
                                                "Corupá",
                                                "Correia Pinto",
                                                "Criciúma",
                                                "Cunha Porã",
                                                "Cunhataí",
                                                "Curitibanos",
                                                "Descanso",
                                                "Dionísio Cerqueira",
                                                "Dona Emma",
                                                "Doutor Pedrinho",
                                                "Entre Rios",
                                                "Ermo",
                                                "Erval Velho",
                                                "Faxinal dos Guedes",
                                                "Flor do Sertão",
                                                "Florianópolis",
                                                "Formosa do Sul",
                                                "Forquilhinha",
                                                "Frei Rogério",
                                                "Galvão",
                                                "Garuva",
                                                "Gaspar",
                                                "Governador Celso Ramos",
                                                "Grão Pará",
                                                "Gravatal",
                                                "Guabiruba",
                                                "Guaraciaba",
                                                "Guaramirim",
                                                "Guarujá do Sul",
                                                "Guatambú",
                                                "Herval d'Oeste",
                                                "Ibiam",
                                                "Ibicaré",
                                                "Ibirama",
                                                "Içara",
                                                "Ilhota",
                                                "Imaruí",
                                                "Imbituba",
                                                "Imbuia",
                                                "Indaial",
                                                "Iomerê",
                                                "Ipira",
                                                "Iporã do Oeste",
                                                "Ipuaçu",
                                                "Ipumirim",
                                                "Iraceminha",
                                                "Irani",
                                                "Irati",
                                                "Irineópolis",
                                                "Itá",
                                                "Itaiópolis",
                                                "Itajaí",
                                                "Itapema",
                                                "Itapiranga",
                                                "Itapoá",
                                                "Ituporanga",
                                                "Jaborá",
                                                "Jacinto Machado",
                                                "Jaguaruna",
                                                "Jaraguá do Sul",
                                                "Jardinópolis",
                                                "Joaçaba",
                                                "Joinville",
                                                "José Boiteux",
                                                "Jupiá",
                                                "Lacerdópolis",
                                                "Lages",
                                                "Laguna",
                                                "Lajeado Grande",
                                                "Laurentino",
                                                "Lauro Muller",
                                                "Lebon Régis",
                                                "Lindóia do Sul",
                                                "Lontras",
                                                "Luiz Alves",
                                                "Luzerna",
                                                "Macieira",
                                                "Mafra",
                                                "Major Gercino",
                                                "Major Vieira",
                                                "Maracajá",
                                                "Maravilha",
                                                "Marema",
                                                "Massaranduba",
                                                "Matos Costa",
                                                "Meleiro",
                                                "Mirim Doce",
                                                "Modelo",
                                                "Mondaí",
                                                "Monte Carlo",
                                                "Monte Castelo",
                                                "Morro da Fumaça",
                                                "Morro Grande",
                                                "Navegantes",
                                                "Nova Erechim",
                                                "Nova Itaberaba",
                                                "Nova Trento",
                                                "Nova Veneza",
                                                "Novo Horizonte",
                                                "Orleans",
                                                "Otacílio Costa",
                                                "Ouro",
                                                "Ouro Verde",
                                                "Paial",
                                                "Palhoça",
                                                "Palma Sola",
                                                "Palmeira",
                                                "Palmitos",
                                                "Papanduva",
                                                "Paraíso",
                                                "Passo de Torres",
                                                "Passos Maia",
                                                "Paulo Lopes",
                                                "Pedras Grandes",
                                                "Penha",
                                                "Peritiba",
                                                "Pescaria Brava",
                                                "Petrolândia",
                                                "Balneário Piçarras",
                                                "Pinhalzinho",
                                                "Pinheiro Preto",
                                                "Piratuba",
                                                "Planalto Alegre",
                                                "Pomerode",
                                                "Ponte Alta",
                                                "Ponte Alta do Norte",
                                                "Ponte Serrada",
                                                "Porto Belo",
                                                "Porto União",
                                                "Pouso Redondo",
                                                "Praia Grande",
                                                "Presidente Castello Branco",
                                                "Presidente Getúlio",
                                                "Presidente Nereu",
                                                "Princesa",
                                                "Quilombo",
                                                "Rancho Queimado",
                                                "Rio das Antas",
                                                "Rio do Campo",
                                                "Rio do Oeste",
                                                "Rio dos Cedros",
                                                "Rio do Sul",
                                                "Rio Fortuna",
                                                "Rio Negrinho",
                                                "Rio Rufino",
                                                "Riqueza",
                                                "Rodeio",
                                                "Romelândia",
                                                "Salete",
                                                "Saltinho",
                                                "Salto Veloso",
                                                "Sangão",
                                                "Santa Cecília",
                                                "Santa Helena",
                                                "Santa Rosa de Lima",
                                                "Santa Rosa do Sul",
                                                "Santa Terezinha",
                                                "Santa Terezinha do Progresso",
                                                "Santiago do Sul",
                                                "Santo Amaro da Imperatriz",
                                                "São Bernardino",
                                                "São Bento do Sul",
                                                "São Bonifácio",
                                                "São Carlos",
                                                "São Cristovão do Sul",
                                                "São Domingos",
                                                "São Francisco do Sul",
                                                "São João do Oeste",
                                                "São João Batista",
                                                "São João do Itaperiú",
                                                "São João do Sul",
                                                "São Joaquim",
                                                "São José",
                                                "São José do Cedro",
                                                "São Lourenço do Oeste",
                                                "São Ludgero",
                                                "São Martinho",
                                                "São Miguel da Boa Vista",
                                                "São Miguel do Oeste",
                                                "São Pedro de Alcântara",
                                                "Saudades",
                                                "Schroeder",
                                                "Seara",
                                                "Serra Alta",
                                                "Siderópolis",
                                                "Sombrio",
                                                "Sul Brasil",
                                                "Taió",
                                                "Tangará",
                                                "Tigrinhos",
                                                "Tijucas",
                                                "Timbé do Sul",
                                                "Timbó",
                                                "Timbó Grande",
                                                "Três Barras",
                                                "Treviso",
                                                "Treze de Maio",
                                                "Treze Tílias",
                                                "Trombudo Central",
                                                "Tubarão",
                                                "Turvo",
                                                "União do Oeste",
                                                "Urubici",
                                                "Urupema",
                                                "Urussanga",
                                                "Vargeão",
                                                "Vargem",
                                                "Vargem Bonita",
                                                "Videira",
                                                "Vitor Meireles",
                                                "Witmarsum",
                                                "Xanxerê",
                                                "Xaxim",
                                                "Zortéa"};

        public WeatherApiHostedService(IUnitOfWork unitOfWork, ICommandDispatcher commandDispatcher, IRequestExecutor requestExecutor)
        {
            _unitOfWork = unitOfWork;
            _commandDispatcher = commandDispatcher;
            _requestExecutor = requestExecutor;
        }
        public WeatherApiHostedService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        public async void GetDataFromWeatherApi()
        {
            try
            {

                var requestList = new List<Task<CurrentLocalWeatherDto>>();

                foreach (var item in _citiesToSearch)
                {
                    var request = new GetByCityNameRequest(item);
                    requestList.Add(_requestExecutor.ExecuteRequest<GetByCityNameRequest, CurrentLocalWeatherDto>(request));
                }

                var currentWeatherResponses = await Task.WhenAll(requestList).ConfigureAwait(true);

                foreach (var response in currentWeatherResponses)
                {
                    var command = new GetByCityNameCurrentWeatherCommand(response.AsBusiness());

                    _commandDispatcher.Dispatch(command);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                GetDataFromWeatherApi();
                await Task.Delay(TimeSpan.FromMinutes(10), cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //TODO
        }
    }
}
