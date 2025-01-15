
using MLC.Models;

namespace MLC.Services
{
    public interface IAccountSVC
    {
        IEnumerable<TblAccount> GetAccounts(); 
    }
    public class AccountSVC : IAccountSVC
    {
        private MlcdataContext _context;
        public AccountSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<TblAccount> GetAccounts()
        {
            return _context.TblAccounts;
        }
    }
}
