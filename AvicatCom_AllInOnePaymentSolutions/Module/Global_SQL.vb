Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Resources
Imports System.Runtime.Remoting
Imports System.Net.NetworkInformation
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Threading
Imports System.Threading.Thread
Module Global_SQL
    Private msModuleName As String = "Global_SQL"
    ''' <summary>
    ''' Max return with first 3000 records
    ''' </summary>
    ''' <param name="sTableName">Database table name</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_GetAllTableData(ByVal sTableName As String, Optional ByVal sCondidtion As String = "") As DataTable

        Try
            Dim sSqlStr As String = "SELECT TOP 3000 * FROM " & sTableName & " (NOLOCK)" & sCondidtion
            Return gobjADO.ExecuteSQLQuery(sSqlStr, gsConnectionString)

        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_GetAllTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_GetAllTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_GetAllTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    ' ''' <summary>
    ' ''' Update record in a table where we supply table name ane parameters
    ' ''' </summary>
    ' ''' <param name="sTableName">Database table name</param>
    ' ''' <param name="sCondidtion">Where condidtion</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Function SQL_UpdateTableData(ByVal sTableName As String, ByVal sSetValue As String, ByVal sCondidtion As String, Optional ByVal bUpdateAllMatch As Boolean = False) As Boolean

    '    Try
    '        Dim sSqlStr As String = IIf(bUpdateAllMatch, "UPDATE ", "UPDATE TOP (1) ") & sTableName & " " & sSetValue & " " & sCondidtion
    '        gobjADO.ExecuteSQLQuery(sSqlStr, gsConnectionString)
    '        Return True
    '    Catch exp As Exception
    '        LogToSystemEvent(gsApplicationClientID, gsApplicationClientID, _
    '        gsApplicationClientID & vbNewLine & msFormName & " - SQL_UpdateTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
    '        Return False
    '    End Try
    'End Function
    ' ''' <summary>
    ' ''' Insert record into a table
    ' ''' </summary>
    ' ''' <param name="sTableName">Database table name</param>
    ' ''' <param name="sTableFields">Table fields need to be fill</param>
    ' ''' <param name="sTableFieldValues">Vales fill base on columns</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Function SQL_InsertTableData(ByVal sTableName As String, ByVal sTableFields As String, ByVal sTableFieldValues As String) As Boolean

    '    Try
    '        Dim sSqlStr As String = "INSERT INTO " & sTableName & " ( " & sTableFields & " ) VALUES ( " & sTableFieldValues & " ) "
    '        gobjADO.ExecuteSQLQuery(sSqlStr, gsConnectionString)
    '        Return True
    '    Catch exp As Exception
    '        LogToSystemEvent(gsApplicationClientID, gsApplicationClientID, _
    '        gsApplicationClientID & vbNewLine & msFormName & " - SQL_UpdateTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
    '        Return False
    '    End Try
    'End Function
    Friend Function SQL_DeleteTableData(ByVal sTableName As String, ByVal sCondidtion As String) As Boolean
        Try
            If sCondidtion.Trim = "" Then
                MessageBox.Show("Cannot Delete Table without any Condidition", "Cannot Delete Table without any Condidition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            Dim sSqlStr As String = "DELETE  " & sTableName & " " & sCondidtion

            gobjADO.ExecuteSQLQuery(sSqlStr, gsConnectionString)
            Return True
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_DeleteTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_DeleteTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_GetAllTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    ' ''' <summary>
    ' ''' return datatable
    ' ''' </summary>
    ' ''' <param name="sTableName">Database table name</param>
    ' ''' <param name="arrColumnsName">Array of columns name in string</param>
    ' ''' <param name="sCondidition">SQL Condition (ex. "WHERE x = y" )</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Function SQL_GetTableColumns(ByVal sTableName As String, ByVal arrColumnsName As ArrayList, ByVal sCondidition As String) As DataTable
    '    Dim sSqlStr As String = "*"
    '    Dim sTableColumns As String = "*"
    '    Try
    '        For Each sColumn As String In arrColumnsName
    '            If sTableColumns = "*" Then
    '                If sColumn.ToString = "*" Then
    '                    sTableColumns = "*"
    '                Else
    '                    sTableColumns = sColumn.ToString
    '                End If

    '            Else
    '                If sColumn.ToString = "*" Then
    '                    sTableColumns = sTableColumns & ", *"
    '                    Exit For
    '                Else
    '                    sTableColumns = sTableColumns & "," & sColumn
    '                End If

    '            End If
    '        Next
    '        sSqlStr = "SELECT " & sTableColumns & " FROM " & sTableName & " (NOLOCK)" & sCondidition

    '        Return gobjADO.ExecuteSQLQuery(sSqlStr, gsConnectionString)
    '    Catch exp As Exception
    '        LogToSystemEvent(gsApplicationClientID, gsApplicationClientID, _
    '        gsApplicationClientID & vbNewLine & msFormName & " - SQL_UpdateTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
    '        Return Nothing
    '    End Try
    'End Function







    ''' <summary>
    ''' Max return with first 3000 records if iOverRideMaxRecords is not set
    ''' </summary>
    ''' <param name="sTableName">Database table name</param>
    ''' <param name="iOverRideMaxRecords">Manully set max return rocords</param>
    ''' <param name="sCondidtion">exp: " WHERE A = B"</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_GetAllTableData_New(ByVal sTableName As String, Optional ByVal iOverRideMaxRecords As Integer = 0, Optional ByVal sCondidtion As String = "", Optional ByVal sConnectionString As String = "") As DataTable
        Dim sSqlStr As String
        Try
            If iOverRideMaxRecords > 0 Then
                sSqlStr = "SELECT TOP " & iOverRideMaxRecords & " * FROM " & sTableName & " (NOLOCK)" & sCondidtion
            Else
                sSqlStr = "SELECT TOP 3000 * FROM " & sTableName & " (NOLOCK)" & sCondidtion
            End If
            Debug.WriteLine("SQL_GetAllTableData SQL Statment: " & sSqlStr)
            Return gobjADO.ExecuteSQLQuery(sSqlStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))

        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_GetAllTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_GetAllTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_GetAllTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Update record in a table where we supply table name ane parameters
    ''' </summary>
    ''' <param name="sTableName">Enter Table name used in database</param>
    ''' <param name="sSetValue">Set column value.  ex: "ItemNo = '0001-01', WHNo = 'NJ'"</param>
    ''' <param name="sCondidtion">Set Condidtion: ex: "WHERE WHNo = 'NJ'"</param>
    ''' <param name="sConnectionString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_UpdateTableData(ByVal sTableName As String, ByVal sSetValue As String, ByVal sCondidtion As String, Optional ByVal sConnectionString As String = "") As Boolean

        Try
            Dim sSqlStr As String = "UPDATE TOP (1) " & sTableName & " SET " & sSetValue & " " & sCondidtion
            gobjADO.ExecuteSQLQuery(sSqlStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))

            Debug.WriteLine("SQL_UpdateTableData SQL Statment: " & sSqlStr)
            Return True
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_UpdateTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_UpdateTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_UpdateTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Insert record into a table
    ''' </summary>
    ''' <param name="sTableName">Database table name</param>
    ''' <param name="sTableFields">Table fields need to be fill</param>
    ''' <param name="sTableFieldValues">Vales fill base on columns</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_InsertTableData(ByVal sTableName As String, ByVal sTableFields As String, ByVal sTableFieldValues As String, Optional ByVal sConnectionString As String = "") As Boolean

        Try
            Dim sSqlStr As String = "INSERT INTO " & sTableName & " ( " & sTableFields & " ) VALUES ( " & sTableFieldValues & " ) "
            gobjADO.ExecuteSQLQuery(sSqlStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))

            Debug.WriteLine("SQL_InsertTableData SQL Statment: " & sSqlStr)
            Return True
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_UpdateTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_UpdateTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_UpdateTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' return datatable
    ''' </summary>
    ''' <param name="sTableName">Database table name</param>
    ''' <param name="arrColumnsName">Array of columns name in string. "*" will be all columns.</param>
    ''' <param name="sCondidition">Enter Conditional exp (Where ItemNo = 'testing'). Empty will be no condidition pass in.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_GetTableColumns(ByVal sTableName As String, ByVal arrColumnsName As ArrayList, Optional ByVal sCondidition As String = "", Optional ByVal sConnectionString As String = "") As DataTable
        Dim sSqlStr As String = "*"
        Dim sTableColumns As String = "*"
        Try

            For Each sColumn As String In arrColumnsName
                If sTableColumns = "*" Then
                    If sColumn.ToString = "*" Then
                        sTableColumns = "*"
                    Else
                        sTableColumns = sColumn.ToString
                    End If

                Else
                    If sColumn.ToString = "*" Then
                        sTableColumns = sTableColumns & ", *"
                        Exit For
                    Else
                        sTableColumns = sTableColumns & "," & sColumn
                    End If

                End If
            Next
            sSqlStr = "SELECT " & sTableColumns & " FROM " & sTableName & " (NOLOCK) " & sCondidition
            Debug.WriteLine("SQL_GetTableColumns SQL Statment: " & sSqlStr)
            Return gobjADO.ExecuteSQLQuery(sSqlStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))

        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_GetAllTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_GetAllTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_GetAllTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' return distinct column in datatable
    ''' </summary>
    ''' <param name="sTableName">Database table name</param>
    ''' <param name="sDistinctColume">Colume name</param>
    ''' <param name="sCondidition">Filter condidition.  EXP (  WHERE ItemNo =  ??? )</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_GetTableDistinctColumn(ByVal sTableName As String, ByVal sDistinctColume As String, Optional ByVal sCondidition As String = "", Optional ByVal sConnectionString As String = "") As DataTable
        Dim sSqlStr As String = "*"
        Try
            If sCondidition <> "" Then
                sSqlStr = "SELECT Distinct(" & sDistinctColume & ") FROM " & sTableName & " (NOLOCK) " & sCondidition
            Else
                sSqlStr = "SELECT Distinct(" & sDistinctColume & ") FROM " & sTableName & " (NOLOCK)"
            End If
            Debug.WriteLine("SQL_GetTableDistinctColumn SQL Statment: " & sSqlStr)
            Return gobjADO.ExecuteSQLQuery(sSqlStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_GetAllTableData: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_GetAllTableData Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_GetAllTableData Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Friend Function SQL_QueryGetTableResult(ByVal sSQL_Query As String, Optional ByVal sMyConnctionString As String = "", Optional ByVal bBlankFirstRow As Boolean = False) As DataTable

        Try

            Debug.WriteLine("SQL_QueryGetTableResult SQL Statment: " & sSQL_Query)
            Dim dTable As DataTable = gobjADO.ExecuteSQLQuery(sSQL_Query, IIf(sMyConnctionString = "", gsConnectionString, sMyConnctionString))
            If bBlankFirstRow Then
                Dim drNewRow As DataRow = dTable.NewRow
                For j As Integer = 0 To dTable.Columns.Count - 1

                    drNewRow.Item(j) = ""

                Next
                dTable.Rows.InsertAt(drNewRow, 0)
                dTable.AcceptChanges()
            End If
            Return dTable

        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_QueryGetTableResult: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_QueryGetTableResult Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_QueryGetTableResult Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Friend Function SQL_GetStandardGridDataSet(ByVal dTable As DataTable, Optional ByVal bLockAllColumns As Boolean = True, Optional ByVal arrCaption As ArrayList = Nothing, Optional ByVal arrCustomizeColumnStatus As ArrayList = Nothing, Optional ByVal arrCustomeizeColumnWidth As ArrayList = Nothing) As DataSet
        Dim dSet As New DataSet
        Dim dt_ColumnWidth As New DataTable
        Dim dt_ColumnFormat As New DataTable

        Dim iColumneCount As Integer = dTable.Columns.Count - 1
        Try
            ' Get Format      
            For j As Integer = 0 To iColumneCount
                Dim dc As DataColumn = dt_ColumnFormat.Columns.Add(IIf(j = 0, "FORMAT", "FORMAT_" & j.ToString), Type.GetType("System.String"))
                If bLockAllColumns Then
                    dc.DefaultValue = "~"
                ElseIf Not arrCustomizeColumnStatus Is Nothing Then
                    If arrCustomizeColumnStatus.Count <= j Then dc.DefaultValue = "~" Else dc.DefaultValue = arrCustomizeColumnStatus.Item(j).ToString
                Else
                    dc.DefaultValue = "~"
                End If
                dc.AllowDBNull = False
                If dc.DefaultValue = "" Then If dTable.Columns(j).ReadOnly Then dTable.Columns(j).ReadOnly = False
            Next
            Dim dRow As DataRow = dt_ColumnFormat.NewRow
            dt_ColumnFormat.Rows.Add(dRow)

            'Get Width
            For j As Integer = 0 To iColumneCount
                Dim dc As DataColumn = dt_ColumnWidth.Columns.Add(IIf(j = 0, "WIDTH", "WIDTH_" & j.ToString), Type.GetType("System.String"))

                If Not arrCustomeizeColumnWidth Is Nothing Then
                    If arrCustomeizeColumnWidth.Count <= j Then dc.DefaultValue = 15 Else dc.DefaultValue = Val(arrCustomeizeColumnWidth.Item(j).ToString)
                Else
                    dc.DefaultValue = 15
                End If
            Next
            dRow = dt_ColumnWidth.NewRow
            dt_ColumnWidth.Rows.Add(dRow)
            dSet.Tables.Add(dt_ColumnFormat)
            dSet.Tables.Add(dt_ColumnWidth)
            dSet.Tables.Add(dTable.Copy)
            Return dSet
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_GetStandardGridDataSet: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_GetStandardGridDataSet Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_GetStandardGridDataSet Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function


    'Friend Sub UpdateDBFromDSet(ByRef DSet1 As DataSet, ByRef cmdUpdate As SqlCommand)
    '    Dim UpdatedRows As System.Data.DataSet = Nothing
    '    Dim InsertedRows As System.Data.DataSet = Nothing
    '    Dim DeletedRows As System.Data.DataSet = Nothing
    '    Dim nCount As Integer
    '    Dim sAction As String = ""
    '    Dim row As DataRow
    '    Try
    '        'these three are Data Table that hold any changes that have been made to the dataset
    '        'since the last update.

    '        UpdatedRows = DSet1.GetChanges(DataRowState.Modified)
    '        InsertedRows = DSet1.GetChanges(DataRowState.Added)
    '        DeletedRows = DSet1.GetChanges(DataRowState.Deleted)


    '        If Not UpdatedRows Is Nothing Or Not InsertedRows Is Nothing Or Not DeletedRows Is Nothing Then
    '            'For each of these, we have to make sure that the Data Tables contain
    '            'any records, otherwise, we will get an error.
    '            If Not UpdatedRows Is Nothing Then
    '                sAction = "Update"
    '                For Each row In UpdatedRows.Tables(UpdatedRows.Tables.Count - 1).Rows
    '                    cmdUpdate.Parameters(0).Value = sAction
    '                    Debug.WriteLine(cmdUpdate.Parameters(0).ParameterName & "   " & sAction)
    '                    For nCount = 0 To UpdatedRows.Tables(UpdatedRows.Tables.Count - 1).Columns.Count - 1

    '                        If (cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int32 Or _
    '                                    cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int16) _
    '                                            And row(nCount, DataRowVersion.Original).ToString = "" Then
    '                            cmdUpdate.Parameters(nCount + 1).Value = 0

    '                        Else
    '                            cmdUpdate.Parameters(nCount + 1).Value = row.Item(nCount).ToString
    '                        End If
    '                        Debug.WriteLine(cmdUpdate.Parameters(nCount + 1).ParameterName & "   " & row.Item(nCount))
    '                    Next nCount

    '                    cmdUpdate.ExecuteNonQuery()
    '                Next
    '            End If

    '            If Not InsertedRows Is Nothing Then
    '                sAction = "ADD"
    '                Dim nCol_1 As Integer
    '                For Each row In InsertedRows.Tables(InsertedRows.Tables.Count - 1).Rows
    '                    cmdUpdate.Parameters(0).Value = sAction
    '                    nCol_1 = InsertedRows.Tables(InsertedRows.Tables.Count - 1).Columns.Count - 1
    '                    For nCount = 0 To nCol_1
    '                        If (cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int32 Or _
    '                                    cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int16) And _
    '                                        row.Item(nCount).ToString = "" Then
    '                            cmdUpdate.Parameters(nCount + 1).Value = 0
    '                        ElseIf (cmdUpdate.Parameters(nCount + 1).DbType = DbType.AnsiString Or _
    '                                cmdUpdate.Parameters(nCount + 1).DbType = DbType.AnsiStringFixedLength) _
    '                                        And row.Item(nCount).ToString = "" Then
    '                            cmdUpdate.Parameters(nCount + 1).Value = ""
    '                        Else
    '                            Debug.Print(row.Item(nCount).ToString)
    '                            cmdUpdate.Parameters(nCount + 1).Value = row.Item(nCount).ToString
    '                        End If

    '                    Next nCount

    '                    cmdUpdate.ExecuteNonQuery()
    '                Next
    '            End If

    '            If Not DeletedRows Is Nothing Then
    '                sAction = "DELETE"
    '                For Each row In DeletedRows.Tables(DeletedRows.Tables.Count - 1).Rows
    '                    cmdUpdate.Parameters(0).Value = sAction
    '                    For nCount = 0 To DeletedRows.Tables(DeletedRows.Tables.Count - 1).Columns.Count - 1
    '                        If (cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int32 Or cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int16) _
    '                                And row(nCount, DataRowVersion.Original).ToString = "" Then
    '                            cmdUpdate.Parameters(nCount + 1).Value = 0
    '                        Else
    '                            cmdUpdate.Parameters(nCount + 1).Value = row(nCount, DataRowVersion.Original).ToString
    '                        End If
    '                    Next nCount

    '                    cmdUpdate.ExecuteNonQuery()
    '                Next
    '            End If
    '            DSet1.AcceptChanges()
    '        End If

    '    Catch exp As Exception
    '        LogToSystemEvent(gsApplicationClientID, msModuleName, _
    '        gsApplicationClientID & " Global_Share - UpdateDBFromDSet: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
    '        LogToFile(msModuleName & ".log", "UpdateDBFromDSet Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
    '        '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "UpdateDBFromDSet Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub
    Friend Function SQL_QueryCheckRecordExsits(ByVal sSQL_Query As String, Optional ByVal sMyConnctionString As String = "") As Integer
        Dim iRecordCount As Integer = 0
        Try
            Using dTable As DataTable = SQL_QueryGetTableResult(sSQL_Query, sMyConnctionString)
                If dTable Is Nothing Then
                    Return 0
                Else
                    Return dTable.Rows.Count
                End If
            End Using
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_QueryCheckRecordExsits: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_QueryCheckRecordExsits Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_QueryCheckRecordExsits Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Return single colume data from database table
    ''' </summary>
    ''' <param name="sTable">Name of the table</param>
    ''' <param name="sColumnName">Name of the table column</param>
    ''' <param name="sCondidtion">Condidition: exp " WHERE A = B"</param>
    ''' <param name="sMyConnctionString">Optional new database connection string if connecting to other database</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_QueryGetSingleRecord(ByVal sTable As String, ByVal sColumnName As String, ByVal sCondidtion As String, Optional ByVal sMyConnctionString As String = "") As String
        Dim sResult As String = ""
        Try
            Debug.WriteLine("SQL_QueryGetSingleRecord - " & "SELECT TOP 1 " & sColumnName & " FROM " & sTable & " (NOLOCK) " & sCondidtion)
            Using dTable As DataTable = SQL_QueryGetTableResult("SELECT TOP 1 " & sColumnName & " FROM " & sTable & " (NOLOCK) " & sCondidtion, sMyConnctionString)
                If dTable.Rows.Count = 1 Then sResult = dTable.Rows(0).Item(0).ToString
            End Using
            Return sResult
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_QueryGetSingleRecord: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_QueryGetSingleRecord Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_QueryGetSingleRecord Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return sResult
        End Try
    End Function
    ''' <summary>
    ''' execute SP from Database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_ExecuteSP(ByVal sSQLStr As String, Optional ByVal sConnectionString As String = "") As Boolean

        Try

            Debug.WriteLine("SQL_ExecuteSP SQL Statment: " & sSQLStr)
            gobjADO.ExecuteSQLQuery(sSqlStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))

            Return True
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_ExecuteSP: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_ExecuteSP Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_ExecuteSP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' execute SP from Database and get return datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SQL_ExecuteSP_ReturnTable(ByVal sSQLStr As String, Optional sConnectionString As String = "") As DataTable
        Try
            Debug.WriteLine("SQL_ExecuteSP SQL Statment: " & sSQLStr)
            Return gobjADO.ExecuteSQLQuery(sSQLStr, IIf(sConnectionString = "", gsConnectionString, sConnectionString))
        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, msModuleName, _
            gsApplicationClientID & " Global_Share - SQL_ExecuteSP: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            LogToFile(msModuleName & ".log", "SQL_ExecuteSP Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '  If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SQL_ExecuteSP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
  

    Friend Function SQL_ExecuteMultiSQLQueries(ByVal arrQueries As ArrayList, ByVal sConnectionString As String, Optional ByVal sSQLQuery_Log As String = "", Optional ByVal sConnectionString_Log As String = "") As Boolean
        Dim bSuccess As Boolean = True
        Dim objSqlConnection As SqlConnection = Nothing
        Dim sSQLString As String = ""
        Try
            objSqlConnection = New SqlConnection(sConnectionString)
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dTable As New DataTable

            cmd.CommandType = CommandType.Text
            cmd.Connection = objSqlConnection

            objSqlConnection.Open()

            For j As Integer = 0 To arrQueries.Count - 1
                Try
                    sSQLString = arrQueries.Item(j).ToString
                    cmd.CommandText = sSQLString
                    reader = cmd.ExecuteReader()
                    ' Data is accessible through the DataReader object here.
                    dTable.Load(reader)
                    'While reader.Read()
                    '    MessageBox.Show(reader.Item(0).ToString & " - " & reader.Item(1).ToString)
                    'End While
                Catch sqlex As SqlException
                    LogToFile("DWL_ADO", _
                                            "ExecuteMultiSQLQueries - DataError > " & " - >" & sqlex.Procedure & " - >" & sqlex.Message & " - >" & _
                                            sqlex.Number & " - >" & sqlex.LineNumber & " - >" & sqlex.StackTrace, System.DateTime.Now.ToString)
                    If sSQLQuery_Log <> "" And sConnectionString_Log <> "" Then SQL_ExecuteSP(sSQLQuery_Log.Replace("ERRORMSG", sSQLString.Replace("'", "''") & vbNewLine & vbNewLine & sqlex.Message), sConnectionString_Log)
                End Try
            Next


            'objSqlConnection.Close()
            Return bSuccess
        Catch sqlex As SqlException
            LogToFile("DWL_ADO", _
                                    "ExecuteMultiSQLQueries > " & " - >" & sqlex.Procedure & " - >" & sqlex.Message & " - >" & _
                                    sqlex.Number & " - >" & sqlex.LineNumber & " - >" & sqlex.StackTrace, System.DateTime.Now.ToString)
            If sSQLQuery_Log <> "" And sConnectionString_Log <> "" Then SQL_ExecuteSP(sSQLQuery_Log.Replace("ERRORMSG", sSQLString & vbNewLine & vbNewLine & sqlex.Message & vbNewLine & vbNewLine & sSQLString), sConnectionString_Log)
            Return Nothing
        Catch exp As Exception
            LogToFile("DWL_ADO", _
            exp.Source & ".ExecuteMultiSQLQueries " & " - >" & exp.Message & " - >" & exp.ToString, System.DateTime.Now.ToString)
            If exp.Message.Contains("The connection's current state is closed") Then

            End If
            If sSQLQuery_Log <> "" And sConnectionString_Log <> "" Then SQL_ExecuteSP(sSQLQuery_Log.Replace("ERRORMSG", sSQLString & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & sSQLString), sConnectionString_Log)
            Return False
        Finally
            objSqlConnection.Close()
        End Try
    End Function
    ''' <summary>
    ''' Log user action to system eventlog (DO NOT Replace ( ' ), Action Log will replace it!!)
    ''' </summary>
    ''' <param name="sFormName">Name of the current form for this action</param>
    ''' <param name="RefNo">OrderID or RefNo</param>
    ''' <param name="sActionType">General Action Name ( What is action about )</param>
    ''' <param name="sOldValue">Current value</param>
    ''' <param name="sNewValue">New value wants to change to</param>
    ''' <param name="sRemarks">Detail description for this action</param>
    ''' <param name="sLocation">Store location (Single location will use Main)</param>
    ''' <param name="iEmployeeID">Employee ID for this action</param>
    ''' <param name="sComputerName">Computer name where this action take place</param>
    ''' <remarks></remarks>
    Friend Sub ActionLog(ByVal sFormName As String, ByVal RefNo As String, ByVal sActionType As String, ByVal sOldValue As String, ByVal sNewValue As String, ByVal sRemarks As String, ByVal sLocation As String, ByVal iEmployeeID As Integer, ByVal sComputerName As String)
        Try
            If Not SQL_ExecuteSP("INSERT INTO tb_SystemEventLog ( FormName,RefNo,ActionType,OldValue,NewValue    ,Remark,Location,EmployeeID,ComputerName,ApplicationVersion ) VALUES ( " &
                                 "'" & sFormName.Replace("'", "''") & "','" & RefNo.Replace("'", "''") & "','" & sActionType.Replace("'", "''") & "','" & sOldValue.Replace("'", "''") & "','" & sNewValue.Replace("'", "''") & "',LEFT('" & sRemarks.Replace("'", "''") & "', 1000) ,'" & sLocation.Replace("'", "''") & "'," & iEmployeeID & ",'" & sComputerName.Replace("'", "''") & "','" & My.Application.Info.Version.ToString.Replace("'", "''") & "')") Then
                MessageBox.Show("Unable to connection to database!!" & vbNewLine & vbNewLine & "Please check network connection and try again!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch exp As Exception
            LogToFile("DWL_ADO", _
            exp.Source & ".ActionLog " & " - >" & exp.Message & " - >" & exp.ToString, System.DateTime.Now.ToString)
            Throw exp
        End Try
    End Sub
End Module
