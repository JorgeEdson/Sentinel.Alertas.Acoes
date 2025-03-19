using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Sentinel.Alertas.Acoes.Modelos;

namespace Sentinel.Alertas.Acoes.Services
{
    public class ElasticsearchService
    {
        private readonly ElasticsearchClient _client;
        private readonly string _indexName;

        public ElasticsearchService(IConfiguration configuration)
        {
            var uri = configuration["Elasticsearch:Uri"] ?? throw new ArgumentNullException("Elasticsearch:Uri não configurado.");
            _indexName = configuration["Elasticsearch:Index"] ?? "acao";

            var settings = new ElasticsearchClientSettings(new Uri(uri));
            _client = new ElasticsearchClient(settings);
        }

        public async Task IndexarDadosAsync(Acao acao)
        {
            var response = await _client.IndexAsync(acao, idx => idx.Index(_indexName));

            if (!response.IsValidResponse)
            {
                throw new Exception($"Erro ao indexar no Elasticsearch: {response.DebugInformation}");
            }
        }
    }
}
