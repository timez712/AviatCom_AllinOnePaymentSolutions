Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data
Imports C1.Win.C1TrueDBGrid
Imports System.Net

Public Class frm_CustomerService_CustomerInformationDetails

    WithEvents MyGrid_MerchantServices As AviatCom_DefaultGrid = Nothing
    Private mdTable As New DataTable
    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 10)
    Private mobjMyGridFooterFont As New Font("Arial", 10)

    Dim mdRow As Data.DataRow = Nothing
    Dim mbNewRecord As Boolean = False
    Dim mbManager As Boolean = False
    Dim miMerchantID As Integer = 0

    Private msSQLString_MerchantServices As String = <MerchantServices>
                                                         SELECT ID,MerchantID,isActive,MerchantService,MerchantServiceCode
                                                            ,Remarks,ActiveDate,ExpiredDate,LastUpdateEmployeeID,LastUpdateTime
                                                            ,CreateTime
                                                            FROM dbo.tbMerchantServices WITH (NOLOCK)
                                                            WHERE MerchantID = MyParameter_MerchantID
                                                     </MerchantServices>
    Private msSQLString_DeleteMerchantService As String = <DeleteMerchantService>
                                                              DELETE dbo.tbMerchantServices
                                                                WHERE ID = MyParameter_ID
                                                          </DeleteMerchantService>
    Private msSQLString_UpdateMerchantService As String = <UpdateMerchantService>
                                                              UPDATE tbMerchantServices
                                                                SET isActive = MyParameter_isActive
                                                                ,MerchantService = N'MyParameter_MerchantServiceType'
                                                                ,MerchantServiceCode = N'MyParameter_MerchantServiceCode'
                                                                ,Remarks = N'MyParameter_Remarks'
                                                                ,ActiveDate = MyParameter_ActiveDate
                                                                ,ExpiredDate = MyParameter_ExpiredDate
                                                                ,LastUpdateEmployeeID = MyParameter_LastUpdateEmployeeID
                                                                ,LastUpdateTime = GETDATE()
                                                                WHERE ID = MyParameter_MerchantID
                                                          </UpdateMerchantService>
    Private msSQLString_AddMerchantService As String = <AddMerchantService>
                                                              INSERT INTO dbo.tbMerchantServices
                                                                   (MerchantID
                                                                   ,MerchantService
                                                                   ,MerchantServiceCode
                                                                   ,Remarks
                                                                   ,isActive
                                                                   ,ActiveDate
                                                                   ,ExpiredDate
                                                                   ,LastUpdateEmployeeID)
                                                             VALUES
                                                                   (
                                                                   MyParameter_MerchantID
                                                                   ,N'MyParameter_MerchantServiceType'
                                                                   ,N'MyParameter_MerchantServiceCode'
                                                                   ,N'MyParameter_Remarks'
                                                                   ,MyParameter_isActive
                                                                   ,MyParameter_ActiveDate
                                                                   ,MyParameter_ExpiredDate
                                                                   ,MyParameter_LastUpdateEmployeeID
		                                                           )
                                                          </AddMerchantService>
    Friend WriteOnly Property SetDataRow As Data.DataRow
        Set(ByVal value As Data.DataRow)
            mdRow = value
        End Set
    End Property
    Friend WriteOnly Property SetNewRecord As Boolean
        Set(ByVal value As Boolean)
            mbNewRecord = value
        End Set
    End Property

    Private Sub frm_CustomerService_CustomerInformationDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            If MyGrid_MerchantServices IsNot Nothing Then
                MyGrid_MerchantServices = Nothing
            End If
            If mdTable IsNot Nothing Then
                mdTable.Dispose()
                mdTable = Nothing
            End If
            If Not IsActiveOpenedForm(frm_CustomerService_CustomerInformation) Then
                Dim frm As New frm_CustomerService_CustomerInformation
                'frm.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom
                frm.Show()
            End If
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "frm_CustomerService_CustomerInformationDetails_Disposed Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Private Sub frm_CustomerService_CustomerInformationDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Add_NewAccessCode("NET:Customer:CustomerDetail", "Customer Detail", "") Then
                MessageBox.Show("Please assign role access for ( NET:Customer:CustomerDetail ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If
            If Not CheckAccessRight("NET:Customer:CustomerDetail") Then
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            Me.AutoScaleMode = AutoScaleMode.Dpi

            MyGrid_MerchantServices = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_MerchantServices.FetchRowStyles = True
            MyGrid_MerchantServices.AC_AllowFilter = True
            MyGrid_MerchantServices.AllowFilter = True
            MyGrid_MerchantServices.AllowDelete = True
            MyGrid_MerchantServices.AllowAddNew = True
            MyGrid_MerchantServices.AllowSort = True
            MyGrid_MerchantServices.AllowColSelect = True
            MyGrid_MerchantServices.BorderStyle = BorderStyle.Fixed3D
            MyGrid_MerchantServices.ColumnFooters = False
            MyGrid_MerchantServices.Anchor = C1TrueDBGrid1.Anchor
            C1TrueDBGrid1.Dispose()
            MyGrid_MerchantServices.Show()



            If mbNewRecord Then
                'txtDate.Text = Now.Date
                DisablenableFormEditing(False)
                chkStatus.Checked = True
                GetMerchantService(0)
            Else
                'txtDate.Text = mdRow.Item("Date").ToString
                miMerchantID = Val(mdRow.Item("MerchantID").ToString)
                lblSystemMerchantID.Text = miMerchantID
                txtBusinessName.Text = mdRow.Item("MerchantName").ToString
                txtBusinessAddress.Text = mdRow.Item("Address").ToString
                txtMerchantNumber.Text = mdRow.Item("MerchantNumber").ToString
                txtFileNumber.Text = mdRow.Item("FileNumber").ToString
                txtOwnerName.Text = mdRow.Item("OwnerName").ToString
                txtBusinessPhone.Text = mdRow.Item("BusinessPhone").ToString
                txtContactNumber.Text = mdRow.Item("ContractPhone").ToString
                txtSSNumber.Text = "N/A"
                txtSSNumber.Tag = mdRow.Item("SS").ToString
                txtTaxID.Text = "N/A"
                txtTaxID.Tag = mdRow.Item("TaxID").ToString
                txtModel1.Text = mdRow.Item("Model1").ToString
                txtModel2.Text = mdRow.Item("Model2").ToString
                txtModel3.Text = mdRow.Item("Model3").ToString
                txtSerial1.Text = mdRow.Item("SerialNumber1").ToString
                txtSerial2.Text = mdRow.Item("SerialNumber2").ToString
                txtSerial3.Text = mdRow.Item("SerialNumber3").ToString
                txtMMOName.Text = mdRow.Item("Businesstrack").ToString
                txtMMOPassword.Text = mdRow.Item("BusinesstrackPassword").ToString
                txtSales.Text = mdRow.Item("Salerep").ToString
                txtCommissionReceived.Text = mdRow.Item("CommissionReceived").ToString
                txtCommissionAdjusted.Text = mdRow.Item("CommissionAdjusted").ToString
                txtCommissionBalance.Text = mdRow.Item("CommissionBalance").ToString
                txtUserID.Text = mdRow.Item("UserID").ToString
                If IsDBNull(mdRow.Item("PCI")) Then
                    txtPCIDate.Text = ""
                Else
                    txtPCIDate.Text = ConvertToDateString(FormatDateTime(mdRow.Item("PCI"), DateFormat.ShortDate))
                End If
                If IsDBNull(mdRow.Item("Date")) Or mdRow.Item("Date").ToString = "" Then
                    txtDate.Text = ""
                Else
                    txtDate.Text = ConvertToDateString(FormatDateTime(mdRow.Item("Date"), DateFormat.ShortDate))
                End If
                'txtDate.Text = IIf(IsDBNull(mdRow.Item("Date")), "", ConvertToDateString(FormatDateTime(mdRow.Item("Date"), DateFormat.ShortDate)))
                txtPassword.Text = mdRow.Item("Password").ToString
                chkStatus.Checked = mdRow.Item("Status")
                DisablenableFormEditing(True)
                GetMerchantService(miMerchantID)
            End If

        Catch exp As Exception
            LogToFile(Me.Name & ".log", "frm_CustomerService_CustomerInformationDetails_Load Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnDisplayInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayInformation.Click
        If txtDisplayPassword.Text = "" Then
            MessageBox.Show("Please enter password above before continue.", "Missing Password", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)

            Exit Sub
        End If
        If txtDisplayPassword.Text = "Admin168" Then
            txtTaxID.Text = txtTaxID.Tag
            txtSSNumber.Text = txtSSNumber.Tag
            mbManager = True
        Else
            MessageBox.Show("Password mismatch!", "Password Mismatch", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim sSQLStr As String = ""
            If mbNewRecord Then
                Using dTable As DataTable = SQL_ExecuteSP_ReturnTable(" EXEC spGetNewMerchantID 'Main',0,0 ")
                    If Not dTable Is Nothing Then
                        If dTable.Rows.Count = 1 Then
                            sSQLStr = " INSERT INTO tb_MerchantInformation " &
                           " (Date,MerchantName,MerchantNumber,FileNumber,Terminal " &
                           " ,SN,OwnerName,SS,BusinessPhone,ContractPhone,Address " &
                           " ,Businesstrack,UserID,Salerep,TaxID,BusinesstrackPassword " &
                           " ,CommissionReceived,CommissionAdjusted,CommissionBalance,Model1,Model2 " &
                           " ,Model3,SerialNumber1,SerialNumber2,SerialNumber3,PCI,Password " &
                           " ,Status,MerchantID) " &
                           " VALUES (" &
                           " " & IIf(txtDate.Text.Replace("/", "").Trim = "", "NULL", " '" & txtDate.Text & "'") &
                           " ,'" & txtBusinessName.Text.Trim.Replace("'", "''") & "'" &
                           " ,'" & txtMerchantNumber.Text & "'" &
                           " ,'" & txtFileNumber.Text & "'" &
                           " ,''" &
                           " ,''" &
                           " ,'" & txtOwnerName.Text & "'" &
                           " ,'" & txtSSNumber.Text & "'" &
                           " ,'" & txtBusinessPhone.Text & "'" &
                           " ,'" & txtContactNumber.Text & "'" &
                           " ,'" & txtBusinessAddress.Text & "'" &
                           " ,'" & txtMMOName.Text & "'" &
                           " ,'" & txtUserID.Text & "'" &
                           " ,'" & txtSales.Text & "'" &
                           " ,'" & txtTaxID.Text & "'" &
                           " ,'" & txtMMOPassword.Text & "'" &
                           " ," & Val(txtCommissionReceived.Text) &
                           " ," & Val(txtCommissionAdjusted.Text) &
                           " ," & Val(txtCommissionBalance.Text) &
                           " ,'" & txtModel1.Text & "'" &
                           " ,'" & txtModel2.Text & "'" &
                           " ,'" & txtModel3.Text & "'" &
                           " ,'" & txtSerial1.Text & "'" &
                           " ,'" & txtSerial2.Text & "'" &
                           " ,'" & txtSerial3.Text & "'" &
                           "," & IIf(txtPCIDate.Text.Replace("/", "").Trim = "", "NULL", " '" & txtPCIDate.Text & "'") &
                           " ,'" & txtPassword.Text & "'" &
                           " ," & IIf(chkStatus.Checked, 1, 0) &
                           " , " & Val(dTable(0).Item(0).ToString) & ")"
                        Else
                            MessageBox.Show("Unable to got new MerchantID!!" & vbNewLine & vbNewLine & "Please contact your vendor!", "Unable To Get New MerchantID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Unable to locate MerchantID counter!!" & vbNewLine & vbNewLine & "Please contact your vendor!", "Unable To Find MerchantID Counter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End Using





            Else
                sSQLStr = "UPDATE tb_MerchantInformation SET " &
                    " Date = " & IIf(txtDate.Text.Replace("/", "").Trim = "", "NULL", " '" & txtDate.Text & "'") &
                    " ,MerchantName = '" & txtBusinessName.Text.Trim.Replace("'", "''") & "'" &
                    " ,MerchantNumber = '" & txtMerchantNumber.Text & "'" &
                    " ,FileNumber = '" & txtFileNumber.Text & "'" &
                    " ,Terminal = ''" &
                    " ,SN = ''" &
                    " ,OwnerName = '" & txtOwnerName.Text & "'" &
                    IIf(mbManager, " ,SS = '" & txtSSNumber.Text & "'", "") &
                    " ,BusinessPhone = '" & txtBusinessPhone.Text & "'" &
                    " ,ContractPhone = '" & txtContactNumber.Text & "'" &
                    " ,Address = '" & txtBusinessAddress.Text & "'" &
                    " ,Businesstrack = '" & txtMMOName.Text & "'" &
                    " ,UserID = '" & txtUserID.Text & "'" &
                    " ,Salerep = '" & txtSales.Text & "'" &
                    IIf(mbManager, " ,TaxID = '" & txtTaxID.Text & "'", "") &
                    " ,BusinesstrackPassword = '" & txtMMOPassword.Text & "'" &
                    " ,CommissionReceived = " & Val(txtCommissionReceived.Text) &
                    " ,CommissionAdjusted = " & Val(txtCommissionAdjusted.Text) &
                    " ,CommissionBalance = " & Val(txtCommissionBalance.Text) &
                    " ,Model1 = '" & txtModel1.Text & "'" &
                    " ,Model2 = '" & txtModel2.Text & "'" &
                    " ,Model3 = '" & txtModel3.Text & "'" &
                    " ,SerialNumber1 = '" & txtSerial1.Text & "'" &
                    " ,SerialNumber2 = '" & txtSerial2.Text & "'" &
                    " ,SerialNumber3 = '" & txtSerial3.Text & "'" &
                    ",PCI = " & IIf(txtPCIDate.Text.Replace("/", "").Trim = "", "NULL", " '" & txtPCIDate.Text & "'") &
                    " ,Password = '" & txtPassword.Text & "'" &
                    " ,Status = " & IIf(chkStatus.Checked, 1, 0) &
                    " WHERE ID =  " & Val(mdRow.Item("ID").ToString)

            End If

            If SQL_ExecuteSP(sSQLStr) Then
                UpdateItem(miMerchantID)
                If mbNewRecord Then
                    mbNewRecord = False
                    ActionLog(Me.Name, "New", "New Merchant", "", "", "Create New Merchant -> " & sSQLStr.Replace("'", "''"), StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                    MessageBox.Show("Successfully Added New Customer", "Successfully Added New Customer." & vbNewLine & vbNewLine & "This screen will be close.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
                Else
                    ActionLog(Me.Name, Val(mdRow.Item("ID").ToString), "Updated Merchant", "", "", "Update Merchant -> " & sSQLStr.Replace("'", "''"), StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                    MessageBox.Show("Successfully updated", "Successfully updated", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Unsuccessful update/Add customer." & vbNewLine & vbNewLine & "Please try again!", "Unsuccessful Edit Customer", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
            End If

        Catch exp As Exception
            LogToFile(Me.Name & ".log", "frm_CustomerService_CustomerInformationDetails_Load Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub txtDisplayPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDisplayPassword.KeyDown
        If e.KeyCode = Keys.End Then
            btnDisplayInformation.PerformClick()
        End If
    End Sub

    Private Sub btnEditData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditData.Click
        If lblDispayFormStatus.Text = "View Only" Then
            lblDispayFormStatus.Text = "Editing Mode"
            DisablenableFormEditing(False)
        Else
            lblDispayFormStatus.Text = "View Only"
            DisablenableFormEditing(True)
        End If
    End Sub
    Private Sub DisablenableFormEditing(ByVal bReadOnly As Boolean)
        Try
            txtDate.Enabled = False
            txtBusinessName.ReadOnly = bReadOnly
            txtBusinessAddress.ReadOnly = bReadOnly
            txtMerchantNumber.ReadOnly = bReadOnly
            txtFileNumber.ReadOnly = bReadOnly
            txtOwnerName.ReadOnly = bReadOnly
            txtBusinessPhone.ReadOnly = bReadOnly
            txtContactNumber.ReadOnly = bReadOnly
            txtSSNumber.ReadOnly = bReadOnly
            txtSSNumber.ReadOnly = bReadOnly
            txtTaxID.ReadOnly = bReadOnly
            txtTaxID.ReadOnly = bReadOnly
            txtModel1.ReadOnly = bReadOnly
            txtModel2.ReadOnly = bReadOnly
            txtModel3.ReadOnly = bReadOnly
            txtSerial1.ReadOnly = bReadOnly
            txtSerial2.ReadOnly = bReadOnly
            txtSerial3.ReadOnly = bReadOnly
            txtMMOName.ReadOnly = bReadOnly
            txtMMOPassword.ReadOnly = bReadOnly
            txtSales.ReadOnly = bReadOnly
            txtCommissionReceived.ReadOnly = bReadOnly
            txtCommissionAdjusted.ReadOnly = bReadOnly
            txtCommissionBalance.ReadOnly = bReadOnly
            txtUserID.ReadOnly = bReadOnly
            btnSave.Enabled = Not bReadOnly
            btnDelete.Enabled = Not bReadOnly
            btnClearPCI.Enabled = Not bReadOnly
            txtPCIDate.Enabled = Not bReadOnly
            txtPassword.ReadOnly = bReadOnly
            chkStatus.Enabled = Not bReadOnly
            txtDate.Enabled = Not bReadOnly
            MyGrid_MerchantServices.AllowDelete = Not bReadOnly
            MyGrid_MerchantServices.AllowUpdate = Not bReadOnly
            MyGrid_MerchantServices.AllowAddNew = Not bReadOnly
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "DisablenableFormEditing Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub


    Private Sub btnClearPCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPCI.Click
        txtPCIDate.Text = ""
    End Sub


    Private Sub txtPCIDate_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)
        If Not e.IsValidInput Then
            If Not txtPCIDate.Text.Replace("/", "").Trim = "" Then
                ToolTip1.ToolTipTitle = "Invalid Date Value"
                ToolTip1.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", txtPCIDate, 5000)
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub txtDate_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)
        If Not e.IsValidInput Then
            If Not txtPCIDate.Text.Replace("/", "").Trim = "" Then
                ToolTip1.ToolTipTitle = "Invalid Date Value"
                ToolTip1.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", txtDate, 5000)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you wants to DELETE Merchant: " & txtBusinessName.Text & "?", "Delete Merchant ( " & txtBusinessName.Text & " )", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Try
            If Not mbNewRecord Then
                If Not SQL_ExecuteSP("DELETE tb_MerchantInformation WHERE ID =  " & Val(mdRow.Item("ID").ToString)) Then
                    MessageBox.Show("Delete Merchant Issue!" & vbNewLine & vbNewLine & "Please try again!")
                Else
                    Me.Close()
                End If
                Me.Close()
            End If

        Catch exp As Exception
            MessageBox.Show("btnDelete_Click Error" & vbNewLine & vbNewLine & exp.Message)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnDelete_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnPrintScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintScreen.Click
        Try

            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument1.Print()
            End If
        Catch exp As Exception
            MessageBox.Show("btnPrintScreen_Click Error" & vbNewLine & vbNewLine & exp.Message)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnPrintScreen_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim myImage As New Bitmap(Me.Width, Me.Height)
            Dim PrintSize As Size = e.MarginBounds.Size
            Dim scale As Double = 1
            Me.DrawToBitmap(myImage, New Rectangle(Point.Empty, Me.Size))
            PrintSize.Width *= 0.96 'convert to pixels
            PrintSize.Height *= 0.96
            If myImage.Width > PrintSize.Width Then
                'Form is to big. Scale it down.
                scale = PrintSize.Width / myImage.Width
                e.Graphics.ScaleTransform(scale, scale)
            End If
            If (myImage.Height * scale) > PrintSize.Height Then
                'The form is still to big. Scale it again.
                scale = PrintSize.Height / (myImage.Height * scale)
                e.Graphics.ScaleTransform(scale, scale)
            End If
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(myImage, e.MarginBounds.Location)
            myImage.Dispose()

        Catch exp As Exception
            MessageBox.Show("PrintDocument1_PrintPage Error" & vbNewLine & vbNewLine & exp.Message)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "PrintDocument1_PrintPage - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnAddFollowupTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFollowupTask.Click
        Try
            If Not IsActiveOpenedForm(frm_Customer_FollowupConfig) Then
                Dim frm As New frm_Customer_FollowupConfig
                frm.SetPreviousForm = Me
                frm.SetMerchantID = miMerchantID
                frm.Show()
            End If
        Catch exp As Exception
            MessageBox.Show("btnAddFollowupTask_Click Error" & vbNewLine & vbNewLine & exp.Message)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnAddFollowupTask_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnRequestPaper_Click(sender As System.Object, e As System.EventArgs) Handles btnRequestPaper.Click
        Using frm As New frm_MerchantPaperRequest
            frm.ClearForm = True
            frm.SetMerchantID = miMerchantID
            frm.SetMerchantName = txtBusinessName.Text
            frm.SetMerchantAddress = txtBusinessAddress.Text

            frm.ShowDialog()
        End Using
    End Sub

    Private Sub btnRequestHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnRequestHistory.Click
        If Not IsActiveOpenedForm(frm_MerchantPaperRequestHistory) Then
            Dim frm As New frm_MerchantPaperRequestHistory
            frm.SetSelectedMerchantName = txtBusinessName.Text.Trim
            frm.Show()
        End If
    End Sub

    Private Sub GetMerchantService(iMerchantID As Int32)
        Try



            Cursor = Cursors.WaitCursor
            MyGrid_MerchantServices.FilterSaveGridFilters()
            MyGrid_MerchantServices.AC_GridDataSet = SQL_GetStandardGridDataSet(SQL_QueryGetTableResult(msSQLString_MerchantServices.Replace("MyParameter_MerchantID", iMerchantID)),
                                                                                                        False,
                                                                                                        Nothing,
                                                                                                        GetParam("~", "~", "", "", "", "", "", "", "~", "~"))
            'If MyGrid_MerchantServices.AC_GridDataSet.Tables(MyGrid_MerchantServices.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_MerchantServices.AC_GridDataSet.Tables(MyGrid_MerchantServices.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_MerchantServices.AC_SortDirectionReset()
            MyGrid_MerchantServices.AC_ColumnWidthMultipler_Disable = True
            MyGrid_MerchantServices.AC_RefreshGrid()

            Dim VI As ValueItems = MyGrid_MerchantServices.Columns("MerchantService").ValueItems
            Using dTable_MerchantServices As DataTable = SQL_QueryGetTableResult("SELECT Selection FROM tbSelectOption WITH (NOLOCK) WHERE Type = 'ServiceType' ORDER BY SelectionDispalySort")
                If dTable_MerchantServices IsNot Nothing Then
                    If dTable_MerchantServices.Rows.Count > 0 Then
                        VI.Translate = False
                        VI.CycleOnClick = False
                        VI.Presentation = PresentationEnum.ComboBox
                        VI.Values.Clear()
                        For Each dr As DataRow In dTable_MerchantServices.Rows
                            VI.Values.Add(New ValueItem(dr.Item("Selection").ToString, dr.Item("Selection").ToString))
                        Next
                    End If
                End If

            End Using
            MyGrid_MerchantServices.Columns("MerchantService").ValueItems.Validate = True

            MyGrid_MerchantServices.Columns("ID").DefaultValue = 0
            MyGrid_MerchantServices.Columns("isActive").DefaultValue = 1
            MyGrid_MerchantServices.Columns("MerchantID").DefaultValue = iMerchantID
            MyGrid_MerchantServices.Columns("LastUpdateEmployeeID").DefaultValue = StrEmployeeInformation.EmployeeID
            MyGrid_MerchantServices.Columns("LastUpdateTime").DefaultValue = Now.Date
            MyGrid_MerchantServices.Columns("CreateTime").DefaultValue = Now.Date

            'MyGrid_MerchantServices.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_MerchantServices.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_MerchantServices.AlternatingRows = True
                'MyGrid_MerchantServices.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_MerchantServices.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_MerchantServices.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_MerchantServices.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_MerchantServices.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_MerchantServices.CaptionStyle.Font.Size * 0.8)
                MyGrid_MerchantServices.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_MerchantServices, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_MerchantServices, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)
            MyGrid_MerchantServices.FilterRestallFilters()
        Catch ex As Exception

            MessageBox.Show("GetMerchantService Error" & vbNewLine & vbNewLine & ex.Message)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetMerchantService - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UpdateItem(iMerchantID As Integer)
        If mdTable Is Nothing Then mdTable = New DataTable
        Try
            mdTable = MyGrid_MerchantServices.AC_GridDataSet.Tables(MyGrid_MerchantServices.AC_GridDataSet.Tables.Count - 1).GetChanges
            Dim SQLStr As String = ""
            If Not mdTable Is Nothing Then
                For Each dRow As DataRow In mdTable.Rows
                    If dRow.RowState = DataRowState.Deleted Then
                        SQL_ExecuteSP(msSQLString_DeleteMerchantService.Replace("MyParameter_ID", dRow("ID", DataRowVersion.Original)))
                    ElseIf dRow.RowState = DataRowState.Modified Then
                        SQL_ExecuteSP(msSQLString_UpdateMerchantService.Replace("MyParameter_isActive", IIf(dRow("isActive"), 1, 0)) _
                                                                        .Replace("MyParameter_MerchantServiceType", dRow("MerchantService").ToString.Replace("'", "''")) _
                                                                        .Replace("MyParameter_MerchantServiceCode", dRow("MerchantServiceCode").ToString.Replace("'", "''")) _
                                                                        .Replace("MyParameter_Remarks", dRow("Remarks").ToString.Replace("'", "''")) _
                                                                        .Replace("MyParameter_ActiveDate", IIf(dRow("ActiveDate").ToString = "", "NULL", "'" & dRow("ActiveDate").ToString.Replace("'", "''") & "'")) _
                                                                        .Replace("MyParameter_ExpiredDate", IIf(dRow("ExpiredDate").ToString = "", "NULL", "'" & dRow("ExpiredDate").ToString.Replace("'", "''") & "'")) _
                                                                        .Replace("MyParameter_LastUpdateEmployeeID", dRow("LastUpdateEmployeeID").ToString) _
                                                                        .Replace("MyParameter_MerchantID", dRow("ID")))
                    ElseIf dRow.RowState = DataRowState.Added Then

                        SQL_ExecuteSP(msSQLString_AddMerchantService.Replace("MyParameter_MerchantID", iMerchantID) _
                                                                        .Replace("MyParameter_MerchantServiceType", dRow("MerchantService").ToString.Replace("'", "''")) _
                                                                        .Replace("MyParameter_MerchantServiceCode", dRow("MerchantServiceCode").ToString.Replace("'", "''")) _
                                                                        .Replace("MyParameter_Remarks", dRow("Remarks").ToString.Replace("'", "''")) _
                                                                        .Replace("MyParameter_isActive", IIf(dRow("isActive"), 1, 0)) _
                                                                        .Replace("MyParameter_ActiveDate", IIf(dRow("ActiveDate").ToString = "", "NULL", "'" & dRow("ActiveDate").ToString & "'")) _
                                                                        .Replace("MyParameter_ExpiredDate", IIf(dRow("ExpiredDate").ToString = "", "NULL", "'" & dRow("ExpiredDate").ToString & "'")) _
                                                                        .Replace("MyParameter_LastUpdateEmployeeID", dRow("LastUpdateEmployeeID").ToString))

                    End If
                Next
                MyGrid_MerchantServices.AC_GridDataSet.Tables(MyGrid_MerchantServices.AC_GridDataSet.Tables.Count - 1).AcceptChanges()
            End If
        Catch ex As Exception
            MessageBox.Show("UpdateItem Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, iMerchantID, "MerchantService", "", "", "Error - Modifing Merchant Service" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "UpdateItem - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub

    Private Sub btnUploadDocument_Click(sender As Object, e As EventArgs) Handles btnUploadDocument.Click
        Try

            Dim myWebClient As WebClient = New WebClient
            Dim sFilePath As String = ""
            Dim sDestinationDirectory As String = ""
            myWebClient.UploadFile("http://321ordernow.theworkpc.com:48168/MyDocuments/", "POST", "C:\Users\johnl\Desktop\New folder\Claims1-80813880-0000-C01F-B8B8-85EA7C9E87F8-1.jpg")
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name,
            gsApplicationClientID & vbNewLine & Me.Name & " - btnUploadDocument_Click: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub
End Class