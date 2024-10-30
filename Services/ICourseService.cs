// ICourseService.cs
using BlazeUTS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazeUTS.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourseById(int id);
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(int id);
    }
}
