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
    public partial class tb_consumer_partition_dal
    {
        public virtual tb_consumer_partition_model Get(DbConn PubConn, int consumerclientid, int partitionid)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
                    
					    //�����߿ͻ���ID
					    new ProcedureParameter("@consumerclientid", consumerclientid),

					    //������ID
					    new ProcedureParameter("@partitionid", partitionid),

                };

                StringBuilder stringSql = new StringBuilder();
                stringSql.Append(@"select s.* from tb_consumer_partition s WITH(NOLOCK) where s.consumerclientid=@consumerclientid and s.partitionid=@partitionid");
                DataSet ds = new DataSet();
                PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return CreateModel(ds.Tables[0].Rows[0]);
                }
                return null;
            });
        }

        public virtual int UpdateLastMQID(DbConn PubConn,int consumerclientid, int partitionid, long lastmqid)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
                    
					    //�����߿ͻ���ID
					    new ProcedureParameter("@consumerclientid",    consumerclientid),
					    //������ID
					    new ProcedureParameter("@partitionid",   partitionid),
					    //
					    new ProcedureParameter("@lastmqid",    lastmqid),
                };

                int rev = PubConn.ExecuteSql(@"update tb_consumer_partition WITH (ROWLOCK) set lastmqid=@lastmqid, lastupdatetime=getdate() where consumerclientid=@consumerclientid and partitionid=@partitionid and lastmqid<@lastmqid", Par);
                return rev;
            });


        }

        public virtual int Edit2(DbConn PubConn, tb_consumer_partition_model model)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
                    
					    //�����߿ͻ���ID
					    new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					    //
					    new ProcedureParameter("@partitionindex",    model.partitionindex),
					    //������ID
					    new ProcedureParameter("@partitionid",    model.partitionid),
					    //
					    new ProcedureParameter("@lastconsumertempid",    model.lastconsumertempid),
                };

                int rev = PubConn.ExecuteSql(@"update tb_consumer_partition WITH (ROWLOCK) set partitionindex=@partitionindex,
                                               lastconsumertempid=@lastconsumertempid where consumerclientid=@consumerclientid and partitionid=@partitionid", Par);
                return rev;
            });


        }

        public virtual bool Add2(DbConn PubConn, tb_consumer_partition_model model)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//�����߿ͻ���ID
					new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					//
					new ProcedureParameter("@partitionindex",    model.partitionindex),
					//������ID
					new ProcedureParameter("@partitionid",    model.partitionid),
					//
					new ProcedureParameter("@lastconsumertempid",    model.lastconsumertempid),
					//������ѵ�MQID
					new ProcedureParameter("@lastmqid",    model.lastmqid),

                };
                int rev = PubConn.ExecuteSql(@"insert into tb_consumer_partition(consumerclientid,partitionindex,partitionid,lastconsumertempid,lastmqid,lastupdatetime,createtime)
										   values(@consumerclientid,@partitionindex,@partitionid,@lastconsumertempid,@lastmqid,getdate(),getdate())", Par);
                return rev == 1;
            });

        }

       

        public virtual tb_consumer_partition_model CreateModel(DataRow dr)
        {
            var o = new tb_consumer_partition_model();

            //
            if (dr.Table.Columns.Contains("id"))
            {
                o.id = dr["id"].Toint();
            }
            //�����߿ͻ���ID
            if (dr.Table.Columns.Contains("consumerclientid"))
            {
                o.consumerclientid = dr["consumerclientid"].Toint();
            }
            //
            if (dr.Table.Columns.Contains("partitionindex"))
            {
                o.partitionindex = dr["partitionindex"].Toint();
            }
            //������ID
            if (dr.Table.Columns.Contains("partitionid"))
            {
                o.partitionid = dr["partitionid"].Toint();
            }
            //
            if (dr.Table.Columns.Contains("lastconsumertempid"))
            {
                o.lastconsumertempid = dr["lastconsumertempid"].Tolong();
            }
            //������ѵ�MQID
            if (dr.Table.Columns.Contains("lastmqid"))
            {
                o.lastmqid = dr["lastmqid"].Tolong();
            }
            //���������ִ��ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
            if (dr.Table.Columns.Contains("lastupdatetime"))
            {
                o.lastupdatetime = dr["lastupdatetime"].ToDateTime();
            }
            //�����߷�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
            if (dr.Table.Columns.Contains("createtime"))
            {
                o.createtime = dr["createtime"].ToDateTime();
            }
            return o;
        }
    }
}