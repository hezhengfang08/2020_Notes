using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
namespace EasryChartTest
{
    public partial class SaleRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 if (!IsPostBack)
        {

            string starttime = YYCMS.Request.GetQueryString("starttime");
            string endtime = YYCMS.Request.GetQueryString("endtime");
            string salemanname = YYCMS.Request.GetQueryString("salemanname");

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");

            if (!String.IsNullOrEmpty(starttime))
            {
                sb.AppendFormat("  and ( DATEDIFF(SS,'{0}',CreateTime)>=0   )", starttime);
            }

            if (!String.IsNullOrEmpty(endtime))
            {
                sb.AppendFormat("  and ( DATEDIFF(SS,'{0}',CreateTime)<=0   )", endtime);
            }

            if (!String.IsNullOrEmpty(salemanname))
            {
                sb.AppendFormat("  and ( SaleMan like '%{0}%' )", salemanname);
            }

            



            YYCMS.SaleRecords Dal = new YYCMS.SaleRecords();

            DataSet dsAll=Dal.GetList(sb.ToString());
            decimal sum = 0;
            foreach(DataRow dr in dsAll.Tables[0].Rows)
            {
                sum += Convert.ToDecimal(dr["SumPrice"]);
            }
            ltr_sumprice.Text = sum.ToString();


            int _pageindex = YYCMS.Request.GetQueryInt("p", 1);
            int pagesize=15;
            int recordcount=0;
            DataSet ds = Dal.Pager(_pageindex, pagesize, sb.ToString(), out recordcount);

            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            
            Pager1.PageIndex = _pageindex;
            Pager1.PageSize = pagesize;
            Pager1.RecordCount = recordcount;
            Pager1.w = "?starttime=" + starttime + "&endtime=" + endtime + "&salemanname=" + salemanname;


           
           
        }
    }
}
}