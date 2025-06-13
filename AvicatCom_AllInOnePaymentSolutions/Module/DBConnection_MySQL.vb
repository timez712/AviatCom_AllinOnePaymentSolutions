Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Imports CrystalDecisions.CrystalReports.Engine


Public Class DBConnection_MySQL
    'Dim sConnectionString As String = "Server=50.22.148.100;Port=3306;Database=aviatcom_yummyOrder;Uid=aviatcom_john;Pwd=John712;"
    'Dim sConnectionString_Backup As String = "Server=50.22.148.100;Port=3306;Database=aviatcom_yummyOrder_Backup;Uid=aviatcom_john;Pwd=John712;"
    'Dim sConnectionString As String = "Server=321OrderNow.com;Port=3306;Database=aviatcom_yummyOrder;Uid=aviatcom;Pwd=Password823;"
    'Dim sConnectionString_Backup As String = "Server=321OrderNow.com;Port=3306;Database=aviatcom_yummyOrder_Backup;Uid=aviatcom;Pwd=Password823;"
    Dim sConnectionString As String = "Server=aviatcomrealestatedb.cb7xjj8p8mid.us-east-1.rds.amazonaws.com;Port=3306;Database=aviatcom_yummyOrder;Uid=AviatCom;Pwd=YJ321Ordernow;CharSet=utf8;"
    Dim sConnectionString_Backup As String = "Server=aviatcomrealestatedb.cb7xjj8p8mid.us-east-1.rds.amazonaws.com;Port=3306;Database=aviatcom_yummyOrder_test;Uid=AviatCom;Pwd=YJ321Ordernow;CharSet=utf8;"
    Friend gsConnectionString_MySQL As String = ""
    Friend conn As MySqlConnection
    Friend conn_Backup As MySqlConnection
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Friend Function GetCurrentConnectionString(Optional ByVal sConnection As String = "")
        Return gsConnectionString_MySQL
    End Function
    Friend Sub CreateConnection(Optional ByVal sConnection As String = "")
        If Not conn Is Nothing Then conn.Close()
        Try
            If sConnection.ToString.ToUpper.Contains("BACKUP") Then
                conn = New MySqlConnection(sConnectionString_Backup)
                gsConnectionString_MySQL = sConnectionString_Backup
            Else
                conn = New MySqlConnection(sConnectionString)
                gsConnectionString_MySQL = sConnectionString
            End If
            Try
                conn.Open()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                Select Case ex.Number
                    Case 0
                        MessageBox.Show("Cannot connect to server. Contact administrator")
                    Case 1045
                        MessageBox.Show("Invalid username/password, please try again")
                End Select
            End Try
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try
    End Sub
    Friend Sub ConnectionClose()
        'If Not conn Is Nothing Then conn.Close()

        Try
            'conn = New MySqlConnection(sConnectionString)
            If Not conn Is Nothing Then conn.Close()

        Catch ex As MySqlException
            MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try
    End Sub

    Friend Function GetCommand() As String
        Return conn.ConnectionString
    End Function

    'Friend Function SQLQueryGetDatatable(sMySQLQuery As String, Optional sConnectionString As String = "") As DataTable
    '    Dim dTable As DataTable = Nothing
    '    Try
    '        Dim MyConn As MySqlConnection = New MySqlConnection()
    '        conn.ConnectionString = gsConnectionString_MySQL
    '        Dim MyCmd As MySqlCommand = New MySqlCommand()


    '        Return dTable
    '    Catch ex As MySqlException
    '        MessageBox.Show("Error connecting to the server: " + ex.Message)
    '        Return Nothing
    '    End Try
    'End Function
    Friend Function MySQLExecuteMultipleSP(arrMySQLQuery As ArrayList, Optional sConnectionString As String = "") As Boolean
        Try
            Using MyConn As MySqlConnection = New MySqlConnection(IIf(sConnectionString <> "", sConnectionString, gsConnectionString_MySQL))
                Using MyCmd As MySqlCommand = New MySqlCommand()
                    MyConn.Open()
                    MyCmd.Connection = MyConn
                    Try
                        For Each sQuery As String In arrMySQLQuery
                            MyCmd.CommandText = sQuery
                            MyCmd.ExecuteNonQuery()
                        Next
                    Catch ex As MySqlException
                        MessageBox.Show(ex.ToString)
                    End Try
                End Using
            End Using
            Return True
        Catch ex As MySqlException
            Throw ex
            MessageBox.Show("Error : " + ex.Message)
            Return False
        End Try
    End Function
    Friend Function MySQLQueryGetData(sMySQLQuery As String, Optional sConnectionString As String = "") As DataTable
        'Dim conn As New MySqlConnection
        'Dim cmd As New MySqlCommand
        'Dim myAdapter As New MySqlDataAdapter
        Dim objDataSet As New DataSet
        Try
            Using MyConn As MySqlConnection = New MySqlConnection(IIf(sConnectionString <> "", sConnectionString, gsConnectionString_MySQL))
                Using MyCmd As MySqlCommand = New MySqlCommand()
                    MyConn.Open()
                    MyCmd.Connection = MyConn
                    Try
                        MyCmd.CommandText = sMySQLQuery
                        'MyCmd.Connection = conn
                        Using myAdapter As MySqlDataAdapter = New MySqlDataAdapter
                            myAdapter.SelectCommand = MyCmd
                            myAdapter.Fill(objDataSet)
                            'myData.WriteXml("C:\dataset.xml", XmlWriteMode.WriteSchema)
                            Return objDataSet.Tables(0)
                        End Using
                    Catch ex As MySqlException
                        MessageBox.Show(ex.ToString)
                        Return Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        'Try
        '    conn.ConnectionString = IIf(sConnectionString <> "", sConnectionString, gsConnectionString_MySQL)
        '    conn.Open()
        '    cmd.CommandText = sMySQLQuery
        '    cmd.Connection = conn
        '    myAdapter.SelectCommand = cmd
        '    myAdapter.Fill(objDataSet)
        '    'myData.WriteXml("C:\dataset.xml", XmlWriteMode.WriteSchema)
        '    Return objDataSet.Tables(0)
        'Catch ex As MySqlException
        '    Throw ex
        '    Return Nothing
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return Nothing
        'End Try
    End Function
    Friend Sub MySQLQueryDirectDisplayCRReport(sMySQLQuery As String, Optional sConnectionString As String = "")
        Dim myReport As New ReportDocument
        Dim myViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter

        conn.ConnectionString = _
            "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=12345;" _
            & "database=test"

        Try
            conn.Open()

            cmd.CommandText = "SELECT city.name AS cityName, city.population AS CityPopulation, " _
                & "country.name, country.population, country.continent " _
                & "FROM country, city ORDER BY country.continent, country.name"
            cmd.Connection = conn

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(myData)

            myReport.Load(".\world_report.rpt")
            myReport.SetDataSource(myData)
            myViewer.ReportSource = myReport
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
