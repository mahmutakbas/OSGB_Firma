﻿using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikGorevleriDal : IEtkinlikGorevleriDal
    {
        public Task<int> AddAsync(EtkinlikGorevleri entity)
        {
            string query = "INSERT INTO etkinlik_gorevleri (etkinlikid, islemid, aciklama, tarih) VALUES(@etkinlikid, @islemid, @aciklama, @tarih); ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM public.etkinlik_gorevleri WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, id);
                return result;
            }
        }

        public async Task<List<EtkinlikGorevleri>> GetAllAsync()
        {
            string query = "SELECT * FROM public.etkinlik_gorevleri";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<EtkinlikGorevleri>(query);
                return result.AsList();
            }
        }

        public async Task<EtkinlikGorevleri> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM public.etkinlik_gorevleri WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<EtkinlikGorevleri>(query,id);
                return result;
            }
        }

        public Task<int> UpdateAsync(EtkinlikGorevleri entity)
        {
            string query = "UPDATE public.etkinlik_gorevleri SET etkinlikid =@etkinlikid, islemid =@islemid , aciklama =@aciklama, tarih =@tarih WHERE id=@id;";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.ExecuteAsync(query, entity);
                return result;
            }
        }
    }
}
