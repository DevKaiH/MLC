
using MLC.Models;

namespace MLC.Services
{
    public interface IsettingsSVC
    {
        IEnumerable<TblSetting> GetValue(string Property);
        IEnumerable<TblSetting> GetTable();
    }
    public class SettingSVC : IsettingsSVC
    {
        private MlcdataContext _context;
        public SettingSVC(MlcdataContext context)
        {
            _context = context;
        }
        public IEnumerable<TblSetting> GetValue(string Property)
        {
            return _context.TblSettings.Where(s => s.Property == Property);
        }
        public IEnumerable<TblSetting> GetTable()
        {
            return _context.TblSettings;
        }
    }
}
