using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class ClientEditForm : Form
    {
        private readonly IClientService _clientService;
        private readonly Client _client;
        private readonly bool _isEditMode;

        public ClientEditForm(IClientService clientService, Client? client = null)
        {
            InitializeComponent();

            _clientService = clientService;
            _isEditMode = client != null;
            _client = client ?? new Client();

            if (_isEditMode)
                LoadClientData();
        }

        private void LoadClientData()
        {
            txtName.Text = _client.Name;
            txtTaxNr.Text = _client.TaxNr;
            txtEmail.Text = _client.Email;
            txtPhone.Text = _client.Phone;
            txtAddress.Text = _client.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (_isEditMode)
            {
                _client.Name = txtName.Text.Trim();
                _client.TaxNr = txtTaxNr.Text.Trim();
                _client.Email = txtEmail.Text.Trim();
                _client.Phone = txtPhone.Text.Trim();
                _client.Address = txtAddress.Text.Trim();

                _clientService.UpdateClient(_client);
            }
            else
            {
                _clientService.AddClient(
                    txtName.Text.Trim(),
                    txtTaxNr.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim()
                );
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome é obrigatório.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTaxNr.Text))
            {
                MessageBox.Show("O NIF é obrigatório.");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
