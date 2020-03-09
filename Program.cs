using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

namespace LinqQuery
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new AnimalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var cougar = new Species();
                {
                    cougar.Name = "Cougar";
                }
                var tiger = new Species();
                {
                    tiger.Name = "Tiger";
                }
                var tortoise = new Species();
                {
                    tortoise.Name = "Tortoise";
                }

                var whiteCougar = new Animal();
                {
                    whiteCougar.Name = "White cougar";
                    whiteCougar.Species = cougar;
                    whiteCougar.RemainingNumber = 3;
                }

                var whiteTiger = new Animal();
                {
                    whiteTiger.Name = "White tiger";
                    whiteTiger.Species = tiger;
                    whiteTiger.RemainingNumber = 100;
                }

                var albinosTortoise = new Animal();
                {
                    albinosTortoise.Name = "Albinos tortoise";
                    albinosTortoise.Species = tortoise;
                    albinosTortoise.RemainingNumber = 15;
                }

                context.Add(whiteCougar);
                context.Add(whiteTiger);
                context.Add(albinosTortoise);
                context.SaveChanges();

                var whiteCougarId = from spec in context.Species
                                    where spec.Name == "White cougar"
                                    select spec.SpeciesId;

                var remainingWhiteCougar = from animal in context.Animals
                                           where animal.Species == whiteCougarId
                                           select animal.RemainingNumber;


                var whiteTigerId = from spec in context.Species
                                   where spec.Name == "White tiger"
                                   select spec.SpeciesId;

                var remainingWhiteTiger = from animal in context.Animals
                                          where animal.Species == whiteTigerId
                                          select animal.RemainingNumber;

                var albinosTortoiseId = from spec in context.Species
                                        where spec.Name == "Albinos tortoise"
                                        select spec.SpeciesId;

                var remainingAlbinosTurtules = from animal in context.Animals
                                               where animal.Species == albinosTortoiseId
                                               select animal.RemainingNumber;

                /*var tigerTest = from animal in context.Animals
                                join spec in context.Species on animal.Species equals spec.SpeciesId
                                where spec.Name == "White tiger"
                                select animal.RemainingNumber;*/

                string boxMessage = "White cougars: " + remainingWhiteCougar.First() + 
                                    "\n White tigers: " + remainingWhiteTiger.First() + 
                                    "\n Albinos turtules: " + remainingAlbinosTurtules.First();

                MessageBox.Show(boxMessage, "Remaining species", MessageBoxButtons.OK);
            }
        }


    }

    
}
