using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTemplate.Models;
namespace WebApiTemplate.BO
{
    public interface IStudentsBO
    {
        ApiResponse GetAllStudents();
        ApiResponse GetStudent(int id);
        ApiResponse AddAStudent(Student student);
        ApiResponse RemoveAStudent(int id);
        ApiResponse UpdateAStudent(int id, Student student);
    }

    public class StudentsBO : IStudentsBO
    {
        private readonly List<Student> students = new List<Student>();
        private readonly ILogger logger;

        public StudentsBO(ILogger<StudentsBO> logger)
        {
            this.students = new List<Student>();
            this.logger = logger;
        }

        public ApiResponse AddAStudent(Student student)
        {
            ApiResponse resp = new ApiResponse();

            if (students.Any(stu => stu.ID == student.ID))
            {
                string logMsg = $"student with id:{student.ID} already exists.";
                resp.Description = logMsg;
                this.logger.LogError(logMsg);
            }
            else
            {
                students.Add(student);
                resp.Success = true;
                resp.Data = student;
            }
            return resp;
        }

        public ApiResponse RemoveAStudent(int id)
        {
            ApiResponse resp = new ApiResponse();
            Student stu = students.Where(s => s.ID == id).FirstOrDefault();
            if (stu != null)
            {
                students.Remove(stu);
                resp = new ApiResponse() { Data = stu, Success = true, Description = $"delete done" };
            }
            else
            {
                resp.Description = "no student to delete";
                resp.Success = false;
                resp.Data = stu;
            }
            return resp;
        }

        public ApiResponse UpdateAStudent(int id, Student student)
        {
            ApiResponse resp = new ApiResponse();

            Student stu = students.Where(s => s.ID == id).FirstOrDefault();

            if (stu == null)
            {
                resp.Success = false;
                resp.Description = $"student with id:{id} doesn't exists.";
            }
            else
            {
                stu.Name = student.Name;
                stu.Age = student.Age;
                stu.Gender = stu.Gender;

                resp.Success = true;
                resp.Data = stu;
                resp.Description = "update done";
            }

            return resp;
        }

        public ApiResponse GetAllStudents()
        {
            return new ApiResponse() { Data = students, Success = true };
        }

        public ApiResponse GetStudent(int id)
        {
            Student stu = students.Where(stu => stu.ID == id).FirstOrDefault();
            if (stu == null)
                return new ApiResponse() { Description = "no data", Success = false };
            return new ApiResponse() { Data = stu, Success = true };
        }
    }
}
