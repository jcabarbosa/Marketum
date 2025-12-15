using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class ClientListForm : Form
    {
        private readonly IClientService _clientService;

        public ClientListForm(IClientService clientService)
        {
            InitializeComponent();
            _clientService = clientService;
        }

        private void ClientListForm_Load(object sender, EventArgs e)
        {
            LoadClients();
            
            // Configurar double-click para editar
            dgvClients.DoubleClick += (s, e) => btnEdit_Click(s, e);
            
            // Configurar atalhos de teclado
            dgvClients.KeyDown += DgvClients_KeyDown;
        }

        private void LoadClients()
        {
            try
            {
                dgvClients.DataSource = null;
                var clients = _clientService.GetAllClients();
                dgvClients.DataSource = clients;
                
                // Configurar colunas
                if (dgvClients.Columns.Count > 0)
                {
                    dgvClients.Columns["Id"].HeaderText = "ID";
                    dgvClients.Columns["Id"].Width = 50;
                    dgvClients.Columns["Name"].HeaderText = "Nome";
                    dgvClients.Columns["Email"].HeaderText = "Email";
                    dgvClients.Columns["Phone"].HeaderText = "Telefone";
                    dgvClients.Columns["TaxNr"].HeaderText = "NIF";
                    dgvClients.Columns["Address"].HeaderText = "Morada";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ClientEditForm(_clientService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadClients();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is Client client)
            {
                using (var form = new ClientEditForm(_clientService, client))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadClients();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is Client client)
            {
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover o cliente '{client.Name}'?\n\nEsta ação não pode ser desfeita.",
                    "Confirmar Remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _clientService.RemoveClient(client.Id);
                        MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClients();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void DgvClients_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnEdit_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Delete:
                    btnRemove_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Insert:
                    btnAdd_Click(sender, EventArgs.Empty);
                    break;
            }
        }
    }
}
