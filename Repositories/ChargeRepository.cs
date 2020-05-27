using Microsoft.EntityFrameworkCore;
using SladoLab.Interfaces;
using SladoLab.Models;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Repositories
{
    public class ChargeRepository : IRepository<Charge>
    {
        private ApplicationContext db;

        public ChargeRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Charge> GetAll()
        {
            return db.Charges;
        }

        public Charge Get(long id)
        {
            return db.Charges.Find(id);
        }

        public void Create(Charge charge)
        {
            db.Charges.Add(charge);
        }

        public void Update(Charge charge)
        {
            db.Entry(charge).State = EntityState.Modified;
        }

        public IEnumerable<Charge> Find(Func<Charge, Boolean> predicate)
        {
            return db.Charges.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            Charge charge = db.Charges.Find(id);
            if (charge != null)
                db.Charges.Remove(charge);
        }
    }
}
