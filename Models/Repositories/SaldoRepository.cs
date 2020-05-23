using Microsoft.EntityFrameworkCore;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Repositories
{
    public class SaldoRepository : IRepository<Saldo>
    {
        private ApplicationContext db;

        public SaldoRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Saldo> GetAll()
        {
            return db.Saldos;
        }

        public Saldo Get(string id)
        {
            return db.Saldos.Find(id);
        }

        public void Create(Saldo Saldo)
        {
            db.Saldos.Add(Saldo);
        }

        public void Update(Saldo Saldo)
        {
            db.Entry(Saldo).State = EntityState.Modified;
        }

        public IEnumerable<Saldo> Find(Func<Saldo, Boolean> predicate)
        {
            return db.Saldos.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            Saldo Saldo = db.Saldos.Find(id);
            if (Saldo != null)
                db.Saldos.Remove(Saldo);
        }
    }
}
