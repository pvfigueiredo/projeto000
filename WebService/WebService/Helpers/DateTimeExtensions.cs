using System;

namespace WebService.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var dataAtual = DateTime.UtcNow;
            var idade = dataAtual.Year - dateTime.Year;

            if(dataAtual < dateTime.AddYears(idade))
            {
                idade--;
            }
            return idade;
        }
    }
}
