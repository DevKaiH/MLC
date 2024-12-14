using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface IPMTSVC
    {
        IEnumerable<TblPayment> FindPayment(int RecID);
        IEnumerable<TblPayment> GetList();
        public string AddPayment(TblPayment payment);
        public string UpdatePayment(TblPayment payment);
        public string DeletePayment(TblPayment delpmt);
        public string ApprovePayment(int id, string m);

    }
    public class PmtSVC : IPMTSVC
    {
        private MlcdataContext _context;
        public PmtSVC(MlcdataContext context)
        {
            _context = context;
        }

        public IEnumerable<TblPayment> GetList()
        {
            return _context.TblPayments;
        }
        public IEnumerable<TblPayment> FindPayment(int RecID)
        {
            return _context.TblPayments.Where(p => p.RecipientId == RecID);
        }
        public string AddPayment(TblPayment payment)
        {
            try
            {
                _context.TblPayments.Add(payment);
                _context.SaveChanges();
                return "Payment request was saved!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string UpdatePayment(TblPayment payment)
        {
            try
            {
                var local = _context.Set<TblPayment>().Local.SingleOrDefault(change => change == payment);
                // check if local is not null
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;

                    local.RecipientId= payment.RecipientId;
                    local.Date = payment.Date;
                    local.Memo = payment.Memo;
                    local.ApproveDate = payment.ApproveDate;
                    local.ApprovedBy = payment.ApprovedBy;
                    local.SubmittedToBmo = payment.SubmittedToBmo;
                    local.Amount = payment.Amount;
                    local.Tax = payment.Tax;
                    local.Account = payment.Account;
                    local.Filename = payment.Filename;

                    _context.Attach(local);
                    _context.Entry(local).State = EntityState.Modified;
                    _context.SaveChanges();

                    return "Payment request was updated!";
                }

                return "No Data was updated!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string DeletePayment(TblPayment delpmt)
        {
            try
            {              
               
                    _context.TblPayments.Remove(delpmt);
                    _context.SaveChanges();
                    return "Payment request was deleted!";
              
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string ApprovePayment(int id,string mode)
        {
            try
            {
                var local = _context.Set<TblPayment>().Local.SingleOrDefault(change => change.Id == id);
                // check if local is not null
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;

                    if (mode == "A") 
                    {
                    local.ApproveDate = DateTime.Now;
                    local.ApprovedBy = "Administrator";
                    }
                    if(mode == "S")
                    {
                    local.SubmittedToBmo = DateTime.Now;
                    }
                    _context.Attach(local);
                    _context.Entry(local).State = EntityState.Modified;
                    _context.SaveChanges();

                    return "Payment has been approved!";
                }
                else
                {
                    return "Payment with the specified ID was not found.";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
