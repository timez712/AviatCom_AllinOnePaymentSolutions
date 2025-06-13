Imports System.Data
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frmLogin
    Dim sAccessFormName As String = ""
    Friend WriteOnly Property SetAccessFormName As String
        Set(value As String)
            sAccessFormName = value
        End Set
    End Property

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If LogIn(txtUserName.Text, txtPassword.Text) Then
            'frm_Product_Information.MdiParent = gfrmMDI
            'frm_Product_Information.BringToFront()
            'frm_Product_Information.Show()
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtUserName.Focus()
        Catch exp As Exception
            MessageBox.Show("Error Starting POS Application")
        End Try
    End Sub

    Private Sub txtUserName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyUp
        If e.KeyCode = Keys.Enter Then txtPassword.Focus()
    End Sub


    Private Sub txtPassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyUp
        If Not txtUserName.Text.Trim = "" And Not txtPassword.Text.Trim = "" Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If
    End Sub

End Class
