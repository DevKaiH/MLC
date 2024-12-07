
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface IBMOFileSVC
    {
        IEnumerable<BMO> GetFile(); 
    }
    public class BMOFileSVC : IBMOFileSVC
    {
        private MlcdataContext _context;
        public BMOFileSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<BMO> GetFile()
        {
            return _context.BMOs.FromSqlRaw("BMOFile");
        }
    }
}
