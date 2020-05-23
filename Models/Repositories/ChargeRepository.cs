using Microsoft.EntityFrameworkCore;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Repositories
{
    public class ChargeRepository: IRepository<Charge>
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

            public Charge Get(string id)
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

            public void Delete(string id)
            {
            Charge charge = db.Charges.Find(id);
                if (charge != null)
                    db.Charges.Remove(charge);
            }
    }
}
