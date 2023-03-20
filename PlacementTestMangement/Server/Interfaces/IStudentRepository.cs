using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudent(int id);
        Student GetStudent(string name);
        Student AddStudent(Student student);
        bool SubmitAnswer(StudentAnswerDto answer); 
        bool SkipQuestion(StudentAnswerDto answer);
        bool DeleteStudent(int id);
        bool UpdateStudent(Student student);
        ICollection<Student> SearchStudents(string searchText);
        bool SubmitReadingAnswers(ReadingAnswersDto answersDto);
    }
}
