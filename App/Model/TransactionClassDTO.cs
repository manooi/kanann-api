using Domain;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace App.Model;

public class TransactionClassDTO
{
    public int TransactionClassId { get; set; }
    public string AcademicYearName { get; set; }
    public int AcademicYearId { get; set; }
    public int ClassWeight { get; set; }
    public DateTime StartDate { get; set; }
    public string ClassRoomName { get; set; }
    
}