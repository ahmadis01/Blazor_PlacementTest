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
        Task<int> SubmitAnswer(StudentAnswerDto answer); 
        Task<int> SkipQuestion(StudentAnswerDto answer);
        bool DeleteStudent(int id);
        bool UpdateStudent(Student student);
        ICollection<Student> SearchStudents(string searchText);
        bool SubmitReadingAnswers(ReadingAnswersDto answersDto);
        int UpdateStudentPersonalData(PersonalDataDto dto);
		bool UpdateTimer(TimerDto timerDto);
        Task<bool> SubmitLearningProfileSurveyAsync(List<StudentProfileAnswers> answers);
        Task<PersonalDataDto> GetStudentPersonalDataAsync(int studentId);
        Task<List<GetStudentAnswersDto>> GetStudentAnswersAsync(int studentId);
    }
}
