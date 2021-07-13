using System;
using System.Collections.Generic;
using System.Data;

namespace WindowsFormsApp1.Impl {

    public class Professor : Person {

        public ProfessorRank Rank { get; set; }

        public DataTable PopulateProfessorsDataGridView(Guid selectedCourseId, University codingSchool) {

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Id", typeof(Guid)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Surname", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Rank", typeof(ProfessorRank)));
            dataTable.Columns.Add(new DataColumn("Age", typeof(int)));

            List<Professor> profs = new List<Professor>();

            foreach (Professor professor in codingSchool.Professors) {

                foreach (Course course in professor.Courses) {

                    if (course.Id == selectedCourseId) {
                        profs.Add(professor);
                        break;
                    }
                }
            }

            foreach (Professor professor in profs) {

                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = professor.Id;
                dataRow["Name"] = professor.Name;
                dataRow["Surname"] = professor.Surname;
                dataRow["Rank"] = professor.Rank;
                dataRow["Age"] = professor.Age;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
