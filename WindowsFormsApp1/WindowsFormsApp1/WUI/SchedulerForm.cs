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

        public SchedulerForm() {
            InitializeComponent();
        }





        public void PopulateData() {

            _CodingSchool = new University();


          
            _CodingSchool.Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "01",
                Subject = "Quantum Physics",
                Category = 0, // physics
                Hours = 10
            });

            _CodingSchool.Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "02",
                Subject = "Electo-Dynamics",
                Category = CourseCategory.Physics, // physics ?
                Hours = 30
            });

            _CodingSchool.Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "03",
                Subject = "Basic Chemistry",
                Category = CourseCategory.Chemistry, // Chemistry
                Hours = 50
            });

            _CodingSchool.Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "04",
                Subject = "Financial II",
                Category = CourseCategory.Financial, // Financial
                Hours = 70
            });

            _CodingSchool.Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "05",
                Subject = "Mathematics I",
                Category = CourseCategory.Mathematics, // Mathematics
                Hours = 90
            });

            _CodingSchool.Students.Add(new Student() {
                //Id = Guid.NewGuid(),
                Name = "Fotis",
                Surname = "Chrysoulas",
                RegistrationNumber = "1234",
                CourseCategories = new List<CourseCategory>() { CourseCategory.Chemistry, CourseCategory.Financial }
            });


            _CodingSchool.Students.Add(new Student() {
                //Id = Guid.NewGuid(),
                Name = "Dimitris",
                Surname = "Raptodimos",
                RegistrationNumber = "1235",
                CourseCategories = new List<CourseCategory>() { CourseCategory.Physics, CourseCategory.Financial }
            });

            _CodingSchool.Professors.Add(new Professor() {
                Name = "Maria",
                Surname = "Papadopoulou",
                Rank = ProfessorRank.Assistant
            });

            _CodingSchool.Professors.Add(new Professor() {
                Name = "Giorgos",
                Surname = "Papadopoulos",
                Rank = ProfessorRank.Associate
            });

            _CodingSchool.Professors.Add(new Professor() {
                Name = "Nikolaos",
                Surname = "Papadopoulos",
                Rank = ProfessorRank.Full
            });



            foreach (Student student in _CodingSchool.Students) {
                ctrlStudents.Items.Add(student.Name + " " + student.Surname);
            }

            foreach (Course course in _CodingSchool.Courses) {
                ctrlCourses.Items.Add(course.Code + "--" + course.Subject);
            }


            foreach (Professor professor in _CodingSchool.Professors) {

                ctrlProfessors.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }




        }






     

      

        private void LoadfromJson() {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            _CodingSchool = serializer.Deserialize<University>(File.ReadAllText("Data.json"));

            foreach (Student student in _CodingSchool.Students) {
                ctrlStudents.Items.Add(student.Name + " " + student.Surname);
            }

            for (int i = 0; i < _CodingSchool.Courses.Count - 1; i++) {

                ctrlCourses.Items.Add(_CodingSchool.Courses[i].Code + "--" + _CodingSchool.Courses[i].Subject);
            }


            foreach (Professor professor in _CodingSchool.Professors) {
                ctrlProfessors.Items.Add(string.Format("{0}  {1}", professor.Name, professor.Surname));
            }
        }

       

        private void SaveToJson() {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            File.WriteAllText("Data.json", serializer.Serialize(_CodingSchool));
        }

        private void DataForm1_Load(object sender, EventArgs e) {

            PopulateData();
        }


     

        private void AddSchedule() {
            try {

                // TODO: 1. CANNOT ADD SAME STUDENT + PROFESSOR IN SAME DATE & HOUR

                // TODO: 2. EACH STUDENT CANNOT HAVE MORE THAN 3 COURSES PER DAY!

                // TODO: 3. A PROFESSOR CANNOT TEACH MORE THAN 4 COURSES PER DAY AND 40 COURSES PER WEEK

                _CodingSchool.Schedules.Add(new Schedule() {
                    Course = new Course() { Code = ctrlCourses.SelectedItem.ToString() },
                    Student = new Student() { Surname = ctrlStudents.SelectedItem.ToString() },
                    Professor = new Professor() { Surname = ctrlProfessors.SelectedItem.ToString() },
                    Calendar = ctrlCalendar.Value
                });

                ctrlSchedules.Items.Clear();
                foreach (Schedule schedule in _CodingSchool.Schedules) {

                    ctrlSchedules.Items.Add(schedule.Calendar + " | " + schedule.Course + " | " + schedule.Student + " | " + schedule.Professor);

                }

                MessageBox.Show("all ok!");


            }
            catch {

            }
            
        }



        private void ctrlExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }



        private void ctrlSaveData_Click(object sender, EventArgs e) {
            SaveToJson();

        }

        private void ctrlLoadData_Click(object sender, EventArgs e) {
            LoadfromJson();

        }

        private void ctrlAddSchedule_Click(object sender, EventArgs e) {
            AddSchedule();

        }

        private void ctrlRemoveSchedule_Click(object sender, EventArgs e) {

        }

        private void SchedulerForm_Load(object sender, EventArgs e) {
            PopulateData();
        }
    }
}

