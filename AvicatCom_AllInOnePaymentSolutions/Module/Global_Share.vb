Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Module Global_Share
    Friend gsApplicationClientID As String = "AvicatCom_AllInOnePaymentSolutions"
    Friend msModuleName As String = "Global_Share"
    Friend gobjADO As New AviatCom_ADO.AviatCom_ADO
    Friend gbDebugDisplayMSG As Boolean = False
    Friend gsVirtualKeyboardData As String = ""
    Friend gsWorkstationName As String = ""

    Friend gbWindowstateMax As Boolean = False
    Friend gsUserName As String = ""
    Friend gsProfile As String = ""
    Friend gbAccess As Boolean = False

    Friend gsCustomerID As String = ""

    'Friend gfrmMDI As New MDI
    Friend gfrmMDI As New MDI
    Friend gAction As String = ""
    Friend gsComfirmOrderID As String = ""
    Friend gsConnectionString As String = ";uid=321OrderNow;Database=AllInOnePaymentSolutionsdb;Password=YJ321Ordernow"
    Friend gsDatabaseIPAddress As String = ""

    Friend gAppConfig As App_Configuration = New App_Configuration

   

    Friend giMaxLoginTry As Integer = 5
    Friend giLoginTried As Integer = 0

    Friend mtProcessingData As Threading.Thread
    Private mbStopThread As Boolean = False

    Friend gsMyEnteredValue As String = ""
    Friend gobj_MyReturnObject As Object
    Friend gsMyReturnValue As String = ""
    Friend gsCustomMSGReturn As String = ""

    Friend gCmd_GetNewFollowupID As New SqlCommand
    Friend gCmd_GetNewMerchantID As New SqlCommand
    Friend gCmd_GetNewRequestID As New SqlCommand

    Friend Structure strMyColor
        'Friend Shared cExit As Color
        'Friend Shared cCancel As Color
        'Friend Shared cOkay As Color
        'Friend Shared cYes As Color
        'Friend Shared cNo As Color
        'Friend Shared cConfirm As Color
        'Friend Shared cConfirmNeeded As Color
        'Friend Shared cFilter As Color
        'Friend Shared cClear As Color
        'Friend Shared cSave As Color
        'Friend Shared cGridCaption As Color
        'Friend Shared cAliceBlue As Color
        'Friend Shared cGreenYellow As Color
        'Friend Shared cLightGldenrodYellow As Color
        'Friend Shared cSelection As Color
        'Friend Shared cEnterKeyborad As Color
        'Friend Shared cRefreshDate As Color
        'Friend Shared cPost_Needed As Color
        'Friend Shared c. isPosted As Color
        'Friend Shared cDisplayReport As Color
        'Friend Shared cColorLegend As Color
        'Friend Shared cColorDisabled As Color
        'Friend Shared cSelected As Color
        'Friend Shared cAdd As Color
        'Friend Shared cLess As Color
        'Friend Shared cStandardButton As Color
        'Friend Shared cTaxExemption As Color
        'Friend Shared cRefreshData As Color
        'Friend Shared cNeedAction As Color


        Friend Shared cAdd As Color = Color.LightGreen
        Friend Shared cAliceBlue As Color = Color.AliceBlue
        Friend Shared cCancel As Color = Color.LightSalmon
        Friend Shared cColorLegend As Color = Color.Bisque
        Friend Shared cColorDisabled As Color = Color.LightGray
        Friend Shared cConfirm As Color = Color.LawnGreen
        Friend Shared cConfirmNeeded As Color = Color.LightPink
        Friend Shared cDisplayReport As Color = Color.LightCoral
        Friend Shared cExit As Color = Color.LightSalmon
        Friend Shared cEnable As Color = Color.LightCyan
        Friend Shared cEnterKeyborad As Color = Color.LightSteelBlue
        Friend Shared cDisable As Color = Color.LightPink
        Friend Shared cFilter As Color = Color.LightBlue
        Friend Shared cGreenYellow As Color = Color.GreenYellow
        Friend Shared cGridCaption As Color = Color.LightCyan
        Friend Shared cLess As Color = Color.LightPink
        Friend Shared cLightGldenrodYellow As Color = Color.LightGoldenrodYellow
        Friend Shared cNeedAction As Color = Color.HotPink
        Friend Shared cNo As Color = Color.Salmon
        Friend Shared cOkay As Color = Color.LightBlue
        Friend Shared cPosted As Color = Color.YellowGreen
        Friend Shared cPost_Needed As Color = Color.LightSalmon
        Friend Shared cRefreshData As Color = Color.Lavender
        Friend Shared cStandardButton As Color = Color.LightGray
        Friend Shared cSelected As Color = Color.LightCyan
        Friend Shared cSave As Color = Color.LightGreen
        Friend Shared cTaxExemption As Color = Color.Magenta
        Friend Shared cYes As Color = Color.LightGreen
        Friend Shared cPaid As Color = Color.LightGreen
        Friend Shared cPaid_Not As Color = Color.LightPink
    End Structure

    Friend Structure App_Configuration
        Friend gLocalDrive As String
        Friend gFileDirectoryPath As String
    End Structure
    Friend Structure POS_Shortcuts
        Friend Const ESC = Chr(&H1B)
        Friend Const CarriageReturn = Chr(&HD)
        Friend Const SetBold = ESC & "bC"
        Friend Const SetUnderline = ESC & "uC"
        Friend Const SetItalic = ESC & "iC"
        Friend Const SetCentre = ESC & "cA"
        Friend Const SetRight = ESC & "rA"
        Friend Const ResetFormatting = ESC & "N"
        Friend Const LineFee = ESC & Chr(10)
        Friend Const FeeLines = ESC & "d"
    End Structure

    Friend Structure PrinterFonts
        Friend Const MS_Mincho_1 As String = "Arial"
        Friend Const BatangChe_2 As String = "BatangChe"
        Friend Const MingLiu_3 As String = "Arial"
        Friend Const SimHei_4 As String = "SimHei"
        Friend Const KaiTi_5 As String = "KaiTi"
        Friend Const GungsuhChe_6 As String = "GungsuhChe"
        Friend Const MingLiu_HKSCS_7 As String = "MingLiu_HKSCS"
        Friend Const GulimChe_8 As String = "GulimChe"
    End Structure

    Friend Structure gObjMyDeclares
        Friend Const sBackupHeader As String = "_Header.bak"
        Friend Const sBackupDetail As String = "_Detail.bak"
    End Structure

    Friend Structure strSystemConfig
        Friend Shared CompanyName As String = ""
        Friend Shared Location As String = ""
        Friend Shared Address As String = ""
        Friend Shared Address_2 As String = ""
        Friend Shared City As String = ""
        Friend Shared State As String = ""
        Friend Shared ZipCode As String = ""
        Friend Shared Phone As String = ""
        Friend Shared WorkstationName As String = ""
        Friend Shared Fax As String = ""
        Friend Shared StoreManager As String = ""
        Friend Shared SaleTax As String = ""
        Friend Shared Mic1 As String = "" ' Application Warning Date
        Friend Shared Mic2 As String = ""   ' Application Expired Date
        Friend Shared Mic3 As String = ""   'Total License #
        Friend Shared Mic4 As String = ""   ' Unknown
        Friend Shared Mic5 As String = ""   ' Activation Connection
        Friend Shared Mic6 As String = ""   ' Installation Date

        Friend Shared CPUID As String = ""
        Friend Shared MotherBoardID As String = ""
        Friend Shared HardDriveID As String = ""
        Friend Shared isNewLicense As Boolean = False

        Friend Shared WarningDate As Date = DateAdd(DateInterval.Year, -1, Now.Date)
        Friend Shared ExpiredDate As Date = DateAdd(DateInterval.Year, -1, Now.Date)

        Friend Shared tb_SystemWorkstationConfig As DataTable
        Friend Shared tb_SystemConfig As DataTable
        Friend Shared tb_SelectOption As DataTable
        Friend Shared tb_Empolyee As DataTable
    End Structure

    Friend Class cls_CustomerID_CustomerCompany
        Property CustomerID As String
        Property CustomerCompany As String
    End Class
  
   
    Friend Function FeeLines(ByVal nLine As Integer) As String
        Return POS_Shortcuts.ESC & "d" & Chr(nLine)
    End Function
    Public Sub ApplicationStart()
        Try
            Dim colSettings As System.Collections.Specialized.NameValueCollection
            colSettings = System.Configuration.ConfigurationManager.AppSettings
            Dim sConnectionString As String = colSettings.Item("DisplayMSG")
            gsConnectionString = colSettings.Item("ConnectionString") & gsConnectionString
            gsDatabaseIPAddress = colSettings.Item("ConnectionString").ToUpper.Trim.ToString.Replace(" ", "").Replace("SERVER=", "")
            If InitialConnection(gsConnectionString) Then

                '$$$$$$$ Mic1 -> CPUID; Mic2 -> MotherBoard; Mic3 -> HardDriveID
                strSystemConfig.tb_SystemWorkstationConfig = SQL_QueryGetTableResult(" SELECT ID,WorkstationName,Mic_1,Mic_2,Mic_3 " &
                                                                                     " ,LastEmployeeID,LastLogin,POS_Printer,POS_PrinterNoPrinter,POS_DisplayPoleComPortName " &
                                                                                     " FROM tb_SystemWorkstationConfig WITH (NOLOCK) ")

                If gsConnectionString.ToUpper.Contains("_TEST") Then
                    gfrmMDI.Text = "All In One Payment Solutions ( Version: " & My.Application.Info.Version.ToString & " )  -  Test database is used!!!"
                    MessageBox.Show("You had connected into the test database, please contact vendor to resolve this issue!!!" & vbNewLine & vbNewLine & "DO NOT USE THIS APPLICATION FOR YOUR BUSINESS OPERATION!!", "Test Database Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    gfrmMDI.Text = "All In One Payment Solutions ( Version: " & My.Application.Info.Version.ToString & " )"
                End If



                StrEmployeeInformation.ComputerName = GetPCName()
                StrEmployeeInformation.tbUserlogin = New DataTable
                StrEmployeeInformation.tbUserlogin = GetSecurityUserLogin()

                strSystemConfig.tb_SystemConfig = New DataTable
                strSystemConfig.tb_SystemConfig = SQL_QueryGetTableResult("SELECT * FROM tb_SystemConfig WITH (NOLOCK) ")

                strSystemConfig.tb_SelectOption = New DataTable
                strSystemConfig.tb_SelectOption = SQL_QueryGetTableResult("SELECT * FROM tbSelectOption WITH (NOLOCK) ")

                strSystemConfig.tb_Empolyee = New DataTable
                strSystemConfig.tb_Empolyee = SQL_QueryGetTableResult("SELECT * FROM tb_Security_Employee WITH (NOLOCK) ORDER BY FirstName, LastName")

            Else
                gfrmMDI.Text = "All In One Payment Solutions ( Version: " & My.Application.Info.Version.ToString & " )  Online order only"
            End If

            If colSettings.Item("DisplayMSG").ToString.ToUpper.Trim = "TRUE" Then
                gbDebugDisplayMSG = True
            Else
                gbDebugDisplayMSG = False
            End If


        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Starting Application")
            Application.Exit()
        End Try

    End Sub

    Friend Function GetProductIDArray(ByVal arrObj() As String, ByVal dSet As DataSet) As Array
        Try
            If Not dSet Is Nothing Then
                Dim dTable As DataTable = dSet.Tables(dSet.Tables.Count - 1)
                ReDim arrObj(dTable.Rows.Count - 1)
                For j As Integer = 0 To dTable.Rows.Count - 1
                    arrObj(j) = dTable.Rows(j).Item(0).ToString
                Next
            End If
            Return arrObj
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Starting POS GetProductIDArray")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "GetProductIDArray - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Get the config from db and start to setup POS base on db config
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub POS_Setup()
        Try

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Starting POS_Setup")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "POS_Setup - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Friend Function InitialConnection(ByVal DBconnectionPath As String) As Boolean
        Try
            If Not gobjADO Is Nothing Then gobjADO = Nothing
            If gobjADO Is Nothing Then
                gobjADO = New AviatCom_ADO.AviatCom_ADO

                If gobjADO.InitialConnection(DBconnectionPath, True, False) Is Nothing Then
                    MessageBox.Show("No Database connection.  Plase make sure the database connection string and location of the database.", "DB Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LogToSystemEvent(gsApplicationClientID, "InitialConnection", "InitialConnection - Error " & Chr(13) & Now & Chr(13) & "               No Database connection.  Plase make sure the database connection string and location of the database.", "Error")
                    If MessageBox.Show("Unable to connection to your system!!", "Do you wants to continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Application.Exit()
                        End
                    Else
                        gbOnlineOrderOnly = True
                        Return False
                    End If

                End If
            End If
            Return True
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error InitialConnection")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "InitialConnection - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            If MessageBox.Show("Unable to connection to your system!!", "Do you wants to continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Application.Exit()
                End
            Else
                gbOnlineOrderOnly = True
                Return False
            End If

        End Try

    End Function

    Friend Sub FillComboBox(ByRef Combo As System.Windows.Forms.ComboBox, ByVal DTable As DataTable, Optional ByVal sFirstConstant As String = "ALL")
        Dim i As Integer
        Try
            Combo.Items.Clear()

            If sFirstConstant <> "" Or DTable Is Nothing Then
                Combo.Items.Add(sFirstConstant)
            End If
            If Not DTable Is Nothing Then
                For i = 0 To DTable.Rows.Count - 1
                    Combo.Items.Add(DTable.Rows(i).Item(0))
                Next

            End If

            If Combo.Items.Count > 0 Then Combo.SelectedIndex = 0
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error FillComboBox")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "FillComboBox - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    'Friend Function LoadComboList(ByVal vParam As ArrayList, ByVal COMMAND As SqlCommand, _
    '                Optional ByVal Combo As ComboBox = Nothing, Optional ByVal ListB As ListBox = Nothing, _
    '                Optional ByVal ComboDefaultAdd As String = "", Optional ByVal ComboDefaultSelect As String = "") As Boolean
    '    'Load NEW Tag List and tags for selected Group
    '    Dim n As Integer
    '    Dim DSet As DataSet
    '    Dim DT As DataTable

    '    Try
    '        If COMMAND Is Nothing Then

    '            Exit Function
    '        End If

    '        If Not ListB Is Nothing Then
    '            ListB.Items.Clear()
    '            DSet = gObjAdo.GetResults(vParam, COMMAND)
    '            If Not DSet Is Nothing Then
    '                DT = DSet.Tables(0)
    '                For n = 0 To DT.Rows.Count - 1
    '                    ListB.Items.Add(DT.Rows(n).Item(0))

    '                Next
    '                DSet.Dispose()
    '            End If
    '        Else
    '            Combo.Items.Clear()
    '            Combo.Text = ""
    '            DSet = gObjAdo.GetResults(vParam, COMMAND)

    '            If Not DSet Is Nothing Then
    '                DT = DSet.Tables(0)
    '                For n = 0 To DT.Rows.Count - 1
    '                    Combo.Items.Add(DT.Rows(n).Item(0))

    '                    If ComboDefaultSelect.ToUpper = Combo.Items(Combo.Items.Count - 1).ToString.ToUpper Then
    '                        Combo.SelectedIndex = n
    '                    End If
    '                Next
    '                DSet.Dispose()
    '            End If

    '            If ComboDefaultAdd <> "" Then
    '                If Combo.SelectedIndex = -1 And Combo Is Nothing Then
    '                    Combo.Items.Add(ComboDefaultAdd)
    '                    Combo.SelectedIndex = 0
    '                ElseIf Combo.SelectedIndex = -1 Then
    '                    Combo.Items.Insert(0, ComboDefaultAdd)
    '                    Combo.SelectedIndex = 0
    '                End If

    '            End If
    '        End If


    '        Return mbLoadComboList

    '    Catch exp As Exception
    '        If gbDebugDisplayMSG Then MessageBox.Show("Error LoadComboList")
    '        LogToSystemEvent(gsApplicationClientID, msModuleName, "LoadComboList - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
    '    End Try
    'End Function


    Public Function GetTableTemp(ByVal Command As SqlCommand, Optional ByVal vParam As ArrayList = Nothing, Optional ByVal TableNumber As Integer = 0) As DataTable
        Try
            Dim i As Integer
            Dim DAdapter As SqlDataAdapter
            Dim DSet As DataSet
            Dim DTable As DataTable = Nothing

            If Not vParam Is Nothing Then
                For i = 0 To vParam.Count - 1
                    Command.Parameters(i).Value = vParam(i)
                Next
            End If

            DAdapter = New SqlDataAdapter(Command)
            DSet = New DataSet
            DAdapter.Fill(DSet)
            DTable = DSet.Tables(TableNumber)
            Return DTable
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetTableTemp")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "GetTableTemp - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return Nothing
        End Try

    End Function
    Friend Sub UpdateDBFromDSet(ByRef DSet1 As DataSet, ByRef cmdUpdate As SqlCommand)
        Dim UpdatedRows As System.Data.DataSet = Nothing
        Dim InsertedRows As System.Data.DataSet = Nothing
        Dim DeletedRows As System.Data.DataSet = Nothing
        Dim nCount As Integer
        Dim sAction As String = ""
        Dim row As DataRow
        Try
            'these three are Data Table that hold any changes that have been made to the dataset
            'since the last update.

            UpdatedRows = DSet1.GetChanges(DataRowState.Modified)
            InsertedRows = DSet1.GetChanges(DataRowState.Added)
            DeletedRows = DSet1.GetChanges(DataRowState.Deleted)


            If Not UpdatedRows Is Nothing Or Not InsertedRows Is Nothing Or Not DeletedRows Is Nothing Then
                'For each of these, we have to make sure that the Data Tables contain
                'any records, otherwise, we will get an error.
                If Not UpdatedRows Is Nothing Then
                    sAction = "UPDATE"
                    For Each row In UpdatedRows.Tables(UpdatedRows.Tables.Count - 1).Rows
                        cmdUpdate.Parameters(0).Value = sAction
                        For nCount = 0 To UpdatedRows.Tables(UpdatedRows.Tables.Count - 1).Columns.Count - 1

                            If (cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int32 Or _
                                        cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int16) _
                                                And row(nCount, DataRowVersion.Original).ToString = "" Then
                                cmdUpdate.Parameters(nCount + 1).Value = 0

                            Else
                                cmdUpdate.Parameters(nCount + 1).Value = row.Item(nCount).ToString
                            End If
                            Debug.WriteLine(cmdUpdate.Parameters(nCount + 1).ParameterName & "   " & row.Item(nCount))
                        Next nCount

                        cmdUpdate.ExecuteNonQuery()
                    Next
                End If

                If Not InsertedRows Is Nothing Then
                    sAction = "ADD"
                    Dim nCol_1 As Integer
                    For Each row In InsertedRows.Tables(InsertedRows.Tables.Count - 1).Rows
                        cmdUpdate.Parameters(0).Value = sAction
                        nCol_1 = InsertedRows.Tables(InsertedRows.Tables.Count - 1).Columns.Count - 1
                        For nCount = 0 To nCol_1
                            If (cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int32 Or _
                                        cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int16 Or _
                                        cmdUpdate.Parameters(nCount + 1).DbType = DbType.Decimal Or _
                                        cmdUpdate.Parameters(nCount + 1).DbType = DbType.Double) And _
                                            row.Item(nCount).ToString = "" Then
                                cmdUpdate.Parameters(nCount + 1).Value = 0
                            ElseIf (cmdUpdate.Parameters(nCount + 1).DbType = DbType.AnsiString Or _
                                    cmdUpdate.Parameters(nCount + 1).DbType = DbType.AnsiStringFixedLength) _
                                            And row.Item(nCount).ToString = "" Then
                                cmdUpdate.Parameters(nCount + 1).Value = ""
                            Else
                                Debug.Print(row.Item(nCount).ToString)
                                cmdUpdate.Parameters(nCount + 1).Value = row.Item(nCount).ToString
                            End If

                        Next nCount

                        cmdUpdate.ExecuteNonQuery()
                    Next
                End If

                If Not DeletedRows Is Nothing Then
                    sAction = "DELETE"
                    For Each row In DeletedRows.Tables(DeletedRows.Tables.Count - 1).Rows
                        cmdUpdate.Parameters(0).Value = sAction
                        For nCount = 0 To DeletedRows.Tables(DeletedRows.Tables.Count - 1).Columns.Count - 1
                            If (cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int32 Or cmdUpdate.Parameters(nCount + 1).DbType = DbType.Int16) _
                                    And row(nCount, DataRowVersion.Original).ToString = "" Then
                                cmdUpdate.Parameters(nCount + 1).Value = 0
                            Else
                                cmdUpdate.Parameters(nCount + 1).Value = row(nCount, DataRowVersion.Original).ToString
                            End If
                        Next nCount

                        cmdUpdate.ExecuteNonQuery()
                    Next
                End If
                DSet1.AcceptChanges()
            End If

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error UpdateDBFromDSet")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "UpdateDBFromDSet - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try

    End Sub
    Friend Sub UpdateANY(ByVal arrParam As ArrayList, ByVal cmdUpdate As SqlCommand)
        'load to DB
        Dim n As Integer
        Try
            For n = 0 To cmdUpdate.Parameters.Count - 1 'arrParam.Count - 1
                If (cmdUpdate.Parameters(n).DbType = DbType.Int32 Or _
                                        cmdUpdate.Parameters(n).DbType = DbType.Int16) And _
                                            arrParam(n) = "" Then 'arrParam.Count - 1 <= n Then
                    cmdUpdate.Parameters(n).Value = 0
                ElseIf (cmdUpdate.Parameters(n).DbType = DbType.AnsiString Or _
                        cmdUpdate.Parameters(n).DbType = DbType.AnsiStringFixedLength) _
                               And arrParam(n) = "" Then 'And arrParam.Count - 1 < n Then
                    cmdUpdate.Parameters(n).Value = ""

                Else
                    cmdUpdate.Parameters(n).Value = arrParam(n)
                End If
                Debug.WriteLine(cmdUpdate.Parameters(n).Value)
            Next
            cmdUpdate.ExecuteNonQuery()

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error UpdateANY")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "UpdateANY - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

        End Try
    End Sub

    'Friend Sub CaptureScreen(ByVal frm As Form, ByRef memoryImage As Bitmap)
    '    Try
    '        Dim mygraphics As Graphics = frm.CreateGraphics()
    '        Dim s As Size = frm.Size
    '        memoryImage = New Bitmap(s.Width, s.Height, mygraphics)
    '        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
    '        Dim dc1 As IntPtr = mygraphics.GetHdc
    '        Dim dc2 As IntPtr = memoryGraphics.GetHdc
    '        BitBlt(dc2, 0, 0, frm.ClientRectangle.Width, _
    '           frm.ClientRectangle.Height, dc1, 0, 0, 13369376)
    '        mygraphics.ReleaseHdc(dc1)
    '        memoryGraphics.ReleaseHdc(dc2)
    '    Catch exp As Exception
    '        If gbDebugDisplayMSG Then MessageBox.Show("Error CaptureScreen")
    '        LogToSystemEvent(gsApplicationClientID, msModuleName, "CaptureScreen - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

    '    End Try

    'End Sub






    Public Function CheckChar(ByVal KeyCode As Integer, ByVal IsNumeric As Boolean) As Boolean
        Try
            If KeyCode = 220 Then
                Return False
            End If
            If KeyCode = 37 Or KeyCode = 38 Or KeyCode = 39 Or KeyCode = 40 Or KeyCode = 13 Or KeyCode = 8 Or KeyCode = 46 Or (KeyCode < 32 Or KeyCode > 90) Then
                Return True
            End If

            If IsNumeric Then
                If KeyCode >= 48 And KeyCode <= 57 Then
                    Return True
                Else
                    Return False
                End If
            Else
                If KeyCode < 48 Or KeyCode > 57 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error CheckChar")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "CheckChar - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return False
        End Try

    End Function



    Private Function BitShopPing(ByVal hostname As String) As Boolean
        Try
            Dim ping As New NetworkInformation.Ping()
            Dim reply As NetworkInformation.PingReply = ping.Send(hostname)
            If reply.Status = NetworkInformation.IPStatus.Success Then
                ' TODO: Remove debugging output. Sample is a console app.
                'debug.WriteLine("Address: {0}", reply.Address.ToString())
                'debug.WriteLine("RoundTrip time: {0}", reply.RoundtripTime)
                'debug.WriteLine("Time to live: {0}", reply.Options.Ttl)
                'debug.WriteLine("Don't fragment: {0}", reply.Options.DontFragment)
                'debug.WriteLine("Buffer size: {0}", reply.Buffer.Length)
                Return True
            Else
                Return False
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error BitShopPing")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "BitShopPing - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return False
        End Try
    End Function
    Friend Sub AddVeriftyCode(ByVal sAccessCode As String, Optional ByVal sDescription As String = "")
        Try
            Dim Cmd As SqlCommand = gobjADO.GetADOCommand("sp_Security_AddAccessCodes")
            gobjADO.ExecuteSP(GetParam(sAccessCode, sDescription), Cmd)

            If Not Cmd Is Nothing Then Cmd.Dispose()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error AddVeriftyCode")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "AddVeriftyCode - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub VerifyExpirDate(ByVal sWarningDate As String, ByVal sExprierDate As String)
        Try
            If Today > sExprierDate Then

                MessageBox.Show("You Inventory Management System is expired.  Please contact (321OrderNow.com) to update your software." & Chr(13) & Chr(13) & _
                "E-Mail: SUPPORT@321OrderNow.com" & Chr(13) & "CELL PHONE: 646-703-8888", "Inventory Management System is expire! expired", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Application.Exit()
            ElseIf Today > sWarningDate Then
                MessageBox.Show("You Inventory Management System is going to expired.  Please contact (321OrderNow.com) to update your software." & Chr(13) & Chr(13) & _
               "E-Mail: SUPPORT@321OrderNow.com" & Chr(13) & "CELL PHONE: 646-703-8888", "Inventory Management System is going to expired", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error VerifyExprierDate")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "VerifyExprierDate - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Application.Exit()
        End Try
    End Sub

    Friend Function SecurityHasAccess(ByVal sAccessCode As String, ByVal bPrompt As Boolean) As Boolean
        Dim sAccessStatus As String
        Dim sErrorMessage As String = ""
        Dim DTb As DataTable
        Try

            Dim cmdSecurityAccess As SqlCommand = gobjADO.GetADOCommand("sp_Secuity_VeritfyAccess")

            DTb = gobjADO.GetTable(cmdSecurityAccess, _
             GetParam(gsProfile, sAccessCode))

            If DTb Is Nothing Then
                If bPrompt = True Then
                    MessageBox.Show("Unable to authenticate user: " & gsUserName, "Security Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                Return False
            End If

            sAccessStatus = DTb.Rows(0).Item(0)
            DTb.Clear()
            DTb.Dispose()
            cmdSecurityAccess.Dispose()

            Select Case sAccessStatus

                Case "SUCCESS"
                    'If bPrompt = True Then
                    'MessageBox.Show(sErrorMessage, "User Has Access to " & sAccessCode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End If
                    Return True
                    'Case "INVALID USERNAME"
                    '    sErrorMessage = "User " & msUserID & " does not exist."
                    'Case "ENTER ADMINISTRATOR USER NAME AND PASSWORD"
                    '    sErrorMessage = "Security did not setup yet. Enter Administrator User Name and Password."
                    '    mbNeedNewAdminData = True
                    'Case "INVALID PASSWORD"
                    '    sErrorMessage = "Invalid Password"
                    '    'mbNeedNewAdminData = True
                    'Case "INSUFFICIENT SECURITY ACCESS"
                    '    sErrorMessage = "You do not have sufficient authorization to access this system."

                    'Case "ACCESS CODE DOES NOT EXIST"
                    '    If bPrompt = True Then
                    '        If WHMSGBoxShow("This Access Code has not been entered yet." & vbCrLf & "Do you want to set it up now?", "Security Setup", MessageBoxButtons.YesNo, Media.SystemSounds.Hand) = DialogResult.Yes Then
                    '            'If MsgBox("This Access Code has not been entered yet." & Chr(13) & Chr(13) & "Do you want to set it up now?", vbYesNo + vbSystemModal, "Security Setup") = vbYes Then
                    '            If Not ActiveFrm Is Nothing Then
                    '                ActiveFrm.Close()
                    '            End If
                    '            ActiveFrm = New frmAddCTRL(Me, sAccessCode)
                    '            'ActiveFrm.TopMost = True
                    '            SetWindowPos(ActiveFrm.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE)
                    '            ActiveFrm.ShowDialog()
                    '        End If
                    '        bPrompt = False
                    '    End If
                Case Else
                    If bPrompt = True Then
                        MessageBox.Show("You do not have sufficient authorization to access this system.", "User Has Access to " & sAccessCode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

            End Select
            Return False



        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error SecurityHasAccess")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "SecurityHasAccess - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return False
        End Try
    End Function

    Friend Sub CloseAllMDIChildForms(ByVal MDIfrm As Form)
        ' Obtain a reference to the currently active MDI child form
        'and close one.
        Dim MDIChild As Form = MDIfrm.ActiveMdiChild
        For Each MDIChild In MDIfrm.MdiChildren
            If Not MDIChild Is Nothing Then
                MDIChild.Hide()
                MDIChild.Dispose()
            End If
        Next
    End Sub
    ''' <summary>
    ''' this need to be motify and test.  John 10/21/2011
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SaveIMGtoDB()
        'Save an Image to a memory stream so you can get the bytes
        Dim sampleImage As Bitmap = New Bitmap(100, 100)
        Dim mStream As New System.IO.MemoryStream
        Dim ImageBytes As Byte()

        sampleImage.Save(mStream, Imaging.ImageFormat.Png)
        ImageBytes = mStream.ToArray

        'Sample Insert image command
        'Save the bytes from the image into a image or varbinary column
        Dim com As New SqlClient.SqlCommand("Insert Into MyTable" & vbCrLf & _
        "(MyImageColumn)" & vbCrLf & _
        "Values(@MyImage)")

        'an image column or varbinary column
        com.Parameters.Add("@MyImage", SqlDbType.Image)
        com.Parameters("@MyImage").Value = ImageBytes


        'Sample Read Image Command
        'Read the bytes from the table and create a new memory stream from them
        com.CommandText = "Select MyImage From MyTable"
        Dim rdr As System.Data.SqlClient.SqlDataReader

        rdr = com.ExecuteReader
        If rdr.Read Then
            Dim newMstream As New System.IO.MemoryStream(CType(rdr.Item("MyImage"), Byte()))
            'Create a new image from the bytes from the memory
            Dim ImageFromDB As New Bitmap(newMstream)

        End If
    End Sub

    ' ''' <summary>
    ' ''' Change Display grid format
    ' ''' </summary>
    ' ''' <param name="objMyGrid">Display grid object</param>
    ' ''' <param name="objCaptionFont">Caption Setting, Font object needed</param>
    ' ''' <param name="objColumnFont">Columns Setting, Font object needed</param>
    ' ''' <param name="iCaptionHeight">Caption Height</param>
    ' ''' <param name="iRowHeight">Row Height</param>
    ' ''' <param name="objFooterFont">Footer Setting, Font object needed</param>
    ' ''' <param name="iFooterHeight">Footer Height</param>
    ' ''' <returns>Return Grid as object</returns>
    ' ''' <remarks></remarks>
    'Friend Function FormatMyGridFont(ByVal objMyGrid As AviatCom_DefaultGrid, ByVal objCaptionFont As Font, ByVal objColumnFont As Font, Optional ByVal iCaptionHeight As Integer = 40, Optional ByVal iRowHeight As Integer = 20, Optional ByVal objFooterFont As Font = Nothing, Optional ByVal iFooterHeight As Integer = 10) As AviatCom_DefaultGrid
    '    Try
    '        'For j As Integer = 0 To objMyGrid.Columns.Count - 1
    '        '    objMyGrid.Splits(0).DisplayColumns(j).HeadingStyle.Font = objCaptionFont
    '        'Next
    '        objMyGrid.CaptionStyle.Font = objCaptionFont
    '        objMyGrid.Splits(0).Style.Font = objColumnFont
    '        objMyGrid.RowHeight = iRowHeight
    '        objMyGrid.Splits(0).ColumnCaptionHeight = iCaptionHeight
    '        objMyGrid.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        objMyGrid.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
    '        objMyGrid.CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        objMyGrid.CaptionStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom

    '        If Not objFooterFont Is Nothing Then
    '            For j As Integer = 0 To objMyGrid.Columns.Count - 1
    '                objMyGrid.Splits(0).DisplayColumns(j).FooterStyle.Font = objFooterFont
    '            Next
    '            objMyGrid.Splits(0).ColumnFooterHeight = iFooterHeight
    '        End If
    '        Return objMyGrid
    '    Catch exp As Exception
    '        If gbDebugDisplayMSG Then MessageBox.Show("Error FormatMyGridFont")
    '        LogToSystemEvent(gsApplicationClientID, msModuleName, "FormatMyGridFont - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
    '        Return objMyGrid
    '    End Try
    'End Function

    Friend Function GetDaysInMonth(ByVal MyYear As Integer, ByVal MyMonth As Integer) As Integer
        Return DateTime.DaysInMonth(MyYear, MyMonth)
    End Function
    Friend Function ValidateNumeric(ByVal keyCode As Windows.Forms.Keys)
        Dim bValid = False
        'MessageBox.Show("KeyCode - " & keyCode & "   " & keyCode.ToString & "        -    ASII   " & Asc(keyCode))
        If Not (keyCode = Keys.Back Or keyCode = Keys.Delete Or keyCode = Keys.Left Or keyCode = Keys.Right Or keyCode = Keys.Up Or keyCode = Keys.Down Or keyCode = Keys.OemPeriod) Then
            If IsNumeric(Chr(keyCode)) Then
                bValid = True
            ElseIf keyCode.ToString.ToUpper.Contains("NUMLOCK") Then
                bValid = True
            ElseIf keyCode.ToString.ToUpper.Contains("NUMPAD") Then
                bValid = True
            End If
        Else
            bValid = True
        End If
        Return bValid
    End Function
    'Friend Sub PrintLabel(ByVal sOrderNumber As String, Optional ByVal iNumberOfSetPrint As Integer = 1)

    '    Try
    '        Dim dSet As New DataSet
    '        dSet = gobjADO.GetResults(GetParam(sOrderNumber), gCmd_GetLabelPrint)
    '        If dSet Is Nothing Then
    '            MessageBox.Show("No record from database!")
    '            Exit Sub
    '        End If
    '        If Not dSet.Tables.Count = 3 Then
    '            MessageBox.Show("Incorrect Tables return from database!")
    '            Exit Sub
    '        End If

    '        Dim sYourCompanyName As String = dSet.Tables(0).Rows(0).Item("CompayName").ToString
    '        Dim sCustomerCompanyName As String = dSet.Tables(1).Rows(0).Item("CompanyName").ToString
    '        Dim sOrderDate As String = dSet.Tables(1).Rows(0).Item("OrderDate").ToString
    '        Dim sDueDate As String = dSet.Tables(1).Rows(0).Item("DueDate").ToString
    '        Dim sPONumber As String = dSet.Tables(1).Rows(0).Item("PONumber").ToString
    '        Dim sDeliveryType As String = dSet.Tables(1).Rows(0).Item("DeliveryType").ToString
    '        Dim objPrinter As New BrotherPrinter
    '        Try
    '            'For t As Integer = 1 To iNumberOfSetPrint
    '            For j As Integer = 0 To dSet.Tables(2).Rows.Count - 1
    '                'For i As Integer = 0 To Val(dSet.Tables(2).Rows(j).Item("Order QTY").ToString) - 1
    '                With objPrinter
    '                    .SetCompanyName = sYourCompanyName
    '                    .SetCustomerCompanyName = sCustomerCompanyName
    '                    .SetPONumber = sPONumber
    '                    .SetOrderNumber = sOrderNumber
    '                    .SetDeliveryType = sDeliveryType



    '                    .SetThickness = dSet.Tables(2).Rows(j).Item("Thickness").ToString
    '                    .SetGlassDesc = dSet.Tables(2).Rows(j).Item("GlassName").ToString
    '                    .SetSize = dSet.Tables(2).Rows(j).Item("Size").ToString

    '                    .SetItemComment = dSet.Tables(2).Rows(j).Item("Comments").ToString
    '                    .SetQTY = Val(dSet.Tables(2).Rows(j).Item("Order QTY").ToString)
    '                    .SetCopyCount = iNumberOfSetPrint * Val(dSet.Tables(2).Rows(j).Item("Order QTY").ToString)
    '                    .PrintLabel()
    '                End With
    '                'Next i
    '            Next j
    '            'Next t

    '            ' If Not objPrinter Is Nothing Then objPrinter.Dispose()
    '        Catch exp As Exception
    '            If gbDebugDisplayMSG Then MessageBox.Show("Error PrintLabel")
    '            LogToSystemEvent(gsApplicationClientID, msModuleName, "PrintLabel - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
    '        Finally
    '            objPrinter.Dispose()
    '        End Try
    '    Catch exp As SqlException
    '        If gbDebugDisplayMSG Then MessageBox.Show("Error PrintLabel")
    '        LogToSystemEvent(gsApplicationClientID, msModuleName, "PrintLabel (SQL) - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
    '    End Try
    'End Sub
    ''' <summary>
    ''' Check for file exist or not
    ''' </summary>
    ''' <param name="FullFilePath">Full Path for file</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function LocalFileExist(ByVal FullFilePath As String, Optional ByVal bDeleteExistsFile As Boolean = False) As Boolean
        Try
            If IO.File.Exists(FullFilePath) Then
                If bDeleteExistsFile Then
                    Try
                        IO.File.Delete(FullFilePath)
                    Catch ex As Exception
                        MessageBox.Show("File already exists and cannot be remore")
                        Return True
                    End Try
                End If
                Return True
            Else
                Return False
            End If

            'Return IO.File.Exists(FullFilePath)
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error LocalFileExist")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "LocalFileExist - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return Nothing
        End Try
    End Function
    Friend Function CheckFileDirectory(ByVal sFolderPath As String) As Boolean
        Try

            If Not IO.Directory.Exists(sFolderPath) Then
                IO.Directory.CreateDirectory(sFolderPath)
            End If
            Return True
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error CheckFileDirectory")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "CheckFileDirectory - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return False
        End Try
    End Function
   

    Public Sub SetupBackupDatabase()
        Try
            Dim sPCName As String = My.Computer.Name.ToUpper

            mtProcessingData = New Threading.Thread(AddressOf ProcessingBackupDatabase)
            mtProcessingData.SetApartmentState(System.Threading.ApartmentState.STA)
            mtProcessingData.Start()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error SetupBackupDatabase")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "SetupBackupDatabase - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

        End Try
    End Sub
    Private Sub ProcessingBackupDatabase()
        Dim cmd_BackupDB As SqlCommand = gobjADO.GetADOCommand("sp_BackupDatabase")

        Dim TickCount As Long = Math.Abs(System.Environment.TickCount)
        Try


            Do
                Try
                    'If DateDiff(DateInterval.Day, mdtLastBackup.Date, Today) > 0 Then
                    '    mdtLastBackup = Today
                    '    gobjADO.ExecuteSP(GetParam(mdtLastBackup), cmd_BackupDB)
                    'End If
                    'If Math.Abs(Math.Abs(System.Environment.TickCount) - TickCount) >= miBackupInterval Then


                    '    TickCount = Math.Abs(System.Environment.TickCount)
                    'End If
                    Thread.Sleep(3600000)
                Catch exp As Exception
                    If gbDebugDisplayMSG Then MessageBox.Show("Error Processing ProcessingBackupDatabase")
                    LogToSystemEvent(gsApplicationClientID, msModuleName, "Processing ProcessingBackupDatabase - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

                End Try
            Loop
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error ProcessingBackupDatabase")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "ProcessingBackupDatabase - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            If Not cmd_BackupDB Is Nothing Then cmd_BackupDB.Dispose()
        End Try
    End Sub
    
    Friend Function EnterDeposit(ByVal sTransactionID As String, ByVal sDepositType As String, ByVal dDeposit As Decimal)
        Dim bResulte As Boolean = False
        Try
            SQL_ExecuteSP("UPDATE tb_Transaction SET Deposit = " & dDeposit & ", DepositType = '" & sDepositType & "', DepositDate = GETDATE() WHERE TransactionID = '" & sTransactionID & "'")
            If SQL_QueryCheckRecordExsits("SELECT TransactionID FROM tb_Transaction WITH (NOLOCK) WHERE  TransactionID = '" & sTransactionID & "' AND Deposit = " & dDeposit) > 0 Then
                bResulte = True
            End If
            Return bResulte
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "EnterDeposit Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - ActiveOpenedForm: " & vbNewLine & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show("ActiveOpenedForm" & vbNewLine & exp.Message, "ActiveOpenedForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResulte
        End Try
    End Function
    Friend Function EnterPayAmount(ByVal sOrderID As String, ByVal sPaymentType As String, ByVal dPayAmount As Decimal)
        Dim bResulte As Boolean = False
        Try
            SQL_ExecuteSP("UPDATE tb_Order SET PaymentType = '" & sPaymentType & "', PaidAmount = Amount, PaymentDate = GETDATE(), PaymentStatus = 'Paid' WHERE OrderID = '" & sOrderID & "'")
          
            Return bResulte
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "EnterPayAmount Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - ActiveOpenedForm: " & vbNewLine & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show("ActiveOpenedForm" & vbNewLine & exp.Message, "ActiveOpenedForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResulte
        End Try
    End Function

    Friend Function GetAmountFromString(ByVal sAmount As String, ByVal sAddOn As String, Optional ByVal bReverse As Boolean = False)
        Dim sReturnAmount As String = ""
        Dim bIsNegative As Boolean = sAmount.Contains("(") Or sAmount.Contains("-")
        Try

            If bReverse Then
                If sAddOn = "-" Then
                    If bIsNegative Then bIsNegative = False Else bIsNegative = True
                ElseIf sAddOn.ToUpper <> "BACKSPACE" Then
                    sReturnAmount = sAddOn
                End If


                For j As Integer = Len(sAmount) - IIf(sAddOn.ToUpper = "BACKSPACE", 1, 0) To 1 Step -1
                    If Len(sReturnAmount) = 2 Then sReturnAmount = "." & sReturnAmount
                    If Mid(sAmount, j, 1).ToString <> "." And Mid(sAmount, j, 1).ToString <> "," Then sReturnAmount = Mid(sAmount, j, 1).ToString & sReturnAmount
                Next
                sReturnAmount = sReturnAmount.Replace("$", "")
                If Len(sReturnAmount) = 1 Then
                    sReturnAmount = "0.0" & sReturnAmount
                ElseIf Len(sReturnAmount) = 2 Then
                    sReturnAmount = "0." & sReturnAmount
                ElseIf Not sReturnAmount.Contains(".") Then
                    sReturnAmount = sReturnAmount.Insert(Len(sReturnAmount) - 2, ".")
                End If
                sReturnAmount = FormatCurrency(Val(sReturnAmount) * IIf(bIsNegative, -1, 1), 2).ToString
                'If Len(sReturnAmount) <= 4 Then
                '    For j As Integer = 1 To 5
                '        If Mid(sReturnAmount, j, 1).ToString = "$" Then
                '            sReturnAmount = sReturnAmount.Insert(1, "0")
                '    Next
                'End If
                'For j As Integer = 2 To Len(sReturnAmount) - 3
                '    If Mid(sReturnAmount, j, 1).ToString = "0" Then
                '        If Mid(sReturnAmount, j, 2).ToString = "0." Then Exit For
                '        sReturnAmount = sReturnAmount.Remove(j - 1, 1)
                '    Else
                '        Exit For
                '    End If
                'Next
                'sReturnAmount = sReturnAmount.Replace("$0.", "$.")
            Else
                If sAddOn.ToUpper = "BACKSPACE" Then
                    Return Strings.Left(sAmount, Len(sAmount) - 1)
                End If
                Dim arrTemp As Array = sAmount.Split(".")
                If Not IsNumeric(sAddOn) Then
                    If Not sAddOn = "." Then sAddOn = ""
                End If
                If arrTemp.Length > 1 Then
                    If Not sAddOn = "." Then
                        If Len(arrTemp(1).ToString) <= 1 Then
                            sReturnAmount = sAmount + sAddOn
                        Else
                            sReturnAmount = sAmount
                        End If
                    Else
                        sReturnAmount = sAmount
                    End If
                Else
                    sReturnAmount = sAmount + sAddOn
                End If
            End If

            Return sReturnAmount
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetAmountFromString Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "GetAmountFromString Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return sReturnAmount
        End Try
    End Function
    Friend Function GetAmountDifferent(ByVal dAmount As Decimal, ByVal dDeposit As Decimal, ByVal dOtherAmount As Decimal, Optional bWithCurrencySign As Boolean = True) As String
        Dim sReturnAmount As String = ""
        Try
            sReturnAmount = dAmount - dDeposit - dOtherAmount
            'If Strings.InStr(sReturnAmount, ".") Then
            '    Dim arrTemp As Array = sReturnAmount.Split(".")
            '    If Len(arrTemp(1)) >= 2 Then
            '        sReturnAmount = arrTemp(0).ToString & "." & Strings.Left(arrTemp(1).ToString, 2)
            '    Else
            '        sReturnAmount = arrTemp(0).ToString & "." & arrTemp(1) & Strings.Left("00", Len(arrTemp(1).ToString))
            '    End If
            'End If
            Return IIf(bWithCurrencySign, FormatCurrency(sReturnAmount, 2), sReturnAmount)
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetAmountFromString Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "GetAmountFromString Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return sReturnAmount
        End Try
    End Function
   
    Friend Function GetEmpolyeeNameByID(ByVal iEmployeeID As String) As String
        Dim sEmployeeName As String = ""
        Try
            Dim dRow() As DataRow

            dRow = StrEmployeeInformation.tbUserlogin.Select("EmployeeID = " & iEmployeeID)


            If dRow Is Nothing Then
                MessageBox.Show("Check network connection.  Fail on get employee name", "Fail to get db Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dRow.Count > 0 Then
                sEmployeeName = dRow(0).Item("FirstName").ToString & " " & dRow(0).Item("LastName").ToString
            End If
            Return sEmployeeName
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetEmpolyeeNameByID")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "GetEmpolyeeNameByID - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return sEmployeeName
        End Try
    End Function
    Friend Function GetCustomerID(ByVal sCompanyName As String) As String
        Dim sCustomerID As String = ""
        Try
            Dim dRow() As DataRow

            'dRow = strSystemConfig.tb_CustomerInformation.Select("CompanyName = '" & sCompanyName & "'")


            If dRow Is Nothing Then
                MessageBox.Show("Check network connection.  Fail on get employee name", "Fail to get db Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dRow.Count > 0 Then
                sCustomerID = dRow(0).Item("CustomerID").ToString
            End If
            Return sCustomerID
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetCustomerID")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "GetCustomerID - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return sCustomerID
        End Try
    End Function

  

    Friend Function PostOrder(ByVal sOrderID As String, Optional ByVal dOrderAmount As Decimal = 0, Optional ByVal dCustomerPaidAmount As Decimal = 0, Optional ByVal sPaymentType As String = "", Optional ByVal bRetailPaidInFull As Boolean = False) As Boolean
        Dim bSuccess As Boolean = False
        Try
            If Not gobjADO.ExecuteSP(GetParam(sOrderID, StrEmployeeInformation.EmployeeID, IIf(bRetailPaidInFull, "YES", "NO"), dOrderAmount, dCustomerPaidAmount, sPaymentType, StrEmployeeInformation.Location), gobjADO.GetADOCommand("spPost_Order")) Then
                MessageBox.Show("Unable to Post Order for ( OrderID: " & sOrderID & " )" & vbNewLine & "Inventory had not been update yet!" & vbNewLine & vbNewLine & "Please check network connection and try again.", "Unable To Post Order", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                bSuccess = True
                ActionLog(msModuleName, sOrderID, "Post Order", "Not Post", "Posted", "Post Order", StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            End If
            Return bSuccess
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error PostOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "PostOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return bSuccess
        End Try
    End Function
    Friend Function PostPayment(ByVal sOrderID As String, ByVal sOrderType As String, ByVal sPaymentID As String, ByVal sPaymentType As String, ByVal dOrderAmount As Decimal, ByVal dCustomerPaidAmount As Decimal, ByVal iEmplyeeID As Integer, Optional ByVal sRemark As String = "") As Boolean
        Dim bSuccess As Boolean = False
        Try
            If Not gobjADO.ExecuteSP(GetParam(sOrderID, sOrderType, sPaymentID, sPaymentType, dOrderAmount, dCustomerPaidAmount, iEmplyeeID, Left(sRemark.Replace("'", "''"), 499)), gobjADO.GetADOCommand("spPost_Order")) Then
                MessageBox.Show("Unable to Post Order for ( OrderID: " & sOrderID & " )" & vbNewLine & "Inventory had not been update yet!" & vbNewLine & vbNewLine & "Please check network connection and try again.", "Unable To Post Order", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                bSuccess = True
                ActionLog(msModuleName, sOrderID, "Post Payment", "Not Post", "Posted", "Post Payment", StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            End If
            Return bSuccess
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error PostPayment")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "PostPayment - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return bSuccess
        End Try
    End Function
    Friend Function PostReceiving(ByVal sPurchaseID As String) As Boolean
        Dim bSuccess As Boolean = False
        Try
            If Not gobjADO.ExecuteSP(GetParam(sPurchaseID), gobjADO.GetADOCommand("spPost_Receiving")) Then
                MessageBox.Show("Unable to Post Purchase Order for ( PurchaseID: " & sPurchaseID & " )" & vbNewLine & "Inventory had not been update yet!" & vbNewLine & vbNewLine & "Please check network connection and try again.", "Unable To Post Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                bSuccess = True
                ActionLog(msModuleName, sPurchaseID, "Post Receiving", "Not Post", "Posted", "Post Receiving", StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            End If
            Return bSuccess
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error PostReceiving")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "PostReceiving - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return bSuccess
        End Try
    End Function
    Friend Function PostReversePayment(ByVal sOrderID As String, ByVal sPaymentID As String, ByVal sPaymentType As String, ByVal dOrderAmount As Decimal, ByVal dPaidAmount As Decimal, ByVal isRetailPayment As Boolean) As Boolean
        Dim bSuccess As Boolean = False
        Try
            If Not gobjADO.ExecuteSP(GetParam(sOrderID, sPaymentID, sPaymentType, dOrderAmount, dPaidAmount, IIf(isRetailPayment, 1, 0), StrEmployeeInformation.EmployeeID, StrEmployeeInformation.Location), gobjADO.GetADOCommand("spPost_ReversePayment")) Then
                MessageBox.Show("Unable to Reverse Payment for ( OrderID: " & sOrderID & " )" & vbNewLine & vbNewLine & "Please check network connection and try again.", "Unable To Reverse Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                bSuccess = True
                ActionLog(msModuleName, sOrderID, "Reverse Payment", "Reverse Payment", "Posted", "PaymentID: " & sPaymentID, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            End If
            Return bSuccess
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error PostReversePayment")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "PostReversePayment - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return bSuccess
        End Try
    End Function
    Friend Function PostBouncedCheck(ByVal sOrderID As String, ByVal sPaymentID As String) As Boolean
        Dim bSuccess As Boolean = False
        Try
            If Not gobjADO.ExecuteSP(GetParam(sOrderID, sPaymentID, StrEmployeeInformation.Location), gobjADO.GetADOCommand("spPost_BouncedCheck")) Then
                MessageBox.Show("Unable to Bounced Check Payment for ( OrderID: " & sOrderID & " )" & vbNewLine & vbNewLine & vbNewLine & "Please check network connection and try again.", "Unable To Bounced Check Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                bSuccess = True
                ActionLog(msModuleName, sOrderID, "Bounced Check", "Bounced Check", "Posted", "PaymentID: " & sPaymentID, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            End If
            Return bSuccess
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error PostBouncedCheck")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "PostBouncedCheck - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return bSuccess
        End Try
    End Function
   
    Friend Function GetName_ID(sName_ID As String, Optional sSpliter As String = " -- ") As Integer
        Try
            Dim arrTemp As Array = Split(sName_ID, sSpliter)
            Return Val(arrTemp(1))
        Catch exp As Exception
            Return ""
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetName_ID")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "GetName_ID - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Function
    
    Friend Function GetCustomerCurrentBalance(ByVal sCustomerID As String) As Decimal
        Try
            Dim sSQLStr As String = "SELECT  ISNULL(SUM(ISNULL(Balance,0)),0) AS 'CurrentBalance' " &
                                    " FROM tb_Order WITH (NOLOCK)" &
                                   " WHERE CustomerID = '" & sCustomerID & "'" &
                                   " and IsVoid = 0"
            Using dTable As DataTable = SQL_QueryGetTableResult(sSQLStr)
                Return dTable.Rows(0).Item("CurrentBalance").ToString
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetCustomerCurrentBalance Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "GetCustomerCurrentBalance Processing Error : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return 0
        End Try
    End Function
    Friend Function GetInvoiceCurrentBalance(ByVal sOrderID As String) As Decimal
        Try
            Dim sSQLStr As String = "SELECT  Amount - PaidAmount AS 'CurrentBalance' " &
                                    " FROM tb_Order WITH (NOLOCK)" &
                                   " WHERE OrderID = '" & sOrderID & "'"
            Using dTable As DataTable = SQL_QueryGetTableResult(sSQLStr)
                Return dTable.Rows(0).Item("CurrentBalance").ToString
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetInvoiceCurrentBalance Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "GetInvoiceCurrentBalance Processing Error : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Convert date to "01/01/1900"
    ''' </summary>
    ''' <param name="dtDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ConvertToDateString(ByVal dtDate As Date) As String
        Dim sDate As String = ""
        Try
            sDate = Format(dtDate.Month, "00") & "/" & Format(dtDate.Day, "00") & "/" & dtDate.Year.ToString
            Return sDate
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "ConvertToDate Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - ActiveOpenedForm: " & vbNewLine & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show("ActiveOpenedForm" & vbNewLine & exp.Message, "ActiveOpenedForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return sDate
        End Try
    End Function

    Friend Function ReplaceSpecialCharacters(sString As String) As String
        Dim sNewString As String = ""
        Try
            sNewString = sString.ToString.Trim.Replace("&", "-and-")
            sNewString = sString.ToString.Trim.Replace("'s", "")
            sNewString = sString.ToString.Trim.Replace("'S", "")
            sNewString = sString.ToString.Trim.Replace("'", "")
            Return sNewString
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "ConvertToDate Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - ActiveOpenedForm: " & vbNewLine & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show("ActiveOpenedForm" & vbNewLine & exp.Message, "ActiveOpenedForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return sNewString
        End Try
    End Function

#Region "MyGrid"
    Friend Sub FormatMyGridCaption(ByRef objMyGrid As AviatCom_DefaultGrid, ByVal objFont As Font, ByVal cColor As Color, Optional ByVal cColor2 As System.Drawing.Color = Nothing, Optional ByVal CaptionHeight As Double = 0, Optional ByVal FooterHeight As Double = 0, Optional ByVal bWrapText As Boolean = True, Optional ByVal bAutoColumnWidth As Boolean = False)
        If cColor2 = Nothing Then cColor2 = Color.White
        Try
            For j As Integer = 0 To objMyGrid.Columns.Count - 1
                objMyGrid.Splits(0).DisplayColumns(j).HeadingStyle.WrapText = bWrapText
                objMyGrid.Splits(0).DisplayColumns(j).HeadingStyle.Font = objFont
                objMyGrid.Splits(0).DisplayColumns(j).HeadingStyle.BackColor = cColor
                objMyGrid.Splits(0).DisplayColumns(j).HeadingStyle.BackColor2 = cColor2
                If bAutoColumnWidth Then objMyGrid.Splits(0).DisplayColumns(j).AutoSize()
                If CaptionHeight > 0 Then objMyGrid.Splits(0).ColumnCaptionHeight = CaptionHeight
                If FooterHeight > 0 Then objMyGrid.Splits(0).ColumnFooterHeight = FooterHeight

            Next j
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "FormatMyGridCaption Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - FormatMyGridCaption: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
        End Try
    End Sub
    Friend Function FormatMyGridFont(ByVal objMyGrid As AviatCom_DefaultGrid, ByVal objCaptionFont As Font, ByVal objColumnFont As Font, _
                                    Optional ByVal iCaptionHeight As Integer = 40, Optional ByVal iRowHeight As Integer = 20, _
                                    Optional ByVal objFooterColumnFont As Font = Nothing, Optional ByVal iFooterHeight As Integer = 20) As AviatCom_DefaultGrid
        Try

            For j As Integer = 0 To objMyGrid.Columns.Count - 1
                objMyGrid.Splits(0).DisplayColumns(j).HeadingStyle.Font = objCaptionFont
                If Not objFooterColumnFont Is Nothing Then
                    objMyGrid.Splits(0).DisplayColumns(j).FooterStyle.Font = objFooterColumnFont
                End If
            Next
            objMyGrid.Splits(0).Style.Font = objColumnFont
            objMyGrid.RowHeight = iRowHeight
            objMyGrid.Splits(0).ColumnCaptionHeight = iCaptionHeight
            If Not objFooterColumnFont Is Nothing Then
                objMyGrid.Splits(0).ColumnFooterHeight = iFooterHeight
            End If
            objMyGrid.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            objMyGrid.Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            objMyGrid.CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            objMyGrid.CaptionStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom


            Return objMyGrid
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "FormatMyGridFont Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "FormatMyGridFont Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - FormatMyGridFont: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
            Return objMyGrid
        End Try
    End Function

    Friend Sub MyGridCopySelectRows(ByVal objMyGrid As AviatCom_DefaultGrid, Optional ByVal bDisplayMSG As Boolean = False)

        Try

            Dim strTemp As New System.Text.StringBuilder   'string to be copied to the clipboard
            For j As Integer = 0 To objMyGrid.Columns.Count - 1
                strTemp.Append(objMyGrid.Columns(j).Caption & vbTab)
            Next
            strTemp.Append(vbCrLf)
            For Each drow As Integer In objMyGrid.SelectedRows
                For j As Integer = 0 To objMyGrid.Columns.Count - 1
                    strTemp.Append(objMyGrid.Item(drow, j).ToString & vbTab)
                Next
                strTemp.Append(vbCrLf)
            Next
            System.Windows.Forms.Clipboard.SetDataObject(strTemp.ToString, False)
            If bDisplayMSG Then MessageBox.Show("Selected row(s) copied into clipboard", "Successful Copy Selected Row(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "MyGridCopySelectRows Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '     LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '           msModuleName & Chr(13) & " objMyGridCopySelectRows: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "objMyGridCopySelectRows Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Friend Function GetActiveOpenedForm(ByVal objForm As Form, Optional ByVal SetActive As Boolean = True) As Form

        Try

            Dim frm As Form
            For Each frm In My.Application.OpenForms
                If frm Is objForm Then
                    If SetActive Then frm.Activate()
                    Return frm
                End If
            Next
            Return Nothing
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetActiveOpenedForm Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - ActiveOpenedForm: " & vbNewLine & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show("ActiveOpenedForm" & vbNewLine & exp.Message, "ActiveOpenedForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Friend Function IsActiveOpenedForm(ByVal objForm As Form, Optional ByVal SetActive As Boolean = True, Optional ByVal SetShowDialog As Boolean = False) As Boolean
        Dim bResulte As Boolean = False
        Try

            Dim frm As Form
            For Each frm In My.Application.OpenForms
                If frm.Name Is objForm.Name Then
                    If SetActive Then
                        frm.Activate()
                    End If
                    If SetShowDialog Then
                        frm.ShowDialog()
                    Else
                        frm.Show()
                    End If
                    If frm.WindowState = FormWindowState.Minimized Then frm.WindowState = FormWindowState.Normal
                    bResulte = True
                End If
            Next
            Return bResulte
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "IsActiveOpenedForm Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            DWL_Lib.DWL_Lib.LogToSystemEvent(gsApplicationClientID, msModuleName, _
            '            gsApplicationClientID & " Global_Share - ActiveOpenedForm: " & vbNewLine & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error")
            'If gbDebug_PDA_MSG Then MessageBox.Show("ActiveOpenedForm" & vbNewLine & exp.Message, "ActiveOpenedForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResulte
        End Try
    End Function
   
    
    Friend Sub AddItemCodeForProduct(ByVal sCustomerID As String, ByVal sProductID As String, ByVal sItemCode As String)
        Dim bProcess As Boolean = True
        Try
            Using dTable_CustomerPrice As DataTable = SQL_QueryGetTableResult("SELECT ID,CustomerID,ProductID,ItemCode,Price FROM tb_CustomerProductPrice WITH (NOLOCK) WHERE CustomerID = '" & sCustomerID.Replace("'", "''") & "' AND ProductID = '" & sProductID.Replace("'", "''") & "'")
                If Not dTable_CustomerPrice Is Nothing Then
                    If dTable_CustomerPrice.Rows.Count > 0 Then
                        If dTable_CustomerPrice.Rows(0).Item("ItemCode").ToString.Trim = "" Then
                            If Not SQL_ExecuteSP("UPDATE tb_CustomerProductPrice SET  ItemCode = '" & sItemCode.Replace("'", "''") & "' WHERE ID = " & dTable_CustomerPrice.Rows(0).Item("ID")) Then
                                MessageBox.Show("Unable to update ItemCode!!" & vbNewLine & vbNewLine & "Please check network connection and try again", "Unable To Update ItemCode", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                bProcess = False
                            End If
                        ElseIf dTable_CustomerPrice.Rows(0).Item("ItemCode").ToString.Trim <> sItemCode.Trim Then
                            If MessageBox.Show("This customer already have the ItemCode for this product." & vbNewLine & "Do you wants to replace the ItemCode for this customer?" & vbNewLine & vbNewLine & "Current ItemCode" & dTable_CustomerPrice.Rows(0).Item("ID").ToString & vbNewLine & vbNewLine & "New entered ItemCode: " & sItemCode, "Confirm Replace ItemCode", MessageBoxButtons.OK, MessageBoxIcon.Question) = DialogResult.Yes Then
                                If Not SQL_ExecuteSP("UPDATE tb_CustomerProductPrice SET ItemCode = '" & sItemCode.Replace("'", "''") & "' WHERE ID = " & dTable_CustomerPrice.Rows(0).Item("ID")) Then
                                    MessageBox.Show("Unable to update ItemCode!!" & vbNewLine & vbNewLine & "Please check network connection and try again", "Unable To Update ItemCode", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    bProcess = False
                                End If
                            Else
                                MessageBox.Show("Process add ItemCode cancelled.", "Process Add ItemCode Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                bProcess = False
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End Using

            Using dTable_Product As DataTable = SQL_QueryGetTableResult("SELECT ID,ProductID,ItemCode FROM tb_Product WITH (NOLOCK) WHERE ProductID = '" & sProductID.Replace("'", "''") & "'")
                If Not dTable_Product Is Nothing Then
                    If dTable_Product.Rows.Count > 0 Then
                        If dTable_Product.Rows(0).Item("ItemCode").ToString.Trim = "" Then
                            If Not SQL_ExecuteSP("UPDATE tb_Product SET ItemCode = '" & sItemCode.Replace("'", "''") & "' WHERE ID = " & dTable_Product.Rows(0).Item("ID")) Then
                                MessageBox.Show("Unable to update ItemCode!!" & vbNewLine & vbNewLine & "Please check network connection and try again", "Unable To Update ItemCode", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                bProcess = False
                            End If
                        ElseIf dTable_Product.Rows(0).Item("ItemCode").ToString.Trim <> sItemCode.Trim Then
                            If MessageBox.Show("The product already have the ItemCode." & vbNewLine & "Do you wants to replace the ItemCode for this product?" & vbNewLine & vbNewLine & "Current ItemCode" & dTable_Product.Rows(0).Item("ID").ToString & vbNewLine & vbNewLine & "New entered ItemCode: " & sItemCode, "Confirm Replace ItemCode", MessageBoxButtons.OK, MessageBoxIcon.Question) = DialogResult.Yes Then
                                If Not SQL_ExecuteSP("UPDATE tb_Product  SET ItemCode = '" & sItemCode.Replace("'", "''") & "' WHERE ID = " & dTable_Product.Rows(0).Item("ID")) Then
                                    MessageBox.Show("Unable to update ItemCode!!" & vbNewLine & vbNewLine & "Please check network connection and try again", "Unable To Update ItemCode", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    bProcess = False
                                End If
                            Else
                                MessageBox.Show("Process add ItemCode to Product canncelled.", "Process Add ItemCode To Product Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                bProcess = False
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End Using

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "AddItemCodeForProduct Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "AddItemCodeForProduct Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub
    Friend Function GetProductByItemCode(ByVal sItemCode As String, Optional ByVal sCustomerID As String = "") As String
        Try
            If sCustomerID <> "" Then
                Using dTable_CustomerProductPrice As DataTable = SQL_QueryGetTableResult("SELECT ID,ProductID,ItemCode FROM tb_CustomerProductPrice WITH (NOLOCK) WHERE CustomerID = '" & sCustomerID.Replace("'", "''") & "' AND ItemCode = '" & sItemCode.Replace("'", "''") & "'")
                    If Not dTable_CustomerProductPrice Is Nothing Then
                        If dTable_CustomerProductPrice.Rows.Count > 0 Then
                            Return dTable_CustomerProductPrice.Rows(0).Item("ProductID").ToString
                        End If
                    End If
                End Using
            End If

            Using dTable_Product As DataTable = SQL_QueryGetTableResult("SELECT ID,ProductID,ItemCode FROM tb_Product WITH (NOLOCK) WHERE ItemCode = '" & sItemCode.Replace("'", "''") & "'")
                If Not dTable_Product Is Nothing Then
                    If dTable_Product.Rows.Count > 0 Then
                        If dTable_Product.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate ItemCode found in Product!!" & vbNewLine & vbNewLine & "Please correct ItemCode in product profile!!" & vbNewLine & vbNewLine & "Get product by ItemCode Cancelled", "Duplicate ItemCode Found In Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return ""
                        Else
                            Return dTable_Product.Rows(0).Item("ProductID").ToString
                        End If

                    End If
                End If
            End Using
            Return ""
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetProductByItemCode Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "GetProductByItemCode Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return ""
        End Try
    End Function
    Friend Function FormatDateToNULL(ByVal dDate As DateTime, Optional ByVal dOlderestDate As Date = #1/1/1910#) As String
        Try
            If dDate.Date >= dOlderestDate Then
                Return "'" & dDate & "'"
            Else
                Return "NULL"
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "FormatDateToNULL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msModuleName & ".log", "FormatDateToNULL Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return ""
        End Try
    End Function
#End Region
    'Depending on what operating system you are using determines the
    'correct function declares and variables. This is an example of
    'conditional compilation.

#If Win32 Then
 Declare Function FlashWindow Lib "user32" ( _
                     ByVal hwnd As Long, _
                     ByVal bInvert As Long) As Long

    Declare Function GetCaretBlinkTime Lib "user32" () As Long

    Dim Success As Long

#Else

    Friend Declare Function FlashWindow Lib "User32" ( _
                     ByVal hwnd As Integer, _
                     ByVal bInvert As Integer) As Integer

    Friend Declare Function GetCaretBlinkTime Lib "User" () As Integer

    Friend Success As Integer

#End If

End Module
