using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WaveLab.Model;

namespace WaveLab.DAL
{
   //public sealed class AdLog
   // {

   //     private static readonly string sql  = "insert into ad_log " +
   //         " (last_update_date,last_updated_by,auditcategory,logmode,logdesc,tablename,columnname,logkey) " +
   //         "values" +
   //         " (@last_update_date,@last_updated_by,@auditcategory,@logmode,@logdesc,@tablename,@columnname,@logkey) ";

   //     public static void Save(ref SqlTransaction trans, AdLogInfo log)
   //     {
   //         SqlParameter[] paras = { 
   //                  new SqlParameter("@last_update_date",SqlDbType.DateTime), 
   //                  new SqlParameter("@last_updated_by",SqlDbType.NVarChar), 
   //                  new SqlParameter("@auditcategory",SqlDbType.NVarChar), 
   //                  new SqlParameter("@logmode",SqlDbType.NVarChar), 
   //                  new SqlParameter("@logdesc",SqlDbType.NVarChar), 
   //                  new SqlParameter("@tablename",SqlDbType.NVarChar), 
   //                  new SqlParameter("@columnname",SqlDbType.NVarChar), 
   //                  new SqlParameter("@logkey",SqlDbType.NVarChar) 
   //              };

   //         paras[6].IsNullable = true;

   //         paras[0].Value= log.LastUpdateDate;
   //         paras[1].Value =log.LastUpdatedBy;
   //         paras[2].Value  =log.AuditCategory;
   //         paras[3].Value =log.LogMode;
   //         paras[4].Value  =log.LogDesc;
   //         paras[5].Value  =log.TableName;
   //         paras[6].Value  =log.ColumnName;
   //         paras[7].Value = log.LogKey;
   //         SqlHelper.ExecuteNonQuery(trans,CommandType.Text, sql, paras);
   //       }
   // }
}
