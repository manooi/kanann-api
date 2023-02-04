namespace Domain;

public class MasterMapping
{
    public int MasterDatabaseId { get; set; }
    public string Variable { get; set; }
    public string Name { get; set; }
    public int Sequence { get; set; }
    public MasterDatabase MasterDatabase { get; set; }
}