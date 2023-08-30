namespace OgrUygulama
{
    partial class FrmOgrenciNotlar
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblNotlarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ogrUygulamaDataSet = new OgrUygulama.OgrUygulamaDataSet();
            this.tbl_NotlarTableAdapter = new OgrUygulama.OgrUygulamaDataSetTableAdapters.Tbl_NotlarTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNotlarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrUygulamaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // tblNotlarBindingSource
            // 
            this.tblNotlarBindingSource.DataMember = "Tbl_Notlar";
            this.tblNotlarBindingSource.DataSource = this.ogrUygulamaDataSet;
            // 
            // ogrUygulamaDataSet
            // 
            this.ogrUygulamaDataSet.DataSetName = "OgrUygulamaDataSet";
            this.ogrUygulamaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_NotlarTableAdapter
            // 
            this.tbl_NotlarTableAdapter.ClearBeforeFill = true;
            // 
            // FrmOgrenciNotlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmOgrenciNotlar";
            this.Text = "Öğrenci Not Ekranı";
            this.Load += new System.EventHandler(this.OgrenciNotlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNotlarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrUygulamaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private OgrUygulamaDataSet ogrUygulamaDataSet;
        private System.Windows.Forms.BindingSource tblNotlarBindingSource;
        private OgrUygulamaDataSetTableAdapters.Tbl_NotlarTableAdapter tbl_NotlarTableAdapter;
    }
}