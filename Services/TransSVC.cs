using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface ITRANSSVC
    {
        IEnumerable<TblTransaction> GetList();
        IEnumerable<TblTransactionDetail> GetDetails(int TransID);
  
        public int AddTransaction(TblTransaction Transaction);
        public string AddDetail(TblTransactionDetail Detail);
        public string DeleteTransaction(TblTransaction delpmt);
        public string DeleteDetail(TblTransactionDetail Detail);
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

        public IEnumerable<TblTransactionDetail>GetDetails(int TransID)
        {
            return _context.TblTransactionDetails.Where(d => d.TransactionId == TransID);
        }
        public int AddTransaction(TblTransaction Transaction)
        {
            try
            {
                _context.TblTransactions.Add(Transaction);
                _context.SaveChanges();
                return Transaction.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public string AddDetail(TblTransactionDetail Detail)
        {
            try
            {
                _context.TblTransactionDetails.Add(Detail);
                _context.SaveChanges();
                return "Transactio detail request was saved!";
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
        public string DeleteDetail(TblTransactionDetail detail)
        {
            try
            {

                _context.TblTransactionDetails.Remove(detail);
                _context.SaveChanges();
                return "Transactio detail request was deleted!";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
