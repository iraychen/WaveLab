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
    public class SPCTxMaskFlat :  AdoDaoSupport, ISPCTxMaskFlat
    {
        public IList<SPCTxMaskFlatItemInfo> Query(Hashtable hashTable, string sortby, string orderby)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct d.model as type,b.mode,b.ch ");
            cmdText.Append(" FROM  nt_tx_maskflat_list a ");
            cmdText.Append(" inner join nt_tx_maskflat_detail b on a.nt_tx_maskflat_id=b.nt_tx_maskflat_id");
            cmdText.Append(" inner join barcode_list c on a.serial_no=c.serial_no");
            cmdText.Append(" inner join label_code d on c.code=d.code and c.model=d.model");
            cmdText.Append(" WHERE  1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(d.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            cmdText.Append(" order by ");
            cmdText.Append(sortby);
            cmdText.Append(" ");
            cmdText.Append(orderby);

            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatItemInfo item = new SPCTxMaskFlatItemInfo();
                item.Type = Convert.ToString(reader["type"]);
                item.Mode = Convert.ToString(reader["mode"]);
                item.CH = Convert.ToString(reader["ch"]);           
                return item;
            }, paras.GetParameters());
        }      

        public IList<SPCTxMaskFlatDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.serial_no,a.end_time,b.mask_flat as val ");
            cmdText.Append(" FROM  nt_tx_maskflat_list a ");
            cmdText.Append(" inner join nt_tx_maskflat_detail b on a.nt_tx_maskflat_id=b.nt_tx_maskflat_id");
            cmdText.Append(" inner join barcode_list c on a.serial_no=c.serial_no");
            cmdText.Append(" inner join label_code d on c.code=d.code and c.model=d.model");
            cmdText.Append(" WHERE  1=1");


            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(d.model) = upper(@" + entry.Key + ")");
                        break;
                    case "mode":
                        cmdText.Append(" AND upper(b.mode) = upper(@" + entry.Key + ")");
                        break;
                    case "ch":
                        cmdText.Append(" AND upper(b.ch) = upper(@" + entry.Key + ")");
                        break;
                    case "pw":
                        cmdText.Append(" AND upper(b.pw) = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }
            cmdText.Append(" order by ");
            cmdText.Append(sortby);
            cmdText.Append(" ");
            cmdText.Append(orderby);
            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatDetail>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatDetail item = new SPCTxMaskFlatDetail();
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.EndTime = Convert.ToDateTime(reader["end_time"]);
                item.Val = Convert.ToString(reader["val"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<SPCTxMaskFlatDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct serial_no,end_time,val ");
            cmdText.Append(" FROM  spc_tx_maskflat_generate ");
            cmdText.Append(" WHERE 1=1 ");


            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) = upper(@" + entry.Key + ")");
                        break;
                    case "mode":
                        cmdText.Append(" AND upper(mode) = upper(@" + entry.Key + ")");
                        break;
                    case "ch":
                        cmdText.Append(" AND upper(ch) = upper(@" + entry.Key + ")");
                        break;                  
                    case "date_from":
                        cmdText.Append(" AND testing_day >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND testing_day<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }
            cmdText.Append(" order by ");
            cmdText.Append(sortby);
            cmdText.Append(" ");
            cmdText.Append(orderby);
            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatDetail>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatDetail item = new SPCTxMaskFlatDetail();
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.EndTime = Convert.ToDateTime(reader["end_time"]);
                item.Val = Convert.ToString(reader["val"]);
                return item;
            }, paras.GetParameters());
        }

        public int Save(SPCTxMaskFlatInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" declare @Tx_MaskFlat_PK int;");

            cmdText.Append(" INSERT INTO SPC_Tx_MaskFlat(");
            cmdText.Append(" Type,Mode,CH,Date_From,Date_To,Grouping_No,X,R,S,USL,");
            cmdText.Append(" CPU,CPL,CPK,CL_X,UCL_X,LCL_X,CL_R,UCL_R,LCL_R,Last_Update_Date,Last_Updated_By)");
            cmdText.Append(" VALUES");
            cmdText.Append(" (@Type,@Mode,@CH,@Date_From,@Date_To,@Grouping_No,@X,@R,@S,@USL,");
            cmdText.Append(" @CPU,@CPL,@CPK,@CL_X,@UCL_X,@LCL_X,@CL_R,@UCL_R,@LCL_R,@Last_Update_Date,@Last_Updated_By);");

            paras.Create().Name("Type").Type(DbType.String).Size(50).Value(entity.Type);
            paras.Create().Name("Mode").Type(DbType.String).Size(50).Value(entity.Mode);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(entity.CH);          
            paras.Create().Name("Date_From").Type(DbType.DateTime).Size(4).Value(entity.DateFrom);
            paras.Create().Name("Date_To").Type(DbType.DateTime).Size(4).Value(entity.DateTo);
            paras.Create().Name("Grouping_No").Type(DbType.Int32).Size(4).Value(entity.GroupingNo);
            paras.Create().Name("X").Type(DbType.Double).Size(8).Value(entity.X);
            paras.Create().Name("R").Type(DbType.Double).Size(8).Value(entity.R);
            paras.Create().Name("S").Type(DbType.Double).Size(8).Value(entity.S);
            paras.Create().Name("USL").Type(DbType.Double).Size(8).Value(entity.USL);
            paras.Create().Name("CPU").Type(DbType.Double).Size(8).Value(entity.CPU);
            paras.Create().Name("CPL").Type(DbType.Double).Size(8).Value(entity.CPL);
            paras.Create().Name("CPK").Type(DbType.Double).Size(8).Value(entity.CPK);
            paras.Create().Name("CL_X").Type(DbType.Double).Size(8).Value(entity.CL_X);
            paras.Create().Name("UCL_X").Type(DbType.Double).Size(8).Value(entity.UCL_X);
            paras.Create().Name("LCL_X").Type(DbType.Double).Size(8).Value(entity.LCL_X);
            paras.Create().Name("CL_R").Type(DbType.Double).Size(8).Value(entity.CL_R);
            paras.Create().Name("UCL_R").Type(DbType.Double).Size(8).Value(entity.UCL_R);
            paras.Create().Name("LCL_R").Type(DbType.Double).Size(8).Value(entity.LCL_R);

            cmdText.Append(" SELECT @Tx_MaskFlat_PK=SCOPE_IDENTITY();");

            for (int i = 0; i < entity.OriginalItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Tx_MaskFlat_Detail");
                cmdText.Append(" (Tx_MaskFlat_PK,Group_No,Serial_No ,End_Time ,Val,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES(@Tx_MaskFlat_PK,@Original_Group_No_" + i.ToString() + ",@Serial_No_" + i.ToString() + " ,@End_Time_" + i.ToString() + " ,@Val_" + i.ToString() + ",@Last_Update_Date,@Last_Updated_By)");

                paras.Create().Name("Original_Group_No_" + i.ToString()).Type(DbType.Int32).Size(4).Value(entity.OriginalItems[i].GroupNo);
                paras.Create().Name("Serial_No_" + i.ToString()).Type(DbType.String).Size(50).Value(entity.OriginalItems[i].SerialNo);
                paras.Create().Name("End_Time_" + i.ToString()).Type(DbType.DateTime).Size(4).Value(entity.OriginalItems[i].EndTime);
                paras.Create().Name("Val_" + i.ToString()).Type(DbType.Double).Size(8).Value(entity.OriginalItems[i].Val);
            }

            for (int i = 0; i < entity.GroupItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Tx_MaskFlat_Group");
                cmdText.Append(" (Tx_MaskFlat_PK,Group_No,X,R,Take_Part_In,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@Tx_MaskFlat_PK,@Group_No_" + i.ToString() + ",@X_Group_" + i.ToString() + ",@R_Group_" + i.ToString() + ",@Take_Part_In_" + i.ToString() + ",@Last_Update_Date,@Last_Updated_By)");

                paras.Create().Name("Group_No_" + i.ToString()).Type(DbType.Int32).Size(4).Value(entity.GroupItems[i].GroupNo);
                paras.Create().Name("X_Group_" + i.ToString()).Type(DbType.Double).Size(8).Value(entity.GroupItems[i].X);
                paras.Create().Name("R_Group_" + i.ToString()).Type(DbType.Double).Size(8).Value(entity.GroupItems[i].R);
                paras.Create().Name("Take_Part_In_" + i.ToString()).Type(DbType.StringFixedLength).Size(1).Value(entity.GroupItems[i].TakePartIn);
            }

            for (int i = 0; i < entity.ExceptionItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Tx_MaskFlat_Exception");
                cmdText.Append(" (Tx_MaskFlat_PK,Group_No,Chart_Type,Comment,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@Tx_MaskFlat_PK,@Group_No_Exception_" + i.ToString() + ",@Chart_Type_" + i.ToString() + ",@Comment_" + i.ToString() + ",@Last_Update_Date,@Last_Updated_By)");

                paras.Create().Name("Group_No_Exception_" + i.ToString()).Type(DbType.Int32).Size(4).Value(entity.ExceptionItems[i].GroupNo);
                paras.Create().Name("Chart_Type_" + i.ToString()).Type(DbType.StringFixedLength).Size(1).Value(entity.ExceptionItems[i].ChartType);
                paras.Create().Name("Comment_" + i.ToString()).Type(DbType.String).Size(100).Value(entity.ExceptionItems[i].Comment);
            }
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(DateTime.Now);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(System.Web.HttpContext.Current.User.Identity.Name);

            cmdText.Append("Select @Tx_MaskFlat_PK");

            //AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM spc_tx_maskflat");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) = upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "mode":
                        cmdText.Append(" AND upper(mode) = upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "ch":
                        cmdText.Append(" AND ch = @" + entry.Key);
                        break;                
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),last_update_date,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),last_update_date,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCTxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" tx_maskflat_pk,type, mode,ch,date_from,date_to,last_update_date");
            cmdText.Append(" FROM spc_tx_maskflat");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) = upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "mode":
                        cmdText.Append(" AND upper(mode) = upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "ch":
                        cmdText.Append(" AND ch = @" + entry.Key);
                        break;                 
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),last_update_date,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),last_update_date,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatInfo item = new SPCTxMaskFlatInfo();
                item.TxMaskFlatPK = Convert.ToInt32(reader["tx_maskflat_pk"]);
                item.Type = Convert.ToString(reader["type"]);
                item.Mode = Convert.ToString(reader["mode"]);
                item.CH = Convert.ToString(reader["ch"]);
                item.DateFrom = Convert.ToDateTime(reader["date_from"]);
                item.DateTo = Convert.ToDateTime(reader["date_to"]);
                item.LastUpdateDate = Convert.ToDateTime(reader["last_update_date"]);
                return item;
            }, paras.GetParameters());
        }

        public SPCTxMaskFlatInfo GetDetail(int TxMaskFlatPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("tx_maskflat_pk").Type(DbType.Int32).Size(4).Value(TxMaskFlatPK);

            StringBuilder OriginalCmdText = new StringBuilder();
            OriginalCmdText.Append(" SELECT group_no,serial_no,end_time,val ");
            OriginalCmdText.Append(" FROM spc_tx_maskflat_detail ");
            OriginalCmdText.Append(" WHERE tx_maskflat_pk=@tx_maskflat_pk");
            OriginalCmdText.Append(" ORDER BY group_no");

            IList<SPCTxMaskFlatDetail> OriginalItems = AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatDetail>(CommandType.Text, OriginalCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatDetail item = new SPCTxMaskFlatDetail();
                item.GroupNo = Convert.ToInt32(reader["group_no"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.EndTime = Convert.ToDateTime(reader["end_time"]);
                item.Val = Convert.ToString(reader["val"]);
                return item;
            }, paras.GetParameters());

            StringBuilder GroupCmdText = new StringBuilder();
            GroupCmdText.Append(" SELECT tx_maskflat_pk,group_no,x,r,take_part_in ");
            GroupCmdText.Append(" FROM spc_tx_maskflat_group ");
            GroupCmdText.Append(" WHERE tx_maskflat_pk=@tx_maskflat_pk");
            GroupCmdText.Append(" AND take_part_in='Y'");
            GroupCmdText.Append(" ORDER BY group_no");

            IList<SPCTxMaskFlatGroup> GroupItems = AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatGroup>(CommandType.Text, GroupCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatGroup item = new SPCTxMaskFlatGroup();
                item.TxMaskFlatPK = Convert.ToInt32(reader["tx_maskflat_pk"]);
                item.GroupNo = Convert.ToInt32(reader["group_no"]);
                item.X = Convert.ToDouble(reader["x"]);
                item.R = Convert.ToDouble(reader["r"]);
                item.TakePartIn = Convert.ToChar(reader["take_part_in"]);
                return item;
            }, paras.GetParameters());

            StringBuilder ExceptionCmdText = new StringBuilder();
            ExceptionCmdText.Append(" SELECT group_no,chart_type,comment ");
            ExceptionCmdText.Append(" FROM spc_tx_maskflat_exception ");
            ExceptionCmdText.Append(" WHERE tx_maskflat_pk=@tx_maskflat_pk");
            ExceptionCmdText.Append(" ORDER BY group_no");

            IList<SPCTxMaskFlatException> ExceptionItems = AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatException>(CommandType.Text, ExceptionCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
                item.GroupNo = Convert.ToInt32(reader["group_no"]);
                item.ChartType = Convert.ToChar(reader["chart_type"]);
                item.Comment = Convert.ToString(reader["comment"]);
                return item;
            }, paras.GetParameters());


            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Tx_MaskFlat_PK,Type,Mode,CH,Date_From,Date_To ,Grouping_No,");
            cmdText.Append(" X,R,S,USL,CPU,CPL,CPK,CL_X,UCL_X,LCL_X,CL_R,UCL_R,LCL_R,Last_Update_Date,Last_Updated_By");
            cmdText.Append(" FROM spc_tx_maskflat ");
            cmdText.Append(" WHERE tx_maskflat_pk=@tx_maskflat_pk");

            return AdoTemplate.QueryForObjectDelegate<SPCTxMaskFlatInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatInfo entity = new SPCTxMaskFlatInfo();
                entity.TxMaskFlatPK = Convert.ToInt32(reader["tx_maskflat_pk"]);
                entity.Type = Convert.ToString(reader["type"]);
                entity.Mode = Convert.ToString(reader["mode"]);
                entity.CH = Convert.ToString(reader["ch"]);             
                entity.DateFrom = Convert.ToDateTime(reader["date_from"]);
                entity.DateTo = Convert.ToDateTime(reader["date_to"]);
                entity.GroupingNo = Convert.ToInt32(reader["grouping_no"]);
                entity.X = Convert.ToDouble(reader["x"]);
                entity.R = Convert.ToDouble(reader["r"]);
                entity.S = Convert.ToDouble(reader["s"]);
                if (reader["usl"] != null) { entity.USL = Convert.ToDouble(reader["usl"]); }
                if (reader["cpu"] != null) { entity.CPU = Convert.ToDouble(reader["cpu"]); }
                if (reader["cpl"] != null) { entity.CPL = Convert.ToDouble(reader["cpl"]); }
                entity.CPK = Convert.ToDouble(reader["cpk"]);
                entity.LCL_X = Convert.ToDouble(reader["lcl_x"]);
                entity.CL_X = Convert.ToDouble(reader["cl_x"]);
                entity.UCL_X = Convert.ToDouble(reader["ucl_x"]);
                entity.LCL_R = Convert.ToDouble(reader["lcl_r"]);
                entity.CL_R = Convert.ToDouble(reader["cl_r"]);
                entity.UCL_R = Convert.ToDouble(reader["ucl_r"]);
                entity.LastUpdateDate = Convert.ToDateTime(reader["last_update_date"]);
                entity.LastUpdatedBy = Convert.ToString(reader["last_updated_by"]);

                entity.OriginalItems = OriginalItems;
                entity.GroupItems = GroupItems;
                entity.ExceptionItems = ExceptionItems;
                return entity;
            }, paras.GetParameters());
        }

        public int GetAutoLatest(string type, string mode, string ch)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("type").Type(DbType.String).Size(50).Value(type);
            paras.Create().Name("mode").Type(DbType.String).Size(50).Value(mode);
            paras.Create().Name("ch").Type(DbType.String).Size(50).Value(ch);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Tx_MaskFlat_PK");
            cmdText.Append(" FROM SPC_Tx_MaskFlat");
            cmdText.Append(" WHERE type=@type AND mode=@mode AND ch=@ch  and auto='Y'");
            cmdText.Append(" and date_to=(");
            cmdText.Append(" select max(date_to) from SPC_Tx_MaskFlat ");
            cmdText.Append(" where type=@type AND mode=@mode AND ch=@ch  and auto='Y' )");

            IList<int> items = AdoTemplate.QueryWithRowMapperDelegate<int>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                return Convert.ToInt32(reader["Tx_MaskFlat_PK"]);
            }, paras.GetParameters());

            int temp = 0;
            if (items.Count > 0)
            {
                temp = items[0];
            }
            return temp;
        }

        public int LastestTargetCount(string type, string mode, string ch)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("type").Type(DbType.String).Size(50).Value(type);
            paras.Create().Name("mode").Type(DbType.String).Size(50).Value(mode);
            paras.Create().Name("ch").Type(DbType.String).Size(50).Value(ch);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*)");
            cmdText.Append(" FROM SPC_Rx_Power ");
            cmdText.Append(" WHERE type=@type AND mode=@mode AND ch=@ch ");
            cmdText.Append(" and last_update_date=(");
            cmdText.Append(" select max(last_update_date) from SPC_Rx_Power ");
            cmdText.Append(" where type=@type AND mode=@mode AND ch=@ch )");
            cmdText.Append(" and usl is not null");

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCTxMaskFlatInfo GetLatestTarget(string type, string mode, string ch)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("type").Type(DbType.String).Size(50).Value(type);
            paras.Create().Name("mode").Type(DbType.String).Size(50).Value(mode);
            paras.Create().Name("ch").Type(DbType.String).Size(50).Value(ch);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT USL");
            cmdText.Append(" FROM SPC_TX_POWER ");
            cmdText.Append(" WHERE type=@type AND mode=@mode AND ch=@ch");
            cmdText.Append(" and last_update_date=(");
            cmdText.Append(" select max(last_update_date) from SPC_Rx_Power ");
            cmdText.Append(" where type=@type AND mode=@mode AND ch=@ch)");

            return AdoTemplate.QueryForObjectDelegate<SPCTxMaskFlatInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatInfo entity = new SPCTxMaskFlatInfo();
                entity.USL = Convert.ToDouble(reader["usl"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Delete(SPCTxMaskFlatInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from spc_tx_maskflat ");
            cmdText.Append(" where tx_maskflat_pk=@tx_maskflat_pk");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("tx_maskflat_pk").Type(DbType.Int32).Size(4).Value(entity.TxMaskFlatPK);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCTxMaskFlatDetail> GetOrignalData(int TxMaskFlatPK, int GroupNo)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("tx_maskflat_pk").Type(DbType.Int32).Size(4).Value(TxMaskFlatPK);
            paras.Create().Name("group_no").Type(DbType.Int32).Size(4).Value(GroupNo);

            StringBuilder OriginalCmdText = new StringBuilder();
            OriginalCmdText.Append(" SELECT serial_no,end_time,val ");
            OriginalCmdText.Append(" FROM spc_tx_maskflat_detail ");
            OriginalCmdText.Append(" WHERE tx_maskflat_pk=@tx_maskflat_pk");
            OriginalCmdText.Append(" AND group_no=@group_No");

            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxMaskFlatDetail>(CommandType.Text, OriginalCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxMaskFlatDetail item = new SPCTxMaskFlatDetail();
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.EndTime = Convert.ToDateTime(reader["end_time"]);
                item.Val = Convert.ToString(reader["val"]);
                return item;
            }, paras.GetParameters());

        }

        public void SaveException(int TxMaskFlatPK, IList<SPCTxMaskFlatException> ExceptionItems)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" DELETE FROM SPC_Tx_MaskFlat_Exception WHERE Tx_MaskFlat_PK=@Tx_MaskFlat_PK;");

            paras.Create().Name("Tx_MaskFlat_PK").Type(DbType.Int32).Value(TxMaskFlatPK);

            for (int i = 0; i < ExceptionItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Tx_MaskFlat_Exception");
                cmdText.Append(" (Tx_MaskFlat_PK,Group_No,Chart_Type,Comment,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@Tx_MaskFlat_PK,@Group_No_" + i.ToString() + ",@Chart_Type_" + i.ToString() + ",@Comment_" + i.ToString() + "," +
                    "@Last_Update_Date_" + i.ToString() + ",@Last_Updated_By_" + i.ToString() + ")");
                paras.Create().Name("Group_No_" + i.ToString()).Type(DbType.Int32).Value(ExceptionItems[i].GroupNo);
                paras.Create().Name("Chart_Type_" + i.ToString()).Type(DbType.StringFixedLength).Size(1).Value(ExceptionItems[i].ChartType);
                paras.Create().Name("Comment_" + i.ToString()).Type(DbType.String).Size(100).Value(ExceptionItems[i].Comment);
                paras.Create().Name("Last_Update_Date_" + i.ToString()).Type(DbType.DateTime).Value(ExceptionItems[i].LastUpdateDate);
                paras.Create().Name("Last_Updated_By_" + i.ToString()).Type(DbType.String).Value(ExceptionItems[i].LastUpdatedBy);
            }
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        } 
    }
}
