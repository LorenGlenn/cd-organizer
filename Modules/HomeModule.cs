using Nancy;
using System.Collections.Generic;
using Organizer.Objects;

namespace Organizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/cd/new"] = _ => View["cd-new-form.cshtml"];
      Get["/artist/new"] = _ => View["artist-new-form.cshtml"];
      Get["/artists/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("Cds", artistCds);
        return View["view-artist.cshtml", model];
      };
      Get["/view-all-artist"] = _ =>
       {
         var allArtists = Artist.GetAll();
         return View["view-all-artist.cshtml", allArtists];
       };
      Post["/view-all-cd"] = _ =>
      {
        Cd newCd = new Cd(Request.Form["name"]);
        var allCds = Cd.GetAllCd();
        return View["view-all-cd.cshtml", allCds];
      };
      Post["/view-all-artist"] = _ =>
      {
        Artist newArtist = new Artist(Request.Form["artist"]);
        var allArtist = Artist.GetAll();
        return View["view-all-artist.cshtml", allArtist];
      };
      Get["/artist/{id}/cds/new"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("Cds", artistCds);
        return View["cd-new-form.cshtml", model];
      };
      Post["/cds"] = _ =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(Request.Form["artist-id"]);
        List<Cd> artistCds = selectedArtist.GetCds();
        Cd newCd = new Cd(Request.Form["cd-name"]);
        artistCds.Add(newCd);
        model.Add("Cds", artistCds);
        model.Add("artist", selectedArtist);
        return View["view-artist.cshtml", model];
      };

      Post["/searchArtist"] = _ =>
      {
        var searchInput = Request.Form["searchName"];
        List<Artist> matchedArtists = Artist.FilterArtist(searchInput);
        return View["view-all-artist.cshtml", matchedArtists];
      };
    }
  }
}
