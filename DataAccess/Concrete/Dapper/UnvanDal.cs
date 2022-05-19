﻿using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class UnvanDal : IUnvanDal
    {
        public async Task<int> AddAsync(Unvan entity)
        {
            var query = "INSERT INTO unvan (unvanadi) VALUES (@UnvanAdi);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.unvan WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, new {id= id });
                return result;
            }
        }

        public async Task<List<Unvan>> GetAllAsync()
        {
            string query = "SELECT id, unvanadi FROM public.unvan;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Unvan>(query);
                return result.AsList();
            }
        }

        public async Task<Unvan> GetByIdAsync(int id)
        {
            string query = "SELECT id, unvanadi FROM public.unvan WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Unvan>(query, id);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Unvan entity)
        {
            string query = "UPDATE public.unvan SET unvanadi = @UnvanAdi WHERE id = @id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
