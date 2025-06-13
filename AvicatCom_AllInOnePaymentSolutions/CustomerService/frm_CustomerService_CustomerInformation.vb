Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports AviatCom_Lib.AviatCom_Lib
Public Class frm_CustomerService_CustomerInformation
    WithEvents MyGrid As AviatCom_DefaultGrid = Nothing
    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 13)
    Private mobjMyGridFooterFont As New Font("Arial", 13)
    Private mbSelectPop As Boolean = False
    Friend WriteOnly Property SetSelectPop As Boolean
        Set(ByVal value As Boolean)
            mbSelectPop = value
        End Set
    End Property
    Private msSQLStr As String = "SELECT CONVERT(VARCHAR(20),Date,111) AS 'Date',MerchantName,MerchantNumber,FileNumber,Terminal " &
                                   " ,SN,OwnerName,SS,BusinessPhone,ContractPhone,Address " &
                                   " ,Businesstrack,UserID,Salerep,TaxID,BusinesstrackPassword " &
                                   " ,CommissionReceived,CommissionAdjusted,CommissionBalance,Model1,Model2 " &
                                   " ,Model3,SerialNumber1,SerialNumber2,SerialNumber3,ID " &
                                   " ,PCI,Password,Status,MerchantID " &
                                   " FROM tb_MerchantInformation WITH (NOLOCK) ORDER BY Status DESC,MerchantName "

    Private Sub frm_CustomerService_CustomerInformation_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
       
        Try
            If Not IsActiveOpenedForm(frmGeneral) Then
                Dim frm As New frmGeneral
                'frm.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom
                frm.Show()
            End If
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "RefreshData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub


    Private Sub frm_CustomerService_CustomerInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Add_NewAccessCode("NET:Customer:CustomerInformation", "Customer Information", "") Then
            MessageBox.Show("Please assign role access for ( NET:Customer:CustomerInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
        End If
        If Not CheckAccessRight("NET:Customer:CustomerInformation") Then
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
        End If

        Me.AutoScaleMode = AutoScaleMode.Dpi
        MyGrid = New AviatCom_DefaultGrid(C1TrueDBGrid1)
        MyGrid.FetchRowStyles = True

        MyGrid.AC_AllowFilter = True
        MyGrid.AllowDelete = False
        MyGrid.AllowAddNew = False
        MyGrid.AllowSort = True

        MyGrid.AllowColSelect = False
        MyGrid.BorderStyle = BorderStyle.Fixed3D
        MyGrid.ColumnFooters = False


        MyGrid.Anchor = C1TrueDBGrid1.Anchor ' AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom
        C1TrueDBGrid1.Dispose()
        MyGrid.Show()
        RefreshData()
        btnRefreshData.BackColor = Color.GreenYellow
    End Sub
    Private Sub RefreshData()

        Try

            Cursor = Cursors.WaitCursor
            MyGrid.FilterSaveGridFilters()
            If Not MyGrid.AC_GridDataSet Is Nothing Then
                MyGrid.AC_GridDataSet.Dispose()
                MyGrid.AC_GridDataSet = Nothing
            End If
            MyGrid.AC_GridDataSet = SQL_GetStandardGridDataSet(SQL_QueryGetTableResult(msSQLStr), False, , GetParam("~", "~", "~", "@", "@", "@", "@", "@", "~", "@", "~", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "@", "~"))



            MyGrid.AC_SortDirectionReset()
            MyGrid.AC_ColumnWidthMultipler_Disable = True

            MyGrid.AC_RefreshGrid()
            'MyGrid.Splits(0).DisplayColumns.Item("SalesRep").Frozen = True
            'MyGrid.Splits(0).DisplayColumns.Item("Comm%").Frozen = True
            'MyGrid.Splits(0).DisplayColumns.Item("WHNo").Frozen = True
            'MyGrid.Splits(0).DisplayColumns.Item("PaymentPercent").Frozen = True
            'MyGrid.Splits(0).DisplayColumns.Item("CheckNo").Frozen = True
            'MyGrid.Splits(0).DisplayColumns.Item("InvoiceNo").Merge = C1.Win.C1TrueDBGrid.ColumnMergeEnum.Restricted
            'With MyGrid.Splits(0).DisplayColumns.Item("InvoiceNo").Style
            '    .HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            '    .VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
            'End With
            'MyGrid.Splits(0).DisplayColumns.Item("MerchantNumber").Frozen = True

            ' If Not mbGridFormated Then
            '$$$$$$$$$$ Set Standard Size

            ' FormatMyGridCaption(MyGrid, New Font("Arial", MyGrid.CaptionStyle.Font.Size * 1.2), Color.LightYellow, , MyGrid.Splits(0).ColumnCaptionHeight * 1.8)
            If Not MyGrid.GetSetGridDisplayFormatLoad Then
                '$$$$$$$$$$ Set Even row color
                MyGrid.AlternatingRows = True
                MyGrid.EvenRowStyle.BackColor = Color.LightCyan

                ' $$$$$$$$$$$ Set Selected row back color
                MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                'MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                '$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"




                MyGrid.RowHeight = Me.Font.Size * 2
                miMyGridCaptionHeight = MyGrid.Splits(0).ColumnCaptionHeight * 2
                mobjMyGridFont = New Font("Arial", MyGrid.CaptionStyle.Font.Size * 1.4)
                mobjMyGridFooterFont = New Font("Arial", MyGrid.CaptionStyle.Font.Size * 1.4)
                MyGrid.GetSetGridDisplayFormatLoad = True
            End If

            FormatMyGridFont(MyGrid, mobjMyGridFont, mobjMyGridFont, , , mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

            'MyGrid.Columns("MaxComm").NumberFormat = "Currency"
            'MyGrid.Columns("CommPaid").NumberFormat = "Currency"


            'MyGrid.Columns("OrderSubTotal").NumberFormat = "Currency"
            ''MyGrid.Columns("NetFeightAmt").NumberFormat = "Currency"
            ''MyGrid.Columns("NetOtherFeeAmt").NumberFormat = "Currency"
            'MyGrid.Columns("PaymentDiscount").NumberFormat = "Currency"
            'MyGrid.Columns("Net Disco").NumberFormat = "Currency"
            'MyGrid.Columns("PaidSubTotal").NumberFormat = "Currency"
            'MyGrid.Columns("PaidFeright").NumberFormat = "Currency"


            ''MyGrid.Columns("Pmt. Amt").NumberFormat = "Currency"
            'MyGrid.Columns("PaidOther").NumberFormat = "Currency"
            'MyGrid.Columns("FC Price").NumberFormat = "Currency"
            'MyGrid.Columns("Tot.Acc.Pmt").NumberFormat = "Currency"


            'For j As Integer = 0 To MyGrid.Columns.Count - 1
            '    If MyGrid.Columns(j).Caption.ToString.EndsWith("%") Then
            '        MyGrid.Columns(j).NumberFormat = "0%"
            '    ElseIf MyGrid.Columns(j).ToString.EndsWith("$") Then
            '        MyGrid.Columns(j).NumberFormat = "Currency"
            '    ElseIf MyGrid.Columns(j).ToString.EndsWith("Amt") Then
            '        MyGrid.Columns(j).NumberFormat = "Currency"
            '    End If
            'Next
            MyGrid.FormatColumeDisplayMask()
            MyGrid.Splits(0).DisplayColumns("AddSub$").FetchStyle = True
            MyGrid.Splits(0).DisplayColumns("Add.Comm%").FetchStyle = True
            'mdTotalCommission = MyGrid.AC_GridDataSet.Tables(2).Compute("SUM('CommPaid')", Nothing)

            'RefreshData_ReturnCredit()
            'RefreshData_Credit()
            MyGrid.FilterRestallFilters()
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "RefreshData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MyGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyGrid.DoubleClick
        Try
            If Not MyGrid.CheckFilterFocused Then
                If mbSelectPop Then
                    Me.DialogResult = MyGrid.Item(MyGrid.Row, "MerchantID")
                Else
                    Dim dRow() As DataRow = MyGrid.AC_GridDataSet.Tables(MyGrid.AC_GridDataSet.Tables.Count - 1).Select("ID = " & Val(MyGrid.Columns("ID").Value.ToString))
                    If Not IsActiveOpenedForm(frm_CustomerService_CustomerInformationDetails) Then
                        Dim frm As New frm_CustomerService_CustomerInformationDetails
                        frm.SetDataRow = dRow(0)
                        frm.SetNewRecord = False
                        frm.Show()
                    End If
                End If

                'Using frm As New frm_CustomerService_CustomerInformationDetails
                '    frm.SetDataRow = dRow(0)
                '    frm.SetNewRecord = False
                '    frm.Show()
                'End Using
                'RefreshData()
            End If
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "MyGrid_DoubleClick Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnNewMerchant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewMerchant.Click
        Try

            Dim dRow() As DataRow = MyGrid.AC_GridDataSet.Tables(MyGrid.AC_GridDataSet.Tables.Count - 1).Select("ID = " & Val(MyGrid.Item(MyGrid.Row, "ID").ToString))
            If Not IsActiveOpenedForm(frm_CustomerService_CustomerInformationDetails) Then
                Dim frm As New frm_CustomerService_CustomerInformationDetails
                frm.SetNewRecord = True
                frm.Show()
            End If
            
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "btnNewMerchant_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData.Click
        RefreshData()
    End Sub

    Private Sub MyGrid_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles MyGrid.FetchRowStyle
        If MyGrid.Item(e.Row, "Status") Then
            e.CellStyle.BackColor = lblActiveLegend.backcolor
        Else
            e.CellStyle.BackColor = lblUnActive.BackColor
        End If
    End Sub

    Private Sub btnFollowupTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFollowupTask.Click
        If Not IsActiveOpenedForm(frm_Customer_FollowupConfig) Then
            Dim frm As New frm_Customer_FollowupConfig
            frm.SetPreviousForm = Me
            frm.Show()
        End If
    End Sub

    Private Sub btnRequestPaperHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnRequestPaperHistory.Click
        If Not IsActiveOpenedForm(frm_MerchantPaperRequestHistory) Then
            Dim frm As New frm_MerchantPaperRequestHistory
            frm.Show()
        End If
    End Sub
End Class