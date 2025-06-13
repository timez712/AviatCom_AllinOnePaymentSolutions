Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports AviatCom_Lib.AviatCom_Lib

Public Class frmOnline_Menu_Import
    Dim DB As New DBConnection_MySQL
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Dim marrCompanyDomainName() As String = Nothing
    Dim marrCompanyID() As String = Nothing
    Private Sub frmOnline_ExportMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar.Maximum = 100
        ProgressBar.Minimum = 0
        ProgressBar.Value = 0
    End Sub
    Private Sub SetButtonEnableDisable(ByVal bEnable As Boolean)
        btnClose.Enabled = bEnable
        btnImportMenu.Enabled = bEnable
        btnImportCompanyInfo.Enabled = bEnable
        btnImportSpeicalMenu.Enabled = bEnable
    End Sub

    Private Sub btnImportCompanyInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportCompanyInfo.Click
        Try
            lisProcessingLog.Items.Clear()
            OpenFile.Title = "Please Select a File"
            OpenFile.FileName = ""
            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            OpenFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not OpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If

            SetButtonEnableDisable(False)
            Cursor = Cursors.WaitCursor
            lisProcessingLog.Items.Insert(0, "Start Processing Company Information Data........")
            lblProcessStatus.Text = "Processing Import Company Info Data........"
            Dim sSelectedPath As String = OpenFile.FileName.ToString

            DB.CreateConnection(cboDatabase.Text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_UpdateRestaurant"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            Dim arrData() As String
            arrData = ReadFileToArray(sSelectedPath)
            ProgressBar.Maximum = arrData.Length + 1
            ProgressBar.Value = 0
            For j As Integer = 0 To arrData.Length - 1
                arrData(j) = arrData(j).Replace("'", "")
                arrData(j) = arrData(j).Replace("&", "")
                arrData(j) = arrData(j).Replace("\", "")
                arrData(j) = arrData(j).Replace("/", "")
                arrData(j) = arrData(j).Replace("?", "")
                Dim arr As Array = Split(arrData(j), "|")
                If Not arr.Length = 31 Then
                    MessageBox.Show("Input Data have incorrect length" & Chr(13) & "Data: <" & arrData(j) & ">" & Chr(13) & "Process cancel")
                    Exit Sub
                End If
                'IIf(ProgressBar.Value + PercentageCount > 99, ProgressBar.Value = 100, ProgressBar.Value = ProgressBar.Value + PercentageCount)
                ProgressBar.Value = ProgressBar.Value + 1

                lisProcessingLog.Items.Insert(0, "Company Name - " & arr(0) & "Address - " & arr(1) &
                                              arr(4) & arr(5) & arr(6))
                Application.DoEvents()
                cmd.Parameters.AddWithValue("sAction", "Add")
                cmd.Parameters.AddWithValue("sCompanyName", arr(0))
                cmd.Parameters.AddWithValue("sCompanyAddress_1", arr(1))
                cmd.Parameters.AddWithValue("sCompanyAddress_2", arr(2))
                cmd.Parameters.AddWithValue("sCompanyAPT", arr(3))
                cmd.Parameters.AddWithValue("sCompanyCity", arr(4))
                cmd.Parameters.AddWithValue("sCompanyState", arr(5))
                cmd.Parameters.AddWithValue("sCompanyZipCode", arr(6))
                cmd.Parameters.AddWithValue("sCompanyZipEx", arr(7))
                cmd.Parameters.AddWithValue("sAddressAdditionalInfo", arr(8))
                cmd.Parameters.AddWithValue("sCompanyPhone_1", arr(9))
                cmd.Parameters.AddWithValue("sCompanyPhone_2", arr(10))
                cmd.Parameters.AddWithValue("sCompanyFax", arr(11))
                cmd.Parameters.AddWithValue("sCompanyWebsite", arr(12))
                cmd.Parameters.AddWithValue("sCompanyEmail", arr(13))
                cmd.Parameters.AddWithValue("tsCreatedTimeStamp", Now())
                cmd.Parameters.AddWithValue("dtLastEditTimeStamp", Now())
                cmd.Parameters.AddWithValue("sCompanyDomainName", arr(14))
                cmd.Parameters.AddWithValue("sReceiveOrderNumber", arr(15))
                cmd.Parameters.AddWithValue("sCompanyTimeZone", arr(16))
                cmd.Parameters.AddWithValue("sCompanyOperation", arr(17))
                cmd.Parameters.AddWithValue("dCompanyDeliveryMin", arr(18))
                cmd.Parameters.AddWithValue("dCompanyDeliveryCharge", arr(19))
                cmd.Parameters.AddWithValue("sLunchSpecialTime", arr(20))
                cmd.Parameters.AddWithValue("sLatitude", arr(21))
                cmd.Parameters.AddWithValue("sLongitude", arr(22))
                cmd.Parameters.AddWithValue("sReceiveOrderType", arr(23))
                cmd.Parameters.AddWithValue("sHasLunchSpecial", arr(24))
                cmd.Parameters.AddWithValue("iMaxSpecialOption", arr(25))
                cmd.Parameters.AddWithValue("sStateTaxRate", arr(26))
                cmd.Parameters.AddWithValue("sIsDelivery", arr(27))
                cmd.Parameters.AddWithValue("sIsCreditCard", arr(28))
                cmd.Parameters.AddWithValue("sEstimateDeliveryTime", arr(29))
                cmd.Parameters.AddWithValue("sRemotePrint", arr(30))
                cmd.ExecuteNonQuery()
                'MessageBox.Show(arrData(j))

            Next

            MessageBox.Show("Data Added")
        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Import Company Infomation Completed!")
            ProgressBar.Value = 0
        End Try
    End Sub

    Private Sub btnImportMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportMenu.Click
        Try
            lisProcessingLog.Items.Clear()
            OpenFile.Title = "Please Select a File"
            OpenFile.FileName = ""
            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            OpenFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not OpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            SetButtonEnableDisable(False)
            lisProcessingLog.Items.Insert(0, "Start Processing Import Menu Data........")
            lblProcessStatus.Text = "Processing Import Menu Data........"
            Dim sSelectedPath As String = OpenFile.FileName

            DB.CreateConnection(cboDatabase.Text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_UpdateRestaurantMenu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            Dim arrData() As String
            arrData = ReadFileToArray(sSelectedPath)
            ProgressBar.Maximum = arrData.Length + 1
            ProgressBar.Value = 0
            'Dim PercentageCount As Double = Math.Abs(100 / Math.Abs(arrData.Length))
            'ProgressBar.Step = Math.Abs(100 / Math.Abs(arrData.Length))
            ProgressBar.Value = 1
            For j As Integer = 0 To arrData.Length - 1
                Try
                    arrData(j) = arrData(j).Replace("'", "")
                    arrData(j) = arrData(j).Replace("&", "")
                    'arrData(j) = arrData(j).Replace("\", "")
                    'arrData(j) = arrData(j).Replace("/", "")
                    arrData(j) = arrData(j).Replace("?", "")
                    Dim arr As Array = Split(arrData(j), "|")
                    If Not arr.Length = 17 Then
                        MessageBox.Show("Input Data have incorrect length" & Chr(13) & "Data: <" & arrData(j) & ">" & Chr(13) & "Process cancel")
                        Exit Sub
                    ElseIf arr(3).ToString = "" Then
                        MessageBox.Show("Process Stopped" & vbNewLine & vbNewLine & "One or more dish(es) without MenuID!!" & Chr(13) & "Data: <" & arrData(j) & ">" & Chr(13) & "Process cancel")
                        Exit Sub
                    ElseIf arr(4).ToString = "" Then
                        MessageBox.Show("Process Stopped" & vbNewLine & vbNewLine & "One or more dish(es) without Dish Name!!" & Chr(13) & "Data: <" & arrData(j) & ">" & Chr(13) & "Process cancel")
                        Exit Sub
                    End If
                    ProgressBar.Value = ProgressBar.Value + 1
                    lisProcessingLog.Items.Insert(0, arr(0) & " - " & arr(1) & "; Food Type - " & arr(2) &
                                                  "; Dish Name - " & arr(4))
                    Application.DoEvents()
                    txtMenuRecordCount.Text = "Uploaded < " & j & " OF " & arrData.Length & " >"

                    cmd.Parameters.AddWithValue("sAction", "Add")
                    cmd.Parameters.AddWithValue("sCompanyDomainName", arr(0))
                    cmd.Parameters.AddWithValue("sFoodtype", arr(1))
                    cmd.Parameters.AddWithValue("sDes", arr(2))
                    cmd.Parameters.AddWithValue("sMenuID", arr(3))
                    cmd.Parameters.AddWithValue("sDishName", arr(4))
                    cmd.Parameters.AddWithValue("sDishDes", arr(5))
                    cmd.Parameters.AddWithValue("sDishSize_1", arr(6))
                    cmd.Parameters.AddWithValue("diDishPrice_1", arr(7))
                    cmd.Parameters.AddWithValue("sDishSize_2", arr(8))
                    cmd.Parameters.AddWithValue("diDishPrice_2", arr(9))
                    cmd.Parameters.AddWithValue("sDishSize_3", arr(10))
                    cmd.Parameters.AddWithValue("diDishPrice_3", arr(11))
                    cmd.Parameters.AddWithValue("sDishSize_4", arr(12))
                    cmd.Parameters.AddWithValue("diDishPrice_4", arr(13))
                    cmd.Parameters.AddWithValue("iDishCalorie", arr(14))
                    cmd.Parameters.AddWithValue("sSpicy", arr(15))
                    cmd.Parameters.AddWithValue("sDisplayOrder", arr(16))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Catch exp As MySqlException
                    MessageBox.Show(exp.ToString)
                End Try

            Next
            MessageBox.Show("Restaurant Menu Added")
        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Importing Menu Completed!")
            ProgressBar.Value = 0
        End Try
    End Sub

    Private Sub btnImportSpeicalMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportSpeicalMenu.Click
        Try
            lisProcessingLog.Items.Clear()
            OpenFile.Title = "Please Select a File"
            OpenFile.FileName = ""
            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            OpenFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not OpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If
            SetButtonEnableDisable(False)
            Cursor = Cursors.WaitCursor
            lisProcessingLog.Items.Insert(0, "Start Processing Speical Menu Data........")
            lblProcessStatus.Text = "Processing Import Speical Menu Data........"
            Dim sSelectedPath As String = OpenFile.FileName

            DB.CreateConnection(cboDatabase.Text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_UpdateSpecialSideMenu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            Dim arrData() As String
            arrData = ReadFileToArray(sSelectedPath)
            ProgressBar.Maximum = arrData.Length + 1
            ProgressBar.Value = 0
            For j As Integer = 0 To arrData.Length - 1
                arrData(j) = arrData(j).Replace("'", "")
                arrData(j) = arrData(j).Replace("&", "")
                arrData(j) = arrData(j).Replace("\", "")
                arrData(j) = arrData(j).Replace("/", "")
                arrData(j) = arrData(j).Replace("?", "")
                Dim arr As Array = Split(arrData(j), "|")
                If arr.Length = 5 Then
                    MessageBox.Show("Input Data have incorrect length" & Chr(13) & "Data: <" & arrData(j) & ">" & Chr(13) & "Process cancel")
                    Exit Sub
                End If
                'IIf(ProgressBar.Value + PercentageCount > 99, ProgressBar.Value = 100, ProgressBar.Value = ProgressBar.Value + PercentageCount)
                ProgressBar.Value = ProgressBar.Value + 1
                lisProcessingLog.Items.Insert(0, "Company - " & arr(0) & "; Food Type - " & arr(4) &
                                              "; SideDish Name - " & arr(2))
                Application.DoEvents()

                cmd.Parameters.AddWithValue("sCompanyDomainName", arr(0))
                cmd.Parameters.AddWithValue("ssoID", arr(1))
                cmd.Parameters.AddWithValue("ssoDishName", arr(2))
                cmd.Parameters.AddWithValue("dsoPrice", arr(3))
                cmd.Parameters.AddWithValue("sFoodType", arr(4))
                cmd.Parameters.AddWithValue("iOptionID", arr(5))

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                'MessageBox.Show(arrData(j))

            Next

            ProgressBar.Value = 0
            MessageBox.Show("Speical Menu Added")


        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Import Speical Menu Completed!")
            ProgressBar.Value = 0
        End Try

    End Sub

    Private Sub lisProcessingLog_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lisProcessingLog.DoubleClick
        lisProcessingLog.Items.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Try
            lisProcessingLog.Items.Clear()

            Cursor = Cursors.WaitCursor
            SetButtonEnableDisable(False)
            Dim iCount As Integer = 10000
            ProgressBar.Step = Math.Abs(100 / Math.Abs(iCount))
            For i As Integer = 0 To iCount
                ProgressBar.PerformStep()
                Application.DoEvents()

                lisProcessingLog.Items.Insert(0, i & " of 10000")
            Next

        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            ProgressBar.Value = 0
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Import Speical Menu Completed!")
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub btnImportRestaurantCoupons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportRestaurantCoupons.Click
        Try
            lisProcessingLog.Items.Clear()
            OpenFile.Title = "Please Select Restaurant Coupons File"
            OpenFile.FileName = ""
            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            OpenFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not OpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If

            SetButtonEnableDisable(False)
            Cursor = Cursors.WaitCursor
            lisProcessingLog.Items.Insert(0, "Start Processing Restaurant Coupons ........")
            lblProcessStatus.Text = "Processing Import Restaurant Coupons ........"
            Dim sSelectedPath As String = OpenFile.FileName.ToString

            DB.CreateConnection(cboDatabase.Text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_UpdateRestaurant"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            Dim arrData() As String
            arrData = ReadFileToArray(sSelectedPath)
            ProgressBar.Maximum = arrData.Length + 1
            ProgressBar.Value = 0
            For j As Integer = 0 To arrData.Length - 1

                Dim arr As Array = Split(arrData(j), "|")
                If Not arr.Length = 31 Then
                    MessageBox.Show("Input Data have incorrect length" & Chr(13) & "Data: <" & arrData(j) & ">" & Chr(13) & "Process cancel")
                    Exit Sub
                End If
                'IIf(ProgressBar.Value + PercentageCount > 99, ProgressBar.Value = 100, ProgressBar.Value = ProgressBar.Value + PercentageCount)
                ProgressBar.Value = ProgressBar.Value + 1

                lisProcessingLog.Items.Insert(0, "Company Name - " & arr(0) & "Address - " & arr(1) &
                                              arr(4) & arr(5) & arr(6))
                Application.DoEvents()
                cmd.Parameters.AddWithValue("sAction", "Add")
                cmd.Parameters.AddWithValue("sCompanyName", arr(0))
                cmd.Parameters.AddWithValue("sCompanyAddress_1", arr(1))
                cmd.Parameters.AddWithValue("sCompanyAddress_2", arr(2))
                cmd.Parameters.AddWithValue("sCompanyAPT", arr(3))
                cmd.Parameters.AddWithValue("sCompanyCity", arr(4))
                cmd.Parameters.AddWithValue("sCompanyState", arr(5))
                cmd.Parameters.AddWithValue("sCompanyZipCode", arr(6))
                cmd.Parameters.AddWithValue("sCompanyZipEx", arr(7))
                cmd.Parameters.AddWithValue("sAddressAdditionalInfo", arr(8))
                cmd.Parameters.AddWithValue("sCompanyPhone_1", arr(9))
                cmd.Parameters.AddWithValue("sCompanyPhone_2", arr(10))
                cmd.Parameters.AddWithValue("sCompanyFax", arr(11))
                cmd.Parameters.AddWithValue("sCompanyWebsite", arr(12))
                cmd.Parameters.AddWithValue("sCompanyEmail", arr(13))
                cmd.Parameters.AddWithValue("tsCreatedTimeStamp", Now())
                cmd.Parameters.AddWithValue("dtLastEditTimeStamp", Now())
                cmd.Parameters.AddWithValue("sCompanyDomainName", arr(14))
                cmd.Parameters.AddWithValue("sReceiveOrderNumber", arr(15))
                cmd.Parameters.AddWithValue("sCompanyTimeZone", arr(16))
                cmd.Parameters.AddWithValue("sCompanyOperation", arr(17))
                cmd.Parameters.AddWithValue("dCompanyDeliveryMin", arr(18))
                cmd.Parameters.AddWithValue("dCompanyDeliveryCharge", arr(19))
                cmd.Parameters.AddWithValue("sLunchSpecialTime", arr(20))
                cmd.Parameters.AddWithValue("sLatitude", arr(21))
                cmd.Parameters.AddWithValue("sLongitude", arr(22))
                cmd.Parameters.AddWithValue("sReceiveOrderType", arr(23))
                cmd.Parameters.AddWithValue("sHasLunchSpecial", arr(24))
                cmd.Parameters.AddWithValue("iMaxSpecialOption", arr(25))
                cmd.Parameters.AddWithValue("sStateTaxRate", arr(26))
                cmd.Parameters.AddWithValue("sIsDelivery", arr(27))
                cmd.Parameters.AddWithValue("sIsCreditCard", arr(28))
                cmd.Parameters.AddWithValue("sEstimateDeliveryTime", arr(29))
                cmd.Parameters.AddWithValue("sRemotePrint", arr(30))
                cmd.ExecuteNonQuery()
                'MessageBox.Show(arrData(j))

            Next

            MessageBox.Show("Data Added")
        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Import Company Infomation Completed!")
            ProgressBar.Value = 0
        End Try
    End Sub

    Private Sub cboDatabase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDatabase.SelectedIndexChanged
        GetCompanies()
    End Sub
    Private Sub GetCompanies()
        Try
            DB.CreateConnection(cboDatabase.Text)

            Dim cmd As New MySqlCommand 'Create command
            Dim MySQLReader As MySqlDataReader
            Dim sTempCompanyDomain As String = ""
            Dim sTempCompanyID As String = ""
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_PrintInvoice_GetAllCompanies"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            MySQLReader = cmd.ExecuteReader
            cboCompanyName.Items.Clear()
            While MySQLReader.Read
                '$$$$$$$$$$$$$$$$$$$$$$$$$$$
                'Do Create file logic here.
                'Dim sTestReturnString As String = ""
                cboCompanyName.Items.Add(MySQLReader.GetValue(MySQLReader.GetOrdinal("CompanyName")))
                sTempCompanyDomain = sTempCompanyDomain & MySQLReader.GetValue(MySQLReader.GetOrdinal("CompanyDomainName")) & "|"
                sTempCompanyID = sTempCompanyID & MySQLReader.GetValue(MySQLReader.GetOrdinal("CompanyID")) & "|"
            End While

            marrCompanyDomainName = Split(sTempCompanyDomain, "|")
            marrCompanyID = Split(sTempCompanyID, "|")

        Catch exp As Exception

        Finally
            DB.ConnectionClose()
        End Try
    End Sub
    Private Sub btnRemoveMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveMenu.Click
        Try
            If cboCompanyName.SelectedIndex < 0 Then Exit Sub
            If MessageBox.Show("Are you sure you wants to remove menu from this restaurant?" & vbNewLine & vbNewLine & cboCompanyName.Text & "  < " & marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString & " >", "Confirm Remove Menu For Restaurant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.No Then Exit Sub
            DB.CreateConnection(cboDatabase.Text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "A_RemoveRestaurantMenu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            cmd.Parameters.AddWithValue("iCompanyID", Val(marrCompanyID(cboCompanyName.SelectedIndex).ToString))
            cmd.ExecuteNonQuery()
            ' marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString
            MessageBox.Show("Successfully removed menu", "Successfully removed menu", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class