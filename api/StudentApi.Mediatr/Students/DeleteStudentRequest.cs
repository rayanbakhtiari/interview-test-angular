using MediatR;
using StudentApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class DeleteStudentRequest: IRequest<DeleteStudentResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteStudentResponse
    {
        public bool Status { get; set; }
    }
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentResponse>
    {
        private readonly IStudentsService studentsService;

        public DeleteStudentHandler(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }
        public Task<DeleteStudentResponse> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            var student = studentsService.GetStudentById(request.Id);
            if (student is null)
                throw new StudentDoesNotExistException($"student with id {request.Id} does not exist");
            var response = new DeleteStudentResponse
            {
                Status = studentsService.DeleteStudent(student)
            };

            return Task.FromResult(response);
        }
    }

    [Serializable]
    public class StudentDoesNotExistException : Exception
    {
        public StudentDoesNotExistException()
        {
        }

        public StudentDoesNotExistException(string message) : base(message)
        {
        }

        public StudentDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StudentDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
