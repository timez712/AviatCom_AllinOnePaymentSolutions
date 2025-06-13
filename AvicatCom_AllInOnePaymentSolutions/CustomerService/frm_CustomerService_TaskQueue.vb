Imports System.Windows.Forms
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data
Public Class frm_CustomerService_TaskQueue
    WithEvents MyGrid_Request As AviatCom_DefaultGrid = Nothing
    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 13)
    Private mobjMyGridFooterFont As New Font("Arial", 13)
    Private mtbMyTasks As New DataTable
    Private mMaxDateTime As DateTime
    Private miTotalTasks As Integer = 0
    Private mbDisplayAllTasks As Boolean = False
    Private Sub frm_CustomerService_TaskQueue_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        MyTimer2.Stop()
        Debug.WriteLine("Actived")
    End Sub

    Private Sub frm_CustomerService_TaskQueue_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Debug.WriteLine("DeActived")
    End Sub

    Private Sub frm_CustomerService_TaskQueue_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter

    End Sub

    Private Sub frm_CustomerService_TaskQueue_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frm_CustomerService_TaskQueue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub frm_CustomerService_TaskQueue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub
    Private Sub frm_CustomerService_TaskQueue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Close()
            MyGrid_Request = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_Request.FetchRowStyles = True
            MyGrid_Request.AC_AllowFilter = True
            MyGrid_Request.AllowDelete = False
            MyGrid_Request.AllowAddNew = False
            MyGrid_Request.AllowSort = True
            MyGrid_Request.AllowColSelect = False
            MyGrid_Request.BorderStyle = BorderStyle.Fixed3D
            MyGrid_Request.ColumnFooters = False
            MyGrid_Request.Anchor = C1TrueDBGrid1.Anchor ' AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom
            MyGrid_Request.SendToBack()
            C1TrueDBGrid1.Dispose()


            If StrEmployeeInformation.EmployeeRole.ToUpper = "Administrator".ToUpper Or StrEmployeeInformation.EmployeeRole.ToUpper = "Manager".ToUpper Then
                mbDisplayAllTasks = True
            Else
                mbDisplayAllTasks = False
            End If

            'GetRequest()
            'MyTimer.Interval = 20000
            'MyTimer.Start()
            'MyTimer2.Interval = 1800
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "frm_CustomerService_TaskQueue_Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "frm_CustomerService_TaskQueue_Load Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub GetRequest()
        Try
            Cursor = Cursors.Default
            'If Not mtbMyTasks Is Nothing Then
            '    mtbMyTasks.Clear()
            'End If
            mtbMyTasks = SQL_QueryGetTableResult(" SELECT Priority,Header,ReminderDate,Details,HistoryLog " &
                                                                                        " ,CreateTime,isReminderSet,ID,FollowupID,LastUpdateTime " &
                                                                                        " FROM tbFollowUp WITH (NOLOCK) " & IIf(mbDisplayAllTasks, " WHERE FollowUpEmployeeID = " & StrEmployeeInformation.EmployeeID, " ") & " ORDER BY isClosed, Priority,ReminderDate ")
            If MyGrid_Request.AC_GridDataSet.Tables.Count = 0 Then
                If mtbMyTasks.Rows.Count > 0 Then
                    mMaxDateTime = mtbMyTasks.Compute("MAX(CreateTime)", Nothing)
                    miTotalTasks = mtbMyTasks.Rows.Count
                    MyGrid_Request.AC_GridDataSet = SQL_GetStandardGridDataSet(mtbMyTasks, False, , GetParam("~", "~", "~", "~", "~" _
                                                                                                                   , "~", "~", "@", "@", "~"))
                    MyTimer2.Start()
                End If
            Else
                If mtbMyTasks.Rows.Count > 0 Then

                    If mMaxDateTime <> mtbMyTasks.Compute("MAX(LastUpdateTime)", Nothing) Then
                        MyTimer2.Start()
                        mMaxDateTime = mtbMyTasks.Compute("MAX(LastUpdateTime)", Nothing)
                        MyGrid_Request.AC_GridDataSet.Dispose()
                        MyGrid_Request.AC_GridDataSet = Nothing
                        MyGrid_Request.AC_GridDataSet = SQL_GetStandardGridDataSet(mtbMyTasks, False, , GetParam("~", "~", "~", "~", "~" _
                                                                                                                   , "~", "~", "@", "@", "~"))
                    Else
                        If miTotalTasks = mtbMyTasks.Rows.Count Then
                            MyGrid_Request.AC_GridDataSet.Dispose()
                            MyGrid_Request.AC_GridDataSet = Nothing
                            MyGrid_Request.AC_GridDataSet = SQL_GetStandardGridDataSet(mtbMyTasks, False, , GetParam("~", "~", "~", "~", "~" _
                                                                                                                       , "~", "~", "@", "@", "~"))
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If
            'MyGrid_Request.AC_GridDataSet.Tables.Clear()
           

            MyGrid_Request.AC_SortDirectionReset()
            MyGrid_Request.AC_ColumnWidthMultipler_Disable = True

            MyGrid_Request.AC_RefreshGrid()
            If Not MyGrid_Request.GetSetGridDisplayFormatLoad Then
                '$$$$$$$$$$ Set Even row color
                MyGrid_Request.AlternatingRows = True
                MyGrid_Request.EvenRowStyle.BackColor = Color.LightCyan

                MyGrid_Request.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_Request.Splits(0).ColumnCaptionHeight * 0.8
                mobjMyGridFont = New Font("Arial", MyGrid_Request.CaptionStyle.Font.Size * 1)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_Request.CaptionStyle.Font.Size * 1)
                MyGrid_Request.GetSetGridDisplayFormatLoad = True
            End If

            FormatMyGridFont(MyGrid_Request, mobjMyGridFont, mobjMyGridFont, , , mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_Request, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetRequest Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "GetRequest Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub MyTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyTimer.Tick
        GetRequest()
    End Sub

    Private Sub MyTimer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTimer2.Tick
        Try
            FlashWindow(Me.Handle, 1)
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "MyTimer2_Tick Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "MyTimer2_Tick Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub


    Private Sub MyGrid_Request_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyGrid_Request.DoubleClick
        Try
            If Not MyGrid_Request.CheckFilterFocused Then
                Using frm As New frm_Customer_FollowupConfig
                    frm.SetFollowupID = Val(MyGrid_Request.Item(MyGrid_Request.Row, "FollowupID"))
                    frm.ShowDialog()
                    Me.Show()
                    Me.BringToFront()
                End Using

            End If
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "MyTimer2_Tick Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "MyTimer2_Tick Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
End Class