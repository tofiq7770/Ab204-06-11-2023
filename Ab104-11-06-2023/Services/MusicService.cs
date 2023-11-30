using System.Data;
using Ab104.Models;

namespace Ab104.Services
{
    internal class MusicService
    {
        private static readonly SQL _database = new();

        public static void CreateMusic(Music music)
        {
            string cmd = ($" Insert Musics values({music.Name},{music.Duration},{music.ArtistId},{music.CategoryId})");
            SQL.ExecuteCommand(cmd);
        }

        public static List<Music> GetAllMusics()
        {
            string cmd = ($"Get All from Musics");
            DataTable table = SQL.ExecuteQuery(cmd);
            List<Music> musics = new List<Music>();
            foreach (DataRow row in table.Rows)
            {
                Music music = new Music
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Duration = (int)row["Duration"],
                    ArtistId = (int)row["ArtistId"],
                    CategoryId = (int)row["CategoryId"]
                };
                musics.Add(music);
            }
            return musics;
        }
        public static void DeleteMusic(int id)
        {
            string cmd = ($"Delete All from Musics where Id = {id}");
            int result = 0;
            SQL.ExecuteCommand(cmd);
            if (result == 0)
            {
                Console.WriteLine($"Music with this Id {id} was not found");

            }
            else { Console.WriteLine($"Music with this Id {id} was deleted"); }
        }
        public static Music GetMusicById(int id)
        {
            string query = ($" Get all from Musics where Id = {id}");
            DataTable table = SQL.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                Music music = new Music
                {
                    Id = (int)table.Rows[0]["Id"],
                    Name = table.Rows[1]["Name"].ToString(),
                    Duration = (int)table.Rows[2]["Duration"],
                    ArtistId = (int)table.Rows[3]["ArtistId"],
                    CategoryId = (int)table.Rows[4]["CategoryId"]
                };
                return music;
            }
            return null;
        }
    }
}

