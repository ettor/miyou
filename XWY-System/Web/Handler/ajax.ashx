<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Web;
public class ajax : IHttpHandler
{
	// 说明：
	// 在本网站的示例中，有些JS调用的URL诸如：url: "/AjaxOrder.AddOrder.cs"
	// 由于 ".cs"这种扩展名一般是被Asp.net禁止访问的。
	// 所以如果您没有机会修改IIS级别的设置或者Web.config，则不能使用上面的格式，
	//
	// 而只能使用这种格式的URL了：url: "handler/ajax.ashx?class=AjaxOrder&method=AddOrder"
	// URL参数中的 class 的含义是：指定要调用哪个Ajax服务类（包含命名空间）， method 的含义是：指定要调用哪个方法。
	//
	// 这也是当前文件"ajax.ashx"存在的意义了。
	// 在这个文件中，只需要简单的“转发”一下调用就可以了。
	// 
	// 如果你觉得 class, method 这二个参数的名称不恰当，也可以用这种方法来“重定义”，
	// 最后可以调用 FishWebLib.Ajax.MethodExecutor.ProcessRequest(HttpContext context, Type type, string method)
	// 或者：ProcessRequest(HttpContext context, string AssemblyName, string className, string method)


	// assemblyName 指定了所有供Ajax可以调用的类型的程序程序集。
    private static readonly string assemblyName = typeof(BusinessLogic.Sys.SysUserAction).Assembly.ToString();
	
    public void ProcessRequest (HttpContext context) {    
		// 转发调用。第二个参数是说：要调用的类在哪个程序集中。
		// 这个重载要求在URL参数中存在这二个参数项：class, method
		FishWebLib.Ajax.MethodExecutor.ProcessRequest(context, assemblyName);
    }
	
    public bool IsReusable {
        get {
            return false;
        }
    }

}