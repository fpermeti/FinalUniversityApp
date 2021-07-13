using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WindowsFormsApp1.Impl;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.WUI {

    public partial class SchedulerForm : Form {

        private University _CodingSchool;

        private DataGridViewButtonColumn _CtrlViewProfessorCourses;

        private JsonHander _JsonHandler;

        private Schedule _Schedule;

        private Course _Course;

        private Professor _Professor;

        public SchedulerForm() {

            InitializeComponent();

            _Schedule = new Schedule();

            _Course = new Course();

            _Professor = new Professor();
        }

        #region Form Events

        private void ctrlExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ctrlAddSchedule_Click(object sender, EventArgs e) {
            AddSchedule();
        }

        private void ctrlRemoveSchedule_Click(object sender, EventArgs e) {
            RemoveSchedule();
        }

        private void SchedulerForm_Load(object sender, EventArgs e) {
            Configurations();
        }

        private void ctrlProfessors_CellClick(object sender, DataGridViewCellEventArgs e) {
            ViewProfessorCourses(e);
        }

        private void ctrlCourses_SelectionChanged(object sender, EventArgs e) {
            ViewProfessorsThatIncludeSelectedCourse();
        }

        #endregion

        private void AddSchedule() {

            DialogResult result = MessageBox.Show("Are you sure you want to create this entry ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK) {

                if (ctrlCalendar.Value.Hour < 8 || 19 < ctrlCalendar.Value.Hour || (ctrlCalendar.Value.Hour == DateTime.Now.Hour && ctrlCalendar.Value.Day == DateTime.Now.Day) || ctrlCalendar.Value.DayOfWeek == DayOfWeek.Saturday || ctrlCalendar.Value.DayOfWeek == DayOfWeek.Sunday) {

                    MessageBox.Show(Resources.Warning2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ctrlCourses.SelectedRows.Count > 0 && ctrlProfessors.SelectedRows.Count > 0) {

                    Guid selectedCourseId = Guid.Parse(Convert.ToString(ctrlCourses.SelectedRows[0].Cells["Id"].Value));

                    Guid selectedProfessorId = Guid.Parse(Convert.ToString(ctrlProfessors.SelectedRows[0].Cells["Id"].Value));

                    DateTime calendar = ctrlCalendar.Value;

                    List<Schedule> howManySchedulesIncludeSelectedProfessorInASpecificDay = _CodingSchool.Schedules.FindAll(x => x.ProfessorId == selectedProfessorId && Convert.ToDateTime(x.Calendar).Day == calendar.Day);

                    List<Student> studentsThatIncludeTheSelectedCourseInTheirCourses = new List<Student>();

                    foreach (Student student in _CodingSchool.Students) {

                        foreach (Course course in student.Courses) {

                            if (course.Id == selectedCourseId) {
                                studentsThatIncludeTheSelectedCourseInTheirCourses.Add(student);
                                break;
                            }
                        }
                    }

                    if (studentsThatIncludeTheSelectedCourseInTheirCourses.Count == 0) {
                        MessageBox.Show(Resources.Warning3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<Schedule> coursesThatAreScheduledToTheSameProfessorInTheSameTime = _CodingSchool.Schedules.FindAll(x => x.ProfessorId == selectedProfessorId && Convert.ToDateTime(x.Calendar).Day == calendar.Day && Convert.ToDateTime(x.Calendar).Hour == calendar.Hour);

                    if (coursesThatAreScheduledToTheSameProfessorInTheSameTime.Count == 0 && howManySchedulesIncludeSelectedProfessorInASpecificDay.Count <= 3 && studentsThatIncludeTheSelectedCourseInTheirCourses.Count > 0) {

                        _CodingSchool.Schedules.Add(new Schedule() {

                            CourseId = selectedCourseId,

                            ProfessorId = selectedProfessorId,

                            Calendar = Convert.ToString(new DateTime(calendar.Year, calendar.Month, calendar.Day, calendar.Hour, 0, 0))
                        });

                        ctrlSchedules.Columns.Clear();
                        ctrlSchedules.DataSource = _Schedule.PopulateSchedulesDataGridView(_CodingSchool);
                        ctrlSchedules.Columns[0].Visible = false;

                        _JsonHandler.SerializeToJson(_CodingSchool);

                        MessageBox.Show("The course was successfully scheduled.");
                    }
                    else {
                        MessageBox.Show(Resources.Warning1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else {

                    MessageBox.Show("Please select an item in each list.");
                }
            }
        }

        private void RemoveSchedule() {

            if (ctrlSchedules.SelectedRows.Count > 0) {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK) {

                    _CodingSchool.Schedules.RemoveAll(x => x.Id == Guid.Parse(Convert.ToString(ctrlSchedules.SelectedRows[0].Cells["Id"].Value)));

                    foreach (DataGridViewRow dataGridViewRow in ctrlSchedules.SelectedRows) {
                        ctrlSchedules.Rows.RemoveAt(dataGridViewRow.Index);
                    }

                    _JsonHandler.SerializeToJson(_CodingSchool);
                }
            }
            else {

                MessageBox.Show("You have to select a specific row.");
            }
        }

        private void Configurations() {

            _JsonHandler = new JsonHander();

            _CodingSchool = _JsonHandler.DeserializeFromJson();

            ctrlCalendar.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, DateTime.Now.Minute, DateTime.Now.Second);

            ctrlSchedules.Columns.Clear();
            ctrlSchedules.DataSource = _Schedule.PopulateSchedulesDataGridView(_CodingSchool);
            ctrlSchedules.Columns[0].Visible = false;

            ctrlCourses.Columns.Clear();
            ctrlCourses.DataSource = _Course.PopulateCoursesDataGridView(_CodingSchool);
            ctrlCourses.Columns[0].Visible = false;
        }

        private void ViewProfessorCourses(DataGridViewCellEventArgs e) {

            if (e.ColumnIndex == ctrlProfessors.Columns["ViewCourses"].Index) {

                Professor professor = _CodingSchool.Professors.Find(x => x.Id == Guid.Parse(Convert.ToString(ctrlProfessors.SelectedRows[0].Cells["Id"].Value)));

                string professorCourses = string.Empty;

                foreach (Course course in professor.Courses) {

                    professorCourses += string.Format("Code: {0} - Subject: {1} - Hours: {2}\n", course.Code, course.Subject, course.Duration);
                }

                MessageBox.Show(string.Format("Courses that {0} {1} is able to teach:\n\n{2}", professor.Name, professor.Surname, professorCourses), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewProfessorsThatIncludeSelectedCourse() {

            Guid selectedCourseId = Guid.Parse(Convert.ToString(ctrlCourses.SelectedRows[0].Cells["Id"].Value));

            if (ctrlProfessors.Columns.Contains("ViewCourses")) {
                ctrlProfessors.Columns.Remove(_CtrlViewProfessorCourses);
            }

            ctrlProfessors.Columns.Clear();
            ctrlProfessors.DataSource = _Professor.PopulateProfessorsDataGridView(selectedCourseId, _CodingSchool);

            if (!ctrlProfessors.Columns.Contains("ViewCourses")) {

                _CtrlViewProfessorCourses = new DataGridViewButtonColumn();
                _CtrlViewProfessorCourses.Name = "ViewCourses";
                _CtrlViewProfessorCourses.HeaderText = "View Courses";
                _CtrlViewProfessorCourses.UseColumnTextForButtonValue = true;
                ctrlProfessors.Columns.Add(_CtrlViewProfessorCourses);
            }

            ctrlProfessors.Columns[0].Visible = false;
        }
    }
}
