Imports AviatCom_Lib.AviatCom_Lib
Imports MySql.Data.MySqlClient
Imports System.Data
Public Class frm_321_RestaurantInformation
    Dim mobjMySQLDBConnection As New cls_321DBConnection
    'Dim mobjMySQLDataAdapter As MySqlDataAdapter
    'Dim mbojMySQLCommandBuilder As MySqlCommandBuilder
    Dim mDTable As DataTable = Nothing
    WithEvents MyGrid_Restaurants As AviatCom_DefaultGrid = Nothing
    Private miMyGridCaptionHeight As Double = 0
    Private mobjMyGridFont As New Font("Arial", 13)
    Private mobjMyGridFooterFont As New Font("Arial", 13)


    Dim msMySQLStr As String = <GetAllRestaurants>SELECT
                                                    tbCompanyInfo.CompanyID AS 'ID',CompanyName,tbContactInfo.ContactEmail AS 'UserName', tbContactInfo.Password,ContactEmail,CompanyAddress_1,CompanyAddress_2,CompanyAPT,
                                                    CompanyCity,CompanyState,CompanyZipCode,CompanyZipEx,AddressAdditionalInfo,
                                                    CompanyPhone_1,CompanyPhone_2,CompanyFax,CompanyWebsite,CompanyEmail,
                                                    ReceiveOrderNumber,CompanyTimeZone,
                                                    CompanyDeliveryMin,CompanyDeliveryCharge,LunchSpecialTime,Latitude,
                                                    Longitude,ReceiveOrderType,HasLunchSpecial,MaxSpecialOption,StateTaxRate,
                                                    IsDelivery,IsCreditCard,EstimateDeliveryTime,
                                                    MonthlyMin,OrderPrice,OrderPricePercent,
                                                    IsByPercent,IsMinChargeCover,BasicCharge,LastSentEMailPomotion
                                                    FROM tbCompanyInfo INNER JOIN tbContactInfo ON tbCompanyInfo.CompanyID = tbContactInfo.CompanyID
                                                    WHERE IsDisplayToAll != 0
                                </GetAllRestaurants>

    Private Sub frm_321_RestaurantInformation_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Try
            If Not mobjMySQLDBConnection Is Nothing Then
                mobjMySQLDBConnection = Nothing
            End If
            If Not mDTable Is Nothing Then
                mDTable.Dispose()
                mDTable = Nothing
            End If
        Catch ex As Exception
            LogToFile(Me.Name & ".log", "frm_321_RestaurantInformation_Disposed Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub
    Private Sub frm_321_RestaurantInformation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            'If Not Add_NewAccessCode("NET:Policy:PolicyInformation", "Policy Information", "Policy Information") Then
            '    MessageBox.Show("Please assign role access for ( NET:Policy:PolicyInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            'End If
            'If Not CheckAccessRight("NET:Policy:PolicyInformation") Then
            '    Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            '    Exit Sub
            'End If

            'ClearField()

            Me.AutoScaleMode = AutoScaleMode.Dpi
            MyGrid_Restaurants = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid_Restaurants.FetchRowStyles = True
            MyGrid_Restaurants.AC_AllowFilter = True
            MyGrid_Restaurants.AllowDelete = False
            MyGrid_Restaurants.AllowAddNew = False
            MyGrid_Restaurants.AllowSort = True
            MyGrid_Restaurants.AllowColSelect = False
            MyGrid_Restaurants.BorderStyle = BorderStyle.Fixed3D
            MyGrid_Restaurants.ColumnFooters = False
            MyGrid_Restaurants.Anchor = C1TrueDBGrid1.Anchor ' AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom
            C1TrueDBGrid1.Dispose()
            MyGrid_Restaurants.Show()
            GetRestaurants()
        Catch ex As Exception
            LogToFile(Me.Name & ".log", "frm_321_RestaurantInformation_Load Processing : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString, Now)
        End Try
    End Sub
    Private Sub GetRestaurants()
        Try
            mobjMySQLDBConnection.MySQLCreateConnection("Production")
            If mDTable IsNot Nothing Then
                mDTable.Dispose()
                mDTable = Nothing
            End If
            mDTable = New DataTable
            mobjMySQLDBConnection.MySQLReturnDatatable(msMySQLStr, mDTable)
            MyGrid_Restaurants.AC_GridDataSet = SQL_GetStandardGridDataSet(mDTable)

            MyGrid_Restaurants.AC_SortDirectionReset()
            MyGrid_Restaurants.AC_ColumnWidthMultipler_Disable = True

            MyGrid_Restaurants.AC_RefreshGrid()
            If Not MyGrid_Restaurants.GetSetGridDisplayFormatLoad Then
                '$$$$$$$$$$ Set Even row color
                MyGrid_Restaurants.AlternatingRows = True
                MyGrid_Restaurants.EvenRowStyle.BackColor = Color.LightCyan

                '' $$$$$$$$$$$ Set Selected row back color
                'MyGrid_Restaurants.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
                'MyGrid_Restaurants.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedRowBorder
                ''$$$$$$$$$$$$$$$$$$$$$$$$$

                MyGrid_Restaurants.RowHeight = Me.Font.Size * 0.8
                miMyGridCaptionHeight = MyGrid_Restaurants.Splits(0).ColumnCaptionHeight * 0.8
                mobjMyGridFont = New Font("Arial", MyGrid_Restaurants.CaptionStyle.Font.Size * 1)
                mobjMyGridFooterFont = New Font("Arial", MyGrid_Restaurants.CaptionStyle.Font.Size * 1)
                MyGrid_Restaurants.GetSetGridDisplayFormatLoad = True
            End If

            FormatMyGridFont(MyGrid_Restaurants, mobjMyGridFont, mobjMyGridFont, , , mobjMyGridFooterFont)
            FormatMyGridCaption(MyGrid_Restaurants, mobjMyGridFont, Color.LightYellow, , miMyGridCaptionHeight, miMyGridCaptionHeight, False, True)

        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetRestaurants Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(Me.Name & ".log", "GetRestaurants Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub btnRefreshData_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshData.Click
        GetRestaurants()
    End Sub
End Class