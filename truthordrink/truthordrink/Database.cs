using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using truthordrink.Model;

namespace truthordrink
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>();
            _database.CreateTableAsync<Question>();
        }

        public Task<User> GetUserAsync(string enteredEmail)
        {
            return _database.Table<User>().Where(user => user.Email == enteredEmail).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<Question>> GetQuestionsAsync()
        {
            return _database.Table<Question>().ToListAsync();
        }

        public Task<List<Question>> GetQuestionsForAuthenticatedUserAsync()
        {
            if (!App.IsAuthenticated()) return null;
            int userId = App.GetAuthenticatedUserId();
            return _database.Table<Question>().Where(question => question.userId == userId).ToListAsync();
        }

        public Task<int> SaveQuestionAsync(Question question)
        {
            return _database.InsertAsync(question);
        }

        public Task<int> DeleteQuestionAsync(Question question)
        {
            return _database.DeleteAsync(question);
        }
    }
}
