
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
            this.ctrlSchedules = new System.Windows.Forms.ListBox();
            this.ctrlProfessors = new System.Windows.Forms.ListBox();
            this.ctrlStudents = new System.Windows.Forms.ListBox();
            this.ctrlCourses = new System.Windows.Forms.ListBox();
            this.ctrlAddSchedule = new System.Windows.Forms.Button();
            this.ctrlRemoveSchedule = new System.Windows.Forms.Button();
            this.ctrlTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ctrlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlMain = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlLoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCalendar = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlSchedules
            // 
            this.ctrlSchedules.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ctrlSchedules.FormattingEnabled = true;
            this.ctrlSchedules.ItemHeight = 32;
            this.ctrlSchedules.Location = new System.Drawing.Point(12, 437);
            this.ctrlSchedules.Name = "ctrlSchedules";
            this.ctrlSchedules.Size = new System.Drawing.Size(1234, 196);
            this.ctrlSchedules.TabIndex = 7;
            // 
            // ctrlProfessors
            // 
            this.ctrlProfessors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ctrlProfessors.FormattingEnabled = true;
            this.ctrlProfessors.ItemHeight = 28;
            this.ctrlProfessors.Location = new System.Drawing.Point(427, 133);
            this.ctrlProfessors.Name = "ctrlProfessors";
            this.ctrlProfessors.Size = new System.Drawing.Size(400, 172);
            this.ctrlProfessors.TabIndex = 6;
            // 
            // ctrlStudents
            // 
            this.ctrlStudents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ctrlStudents.FormattingEnabled = true;
            this.ctrlStudents.ItemHeight = 28;
            this.ctrlStudents.Location = new System.Drawing.Point(846, 133);
            this.ctrlStudents.Name = "ctrlStudents";
            this.ctrlStudents.Size = new System.Drawing.Size(400, 172);
            this.ctrlStudents.TabIndex = 5;
            // 
            // ctrlCourses
            // 
            this.ctrlCourses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ctrlCourses.FormattingEnabled = true;
            this.ctrlCourses.ItemHeight = 28;
            this.ctrlCourses.Location = new System.Drawing.Point(12, 133);
            this.ctrlCourses.Name = "ctrlCourses";
            this.ctrlCourses.Size = new System.Drawing.Size(400, 172);
            this.ctrlCourses.TabIndex = 4;
            // 
            // ctrlAddSchedule
            // 
            this.ctrlAddSchedule.Location = new System.Drawing.Point(175, 379);
            this.ctrlAddSchedule.Name = "ctrlAddSchedule";
            this.ctrlAddSchedule.Size = new System.Drawing.Size(143, 32);
            this.ctrlAddSchedule.TabIndex = 8;
            this.ctrlAddSchedule.Text = "Add";
            this.ctrlAddSchedule.UseVisualStyleBackColor = true;
            this.ctrlAddSchedule.Click += new System.EventHandler(this.ctrlAddSchedule_Click);
            // 
            // ctrlRemoveSchedule
            // 
            this.ctrlRemoveSchedule.Location = new System.Drawing.Point(12, 379);
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
            this.ctrlFile,
            this.ctrlMain});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1275, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ctrlFile
            // 
            this.ctrlFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlExit});
            this.ctrlFile.Name = "ctrlFile";
            this.ctrlFile.Size = new System.Drawing.Size(46, 24);
            this.ctrlFile.Text = "File";
            // 
            // ctrlExit
            // 
            this.ctrlExit.Name = "ctrlExit";
            this.ctrlExit.Size = new System.Drawing.Size(116, 26);
            this.ctrlExit.Text = "Exit";
            this.ctrlExit.Click += new System.EventHandler(this.ctrlExit_Click);
            // 
            // ctrlMain
            // 
            this.ctrlMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlLoadData,
            this.ctrlSaveData});
            this.ctrlMain.Name = "ctrlMain";
            this.ctrlMain.Size = new System.Drawing.Size(56, 24);
            this.ctrlMain.Text = "Main";
            // 
            // ctrlLoadData
            // 
            this.ctrlLoadData.Name = "ctrlLoadData";
            this.ctrlLoadData.Size = new System.Drawing.Size(161, 26);
            this.ctrlLoadData.Text = "Load Data";
            this.ctrlLoadData.Click += new System.EventHandler(this.ctrlLoadData_Click);
            // 
            // ctrlSaveData
            // 
            this.ctrlSaveData.Name = "ctrlSaveData";
            this.ctrlSaveData.Size = new System.Drawing.Size(161, 26);
            this.ctrlSaveData.Text = "Save Data";
            this.ctrlSaveData.Click += new System.EventHandler(this.ctrlSaveData_Click);
            // 
            // ctrlCalendar
            // 
            this.ctrlCalendar.Location = new System.Drawing.Point(12, 329);
            this.ctrlCalendar.Name = "ctrlCalendar";
            this.ctrlCalendar.Size = new System.Drawing.Size(200, 22);
            this.ctrlCalendar.TabIndex = 16;
            // 
            // SchedulerForm
            // 
            this.ClientSize = new System.Drawing.Size(1275, 655);
            this.Controls.Add(this.ctrlCalendar);
            this.Controls.Add(this.ctrlTitle);
            this.Controls.Add(this.ctrlRemoveSchedule);
            this.Controls.Add(this.ctrlAddSchedule);
            this.Controls.Add(this.ctrlSchedules);
            this.Controls.Add(this.ctrlProfessors);
            this.Controls.Add(this.ctrlStudents);
            this.Controls.Add(this.ctrlCourses);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SchedulerForm";
            this.Load += new System.EventHandler(this.SchedulerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
      
        private System.Windows.Forms.ListBox ctrlSchedules;
        private System.Windows.Forms.ListBox ctrlProfessors;
        private System.Windows.Forms.ListBox ctrlStudents;
        private System.Windows.Forms.ListBox ctrlCourses;
        private System.Windows.Forms.Button ctrlAddSchedule;
        private System.Windows.Forms.Button ctrlRemoveSchedule;
        private System.Windows.Forms.Label ctrlTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctrlMain;
        private System.Windows.Forms.ToolStripMenuItem ctrlLoadData;
        private System.Windows.Forms.ToolStripMenuItem ctrlSaveData;
        private System.Windows.Forms.ToolStripMenuItem ctrlFile;
        private System.Windows.Forms.ToolStripMenuItem ctrlExit;
        private System.Windows.Forms.DateTimePicker ctrlCalendar;
    }
}