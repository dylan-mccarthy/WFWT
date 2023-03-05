namespace WFWT_BFF_API.Models;

public class Location
{
    public int id {get; set;}
    public string name {get; set;}
    public string description {get; set;}

    public Location(int id, string name, string description){
        this.id = id;
        this.name = name;
        this.description = description;
    }
}