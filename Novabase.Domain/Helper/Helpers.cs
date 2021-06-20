using System;
using System.Collections.Generic;
using System.Text;

namespace Novabase.Domain.Helper
{
    public static class Helpers
    {
        public static string GenerateTrackingCode(string inCountry, int codeCountry, string code, DateTime receiveDate)
        {
            code = code.PadLeft(7, '0');
            var date = receiveDate.ToString("dd/MM/yy").Replace("/", "");
            var finalCode = GerenateFinalCode(receiveDate, codeCountry);
            return inCountry + "-" + code + "-" + Guid.NewGuid().ToString().Substring(30).ToUpper() + "-" + date + "-" + finalCode;
        }


        private static string GerenateFinalCode(DateTime date, int codeCountry)
        {
            //T[0]
            var dia = date.Day.ToString("D2").Substring(0, 1);
            var mes = date.Month.ToString("D2").Substring(1);
            var uYear = date.Year.ToString().Substring(3);
            var codigo = Int32.Parse(dia) + Int32.Parse(mes) + 20;
            var digito = 0;
            var soma = 0;

            while (codigo > 0)
            {
                digito = codigo % 10;
                soma += digito;
                codigo = codigo / 10;
            }

            //t[1]
            var number = codeCountry + Int32.Parse(uYear);
            var aux = 0;
            var sum = 0;

            while (number > 0)
            {
                aux = number % 10;
                sum += aux;
                number = number / 10;
            }
            if (sum > 10)
            {
                number = sum;
                aux = 0;
                sum = 0;
                while (number > 0)
                {
                    aux = number % 10;
                    sum += aux;
                    number = number / 10;
                }
            }
            return soma.ToString() + sum.ToString();
        }
    }

}
