using Microsoft.EntityFrameworkCore;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Repositories
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

        public Payment Get(string id)
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

        public void Delete(string id)
        {
            Payment Payment = db.Payments.Find(id);
            if (Payment != null)
                db.Payments.Remove(Payment);
        }
    }
}
