namespace Domain;

public class MasterDatabase
{
    public int MasterDataBaseId { get; set; }
    public string MasterName { get; set; }
    public List<MasterMapping> MasterMappings { get; set; }

    public MasterDatabase()
    {
        MasterMappings = new List<MasterMapping>();
    }
}