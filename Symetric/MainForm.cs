using System;
using System.IO;
using System.Windows.Forms;

namespace Symetric
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
             var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Файл не найден");
                return;
            }

            var data = File.ReadAllBytes(txtFilePath.Text);
            var results = PerformanceTester.TestAlgorithms(data);

            dgvResults.Rows.Clear();
            foreach (var result in results)
            {
                dgvResults.Rows.Add(result.Algorithm, result.Mode, result.EncryptionTime.TotalMilliseconds, result.DecryptionTime.TotalMilliseconds);
            }
        }
    }
}
