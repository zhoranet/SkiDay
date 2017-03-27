using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using SkiDay.WebApp.Models;

namespace SkiDay.WebApp.Services
{
    public class SkiService : ISkiResortsService
    {
        private readonly SkiDayContext _context;

        public SkiService(SkiDayContext context)
        {
            _context = context;
        }

        public void ImportSkiResorts()
        {
            var fileName = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug","") + 
                "App_Data\\resort-names.json";

            if (File.Exists(fileName))
            {
                var text = File.ReadAllText(fileName);

                var array = JArray.Parse(text);

                foreach (var token in array)
                {
                    var value = token.Value<string>();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        _context.SkiResorts.Add(new SkiResort {Name = value});
                    }
                }

                _context.SaveChanges();
            }
            else
            {
                _context.SkiResorts.Add(new SkiResort {Name = "Test"});
            }
        }

        public IEnumerable<SkiResort> GetAllResortsByName(string name)
        {
            var expression = string.IsNullOrWhiteSpace(name)
                ? (Expression<Func<SkiResort, bool>>) (x => x.Id > 0)
                : (x => x.Name.StartsWith(name));

            return _context.SkiResorts.Where(expression).OrderBy(x=>x.Name).Take(1000);
        }

        public IEnumerable<MySkiDay> GetAllDays(string userId)
        {
            return _context.SkiDays.Where(x => x.UserId == userId).ToList();
        }

        public void AddSkiDay(MySkiDay skiDay)
        {
            skiDay.Added = DateTime.Now;
            _context.SkiDays.Add(skiDay);
            _context.SaveChanges();
        }

        public MySkiDay FindSkiDay(DateTime date, string userId)
        {
            return _context.SkiDays.FirstOrDefault(x => x.Date == date);
        }

        public void Remove(MySkiDay day)
        {
            if (day == null) return;
            _context.SkiDays.Remove(day);
            _context.SaveChanges();
        }
    }
}