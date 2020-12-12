using AutoMapper;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile( )
        {
            //criando um mapeamento entre Models e DTO's
            CreateMap<Aluno, AlunoDTO>()
            
            //criando os mebros do mapeamento
            .ForMember(
                dest => dest.NomeAluno,
                opt => opt.MapFrom(source => $"{source.NomeAluno} {source.SobrenomeAluno}")
            )
            
            //calculando a idade
            .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(source => source.DataNascimento.PegarIdadeAtual())
            );

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDTO>().ReverseMap();


            //Professor
            CreateMap<Professor, ProfessorDTO>()
                .ForMember(
                    dest => dest.NomeProfessor,
                    opt => opt.MapFrom(source => $"{source.NomeProfessor} {source.SobrenomeProfessor}")
                );
            
            CreateMap<ProfessorDTO, Professor>();
            CreateMap<Professor, ProfessorRegistrarDTO>().ReverseMap();
        }
    }
}