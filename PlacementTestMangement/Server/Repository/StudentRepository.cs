using PlacementTestMangement.Server.Data;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;
using PlacementTestMangement.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlacementTestMangement.Client.Pages.Admin;
using PlacementTestMangement.Shared.Enums;
using Microsoft.EntityFrameworkCore;

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
        public int UpdateStudentPersonalData(PersonalDataDto dto)
        {
            Student student = new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                BirthDate = dto.BirthDate,
                PhoneNumber = dto.PhoneNumber,
                Age = dto.Age,
                SchoolOrWork = dto.SchoolOrWork,
            };
            _context.Update(student);
            _context.SaveChanges();
            return student.Id;
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
        public async Task<int> SubmitAnswer(StudentAnswerDto answer)
        {
            StudentAnswers studentAnswer = new StudentAnswers
            {
                AnswerId = answer.AnswerId,
                QuestionId = answer.QuestionId,
                StudentId = answer.StudentId,
            };
            _context.Add(studentAnswer);
            Student student = _context.Students.Where(x => x.Id == answer.StudentId).FirstOrDefault();
            Answer? correctAnswer = _context.Answers.Where(x => x.Id == answer.AnswerId).FirstOrDefault();
            Question question = _context.Questions.Where(x => x.Id == answer.QuestionId).FirstOrDefault();
            if (correctAnswer.IsCorrect)
            {
                student.PlacementTestMark++;
                student.CurrentQuestion = student.CurrentQuestion + 1;
                _context.Update(student);
               await  _context.SaveChangesAsync();
                return student.CurrentQuestion;
            }
            else
            {
                student.CurrentQuestion = student.CurrentQuestion + 1;
                _context.Update(student);
				await _context.SaveChangesAsync();
				return student.CurrentQuestion;
			}
		}
        public async Task<int> SkipQuestion(StudentAnswerDto answer)
        {
            Student student = _context.Students.Where(x => x.Id ==answer.StudentId).FirstOrDefault();
            student.CurrentQuestion ++;
            student.Timer = answer.Timer;
            _context.Update(student);
            await _context.SaveChangesAsync();
            return student.CurrentQuestion;
        }
        public bool SubmitReadingAnswers(ReadingAnswersDto answersDto)
        {
            Student student = _context.Students.Where(x => x.Id == answersDto.StudentId).FirstOrDefault();
            foreach (var answer in answersDto.Answers)
            {
                if (answer.AnswerId != 0)
                {
                    Answer? correctAnswer = _context.Answers.Where(x => x.Id == answer.AnswerId).FirstOrDefault();
                    Question question = _context.Questions.Where(x => x.Id == answer.QuestionId).FirstOrDefault();
                    if (correctAnswer.IsCorrect)
                    {
                        student.PlacementTestMark++;
                    }
                }    
            }
            student.CurrentQuestion = student.CurrentQuestion+30;
            student.Timer = answersDto.Timer;
            _context.Update(student);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateTimer(TimerDto timerDto)
        {
            Student student = _context.Students.FirstOrDefault(s => s.Id == timerDto.StudentId);
            student.Timer = timerDto.Timer;
            _context.Update(student);
            _context.SaveChanges();
            return true;
        }
        public async Task<bool> SubmitLearningProfileSurveyAsync(List<StudentProfileAnswers> answers)
        {
            var entities = new List<StudentAnswers>();
            foreach (var answer in answers)
            {
                entities.Add(new StudentAnswers
                {
                    AnswerId = answer.AnswerId != 0 ? answer.AnswerId : null,
                    AnswerText = answer.AnswerText,
                    QuestionId = answer.QuestionId,
                    StudentId = answer.StudentId,
                });
			}
            _context.StudentAnswers.AddRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<PersonalDataDto> GetStudentPersonalDataAsync(int studentId)
        {
            var student = await _context.Students.Where(x => x.Id == studentId).Select(s => new PersonalDataDto
            {
                Id = s.Id,
                Address = s.Address,
                Age = s.Age,
                BirthDate = s.BirthDate,
                Name = s.Name,
                PhoneNumber = s.PhoneNumber,
                SchoolOrWork = s.SchoolOrWork
            }).FirstOrDefaultAsync();
            return student;
        }
        public async Task<List<GetStudentAnswersDto>> GetStudentAnswersAsync(int studentId)
        {
            var answers = await _context.StudentAnswers.Where(s => s.StudentId == studentId).Select(s => new GetStudentAnswersDto
            {
                Question = s.Question.QuestionText,
                Answer = string.IsNullOrEmpty(s.AnswerText) ? s.Answer.AnswerText : s.AnswerText
            }).ToListAsync();
            return answers;
        }
    }
}
