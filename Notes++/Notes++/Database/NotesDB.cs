﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Notes__.Database
{
    public class NotesDB
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public NotesDB(string dbPath)
        {
            _dbConnection = new SQLiteAsyncConnection(dbPath);
            _dbConnection.CreateTableAsync<Note>().Wait();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return await _dbConnection.Table<Note>().ToListAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _dbConnection.Table<Note>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return await _dbConnection.UpdateAsync(note);
            }
            else
            {
                return await _dbConnection.InsertAsync(note);
            }
        }

        public async Task<int> DeleteNoteAsync(Note note)
        {
            return await _dbConnection.DeleteAsync(note);
        }
    }
}
