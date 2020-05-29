using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models;
using HouseSaldoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private IRepository<Charge> chargeRepository;
        private IRepository<Contract> contractRepository;
        private IRepository<House> houseRepository;
        private IRepository<Payment> paymentRepository;
        private IRepository<Saldo> saldoRepository;

        public UnitOfWork(ApplicationContext context)
        {
            db = context;
        }

        public IRepository<Charge> Charges
        {
            get
            {
                if (chargeRepository == null)
                {
                    chargeRepository = new ChargeRepository(db);
                }
                return chargeRepository;
            }

        }

        public IRepository<Contract> Contracts
        {
            get
            {
                if (contractRepository == null)
                {
                    contractRepository = new ContractRepository(db);
                }
                return contractRepository;
            }
        }

        public IRepository<House> Houses
        {
            get
            {
                if (houseRepository == null)
                {
                    houseRepository = new HouseRepository(db);
                }
                return houseRepository;
            }
        }

        public IRepository<Payment> Payments
        {
            get
            {
                if (paymentRepository == null)
                {
                    paymentRepository = new PaymentRepository(db);
                }
                return paymentRepository;
            }
        }

        public IRepository<Saldo> Saldos
        {
            get
            {
                if (saldoRepository == null)
                {
                    saldoRepository = new SaldoRepository(db);
                }
                return saldoRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
