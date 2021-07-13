using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Impl {
    public class DataPopulation {

        public void CreateDummyData(University codingSchool) {

            codingSchool.Courses.Add(new Course() {
                Code = "01",
                Subject = "Quantum Physics",
                Category = CourseCategory.Physics,
                Duration = 50
            });

            codingSchool.Courses.Add(new Course() {
                Code = "02",
                Subject = "Electo-Dynamics",
                Category = CourseCategory.Physics,
                Duration = 60
            });

            codingSchool.Courses.Add(new Course() {
                Code = "03",
                Subject = "Basic Chemistry",
                Category = CourseCategory.Chemistry,
                Duration = 70
            });

            codingSchool.Courses.Add(new Course() {
                Code = "04",
                Subject = "Financial II",
                Category = CourseCategory.Financial,
                Duration = 80
            });

            codingSchool.Courses.Add(new Course() {
                Code = "05",
                Subject = "Mathematics I",
                Category = CourseCategory.Mathematics,
                Duration = 90
            });

            codingSchool.Students.Add(new Student() {
                Name = "Std1Name",
                Surname = "Std1Surname",
                Age = 23,
                RegistrationNumber = "1234",
                Courses = new List<Course>() { codingSchool.Courses.FirstOrDefault(x => x.Code == "02"), codingSchool.Courses.FirstOrDefault(x => x.Code == "03") }
            });

            codingSchool.Students.Add(new Student() {
                Name = "Std2Name",
                Surname = "Std2Surname",
                Age = 26,
                RegistrationNumber = "1235",
                Courses = new List<Course>() { codingSchool.Courses.FirstOrDefault(x => x.Code == "02"), codingSchool.Courses.FirstOrDefault(x => x.Code == "04") }
            });

            codingSchool.Students.Add(new Student() {
                Name = "Std3Name",
                Surname = "Std3Surname",
                Age = 26,
                RegistrationNumber = "1236",
                Courses = new List<Course>() { codingSchool.Courses.FirstOrDefault(x => x.Code == "04"), codingSchool.Courses.FirstOrDefault(x => x.Code == "05") }
            });

            codingSchool.Professors.Add(new Professor() {
                Name = "Prof1Name",
                Surname = "Prof1Surname",
                Age = 61,
                Rank = ProfessorRank.Assistant,
                Courses = new List<Course>() { codingSchool.Courses.FirstOrDefault(x => x.Code == "03"), codingSchool.Courses.FirstOrDefault(x => x.Code == "04") }
            });

            codingSchool.Professors.Add(new Professor() {
                Name = "Prof2Name",
                Surname = "Prof2Surname",
                Age = 48,
                Rank = ProfessorRank.Associate,
                Courses = new List<Course>() { codingSchool.Courses.FirstOrDefault(x => x.Code == "01"), codingSchool.Courses.FirstOrDefault(x => x.Code == "02") }
            });

            codingSchool.Professors.Add(new Professor() {
                Name = "Prof3Name",
                Surname = "Prof3Surname",
                Age = 38,
                Rank = ProfessorRank.Full,
                Courses = new List<Course>() { codingSchool.Courses.FirstOrDefault(x => x.Code == "05"), codingSchool.Courses.FirstOrDefault(x => x.Code == "03") }
            });
        }
    }
}
