Imports System
Imports System.Net
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frm_OnlineOrderEditMenu
    Dim DB As New DBConnection_MySQL
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder

    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 10)
    Private mobjMyGridFooterFont As New Font("Arial", 10)

    Private mbNewMenu As Boolean = False

    Private miCompanyID As Integer = 0
    Private msRestaurantMenuIndex As Integer = 0
    Private msConnectionString As String = ""
    Private msSQLStr_FoodType As String = "SELECT DISTINCT FoodTypeID,FoodType FROM tbFoodType WHERE CompanyID = MyParameter_CompanyID;"
    Private msSQLStr_RestaurantMenu As String = <RestaurantMenu>
        SELECT Foodtype,Des,DisplayOrder,DishName,DishDes,
        DishSize_1, DishPrice_1,DishSize_2, DishPrice_2,DishSize_3, DishPrice_3,DishSize_4, DishPrice_4,Spicy
        ,DishName_2
        ,tbRestaurantMenu.RestaurantMenuID,tbRestaurantMenu.CompanyID,tbRestaurantMenu.FoodTypeID,tbRestaurantMenu.DishesID,tbRestaurantMenu.MenuID
        ,tbFoodType.FoodTypeID 
        FROM tbRestaurantMenu
        INNER JOIN tbDishes
        ON tbRestaurantMenu.DishesID = tbDishes.DishesID
        INNER JOIN tbFoodType
        ON tbRestaurantMenu.FoodTypeID = tbFoodType.FoodTypeID 
        WHERE tbRestaurantMenu.CompanyID = MyParameter_OrderID AND tbRestaurantMenu.RestaurantMenuID = MyParameter_RestaurantMenuIndex
        ORDER BY Foodtype,DishName;

                                                </RestaurantMenu>
    WithEvents MyGrid_FoodType As AviatCom_DefaultGrid = Nothing

    Friend Property SetDatabaseConnection As String
        Get
            Return msConnectionString
        End Get
        Set(value As String)
            msConnectionString = value
        End Set
    End Property
    Friend WriteOnly Property SetCompanyID As Integer
        Set(value As Integer)
            miCompanyID = value
        End Set
    End Property
    Friend WriteOnly Property SetCompanyName As String
        Set(value As String)
            lblCompanyName.Text = value
        End Set
    End Property
    Friend WriteOnly Property SetRestaurantMenuIndex As Integer
        Set(value As Integer)
            msRestaurantMenuIndex = value
        End Set
    End Property
    Friend WriteOnly Property SetNewDish As Boolean
        Set(value As Boolean)
            mbNewMenu = value
        End Set
    End Property
    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        UpdateDishInformation()
    End Sub

    Private Sub btnRefreshData_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshData.Click
        GetFoodType(miCompanyID)
        GetDishInformation(miCompanyID, msRestaurantMenuIndex)
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frm_OnlineOrderEditMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.AutoScaleMode = AutoScaleMode.Dpi

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


            GetFoodType(miCompanyID)
            GetDishInformation(miCompanyID, msRestaurantMenuIndex)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetFoodType(iCompanyID As Integer)
        Try
            Cursor = Cursors.WaitCursor
            DB.CreateConnection(msConnectionString)

            Dim MyDtable As DataTable = DB.MySQLQueryGetData(msSQLStr_FoodType.Replace("MyParameter_CompanyID", iCompanyID.ToString))
            Dim NewCol As New DataColumn
            NewCol.ColumnName = "Sel"
            NewCol.DataType = Type.GetType("System.Boolean")
            NewCol.DefaultValue = False
            MyDtable.Columns.Add(NewCol)
            MyDtable.Columns("Sel").SetOrdinal(0)
            MyGrid_FoodType.AC_GridDataSet = SQL_GetStandardGridDataSet(MyDtable, False, , GetParam("", "@", "~"))
            'If MyGrid_FoodType.AC_GridDataSet.Tables(MyGrid_FoodType.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_FoodType.AC_GridDataSet.Tables(MyGrid_FoodType.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


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
            MessageBox.Show(ex.ToString)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GetDishInformation(iCompanyID As Integer, iMenuIndex As Integer)
        Try
            Using dTable As DataTable = DB.MySQLQueryGetData(msSQLStr_RestaurantMenu.Replace("MyParameter_OrderID", iCompanyID).Replace("MyParameter_RestaurantMenuIndex", iMenuIndex))
                If dTable Is Nothing Then
                    MessageBox.Show("Nothing return from database!!")
                    ClearFields()
                    Exit Sub
                End If
                If dTable.Rows.Count <= 0 Then
                    If Not mbNewMenu Then MessageBox.Show("No match found for menu index!!")
                    ClearFields()
                    Exit Sub
                End If
                txtMenuID.Text = dTable.Rows(0).Item("MenuID").ToString
                txtMenuID.Tag = dTable.Rows(0).Item("RestaurantMenuID").ToString
                txtDishName.Text = dTable.Rows(0).Item("DishName").ToString
                txtDishName_2.Text = dTable.Rows(0).Item("DishName_2").ToString
                txtDishDescription.Text = dTable.Rows(0).Item("DishDes").ToString
                txtDishSize_1.Text = dTable.Rows(0).Item("DishSize_1").ToString
                txtDishSize_2.Text = dTable.Rows(0).Item("DishSize_2").ToString
                txtDishSize_3.Text = dTable.Rows(0).Item("DishSize_3").ToString
                txtDishSize_4.Text = dTable.Rows(0).Item("DishSize_4").ToString
                txtDishPrice_1.Text = Val(dTable.Rows(0).Item("DishPrice_1").ToString)
                txtDishPrice_2.Text = Val(dTable.Rows(0).Item("DishPrice_2").ToString)
                txtDishPrice_3.Text = Val(dTable.Rows(0).Item("DishPrice_3").ToString)
                txtDishPrice_4.Text = Val(dTable.Rows(0).Item("DishPrice_4").ToString)
                chkSpicy.Checked = IIf(dTable.Rows(0).Item("Spicy").ToString.ToUpper = "Y", True, False)

                lblDishID.Text = "DishID: " & dTable.Rows(0).Item("DishesID").ToString
                lblDishID.Tag = dTable.Rows(0).Item("DishesID").ToString
                Dim dRow() As DataRow = MyGrid_FoodType.AC_GridDataSet.Tables(MyGrid_FoodType.AC_GridDataSet.Tables.Count - 1).Select(" FoodTypeID = " & Val(dTable.Rows(0).Item("FoodTypeID").ToString))
                If dRow Is Nothing Then
                    MessageBox.Show("Empty Food type return!!")
                    ClearFields()
                    Exit Sub
                End If
                If dRow.Length <= 0 Then
                    MessageBox.Show("Unable to find matched FoodType for this Dish!!")
                    Exit Sub
                End If
                dRow(0).Item("Sel") = True
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateDishInformation(Optional bDelete As Boolean = False)
        Try
            Dim dRow() As DataRow = MyGrid_FoodType.AC_GridDataSet.Tables(MyGrid_FoodType.AC_GridDataSet.Tables.Count - 1).Select(" Sel <> 0 ")
            If dRow Is Nothing Then
                MessageBox.Show("Empty Food type return!!")
                ClearFields()
                Exit Sub
            End If
            If dRow.Length <= 0 Then
                MessageBox.Show("Please check at less one FoodType for this Dish!!")
                Exit Sub
            End If
            If bDelete Then
                If Not ProcessUpdateRestaurantDishInformation("DELETE", miCompanyID, Val(dRow(0).Item("FoodTypeID").ToString), lblDishID.Tag, txtMenuID.Tag,
                                                                        txtDishName.Text,
                                                                      txtDishName_2.Text,
                                                                        txtDishDescription.Text,
                                                                       0,
                                                                        txtMenuID.Text,
                                                                        txtDishSize_1.Text,
                                                                        Val(txtDishPrice_1.Text),
                                                                        txtDishSize_2.Text,
                                                                        Val(txtDishPrice_2.Text),
                                                                       txtDishSize_3.Text,
                                                                        Val(txtDishPrice_3.Text),
                                                                        txtDishSize_4.Text,
                                                                        Val(txtDishPrice_4.Text),
                                                                        IIf(chkSpicy.Checked, "Y", "N")) Then
                    MessageBox.Show("Error update existing dish to restaurant!!")
                    Exit Sub
                Else
                    MessageBox.Show("Successfully Deleted dish", "Successfully Deleted Dish", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
               
            Else
                If mbNewMenu Then
                    For j As Integer = 0 To dRow.Length - 1
                        If Not ProcessUpdateRestaurantDishInformation("ADD", miCompanyID, Val(dRow(j).Item("FoodTypeID").ToString), 0, 0,
                                                                        txtDishName.Text,
                                                                        txtDishName_2.Text,
                                                                        txtDishDescription.Text,
                                                                       0,
                                                                         txtMenuID.Text,
                                                                         txtDishSize_1.Text,
                                                                        Val(txtDishPrice_1.Text),
                                                                         txtDishSize_2.Text,
                                                                        Val(txtDishPrice_2.Text),
                                                                         txtDishSize_3.Text,
                                                                        Val(txtDishPrice_3.Text),
                                                                         txtDishSize_4.Text,
                                                                        Val(txtDishPrice_4.Text),
                                                                        IIf(chkSpicy.Checked, 1, 0)) Then
                            MessageBox.Show("Error update new dish to restaurant!!")
                        End If
                    Next
                Else
                    If dRow.Length > 1 Then
                        MessageBox.Show("Please check at less one FoodType for this Dish!!")
                        Exit Sub
                    End If
                    If Not ProcessUpdateRestaurantDishInformation("UPDATE", miCompanyID, Val(dRow(0).Item("FoodTypeID").ToString), lblDishID.Tag, txtMenuID.Tag,
                                                                        txtDishName.Text,
                                                                      txtDishName_2.Text,
                                                                        txtDishDescription.Text,
                                                                       0,
                                                                        txtMenuID.Text,
                                                                        txtDishSize_1.Text,
                                                                        Val(txtDishPrice_1.Text),
                                                                        txtDishSize_2.Text,
                                                                        Val(txtDishPrice_2.Text),
                                                                       txtDishSize_3.Text,
                                                                        Val(txtDishPrice_3.Text),
                                                                        txtDishSize_4.Text,
                                                                        Val(txtDishPrice_4.Text),
                                                                        IIf(chkSpicy.Checked, "Y", "N")) Then
                        MessageBox.Show("Error update existing dish to restaurant!!")
                        Exit Sub
                    End If
                    'If Not ProcessUpdateRestaurantDishInformation("UPDATE", miCompanyID, Val(dRow(0).Item("FoodTypeID").ToString), lblDishID.Tag, txtMenuID.Tag,
                    '                                                   "'" & txtDishName.Text & "'",
                    '                                                   "'" & txtDishName_2.Text & "'",
                    '                                                   "'" & txtDishDescription.Text & "'",
                    '                                                   0,
                    '                                                    "'" & txtMenuID.Text & "'",
                    '                                                    "'" & txtDishSize_1.Text & "'",
                    '                                                    Val(txtDishPrice_1.Text),
                    '                                                    "'" & txtDishSize_2.Text & "'",
                    '                                                    Val(txtDishPrice_2.Text),
                    '                                                    "'" & txtDishSize_3.Text & "'",
                    '                                                    Val(txtDishPrice_3.Text),
                    '                                                    "'" & txtDishSize_4.Text & "'",
                    '                                                    Val(txtDishPrice_4.Text),
                    '                                                    IIf(chkSpicy.Checked, "Y", "N")) Then
                    '    MessageBox.Show("Error update existing dish to restaurant!!")
                    'End If
                End If
                If mbNewMenu Then
                    MessageBox.Show("Successfully Addeded new dish")
                Else
                    MessageBox.Show("Successfully updated dish")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Function ProcessUpdateRestaurantDishInformation(sAction As String, iCompanyID As Integer, iFoodTypeID As Integer, iDishesID As Integer, iRestaurantMenuID As Integer _
        , sDishName As String, sDishName_2 As String, sDishDes As String, iDishCalorie As Integer, sMenuID As String, sDishSize_1 As String _
        , iDishPrice_1 As Decimal, sDishSize_2 As String, iDishPrice_2 As Decimal, sDishSize_3 As String, iDishPrice_3 As Decimal _
        , sDishSize_4 As String, iDishPrice_4 As Decimal, sSpicy As String) As Boolean
        Dim bResult As Boolean = True
        Try
            DB.CreateConnection(msConnectionString)
            Dim cmd As New MySqlCommand 'Create command
            cmd.Connection = DB.conn    'Inert connection string
            cmd.CommandText = "spUpdate_Menu"   'insert SP Name
            cmd.CommandType = CommandType.StoredProcedure   'select try as sp
            cmd.Parameters.AddWithValue("sAction", sAction)
            cmd.Parameters.AddWithValue("iCompanyID", iCompanyID)
            cmd.Parameters.AddWithValue("iFoodTypeID", iFoodTypeID)
            cmd.Parameters.AddWithValue("iDishesID", iDishesID)
            cmd.Parameters.AddWithValue("iRestaurantMenuID", iRestaurantMenuID)
            cmd.Parameters.AddWithValue("sDishName", sDishName)
            cmd.Parameters.AddWithValue("sDishName_2", sDishName_2)
            cmd.Parameters.AddWithValue("sDishDes", sDishDes)
            cmd.Parameters.AddWithValue("iDishCalorie", iDishCalorie)
            cmd.Parameters.AddWithValue("sMenuID", sMenuID)
            cmd.Parameters.AddWithValue("sDishSize_1", sDishSize_1)
            cmd.Parameters.AddWithValue("iDishPrice_1", iDishPrice_1)
            cmd.Parameters.AddWithValue("sDishSize_2", sDishSize_2)
            cmd.Parameters.AddWithValue("iDishPrice_2", iDishPrice_2)
            cmd.Parameters.AddWithValue("sDishSize_3", sDishSize_3)
            cmd.Parameters.AddWithValue("iDishPrice_3", iDishPrice_3)
            cmd.Parameters.AddWithValue("sDishSize_4", sDishSize_4)
            cmd.Parameters.AddWithValue("iDishPrice_4", iDishPrice_4)
            cmd.Parameters.AddWithValue("sSpicy", sSpicy)
            cmd.ExecuteNonQuery()
            Return bResult
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function
    Private Sub ClearFields()
        Try
            txtMenuID.Text = ""
            txtDishName.Text = ""
            txtDishName_2.Text = ""
            txtDishDescription.Text = ""
            txtDishSize_1.Text = ""
            txtDishSize_2.Text = ""
            txtDishSize_3.Text = ""
            txtDishSize_4.Text = ""
            txtDishPrice_1.Text = ""
            txtDishPrice_2.Text = ""
            txtDishPrice_3.Text = ""
            txtDishPrice_4.Text = ""
            lblDishID.Text = "DishID: "
            chkSpicy.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnDeleteDish_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteDish.Click
        If MessageBox.Show("Are you sure you wants to delete this dish?", "Confirm Delete Dish", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        UpdateDishInformation(True)
    End Sub
End Class