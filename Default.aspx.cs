using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private void ShowError(string msg)
    {
        lblErrors.Text = msg;
        lblErrors.Visible = true;
    }
    private void ShowMessage(string msg)
    {
        lblMessage.Text = msg;
        lblMessage.Visible = true;
    }
    private void UpdateRefreshTime()
    {
        lblRefreshtime.Text = DateTime.Now.ToString("H:mm:ss");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrors.Visible = false;
        lblMessage.Visible = false;
        lblDebug.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
    }
    protected void btnRefreshClick(object sender, EventArgs e)
    {
        gvComputers.DataBind();
    }
    protected void tmrRefreshComputers_Tick(object sender, EventArgs e)
    {
        gvComputers.DataBind();
    }
    protected void cbAutoRefresh_CheckedChanged(object sender, EventArgs e)
    {
        tmrRefreshComputers.Enabled = ((CheckBox)sender).Checked;
    }
    protected void gvComputers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("action", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                // e.CommandArgument = row index
                int rownum = int.Parse(e.CommandArgument.ToString());
                GridView gv = (GridView)e.CommandSource;
                // Info uitlezen
                string info = ((GridView)e.CommandSource).Rows[rownum].Cells[0].Text;
                // Status
                if (((CheckBox)gv.Rows[rownum].Cells[4].Controls[0]).Checked)
                {
                    // Host uitlezen
                    string host = ((GridView)e.CommandSource).Rows[rownum].Cells[1].Text;
                    // Afsluiten obv host
                    WOL.AquilaWolLibrary.Shutdown(host, WOL.AquilaWolLibrary.ShutdownFlags.Shutdown);                    
                    // Notify user
                    ShowMessage("Afsluitcommando is verstuurd naar '" + info + "'.");
                }
                else
                {
                    // MAC-adress uitlezen
                    string mac = ((GridView)e.CommandSource).Rows[rownum].Cells[2].Text;
                    // Wakker maken obv MAC
                    WOL.AquilaWolLibrary.WakeUp(mac);
                    // Notify user
                    ShowMessage("Opstartcommando is verstuurd naar '" + info + "'.");
                }
            }
            catch(Exception err)
            {
                ShowError(err.Message);
            }
        }
    }
    protected void odsComputers_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        UpdateRefreshTime();
    }
}