using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface IPMTSVC
    {
        IEnumerable<TblPayment> FindPayment(int UserID);
        IEnumerable<TblPayment> GetList();
        public string AddPayment(TblPayment payment);
        public string UpdatePayment(TblPayment payment);
        public string DeletePayment(int id);
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
        public IEnumerable<TblPayment> FindPayment(int UserID)
        {
            return _context.TblPayments.Where(p => p.UserId == UserID);
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

                    local.UserId= payment.UserId;
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
        public string DeletePayment(int id)
        {
            try
            {
                var paymentToDelete = _context.TblPayments.Find(id);
                if (paymentToDelete != null)
                {
                    _context.TblPayments.Remove(paymentToDelete);
                    _context.SaveChanges();
                    return "Payment request was deleted!";
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
