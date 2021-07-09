using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WindowsFormsApp1.Impl;

namespace WindowsFormsApp1.WUI {

    public partial class SchedulerForm : Form {

        private University _CodingSchool;

        private List<Schedule> Schedules;


        private const string _JsonFile = "UniversityData.json";



        public SchedulerForm() {
            InitializeComponent();
        }




        private void PopulateListBoxes() {

            //_CodingSchool = new University();

            if (_CodingSchool.Professors.Count == 0 || _CodingSchool.Students.Count == 0 || _CodingSchool.Courses.Count == 0) {

                DataPopulation.CreateDummyData(_CodingSchool);

            }



            foreach (Course course in _CodingSchool.Courses) {
                ctrlCourses.Items.Add(string.Format("{0}--{1}", course.Code, course.Subject));
            }



            foreach (Professor professor in _CodingSchool.Professors) {

                ctrlProfessors.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }


            foreach (Student student in _CodingSchool.Students) {
                ctrlStudents.Items.Add(string.Format("{0}  {1}", student.Name, student.Surname));
            }


            foreach (Schedule schedule in _CodingSchool.Schedules) {
                ctrlSchedules.Items.Add(string.Format("{0}--{1}--{2}--{3}",
                    schedule.Calendar, schedule.Course.Category.ToString(), schedule.Professor.Surname, schedule.Student.Surname));
            }

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


        private void LoadfromJson() {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            _CodingSchool = serializer.Deserialize<University>(File.ReadAllText(_JsonFile));



            //foreach (Course course in _CodingSchool.Courses) {
            //    ctrlCourses.Items.Add(string.Format("{0} -- {1}", course.Code, course.Subject));
            //}

            //foreach (Professor professor in _CodingSchool.Professors) {

            //    ctrlProfessors.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            //}

            //foreach (Student student in _CodingSchool.Students) {
            //    ctrlStudents.Items.Add(string.Format("{0}  {1}", student.Name, student.Surname));
            //}
        }



        private void SaveToJson() {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            File.WriteAllText(_JsonFile, serializer.Serialize(_CodingSchool));

            //MessageBox.Show("OK");

        }






        private void AddSchedule() {

            // TODO: 1. CANNOT ADD SAME STUDENT + PROFESSOR IN SAME DATE & HOUR

            // TODO: 2. EACH STUDENT CANNOT HAVE MORE THAN 3 COURSES PER DAY!

            // TODO: 3. A PROFESSOR CANNOT TEACH MORE THAN 4 COURSES PER DAY AND 40 COURSES PER WEEK
            if (ctrlProfessors.SelectedItems.Count != 0 && ctrlStudents.SelectedItems.Count != 0 && ctrlCourses.SelectedItems.Count != 0) {


                _CodingSchool.Schedules.Add(new Schedule() {
                    Course = _CodingSchool.Courses.Find(x => x.Code == ctrlCourses.SelectedItem.ToString().Substring(0, Math.Max(ctrlCourses.SelectedItem.ToString().IndexOf('-'), 0))),
                    Student = _CodingSchool.Students.Find(x => x.Name == ctrlStudents.SelectedItem.ToString().Substring(0, Math.Max(ctrlStudents.SelectedItem.ToString().IndexOf(' '), 0))),
                    Professor = _CodingSchool.Professors.Find(x => x.Name == ctrlProfessors.SelectedItem.ToString().Substring(0, Math.Max(ctrlProfessors.SelectedItem.ToString().IndexOf(' '), 0))),
                    Calendar = ctrlCalendar.Value
                });

                ctrlSchedules.Items.Clear();
                foreach (Schedule schedule in _CodingSchool.Schedules) {

                    ctrlSchedules.Items.Add(schedule.Calendar + " | " + schedule.Course.Code + " | " + schedule.Student.Surname + " | " + schedule.Professor.Surname);

                }

                SerializeToJson(_CodingSchool);

                MessageBox.Show("OK");


            }
            else {

                MessageBox.Show("Please select an item in each list");
            }




        }



        private void ctrlExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }



        private void ctrlSaveData_Click(object sender, EventArgs e) {
            //SaveToJson();
            SerializeToJson(_CodingSchool);
        }

        private void ctrlLoadData_Click(object sender, EventArgs e) {
            //LoadfromJson();

        }

        private void ctrlAddSchedule_Click(object sender, EventArgs e) {
            AddSchedule();

        }

        private void ctrlRemoveSchedule_Click(object sender, EventArgs e) {

        }

        private void SchedulerForm_Load(object sender, EventArgs e) {
            DeserializeFromJson();


            PopulateListBoxes();
        }
    }
}

