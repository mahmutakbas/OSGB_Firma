﻿using Dapper;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dapper
{
    public class EtkinlikGorevliileriDal : IEtkinlikGorevlileriDal
    {
        public  int Add(EtkinlikGorevlileri entity)
        {
            string query = "INSERT INTO public.etkinlik_gorevlileri(personelid, yetki,etkinlikziyaretid)VALUES (@personelid, @yetki,@etkinlikziyaretid);";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }

        public  int Delete(int id)
        {
            string query = "DELETE FROM public.etkinlik_gorevlileri WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query,new { id = id });
                return result;
            }
        }

        public  List<EtkinlikGorevlileri> GetAll()
        {
            string query = "SELECT * FROM public.etkinlik_gorevlileri; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Query<EtkinlikGorevlileri>(query);
                return result.AsList();
            }
        }

   

        public  EtkinlikGorevlileri GetById(int id)
        {
            string query = "SELECT * FROM public.etkinlik_gorevlileri WHERE id=@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.QueryFirst<EtkinlikGorevlileri>(query, id);
                return result;
            }
        }

        public List<EtkinlikGorevliDto> GetDtos(string personelAdi, int ziyaretId)
        {
            string query = "SELECT p.adi,p.soyadi,e.yetki FROM public.etkinlik_gorevlileri e INNER JOIN public.personel p ON e.personelid = p.id  WHERE p.adi LIKE CONCAT('%',@adi,'%') AND etkinlikziyaretid=@etkinlikziyaretid; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result = connection.Query<EtkinlikGorevliDto>(query, new { adi=personelAdi, etkinlikziyaretid =ziyaretId
                });
                return result.AsList();
            }
        }

        public  int Update(EtkinlikGorevlileri entity)
        {
            string query = "UPDATE public.etkinlik_gorevlileri SET personelid =@personelid, yetki =@yetki, etkinlikziyaretid =@etkinlikziyaretid WHERE id =@id; ";
            using (var connection = new NpgsqlConnection(OsgbContext.ConnectionString))
            {
                connection.Open();
                var result =  connection.Execute(query, entity);
                return result;
            }
        }
    }
}
