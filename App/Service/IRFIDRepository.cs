using Domain;

namespace App.Service;

public interface IRFIDRepository
{
    public IEnumerable<RFIDMapping> GetRFIDMapping();
}