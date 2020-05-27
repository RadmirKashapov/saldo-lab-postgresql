using SladoLab.Interfaces;
using SladoLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationContext db;

        public UnitOfWork(ApplicationContext context)
        {
            db = context;
        }

        public IRepository<Charge> Charges
        {
            get
            {
                if (Charges == null)
                {
                    Charges = new ChargeRepository(db);
                }
                return Charges;
            }

            private set { }
        }

        public IRepository<Contract> Contracts
        {
            get
            {
                if (Contracts == null)
                {
                    Contracts = new ContractRepository(db);
                }
                return Contracts;
            }

            private set { }
        }

        public IRepository<House> Houses
        {
            get
            {
                if (Houses == null)
                {
                    Houses = new HouseRepository(db);
                }
                return Houses;
            }

            private set { }
        }

        public IRepository<Payment> Payments
        {
            get
            {
                if (Payments == null)
                {
                    Payments = new PaymentRepository(db);
                }
                return Payments;
            }

            private set { }
        }

        public IRepository<Saldo> Saldos
        {
            get
            {
                if (Saldos == null)
                {
                    Saldos = new SaldoRepository(db);
                }
                return Saldos;
            }

            private set { }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
