using System;
using System.Data;

namespace WindowsFormsApp1.Impl {

    public class Schedule : Entity {

        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }

        public string Calendar { get; set; }

        public DataTable PopulateSchedulesDataGridView(University codingSchool) {

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));
            dataTable.Columns.Add(new DataColumn("Course code", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Course subject", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Course duration", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Professor", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Calendar", typeof(string)));

            foreach (Schedule schedule in codingSchool.Schedules) {

                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = schedule.Id;
                dataRow["Calendar"] = schedule.Calendar;
                dataRow["Course code"] = codingSchool.Courses.Find(x => x.Id == schedule.CourseId).Code;
                dataRow["Course subject"] = codingSchool.Courses.Find(x => x.Id == schedule.CourseId).Subject;
                dataRow["Course duration"] = codingSchool.Courses.Find(x => x.Id == schedule.CourseId).Duration;
                dataRow["Professor"] = string.Format("{0}  {1}", codingSchool.Professors.Find(x => x.Id == schedule.ProfessorId).Name, codingSchool.Professors.Find(x => x.Id == schedule.ProfessorId).Surname);

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
