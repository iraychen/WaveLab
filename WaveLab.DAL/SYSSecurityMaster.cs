using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
   public class SYSSecurityMaster:AdoDaoSupport,ISYSSecurityMaster
   {
        #region For Login
        public bool CheckExists(string userId)
       {
           bool retVal;
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select count(*) from SYS_security_master where upper(user_id)=upper(@user_id)");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

           int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           if (recordCount > 0)
           {
               retVal = true;
           }
           else
           {
               retVal = false;
           }
           return retVal;
       }

        public bool CheckPWD(string userId, string encryptPassWord)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_security_master where upper(user_id)=upper(@user_id) and upper(password)=upper(@password)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);
            paras.Create().Name("password").Type(DbType.String).Size(50).Value(encryptPassWord);

            int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (recordCount > 0)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool CheckActive(string userId)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_security_master where upper(user_id)=upper(@user_id) and active='Y'");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

            int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (recordCount > 0)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool IsAdmin(string userId)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_security_master where upper(user_id)=upper(@user_id) and admin='Y'");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

            int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (recordCount > 0)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public IList<int> GetACMenu(string userId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct menu_id");
            cmdText.Append(" FROM ");
            cmdText.Append("        (SELECT t.menu_id   ");
            cmdText.Append("        FROM    SYS_menus t ");
            cmdText.Append("        WHERE   upper(t.enabled)=UPPER('Y') ");
            cmdText.Append("            AND EXISTS ");
            cmdText.Append("                (SELECT 'x' ");
            cmdText.Append("                FROM    SYS_role_menu_mapping ");
            cmdText.Append("                WHERE   menu_id=t.menu_id ");
            cmdText.Append("                    AND role_id  in ");
            cmdText.Append("                        ( SELECT b.role_id ");
            cmdText.Append("                          FROM   SYS_security_master a,SYS_master_role_mapping b");
            cmdText.Append("                          WHERE  a.user_id=b.user_id and upper(a.user_id)=upper(@user_id) ");
            cmdText.Append("                          AND a.admin ='N' ");
            cmdText.Append("                        ) ");
            cmdText.Append("                ) ");
            cmdText.Append("         ");
            cmdText.Append("        UNION ");
            cmdText.Append("         ");
            cmdText.Append("        SELECT  menu_id  ");
            cmdText.Append("        FROM    SYS_menus ");
            cmdText.Append("        WHERE   upper(enabled)=UPPER('Y') ");
            cmdText.Append("            AND EXISTS ");
            cmdText.Append("                (SELECT 'x' ");
            cmdText.Append("                FROM   SYS_security_master  ");
            cmdText.Append("                WHERE   upper(user_id)=upper(@user_id) ");
            cmdText.Append("                    AND admin='Y' ");
            cmdText.Append("                ) ");
            cmdText.Append("        ) userSYS_menus");
            cmdText.Append(" where 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

            return AdoTemplate.QueryWithRowMapperDelegate<int>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                return Convert.ToInt32(reader["menu_id"]);
            },paras.GetParameters());
        }


       #endregion

        #region  Basic Operation
        public IList<SYSSecurityMasterInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  user_id,user_name,section_id,");
            cmdText.Append("(select section_desc from SYS_section_list where section_id=a.section_id) section_desc,active,admin ");
            cmdText.Append(" FROM   SYS_security_master a ");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND upper(a." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                cmdText.Append(" order by ");
                cmdText.Append(sortBy);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                cmdText.Append(" ");
                cmdText.Append(orderBy);
            }
            return AdoTemplate.QueryWithRowMapperDelegate<SYSSecurityMasterInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSSectionInfo sectionItem = new SYSSectionInfo()
                {
                    SectionId = Convert.ToString(reader["section_id"]),
                    SectionDesc = Convert.ToString(reader["section_desc"])
                };
                SYSSecurityMasterInfo item = new SYSSecurityMasterInfo();
                item.UserId = Convert.ToString(reader["user_id"]);
                item.UserName = Convert.ToString(reader["user_name"]);
                item.Admin = Convert.ToString(reader["admin"]);
                item.Active = Convert.ToString(reader["active"]);
                item.SectionItem = sectionItem;
                return item;
            }, paras.GetParameters());
        }

        public void Save(SYSSecurityMasterInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SYS_security_master");
            cmdText.Append("(");
            cmdText.Append("user_id,last_update_date,last_updated_by,creation_date,created_by,password,user_name,admin,active,section_id");
            cmdText.Append(")");
            cmdText.Append("values");
            cmdText.Append("(");
            cmdText.Append("@user_id,@last_update_date,@last_updated_by,@creation_date,@created_by,@password,@user_name,@admin,@active,@section_id");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(entity.UserId);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("password").Type(DbType.String).Size(50).Value(entity.PassWord);
            paras.Create().Name("user_name").Type(DbType.String).Size(50).Value(entity.UserName);
            paras.Create().Name("admin").Type(DbType.String).Size(50).Value(entity.Admin);
            paras.Create().Name("active").Type(DbType.String).Size(50).Value(entity.Active);
            paras.Create().Name("section_id").Type(DbType.String).Size(50).Value(entity.SectionItem.SectionId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SYSSecurityMasterInfo GetDetail(string userId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select user_id,user_name,password,last_update_date,last_updated_by ,section_id,");
            cmdText.Append(" (select section_desc from SYS_section_list where section_id=t.section_id) section_desc,");
            cmdText.Append(" active,admin");
            cmdText.Append(" from SYS_security_master t ");
            cmdText.Append(" where upper(user_id)=upper(@user_id)");

            return AdoTemplate.QueryForObjectDelegate<SYSSecurityMasterInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSSectionInfo sectionItem = new SYSSectionInfo()
                {
                    SectionId = Convert.ToString(reader["section_id"]),
                    SectionDesc = Convert.ToString(reader["section_desc"])
                };

                SYSSecurityMasterInfo entity = new SYSSecurityMasterInfo();
                entity.UserId = Convert.ToString(reader["user_id"]);
                entity.PassWord = Convert.ToString(reader["password"]);
                entity.UserName = Convert.ToString(reader["user_name"]);
                entity.Admin = Convert.ToString(reader["admin"]);
                entity.Active = Convert.ToString(reader["active"]);
                entity.SectionItem = sectionItem;

                return entity;
            }, paras.GetParameters());
        }

        public void Update(SYSSecurityMasterInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SYS_security_master set ");
            cmdText.Append(" last_update_date=@last_update_date,");
            cmdText.Append(" last_updated_by=@last_updated_by,");
            cmdText.Append(" password=@password,");
            cmdText.Append(" user_name=@user_name,");
            cmdText.Append(" admin=@admin,");
            cmdText.Append(" active=@active,");
            cmdText.Append(" section_id=@section_id");
            cmdText.Append(" where upper(user_id)=upper(@user_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("password").Type(DbType.String).Size(50).Value(entity.PassWord);
            paras.Create().Name("user_name").Type(DbType.String).Size(50).Value(entity.UserName);
            paras.Create().Name("admin").Type(DbType.String).Size(50).Value(entity.Admin);
            paras.Create().Name("active").Type(DbType.String).Size(50).Value(entity.Active);
            paras.Create().Name("section_id").Type(DbType.String).Size(50).Value(entity.SectionItem.SectionId);
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(entity.UserId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SYSRoleInfo> GetRoles(string userId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select role_id,role_desc from SYS_role_list t ");
            cmdText.Append(" where exists ( ");
            cmdText.Append(" select 'x' from SYS_master_role_mapping ");
            cmdText.Append(" where role_id=t.role_id ");
            cmdText.Append(" and upper(user_id)=upper(@user_id)");
            cmdText.Append(" ) ");

            return  AdoTemplate.QueryWithRowMapperDelegate<SYSRoleInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSRoleInfo item = new SYSRoleInfo()
                {
                    RoleId = Convert.ToInt32(reader["role_id"]),
                    RoleDesc = Convert.ToString(reader["role_desc"])
                };
                return item;
            }, paras.GetParameters());
        }

        public void SaveRoleMapping(string userId, IList<SYSRoleInfo> roleItems)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_master_role_mapping where upper(user_id)=upper(@user_id) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

            foreach (SYSRoleInfo roleItem in roleItems)
            {

                StringBuilder roleCmdText = new StringBuilder();
                roleCmdText.Append(" insert into SYS_master_role_mapping(user_id,role_id,creation_date,created_by,last_update_date,last_updated_by) values( ");
                roleCmdText.Append(" @user_id,@role_id,@creation_date,@created_by,@last_update_date,@last_updated_by)");

                IDbParametersBuilder param = base.CreateDbParametersBuilder();
                param.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);
                param.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleItem.RoleId);
                param.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(roleItem.CreationDate);
                param.Create().Name("created_by").Type(DbType.String).Size(50).Value(roleItem.CreatedBy);
                param.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(roleItem.LastUpdateDate);
                param.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(roleItem.LastUpdatedBy);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, roleCmdText.ToString(), param.GetParameters());
            }
        }

        public bool CheckPerm(string userId,string op)
        {
            bool retVal;
            if (this.IsAdmin(userId) == true)
            {
                retVal = true;
            }
            else
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append("select count(*) from SYS_security_master a inner join SYS_Master_Role_Mapping b on a.user_id=b.user_id ");
                cmdText.Append("inner join SYS_Role_List c on b.role_id=c.role_id  ");
                cmdText.Append("where upper(a.user_id)=upper(@user_id) and c." + op + "=1");


                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);

                int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
                if (recordCount > 0)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            return retVal;
        }
        #endregion
   }
}
