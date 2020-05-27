using Microsoft.EntityFrameworkCore;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Repositories
{
    public class HouseRepository : IRepository<House>
    {
        private ApplicationContext db;

        public HouseRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<House> GetAll()
        {
            return db.Houses;
        }

        public House Get(string id)
        {
            return db.Houses.Find(id);
        }

        public void Create(House House)
        {
            db.Houses.Add(House);
        }

        public void Update(House House)
        {
            db.Entry(House).State = EntityState.Modified;
        }

        public IEnumerable<House> Find(Func<House, Boolean> predicate)
        {
            return db.Houses.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            House House = db.Houses.Find(id);
            if (House != null)
                db.Houses.Remove(House);
        }
    }
}
