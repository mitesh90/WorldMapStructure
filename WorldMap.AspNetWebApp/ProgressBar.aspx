<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressBar.aspx.cs" Inherits="WorldMap.AspNetWebApp.ProgressBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="True">
            </asp:ScriptManager>
            <div>
                <asp:Timer ID="TimerControlNew" runat="server" OnTick="TimerControl1_Tick" Enabled="false" Interval="2000">
                </asp:Timer>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Mode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerControlNew" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <div style="background-color: coral; height: 30px; width: 300px">
                        <div id="bar" runat="server"
                            style="height: 30px; width: 0px; background-color: cadetblue">
                        </div>
                    </div>

                    <asp:Label ID="Label1" runat="server" Text="0 %"></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Visible="False">Reload Page</asp:HyperLink><br />
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
        </div>
    </form>
</body>
</html>
