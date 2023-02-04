using App.Model;
using Domain;

namespace App.Service;

public interface ITransactionClassRepository
{
   IEnumerable<TransactionClassDTO> GetTransactionClass(GetTransactionClassQuery query);
   void AddTransaction(PostTransactionClass req);

   GetCheck GetCheck(int transactionClassId);

   public void UpdateAttendance(UpdateAttendance req);

    void RemoveTransaction(int transactionClassId);
}