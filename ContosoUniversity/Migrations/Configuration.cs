namespace ContosoUniversity.Migrations
{
    using ContosoUniversity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            //构建学生数据
            var students = new List<Student>
            {
            new Student{Name="Carson",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{Name="Meredith",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="Arturo",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Name="Gytis",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="Yan",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="Peggy",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{Name="Laura",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Name="Nino",EnrollmentDate=DateTime.Parse("2005-09-01")}  
        };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
               
            new Enrollment{
                StudentID =students.Single(s=>s.Name=="Carson").ID,
                CourseID =courses.Single(s=>s.Title=="Chemistry").CourseID,
                Grade =Grade.A},

            new Enrollment{
               StudentID =students.Single(s=>s.Name=="Carson").ID,
                CourseID =courses.Single(s=>s.Title=="Microeconomics").CourseID,
               Grade =Grade.C},

            new Enrollment{
                  StudentID =students.Single(s=>s.Name=="Carson").ID,
                CourseID =courses.Single(s=>s.Title=="Microeconomics").CourseID,
                Grade =Grade.B},

             new Enrollment{
                StudentID =students.Single(s=>s.Name=="Arturo").ID,
                CourseID =courses.Single(s=>s.Title=="Calculus").CourseID,
                Grade =Grade.B},

            new Enrollment{
               StudentID =students.Single(s=>s.Name=="Arturo").ID,
                CourseID =courses.Single(s=>s.Title=="Trigonometry").CourseID,
               Grade =Grade.B},

            new Enrollment{
                  StudentID =students.Single(s=>s.Name=="Arturo").ID,
                CourseID =courses.Single(s=>s.Title=="Composition").CourseID,
                Grade =Grade.B},
            new Enrollment {
                    StudentID = students.Single(s => s.Name == "Yan").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.Name == "Yan").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                 },
                new Enrollment {
                    StudentID = students.Single(s => s.Name == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.Name == "Gytis").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.Name == "Laura").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                 }
            };


            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == e.StudentID &&
                         s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}