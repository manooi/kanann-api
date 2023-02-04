using Domain;

namespace App.Service;

public interface IMasterRepository
{
   IEnumerable<MasterMapping> GetMasterMapping(int masterId);
}