using Microsoft.EntityFrameworkCore;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Repositories
{
    public class ReportRepository : IRepository<Report>
    {
        private ApplicationContext db;

        public ReportRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Report> GetAll()
        {
            return db.Reports;
        }

        public Report Get(string id)
        {
            return db.Reports.Find(id);
        }

        public void Create(Report Report)
        {
            db.Reports.Add(Report);
        }

        public void Update(Report Report)
        {
            db.Entry(Report).State = EntityState.Modified;
        }

        public IEnumerable<Report> Find(Func<Report, Boolean> predicate)
        {
            return db.Reports.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            Report Report = db.Reports.Find(id);
            if (Report != null)
                db.Reports.Remove(Report);
        }
    }
}
