using MyHealthChart3.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHealthChart3.Services
{
    public class DBNotification : INotificationStore
    {
        private SQLiteAsyncConnection Connection;

        public DBNotification(ISQLite db)
        {
            Connection = db.GetConnection();
            Connection.CreateTableAsync<Notification>();
        }
        public async Task Add(Notification Notification)
        {
            await Connection.InsertAsync(Notification);
        }

        public async Task DeleteAll()
        {
            await Connection.DeleteAllAsync<Notification>();
        }
        public async Task DeleteOldPrescription(int PId)
        {
            await Connection.QueryAsync<Notification>("Delete from Notification where " +
                                                                  "PId = " + PId);
        }
        public async Task DeleteOldAppointment(int AId)
        {
            await Connection.QueryAsync<Notification>("Delete from Notification where AId = " + AId);
        }
        public async Task<List<Notification>> GetAll()
        {
            return await Connection.Table<Notification>().ToListAsync();
        }
        public async Task<List<Notification>> GetPrescriptionNotifs(int PId)
        {
            return await Connection.QueryAsync<Notification>("select * from Notification where PId = " + PId);
        }
        public async Task<List<Notification>> GetAppointmentNotif(int AId)
        {
            return await Connection.QueryAsync<Notification>("select * from Notification where AId = " + AId);
        }
    }
}
