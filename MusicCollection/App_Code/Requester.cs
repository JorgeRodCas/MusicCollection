using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

/// <summary>
/// Summary description for Requester
/// </summary>
public class Requester
{
    public Requester()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Album> getAlbums()
    {
        List<Album> albums = new List<Album>();

        var request = System.Net.WebRequest.Create(ConfigurationManager.AppSettings["albumEndpoint"]);
        request.ContentType = "application/json; charset=utf-8";
        request.Method = "GET";

        var response = (HttpWebResponse)request.GetResponse();

        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            albums = JsonConvert.DeserializeObject<List<Album>>(reader.ReadToEnd());
        }

        return albums;
    }

    public List<Photo> getPhotos(int albumId)
    {
        List<Photo> photos = new List<Photo>();

        var request = System.Net.WebRequest.Create(ConfigurationManager.AppSettings["photoEndpoint"].Replace("{albumId}", albumId.ToString()));
        request.ContentType = "application/json; charset=utf-8";
        request.Method = "GET";

        var response = (HttpWebResponse)request.GetResponse();

        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            photos = JsonConvert.DeserializeObject<List<Photo>>(reader.ReadToEnd());
        }

        return photos;
    }
}