<%@ WebHandler Language="C#" Class="OutStartWorkFlow" %>
using System;
using System.Web;
using System.Collections.Generic;

public class OutStartWorkFlow : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
       //json 格式访问
        string method = string.Empty;
        context.Response.ContentType ="application/json";
        byte[] aa = new byte[context.Request.ContentLength];
        string ss = "";
        try
        {
            int r = context.Request.InputStream.Read(aa, 0, context.Request.ContentLength);
        }
        catch (Exception ex)
        {
            ss = ex.Message;
        }
        ss = System.Text.Encoding.UTF8.GetString(aa);
        System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
        json.MaxJsonLength = int.MaxValue;
        //json 专程字典
        Dictionary<string, object> JsonData = (Dictionary<string, object>)json.DeserializeObject(ss);
        string workflowCode = JsonData["workflowCode"]+string.Empty;
        string userCode = JsonData["userCode"] + string.Empty;
        bool finishStart = true;
        string objStr  = JsonData["objStr"] + string.Empty;
        OThinker.H3.Portal.StartWorkflow startWorkflow = new OThinker.H3.Portal.StartWorkflow();
        bool rest = startWorkflow.StartWorkflowByEntityTransJson(workflowCode, userCode, finishStart, objStr);
        string result ="";
        if(rest)
        {
             result = "[{\"result\":Success}]";
            context.Response.Write(result);
        }
        else
        {
             result = "[{\"result\":Fail}]";
             context.Response.Write(result);
        }
        
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }




}
