namespace eCourse.WinUI.Izvjestaji
{
    partial class frmKursRpt
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MojaKursInstancaForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnFiltriraj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateDo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateOd = new System.Windows.Forms.DateTimePicker();
            this.comboBroj = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MojaKursInstancaForReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MojaKursInstancaForReportBindingSource
            // 
            this.MojaKursInstancaForReportBindingSource.DataSource = typeof(eCourse.Models.KursInstanca.MojaKursInstancaForReport);
            // 
            // btnFiltriraj
            // 
            this.btnFiltriraj.Location = new System.Drawing.Point(1048, 196);
            this.btnFiltriraj.Name = "btnFiltriraj";
            this.btnFiltriraj.Size = new System.Drawing.Size(75, 23);
            this.btnFiltriraj.TabIndex = 19;
            this.btnFiltriraj.Text = "Filtriraj";
            this.btnFiltriraj.UseVisualStyleBackColor = true;
            this.btnFiltriraj.Click += new System.EventHandler(this.btnFiltriraj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1028, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Uzmi prvih [Broj] zapisa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1055, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Datum do";
            // 
            // dateDo
            // 
            this.dateDo.Location = new System.Drawing.Point(989, 115);
            this.dateDo.Name = "dateDo";
            this.dateDo.Size = new System.Drawing.Size(200, 20);
            this.dateDo.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1055, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Datum od";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1066, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filteri";
            // 
            // dateOd
            // 
            this.dateOd.Location = new System.Drawing.Point(989, 73);
            this.dateOd.Name = "dateOd";
            this.dateOd.Size = new System.Drawing.Size(200, 20);
            this.dateOd.TabIndex = 13;
            // 
            // comboBroj
            // 
            this.comboBroj.FormattingEnabled = true;
            this.comboBroj.Location = new System.Drawing.Point(989, 159);
            this.comboBroj.Name = "comboBroj";
            this.comboBroj.Size = new System.Drawing.Size(201, 21);
            this.comboBroj.TabIndex = 12;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dataSetKursDetails";
            reportDataSource1.Value = this.MojaKursInstancaForReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCourse.WinUI.Izvjestaji.KursReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 7);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(970, 596);
            this.reportViewer1.TabIndex = 20;
            // 
            // frmKursRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 606);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnFiltriraj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateDo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateOd);
            this.Controls.Add(this.comboBroj);
            this.Name = "frmKursRpt";
            this.Text = "Izvještaj o popularnosti kurseva";
            this.Load += new System.EventHandler(this.frmKursRpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MojaKursInstancaForReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFiltriraj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateOd;
        private System.Windows.Forms.ComboBox comboBroj;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MojaKursInstancaForReportBindingSource;
    }
}