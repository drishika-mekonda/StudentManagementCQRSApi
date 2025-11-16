using MediatR;
using StudentManagementCQRSApi.Models;
using System.Collections.Generic;


namespace StudentManagementCQRSApi.Application.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
}
