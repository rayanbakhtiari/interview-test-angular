﻿using StudentApi.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Services
{
    public class StudentsService : IStudentsService
    {
        public static List<Student> students = new List<Student>();

        public StudentsService()
        {
            students.Add(new Student
            {
                Id= 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                AverageGrade = 85M 
            });

            students.Add(new Student {
                Id= 2,
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                AverageGrade = 70M 
            });

            students.Add(new Student
            {
                Id  = 3,
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                AverageGrade = 45M
            });
        }

        /// <summary>
        /// Adds a new student to the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddStudent(Student student)
        {
            student.Id = students.Max(x => x.Id) + 1;
            students.Add(student);
            return true;
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteStudent(Student student)
        {
            return students.Remove(student);
        }

        /// <summary>
        /// Returns all of the students currently in the system
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }
    }
}
