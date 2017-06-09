namespace PerfectArm
{
    partial class FrmPrincipale
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdCollega = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.cmdScollega = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblFrame = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHand = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSerial = new System.Windows.Forms.ComboBox();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdCambiaAngolo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdCollega
            // 
            this.cmdCollega.Location = new System.Drawing.Point(13, 19);
            this.cmdCollega.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdCollega.Name = "cmdCollega";
            this.cmdCollega.Size = new System.Drawing.Size(112, 35);
            this.cmdCollega.TabIndex = 0;
            this.cmdCollega.Text = "Collega";
            this.cmdCollega.UseVisualStyleBackColor = true;
            this.cmdCollega.Click += new System.EventHandler(this.cmdCollega_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stato:";
            // 
            // lblStato
            // 
            this.lblStato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStato.ForeColor = System.Drawing.Color.Red;
            this.lblStato.Location = new System.Drawing.Point(341, 20);
            this.lblStato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(469, 34);
            this.lblStato.TabIndex = 2;
            this.lblStato.Text = "Not Connect";
            this.lblStato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdScollega
            // 
            this.cmdScollega.Location = new System.Drawing.Point(133, 19);
            this.cmdScollega.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdScollega.Name = "cmdScollega";
            this.cmdScollega.Size = new System.Drawing.Size(112, 35);
            this.cmdScollega.TabIndex = 3;
            this.cmdScollega.Text = "Scollega";
            this.cmdScollega.UseVisualStyleBackColor = true;
            this.cmdScollega.Click += new System.EventHandler(this.cmdScollega_Click);
            // 
            // lstLog
            // 
            this.lstLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(12, 366);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1138, 212);
            this.lstLog.TabIndex = 4;
            // 
            // lblFrame
            // 
            this.lblFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFrame.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrame.ForeColor = System.Drawing.Color.Black;
            this.lblFrame.Location = new System.Drawing.Point(89, 169);
            this.lblFrame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(1061, 34);
            this.lblFrame.TabIndex = 5;
            this.lblFrame.Text = "Not Connect";
            this.lblFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Frame:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hand:";
            // 
            // lblHand
            // 
            this.lblHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHand.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHand.ForeColor = System.Drawing.Color.Black;
            this.lblHand.Location = new System.Drawing.Point(89, 215);
            this.lblHand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHand.Name = "lblHand";
            this.lblHand.Size = new System.Drawing.Size(1061, 121);
            this.lblHand.TabIndex = 8;
            this.lblHand.Text = "Not Connect";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Serial:";
            // 
            // cmbSerial
            // 
            this.cmbSerial.FormattingEnabled = true;
            this.cmbSerial.Location = new System.Drawing.Point(341, 69);
            this.cmbSerial.Name = "cmbSerial";
            this.cmbSerial.Size = new System.Drawing.Size(121, 28);
            this.cmbSerial.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(609, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 12;
            // 
            // cmdCambiaAngolo
            // 
            this.cmdCambiaAngolo.Location = new System.Drawing.Point(715, 83);
            this.cmdCambiaAngolo.Name = "cmdCambiaAngolo";
            this.cmdCambiaAngolo.Size = new System.Drawing.Size(95, 44);
            this.cmdCambiaAngolo.TabIndex = 13;
            this.cmdCambiaAngolo.Text = "Cambia";
            this.cmdCambiaAngolo.UseVisualStyleBackColor = true;
            this.cmdCambiaAngolo.Click += new System.EventHandler(this.cmdCambiaAngolo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Angolo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(539, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Angolo:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(609, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 15;
            // 
            // FrmPrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 666);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdCambiaAngolo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbSerial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHand);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFrame);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.cmdScollega);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCollega);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmPrincipale";
            this.Text = "PerfectArm v.1.0.0";
            this.Load += new System.EventHandler(this.FrmPrincipale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCollega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Button cmdScollega;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSerial;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cmdCambiaAngolo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
    }
}

