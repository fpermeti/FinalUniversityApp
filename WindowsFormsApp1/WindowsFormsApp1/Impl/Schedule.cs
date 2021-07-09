using System;

namespace WindowsFormsApp1.Impl {

    public class Schedule :Entity{


        public Guid StudentId { get; set; }

        public Guid ProfessorId { get; set; }

        public Guid CourseId { get; set; }

        public DateTime Calendar { get; set; }


    }

}

