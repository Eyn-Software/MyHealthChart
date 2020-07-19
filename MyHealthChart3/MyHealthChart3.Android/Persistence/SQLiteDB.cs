using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyHealthChart3.Droid.Persistence;
using MyHealthChart3.Services;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace MyHealthChart3.Droid.Persistence
{
    public class SQLiteDB : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var FullPath = Path.Combine(path, "MySQLite.db3");
            return new SQLiteAsyncConnection(FullPath);
        }
    }
}