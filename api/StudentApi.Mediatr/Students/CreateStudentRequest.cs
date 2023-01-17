using MediatR;
using StudentApi.Models.Students;
using StudentApi.Services;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class CreateStudentRequest: IRequest<CreateStudentResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Major { get; set; }
        public decimal AverageGrade { get; set; }
    }


    public class CreateStudentResponse
    {
        public bool Status { get; set; }
    }
    public class CreateStudentHandler : IRequestHandler<CreateStudentRequest, CreateStudentResponse>
    {
        private readonly IStudentsService studentsService;
        private readonly IStudentMapper mapper;

        public CreateStudentHandler(IStudentsService studentsService, IStudentMapper mapper)
        {
            this.studentsService = studentsService;
            this.mapper = mapper;
        }
        public Task<CreateStudentResponse> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            Student student = mapper.Map(request);
            var response = new CreateStudentResponse()
            {
                Status = studentsService.AddStudent(student)
            };
            return Task.FromResult(response);
        }
    }

    public interface IStudentMapper
    {
        Student Map(CreateStudentRequest request);
    }
    public class StudentMapper : IStudentMapper
    {
        public Student Map(CreateStudentRequest request)
        {
            return new Student()
            {
                FirstName= request.FirstName,
                LastName= request.LastName,
                AverageGrade= request.AverageGrade,
                Email= request.Email,
                Major = request.Major,
            };
        }
    }
}
