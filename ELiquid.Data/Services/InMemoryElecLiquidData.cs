using System;
using System.Collections.Generic;
using System.Linq;
using ELiquid.Data.Models;

namespace ELiquid.Data.Services
{
    public class InMemoryElecLiquidData : IElecLiquidData
    {
        List<ElecLiquid> elecLiquids;
        public InMemoryElecLiquidData()
        {
            elecLiquids = new List<ElecLiquid>()
            {
                new ElecLiquid {Id=1, Name = "Cigarillo", Category= Category.Tobacco, PGVGRatio = "50/50", Image= "url..."},
                new ElecLiquid {Id=2, Name = "Peach Brust", Category= Category.Fruit, PGVGRatio = "30/70", Image= "url..."},
                new ElecLiquid {Id=3, Name = "Tiramisu Vape", Category= Category.Dessert, PGVGRatio = "50/50", Image= "url..."}
            };
        }
        public void Add(ElecLiquid elecLiquid)
        {
            elecLiquids.Add(elecLiquid);
            elecLiquid.Id = elecLiquids.Max(e => e.Id) + 1;
        }

        public ElecLiquid Get(int id)
        {
            return elecLiquids.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<ElecLiquid> GetAll()
        {
            return elecLiquids.OrderBy(e => e.Name);
        }

        public void Update(ElecLiquid elecLiquid)
        {
            var existing = Get(elecLiquid.Id);
            if (existing != null)
            {
                existing.Name = elecLiquid.Name;
                existing.Category = elecLiquid.Category;
                existing.PGVGRatio = elecLiquid.PGVGRatio;
                existing.Image = elecLiquid.Image;
            }
        }
        public void Delete(int id)
        {
            var elecLiquid = Get(id);
            if (elecLiquid != null)
            {
                elecLiquids.Remove(elecLiquid);
            }
        }

        public void Like(int like)
        {
            throw new NotImplementedException();
        }

        public void Dislike(int dislike)
        {
            throw new NotImplementedException();
        }
    }
}
