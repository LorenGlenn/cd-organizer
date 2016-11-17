using System.Collections.Generic;

namespace Organizer.Objects
{
  public class Cd
  {

    private string _name;
    private int _id;
    private static List<Cd> _instances = new List<Cd> {};

    public Cd (string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public static List<Cd> GetAllCd()
    {
      return _instances;
    }

    public static Cd Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
