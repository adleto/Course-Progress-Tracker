﻿namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    partial class frmMojiKursevi
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
            this.gridInstance = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedFilter = new System.Windows.Forms.CheckedListBox();
            this.btnFiltriraj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridInstance)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInstance
            // 
            this.gridInstance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInstance.Location = new System.Drawing.Point(12, 41);
            this.gridInstance.Name = "gridInstance";
            this.gridInstance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInstance.Size = new System.Drawing.Size(880, 513);
            this.gridInstance.TabIndex = 0;
            this.gridInstance.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridInstance_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Za vođenje kursa pritisni dvoklik na jednu od instanci";
            // 
            // checkedFilter
            // 
            this.checkedFilter.CheckOnClick = true;
            this.checkedFilter.FormattingEnabled = true;
            this.checkedFilter.Location = new System.Drawing.Point(898, 41);
            this.checkedFilter.Name = "checkedFilter";
            this.checkedFilter.Size = new System.Drawing.Size(120, 124);
            this.checkedFilter.TabIndex = 2;
            // 
            // btnFiltriraj
            // 
            this.btnFiltriraj.Location = new System.Drawing.Point(898, 171);
            this.btnFiltriraj.Name = "btnFiltriraj";
            this.btnFiltriraj.Size = new System.Drawing.Size(120, 23);
            this.btnFiltriraj.TabIndex = 3;
            this.btnFiltriraj.Text = "Filtriraj";
            this.btnFiltriraj.UseVisualStyleBackColor = true;
            this.btnFiltriraj.Click += new System.EventHandler(this.btnFiltriraj_Click);
            // 
            // frmMojiKursevi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 566);
            this.Controls.Add(this.btnFiltriraj);
            this.Controls.Add(this.checkedFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridInstance);
            this.Name = "frmMojiKursevi";
            this.Text = "Moji kursevi";
            this.Load += new System.EventHandler(this.frmMojiKursevi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInstance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridInstance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedFilter;
        private System.Windows.Forms.Button btnFiltriraj;
    }
}