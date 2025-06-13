Imports System
Imports System.Net
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports C1.Win.C1TrueDBGrid
Imports System.ComponentModel

Public Class frmOnlineOrderMenu
    Private DB As New DBConnection_MySQL
    Private data As DataTable
    Private da As MySqlDataAdapter
    Private cb As MySqlCommandBuilder


    WithEvents MyGrid_FoodType As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_Menu As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_MenuAddtional As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_FoodTypeMenuAddtional As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_Promotion As AviatCom_DefaultGrid = Nothing

    'Restaurant Times
    WithEvents MyGrid_RestaurantHour As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_BusinessOperation As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_LunchSpecial As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_DinnerSpecial As AviatCom_DefaultGrid = Nothing

    'New Restaurant Menu

    WithEvents MyGrid_NewRestaurantMenu As AviatCom_DefaultGrid = Nothing
    WithEvents MyGrid_NewRestaurantMenuOption As AviatCom_DefaultGrid = Nothing

    Private mdTable_RestaurantHour As DataTable
    Private mdTable_BusinessOperation As DataTable
    Private mdTable_LunchSpecial As DataTable
    Private mdTable_DinnerSpecial As DataTable


    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 10)
    Private mobjMyGridFooterFont As New Font("Arial", 10)

    Private mbProcessCodeEntered As Boolean = False
    Private mbRefreshingData As Boolean = False

    Dim marrCompanyDomainName() As String = Nothing
    Dim marrCompanyID() As String = Nothing

    Dim msDateSpliter As String = "$"
    Dim msDateTimeSpliter As String = "|"
    Dim msTimeSpliter As String = "@"
    Dim msTimeFromToSpliter As String = "-"

    Private msSQLStr_FoodType As String = "SELECT FoodTypeID, CompanyID, FoodType, DES AS 'Description', DisplayOrder FROM tbFoodType WHERE CompanyID = MyParameter_CompanyID;"
    Private msSQLStr_RestaurantMenu As String = <RestaurantMenu> 
                                                                    SELECT Foodtype,DishName,DishDes,
                                                                    DishSize_1, DishPrice_1,DishSize_2, DishPrice_2,DishSize_3, DishPrice_3,DishSize_4, DishPrice_4,Spicy
                                                                    ,tbRestaurantMenu.RestaurantMenuID,DisplayOrder,tbRestaurantMenu.CompanyID,tbRestaurantMenu.FoodTypeID,tbRestaurantMenu.DishesID,tbRestaurantMenu.MenuID
                                                                    FROM tbRestaurantMenu
                                                                    INNER JOIN tbDishes
                                                                    ON tbRestaurantMenu.DishesID = tbDishes.DishesID
                                                                    INNER JOIN tbFoodType
                                                                    ON tbRestaurantMenu.FoodTypeID = tbFoodType.FoodTypeID 
                                                                    WHERE tbRestaurantMenu.CompanyID = MyParameter_CompanyID
                                                                    ORDER BY Foodtype,DishName;
                                                </RestaurantMenu>
    Private msSQLStr_RestaurantMenu_SubMenu As String = <RestaurantMenu_SubMenu> 
                                                                    SELECT SpecialID,SOID,SODishName,SOPrice,CompanyID,
                                                                    FoodType,OptionID
                                                                    FROM tbSpecial
                                                                    WHERE CompanyID = MyParameter_CompanyID;
                                                </RestaurantMenu_SubMenu>

    Private msSQL_GetNewRestaurantMenu As String = $"SELECT 'MyParameter_CompanyDomainName' AS DomainName,
			                                            tbMenuDish.PrintGroup AS 'Print Group',
                                                        CASE WHEN tbMenuCategory.isLunchSpecial = 0 THEN 'N' ELSE 'Y' END AS 'isLunchSpecial',
                                                        CASE WHEN tbMenuCategory.isDinnerSpecial = 0 THEN 'N' ELSE 'Y' END   AS 'isDinnerSpecial',
                                                        tbMenuCategory.CategoryName AS 'Category Name',
                                                        tbMenuCategory.CategoryDescription AS 'Category Description',
                                                        tbMenuCategory.CategoryDisplaySequence AS 'Category Display Sequence',
                                                        tbMenuMapping.RestaurantMenuID AS 'MenuID',
                                                        tbMenuDish.DishName AS 'Dish Name',
                                                        tbMenuDish.DishDescription AS 'Dish Description',
                                                        tbMenuDish.SizeName AS 'Size Name',
                                                        tbMenuDish.SizePrice AS 'Size Price',
                                                        CASE WHEN tbMenuDish.isRaw = 0 THEN 'N' ELSE 'Y' END AS 'isRaw',
                                                        CASE WHEN tbMenuDish.isSpicy = 0 THEN 'N' ELSE 'Y' END AS 'isSpicy',
                                                        tbMenuMapping.OptionGroup AS 'Option Group',
                                                        tbMenuDish.DishName2 AS 'Dish Name2',
                                                        tbMenuDish.DishDescription2 AS 'Dish Description2',
                                                        tbMenuDish.SizeName2 AS 'Size Name2',
                                                        tbMenuCategory.CategoryName2 AS 'Category Name2',
                                                        tbMenuCategory.CategoryDescription2 AS 'Category Description2',
                                                        tbMenuCategory.Remarks AS 'Category Remarks',
                                                        tbMenuDish.Remarks AS 'Dish Remarks',
                                                        tbMenuDish.DisplaySequence AS 'Dish Display Sequence'
                                                FROM tbMenuMapping
                                                INNER JOIN tbMenuCategory
                                                ON tbMenuMapping.CompanyDomainName = tbMenuCategory.CompanyDomainName
		                                            AND tbMenuMapping.CategoryName = tbMenuCategory.CategoryName
                                                INNER JOIN tbMenuDish
                                                ON tbMenuMapping.CompanyDomainName = tbMenuDish.CompanyDomainName
		                                            AND tbMenuMapping.DishName = tbMenuDish.DishName  
                                                WHERE tbMenuMapping.CompanyDomainName = 'MyParameter_CompanyDomainName'
                                                ORDER BY tbMenuCategory.CategoryDisplaySequence,
				                                            tbMenuDish.DisplaySequence,
				                                            tbMenuMapping.RestaurantMenuID;"

    Private msStr_GetNewRestaurantMenuOption As String = $"SELECT 
		                                                        tbMenuDishOption.CompanyDomainName AS 'DomainName',
		                                                        tbMenuDishOption.DisplaySequence AS 'Display Sequence',
		                                                        CASE WHEN tbMenuDishOption.isSpicy = 0 THEN 'N' ELSE 'Y' END AS 'isSpicy',
		                                                        tbMenuDishOption.OptionGroup AS 'Option Group',
		                                                        tbMenuDishOption.SectionGroup AS 'Section Group',
		                                                        tbMenuDishOption.OptionName AS 'Option Name',
		                                                        tbMenuDishOption.OptionPrice AS 'Option Price',
		                                                        tbMenuDishOption.Remarks AS 'Remarks',
		                                                        tbMenuDishOption.OptionName2 AS 'Option Name2'
	                                                        FROM tbMenuDishOption
                                                            WHERE tbMenuDishOption.CompanyDomainName = 'MyParameter_CompanyDomainName'
                                                            ORDER BY tbMenuDishOption.DisplaySequence,
				                                                        tbMenuDishOption.OptionGroup,
				                                                        tbMenuDishOption.SectionGroup;"

    Private Function CreateDateTimeTable(Optional bDisplayHourOnly As Boolean = False) As DataTable
        Try
            Dim dTable As New DataTable
            dTable.Columns.Add("DateName", GetType(System.String))
            dTable.Columns.Add("From", GetType(System.String))
            dTable.Columns.Add("To", GetType(System.String))
            dTable.Columns.Add("DisplayOrder", GetType(System.String))
            Return dTable
            'Dim Row As DataRow = dTable.NewRow
            'Row("TransactionID") = dSet.Tables(1).Rows(0).Item("TransactionID").ToString
            'Row("AmountType") = "DMV Amount:"
            'Row("Amount") = Val(dSet.Tables(1).Rows(0).Item("DMVAmount").ToString)
            'dTable.Rows.Add(Row)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub FillDateTime(ByRef MyDTable As DataTable, sDateTimeString As String, Optional bDisplayHourOnly As Boolean = False)
        Try
            If sDateTimeString = "" Then Exit Sub
            If MyDTable IsNot Nothing Then
                Dim arrDate As Array = Microsoft.VisualBasic.Strings.Split(sDateTimeString, msDateSpliter)
                For j As Integer = 0 To arrDate.Length - 1
                    Dim arrDateTime As Array = Microsoft.VisualBasic.Strings.Split(arrDate(j), msDateTimeSpliter)
                    Dim sDateName As String = arrDateTime(0).ToString
                    Dim sDisplayOrder As String = GetDateDisplayOrder(sDateName)
                    Dim arrTimeSet As Array = Microsoft.VisualBasic.Strings.Split(arrDateTime(1), msTimeSpliter)
                    If bDisplayHourOnly Then
                        Dim dRow As DataRow = MyDTable.NewRow
                        dRow("DateName") = sDateName.Trim
                        dRow("HourDesc") = arrDateTime(1).ToString.Trim
                        dRow("DisplayOrder") = sDisplayOrder
                        MyDTable.Rows.Add(dRow)
                    Else
                        For i As Integer = 0 To arrTimeSet.Length - 1
                            Dim dRow As DataRow = MyDTable.NewRow
                            Dim arrFromTo As Array = Microsoft.VisualBasic.Strings.Split(arrTimeSet(i), msTimeFromToSpliter)
                            dRow("DateName") = sDateName.Trim
                            dRow("From") = arrFromTo(0).ToString.Trim
                            dRow("To") = arrFromTo(1).ToString.Trim
                            dRow("DisplayOrder") = sDisplayOrder
                            MyDTable.Rows.Add(dRow)
                        Next
                    End If

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function GetDateTimeInString(dTable As DataTable, Optional sSpaceBetweenTime As String = "", Optional bDisplayHourOnly As Boolean = False) As String
        Dim sResult As String = ""
        For j As Integer = 0 To dTable.Rows.Count - 1
            dTable.Rows(j).Item("DisplayOrder") = GetDateDisplayOrder(dTable.Rows(j).Item("DateName").ToString.ToUpper)
        Next
        Dim DV As New DataView(dTable)
        Dim LastProcessWeekDateName As String = ""
        If bDisplayHourOnly Then
            DV.Sort = "DisplayOrder ASC, HourDesc ASC"
        Else
            DV.Sort = "DisplayOrder ASC, From ASC"
        End If

        Try
            For j As Integer = 0 To DV.Count - 1
                If bDisplayHourOnly Then
                    If LastProcessWeekDateName = DV(j).Item("DateName").ToString Then
                        sResult = sResult & msTimeSpliter & DV(j).Item("HourDesc").ToString
                    Else
                        LastProcessWeekDateName = DV(j).Item("DateName").ToString
                        sResult = IIf(sResult = "", "", sResult & msDateSpliter) & DV(j).Item("DateName").ToString & msDateTimeSpliter & DV(j).Item("HourDesc").ToString
                    End If
                Else
                    If LastProcessWeekDateName = DV(j).Item("DateName").ToString Then
                        sResult = sResult & msTimeSpliter & DV(j).Item("From").ToString & sSpaceBetweenTime & msTimeFromToSpliter & sSpaceBetweenTime & DV(j).Item("To").ToString
                    Else
                        LastProcessWeekDateName = DV(j).Item("DateName").ToString
                        sResult = IIf(sResult = "", "", sResult & msDateSpliter) & DV(j).Item("DateName").ToString & msDateTimeSpliter & DV(j).Item("From").ToString & sSpaceBetweenTime & msTimeFromToSpliter & sSpaceBetweenTime & DV(j).Item("To").ToString
                    End If
                End If


            Next
            Return sResult ' MsgBox(sResult)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return sResult
        End Try
    End Function
    Private Function GetDateDisplayOrder(sDateName As String) As String
        Try
            Select Case sDateName.ToUpper

                Case "Monday".ToUpper
                    Return 1
                Case "Tuesday".ToUpper
                    Return 2
                Case "Wednesday".ToUpper
                    Return 3
                Case "Thursday".ToUpper
                    Return 4
                Case "Friday".ToUpper
                    Return 5
                Case "Saturday".ToUpper
                    Return 6
                Case Else
                    Return 0
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Private Sub cboDatabase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDatabase.SelectedIndexChanged

        GetCompanies()
    End Sub

    Private Sub cboCompanyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCompanyName.SelectedIndexChanged
        'MessageBox.Show("Company Domain Name Selected - " & marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
        FillRestaurantInformation(marrCompanyID(cboCompanyName.SelectedIndex))
        GetRestaurantMenu(marrCompanyID(cboCompanyName.SelectedIndex))
        GetFoodType(marrCompanyID(cboCompanyName.SelectedIndex))
        GetNewRestaurantMenu(marrCompanyDomainName(cboCompanyName.SelectedIndex))
        GetNewRestaurantMenuOption(marrCompanyDomainName(cboCompanyName.SelectedIndex))
        If Not TabControl1.Enabled Then TabControl1.Enabled = True
    End Sub
    Private Sub GetCompanies()
        Try

            mbProcessCodeEntered = False
            cboCompanyName.Items.Clear()
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

            marrCompanyDomainName = Microsoft.VisualBasic.Strings.Split(sTempCompanyDomain, "|")
            marrCompanyID = Microsoft.VisualBasic.Strings.Split(sTempCompanyID, "|")


        Catch exp As Exception

        Finally
            DB.ConnectionClose()
        End Try
    End Sub

    Private Sub frmOnlineOrderMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            gbRestaurantStatus.BackColor = strMyColor.cNo
            btnActiveRestaurant.Text = "Active Restaurant"
            Me.AutoScaleMode = AutoScaleMode.Dpi

            MyGrid_Menu = New AviatCom_DefaultGrid(C1TrueDBGrid2)
            MyGrid_Menu.FetchRowStyles = True
            MyGrid_Menu.AC_AllowFilter = True
            MyGrid_Menu.AllowFilter = True
            MyGrid_Menu.AllowDelete = True
            MyGrid_Menu.AllowAddNew = True
            MyGrid_Menu.AllowSort = True
            MyGrid_Menu.AllowColSelect = True
            MyGrid_Menu.BorderStyle = BorderStyle.Fixed3D
            MyGrid_Menu.ColumnFooters = False
            MyGrid_Menu.Anchor = C1TrueDBGrid2.Anchor
            C1TrueDBGrid2.Dispose()
            MyGrid_Menu.Show()

            MyGrid_FoodType = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_FoodType.FetchRowStyles = True
            MyGrid_FoodType.AC_AllowFilter = True
            MyGrid_FoodType.AllowFilter = True
            MyGrid_FoodType.AllowDelete = True
            MyGrid_FoodType.AllowAddNew = True
            MyGrid_FoodType.AllowSort = True
            MyGrid_FoodType.AllowColSelect = True
            MyGrid_FoodType.BorderStyle = BorderStyle.Fixed3D
            MyGrid_FoodType.ColumnFooters = False
            MyGrid_FoodType.Anchor = C1TrueDBGrid1.Anchor
            C1TrueDBGrid1.Dispose()
            MyGrid_FoodType.Show()

            MyGrid_FoodTypeMenuAddtional = New AviatCom_DefaultGrid(C1TrueDBGrid9)
            MyGrid_FoodTypeMenuAddtional.FetchRowStyles = True
            MyGrid_FoodTypeMenuAddtional.AC_AllowFilter = True
            MyGrid_FoodTypeMenuAddtional.AllowFilter = True
            MyGrid_FoodTypeMenuAddtional.AllowDelete = False
            MyGrid_FoodTypeMenuAddtional.AllowAddNew = False
            MyGrid_FoodTypeMenuAddtional.AllowUpdate = False
            MyGrid_FoodTypeMenuAddtional.AllowSort = True
            MyGrid_FoodTypeMenuAddtional.AllowColSelect = True
            MyGrid_FoodTypeMenuAddtional.BorderStyle = BorderStyle.Fixed3D
            MyGrid_FoodTypeMenuAddtional.ColumnFooters = False
            MyGrid_FoodTypeMenuAddtional.Anchor = C1TrueDBGrid9.Anchor
            C1TrueDBGrid9.Dispose()
            MyGrid_FoodTypeMenuAddtional.Show()


            MyGrid_MenuAddtional = New AviatCom_DefaultGrid(C1TrueDBGrid3)
            MyGrid_MenuAddtional.FetchRowStyles = True
            MyGrid_MenuAddtional.AC_AllowFilter = True
            MyGrid_MenuAddtional.AllowFilter = True
            MyGrid_MenuAddtional.AllowDelete = True
            MyGrid_MenuAddtional.AllowAddNew = True
            MyGrid_MenuAddtional.AllowSort = True
            MyGrid_MenuAddtional.AllowColSelect = True
            MyGrid_MenuAddtional.BorderStyle = BorderStyle.Fixed3D
            MyGrid_MenuAddtional.ColumnFooters = False
            MyGrid_MenuAddtional.Anchor = C1TrueDBGrid3.Anchor
            C1TrueDBGrid3.Dispose()
            MyGrid_MenuAddtional.Show()



            MyGrid_Promotion = New AviatCom_DefaultGrid(C1TrueDBGrid4)
            MyGrid_Promotion.FetchRowStyles = True
            MyGrid_Promotion.AC_AllowFilter = True
            MyGrid_Promotion.AllowFilter = True
            MyGrid_Promotion.AllowDelete = True
            MyGrid_Promotion.AllowAddNew = True
            MyGrid_Promotion.AllowSort = True
            MyGrid_Promotion.AllowColSelect = True
            MyGrid_Promotion.BorderStyle = BorderStyle.Fixed3D
            MyGrid_Promotion.ColumnFooters = False
            MyGrid_Promotion.Anchor = C1TrueDBGrid4.Anchor
            C1TrueDBGrid4.Dispose()
            MyGrid_Promotion.Show()


            MyGrid_RestaurantHour = New AviatCom_DefaultGrid(C1TrueDBGrid5)
            MyGrid_RestaurantHour.FetchRowStyles = True
            MyGrid_RestaurantHour.AC_AllowFilter = True
            MyGrid_RestaurantHour.AllowFilter = True
            MyGrid_RestaurantHour.AllowDelete = True
            MyGrid_RestaurantHour.AllowAddNew = True
            MyGrid_RestaurantHour.AllowSort = True
            MyGrid_RestaurantHour.AllowColSelect = True
            MyGrid_RestaurantHour.BorderStyle = BorderStyle.Fixed3D
            MyGrid_RestaurantHour.ColumnFooters = False
            MyGrid_RestaurantHour.Anchor = C1TrueDBGrid5.Anchor
            C1TrueDBGrid5.Dispose()
            MyGrid_RestaurantHour.Show()

            MyGrid_BusinessOperation = New AviatCom_DefaultGrid(C1TrueDBGrid6)
            MyGrid_BusinessOperation.FetchRowStyles = True
            MyGrid_BusinessOperation.AC_AllowFilter = True
            MyGrid_BusinessOperation.AllowFilter = True
            MyGrid_BusinessOperation.AllowDelete = True
            MyGrid_BusinessOperation.AllowAddNew = True
            MyGrid_BusinessOperation.AllowSort = True
            MyGrid_BusinessOperation.AllowColSelect = True
            MyGrid_BusinessOperation.BorderStyle = BorderStyle.Fixed3D
            MyGrid_BusinessOperation.ColumnFooters = False
            MyGrid_BusinessOperation.Anchor = C1TrueDBGrid6.Anchor
            C1TrueDBGrid6.Dispose()
            MyGrid_BusinessOperation.Show()

            MyGrid_LunchSpecial = New AviatCom_DefaultGrid(C1TrueDBGrid7)
            MyGrid_LunchSpecial.FetchRowStyles = True
            MyGrid_LunchSpecial.AC_AllowFilter = True
            MyGrid_LunchSpecial.AllowFilter = True
            MyGrid_LunchSpecial.AllowDelete = True
            MyGrid_LunchSpecial.AllowAddNew = True
            MyGrid_LunchSpecial.AllowSort = True
            MyGrid_LunchSpecial.AllowColSelect = True
            MyGrid_LunchSpecial.BorderStyle = BorderStyle.Fixed3D
            MyGrid_LunchSpecial.ColumnFooters = False
            MyGrid_LunchSpecial.Anchor = C1TrueDBGrid7.Anchor
            C1TrueDBGrid7.Dispose()
            MyGrid_LunchSpecial.Show()

            MyGrid_DinnerSpecial = New AviatCom_DefaultGrid(C1TrueDBGrid8)
            MyGrid_DinnerSpecial.FetchRowStyles = True
            MyGrid_DinnerSpecial.AC_AllowFilter = True
            MyGrid_DinnerSpecial.AllowFilter = True
            MyGrid_DinnerSpecial.AllowDelete = True
            MyGrid_DinnerSpecial.AllowAddNew = True
            MyGrid_DinnerSpecial.AllowSort = True
            MyGrid_DinnerSpecial.AllowColSelect = True
            MyGrid_DinnerSpecial.BorderStyle = BorderStyle.Fixed3D
            MyGrid_DinnerSpecial.ColumnFooters = False
            MyGrid_DinnerSpecial.Anchor = C1TrueDBGrid8.Anchor
            C1TrueDBGrid8.Dispose()
            MyGrid_DinnerSpecial.Show()


            '$$$$$$$$ 6/12/2021, New Restaurant Menu

            MyGrid_NewRestaurantMenu = New AviatCom_DefaultGrid(C1TrueDBGrid10)
            MyGrid_NewRestaurantMenu.FetchRowStyles = True
            MyGrid_NewRestaurantMenu.AC_AllowFilter = True
            MyGrid_NewRestaurantMenu.AllowFilter = True
            MyGrid_NewRestaurantMenu.AllowDelete = False
            MyGrid_NewRestaurantMenu.AllowAddNew = False
            MyGrid_NewRestaurantMenu.AllowUpdate = False
            MyGrid_NewRestaurantMenu.AllowSort = True
            MyGrid_NewRestaurantMenu.AllowColSelect = True
            MyGrid_NewRestaurantMenu.BorderStyle = BorderStyle.Fixed3D
            MyGrid_NewRestaurantMenu.ColumnFooters = False
            MyGrid_NewRestaurantMenu.Anchor = C1TrueDBGrid10.Anchor
            C1TrueDBGrid10.Dispose()
            MyGrid_NewRestaurantMenu.Show()

            MyGrid_NewRestaurantMenuOption = New AviatCom_DefaultGrid(C1TrueDBGrid11)
            MyGrid_NewRestaurantMenuOption.FetchRowStyles = True
            MyGrid_NewRestaurantMenuOption.AC_AllowFilter = True
            MyGrid_NewRestaurantMenuOption.AllowFilter = True
            MyGrid_NewRestaurantMenuOption.AllowDelete = False
            MyGrid_NewRestaurantMenuOption.AllowAddNew = False
            MyGrid_NewRestaurantMenuOption.AllowUpdate = False
            MyGrid_NewRestaurantMenuOption.AllowSort = True
            MyGrid_NewRestaurantMenuOption.AllowColSelect = True
            MyGrid_NewRestaurantMenuOption.BorderStyle = BorderStyle.Fixed3D
            MyGrid_NewRestaurantMenuOption.ColumnFooters = False
            MyGrid_NewRestaurantMenuOption.Anchor = C1TrueDBGrid11.Anchor
            C1TrueDBGrid11.Dispose()
            MyGrid_NewRestaurantMenuOption.Show()
            '$$$$$$$$$$$$$$$$$$$$$$$$ New Restaurant Menu

            mdTable_RestaurantHour = New DataTable
            mdTable_RestaurantHour.Columns.Add("DateName", GetType(System.String))
            mdTable_RestaurantHour.Columns.Add("HourDesc", GetType(System.String))
            mdTable_RestaurantHour.Columns.Add("DisplayOrder", GetType(System.String))




            mdTable_BusinessOperation = New DataTable
            mdTable_BusinessOperation.Columns.Add("DateName", GetType(System.String))
            mdTable_BusinessOperation.Columns.Add("From", GetType(System.String))
            mdTable_BusinessOperation.Columns.Add("To", GetType(System.String))
            mdTable_BusinessOperation.Columns.Add("DisplayOrder", GetType(System.String))

            mdTable_LunchSpecial = New DataTable
            mdTable_LunchSpecial.Columns.Add("DateName", GetType(System.String))
            mdTable_LunchSpecial.Columns.Add("From", GetType(System.String))
            mdTable_LunchSpecial.Columns.Add("To", GetType(System.String))
            mdTable_LunchSpecial.Columns.Add("DisplayOrder", GetType(System.String))

            mdTable_DinnerSpecial = New DataTable
            mdTable_DinnerSpecial.Columns.Add("DateName", GetType(System.String))
            mdTable_DinnerSpecial.Columns.Add("From", GetType(System.String))
            mdTable_DinnerSpecial.Columns.Add("To", GetType(System.String))
            mdTable_DinnerSpecial.Columns.Add("DisplayOrder", GetType(System.String))

            FillDataTime(MyGrid_RestaurantHour, mdTable_RestaurantHour)
            FillDataTime(MyGrid_BusinessOperation, mdTable_BusinessOperation)
            FillDataTime(MyGrid_LunchSpecial, mdTable_LunchSpecial)
            FillDataTime(MyGrid_DinnerSpecial, mdTable_DinnerSpecial)


            cboReceiveOrderType.Items.Clear()
            cboReceiveOrderType.Items.Add("")
            cboReceiveOrderType.Items.Add("FAX")
            cboReceiveOrderType.Items.Add("POS")
            cboReceiveOrderType.Items.Add("EMAIL")

            AddHandler txtStateTaxRate.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot
            AddHandler txtDeliveryDistance.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot
            AddHandler txtDeliveryCharge.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot
            AddHandler txtDeliveryMin.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot
            AddHandler txtLatitude.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot
            AddHandler txtDeliveryMin.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot
            AddHandler txtLongittude.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot


            AddHandler txtChargeTheirCustomerAmountChagePerOrder.KeyPress, AddressOf Textbox_KeyPress_NumbersWithDot


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetRestaurantMenu(iCompanyID As Integer)
        Try



            Cursor = Cursors.WaitCursor
            MyGrid_Menu.FilterSaveGridFilters()
            '$$$$$$$$$$$$$, 2024/04/30, John
            'msSQLStr_RestaurantMenu = "CALL spMenu_GetMenu('china-moon');"
            'MyGrid_Menu.AC_GridDataSet = SQL_GetStandardGridDataSet(DB.MySQLQueryGetData(msSQLStr_RestaurantMenu))
            MyGrid_Menu.AC_GridDataSet = SQL_GetStandardGridDataSet(DB.MySQLQueryGetData(msSQLStr_RestaurantMenu.Replace("MyParameter_CompanyID", iCompanyID.ToString)))
            'If MyGrid_Menu.AC_GridDataSet.Tables(MyGrid_Menu.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_Menu.AC_GridDataSet.Tables(MyGrid_Menu.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_Menu.AC_SortDirectionReset()
            MyGrid_Menu.AC_ColumnWidthMultipler_Disable = True
            MyGrid_Menu.AC_RefreshGrid()

            'MyGrid_Menu.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_Menu.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_Menu.AlternatingRows = True
                'MyGrid_Menu.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_Menu.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_Menu.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_Menu.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_Menu.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_Menu.CaptionStyle.Font.Size * 0.8)
                MyGrid_Menu.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_Menu, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_Menu, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)
            MyGrid_Menu.FilterRestallFilters()
        Catch ex As Exception
            MessageBox.Show("GetRestaurantMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - GetRestaurantMenu " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetRestaurantMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GetRestaurantMenuAddtional(iCompanyID As Integer)
        Try

            Cursor = Cursors.WaitCursor

            MyGrid_FoodTypeMenuAddtional.AC_GridDataSet = SQL_GetStandardGridDataSet(DB.MySQLQueryGetData(msSQLStr_RestaurantMenu.Replace("MyParameter_CompanyID", iCompanyID.ToString)))
            'If MyGrid_FoodTypeMenuAddtional.AC_GridDataSet.Tables(MyGrid_FoodTypeMenuAddtional.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_FoodTypeMenuAddtional.AC_GridDataSet.Tables(MyGrid_FoodTypeMenuAddtional.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_FoodTypeMenuAddtional.AC_SortDirectionReset()
            MyGrid_FoodTypeMenuAddtional.AC_ColumnWidthMultipler_Disable = True
            MyGrid_FoodTypeMenuAddtional.AC_RefreshGrid()

            'MyGrid_FoodTypeMenuAddtional.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_FoodTypeMenuAddtional.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_FoodTypeMenuAddtional.AlternatingRows = True
                'MyGrid_FoodTypeMenuAddtional.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_FoodTypeMenuAddtional.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_FoodTypeMenuAddtional.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_FoodTypeMenuAddtional.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_FoodTypeMenuAddtional.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_FoodTypeMenuAddtional.CaptionStyle.Font.Size * 0.8)
                MyGrid_FoodTypeMenuAddtional.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_FoodTypeMenuAddtional, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_FoodTypeMenuAddtional, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch ex As Exception
            MessageBox.Show("GetRestaurantMenuAddtional Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - GetRestaurantMenuAddtional " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetRestaurantMenuAddtional - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GetRestaurantPromotion(iCompanyID As Integer)
        Try



            Cursor = Cursors.WaitCursor

            MyGrid_Promotion.AC_GridDataSet = SQL_GetStandardGridDataSet(DB.MySQLQueryGetData(msSQLStr_RestaurantMenu.Replace("MyParameter_CompanyID", iCompanyID.ToString)))
            'If MyGrid_Promotion.AC_GridDataSet.Tables(MyGrid_Promotion.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_Promotion.AC_GridDataSet.Tables(MyGrid_Promotion.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_Promotion.AC_SortDirectionReset()
            MyGrid_Promotion.AC_ColumnWidthMultipler_Disable = True
            MyGrid_Promotion.AC_RefreshGrid()

            'MyGrid_Promotion.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_Promotion.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_Promotion.AlternatingRows = True
                'MyGrid_Promotion.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_Promotion.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_Promotion.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_Promotion.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_Promotion.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_Promotion.CaptionStyle.Font.Size * 0.8)
                MyGrid_Promotion.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_Promotion, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_Promotion, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch ex As Exception
            MessageBox.Show("GetRestaurantPromotion Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - GetRestaurantPromotion " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetRestaurantPromotion - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GetFoodType(iCompanyID As Integer)
        Try
            Cursor = Cursors.WaitCursor
            DB.CreateConnection(cboDatabase.Text)
            Using dTable As DataTable = DB.MySQLQueryGetData(msSQLStr_FoodType.Replace("MyParameter_CompanyID", iCompanyID.ToString))
                FillFoodType(dTable.Copy)
                FillFoodTypeForSubMenu(dTable.Copy)
            End Using
        Catch ex As Exception
            MessageBox.Show("GetFoodType Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - GetFoodType " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetFoodType - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub FillFoodType(dTable As DataTable)
        Try

            MyGrid_FoodType.AC_GridDataSet = SQL_GetStandardGridDataSet(dTable, False, , GetParam("@", "@", "", "", ""))


            MyGrid_FoodType.AC_SortDirectionReset()
            MyGrid_FoodType.AC_ColumnWidthMultipler_Disable = True
            MyGrid_FoodType.AC_RefreshGrid()

            'MyGrid_FoodType.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_FoodType.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_FoodType.AlternatingRows = True
                'MyGrid_FoodType.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_FoodType.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_FoodType.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_FoodType.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_FoodType.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_FoodType.CaptionStyle.Font.Size * 0.8)
                MyGrid_FoodType.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_FoodType, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_FoodType, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch ex As Exception
            MessageBox.Show("FillFoodType Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - FillFoodType " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "FillFoodType - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub
    Private Sub FillFoodTypeForSubMenu(dTable As DataTable)
        Try
            'MyGrid_MenuAddtional

            MyGrid_MenuAddtional.AC_GridDataSet = SQL_GetStandardGridDataSet(dTable, False, , GetParam("@", "@", "~", "~", "~"))


            MyGrid_MenuAddtional.AC_SortDirectionReset()
            MyGrid_MenuAddtional.AC_ColumnWidthMultipler_Disable = True
            MyGrid_MenuAddtional.AC_RefreshGrid()

            'MyGrid_MenuAddtional.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_FoodTypeMenuAddtional.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_FoodTypeMenuAddtional.AlternatingRows = True
                'MyGrid_FoodTypeMenuAddtional.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_FoodTypeMenuAddtional.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_FoodTypeMenuAddtional.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_FoodTypeMenuAddtional.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_FoodTypeMenuAddtional.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_FoodTypeMenuAddtional.CaptionStyle.Font.Size * 0.8)
                MyGrid_FoodTypeMenuAddtional.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_FoodTypeMenuAddtional, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_FoodTypeMenuAddtional, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch ex As Exception
            MessageBox.Show("FillFoodTypeForSubMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - FillFoodTypeForSubMenu " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "FillFoodTypeForSubMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub
    Private Sub FillDataTime(ByRef MyRefGrid_testing As AviatCom_DefaultGrid, ByRef dTable As DataTable)
        Try



            Cursor = Cursors.WaitCursor

            'FillDateTime(dTable, sDatetime)
            Dim DSet As DataSet = SQL_GetStandardGridDataSet(dTable, False, , GetParam("", "", "", "~"), GetParam(12, 7, 7, 0))
            MyRefGrid_testing.AC_GridDataSet = DSet
            'If MyRefGrid_testing.AC_GridDataSet.Tables(MyRefGrid_testing.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyRefGrid_testing.AC_GridDataSet.Tables(MyRefGrid_testing.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyRefGrid_testing.AC_SortDirectionReset()
            MyRefGrid_testing.AC_ColumnWidthMultipler_Disable = True
            MyRefGrid_testing.AC_RefreshGrid()



            Dim VI As ValueItems = MyRefGrid_testing.Columns("DateName").ValueItems
            VI.Translate = True
            VI.CycleOnClick = True
            VI.Presentation = PresentationEnum.ComboBox
            VI.Values.Clear()
            VI.Values.Add(New ValueItem("Sunday", "Sunday"))
            VI.Values.Add(New ValueItem("Monday", "Monday"))
            VI.Values.Add(New ValueItem("Tuesday", "Tuesday"))
            VI.Values.Add(New ValueItem("Wednesday", "Wednesday"))
            VI.Values.Add(New ValueItem("Thursday", "Thursday"))
            VI.Values.Add(New ValueItem("Friday", "Friday"))
            VI.Values.Add(New ValueItem("Saturday", "Saturday"))



            MyRefGrid_testing.Columns("DateName").ValueItems.Validate = True


            'MyRefGrid_testing.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyRefGrid_testing.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyRefGrid_testing.AlternatingRows = True
                'MyRefGrid_testing.EvenRowStyle.BackColor = Color.LightCyan


                MyRefGrid_testing.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyRefGrid_testing.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyRefGrid_testing.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyRefGrid_testing.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyRefGrid_testing.CaptionStyle.Font.Size * 0.8)
                MyRefGrid_testing.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyRefGrid_testing, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyRefGrid_testing, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, False)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ClearFields()
        Try
            txtCompanyName.Text = ""
            txtAddress1.Text = ""
            txtAddress2.Text = ""
            txtApt.Text = ""
            txtCity.Text = ""
            txtState.Text = ""
            txtZipCode.Text = ""
            txtAddressAdditionalInfo.Text = ""
            txtPhone1.Text = ""
            txtPhone2.Text = ""
            txtFax.Text = ""
            txtWebsite.Text = ""
            txtDomainName.Text = ""
            txtReceiveOrderNumber.Text = ""
            ' txtTimeZone.Text = "UTC-5"
            txtDeliveryMin.Text = ""
            txtDeliveryCharge.Text = ""
            txtReceiveOrderNumber.Text = "Fax"
            chkHasLunchSpecial.Checked = True
            txtStateTaxRate.Text = "8.875"
            chkIsDelivery.Checked = True
            chkIsCreditCard.Checked = True
            txtEstimateDeliveryTime.Text = "30 Mins after place order"
            txtRemotePrinter.Text = ""
            txtPaymentUserName.Text = ""
            txtPaymentPassword.Text = ""
            txtMonthlyMin.Text = ""
            chkIsByPercentage.Checked = False
            txtOrderPrice.Text = ""
            txtOrderPricePercentage.Text = ""
            chkisMinChargeCover.Checked = False
            txtBasicCharge.Text = ""
            txtLastEmailPomotion.Text = ""
            lblCompanyID.Text = "CompanyID: "
            lblCreateTime.Text = "Created: "
            lblLastEditTime.Text = "LastUpdate: "
            txtOrderEmail.Text = ""
            txtOrderEmailCC.Text = ""
            'txtOrderEmailBCC.Text = ""
            MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1).Clear()
            MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1).Clear()
            MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1).Clear()
            MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1).Clear()
            txtPlaceOrderAlertFromRestaurant.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub FillRestaurantInformation(iCompanyID As Integer)
        Try

            Using dTable As DataTable = DB.MySQLQueryGetData("SELECT * FROM tbCompanyInfo INNER JOIN tbContactInfo ON tbCompanyInfo.CompanyID = tbContactInfo.CompanyID WHERE tbCompanyInfo.CompanyID =" & Val(marrCompanyID(cboCompanyName.SelectedIndex).ToString) & ";")
                If Not dTable Is Nothing Then
                    If dTable.Rows.Count = 1 Then
                        MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1).Clear()
                        MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1).Clear()
                        MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1).Clear()
                        MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1).Clear()
                        txtCompanyName.Text = dTable.Rows(0).Item("CompanyName").ToString
                        txtCompanyName.Tag = dTable.Rows(0).Item("CompanyID").ToString
                        txtAddress1.Text = dTable.Rows(0).Item("CompanyAddress_1").ToString
                        txtAddress2.Text = dTable.Rows(0).Item("CompanyAddress_2").ToString
                        txtApt.Text = dTable.Rows(0).Item("CompanyAPT").ToString
                        txtCity.Text = dTable.Rows(0).Item("CompanyCity").ToString
                        txtState.Text = dTable.Rows(0).Item("CompanyState").ToString
                        txtZipCode.Text = dTable.Rows(0).Item("CompanyZipCode").ToString
                        txtAddressAdditionalInfo.Text = dTable.Rows(0).Item("AddressAdditionalInfo").ToString
                        txtPhone1.Text = dTable.Rows(0).Item("CompanyPhone_1").ToString
                        txtPhone2.Text = dTable.Rows(0).Item("CompanyPhone_2").ToString
                        txtFax.Text = dTable.Rows(0).Item("CompanyFax").ToString
                        txtWebsite.Text = dTable.Rows(0).Item("CompanyWebsite").ToString
                        txtEmail.Text = dTable.Rows(0).Item("CompanyEmail").ToString
                        txtDomainName.Text = dTable.Rows(0).Item("CompanyDomainName").ToString
                        txtReceiveOrderNumber.Text = dTable.Rows(0).Item("ReceiveOrderNumber").ToString
                        cboTimeZone.Text = TimeZoneMapping(dTable.Rows(0).Item("CompanyTimeZone").ToString, True)
                        'txtTimeZone.Text = dTable.Rows(0).Item("CompanyTimeZone").ToString
                        txtDeliveryMin.Text = dTable.Rows(0).Item("CompanyDeliveryMin").ToString
                        txtDeliveryCharge.Text = dTable.Rows(0).Item("CompanyDeliveryCharge").ToString
                        txtReceiveOrderNumber.Text = dTable.Rows(0).Item("ReceiveOrderNumber").ToString

                        cboReceiveOrderType.Text = dTable.Rows(0).Item("ReceiveOrderType").ToString
                        chkHasLunchSpecial.Checked = dTable.Rows(0).Item("HasLunchSpecial")


                        txtStateTaxRate.Text = dTable.Rows(0).Item("StateTaxRate").ToString
                        chkIsDelivery.Checked = dTable.Rows(0).Item("IsDelivery")


                        chkIsCreditCard.Checked = dTable.Rows(0).Item("IsCreditCard")


                        txtEstimateDeliveryTime.Text = dTable.Rows(0).Item("EstimateDeliveryTime").ToString
                        txtRemotePrinter.Text = dTable.Rows(0).Item("RemotePrint").ToString
                        'txtCompanyOperation.Text = dTable.Rows(0).Item("CompanyBusinessHour").ToString


                        txtLastEmailPomotion.Text = dTable.Rows(0).Item("LastSentEMailPomotion").ToString

                        lblCompanyID.Text = "CompanyID: " & dTable.Rows(0).Item("CompanyID").ToString
                        lblCreateTime.Text = "Created: " & dTable.Rows(0).Item("CreatedTimeStamp").ToString
                        If dTable.Rows(0).Item("isInActive") Then
                            chkActiveRestaurant.Checked = False
                            lblRestaurantInactiveDate.Text = "InActive: " & dTable.Rows(0).Item("InActiveTime").ToString
                        Else
                            chkActiveRestaurant.Checked = True
                            lblRestaurantInactiveDate.Text = ""
                        End If
                        'chkActiveRestaurant.Checked = Not dTable.Rows(0).Item("isInActive")
                        'lblRestaurantInactiveDate.Text = IIf(dTable.Rows(0).Item("isInActive"), "", "InActive: " & dTable.Rows(0).Item("InActiveTime").ToString)
                        lblLastEditTime.Text = "LastUpdate: " & dTable.Rows(0).Item("LastEditTimeStamp").ToString


                        'txtLastEmailPomotion.Text = dTable.Rows(0).Item("IsDisplayToAll").ToString
                        'txtLastEmailPomotion.Text = dTable.Rows(0).Item("isSingleReceipt").ToString


                        'txtRemotePrinter.Text = dTable.Rows(0).Item("RemotePrint").ToString


                        chkIsCash.Checked = dTable.Rows(0).Item("isCash")
                        txtDeliveryDistance.Text = dTable.Rows(0).Item("deliveryDistance").ToString
                        txtSelectedDateClose.Text = dTable.Rows(0).Item("tempClosed").ToString

                        txtOrderEmail.Text = dTable.Rows(0).Item("OrderEmail").ToString
                        txtOrderEmailCC.Text = dTable.Rows(0).Item("OrderEmailCC").ToString
                        'txtOrderEmailBCC.Text = dTable.Rows(0).Item("OrderEmailBCC").ToString

                        txtWebLoginUserName.Text = dTable.Rows(0).Item("ContactEmail").ToString
                        txtWebLoginPassword.Text = dTable.Rows(0).Item("Password").ToString



                        txtLatitude.Text = dTable.Rows(0).Item("Latitude").ToString
                        txtLongittude.Text = dTable.Rows(0).Item("Longitude").ToString

                        cboReceiveOrderType.Text = dTable.Rows(0).Item("ReceiveOrderType").ToString

                        txtPlaceOrderAlertFromRestaurant.Text = dTable.Rows(0).Item("PlaceOrderAlertFromRestaurant").ToString

                        txtRestaurantAnnouncement.Text = dTable.Rows(0).Item("Announcement").ToString



                        FillDateTime(MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1), dTable.Rows(0).Item("CompanyBusinessHour").ToString, True)
                        FillDateTime(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1), dTable.Rows(0).Item("CompanyOperation").ToString)
                        FillDateTime(MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1), dTable.Rows(0).Item("LunchSpecialTime").ToString)
                        FillDateTime(MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1), dTable.Rows(0).Item("dinnerSpecialTime").ToString)

                        'txtPlaceOrderAlertFromRestaurant.Text = dTable.Rows(0).Item("Remarks").ToString
                        GetSetWebLogin(True, Val(marrCompanyID(cboCompanyName.SelectedIndex).ToString))


                        ' RestaurantPomotion
                        txtRegisterPomotionRate.Text = dTable.Rows(0).Item("RegisterSpecialRate").ToString
                        txtRegisterPomotionDescription.Text = dTable.Rows(0).Item("RegisterSpecialDesc").ToString
                        txtLoginPomotionRate.Text = dTable.Rows(0).Item("LoginSpecialRate").ToString
                        txtLoginPomotionDescription.Text = dTable.Rows(0).Item("LoginSpecialDesc").ToString


                        'Gateway Setup
                        'txtReceiveOrderBccEmail.Text = dTable.Rows(0).Item("EmailBCC").ToString
                        'txtSelectedDateClose.Text = dTable.Rows(0).Item("EmailBCC").ToString
                        txtCCPaymentType.Text = dTable.Rows(0).Item("CCPaymentType").ToString
                        txtCCUserName.Text = dTable.Rows(0).Item("ccUserName").ToString
                        txtCCPassword.Text = dTable.Rows(0).Item("ccPassword").ToString
                        txtPayeeToken.Text = dTable.Rows(0).Item("PayeeToken").ToString
                        txtKeyStoreName.Text = dTable.Rows(0).Item("keyStoreName").ToString
                        txtKeyStorePassword.Text = dTable.Rows(0).Item("keyStorePassword").ToString

                        'Payments and fees

                        txtBasicCharge.Text = dTable.Rows(0).Item("BasicCharge").ToString
                        txtMonthlyMin.Text = dTable.Rows(0).Item("MonthlyMin").ToString
                        chkisMinChargeCover.Checked = dTable.Rows(0).Item("IsMinChargeCover")
                        txtOrderPrice.Text = dTable.Rows(0).Item("OrderPrice").ToString
                        txtOrderPricePercentage.Text = dTable.Rows(0).Item("OrderPricePercent").ToString
                        chkIsByPercentage.Checked = dTable.Rows(0).Item("IsByPercent")

                        chkEnablePickupFee.Checked = dTable.Rows(0).Item("isPickupFee")
                        txtPickupFee.Text = dTable.Rows(0).Item("PickupFee").ToString

                        txtPaymentUserName.Text = dTable.Rows(0).Item("PaymentUserName").ToString
                        txtPaymentPassword.Text = dTable.Rows(0).Item("PaymentPassword").ToString


                        chkEnable321ChargeRestaurant.Checked = dTable.Rows(0).Item("isServiceFee")
                        chk321ChargeRestaurantChargeRestaurantByPercentage.Checked = dTable.Rows(0).Item("isServiceFeePercentage")
                        txt321ChargeRestaurantAmountChargePerOrder.Text = dTable.Rows(0).Item("ServiceFeeAmount").ToString
                        txt321ChargeRestaurantPercentageChargePerOrder.Text = dTable.Rows(0).Item("ServiceFeePercentage").ToString

                        chkEnableFeeToChargeTheirCustomer.Checked = dTable.Rows(0).Item("isCompanyCommissionPerOrder")
                        chkChargeTheirCustomerByPercentage.Checked = dTable.Rows(0).Item("isCompanyCommissionPerOrderPercentage")
                        txtChargeTheirCustomerAmountChagePerOrder.Text = dTable.Rows(0).Item("CompanyCommissionPerOrderAmount").ToString
                        txtChargeTheirCustomerPercentageChargePerOrder.Text = dTable.Rows(0).Item("CompanyCommissionPerOrderPercentage").ToString


                    End If
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            EnableEditGatewaySetting()
        End Try
    End Sub
    Private Sub Update_RestaurantInformation()
        Try
            Cursor = Cursors.WaitCursor


            Using mysqlconn = New MySqlConnection(DB.GetCurrentConnectionString)
                'Using cmd As New MySqlCommand("SELECT Column4_Name FROM name_list;", mysqlconn)
                '    mysqlconn.Open()
                '    dtBeforeUpdate.Load(cmd.ExecuteReader)
                '    mysqlconn.Close()
                'End Using
                Using cmd As New MySqlCommand($"UPDATE tbCompanyInfo  SET                    
                    CompanyName = @CompanyName,
                    CompanyAddress_1 = @CompanyAddress_1,
                    CompanyAddress_2 = @CompanyAddress_2,
                    CompanyAPT = @CompanyAPT,
                    CompanyCity = @CompanyCity,
                    CompanyState = @CompanyState,
                    CompanyZipCode = @CompanyZipCode,
                    CompanyZipEx = @CompanyZipEx,
                    AddressAdditionalInfo = @AddressAdditionalInfo,
                    CompanyPhone_1 = @CompanyPhone_1,
                    CompanyPhone_2 = @CompanyPhone_2,
                    CompanyFax = @CompanyFax,
                    CompanyWebsite = @CompanyWebsite,
                    CompanyEmail = @CompanyEmail,
                    LastEditTimeStamp = @LastEditTimeStamp,
                    ReceiveOrderNumber = @ReceiveOrderNumber,
                    CompanyTimeZone = @CompanyTimeZone,
                    CompanyOperation = @CompanyOperation,
                    CompanyDeliveryMin = @CompanyDeliveryMin,
                    CompanyDeliveryCharge = @CompanyDeliveryCharge,
                    LunchSpecialTime = @LunchSpecialTime,
                    Latitude = @Latitude,
                    Longitude = @Longitude,
                    ReceiveOrderType = @ReceiveOrderType,
                    HasLunchSpecial = @HasLunchSpecial,
                    MaxSpecialOption = @MaxSpecialOption,
                    StateTaxRate = @StateTaxRate,
                    IsDelivery = @IsDelivery,
                    IsCreditCard = @IsCreditCard,
                    EstimateDeliveryTime = @EstimateDeliveryTime,
                    RemotePrint = @RemotePrint,
                    PaymentUserName = @PaymentUserName,
                    PaymentPassword = @PaymentPassword,
                    PrintInvoice = @PrintInvoice,
                    MonthlyMin = @MonthlyMin,
                    OrderPrice = @OrderPrice,
                    OrderPricePercent = @OrderPricePercent,
                    IsByPercent = @IsByPercent,
                    IsMinChargeCover = @IsMinChargeCover,
                    BasicCharge = @BasicCharge,
                    IsDisplayToAll = @IsDisplayToAll,
                    isSingleReceipt = @isSingleReceipt,
                    RegisterSpecialRate = @RegisterSpecialRate,
                    RegisterSpecialDesc = @RegisterSpecialDesc,
                    LoginSpecialRate = @LoginSpecialRate,
                    LoginSpecialDesc = @LoginSpecialDesc,
                    CCPaymentType = @CCPaymentType,
                    PayeeToken = @PayeeToken,
                    keyStoreName = @keyStoreName,
                    ccUserName = @ccUserName,
                    isCash = @isCash,
                    deliveryDistance = @deliveryDistance,
                    keyStorePassword = @keyStorePassword,
                    tempClosed = @tempClosed,
                    ccPassword = @ccPassword,
                    dinnerSpecialTime = @dinnerSpecialTime,
                    CompanyBusinessHour = @CompanyBusinessHour,
                    OrderEmail = @OrderEmail,
                    OrderEmailCC = @OrderEmailCC,
                    Remarks = @Remarks,
                    isPickupFee = @isPickupFee,
                    PickupFee = @PickupFee,
                    isServiceFee = @isServiceFee,
                    isServiceFeePercentage = @isServiceFeePercentage,
                    ServiceFeeAmount = @ServiceFeeAmount,
                    ServiceFeePercentage = @ServiceFeePercentage,
                    isCompanyCommissionPerOrder = @isCompanyCommissionPerOrder,
                    isCompanyCommissionPerOrderPercentage = @isCompanyCommissionPerOrderPercentage,
                    CompanyCommissionPerOrderAmount = @CompanyCommissionPerOrderAmount,
                    CompanyCommissionPerOrderPercentage = @CompanyCommissionPerOrderPercentage,
                    Announcement = @Announcement,
                    PlaceOrderAlertFromRestaurant = @PlaceOrderAlertFromRestaurant
                    WHERE CompanyDomainName = @CompanyDomainName ",
                                              mysqlconn)
                    'cmd.Parameters.Add("CompanyID", MySqlDbType.String).Value =
                    cmd.Parameters.Add("CompanyName", MySqlDbType.String).Value = txtCompanyName.Text
                    cmd.Parameters.Add("CompanyAddress_1", MySqlDbType.String).Value = txtAddress1.Text
                    cmd.Parameters.Add("CompanyAddress_2", MySqlDbType.String).Value = txtAddress2.Text
                    cmd.Parameters.Add("CompanyAPT", MySqlDbType.String).Value = txtApt.Text
                    cmd.Parameters.Add("CompanyCity", MySqlDbType.String).Value = txtCity.Text
                    cmd.Parameters.Add("CompanyState", MySqlDbType.String).Value = txtState.Text
                    cmd.Parameters.Add("CompanyZipCode", MySqlDbType.String).Value = txtZipCode.Text
                    cmd.Parameters.Add("CompanyZipEx", MySqlDbType.String).Value = ""
                    cmd.Parameters.Add("AddressAdditionalInfo", MySqlDbType.String).Value = txtAddressAdditionalInfo.Text
                    cmd.Parameters.Add("CompanyPhone_1", MySqlDbType.String).Value = txtPhone1.Text
                    cmd.Parameters.Add("CompanyPhone_2", MySqlDbType.String).Value = txtPhone2.Text
                    cmd.Parameters.Add("CompanyFax", MySqlDbType.String).Value = txtFax.Text
                    cmd.Parameters.Add("CompanyWebsite", MySqlDbType.String).Value = txtWebsite.Text
                    cmd.Parameters.Add("CompanyEmail", MySqlDbType.String).Value = txtEmail.Text
                    'cmd.Parameters.Add("CreatedTimeStamp", MySqlDbType.TimeSteamp).Value =
                    cmd.Parameters.Add("LastEditTimeStamp", MySqlDbType.DateTime).Value = Now
                    'cmd.Parameters.Add("CompanyDomainName", MySqlDbType.String).Value =
                    cmd.Parameters.Add("ReceiveOrderNumber", MySqlDbType.String).Value = txtReceiveOrderNumber.Text
                    cmd.Parameters.Add("CompanyTimeZone", MySqlDbType.String).Value = TimeZoneMapping(cboTimeZone.Text)
                    cmd.Parameters.Add("CompanyOperation", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1))
                    cmd.Parameters.Add("CompanyDeliveryMin", MySqlDbType.Decimal).Value = Val(txtDeliveryMin.Text)
                    cmd.Parameters.Add("CompanyDeliveryCharge", MySqlDbType.Decimal).Value = Val(txtDeliveryCharge.Text)
                    cmd.Parameters.Add("LunchSpecialTime", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1))
                    cmd.Parameters.Add("Latitude", MySqlDbType.String).Value = Val(txtLatitude.Text)
                    cmd.Parameters.Add("Longitude", MySqlDbType.String).Value = Val(txtLongittude.Text)
                    cmd.Parameters.Add("ReceiveOrderType", MySqlDbType.String).Value = cboReceiveOrderType.Text
                    cmd.Parameters.Add("HasLunchSpecial", MySqlDbType.Bit).Value = IIf(chkHasLunchSpecial.Checked, 1, 0)
                    cmd.Parameters.Add("MaxSpecialOption", MySqlDbType.Int16).Value = 4
                    cmd.Parameters.Add("StateTaxRate", MySqlDbType.String).Value = Val(txtStateTaxRate.Text)
                    cmd.Parameters.Add("IsDelivery", MySqlDbType.Bit).Value = IIf(chkIsDelivery.Checked, 1, 0)
                    cmd.Parameters.Add("IsCreditCard", MySqlDbType.Bit).Value = IIf(chkIsCreditCard.Checked, 1, 0)
                    cmd.Parameters.Add("EstimateDeliveryTime", MySqlDbType.String).Value = txtEstimateDeliveryTime.Text
                    cmd.Parameters.Add("RemotePrint", MySqlDbType.String).Value = txtRemotePrinter.Text
                    cmd.Parameters.Add("PaymentUserName", MySqlDbType.String).Value = txtPaymentUserName.Text
                    cmd.Parameters.Add("PaymentPassword", MySqlDbType.String).Value = txtPaymentPassword.Text
                    cmd.Parameters.Add("PrintInvoice", MySqlDbType.Bit).Value = 1
                    cmd.Parameters.Add("MonthlyMin", MySqlDbType.Decimal).Value = Val(txtMonthlyMin.Text)
                    cmd.Parameters.Add("OrderPrice", MySqlDbType.Decimal).Value = Val(txtOrderPrice.Text)
                    cmd.Parameters.Add("OrderPricePercent", MySqlDbType.Float).Value = Val(txtOrderPricePercentage.Text)
                    cmd.Parameters.Add("IsByPercent", MySqlDbType.Bit).Value = IIf(chkIsByPercentage.Checked, 1, 0)
                    cmd.Parameters.Add("IsMinChargeCover", MySqlDbType.Bit).Value = IIf(chkisMinChargeCover.Checked, 1, 0)
                    cmd.Parameters.Add("BasicCharge", MySqlDbType.String).Value = Val(txtBasicCharge.Text)
                    'cmd.Parameters.Add("LastSentEMailPomotion", MySqlDbType.Date).Value =
                    cmd.Parameters.Add("IsDisplayToAll", MySqlDbType.Bit).Value = 1
                    cmd.Parameters.Add("isSingleReceipt", MySqlDbType.Bit).Value = 1
                    cmd.Parameters.Add("RegisterSpecialRate", MySqlDbType.Float).Value = Val(txtRegisterPomotionRate.Text)
                    cmd.Parameters.Add("RegisterSpecialDesc", MySqlDbType.String).Value = txtRegisterPomotionDescription.Text
                    cmd.Parameters.Add("LoginSpecialRate", MySqlDbType.Float).Value = Val(txtLoginPomotionRate.Text)
                    cmd.Parameters.Add("LoginSpecialDesc", MySqlDbType.String).Value = txtLoginPomotionDescription.Text
                    cmd.Parameters.Add("CCPaymentType", MySqlDbType.String).Value = txtCCPaymentType.Text
                    cmd.Parameters.Add("PayeeToken", MySqlDbType.String).Value = txtPayeeToken.Text
                    'cmd.Parameters.Add("EmailBCC", MySqlDbType.String).Value =txtOrderEmailBCC.Text
                    cmd.Parameters.Add("keyStoreName", MySqlDbType.String).Value = txtKeyStoreName.Text
                    cmd.Parameters.Add("ccUserName", MySqlDbType.String).Value = txtCCUserName.Text
                    cmd.Parameters.Add("isCash", MySqlDbType.Bit).Value = IIf(chkIsCash.Checked, 1, 0)
                    cmd.Parameters.Add("deliveryDistance", MySqlDbType.Float).Value = Val(txtDeliveryDistance.Text)
                    cmd.Parameters.Add("keyStorePassword", MySqlDbType.String).Value = txtKeyStorePassword.Text
                    cmd.Parameters.Add("tempClosed", MySqlDbType.String).Value = txtSelectedDateClose.Text
                    cmd.Parameters.Add("ccPassword", MySqlDbType.String).Value = txtCCPassword.Text
                    cmd.Parameters.Add("dinnerSpecialTime", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1))
                    cmd.Parameters.Add("CompanyBusinessHour", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1), , True)
                    cmd.Parameters.Add("OrderEmail", MySqlDbType.String).Value = txtOrderEmail.Text.Trim
                    cmd.Parameters.Add("OrderEmailCC", MySqlDbType.String).Value = txtOrderEmailCC.Text.Trim
                    'cmd.Parameters.Add("OrderEmailBCC", MySqlDbType.String).Value = txtOrderEmailBCC.Text.Trim
                    'cmd.Parameters.Add("OnlineOrderRefreshRateInMilliseconds", MySqlDbType.Int16).Value = 120000
                    cmd.Parameters.Add("Remarks", MySqlDbType.String).Value = ""
                    cmd.Parameters.Add("isPickupFee", MySqlDbType.Bit).Value = IIf(chkEnablePickupFee.Checked, 1, 0)
                    cmd.Parameters.Add("PickupFee", MySqlDbType.Decimal).Value = Val(txtPickupFee.Text)
                    'cmd.Parameters.Add("isInActive", MySqlDbType.Bit).Value = IIf(chkActiveRestaurant.Checked, 1, 0)
                    'cmd.Parameters.Add("InActiveTime", MySqlDbType.DateTime).Value = IIf(chkActiveRestaurant.Checked, 1, 0)
                    cmd.Parameters.Add("isServiceFee", MySqlDbType.Bit).Value = IIf(chkEnableFeeToChargeTheirCustomer.Checked, 1, 0)
                    cmd.Parameters.Add("isServiceFeePercentage", MySqlDbType.Bit).Value = IIf(chk321ChargeRestaurantChargeRestaurantByPercentage.Checked, 1, 0)
                    cmd.Parameters.Add("ServiceFeeAmount", MySqlDbType.Float).Value = Val(txt321ChargeRestaurantAmountChargePerOrder.Text)
                    cmd.Parameters.Add("ServiceFeePercentage", MySqlDbType.Float).Value = Val(txt321ChargeRestaurantPercentageChargePerOrder.Text)
                    cmd.Parameters.Add("isCompanyCommissionPerOrder", MySqlDbType.Bit).Value = IIf(chkEnableFeeToChargeTheirCustomer.Checked, 1, 0)
                    cmd.Parameters.Add("isCompanyCommissionPerOrderPercentage", MySqlDbType.Bit).Value = IIf(chkChargeTheirCustomerByPercentage.Checked, 1, 0)
                    cmd.Parameters.Add("CompanyCommissionPerOrderAmount", MySqlDbType.Float).Value = Val(txtChargeTheirCustomerAmountChagePerOrder.Text)
                    cmd.Parameters.Add("CompanyCommissionPerOrderPercentage", MySqlDbType.Float).Value = Val(txtChargeTheirCustomerPercentageChargePerOrder.Text)
                    cmd.Parameters.Add("Announcement", MySqlDbType.String).Value = txtRestaurantAnnouncement.Text.Trim
                    cmd.Parameters.Add("PlaceOrderAlertFromRestaurant", MySqlDbType.String).Value = txtPlaceOrderAlertFromRestaurant.Text.Trim
                    cmd.Parameters.Add("CompanyDomainName", MySqlDbType.String).Value = txtDomainName.Text
                    Try
                        mysqlconn.Open()
                        If cmd.ExecuteNonQuery = 1 Then
                            MessageBox.Show("Successfully updated restaurant information", "Successfully Updated Restaurant Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Faild update restaurant information", "Faild Update Restaurant Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        cmd.ExecuteNonQuery()
                        mysqlconn.Close()
                    Catch ex As Exception
                        MessageBox.Show("Update_RestaurantInformation Query Error" & vbNewLine & vbNewLine & ex.Message)
                        ActionLog(Me.Name, txtCompanyName.Text, "RestaurantInformation", "", "", "Error - Restaurant Information Query" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                        LogToSystemEvent(gsApplicationClientID, Me.Name, "Update_RestaurantInformation Query - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                    End Try

                End Using
            End Using
            '$$$$$$$$$$$$, Old code from 2010.
            'DB.CreateConnection(cboDatabase.Text)
            'Dim cmd As New MySqlCommand 'Create command
            'cmd.Connection = DB.conn    'Inert connection string
            'cmd.CommandText = "spUpdate_RestaurantInfo"   'insert SP Name
            'cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            'cmd.Parameters.Clear()
            'Try

            '    cmd.Parameters.AddWithValue("iCompanyID", Val(txtCompanyName.Tag))
            '    cmd.Parameters.AddWithValue("sCompanyName", txtCompanyName.Text)
            '    cmd.Parameters.AddWithValue("sCompanyAddress_1", txtAddress1.Text)
            '    cmd.Parameters.AddWithValue("sCompanyAddress_2", txtAddress2.Text)
            '    cmd.Parameters.AddWithValue("sCompanyAPT", txtApt.Text)

            '    cmd.Parameters.AddWithValue("sCompanyCity", txtCity.Text)
            '    cmd.Parameters.AddWithValue("sCompanyState", txtState.Text)
            '    cmd.Parameters.AddWithValue("sCompanyZipCode", txtZipCode.Text)
            '    cmd.Parameters.AddWithValue("sCompanyZipEx", "")
            '    cmd.Parameters.AddWithValue("sAddressAdditionalInfo", txtAddressAdditionalInfo.Text)

            '    cmd.Parameters.AddWithValue("sCompanyPhone_1", txtPhone1.Text)
            '    cmd.Parameters.AddWithValue("sCompanyPhone_2", txtPhone2.Text)
            '    cmd.Parameters.AddWithValue("sCompanyFax", txtFax.Text)
            '    cmd.Parameters.AddWithValue("sCompanyWebsite", txtWebsite.Text)
            '    cmd.Parameters.AddWithValue("sCompanyEmail", txtEmail.Text)

            '    cmd.Parameters.AddWithValue("dsCreatedTimeStamp", Now)


            '    cmd.Parameters.AddWithValue("dtLastEditTimeStamp", Now)
            '    cmd.Parameters.AddWithValue("sCompanyDomainName", txtDomainName.Text)
            '    cmd.Parameters.AddWithValue("sReceiveOrderNumber", txtReceiveOrderNumber.Text)
            '    'cmd.Parameters.AddWithValue("sCompanyTimeZone", txtTimeZone.Text)
            '    cmd.Parameters.AddWithValue("sCompanyOperation", GetDateTimeInString(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1)))

            '    cmd.Parameters.AddWithValue("dCompanyDeliveryMin", Val(txtDeliveryMin.Text))
            '    cmd.Parameters.AddWithValue("dCompanyDeliveryCharge", Val(txtDeliveryCharge.Text))
            '    cmd.Parameters.AddWithValue("sLunchSpecialTime", GetDateTimeInString(MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1)))
            '    cmd.Parameters.AddWithValue("sLatitude", txtLatitude.Text)
            '    cmd.Parameters.AddWithValue("sLongitude", txtLongittude.Text)

            '    cmd.Parameters.AddWithValue("sReceiveOrderType", txtReceiveOrderNumber.Text)
            '    cmd.Parameters.AddWithValue("bHasLunchSpecial", IIf(chkHasLunchSpecial.Checked, 1, 0))
            '    cmd.Parameters.AddWithValue("iMaxSpecialOption", Val(0))
            '    cmd.Parameters.AddWithValue("fStateTaxRate", Val(txtStateTaxRate.Text))
            '    cmd.Parameters.AddWithValue("bIsDelivery", IIf(chkIsDelivery.Checked, 1, 0))

            '    cmd.Parameters.AddWithValue("bIsCreditCard", IIf(chkIsCreditCard.Checked, 1, 0))
            '    cmd.Parameters.AddWithValue("sEstimateDeliveryTime", txtEstimateDeliveryTime.Text)
            '    cmd.Parameters.AddWithValue("sRemotePrint", txtRemotePrinter.Text)
            '    cmd.Parameters.AddWithValue("sPaymentUserName", txtPaymentUserName.Text)
            '    cmd.Parameters.AddWithValue("sPaymentPassword", txtPaymentPassword.Text)

            '    cmd.Parameters.AddWithValue("bPrintInvoice", 1)
            '    cmd.Parameters.AddWithValue("dMonthlyMin", Val(txtMonthlyMin.Text))
            '    cmd.Parameters.AddWithValue("dOrderPrice", Val(txtOrderPrice.Text))
            '    cmd.Parameters.AddWithValue("fOrderPricePercent", Val(txtOrderPricePercentage.Text))
            '    cmd.Parameters.AddWithValue("bIsByPercent", IIf(chkIsByPercentage.Checked, 1, 0))

            '    cmd.Parameters.AddWithValue("bIsMinChargeCover", IIf(chkisMinChargeCover.Checked, 1, 0))
            '    cmd.Parameters.AddWithValue("dBasicCharge", Val(txtBasicCharge.Text))
            '    cmd.Parameters.AddWithValue("bIsDisplayToAll", 1)
            '    cmd.Parameters.AddWithValue("bisSingleReceipt", 1)
            '    cmd.Parameters.AddWithValue("fRegisterSpecialRate", Val(txtRegisterPomotionRate.Text))

            '    cmd.Parameters.AddWithValue("sRegisterSpecialDesc", txtRegisterPomotionDescription.Text)
            '    cmd.Parameters.AddWithValue("dLoginSpecialRate", Val(txtLoginPomotionRate.Text))
            '    cmd.Parameters.AddWithValue("sLoginSpecialDesc", txtLoginPomotionDescription.Text)
            '    cmd.Parameters.AddWithValue("sCCPaymentType", txtCCPaymentType.Text)
            '    cmd.Parameters.AddWithValue("sPayeeToken", txtPayeeToken.Text)

            '    'cmd.Parameters.AddWithValue("sEmailBCC", txtOrderEmailBCC.Text)
            '    cmd.Parameters.AddWithValue("skeyStoreName", txtKeyStoreName.Text)
            '    cmd.Parameters.AddWithValue("sccUserName", txtCCUserName.Text)
            '    cmd.Parameters.AddWithValue("bisCash", IIf(chkIsCash.Checked, 1, 0))
            '    cmd.Parameters.AddWithValue("fdeliveryDistance", Val(txtDeliveryDistance.Text))

            '    cmd.Parameters.AddWithValue("sKeyStorePassword", txtKeyStorePassword.Text)
            '    cmd.Parameters.AddWithValue("stempClosed", txtSelectedDateClose.Text)
            '    cmd.Parameters.AddWithValue("sccPassword", txtCCPassword.Text)
            '    cmd.Parameters.AddWithValue("sdinnerSpecialTime", GetDateTimeInString(MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1)))
            '    cmd.Parameters.AddWithValue("sCompanyBusinessHour", GetDateTimeInString(MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1), , True))


            '    cmd.Parameters.AddWithValue("sOrderEmail", txtOrderEmail.Text.Trim)
            '    cmd.Parameters.AddWithValue("sOrderEmailCC", txtOrderEmailCC.Text.Trim)
            '    'cmd.Parameters.AddWithValue("sOrderEmailBCC", txtOrderEmailBCC.Text.Trim)
            '    cmd.Parameters.AddWithValue("sCompanyRemarks", txtCompanyWebRemarks.Text.Trim)
            '    cmd.ExecuteNonQuery()
            'Catch ex As Exception
            '        MessageBox.Show(ex.Message)
            '    End Try

        Catch ex As Exception
            MessageBox.Show("Update_RestaurantInformation Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, "RestaurantInformation", "", "", "Error - Restaurant Information" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "Update_RestaurantInformation - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    'Private Sub Update_RestaurantInformation()
    '    Try
    '        Cursor = Cursors.WaitCursor


    '        Using mysqlconn = New MySqlConnection(DB.GetCurrentConnectionString)
    '            'Using cmd As New MySqlCommand("SELECT Column4_Name FROM name_list;", mysqlconn)
    '            '    mysqlconn.Open()
    '            '    dtBeforeUpdate.Load(cmd.ExecuteReader)
    '            '    mysqlconn.Close()
    '            'End Using
    '            Using cmd As New MySqlCommand($"UPDATE tbCompanyInfo  SET                    
    '                ,CompanyName = @CompanyName
    '                ,CompanyAddress_1 = @CompanyAddress_1
    '                ,CompanyAddress_2 = @CompanyAddress_2
    '                ,CompanyAPT = @CompanyAPT
    '                ,CompanyCity = @CompanyCity
    '                ,CompanyState = @CompanyState
    '                ,CompanyZipCode = @CompanyZipCode
    '                ,CompanyZipEx = @CompanyZipEx
    '                ,AddressAdditionalInfo = @AddressAdditionalInfo
    '                ,CompanyPhone_1 = @CompanyPhone_1
    '                ,CompanyPhone_2 = @CompanyPhone_2
    '                ,CompanyFax = @CompanyFax
    '                ,CompanyWebsite = @CompanyWebsite
    '                ,CompanyEmail = @CompanyEmail
    '                ,CompanyDomainName = @CompanyDomainName
    '                ,ReceiveOrderNumber = @ReceiveOrderNumber
    '                ,CompanyTimeZone = @CompanyTimeZone
    '                ,CompanyOperation = @CompanyOperation
    '                ,CompanyDeliveryMin = @CompanyDeliveryMin
    '                ,CompanyDeliveryCharge = @CompanyDeliveryCharge
    '                ,LunchSpecialTime = @LunchSpecialTime
    '                ,Latitude = @Latitude
    '                ,Longitude = @Longitude
    '                ,ReceiveOrderType = @ReceiveOrderType
    '                ,HasLunchSpecial = @HasLunchSpecial
    '                ,StateTaxRate = @StateTaxRate
    '                ,IsDelivery = @IsDelivery
    '                ,IsCreditCard = @IsCreditCard
    '                ,EstimateDeliveryTime = @EstimateDeliveryTime
    '                ,RemotePrint = @RemotePrint
    '                ,PaymentUserName = @PaymentUserName
    '                ,PaymentPassword = @PaymentPassword
    '                ,PrintInvoice = @PrintInvoice
    '                ,MonthlyMin = @MonthlyMin
    '                ,OrderPrice = @OrderPrice
    '                ,OrderPricePercent = @OrderPricePercent
    '                ,IsByPercent = @IsByPercent
    '                ,IsMinChargeCover = @IsMinChargeCover
    '                ,BasicCharge = @BasicCharge
    '                ,IsDisplayToAll = @IsDisplayToAll
    '                ,isSingleReceipt = @isSingleReceipt
    '                ,RegisterSpecialRate = @RegisterSpecialRate
    '                ,RegisterSpecialDesc = @RegisterSpecialDesc
    '                ,LoginSpecialRate = @LoginSpecialRate
    '                ,LoginSpecialDesc = @LoginSpecialDesc
    '                ,CCPaymentType = @CCPaymentType
    '                ,PayeeToken = @PayeeToken
    '                ,keyStoreName = @keyStoreName
    '                ,ccUserName = @ccUserName
    '                ,isCash = @isCash
    '                ,deliveryDistance = @deliveryDistance
    '                ,keyStorePassword = @keyStorePassword
    '                ,tempClosed = @tempClosed
    '                ,ccPassword = @ccPassword
    '                ,dinnerSpecialTime = @dinnerSpecialTime
    '                ,CompanyBusinessHour = @CompanyBusinessHour
    '                ,OrderEmail = @OrderEmail
    '                ,OrderEmailCC = @OrderEmailCC
    '                ,Remarks = @Remarks
    '                ,isPickupFee = @isPickupFee
    '                ,PickupFee = @PickupFee
    '                ,isServiceFee = @isServiceFee
    '                ,isServiceFeePercentage = @isServiceFeePercentage
    '                ,ServiceFeeAmount = @ServiceFeeAmount
    '                ,ServiceFeePercentage = @ServiceFeePercentage
    '                ,isCompanyCommissionPerOrder = @isCompanyCommissionPerOrder
    '                ,isCompanyCommissionPerOrderPercentage = @isCompanyCommissionPerOrderPercentage
    '                ,CompanyCommissionPerOrderAmount = @CompanyCommissionPerOrderAmount
    '                ,CompanyCommissionPerOrderPercentage = @CompanyCommissionPerOrderPercentage
    '                ,Announcement = @Announcement
    '                ,PlaceOrderAlertFromRestaurant = @PlaceOrderAlertFromRestaurant

    '                WHERE CompanyDomainName = @CompanyDomainName ",
    '                                          mysqlconn)
    '                cmd.Parameters.Add("CompanyName", MySqlDbType.String).Value = txtCompanyName.Text
    '                cmd.Parameters.Add("CompanyAddress_1", MySqlDbType.String).Value = txtAddress1.Text
    '                cmd.Parameters.Add("CompanyAddress_2", MySqlDbType.String).Value = txtAddress2.Text
    '                cmd.Parameters.Add("CompanyAPT", MySqlDbType.String).Value = txtApt.Text
    '                cmd.Parameters.Add("CompanyCity", MySqlDbType.String).Value = txtCity.Text
    '                cmd.Parameters.Add("CompanyState", MySqlDbType.String).Value = txtState.Text
    '                cmd.Parameters.Add("CompanyZipCode", MySqlDbType.String).Value = txtZipCode.Text
    '                cmd.Parameters.Add("CompanyZipEx", MySqlDbType.String).Value = ""
    '                cmd.Parameters.Add("AddressAdditionalInfo", MySqlDbType.String).Value = txtAddressAdditionalInfo.Text
    '                cmd.Parameters.Add("CompanyPhone_1", MySqlDbType.String).Value = txtPhone1.Text
    '                cmd.Parameters.Add("CompanyPhone_2", MySqlDbType.String).Value = txtPhone2.Text
    '                cmd.Parameters.Add("CompanyFax", MySqlDbType.String).Value = txtFax.Text
    '                cmd.Parameters.Add("CompanyWebsite", MySqlDbType.String).Value = txtWebsite.Text
    '                cmd.Parameters.Add("CompanyEmail", MySqlDbType.String).Value = txtEmail.Text
    '                'cmd.Parameters.Add("CreatedTimeStamp", MySqlDbType.Timestamp).Value = txtCompanyName.Text
    '                'cmd.Parameters.Add("LastEditTimeStamp", MySqlDbType.DateTime).Value = txtCompanyName.Text
    '                cmd.Parameters.Add("ReceiveOrderNumber", MySqlDbType.String).Value = txtReceiveOrderNumber.Text
    '                cmd.Parameters.Add("CompanyTimeZone", MySqlDbType.String).Value = TimeZoneMapping(cboTimeZone.Text)
    '                cmd.Parameters.Add("CompanyOperation", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1))
    '                cmd.Parameters.Add("CompanyDeliveryMin", MySqlDbType.Decimal).Value = Val(txtDeliveryMin.Text)
    '                cmd.Parameters.Add("CompanyDeliveryCharge", MySqlDbType.Decimal).Value = Val(txtDeliveryCharge.Text)
    '                cmd.Parameters.Add("LunchSpecialTime", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1))
    '                cmd.Parameters.Add("Latitude", MySqlDbType.String).Value = Val(txtLatitude.Text)
    '                cmd.Parameters.Add("Longitude", MySqlDbType.String).Value = Val(txtLongittude.Text)
    '                cmd.Parameters.Add("ReceiveOrderType", MySqlDbType.String).Value = cboReceiveOrderType.Text
    '                cmd.Parameters.Add("HasLunchSpecial", MySqlDbType.Bit).Value = IIf(chkHasLunchSpecial.Checked, 1, 0)
    '                'cmd.Parameters.Add("MaxSpecialOption", MySqlDbType.Int16).Value =
    '                cmd.Parameters.Add("StateTaxRate", MySqlDbType.String).Value = Val(txtStateTaxRate.Text)
    '                cmd.Parameters.Add("IsDelivery", MySqlDbType.Bit).Value = IIf(chkIsDelivery.Checked, 1, 0)
    '                cmd.Parameters.Add("IsCreditCard", MySqlDbType.Bit).Value = IIf(chkIsCreditCard.Checked, 1, 0)
    '                cmd.Parameters.Add("EstimateDeliveryTime", MySqlDbType.String).Value = txtEstimateDeliveryTime.Text
    '                cmd.Parameters.Add("RemotePrint", MySqlDbType.String).Value = txtRemotePrinter.Text
    '                cmd.Parameters.Add("PaymentUserName", MySqlDbType.String).Value = txtPaymentUserName.Text
    '                cmd.Parameters.Add("PaymentPassword", MySqlDbType.String).Value = txtPaymentPassword.Text
    '                cmd.Parameters.Add("PrintInvoice", MySqlDbType.Bit).Value = 1
    '                cmd.Parameters.Add("MonthlyMin", MySqlDbType.Decimal).Value = Val(txtMonthlyMin.Text)
    '                cmd.Parameters.Add("OrderPrice", MySqlDbType.Decimal).Value = Val(txtOrderPrice.Text)
    '                cmd.Parameters.Add("OrderPricePercent", MySqlDbType.Float).Value = Val(txtOrderPricePercentage.Text)
    '                cmd.Parameters.Add("IsByPercent", MySqlDbType.Bit).Value = IIf(chkIsByPercentage.Checked, 1, 0)
    '                cmd.Parameters.Add("IsMinChargeCover", MySqlDbType.Bit).Value = IIf(chkisMinChargeCover.Checked, 1, 0)
    '                cmd.Parameters.Add("BasicCharge", MySqlDbType.String).Value = Val(txtBasicCharge.Text)
    '                'cmd.Parameters.Add("LastSentEMailPomotion", MySqlDbType.Date).Value =
    '                cmd.Parameters.Add("IsDisplayToAll", MySqlDbType.Bit).Value = 1
    '                cmd.Parameters.Add("isSingleReceipt", MySqlDbType.Bit).Value = 1
    '                cmd.Parameters.Add("RegisterSpecialRate", MySqlDbType.Float).Value = Val(txtRegisterPomotionRate.Text)
    '                cmd.Parameters.Add("RegisterSpecialDesc", MySqlDbType.String).Value = txtRegisterPomotionDescription.Text
    '                cmd.Parameters.Add("LoginSpecialRate", MySqlDbType.Float).Value = Val(txtLoginPomotionRate.Text)
    '                cmd.Parameters.Add("LoginSpecialDesc", MySqlDbType.String).Value = txtLoginPomotionDescription.Text
    '                cmd.Parameters.Add("CCPaymentType", MySqlDbType.String).Value = txtCCPaymentType.Text
    '                cmd.Parameters.Add("PayeeToken", MySqlDbType.String).Value = txtPayeeToken.Text
    '                'cmd.Parameters.Add("EmailBCC", MySqlDbType.String).Value =txtOrderEmailBCC.Text
    '                cmd.Parameters.Add("keyStoreName", MySqlDbType.String).Value = txtKeyStoreName.Text
    '                cmd.Parameters.Add("ccUserName", MySqlDbType.String).Value = txtCCUserName.Text
    '                cmd.Parameters.Add("isCash", MySqlDbType.Bit).Value = IIf(chkIsCash.Checked, 1, 0)
    '                cmd.Parameters.Add("deliveryDistance", MySqlDbType.Float).Value = Val(txtDeliveryDistance.Text)
    '                cmd.Parameters.Add("keyStorePassword", MySqlDbType.String).Value = txtKeyStorePassword.Text
    '                cmd.Parameters.Add("tempClosed", MySqlDbType.String).Value = txtSelectedDateClose.Text
    '                cmd.Parameters.Add("ccPassword", MySqlDbType.String).Value = txtCCPassword.Text
    '                cmd.Parameters.Add("dinnerSpecialTime", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1))
    '                cmd.Parameters.Add("CompanyBusinessHour", MySqlDbType.String).Value = GetDateTimeInString(MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1), , True)
    '                cmd.Parameters.Add("OrderEmail", MySqlDbType.String).Value = txtOrderEmail.Text.Trim
    '                cmd.Parameters.Add("OrderEmailCC", MySqlDbType.String).Value = txtOrderEmailCC.Text.Trim
    '                'cmd.Parameters.Add("OrderEmailBCC", MySqlDbType.String).Value = txtOrderEmailBCC.Text.Trim
    '                'cmd.Parameters.Add("OnlineOrderRefreshRateInMilliseconds", MySqlDbType.Int16).Value = 120000
    '                cmd.Parameters.Add("Remarks", MySqlDbType.String).Value = txtPlaceOrderAlertFromRestaurant.Text.Trim
    '                cmd.Parameters.Add("isPickupFee", MySqlDbType.Bit).Value = IIf(chkEnablePickupFee.Checked, 1, 0)
    '                cmd.Parameters.Add("PickupFee", MySqlDbType.Decimal).Value = Val(txtPickupFee.Text)
    '                'cmd.Parameters.Add("isInActive", MySqlDbType.Bit).Value = IIf(chkActiveRestaurant.Checked, 1, 0)
    '                'cmd.Parameters.Add("InActiveTime", MySqlDbType.DateTime).Value = IIf(chkActiveRestaurant.Checked, "NULL", "GETDATE()")
    '                cmd.Parameters.Add("isServiceFee", MySqlDbType.Bit).Value = IIf(chkEnableFeeToChargeTheirCustomer.Checked, 1, 0)
    '                cmd.Parameters.Add("isServiceFeePercentage", MySqlDbType.Bit).Value = IIf(chk321ChargeRestaurantChargeRestaurantByPercentage.Checked, 1, 0)
    '                cmd.Parameters.Add("ServiceFeeAmount", MySqlDbType.Float).Value = Val(txtChargeTheirCustomerAmountChagePerOrder.Text)
    '                cmd.Parameters.Add("ServiceFeePercentage", MySqlDbType.Float).Value = Val(txtChargeTheirCustomerPercentageChargePerOrder.Text)
    '                cmd.Parameters.Add("isCompanyCommissionPerOrder", MySqlDbType.Bit).Value = IIf(chkEnableFeeToChargeTheirCustomer.Checked, 1, 0)
    '                cmd.Parameters.Add("isCompanyCommissionPerOrderPercentage", MySqlDbType.Bit).Value = IIf(chkEnableFeeToChargeTheirCustomer.Checked, 1, 0)
    '                cmd.Parameters.Add("CompanyCommissionPerOrderAmount", MySqlDbType.Float).Value = Val(txt321ChargeRestaurantAmountChargePerOrder.Text)
    '                cmd.Parameters.Add("CompanyCommissionPerOrderPercentage", MySqlDbType.Float).Value = Val(txt321ChargeRestaurantPercentageChargePerOrder.Text)
    '                cmd.Parameters.Add("Announcement", MySqlDbType.String).Value = txtRestaurantAnnouncement.Text.Trim
    '                cmd.Parameters.Add("PlaceOrderAlertFromRestaurant", MySqlDbType.String).Value = txtPlaceOrderAlertFromRestaurant.Text
    '                cmd.Parameters.Add("CompanyDomainName", MySqlDbType.String).Value = txtDomainName.Text
    '                Try
    '                    mysqlconn.Open()
    '                    If cmd.ExecuteNonQuery() = 1 Then
    '                        MessageBox.Show("Successfully update restaurant information.", "Successfully update restaurant information.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Else
    '                        MessageBox.Show("Unablet to update restaruant information", "Unablet to update restaruant information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    End If

    '                Catch ex As Exception
    '                    MessageBox.Show(ex.Message)
    '                Finally
    '                    mysqlconn.Close()
    '                End Try
    '            End Using
    '        End Using
    '        ' MessageBox.Show("Successfully updated FoodType", "Successfully updated FoodType", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MessageBox.Show("Update_RestaurantInformation Error" & vbNewLine & vbNewLine & ex.Message)
    '        ActionLog(Me.Name, txtCompanyName.Text, "RestaurantInformation", "", "", "Error - Restaurant Information" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
    '        LogToSystemEvent(gsApplicationClientID, Me.Name, "Update_RestaurantInformation - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
    '    Finally
    '        Cursor = Cursors.Default
    '    End Try
    'End Sub
    Private Sub Update_FoodType()
        Try
            Cursor = Cursors.WaitCursor
            Dim bUpdate As Boolean = False
            Dim bResult As Boolean = True
            Dim dTable = MyGrid_FoodType.AC_GridDataSet.Tables(MyGrid_FoodType.AC_GridDataSet.Tables.Count - 1).GetChanges
            If Not dTable Is Nothing Then
                If dTable.Rows.Count > 0 Then

                    DB.CreateConnection(cboDatabase.Text)
                    Dim cmd As New MySqlCommand 'Create command
                    cmd.Connection = DB.conn    'Inert connection string
                    cmd.CommandText = "spUpdate_FoodType"   'insert SP Name
                    cmd.CommandType = CommandType.StoredProcedure   'select try as sp

                    For Each dRow As DataRow In dTable.Rows
                        bUpdate = False
                        cmd.Parameters.Clear()
                        If dRow.RowState = DataRowState.Added Then
                            bUpdate = True
                            cmd.Parameters.AddWithValue("sAction", "ADD")
                        ElseIf dRow.RowState = DataRowState.Modified Then
                            bUpdate = True
                            cmd.Parameters.AddWithValue("sAction", "UPDATE")
                        End If
                        If bUpdate = True Then
                            Try
                                cmd.Parameters.AddWithValue("iCompanyID", Val(marrCompanyID(cboCompanyName.SelectedIndex).ToString))
                                cmd.Parameters.AddWithValue("iFoodTypeID", dRow("FoodTypeID").ToString)
                                cmd.Parameters.AddWithValue("sFoodTypeDesc", dRow("Description").ToString)
                                cmd.Parameters.AddWithValue("sOldFoodType", dRow("FoodType", DataRowVersion.Original).ToString)
                                cmd.Parameters.AddWithValue("sNewFoodType", dRow("FoodType").ToString)
                                cmd.Parameters.AddWithValue("sDisplayOrder", dRow("DisplayOrder").ToString)
                                cmd.ExecuteNonQuery()
                            Catch ex As MySqlException
                                bResult = False
                                MessageBox.Show("Update_FoodType Error" & vbNewLine & vbNewLine & ex.Message)
                                ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - Update_FoodType" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                LogToSystemEvent(gsApplicationClientID, Me.Name, "Update_FoodType - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                            End Try
                        Else
                            If dRow.RowState = DataRowState.Deleted Then
                                bUpdate = True
                                cmd.Parameters.AddWithValue("sAction", "DELETE")
                                Try
                                    cmd.Parameters.AddWithValue("iCompanyID", Val(marrCompanyID(cboCompanyName.SelectedIndex).ToString))
                                    cmd.Parameters.AddWithValue("iFoodTypeID", dRow("FoodTypeID", DataRowVersion.Original).ToString)
                                    cmd.Parameters.AddWithValue("sFoodTypeDesc", dRow("Description", DataRowVersion.Original).ToString)
                                    cmd.Parameters.AddWithValue("sOldFoodType", dRow("FoodType", DataRowVersion.Original).ToString)
                                    cmd.Parameters.AddWithValue("sNewFoodType", dRow("FoodType", DataRowVersion.Original).ToString)
                                    cmd.Parameters.AddWithValue("sDisplayOrder", dRow("DisplayOrder", DataRowVersion.Original).ToString)
                                    cmd.ExecuteNonQuery()
                                Catch ex As MySqlException
                                    bResult = False
                                    MessageBox.Show("Delete_FoodType Error" & vbNewLine & vbNewLine & ex.Message)
                                    ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - Update_FoodType" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                    LogToSystemEvent(gsApplicationClientID, Me.Name, "Update_FoodType - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                                End Try
                            End If

                        End If


                    Next
                    If bResult Then
                        GetRestaurantMenu(marrCompanyID(cboCompanyName.SelectedIndex))
                        MessageBox.Show("Successfully updated FoodType", "Successfully updated FoodType", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Unable to add/update one or more item!!", "Add/Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Update_FoodType Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - Update_FoodType" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "Update_FoodType - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSaveFoodType_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveFoodType.Click
        Update_FoodType()
    End Sub

    Private Sub btnRefreshMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshMenu.Click
        GetRestaurantMenu(marrCompanyID(cboCompanyName.SelectedIndex))
        GetFoodType(marrCompanyID(cboCompanyName.SelectedIndex))
    End Sub

    Private Sub MyGrid_Menu_DoubleClick(sender As Object, e As System.EventArgs) Handles MyGrid_Menu.DoubleClick
        Try
            If cboDatabase.SelectedIndex = 1 And Not mbProcessCodeEntered Then
                If InputBox("Please enter access code for product restaurant menu change!", "Confirm Production Menu Access").ToUpper <> "PROCESSPRODUCTION" Then Exit Sub
                mbProcessCodeEntered = True
            End If
            If Not MyGrid_Menu.CheckFilterFocused Then
                Using frm As New frm_OnlineOrderEditMenu
                    frm.SetDatabaseConnection = cboDatabase.Text
                    frm.SetCompanyID = Val(MyGrid_Menu.Columns("CompanyID").Value.ToString)
                    frm.SetRestaurantMenuIndex = Val(MyGrid_Menu.Columns("RestaurantMenuID").Value.ToString)
                    frm.ShowDialog()
                End Using
                GetRestaurantMenu(marrCompanyID(cboCompanyName.SelectedIndex))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnNewDish_Click(sender As System.Object, e As System.EventArgs) Handles btnNewDish.Click
        Try
            If Not MyGrid_Menu.CheckFilterFocused Then
                Using frm As New frm_OnlineOrderEditMenu
                    frm.SetDatabaseConnection = cboDatabase.Text
                    frm.SetCompanyID = Val(MyGrid_Menu.Columns("CompanyID").Value.ToString)
                    frm.SetNewDish = True
                    frm.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSaveBusinessHour_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveBusinessHour.Click
        'GetDateTimeInString(MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1), " ")
        FillDateTime(MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1), "Sunday|10:00AM - 11:00PM$Monday|10:00AM - 11:00PM$Tuesday|10:00AM - 11:00PM$Wednesday|10:00AM - 11:00PM$Thursday|10:00AM - 11:00PM$Friday|10:00AM - 11:00PM$Saturday|10:00AM - 11:00PM", True)
    End Sub

    Private Sub btnCopyFromRestaurantBusinessHour_Click(sender As System.Object, e As System.EventArgs) Handles btnCopyFromRestaurantBusinessHour.Click
        FillDateTime(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1), "Sunday|10:00AM - 11:00PM$Monday|10:00AM - 11:00PM$Tuesday|10:00AM - 11:00PM$Wednesday|10:00AM - 11:00PM$Thursday|10:00AM - 11:00PM$Friday|10:00AM - 11:00PM$Saturday|10:00AM - 11:00PM")
    End Sub

    Private Sub btnLunchSpecialCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnLunchSpecialCopy.Click
        FillDateTime(MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1), GetDateTimeInString(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1)))
    End Sub

    Private Sub btnDinnerSpecailCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnDinnerSpecailCopy.Click
        FillDateTime(MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1), GetDateTimeInString(MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1)))
    End Sub

    Private Sub btnClearSelectedCloseDate_Click(sender As System.Object, e As System.EventArgs) Handles btnClearSelectedCloseDate.Click
        txtSelectedDateClose.Text = ""
    End Sub

    Private Sub btnEnableEditGatewaySetup_Click(sender As System.Object, e As System.EventArgs) Handles btnEnableEditGatewaySetup.Click
        If InputBox("Please enter passcode before edit!", "Confrim Edit Gateway Setting", "Passcode") = "Testing" Then
            EnableEditGatewaySetting(True)
            MsgBox("Enabled Edit")
        Else
            MsgBox("You do not have right to edit Gateway Setting!", MsgBoxStyle.OkOnly, "Unable To Edit Gateway Setting")
        End If
    End Sub
    Private Sub EnableEditGatewaySetting(Optional bEnableEdit As Boolean = False)
        Try
            txtCCPaymentType.Enabled = bEnableEdit
            txtCCUserName.Enabled = bEnableEdit
            txtCCPassword.Enabled = bEnableEdit
            txtPayeeToken.Enabled = bEnableEdit
            txtKeyStoreName.Enabled = bEnableEdit
            txtKeyStorePassword.Enabled = bEnableEdit
            txtRemotePrinter.Enabled = bEnableEdit
        Catch ex As Exception
            MsgBox("EnableEditGatewaySetting Error - " & ex.Message)
        End Try
    End Sub

    Private Sub btnSaveRestaurantInformation_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveRestaurantInformation.Click
        If MessageBox.Show("Are you sure upateing restaurant setting?", "Update Restaurant Setting Might affect Online Order", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then Exit Sub
        Update_RestaurantInformation()
    End Sub

    Private Sub btnClearRestaurantHour_Click(sender As System.Object, e As System.EventArgs) Handles btnClearRestaurantHour.Click
        If MyGrid_RestaurantHour IsNot Nothing Then
            If MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count > 0 Then
                MyGrid_RestaurantHour.AC_GridDataSet.Tables(MyGrid_RestaurantHour.AC_GridDataSet.Tables.Count - 1).Clear()
            End If
        End If
    End Sub

    Private Sub btnClearBusinessOperation_Click(sender As System.Object, e As System.EventArgs) Handles btnClearBusinessOperation.Click
        If MyGrid_BusinessOperation IsNot Nothing Then
            If MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count > 0 Then
                MyGrid_BusinessOperation.AC_GridDataSet.Tables(MyGrid_BusinessOperation.AC_GridDataSet.Tables.Count - 1).Clear()
            End If
        End If
    End Sub

    Private Sub ClearLunchSpecial_Click(sender As System.Object, e As System.EventArgs) Handles ClearLunchSpecial.Click
        If MyGrid_RestaurantHour IsNot Nothing Then
            If MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count > 0 Then
                MyGrid_LunchSpecial.AC_GridDataSet.Tables(MyGrid_LunchSpecial.AC_GridDataSet.Tables.Count - 1).Clear()
            End If
        End If
    End Sub

    Private Sub btnClearDinnerSpecial_Click(sender As System.Object, e As System.EventArgs) Handles btnClearDinnerSpecial.Click
        If MyGrid_DinnerSpecial IsNot Nothing Then
            If MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count > 0 Then
                MyGrid_DinnerSpecial.AC_GridDataSet.Tables(MyGrid_DinnerSpecial.AC_GridDataSet.Tables.Count - 1).Clear()
            End If
        End If
    End Sub
    Private Sub GetSetWebLogin(bGet As Boolean, iCompanyID As Integer)
        Try
            If bGet Then
                Dim MyDtable As DataTable = DB.MySQLQueryGetData("SELECT * FROM tbContactInfo WHERE CompanyID = " & iCompanyID)
                If MyDtable IsNot Nothing Then
                    If MyDtable.Rows.Count > 0 Then
                        txtWebLoginUserName.Text = MyDtable.Rows(0).Item("ContactEmail").ToString
                        txtWebLoginPassword.Text = MyDtable.Rows(0).Item("Password").ToString
                    End If
                End If
            Else

            End If
        Catch ex As Exception
            MsgBox("GetSetWebLogin Error - " & ex.Message)
        End Try
    End Sub

    Private Sub btnReloadOnlineMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnReloadOnlineMenu.Click
        Try
            If MessageBox.Show("Are you sure you want to reload online menu for this customer?", "Confirm Reload Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Process.Start("http://321ordernow.com/ordernow.do?actionType=updateSingleMenu&domainStr=" & txtDomainName.Text & "&password=123update")
        Catch ex As Exception
            MsgBox("btnReloadOnlineMenu_Click Error - " & ex.Message)
        End Try
    End Sub


    Private Sub txtCompanyWebRemarks_DoubleClick(sender As Object, e As System.EventArgs) Handles txtPlaceOrderAlertFromRestaurant.DoubleClick
        If MessageBox.Show("Do you want to clear web remarks?", "Confirm Clear Web Remarks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        txtPlaceOrderAlertFromRestaurant.Text = ""
    End Sub

    Private Sub btnUpdateAllRestaurantsHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAllRestaurantsHours.Click
        ' 
        Try
            If MessageBox.Show("Are you sure you want to update all restaurants hours?", "Confirm Update All Restaurants Hours", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Process.Start("http://321ordernow.com/ordernow.do?actionType=updateJSON&password=123update")
        Catch ex As Exception
            MsgBox("btnUpdateAllRestaurantsHours_Click Error - " & ex.Message)
        End Try
    End Sub

    Private Sub txtStateTaxRate_TextChanged(sender As Object, e As EventArgs) Handles txtStateTaxRate.TextChanged

    End Sub

    Private Sub chkEnable321ChargeRestaurant_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnable321ChargeRestaurant.CheckedChanged
        pa321ChargeRestaurantFee.Enabled = chkEnable321ChargeRestaurant.Checked
    End Sub

    Private Sub chkEnableFeeToChargeTheirCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableFeeToChargeTheirCustomer.CheckedChanged
        paRestaurantChargeTheirCustomerFee.Enabled = chkEnableFeeToChargeTheirCustomer.Checked
    End Sub

    Private Sub chkIsByPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsByPercentage.CheckedChanged
        txtOrderPrice.Enabled = Not chkIsByPercentage.Checked
        txtOrderPricePercentage.Enabled = chkIsByPercentage.Checked
    End Sub

    Private Sub chkEnablePickupFee_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnablePickupFee.CheckedChanged
        lblPickupFee.Visible = chkEnablePickupFee.Checked
        txtPickupFee.Visible = chkEnablePickupFee.Checked
    End Sub

    Private Sub chk321ChargeRestaurantChargeRestaurantByPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles chk321ChargeRestaurantChargeRestaurantByPercentage.CheckedChanged
        txt321ChargeRestaurantAmountChargePerOrder.Enabled = Not chk321ChargeRestaurantChargeRestaurantByPercentage.Checked
        txt321ChargeRestaurantPercentageChargePerOrder.Enabled = chk321ChargeRestaurantChargeRestaurantByPercentage.Checked
    End Sub

    Private Sub chkActiveRestaurant_CheckedChanged(sender As Object, e As EventArgs) Handles chkActiveRestaurant.CheckedChanged

        If chkActiveRestaurant.Checked Then
            gbRestaurantStatus.BackColor = strMyColor.cOkay
            btnActiveRestaurant.Text = "Disable Restaurant"
        Else
            gbRestaurantStatus.BackColor = strMyColor.cNo
            btnActiveRestaurant.Text = "Active Restaurant"
        End If
        lblRestaurantInactiveDate.Visible = Not chkActiveRestaurant.Checked
    End Sub

    Private Sub btnActiveRestaurant_Click(sender As Object, e As EventArgs) Handles btnActiveRestaurant.Click
        If chkActiveRestaurant.Checked Then
            If MessageBox.Show(Me, "Are you sure you want to Disable this restaurant?", "Confirm Disable Restaurant", vbYesNo, vbQuestion) = DialogResult.No Then Exit Sub
            ChangeReataurantStatus(txtDomainName.Text, 0)
        Else
            If MessageBox.Show(Me, "Are you sure you want to Re-Active this restaurant?", "Confirm Re-Acticw Restaurant", vbYesNo, vbQuestion) = DialogResult.No Then Exit Sub
            ChangeReataurantStatus(txtDomainName.Text, 1)
        End If
    End Sub
    Private Sub ChangeReataurantStatus(sRestaurantDomainName As String, bActive As Boolean)
        Try

            Using mysqlconn = New MySqlConnection(DB.GetCurrentConnectionString)
                Using cmd As New MySqlCommand($"UPDATE tbCompanyInfo  SET                    
                    isInActive = @isInActive,
                    InActiveTime = @InActiveTime                    
                    WHERE CompanyDomainName = @CompanyDomainName ",
                                              mysqlconn)
                    'cmd.Parameters.Add("CompanyID", MySqlDbType.String).Value =
                    cmd.Parameters.Add("isInActive", MySqlDbType.Bit).Value = IIf(bActive, 0, 1)
                    If chkActiveRestaurant.Checked Then
                        cmd.Parameters.Add("InActiveTime", MySqlDbType.DateTime).Value = Now
                    Else
                        cmd.Parameters.Add("InActiveTime", MySqlDbType.DateTime).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add("CompanyDomainName", MySqlDbType.String).Value = txtDomainName.Text

                    Try
                        mysqlconn.Open()
                        cmd.ExecuteNonQuery()
                        mysqlconn.Close()

                        chkActiveRestaurant.Checked = bActive
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)

                    End Try

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function ConvertXlxsToDataTable(sSheetName As String) As DataTable
        Dim sFilePath As String = ""
        Dim dt As DataTable = New DataTable()
        Try
            Using objFileDialog As OpenFileDialog = New OpenFileDialog
                objFileDialog.InitialDirectory = "c:\\"
                objFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                objFileDialog.FilterIndex = 2
                objFileDialog.RestoreDirectory = True
                If objFileDialog.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    sFilePath = objFileDialog.FileName

                    Using con As OleDb.OleDbConnection = New OleDb.OleDbConnection()
                        Try
                            'If System.IO.Path.GetExtension(path) = ".csv" Then
                            '    con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Text;HDR=YES;FMT=Delimited""", "Microsoft.Jet.OLEDB.4.0", IO.Path.GetDirectoryName(path))
                            'ElseIf System.IO.Path.GetExtension(path) = ".xlsx" Then
                            '    con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", IO.Path.GetDirectoryName(path))
                            'End If
                            If System.IO.Path.GetExtension(sFilePath) = ".xls" Then
                                con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.8.0", sFilePath)
                            ElseIf System.IO.Path.GetExtension(sFilePath) = ".xlsx" Then
                                con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", sFilePath)
                            End If
                            con.Open()

                            Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)

                            'Dim firstSheetname As String = "Restaurant Info"
                            'Dim firstSheetname As String = dbSchema.Rows(0)("Restaurant Info").ToString
                            Using cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM [" & sSheetName & "$]", con)
                                Using da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(cmd)
                                    If con.State <> ConnectionState.Open Then con.Open()
                                    da.Fill(dt)
                                    con.Close()
                                End Using
                            End Using
                        Catch ex As Exception
                            MessageBox.Show("Unable to process selected File:" & vbNewLine & vbNewLine &
                                             ex.Message, "Unable To Process Selected File!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            Throw ex
                        Finally
                            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                                con.Close()
                            End If
                        End Try
                    End Using
                End If

                Return dt
            End Using
        Catch ex As Exception
        Finally
            Cursor = Cursors.Default
        End Try


    End Function
    Private Function BuildConnectionString(ByVal m_strExcelPath As String) As String
        If m_strExcelPath.Substring(m_strExcelPath.LastIndexOf(".")).ToLower = ".xlsx" Then
            Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & m_strExcelPath & ";Excel 12.0;HDR=YES;IMEX=1"
        Else
            Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & m_strExcelPath & ";Excel 8.0;HDR=YES;IMEX=1"
        End If
    End Function
    Private Function TimeZoneMapping(sTimeZone As String, Optional isRevered As Boolean = False) As String
        Try
            If isRevered Then
                Select Case True
                    Case sTimeZone.Contains("New_York")
                        Return "Eastern Standard Time (EST)"
                    Case sTimeZone.Contains("Chicago")
                        Return "Central Standard Time (CST)"
                    Case sTimeZone.Contains("Denver")
                        Return "Mountain Standard Time (MST)"
                    Case sTimeZone.Contains("Los_Angeles")
                        Return "Pacific Standard Time (PST)"
                    Case sTimeZone.Contains("Anchorage")
                        Return "Alaska Standard Time (AST)"
                    Case sTimeZone.Contains("Adak")
                        Return "Hawaii-Aleutian Standard Time (HST)"
                    Case Else
                        Return ""
                End Select
            Else
                Select Case True
                    Case sTimeZone.Contains("(EST)")
                        Return "America/New_York"
                    Case sTimeZone.Contains("(CST)")
                        Return "America/Chicago"
                    Case sTimeZone.Contains("(MST)")
                        Return "America/Denver"
                    Case sTimeZone.Contains("(PST)")
                        Return "America/Los_Angeles"
                    Case sTimeZone.Contains("(AST)")
                        Return "America/Anchorage"
                    Case sTimeZone.Contains("(HST)")
                        Return "America/Adak"
                    Case Else
                        Return ""
                End Select
            End If

        Catch ex As Exception
            MessageBox.Show("TimeZoneMapping Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - TimeZoneMapping " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "TimeZoneMapping - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try

    End Function

    Private Sub chkChargeTheirCustomerByPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles chkChargeTheirCustomerByPercentage.CheckedChanged
        txtChargeTheirCustomerAmountChagePerOrder.Enabled = Not chkChargeTheirCustomerByPercentage.Checked
        txtChargeTheirCustomerPercentageChargePerOrder.Enabled = chkChargeTheirCustomerByPercentage.Checked
    End Sub

    Private Sub btnloadNewRestaurant_Click(sender As Object, e As EventArgs) Handles btnloadNewRestaurant.Click
        Try
            If MessageBox.Show(Me, "Import new restaurant?", "Confirm Import New Restaurant", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            If ImportRestaurant() Then
                'If ImportMenu() Then

                '    'If ImportSubMenu() Then
                '    '    MessageBox.Show(Me, "Successfully imported new restaurant with Menu and SubMenu", "Successfully Imported New Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    'Else
                '    '    MessageBox.Show(Me, "Please make sure Sub Menu for this restaurant!", "Sub Menu Not Found For Import", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    'End If
                'Else
                '    MessageBox.Show(Me, "New Restaruant created without Menu and SubMenu!", "New Restaurant Missing Menu and SubMenu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
                GetCompanies()
            Else
                MessageBox.Show(Me, "Unable to import new restaurant", "Unable To Import New Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("btnloadNewRestaurant_Click Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - btnloadNewRestaurant_Click " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnloadNewRestaurant_Click - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub

    Private Sub frmOnlineOrderMenu_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Try
            If DB IsNot Nothing Then
                DB = Nothing
            End If
            If data IsNot Nothing Then
                data.Dispose()
                data = Nothing
            End If
            If da IsNot Nothing Then
                da.Dispose()
                da = Nothing
            End If
            If cb IsNot Nothing Then
                cb.Dispose()
                cb = Nothing
            End If


            If MyGrid_FoodType IsNot Nothing Then
                MyGrid_FoodType.Dispose()
                MyGrid_FoodType = Nothing
            End If
            If MyGrid_FoodTypeMenuAddtional IsNot Nothing Then
                MyGrid_FoodTypeMenuAddtional.Dispose()
                MyGrid_FoodTypeMenuAddtional = Nothing
            End If
            If MyGrid_Menu IsNot Nothing Then
                MyGrid_Menu.Dispose()
                MyGrid_Menu = Nothing
            End If
            If MyGrid_MenuAddtional IsNot Nothing Then
                MyGrid_MenuAddtional.Dispose()
                MyGrid_MenuAddtional = Nothing
            End If
            If MyGrid_Promotion IsNot Nothing Then
                MyGrid_Promotion.Dispose()
                MyGrid_Promotion = Nothing
            End If



            If MyGrid_RestaurantHour IsNot Nothing Then
                MyGrid_RestaurantHour.Dispose()
                MyGrid_RestaurantHour = Nothing
            End If
            If MyGrid_BusinessOperation IsNot Nothing Then
                MyGrid_BusinessOperation.Dispose()
                MyGrid_BusinessOperation = Nothing
            End If
            If MyGrid_LunchSpecial IsNot Nothing Then
                MyGrid_LunchSpecial.Dispose()
                MyGrid_LunchSpecial = Nothing
            End If
            If MyGrid_DinnerSpecial IsNot Nothing Then
                MyGrid_DinnerSpecial.Dispose()
                MyGrid_DinnerSpecial = Nothing
            End If


            '$$$$$$$$ 6/12/2021, New restaurant menu
            If MyGrid_NewRestaurantMenu IsNot Nothing Then
                MyGrid_NewRestaurantMenu.Dispose()
                MyGrid_NewRestaurantMenu = Nothing
            End If
            If MyGrid_NewRestaurantMenuOption IsNot Nothing Then
                MyGrid_NewRestaurantMenuOption.Dispose()
                MyGrid_NewRestaurantMenuOption = Nothing
            End If


            If mdTable_RestaurantHour IsNot Nothing Then
                mdTable_RestaurantHour.Dispose()
                mdTable_RestaurantHour = Nothing
            End If
            If mdTable_BusinessOperation IsNot Nothing Then
                mdTable_BusinessOperation.Dispose()
                mdTable_BusinessOperation = Nothing
            End If
            If mdTable_LunchSpecial IsNot Nothing Then
                mdTable_LunchSpecial.Dispose()
                mdTable_LunchSpecial = Nothing
            End If
            If mdTable_DinnerSpecial IsNot Nothing Then
                mdTable_DinnerSpecial.Dispose()
                mdTable_DinnerSpecial = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("frmOnlineOrderMenu_Disposed Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - frmOnlineOrderMenu_Disposed " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frmOnlineOrderMenu_Disposed - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' New menu with JSON output
    ''' </summary>
    ''' <returns></returns>
    Private Function RemoveReataurantMenu() As Boolean
        Try
            If cboCompanyName.SelectedIndex < 0 Then Exit Function
            If MessageBox.Show("Are you sure you wants to remove menu from this restaurant?" & vbNewLine & vbNewLine & cboCompanyName.Text & "  < " & marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString & " >", "Confirm Remove Menu For Restaurant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.No Then
                Exit Function
            End If
            DB.CreateConnection(cboDatabase.Text)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "spRestaurant_RemoveMenu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            cmd.Parameters.AddWithValue("sCompanyDomainName", marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString)
            cmd.ExecuteNonQuery()
            ' marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString
            MessageBox.Show("Successfully removed menu", "Successfully removed menu", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    ''' <summary>
    ''' Remove old menu, menu before 6/2021
    ''' </summary>
    ''' <returns></returns>
    Private Function RemoveExistingMenuAndSubmenu() As Boolean
        Try
            If cboCompanyName.SelectedIndex < 0 Then Exit Function
            If MessageBox.Show("Are you sure you wants to remove menu from this restaurant?" & vbNewLine & vbNewLine & cboCompanyName.Text & "  < " & marrCompanyDomainName(cboCompanyName.SelectedIndex).ToString & " >", "Confirm Remove Menu For Restaurant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.No Then
                Exit Function
            End If
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
    End Function
    Private Function ImportRestaurant() As Boolean
        Dim bResult As Boolean = False
        Try
            Using dTable As DataTable = ConvertXlxsToDataTable("Restaurant Info")
                If dTable IsNot Nothing Then
                    If dTable.Rows.Count <= 0 Then
                        MessageBox.Show(Me, "There is no restaurant information from the file!!" & vbNewLine & vbNewLine &
                                         "Please make sure the file contains a tab named (Restaurant Info)", "Missing Restaurant Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        bResult = False
                        Exit Try
                    ElseIf dTable.Rows.Count > 1 Then
                        MessageBox.Show(Me, "There is more then one line of record in restaurant information from the file!!" & vbNewLine & vbNewLine &
                                         "Please make sure the file contains a tab named (Restaurant Info)", "Missing Restaurant Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    If dTable.Columns.Count <> 26 Then
                        MessageBox.Show("Miss match restaurant information file seleced!!" & vbNewLine & vbNewLine &
                                        "The file contain more or less columns it reqired!" & vbNewLine & vbNewLine &
                                        "Please make sure restaurant information after uploaded!", "Incorrect Restaurant Information File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    If dTable.Rows.Count > 0 Then
                        Using mysqlconn = New MySqlConnection(DB.GetCurrentConnectionString)
                            Using cmd As New MySqlCommand("spRestaurant_UpdateRestaurantInformation", mysqlconn)
                                'cmd.CommandText = "sp_UpdateRestaurant"
                                'cmd.Connection = mysqlconn
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("sCompanyName", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Name").ToString))
                                cmd.Parameters.AddWithValue("sCompanyAddress_1", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Address 1").ToString))
                                cmd.Parameters.AddWithValue("sCompanyAddress_2", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Address 2").ToString))
                                cmd.Parameters.AddWithValue("sCompanyAPT", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company APT").ToString))
                                cmd.Parameters.AddWithValue("sCompanyCity", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company City").ToString))

                                cmd.Parameters.AddWithValue("sCompanyState", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company State").ToString))
                                cmd.Parameters.AddWithValue("sCompanyZipCode", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company ZipCode").ToString))
                                cmd.Parameters.AddWithValue("sCompanyZipEx", ReplaceSpecialCharacters(dTable.Rows(0).Item("CompanyZipEx").ToString))
                                cmd.Parameters.AddWithValue("sAddressAdditionalInfo", ReplaceSpecialCharacters(dTable.Rows(0).Item("Address Additional Info").ToString))
                                cmd.Parameters.AddWithValue("sCompanyPhone_1", ReplaceSpecialCharacters(dTable.Rows(0).Item("sCompany Phone 1").ToString))

                                cmd.Parameters.AddWithValue("sCompanyPhone_2", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Phone 2").ToString))
                                cmd.Parameters.AddWithValue("sCompanyFax", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Fax").ToString))
                                cmd.Parameters.AddWithValue("sCompanyWebsite", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Website").ToString))
                                cmd.Parameters.AddWithValue("sCompanyEmail", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Email").ToString))
                                cmd.Parameters.AddWithValue("sCompanyDomainName", ReplaceSpecialCharacters(dTable.Rows(0).Item("Company Domain Name").ToString))

                                cmd.Parameters.AddWithValue("sReceiveOrderNumber", ReplaceSpecialCharacters(dTable.Rows(0).Item("Receive Order Number").ToString))
                                cmd.Parameters.AddWithValue("sCompanyTimeZone", ReplaceSpecialCharacters(IIf(dTable.Rows(0).Item("Company Time Zone").ToString.Contains("UTC"), "America/New_York", dTable.Rows(0).Item("Company Time Zone").ToString)))
                                cmd.Parameters.AddWithValue("jCompanyOperation", ReplaceSpecialCharacters("[{""jCompanyOperation"":""data1"",""Var2"":""data2"",""Var3"":""data3"",""Var4"":""data4""}]")) ' dTable.Rows(0).Item("Company Operation").ToString)
                                cmd.Parameters.AddWithValue("dCompanyDeliveryMin", Val(dTable.Rows(0).Item("Company Delivery Min").ToString))
                                cmd.Parameters.AddWithValue("dCompanyDeliveryCharge", Val(dTable.Rows(0).Item("Company Delivery Charge").ToString))

                                cmd.Parameters.AddWithValue("jLunchSpecialTime", ReplaceSpecialCharacters("[{""jLunchSpecialTime"":""data1"",""Var2"":""data2"",""Var3"":""data3"",""Var4"":""data4""}]")) ' dTable.Rows(0).Item("Lunch Special Time").ToString)
                                cmd.Parameters.AddWithValue("sLatitude", ReplaceSpecialCharacters(dTable.Rows(0).Item("Latitude").ToString))
                                cmd.Parameters.AddWithValue("sLongitude", ReplaceSpecialCharacters(dTable.Rows(0).Item("Longitude").ToString))
                                cmd.Parameters.AddWithValue("sReceiveOrderType", ReplaceSpecialCharacters(dTable.Rows(0).Item("Receive Order Type").ToString))
                                cmd.Parameters.AddWithValue("sStateTaxRate", Val(dTable.Rows(0).Item("State Tax Rate").ToString))

                                cmd.Parameters.AddWithValue("sIsDelivery", IIf(dTable.Rows(0).Item("Is Delivery").ToString.ToUpper = "Y" Or dTable.Rows(0).Item("Is Delivery").ToString = "1", "1", "0"))
                                cmd.Parameters.AddWithValue("sIsCreditCard", IIf(dTable.Rows(0).Item("Is CreditCard").ToString.ToUpper = "Y" Or dTable.Rows(0).Item("Is CreditCard").ToString = "1", "1", "0"))
                                cmd.Parameters.AddWithValue("sEstimateDeliveryTime", dTable.Rows(0).Item("EstimateDelivery Time").ToString)
                                cmd.Parameters.AddWithValue("jCompanyBusinessHour", ReplaceSpecialCharacters("[{""jCompanyBusinessHour"":""data1"",""Var2"":""data2"",""Var3"":""data3"",""Var4"":""data4""}]"))
                                cmd.Parameters.AddWithValue("jDinnerSpecialTime", ReplaceSpecialCharacters("[{""jDinnerSpecialTime"":""data1"",""Var2"":""data2"",""Var3"":""data3"",""Var4"":""data4""}]"))


                                Try
                                    mysqlconn.Open()
                                    If cmd.ExecuteNonQuery() = 1 Then
                                        bResult = True
                                        MessageBox.Show("Successfully added new restaurant", "Successfully Added New Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBox.Show("Failed add new restaurant" & vbNewLine & vbNewLine & "Restaurant might already exists in system!", "Failed Add New Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                    mysqlconn.Close()

                                Catch ex As Exception
                                    MessageBox.Show("ImportRestaurant Error" & vbNewLine & vbNewLine & ex.Message)
                                    ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportRestaurant " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                    LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportRestaurant - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                                    If mysqlconn.State <> ConnectionState.Closed Then mysqlconn.Close()
                                End Try

                            End Using
                        End Using
                    End If


                End If


            End Using
        Catch ex As Exception
            MessageBox.Show("ImportRestaurant Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportRestaurant " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportRestaurant - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
        Cursor = Cursors.Default
        Return bResult
    End Function



    Private Function ImportOptions() As Boolean
        Dim bResult As Boolean = True
        Dim iErrorCount As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            Using dTable As DataTable = ConvertXlxsToDataTable("Options")
                If dTable IsNot Nothing Then
                    If dTable.Rows.Count <= 0 Then
                        If MessageBox.Show(Me, "There is no options from the file!!" & vbNewLine & vbNewLine &
                                         "Do you want to continue process this menu with Options?", "Missing Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            bResult = False
                            Exit Try
                        End If
                    End If

                    If dTable.Columns.Count <> 9 Then
                        If MessageBox.Show("Miss match option column count!!" & vbNewLine & vbNewLine &
                                        "You may have an incorrect menu option template!!" & vbNewLine & vbNewLine &
                                        "Do you want to conintue the process", "Incorrect Menu Option In File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            bResult = False
                            Exit Try
                        End If
                    End If
                    If dTable.Rows.Count > 0 Then
                        Using mysqlconn = New MySqlConnection(DB.GetCurrentConnectionString)
                            Using cmd As New MySqlCommand("spMenu_UpdateOptions", mysqlconn)
                                'cmd.CommandText = "sp_UpdateRestaurant"
                                'cmd.Connection = mysqlconn

                                Try
                                    mysqlconn.Open()
                                    cmd.CommandType = CommandType.StoredProcedure
                                    For Each dRow_Options As DataRow In dTable.Rows
                                        If ReplaceSpecialCharacters(dRow_Options("DomainName").ToString).Length > 3 _
                                            And ReplaceSpecialCharacters(dRow_Options("Option Group").ToString).Length > 1 _
                                            And ReplaceSpecialCharacters(dRow_Options("Option Name").ToString).Length > 1 Then
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.AddWithValue("iOptionID", 0)
                                            cmd.Parameters.AddWithValue("sCompanyDomainName", ReplaceSpecialCharacters(dRow_Options("DomainName").ToString))
                                            cmd.Parameters.AddWithValue("sOptionGroup", ReplaceSpecialCharacters(dRow_Options("Option Group").ToString))
                                            cmd.Parameters.AddWithValue("sOptionName", ReplaceSpecialCharacters(dRow_Options("Option Name").ToString))
                                            cmd.Parameters.AddWithValue("sOptionName2", ReplaceSpecialCharacters(dRow_Options("Option Name2").ToString))

                                            cmd.Parameters.AddWithValue("sSectionGroup", IIf(Val(dRow_Options("Section Group").ToString) < 1, 1, Val(dRow_Options("Section Group").ToString)))
                                            cmd.Parameters.AddWithValue("dOptionPrice", Val(dRow_Options("Option Price").ToString))
                                            cmd.Parameters.AddWithValue("iisSpicy", IIf(dRow_Options("isSpicy").ToString = "N", 0, 1))
                                            cmd.Parameters.AddWithValue("sDisplaySequence", ReplaceSpecialCharacters(dRow_Options("Display Sequence").ToString))
                                            cmd.Parameters.AddWithValue("sRemarks", ReplaceSpecialCharacters(dRow_Options("Remarks").ToString))
                                            Try
                                                If cmd.ExecuteNonQuery() < 0 Then
                                                    If iErrorCount > 10 Then
                                                        MessageBox.Show("Options from file have too much issue" & vbNewLine & vbNewLine & "Please double check option file before reprocess!", "Option Import Abort Due To File Data Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                        Exit For
                                                    Else
                                                        iErrorCount = iErrorCount + 1
                                                    End If
                                                    bResult = False
                                                    MessageBox.Show("Failed add new restaurant" & vbNewLine & vbNewLine & "Restaurant might already exists in system!", "Failed Add New Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                End If
                                            Catch ex As MySqlException
                                                bResult = False
                                                MessageBox.Show("ImportOptions DB Save Error" & vbNewLine & vbNewLine & ex.Message)
                                                ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportOptions - DB Save" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                                LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportOptions - DB Save " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                                            End Try
                                        End If


                                    Next
                                    mysqlconn.Close()

                                Catch ex As Exception
                                    MessageBox.Show("ImportOptions Error" & vbNewLine & vbNewLine & ex.Message)
                                    ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportOptions " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                    LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportOptions - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                                    If mysqlconn.State <> ConnectionState.Closed Then mysqlconn.Close()
                                End Try
                            End Using
                        End Using
                    End If
                End If
            End Using
            Return bResult
        Catch ex As Exception
            MessageBox.Show("ImportOptions Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportOptions" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportOptions - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
        Cursor = Cursors.Default
        Return bResult
    End Function


    Private Function ImportDishes() As Boolean
        Dim bResult As Boolean = True
        Dim iErrorCount As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            Using dTable As DataTable = ConvertXlxsToDataTable("Dishes")
                If dTable IsNot Nothing Then
                    If dTable.Rows.Count <= 0 Then
                        If MessageBox.Show(Me, "There is no dish from the file!!", "Missing Dish", MessageBoxButtons.OK, MessageBoxIcon.Question) = DialogResult.No Then
                            bResult = False
                            Exit Try
                        End If
                    End If

                    If dTable.Columns.Count <> 23 Then
                        If MessageBox.Show("Miss match dish column count!!" & vbNewLine & vbNewLine &
                                        "You may have an incorrect menu dish template!!" & vbNewLine & vbNewLine &
                                        "Do you want to conintue the process?", "Incorrect Menu Dish In File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            bResult = False
                            Exit Try
                        End If
                    End If
                    If dTable.Rows.Count > 0 Then
                        Using mysqlconn = New MySqlConnection(DB.GetCurrentConnectionString)
                            Using cmd As New MySqlCommand("spMenu_UpdateMenu", mysqlconn)
                                'cmd.CommandText = "sp_UpdateRestaurant"
                                'cmd.Connection = mysqlconn

                                Try
                                    mysqlconn.Open()
                                    For Each dRow_Dishes As DataRow In dTable.Rows
                                        If dRow_Dishes("DomainName").ToString.Trim.Length <= 3 _
                                            Or dRow_Dishes("Category Name").ToString.Trim.Length <= 1 _
                                            Or dRow_Dishes("Dish Name").ToString.Trim.Length <= 1 Then
                                            ' Skip and pricess Next record
                                        Else
                                            cmd.Parameters.Clear()
                                            cmd.CommandType = CommandType.StoredProcedure
                                            cmd.Parameters.AddWithValue("sCompanyDomainName", ReplaceSpecialCharacters(dRow_Dishes("DomainName").ToString))
                                            cmd.Parameters.AddWithValue("sPrintGroup", ReplaceSpecialCharacters(dRow_Dishes("Print Group").ToString))
                                            cmd.Parameters.AddWithValue("iisLunchSpecial", IIf(dRow_Dishes("isLunchSpecial").ToString = "N", 0, 1))
                                            cmd.Parameters.AddWithValue("iisDinnerSpecial", IIf(dRow_Dishes("isDinnerSpecial").ToString = "N", 0, 1))
                                            cmd.Parameters.AddWithValue("sCategoryName", ReplaceSpecialCharacters(dRow_Dishes("Category Name").ToString))

                                            cmd.Parameters.AddWithValue("sCategoryName2", ReplaceSpecialCharacters(dRow_Dishes("Category Name2").ToString))
                                            cmd.Parameters.AddWithValue("sCategoryDescription", ReplaceSpecialCharacters(dRow_Dishes("Category Description").ToString))
                                            cmd.Parameters.AddWithValue("sCategoryDescription2", ReplaceSpecialCharacters(dRow_Dishes("Category Description2").ToString))
                                            cmd.Parameters.AddWithValue("sCategoryDisplaySequence", ReplaceSpecialCharacters(dRow_Dishes("Category  Display Sequence").ToString))
                                            cmd.Parameters.AddWithValue("sDishDisplaySequence", ReplaceSpecialCharacters(dRow_Dishes("Dish Display Sequence").ToString))

                                            cmd.Parameters.AddWithValue("sRestaurantMenuID", ReplaceSpecialCharacters(dRow_Dishes("MenuID").ToString))
                                            cmd.Parameters.AddWithValue("sDishName", ReplaceSpecialCharacters(dRow_Dishes("Dish Name").ToString))
                                            cmd.Parameters.AddWithValue("sDishName2", ReplaceSpecialCharacters(dRow_Dishes("Dish Name2").ToString))
                                            cmd.Parameters.AddWithValue("sDishDescription", ReplaceSpecialCharacters(dRow_Dishes("Dish Description").ToString))
                                            cmd.Parameters.AddWithValue("sDishDescription2", ReplaceSpecialCharacters(dRow_Dishes("Dish Description2").ToString))

                                            cmd.Parameters.AddWithValue("sSizeName", ReplaceSpecialCharacters(dRow_Dishes("Size Name").ToString))
                                            cmd.Parameters.AddWithValue("sSizeName2", ReplaceSpecialCharacters(dRow_Dishes("Size Name2").ToString))
                                            cmd.Parameters.AddWithValue("dSizePrice", ReplaceSpecialCharacters(dRow_Dishes("Size Price").ToString))
                                            cmd.Parameters.AddWithValue("iisRaw", IIf(dRow_Dishes("isRaw").ToString = "N", 0, 1))
                                            cmd.Parameters.AddWithValue("iisSpicy", IIf(dRow_Dishes("isSpicy").ToString = "N", 0, 1))

                                            cmd.Parameters.AddWithValue("sOptionGroup", ReplaceSpecialCharacters(dRow_Dishes("Option Group").ToString))
                                            cmd.Parameters.AddWithValue("sCategoryRemark", ReplaceSpecialCharacters(dRow_Dishes("Category Remarks").ToString))
                                            cmd.Parameters.AddWithValue("sDishRemark", ReplaceSpecialCharacters(dRow_Dishes("Dish Display Sequence").ToString))

                                            Try
                                                If cmd.ExecuteNonQuery() < 0 Then
                                                    If iErrorCount > 10 Then
                                                        MessageBox.Show("Options from file have too much issue" & vbNewLine & vbNewLine & "Please double check option file before reprocess!", "Option Import Abort Due To File Data Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                        Exit For
                                                    Else
                                                        iErrorCount = iErrorCount + 1
                                                    End If
                                                    bResult = False
                                                    MessageBox.Show("Failed add new restaurant" & vbNewLine & vbNewLine & "Restaurant might already exists in system!", "Failed Add New Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                End If
                                            Catch ex As MySqlException
                                                bResult = False
                                                MessageBox.Show("ImportDishes Error" & vbNewLine & vbNewLine & ex.Message)
                                                ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportDishes - Save Dishes" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                                LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportDishes - Save Dishes" & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                                            End Try
                                        End If


                                    Next
                                    mysqlconn.Close()

                                Catch ex As Exception
                                    MessageBox.Show("ImportDishes Error" & vbNewLine & vbNewLine & ex.Message)
                                    ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportDishes - Setup Conneciton" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
                                    LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportDishes - Setup Conneciton" & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
                                    If mysqlconn.State <> ConnectionState.Closed Then mysqlconn.Close()
                                End Try
                            End Using
                        End Using
                    End If
                End If
            End Using
            Return bResult
        Catch ex As Exception
            MessageBox.Show("ImportMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - ImportMenu" & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "ImportMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
        Cursor = Cursors.Default
        Return bResult
    End Function

    Private Sub btnImportOptions_Click(sender As Object, e As EventArgs) Handles btnImportOptions.Click

        Cursor = Cursors.WaitCursor
        If ImportOptions() Then
            GetNewRestaurantMenuOption(marrCompanyDomainName(cboCompanyName.SelectedIndex))
            MessageBox.Show(Me, "Successfully Imported Options")
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub btnImportMenu_Click(sender As Object, e As EventArgs) Handles btnImportMenu.Click
        Try
            If MessageBox.Show(Me, "Do you want to import/update menu for" & vbNewLine & vbNewLine & cboCompanyName.Text &
                               vbNewLine & vbNewLine & "Please make sure you import AddOn menu!!", "Confirm Import/Update Online Munu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                Cursor = Cursors.WaitCursor
                If ImportDishes() Then
                    GetNewRestaurantMenu(marrCompanyDomainName(cboCompanyName.SelectedIndex))
                    MessageBox.Show(Me, "Successfully Imported Dishes")
                End If
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show("btnImportMenu_Click Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - btnImportMenu_Click " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnImportMenu_Click - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        End Try
    End Sub

    Private Sub btnRemoveAllMenu_Click(sender As Object, e As EventArgs) Handles btnRemoveAllMenu.Click
        RemoveReataurantMenu()

        GetNewRestaurantMenu(marrCompanyDomainName(cboCompanyName.SelectedIndex))
        GetNewRestaurantMenuOption(marrCompanyDomainName(cboCompanyName.SelectedIndex))
    End Sub


    Private Sub GetNewRestaurantMenu(sCompanyDomainName As String)
        Try
            Cursor = Cursors.WaitCursor
            MyGrid_NewRestaurantMenu.FilterSaveGridFilters()
            MyGrid_NewRestaurantMenu.AC_GridDataSet = SQL_GetStandardGridDataSet(DB.MySQLQueryGetData(msSQL_GetNewRestaurantMenu.Replace("MyParameter_CompanyDomainName", sCompanyDomainName)))
            'If MyGrid_NewRestaurantMenu.AC_GridDataSet.Tables(MyGrid_NewRestaurantMenu.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_NewRestaurantMenu.AC_GridDataSet.Tables(MyGrid_NewRestaurantMenu.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_NewRestaurantMenu.AC_SortDirectionReset()
            MyGrid_NewRestaurantMenu.AC_ColumnWidthMultipler_Disable = True
            MyGrid_NewRestaurantMenu.AC_RefreshGrid()

            'MyGrid_NewRestaurantMenu.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_NewRestaurantMenu.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_NewRestaurantMenu.AlternatingRows = True
                'MyGrid_NewRestaurantMenu.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_NewRestaurantMenu.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_NewRestaurantMenu.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_NewRestaurantMenu.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_NewRestaurantMenu.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_NewRestaurantMenu.CaptionStyle.Font.Size * 0.8)
                MyGrid_NewRestaurantMenu.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_NewRestaurantMenu, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_NewRestaurantMenu, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)
            MyGrid_NewRestaurantMenu.FilterRestallFilters()
        Catch ex As Exception
            MessageBox.Show("GetNewRestaurantMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - GetNewRestaurantMenu " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetNewRestaurantMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GetNewRestaurantMenuOption(sCompanyDomainName As String)
        Try
            Cursor = Cursors.WaitCursor
            MyGrid_NewRestaurantMenuOption.FilterSaveGridFilters()
            MyGrid_NewRestaurantMenuOption.AC_GridDataSet = SQL_GetStandardGridDataSet(DB.MySQLQueryGetData(msStr_GetNewRestaurantMenuOption.Replace("MyParameter_CompanyDomainName", sCompanyDomainName)))
            'If MyGrid_NewRestaurantMenuOption.AC_GridDataSet.Tables(MyGrid_NewRestaurantMenuOption.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_NewRestaurantMenuOption.AC_GridDataSet.Tables(MyGrid_NewRestaurantMenuOption.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_NewRestaurantMenuOption.AC_SortDirectionReset()
            MyGrid_NewRestaurantMenuOption.AC_ColumnWidthMultipler_Disable = True
            MyGrid_NewRestaurantMenuOption.AC_RefreshGrid()

            'MyGrid_NewRestaurantMenuOption.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_NewRestaurantMenuOption.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_NewRestaurantMenuOption.AlternatingRows = True
                'MyGrid_NewRestaurantMenuOption.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_NewRestaurantMenuOption.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_NewRestaurantMenuOption.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_NewRestaurantMenuOption.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_NewRestaurantMenuOption.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_NewRestaurantMenuOption.CaptionStyle.Font.Size * 0.8)
                MyGrid_NewRestaurantMenuOption.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_NewRestaurantMenuOption, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_NewRestaurantMenuOption, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)
            MyGrid_NewRestaurantMenuOption.FilterRestallFilters()
        Catch ex As Exception
            MessageBox.Show("GetNewRestaurantMenu Error" & vbNewLine & vbNewLine & ex.Message)
            ActionLog(Me.Name, txtCompanyName.Text, Me.Name, "", "", "Error - GetNewRestaurantMenu " & vbNewLine & ex.Message, StrEmployeeInformation.Location, StrEmployeeInformation.EmployeeID, StrEmployeeInformation.ComputerName)
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetNewRestaurantMenu - " & Chr(13) & ex.Message & Chr(13) & Chr(13) & ex.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class