using AutoMapper;
using Domain.Entities;
using Domain.Entitiesl;
using Service.DTOs.Assigment;
using Service.DTOs.Course;
using Service.DTOs.Enrollment;
using Service.DTOs.Lesson;
using Service.DTOs.Quiz;
using Service.DTOs.QuizQuestion;
using Service.DTOs.Submission;
using Service.DTOs.User;

namespace Service.Mappers;

public class MappingProFile:Profile
{
    public MappingProFile()
    {
        //User
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();
        
        //Assigment
        CreateMap<Assigment, AssigmentCreationDto>().ReverseMap();
        CreateMap<AssigmentUpdateDto, Assigment>().ReverseMap();
        CreateMap<AssigmentResultDto, Assigment>().ReverseMap();

        //Course
        CreateMap<Course, CourseCreationDto>().ReverseMap();
        CreateMap<CourseUpdateDto, Course>().ReverseMap();
        CreateMap<CourseResultDto, Course>().ReverseMap();

        //Enrollment
        CreateMap<Enrollment, EnrollmentCreationDto>().ReverseMap();
        CreateMap<EnrollmentUpdateDto, Enrollment>().ReverseMap();
        CreateMap<EnrollmentResultDto, Enrollment>().ReverseMap();

        //Lesson
        CreateMap<Lesson, LessonCreationDto>().ReverseMap();
        CreateMap<LessonUpdateDto, Lesson>().ReverseMap();
        CreateMap<LessonResultDto, Lesson>().ReverseMap();

        //Quiz
        CreateMap<Quiz, QuizCreationDto>().ReverseMap();
        CreateMap<QuizUpdateDto, Quiz>().ReverseMap();
        CreateMap<QuizResultDto, Quiz>().ReverseMap();

        //QuizQuestion
        CreateMap<QuizQuestion, QuizQuestionCreationDto>().ReverseMap();
        CreateMap<QuizQuestionUpdateDto, QuizQuestion>().ReverseMap();
        CreateMap<QuizQuestionResultDto, QuizQuestion>().ReverseMap();

        //Submission
        CreateMap<Submission, SubmissionCreationDto>().ReverseMap();
        CreateMap<SubmissionUpdateDto, Submission>().ReverseMap();
        CreateMap<SubmissionResultDto, Submission>().ReverseMap();
    }
}
