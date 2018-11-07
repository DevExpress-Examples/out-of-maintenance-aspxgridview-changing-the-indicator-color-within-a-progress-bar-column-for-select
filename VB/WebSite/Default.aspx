<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Changing Progress Bar Indicator Color</title>
</head>
<body>
	<form id="form1" runat="server">

		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" >
			<Columns>
				<dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
				</dx:GridViewCommandColumn>

				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1">
				</dx:GridViewDataTextColumn>

				<dx:GridViewDataSpinEditColumn FieldName="Complete" VisibleIndex="2">
					<CellStyle HorizontalAlign="Left"></CellStyle>
					<DataItemTemplate>
						<dx:ASPxProgressBar ID="ASPxProgressBar1" runat="server" Height="21px" Width="100px"
							Position='<%#Eval("Complete")%>'  OnLoad="ASPxProgressBar1_Load">
							<IndicatorStyle BackColor="Yellow">
							</IndicatorStyle>
						</dx:ASPxProgressBar>
					</DataItemTemplate>
				</dx:GridViewDataSpinEditColumn>        
			</Columns>

			<SettingsBehavior ProcessSelectionChangedOnServer="True" />
		</dx:ASPxGridView>


	</form>
</body>
</html>