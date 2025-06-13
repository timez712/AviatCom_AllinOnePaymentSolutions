Imports System
Imports System.Net
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frmProcessGetDataFromMySQL
    Dim DB As New DBConnection_MySQL
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Dim marrCompanyDomainName() As String = Nothing

    Private Sub ExportCompanyInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportCompanyInfo.Click
        Try

            Dim MySQLReader As MySqlDataReader = Nothing
            Dim bReplaceFile As Boolean = True
            Dim sFileName As String = ""
            Dim sSpliter As String = "|"
            lisProcessingLog.Items.Clear()
            SaveFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            'SaveFile.Filter = "Text(*.txt)|*.txt"
            SaveFile.FileName = cboCompanyName.Items(cboCompanyName.SelectedIndex).ToString & " Company Infomation.txt"


            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            SaveFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not SaveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If
            sFileName = SaveFile.FileName

            SetButtonEnableDisable(False)
            Cursor = Cursors.WaitCursor
            lisProcessingLog.Items.Insert(0, "Start Processing Gat Company Information Data........")
            lblProcessStatus.Text = "Processing Export Company Info Data........"

            DB.CreateConnection(cboDatabase.text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_ExportRestaurantInfo"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            cmd.Parameters.AddWithValue("sCompanyDomainName", marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
            ' cmd.Parameters.Add("greatdragon")
            MySQLReader = cmd.ExecuteReader


            While MySQLReader.Read
                '$$$$$$$$$$$$$$$$$$$$$$$$$$$
                'Do Create file logic here.
                Dim sTestReturnString As String = ""
                'sTestReturnString = MySQLReader.GetValue(MySQLReader.GetOrdinal("ColumnName"))
                'sTestReturnString = MySQLReader.GetString(0)
                'sTestReturnString = MySQLReader.GetString("ColumnName")

                'data = New DataTable

                'da = New MySqlDataAdapter("SELECT * FROM " + tables.SelectedItem.ToString(), conn)
                'cb = New MySqlCommandBuilder(da)

                'da.Fill(data)

                'DataGrid.DataSource = data


                'sTestReturnString = MySQLReader.GetString("Action")
                sTestReturnString = MySQLReader.GetString("CompanyName")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyAddress_1")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyAddress_2")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyAPT")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyCity")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyState")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyZipCode")
                lisProcessingLog.Items.Insert(0, sTestReturnString)
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyZipEx")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("AddressAdditionalInfo")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyPhone_1")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyPhone_2")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyFax")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyWebsite")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyEmail")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyDomainName")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("ReceiveOrderNumber")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyTimeZone")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyOperation")
                'sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CreatedTimeStamp")
                'sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("LastEditTimeStamp")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyDeliveryMin")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("CompanyDeliveryCharge")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("LunchSpecialTime")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("Latitude")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("Longitude")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("ReceiveOrderType")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("HasLunchSpecial")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("MaxSpecialOption")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("StateTaxRate")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("IsDelivery")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("IsCreditCard")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("EstimateDeliveryTime")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("RemotePrint")

                If bReplaceFile Then
                    LogToFile(sFileName, sTestReturnString, , True, True)
                    bReplaceFile = False
                Else
                    LogToFile(sFileName, sTestReturnString, , True, False)
                End If
                Application.DoEvents()
            End While


            MessageBox.Show("Company Infomation Data been Exported")
        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Export Company Infomation Completed!")
            DB.ConnectionClose()
        End Try
    End Sub
    Private Sub SetButtonEnableDisable(ByVal bEnable As Boolean)
        btnClose.Enabled = bEnable
        btnExportMenu.Enabled = bEnable
        btnExportCompanyInfo.Enabled = bEnable
        btnExportSpeicalMenu.Enabled = bEnable
    End Sub

    Private Sub btnExportMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportMenu.Click
        Try
            Dim MySQLReader As MySqlDataReader = Nothing
            Dim bReplaceFile As Boolean = True
            Dim sFileName As String = ""
            Dim sSpliter As String = "|"
            lisProcessingLog.Items.Clear()
            SaveFile.InitialDirectory = "Desktop"
            'SaveFile.Filter = "Text(*.txt)|*.txt"
            SaveFile.FileName = cboCompanyName.Items(cboCompanyName.SelectedIndex).ToString & " Menu.txt"


            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            SaveFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not SaveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If
            sFileName = SaveFile.FileName

            SetButtonEnableDisable(False)
            Cursor = Cursors.WaitCursor
            lisProcessingLog.Items.Insert(0, "Start Processing Gat Menu Data........")
            lblProcessStatus.Text = "Processing Export Menu Data........"

            DB.CreateConnection(cboDatabase.text)

            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "sp_ExportRestaurantMenu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            cmd.Parameters.AddWithValue("sCompanyDomainName", marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
            MySQLReader = cmd.ExecuteReader

            While MySQLReader.Read
                '$$$$$$$$$$$$$$$$$$$$$$$$$$$
                'Do Create file logic here.
                Dim sTestReturnString As String = MySQLReader.GetString("sCompanyDomainName")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("Foodtype")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("Des")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("MenuID")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishName")
                lisProcessingLog.Items.Insert(0, sTestReturnString)
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishDes")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishSize_1")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishPrice_1")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishSize_2")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishPrice_2")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishSize_3")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishPrice_3")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishSize_4")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishPrice_4")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DishCalorie")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("Spicy")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("DisplayOrder")
                If bReplaceFile Then
                    LogToFile(sFileName, sTestReturnString, , True, True)
                    bReplaceFile = False
                Else
                    LogToFile(sFileName, sTestReturnString, , True, False)
                End If
                Application.DoEvents()
            End While


            MessageBox.Show("Menu Data been Exported")
        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Export Menu Completed!")
            DB.ConnectionClose()
        End Try
    End Sub

    Private Sub btnExportSpeicalMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSpeicalMenu.Click
        Try
            Dim MySQLReader As MySqlDataReader = Nothing
            Dim bReplaceFile As Boolean = True
            Dim sFileName As String = ""
            Dim sSpliter As String = "|"
            lisProcessingLog.Items.Clear()
            SaveFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            'SaveFile.Filter = "Text(*.txt)|*.txt"
            SaveFile.FileName = cboCompanyName.Items(cboCompanyName.SelectedIndex).ToString & " SpeicalMenu.txt"


            'OpenFile.Filter = "ASCII files (*.txt;*.)|*.txt;*.log"
            SaveFile.InitialDirectory = "D:\My Window form Applications\Restaurants\"
            ' OpenFile.ShowDialog()
            If Not SaveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("File not found")
                Exit Sub
            End If
            sFileName = SaveFile.FileName

            SetButtonEnableDisable(False)
            Cursor = Cursors.WaitCursor
            lisProcessingLog.Items.Insert(0, "Start Export Speical Menu Data........")
            lblProcessStatus.Text = "Processing Export Speical Menu Data........"

            DB.CreateConnection(cboDatabase.text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string

            'cmd.CommandText = "sp_A_Test_GetData"   'insert SP Name
            'cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            'cmd.Parameters.AddWithValue("sCompanyDomainName", marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
            'MySQLReader = cmd.ExecuteReader


            cmd.CommandText = "sp_ExportRestaurantSpeicalMenu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            cmd.Parameters.AddWithValue("sCompanyDomainName", marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
            MySQLReader = cmd.ExecuteReader

            While MySQLReader.Read
                '$$$$$$$$$$$$$$$$$$$$$$$$$$$
                'Do Create file logic here.
                Dim sTestReturnString As String = MySQLReader.GetString("sCompanyDomainName")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("soID")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("soDishName")
                lisProcessingLog.Items.Insert(0, sTestReturnString)
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("soPrice")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("FoodType")
                sTestReturnString = sTestReturnString & sSpliter & MySQLReader.GetString("OptionID")

                If bReplaceFile Then
                    LogToFile(sFileName, sTestReturnString, , True, True)
                    bReplaceFile = False
                Else
                    LogToFile(sFileName, sTestReturnString, , True, False)
                End If
                Application.DoEvents()
            End While


            MessageBox.Show("Speical Menu Data been Exported")
        Catch exp As Exception
            MessageBox.Show(exp.ToString)
        Finally
            SetButtonEnableDisable(True)
            Cursor = Cursors.Default
            lblProcessStatus.Text = "Ready........"
            lisProcessingLog.Items.Insert(0, "Export Speical Menu Completed!")
            DB.ConnectionClose()
        End Try
    End Sub
    Private Sub GetCompanies()
        Try
            DB.CreateConnection(cboDatabase.text)

            Dim cmd As New MySqlCommand 'Create command
            Dim MySQLReader As MySqlDataReader
            Dim sTempCompanyDomain As String = ""
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
            End While

            marrCompanyDomainName = Split(sTempCompanyDomain, "|")


        Catch exp As Exception

        Finally
            DB.ConnectionClose()
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmProcessGetDataFromMySQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetCompanies()
    End Sub

    Private Sub cboCompanyName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompanyName.SelectedIndexChanged
        MessageBox.Show("Company Domain Name Selected - " & marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
    End Sub

    Private Sub cboDatabase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDatabase.SelectedIndexChanged
        GetCompanies()
    End Sub
End Class