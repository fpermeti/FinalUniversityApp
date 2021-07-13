using System;
using System.Data;

namespace WindowsFormsApp1.Impl {
    public class Course : Entity {

        public string Code { get; set; }

        public string Subject { get; set; }

        public int Duration { get; set; }

        public CourseCategory Category { get; set; }

        public DataTable PopulateCoursesDataGridView(University codingSchool) {

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));
            dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Subject", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Duration", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Category", typeof(CourseCategory)));

            foreach (Course course in codingSchool.Courses) {

                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = course.Id;
                dataRow["Code"] = course.Code;
                dataRow["Subject"] = course.Subject;
                dataRow["Duration"] = course.Duration;
                dataRow["Category"] = course.Category;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
