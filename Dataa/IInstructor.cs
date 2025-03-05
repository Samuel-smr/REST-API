using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modelss;

namespace WebApplication1.Dataa
{
    public interface IInstructor
    {
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorById(int instructorId);

        Instructor AddInstructor(Instructor instructor);
        Instructor updateInstructor(Instructor instructor);
        
        void DeleteInstructor(int instructorId);
    }
}