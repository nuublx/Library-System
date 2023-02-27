
namespace DataBaseProject
{
    partial class generateReports
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
            this.BooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LibraryDataSet = new DataBaseProject.LibraryDataSet();
            this.BooksTableAdapter = new DataBaseProject.LibraryDataSetTableAdapters.BooksTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport12 = new DataBaseProject.CrystalReport1();
            this.CrystalReport11 = new DataBaseProject.CrystalReport1();
            ((System.ComponentModel.ISupportInitialize)(this.BooksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BooksBindingSource
            // 
            this.BooksBindingSource.DataMember = "Books";
            this.BooksBindingSource.DataSource = this.LibraryDataSet;
            // 
            // LibraryDataSet
            // 
            this.LibraryDataSet.DataSetName = "LibraryDataSet";
            this.LibraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BooksTableAdapter
            // 
            this.BooksTableAdapter.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport12;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1239, 618);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // generateReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 618);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "generateReports";
            this.Text = "generateReports";
            this.Load += new System.EventHandler(this.generateReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BooksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource BooksBindingSource;
        private LibraryDataSet LibraryDataSet;
        private LibraryDataSetTableAdapters.BooksTableAdapter BooksTableAdapter;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport1 CrystalReport11;
        private CrystalReport1 CrystalReport12;
    }
}