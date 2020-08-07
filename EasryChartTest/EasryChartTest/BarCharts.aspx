<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarCharts.aspx.cs" Inherits="EasryChartTest.BarCharts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    年份选择： <select id="yearselect">
                    <option value="2017">2017</option>
                    <option value="2018">2018</option>
                    <option value="2019">2019</option>
                </select>
    <div>
        <div id="main" style="width: 600px;height:400px;"></div>
    </div>
    </form>
    <script src="js/jquery-1.11.0.js"></script>
    <script>
        var myChart = echarts.init(document.getElementById('main'));
        // 指定图表的配置项和数据 json
        var option = {
            title: {
                text: '夜鹰网2017年月销售金额报表'
            },
            tooltip: {},
            legend: {
                data: ['销售金额', '销售商品数量'],
                x: '338px',
                y:"30px"
            },
            xAxis: {
                data: []
            },
            yAxis: {},
            series: [{
                name: '销售金额',
                type: 'bar',
                data: []
            }, {
                name: '销售商品数量',
                type: 'bar',
                data: []
            }]
        };
        myChart.setOption(option);
        function getajaxdata(objyear)
        {
            $.ajax({
                type: "post",
                url: "Ajax.ashx",
                data: { w: "GetSaleSumPricesByMonth", year: objyear},
                timeout: 5000,
                dataType: "json",
                async: true,//默认设置为true，所有请求均为异步请求
                //cache：true,//默认为true（当dataType为script时，默认为false）设置为false将不会从浏览器缓存中加载请求信息。
                success: function (data) {
                    console.log(data.datamonths);
                    console.log(data.dataitems);
                    console.log(data.datasalecounts);
                    var optionhasvalue = {
                        title: {
                            text: '夜鹰网' + objyear + '年月销售金额报表',
                        },
                        tooltip: {},
                        legend: {
                            data: ['销售金额', '销售商品数量'],

                        },
                        xAxis: {
                            data: data.datamonths
                        },
                        yAxis: {},
                        series: [{
                            name: '销售金额',
                            type: 'bar',
                            data: data.dataitems
                        },
                        {
                            name: '销售商品数量',
                            type: 'bar',
                            data: data.datasalecounts
                        }
                        ]
                    };
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
