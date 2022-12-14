using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;
using PlacementTestMangement.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace PlacementTestMangement.Server.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Student> GetStudents()
        {
            return _context.Students.OrderBy(x => x.Id).ToList();
        }
        public Student GetStudent(int id)
        {
            return _context.Students.Where(x => x.Id == id).FirstOrDefault();
        }

        public Student GetStudent(string name)
        {
            return _context.Students.Where(x => x.Name == name).FirstOrDefault();
        }
        public Student AddStudent(Student student)
        {
            _context.Add(student);

            _context.SaveChanges();
            var respond = GetStudent(student.Id);
            return respond;

        }
        public bool DeleteStudent(int id)
        {
            _context.Remove(id);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateStudent(Student student)
        {
            _context.Update(student);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Student> SearchStudents(string searchText)
        {
            return _context.Students.Where(x => x.PhoneNumber.Contains(searchText) || x.Name.Contains(searchText)).ToList();
        }
        public bool SubmitAnswer(StudentAnswerDto answer)
        {
            Student student = _context.Students.Where(x => x.Id == answer.StudentId).FirstOrDefault();
            Question question = _context.Questions.Where(x => x.Id == answer.QuestionId).FirstOrDefault();
            Answer? correctAnswer = _context.Answers.Where(x => x.QuestionId == answer.QuestionId && x.IsCorrect == true).FirstOrDefault();
            if (correctAnswer != null)
            {
                student.GrammerMark++;
                student.CurrentQuestion = answer.QuestionId + 1;
                _context.Update(student);
                _context.SaveChanges();
                return true;
            }
            else
            {
                student.CurrentQuestion = answer.QuestionId + 1;
                student.Timer = answer.Timer;
                _context.Update(student);
                _context.SaveChanges();
                return false;
            }
        }
        public bool SkipQuestion(StudentAnswerDto answer)
        {
            Student student = _context.Students.Where(x => x.Id ==answer.StudentId).FirstOrDefault();
            student.CurrentQuestion = answer.QuestionId + 1;
            student.Timer = answer.Timer;
            _context.Update(student);
            _context.SaveChanges();
            return true;
        }
    }
}
