using System;
using TicketPlatform.Core.Entities;
using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.DTO;

namespace TicketPlatform.Core.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignments>> GetAssignments();

        Task<Assignments> GetAssignment(int Id);

        Task<bool> UpdateAssigment(AssignmentsPutDto assignmentDto);
        
        Task<bool> DeleteAssigment(int Id);

        Task<bool> CreateAssigment(AssignmentsPostDto assignmentDto);
    }
}
