using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface ITRANSSVC
    {
        IEnumerable<TblTransaction> GetList();
        public string AddTransaction(TblTransaction Transaction);
        public string DeleteTransaction(TblTransaction delpmt);
        
    }
    public class TransSVC : ITRANSSVC
    {
        private MlcdataContext _context;
        public TransSVC(MlcdataContext context)
        {
            _context = context;
        }

        public IEnumerable<TblTransaction> GetList()
        {
            return _context.TblTransactions;
        }
        public string AddTransaction(TblTransaction Transaction)
        {
            try
            {
                _context.TblTransactions.Add(Transaction);
                _context.SaveChanges();
                return "Transaction request was saved!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }    
        public string DeleteTransaction(TblTransaction deltrans)
        {
            try
            {              
               
                    _context.TblTransactions.Remove(deltrans);
                    _context.SaveChanges();
                    return "Transaction request was deleted!";
              
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }        
    }
}
