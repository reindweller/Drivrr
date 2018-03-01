using Driverr.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Driverr.Api.Models
{
    public static class DbInitializer
    {
        public static void Initialize(DrivrrContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.States.Any())
            {
                return;   // DB has been seeded
            }

            var states = new State[]
            {
                new State{Name="New South Wales",Abbrev="NSW",Type=StateTypeEnum.State},
                new State{Name="Queensland",Abbrev="Qld",Type=StateTypeEnum.State},
                new State{Name="South Australia",Abbrev="SA",Type=StateTypeEnum.State},
                new State{Name="Tasmania",Abbrev="Tas",Type=StateTypeEnum.State},
                new State{Name="Victoria",Abbrev="Vic",Type=StateTypeEnum.State},
                new State{Name="Western Australia",Abbrev="WA",Type=StateTypeEnum.State}
            };
            foreach (State s in states)
            {
                context.States.Add(s);
            }

            context.SaveChanges();

            var nswId = context.States.Where(o => o.Name == "New South Wales").FirstOrDefault().Id;
            var suburbs = new Suburb[]
            {
                new Suburb{Name = "Aarons Pass", StateId = nswId, PostCode = "2850"},
                new Suburb{Name = "Abbotsford", StateId = nswId, PostCode = "2046"},
                new Suburb{Name = "Abercrombie River", StateId = nswId, PostCode = "2795"}
            };
            foreach (Suburb s in suburbs)
            {
                context.Suburbs.Add(s);
            }

            context.SaveChanges();


        }
    }
}
