using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELiquid.Data.Models;

namespace ELiquid.Data.Services
{
    public class SqlElecLiquidData : IElecLiquidData
    {
        private readonly ELiquidDbContext db;
        public SqlElecLiquidData(ELiquidDbContext db)
        {
            this.db = db;
        }

        public ELiquidDbContext Db { get; }

        public void Add(ElecLiquid elecLiquid)
        {
            db.ElecLiquids.Add(elecLiquid);
            db.SaveChanges();
        }
               
        public ElecLiquid Get(int id)
        {
            return db.ElecLiquids.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<ElecLiquid> GetAll()
        {
            return from e in db.ElecLiquids
                   orderby e.Name
                   select e;
        }

        public void Update(ElecLiquid elecLiquid)
        {
            //var e = Get(elecLiquid.Id);
            //e.Name = "";
            //db.SaveChanges();
            var entry = db.Entry(elecLiquid);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var elecLiquid = db.ElecLiquids.Find(id);
            db.ElecLiquids.Remove(elecLiquid);
            db.SaveChanges();
        }

        public void Like(int id)
        {
            //var elecLiquid = db.ElecLiquids.Find(id);
            
            //elecLiquid.Like++;
            //db.SaveChanges();

            throw new NotImplementedException();
        }

        public void Dislike(int dislike)
        {
            throw new NotImplementedException();
        }
    }
}
