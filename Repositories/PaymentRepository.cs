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
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly ApplicationContext db;

        public PaymentRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Payment> GetAll()
        {
            return db.Payments;
        }

        public Payment Get(Guid id)
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

        public void Delete(Guid id)
        {
            Payment Payment = db.Payments.Find(id);
            if (Payment != null)
                db.Payments.Remove(Payment);
        }
    }
}
