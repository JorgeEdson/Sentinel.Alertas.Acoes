using Sentinel.Alertas.Acoes.Modelos;
using Sentinel.Alertas.Acoes.Services;
using Sentinel.Alertas.Acoes.Utils;

namespace Sentinel.Alertas.Acoes
{
    public partial class ModalAcao : Form
    {
        public long _idAlerta { get; set; }
        private readonly ElasticsearchService _elasticsearchService;
        public event Action<long> AcaoSalva;

        public ModalAcao(long idAlerta, ElasticsearchService elasticsearchService)
        {
            InitializeComponent();
            _idAlerta = idAlerta;
            _elasticsearchService = elasticsearchService;
        }
        

        private async Task btnSalvar_Click(object sender, EventArgs e)
        {
            try 
            {
                var acao = new Acao
                {
                    Id = GeradorIdUtil.ProximoId(),
                    IdAlerta = _idAlerta,
                    Laudo = txtLaudo.Text,
                    Horario = DateTime.Now
                };

                await _elasticsearchService.IndexarDadosAsync(acao);
                
                AcaoSalva?.Invoke(_idAlerta);

                MessageBox.Show("Ação salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar ação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
