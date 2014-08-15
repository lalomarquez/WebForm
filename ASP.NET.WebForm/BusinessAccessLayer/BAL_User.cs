using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = BussinesObject;
using DAL = DataAccessLayer;

namespace BusinessAccessLayer
{
    public class BAL_User
    {
        DAL.DAL_User uDAL = new DAL.DAL_User();            
        //SCRUD
        #region Search "S"  
        public DataTable SearchBAL(BO.BO_User uBO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = uDAL.SearchDAL(uBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt.Dispose();
            }
            return dt;
        }
        #endregion
        #region Insert "C"
        public int CreateBAL(BO.BO_User uBO)
        {            
            try
            {
                return uDAL.CreteDAL(uBO);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                uDAL = null;
            }
        }
        #endregion
        #region Read "R"   
        public DataSet ReadBAL()
        {
            DataSet ds = new DataSet();            
            try
            {
                ds =uDAL.ReadRecordsDAL();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        #endregion
        #region Update "U"    
        public int UpdateBAL(BO.BO_User uBO)
        {
            try
            {
                return uDAL.UpdateDAL(uBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                uDAL = null;
            }
        }    
        #endregion
        #region Delete "D" 
        public int DeleteBAL(BO.BO_User uBO)
        {
            try
            {
                return uDAL.DeleteDAL(uBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                uDAL = null;
            }
        }
        #endregion


    }
}
