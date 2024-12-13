using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


/// <summary>
/// Summary description for Class1
/// </summary>
public class ClsConnection
{
 
    SqlBulkCopy Bcp ;
    
    public  SqlConnection Con ;
    public  SqlCommand Cmd;
    public  SqlDataReader Dr;
    public  DataSet Ds;
    public string  PaymentDays = "24";
     SqlDataAdapter  Add;
     SqlTransaction  Tran;
     public delegate void SqlRowsCopieddel(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e);
     public event SqlRowsCopieddel SqlRowsCopied;
     public ClsConnection()
	{
        Con = new SqlConnection();

        Con.ConnectionString = ConfigurationManager.ConnectionStrings["DigitalMobiz"].ConnectionString;     
        
	}
    public void cancel()
    {
        Cmd.Cancel();
    }
    public void  class1(string SqlCon)
    {   Con = new SqlConnection();
        Con.ConnectionString = SqlCon;
        Con.Open();
    }
    public bool Open()  
    {   if( Con.State != ConnectionState.Open )
        {   try
            {   
                Con.Open();
                return true;
            }
            catch( Exception  ex)
            {
                return false;
            }
        }
        else
            return true;
        
    }
    public void Close()
    {
        if ( Con .State != ConnectionState .Closed )
        Con.Close();
      
    }

    public void Bulkcopy(string Destination, DataTable DataSource, int NotifyAfter)
    {
        try
        {
            Bcp = new SqlBulkCopy(Con, SqlBulkCopyOptions.FireTriggers, Tran);
            Bcp.SqlRowsCopied += new SqlRowsCopiedEventHandler(Bcp_SqlRowsCopied);
            Bcp.BulkCopyTimeout = 300;
            Bcp.DestinationTableName = Destination;
            Bcp.NotifyAfter = NotifyAfter;
            Bcp.WriteToServer(DataSource);

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    private void Bcp_SqlRowsCopied(Object Sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
    {
        SqlRowsCopied(Sender, e);
    }

    public int MaxValue(  string Table, string  Column , string  DefaultValue )
    {
        return( MaxValue(Table ,Column ,DefaultValue,"")); 
    }

    public int MaxValue(  string Table, string  Column , string  DefaultValue , string  Condition  ) 
    {
       return ( Convert .ToInt32 ( ExecuteScalar("Select isnull(max(" + Column + ")," + DefaultValue  + ") from " + Table + (Condition == ""? "": " Where ") + Condition)));
   }
 


    public DataRow  FillRow(string  Sqlstr)
    {
        CommandText(Sqlstr);
        SqlDataAdapter  Ad = new SqlDataAdapter();
        Ad.SelectCommand = Cmd;
        DataSet  LDs = new DataSet();
        Ad.Fill(LDs, "Table");
        if( LDs.Tables["Table"].Rows.Count > 0)
            return ((LDs.Tables["Table"].Rows[0]));
        else
            return(null);
        
    }
    public void  FillDataSet(DataSet  LDataSet ,string  Sqlstr, string  TableName )
    {   CommandText(Sqlstr);
        SqlDataAdapter  Ad =new SqlDataAdapter();
        
        Ad.SelectCommand = Cmd;
        Ad.Fill(LDataSet, TableName);
    }
    public void  ClearDataSet(DataSet  LDataSet )
    {LDataSet.Clear();
    }
    public void  BeginTrans()
    { Tran = Con.BeginTransaction();
    }
    public void  CommitTrans()
    {Tran.Commit();
    }
    public void RollBackTrans()
    {       Tran.Rollback();
    }
    public void  CommandText(string  SqlStr )
    {   Cmd = new SqlCommand();
        Cmd.CommandText = SqlStr;
        Cmd.Connection = Con;
        Cmd.Transaction = Tran;
    }

    public int  ExecuteNonQuery(string  SqlStr )
    {   CommandText(SqlStr);
        return( Cmd.ExecuteNonQuery());
    }

    public object  ExecuteScalar(string  SqlStr )
    {   CommandText(SqlStr);
        return( Cmd.ExecuteScalar());
        
    }

    public int  ExecuteLineReader(string  SqlStr )
    {   CommandText(SqlStr);
        Dr = Cmd.ExecuteReader();
        if( Dr.Read() )
            return(1);
        else
            return( 0);
        
    }
    public DataTable FillTable(string  Sqlstr , string  TableName )
    {   CommandText(Sqlstr);
         SqlDataAdapter  Ad = new SqlDataAdapter();
        Ad.SelectCommand = Cmd;
        Ds = new DataSet();
        Ad.Fill(Ds, TableName);
        return( Ds.Tables[TableName]);
    }
    public DataTable  ExecuteProc(string  ProcName ,  params     object[] Parameter ) 
    {   CommandText(ProcName);
        Cmd.CommandType = CommandType.StoredProcedure;
        int i  = 0;
        while( i < Parameter.Length)
        {   Cmd.Parameters.Add(Cmd.CreateParameter());
            Cmd.Parameters[i].ParameterName = Convert.ToString ( Parameter[i]);
            Cmd.Parameters[i].Value = Parameter[i * 2 + 1];
            i = i + 1;
        }
        SqlDataAdapter  Ad = new SqlDataAdapter();
        Ad.SelectCommand = Cmd;
        Ds = new DataSet();
        Ad.Fill(Ds, ProcName);
      return( Ds.Tables[ProcName]);
    }

    public void CloseReader()
    {Dr.Close();
    }


    public void StoreBlobData(string FileName,string SqlStr)
    {
        FileName = "D:\\Picture 001.jpg";
        FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read);
        byte[] rawdata = new byte[file.Length];
        file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
        CommandText(SqlStr );
        SqlParameter BlobData1 = Cmd.Parameters.Add ("@Data", SqlDbType.Image);
        BlobData1.Value = rawdata;
        BlobData1.Size = (int )file.Length;
        file.Close();
        Cmd.ExecuteNonQuery ();
    }


    public void ReadBlobData(   string SqlStr,string FileName)
    {
      
        System.IO.FileStream file;
        BinaryWriter Bw;
        int BufferSize = 100;
        byte[] OutByte = new byte[BufferSize];
        long RetVal;
        long StartIndex = 0;
        CommandText ( SqlStr);
        SqlDataReader MyReader = Cmd.ExecuteReader(CommandBehavior.SequentialAccess);
        while (MyReader.Read())
        {
            file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            Bw = new BinaryWriter(file);
            StartIndex = 0;
            RetVal = MyReader.GetBytes(0, StartIndex, OutByte, 0, BufferSize);
            while (RetVal == BufferSize)
            {
                Bw.Write(OutByte);
                Bw.Flush ();
                StartIndex += BufferSize;
                RetVal = MyReader.GetBytes(0, StartIndex, OutByte, 0, BufferSize);
            }
            Bw.Write (OutByte ,0,(int)RetVal -1);
            Bw.Flush ();
            Bw.Close ();
            file.Close ();
        }


           
    
    }

   public void ExportToExcel(string strFileName, ref DataTable DtName)
    {
        DataTable dt = DtName;
        string attachment = ("attachment; filename=" + strFileName);
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            HttpContext.Current.Response.Write((tab + dc.ColumnName));
            tab = "\t";
        }

        HttpContext.Current.Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; (i
                        <= (dt.Columns.Count - 1)); i++)
            {
                HttpContext.Current.Response.Write((tab + dr[i].ToString()));
                tab = "\t";
            }

            HttpContext.Current.Response.Write("\n");
        }

        HttpContext.Current.Response.End();
    }

    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================

}
