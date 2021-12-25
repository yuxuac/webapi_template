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
        private readonly Dictionary<int, Student> students = new Dictionary<int, Student>();
        private readonly ILogger logger;

        public StudentsBO(ILogger<StudentsBO> logger)
        {
            this.students = new Dictionary<int, Student>();
            this.logger = logger;
        }

        public ApiResponse AddAStudent(Student student)
        {
            ApiResponse resp = new ApiResponse();

            if (student.ID != null && students.ContainsKey(student.ID.Value))
            {
                string logMsg = $"student with id:{student.ID} already exists.";
                resp.Description = logMsg;
                this.logger.LogError(logMsg);
            }
            else
            {
                if(student.ID == null)
                    student.ID = this.students.Keys.Any() ? this.students.Keys.Max() + 1 : 1;
                students.Add(student.ID.Value, student);
                resp.Success = true;
                resp.Data = student;
                resp.Description = "add done";
            }
            return resp;
        }

        public ApiResponse RemoveAStudent(int id)
        {
            ApiResponse resp = new ApiResponse();
            if (this.students.ContainsKey(id))
            {
                var stu = this.students[id];
                students.Remove(id);
                resp = new ApiResponse() 
                { 
                    Data = stu, 
                    Success = true, 
                    Description = $"delete done" 
                };
            }
            else
            {
                resp.Description = "no student to delete";
                resp.Success = false;
                resp.Data = null;
            }
            return resp;
        }

        public ApiResponse UpdateAStudent(int id, Student student)
        {
            ApiResponse resp = new ApiResponse();

            if (!students.ContainsKey(id))
            {
                resp.Success = false;
                resp.Description = $"student with id:{id} doesn't exists.";
            }
            else
            {
                var stu = this.students[id];
                stu.Name = student.Name;
                stu.Age = student.Age;
                stu.Gender = student.Gender;

                resp.Success = true;
                resp.Data = stu;
                resp.Description = "update done";
            }

            return resp;
        }

        public ApiResponse GetAllStudents()
        {
            return new ApiResponse() { Data = students, Success = true, Description = "get all done" };
        }

        public ApiResponse GetStudent(int id)
        {
            if (!this.students.ContainsKey(id))
                return new ApiResponse() { Description = "no data", Success = false };
            return new ApiResponse() { Data = this.students[id], Success = true, Description = "get done" };
        }
    }
}
