using System.Data;
using Ab104.Models;

namespace Ab104.Services
{
    internal class ArtistService
    {
        private readonly SQL _database = new();

        public static void CreateArtists(Artist artist)
        {
            string cmd = ($" Insert into Artists values({artist.Name},{artist.Surname},{artist.Birthday}<{artist.Gender})");
            SQL.ExecuteCommand(cmd);
        }

        public static void DeleteArtist(int id)
        {
            string cmd = ($" Delete * from Artists where Id = {id}");
            int result = 0;
            SQL.ExecuteCommand(cmd);
            if (result == 0)
            {
                Console.WriteLine($"Artist with this Id {id} was not found");

            }
            else { Console.WriteLine($"Artis with this Id {id} was deleted"); }
        }

        public static List<Artist> GetAllArtists()
        {
            string cmd = ($" Get * from Artists");
            DataTable table = SQL.ExecuteQuery(cmd);
            List<Artist> artists = new List<Artist>();
            foreach (DataRow row in table.Rows)
            {
                Artist artist = new Artist
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Birthday = row["Birthday"].ToString(),
                    Gender = row["Gender"].ToString(),


                };
                artists.Add(artist);
            }
            return artists;

        }
        public static Artist GetArtistById(int id)
        {
            string query = ($" Get all from Artists where Id={id}");
            DataTable table = SQL.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                Artist artist = new Artist
                {
                    Id = (int)table.Rows[0]["Id"],
                    Name = table.Rows[1]["Name"].ToString(),
                    Surname = table.Rows[2]["Surname"].ToString(),
                    Birthday = table.Rows[3]["Birthday"].ToString(),
                    Gender = table.Rows[4]["Gender"].ToString(),


                };
                return artist;
            }
            return null;
        }
    }
}
