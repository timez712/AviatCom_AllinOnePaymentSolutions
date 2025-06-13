Imports AviatCom_Lib.AviatCom_Lib
Public Class frm_MerchantPaperRequestHistory

    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 10)
    Private mobjMyGridFooterFont As New Font("Arial", 10)
    WithEvents MyGrid_RequestedPapers As AviatCom_DefaultGrid = Nothing
    Private msSQLStr_RequestedPaper As String = <msSQLStr_RequestedPaper>
                                                    SELECT tbPaperRequests.MerchantID
		                                                    ,tbPaperRequests.RefNumber
                                                            ,Shipper
                                                            ,CASE WHEN isConfirmedShipDate = 0 THEN 'Yes' ELSE 'No' END AS 'CMF'
		                                                    ,LTRIM(RTRIM(tb_MerchantInformation.MerchantName )) AS 'MerchantName'
		                                                    ,tbPaperRequests.Status
		                                                    ,tbPaperRequests.ConfirmedShippedDate
		                                                    ,(tbPaperRequests.OrderedBox * tbPaperRequests.RollsInOneBox) + tbPaperRequests.AddtionalRolls AS 'TotalRolls'
		                                                    ,tbPaperRequests.ShippingAddress
		                                                    /*,tbPaperRequests.ShippingCity
		                                                    ,tbPaperRequests.ShippingState*/
		                                                    ,tbPaperRequests.Remarks
                                                            ,CASE WHEN tbPaperRequests.ConfirmedShippedDate IS NULL THEN 0 ELSE 1 END AS 'DisplayOrder'
                                                    FROM tbPaperRequests WITH (NOLOCK)
                                                    INNER JOIN tb_MerchantInformation WITH (NOLOCK)
                                                    ON tbPaperRequests.MerchantID = tb_MerchantInformation.MerchantID  
                                                    WHERE tbPaperRequests.ConfirmedShippedDate IS NULL 
                                                    OR ( tbPaperRequests.ConfirmedShippedDate BETWEEN 'MyParameter_DateFrom' AND 'MyParameter_DateTo' OR isConfirmedShipDate = 0  )
                                                    ORDER BY DisplayOrder,ConfirmedShippedDate DESC,RefNumber DESC
                                                </msSQLStr_RequestedPaper>
    Private msSelectedMerchantName As String = ""
    Friend WriteOnly Property SetSelectedMerchantName As String
        Set(value As String)
            msSelectedMerchantName = value
        End Set
    End Property

    Private Sub frm_MerchantPaperRequestHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            MyGrid_RequestedPapers = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_RequestedPapers.FetchRowStyles = True
            MyGrid_RequestedPapers.AC_AllowFilter = True
            MyGrid_RequestedPapers.AllowFilter = True
            MyGrid_RequestedPapers.AllowDelete = False
            MyGrid_RequestedPapers.AllowAddNew = False
            MyGrid_RequestedPapers.AllowSort = True
            MyGrid_RequestedPapers.AllowColSelect = True
            MyGrid_RequestedPapers.BorderStyle = BorderStyle.Fixed3D
            MyGrid_RequestedPapers.ColumnFooters = False
            MyGrid_RequestedPapers.Anchor = C1TrueDBGrid1.Anchor
            C1TrueDBGrid1.Dispose()
            MyGrid_RequestedPapers.Show()
            dtDateFrom.Value = Now.AddMonths(-2)
            GetRequestedPaper()
            If msSelectedMerchantName <> "" Then
                MyGrid_RequestedPapers.Columns("MerchantName").FilterText = msSelectedMerchantName
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetRequestedPaper()
        Try
            Cursor = Cursors.WaitCursor
            MyGrid_RequestedPapers.FilterSaveGridFilters()
            MyGrid_RequestedPapers.AC_GridDataSet = SQL_GetStandardGridDataSet(SQL_QueryGetTableResult(msSQLStr_RequestedPaper.Replace("MyParameter_DateFrom", dtDateFrom.Value).Replace("MyParameter_DateTo", dtDateTo.Value)), False, , GetParam("@", "@", "~", "~", "~", "~", "~", "~", "~"))

            MyGrid_RequestedPapers.AC_SortDirectionReset()
            MyGrid_RequestedPapers.AC_ColumnWidthMultipler_Disable = True
            MyGrid_RequestedPapers.AC_RefreshGrid()

            'MyGrid_RequestedPapers.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_RequestedPapers.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_RequestedPapers.AlternatingRows = True
                'MyGrid_RequestedPapers.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_RequestedPapers.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_RequestedPapers.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_RequestedPapers.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_RequestedPapers.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_RequestedPapers.CaptionStyle.Font.Size * 0.8)
                MyGrid_RequestedPapers.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_RequestedPapers, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_RequestedPapers, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

            MyGrid_RequestedPapers.FilterRestallFilters()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MyGrid_RequestedPapers_DoubleClick(sender As Object, e As System.EventArgs) Handles MyGrid_RequestedPapers.DoubleClick
        Try
            If Not MyGrid_RequestedPapers.CheckFilterFocused Then
                Using frm As New frm_MerchantPaperRequest
                    frm.ClearForm = True
                    frm.SetMerchantID = MyGrid_RequestedPapers.Columns("MerchantID").Value
                    frm.SetMerchantName = MyGrid_RequestedPapers.Columns("MerchantName").Value
                    frm.SetRefNumber = MyGrid_RequestedPapers.Columns("RefNumber").Value
                    frm.ShowDialog()
                    GetRequestedPaper()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnRefreshData_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshData.Click
        GetRequestedPaper()
    End Sub

    Private Sub MyGrid_RequestedPapers_FetchRowStyle(sender As Object, e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles MyGrid_RequestedPapers.FetchRowStyle
        Try
            If MyGrid_RequestedPapers.Item(e.Row, "Shipper").ToString.ToUpper = "??" Or MyGrid_RequestedPapers.Item(e.Row, "Shipper").ToString.Trim = "" Then
                e.CellStyle.BackColor = lblMissingShipper.BackColor
            ElseIf MyGrid_RequestedPapers.Item(e.Row, "CMF").ToString.ToUpper = "YES" Then
                e.CellStyle.BackColor = lblConfirmShipped.BackColor
            Else
                e.CellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class