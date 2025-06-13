Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Public Class cls_321DBConnection
    'Dim sConnectionString As String = "Server=50.22.148.100;Port=3306;Database=aviatcom_yummyOrder;Uid=aviatcom_john;Pwd=John712;"
    'Dim sConnectionString_Backup As String = "Server=50.22.148.100;Port=3306;Database=aviatcom_yummyOrder_Backup;Uid=aviatcom_john;Pwd=John712;"
    Dim sConnectionString As String = "Server=321OrderNow.com;Port=3306;Database=aviatcom_yummyOrder;Uid=aviatcom;Pwd=Password823;"
    Dim sConnectionString_Backup As String = "Server=321OrderNow.com;Port=3306;Database=aviatcom_yummyOrder_Backup;Uid=aviatcom;Pwd=Password823;"
    Friend mobjMySQLConnection As MySqlConnection
    Friend mobjMySQLConnection_Backup As MySqlConnection
    Dim data As DataTable
    Dim mobjMySQLDataAddapter As MySqlDataAdapter = Nothing
    Dim cb As MySqlCommandBuilder
    Friend Sub MySQLCreateConnection(Optional ByVal sConnection As String = "")
        If Not mobjMySQLConnection Is Nothing Then mobjMySQLConnection.Close()
        Try
            If sConnection.ToString.ToUpper.Contains("BACKUP") Then
                mobjMySQLConnection = New MySqlConnection(sConnectionString_Backup)
            Else
                mobjMySQLConnection = New MySqlConnection(sConnectionString)
            End If
            mobjMySQLConnection.Open()

        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try
    End Sub
    Friend Sub MySQLConnectionClose()
        'If Not conn Is Nothing Then conn.Close()

        Try
            'conn = New MySqlConnection(sConnectionString)
            If Not mobjMySQLConnection Is Nothing Then mobjMySQLConnection.Close()

        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try
    End Sub

    Friend Function MySQLGetCommand() As String
        Return mobjMySQLConnection.ConnectionString
    End Function
    Friend Sub MySQLReturnDatatable(ByVal sMySQLStr As String, ByRef dTable As DataTable)
        Try

            Using cmd As New MySqlCommand(sMySQLStr, mobjMySQLConnection)
                'cmd.Parameters.AddWithValue("&uname", UsernameTextBox.Text)
                'cmd.Parameters.AddWithValue("&pword", PasswordTextBox.Text)
                If mobjMySQLDataAddapter Is Nothing Then
                    mobjMySQLDataAddapter = New MySqlDataAdapter
                End If
                mobjMySQLDataAddapter.SelectCommand = cmd
                mobjMySQLDataAddapter.Fill(dTable)
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error MySQLReturnDatatable: " & ex.Message)
        End Try
    End Sub
    Friend Sub MySQLExecute(ByVal sMySQLStr As String)
        Try

            Using cmd As New MySqlCommand(sMySQLStr, mobjMySQLConnection)
                'cmd.Parameters.AddWithValue("&uname", UsernameTextBox.Text)
                'cmd.Parameters.AddWithValue("&pword", PasswordTextBox.Text)
                If mobjMySQLDataAddapter Is Nothing Then
                    mobjMySQLDataAddapter = New MySqlDataAdapter
                End If
                mobjMySQLDataAddapter.SelectCommand = cmd
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error MySQLReturnDatatable: " & ex.Message)
        End Try
    End Sub
End Class
