
Imports MySql.Data.MySqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports C1.Win.C1TrueDBGrid
Imports System.Data

Public Class frm_Report_RestaurantBusinessSummary
    Dim DB As New DBConnection_MySQL

    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder

    WithEvents MyGrid_RestaurantSummary As AviatCom_DefaultGrid = Nothing

    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 10)
    Private mobjMyGridFooterFont As New Font("Arial", 10)

    Private msSQLStr_GetRestaurantSummary As String = $" spReport_GetAllActiveRestaurantPaymentSummary ('2021-04-01','2021-05-01') "
    Private Sub btnLastMonth_Click(sender As Object, e As EventArgs) Handles btnLastMonth.Click
        ChangeByMonth(dtDateFrom, dtDateTo, Now, -1)

    End Sub

    Private Sub ChangeByMonth(ByRef dtFrom As DateTimePicker, ByRef dtTo As DateTimePicker, objDate As Date, iAdjustMont As Integer)
        Try
            Dim objMyDate As Date
            objMyDate = New DateTime(objDate.Year, objDate.Month, 1)
            objMyDate = objMyDate.AddMonths(iAdjustMont)
            dtFrom.Value = objMyDate.Date
            objMyDate = objMyDate.AddMonths(1)
            objMyDate = objMyDate.AddDays(-1)
            dtTo.Value = objMyDate.Date
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnPreviousMonth_Click(sender As Object, e As EventArgs) Handles btnPreviousMonth.Click
        ChangeByMonth(dtDateFrom, dtDateTo, dtDateFrom.Value.Date, -1)
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        ChangeByMonth(dtDateFrom, dtDateTo, dtDateFrom.Value.Date, 1)
    End Sub

    Private Sub btnGetSummary_Click(sender As Object, e As EventArgs) Handles btnGetSummary.Click
        Dim objDateTo As Date = dtDateTo.Value.AddDays(1)
        Try
            GetRestaurantMenu(dtDateFrom.Value.Year & "-" & dtDateFrom.Value.Month & "-" & dtDateFrom.Value.Day, objDateTo.Year & "-" & objDateTo.Month & "-" & objDateTo.Day)
        Catch ex As Exception
            MessageBox.Show("btnGetSummary_Click Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, Me.Name, Me.Name, "", "", "Error - btnGetSummary_Click" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnGetSummary_Click - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub

    Private Sub frm_Report_RestaurantBusinessSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi
        Try
            MyGrid_RestaurantSummary = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_RestaurantSummary.FetchRowStyles = True
            MyGrid_RestaurantSummary.AC_AllowFilter = True
            MyGrid_RestaurantSummary.AllowFilter = True
            MyGrid_RestaurantSummary.AllowDelete = False
            MyGrid_RestaurantSummary.AllowAddNew = False
            MyGrid_RestaurantSummary.AllowUpdate = False
            MyGrid_RestaurantSummary.AllowSort = True
            MyGrid_RestaurantSummary.AllowColSelect = True
            MyGrid_RestaurantSummary.BorderStyle = BorderStyle.Fixed3D
            MyGrid_RestaurantSummary.ColumnFooters = False
            MyGrid_RestaurantSummary.Anchor = C1TrueDBGrid1.Anchor
            C1TrueDBGrid1.Dispose()
            MyGrid_RestaurantSummary.Show()

            btnLastMonth.PerformClick()
        Catch ex As Exception
            MessageBox.Show("frm_Report_RestaurantBusinessSummary_Load Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, Me.Name, Me.Name, "", "", "Error - frm_Report_RestaurantBusinessSummary_Load" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frm_Report_RestaurantBusinessSummary_Load - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub
    Private Sub GetRestaurantMenu(sDateFrom As String, sDateTo As String)
        Try



            Cursor = Cursors.WaitCursor
            MyGrid_RestaurantSummary.FilterSaveGridFilters()
            MyGrid_RestaurantSummary.AC_GridDataSet = SQL_GetStandardGridDataSet(GetRestaurantSummary(sDateFrom, sDateTo))
            'If MyGrid_RestaurantSummary.AC_GridDataSet.Tables(MyGrid_RestaurantSummary.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_RestaurantSummary.AC_GridDataSet.Tables(MyGrid_RestaurantSummary.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_RestaurantSummary.AC_SortDirectionReset()
            MyGrid_RestaurantSummary.AC_ColumnWidthMultipler_Disable = True
            MyGrid_RestaurantSummary.AC_RefreshGrid()

            'MyGrid_RestaurantSummary.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_RestaurantSummary.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_RestaurantSummary.AlternatingRows = True
                'MyGrid_RestaurantSummary.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_RestaurantSummary.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_RestaurantSummary.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_RestaurantSummary.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_RestaurantSummary.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_RestaurantSummary.CaptionStyle.Font.Size * 0.8)
                MyGrid_RestaurantSummary.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_RestaurantSummary, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_RestaurantSummary, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)
            MyGrid_RestaurantSummary.FilterRestallFilters()
        Catch ex As Exception
            MessageBox.Show("GetRestaurantMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, Me.Name, Me.Name, "", "", "Error - GetRestaurantMenu " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetRestaurantMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Function GetRestaurantSummary(sDateFrom As String, sDateTo As String) As DataTable
        Dim dTable As New DataTable
        Dim MySQLReader As MySqlDataReader
        Try
            DB.CreateConnection()
            Using cmd As New MySqlCommand 'Create command
                cmd.Connection = DB.conn    'Inert connection string
                cmd.CommandText = "spReport_GetAllActiveRestaurantPaymentSummary"   'insert SP Name
                cmd.CommandType = CommandType.StoredProcedure   'select try as sp
                cmd.Parameters.AddWithValue("dtDateTimeFrom", sDateFrom)
                cmd.Parameters.AddWithValue("dtDateTimeTo", sDateTo)
                String.Format(Now, "yyyy-MM-dd")
                Try
                    MySQLReader = cmd.ExecuteReader
                    dTable.Load(MySQLReader)
                Catch ex As MySqlException
                    MessageBox.Show(Me, "Error loading data from db!!")
                End Try
                'Using dt As New DataTable
                '    dt.Load(MySQLReader)
                '    If dt.Rows(0).Item(0) = "SUCCESS" Then
                '        'MySQLReader.NextResult()
                '        Using dt2 As New DataTable
                '            dt2.Load(MySQLReader)
                '            If dt2.Rows.Count > 0 Or bFirstRund Then
                '                If bFirstRund Then bFirstRund = False
                '                dt2.TableName = "NewOrderReceived"
                '                RaiseEvent NewData(dt2.Copy, mbSkipFirstPrints)
                '            End If
                '            'MsgBox(dt2.Columns.Count)
                '        End Using
                '        'ds2.Tables.Add(dt2)
                '        If mbSkipFirstPrints Then mbSkipFirstPrints = False
                '    Else
                '        RaiseEvent ErrorMSG(dt.Item(0).Item(0).ToString, dt.Item(0).Item(1).ToString)

                '    End If
                'End Using
            End Using




        Catch ex As Exception
            MessageBox.Show("GetRestaurantMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, Me.Name, Me.Name, "", "", "Error - GetRestaurantMenu " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetRestaurantMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            DB.ConnectionClose()
            If MySQLReader IsNot Nothing Then
                MySQLReader.Dispose()
                MySQLReader = Nothing
            End If
        End Try
        Return dTable
    End Function
End Class