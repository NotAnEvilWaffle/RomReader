using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;

namespace RomReader.Util;

public class IgdbUtils
{
    public static IGDBClient igdb;
    
    public IgdbUtils()
    {
        igdb = new IGDBClient(
            Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
            Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
        );
        
        Debug.WriteLine("Client ID: " + Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"));
        Debug.WriteLine("Client Secret: " + Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET"));
        
        
    }

    public static async Task<string> GetBoxArtByTitle(string title)
    {
        int game = 0;
        var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields cover.image_id,name; where name = \"{title}\";");

        if(games.Length > 0) Debug.WriteLine(games[0].Name);
        
        for (int i = 0; i < games.Length; i++)
        {
            if (games[i].Cover != null)
            {
                Debug.WriteLine("Cover found for: " + title);
                game = i;
                break;
            }

            game = -1;
        }
        
        if(game == -1) return String.Empty;
        
        //Debug.WriteLine(games.Length + " " + games[0].Name);
        var artworkImageId = games.First().Cover.Value.ImageId;
        //Debug.WriteLine(artworkImageId);

        return IGDB.ImageHelper.GetImageUrl(imageId: artworkImageId, size: ImageSize.CoverBig, retina: false);
    }
}