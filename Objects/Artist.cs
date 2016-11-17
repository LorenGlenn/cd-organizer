using System.Collections.Generic;

namespace Organizer.Objects
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    private string _artistName;
    private int _id;
    private List<Cd> _cds;
    private static List<Artist> _matches = new List<Artist> {};

    public Artist(string artistName)
    {
      _artistName = artistName;
      _instances.Add(this);
      _id = _instances.Count;
      _cds = new List<Cd>{};
    }
    public string GetArtistName()
    {
      return _artistName;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Cd> GetCds()
    {
      return _cds;
    }
    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public static List<Artist> FilterArtist(string searchName)
    {
      foreach(Artist i in _instances)
      {
        if(i._artistName == searchName)
        {
          _matches.Add(i);
        }
      }
      return _matches;
    }
    public static List<Artist> GetAll()
    {
      return _instances;
    }
  }


}
