<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleRecords.aspx.cs" Inherits="EasryChartTest.SaleRecords" %>

<%@ Register src="Control/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title></title>
    <script src="My97DatePicker/WdatePicker.js"></script>

    <style type="text/css">
        * {
            margin:0;
            padding:0;
        }
        #reportbox {
            width:1000px;
            margin:0 auto;
        }
        .tblist {
            width:100%;
            min-width:600px;
            border-collapse:collapse;
        }

        .tblist tr:nth-child(2n+1) {
            background-color:#eee;
        }

         .tblist td{
            border:solid 1px #ccc;
            height:30px;
            text-align:center;
        }
        h3 {
            text-align:center;
            padding:10px 0;
        }
        .search {
            padding-bottom:10px;
        }

        #btnSearch {
            width:80px;
            text-align:center;
            height:22px;
            background-color:#ff6600;
            color:white;
            border:0;
        }

        .pager {
            height:35px;
            line-height:35px;
            color:#333;
            text-align:right;
        }

         .pager a{
            color:#333;
            text-decoration:none;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="reportbox">
         <h3>员工销售明细报表</h3> 
        <div class="search">
            开始日期： <input type="text" id="starttime" name="starttime" placeholder="" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly" class="Wdate" />结束日期：<input type="text" name="endtime" id="endtime" placeholder="" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly" class="Wdate"/>&nbsp;<input type="text" placeholder="请输入销售人员的姓名..." name="salemanname" id="salemanname"/>
            <asp:Button ID="btnSearch" runat="server" Text="查询" />
         </div>
          <table class="tblist" cellspacing="0" cellpadding="0">
              <tr><td>时间</td><td>姓名</td><td>商品名称</td><td>单价</td><td>数量</td><td>总价</td></tr>
              <asp:Repeater ID="Repeater1" runat="server">
                  <ItemTemplate>
                       <tr><td><%#Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td><td><%#Eval("SaleMan")%></td><td><%#Eval("ProName")%></td><td><%#Eval("Prices")%></td><td><%#Eval("SaleCounts")%></td><td><%#Eval("SumPrice")%></td></tr>
                  </ItemTemplate>
              </asp:Repeater>    
              <tr><td colspan="5" style="color:red;">销售金额汇总</td><td style="color:red;"><asp:Literal ID="ltr_sumprice" runat="server"></asp:Literal> </td></tr>     
          </table>
          <div class="pager"><uc1:Pager ID="Pager1" runat="server" /></div>

      </div>
    </form>


    <script src="js/jquery-1.11.0.js"></script>
    <script>

        var vstarttime = localStorage.getItem("starttime");
        var vendtime = localStorage.getItem("endtime");
        var vsalemanname = localStorage.getItem("salemanname");

        if (vstarttime == null) {
            vstarttime = "";
        }
        if (vendtime == null) {
            vendtime = "";
        }
        if (vsalemanname == null) {
            vsalemanname = "";
        }

        $("#starttime").val(vstarttime);
        $("#endtime").val(vendtime);
        $("#salemanname").val(vsalemanname);


        
        $("#btnSearch").click(function (e) {
            var starttime = $("#starttime").val();
            var endtime = $("#endtime").val();
            var salemanname = $("#salemanname").val();

            localStorage.setItem("starttime", starttime);
            localStorage.setItem("endtime", endtime);
            localStorage.setItem("salemanname", salemanname);

            location.href = "SaleRecords.aspx?starttime=" + starttime + "&endtime=" + endtime + "&salemanname=" + salemanname;
            e.preventDefault();
        });


    </script>


</body>
</html>
