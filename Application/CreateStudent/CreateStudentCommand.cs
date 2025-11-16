using MediatR;

namespace StudentManagementCQRSApi.Application.CreateStudent
{
    public record CreateStudentCommand(string Name,int Age,string Branch):IRequest<int>;
    
}
