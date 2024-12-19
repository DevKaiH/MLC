
using MLC.Models;

namespace MLC.Services
{
    public interface IAccountSVC
    {
        IEnumerable<TblAccount> GetAccounts(string type); 
    }
    public class AccountSVC : IAccountSVC
    {
        private MlcdataContext _context;
        public AccountSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<TblAccount> GetAccounts(string type)
        {
            return _context.TblAccounts.Where(a => a.Type == type);
        }
    }
}
