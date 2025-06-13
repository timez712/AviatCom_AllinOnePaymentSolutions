Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frmOrderHistory
    Private mCmd_GetOrderHistory As SqlCommand = Nothing
    Private mCmd_GetLabelPrint As SqlCommand = Nothing
    Private mCmd_CloseOrder As SqlCommand = Nothing
    WithEvents MyGrid As AviatCom_DefaultGrid
    WithEvents MyGrid2 As AviatCom_DefaultGrid
    Private mbIsLoading As Boolean = True
    Private mbDirty As Boolean = False

    Private Sub frmOrderHistory_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Try
            If Not mCmd_GetLabelPrint Is Nothing Then mCmd_GetLabelPrint.Dispose()
            If Not mCmd_GetOrderHistory Is Nothing Then mCmd_GetOrderHistory.Dispose()
            If Not mCmd_CloseOrder Is Nothing Then mCmd_CloseOrder.Dispose()
            If Not MyGrid Is Nothing Then MyGrid.Dispose()

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error frmOrderHistory_Disposed")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frmOrderHistory_Disposed - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub frmOrderHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            mCmd_GetOrderHistory = gobjADO.GetADOCommand("sp_frmOrderHisotry_GetOrderHistory")
            mCmd_GetLabelPrint = gobjADO.GetADOCommand("sp_GetLabelPrint")
            mCmd_CloseOrder = gobjADO.GetADOCommand("sp_frmOrderHistory_CloseOrder")
            MyGrid = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid.FetchRowStyles = False
            MyGrid.AC_AllowFilter = True
            MyGrid.AllowDelete = False
            MyGrid.AllowAddNew = False
            MyGrid.AllowSort = True
            MyGrid.BorderStyle = BorderStyle.Fixed3D
            MyGrid.HighLightRowStyle.BackColor = Color.Red
            MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow


            C1TrueDBGrid1.Dispose()
            MyGrid.Show()

            MyGrid2 = New AviatCom_DefaultGrid(C1TrueDBGrid2)
            MyGrid2.FetchRowStyles = False
            MyGrid2.AC_AllowFilter = True
            MyGrid2.AllowDelete = False
            MyGrid2.AllowAddNew = False
            MyGrid2.AllowSort = True
            MyGrid2.BorderStyle = BorderStyle.Fixed3D
            MyGrid2.HighLightRowStyle.BackColor = Color.Green
            MyGrid2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow

            C1TrueDBGrid2.Dispose()
            MyGrid2.Show()

            dtDateFrom.Value = dtDateFrom.Value.AddMonths(-3)
            MyGrid.Columns("Order Status").FilterText = "New"

            MyGrid.Splits(0).DisplayColumns("Order Status").Frozen = True
            MyGrid.Splits(0).DisplayColumns("Order #").Frozen = True
            MyGrid.Splits(0).DisplayColumns("Company Name").Frozen = True
            MyGrid.Splits(0).DisplayColumns("PO #").Frozen = True
            MyGrid.Splits(0).DisplayColumns("Confirm Date").Frozen = True

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error frmOrderHistory_Load")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frmOrderHistory_Load - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            mbIsLoading = False
        End Try
    End Sub
    Private Sub RefreshData()
        Dim sCompanyNameFilter As String = ""
        Dim sCompanyOrderNumberFilter As String = ""
        Dim sPoNumberFilter As String = ""
        Dim sOrderStatusFilter As String = ""
        Try
            Try
                Cursor = Cursors.WaitCursor




                gbFilter.Visible = False
                If TabControl.SelectedTab.Name.ToUpper.Contains("TEMP") Then
                    MyGrid2.AC_GridDataSet = gobjADO.GetResults(GetParam("TEMP", dtDateFrom.Value.ToShortDateString, dtDateTo.Value.AddDays(1).ToShortDateString, ""), mCmd_GetOrderHistory)
                    If MyGrid2.AC_GridDataSet Is Nothing Then
                        MessageBox.Show("找不到資料", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub

                    End If
                    If MyGrid2.RowCount > 1 Then
                        sCompanyNameFilter = MyGrid2.Columns("Company Name").FilterText
                        sCompanyOrderNumberFilter = MyGrid2.Columns("Quote #").FilterText
                        sPoNumberFilter = MyGrid2.Columns("PO #").FilterText
                        sOrderStatusFilter = MyGrid2.Columns("Order Status").FilterText
                    End If
                    MyGrid2.AC_SortDirectionReset()
                    MyGrid2.AC_ColumnWidthMultipler_Disable = True
                    MyGrid2.AC_RefreshGrid()
                    MyGrid2 = FormatMyGridFont(MyGrid2, New Font("Arial", 10, FontStyle.Bold), New Font("Arial", 12, FontStyle.Regular), 40, 25, New Font("Arial", 15, FontStyle.Regular), 25)
                    If Not rbNew.Checked Then rbNew.Checked = True

                    MyGrid2.Columns("Company Name").FilterText = sCompanyNameFilter
                    MyGrid2.Columns("Quote #").FilterText = sCompanyOrderNumberFilter
                    MyGrid2.Columns("PO #").FilterText = sPoNumberFilter
                    MyGrid2.Columns("Order Status").FilterText = sOrderStatusFilter

                    If Not MyGrid2.Splits(0).DisplayColumns("Order Status").Frozen Then MyGrid2.Splits(0).DisplayColumns("Order Status").Frozen = True
                    If Not MyGrid2.Splits(0).DisplayColumns("Quote #").Frozen Then MyGrid2.Splits(0).DisplayColumns("Quote #").Frozen = True '
                    If Not MyGrid2.Splits(0).DisplayColumns("PO #").Frozen Then MyGrid2.Splits(0).DisplayColumns("PO #").Frozen = True
                    If Not MyGrid2.Splits(0).DisplayColumns("Company Name").Frozen Then MyGrid2.Splits(0).DisplayColumns("Company Name").Frozen = True
                    If Not MyGrid2.Splits(0).DisplayColumns("Order Date").Frozen Then MyGrid2.Splits(0).DisplayColumns("Order Date").Frozen = True
                Else
                    gbFilter.Visible = True
                    Dim sFilter As String = ""
                    'If rbNew.Checked Then
                    '    sFilter = "NEW"
                    'ElseIf rbDeleted.Checked Then
                    '    sFilter = "DELETED"
                    'ElseIf rbReady.Checked Then
                    '    sFilter = "READY"
                    'ElseIf rbClosed.Checked Then
                    '    sFilter = "CLOSED"
                    'Else
                    '    sFilter = "ALL"
                    'End If
                    sFilter = "ALL"
                    MyGrid.AC_GridDataSet = gobjADO.GetResults(GetParam("ORDER", dtDateFrom.Value.ToShortDateString, dtDateTo.Value.AddDays(1).ToShortDateString, sFilter), mCmd_GetOrderHistory)
                    If MyGrid.AC_GridDataSet Is Nothing Then
                        MessageBox.Show("找不到資料", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If MyGrid.RowCount > 1 Then
                        sCompanyNameFilter = MyGrid.Columns("Company Name").FilterText
                        sCompanyOrderNumberFilter = MyGrid.Columns("Order #").FilterText
                        sPoNumberFilter = MyGrid.Columns("PO #").FilterText
                        sOrderStatusFilter = MyGrid.Columns("Order Status").FilterText
                    End If


                    MyGrid.AC_SortDirectionReset()
                    MyGrid.AC_ColumnWidthMultipler_Disable = True
                    MyGrid.AC_RefreshGrid(False, False)
                    MyGrid = FormatMyGridFont(MyGrid, New Font("Arial", 10, FontStyle.Bold), New Font("Arial", 12, FontStyle.Regular), 40, 25, New Font("Arial", 15, FontStyle.Regular), 25)

                    MyGrid.Columns("Order Status").FilterText = rbNew.Text
                    MyGrid.Columns("Company Name").FilterText = sCompanyNameFilter
                    MyGrid.Columns("Order #").FilterText = sCompanyOrderNumberFilter
                    MyGrid.Columns("PO #").FilterText = sPoNumberFilter
                    MyGrid.Columns("Order Status").FilterText = sOrderStatusFilter
                End If



            Catch exp As Exception
                If gbDebugDisplayMSG Then MessageBox.Show("Error GetOrderDetail")
                LogToSystemEvent(gsApplicationClientID, Me.Name, "GetOrderDetail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Finally
                Cursor = Cursors.Default
            End Try
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error RefreshData")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "RefreshData - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub dtDateFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDateFrom.ValueChanged
        RefreshData()
    End Sub

    Private Sub dtDateTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDateTo.ValueChanged
        RefreshData()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshData()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        CloseAllMDIChildForms(gGlobalForm)
        frmGeneral.MdiParent = gGlobalForm
        frmGeneral.Show()
    End Sub

    Private Sub MyGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyGrid.DoubleClick
        Try
            'Dim temDset As DataSet = gobjADO.GetResults(GetParam(MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))).ToString), gobjADO.GetADOCommand("sp_Report_CustomerInvoice"))

            'If temDset Is Nothing Then
            '    MessageBox.Show("Empty DataSet return.")
            '    Exit Sub
            'End If

            'Dim frm As New frmReport
            'frm.SetReportName = "CUSTOMERINVOICE"
            'frm.SetReportDataSet = temDset
            'frm.ShowDialog()
            'frm.Dispose()
            'temDset.Dispose()

            'If MessageBox.Show("Do you want to print Labels for this order < " & MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))).ToString & " > ?", "Print Labels confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '    PrintLabel(MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))))
            'End If       
            Dim frm As New frmSelectPrint
            frm.SetOrderNumber = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))).ToString
            frm.SetCustomerID = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("CustomerID"))).ToString
            frm.SetCompanyName = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Company Name"))).ToString
            frm.SetCustomerName = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Contact Name"))).ToString
            frm.SetPONumber = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("PO #"))).ToString
            frm.SetOrderStatus = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order Status"))).ToString
            frm.ShowDialog()
            frm.Dispose()

            RefreshData()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error MyGrid_DoubleClick")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "MyGrid_DoubleClick - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnCloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrder.Click
        Dim frm As New frmLogin
        Try

            frm.ShowDialog()

            If gbAccess Then
                gbAccess = False
            Else
                MessageBox.Show("You don't have the right to close order.", "Close Order Denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            For j As Integer = 0 To MyGrid.SelectedRows.Count - 1
                If MessageBox.Show("Do you want to close the order < " & MyGrid.Item(j, "Order #").ToString & " > ?", "Close Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    gobjADO.ExecuteSP(GetParam(MyGrid.Item(j, "Order #").ToString), mCmd_CloseOrder)
                End If
            Next
            RefreshData()

            'MyGrid.FilterActive = True
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnCloseOrder_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnCloseOrder_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            MyGrid.SelectedRows.Clear()
            If Not frm Is Nothing Then frm.Dispose()
        End Try
    End Sub

    Private Sub MyGrid_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MyGrid.SelChange
        If MyGrid.SelectedRows.Count > 0 Then
            btnCloseOrder.Enabled = True
            btnCloseOrder.Visible = True
            If giPCNumber = 0 Then btnSaveUnwantedOrder.Visible = True
        Else
            btnCloseOrder.Enabled = False
            btnCloseOrder.Visible = False
            btnSaveUnwantedOrder.Visible = False
        End If
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        'If Not mbIsLoading Then
        '    If rbAll.Checked Then RefreshData()
        'End If
        'MyGrid.Columns("Order Status").FilterText = ""
    End Sub

    Private Sub rbNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNew.CheckedChanged
        'If Not mbIsLoading Then
        '    If rbNew.Checked Then RefreshData()
        'End If
        'If mbIsLoading Then Exit Sub
        'MyGrid.Columns("Order Status").FilterText = rbNew.Text
    End Sub

    Private Sub rbDeleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDeleted.CheckedChanged
        'If Not mbIsLoading Then
        '    If rbDeleted.Checked Then RefreshData()
        'End If
        'MyGrid.Columns("Order Status").FilterText = rbDeleted.Text
    End Sub

    Private Sub rbReady_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReady.CheckedChanged
        'If Not mbIsLoading Then
        '    If rbReady.Checked Then RefreshData()
        'End If
        'MyGrid.Columns("Order Status").FilterText = rbReady.Text
    End Sub

    Private Sub rbClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClosed.CheckedChanged
        'If Not mbIsLoading Then
        '    If rbClosed.Checked Then RefreshData()
        'End If
        'MyGrid.Columns("Order Status").FilterText = rbClosed.Text
    End Sub

    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl.SelectedIndexChanged
        Try
            If Not mbIsLoading Then RefreshData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MyGrid2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyGrid2.DoubleClick
        Try
            'Dim temDset As DataSet = gobjADO.GetResults(GetParam(MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))).ToString), gobjADO.GetADOCommand("sp_Report_CustomerInvoice"))

            'If temDset Is Nothing Then
            '    MessageBox.Show("Empty DataSet return.")
            '    Exit Sub
            'End If

            'Dim frm As New frmReport
            'frm.SetReportName = "CUSTOMERINVOICE"
            'frm.SetReportDataSet = temDset
            'frm.ShowDialog()
            'frm.Dispose()
            'temDset.Dispose()

            'If MessageBox.Show("Do you want to print Labels for this order < " & MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))).ToString & " > ?", "Print Labels confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '    PrintLabel(MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))))
            'End If
            If MyGrid2.Col = MyGrid.Columns.IndexOf(MyGrid.Columns("Order Status")) Then
                MessageBox.Show("select or change Order status")
                Exit Sub
            Else
                Dim frm As New frmSelectPrint
                frm.SetOrderNumber = MyGrid2.Item(MyGrid2.Row, MyGrid2.Columns.IndexOf(MyGrid2.Columns("Quote #"))).ToString
                frm.SetCustomerID = MyGrid2.Item(MyGrid2.Row, MyGrid2.Columns.IndexOf(MyGrid2.Columns("CustomerID"))).ToString
                frm.SetCompanyName = MyGrid2.Item(MyGrid2.Row, MyGrid2.Columns.IndexOf(MyGrid2.Columns("Company Name"))).ToString
                frm.SetCustomerName = MyGrid2.Item(MyGrid2.Row, MyGrid2.Columns.IndexOf(MyGrid2.Columns("Contact Name"))).ToString
                frm.SetPONumber = MyGrid2.Item(MyGrid2.Row, MyGrid2.Columns.IndexOf(MyGrid2.Columns("PO #"))).ToString
                frm.SetOrderStatus = "QUOTE"
                frm.ShowDialog()
                frm.Dispose()
                'If Not gAction = "DELETEDORDER" Then
                '    If MessageBox.Show("Do you want to print Labels for this order < " & MyGrid2.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))).ToString & " > ?", "Print Labels confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                '        PrintLabel(MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("Order #"))))
                '    End If
                'End If
            End If

            RefreshData()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error MyGrid2_DoubleClick")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "MyGrid2_DoubleClick - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            gAction = ""
        End Try
    End Sub

    Private Sub btnSaveUnwantedOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveUnwantedOrder.Click
        If MessageBox.Show("You are going to backup and remove <Unwanted Order(s)>." & Chr(13) & Chr(13) & "Do you want to continue the process?", "Remove Unwanted Orders", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = vbNo Then Exit Sub
        Dim frm As New frmLogin

        frm.ShowDialog()

        If gbAccess Then
            gbAccess = False
        Else
            MessageBox.Show("You don't have the right to save unwanted orders.", "Save Unwanted Orders Denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim cmd_GetUnwantedOrders As SqlCommand = Nothing
        Dim cmd_RemoveUnwantedOrders As SqlCommand = Nothing
        Dim dSet As DataSet = Nothing
        Dim objFolderBrowserDialog As New FolderBrowserDialog
        Dim sSaveFilePath As String = ""
        Dim sFileHeaderName As String = ""
        Dim sFileDetailName As String = ""
        Try
            If MyGrid.SelectedRows.Count = 0 Then Exit Sub
            sFileHeaderName = "\" & Format(Now, "yyyyMMddhhmmss")
            sFileDetailName = sFileHeaderName
            sFileHeaderName = sFileHeaderName & gObjMyDeclares.sBackupHeader
            sFileDetailName = sFileDetailName & gObjMyDeclares.sBackupDetail
            cmd_GetUnwantedOrders = gobjADO.GetADOCommand("sp_SaveUnwantedOrders")
            cmd_RemoveUnwantedOrders = gobjADO.GetADOCommand("sp_DeleteUnwantedOrders")

            If objFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
                sSaveFilePath = objFolderBrowserDialog.SelectedPath
            Else
                Exit Sub
            End If


            For j As Integer = 0 To MyGrid.SelectedRows.Count - 1
                dSet = gobjADO.GetResults(GetParam(MyGrid.Item(MyGrid.SelectedRows(j), "Order #")), cmd_GetUnwantedOrders)
                If Not dSet Is Nothing Then
                    If dSet.Tables(0).Rows.Count < 0 Then Exit Sub
                    If dSet.Tables(1).Rows.Count < 0 Then Exit Sub

                    Dim sHeader As String = dSet.Tables(0).Rows(0).Item("CustomerID").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("OrderNumber").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("TotalQTY").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("TotalPrice").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("TotalTax").ToString & "|" &
                   dSet.Tables(0).Rows(0).Item("TotalDeposit").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("FinalTotalPrice").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("Discount").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("TotalPayment").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("Balance").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("OrderDate").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("DueDate").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("DeliveryType").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("PaymentStatus").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("OrderStatus").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("TaxExemption").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("OrderComment").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("IsTempOrder").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("FilePath").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("FilePath_2").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("PONumber").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("TempOrderNumber").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("DeliveryCharge").ToString & "|" &
                    dSet.Tables(0).Rows(0).Item("CloseDate").ToString & "|" &
                     dSet.Tables(0).Rows(0).Item("TotalCreditApplied").ToString

                    LogToFile(sSaveFilePath & sFileHeaderName, sHeader, Today, True)

                    For i As Integer = 0 To dSet.Tables(1).Rows.Count - 1
                        Dim sDetail As String = dSet.Tables(1).Rows(i).Item("ID").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("OrderNumber").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("ItemNumber").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("GlassName").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("GlassType").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Price").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Size").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Thickness").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("WorkDesc").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("QTY").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Comments").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Width_1").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Width_2").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Width_3").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Height_1").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Height_2").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Height_3").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("PolishLong").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("PolishShort").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("PolishRegular").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("PolishShape").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Miter1Inch").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("HoleLargerThan1Inch").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("HoleSmallerEqual1Inch").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Noth").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Hinge").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("Patch").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("DisplayOrder").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("SQ_FT").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("CustomizeService").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("ItemStatus").ToString & "|" &
                        dSet.Tables(1).Rows(i).Item("RefundTime").ToString

                        LogToFile(sSaveFilePath & sFileDetailName, sDetail, Today, True)
                    Next

                    gobjADO.ExecuteSP(GetParam(MyGrid.Item(MyGrid.SelectedRows(j), "Order #")), cmd_RemoveUnwantedOrders)
                End If
            Next
            MessageBox.Show("You had finish removing all unwanted orders.", "Completed removed Unwanted Orders.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnSaveUnwantedOrder_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnSaveUnwantedOrder_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            If Not cmd_GetUnwantedOrders Is Nothing Then cmd_GetUnwantedOrders.Dispose()
            If Not cmd_RemoveUnwantedOrders Is Nothing Then cmd_RemoveUnwantedOrders.Dispose()
            If Not objFolderBrowserDialog Is Nothing Then objFolderBrowserDialog.Dispose()
            If Not frm Is Nothing Then frm.Dispose()
            MyGrid.SelectedRows.Clear()
            RefreshData()

        End Try
    End Sub
    Private Sub AddGridFilter()
        Try

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error AddGridFilter")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "AddGridFilter - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub rbNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNew.Click
        MyGrid.Columns("Order Status").FilterText = rbNew.Text
    End Sub

    Private Sub rbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbAll.Click
        MyGrid.Columns("Order Status").FilterText = ""
    End Sub

    Private Sub rbReady_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbReady.Click
        MyGrid.Columns("Order Status").FilterText = rbReady.Text
    End Sub

    Private Sub rbClosed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbClosed.Click
        MyGrid.Columns("Order Status").FilterText = rbClosed.Text
    End Sub

    Private Sub rbDeleted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDeleted.Click
        MyGrid.Columns("Order Status").FilterText = rbDeleted.Text
    End Sub
End Class