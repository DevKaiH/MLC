
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface IPCFileSVC
    {
        IEnumerable<PCFile> GetData(int FileNr); 
    }
    public class PCFileSVC : IPCFileSVC
    {
        private MlcdataContext _context;
        public PCFileSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<PCFile> GetData(int FileNr)
        {
            return _context.PCFiles.FromSqlRaw("PCFile {0}", FileNr);
        }
    }
}
