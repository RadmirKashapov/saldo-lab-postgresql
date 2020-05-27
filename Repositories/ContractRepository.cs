﻿using Microsoft.EntityFrameworkCore;
using SladoLab.Interfaces;
using SladoLab.Models;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Repositories
{
    public class ContractRepository : IRepository<Contract>
    {
        private ApplicationContext db;

        public ContractRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Contract> GetAll()
        {
            return db.Contracts;
        }

        public Contract Get(long id)
        {
            return db.Contracts.Find(id);
        }

        public void Create(Contract Contract)
        {
            db.Contracts.Add(Contract);
        }

        public void Update(Contract Contract)
        {
            db.Entry(Contract).State = EntityState.Modified;
        }

        public IEnumerable<Contract> Find(Func<Contract, Boolean> predicate)
        {
            return db.Contracts.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            Contract Contract = db.Contracts.Find(id);
            if (Contract != null)
                db.Contracts.Remove(Contract);
        }
    }
}
