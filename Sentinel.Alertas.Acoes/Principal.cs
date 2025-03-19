using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using Sentinel.Alertas.Acoes.Modelos;
using Sentinel.Alertas.Acoes.Services;
using System.Media;

namespace Sentinel.Alertas.Acoes
{
    public partial class Principal : Form
    {
        private RabbitMQService _rabbitMQService;
        private ElasticsearchService _elasticsearchService;



        public Principal()
        {
            InitializeComponent();
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" }; // Configure seu host RabbitMQ aqui
            var connection = connectionFactory.CreateConnection();
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Carregar configurações

            _rabbitMQService = new RabbitMQService(connection, configuration);
            _elasticsearchService = new ElasticsearchService(configuration);
            
            _rabbitMQService.AlertaRecebido += OnAlertaRecebido;
            _rabbitMQService.CriticoRecebido += OnCriticoRecebido;
        }

        private void OnAlertaRecebido(Alerta alerta)
        {
            // Atualizar GridView com a mensagem de alerta
            if (dgvAlertas.InvokeRequired)
            {
                dgvAlertas.Invoke(new Action(() => AdicionarAlertaAoGrid(dgvAlertas, alerta)));
            }
            else
            {
                AdicionarAlertaAoGrid(dgvAlertas, alerta);
            }

            TocarSom("alerta.wav");
        }

        private void OnCriticoRecebido(Alerta critico)
        {

            if (dgvCriticos.InvokeRequired)
            {
                dgvCriticos.Invoke(new Action(() => AdicionarAlertaAoGrid(dgvCriticos, critico)));
            }
            else
            {
                AdicionarAlertaAoGrid(dgvCriticos, critico);
            }

            TocarSom("critico.wav");
        }

        private void AdicionarAlertaAoGrid(DataGridView grid, Alerta alerta)
        {

            grid.Rows.Add(alerta.Id, alerta.Mensagem);
        }

        private void TocarSom(string arquivo)
        {
            try
            {
                string caminhoArquivo = Path.Combine(Application.StartupPath, "Resources", arquivo);

                using (SoundPlayer player = new SoundPlayer(caminhoArquivo))
                {
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao reproduzir o som: {ex.Message}");
            }
        }

        private void dgvCriticos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                var criticoId = dgvCriticos.Rows[e.RowIndex].Cells[0].Value;
                AbrirModal((long)criticoId, "Alerta");
            }
        }

        private void dgvAlertas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                var alertaId = dgvAlertas.Rows[e.RowIndex].Cells[0].Value;
                AbrirModal((long)alertaId, "Critico");
            }
        }

        private void AbrirModal(long idAlerta, string tipo)
        {
            var modalForm = new ModalAcao(idAlerta,_elasticsearchService);
           
            modalForm.AcaoSalva += (alertaId) =>
            {
                if (tipo == "Critico")
                    RemoverLinhaCritico(alertaId);
                else
                    RemoverLinhaAlerta(alertaId);
            };

            modalForm.ShowDialog();
        }
        private void RemoverLinhaAlerta(long idAlerta)
        {
            foreach (DataGridViewRow row in dgvAlertas.Rows)
            {
                if (Convert.ToInt64(row.Cells[0].Value) == idAlerta)
                {
                    dgvAlertas.Rows.Remove(row);
                    break;
                }
            }
        }

        private void RemoverLinhaCritico(long idAlerta)
        {
            foreach (DataGridViewRow row in dgvCriticos.Rows)
            {
                if (Convert.ToInt64(row.Cells[0].Value) == idAlerta)
                {
                    dgvCriticos.Rows.Remove(row);
                    break;
                }
            }
        }
    }
}
