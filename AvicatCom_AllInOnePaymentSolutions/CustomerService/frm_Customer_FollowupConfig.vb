Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data.SqlClient
Imports System.Data

Public Class frm_Customer_FollowupConfig
    Private mdtFollowup As New DataTable
    Private miMerchantID As Integer = 0
    Private miFollowupEmployeeID As Integer = 0
    Private miInputerID As Integer = 0

    Private objPreviousForm As Form
    Friend WriteOnly Property SetFollowupID As Integer
        Set(ByVal value As Integer)
            lblFolloupID.Text = value
        End Set
    End Property
    Friend WriteOnly Property SetMerchantID As Integer
        Set(ByVal value As Integer)
            miMerchantID = value
            DisplayMerchantInformation(miMerchantID)
        End Set
    End Property
    Friend WriteOnly Property SetPreviousForm As Form
        Set(ByVal value As Form)
            objPreviousForm = value
        End Set
    End Property

    Private Sub frm_Customer_FollowupConfig_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            If Not objPreviousForm Is Nothing Then
                If Not objPreviousForm.IsDisposed Then
                    objPreviousForm.Show()
                    objPreviousForm.BringToFront()
                End If
            End If

        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "frm_Customer_FollowupConfig_Disposed Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "frm_Customer_FollowupConfig_Disposed Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub frm_Customer_FollowupConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cboPriority.Items.Clear()
            Dim dRow_Priority() As DataRow = strSystemConfig.tb_SelectOption.Select("Type = 'Priority'", "SelectionDispalySort ASC")
            For j As Integer = 0 To dRow_Priority.Length - 1
                cboPriority.Items.Add(dRow_Priority(j).Item("Selection").ToString)
            Next

            cboFollowUpType.Items.Clear()
            Dim dRow_FollowupType() As DataRow = strSystemConfig.tb_SelectOption.Select("Type = 'FolowupType'", "SelectionDispalySort")
            For j As Integer = 0 To dRow_FollowupType.Length - 1
                cboFollowUpType.Items.Add(dRow_FollowupType(j).Item("Selection").ToString)
            Next

            cboFollowupEmployee.Items.Clear()
            For j As Integer = 0 To strSystemConfig.tb_Empolyee.Rows.Count - 1
                cboFollowupEmployee.Items.Add(strSystemConfig.tb_Empolyee.Rows(j).Item("FirstName").ToString & " " & strSystemConfig.tb_Empolyee.Rows(j).Item("LastName").ToString & " - " & strSystemConfig.tb_Empolyee.Rows(j).Item("EmployeeID"))

            Next
            cboFollowupEmployee.AutoCompleteMode = AutoCompleteMode.Append
            cboFollowupEmployee.DropDownStyle = ComboBoxStyle.DropDownList

            btnCloseFollowup.Enabled = True
            btnUpdateFollowup.Enabled = True

            txtCreatedBy.Text = StrEmployeeInformation.EmployeeName
            If Val(lblFolloupID.Text) > 0 Then GetFollowupInformation(Val(lblFolloupID.Text))
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "frm_Customer_FollowupConfig_Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "frm_Customer_FollowupConfig_Load Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnRemindDate_Today_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemindDate_Today.Click
        Try
            dtRemindDate.Value = Now
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnRemindDate_Today_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnRemindDate_Today_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnRemindDate_Tomorrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemindDate_Tomorrow.Click
        Try
            dtRemindDate.Value = Now.AddDays(1).ToShortDateString
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnRemindDate_Tomorrow_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnRemindDate_Tomorrow_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnRemindDate_NextTwoDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemindDate_NextTwoDays.Click
        Try
            dtRemindDate.Value = Now.AddDays(2).ToShortDateString
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnRemindDate_NextTwoDays_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnRemindDate_NextTwoDays_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnRemindDate_NextWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemindDate_NextWeek.Click
        Try
            dtRemindDate.Value = Now.AddDays(1)
            Do While 1 = 1
                If DayOfWeek.Monday = dtRemindDate.Value.DayOfWeek Then
                    Exit Do
                Else
                    dtRemindDate.Value = dtRemindDate.Value.AddDays(1).ToShortDateString
                End If
            Loop
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnRemindDate_NextWeek_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnRemindDate_NextWeek_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnRemindDate_NextMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemindDate_NextMonth.Click
        Try
            dtRemindDate.Value = Month(Now.AddMonths(1)) & "/1/" & Year(Now.AddMonths(1))
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnRemindDate_NextMonth_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnRemindDate_NextMonth_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub chkReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReminder.CheckedChanged
        Try
            EnableReminder(chkReminder.Checked)
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "chkReminder_CheckedChanged Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "chkReminder_CheckedChanged Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub EnableReminder(ByVal bEnable As Boolean)
        Try
            dtRemindDate.Enabled = bEnable
            btnRemindDate_Today.Enabled = bEnable
            btnRemindDate_Tomorrow.Enabled = bEnable
            btnRemindDate_NextTwoDays.Enabled = bEnable
            btnRemindDate_NextWeek.Enabled = bEnable
            btnRemindDate_NextMonth.Enabled = bEnable
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "EnableReminder Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "EnableReminder Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub


    Private Sub btnCloseFollowup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseFollowup.Click
        Try
            If MessageBox.Show("Are you sure you wants to Close this Followup?", "Close Followup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            If SQL_ExecuteSP("UPDATE tbFollowUp SET isClosed = 1, ClosedTime = GETDATE() WHERE FollowupID = " & lblFolloupID.Text) Then
                ActionLog(Me.Name, lblFolloupID.Text, "Followup", "", "", "Closed Followup -> " & "UPDATE tbFollowUp SET isClosed = 1, ClosedTime = GETDATE() WHERE FollowupID = " & lblFolloupID.Text, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                MessageBox.Show("Successfully Closed Followup", "Successfully Closed Followup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Unable to Closed Followup" & vbNewLine & vbNewLine & "Please check network connection and try again", "Unable To Closed Followup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnCloseFollowup_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnCloseFollowup_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnUpdateFollowup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateFollowup.Click
        Try
            UpdateField()
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "btnUpdateFollowup_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnUpdateFollowup_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub UpdateField()
        Dim sWarning As String = ""
        If cboPriority.Text = "" Then
            ErrorProvider.SetError(cboPriority, "Missing Priority!")
            sWarning = "Missing Priority Type!"
        Else
            ErrorProvider.SetError(cboPriority, "")
        End If
        If cboFollowUpType.Text = "" Then
            ErrorProvider.SetError(cboFollowUpType, "Missing Followup Type!")
            sWarning = sWarning & vbNewLine & vbNewLine & "Missing Priority Type!"
        Else
            ErrorProvider.SetError(cboFollowUpType, "")
        End If
        If cboFollowupEmployee.Text = "" Then
            ErrorProvider.SetError(cboFollowupEmployee, "Missing Followup Employee!")
            sWarning = sWarning & vbNewLine & vbNewLine & "Missing Followup Employee!"
        Else
            ErrorProvider.SetError(cboFollowupEmployee, "")
        End If
        If sWarning <> "" Then
            MessageBox.Show("Missing information:" & vbNewLine & vbNewLine & sWarning, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim sSQLStr As String = ""
        Dim iFollowupID As Integer = Val(lblFolloupID.Text)
        Dim arrTemp As Array = Split(cboFollowupEmployee.Text, " - ")

        Try
            If iFollowupID > 0 Then
                sSQLStr = "UPDATE tbFollowUp SET Priority = '" & cboPriority.Text.Replace("'", "''") & "'" &
                            ", FollowupType = '" & cboFollowUpType.Text.Replace("'", "''") & "'" &
                            ", FollowUpEmployeeID = " & arrTemp(1) &
                            ", Header = '" & txtHeader.Text.Replace("'", "''") & "'" &
                            ", Details = '" & txtDetails.Text.Replace("'", "''") & "'" &
                            ", isReminderSet = " & IIf(chkReminder.Checked, 1, 0) &
                            ", ReminderDate = '" & dtRemindDate.Value.ToShortDateString & "'" &
                            ", MerchantID = " & miMerchantID &
                            ", LastUpdateTime = GETDATE() " &
                            " WHERE FollowupID = " & iFollowupID
            Else
                iFollowupID = GetNewFollowupID(StrEmployeeInformation.Location)
                sSQLStr = "INSERT INTO tbFollowUp (FollowupID,Priority,InputerID,FollowUpEmployeeID,ReminderDate " &
                            " ,FollowupType,Header,Details,isReminderSet " &
                            " ,MerchantID ) VALUES ( " &
                            iFollowupID &
                            ", '" & cboPriority.Text.Replace("'", "''") & "'" &
                            ", " & StrEmployeeInformation.EmployeeID &
                            ", " & arrTemp(1) &
                            ", '" & dtRemindDate.Value.ToShortDateString & "'" &
                            ", '" & cboFollowUpType.Text.Replace("'", "''") & "'" &
                            ", '" & txtHeader.Text.Replace("'", "''") & "'" &
                            ", '" & txtDetails.Text.Replace("'", "''") & "'" &
                            ", " & IIf(chkReminder.Checked, 1, 0) &
                            ", " & miMerchantID &
                            ") "

            End If
            If SQL_ExecuteSP(sSQLStr) Then
                If sSQLStr.StartsWith("UPDATE") Then
                    ActionLog(Me.Name, iFollowupID, "Followup", "", "", "Update Followup -> " & sSQLStr, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                    MessageBox.Show("Successfully updated followup!!" & vbNewLine & vbNewLine & "Please check network connection and try again!", "Successfully updated followup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ActionLog(Me.Name, iFollowupID, "Followup", "", "", "New Followup -> " & sSQLStr, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                    MessageBox.Show("Successfully Added New followup!!" & vbNewLine & vbNewLine & "Please check network connection and try again!", "Successfully Added New followup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                lblFolloupID.Text = iFollowupID
            Else
                If sSQLStr.StartsWith("UPDATE") Then
                    MessageBox.Show("Unable to update followup!!" & vbNewLine & vbNewLine & "Please check network connection and try again!", "Unable To Update Followup", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Unable to Add New followup!!" & vbNewLine & vbNewLine & "Please check network connection and try again!", "Unable To Add New Followup", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "UpdateField Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "UpdateField Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub GetFollowupInformation(ByVal iFollowupID As Integer)
        Try
            Using dTable As DataTable = SQL_QueryGetTableResult("SELECT * FROM tbFollowUp WITH (NOLOCK) WHERE FollowupID = " & iFollowupID)
                If dTable Is Nothing Then
                    MessageBox.Show("Followup task no longer exisit!", "Followup Task No Longer Exisit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    If dTable.Rows.Count = 0 Then
                        MessageBox.Show("Followup task not found!!", "Followup Task Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                      
                        cboPriority.Text = dTable.Rows(0).Item("Priority").ToString
                        lblFolloupID.Text = dTable.Rows(0).Item("FollowupID").ToString
                        dtRemindDate.Value = dTable.Rows(0).Item("ReminderDate").ToString
                        cboFollowUpType.Text = dTable.Rows(0).Item("FollowupType").ToString
                        txtHeader.Text = dTable.Rows(0).Item("Header").ToString
                        txtDetails.Text = dTable.Rows(0).Item("Details").ToString
                        chkReminder.Checked = dTable.Rows(0).Item("isReminderSet")
                        miInputerID = Val(dTable.Rows(0).Item("InputerID").ToString)
                        txtCreatedBy.Text = GetEmpolyeeNameByID(miInputerID)
                        miMerchantID = Val(dTable.Rows(0).Item("MerchantID").ToString)
                        miFollowupEmployeeID = Val(dTable.Rows(0).Item("FollowUpEmployeeID").ToString)
                        cboFollowupEmployee.Text = GetEmpolyeeNameByID(miFollowupEmployeeID) & " - " & miFollowupEmployeeID
                        DisplayMerchantInformation(miMerchantID)
                        btnCloseFollowup.Enabled = Not dTable.Rows(0).Item("isClosed")
                        btnUpdateFollowup.Enabled = Not dTable.Rows(0).Item("isClosed")
                       
                    End If
                End If
            End Using
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetFollowupInformation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "GetFollowupInformation Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub lblID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFolloupID.Click
        If Val(lblFolloupID.Text) > 0 Then
            btnUpdateFollowup.Text = "Update Followup"
        Else
            btnUpdateFollowup.Text = "Add New Followup"
        End If
    End Sub
    Friend Function GetNewFollowupID(ByVal sLocation As String) As String
        Try
            If gCmd_GetNewFollowupID.CommandText = "" Then
                gCmd_GetNewFollowupID = gobjADO.GetADOCommand("spGetNewFollowupID")
            End If
            Using dTable As DataTable = gobjADO.GetTable(gCmd_GetNewFollowupID, GetParam(sLocation, StrEmployeeInformation.EmployeeID))
                If dTable Is Nothing Then
                    MessageBox.Show("Check DB Connection.  Fail on get new FollowupID", "Fail to get db Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                Else
                    Return dTable.Rows(0).Item(0).ToString
                End If
            End Using
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetNewFollowupID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "GetNewFollowupID Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return Nothing
        End Try
    End Function

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        Using frm As New frm_CustomerService_CustomerInformation
            frm.SetSelectPop = True
            miMerchantID = Val(frm.ShowDialog)
            DisplayMerchantInformation(miMerchantID)
        End Using
    End Sub
    Private Sub DisplayMerchantInformation(ByVal iMerchantID As Integer)
        Try
            txtMerchantName.Text = ""
            txtMerchantNumber.Text = ""
            If iMerchantID <= 0 Then Exit Sub
            Using dTable As DataTable = SQL_QueryGetTableResult("SELECT * FROM tb_MerchantInformation WITH (NOLOCK) WHERE MerchantID = ")
                If dTable IsNot Nothing Then
                    If dTable.Rows.Count > 0 Then
                        txtMerchantName.Text = dTable.Rows(0).Item("MerchantName").ToString
                        txtMerchantNumber.Text = dTable.Rows(0).Item("MerchantNumber").ToString
                    End If

                End If
            End Using
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "DisplayMerchantInformation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "DisplayMerchantInformation Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub lblID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblFolloupID.TextChanged
        If Val(lblFolloupID.Text) > 0 Then
            btnUpdateFollowup.Text = "Update Followup"
        Else
            btnUpdateFollowup.Text = "Add New Followup"
        End If
    End Sub
End Class