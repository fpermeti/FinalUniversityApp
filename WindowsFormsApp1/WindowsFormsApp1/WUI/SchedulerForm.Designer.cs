
namespace WindowsFormsApp1.WUI {
    partial class SchedulerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ctrlAddSchedule = new System.Windows.Forms.Button();
            this.ctrlRemoveSchedule = new System.Windows.Forms.Button();
            this.ctrlTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ctrlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCalendar = new System.Windows.Forms.DateTimePicker();
            this.lblCourses = new System.Windows.Forms.Label();
            this.lblProfessors = new System.Windows.Forms.Label();
            this.lblStudents = new System.Windows.Forms.Label();
            this.ctrlCourses = new System.Windows.Forms.DataGridView();
            this.ctrlProfessors = new System.Windows.Forms.DataGridView();
            this.ctrlStudents = new System.Windows.Forms.DataGridView();
            this.ctrlSchedules = new System.Windows.Forms.DataGridView();
            this.lblSchedules = new System.Windows.Forms.Label();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlProfessors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlAddSchedule
            // 
            this.ctrlAddSchedule.Location = new System.Drawing.Point(174, 392);
            this.ctrlAddSchedule.Name = "ctrlAddSchedule";
            this.ctrlAddSchedule.Size = new System.Drawing.Size(143, 32);
            this.ctrlAddSchedule.TabIndex = 8;
            this.ctrlAddSchedule.Text = "Add";
            this.ctrlAddSchedule.UseVisualStyleBackColor = true;
            this.ctrlAddSchedule.Click += new System.EventHandler(this.ctrlAddSchedule_Click);
            // 
            // ctrlRemoveSchedule
            // 
            this.ctrlRemoveSchedule.Location = new System.Drawing.Point(14, 392);
            this.ctrlRemoveSchedule.Name = "ctrlRemoveSchedule";
            this.ctrlRemoveSchedule.Size = new System.Drawing.Size(143, 32);
            this.ctrlRemoveSchedule.TabIndex = 9;
            this.ctrlRemoveSchedule.Text = "Remove";
            this.ctrlRemoveSchedule.UseVisualStyleBackColor = true;
            this.ctrlRemoveSchedule.Click += new System.EventHandler(this.ctrlRemoveSchedule_Click);
            // 
            // ctrlTitle
            // 
            this.ctrlTitle.AutoSize = true;
            this.ctrlTitle.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ctrlTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ctrlTitle.Location = new System.Drawing.Point(368, 45);
            this.ctrlTitle.Name = "ctrlTitle";
            this.ctrlTitle.Size = new System.Drawing.Size(538, 54);
            this.ctrlTitle.TabIndex = 13;
            this.ctrlTitle.Text = "University Courses Scheduler";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1243, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ctrlFile
            // 
            this.ctrlFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlExit});
            this.ctrlFile.Name = "ctrlFile";
            this.ctrlFile.Size = new System.Drawing.Size(46, 26);
            this.ctrlFile.Text = "File";
            // 
            // ctrlExit
            // 
            this.ctrlExit.Name = "ctrlExit";
            this.ctrlExit.Size = new System.Drawing.Size(116, 26);
            this.ctrlExit.Text = "Exit";
            this.ctrlExit.Click += new System.EventHandler(this.ctrlExit_Click);
            // 
            // ctrlCalendar
            // 
            this.ctrlCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ctrlCalendar.Location = new System.Drawing.Point(106, 332);
            this.ctrlCalendar.Name = "ctrlCalendar";
            this.ctrlCalendar.Size = new System.Drawing.Size(200, 22);
            this.ctrlCalendar.TabIndex = 16;
            this.ctrlCalendar.ValueChanged += new System.EventHandler(this.ctrlCalendar_ValueChanged);
            // 
            // lblCourses
            // 
            this.lblCourses.AutoSize = true;
            this.lblCourses.Location = new System.Drawing.Point(12, 113);
            this.lblCourses.Name = "lblCourses";
            this.lblCourses.Size = new System.Drawing.Size(94, 17);
            this.lblCourses.TabIndex = 17;
            this.lblCourses.Text = "Select course";
            // 
            // lblProfessors
            // 
            this.lblProfessors.AutoSize = true;
            this.lblProfessors.Location = new System.Drawing.Point(424, 113);
            this.lblProfessors.Name = "lblProfessors";
            this.lblProfessors.Size = new System.Drawing.Size(111, 17);
            this.lblProfessors.TabIndex = 18;
            this.lblProfessors.Text = "Select professor";
            // 
            // lblStudents
            // 
            this.lblStudents.AutoSize = true;
            this.lblStudents.Location = new System.Drawing.Point(843, 113);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(98, 17);
            this.lblStudents.TabIndex = 19;
            this.lblStudents.Text = "Select student";
            // 
            // ctrlCourses
            // 
            this.ctrlCourses.AllowUserToAddRows = false;
            this.ctrlCourses.AllowUserToDeleteRows = false;
            this.ctrlCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctrlCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlCourses.Location = new System.Drawing.Point(12, 133);
            this.ctrlCourses.MultiSelect = false;
            this.ctrlCourses.Name = "ctrlCourses";
            this.ctrlCourses.ReadOnly = true;
            this.ctrlCourses.RowHeadersWidth = 51;
            this.ctrlCourses.RowTemplate.Height = 24;
            this.ctrlCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlCourses.Size = new System.Drawing.Size(369, 186);
            this.ctrlCourses.TabIndex = 20;
            // 
            // ctrlProfessors
            // 
            this.ctrlProfessors.AllowUserToAddRows = false;
            this.ctrlProfessors.AllowUserToDeleteRows = false;
            this.ctrlProfessors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctrlProfessors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlProfessors.Location = new System.Drawing.Point(427, 133);
            this.ctrlProfessors.MultiSelect = false;
            this.ctrlProfessors.Name = "ctrlProfessors";
            this.ctrlProfessors.ReadOnly = true;
            this.ctrlProfessors.RowHeadersWidth = 51;
            this.ctrlProfessors.RowTemplate.Height = 24;
            this.ctrlProfessors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlProfessors.Size = new System.Drawing.Size(369, 186);
            this.ctrlProfessors.TabIndex = 21;
            // 
            // ctrlStudents
            // 
            this.ctrlStudents.AllowUserToAddRows = false;
            this.ctrlStudents.AllowUserToDeleteRows = false;
            this.ctrlStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctrlStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlStudents.Location = new System.Drawing.Point(846, 133);
            this.ctrlStudents.MultiSelect = false;
            this.ctrlStudents.Name = "ctrlStudents";
            this.ctrlStudents.ReadOnly = true;
            this.ctrlStudents.RowHeadersWidth = 51;
            this.ctrlStudents.RowTemplate.Height = 24;
            this.ctrlStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlStudents.Size = new System.Drawing.Size(369, 186);
            this.ctrlStudents.TabIndex = 22;
            // 
            // ctrlSchedules
            // 
            this.ctrlSchedules.AllowUserToAddRows = false;
            this.ctrlSchedules.AllowUserToDeleteRows = false;
            this.ctrlSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctrlSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlSchedules.Location = new System.Drawing.Point(15, 468);
            this.ctrlSchedules.MultiSelect = false;
            this.ctrlSchedules.Name = "ctrlSchedules";
            this.ctrlSchedules.ReadOnly = true;
            this.ctrlSchedules.RowHeadersWidth = 51;
            this.ctrlSchedules.RowTemplate.Height = 24;
            this.ctrlSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlSchedules.Size = new System.Drawing.Size(1200, 186);
            this.ctrlSchedules.TabIndex = 23;
            // 
            // lblSchedules
            // 
            this.lblSchedules.AutoSize = true;
            this.lblSchedules.Location = new System.Drawing.Point(12, 448);
            this.lblSchedules.Name = "lblSchedules";
            this.lblSchedules.Size = new System.Drawing.Size(108, 17);
            this.lblSchedules.TabIndex = 24;
            this.lblSchedules.Text = "Select schedule";
            // 
            // lblCalendar
            // 
            this.lblCalendar.AutoSize = true;
            this.lblCalendar.Location = new System.Drawing.Point(12, 337);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(79, 17);
            this.lblCalendar.TabIndex = 25;
            this.lblCalendar.Text = "Select date";
            // 
            // SchedulerForm
            // 
            this.ClientSize = new System.Drawing.Size(1243, 666);
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.lblSchedules);
            this.Controls.Add(this.ctrlSchedules);
            this.Controls.Add(this.ctrlStudents);
            this.Controls.Add(this.ctrlProfessors);
            this.Controls.Add(this.ctrlCourses);
            this.Controls.Add(this.lblStudents);
            this.Controls.Add(this.lblProfessors);
            this.Controls.Add(this.lblCourses);
            this.Controls.Add(this.ctrlCalendar);
            this.Controls.Add(this.ctrlTitle);
            this.Controls.Add(this.ctrlRemoveSchedule);
            this.Controls.Add(this.ctrlAddSchedule);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SchedulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SchedulerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlProfessors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSchedules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ctrlAddSchedule;
        private System.Windows.Forms.Button ctrlRemoveSchedule;
        private System.Windows.Forms.Label ctrlTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctrlFile;
        private System.Windows.Forms.ToolStripMenuItem ctrlExit;
        private System.Windows.Forms.DateTimePicker ctrlCalendar;
        private System.Windows.Forms.Label lblCourses;
        private System.Windows.Forms.Label lblProfessors;
        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.DataGridView ctrlCourses;
        private System.Windows.Forms.DataGridView ctrlProfessors;
        private System.Windows.Forms.DataGridView ctrlStudents;
        private System.Windows.Forms.DataGridView ctrlSchedules;
        private System.Windows.Forms.Label lblSchedules;
        private System.Windows.Forms.Label lblCalendar;
    }
}