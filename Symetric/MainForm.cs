using System;
using System.IO;
using System.Windows.Forms;

namespace Asymmetric
{
    public partial class MainForm : Form
    {
        private string privateKey;
        private string publicKey;
        private string foreignPublicKey;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            (privateKey, publicKey) = AsymmetricEncryptionService.GenerateKeys();
            MessageBox.Show("Ключи сгенерированы. Не забудьте их сохранить.");
        }

        private void btnExportKeys_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                FileName = "rsa_key"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var basePath = Path.Combine(Path.GetDirectoryName(sfd.FileName), Path.GetFileNameWithoutExtension(sfd.FileName));

                AsymmetricEncryptionService.ExportKey(privateKey, basePath + "_private.xml");
                AsymmetricEncryptionService.ExportKey(publicKey, basePath + "_public.xml");

                MessageBox.Show("Ключи сохранены: \n- Закрытый: " + basePath + "_private.xml" + "\n- Открытый: " + basePath + "_public.xml");
            }
        }

        private void btnImportKey_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                privateKey = AsymmetricEncryptionService.ImportKey(ofd.FileName);
                MessageBox.Show("Закрытый ключ загружен.");
            }
        }

        private void btnDecryptForeign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(privateKey))
            {
                MessageBox.Show("Сначала загрузите или сгенерируйте приватный ключ.");
                return;
            }

            var ofd = new OpenFileDialog();
            ofd.Filter = "Зашифрованные файлы (*.dat)|*.dat|Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var encryptedData = File.ReadAllBytes(ofd.FileName);
                var decryptedData = AsymmetricEncryptionService.Decrypt(encryptedData, privateKey);

                var sfd = new SaveFileDialog();
                sfd.Filter = "Все файлы (*.*)|*.*";
                sfd.FileName = "decrypted_output";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, decryptedData);
                    MessageBox.Show("Файл успешно расшифрован и сохранён.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при дешифровании: " + ex.Message);
            }
        }

        private void buttonImportPublicKey_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "XML files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreignPublicKey = File.ReadAllText(ofd.FileName);
                MessageBox.Show("Публичный ключ соседа загружен.");
            }
        }
        private void buttonEncryptWithForeign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(foreignPublicKey))
            {
                MessageBox.Show("Импортируйте публичный ключ соседа перед шифрованием.");
                return;
            }

            var ofd = new OpenFileDialog();
            ofd.Filter = "Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            var data = File.ReadAllBytes(ofd.FileName);
            try
            {
                var encryptedData = AsymmetricEncryptionService.Encrypt(data, foreignPublicKey);

                var sfd = new SaveFileDialog();
                sfd.Filter = "Зашифрованные файлы (*.dat)|*.dat";
                sfd.FileName = "encrypted.dat";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, encryptedData);
                    MessageBox.Show("Файл успешно зашифрован и сохранён.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при шифровании: " + ex.Message);
            }

        }
    }
}
