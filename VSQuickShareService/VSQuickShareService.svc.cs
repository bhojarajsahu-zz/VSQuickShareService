using System;
using System.Data;
using System.Data.SqlClient;
using VSQuickShareService.Model;

namespace VSQuickShareService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class VSQuickShareService : IService
    {
        ErrorModel errorModel;
        string connectionString = string.Empty;
        public string GetShareKey(string sharedKey, out ErrorModel errorModel)
        {
            errorModel = new ErrorModel();
            string searchResult = string.Empty;
            string sqlstatement = null;
            DataSet objDataSet = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                connectionString = UtilityOperations.getConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    //sqlstatement = @"select * from login_info where userid = '" + userId + "' and userpassword='" + password + "' and Status = 'ACTIVE'";// Check user login details
                    sqlstatement = @"SELECT * FROM VSQuickShare where ShareId = " + Convert.ToInt32(sharedKey) + " and ShareStatus = 1";
                    cmd.CommandText = sqlstatement;

                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;
                    da.Fill(objDataSet);
                    con.Close();
                }
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = objDataSet.Tables[0].Rows[0];
                    //byte[] resultArray = Encoding.ASCII.GetBytes((byte[])dr["ShareCode"]);
                    searchResult = Convert.ToString(dr["ShareCode"]);
                }
            }
            catch (Exception ex)
            {
                errorModel.ErrorCode = Convert.ToString(ex.Source);
                errorModel.ErrorMessage = Convert.ToString(ex.Message);
            }
            return searchResult;
        }
        public string AddSharedCode(string userId, string code, string uniqueCode, out ErrorModel errorModel)
        {
            errorModel = new ErrorModel();
            string sqlstatement = null;
            int status = 0;
            string shareId = string.Empty;
            DataSet objDataSet = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                connectionString = UtilityOperations.getConnectionString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                   // byte[] dataArray = Encoding.ASCII.GetBytes(code);

                    con.Open();
                    sqlstatement = @"insert into VSQuickShare (UserId,ShareCode,ShareUniqueCode,ShareStatus) 
                            values ('" + userId + "', @Code,'" + uniqueCode + "',1);SELECT SCOPE_IDENTITY();";// Check user login details

                    cmd.CommandText = sqlstatement;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@Code", SqlDbType.VarChar);
                    cmd.Parameters["@Code"].Value = code;

                    var result = cmd.ExecuteScalar();
                    status = Convert.ToInt32(result);
                    con.Close();
                    shareId = Convert.ToString(status);
                }
            }
            catch (Exception ex)
            {
                errorModel.ErrorCode = Convert.ToString(ex.Source);
                errorModel.ErrorMessage = Convert.ToString(ex.Message);
            }
            return shareId;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public string GetData(int value)
        {
            throw new NotImplementedException();
        }
    }
}
