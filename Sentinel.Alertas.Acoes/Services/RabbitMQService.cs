using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sentinel.Alertas.Acoes.Modelos;
using System.Text;
using System.Text.Json;

namespace Sentinel.Alertas.Acoes.Services
{
    public class RabbitMQService
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public event Action<Alerta> AlertaRecebido;
        public event Action<Alerta> CriticoRecebido;

        public RabbitMQService(IConnection connection, IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = connection;
            _channel = _connection.CreateModel();            
            ConfigurarFilas();
        }

        private void ConfigurarFilas()
        {
            ConfigurarFila("Alerta");
            ConfigurarFila("Critico");
        }

        private void ConfigurarFila(string tipo)
        {
            var exchange = _configuration[$"RabbitMQ:Exchanges:{tipo}"] ?? $"{tipo.ToLower()}-exchange";
            var queue = _configuration[$"RabbitMQ:Queues:{tipo}"] ?? $"{tipo.ToLower()}-queue";
            var routingKey = _configuration[$"RabbitMQ:RoutingKeys:{tipo}"] ?? $"{tipo.ToLower()}-key";
            _channel.QueueBind(queue, exchange, routingKey);
            IniciarConsumo(queue, tipo);
        }

        private void IniciarConsumo(string queue, string tipo)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var mensagem = Encoding.UTF8.GetString(ea.Body.ToArray());

                if (tipo == "Alerta")
                {
                    var alerta = JsonSerializer.Deserialize<Alerta>(mensagem);
                    AlertaRecebido?.Invoke(alerta);
                }
                else if (tipo == "Critico")
                {
                    var critico = JsonSerializer.Deserialize<Alerta>(mensagem); 
                    CriticoRecebido?.Invoke(critico);
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(queue: queue, autoAck: false, consumer: consumer);
        }
    }
}
