using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tedon.Web.Models;
using Dapper;

namespace Tedon.Web.Data
{
    public class BoardService 
    {

        private string connectionString = Startup.Configuration.GetConnectionString("Tedon");

        public List<Board> Get()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<Board>(
                    "dbo.usp_board_get",
                    new { },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Board Get(int idx)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<Board>(
                    "dbo.usp_board_get",
                    new { idx = idx },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Board> List()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<Board>(
                    "dbo.usp_board_list",
                    new { },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Add(Board board)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Execute(
                    "dbo.usp_board_set",
                    new {
                        Title = board.Title,
                        Body = board.Body
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int Update(Board board)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Execute(
                    "dbo.usp_board_upd",
                    new {
                        Idx = board.Idx,
                        Title = board.Title,
                        Body = board.Body
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int Delete(int idx)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Execute(
                    "dbo.usp_board_del",
                    new {
                        Idx = idx
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
