using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldMap.DAL;
using WorldMap.Model;

namespace WorldMap.AspNetWebApp
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

            DAL.CRUDOperation.StateDataCRUD dep = new DAL.CRUDOperation.StateDataCRUD();
            List<StateData> tgb = dep.SelectAll();

            int abc = 0;
        }
    }
}