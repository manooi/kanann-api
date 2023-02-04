namespace Domain;

public class RFIDMapping
{
    public int RFIDMappingId { get; set; }
    public string RFID { get; set; }
    public string StudentId { get; set; }
    
    public Student Student { get; set; }
}