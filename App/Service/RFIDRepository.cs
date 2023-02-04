using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Service;

public class RFIDRepository : IRFIDRepository
{
    private readonly KananContext _context;

    public RFIDRepository(KananContext _ctx)
    {
        _context = _ctx;
    }
    
    public IEnumerable<RFIDMapping> GetRFIDMapping()
    {
        return _context.RfidMappings.ToList();
    }
}