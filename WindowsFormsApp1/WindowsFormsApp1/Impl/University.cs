using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Impl {

    public class University : Entity {

        public List<Student> Students { get; set; }

        public List<Professor> Professors { get; set; }

        public List<Course> Courses { get; set; }

        public List<Schedule> Schedules { get; set; }



        public University() {
            Students = new List<Student>();
            Professors = new List<Professor>();
            Courses = new List<Course>();
            Schedules = new List<Schedule>();
        }


        public void RunOnce() {


            // TODO: MUST IMPLEMENT ENUMERATION FOR CATEGORY ?

            Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "1",
                Subject = "Quantum Physics",
                Category = 0, // physics
                Hours = 100
            });

            Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "2",
                Subject = "Electo-Dynamics",
                Category = CourseCategory.Physics, // physics ?
                Hours = 50
            });

            Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "03",
                Subject = "Basic Chemistry",
                Category = CourseCategory.Chemistry, // Chemistry
                Hours = 50
            });

            Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "04",
                Subject = "Financial II",
                Category = CourseCategory.Financial, // Financial
                Hours = 50
            });

            Courses.Add(new Course() {
                //Id = Guid.NewGuid(),
                Code = "5",
                Subject = "Mathematics I",
                Category = CourseCategory.Mathematics, // Mathematics
                Hours = 50
            });

            Students.Add(new Student() {
                //Id = Guid.NewGuid(),
                Name = "Fotis",
                Surname = "Chrysoulas",
                RegistrationNumber = "1234",
                CourseCategories = new List<CourseCategory>() { CourseCategory.Chemistry, CourseCategory.Financial }
            });


            Students.Add(new Student() {
                //Id = Guid.NewGuid(),
                Name = "Dimitris",
                Surname = "Raptodimos",
                RegistrationNumber = "1235",
                CourseCategories = new List<CourseCategory>() { CourseCategory.Physics, CourseCategory.Financial }
            });

            Professors.Add(new Professor() {
                Name = "Maria",
                Surname = "Papadopoulou",
                Rank = ProfessorRank.Assistant
            });

            Professors.Add(new Professor() {
                Name = "Giorgos",
                Surname = "Papadopoulos",
                Rank = ProfessorRank.Associate
            });

            Professors.Add(new Professor() {
                Name = "Nikolaos",
                Surname = "Papadopoulos",
                Rank = ProfessorRank.Full
            });
        }

    }

}

