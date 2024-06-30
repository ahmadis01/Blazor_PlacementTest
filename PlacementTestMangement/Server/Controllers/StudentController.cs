using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacementTestMangement.Server.Interfaces;
using PlacementTestMangement.Shared.Models;
using PlacementTestMangement.Shared.Dto;
using PlacementTestMangement.Server.Repository;

namespace PlacementTestMangement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = _studentRepository.GetStudents();
            return Ok(students);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetStudent(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = _studentRepository.GetStudent(id);
            return Ok(students);
        }
        [HttpGet("{name}")]
        public IActionResult GetStudent(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = _studentRepository.GetStudent(name);
            return Ok(students);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var respond = _studentRepository.AddStudent(student);
            return Ok(respond);

        }
        [HttpGet("search/{searchText?}")]
        public IActionResult SearchStudents(string? searchText)
        {
            if (searchText == null)
                return Ok(GetStudents());
            return Ok(_studentRepository.SearchStudents(searchText));
        }
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _studentRepository.UpdateStudent(student);
            return Ok();
        }
        [HttpPut("/api/student/submitAnswer")]
        public async Task<IActionResult> SubmitAnswer([FromBody] StudentAnswerDto answer)
        {
            if (answer == null)
                return BadRequest();
            var result = await _studentRepository.SubmitAnswer(answer);
            return Ok(result);
        }
        [HttpPut("/api/student/skip")]
        public async Task<IActionResult> SkipAnswer([FromBody]StudentAnswerDto answer)
        {
            var result = await _studentRepository.SkipQuestion(answer);
            return Ok(result);
        }
        [HttpPut("/api/student/subimtReadingAnswers")]
        public IActionResult SubmitReadingAnswers(ReadingAnswersDto answersDto)
        {
            var result = _studentRepository.SubmitReadingAnswers(answersDto);
            return Ok();
        }

        [HttpPut("/api/student/updatePersonalData")]
        public IActionResult UpdatePersonalData(PersonalDataDto dto)
        {
            var result = _studentRepository.UpdateStudentPersonalData(dto);
            return Ok(result);
        }

		[HttpPut("/api/student/updateTimer")]
		public IActionResult UpdateTimer(TimerDto dto)
		{
			var result = _studentRepository.UpdateTimer(dto);
			return Ok(result);
		}
		[HttpPut("/api/student/SubmitLearningProfileSurvey")]
		public async Task<IActionResult> SubmitLearningProfileSurvey(List<StudentProfileAnswers> dto)
		{
			var result = await _studentRepository.SubmitLearningProfileSurveyAsync(dto);
			return Ok(result);
		}
        [HttpGet("/api/student/GetStudentPersonalData/{studentId}")]
        public async Task<IActionResult> GetStudentPersonalData(int studentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _studentRepository.GetStudentPersonalDataAsync(studentId);
            return Ok(result);
        }
        [HttpGet("/api/student/GetStudentAnswers/{studentId}")]
        public async Task<IActionResult> GetStudentAnswers(int studentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _studentRepository.GetStudentAnswersAsync(studentId);
            return Ok(result);
        }
    }
}
