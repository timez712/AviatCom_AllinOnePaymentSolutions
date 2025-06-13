Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports AviatCom_Lib.AviatCom_Lib
Public Class frmReport
    Private mdSet_Report As New DataSet
    Private msReportName As String = ""
    Private msReportPath As String = ""
    Private mdtReport_Header As DataTable = Nothing
    Private mdtReport_Detail As DataTable = Nothing
    Private mdtCustomerInfo As DataTable = Nothing
    Private mbDisplayOnly As Boolean = False
    Private msPOSPrinterName As String = "MyPOSPrinter1"
    Private mdt_Date As Date = Now.Date.ToShortDateString
    Private msReportDateOnReport As String = "01/01/1900"
    Friend WriteOnly Property SetDisplayOnly As Boolean
        Set(ByVal value As Boolean)
            mbDisplayOnly = value
            'GetDisplayReport()
        End Set
    End Property
    Friend WriteOnly Property SetReportDataSet As DataSet
        Set(value As DataSet)
            mdSet_Report = value
            'GetDisplayReport()
        End Set
    End Property
    Friend WriteOnly Property SetReportName As String
        Set(value As String)
            msReportName = value
        End Set
    End Property
    Friend WriteOnly Property SetFilePath As String
        Set(ByVal value As String)
            msReportPath = value
        End Set
    End Property
    Friend WriteOnly Property SetdtHeader As DataTable
        Set(ByVal value As DataTable)
            mdtReport_Header = value
        End Set
    End Property
    Friend WriteOnly Property SetdtDetail As DataTable
        Set(ByVal value As DataTable)
            mdtReport_Detail = value
        End Set
    End Property
    Friend WriteOnly Property SetdtCustomerInfo As DataTable
        Set(ByVal value As DataTable)
            mdtCustomerInfo = value
        End Set
    End Property
    Friend WriteOnly Property SetDisplayReportDate As String
        Set(ByVal value As String)
            msReportDateOnReport = value
            'GetDisplayReport()
        End Set
    End Property
    Private Sub frmReport_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        If Not mdSet_Report Is Nothing Then mdSet_Report.Dispose()
    End Sub

    Private Sub frmReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            If msReportName.ToString.Trim = "" Then Me.Close()
            If mbDisplayOnly Then
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.Hide()
            End If
            GetDisplayReport()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error frmReport_Load")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frmReport_Load - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

        End Try
    End Sub
    Private Sub GetDisplayReport()
        Try
            'If msReportName.ToUpper = "SALESORDER" Then
            '    Dim cr As New cr_SalesOrder
            '    cr.SetDataSource(FillDataSet_SaleOrder(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "SALESORDER_WITHITEMCODE" Then
            '    Dim cr As New cr_SalesOrder_WithItemCode
            '    cr.SetDataSource(FillDataSet_SaleOrder(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "POS_SALESORDER" Then
            '    Dim cr As New cr_POS_SaleReceipt
            '    cr.SetDataSource(FillDataSet_POS_SaleOrder(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    If mbDisplayOnly Then

            '        CR_ReportViewer.ReportSource = cr
            '    Else

            '        '$$$$$$$ Print Receipt $$$$$$$$$$$$$$$$$
            '        Dim objPrinterPageSetting As New System.Drawing.Printing.PageSettings
            '        objPrinterPageSetting.Landscape = False
            '        'objPrinterPageSetting.PaperSize = New System.Drawing.Printing.PaperSize("Customer Paper Size", 400, 600)

            '        objPrinterPageSetting.PrinterSettings.PrinterName = StrEmployeeInformation.POS_PrinterName
            '        cr.PrintToPrinter(objPrinterPageSetting.PrinterSettings, objPrinterPageSetting, False)

            '        Me.Close()
            '    End If

            'ElseIf msReportName.ToUpper = "MANAGEMENT_SALESORDER" Then
            '    Dim cr As New cr_Management_SaleReport
            '    cr.SetDataSource(FillDataSet_Management_SaleOrder(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "MANAGEMENT_SALESPERFORMANCEORDER" Then
            '    Dim cr As New cr_Management_SalePerformanceReport
            '    cr.SetDataSource(FillDataSet_Management_SaleOrder(mdSet_Report))
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "MANAGEMENT_SALESPERFORMANCEORDER_WITHDETAIL" Then
            '    Dim cr As New cr_Management_SalePerformanceReport_WithDetail
            '    cr.SetDataSource(FillDataSet_Management_SaleOrder(mdSet_Report))
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "MANAGEMENT_EXPENSETRANSACTION" Then
            '    Dim cr As New cr_Management_ExpenseTransaction
            '    cr.SetDataSource(FillDataSet_Management_ExpenseTransaction(mdSet_Report))
            '    CR_ReportViewer.ReportSource = cr
            '    '
            'ElseIf msReportName.ToUpper = "CUSTOMERSERVICE_ORDERHISTORY" Then
            '    Dim cr As New cr_CustomerService_OrderHistory
            '    cr.SetDataSource(FillDataSet_CustomerService_OrderHistory(mdSet_Report))
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "CUSTOMERSERVICE_PAYMENTHISTORY" Then
            '    Dim cr As New cr_CustomerService_PaymentHistory
            '    cr.SetDataSource(FillDataSet_CustomerService_PaymentHistory(mdSet_Report))
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "PURCHASE_ORDER" Then
            '    Dim cr As New cr_Purchasing_PurchaseOrder
            '    cr.SetDataSource(FillDataSet_Purchasing_PurchaesOrder(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "ORDER_KEGPURCHASERAFFIRMATION" Then
            '    Dim cr As New cr_Order_KegPurchaserAffirmation
            '    cr.SetDataSource(FillDataSet_Order_KegPurchaserAffirmation(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "WHOLESALE_SUMMARY" Then
            '    Dim cr As New cr_Management_Wholesale_Summary
            '    cr.SetDataSource(FillDataSet_Management_Wholesale_Summary(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            'ElseIf msReportName.ToUpper = "RETAILSALE_SUMMARY" Then
            '    Dim cr As New cr_Management_RetailSale_Summary
            '    cr.SetDataSource(FillDataSet_Management_RetailSummary(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            '    CR_ReportViewer.Zoom(75)
            '    CR_ReportViewer.PerformAutoScale()
            'ElseIf msReportName.ToUpper = "WHOLESALE_EOF_SUMMARY".ToUpper Then
            '    Dim cr As New cr_Management_Wholesale_Summary_EOD
            '    cr.SetDataSource(FillDataSet_Management_RetailSummary(mdSet_Report))
            '    'cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, msReportPath)
            '    CR_ReportViewer.ReportSource = cr
            '    CR_ReportViewer.Zoom(75)
            '    CR_ReportViewer.PerformAutoScale()
            'Else
            '    MessageBox.Show("No Report Found!")
            '    Me.Close()
            'End If


            If mbDisplayOnly And msReportName.ToUpper = "POS_SALESORDER" Then
                CR_ReportViewer.Zoom(100)
                Me.WindowState = FormWindowState.Normal
                Me.AutoScroll = True
                CR_ReportViewer.PerformAutoScale()
                CR_ReportViewer.Refresh()
                CR_ReportViewer.Visible = True
                CR_ReportViewer.BringToFront()
            Else
                CR_ReportViewer.PerformAutoScale()
            End If


        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetDisplayReport" & Chr(13) & Chr(13) & exp.Message)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetDisplayReport - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

        End Try

    End Sub

   

    'Public Function FillDataSet_Management_ExpenseTransaction(ByRef dSet As DataSet) As ds_Management_ExpenseTransaction
    '    Dim TempDset As New ds_Management_ExpenseTransaction
    '    dSet.EnforceConstraints = False
    '    Try
    '        TempDset.dt_SystemInfo.Adddt_SystemInfoRow(dSet.Tables(0).Rows(0).Item(0).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(1).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(2).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(3).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(4).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(5).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(6).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(7).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(8).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(9).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(10).ToString,
    '                                            dSet.Tables(0).Rows(0).Item(11).ToString,
    '                                            msReportDateOnReport)

    '        If dSet.Tables(1).Rows.Count = 0 Then
    '            TempDset.tb_ExpenseTransaction.Addtb_ExpenseTransactionRow("",
    '                                                                                 "",
    '                                                                                 "",
    '                                                                                 "",
    '                                                                                 "",
    '                                                                                 0.0,
    '                                                                                 0.0,
    '                                                                                 False,
    '                                                                                 "",
    '                                                                                 0.0,
    '                                                                                 "")
    '        Else
    '            For j As Integer = 0 To dSet.Tables(1).Rows.Count - 1
    '                TempDset.tb_ExpenseTransaction.Addtb_ExpenseTransactionRow(dSet.Tables(1).Rows(j).Item(0).ToString,
    '                                                                              dSet.Tables(1).Rows(j).Item(1).ToString,
    '                                                                              dSet.Tables(1).Rows(j).Item(2).ToString,
    '                                                                              dSet.Tables(1).Rows(j).Item(3).ToString,
    '                                                                              dSet.Tables(1).Rows(j).Item(4).ToString,
    '                                                                              Val(dSet.Tables(1).Rows(j).Item(5).ToString),
    '                                                                              Val(dSet.Tables(1).Rows(j).Item(6).ToString),
    '                                                                              dSet.Tables(1).Rows(j).Item(7),
    '                                                                              dSet.Tables(1).Rows(j).Item(8).ToString,
    '                                                                              Val(dSet.Tables(1).Rows(j).Item(9).ToString),
    '                                                                              dSet.Tables(1).Rows(j).Item(10).ToString)
    '            Next

    '        End If

    '        Return TempDset
    '    Catch exp As Exception
    '        If gbDebugDisplayMSG Then MessageBox.Show("Error FillDataSet_Management_RetailSummary")
    '        LogToSystemEvent(gsApplicationClientID, Me.Name, "FillDataSet_Management_RetailSummary - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
    '        Return Nothing
    '    Finally
    '        Cursor = Cursors.Default
    '    End Try
    'End Function
End Class