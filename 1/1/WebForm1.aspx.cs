using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Page_Load");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Console.WriteLine("Page_Init");
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            Console.WriteLine("Page_PRerender");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Console.WriteLine("Page_Unload");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["test"] = TextBox1.Text;
            Label1.Text = ViewState["test"].ToString();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("CheckedChanged");
        }
    }
}