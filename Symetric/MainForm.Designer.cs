using System;
using System.Windows.Forms;

namespace Asymmetric
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDecryptForeign = new System.Windows.Forms.Button();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.btnExportKey = new System.Windows.Forms.Button();
            this.buttonImportPublicKey = new System.Windows.Forms.Button();
            this.buttonEncryptWithForeign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDecryptForeign
            // 
            this.btnDecryptForeign.Location = new System.Drawing.Point(63, 147);
            this.btnDecryptForeign.Name = "btnDecryptForeign";
            this.btnDecryptForeign.Size = new System.Drawing.Size(153, 23);
            this.btnDecryptForeign.TabIndex = 2;
            this.btnDecryptForeign.Text = "Decrypt Foreign File";
            this.btnDecryptForeign.UseVisualStyleBackColor = true;
            this.btnDecryptForeign.Click += new System.EventHandler(this.btnDecryptForeign_Click);
            // 
            // btnGenerateKeys
            // 
            this.btnGenerateKeys.Location = new System.Drawing.Point(63, 13);
            this.btnGenerateKeys.Name = "btnGenerateKeys";
            this.btnGenerateKeys.Size = new System.Drawing.Size(153, 23);
            this.btnGenerateKeys.TabIndex = 4;
            this.btnGenerateKeys.Text = "Generate Keys";
            this.btnGenerateKeys.UseVisualStyleBackColor = true;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);
            // 
            // btnExportKey
            // 
            this.btnExportKey.Location = new System.Drawing.Point(222, 12);
            this.btnExportKey.Name = "btnExportKey";
            this.btnExportKey.Size = new System.Drawing.Size(153, 23);
            this.btnExportKey.TabIndex = 5;
            this.btnExportKey.Text = "Export Keys";
            this.btnExportKey.UseVisualStyleBackColor = true;
            this.btnExportKey.Click += new System.EventHandler(this.btnExportKeys_Click);
            // 
            // buttonImportPublicKey
            // 
            this.buttonImportPublicKey.Location = new System.Drawing.Point(63, 86);
            this.buttonImportPublicKey.Name = "buttonImportPublicKey";
            this.buttonImportPublicKey.Size = new System.Drawing.Size(81, 23);
            this.buttonImportPublicKey.TabIndex = 6;
            this.buttonImportPublicKey.Text = "Import Public Key";
            this.buttonImportPublicKey.UseVisualStyleBackColor = true;
            this.buttonImportPublicKey.Click += new System.EventHandler(this.buttonImportPublicKey_Click);
            // 
            // buttonEncryptWithForeign
            // 
            this.buttonEncryptWithForeign.Location = new System.Drawing.Point(150, 86);
            this.buttonEncryptWithForeign.Name = "buttonEncryptWithForeign";
            this.buttonEncryptWithForeign.Size = new System.Drawing.Size(207, 23);
            this.buttonEncryptWithForeign.TabIndex = 7;
            this.buttonEncryptWithForeign.Text = "Encrypt File with Foreign Key";
            this.buttonEncryptWithForeign.UseVisualStyleBackColor = true;
            this.buttonEncryptWithForeign.Click += new System.EventHandler(this.buttonEncryptWithForeign_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEncryptWithForeign);
            this.Controls.Add(this.buttonImportPublicKey);
            this.Controls.Add(this.btnExportKey);
            this.Controls.Add(this.btnGenerateKeys);
            this.Controls.Add(this.btnDecryptForeign);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button btnDecryptForeign;
        private Button btnGenerateKeys;
        private Button btnExportKey;
        private Button buttonImportPublicKey;
        private Button buttonEncryptWithForeign;
    }
}

