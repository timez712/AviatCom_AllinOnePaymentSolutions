Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frm_Security_ProductKey
    Private mdTable As DataTable = SQL_QueryGetTableResult(" SELECT Key_1,Key_2,Key_3,Key_4 " &
                                                           " FROM tb_ApplicationLicense WITH (NOLOCK) WHERE isKeyUsed = 0 ", DecryptText(strSystemConfig.Mic5))
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtKey_1.Text = ""
        txtKey_2.Text = ""
        txtKey_3.Text = ""
        txtKey_4.Text = ""
    End Sub

    Private Sub btnActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActive.Click
        Dim bResult As Boolean = False
        Try
            Dim dRow() As DataRow = mdTable.Select("Key_1 = '" & txtKey_1.Text.Trim & "' AND Key_2 = '" & txtKey_2.Text.Trim & "' AND Key_3 = '" & txtKey_3.Text.Trim & "' AND Key_4 = '" & txtKey_4.Text.Trim & "'")
            If dRow Is Nothing Then
                MessageBox.Show("No License found for your application", "License Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
            ElseIf dRow.Count >= 1 Then
                SQL_ExecuteSP("UPDATE tb_ApplicationLicense SET isKeyUsed = 1 , CompanyName = '" & strSystemConfig.CompanyName & "', PCName = '" & strSystemConfig.WorkstationName & "',Location = '" & strSystemConfig.Location & "', CPUID = '" & strSystemConfig.CPUID & "',MotherBoardID = '" & strSystemConfig.MotherBoardID & "' " &
                              " WHERE Key_1 = '" & dRow(0).Item("Key_1").ToString & "' AND Key_2 = '" & dRow(0).Item("Key_2").ToString & "' AND Key_3 = '" & dRow(0).Item("Key_3").ToString & "' AND Key_4 = '" & dRow(0).Item("Key_4").ToString & "'", DecryptText(strSystemConfig.Mic5))

                RegisterNewLicense(EncryptText(strSystemConfig.CPUID), EncryptText(strSystemConfig.MotherBoardID))
                strSystemConfig.isNewLicense = True
                MessageBox.Show("New license had added into your system." & vbNewLine & vbNewLine & "Thank you for your new license purchase.", "New License Registry", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)

                bResult = True
                Me.Close()
            ElseIf dRow.Count <= 0 Then
                MessageBox.Show("Incorrect product key entered", "Incorrect Product Key Entered", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
            End If
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "LogIn_TempAccess Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "LogIn_TempAccess Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frm_Security_ProductKey_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            If Not mdTable Is Nothing Then
                mdTable.Dispose()
                mdTable = Nothing
            End If
        Catch exp As Exception
            LogToFile(Me.Name & ".log", "frm_Security_ProductKey_Disposed Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "frm_Security_ProductKey_Disposed Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class