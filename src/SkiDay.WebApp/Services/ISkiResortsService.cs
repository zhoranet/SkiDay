using System;
using System.Collections.Generic;
using SkiDay.WebApp.Models;

namespace SkiDay.WebApp.Services
{
    public interface ISkiResortsService
    {
        void ImportSkiResorts();
        IEnumerable<SkiResort> GetAllResortsByName(string name);
        IEnumerable<MySkiDay> GetAllDays(string userId);
        void AddSkiDay(MySkiDay skiDay);
        MySkiDay FindSkiDay(DateTime date, string userId);
        void Remove(MySkiDay day);
    }
}