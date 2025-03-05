using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modelss;

namespace WebApplication1.Dataa
{
    public class InstructorDal : IInstructor
    {
        private List<Instructor> _instructors = new List<Instructor>();

        public InstructorDal()
        {
            _instructors = new List<Instructor>(){
                new Instructor()
                {
                    InstructorId = 1,
                    InstructorName = "John Doe",
                    InstructorEmail = "johndoe@yahoo",
                    InstructorPhone = "123-456-7890",
                    InstructorAddress = "1234 Elm St",
                    InstructorCity = "Springfield",
                },
                new Instructor()
                {
                    InstructorId = 2,
                    InstructorName = "Jane Doe",
                    InstructorEmail = "janedoe@yahoo",
                    InstructorPhone = "123-456-7890",
                    InstructorAddress = "1234 Elm St",
                    InstructorCity = "Springfield",
                },
                new Instructor()
                {
                    InstructorId = 3,
                    InstructorName = "John Smith",
                    InstructorEmail = "johnsmith@yahoo",
                    InstructorPhone = "123-456-7890",
                    InstructorAddress = "1234 Elm St",
                    InstructorCity = "Springfield",
                },
                new Instructor()
                {
                    InstructorId = 4,
                    InstructorName = "Jane Smith",
                    InstructorEmail = "janesmith@yahoo",
                    InstructorPhone = "123-456-7890",
                    InstructorAddress = "1234 Elm St",
                    InstructorCity = "Springfield",
                },
                new Instructor()
                {
                    InstructorId = 5,
                    InstructorName = "John Johnson",
                    InstructorEmail = "johnjohnson@yahoo",
                    InstructorPhone = "123-456-7890",
                    InstructorAddress = "1234 Elm St",
                    InstructorCity = "Springfield",
                }
            };
        }

        public Instructor updateInstructor(Instructor instructor)
        {
            var existingInstructor = GetInstructorById(instructor.InstructorId);
            if(existingInstructor != null)
            {
                existingInstructor.InstructorName = instructor.InstructorName;
                existingInstructor.InstructorEmail = instructor.InstructorEmail;
                existingInstructor.InstructorPhone = instructor.InstructorPhone;
                existingInstructor.InstructorAddress = instructor.InstructorAddress;
                existingInstructor.InstructorCity = instructor.InstructorCity;
            }
            return existingInstructor;
        }

        public void DeleteInstructor(int instructorId)
        {
            var instructor = GetInstructorById(instructorId);
            if(instructor != null)
            {
                _instructors.Remove(instructor);
            }
        }

        public Instructor AddInstructor(Instructor instructor)
        {
            _instructors.Add(instructor);
            return instructor;
        }

        public Instructor GetInstructorById(int instructorId)
        {
            var instructor = _instructors.FirstOrDefault(x => x.InstructorId == instructorId);
            return instructor;
        }
        public IEnumerable<Instructor> GetInstructors()
        {
            return _instructors;
        }
    }
}