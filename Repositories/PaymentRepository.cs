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
    public class PaymentRepository : IRepository<Payment>
    {
        private ApplicationContext db;

        public PaymentRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Payment> GetAll()
        {
            return db.Payments;
        }

        public Payment Get(long id)
        {
            return db.Payments.Find(id);
        }

        public void Create(Payment Payment)
        {
            db.Payments.Add(Payment);
        }

        public void Update(Payment Payment)
        {
            db.Entry(Payment).State = EntityState.Modified;
        }

        public IEnumerable<Payment> Find(Func<Payment, Boolean> predicate)
        {
            return db.Payments.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            Payment Payment = db.Payments.Find(id);
            if (Payment != null)
                db.Payments.Remove(Payment);
        }
    }
}
