Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Public Class frmOrderInput
    Private mCmd_GetProductName As SqlCommand = Nothing
    Private mCmd_GetProductInformation As SqlCommand = Nothing
    Private mCmd_GetExtraService As SqlCommand = Nothing
    Private mCmd_GetOrderNumber As SqlCommand = Nothing
    Private mCmd_GetOrderDetail As SqlCommand = Nothing
    Private mCmd_GetCustomerInformation As SqlCommand = Nothing
    Private mCmd_AddProduct As SqlCommand = Nothing
    Private mCmd_DepositDiscount As SqlCommand = Nothing
    Private mCmd_GetTotalPrice As SqlCommand = Nothing
    Private mCmd_RemoveProduct As SqlCommand = Nothing
    Private mCmd_UpdateOrderNumber As SqlCommand = Nothing
    Private mCmd_UpdateRefundItem As SqlCommand = Nothing
    Private mCmd_UpdateCustomerBalance As SqlCommand = Nothing
    WithEvents MyGrid As AviatCom_DefaultGrid
    'Private mdTable As New DataTable
    Private arrRB() As RBButton
    Private mrbThiness As New RBButton
    Private mbIsLoading As Boolean = True
    Private mbDirty As Boolean = False
    Private mbThinknessSelected = False
    Private mbThinknessPricePreInch As Double = 0.0
    Private msCustomerID As String = ""
    Private msThickness As String = ""
    Private miID As Integer = 0
    Private msItemNumber As String = ""
    Private mdSQ_FT As Double = 0.0
    Private msTempOrderNumber As String = "" '= GetNewReceiptNumber() 'GetNewReceiptNumber("A")  '"Temp" & Format(Now(), "yyyyMMddhhmmss") & Now.Millisecond.ToString

    Private mbPopScreen As Boolean = False
    Private msPopOrderNumber As String = ""
    Private msPopCustomerID As String = ""
    Private msOrderStatus As String = "NEW"
    Private mbLockUpdate As Boolean = False
    Private mbGettingData As Boolean = False

    Private msOwnerCompanyName As String = ""
    Private msOrderDate As String = ""
    Private miCustomerLevel As Integer = 1

    Private dt_ItemPrice As New DataTable
    Private dt_ItemPrice_2 As New DataTable

    Friend WriteOnly Property SetPopScreen As Boolean
        Set(ByVal value As Boolean)
            mbPopScreen = value
        End Set
    End Property
    Friend WriteOnly Property SetOrderNumber As String
        Set(ByVal value As String)
            msPopOrderNumber = value
        End Set
    End Property
    Friend WriteOnly Property SetCustomerID As String
        Set(ByVal value As String)
            msPopCustomerID = value
        End Set
    End Property
    Friend WriteOnly Property SetOrderStatus As String
        Set(ByVal value As String)
            msOrderStatus = value
            If value.ToUpper = "CLOSED" Then mbLockUpdate = True
        End Set
    End Property
    Private Sub btnAddOnService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            CloseAllMDIChildForms(gGlobalForm)
            'LogToSystemEvent(gsApplicationClientID, Me.Name, "btnSupplier_Click - " & Chr(13) & "TEST".ToString & Chr(13) & Chr(13) & "TEST".ToString, "Error")
            frmAddOnServices.MdiParent = gGlobalForm
            frmAddOnServices.Show()

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnAddOnService_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnAddOnService_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Try
            If mbPopScreen Then
                Me.Close()
            Else
                If txtOrderNumber.Text.Trim = "" And MyGrid.RowCount > 0 Then
                    If MessageBox.Show("Do you want to save your current order?", "Save order", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                        '8/30/2014, get text from cbo
                        'gobjADO.ExecuteSP(GetParam("ADD", txtOrderNumber.Text, msTempOrderNumber, dtDelieveryDate.Value, IIf(rbDelivery.Checked, rbDelivery.Text, rbPickup.Text), IIf(chkTaxExemption.Checked, "Y", "N"), txtOrderComment.Text, txtCustomerPONumber.Text, Val(txtDeliveryCharge.Text)), mCmd_UpdateOrderNumber)
                        gobjADO.ExecuteSP(GetParam("ADD", txtOrderNumber.Text, msTempOrderNumber, dtDelieveryDate.Value, cboDeliveryMethod.Text, IIf(chkTaxExemption.Checked, "Y", "N"), txtOrderComment.Text, txtCustomerPONumber.Text, Val(txtDeliveryCharge.Text), txtJobSite.Text.Trim), mCmd_UpdateOrderNumber)
                    End If
                End If

                CloseAllMDIChildForms(gGlobalForm)
                frmGeneral.MdiParent = gGlobalForm
                frmGeneral.Show()
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnQuit_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnQuit_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            mbLockUpdate = True
            gobjADO.ExecuteSP(GetParam(txtOrderNumber.Text), mCmd_UpdateCustomerBalance)
        End Try


    End Sub

    Private Sub frmPurchase_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            'gobjADO.ExecuteSP(GetParam("DELETE", "", msTempOrderNumber, dtDelieveryDate.Value, IIf(rbDelivery.Checked, rbDelivery.Text, rbPickup.Text), IIf(chkTaxExemption.Checked, "Y", "N"), txtOrderComment.Text), mCmd_UpdateOrderNumber)
            'If Not mdTable Is Nothing Then mdTable.Dispose()

            If Not MyGrid Is Nothing Then MyGrid.Dispose()
            If Not mCmd_GetProductInformation Is Nothing Then mCmd_GetProductInformation.Dispose()
            If Not mCmd_GetProductName Is Nothing Then mCmd_GetProductName.Dispose()
            If Not mCmd_GetExtraService Is Nothing Then mCmd_GetExtraService.Dispose()
            If Not mCmd_GetOrderNumber Is Nothing Then mCmd_GetOrderNumber.Dispose()
            If Not mCmd_GetOrderDetail Is Nothing Then mCmd_GetOrderDetail.Dispose()
            If Not mCmd_GetCustomerInformation Is Nothing Then mCmd_GetCustomerInformation.Dispose()
            If Not mCmd_AddProduct Is Nothing Then mCmd_AddProduct.Dispose()
            If Not mCmd_DepositDiscount Is Nothing Then mCmd_DepositDiscount.Dispose()
            If Not mCmd_GetTotalPrice Is Nothing Then mCmd_GetTotalPrice.Dispose()
            If Not mCmd_RemoveProduct Is Nothing Then mCmd_RemoveProduct.Dispose()
            If Not mCmd_UpdateOrderNumber Is Nothing Then mCmd_UpdateOrderNumber.Dispose()
            If Not mCmd_UpdateRefundItem Is Nothing Then mCmd_UpdateRefundItem.Dispose()
            If Not mCmd_UpdateCustomerBalance Is Nothing Then mCmd_UpdateCustomerBalance.Dispose()
            If Not dt_ItemPrice Is Nothing Then
                dt_ItemPrice.Dispose()
                dt_ItemPrice = Nothing
            End If
            If Not dt_ItemPrice_2 Is Nothing Then
                dt_ItemPrice_2.Dispose()
                dt_ItemPrice_2 = Nothing
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error frmPurchase_Disposed")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frmPurchase_Disposed - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

        End Try
    End Sub

    Private Sub frmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetupThickness()

            cboDeliveryMethod.Items.Clear()
            cboDeliveryMethod.Items.Add("Self Pickup")
            cboDeliveryMethod.Items.Add("Rush Pickup")
            cboDeliveryMethod.Items.Add("Delivery")
            cboDeliveryMethod.Items.Add("Rush Delivery")
            cboDeliveryMethod.SelectedIndex = 0

            btnSetShippingAddress.BackColor = gObjMyColors.cNeedAction
            dtDelieveryDate.Value = dtDelieveryDate.Value.AddDays(5)
            Me.Text = Me.Text & "          Current Date   < " & Today & " >"
            mCmd_GetProductName = gobjADO.GetADOCommand("sp_frmPurchase_GetProductName")
            mCmd_GetProductInformation = gobjADO.GetADOCommand("sp_frmPurchase_GetProductInformation")
            mCmd_GetExtraService = gobjADO.GetADOCommand("sp_frmPurchase_GetExtraServices")
            mCmd_GetOrderDetail = gobjADO.GetADOCommand("sp_frmPurchase_GetOrderDetail")
            mCmd_GetCustomerInformation = gobjADO.GetADOCommand("sp_GetCustomerInformation")
            mCmd_AddProduct = gobjADO.GetADOCommand("sp_frmPurchase_AddOrder")
            mCmd_DepositDiscount = gobjADO.GetADOCommand("sp_frmPurchase_DepositDiscount")
            mCmd_GetTotalPrice = gobjADO.GetADOCommand("sp_frmPurchase_GetTotalPrice")
            mCmd_RemoveProduct = gobjADO.GetADOCommand("sp_frmPurchase_RemoveProduct")
            mCmd_UpdateOrderNumber = gobjADO.GetADOCommand("sp_frmPurchase_UpdateOrderNumber")
            mCmd_UpdateRefundItem = gobjADO.GetADOCommand("sp_frmPurchase_UpdateRefundItem")
            mCmd_UpdateCustomerBalance = gobjADO.GetADOCommand("sp_UpdateOrderTotalAmount")
            MyGrid = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid.FetchRowStyles = True
            MyGrid.AC_AllowFilter = False
            MyGrid.AllowDelete = False
            MyGrid.AllowAddNew = False
            MyGrid.AllowSort = False
            MyGrid.BorderStyle = BorderStyle.Fixed3D
            'MyGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
            'txtOrderNumber.Text = msTempOrderNumber
            C1TrueDBGrid1.Dispose()
            MyGrid.Show()

            GetProductNames()
            FillExtraService()
            GetAdditionalAddOn()
            GetOrderDetail("")
            MyGrid.Splits(0).DisplayColumns("Name").Frozen = True

            dt_ItemPrice.Columns.Add("ProductName", Type.GetType("System.String"))
            dt_ItemPrice.Columns.Add("Thickness", Type.GetType("System.String"))
            dt_ItemPrice.Columns.Add("More_1", Type.GetType("System.Int32"))
            dt_ItemPrice.Columns.Add("LessOrEqual_1", Type.GetType("System.Int32"))
            dt_ItemPrice.Columns.Add("Price_1", Type.GetType("System.Decimal"))
            dt_ItemPrice.Columns.Add("More_2", Type.GetType("System.Int32"))
            dt_ItemPrice.Columns.Add("LessOrEqual_2", Type.GetType("System.Int32"))
            dt_ItemPrice.Columns.Add("Price_2", Type.GetType("System.Decimal"))
            dt_ItemPrice.Columns.Add("More_3", Type.GetType("System.Int32"))
            dt_ItemPrice.Columns.Add("LessOrEqual_3", Type.GetType("System.Int32"))
            dt_ItemPrice.Columns.Add("Price_3", Type.GetType("System.Decimal"))
            dt_ItemPrice.Columns.Add("GlassPrice", Type.GetType("System.Decimal"))

            dt_ItemPrice_2.Columns.Add("ProductName", Type.GetType("System.String"))
            dt_ItemPrice_2.Columns.Add("Thickness", Type.GetType("System.String"))
            dt_ItemPrice_2.Columns.Add("More_1", Type.GetType("System.Int32"))
            dt_ItemPrice_2.Columns.Add("LessOrEqual_1", Type.GetType("System.Int32"))
            dt_ItemPrice_2.Columns.Add("Price_1", Type.GetType("System.Decimal"))
            dt_ItemPrice_2.Columns.Add("More_2", Type.GetType("System.Int32"))
            dt_ItemPrice_2.Columns.Add("LessOrEqual_2", Type.GetType("System.Int32"))
            dt_ItemPrice_2.Columns.Add("Price_2", Type.GetType("System.Decimal"))
            dt_ItemPrice_2.Columns.Add("More_3", Type.GetType("System.Int32"))
            dt_ItemPrice_2.Columns.Add("LessOrEqual_3", Type.GetType("System.Int32"))
            dt_ItemPrice_2.Columns.Add("Price_3", Type.GetType("System.Decimal"))
            dt_ItemPrice_2.Columns.Add("GlassPrice", Type.GetType("System.Decimal"))

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error frmPurchase_Load")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "frmPurchase_Load - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            'txtOrderNumber.Text = GetNewReceiptNumber()
            If mbPopScreen Then
                If msPopCustomerID = "" Or msPopOrderNumber = "" Then
                    MessageBox.Show("Missing Ether Customer ID or Order Number." & Chr(13) & "Contact your software vendor for more information", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
                btnFindCustomer.Enabled = False
                btnDeleteWholeOrder.Enabled = False
                msCustomerID = msPopCustomerID
                'If msPopOrderNumber.ToUpper.Contains("A") Then
                '    msTempOrderNumber = msPopOrderNumber
                'Else
                txtOrderNumber.Text = msPopOrderNumber
                If IsQuote(txtOrderNumber.Text) Then
                    ' btnComfirmOrder.Enabled = True
                    btnComfirmOrder.Visible = True
                Else
                    ' btnComfirmOrder.Enabled = False
                    btnComfirmOrder.Visible = False
                End If

                'End If

                GetCustomerInformation(msCustomerID)
                GetOrderDetail(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
                gbSetShipAddress.Enabled = True
                GetShippingAddress()
            End If
            mbIsLoading = False
            mbDirty = False
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GetProductNames()
        Try
            Using dTable As DataTable = gobjADO.GetTable(mCmd_GetProductName, Nothing)
                FillComboBox(cboProduct_2, dTable, " ")
                FillComboBox(cboProduct, dTable, " ")

            End Using

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetProductNames")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetProductNames - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub GetAdditionalAddOn()
        Try
            cboAdditionalAddon.Items.Clear()
            cboAdditionalAddon.Items.Add("")
            Using dTable As DataTable = SQL_GetAllTableData("tb_AdditionalAddOn", " ORDER BY ID DESC")
                For j As Integer = 0 To dTable.Rows.Count - 1
                    cboAdditionalAddon.Items.Add(dTable.Rows(j).Item("AdditionalAddOnName").ToString & " @ $" & dTable.Rows(j).Item("AdditionalAddOnPrice").ToString)
                Next
            End Using

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetProductNames")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetProductNames - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub SetupProduct(ByVal sProduct As String, Optional bSecoundProduct As Boolean = False)
        Dim iPrice As Double = 0
        Try
            If Not gProductDetailTable Is Nothing Then gProductDetailTable = Nothing
            'For Each MyControl As RBButton In gbThickness.Controls.OfType(Of RBButton)()
            '    MyControl.Visible = False
            'Next
            'For Each MyControl As TXTbox In gbThickness.Controls.OfType(Of TXTbox)()
            '    MyControl.Visible = False
            'Next

            If sProduct.Trim = "" Then Exit Sub
            gProductDetailTable = gobjADO.GetTable(mCmd_GetProductInformation, GetParam(sProduct))
            If Not bSecoundProduct Then
                'If Not arrRB Is Nothing Then
                '    For j As Integer = 0 To arrRB.Length - 1
                '        arrRB(j).Visible = False
                '    Next
                'End If
                'ReDim arrRB(gProductDetailTable.Rows.Count - 1)
                dt_ItemPrice.Clear()



                For j As Integer = 0 To gProductDetailTable.Rows.Count - 1
                    ''If Val(gProductDetailTable.Rows(j).Item("PricePreSQ").ToString) > 0 Then Me.rbRegularGlass.Visible = True
                    ''If Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP").ToString) > 0 Then Me.rbTemperGlass.Visible = True
                    'arrRB(j) = New RBButton
                    'arrRB(j).Parent = rbTemp.Parent
                    'arrRB(j).Size = rbTemp.Size
                    'arrRB(j).BackColor = rbTemp.BackColor
                    'arrRB(j).Visible = True
                    'arrRB(j).Enabled = True
                    'arrRB(j).BringToFront()
                    'AddHandler arrRB(j).Click, AddressOf ThinknessRadioSelect
                    'If j = 0 Then
                    '    arrRB(j).Top = rbTemp.Top
                    '    arrRB(j).Left = rbTemp.Left
                    'Else
                    '    arrRB(j).Top = arrRB(j - 1).Top + arrRB(j - 1).Height + 15
                    '    arrRB(j).Left = arrRB(j - 1).Left
                    'End If
                    'arrRB(j).Text = gProductDetailTable.Rows(j).Item("Thickness").ToString

                    Select Case miCustomerLevel
                        Case 2
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP2").ToString)
                        Case 3
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP3").ToString)
                        Case 4
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP4").ToString)
                        Case 5
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP5").ToString)
                        Case 6
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP6").ToString)
                        Case 7
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP7").ToString)
                        Case 8
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP8").ToString)
                        Case 9
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP9").ToString)
                        Case 10
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP10").ToString)
                        Case Else
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP").ToString)

                    End Select

                    dt_ItemPrice.Rows.Add(gProductDetailTable.Rows(j).Item("ProductName").ToString _
                                          , gProductDetailTable.Rows(j).Item("Thickness").ToString _
                                          , gProductDetailTable.Rows(j).Item("More_1") _
                                          , gProductDetailTable.Rows(j).Item("LessOrEqual_1") _
                                          , gProductDetailTable.Rows(j).Item("Price_1") _
                                          , gProductDetailTable.Rows(j).Item("More_2") _
                                          , gProductDetailTable.Rows(j).Item("LessOrEqual_2") _
                                          , gProductDetailTable.Rows(j).Item("Price_2") _
                                          , gProductDetailTable.Rows(j).Item("More_3") _
                                          , gProductDetailTable.Rows(j).Item("LessOrEqual_3") _
                                          , gProductDetailTable.Rows(j).Item("Price_3") _
                                          , Math.Round(iPrice, 2))
                    mbThinknessSelected = False
                Next
            Else
                dt_ItemPrice_2.Clear()
                Dim sMSGDisplay As String = ""

                For j As Integer = 0 To gProductDetailTable.Rows.Count - 1
                    Select Case miCustomerLevel
                        Case 2
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP2").ToString)
                        Case 3
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP3").ToString)
                        Case 4
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP4").ToString)
                        Case 5
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP5").ToString)
                        Case 6
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP6").ToString)
                        Case 7
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP7").ToString)
                        Case 8
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP8").ToString)
                        Case 9
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP9").ToString)
                        Case 10
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP10").ToString)
                        Case Else
                            iPrice = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP").ToString)
                    End Select

                    dt_ItemPrice_2.Rows.Add(gProductDetailTable.Rows(j).Item("ProductName").ToString _
                                          , gProductDetailTable.Rows(j).Item("Thickness").ToString _
                                          , gProductDetailTable.Rows(j).Item("More_1") _
                                          , gProductDetailTable.Rows(j).Item("LessOrEqual_1") _
                                          , gProductDetailTable.Rows(j).Item("Price_1") _
                                          , gProductDetailTable.Rows(j).Item("More_2") _
                                          , gProductDetailTable.Rows(j).Item("LessOrEqual_2") _
                                          , gProductDetailTable.Rows(j).Item("Price_2") _
                                          , gProductDetailTable.Rows(j).Item("More_3") _
                                          , gProductDetailTable.Rows(j).Item("LessOrEqual_3") _
                                          , gProductDetailTable.Rows(j).Item("Price_3") _
                                          , Math.Round(iPrice, 2))
                Next
                Dim bExists As Boolean = False
                Dim bMissMatch As Boolean = False
                If arrRB Is Nothing Then
                    gbThickness.Enabled = False
                    Exit Sub
                Else
                    gbThickness.Enabled = True
                End If
                For j As Integer = 0 To arrRB.Length - 1
                    arrRB(j).Checked = False
                    'bExists = False
                    'For Each dRow As DataRow In dt_ItemPrice_2.Rows
                    '    If dRow.Item("Thickness").ToString = arrRB(j).Text Then
                    '        bExists = True
                    '        Exit For
                    '    End If
                    'Next
                    'If Not bExists Then
                    '    arrRB(j).Enabled = False
                    '    sMSGDisplay = sMSGDisplay & vbNewLine & arrRB(j).Text
                    '    If Not bMissMatch Then bMissMatch = True
                    'Else
                    '    arrRB(j).Enabled = True
                    'End If
                Next
                'If bMissMatch Then
                '    MessageBox.Show("One or more Glass Thickness Mis-Match." & vbNewLine & vbNewLine & cboProduct.Text & " - " & cboProduct_2.Text & vbNewLine & sMSGDisplay, "Some Glass Thickness Mis-Match", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

            End If


        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error SetupProduct")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "SetupProduct - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub ThinknessRadioSelect(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As New RBButton
        btn = CType(sender, RBButton)
        'frmPurchase.mbThinknessPricePreInch = Val(btn.Tag)
        msThickness = btn.Text
        FillProductDetail(btn.Text)

    End Sub
    Private Sub FillProductDetail(ByVal sThickness As String)
        Try
            If gProductDetailTable Is Nothing Then Exit Sub

            If gProductDetailTable.Rows.Count = 0 Then
                gobjADO.GetTable(mCmd_GetProductInformation, GetParam(cboProduct.Text))
            End If
            For j As Integer = 0 To gProductDetailTable.Rows.Count - 1

                'If gProductDetailTable.Rows(j).Item("Thickness").ToString = sThickness Then
                If gProductDetailTable.Rows(j).Item("ProductName").ToString = cboProduct.Text Then
                    If miCustomerLevel = 2 Then
                        'rbRegularGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQ2").ToString)
                        'rbTemperGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP2").ToString)
                        mbThinknessPricePreInch = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP2").ToString)
                    ElseIf miCustomerLevel = 3 Then
                        'rbRegularGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQ3").ToString)
                        'rbTemperGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP3").ToString)
                        mbThinknessPricePreInch = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP3").ToString)
                    ElseIf miCustomerLevel = 4 Then
                        'rbRegularGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQ4").ToString)
                        'rbTemperGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP4").ToString)
                        mbThinknessPricePreInch = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP4").ToString)
                    ElseIf miCustomerLevel = 5 Then
                        'rbRegularGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQ5").ToString)
                        'rbTemperGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP5").ToString)
                        mbThinknessPricePreInch = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP5").ToString)
                    Else
                        'rbRegularGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQ").ToString)
                        'rbTemperGlass.Tag = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP").ToString)
                        mbThinknessPricePreInch = Val(gProductDetailTable.Rows(j).Item("PricePreSQwTMP").ToString)
                    End If

                    msThickness = sThickness


                    If Val(gProductDetailTable.Rows(j).Item("PolishRegular").ToString) = 0 Then
                        chkRegularPolish.Visible = False
                        txtRegularPolish.Visible = False
                        lblRegularPolishInch.Visible = False
                    Else
                        chkRegularPolish.Visible = True
                        txtRegularPolish.Visible = True
                        lblRegularPolishInch.Visible = True
                        If miCustomerLevel = 2 Then
                            chkRegularPolish.Text = "Regular Polish ( $" & gProductDetailTable.Rows(j).Item("PolishRegular2").ToString & " )"
                            chkRegularPolish.Tag = gProductDetailTable.Rows(j).Item("PolishRegular2").ToString
                        ElseIf miCustomerLevel = 3 Then
                            chkRegularPolish.Text = "Regular Polish ( $" & gProductDetailTable.Rows(j).Item("PolishRegular3").ToString & " )"
                            chkRegularPolish.Tag = gProductDetailTable.Rows(j).Item("PolishRegular3").ToString
                        ElseIf miCustomerLevel = 4 Then
                            chkRegularPolish.Text = "Regular Polish ( $" & gProductDetailTable.Rows(j).Item("PolishRegular4").ToString & " )"
                            chkRegularPolish.Tag = gProductDetailTable.Rows(j).Item("PolishRegular4").ToString
                        ElseIf miCustomerLevel = 5 Then
                            chkRegularPolish.Text = "Regular Polish ( $" & gProductDetailTable.Rows(j).Item("PolishRegular5").ToString & " )"
                            chkRegularPolish.Tag = gProductDetailTable.Rows(j).Item("PolishRegular5").ToString
                        Else
                            chkRegularPolish.Text = "Regular Polish ( $" & gProductDetailTable.Rows(j).Item("PolishRegular").ToString & " )"
                            chkRegularPolish.Tag = gProductDetailTable.Rows(j).Item("PolishRegular").ToString
                        End If

                        'txtRegularPolish.Text = ""
                    End If

                    If Val(gProductDetailTable.Rows(j).Item("PolishShape").ToString) = 0 Then
                        chkShapePolish.Visible = False
                        txtShapePolish.Visible = False
                        lblShapePolishInch.Visible = False
                    Else
                        chkShapePolish.Visible = True
                        txtShapePolish.Visible = True
                        lblShapePolishInch.Visible = True
                        If miCustomerLevel = 2 Then
                            chkShapePolish.Text = "Shape Polish ( $" & gProductDetailTable.Rows(j).Item("PolishShape2").ToString & " )"
                            chkShapePolish.Tag = gProductDetailTable.Rows(j).Item("PolishShape2").ToString
                        ElseIf miCustomerLevel = 3 Then
                            chkShapePolish.Text = "Shape Polish ( $" & gProductDetailTable.Rows(j).Item("PolishShape3").ToString & " )"
                            chkShapePolish.Tag = gProductDetailTable.Rows(j).Item("PolishShape3").ToString
                        ElseIf miCustomerLevel = 4 Then
                            chkShapePolish.Text = "Shape Polish ( $" & gProductDetailTable.Rows(j).Item("PolishShape4").ToString & " )"
                            chkShapePolish.Tag = gProductDetailTable.Rows(j).Item("PolishShape4").ToString
                        ElseIf miCustomerLevel = 5 Then
                            chkShapePolish.Text = "Shape Polish ( $" & gProductDetailTable.Rows(j).Item("PolishShape5").ToString & " )"
                            chkShapePolish.Tag = gProductDetailTable.Rows(j).Item("PolishShape5").ToString
                        Else
                            chkShapePolish.Text = "Shape Polish ( $" & gProductDetailTable.Rows(j).Item("PolishShape").ToString & " )"
                            chkShapePolish.Tag = gProductDetailTable.Rows(j).Item("PolishShape").ToString
                        End If

                        'txtShapePolish.Text = ""
                    End If

                    If Val(gProductDetailTable.Rows(j).Item("Miter_1_Inch").ToString) = 0 Then
                        chkMiter.Visible = False
                        txtMiter.Visible = False
                        lblMiterInch.Visible = False
                    Else
                        chkMiter.Visible = True
                        txtMiter.Visible = True
                        lblMiterInch.Visible = True
                        chkMiter.Text = "MITER 1" & Chr(34) & " ( $" & gProductDetailTable.Rows(j).Item("Miter_1_Inch").ToString & " )"
                        chkMiter.Tag = gProductDetailTable.Rows(j).Item("Miter_1_Inch").ToString
                        'txtMiter.Text = ""
                    End If


                    If Val(gProductDetailTable.Rows(j).Item("HoleLargerThanInch").ToString) = 0 Then
                        chkHoleLargerThan1Inch.Visible = False
                        txtHoleLargerThan1Inch.Visible = False
                    Else
                        chkHoleLargerThan1Inch.Visible = True
                        txtHoleLargerThan1Inch.Visible = True
                        chkHoleLargerThan1Inch.Text = "Hole > 1" & Chr(34) & " ( $" & gProductDetailTable.Rows(j).Item("HoleLargerThanInch").ToString & " )"
                        chkHoleLargerThan1Inch.Tag = gProductDetailTable.Rows(j).Item("HoleLargerThanInch").ToString
                        'txtHoleLargerThan1Inch.Text = ""
                    End If


                    If Val(gProductDetailTable.Rows(j).Item("HoleSmallerThanInch").ToString) = 0 Then
                        chkHoleSmallerThan1Inch.Visible = False
                        txtHoleSmallerThan1Inch.Visible = False
                    Else
                        chkHoleSmallerThan1Inch.Visible = True
                        txtHoleSmallerThan1Inch.Visible = True
                        chkHoleSmallerThan1Inch.Text = "Hole <= 1" & Chr(34) & " ( $" & gProductDetailTable.Rows(j).Item("HoleSmallerThanInch").ToString & " )"
                        chkHoleSmallerThan1Inch.Tag = gProductDetailTable.Rows(j).Item("HoleSmallerThanInch").ToString
                        ' txtHoleSmallerThan1Inch.Text = ""
                    End If
                End If
                mbThinknessSelected = True
            Next
            'msThickness = sThickness
            'mbThinknessSelected = True
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error FillProductDetail")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "FillProductDetail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub FillExtraService()
        Try
            Dim dt As DataTable = gobjADO.GetTable(mCmd_GetExtraService, Nothing)

            If dt Is Nothing Then
                Exit Sub
            End If
            If dt.Rows.Count = 3 Then
                chkNOTCH.Text = "NOTCH ( $" & dt.Rows(0).Item(1).ToString & " ) Each"
                chkNOTCH.Tag = dt.Rows(0).Item(1).ToString
                txtNOTCH.Text = ""
                chkHINGE.Text = "HINGE ( $" & dt.Rows(1).Item(1).ToString & " ) Each"
                chkHINGE.Tag = dt.Rows(1).Item(1).ToString
                txtHINGE.Text = ""
                chkPATCH.Text = "PATCH ( $" & dt.Rows(2).Item(1).ToString & " ) Each"
                chkPATCH.Tag = dt.Rows(2).Item(1).ToString
                txtPATCH.Text = ""
            End If

            If Not dt Is Nothing Then dt.Dispose()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error FillExtraService")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "FillExtraService - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub cboProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.SelectedIndexChanged

        ClearForm(, "KEEP")
        SetupProduct(cboProduct.Text)
        cboProduct_2.SelectedIndex = cboProduct.SelectedIndex

    End Sub

    Private Class CHKbox
        Inherits Windows.Forms.CheckBox

        Private Sub CHKbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

        End Sub
    End Class

    Private Class TXTbox
        Inherits Windows.Forms.TextBox
    End Class
    Private Class RBButton
        Inherits Windows.Forms.RadioButton

        Private Sub RBButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
            'Dim btn As New RBButton
            'btn = CType(sender, RBButton)
            ''frmPurchase.mbThinknessPricePreInch = Val(btn.Tag)
            'frmPurchase.FillProductDetail(btn.Text)
        End Sub
    End Class

    Private Sub GetCustomerInformation(ByVal sCustomerID As String)
        Try
            Dim dt As New DataTable
            dt = gobjADO.GetTable(mCmd_GetCustomerInformation, GetParam(sCustomerID))
            If dt.Rows.Count > 0 Then
                txtCustomerName.Text = dt.Rows(0).Item("CustomerName").ToString()
                txtCustomerCompanyName.Text = dt.Rows(0).Item("CompanyNameEng").ToString()
                txtCustomerAddress.Text = dt.Rows(0).Item("Address").ToString()
                txtCustomerCity.Text = dt.Rows(0).Item("City").ToString()
                txtCustomerState.Text = dt.Rows(0).Item("State").ToString()
                txtCustomerZip.Text = dt.Rows(0).Item("zip").ToString()
                txtPhoneNumber.Text = dt.Rows(0).Item("ContactPhone_1").ToString()
                msCustomerID = dt.Rows(0).Item("CustomerID").ToString()
                chkTaxExemption.Checked = IIf(dt.Rows(0).Item("IsTaxExemption").ToString.ToUpper = "Y", True, False)
                miCustomerLevel = Val(dt.Rows(0).Item("CustomerLevel").ToString())

            Else
                LogToSystemEvent(gsApplicationClientID, Me.Name, "GetCustomerInformation - Multi Customers received from database", "Warning")
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetCustomerInformation")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetCustomerInformation - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Try
            Dim frm As New frmCustomerInfomation
            gsCustomerID = ""
            frm.SetPopSelect = True
            frm.ShowDialog()
            msCustomerID = gsCustomerID
            If Not frm Is Nothing Then frm.Dispose()
            GetCustomerInformation(msCustomerID)
            gbSetShipAddress.Enabled = True
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnFindCustomer_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnFindCustomer_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            If txtOrderNumber.Text.Trim = "" Then
                msTempOrderNumber = GetNewReceiptNumber()
                txtOrderNumber.Text = msTempOrderNumber
            End If
            ClearForm()
        End Try

    End Sub
    Private Sub GetOrderDetail(ByVal sOrderNumber As String)
        Try
            Cursor = Cursors.WaitCursor
            MyGrid.AC_GridDataSet = gobjADO.GetResults(GetParam(sOrderNumber), mCmd_GetOrderDetail)
            If MyGrid.AC_GridDataSet Is Nothing Then
                MessageBox.Show("找不到資料", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            MyGrid.AC_SortDirectionReset()
            MyGrid.AC_ColumnWidthMultipler_Disable = True
            MyGrid.AC_RefreshGrid()
            MyGrid = FormatMyGridFont(MyGrid, New Font("Arial", 10, FontStyle.Bold), New Font("Arial", 12, FontStyle.Regular), 30, 20, New Font("Arial", 15, FontStyle.Regular), 25)

            GetTotalPriceDisplay(sOrderNumber)
            'Dim dt As New DataTable
            'dt = MyGrid.AC_GridDataSet.Tables(0)

            'If MyGrid.AC_GridDataSet.Tables(0).Rows.Count > 0 Then
            '    txtSubtotal.Text = dt.Rows(0).Item(0) ' FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Subtotal").ToString)
            '    txtTax.Text = FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Tax").ToString)
            '    txtDiscount.Text = MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Discount").ToString & " %"
            '    txtTotalPrice.Text = FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Total").ToString)
            '    txtDeposit.Text = FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Deposit").ToString)
            '    txtRemaining.Text = FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Remaining").ToString)
            'End If

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetOrderDetail")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetOrderDetail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GetTotalPriceDisplay(ByVal sOrderNumber As String)
        Try
            Dim dt As New DataTable
            dt = gobjADO.GetTable(mCmd_GetTotalPrice, GetParam(sOrderNumber))
            If dt Is Nothing Then Exit Sub
            If dt.Rows.Count > 0 Then
                txtSubtotal.Text = FormatCurrency(dt.Rows(0).Item("Subtotal").ToString)  ' FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Subtotal").ToString)
                txtTax.Text = FormatCurrency(dt.Rows(0).Item("Tax").ToString)  ' FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Tax").ToString)
                txtDiscount.Text = dt.Rows(0).Item("Discount").ToString + " %" 'MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Discount").ToString & " %"
                txtTotalPrice.Text = FormatCurrency(dt.Rows(0).Item("Total").ToString)  ' FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Total").ToString)
                txtDeposit.Text = FormatCurrency(dt.Rows(0).Item("Deposit").ToString)  ' FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Deposit").ToString)
                txtRemaining.Text = FormatCurrency(dt.Rows(0).Item("Remaining").ToString)  'FormatCurrency(MyGrid.AC_GridDataSet.Tables(0).Rows(0).Item("Remaining").ToString)
                dtDelieveryDate.Value = dt.Rows(0).Item("DueDate").ToString
                chkTaxExemption.Checked = IIf(dt.Rows(0).Item("TaxExemption").ToString.ToUpper = "Y", True, False)
                txtOrderComment.Text = dt.Rows(0).Item("OrderComment").ToString
                txtCustomerPONumber.Text = dt.Rows(0).Item("PONumber").ToString
                msOrderDate = dt.Rows(0).Item("OrderDate").ToString
                cboDeliveryMethod.Text = dt.Rows(0).Item("DeliveryType").ToString
                txtDeliveryCharge.Text = dt.Rows(0).Item("DeliveryCharge").ToString
                txtJobSite.Text = dt.Rows(0).Item("JobName").ToString
                '8/30/2014,New update using cbo
                'If dt.Rows(0).Item("DeliveryType").ToString.ToUpper = "DELIVERY" Then
                '    rbPickup.Checked = False
                '    rbDelivery.Checked = True
                'Else
                '    rbDelivery.Checked = False
                '    rbPickup.Checked = True
                'End If
                cboDeliveryMethod.Text = dt.Rows(0).Item("DeliveryType").ToString

                txtDeliveryCharge.Text = IIf(Val(dt.Rows(0).Item("DeliveryCharge").ToString) <= 0, "", Math.Round(Val(dt.Rows(0).Item("DeliveryCharge").ToString), 2))
                If Val(dt.Rows(0).Item("TotalPayment").ToString) > 0 Then
                    btnDiscount.Enabled = False
                    btnDeposit.Enabled = False
                End If
                If dt.Rows(0).Item("OrderStatus").ToString.ToUpper = "DELETED" Then
                    Panel3.Enabled = False
                    Panel2.Enabled = False
                    MyGrid.Enabled = False
                    btnRemoveItems.Enabled = False
                    btnRefund.Enabled = False
                    btnDiscount.Enabled = False
                    btnDeposit.Enabled = False
                    btnDeleteWholeOrder.Enabled = False
                    chkTaxExemption.Enabled = False
                    btnUpdate.Enabled = False
                End If
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetOrderDetail")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetOrderDetail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        Try
            If txtCustomerName.Text.Trim = "" Then
                MessageBox.Show("Please select customer for this order!", "Please select customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then
                    Dim frm As New frmLogin
                    frm.ShowDialog()
                    If Not frm Is Nothing Then frm.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If
            If ValidInput() Then

                txtProductPrice.Text = FormatCurrency(GetProductTotalWithOptions())
                gobjADO.ExecuteSP(GetParam(btnAddProduct.Text,
                                           miID,
                                           IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text),
                                          msCustomerID,
                                          txtCustomerName.Text,
                                          cboProduct.Text,
                                           "Temper",
                                            msThickness,
                                            Val(txtWidth_1.Text),
                                            Val(txtWidth_2.Text),
                                            Val(txtWidth_3.Text),
                                            Val(txtHeight_1.Text),
                                           Val(txtHeight_2.Text),
                                            Val(txtHeight_3.Text),
                                           Val(txtQTY.Text),
                                           IIf(chk1L.Checked, chk1L.Text, IIf(chk2L.Checked, chk2L.Text, "")),
                                           IIf(chk1S.Checked, chk1S.Text, IIf(chk2S.Checked, chk2S.Text, "")),
                                           IIf(chkRegularPolish.Checked, Val(txtRegularPolish.Text), 0),
                                           IIf(chkShapePolish.Checked, Val(txtShapePolish.Text), 0),
                                           IIf(chkMiter.Checked, Val(txtMiter.Text), 0),
                                           IIf(chkHoleLargerThan1Inch.Checked, Val(txtHoleLargerThan1Inch.Text), 0),
                                           IIf(chkHoleSmallerThan1Inch.Checked, Val(txtHoleSmallerThan1Inch.Text), 0),
                                           IIf(chkNOTCH.Checked, Val(txtNOTCH.Text), 0),
                                           IIf(chkHINGE.Checked, Val(txtHINGE.Text), 0),
                                            IIf(chkPATCH.Checked, Val(txtPATCH.Text), 0),
                                            txtComments.Text.Trim,
                                            dtDelieveryDate.Value,
                                            cboDeliveryMethod.Text,
                                           miID,
                                          msItemNumber,
                                         Val(Replace(Replace(txtProductPrice.Text, "$", ""), ",", "")),
                                         Val(Replace(Replace(txtDeposit.Text, "$", ""), ",", "")),
                                         Val(Replace(txtDiscount.Text, "%", "")),
                                         Val(mdSQ_FT),
                                         IIf(chkTaxExemption.Checked, "Y", "N"),
                                          If(chkCustomizeService.Checked, Val(txtCustomizeService.Text), 0.0),
                                          txtCustomerPONumber.Text,
                                          Val(txtDeliveryCharge.Text),
                                          cboProduct.Text,
                                          cboProduct_2.Text,
                                          chkUseOption1.Checked,
                                          chkUseOption2.Checked,
                                          txtJobSite.Text.Trim,
                                          txtAdditionalAddonPrice.Tag,
                                          Val(txtAdditionalAddonPrice.Text)), mCmd_AddProduct)
                'Val(Replace(txtProductPrice.Text, "$", ""))), mCmd_AddProduct)
                GetOrderDetail(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
                GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
                miID = 0
                If btnAddProduct.Text = "Update" Then
                    btnAddProduct.Text = "Add"
                End If
                ClearForm(, , True)
            End If

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnAddProduct_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnAddProduct_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            Me.btnFindCustomer.Enabled = False
        End Try
    End Sub
    Private Sub ClearForm(Optional ByVal bClear As Boolean = True, Optional ByVal sAction As String = "", Optional bAddNewItem As Boolean = False)
        Try
          
            If Not bAddNewItem Then

                mbDirty = False
                mbThinknessSelected = False
                mbThinknessPricePreInch = 0.0
                'msCustomerID = ""

                miID = 0

                txtProductPrice.Text = ""

                msThickness = ""

                mbThinknessSelected = False

                If Not sAction.ToUpper = "KEEP" Then
                    cboProduct.Text = ""
                    cboProduct_2.Text = ""
                    ClearThickness()
                End If


                'If Not arrRB Is Nothing Then
                '    For j As Integer = 0 To arrRB.Length - 1
                '        arrRB(j).Visible = False
                '    Next
                '    arrRB = Nothing
                'End If

            End If

            msItemNumber = ""


            txtWidth_1.Text = ""
            txtWidth_2.Text = ""
            txtWidth_3.Text = ""
            txtHeight_1.Text = ""
            txtHeight_2.Text = ""
            txtHeight_3.Text = ""
            chk1L.Checked = False
            chk2L.Checked = False
            chk1S.Checked = False
            chk2S.Checked = False
            chkRegularPolish.Checked = False
            txtRegularPolish.Text = ""
            chkShapePolish.Checked = False
            txtShapePolish.Text = ""
            chkMiter.Checked = False
            txtMiter.Text = ""
            chkHoleLargerThan1Inch.Checked = False
            txtHoleLargerThan1Inch.Text = ""
            chkHoleSmallerThan1Inch.Checked = False
            txtHoleSmallerThan1Inch.Text = ""
            chkNOTCH.Checked = False
            txtNOTCH.Text = ""
            chkHINGE.Checked = False
            txtHINGE.Text = ""
            chkPATCH.Checked = False
            txtPATCH.Text = ""
            txtProductPrice.Text = ""
            txtComments.Text = ""
            btnAddProduct.Text = "Add"
            txtQTY.Text = 1
            lblRegularPolishInch.Visible = False
            lblShapePolishInch.Visible = False
            lblMiterInch.Visible = False
            chkRegularPolish.Visible = False
            chkShapePolish.Visible = False
            chkMiter.Visible = False
            chkHoleLargerThan1Inch.Visible = False
            chkHoleSmallerThan1Inch.Visible = False
            txtRegularPolish.Visible = False
            txtShapePolish.Visible = False
            txtMiter.Visible = False
            txtHoleLargerThan1Inch.Visible = False
            txtHoleSmallerThan1Inch.Visible = False
            txtCustomizeService.Text = ""
            chkCustomizeService.Checked = False


        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error ClearForm")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "ClearForm - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub EditProduct(ByVal sItemNumber As String)
        Try
            ClearForm()
            miID = MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("ID")))
            Dim dt As New DataTable
            dt = MyGrid.AC_GridDataSet.Tables(MyGrid.AC_GridDataSet.Tables.Count - 1)
            For j As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item("ItemNumber").ToString = sItemNumber Then
                    mbGettingData = True
                    'cboProduct.Text = dt.Rows(j).Item("Name").ToString
                    cboProduct.Text = dt.Rows(j).Item("GlassName_1").ToString
                    cboProduct_2.Text = dt.Rows(j).Item("GlassName_2").ToString
                    chkUseOption1.Checked = dt.Rows(j).Item("CostOption_1")
                    chkUseOption2.Checked = dt.Rows(j).Item("CostOption_2")

                    SetupProduct(cboProduct.Text)
                    For i As Integer = 0 To arrRB.Count - 1
                        If arrRB(i).Text = dt.Rows(j).Item("Thickness").ToString Then
                            FillProductDetail(arrRB(i).Text)
                            arrRB(i).Checked = True
                            Exit For
                        End If

                    Next

                    txtWidth_1.Text = dt.Rows(j).Item("Width_1").ToString.ToUpper
                    txtWidth_2.Text = dt.Rows(j).Item("Width_2").ToString.ToUpper
                    txtWidth_3.Text = dt.Rows(j).Item("Width_3").ToString.ToUpper
                    txtHeight_1.Text = dt.Rows(j).Item("Height_1").ToString.ToUpper
                    txtHeight_2.Text = dt.Rows(j).Item("Height_2").ToString.ToUpper
                    txtHeight_3.Text = dt.Rows(j).Item("Height_3").ToString.ToUpper
                    If Not dt.Rows(j).Item("PolishLong").ToString.Trim = "" Then
                        If dt.Rows(j).Item("PolishLong").ToString.Contains("1") Then
                            chk1L.Checked = True
                        Else
                            chk2L.Checked = True
                        End If
                    End If
                    If Not dt.Rows(j).Item("PolishShort").ToString.Trim = "" Then
                        If dt.Rows(j).Item("PolishShort").ToString.Contains("1") Then
                            chk1S.Checked = True
                        Else
                            chk2S.Checked = True
                        End If
                    End If

                    IIf(dt.Rows(j).Item("PolishLong").ToString.Contains("1"), chk1L.Checked = True, chk2L.Checked = True)
                    IIf(dt.Rows(j).Item("PolishShort").ToString.Contains("1"), chk1S.Checked = True, chk2S.Checked = True)
                    If Val(dt.Rows(j).Item("PolishRegular").ToString) > 0 Then
                        chkRegularPolish.Checked = True
                        txtRegularPolish.Text = Val(dt.Rows(j).Item("PolishRegular").ToString)
                    End If
                    If Val(dt.Rows(j).Item("PolishShape").ToString) > 0 Then
                        chkShapePolish.Checked = True
                        txtShapePolish.Text = Val(dt.Rows(j).Item("PolishShape").ToString)
                    End If
                    If Val(dt.Rows(j).Item("Miter1Inch").ToString) > 0 Then
                        chkMiter.Checked = True
                        txtMiter.Text = Val(dt.Rows(j).Item("Miter1Inch").ToString)
                    End If

                    If Val(dt.Rows(j).Item("HoleLargerThan1Inch")) > 0 Then
                        chkHoleLargerThan1Inch.Checked = True
                        txtHoleLargerThan1Inch.Text = dt.Rows(j).Item("HoleLargerThan1Inch").ToString
                    End If
                    If Val(dt.Rows(j).Item("HoleSmallerEqual1Inch")) > 0 Then
                        chkHoleSmallerThan1Inch.Checked = True
                        txtHoleSmallerThan1Inch.Text = dt.Rows(j).Item("HoleSmallerEqual1Inch").ToString
                    End If
                    If Val(dt.Rows(j).Item("Noth")) > 0 Then
                        chkNOTCH.Checked = True
                        txtNOTCH.Text = dt.Rows(j).Item("Noth").ToString
                    End If
                    If Val(dt.Rows(j).Item("Hinge")) > 0 Then
                        chkHINGE.Checked = True
                        txtHINGE.Text = dt.Rows(j).Item("Hinge").ToString
                    End If
                    If Val(dt.Rows(j).Item("Patch")) > 0 Then
                        chkPATCH.Checked = True
                        txtPATCH.Text = dt.Rows(j).Item("Patch").ToString
                    End If
                    If Val(dt.Rows(j).Item("CustomizeService")) > 0 Then
                        chkCustomizeService.Checked = True
                        txtCustomizeService.Text = dt.Rows(j).Item("CustomizeService").ToString
                    End If
                    msItemNumber = dt.Rows(j).Item("ItemNumber").ToString
                    txtComments.Text = dt.Rows(j).Item("Comments").ToString
                    txtQTY.Text = dt.Rows(j).Item("QTY").ToString

                    If dt.Rows(j).Item("AdditionalAddon").ToString = "" Then
                        txtAdditionalAddonPrice.Text = ""
                        cboAdditionalAddon.Text = ""
                    Else
                        txtAdditionalAddonPrice.Text = dt.Rows(j).Item("AdditionalAddonPrice").ToString
                        cboAdditionalAddon.Text = dt.Rows(j).Item("AdditionalAddon").ToString & " @ $" & txtAdditionalAddonPrice.Text
                    End If
                   
                    txtProductPrice.Text = FormatCurrency(GetProductTotalWithOptions())
                    btnAddProduct.Text = "Update"
                    SelectRB(dt.Rows(j).Item("Thickness").ToString)
                    ' msThickness = dt.Rows(j).Item("Thickness").ToString

                    If Not msThickness.Trim = "" Then
                        mbThinknessSelected = True
                    End If

                    Exit For
                End If

            Next

            If Not dt Is Nothing Then dt.Dispose()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error EditProduct")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "EditProduct - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            mbGettingData = False
        End Try
    End Sub
    Private Sub SelectRB(sThicknessOA As String)
        Try
            For j As Integer = 0 To arrRB.Count - 1
                If arrRB(j).Text = sThicknessOA Then
                    arrRB(j).Checked = True
                    Exit For
                End If
            Next
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error SelectRB")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "SelectRB - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Function ValidInput() As Boolean
        Dim bValid As Boolean = False
        Try

            'For i As Integer = 0 To arrRB.Count - 1
            '    If arrRB(i).Checked Then

            '        FillProductDetail(arrRB(i).Text)

            '        Exit For
            '    End If
            'Next


            If msTempOrderNumber = "" And txtOrderNumber.Text = "" Then
                MessageBox.Show("No Order Number found.", "Order Number Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ElseIf cboProduct.Text.Trim = "" Then
                MessageBox.Show("Please Select Glass Type!")
            ElseIf Not mbThinknessSelected Then
                MessageBox.Show("Please Select Glass Thinkness!")
            ElseIf txtWidth_1.Text.Trim = "" And (txtWidth_2.Text.Trim = "" Or txtWidth_3.Text.Trim = "") Then
                MessageBox.Show("Please enter Width in Inch!", "Missing width", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf txtHeight_1.Text.Trim = "" And (txtHeight_2.Text.Trim = "" Or txtHeight_3.Text.Trim = "") Then
                MessageBox.Show("Please enter Height in Inch!", "Missing width", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Not (Val(txtHeight_1.Text)) > 0 Then
                If (Val(txtHeight_2.Text) > Val(txtHeight_3.Text)) And (Val(txtHeight_2.Text) <= 0 And Val(txtHeight_3.Text) <= 0) Then
                    MessageBox.Show("Incorrect Height had Entered!")
                End If
            ElseIf Not (Val(txtWidth_1.Text)) > 0 Then
                If (Val(txtWidth_2.Text) > Val(txtWidth_3.Text)) And (Val(txtWidth_2.Text) <= 0 And Val(txtWidth_3.Text) <= 0) Then
                    MessageBox.Show("Incorrect Width Had Entered!")
                End If
                MessageBox.Show("Please Enter Width!")
            ElseIf Val(txtWidth_2.Text) > Val(txtWidth_3.Text) Then
                MessageBox.Show("Incorrect Width had Entered!")
            ElseIf Val(txtWidth_2.Text) > Val(txtWidth_3.Text) Then
                MessageBox.Show("Incorrect Width had Entered!")
            ElseIf Val(txtHeight_2.Text) > Val(txtHeight_2.Text) Then
                MessageBox.Show("Incorrect Height had Entered!")
            Else
                bValid = True
            End If

            Return bValid
        Catch exp As Exception
            Return bValid
            If gbDebugDisplayMSG Then MessageBox.Show("Error ValidInput")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "ValidInput - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Function
    Private Function GetProductTotalWithOptions() As Double
        'Dim dSQF As Double = 0
        Dim dTotalPrice As Double = 0.0
        Dim dTotalPrice_2 As Double = 0.0
        'Dim iWidthInFoot As Integer = 0
        'Dim iHeightInFoot As Integer = 0
        Dim iWidthInInch As Integer = 0
        Dim iHeightInInch As Integer = 0
        Dim iLongInInch As Integer = 0
        Dim iShortInInch As Integer = 0
        Dim dRow() As DataRow = dt_ItemPrice.Select("ProductName = '" & cboProduct.Text & "'")
        Dim dRow_2() As DataRow = dt_ItemPrice_2.Select("ProductName = '" & cboProduct_2.Text & "'")
        Dim iPrice As Double = 0
        Dim iPrice_2 As Double = 0
        Try

            If Val(txtWidth_2.Text) = 0 And Val(txtWidth_3.Text) = 0 Then
                iWidthInInch = Val(txtWidth_1.Text)
            Else
                iWidthInInch = Val(txtWidth_1.Text) + 1
            End If

            If Val(txtHeight_2.Text) = 0 And Val(txtHeight_3.Text) = 0 Then
                iHeightInInch = Val(txtHeight_1.Text)
            Else
                iHeightInInch = Val(txtHeight_1.Text) + 1
            End If


            'iWidthInFoot = iWidthInInch * 12
            'iHeightInFoot = iHeightInInch * 12


            ' iSQF = iWidthInFoot * iHeightInFoot

            mdSQ_FT = Format((iWidthInInch * iHeightInInch) / 144, "0.00")

            '$$$$ 6/6/2014, Ricky request to have minimun SQ Feet.
            If gdMinimumSQFeet <> 0 Then
                If mdSQ_FT < gdMinimumSQFeet Then mdSQ_FT = gdMinimumSQFeet
            End If

            If mdSQ_FT > Val(dRow(0).Item("More_3")) And mdSQ_FT <= Val(dRow(0).Item("LessOrEqual_3")) Then
                iPrice = Val(dRow(0).Item("Price_3"))
            ElseIf mdSQ_FT > Val(dRow(0).Item("More_2")) And mdSQ_FT <= Val(dRow(0).Item("LessOrEqual_2")) Then
                iPrice = Val(dRow(0).Item("Price_2"))
            ElseIf mdSQ_FT > Val(dRow(0).Item("More_1")) And mdSQ_FT <= Val(dRow(0).Item("LessOrEqual_1")) Then
                iPrice = Val(dRow(0).Item("Price_1"))
            End If

            If mdSQ_FT > Val(dRow_2(0).Item("More_3")) And mdSQ_FT <= Val(dRow_2(0).Item("LessOrEqual_3")) Then
                iPrice_2 = Val(dRow_2(0).Item("Price_3"))
            ElseIf mdSQ_FT > Val(dRow_2(0).Item("More_2")) And mdSQ_FT <= Val(dRow_2(0).Item("LessOrEqual_2")) Then
                iPrice_2 = Val(dRow_2(0).Item("Price_2"))
            ElseIf mdSQ_FT > Val(dRow_2(0).Item("More_1")) And mdSQ_FT <= Val(dRow_2(0).Item("LessOrEqual_1")) Then
                iPrice_2 = Val(dRow_2(0).Item("Price_1"))
            End If

            '$$$ Glase Price Only
            'dTotalPrice = dTotalPrice + ((mbThinknessPricePreInch + iPrice) * mdSQ_FT)
            dTotalPrice = dTotalPrice + ((Val(dRow(0).Item("GlassPrice")) + iPrice) * mdSQ_FT)
            dTotalPrice_2 = dTotalPrice_2 + ((Val(dRow_2(0).Item("GlassPrice")) + iPrice_2) * mdSQ_FT)
            dTotalPrice = dTotalPrice + dTotalPrice_2



            '$$$ Options Price
            'If gbAddOnServices.Enabled Then
            If iWidthInInch > iHeightInInch Then
                iLongInInch = iWidthInInch
                iShortInInch = iHeightInInch
            Else
                iLongInInch = iHeightInInch
                iShortInInch = iWidthInInch
            End If

            'MessageBox.Show("Don't know how to caluate!!!!!!!!!!!")

            'If chk1L.Checked Then
            '    If chkRegularPolish.Checked Then
            '        dTotalPrice = dTotalPrice + (Val(chkRegularPolish.Tag) * Val(txtRegularPolish.Text))
            '    End If
            '    If chkShapePolish.Checked Then
            '        dTotalPrice = dTotalPrice + (Val(chkShapePolish.Tag) * Val(txtShapePolish.Text))
            '    End If
            '    If chkMiter.Checked Then
            '        dTotalPrice = dTotalPrice + (Val(chkMiter.Tag) * Val(txtMiter.Text))
            '    End If
            'Else

            'End If

            If chk1L.Checked Or chk2L.Checked Then

                If chk2L.Checked Then iLongInInch = iLongInInch * 2

                If chkRegularPolish.Checked Then
                    dTotalPrice = dTotalPrice + (Val(chkRegularPolish.Tag) * iLongInInch)
                End If
                If chkShapePolish.Checked Then
                    dTotalPrice = dTotalPrice + (Val(chkShapePolish.Tag) * iLongInInch)
                End If
                If chkMiter.Checked Then
                    dTotalPrice = dTotalPrice + (Val(chkMiter.Tag) * iLongInInch)
                End If

            End If

            If chk1S.Checked Or chk2S.Checked Then
                If chk2S.Checked Then iShortInInch = iShortInInch * 2

                If chkRegularPolish.Checked Then
                    dTotalPrice = dTotalPrice + (Val(chkRegularPolish.Tag) * iShortInInch)
                End If
                If chkShapePolish.Checked Then
                    dTotalPrice = dTotalPrice + (Val(chkShapePolish.Tag) * iShortInInch)
                End If
                If chkMiter.Checked Then
                    dTotalPrice = dTotalPrice + (Val(chkMiter.Tag) * iShortInInch)
                End If

            End If

            txtRegularPolish.Text = (iHeightInInch + iWidthInInch).ToString
            txtShapePolish.Text = txtRegularPolish.Text
            txtMiter.Text = txtRegularPolish.Text
            'End If


            'If chkRegularPolish.Checked Then
            '    dTotalPrice = dTotalPrice + (Val(chkRegularPolish.Tag) * Val(txtRegularPolish.Text))
            'End If
            'If chkShapePolish.Checked Then
            '    dTotalPrice = dTotalPrice + (Val(chkShapePolish.Tag) * Val(txtShapePolish.Text))
            'End If
            'If chkMiter.Checked Then
            '    dTotalPrice = dTotalPrice + (Val(chkMiter.Tag) * Val(txtMiter.Text))
            'End If
            If chkHoleLargerThan1Inch.Checked Then
                dTotalPrice = dTotalPrice + (Val(txtHoleLargerThan1Inch.Text) * Val(chkHoleLargerThan1Inch.Tag))
            End If
            If chkHoleSmallerThan1Inch.Checked Then
                dTotalPrice = dTotalPrice + (Val(txtHoleSmallerThan1Inch.Text) * Val(chkHoleSmallerThan1Inch.Tag))
            End If

            If chkNOTCH.Checked Then dTotalPrice = dTotalPrice + (Val(chkNOTCH.Tag) * Val(txtNOTCH.Text))
            If chkHINGE.Checked Then dTotalPrice = dTotalPrice + (Val(chkHINGE.Tag) * Val(txtHINGE.Text))
            If chkPATCH.Checked Then dTotalPrice = dTotalPrice + (Val(chkPATCH.Tag) * Val(txtPATCH.Text))
            If chkCustomizeService.Checked Then
                If Val(txtCustomizeService.Text) > 0 Then dTotalPrice = dTotalPrice + Val(txtCustomizeService.Text)
            End If

            '$$$$ 3/30/2015, Add addtional Price
            If cboAdditionalAddon.Text <> "" Then dTotalPrice = dTotalPrice + (Val(txtAdditionalAddonPrice.Text) * mdSQ_FT)

            dTotalPrice = dTotalPrice * Val(txtQTY.Text)
            Return dTotalPrice
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetProductTotalWithOptions")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetProductTotalWithOptions - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            Return dTotalPrice
        End Try
    End Function

    Private Sub txtWidth_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWidth_1.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtWidth_1_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtWidth_1_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtWidth_2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWidth_2.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtWidth_2_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtWidth_2_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtWidth_3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWidth_3.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtWidth_3_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtWidth_3_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtHeight_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHeight_1.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtHeight_1_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtHeight_1_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub txtHeight_2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHeight_2.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtHeight_2_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtHeight_2_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub txtHeight_3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHeight_3.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtHeight_3_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtHeight_3_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub txtQTY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQTY.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtQTY_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtQTY_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtRegularPolish_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRegularPolish.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtRegularPolish_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtRegularPolish_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtShapePolish_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShapePolish.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtRegularPolish_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtRegularPolish_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtMiter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMiter.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtMiter_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtMiter_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtHoleLargerThan1Inch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHoleLargerThan1Inch.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtHoleLargerThan1Inch_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtHoleLargerThan1Inch_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtHoleSmallerThan1Inch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHoleSmallerThan1Inch.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtHoleSmallerThan1Inch_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtHoleSmallerThan1Inch_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtNOTCH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNOTCH.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtNOTCH_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtNOTCH_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtHINGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHINGE.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtHINGE_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtHINGE_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub txtPATCH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPATCH.KeyDown
        Try
            If Not ValidateNumeric(e.KeyCode) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtPATCH_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtPATCH_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub chk1L_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk1L.CheckedChanged
        If chk1L.Checked Then
            chk2L.Checked = False
        End If
        'If Not chk1L.Checked And Not chk2L.Checked And Not chk1S.Checked And Not chk2S.Checked Then
        '    gbAddOnServices.Enabled = False
        'Else
        '    If chk1L.Checked Then chk2L.Checked = False
        '    gbAddOnServices.Enabled = True
        'End If

    End Sub

    Private Sub chk2L_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk2L.CheckedChanged
        If chk2L.Checked Then
            chk1L.Checked = False
        End If
        'If Not chk1L.Checked And Not chk2L.Checked And Not chk1S.Checked And Not chk2S.Checked Then
        '    gbAddOnServices.Enabled = False
        'Else
        '    If chk2L.Checked Then chk1L.Checked = False
        '    gbAddOnServices.Enabled = True
        'End If

    End Sub

    Private Sub chk1S_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk1S.CheckedChanged
        If chk1S.Checked Then
            chk2S.Checked = False
        End If
        'If Not chk1L.Checked And Not chk2L.Checked And Not chk1S.Checked And Not chk2S.Checked Then
        '    gbAddOnServices.Enabled = False
        'Else
        '    If chk1S.Checked Then chk2S.Checked = False
        '    gbAddOnServices.Enabled = True
        'End If

    End Sub

    Private Sub chk2S_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk2S.CheckedChanged
        If chk2S.Checked Then
            chk1S.Checked = False
        End If
        'If Not chk1L.Checked And Not chk2L.Checked And Not chk1S.Checked And Not chk2S.Checked Then
        '    gbAddOnServices.Enabled = False
        'Else
        '    If chk2S.Checked Then chk1S.Checked = False
        '    gbAddOnServices.Enabled = True
        'End If

    End Sub

    Private Sub btnUpdateTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateTotal.Click
        If Not ValidInput() Then
            txtProductPrice.Text = ""
        Else
            txtProductPrice.Text = FormatCurrency(GetProductTotalWithOptions())
        End If

    End Sub

    Private Sub chkRegularPolish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRegularPolish.CheckedChanged
        txtRegularPolish.Enabled = chkRegularPolish.Checked
    End Sub

    Private Sub chkShapePolish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShapePolish.CheckedChanged
        txtShapePolish.Enabled = chkShapePolish.Checked
    End Sub

    Private Sub chkMiter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMiter.CheckedChanged
        txtMiter.Enabled = chkMiter.Checked
    End Sub

    Private Sub chkHoleLargerThan1Inch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHoleLargerThan1Inch.CheckedChanged
        txtHoleLargerThan1Inch.Enabled = chkHoleLargerThan1Inch.Checked
    End Sub

    Private Sub chkHoleSmallerThan1Inch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHoleSmallerThan1Inch.CheckedChanged
        txtHoleSmallerThan1Inch.Enabled = chkHoleSmallerThan1Inch.Checked
    End Sub

    Private Sub chkNOTCH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNOTCH.CheckedChanged
        txtNOTCH.Enabled = chkNOTCH.Checked
    End Sub

    Private Sub chkHINGE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHINGE.CheckedChanged
        txtHINGE.Enabled = chkHINGE.Checked
    End Sub

    Private Sub chkPATCH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPATCH.CheckedChanged
        txtPATCH.Enabled = chkPATCH.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetOrderDetail(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
        GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
    End Sub

    Private Sub btnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscount.Click
        Try
            If msCustomerID = "" Then
                MessageBox.Show("Please Select Customer First!", "No Customer select", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MyGrid.RowCount = 0 Then
                MessageBox.Show("Please Add a item First!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then

                    Dim frm1 As New frmLogin
                    frm1.ShowDialog()
                    If Not frm1 Is Nothing Then frm1.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If

            Dim frm As New frmDepositDiscount
            frm.SetOrderNumber = IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text)
            frm.SetDeposit = Val(Replace(Replace(txtDeposit.Text, "$", ""), ",", ""))
            frm.SetTotalPrice = Val(Replace(Replace(txtTotalPrice.Text, "$", ""), ",", ""))
            frm.SetDiscount = Val(Replace(txtDiscount.Text, "%", ""))
            frm.ShowDialog()
            If Not frm Is Nothing Then frm.Dispose()
            GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnDiscount_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnDiscount_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnDeposit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeposit.Click
        Try
            If msCustomerID = "" Then
                MessageBox.Show("Please Select Customer First!", "No Customer select", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MyGrid.RowCount = 0 Then
                MessageBox.Show("Please Add a item First!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then

                    Dim frm1 As New frmLogin
                    frm1.ShowDialog()
                    If Not frm1 Is Nothing Then frm1.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If

            Dim frm As New frmDepositDiscount
            frm.SetOrderNumber = IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text)
            frm.SetDeposit = Val(Replace(Replace(txtDeposit.Text, "$", ""), ",", ""))
            frm.SetTotalPrice = Val(Replace(Replace(txtTotalPrice.Text, "$", ""), ",", ""))
            frm.SetDiscount = Val(Replace(txtDiscount.Text, "%", ""))
            frm.ShowDialog()
            If Not frm Is Nothing Then frm.Dispose()
            GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnDeposit_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnDeposit_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If msCustomerID = "" Then
                MessageBox.Show("Please Select Customer First!", "No Customer select", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MyGrid.RowCount = 0 Then
                MessageBox.Show("Please Add a item First!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim frm As New frmSelectPrint
            frm.SetOrderNumber = IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text)
            frm.SetCustomerName = txtCustomerName.Text
            frm.SetCompanyName = txtCustomerCompanyName.Text
            frm.SetPONumber = txtCustomerPONumber.Text
            frm.ShowDialog()
            frm.Dispose()
            'If Not txtOrderNumber.Text.Trim = "" Then
            '    If MessageBox.Show("Do you want to print Labels for this order < " & IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text) & " > ?", "Print Labels confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        PrintLabel(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text), Val(InputBox("How many set label you want to print?", "Print Lable", "1")))
            '    End If
            'End If


            'If Not gsComfirmOrderID = "" Then
            '    txtOrderNumber.Text = gsComfirmOrderID
            '    msPopCustomerID = gsComfirmOrderID
            '    GetCustomerInformation(msCustomerID)
            '    GetOrderDetail(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
            'End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnPrint_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnPrint_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            gsComfirmOrderID = ""
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub MyGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyGrid.DoubleClick
        If MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("ItemStatus"))) = "R" Then
            MessageBox.Show("Refunded Product cannot be edit", "Item Refuned", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            EditProduct(MyGrid.Item(MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("ItemNumber"))))
        End If


    End Sub

    Private Sub btnDeleteWholeOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteWholeOrder.Click
        Try

            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then

                    Dim frm1 As New frmLogin
                    frm1.ShowDialog()
                    If Not frm1 Is Nothing Then frm1.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If

            Dim frm As New frmLogin
            frm.ShowDialog()
            If Not frm Is Nothing Then frm.Dispose()
            If gbAccess Then
                gbAccess = False
            Else
                MessageBox.Show("You don't have the right to access to form < Customer Invoice>.", "Form access denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete othe order < Order Number : " & IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text) & " >?", "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                gobjADO.ExecuteSP(GetParam("DELETEORDER",
                                          miID,
                                          IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text),
                                          msCustomerID,
                                          txtCustomerName.Text,
                                          cboProduct.Text,
                                           "Temper",
                                            msThickness,
                                            Val(txtWidth_1.Text),
                                            Val(txtWidth_2.Text),
                                            Val(txtWidth_3.Text),
                                            Val(txtHeight_1.Text),
                                           Val(txtHeight_2.Text),
                                            Val(txtHeight_3.Text),
                                           Val(txtQTY.Text),
                                           IIf(chk1L.Checked, chk1L.Text, IIf(chk2L.Checked, chk2L.Text, "")),
                                           IIf(chk1S.Checked, chk1S.Text, IIf(chk2S.Checked, chk2S.Text, "")),
                                           IIf(chkRegularPolish.Checked, Val(txtRegularPolish.Text), 0),
                                           IIf(chkShapePolish.Checked, Val(txtShapePolish.Text), 0),
                                           IIf(chkMiter.Checked, Val(txtMiter.Text), 0),
                                           IIf(chkHoleLargerThan1Inch.Checked, Val(txtHoleLargerThan1Inch.Text), 0),
                                           IIf(chkHoleSmallerThan1Inch.Checked, Val(txtHoleSmallerThan1Inch.Text), 0),
                                           IIf(chkNOTCH.Checked, Val(txtNOTCH.Text), 0),
                                           IIf(chkHINGE.Checked, Val(txtHINGE.Text), 0),
                                            IIf(chkPATCH.Checked, Val(txtPATCH.Text), 0),
                                            txtComments.Text.Trim,
                                            dtDelieveryDate.Value,
                                            cboDeliveryMethod.Text,
                                           miID,
                                          msItemNumber,
                                         Val(Replace(Replace(txtProductPrice.Text, "$", ""), ",", "")),
                                         Val(Replace(Replace(txtDeposit.Text, "$", ""), ",", "")),
                                         Val(Replace(txtDiscount.Text, "%", "")),
                                         Val(mdSQ_FT),
                                         IIf(chkTaxExemption.Checked, "Y", "N"),
                                          If(chkCustomizeService.Checked, Val(txtCustomizeService.Text), 0.0),
                                          txtCustomerPONumber.Text,
                                          Val(txtDeliveryCharge.Text),
                                          cboProduct.Text,
                                          cboProduct_2.Text,
                                          chkUseOption1.Checked,
                                          chkUseOption2.Checked,
                                          txtJobSite.Text.Trim,
                                          txtAdditionalAddonPrice.Tag,
                                          Val(txtAdditionalAddonPrice.Text)), mCmd_AddProduct)

                '8/30/2014, use new cbo for delivery type
                gobjADO.ExecuteSP(GetParam("DELETE", "", msTempOrderNumber, dtDelieveryDate.Value, cboDeliveryMethod.Text, IIf(chkTaxExemption.Checked, "Y", "N"), txtOrderComment.Text, txtCustomerPONumber.Text, Val(txtDeliveryCharge.Text), txtJobSite.Text.Trim), mCmd_UpdateOrderNumber)
                miID = 0
                btnAddProduct.Text = "Add"
                ClearForm()
                txtSubtotal.Text = ""
                txtTax.Text = ""
                txtDiscount.Text = ""
                txtTotalPrice.Text = ""
                txtDeposit.Text = ""
                txtRemaining.Text = ""
                ClearForm()
                msTempOrderNumber = GetNewReceiptNumber()
                msCustomerID = ""
                GetOrderDetail("")
                GetTotalPriceDisplay("")
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnDeleteWholeOrder_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnDeleteWholeOrder_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnTest2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each MyControl As RBButton In gbThickness.Controls.OfType(Of RBButton)()

            'MyControl.PerformClick()
            MyControl.Checked = True
            Exit For

        Next
    End Sub

    Private Sub btnRemoveItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItems.Click
        Try

            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then

                    Dim frm As New frmLogin
                    frm.ShowDialog()
                    If Not frm Is Nothing Then frm.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If
            For j As Integer = 0 To MyGrid.SelectedRows.Count - 1
                gobjADO.ExecuteSP(GetParam(MyGrid.Item(MyGrid.SelectedRows.Item(j), "OrderNumber").ToString, MyGrid.Item(MyGrid.SelectedRows.Item(j), "ItemNumber").ToString, Val(MyGrid.Item(MyGrid.SelectedRows.Item(j), "ID"))), mCmd_RemoveProduct)
            Next
            GetOrderDetail(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
            GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
            MyGrid.SelectedRows.Clear()
            btnRemoveItems.Enabled = False
            btnRemoveItems.Visible = False
            btnRefund.Enabled = False
            btnRefund.Visible = False
            btnPrintLabel.Enabled = False
            btnPrintLabel.Visible = False
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnRemoveItems_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnRemoveItems_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub MyGrid_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles MyGrid.FetchRowStyle
        Try

            If MyGrid.Columns("ItemStatus").CellValue(e.Row).ToString.ToUpper = "R" Then
                ' MyGrid.Row, MyGrid.Columns.IndexOf(MyGrid.Columns("ItemStatus"))
                e.CellStyle.BackColor = Color.LightPink
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MyGrid_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MyGrid.SelChange
        If MyGrid.SelectedRows.Count > 0 Then
            btnRemoveItems.Enabled = True
            btnRemoveItems.Visible = True
            btnRefund.Enabled = True
            btnRefund.Visible = True
            btnPrintLabel.Enabled = True
            btnPrintLabel.Visible = True
        Else
            btnRemoveItems.Enabled = False
            btnRemoveItems.Visible = False
            btnRefund.Enabled = False
            btnRefund.Visible = False
            btnPrintLabel.Enabled = False
            btnPrintLabel.Visible = False
        End If
    End Sub

    Private Sub chkTaxExemption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTaxExemption.CheckedChanged
        If chkTaxExemption.Checked Then
            chkTaxExemption.BackColor = Color.Red
        Else
            chkTaxExemption.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If MyGrid.RowCount <= 0 Then
                Exit Sub
            End If

            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then

                    Dim frm As New frmLogin
                    frm.ShowDialog()
                    If Not frm Is Nothing Then frm.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If
            '8/30/2014, update using cbo for delivery
            gobjADO.ExecuteSP(GetParam("UPDATE", txtOrderNumber.Text, msTempOrderNumber, dtDelieveryDate.Value, cboDeliveryMethod.Text, IIf(chkTaxExemption.Checked, "Y", "N"), txtOrderComment.Text, txtCustomerPONumber.Text, Val(txtDeliveryCharge.Text), txtJobSite.Text.Trim), mCmd_UpdateOrderNumber)
            'msTempOrderNumber = txtOrderNumber.Text
            GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))

            MessageBox.Show("Successfully updated order.", "Order Updated Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnUpdate_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnUpdate_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
            mbLockUpdate = True
        End Try
    End Sub

    Private Sub txtCustomizeService_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomizeService.KeyDown
        Try
            If Not (ValidateNumeric(e.KeyCode) Or e.KeyCode = 190) Then
                e.SuppressKeyPress = True
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error txtCustomizeService_KeyDown")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "txtCustomizeService_KeyDown - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub chkCustomizeService_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomizeService.CheckedChanged
        txtCustomizeService.Enabled = chkCustomizeService.Checked
    End Sub



    Private Sub btnComfirmOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComfirmOrder.Click

        If msCustomerID = "" Then
            MessageBox.Show("Cannot comfirm order without Customer!", "No Customer select", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MyGrid.RowCount = 0 Then
            MessageBox.Show("Cannot comfirm order without any item!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'txtOrderNumber.Text = GetNewReceiptNumber()
        dtDelieveryDate.Value = Today.AddDays(5)
        '8/30/2014, Using cbo for delivery option
        gobjADO.ExecuteSP(GetParam("COMFIRMORDER", txtOrderNumber.Text, msTempOrderNumber, dtDelieveryDate.Value, cboDeliveryMethod.Text, IIf(chkTaxExemption.Checked, "Y", "N"), txtOrderComment.Text, txtCustomerPONumber.Text, Val(txtDeliveryCharge.Text), txtJobSite.Text.Trim), mCmd_UpdateOrderNumber)
        '  btnComfirmOrder.Enabled = False
        btnComfirmOrder.Visible = False

    End Sub

    Private Sub btnRefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefund.Click
        Try

            If msOrderStatus.ToUpper = "CLOSED" Then
                If mbLockUpdate Then

                    Dim frm As New frmLogin
                    frm.ShowDialog()
                    If Not frm Is Nothing Then frm.Dispose()
                    If gbAccess Then
                        gbAccess = False
                        mbLockUpdate = False
                    Else
                        MessageBox.Show("You don't have the right to update this order.", "Form Update denied!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If
            For j As Integer = 0 To MyGrid.SelectedRows.Count - 1
                If Not MyGrid.Item(MyGrid.SelectedRows.Item(j), "ItemStatus").ToString.ToUpper = "R" Then
                    gobjADO.ExecuteSP(GetParam(MyGrid.Item(MyGrid.SelectedRows.Item(j), "OrderNumber").ToString, MyGrid.Item(MyGrid.SelectedRows.Item(j), "ItemNumber").ToString, Val(MyGrid.Item(MyGrid.SelectedRows.Item(j), "ID"))), mCmd_UpdateRefundItem)
                End If
            Next
            GetOrderDetail(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
            GetTotalPriceDisplay(IIf(txtOrderNumber.Text.Trim = "", msTempOrderNumber, txtOrderNumber.Text))
            MyGrid.SelectedRows.Clear()
            btnRemoveItems.Enabled = False
            btnRemoveItems.Visible = False
            btnRefund.Enabled = False
            btnRefund.Visible = False
            btnPrintLabel.Enabled = False
            btnPrintLabel.Visible = False
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnRefund_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnRefund_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub rbDelivery_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDelivery.CheckedChanged

        'Me.txtDeliveryCharge.Enabled = rbDelivery.Checked

    End Sub

    Private Sub btnPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLabel.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objPrinter As New BrotherPrinter
        Try

            For j As Integer = 0 To MyGrid.SelectedRows.Count - 1
                'With objPrinter

                '    .SetCompanyName = "Sky Land Tempering Glass Corp"
                '    .SetCustomerCompanyName = txtCustomerCompanyName.Text
                '    '.SetOrderDate = FormatDateTime(msOrderDate, DateFormat.ShortDate)
                '    '.SetDueDate = dtDelieveryDate.Value
                '    .SetPONumber = txtCustomerPONumber.Text
                '    .SetOrderNumber = txtOrderNumber.Text
                '    .SetGlassName = MyGrid.Item(MyGrid.SelectedRows(j), "Name").ToString
                '    .SetDimensions = MyGrid.Item(MyGrid.SelectedRows(j), "Size").ToString
                '    .SetsWorkDesc = MyGrid.Item(MyGrid.SelectedRows(j), "WorkDesc").ToString
                '    .SetBarcode = ""
                '    .SetQTY = Val(MyGrid.Item(MyGrid.SelectedRows(j), "QTY").ToString)
                '    .SetGlassType = MyGrid.Item(MyGrid.SelectedRows(j), "GlassType").ToString
                '    .SetDeliveryType = IIf(rbDelivery.Checked, "Delivery", "Pickup")
                '    .SetItemComment = MyGrid.Item(MyGrid.SelectedRows(j), "Comments").ToString
                '    .PrintLabel()
                'End With
                With objPrinter
                    .SetCompanyName = "SkyLand Tempering Glass Corp"
                    .SetCustomerCompanyName = txtCustomerCompanyName.Text
                    .SetPONumber = txtCustomerPONumber.Text
                    .SetOrderNumber = txtOrderNumber.Text
                    .SetDeliveryType = cboDeliveryMethod.Text



                    .SetThickness = MyGrid.Item(MyGrid.SelectedRows(j), "Thickness").ToString
                    .SetGlassDesc = MyGrid.Item(MyGrid.SelectedRows(j), "Name").ToString
                    .SetSize = MyGrid.Item(MyGrid.SelectedRows(j), "Size").ToString
                    .SetQTY = MyGrid.Item(MyGrid.SelectedRows(j), "QTY").ToString
                    .SetItemComment = MyGrid.Item(MyGrid.SelectedRows(j), "Comments").ToString
                    '.SetCopyCount = iNumberOfSetPrint * Val(dSet.Tables(2).Rows(j).Item("Order QTY").ToString)
                    .PrintLabel()
                End With
            Next j



            btnRemoveItems.Enabled = False
            btnRemoveItems.Visible = False
            btnRefund.Enabled = False
            btnRefund.Visible = False
            btnPrintLabel.Enabled = False
            btnPrintLabel.Visible = False
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnPrintLabel_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnPrintLabel_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            objPrinter.Dispose()
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub GetShippingAddress()
        Try
            Using dTable As DataTable = SQL_GetAllTableData("tb_POS_ShipToAddress", " WHERE CustomerID =  '" & msCustomerID & "' AND OrderNumber = '" & txtOrderNumber.Text & "'")
                If dTable.Rows.Count > 0 Then
                    btnSetShippingAddress.BackColor = Color.Transparent
                Else
                    btnSetShippingAddress.BackColor = gObjMyColors.cNeedAction
                End If
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error GetShippingAddress")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "GetShippingAddress - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub btnSetShippingAddress_Click(sender As System.Object, e As System.EventArgs) Handles btnSetShippingAddress.Click
        Try
            Using frm As New frm_SelectShipAddress
                frm.SetCompanyAddress = txtCustomerAddress.Text
                frm.SetCompanyCity = txtCustomerCity.Text
                frm.SetCompanyName = txtCustomerCompanyName.Text
                frm.SetCompanyState = txtCustomerState.Text
                frm.SetCompanyZip = txtCustomerZip.Text
                frm.SetCustomerID = msCustomerID
                frm.SetOrderNumber = txtOrderNumber.Text
                frm.ShowDialog()
            End Using
            'btnSetShippingAddress.BackColor = Color.Transparent
            GetShippingAddress()
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnSetShippingAddress_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "btnSetShippingAddress_Click - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub cboProduct_2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProduct_2.SelectedIndexChanged
        Try
            SetupProduct(cboProduct_2.Text, True)
            msThickness = ""
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error cboProduct_2_SelectedIndexChanged")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "cboProduct_2_SelectedIndexChanged - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub txtCustomerCompanyName_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCompanyName.TextChanged
        Try
            If txtCustomerCompanyName.Text.Trim = "" And txtCustomerName.Text.Trim = "" Then
                cboProduct.Enabled = False
                cboProduct_2.Enabled = False
            Else
                cboProduct.Enabled = True
                cboProduct_2.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetupThickness()
        Try
            Using dTable As DataTable = SQL_GetAllTableData("tb_Thickness")

                ReDim arrRB(dTable.Rows.Count - 1)
                For j As Integer = 0 To dTable.Rows.Count - 1
                    arrRB(j) = New RBButton
                    arrRB(j).Parent = rbTemp.Parent
                    arrRB(j).Size = rbTemp.Size
                    arrRB(j).BackColor = rbTemp.BackColor
                    arrRB(j).Visible = True
                    arrRB(j).Enabled = True

                    arrRB(j).BringToFront()
                    AddHandler arrRB(j).Click, AddressOf ThinknessRadioSelect

                    If j = 0 Then
                        arrRB(j).Top = rbTemp.Top
                        arrRB(j).Left = rbTemp.Left
                    Else
                        arrRB(j).Top = arrRB(j - 1).Top + arrRB(j - 1).Height + 15
                        arrRB(j).Left = arrRB(j - 1).Left
                    End If
                    arrRB(j).Text = dTable.Rows(j).Item("Thickness").ToString
                    arrRB(j).AutoSize = True
                Next

            End Using

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error SetupThickness")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "SetupThickness - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub ClearThickness()
        Try
            For j As Integer = 0 To arrRB.Count - 1
                arrRB(j).Checked = False
            Next
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error ClearThickness")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "ClearThickness - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub cboAdditionalAddon_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAdditionalAddon.SelectedIndexChanged
        Try
            If cboAdditionalAddon.Text = "" Then
                txtAdditionalAddonPrice.Text = ""
                txtAdditionalAddonPrice.Tag = ""
                Exit Sub
            End If

            Dim arrTemp As Array = cboAdditionalAddon.Text.Split("@")
            txtAdditionalAddonPrice.Tag = arrTemp(0).ToString
            txtAdditionalAddonPrice.Text = arrTemp(arrTemp.Length - 1).ToString.Replace("$", "")
           
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error cboAdditionalAddon_SelectedIndexChanged")
            LogToSystemEvent(gsApplicationClientID, Me.Name, "cboAdditionalAddon_SelectedIndexChanged - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    
End Class
