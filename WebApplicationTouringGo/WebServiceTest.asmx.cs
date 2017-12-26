using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using cn.bmob.io;

namespace WebApplicationTouringGo
{
    /// <summary>
    /// WebServiceTest 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTest : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }

    //Game表对应的模型类
    class AttractionObject : BmobTable
    {

        private String fTable;
        //以下对应云端字段名称
        public String point { get; set; }
        public String name { get; set; }
        public BmobDate createdAt { get; set; }
        public BmobDate updatedAt { get; set; }

        //构造函数
        public AttractionObject() { }

        //构造函数
        public AttractionObject(String tableName)
        {
            this.fTable = tableName;
        }

        public override string table
        {
            get
            {
                if (fTable != null)
                {
                    return fTable;
                }
                return base.table;
            }
        }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.point = input.getString("point");
            this.name = input.getString("name");
            this.createdAt = input.getDate("createdAt");
            this.updatedAt = input.getDate("updateAt");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("point", this.point);
            output.Put("name", this.name);
            output.Put("createdAt", this.createdAt);
            output.Put("updatedAt", this.updatedAt);
        }
    }
}
