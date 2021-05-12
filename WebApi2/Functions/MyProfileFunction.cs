using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi2.Helper;
using WebApi2.Models;

namespace WebApi2.Functions
{
    public class MyProfileFunction
    {
        public bool SaveMyProfile(MyProfileModel data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@first_name", data.first_name);
                    param.Add("@last_name", data.last_name);
                    conn.Execute("SPInsertMyProfile", param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetMyProfile(out List<MyProfileModel> data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString()))
                {
                    data = conn.Query<MyProfileModel>("SPGetMyProfile", commandType: CommandType.StoredProcedure).ToList();

                    return true;
                }
            }
            catch (Exception)
            {
                data = null;
                return false;
            }
        }

        public bool DeleteMyProfile(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", id);
                    conn.Execute("SPDeleteMyProfile", param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateMyProfile(MyProfileModel data, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", id);
                    param.Add("@first_name", data.first_name);
                    param.Add("@last_name", data.last_name);
                    conn.Execute("SPUpdateMyProfile", param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}