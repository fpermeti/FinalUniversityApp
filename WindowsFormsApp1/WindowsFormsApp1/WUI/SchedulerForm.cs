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

            PopulateDataTableColumns(dataTable, typeof(Schedule));


            foreach (Schedule schedule in _CodingSchool.Schedules) {

                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = schedule.Id;
                dataRow["Calendar"] = schedule.Calendar;
                dataRow["CourseId"] = schedule.CourseId;
                dataRow["ProfessorId"] = schedule.ProfessorId;
                dataRow["StudentId"] = schedule.StudentId;

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


                if (ctrlCourses.SelectedRows.Count > 0 && ctrlProfessors.SelectedRows.Count > 0 && ctrlStudents.SelectedRows.Count > 0) {



                    _CodingSchool.Schedules.Add(new Schedule() {

                        CourseId = Guid.Parse(Convert.ToString(ctrlCourses.SelectedRows[0].Cells["Id"].Value)),

                        ProfessorId = Guid.Parse(Convert.ToString(ctrlProfessors.SelectedRows[0].Cells["Id"].Value)),

                        StudentId = Guid.Parse(Convert.ToString(ctrlStudents.SelectedRows[0].Cells["Id"].Value)),

                        Calendar = ctrlCalendar.Value.ToString()
                    });

                    PopulateSchedulesDataGrid();

                    SerializeToJson(_CodingSchool);

                    //MessageBox.Show("OK");

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

            PopulateProfessorsDataGridView();

            PopulateStudentsDataGridView();

        }

        private void PopulateStudentsDataGridView() {
            DataTable dataTable = new DataTable();

            PopulateDataTableColumns(dataTable, typeof(Student));


            foreach (Student student in _CodingSchool.Students) {

                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = student.Id;
                dataRow["Surname"] = student.Surname;
                dataRow["Name"] = student.Name;
                dataRow["Age"] = student.Age;
                dataRow["RegistrationNumber"] = student.RegistrationNumber;

                dataTable.Rows.Add(dataRow);
            }

            ctrlStudents.DataSource = dataTable;



            DataGridViewButtonColumn ctrlViewStudentCourses = new DataGridViewButtonColumn();
            ctrlViewStudentCourses.Name = "ViewCourses";
            ctrlViewStudentCourses.Text = "View Courses";
            //int columnIndex = 2;
            if (ctrlStudents.Columns["ViewCourses"] == null) {
                ctrlStudents.Columns.Insert(ctrlStudents.Columns.Count, ctrlViewStudentCourses);
            }

            ctrlStudents.CellClick += ctrlStudents_CellClick;



            ctrlStudents.Columns[0].Visible = false;
        }


        private void ctrlStudents_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == ctrlStudents.Columns["ViewCourses"].Index) {

                Student student = _CodingSchool.Students.Find(x => x.Id == Guid.Parse(Convert.ToString(ctrlStudents.SelectedRows[0].Cells["Id"].Value)));

                string studentCourses = string.Empty;

                foreach (Course course in student.Courses) {

                    studentCourses += string.Format("Code: {0} - Subject: {1} - Hours: {2}\n", course.Code, course.Subject, course.Hours);

                }

                MessageBox.Show(studentCourses);
            }
        }




        private void PopulateProfessorsDataGridView() {
            DataTable dataTable = new DataTable();

            PopulateDataTableColumns(dataTable, typeof(Professor));

            foreach (Professor professor in _CodingSchool.Professors) {

                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = professor.Id;
                dataRow["Surname"] = professor.Surname;
                dataRow["Name"] = professor.Name;
                dataRow["Age"] = professor.Age;
                dataRow["Rank"] = professor.Rank;

                dataTable.Rows.Add(dataRow);
            }




            ctrlProfessors.DataSource = dataTable;


            //-----------------------------------------------------

            DataGridViewButtonColumn ctrlViewProfessorCourses = new DataGridViewButtonColumn();
            ctrlViewProfessorCourses.Name = "ViewCourses";
            ctrlViewProfessorCourses.HeaderText = "View Courses";
            //int columnIndex = 2;
            if (ctrlProfessors.Columns["ViewCourses"] == null) {
                ctrlProfessors.Columns.Insert(ctrlProfessors.Columns.Count, ctrlViewProfessorCourses);
            }

            ctrlProfessors.CellClick += ctrlProfessors_CellClick;

            //----------------------------------------------------



            ctrlProfessors.Columns[0].Visible = false;




        }


        private void ctrlProfessors_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == ctrlProfessors.Columns["ViewCourses"].Index) {

                Professor professor = _CodingSchool.Professors.Find(x => x.Id == Guid.Parse(Convert.ToString(ctrlProfessors.SelectedRows[0].Cells["Id"].Value)));

                string professorCourses = string.Empty;

                foreach (Course course in professor.Courses) {

                    professorCourses += string.Format("Code: {0} - Subject: {1} - Hours: {2}\n", course.Code, course.Subject, course.Hours);

                }

                MessageBox.Show(professorCourses);
            }
        }

        private static void PopulateDataTableColumns(DataTable dataTable, Type type) {
            dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));

            PropertyInfo[] properties = null;

            if (type == typeof(Professor)) {
                properties = typeof(Professor).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            }
            else if (type == typeof(Course)) {
                properties = typeof(Course).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            }
            else if (type == typeof(Student)) {
                properties = typeof(Student).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            }
            else if (type == typeof(Schedule)) {
                properties = typeof(Schedule).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            }

            foreach (PropertyInfo property in properties) {
                if (property.Name != "Id") {

                    dataTable.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                }
            }
        }

        private void PopulateCoursesDataGridView() {
            DataTable dataTable = new DataTable();

            PopulateDataTableColumns(dataTable, typeof(Course));


            foreach (Course course in _CodingSchool.Courses) {

                DataRow dataRow = dataTable.NewRow();

                dataRow["Id"] = course.Id;
                dataRow["Code"] = course.Code;
                dataRow["Subject"] = course.Subject;
                dataRow["Hours"] = course.Hours;
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
    }
}

