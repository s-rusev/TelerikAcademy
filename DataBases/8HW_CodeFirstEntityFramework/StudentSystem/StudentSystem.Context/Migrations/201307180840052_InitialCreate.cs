namespace StudentSystem.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                {
                    StudentId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Number = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.StudentId);

            CreateTable(
                "dbo.Course",
                c => new
                {
                    CourseId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Materials = c.String(),
                })
                .PrimaryKey(t => t.CourseId);

            CreateTable(
                "dbo.Homeworks",
                c => new
                {
                    HomeworkId = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    TimeSent = c.DateTime(nullable: false),
                    CourseId = c.Int(nullable: false),
                    StudentId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.HomeworkId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.CourseStudents",
                c => new
                {
                    Course_CourseId = c.Int(nullable: false),
                    Student_StudentID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Course_CourseId, t.Student_StudentID })
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentID);

        }

        public override void Down()
        {
            DropIndex("dbo.CourseStudents", new[] { "Student_StudentID" });
            DropIndex("dbo.CourseStudents", new[] { "Course_CourseId" });
            DropIndex("dbo.Homeworks", new[] { "StudentId" });
            DropIndex("dbo.Homeworks", new[] { "CourseId" });
            DropForeignKey("dbo.CourseStudents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.Homeworks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Homeworks", "CourseId", "dbo.Course");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Homeworks");
            DropTable("dbo.Course");
            DropTable("dbo.Students");
        }
    }
}