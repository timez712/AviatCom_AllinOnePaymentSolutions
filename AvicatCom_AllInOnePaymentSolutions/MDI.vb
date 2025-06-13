Imports System.Windows.Forms
Imports AviatCom_Lib.AviatCom_Lib

Public Class MDI

   
    Private Sub MDI_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        'If Not gdt_GetSystemInfo Is Nothing Then gdt_GetSystemInfo.Dispose()
        'If Not gVirtualKeyboard Is Nothing Then gVirtualKeyboard.Dispose()
        'If Not gProductDetailTable Is Nothing Then gProductDetailTable.Dispose()
        If Not gobjADO Is Nothing Then gobjADO.Dispose()
        If Not gfrmMDI Is Nothing Then gfrmMDI.Dispose()

    End Sub


    Private Sub MDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Me.Height = My.Computer.Screen.WorkingArea.Height - 10
            'Me.Width = My.Computer.Screen.WorkingArea.Width - 10
            Dim bFound As Boolean = False
            'Me.AutoScaleMode = AutoScaleMode.Dpi
            gfrmMDI = Me
            ApplicationStart()
            Me.mnuFile_SignIn.PerformClick()
            If gbOnlineOrderOnly Then Exit Sub
            If Not Add_NewAccessCode("NET:EmployeeInformation", "Edit Employee Profile", "Edit Employee Profile") Then
                'MessageBox.Show("Please assign role access for ( NET:Security:EmployeeInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Else
                CustomerInformationToolStripMenuItem.Visible = True
                'CustomersToolStripMenuItem.Visible = True
                bFound = True
            End If



            If Not Add_NewAccessCode("NET:CustomerInformation", "Edit Employee Profile", "Edit Employee Profile") Then
                'MessageBox.Show("Please assign role access for ( NET:Security:EmployeeInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Else
                CustomersToolStripMenuItem.Visible = True
                bFound = True
            End If


            If Not Add_NewAccessCode("NET:Security", "Edit Employee Profile", "Edit Employee Profile") Then
                'MessageBox.Show("Please assign role access for ( NET:Security:EmployeeInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Else
                mnuTools_Administrator.Visible = True
                mnuAdministrator_SetupUser.Visible = True
                bFound = True
            End If
            'Me.AutoScaleMode = AutoScaleMode.Dpi
          
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, "MDI", ".MDI_Load: " & exp.ToString, "Error")
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "MDI_Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile_Exit.Click
        Application.Exit()
    End Sub


    Private Sub mnuFile_SignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile_SignIn.Click
        'Exit Sub
        Login_Clear()
        CloseAllMDIChildForms(gfrmMDI)
        Dim frm As New frmLogin
        frm.ShowDialog()
    End Sub



    Private Sub mnuAdministrator_SetupAccessCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministrator_SetupAccessCodes.Click
        CloseAllMDIChildForms(gfrmMDI)
        frm_Security_AccessControl.MdiParent = gfrmMDI
        frm_Security_AccessControl.Text = "Administrator Access Code Setup"
        frm_Security_AccessControl.Show()
    End Sub

    Private Sub mnuFile_SignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile_SignOut.Click
        MessageBox.Show("User ( " & StrEmployeeInformation.UserName & " ) sign-out success.", "User Sign-out", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        CloseAllMDIChildForms(gfrmMDI)
        Login_Clear()
    End Sub


    Private Sub MinScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinScreenToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersToolStripMenuItem.Click

        If Not IsActiveOpenedForm(frm_CustomerService_CustomerInformation) Then
            Dim frm As New frm_CustomerService_CustomerInformation
            'frm.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom

            frm.Show()
        End If
    End Sub

    Private Sub mnuAdministrator_SetupUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministrator_SetupUser.Click
        If Not IsActiveOpenedForm(frm_Security_EmployeeInformation) Then
            Dim frm As New frm_Security_EmployeeInformation
            'frm.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom

            frm.Show()
        End If
    End Sub
    
    Private Sub RestaurantsInformationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantsInformationToolStripMenuItem.Click
        'If Not IsActiveOpenedForm(frm_321_RestaurantInformation) Then
        '    Dim frm As New frm_321_RestaurantInformation
        '    frm.Show()
        'End If
        'frmOnlineOrderMenu
        If Not IsActiveOpenedForm(frmOnlineOrderMenu) Then
            Dim frm As New frmOnlineOrderMenu
            frm.Show()
        End If
    End Sub

    Private Sub ExportMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportMenuToolStripMenuItem.Click
        If Not IsActiveOpenedForm(frmOnline_Menu_Export) Then
            Dim frm As New frmOnline_Menu_Export
            frm.Show()
        End If
    End Sub

    Private Sub ImportMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportMenuToolStripMenuItem.Click
        If InputBox("Please enter AccessCode for import menu", "Enter Access Code", "") = "ActiveImportMenu" Then
            If Not IsActiveOpenedForm(frmOnline_Menu_Import) Then
                Dim frm As New frmOnline_Menu_Import
                frm.Show()
            End If
        Else
            MessageBox.Show(Me, "Unable to vertify for access", "Unable To Vertify Access Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub RestaurantsSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurantsSummaryToolStripMenuItem.Click
        Try
            If Not IsActiveOpenedForm(frm_Report_RestaurantBusinessSummary) Then
                Dim frm As New frm_Report_RestaurantBusinessSummary
                frm.Show()
            End If
        Catch ex As Exception
            MessageBox.Show("RestaurantsSummaryToolStripMenuItem_Click Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, Me.Name, Me.Name, "", "", "Error - RestaurantsSummaryToolStripMenuItem_Click" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "RestaurantsSummaryToolStripMenuItem_Click - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub
End Class
