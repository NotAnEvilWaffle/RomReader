using System;
using System.Linq;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;

namespace RomReader.Util;

public class IgdbUtils
{
    public IGDBClient igdb;
    
    public IgdbUtils()
    {
        igdb = new IGDBClient(
            Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
            Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
        );
    }

    public async Task<string> GetIDByTitle(string title)
    {
        var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields name,cover; where name {title};");
        var artworkImageId = games.First().Artworks.Values.First().ImageId;

        return IGDB.ImageHelper.GetImageUrl(imageId: artworkImageId, size: ImageSize.CoverBig, retina: false);
    }
}