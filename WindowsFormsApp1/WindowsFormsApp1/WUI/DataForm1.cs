using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WindowsFormsApp1.Impl;

namespace WindowsFormsApp1.WUI {

    public partial class DataForm1 : Form {

        private University _CodingSchool = new University();

        public DataForm1() {
            InitializeComponent();
        }

        #region old code
        private void DataForm_Load(object sender, EventArgs e) {

            // todo : load data on enter!
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e) {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            _CodingSchool = serializer.Deserialize<University>(File.ReadAllText("Data.json"));

            foreach (Student student in _CodingSchool.Students) {
                list1.Items.Add(student.Name + " " + student.Surname);
            }

            for (int i = 0; i < _CodingSchool.Courses.Count - 1; i++) {

                listBox1.Items.Add(_CodingSchool.Courses[i].Code + "--" + _CodingSchool.Courses[i].Subject);
            }


            foreach (Professor professor in _CodingSchool.Professors) {
                list3.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            File.WriteAllText("Data.json", serializer.Serialize(_CodingSchool));
        }
        #endregion

        #region new code
        private void DataForm1_Load(object sender, EventArgs e) {

            // todo : load data on enter!
        }

        private void initializeDedomenaToolStripMenuItem_Click(object sender, EventArgs e) {

            _CodingSchool.RunOnce();

            foreach (Student student in _CodingSchool.Students) {
                list1.Items.Add(student.Name + " " + student.Surname);
            }

            foreach (Course course in _CodingSchool.Courses) {
                listBox1.Items.Add(course.Code + "--" + course.Subject);
            }


            foreach (Professor professor in _CodingSchool.Professors) {

                list3.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }

            //should run only once!
            button11.Hide();
        }

        private void button9_Click(object sender, EventArgs e) {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            _CodingSchool = serializer.Deserialize<University>(File.ReadAllText("Data.json"));

            foreach (Student student in _CodingSchool.Students) {
                list1.Items.Add(student.Name + " " + student.Surname);
            }

            for (int i = 0; i < _CodingSchool.Courses.Count - 1; i++) {

                listBox1.Items.Add(_CodingSchool.Courses[i].Code + "--" + _CodingSchool.Courses[i].Subject);
            }

            // we do a loop
            foreach (Professor professor in _CodingSchool.Professors) {
                // we add to the list
                list3.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }

        }

        private void button10_Click(object sender, EventArgs e) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            File.WriteAllText("Data.json", serializer.Serialize(_CodingSchool));
        }

        private void ctrlExit_Click(object sender, EventArgs e) {

            try {

                // TODO: 1. CANNOT ADD SAME STUDENT + PROFESSOR IN SAME DATE & HOUR

                // TODO: 2. EACH STUDENT CANNOT HAVE MORE THAN 3 COURSES PER DAY!

                // TODO: 3. A PROFESSOR CANNOT TEACH MORE THAN 4 COURSES PER DAY AND 40 COURSES PER WEEK

                _CodingSchool.Schedules.Add(new Schedule() {
                    Course = new Course() { Code = listBox1.SelectedItem.ToString() },
                    Student = new Student() { Surname = list1.SelectedItem.ToString() },
                    Professor = new Professor() { Surname = list3.SelectedItem.ToString() },
                    Calendar = dateTimePicker2.Value
                });

                ctrlSchedule.Items.Clear();
                foreach (Schedule schedule in _CodingSchool.Schedules) {

                    ctrlSchedule.Items.Add(schedule.Calendar + " | " + schedule.Course + " | " + schedule.Student + " | " + schedule.Professor);

                }
            }
            catch {

            }
            finally {
                MessageBox.Show("all ok!");

            }
        }

        public void validate_professorCourse_with_studentCourse() {

            //TODO: ???

        }

        #endregion

        private void button11_Click(object sender, EventArgs e) {



            _CodingSchool.RunOnce();

            foreach (Student student in _CodingSchool.Students) {
                list1.Items.Add(student.Name + " " + student.Surname);
            }

            foreach (Course course in _CodingSchool.Courses) {
                listBox1.Items.Add(course.Code + "--" + course.Subject);
            }


            foreach (Professor professor in _CodingSchool.Professors) {

                list3.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }

            //should run only once!
            button11.Hide();
        }

        private void addToScheduleToolStripMenuItem_Click(object sender, EventArgs e) {

            // todo : display on a grid??

            // todo: add exception handling?
            _CodingSchool.Schedules.Add(new Schedule() {
                Course = new Course() { Code = listBox1.SelectedItem.ToString() },
                Student = new Student() { Surname = list1.SelectedItem.ToString() },
                Professor = new Professor() { Surname = list3.SelectedItem.ToString() },
                Calendar = dateTimePicker2.Value
            });

            ctrlSchedule.Items.Clear();
            foreach (Schedule schedule in _CodingSchool.Schedules) {

                ctrlSchedule.Items.Add(schedule.Calendar + " " + schedule.Course + " " + schedule.Student + " " + schedule.Professor);

            }

        }

    }
}

