using Dapper;
using Latihan1.Config;
using Latihan1.Models;
using System.Data.SqlClient;
using System.Linq;

namespace Latihan1.DAO
{
    public class MemberDAO
    {
        public List<MemberModel> GetAllMember()
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.koneksi))
            {
                try
                {
                    string query = @"SELECT * FROM MEMBER";

                    var data = conn.Query<MemberModel>(query).ToList();

                    return data;
                }
                catch (Exception ex)
                {
                    return new List<MemberModel>();
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public bool InsertMember(MemberModel dataMember)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.koneksi))
            {
                try
                {
                    string query = @"INSERT INTO MEMBER (NAME, DESCRIPTION)
                                    VALUES (@Name, @Description)";

                    conn.Execute(query, dataMember);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public MemberModel GetMemberById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.koneksi))
            {
                try
                {
                    string query = @"SELECT * FROM MEMBER WHERE ID = @ID";

                    MemberModel data = conn.QueryFirstOrDefault<MemberModel>(query, new { ID = id });

                    return data;
                }
                catch (Exception ex)
                {
                    return new MemberModel();
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public bool UpdateMember(MemberModel memberData)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.koneksi))
            {
                try
                {
                    string query = @"UPDATE MEMBER SET NAME = @NAME, DESCRIPTION = @DESCRIPTION WHERE ID = @ID";

                    conn.Execute(query, memberData);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public bool DeleteMember(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.koneksi))
            {
                try
                {
                    string query = @"DELETE FROM MEMBER WHERE ID = @ID";

                    conn.Execute(query, new { ID = id});

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
    }
}
