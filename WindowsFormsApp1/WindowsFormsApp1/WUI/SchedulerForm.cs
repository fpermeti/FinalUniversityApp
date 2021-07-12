using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WindowsFormsApp1.Impl;

namespace WindowsFormsApp1.WUI {

    public partial class SchedulerForm : Form {

        private University _CodingSchool;

        private const string _JsonFile = "UniversityData.json";

        private DataGridViewButtonColumn ctrlViewProfessorCourses;

        #region



        #endregion

        public SchedulerForm() {
            InitializeComponent();
        }

        private void PopulateListBoxes() {


            if (_CodingSchool.Professors.Count == 0 || _CodingSchool.Students.Count == 0 || _CodingSchool.Courses.Count == 0) {

                DataPopulation.CreateDummyData(_CodingSchool);
            }

            PopulateSchedulesDataGrid();
        }

        private void PopulateSchedulesDataGrid() {
            DataTable dataTable = new DataTable();


            dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));


            dataTable.Columns.Add(new DataColumn("Course code", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Course subject", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Course duration", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Professor", typeof(string)));

            dataTable.Columns.Add(new DataColumn("Calendar", typeof(string)));



            foreach (Schedule schedule in _CodingSchool.Schedules) {

                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = schedule.Id;
                dataRow["Calendar"] = schedule.Calendar;
                dataRow["Course code"] = _CodingSchool.Courses.Find(x => x.Id == schedule.CourseId).Code;
                dataRow["Course subject"] = _CodingSchool.Courses.Find(x => x.Id == schedule.CourseId).Subject;

                dataRow["Course duration"] = _CodingSchool.Courses.Find(x => x.Id == schedule.CourseId).Duration;

                dataRow["Professor"] = _CodingSchool.Professors.Find(x => x.Id == schedule.ProfessorId).Name + "  " + _CodingSchool.Professors.Find(x => x.Id == schedule.ProfessorId).Surname;

                //dataRow["Student"] = _CodingSchool.Students.Find(x => x.Id == schedule.StudentId).Name + "  " + _CodingSchool.Students.Find(x => x.Id == schedule.StudentId).Surname; ;


                dataTable.Rows.Add(dataRow);
            }

            ctrlSchedules.DataSource = dataTable;
            ctrlSchedules.Columns[0].Visible = false;
        }

        private void DeserializeFromJson() {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string path = Path.Combine(Environment.CurrentDirectory, _JsonFile);

            string data = string.Empty;

            if (File.Exists(path)) {

                data = File.ReadAllText(path);

                _CodingSchool = serializer.Deserialize<University>(data);
            }
            else {

                File.Create(path).Dispose();

                _CodingSchool = new University();

                SerializeToJson(_CodingSchool);
            }
        }

        private void SerializeToJson(object objectToBeSerialized) {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string data = serializer.Serialize(objectToBeSerialized);

            string path = Path.Combine(Environment.CurrentDirectory, _JsonFile);

            File.WriteAllText(path, data);

            //MessageBox.Show("OK");

        }

        private void AddSchedule() {

            // TODO: 1. CANNOT ADD SAME STUDENT + PROFESSOR IN SAME DATE & HOUR

            // TODO: 2. EACH STUDENT CANNOT HAVE MORE THAN 3 COURSES PER DAY!

            // TODO: 3. A PROFESSOR CANNOT TEACH MORE THAN 4 COURSES PER DAY AND 40 COURSES PER WEEK


            DialogResult result = MessageBox.Show("Are you sure you want to create this entry ?", "Warning", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) {


                if (ctrlCourses.SelectedRows.Count > 0 && ctrlProfessors.SelectedRows.Count > 0) {



                    //---------------------------------------------------------------------------------------
                    Guid courseId = Guid.Parse(Convert.ToString(ctrlCourses.SelectedRows[0].Cells["Id"].Value));

                    Guid profId = Guid.Parse(Convert.ToString(ctrlProfessors.SelectedRows[0].Cells["Id"].Value));


                    //---------------------------------------------------------------------------------------

                    if (_CodingSchool.Schedules.Count == 0) {

                        _CodingSchool.Schedules.Add(new Schedule() {

                            CourseId = courseId,

                            ProfessorId = profId,

                            //StudentId = studId,

                            Calendar = ctrlCalendar.Value.ToString()
                        });

                        PopulateSchedulesDataGrid();

                        SerializeToJson(_CodingSchool);

                        MessageBox.Show("OK");

                    }
                    else {

                        MessageBox.Show("ERROR");
                    }






                    //----------------------------------------------------------------------------------------------

                }
                else {

                    MessageBox.Show("Please select an item in each list");
                }
            }
        }

        private void ctrlExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ctrlAddSchedule_Click(object sender, EventArgs e) {
            AddSchedule();

        }

        private void ctrlRemoveSchedule_Click(object sender, EventArgs e) {

            if (ctrlSchedules.SelectedRows.Count > 0) {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry ?", "Warning", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK) {

                    _CodingSchool.Schedules.RemoveAll(x => x.Id == Guid.Parse(Convert.ToString(ctrlSchedules.SelectedRows[0].Cells["Id"].Value)));

                    foreach (DataGridViewRow dataGridViewRow in ctrlSchedules.SelectedRows) {
                        ctrlSchedules.Rows.RemoveAt(dataGridViewRow.Index);
                    }

                    SerializeToJson(_CodingSchool);
                }
            }
            else {

                MessageBox.Show("You have to select a specific row.");
            }

        }

