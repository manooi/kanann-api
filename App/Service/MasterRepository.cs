using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Service;

public class MasterRepository : IMasterRepository
{
    private readonly KananContext _context;

    public MasterRepository(KananContext _ctx)
    {
        _context = _ctx;
    }

    public IEnumerable<MasterMapping> GetMasterMapping(int masterId)
    {
        return _context.MasterMappings
            .Where(master => master.MasterDatabaseId == masterId)
            .OrderBy(master => master.Sequence)
            .ToList();
    }
}