Public Class frm_InputPassword
    Friend WriteOnly Property SetHeaderText As String
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property
    Friend WriteOnly Property SetDisplayMessage As String
        Set(value As String)
            lblDisplayMessage.Text = value
        End Set
    End Property
    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtPassword.Text.Trim = "" Then
                    ErrorProvider.SetError(txtPassword, "Please Enter Password.")
                Else
                    ErrorProvider.SetError(txtPassword, "")
                    gsMyEnteredValue = txtPassword.Text
                    Me.Close()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtPassword.Text = ""
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        gsMyEnteredValue = ""
        Me.Close()
    End Sub

    Private Sub BtnEnter_Click(sender As System.Object, e As System.EventArgs) Handles BtnEnter.Click
        If txtPassword.Text.Trim = "" Then
            ErrorProvider.SetError(txtPassword, "Please Enter Password.")
        Else
            ErrorProvider.SetError(txtPassword, "")
            gsMyEnteredValue = txtPassword.Text
            Me.Close()
        End If
    End Sub

    Private Sub frm_InputPassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        txtPassword.Select()
    End Sub
End Class