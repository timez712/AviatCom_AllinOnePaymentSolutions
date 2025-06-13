Imports System.Data.SqlClient
Imports System.Drawing
Imports System.ComponentModel
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data
Imports System.Net

Public Class frm_MerchantDetail
    Private mCmd_UpdateMerchantDetail As SqlCommand = Nothing
    Private msCompanyID As String = ""
    Private mDataRowView As DataRowView
    WithEvents MyGrid As AviatCom_DefaultGrid
    Friend WriteOnly Property SetMerchantData As DataRowView
        Set(ByVal value As DataRowView)
            mDataRowView = value
        End Set
    End Property
    Friend WriteOnly Property SetCompanyID As String
        Set(ByVal value As String)
            txtCompanyID.Text = value
        End Set
    End Property

    Private Sub frm_MerchantDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cboSaleRep.AutoCompleteSource = AutoCompleteSource.ListItems
            cboSaleRep.AutoCompleteMode = AutoCompleteMode.Append
            cboSaleRep.DropDownStyle = ComboBoxStyle.DropDown
            'cboSaleRep.Items.AddRange(garrEmployee)
            DisplayMerchantInformation()

            MyGrid = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid.AC_AllowFilter = True
            'If Not giCustomerID = 0 Then RefreshData()


            MyGrid.Parent = Me.Panel
            MyGrid.BorderStyle = BorderStyle.Fixed3D
            MyGrid.Show()
            C1TrueDBGrid1.Dispose()


            '$$ Resize grid height
            MyGrid.Splits(0).ColumnCaptionHeight = MyGrid.Splits(0).ColumnCaptionHeight * 1.2
            MyGrid.Splits(0).ColumnFooterHeight = MyGrid.Splits(0).ColumnFooterHeight * 1.2
            MyGrid.RowHeight = MyGrid.Font.Size * 1.5

            '$$$$$$$$

            cboStatus.Text = "Active"
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - frm_MerchantDetail_Load: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub
    Private Sub DisplayMerchantInformation()
        Try
            If Not mDataRowView Is Nothing Then
                msCompanyID = mDataRowView.Item("CompanyID").ToString
                txtMerchantName.Text = mDataRowView.Item("MerchantName").ToString
                txtMerchantID.Text = mDataRowView.Item("MerchantID").ToString
                txtCreateDate.Text = mDataRowView.Item("CreateDate").ToString
                cboStatus.Text = mDataRowView.Item("Status").ToString
                cboSaleRep.Text = mDataRowView.Item("SalesRep").ToString
                dtActivationDate.Text = mDataRowView.Item("ActivationDate").ToString
                txtMerchantNumber.Text = mDataRowView.Item("MerchantNumber").ToString
                txtMMO.Text = mDataRowView.Item("MMO").ToString
                txtEinNumber.Text = mDataRowView.Item("EinNumber").ToString
                cboTeminalType.Text = mDataRowView.Item("TerminalType").ToString
                txtSNNumber.Text = mDataRowView.Item("SN").ToString
                txtURL.Text = mDataRowView.Item("URL").ToString
                txtPhone.Text = mDataRowView.Item("Phone").ToString
                txtFax.Text = mDataRowView.Item("Fax").ToString
                txtEMail.Text = mDataRowView.Item("Email").ToString
                txtRemarks.Text = mDataRowView.Item("Remark").ToString
            End If
            'If txtMerchantID.Text.Trim = "" Then txtMerchantID.Text = GetNewCustomerID("M")
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - DisplayEmployeeInformation: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub

    Private Sub cboSaleRep_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSaleRep.Validating
        If cboSaleRep.Text <> String.Empty Then
            If cboSaleRep.SelectedItem Is Nothing OrElse cboSaleRep.SelectedItem.ToString <> cboSaleRep.Text Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            'If mCmd_UpdateMerchantDetail Is Nothing Then mCmd_UpdateMerchantDetail = gobjADO.GetADOCommand("sp_Customer_UpdateMerchantDetail")
            ''$$$$$$$ testing
            'If gObjEmployeeInformation.EmployeeID Is Nothing Then gObjEmployeeInformation.EmployeeID = 999
            ''$$$$$$$$$$$$$$
            'gobjADO.ExecuteSP(GetParam(gObjEmployeeInformation.EmployeeID, txtMerchantID.Text, txtMerchantName.Text, cboStatus.Text, txtMerchantNumber.Text, _
            '                          txtMMO.Text, txtSNNumber.Text, txtEinNumber.Text, cboSaleRep.Text, msCompanyID, _
            '                           dtActivationDate.Value.ToShortDateString, txtURL.Text, cboTeminalType.Text, txtFax.Text, txtPhone.Text, _
            '                           txtEMail.Text, txtRemarks.Text), mCmd_UpdateMerchantDetail)
            'Me.Close()
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - btnSave_Click: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Close()
    End Sub

    Private Sub btnPaperRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaperRequest.Click
        Try
            frm_MerchantPaperRequest.ShowDialog()
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - btnPaperRequest_Click: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub

    Private Sub btnNewLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLog.Click
        Try
            frm_TaskDetail.ShowDialog()
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - btnNewLog_Click: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try

    End Sub

    Private Sub btnUploadDocument_Click(sender As Object, e As EventArgs) Handles btnUploadDocument.Click
        Try

            Dim myWebClient As WebClient = New WebClient
            myWebClient.UploadFile("http://321ordernow.theworkpc.com:48168/MyDocuments/", "POST", "C:\Users\johnl\Desktop\New folder\Claims1-80813880-0000-C01F-B8B8-85EA7C9E87F8-1.jpg")
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - btnUploadDocument_Click: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub
End Class