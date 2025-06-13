Imports System
Imports System.Net
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frm_OnlineOrderEditSubMenu
    Dim DB As New DBConnection_MySQL
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    WithEvents MyGrid_DishSubMenu As AviatCom_DefaultGrid = Nothing
    Private msConnectionString As String = ""
    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 10)
    Private mobjMyGridFooterFont As New Font("Arial", 10)
    Private miCompanyID As Integer = 0
    Private msFoodType As String = ""
    Private mbLoading As Boolean = True
    Private msConnectionStr As String = ""
    Private msSQLStr_FoodType As String = "SELECT  SpecialID,SOID,SODishName,SOPrice,OptionID FROM tbSpecial WHERE CompanyID = MyParameter_CompanyID AND FoodTypeID = 'MyParameter_FoodType';"
    Public WriteOnly Property SetCompanyID As Integer
        Set(value As Integer)
            miCompanyID = value
        End Set
    End Property
    Public WriteOnly Property SetFoodType As String
        Set(value As String)
            msFoodType = value
        End Set
    End Property
    Public WriteOnly Property SetConnectionStr As String
        Set(value As String)
            msConnectionStr = value
        End Set
    End Property
    Private Sub frm_OnlineOrderEditSubMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.AutoScaleMode = AutoScaleMode.Dpi
            MyGrid_DishSubMenu = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_DishSubMenu.FetchRowStyles = True
            MyGrid_DishSubMenu.AC_AllowFilter = True
            MyGrid_DishSubMenu.AllowFilter = True
            MyGrid_DishSubMenu.AllowDelete = True
            MyGrid_DishSubMenu.AllowAddNew = True
            MyGrid_DishSubMenu.AllowSort = True
            MyGrid_DishSubMenu.AllowColSelect = True
            MyGrid_DishSubMenu.BorderStyle = BorderStyle.Fixed3D
            MyGrid_DishSubMenu.ColumnFooters = False
            MyGrid_DishSubMenu.Anchor = C1TrueDBGrid1.Anchor
            C1TrueDBGrid1.Dispose()
            MyGrid_DishSubMenu.Show()
            mbLoading = False
            GetFoodType(miCompanyID, msFoodType)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GetFoodType(iCompanyID As Integer, sFoodType As String)
        Try
            Cursor = Cursors.WaitCursor
            DB.CreateConnection(msConnectionString)

            Dim MyDtable As DataTable = DB.MySQLQueryGetData(msSQLStr_FoodType.Replace("MyParameter_CompanyID", iCompanyID.ToString).Replace("MyParameter_FoodType", sFoodType.Replace("'", "''")))

            MyGrid_DishSubMenu.AC_GridDataSet = SQL_GetStandardGridDataSet(MyDtable, False, , GetParam("@", "", "", "", ""))
            'If MyGrid_DishSubMenu.AC_GridDataSet.Tables(MyGrid_DishSubMenu.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly Then MyGrid_DishSubMenu.AC_GridDataSet.Tables(MyGrid_DishSubMenu.AC_GridDataSet.Tables.Count - 1).Columns("isNotFromOrder").ReadOnly = False


            MyGrid_DishSubMenu.AC_SortDirectionReset()
            MyGrid_DishSubMenu.AC_ColumnWidthMultipler_Disable = True
            MyGrid_DishSubMenu.AC_RefreshGrid()





            'MyGrid_DishSubMenu.Splits(0).DisplayColumns("ItemNo").Frozen = True

            '$$$$$$$$$$ Set Standard Size
            If Not MyGrid_DishSubMenu.GetSetGridDisplayFormatLoad Then
                ''$$$$$$$$$$ Set Even row color
                'MyGrid_DishSubMenu.AlternatingRows = True
                'MyGrid_DishSubMenu.EvenRowStyle.BackColor = Color.LightCyan


                MyGrid_DishSubMenu.HighLightRowStyle.ForeColor = Color.Red

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                ''MyGrid.HighLightRowStyle.BackColor = Color.BlueViolet
                'MyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                'MyGrid.Columns("InvoiceAmt").NumberFormat = "Currency"


                MyGrid_DishSubMenu.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_DishSubMenu.Splits(0).ColumnCaptionHeight * 1.0
                mobjMyGridFont = New Font("Arial", MyGrid_DishSubMenu.CaptionStyle.Font.Size * 1.0)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_DishSubMenu.CaptionStyle.Font.Size * 0.8)
                MyGrid_DishSubMenu.GetSetGridDisplayFormatLoad = True
            End If
            FormatMyGridFont(MyGrid_DishSubMenu, mobjMyGridFont, mobjMyGridFont, , 22, mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_DishSubMenu, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click

    End Sub

    Private Sub Update_FoodType()
        Try
            Cursor = Cursors.WaitCursor
            Dim bUpdate As Boolean = False
            Dim bResult As Boolean = True
            Dim dTable = MyGrid_DishSubMenu.AC_GridDataSet.Tables(MyGrid_DishSubMenu.AC_GridDataSet.Tables.Count - 1).GetChanges
            If Not dTable Is Nothing Then
                If dTable.Rows.Count > 0 Then
                    DB.CreateConnection(msConnectionStr)
                    Dim cmd As New MySqlCommand 'Create command
                    cmd.Connection = DB.conn    'Inert connection string
                    cmd.CommandText = "spUpdate_OrderSubMenu"   'insert SP Name
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
                        ElseIf dRow.RowState = DataRowState.Deleted Then
                            bUpdate = True
                            cmd.Parameters.AddWithValue("sAction", "DELETE")
                        End If
                        If bUpdate = True Then
                            Try
                                cmd.Parameters.AddWithValue("iCompanyID", miCompanyID)
                                cmd.Parameters.AddWithValue("iFoodTypeID", dRow("FoodTypeID").ToString)
                                cmd.Parameters.AddWithValue("sFoodTypeDesc", dRow("Description").ToString)
                                cmd.Parameters.AddWithValue("sOldFoodType", dRow("FoodType", DataRowVersion.Original).ToString)
                                cmd.Parameters.AddWithValue("sNewFoodType", dRow("FoodType").ToString)
                                cmd.Parameters.AddWithValue("sDisplayOrder", dRow("DisplayOrder").ToString)
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        End If


                    Next
                    If Not bResult Then MessageBox.Show("Successfully updated FoodType", "Successfully updated FoodType", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            If Not bResult Then
                MessageBox.Show("Unable to add/update one or more item!!", "Add/Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            'DWL_Lib.DWL_Lib.LogToFile(Me.Name & ".log", "Update_SpecialPackingVolum Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
            'If gbDebug_PDA_MSG Then MessageBox.Show(ex.StackTrace & vbNewLine & ex.Message, "Update_SpecialPackingVolum Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ApplicationEventLog(gsApplicationType, "Error", Me.Name & " - Update_SpecialPackingVolum", ex.Message & ". " & vbNewLine & vbNewLine & ex.ToString, gStrEmployeeInformation.EmployeeID, gStrEmployeeInformation.ComputerName, gStrEmployeeInformation.WorkstationIPAddress.ToString, gStrEmployeeInformation.WHNo)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRefreshData_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshData.Click

    End Sub
End Class