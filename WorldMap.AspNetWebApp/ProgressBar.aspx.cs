using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Web.UI.HtmlControls;

namespace WorldMap.AspNetWebApp
{
    public partial class ProgressBar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DoTheWork()
        {
            int i = 0;
            while (i < 100)
            {
                Thread.Sleep(1000);
                i = i + 1;
                Session["status"] = i;
            }
            Thread objThread = (Thread)Session["Thread"];
            objThread.Abort();
        }

        protected void TimerControl1_Tick(object sender, System.EventArgs e)
        {
            int i = (int)Session["status"];
            if (i == 100)
            {
                TimerControlNew.Enabled = false;
                HyperLink1.Visible = true;
            }
            Label1.Text = i.ToString() + "%";
            HtmlGenericControl div = (HtmlGenericControl)this.Controls[0].FindControl("bar");
            i = i * 3;
            string p = (i.ToString() + "px");
            div.Style.Add("width", p);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session.Add("status", 0);
            Thread objThread = new Thread(new System.Threading.ThreadStart(DoTheWork));
            objThread.IsBackground = true;
            objThread.Start();
            Session["Thread"] = objThread;
            Button1.Enabled = false;
            TimerControlNew.Enabled = true;
        }
    }
}