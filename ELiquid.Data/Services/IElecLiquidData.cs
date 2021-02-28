using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELiquid.Data.Models;

namespace ELiquid.Data.Services
{
    public interface IElecLiquidData
    {
        IEnumerable<ElecLiquid> GetAll();
        ElecLiquid Get(int id);
        void Add(ElecLiquid elecLiquid);
        void Update(ElecLiquid elecLiquid);
        void Delete(int id);
        void Like(int like);
        void Dislike(int dislike);
    }
}
