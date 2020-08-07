using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
namespace EasryChartTest
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
    {
     HttpContext ctx;
    
    public void ProcessRequest (HttpContext context) {
        ctx = context;
        var w = YYCMS.Request.GetFormString("w");
        switch (w)
        {
            case "GetSaleSumPricesByMonth": GetSaleSumPricesByMonth(); break;
            case "GetSaleInfoForPie": GetSaleInfoForPie(); break;
        }
            
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

    public void GetSaleInfoForPie()
    {
        var year = YYCMS.Request.GetFormInt("year", 0);
        YYCMS.SaleRecords Dal = new YYCMS.SaleRecords();
        DataSet ds = Dal.GetSaleInfoByYearForPie(year);
        StringBuilder sb = new StringBuilder();
        //{"dataproname":["打印机","电视机"],"dataitems":[{value:335, name:"直接访问"},{value:335, name:"直接访问"}]}
        sb.Append("{");
        sb.Append("\"dataproname\":[");
        int i = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (i == (ds.Tables[0].Rows.Count - 1))
            {
                sb.AppendFormat("\"{0}\"", dr["ProName"].ToString());
            }
            else
            {
                sb.AppendFormat("\"{0}\",", dr["ProName"].ToString());            
            }
            i++;
        }
        sb.Append("],");
        sb.Append("\"dataitems\":[");
        int j = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            sb.Append("{");

            sb.AppendFormat("\"value\":{0}, \"name\":\"{1}\"", dr["SaleSumCounts"].ToString(), dr["ProName"].ToString());
            
            if (j == (ds.Tables[0].Rows.Count - 1))
            {
                sb.Append("}");
            }
            else
            {
                sb.Append("},");
            }
           
            j++;
        }
        sb.Append("]");
        sb.Append("}");
        
        ctx.Response.ContentType = "text/json";
        ctx.Response.Write(sb.ToString());
    }
    

    public void GetSaleSumPricesByMonth()
    {
         var year=YYCMS.Request.GetFormInt("year", 0);
         YYCMS.SaleRecords Dal = new YYCMS.SaleRecords();
         DataSet ds=Dal.GetSaleInfoByYear(year);
         //{"datamonths":["1月","2月","3月"],"dataitems":[100,200,150]}
         StringBuilder sb = new StringBuilder();
         sb.Append("{");
             sb.Append("\"datamonths\":[");
             int i = 0;
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 if (i == (ds.Tables[0].Rows.Count - 1))
                 {
                     sb.AppendFormat("\"{0}月\"", dr["SaleMonth"].ToString());
                 }
                 else
                 {
                     sb.AppendFormat("\"{0}月\",", dr["SaleMonth"].ToString());
                 }
                 
                 i++;
             }
             sb.Append("],");
             sb.Append("\"dataitems\":[");
             int j = 0; 
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 if (j == (ds.Tables[0].Rows.Count - 1))
                 {
                     sb.AppendFormat("{0}", dr["SaleSumprice"].ToString());
                 }
                 else
                 {
                     sb.AppendFormat("{0},", dr["SaleSumprice"].ToString());
                 }
                 j++;
             }
             sb.Append("],");

             sb.Append("\"datasalecounts\":[");
             int k = 0;
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 if (k == (ds.Tables[0].Rows.Count - 1))
                 {
                     sb.AppendFormat("{0}", dr["SaleSumCounts"].ToString());
                 }
                 else
                 {
                     sb.AppendFormat("{0},", dr["SaleSumCounts"].ToString());
                 }
                 k++;
             }
             sb.Append("]");
        
         sb.Append("}");
         ctx.Response.ContentType = "text/json";
         ctx.Response.Write(sb.ToString());
    }
    
    
    

}
}