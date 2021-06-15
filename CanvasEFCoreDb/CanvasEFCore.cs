using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasEFCoreDb.Entities;

namespace CanvasEFCoreDb
{
    /// <summary>
    /// Класс для работы с базой SQLite через ORM EF Core
    /// </summary>
    public class CanvasEFCore
    {
        public async Task UpdDbDataAsync()
        {
            using ApplicationDbContext db = new ApplicationDbContext();

            db.Courses.Add(new LmsCourse() { Name = "Курс 1" });
            db.Courses.Add(new LmsCourse() { Name = "Курс 2" });
            db.Courses.Add(new LmsCourse() { Name = "Курс 3" });
            db.Courses.Add(new LmsCourse() { Name = "Курс 4" });

            db.Students.Add(new LmsStudent() { Name = "Вася", Email = "vasa@edu.misis.ru", Courses = new List<LmsCourse>() { new LmsCourse() { Name = "Курс 3" } } });
            db.Students.Add(new LmsStudent() { Name = "Петя", Email = "peta@edu.misis.ru", Courses = new List<LmsCourse>() { new LmsCourse() { Name = "Курс 4" } } });

            await db.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
