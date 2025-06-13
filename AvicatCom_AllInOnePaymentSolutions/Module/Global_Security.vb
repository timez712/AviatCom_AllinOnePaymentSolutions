Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module Global_Security
    Friend gsActivationConnection As String = ""
    Friend gbOnlineOrderOnly As Boolean = False
    Private msModuleName As String = "Global_Security_Phoenix"


    Friend Structure StrEmployeeInformation
        Friend Shared EmployeeName As String
        Friend Shared EmployeeID As String
        Friend Shared EmployeeRole As String
        Friend Shared EmployeeDepartment As String
        Friend Shared ComputerName As String
        Friend Shared UserName As String
        Friend Shared Password As String
        Friend Shared Location As String
        Friend Shared QuickAccess As Boolean
        Friend Shared tbAccessCodes As DataTable
        Friend Shared tbAccessRights As DataTable
        Friend Shared tbUserlogin As DataTable
        Friend Shared tbApplicationUserRole As DataTable
        Friend Shared lisSales As List(Of cls_Sales)
        Friend Shared POS_PrinterName As String = "MyPOSPrinter1"
        Friend Shared POS_Printer_NotAvailable As Boolean = False
        Friend Shared DisplayPoleComPortName As String = "COM1"
    End Structure

    Friend Class cls_Sales
        Property SalesID As String
        Property SalesName As String
        Property SalesUserName As String
        Property SalesUserNameAndID As String
    End Class
    Friend Function LogIn(ByVal sUserName As String, ByVal sPassword As String) As Boolean
        Dim bResult As Boolean = False
        Dim tempStartupForm As New Form
        Try
            'If sUserName = "tester" And sPassword = "testing123" Then
            '    Return True

            'Else
            '    Return False
            'End If
            'Exit Function
            If gbOnlineOrderOnly Then
                If sUserName = "john" And sPassword = "john" Then
                    For j As Integer = 0 To gfrmMDI.MenuStrip.Items.Count - 2
                        gfrmMDI.MenuStrip.Items(j).Enabled = False
                    Next
                    Return True
                Else
                    MessageBox.Show("Incorrect password entered!", "Incorrect Password Entered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Application.Exit()
                End If
            Else
                Dim drow() As DataRow = StrEmployeeInformation.tbUserlogin.Select("UserName = '" & sUserName & "' AND Password = '" & EncryptText(sPassword) & "'")
                If drow Is Nothing Then
                    Return False
                    Exit Function
                End If
                If drow.Count > 0 Then
                    StrEmployeeInformation.EmployeeID = drow(0).Item("EmployeeID").ToString
                    StrEmployeeInformation.EmployeeName = drow(0).Item("FirstName").ToString & " " & drow(0).Item("LastName").ToString
                    StrEmployeeInformation.EmployeeRole = drow(0).Item("Role").ToString
                    StrEmployeeInformation.UserName = drow(0).Item("UserName").ToString
                    StrEmployeeInformation.Password = drow(0).Item("Password").ToString
                    StrEmployeeInformation.Location = drow(0).Item("Location").ToString
                    StrEmployeeInformation.tbAccessRights = New DataTable
                    StrEmployeeInformation.tbAccessRights = GetUserSecurityAccessRight(StrEmployeeInformation.EmployeeID, StrEmployeeInformation.EmployeeRole)

                    StrEmployeeInformation.tbAccessCodes = New DataTable
                    StrEmployeeInformation.tbAccessCodes = GetSecurityAccessCodes()

                    StrEmployeeInformation.tbApplicationUserRole = New DataTable
                    StrEmployeeInformation.tbApplicationUserRole = GetApplicationRole()

                    If Not SetSystemParameter() Then
                        MessageBox.Show("Application setup error.  Please contact Vendor to resolve this issue", "Application Setup Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                        'Application.Exit()
                        bResult = False
                    End If
                    'If Not VertifyWorksstation() Then
                    '    MessageBox.Show("Application license cannot be vertify." & vbNewLine & vbNewLine & "Please contact vendor to resolve this issue!", "Application License Issue", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                    '    'Application.Exit()
                    '    bResult = False
                    'Else
                    '    bResult = True
                    'End If
                    bResult = True
                    ActionLog(msModuleName, StrEmployeeInformation.EmployeeID, "User Login", "", "", "EmployeeName: " & StrEmployeeInformation.EmployeeName & "; Computer: " & StrEmployeeInformation.ComputerName & "; EmpolyeeRole: " & StrEmployeeInformation.EmployeeRole, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                Else
                    MessageBox.Show("Incorrect UserName or Password entered", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                    Exit Function
                End If

                If bResult Then
                    SetupMDIDisplay(tempStartupForm)
                    'CloseAllMDIChildForms(gfrmMDI)
                    tempStartupForm.MdiParent = gfrmMDI
                    tempStartupForm.Show()
                    tempStartupForm.BringToFront()

                    Dim frm As New frm_CustomerService_TaskQueue
                    frm.Show()
                    frm.BringToFront()

                End If
            End If


            Return bResult
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "LogIn Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "LogIn Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResult
        End Try
    End Function
    Friend Function LogOut() As Boolean
        Try
            Login_Clear()
            Return True
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "LogOut Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "LogOut Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Friend Function LogIn_TempAccess(ByVal sUserName As String, ByVal sPassword As String, ByVal sFormName As String) As Boolean
        Dim bResult As Boolean = False
        Try
            Dim sSqlStr As String = "SELECT * FROM TbEmployee WHERE FirstName = '" & sUserName & "' AND UPswd = '" & sPassword & "'"
            Dim objDataTable As DataTable = gobjADO.ExecuteSQLQuery(sSqlStr, gsConnectionString)
            If objDataTable Is Nothing Then
                MessageBox.Show("Empty user returned. " & vbNewLine & "Please restart your program and try again." & vbNewLine & "Contact IT Department if problem remain.", "Log-In Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf objDataTable.Rows.Count = 0 Then
                MessageBox.Show("Invaid UserName or Password had entered!", "Temporary Access Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                bResult = True
            End If
            Return bResult
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "LogIn_TempAccess Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "LogIn_TempAccess Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResult
        End Try
    End Function

    Friend Function GetUserSecurityAccessRight(ByVal iEmployeeID As Integer, ByVal sRole As String) As DataTable
        Try
            Dim sSQLStr As String = " SELECT AccessCode,AccessCodeDesc,Remark " &
                                    " FROM tb_Security_AccessCode WITH (NOLOCK) " &
                                    " WHERE (AccessCode IN ( " &
                                    " SELECT  AccessCode " &
                                    " FROM tb_Security_RoleAccessCode WITH (NOLOCK) " &
                                    " WHERE Role = '" & sRole & "') " &
                                    " OR AccessCode IN ( " &
                                    " SELECT  AccessCode " &
                                    " FROM tb_Security_EmployeeAccessCode WITH (NOLOCK) " &
                                    " WHERE isGrant <> 0 AND EmployeeID = " & iEmployeeID & ")) " &
                                    " AND AccessCode NOT IN ( " &
                                    " SELECT AccessCode " &
                                    " FROM tb_Security_EmployeeAccessCode WITH (NOLOCK) " &
                                    " WHERE isGrant = 0 AND EmployeeID = " & iEmployeeID & ")"

            Return SQL_QueryGetTableResult(sSQLStr)

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetUserSecurity Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetUserSecurity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Friend Function CheckAccessRight(ByVal sAppPermName As String) As Boolean
        Try
            Dim dRow As DataRow() = StrEmployeeInformation.tbAccessRights.Select("AccessCode = '" & sAppPermName & "'")
            If dRow Is Nothing Then Return False
            If dRow.Count <= 0 Then Return False
            Return True
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "CheckAccessRight Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "CheckAccessRight Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Friend Function GetSecurityAccessCodes() As DataTable
        Try
            Dim sSQLStr As String = " SELECT AccessCode,AccessCodeDesc,Remark FROM tb_Security_AccessCode WITH (NOLOCK) "

            Return SQL_QueryGetTableResult(sSQLStr)

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetSecurityAccessCodes Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetUserSecurity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Friend Function GetApplicationRole() As DataTable
        Try
            Dim sSQLStr As String = " SELECT Role FROM tb_Security_Role WITH (NOLOCK) ORDER BY Role"

            Return SQL_QueryGetTableResult(sSQLStr)

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetSecurityAccessCodes Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetUserSecurity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Friend Function GetSecurityUserLogin() As DataTable
        Try
            Dim sSQLStr As String = " SELECT * FROM tb_Security_Employee WITH (NOLOCK) WHERE isEnabled <> 0 "
            'Dim sSQLStr As String = " SELECT ID,EmployeeID,UserName,Password,Role " &
            '                        " ,isEnabled,FirstName,LastName,HomePhone,CellPhone " &
            '                        " ,Email,Address,City,State,Zip,Location " &
            '                        " FROM tb_Security_Employee WITH (NOLOCK) "
            Return SQL_QueryGetTableResult(sSQLStr)
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetSecurityAccessCodes Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetUserSecurity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Friend Sub GetSalesAndDriverList()
        Try
            'If Not StrEmployeeInformation.tbUserlogin Is Nothing Then
            '    If StrEmployeeInformation.tbUserlogin.Rows.Count > 0 Then
            '        StrEmployeeInformation.lisDriver = Nothing
            '        StrEmployeeInformation.lisSales = Nothing
            '        StrEmployeeInformation.lisDriver = New List(Of cls_Drivers)
            '        StrEmployeeInformation.lisSales = New List(Of cls_Sales)
            '        StrEmployeeInformation.lisDriver.Add(New cls_Drivers With {.DriverID = "", .DriverName = "", .DriverUserName = "", .DriverUserNameAndID = ""})
            '        StrEmployeeInformation.lisSales.Add(New cls_Sales With {.SalesID = "", .SalesName = "", .SalesUserName = "", .SalesUserNameAndID = ""})
            '        For j As Integer = 0 To StrEmployeeInformation.tbUserlogin.Rows.Count - 1
            '            If StrEmployeeInformation.tbUserlogin.Rows(j).Item("isSales") Then
            '                StrEmployeeInformation.lisSales.Add(New cls_Sales With {.SalesID = StrEmployeeInformation.tbUserlogin.Rows(j).Item("EmployeeID"), .SalesName = StrEmployeeInformation.tbUserlogin.Rows(j).Item("FirstName") & " " & StrEmployeeInformation.tbUserlogin.Rows(j).Item("LastName"), .SalesUserName = StrEmployeeInformation.tbUserlogin.Rows(j).Item("UserName"), .SalesUserNameAndID = StrEmployeeInformation.tbUserlogin.Rows(j).Item("UserName") & " -- " & StrEmployeeInformation.tbUserlogin.Rows(j).Item("EmployeeID")})
            '            End If
            '            If StrEmployeeInformation.tbUserlogin.Rows(j).Item("isDriver") Then
            '                StrEmployeeInformation.lisDriver.Add(New cls_Drivers With {.DriverID = StrEmployeeInformation.tbUserlogin.Rows(j).Item("EmployeeID"), .DriverName = StrEmployeeInformation.tbUserlogin.Rows(j).Item("FirstName") & " " & StrEmployeeInformation.tbUserlogin.Rows(j).Item("LastName"), .DriverUserName = StrEmployeeInformation.tbUserlogin.Rows(j).Item("UserName"), .DriverUserNameAndID = StrEmployeeInformation.tbUserlogin.Rows(j).Item("UserName") & " -- " & StrEmployeeInformation.tbUserlogin.Rows(j).Item("EmployeeID")})
            '            End If
            '        Next
            '    End If
            'End If

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetSalesAndDriverList Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetSalesAndDriverList Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Friend Function CheckAccessCodeExists(ByVal sAppPermName As String) As Boolean
        Try
            If Not StrEmployeeInformation.tbAccessCodes Is Nothing Then
                If Val(StrEmployeeInformation.tbAccessCodes.Compute("Count([AccessCode])", "AccessCode = '" & sAppPermName & "'")) > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "CheckAccessCodeExists Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "CheckAccessCodeExists Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Add access code when not exists
    ''' </summary>
    ''' <param name="sAppPermName">AccessCode Name ( e.g Net:Administrator, use ":" to seperate between layers )</param>
    ''' <param name="sAppPermDescription">Addcess code Desc for ref only</param>
    ''' <param name="sRemarks"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Add_NewAccessCode(ByVal sAppPermName As String, ByVal sAppPermDescription As String, Optional ByVal sRemarks As String = "") As Boolean
        Try
            If Not CheckAccessCodeExists(sAppPermName) Then
                SQL_ExecuteSP(" INSERT INTO tb_Security_AccessCode (  AccessCode,AccessCodeDesc,Remark) VALUES ('" & sAppPermName & "','" & sAppPermDescription & "','" & sRemarks & "')")
                StrEmployeeInformation.tbAccessCodes = New DataTable
                StrEmployeeInformation.tbAccessCodes = GetSecurityAccessCodes()
                Return False
            Else
                Return True
            End If

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "Add_NewAccessCode Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "Add_NewAccessCode Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub SetupMDIDisplay(ByRef frm As Form)
        Try

            'frm = New frm_Security_EmployeeInformation
           
            If CheckAccessRight("NET:CustomerInformation") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:CompanyMic") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:EmployeeInformation") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:OrderHistory") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:Product") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:Purchase") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:Security") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:NET:Wholesale") Then
                If frm.Name = "" Then frm = New frmGeneral
            End If
            If CheckAccessRight("NET:Order:Retail") Then
                'If frm.Name = "" Then frm = New frm_OrderInput_Retail
            End If
                'frm = New frm_Transaction_Information
                'If CheckAccessRight("Net:Administrator") Then
                '    gfrmMDI.mnu_Warehouse_Root.Visible = True
                '    gfrmMDI.mnu_Purchasing_Root.Visible = True
                '    gfrmMDI.mnu_Purchasing_Root.Visible = True
                '    gfrmMDI.mnu_Accounting_Root.Visible = True
                '    gfrmMDI.mnu_Shipping_Root.Visible = True
                '    gfrmMDI.mnu_CustomerService_Root.Visible = True
                '    gfrmMDI.mnu_Marketing_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_Administrator
                'End If
                'If CheckAccessRight("Net:IT") Then
                '    If frm.Name = "" Then frm = New frm_Main_InformationTechnology
                'End If
                'If CheckAccessRight("Net:Management") Then
                '    gfrmMDI.mnu_Warehouse_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_Management
                'End If
                'If CheckAccessRight("Net:Accounting") Then
                '    gfrmMDI.mnu_Accounting_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_AccountingDepartment
                'End If
                'If CheckAccessRight("Net:Purchasing") Then
                '    gfrmMDI.mnu_Purchasing_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_PurchesingDepartment
                'End If
                'If CheckAccessRight("Net:Marketing") Then
                '    gfrmMDI.mnu_Marketing_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Marketing_ImageNameChange
                'End If
                'If CheckAccessRight("Net:CustomerService") Then
                '    gfrmMDI.mnu_CustomerService_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_CustomerServiceDepartment
                'End If
                'If CheckAccessRight("Net:Sale") Then
                '    gfrmMDI.mnu_Purchasing_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_SalesDepartment
                'End If
                'If CheckAccessRight("Net:Shipping") Then
                '    gfrmMDI.mnu_Shipping_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_ShippingDepartment
                'End If
                'If CheckAccessRight("Net:Warehouse") Then
                '    gfrmMDI.mnu_Warehouse_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_WarehouseDepartment
                'End If
                'If CheckAccessRight("Net:EDIWeb") Then
                '    gfrmMDI.mnu_Warehouse_Root.Visible = True
                '    If frm.Name = "" Then frm = New frm_Main_EDI
                'End If
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "SetupMDIDisplay Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SetupMDIDisplay Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Friend Sub Login_Clear()
        Try
            StrEmployeeInformation.ComputerName = GetPCName()
            StrEmployeeInformation.Location = ""
            'StrEmployeeInformation.WHNo = objDataTable.Rows(0).Item("ComCode").ToString
            StrEmployeeInformation.EmployeeID = ""
            StrEmployeeInformation.EmployeeName = ""
            StrEmployeeInformation.EmployeeRole = ""
            StrEmployeeInformation.UserName = ""
            StrEmployeeInformation.Password = ""
            StrEmployeeInformation.EmployeeDepartment = ""
            StrEmployeeInformation.tbAccessRights = Nothing
            StrEmployeeInformation.QuickAccess = False
            StrEmployeeInformation.tbAccessCodes = Nothing

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "Login_Clear Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "Login_Clear Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            LogToFile(msModuleName & ".log", "VerifyExpirDate Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "VerifyExpirDate Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
    Friend Function SystemGetMotherboardSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object = _
            wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers = _
            serial_numbers.Substring(2)

        Return serial_numbers
    End Function

    Friend Function SystemGetCpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
            "{impersonationLevel=impersonate}!\\" & _
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " & _
            "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = _
            cpu_ids.Substring(2)

        Return cpu_ids
    End Function
    Friend Function SystemApplicationLarnched() As Boolean
        Try
            Dim iCount As Integer = 0
            For Each clsProcess As Process In Process.GetProcesses()
                If clsProcess.ProcessName.StartsWith(Application.ProductName) Then
                    iCount = iCount + 1
                    If iCount > 1 Then
                        Return True
                        MsgBox("FOUND")
                        Exit For
                    End If
                End If
            Next
            Return False
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "SystemApplicationLarnched Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SystemApplicationLarnched Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Friend Function VertifyWorksstation()
        Dim bResult As Boolean = False
        Try
            Dim dRow() As DataRow = strSystemConfig.tb_SystemWorkstationConfig.Select("Mic_1 = '" & EncryptText(strSystemConfig.CPUID) & "' AND Mic_2 = '" & EncryptText(strSystemConfig.MotherBoardID) & "' ")
            If dRow Is Nothing Then
                'MessageBox.Show("No License found for your application", "License Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                frm_Security_ProductKey.ShowDialog()
            ElseIf dRow.Count >= 1 Then
                bResult = True
            ElseIf dRow.Count <= 0 Then
                'MessageBox.Show("No License found for your application", "License Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                frm_Security_ProductKey.ShowDialog()
            End If
            ' frm_Security_ProductKey.ShowDialog()
            If Not bResult And Not strSystemConfig.isNewLicense Then
                bResult = False
            Else
                bResult = True
            End If
            If dRow.Length > 0 Then
                StrEmployeeInformation.DisplayPoleComPortName = dRow(0).Item("POS_DisplayPoleComPortName").ToString
                StrEmployeeInformation.POS_PrinterName = dRow(0).Item("POS_Printer").ToString
                StrEmployeeInformation.POS_Printer_NotAvailable = dRow(0).Item("POS_PrinterNoPrinter")
            End If

            Return bResult
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "VertifyWorksstation Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "VertifyWorksstation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResult
        End Try
    End Function
    Friend Function SetSystemParameter() As Boolean
        Dim bResult As Boolean = False
        Try

            Dim dTable As DataTable = SQL_QueryGetTableResult(" SELECT ID,CompanyName,Location,Address,Address_2 " &
                                                              " ,City,State,ZipCode,Phone,Fax " &
                                                              " ,StoreManager,SaleTax,Mic1,Mic2,Mic3 " &
                                                              " ,Mic4,Mic5,Mic6 " &
                                                              " FROM tb_SystemConfig WITH (NOLOCK) WHERE Location = '" & StrEmployeeInformation.Location & "'")

            If dTable Is Nothing Then
                MessageBox.Show("User Location Not Found" & vbNewLine & vbNewLine & "Please contact your vendor to resolve this issue!", "User Location Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                'frm_Security_ProductKey.ShowDialog()
            ElseIf dTable.Rows.Count <= 0 Then
                MessageBox.Show("User Location Not Found" & vbNewLine & vbNewLine & "Please contact your vendor to resolve this issue!", "User Location Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                'MessageBox.Show("No License found for your application", "License Not Found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
                'frm_Security_ProductKey.ShowDialog()
            Else
                strSystemConfig.CompanyName = dTable.Rows(0).Item("CompanyName").ToString
                strSystemConfig.Location = dTable.Rows(0).Item("Location").ToString
                strSystemConfig.Address = dTable.Rows(0).Item("Address").ToString
                strSystemConfig.Address_2 = dTable.Rows(0).Item("Address_2").ToString
                strSystemConfig.City = dTable.Rows(0).Item("City").ToString
                strSystemConfig.State = dTable.Rows(0).Item("State").ToString
                strSystemConfig.ZipCode = dTable.Rows(0).Item("ZipCode").ToString
                strSystemConfig.Phone = dTable.Rows(0).Item("Phone").ToString

                strSystemConfig.Fax = dTable.Rows(0).Item("Fax").ToString
                strSystemConfig.StoreManager = dTable.Rows(0).Item("StoreManager").ToString
                strSystemConfig.SaleTax = dTable.Rows(0).Item("SaleTax").ToString
               
                strSystemConfig.Mic1 = dTable.Rows(0).Item("Mic1").ToString ' Application Warning Date
                strSystemConfig.Mic2 = dTable.Rows(0).Item("Mic2").ToString   ' Application Expired Date
                strSystemConfig.Mic3 = dTable.Rows(0).Item("Mic3").ToString   'Total License #
                strSystemConfig.Mic4 = dTable.Rows(0).Item("Mic4").ToString   ' Unknown
                strSystemConfig.Mic5 = dTable.Rows(0).Item("Mic5").ToString   ' Activation Connection
                strSystemConfig.Mic6 = dTable.Rows(0).Item("Mic6").ToString   ' Installation Date
                If Not dTable.Rows(0).Item("Mic1").ToString = "" Then
                    strSystemConfig.WarningDate = DateTime.Parse(DecryptText(dTable.Rows(0).Item("Mic1").ToString))
                Else
                    strSystemConfig.WarningDate = "1900-1-1"
                End If
                If Not dTable.Rows(0).Item("Mic1").ToString = "" Then
                    strSystemConfig.ExpiredDate = DateTime.Parse(DecryptText(dTable.Rows(0).Item("Mic2").ToString))
                Else
                    strSystemConfig.ExpiredDate = "1900-1-1"
                End If

                'strSystemConfig.ExpiredDate = DateTime.Parse(DecryptText(dTable.Rows(0).Item("Mic2").ToString))

                strSystemConfig.WorkstationName = GetPCName()
                strSystemConfig.CPUID = SystemGetCpuId()
                strSystemConfig.MotherBoardID = SystemGetMotherboardSerialNumber()
                strSystemConfig.HardDriveID = "Today: " & Now

                VerifyExpirDate("12/15/2025", "1/20/2027")
            bResult = True
            End If
            Return bResult
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "SetSystemParameter Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "SetSystemParameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bResult
        End Try
    End Function
    Friend Sub RegisterNewLicense(ByVal sCPUID As String, ByVal sMotherBoard As String)
        Try
            SQL_ExecuteSP(" INSERT INTO tb_SystemWorkstationConfig (WorkstationName ,Mic_1,Mic_2,Mic_3,LastEmployeeID) VALUES ('" & strSystemConfig.WorkstationName & "','" & sCPUID & "','" & sMotherBoard & "','" & EncryptText("NoHarddriveID: " & Now.ToString) & "',0)")

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "RegisterNewLicense Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            If gbDebugDisplayMSG Then MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "RegisterNewLicense Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
