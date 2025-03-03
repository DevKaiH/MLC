
using MLC.Models;

namespace MLC.Services
{
    public interface IMemberSVC
    {
        IEnumerable<TblMember> GetMemberlist(); 
    }
    public class MemberSVC : IMemberSVC
    {
        private MlcdataContext _context;
        public MemberSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<TblMember> GetMemberlist()
        {
            return _context.TblMembers.OrderBy(o => o.Lastname);
        }
    }
}
