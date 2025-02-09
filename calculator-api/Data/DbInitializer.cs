using calculator_api.Models;
using System;
using System.Linq;

namespace calculator_api.Data
{
    public class DbInitializer
    {
        public static void Initialize(CalculatorContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Aliquotas.Any())
            {
                return;   // DB has been seeded
            }

            var aliquotas = new Aliquota[]
            {
                new Aliquota{SalarioMax=2, Porcentagem = 0},
                new Aliquota{SalarioMin=2, SalarioMax=4, Porcentagem = 7.5m},
                new Aliquota{SalarioMin=4, SalarioMax=5, Porcentagem = 15},
                new Aliquota{SalarioMin=5, SalarioMax=7, Porcentagem = 22.5m},
                new Aliquota{SalarioMin=7, Porcentagem = 27.5m},

            };
            foreach (Aliquota a in aliquotas)
            {
                context.Aliquotas.Add(a);
            }
            context.SaveChanges();
            
        }
    }
}