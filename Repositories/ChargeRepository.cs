using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models;
using HouseSaldoLab.Models.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Repositories
{
    public class ChargeRepository : IRepository<Charge>
    {
        private readonly ApplicationContext db;

        public ChargeRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Charge> GetAll()
        {
            return db.Charges;
        }

        public Charge Get(Guid id)
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

        public void Delete(Guid id)
        {
            Charge charge = db.Charges.Find(id);
            if (charge != null)
                db.Charges.Remove(charge);
        }
    }
}
