using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using MLC.Models;

namespace MLC.Services
{
    public interface IUserSVC
    {
        IEnumerable<VRecipient> getUsers();
        public TblRecipient getUser(int Id); 
        public string addUser(TblRecipient user);
        public string updateUser(TblRecipient user);
        public string deleteUser(TblRecipient user);
    }
    public class UserSVC : IUserSVC
    {
        private MlcdataContext _context;
        public UserSVC(MlcdataContext context)
        {
            _context = context;
        }

        public IEnumerable<VRecipient> getUsers()
        {
            return _context.VRecipients.OrderBy(r => r.LastName);
        }
        public TblRecipient getUser(int Id)
        {
            return (TblRecipient)_context.TblRecipients.Where(x => x.Id == Id);
        }
        public string addUser(TblRecipient user)
        {
            try { 
            _context.TblRecipients.Add(user);
            _context.SaveChanges();
            return "User " + user.FirstName + " " + user.LastName + " was inserted!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }   
        }
        public string updateUser(TblRecipient user)
        {
            try
            {
                var local = _context.Set<TblRecipient>().Local.SingleOrDefault(change => change.Id == user.Id);
                // check if local is not null
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;

                    local.FirstName = user.FirstName;
                    local.LastName = user.LastName;
                    local.Email = user.Email;
                    local.Bank = user.Bank;
                    local.Transit = user.Transit;
                    local.Account = user.Account;

                    _context.Attach(local);
                    _context.Entry(local).State = EntityState.Modified;
                    _context.SaveChanges();

                    return "User " + user.FirstName + " " + user.LastName + " was updated!";
                }

                return "No Data was updated!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string deleteUser(TblRecipient user)
        {
            try 
            { 
            _context.Remove(user);
            _context.SaveChanges();
            return "User was deleted!";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        
    }
}
