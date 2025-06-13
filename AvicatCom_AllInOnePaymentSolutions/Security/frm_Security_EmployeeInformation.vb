Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Windows.Forms
Public Class frm_Security_EmployeeInformation
    WithEvents MyGrid As AviatCom_DefaultGrid = Nothing
    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 13)
    Private mobjMyGridFooterFont As New Font("Arial", 13)

    Private msSQLStr As String = " SELECT EmployeeID,FirstName,LastName,UserName,Role " &
                                    " ,isEnabled,HomePhone,CellPhone " &
                                    " ,Email,Address,City,State,Zip " &
                                    " ,Password,CreateTime" &
                                    " FROM tb_Security_Employee WITH (NOLOCK) "

    Private Sub frm_Security_EmployeeInformation_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Try

        Catch ex As Exception
        Finally
            If Not IsActiveOpenedForm(frmGeneral) Then
                Dim frm As New frmGeneral
                frm.MdiParent = gfrmMDI
                frm.Show()
            End If
        End Try
    End Sub

    Private Sub frm_Security_EmployeeInformation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Add_NewAccessCode("NET:Security:EmployeeInformation", "Edit Employee Profile", "Edit Employee Profile") Then
                MessageBox.Show("Please assign role access for ( NET:Security:EmployeeInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If
            If Not CheckAccessRight("NET:Security:EmployeeInformation") Then
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If
            Me.AutoScaleMode = AutoScaleMode.Dpi
            MyGrid = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid.FetchRowStyles = False

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
            FillComboBox(cboRole, StrEmployeeInformation.tbApplicationUserRole)
            btnRefreshData.BackColor = Color.GreenYellow
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "frm_Security_EmployeeInformation_Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "frm_Security_EmployeeInformation_Load Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub RefreshData()
        Try

            Cursor = Cursors.WaitCursor
            If Not MyGrid.AC_GridDataSet Is Nothing Then
                MyGrid.AC_GridDataSet.Dispose()
                MyGrid.AC_GridDataSet = Nothing
            End If
            MyGrid.AC_GridDataSet = SQL_GetStandardGridDataSet(SQL_QueryGetTableResult(msSQLStr), False, , GetParam("~", "~", "~", "~", "~", "~", "~", "~", "@", "@", "@", "@", "@", "@", "@", "@", "@"))

            MyGrid.AC_SortDirectionReset()
            MyGrid.AC_ColumnWidthMultipler_Disable = True

            MyGrid.AC_RefreshGrid()
            MyGrid.Splits(0).DisplayColumns.Item("UserName").Frozen = True

            If Not MyGrid.GetSetGridDisplayFormatLoad Then
                '$$$$$$$$$$ Set Even row color
                MyGrid.AlternatingRows = True
                MyGrid.EvenRowStyle.BackColor = Color.LightCyan

                ' $$$$$$$$$$$ Set Selected row back color
                MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                '$$$$$$$$$$$$$$$$$$$$$$$$$

                MyGrid.RowHeight = Me.Font.Size * 2
                miMyGridCaptionHeight = MyGrid.Splits(0).ColumnCaptionHeight * 2
                mobjMyGridFont = New Font("Arial", MyGrid.CaptionStyle.Font.Size * 1.4)
                mobjMyGridFooterFont = New Font("Arial", MyGrid.CaptionStyle.Font.Size * 1.4)
                MyGrid.GetSetGridDisplayFormatLoad = True
            End If

            FormatMyGridFont(MyGrid, mobjMyGridFont, mobjMyGridFont, , , mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "RefreshData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "RefreshData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ClearFields()
        Try
            txtUserName.Text = ""
            txtPassword.Text = ""
            cboRole.Text = ""
            cboState.SelectedIndex = 0
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtHomePhone.Text = ""
            txtCellPhone.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            txtCity.Text = ""
            cboState.Text = ""
            txtZipCode.Text = ""
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "ClearFields Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "ClearFields Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub MyGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyGrid.DoubleClick
        Try
            If Not MyGrid.CheckFilterFocused Then
                txtUserName.Text = MyGrid.Item(MyGrid.Row, "UserName").ToString
                txtPassword.Text = DecryptText(MyGrid.Item(MyGrid.Row, "Password").ToString)
                cboRole.Text = MyGrid.Item(MyGrid.Row, "Role").ToString
                cboStatus.SelectedIndex = Val(MyGrid.Item(MyGrid.Row, "isEnabled").ToString)
                txtFirstName.Text = MyGrid.Item(MyGrid.Row, "FirstName").ToString
                txtLastName.Text = MyGrid.Item(MyGrid.Row, "LastName").ToString
                txtHomePhone.Text = MyGrid.Item(MyGrid.Row, "HomePhone").ToString
                txtCellPhone.Text = MyGrid.Item(MyGrid.Row, "CellPhone").ToString
                txtEmail.Text = MyGrid.Item(MyGrid.Row, "Email").ToString
                txtAddress.Text = MyGrid.Item(MyGrid.Row, "Address").ToString
                txtCity.Text = MyGrid.Item(MyGrid.Row, "City").ToString
                cboState.Text = MyGrid.Item(MyGrid.Row, "State").ToString
                txtZipCode.Text = MyGrid.Item(MyGrid.Row, "Zip").ToString
             
            End If
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "CleaMyGrid_DoubleClickrFields Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "MyGrid_DoubleClick Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtUserName.Text = ""
        txtPassword.Text = ""
        cboRole.Text = "User"
        cboState.SelectedIndex = 0
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtHomePhone.Text = ""
        txtCellPhone.Text = ""
        txtEmail.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtZipCode.Text = ""
      
    End Sub
    Private Sub FillComboBox(ByRef cbo As ComboBox, ByVal dTable As DataTable)
        Try
            cbo.Items.Clear()
            For Each dRow As DataRow In dTable.Rows
                cbo.Items.Add(dRow(0).ToString)
            Next
            cbo.Sorted = True
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "FillComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "FillComboBox Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sSQLStr As String = ""
            'txtUserName.Text = MyGrid.Item(MyGrid.Row, "UserName").ToString
            'txtPassword.Text = DecryptText(MyGrid.Item(MyGrid.Row, "Password").ToString)
            'cboRole.Text = MyGrid.Item(MyGrid.Row, "Role").ToString
            'cboState.SelectedIndex = Val(MyGrid.Item(MyGrid.Row, "isEnabled").ToString)
            'txtFirstName.Text = MyGrid.Item(MyGrid.Row, "FirstName").ToString
            'txtLastName.Text = MyGrid.Item(MyGrid.Row, "LastName").ToString
            'txtHomePhone.Text = MyGrid.Item(MyGrid.Row, "HomePhone").ToString
            'txtCellPhone.Text = MyGrid.Item(MyGrid.Row, "CellPhone").ToString
            'txtEmail.Text = MyGrid.Item(MyGrid.Row, "Email").ToString
            'txtAddress.Text = MyGrid.Item(MyGrid.Row, "Address").ToString
            'txtCity.Text = MyGrid.Item(MyGrid.Row, "City").ToString
            'cboState.Text = MyGrid.Item(MyGrid.Row, "State").ToString
            'txtZipCode.Text = MyGrid.Item(MyGrid.Row, "Zip").ToString

            If SQL_QueryCheckRecordExsits(" SELECT ID FROM tb_Security_Employee WITH (NOLOCK)  WHERE UserName = '" & txtUserName.Text & "'") Then
                If MessageBox.Show("Are you sure you wants to update User ( UserName: " & txtUserName.Text & " )?" & vbNewLine & vbNewLine & "Employee Name : " & txtFirstName.Text & " " & txtLastName.Text, "Update Existing User", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbNo Then Exit Sub
                sSQLStr = " Update tb_Security_Employee SET " &
                            "Password = '" & EncryptText(txtPassword.Text) & "'" &
                            ",Role = '" & cboRole.Text & "'" &
                            ",isEnabled = " & IIf(cboStatus.Text = "Enabled", 1, 0) &
                            ",FirstName = '" & txtFirstName.Text & "'" &
                            ",LastName = '" & txtLastName.Text & "'" &
                            ",HomePhone = '" & txtHomePhone.Text & "'" &
                            ",CellPhone = '" & txtCellPhone.Text & "'" &
                            ",Email = '" & txtEmail.Text & "'" &
                            ",Address = '" & txtAddress.Text & "'" &
                            ",City = '" & txtCity.Text & "'" &
                            ",State = '" & cboState.Text & "'" &
                            ",Zip = '" & txtZipCode.Text & "'" &
                            " WHERE UserName = '" & Me.txtUserName.Text & "'"
            Else
                Dim iNewEmployeeID As Integer = Val(SQL_QueryGetSingleRecord("tb_Security_Employee", "MAX(ID)", "")) + 1

                sSQLStr = " INSERT INTO tb_Security_Employee ( " &
                            " UserName,Password,Role,isEnabled " &
                            " ,FirstName,LastName,HomePhone,CellPhone,Email " &
                            " ,Address,City,State,Zip " &
                            " ,EmployeeID" &
                            " ) VALUES ( " &
                            "'" & txtUserName.Text & "'" &
                            " , '" & EncryptText(txtPassword.Text) & "'" &
                            " , '" & cboRole.Text & "'" &
                            " , " & IIf(cboStatus.Text = "Enabled", 1, 0) &
                            " , '" & txtFirstName.Text & "'" &
                            " , '" & txtLastName.Text & "'" &
                            " , '" & txtHomePhone.Text & "'" &
                            " , '" & txtCellPhone.Text & "'" &
                            " , '" & txtEmail.Text & "'" &
                            " , '" & txtAddress.Text & "'" &
                            " , '" & txtCity.Text & "'" &
                            " , '" & cboState.Text & "'" &
                            " , '" & txtZipCode.Text & "'" &
                            " , " & iNewEmployeeID & " )"

            End If
            If Not SQL_ExecuteSP(sSQLStr) Then
                MessageBox.Show("Unable to create/update user!!" & vbNewLine & vbNewLine & "Please check network connection and try again", "Unable to create/update user", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            RefreshData()

        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "CleaMyGrbtnSave_Clickid_DoubleClickrFields Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "MyGrid_DoubtnSave_ClickbleClick Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

End Class