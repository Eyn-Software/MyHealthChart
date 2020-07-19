using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Services
{
    public interface ISQLite
    {
        SQLite.SQLiteAsyncConnection GetConnection();
    }
}
