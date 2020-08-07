using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Text;
namespace YYCMS
{
/// <summary>  
///SaleRecords类 
/// </summary>  
public class SaleRecords  
 { 
    public SaleRecords() 
    { } 
    #region Model 
     public int ID {set;get;}
     public DateTime? CreateTime {set;get;}
     public string ProName {set;get;}
     public int? SaleCounts {set;get;}
     public decimal? Prices {set;get;}
     public decimal? SumPrice {set;get;}
     public string SaleMan {set;get;}
     public string SaleDepart {set;get;}
     public string ProvinceName {set;get;}
     public string CityName {set;get;}
     public string CountyName {set;get;}
     public string Address {set;get;}
    #endregion Model 
    #region 方法成员 
  /// <summary> 
  /// 增加一条数据 
  /// </summary> 
  public int Add() 
  {
     StringBuilder strSql = new StringBuilder(); 
     strSql.Append("insert into SaleRecords(");
     strSql.Append("CreateTime,ProName,SaleCounts,Prices,SumPrice,SaleMan,SaleDepart,ProvinceName,CityName,CountyName,Address");
     strSql.Append(") values ("); 
     strSql.Append("@CreateTime,@ProName,@SaleCounts,@Prices,@SumPrice,@SaleMan,@SaleDepart,@ProvinceName,@CityName,@CountyName,@Address"); 
     strSql.Append(")");
     strSql.Append(";select @@IDENTITY");  
     SqlParameter[] parameters = {
      new SqlParameter("@CreateTime",SqlDbType.DateTime), 
      new SqlParameter("@ProName",SqlDbType.NVarChar,50), 
      new SqlParameter("@SaleCounts",SqlDbType.Int), 
      new SqlParameter("@Prices",SqlDbType.Decimal), 
      new SqlParameter("@SumPrice",SqlDbType.Decimal), 
      new SqlParameter("@SaleMan",SqlDbType.NVarChar,20), 
      new SqlParameter("@SaleDepart",SqlDbType.NVarChar,20), 
      new SqlParameter("@ProvinceName",SqlDbType.NVarChar,20), 
      new SqlParameter("@CityName",SqlDbType.NVarChar,20), 
      new SqlParameter("@CountyName",SqlDbType.NVarChar,10), 
      new SqlParameter("@Address",SqlDbType.NVarChar,50) 
     };  
     parameters[0].Value = CreateTime; 
     parameters[1].Value = ProName; 
     parameters[2].Value = SaleCounts; 
     parameters[3].Value = Prices; 
     parameters[4].Value = SumPrice; 
     parameters[5].Value = SaleMan; 
     parameters[6].Value = SaleDepart; 
     parameters[7].Value = ProvinceName; 
     parameters[8].Value = CityName; 
     parameters[9].Value = CountyName; 
     parameters[10].Value = Address; 
     object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
     if (obj == null)
     {
          return 1;
     }
     else
     {
          return Convert.ToInt32(obj);
     }
  }
     /// <summary> 
     /// 修改一条数据
     /// </summary> 
     public int Update() 
     {
     StringBuilder strSql = new StringBuilder(); 
     strSql.Append("update SaleRecords set ");
     strSql.Append("CreateTime=@CreateTime,");
     strSql.Append("ProName=@ProName,");
     strSql.Append("SaleCounts=@SaleCounts,");
     strSql.Append("Prices=@Prices,");
     strSql.Append("SumPrice=@SumPrice,");
     strSql.Append("SaleMan=@SaleMan,");
     strSql.Append("SaleDepart=@SaleDepart,");
     strSql.Append("ProvinceName=@ProvinceName,");
     strSql.Append("CityName=@CityName,");
     strSql.Append("CountyName=@CountyName,");
     strSql.Append("Address=@Address");
     strSql.Append(" where ID=@Id");
     SqlParameter[] parameters = { 
      new SqlParameter("@ID",SqlDbType.Int), 
      new SqlParameter("@CreateTime",SqlDbType.DateTime), 
      new SqlParameter("@ProName",SqlDbType.NVarChar,50), 
      new SqlParameter("@SaleCounts",SqlDbType.Int), 
      new SqlParameter("@Prices",SqlDbType.Decimal), 
      new SqlParameter("@SumPrice",SqlDbType.Decimal), 
      new SqlParameter("@SaleMan",SqlDbType.NVarChar,20), 
      new SqlParameter("@SaleDepart",SqlDbType.NVarChar,20), 
      new SqlParameter("@ProvinceName",SqlDbType.NVarChar,20), 
      new SqlParameter("@CityName",SqlDbType.NVarChar,20), 
      new SqlParameter("@CountyName",SqlDbType.NVarChar,10), 
      new SqlParameter("@Address",SqlDbType.NVarChar,50) 
      };
     parameters[0].Value = ID; 
     parameters[1].Value = CreateTime; 
     parameters[2].Value = ProName; 
     parameters[3].Value = SaleCounts; 
     parameters[4].Value = Prices; 
     parameters[5].Value = SumPrice; 
     parameters[6].Value = SaleMan; 
     parameters[7].Value = SaleDepart; 
     parameters[8].Value = ProvinceName; 
     parameters[9].Value = CityName; 
     parameters[10].Value = CountyName; 
     parameters[11].Value = Address; 
       return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
     }
/// <summary> 
/// 删除一条数据 
/// </summary> 
public int delete() 
{ 
StringBuilder strSql = new StringBuilder(); 
strSql.Append("delete from SaleRecords ");
strSql.Append(" where ID=@ID ");
SqlParameter[] parameters = { 
new SqlParameter("@ID", SqlDbType.Int,4) 
}; 
parameters[0].Value = ID;
return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters); 
} 
/// <summary> 
/// 获取数据列表 
/// </summary> 
public DataSet GetList(string strWhere) 
{ 
StringBuilder strSql = new StringBuilder(); 
strSql.Append(" select * from SaleRecords ");
if(strWhere.Trim() != "") 
{
strSql.Append(" where " + strWhere);
}
return  DbHelperSQL.Query(strSql.ToString()); 
}


/// <summary> 
/// 获取数据列表 
/// </summary> 
public DataSet GetSaleInfoByYear(int year)
{
    StringBuilder strSql = new StringBuilder();
    strSql.AppendFormat(" SELECT DATEPART(MONTH,CreateTime) as SaleMonth,SUM(SaleCounts) as SaleSumCounts,SUM(SumPrice) SaleSumprice   FROM [EasyReport].[dbo].[SaleRecords] where DATEPART(year,CreateTime)='{0}' group by DATEPART(MONTH,CreateTime) ", year);
    
    return DbHelperSQL.Query(strSql.ToString());
}


/// <summary> 
/// 获取销售数据用于做饼状图 
/// </summary> 
public DataSet GetSaleInfoByYearForPie(int year)
{
    StringBuilder strSql = new StringBuilder();
    strSql.AppendFormat(" SELECT ProName,SUM(SaleCounts) as SaleSumCounts,SUM(SumPrice) SaleSumprice   FROM [EasyReport].[dbo].[SaleRecords] where DATEPART(year,CreateTime)='{0}' group by ProName ", year);
    return DbHelperSQL.Query(strSql.ToString());
}



/// <summary> 
/// 分页查询 
/// </summary> 
/// <param name="PageIndex">当前第几页</param> 
/// <param name="PageSize">每页条数</param> 
/// <param name="strWhere">条件</param> 
/// <param name="Recordcount">记录总条数</param> 
/// <returns></returns> 
public DataSet Pager(int PageIndex, int PageSize, string strWhere, out int Recordcount) 
 {
string strSql =string.Empty; 
if(string.IsNullOrEmpty(strWhere)) 
{
strWhere = " 1=1 ";
}
strSql = string.Format("select top {0} * from SaleRecords where id not in (select top {1} id from SaleRecords where {2} order by id desc) and ({2}) order by id desc", PageSize, PageSize * (PageIndex - 1), strWhere); 
DataSet ds = DbHelperSQL.Query(strSql); 
string strSql2 = string.Format("select id from SaleRecords where {0}", strWhere);
DataSet dsCount = DbHelperSQL.Query(strSql2);
try
{
Recordcount = dsCount.Tables[0].Rows.Count;
}
catch
{
Recordcount = 0;
}
return  DbHelperSQL.Query(strSql.ToString());
}
/// <summary> 
/// 批量删除数据 
/// </summary> 
public int BatchDelete(string _idstr) 
{
StringBuilder strSql = new StringBuilder(); 
strSql.Append(" delete from SaleRecords ");
strSql.Append(string.Format(" where ID in ({0}) ", _idstr)); 
return DbHelperSQL.ExecuteSql(strSql.ToString()); 
}
#endregion 方法成员
}
}

