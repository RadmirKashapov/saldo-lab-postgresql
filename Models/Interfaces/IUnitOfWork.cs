using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Charge> Charges { get; }
        IRepository<Contract> Contracts { get; }
        IRepository<House> Houses { get; }
        IRepository<Payment> Payments { get; }
        IRepository<Saldo> Saldos { get; }
        void Save();
    }
}
