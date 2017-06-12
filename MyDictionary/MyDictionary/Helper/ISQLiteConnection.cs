using SQLite.Net;

namespace MyDictionary.Helper
{
    public interface ISQLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
