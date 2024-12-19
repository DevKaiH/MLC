
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface IPCFileSVC
    {
        IEnumerable<PCFile> GetData(int UserID); 
    }
    public class PCFileSVC : IPCFileSVC
    {
        private MlcdataContext _context;
        public PCFileSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<PCFile> GetData(int UserID)
        {
            return _context.PCFiles.FromSqlRaw("PCFile {0}", UserID);
        }
    }
}
