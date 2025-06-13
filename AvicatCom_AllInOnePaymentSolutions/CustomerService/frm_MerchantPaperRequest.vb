Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data
Public Class frm_MerchantPaperRequest
    Private bSetDefault As Boolean = True
    Private msSQLStr_Get As String = <Get>
                                        SELECT tbPaperRequests.RefNumber
                                                ,tbPaperRequests.MerchantID
                                                ,tbPaperRequests.Status
                                                ,tbPaperRequests.ShippingAddress
                                                ,tbPaperRequests.ShippingCity
                                                ,tbPaperRequests.ShippingState
                                                ,tbPaperRequests.ShippingZipCode
                                                ,tbPaperRequests.ConfirmedShippedDate
                                                ,tbPaperRequests.OrderedBox
                                                ,tbPaperRequests.RollsInOneBox
                                                ,tbPaperRequests.AddtionalRolls
                                                ,tbPaperRequests.Remarks
                                                ,tb_MerchantInformation.MerchantName
                                        FROM tbPaperRequests WITH (NOLOCK) 
                                        INNER JOIN tb_MerchantInformation 
                                        ON tbPaperRequests.MerchantID = tb_MerchantInformation.MerchantID 

                                    </Get>

    Friend WriteOnly Property SetRefNumber As String
        Set(value As String)
            GetPaperRequest(value)
        End Set
    End Property
    Friend WriteOnly Property ClearForm As Boolean
        Set(value As Boolean)
            ClearFields()
        End Set
    End Property

    Friend WriteOnly Property SetMerchantID As Integer
        Set(value As Integer)
            txtMerchantName.Tag = Val(value)
        End Set
    End Property
    Friend WriteOnly Property SetMerchantName As String
        Set(value As String)
            txtMerchantName.Text = value
        End Set
    End Property
    Friend WriteOnly Property SetMerchantAddress As String
        Set(value As String)
            txtCompanyAddress.Text = value
        End Set
    End Property


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frm_MerchantPaperRequest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            ' ClearFields()
            'GetPaperRequest(txtMerchantName.Tag)
            If bSetDefault Then
                dtConfirmedShippedDate.Visible = True
                btnSetToday.Visible = True
                If cboShipper.Text = "" Then cboShipper.SelectedIndex = 0
                If cboStatus.Text = "" Then cboStatus.SelectedIndex = 1
                If cboTotalBoxRequest.Text = 0 Then cboTotalBoxRequest.SelectedIndex = 0
                If cboRollsInOneBox.Text = 0 Then cboRollsInOneBox.SelectedIndex = 0
                'If Not chkConfirmedShipped.Checked Then
                chkConfirmedShipped.Checked = True
                dtConfirmedShippedDate.Value = Today
                'End If
            End If


        Catch ex As Exception
            LogToFile(Me.Name & ".log", "frm_MerchantPaperRequest_Load Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub


    Private Sub cboTotalBoxRequest_TextChanged(sender As Object, e As System.EventArgs) Handles cboTotalBoxRequest.TextChanged
        CalculateTotalRolls()
    End Sub


    Private Sub cboRollsInOneBox_TextChanged(sender As Object, e As System.EventArgs) Handles cboRollsInOneBox.TextChanged
        CalculateTotalRolls()
    End Sub
    Private Sub CalculateTotalRolls()
        Try
            txtTotalRollsRequested.Text = Val(cboTotalBoxRequest.Text) * Val(cboRollsInOneBox.Text) + Val(txtAddtionalRolls.Text)
        Catch ex As Exception
            LogToFile(Me.Name & ".log", "CalculateTotalRolls Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If MessageBox.Show("Are you sure you wants to save?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        UpdatePaperRequest()
    End Sub
    Private Sub UpdatePaperRequest()
        Try
            If Val(lblDisplayRequestID.Tag) <> 0 Then
                'Update Existing request
                If SQL_ExecuteSP("UPDATE tbPaperRequests SET " & _
                                 "Status = '" & cboStatus.Text.Replace("'", "''") & "'" & _
                                 ",ShippingAddress = '" & txtCompanyAddress.Text.Replace("'", "''") & "' " & _
                                 ",ShippingCity = '' " & _
                                 ",ShippingState = '' " & _
                                 ",ShippingZipCode = '' " & _
                                 ",ConfirmedShippedDate = " & IIf(chkConfirmedShipped.Checked, "'" & dtConfirmedShippedDate.Value & "'", "NULL") & _
                                 ",OrderedBox = " & Val(cboTotalBoxRequest.Text) & _
                                 ",RollsInOneBox = " & Val(cboRollsInOneBox.Text) & _
                                 ",AddtionalRolls = " & Val(txtAddtionalRolls.Text) & _
                                 ",Remarks = '" & txtRemarks.Text.Replace("'", "''") & "' " & _
                                 ",isConfirmedShipDate = " & IIf(chkConfirmedShipped.Checked, 1, 0) & _
                                 ",Shipper = '" & cboShipper.Text.Replace("'", "''") & "'" & _
                                 " WHERE RefNumber = '" & Val(lblDisplayRequestID.Tag) & "'") Then
                    MessageBox.Show("Paper request update successfully", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Unable to update paper request!!" & vbNewLine & vbNewLine & "Please try again!", "Unable To Update Paper Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                'New request
                Using dTable As DataTable = SQL_ExecuteSP_ReturnTable(" EXEC spGetNewRequestID 'Main',0,0 ")
                    If Not dTable Is Nothing Then
                        If dTable.Rows.Count = 1 Then
                            lblDisplayRequestID.Tag = dTable.Rows(0).Item(0).ToString
                            If SQL_ExecuteSP("INSERT INTO tbPaperRequests " & _
                                                                                 " (RefNumber,MerchantID,Status,ShippingAddress,ShippingCity " & _
                                                                                 " ,ShippingState,ShippingZipCode,ConfirmedShippedDate,OrderedBox,RollsInOneBox " & _
                                                                                 " ,AddtionalRolls,Remarks,isConfirmedShipDate,Shipper) VALUES (" & _
                                                                                 " '" & Val(lblDisplayRequestID.Tag) & "'" & _
                                                                                 ", '" & Val(txtMerchantName.Tag) & "'" & _
                                                                                 ", '" & cboStatus.Text.Replace("'", "''") & "'" & _
                                                                                 ", '" & txtCompanyAddress.Text.Replace("'", "''") & "' " & _
                                                                                 ", '' " & _
                                                                                 ", '' " & _
                                                                                 ", '' " & _
                                                                                 ", " & IIf(dtConfirmedShippedDate.Visible, "'" & dtConfirmedShippedDate.Value & "'", "NULL") & _
                                                                                 ", " & Val(cboTotalBoxRequest.Text) & _
                                                                                 ", " & Val(cboRollsInOneBox.Text) & _
                                                                                 ", " & Val(txtAddtionalRolls.Text) & _
                                                                                 ", '" & txtRemarks.Text.Replace("'", "''") & "'" &
                                                                                 ", " & IIf(chkConfirmedShipped.Checked, 1, 0) &
                                                                                 ", '" & cboShipper.Text.Replace("'", "''") & "')") Then
                                MessageBox.Show("New Paper request successfully saved", "Save Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Unable to save new paper request!!" & vbNewLine & vbNewLine & "Please try again!", "Unable To Save Paper Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If

                End Using

            End If
        Catch ex As Exception
            LogToFile(Me.Name & ".log", "UpdatePaperRequest Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub
    Private Sub GetPaperRequest(sRefNumber As String)
        Try
            If Val(sRefNumber) <= 0 Then Exit Sub
            Using dTable As DataTable = SQL_QueryGetTableResult(msSQLStr_Get & " WHERE tbPaperRequests.RefNumber = '" & sRefNumber.Replace("'", "''") & "'")
                If dTable IsNot Nothing Then
                    If dTable.Rows.Count = 1 Then
                        bSetDefault = False
                        'Select tbPaperRequests.RefNumber
                        '                       ,tbPaperRequests.MerchantID
                        '                       ,tbPaperRequests.Status
                        '                       ,tbPaperRequests.ShippingAddress
                        '                       ,tbPaperRequests.ShippingCity
                        '                       ,tbPaperRequests.ShippingState
                        '                       ,tbPaperRequests.ShippingZipCode
                        '                       ,tbPaperRequests.ConfirmedShippedDate
                        '                       ,tbPaperRequests.OrderedBox
                        '                       ,tbPaperRequests.RollsInOneBox
                        '                       ,tbPaperRequests.AddtionalRolls
                        '                       ,tbPaperRequests.Remarks
                        '                       ,tbPaperRequests.MerchantName

                        lblDisplayRequestID.Text = "RequestID: " & dTable.Rows(0).Item("RefNumber").ToString
                        lblDisplayRequestID.Tag = Val(dTable.Rows(0).Item("RefNumber").ToString)
                        txtMerchantName.Text = dTable.Rows(0).Item("MerchantName").ToString
                        txtMerchantName.Tag = dTable.Rows(0).Item("MerchantID").ToString
                        txtCompanyAddress.Text = dTable.Rows(0).Item("ShippingAddress").ToString
                        'cboCompanyCity.Text = dTable.Rows(0).Item("ShippingCity").ToString
                        'cboCompanyState.Text = dTable.Rows(0).Item("ShippingState").ToString
                        'cboCompanyZipCode.Text = dTable.Rows(0).Item("ShippingZipCode").ToString
                        cboTotalBoxRequest.Text = Val(dTable.Rows(0).Item("OrderedBox").ToString)
                        cboRollsInOneBox.Text = Val(dTable.Rows(0).Item("RollsInOneBox").ToString)
                        txtAddtionalRolls.Text = Val(dTable.Rows(0).Item("AddtionalRolls").ToString)
                        cboStatus.Text = dTable.Rows(0).Item("Status").ToString
                        If IsDBNull(dTable.Rows(0).Item("ConfirmedShippedDate")) Then
                            dtConfirmedShippedDate.Visible = False
                        Else
                            dtConfirmedShippedDate.Visible = True
                            dtConfirmedShippedDate.Value = FormatDateTime(dTable.Rows(0).Item("ConfirmedShippedDate").ToString, DateFormat.ShortDate)
                        End If

                        txtRemarks.Text = dTable.Rows(0).Item("Remarks").ToString
                    Else
                        ClearFields()
                    End If
                Else
                    ClearFields()
                End If
            End Using
        Catch ex As Exception
            LogToFile(Me.Name & ".log", "GetPaperRequest Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub
    Private Sub ClearFields()
        Try
            lblDisplayRequestID.Text = "RequestID:"
            lblDisplayRequestID.Tag = ""
            txtMerchantName.Text = ""
            txtMerchantName.Tag = ""
            txtCompanyAddress.Text = ""
            'cboCompanyCity.Text = ""
            'cboCompanyState.Text = ""
            'cboCompanyZipCode.Text = ""
            cboTotalBoxRequest.Text = 0
            cboRollsInOneBox.Text = 0
            txtAddtionalRolls.Text = 0
            cboStatus.Text = "New"
            dtConfirmedShippedDate.Visible = False
        Catch ex As Exception
            LogToFile(Me.Name & ".log", "ClearFields Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub

    Private Sub btnComfirmShipDate_Click(sender As System.Object, e As System.EventArgs) Handles btnSetToday.Click
        dtConfirmedShippedDate.Visible = True
        dtConfirmedShippedDate.Value = Now
    End Sub

    Private Sub chkConfirmedShipped_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkConfirmedShipped.CheckedChanged
        If chkConfirmedShipped.Checked Then
            dtConfirmedShippedDate.Visible = True
            btnSetToday.Visible = True
        Else
            dtConfirmedShippedDate.Visible = False
            btnSetToday.Visible = False
        End If
    End Sub

    Private Sub txtAddtionalRolls_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAddtionalRolls.TextChanged
        CalculateTotalRolls()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If Val(lblDisplayRequestID.Tag) = 0 Then
                MessageBox.Show("Unable to delete Paper Request at this time!" & vbNewLine & vbNewLine & "Please close current screen and try again!", "Unable To Delete Record Now", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you wants to delete the Paper Request?" & vbNewLine & vbNewLine & "Deleted paper request will no longer exists in the system!!", "Confirm Delete Paper Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            If SQL_ExecuteSP("DELETE FROM tbPaperRequests WHERE RefNumber =  " & Val(lblDisplayRequestID.Tag)) Then
                MessageBox.Show("Paper request successfully deleted", "Successfully Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Unable to delete paper request!!" & vbNewLine & vbNewLine & "Please try again!", "Unable To Delete Paper Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error process btnDelete_Click: " & vbNewLine & ex.Message, "Error process btnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "btnDelete_Click Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub
End Class