        private void SchedulerForm_Load(object sender, EventArgs e) {

            ctrlCalendar.Format = DateTimePickerFormat.Custom;
            ctrlCalendar.CustomFormat = "dd-MM-yyyy HH:MM";


            ctrlCalendar.MinDate = DateTime.Now;

            DeserializeFromJson();

            PopulateListBoxes();

            PopulateCoursesDataGridView();


        }

        private void PopulateProfessorsDataGridView(Guid selectedCourseId) {



            DataTable professorsDataTable = new DataTable();

            professorsDataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));
            professorsDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            professorsDataTable.Columns.Add(new DataColumn("Surname", typeof(string)));
            professorsDataTable.Columns.Add(new DataColumn("Rank", typeof(ProfessorRank)));
            professorsDataTable.Columns.Add(new DataColumn("Age", typeof(int)));


            foreach (Professor professor in _CodingSchool.Professors.FindAll(x => x.Courses.Contains(_CodingSchool.Courses.Find(y => y.Id == selectedCourseId)))) {

                DataRow dataRow = professorsDataTable.NewRow();

                dataRow["Id"] = professor.Id;
                dataRow["Name"] = professor.Name;
                dataRow["Surname"] = professor.Surname;

                dataRow["Rank"] = professor.Rank;
                dataRow["Age"] = professor.Age;


                professorsDataTable.Rows.Add(dataRow);
            }

            ctrlProfessors.DataSource = professorsDataTable;




            if (!ctrlProfessors.Columns.Contains("ViewCourses")) {

                ctrlViewProfessorCourses = new DataGridViewButtonColumn();
                ctrlViewProfessorCourses.Name = "ViewCourses";
                ctrlViewProfessorCourses.HeaderText = "View Courses";
                ctrlViewProfessorCourses.UseColumnTextForButtonValue = true;

                ctrlProfessors.Columns.Add(ctrlViewProfessorCourses);
            }


            ctrlProfessors.Columns[0].Visible = false;


        }

        private void PopulateCoursesDataGridView() {
            DataTable dataTable = new DataTable();

            //PopulateDataTableColumns(dataTable, typeof(Course));



            dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));
            dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Subject", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Duration", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Category", typeof(CourseCategory)));





            foreach (Course course in _CodingSchool.Courses) {

                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = course.Id;
                dataRow["Code"] = course.Code;
                dataRow["Subject"] = course.Subject;
                dataRow["Duration"] = course.Duration;
                dataRow["Category"] = course.Category;

                dataTable.Rows.Add(dataRow);
            }

            ctrlCourses.DataSource = dataTable;
            ctrlCourses.Columns[0].Visible = false;
        }

        private void ctrlCalendar_ValueChanged(object sender, EventArgs e) {

            //System.DayOfWeek i = ctrlCalendar.Value.DayOfWeek;
            //if ((i == System.DayOfWeek.Sunday) || (i == System.DayOfWeek.Saturday)) {
            //    MessageBox.Show("Please try again, can't select a weekend day");
            //    ctrlCalendar.Value = DateTime.Now;
            //    return;
            //}
        }

        private void ctrlCourses_SelectionChanged(object sender, EventArgs e) {

            Guid selectedCourseId = Guid.Parse(Convert.ToString(ctrlCourses.SelectedRows[0].Cells["Id"].Value));

            if (ctrlProfessors.Columns.Contains("ViewCourses")) {
                ctrlProfessors.Columns.Remove(ctrlViewProfessorCourses);
            }


            PopulateProfessorsDataGridView(selectedCourseId);



        }

        private void ctrlProfessors_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == ctrlProfessors.Columns["ViewCourses"].Index) {

                Professor professor = _CodingSchool.Professors.Find(x => x.Id == Guid.Parse(Convert.ToString(ctrlProfessors.SelectedRows[0].Cells["Id"].Value)));

                string professorCourses = string.Empty;

                foreach (Course course in professor.Courses) {

                    professorCourses += string.Format("Code: {0} - Subject: {1} - Hours: {2}\n", course.Code, course.Subject, course.Duration);

                }

                MessageBox.Show(professorCourses);
            }
        }
    }

}

