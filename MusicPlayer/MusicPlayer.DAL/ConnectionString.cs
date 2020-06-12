using Microsoft.EntityFrameworkCore.Storage;

namespace MusicPlayer.DAL
{
    public static class ConnectionString
    {
        public static string Value { get; } = "Data Source=.\\SQLEXPRESS;Initial Catalog=MusicDB;Integrated Security=True";
    }
}
