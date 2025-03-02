using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface ITRANSSVC
    {
        IEnumerable<TblTransaction> GetList();
        IEnumerable<TblTransactionDetail> GetDetails(int TransID);        
        public Totals GetTotals(int month, int year);
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
            var transactions = from t in _context.TblTransactions
                               join td in _context.TblTransactionDetails on t.Id equals td.TransactionId into transactionDetails
                               select new TblTransaction
                               {
                                   Id = t.Id,
                                   Transactiondate = t.Transactiondate,
                                   Memo = t.Memo,
                                   Account = t.Account,
                                   ReimburseToUser = t.ReimburseToUser,
                                   AddUser = t.AddUser,
                                   AddTime = t.AddTime,
                                   Total = transactionDetails.Sum(td => td.Amount) // Calculate the total amount
                               };

            return transactions.ToList();
        }
        public Totals GetTotals(int month, int year)
        {
            var transactionTotals = (from td in _context.TblTransactionDetails
                                     join t in _context.TblTransactions on td.TransactionId equals t.Id
                                     join a in _context.TblAccounts on td.Account equals a.Id
                                     where t.Transactiondate.Month == month && t.Transactiondate.Year == year
                                     group td by a.Type into g
                                     select new
                                     {
                                         Type = g.Key,
                                         TotalAmount = g.Sum(td => td.Amount)
                                     })
                                     .ToList();

            var totals = new Totals
            {
                TotalIncome = transactionTotals.Where(t => t.Type == "I").Sum(t => t.TotalAmount),
                TotalExpense = transactionTotals.Where(t => t.Type == "E").Sum(t => t.TotalAmount)
            };

            return totals;
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
                return "Transaction detail request was saved!";
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
                return "Transaction detail request was deleted!";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
