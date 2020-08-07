<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZXTDYY.aspx.cs" Inherits="EasryChartTest.ZXTDYY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    年份选择： <select id="yearselect">
                    <option value="2017">2017</option>
                    <option value="2018">2018</option>
                    <option value="2019">2019</option>
                </select>
    <div id="main" style="width: 600px;height:400px;"></div>
    </div>
    </form>
    <script src="js/jquery-1.11.0.js"></script>
    <script type="text/javascript">
        var myChart = echarts.init(document.getElementById('main'));

        var option = {
            title: {
                text: '2017年商品销量比例报表',
                subtext: 'QQ：1416759661 微信号:yyjcw10000',
                x: 'center',
                y: '0px'
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            xAxis: {
                type: 'category',
                data: []
            },
            yAxis: {
                type: 'value'
            },
            series: [{
                data: [],
                type: 'line'
            }]
        };
        myChart.setOption(option);
        function getajaxdata(objyear) {
            $.ajax({
                type: "post",
                url: "Ajax.ashx",
                data: { w: "GetSaleInfoForPie", year: objyear },
                timeout: 5000,
                dataType: "json",
                async: true,//默认设置为true，所有请求均为异步请求
                //cache：true,//默认为true（当dataType为script时，默认为false）设置为false将不会从浏览器缓存中加载请求信息。
                success: function (data) {

                    var optionhasvalue = {
                        title: {
                            text: '2017年商品销量比例报表',
                            subtext: 'QQ：1416759661 微信号:yyjcw10000',
                            x: 'center',
                            y: '0px'
                        },
                        tooltip: {
                            trigger: 'item',
                            formatter: "{a} <br/>{b} : {c} ({d}%)"
                        },
                        xAxis: {
                            type: 'category',
                            data: data.dataproname
                        },
                        yAxis: {
                            type: 'value'
                        },
                        series: [{
                            data: data.dataitems,
                            type: 'line'
                        }]
                    };//optionhasvalue结束
                    myChart.setOption(optionhasvalue);

                }
            });

        }
        getajaxdata(2017);
        $("#yearselect").change(function () {
            var v = $(this).val();
            getajaxdata(v);
        });

    </script>
</body>
</html>
