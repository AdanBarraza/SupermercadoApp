using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace SupermercadoApp.Data
{
    internal class Datos
    {
        // Ajusta el puerto si usaste otro; aquí usamos 5433
        private readonly string _cs =
            "Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=db_supermercado";

        // INSERT / UPDATE / DELETE
        public bool ExecuteQuery(string sql)
        {
            try
            {
                using var conn = new NpgsqlConnection(_cs);
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch
            {
                return false; // estilo Octubre: simple
            }
        }

        // SELECT → DataTable
        public DataTable GetDataTable(string sql)
        {
            var dt = new DataTable();
            using var conn = new NpgsqlConnection(_cs);
            conn.Open();
            using var da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
    }
}

