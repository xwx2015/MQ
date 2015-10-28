using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XXF.Extensions;
using XXF.Db;
using XXF.BaseService.MessageQuque.Model;
using XXF.ProjectTool;

namespace XXF.BaseService.MessageQuque.Dal
{
    /*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
    public partial class tb_consumer_dal
    {
        public bool DeleteNotOnLineByClientID(DbConn PubConn, int consumerclientid, int maxtimeoutsenconds)
        {
            return SqlHelper.Visit((ps) =>
            {
                ps.Add("@consumerclientid", consumerclientid); ps.Add("@maxtimeoutsenconds", maxtimeoutsenconds);
                string Sql = "delete from tb_consumer where consumerclientid=@consumerclientid and DATEDIFF(S,lastheartbeat,getdate())>@maxtimeoutsenconds";
                int rev = PubConn.ExecuteSql(Sql, ps.ToParameters());
                return true;
            });
        }

        public bool DeleteClient(DbConn PubConn, int consumerclientid, long tempid)
        {
            return SqlHelper.Visit((ps) =>
            {
                ps.Add("@consumerclientid", consumerclientid); ps.Add("@tempid", tempid);
                string Sql = "delete from tb_consumer where consumerclientid=@consumerclientid and tempid=@tempid";
                int rev = PubConn.ExecuteSql(Sql, ps.ToParameters());
                return true;
            });
        }

        public bool ClientHeatbeat(DbConn PubConn, int consumerclientid, long tempid)
        {
            return SqlHelper.Visit((ps) =>
            {
                ps.Add("@consumerclientid", consumerclientid); ps.Add("@tempid", tempid);
                string Sql = "update tb_consumer WITH (ROWLOCK) set lastheartbeat=getdate() where consumerclientid=@consumerclientid and tempid=@tempid";
                int rev = PubConn.ExecuteSql(Sql, ps.ToParameters());
                return true;
            });
        }

        public List<int> GetRegisterPartitionIndexs(DbConn PubConn, int consumerclientid)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<int> rs = new List<int>();
                ps.Add("@consumerclientid", consumerclientid);
                string Sql = "select s.partitionindexs from tb_consumer s WITH(NOLOCK) where s.consumerclientid=@consumerclientid";
                DataSet ds = new DataSet();
                PubConn.SqlToDataSet(ds, Sql.ToString(), ps.ToParameters());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string partitionindexs = Convert.ToString(dr["partitionindexs"]);
                        string[] indexs = partitionindexs.Trim(',').Split(',');
                        foreach (var index in indexs)
                        {
                            if (!string.IsNullOrWhiteSpace(index) &&!rs.Contains(Convert.ToInt32(index)))
                            {
                                rs.Add(Convert.ToInt32(index));
                            }
                        }
                    }
                }
                return rs;
            });
        }

        public virtual bool Add2(DbConn PubConn, tb_consumer_model model)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<ProcedureParameter> Par = new List<ProcedureParameter>()
                    {
					
					    //��������ʱid(������������Ψһ,Guidתlong)
					    new ProcedureParameter("@tempid",    model.tempid),
					    //������clinet��id
					    new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					    //֧�ֵķ���˳���(֧�ֶ��˳���)
					    new ProcedureParameter("@partitionindexs",    model.partitionindexs),
					    //�ͻ�������
					    new ProcedureParameter("@clientname",    model.clientname),
                        ////�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
                        //new ProcedureParameter("@lastheartbeat",    model.lastheartbeat),
                        ////��һ�θ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
                        //new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
                        ////�ͻ��˴���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
                        //new ProcedureParameter("@createtime",    model.createtime)   
                    };
                int rev = PubConn.ExecuteSql(@"insert into tb_consumer(tempid,consumerclientid,partitionindexs,clientname,lastheartbeat,lastupdatetime,createtime)
										       values(@tempid,@consumerclientid,@partitionindexs,@clientname,getdate(),getdate(),getdate())", Par);
                return rev == 1;
            });

        }

        public virtual tb_consumer_model Get(DbConn PubConn, long tempid, int consumerclientid)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<ProcedureParameter> Par = new List<ProcedureParameter>();
                Par.Add(new ProcedureParameter("@tempid", tempid)); Par.Add(new ProcedureParameter("@consumerclientid", consumerclientid));
                StringBuilder stringSql = new StringBuilder();
                stringSql.Append(@"select s.* from tb_consumer s WITH(NOLOCK) where s.tempid=@tempid and consumerclientid=@consumerclientid");
                DataSet ds = new DataSet();
                PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return CreateModel(ds.Tables[0].Rows[0]);
                }
                return null;
            });
        }

    

        public virtual tb_consumer_model CreateModel(DataRow dr)
        {
            var o = new tb_consumer_model();

            //
            if (dr.Table.Columns.Contains("id"))
            {
                o.id = dr["id"].Toint();
            }
            //��������ʱid(������������Ψһ,Guidתlong)
            if (dr.Table.Columns.Contains("tempid"))
            {
                o.tempid = dr["tempid"].Tolong();
            }
            //������clinet��id
            if (dr.Table.Columns.Contains("consumerclientid"))
            {
                o.consumerclientid = dr["consumerclientid"].Toint();
            }
            //֧�ֵķ���˳���(֧�ֶ��˳���)
            if (dr.Table.Columns.Contains("partitionindexs"))
            {
                o.partitionindexs = dr["partitionindexs"].Tostring();
            }
            //�ͻ�������
            if (dr.Table.Columns.Contains("clientname"))
            {
                o.clientname = dr["clientname"].Tostring();
            }
            //�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
            if (dr.Table.Columns.Contains("lastheartbeat"))
            {
                o.lastheartbeat = dr["lastheartbeat"].ToDateTime();
            }
            //��һ�θ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
            if (dr.Table.Columns.Contains("lastupdatetime"))
            {
                o.lastupdatetime = dr["lastupdatetime"].ToDateTime();
            }
            //�ͻ��˴���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
            if (dr.Table.Columns.Contains("createtime"))
            {
                o.createtime = dr["createtime"].ToDateTime();
            }
            return o;
        }
    }
}