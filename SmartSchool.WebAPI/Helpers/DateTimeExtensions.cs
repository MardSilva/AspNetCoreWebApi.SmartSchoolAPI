using System;

namespace SmartSchool.WebAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int PegarIdadeAtual(this DateTime dateTime)
        {
            //ex.: 2020 - ano = idade;
            var dataAtual = DateTime.UtcNow;
            int idade = dataAtual.Year - dateTime.Year;

            if(dataAtual < dateTime.AddYears(idade))
            {
                idade--;
            }
            return idade;
        }
    }
}