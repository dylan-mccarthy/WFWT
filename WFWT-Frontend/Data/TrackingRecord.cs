namespace WFWT_Frontend.Data;

public class TrackingRecord
{
    public int id {get; set;}
    public string userId {get; set;}
    public DateTime date {get; set;}
    public int location {get; set;}

    public TrackingRecord(int id, string userId, DateTime date, int location){
        this.id = id;
        this.userId = userId;
        this.date = date;
        this.location = location;
    }
}