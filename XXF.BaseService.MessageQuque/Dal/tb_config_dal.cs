using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XXF.Extensions;
using XXF.Db;
using XXF.BaseService.MessageQuque.Model;

namespace XXF.BaseService.MessageQuque.Dal
{
    /*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
    public partial class tb_config_dal
    {
        public virtual List<tb_config_model> List(DbConn PubConn)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_config s WITH(NOLOCK)");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            List<tb_config_model> rs = new List<tb_config_model>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                    rs.Add(CreateModel(dr));
            }
            return rs;
        }

        public virtual string Get2(DbConn PubConn, string key)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@key", key));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select value from tb_config s WITH(NOLOCK) where s.[key]=@key");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(ds.Tables[0].Rows[0][0]);
            }
            return null;
        }

        public virtual tb_config_model CreateModel(DataRow dr)
        {
            var o = new tb_config_model();

            //����Key
            if (dr.Table.Columns.Contains("key"))
            {
                o.key = dr["key"].Tostring();
            }
            //����Value
            if (dr.Table.Columns.Contains("value"))
            {
                o.value = dr["value"].Tostring();
            }
            //���ñ�ע��Ϣ
            if (dr.Table.Columns.Contains("remark"))
            {
                o.remark = dr["remark"].Tostring();
            }
            return o;
        }
    }
}