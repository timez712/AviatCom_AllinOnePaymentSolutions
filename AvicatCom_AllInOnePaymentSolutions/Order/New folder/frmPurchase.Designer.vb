<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrderInput))
        Me.gbPurchaseItems = New System.Windows.Forms.GroupBox()
        Me.btnPrintLabel = New System.Windows.Forms.Button()
        Me.btnRefund = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOrderComment = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.chkTaxExemption = New System.Windows.Forms.CheckBox()
        Me.btnRemoveItems = New System.Windows.Forms.Button()
        Me.txtRemaining = New System.Windows.Forms.TextBox()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.txtTax = New System.Windows.Forms.TextBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnDiscount = New System.Windows.Forms.Button()
        Me.btnDeposit = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnDeleteWholeOrder = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAdditionalAddonPrice = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboAdditionalAddon = New System.Windows.Forms.ComboBox()
        Me.chkUseOption2 = New System.Windows.Forms.CheckBox()
        Me.chkUseOption1 = New System.Windows.Forms.CheckBox()
        Me.cboProduct_2 = New System.Windows.Forms.ComboBox()
        Me.gbSetShipAddress = New System.Windows.Forms.GroupBox()
        Me.btnSetShippingAddress = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.chk2S = New System.Windows.Forms.CheckBox()
        Me.btnUpdateTotal = New System.Windows.Forms.Button()
        Me.txtProductPrice = New System.Windows.Forms.TextBox()
        Me.chk1S = New System.Windows.Forms.CheckBox()
        Me.chk2L = New System.Windows.Forms.CheckBox()
        Me.lblProdctPrice = New System.Windows.Forms.Label()
        Me.chk1L = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbExtra = New System.Windows.Forms.GroupBox()
        Me.txtCustomizeService = New System.Windows.Forms.TextBox()
        Me.chkCustomizeService = New System.Windows.Forms.CheckBox()
        Me.txtPATCH = New System.Windows.Forms.TextBox()
        Me.chkPATCH = New System.Windows.Forms.CheckBox()
        Me.txtHINGE = New System.Windows.Forms.TextBox()
        Me.chkHINGE = New System.Windows.Forms.CheckBox()
        Me.txtNOTCH = New System.Windows.Forms.TextBox()
        Me.chkNOTCH = New System.Windows.Forms.CheckBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.gbAddOnServices = New System.Windows.Forms.GroupBox()
        Me.lblMiterInch = New System.Windows.Forms.Label()
        Me.lblShapePolishInch = New System.Windows.Forms.Label()
        Me.lblRegularPolishInch = New System.Windows.Forms.Label()
        Me.txtHoleSmallerThan1Inch = New System.Windows.Forms.TextBox()
        Me.chkHoleSmallerThan1Inch = New System.Windows.Forms.CheckBox()
        Me.txtHoleLargerThan1Inch = New System.Windows.Forms.TextBox()
        Me.chkHoleLargerThan1Inch = New System.Windows.Forms.CheckBox()
        Me.txtMiter = New System.Windows.Forms.TextBox()
        Me.chkMiter = New System.Windows.Forms.CheckBox()
        Me.txtShapePolish = New System.Windows.Forms.TextBox()
        Me.chkShapePolish = New System.Windows.Forms.CheckBox()
        Me.txtRegularPolish = New System.Windows.Forms.TextBox()
        Me.chkRegularPolish = New System.Windows.Forms.CheckBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.gbDimensions = New System.Windows.Forms.GroupBox()
        Me.txtHeight_3 = New System.Windows.Forms.TextBox()
        Me.txtHeight_2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHeight_1 = New System.Windows.Forms.TextBox()
        Me.txtWidth_3 = New System.Windows.Forms.TextBox()
        Me.txtWidth_2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblQTY = New System.Windows.Forms.Label()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.txtWidth_1 = New System.Windows.Forms.TextBox()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbThickness = New System.Windows.Forms.GroupBox()
        Me.rbTemp = New System.Windows.Forms.RadioButton()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOrderNumber = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtJobSite = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboDeliveryMethod = New System.Windows.Forms.ComboBox()
        Me.txtDeliveryCharge = New System.Windows.Forms.TextBox()
        Me.txtCustomerPONumber = New System.Windows.Forms.TextBox()
        Me.lblCustomerPO = New System.Windows.Forms.Label()
        Me.btnComfirmOrder = New System.Windows.Forms.Button()
        Me.rbDelivery = New System.Windows.Forms.RadioButton()
        Me.rbPickup = New System.Windows.Forms.RadioButton()
        Me.txtCustomerName = New System.Windows.Forms.MaskedTextBox()
        Me.dtDelieveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCustomerCompanyName = New System.Windows.Forms.Label()
        Me.txtCustomerCompanyName = New System.Windows.Forms.MaskedTextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomerZip = New System.Windows.Forms.MaskedTextBox()
        Me.txtCustomerState = New System.Windows.Forms.MaskedTextBox()
        Me.txtCustomerAddress = New System.Windows.Forms.MaskedTextBox()
        Me.txtCustomerCity = New System.Windows.Forms.MaskedTextBox()
        Me.txtPhoneNumber = New System.Windows.Forms.MaskedTextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbPurchaseItems.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.gbSetShipAddress.SuspendLayout()
        Me.gbExtra.SuspendLayout()
        Me.gbAddOnServices.SuspendLayout()
        Me.gbDimensions.SuspendLayout()
        Me.gbThickness.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPurchaseItems
        '
        Me.gbPurchaseItems.Controls.Add(Me.btnPrintLabel)
        Me.gbPurchaseItems.Controls.Add(Me.btnRefund)
        Me.gbPurchaseItems.Controls.Add(Me.Label8)
        Me.gbPurchaseItems.Controls.Add(Me.txtOrderComment)
        Me.gbPurchaseItems.Controls.Add(Me.btnUpdate)
        Me.gbPurchaseItems.Controls.Add(Me.chkTaxExemption)
        Me.gbPurchaseItems.Controls.Add(Me.btnRemoveItems)
        Me.gbPurchaseItems.Controls.Add(Me.txtRemaining)
        Me.gbPurchaseItems.Controls.Add(Me.txtDeposit)
        Me.gbPurchaseItems.Controls.Add(Me.txtTotalPrice)
        Me.gbPurchaseItems.Controls.Add(Me.txtDiscount)
        Me.gbPurchaseItems.Controls.Add(Me.txtTax)
        Me.gbPurchaseItems.Controls.Add(Me.txtSubtotal)
        Me.gbPurchaseItems.Controls.Add(Me.Label14)
        Me.gbPurchaseItems.Controls.Add(Me.Label13)
        Me.gbPurchaseItems.Controls.Add(Me.Label12)
        Me.gbPurchaseItems.Controls.Add(Me.Label11)
        Me.gbPurchaseItems.Controls.Add(Me.Label10)
        Me.gbPurchaseItems.Controls.Add(Me.Label9)
        Me.gbPurchaseItems.Controls.Add(Me.btnDiscount)
        Me.gbPurchaseItems.Controls.Add(Me.btnDeposit)
        Me.gbPurchaseItems.Controls.Add(Me.btnPrint)
        Me.gbPurchaseItems.Controls.Add(Me.btnQuit)
        Me.gbPurchaseItems.Controls.Add(Me.C1TrueDBGrid1)
        Me.gbPurchaseItems.Controls.Add(Me.btnDeleteWholeOrder)
        Me.gbPurchaseItems.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPurchaseItems.Location = New System.Drawing.Point(889, 12)
        Me.gbPurchaseItems.Name = "gbPurchaseItems"
        Me.gbPurchaseItems.Size = New System.Drawing.Size(583, 738)
        Me.gbPurchaseItems.TabIndex = 0
        Me.gbPurchaseItems.TabStop = False
        Me.gbPurchaseItems.Text = "Purchase Items"
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPrintLabel.Location = New System.Drawing.Point(86, 496)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(64, 68)
        Me.btnPrintLabel.TabIndex = 193
        Me.btnPrintLabel.Text = "Print Label"
        Me.btnPrintLabel.UseVisualStyleBackColor = False
        Me.btnPrintLabel.Visible = False
        '
        'btnRefund
        '
        Me.btnRefund.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefund.Enabled = False
        Me.btnRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefund.Location = New System.Drawing.Point(12, 533)
        Me.btnRefund.Name = "btnRefund"
        Me.btnRefund.Size = New System.Drawing.Size(68, 32)
        Me.btnRefund.TabIndex = 192
        Me.btnRefund.Text = "Refund"
        Me.btnRefund.UseVisualStyleBackColor = False
        Me.btnRefund.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(157, 486)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(205, 18)
        Me.Label8.TabIndex = 191
        Me.Label8.Text = "Order Comment : (100 Char)"
        '
        'txtOrderComment
        '
        Me.txtOrderComment.Location = New System.Drawing.Point(159, 509)
        Me.txtOrderComment.MaxLength = 100
        Me.txtOrderComment.Multiline = True
        Me.txtOrderComment.Name = "txtOrderComment"
        Me.txtOrderComment.Size = New System.Drawing.Size(192, 164)
        Me.txtOrderComment.TabIndex = 190
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Lime
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(322, 689)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(146, 40)
        Me.btnUpdate.TabIndex = 189
        Me.btnUpdate.Text = "Update / Save"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'chkTaxExemption
        '
        Me.chkTaxExemption.AutoSize = True
        Me.chkTaxExemption.BackColor = System.Drawing.Color.Transparent
        Me.chkTaxExemption.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkTaxExemption.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTaxExemption.Location = New System.Drawing.Point(159, 689)
        Me.chkTaxExemption.Name = "chkTaxExemption"
        Me.chkTaxExemption.Size = New System.Drawing.Size(152, 40)
        Me.chkTaxExemption.TabIndex = 183
        Me.chkTaxExemption.Text = "Tax Exemption"
        Me.chkTaxExemption.UseVisualStyleBackColor = False
        '
        'btnRemoveItems
        '
        Me.btnRemoveItems.BackColor = System.Drawing.Color.Crimson
        Me.btnRemoveItems.Enabled = False
        Me.btnRemoveItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveItems.Location = New System.Drawing.Point(12, 494)
        Me.btnRemoveItems.Name = "btnRemoveItems"
        Me.btnRemoveItems.Size = New System.Drawing.Size(68, 33)
        Me.btnRemoveItems.TabIndex = 182
        Me.btnRemoveItems.Text = "Remove"
        Me.btnRemoveItems.UseVisualStyleBackColor = False
        Me.btnRemoveItems.Visible = False
        '
        'txtRemaining
        '
        Me.txtRemaining.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemaining.Location = New System.Drawing.Point(462, 644)
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.ReadOnly = True
        Me.txtRemaining.Size = New System.Drawing.Size(115, 29)
        Me.txtRemaining.TabIndex = 180
        '
        'txtDeposit
        '
        Me.txtDeposit.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeposit.Location = New System.Drawing.Point(462, 613)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.ReadOnly = True
        Me.txtDeposit.Size = New System.Drawing.Size(115, 29)
        Me.txtDeposit.TabIndex = 179
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.Location = New System.Drawing.Point(462, 582)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(115, 29)
        Me.txtTotalPrice.TabIndex = 178
        '
        'txtDiscount
        '
        Me.txtDiscount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Location = New System.Drawing.Point(462, 551)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.Size = New System.Drawing.Size(115, 29)
        Me.txtDiscount.TabIndex = 177
        '
        'txtTax
        '
        Me.txtTax.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTax.Location = New System.Drawing.Point(462, 520)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.ReadOnly = True
        Me.txtTax.Size = New System.Drawing.Size(115, 29)
        Me.txtTax.TabIndex = 176
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(462, 489)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(115, 29)
        Me.txtSubtotal.TabIndex = 175
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(380, 618)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 20)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "Deposit :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(357, 649)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 20)
        Me.Label13.TabIndex = 172
        Me.Label13.Text = "Remaining :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(371, 556)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 20)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = "Discount :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(402, 587)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 20)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Total :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(414, 525)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 20)
        Me.Label10.TabIndex = 169
        Me.Label10.Text = "Tax :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(371, 494)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 20)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Subtotal :"
        '
        'btnDiscount
        '
        Me.btnDiscount.BackColor = System.Drawing.Color.Yellow
        Me.btnDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiscount.Location = New System.Drawing.Point(12, 571)
        Me.btnDiscount.Name = "btnDiscount"
        Me.btnDiscount.Size = New System.Drawing.Size(139, 34)
        Me.btnDiscount.TabIndex = 161
        Me.btnDiscount.Text = "Discount"
        Me.btnDiscount.UseVisualStyleBackColor = False
        '
        'btnDeposit
        '
        Me.btnDeposit.BackColor = System.Drawing.Color.Cyan
        Me.btnDeposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeposit.Location = New System.Drawing.Point(12, 611)
        Me.btnDeposit.Name = "btnDeposit"
        Me.btnDeposit.Size = New System.Drawing.Size(139, 34)
        Me.btnDeposit.TabIndex = 160
        Me.btnDeposit.Text = "Deposit"
        Me.btnDeposit.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Fuchsia
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(12, 649)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(139, 35)
        Me.btnPrint.TabIndex = 159
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.Red
        Me.btnQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(474, 687)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(103, 45)
        Me.btnQuit.TabIndex = 134
        Me.btnQuit.Text = "Exit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowRowSelect = False
        Me.C1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid1.CaptionHeight = 34
        Me.C1TrueDBGrid1.ExtendRightColumn = True
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(12, 18)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(565, 465)
        Me.C1TrueDBGrid1.TabIndex = 59
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid2"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'btnDeleteWholeOrder
        '
        Me.btnDeleteWholeOrder.BackColor = System.Drawing.Color.OrangeRed
        Me.btnDeleteWholeOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteWholeOrder.Location = New System.Drawing.Point(12, 689)
        Me.btnDeleteWholeOrder.Name = "btnDeleteWholeOrder"
        Me.btnDeleteWholeOrder.Size = New System.Drawing.Size(139, 36)
        Me.btnDeleteWholeOrder.TabIndex = 156
        Me.btnDeleteWholeOrder.Text = "Delete Order"
        Me.btnDeleteWholeOrder.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtAdditionalAddonPrice)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.cboAdditionalAddon)
        Me.Panel2.Controls.Add(Me.chkUseOption2)
        Me.Panel2.Controls.Add(Me.chkUseOption1)
        Me.Panel2.Controls.Add(Me.cboProduct_2)
        Me.Panel2.Controls.Add(Me.gbSetShipAddress)
        Me.Panel2.Controls.Add(Me.btnClear)
        Me.Panel2.Controls.Add(Me.chk2S)
        Me.Panel2.Controls.Add(Me.btnUpdateTotal)
        Me.Panel2.Controls.Add(Me.txtProductPrice)
        Me.Panel2.Controls.Add(Me.chk1S)
        Me.Panel2.Controls.Add(Me.chk2L)
        Me.Panel2.Controls.Add(Me.lblProdctPrice)
        Me.Panel2.Controls.Add(Me.chk1L)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.gbExtra)
        Me.Panel2.Controls.Add(Me.txtComments)
        Me.Panel2.Controls.Add(Me.gbAddOnServices)
        Me.Panel2.Controls.Add(Me.btnAddProduct)
        Me.Panel2.Controls.Add(Me.gbDimensions)
        Me.Panel2.Controls.Add(Me.gbThickness)
        Me.Panel2.Controls.Add(Me.cboProduct)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 219)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(871, 531)
        Me.Panel2.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(3, 91)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 42)
        Me.Label18.TabIndex = 197
        Me.Label18.Text = "Additional Add-On"
        '
        'txtAdditionalAddonPrice
        '
        Me.txtAdditionalAddonPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtAdditionalAddonPrice.Enabled = False
        Me.txtAdditionalAddonPrice.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdditionalAddonPrice.ForeColor = System.Drawing.Color.Blue
        Me.txtAdditionalAddonPrice.Location = New System.Drawing.Point(211, 127)
        Me.txtAdditionalAddonPrice.Name = "txtAdditionalAddonPrice"
        Me.txtAdditionalAddonPrice.Size = New System.Drawing.Size(95, 27)
        Me.txtAdditionalAddonPrice.TabIndex = 194
        Me.txtAdditionalAddonPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label17.Location = New System.Drawing.Point(192, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(17, 18)
        Me.Label17.TabIndex = 196
        Me.Label17.Text = "$"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(134, 130)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 20)
        Me.Label16.TabIndex = 195
        Me.Label16.Text = "Price :"
        '
        'cboAdditionalAddon
        '
        Me.cboAdditionalAddon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAdditionalAddon.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAdditionalAddon.FormattingEnabled = True
        Me.cboAdditionalAddon.Location = New System.Drawing.Point(99, 91)
        Me.cboAdditionalAddon.Name = "cboAdditionalAddon"
        Me.cboAdditionalAddon.Size = New System.Drawing.Size(296, 30)
        Me.cboAdditionalAddon.TabIndex = 193
        '
        'chkUseOption2
        '
        Me.chkUseOption2.AutoSize = True
        Me.chkUseOption2.Checked = True
        Me.chkUseOption2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseOption2.Location = New System.Drawing.Point(304, 12)
        Me.chkUseOption2.Name = "chkUseOption2"
        Me.chkUseOption2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUseOption2.Size = New System.Drawing.Size(78, 19)
        Me.chkUseOption2.TabIndex = 192
        Me.chkUseOption2.Text = "Cost Use"
        Me.chkUseOption2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseOption2.UseVisualStyleBackColor = True
        Me.chkUseOption2.Visible = False
        '
        'chkUseOption1
        '
        Me.chkUseOption1.AutoSize = True
        Me.chkUseOption1.Checked = True
        Me.chkUseOption1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseOption1.Location = New System.Drawing.Point(184, 12)
        Me.chkUseOption1.Name = "chkUseOption1"
        Me.chkUseOption1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUseOption1.Size = New System.Drawing.Size(78, 19)
        Me.chkUseOption1.TabIndex = 191
        Me.chkUseOption1.Text = "Cost Use"
        Me.chkUseOption1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseOption1.UseVisualStyleBackColor = True
        Me.chkUseOption1.Visible = False
        '
        'cboProduct_2
        '
        Me.cboProduct_2.Enabled = False
        Me.cboProduct_2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduct_2.FormattingEnabled = True
        Me.cboProduct_2.Location = New System.Drawing.Point(312, 37)
        Me.cboProduct_2.Name = "cboProduct_2"
        Me.cboProduct_2.Size = New System.Drawing.Size(303, 30)
        Me.cboProduct_2.TabIndex = 190
        '
        'gbSetShipAddress
        '
        Me.gbSetShipAddress.Controls.Add(Me.btnSetShippingAddress)
        Me.gbSetShipAddress.Enabled = False
        Me.gbSetShipAddress.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.gbSetShipAddress.Location = New System.Drawing.Point(630, 186)
        Me.gbSetShipAddress.Name = "gbSetShipAddress"
        Me.gbSetShipAddress.Size = New System.Drawing.Size(200, 128)
        Me.gbSetShipAddress.TabIndex = 189
        Me.gbSetShipAddress.TabStop = False
        Me.gbSetShipAddress.Text = "Set Ship Address"
        '
        'btnSetShippingAddress
        '
        Me.btnSetShippingAddress.Font = New System.Drawing.Font("Arial", 15.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetShippingAddress.Location = New System.Drawing.Point(6, 39)
        Me.btnSetShippingAddress.Name = "btnSetShippingAddress"
        Me.btnSetShippingAddress.Size = New System.Drawing.Size(183, 58)
        Me.btnSetShippingAddress.TabIndex = 0
        Me.btnSetShippingAddress.Text = "Set Shipping Address"
        Me.btnSetShippingAddress.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Gold
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(644, 462)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(103, 52)
        Me.btnClear.TabIndex = 180
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'chk2S
        '
        Me.chk2S.AutoSize = True
        Me.chk2S.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk2S.Location = New System.Drawing.Point(801, 24)
        Me.chk2S.Name = "chk2S"
        Me.chk2S.Size = New System.Drawing.Size(58, 26)
        Me.chk2S.TabIndex = 13
        Me.chk2S.Text = "2 S"
        Me.chk2S.UseVisualStyleBackColor = True
        Me.chk2S.Visible = False
        '
        'btnUpdateTotal
        '
        Me.btnUpdateTotal.BackColor = System.Drawing.Color.Aquamarine
        Me.btnUpdateTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateTotal.Location = New System.Drawing.Point(644, 419)
        Me.btnUpdateTotal.Name = "btnUpdateTotal"
        Me.btnUpdateTotal.Size = New System.Drawing.Size(216, 37)
        Me.btnUpdateTotal.TabIndex = 187
        Me.btnUpdateTotal.Text = "Update Product Price"
        Me.btnUpdateTotal.UseVisualStyleBackColor = False
        '
        'txtProductPrice
        '
        Me.txtProductPrice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductPrice.Location = New System.Drawing.Point(719, 387)
        Me.txtProductPrice.Name = "txtProductPrice"
        Me.txtProductPrice.ReadOnly = True
        Me.txtProductPrice.Size = New System.Drawing.Size(141, 26)
        Me.txtProductPrice.TabIndex = 178
        '
        'chk1S
        '
        Me.chk1S.AutoSize = True
        Me.chk1S.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk1S.Location = New System.Drawing.Point(802, 22)
        Me.chk1S.Name = "chk1S"
        Me.chk1S.Size = New System.Drawing.Size(58, 26)
        Me.chk1S.TabIndex = 12
        Me.chk1S.Text = "1 S"
        Me.chk1S.UseVisualStyleBackColor = True
        Me.chk1S.Visible = False
        '
        'chk2L
        '
        Me.chk2L.AutoSize = True
        Me.chk2L.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk2L.Location = New System.Drawing.Point(791, 21)
        Me.chk2L.Name = "chk2L"
        Me.chk2L.Size = New System.Drawing.Size(57, 26)
        Me.chk2L.TabIndex = 11
        Me.chk2L.Text = "2 L"
        Me.chk2L.UseVisualStyleBackColor = True
        Me.chk2L.Visible = False
        '
        'lblProdctPrice
        '
        Me.lblProdctPrice.AutoSize = True
        Me.lblProdctPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblProdctPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProdctPrice.Location = New System.Drawing.Point(654, 389)
        Me.lblProdctPrice.Name = "lblProdctPrice"
        Me.lblProdctPrice.Size = New System.Drawing.Size(59, 20)
        Me.lblProdctPrice.TabIndex = 167
        Me.lblProdctPrice.Text = "Total :"
        '
        'chk1L
        '
        Me.chk1L.AutoSize = True
        Me.chk1L.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk1L.Location = New System.Drawing.Point(791, 16)
        Me.chk1L.Name = "chk1L"
        Me.chk1L.Size = New System.Drawing.Size(57, 26)
        Me.chk1L.TabIndex = 10
        Me.chk1L.Text = "1 L"
        Me.chk1L.UseVisualStyleBackColor = True
        Me.chk1L.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(186, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(256, 20)
        Me.Label7.TabIndex = 177
        Me.Label7.Text = "Item Comment (45 Characters)"
        '
        'gbExtra
        '
        Me.gbExtra.Controls.Add(Me.txtCustomizeService)
        Me.gbExtra.Controls.Add(Me.chkCustomizeService)
        Me.gbExtra.Controls.Add(Me.txtPATCH)
        Me.gbExtra.Controls.Add(Me.chkPATCH)
        Me.gbExtra.Controls.Add(Me.txtHINGE)
        Me.gbExtra.Controls.Add(Me.chkHINGE)
        Me.gbExtra.Controls.Add(Me.txtNOTCH)
        Me.gbExtra.Controls.Add(Me.chkNOTCH)
        Me.gbExtra.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExtra.Location = New System.Drawing.Point(190, 285)
        Me.gbExtra.Name = "gbExtra"
        Me.gbExtra.Size = New System.Drawing.Size(309, 62)
        Me.gbExtra.TabIndex = 175
        Me.gbExtra.TabStop = False
        Me.gbExtra.Text = "Extra"
        '
        'txtCustomizeService
        '
        Me.txtCustomizeService.Enabled = False
        Me.txtCustomizeService.Location = New System.Drawing.Point(247, 22)
        Me.txtCustomizeService.Name = "txtCustomizeService"
        Me.txtCustomizeService.Size = New System.Drawing.Size(48, 26)
        Me.txtCustomizeService.TabIndex = 187
        Me.txtCustomizeService.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkCustomizeService
        '
        Me.chkCustomizeService.AutoSize = True
        Me.chkCustomizeService.Location = New System.Drawing.Point(6, 25)
        Me.chkCustomizeService.Name = "chkCustomizeService"
        Me.chkCustomizeService.Size = New System.Drawing.Size(236, 23)
        Me.chkCustomizeService.TabIndex = 186
        Me.chkCustomizeService.Text = "Customize Service/Product"
        Me.chkCustomizeService.UseVisualStyleBackColor = True
        '
        'txtPATCH
        '
        Me.txtPATCH.Enabled = False
        Me.txtPATCH.Location = New System.Drawing.Point(247, 160)
        Me.txtPATCH.Name = "txtPATCH"
        Me.txtPATCH.Size = New System.Drawing.Size(48, 26)
        Me.txtPATCH.TabIndex = 185
        Me.txtPATCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkPATCH
        '
        Me.chkPATCH.AutoSize = True
        Me.chkPATCH.Location = New System.Drawing.Point(6, 163)
        Me.chkPATCH.Name = "chkPATCH"
        Me.chkPATCH.Size = New System.Drawing.Size(82, 23)
        Me.chkPATCH.TabIndex = 184
        Me.chkPATCH.Text = "PATCH"
        Me.chkPATCH.UseVisualStyleBackColor = True
        '
        'txtHINGE
        '
        Me.txtHINGE.Enabled = False
        Me.txtHINGE.Location = New System.Drawing.Point(247, 118)
        Me.txtHINGE.Name = "txtHINGE"
        Me.txtHINGE.Size = New System.Drawing.Size(48, 26)
        Me.txtHINGE.TabIndex = 183
        Me.txtHINGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkHINGE
        '
        Me.chkHINGE.AutoSize = True
        Me.chkHINGE.Location = New System.Drawing.Point(6, 121)
        Me.chkHINGE.Name = "chkHINGE"
        Me.chkHINGE.Size = New System.Drawing.Size(79, 23)
        Me.chkHINGE.TabIndex = 182
        Me.chkHINGE.Text = "HINGE"
        Me.chkHINGE.UseVisualStyleBackColor = True
        '
        'txtNOTCH
        '
        Me.txtNOTCH.Enabled = False
        Me.txtNOTCH.Location = New System.Drawing.Point(247, 77)
        Me.txtNOTCH.Name = "txtNOTCH"
        Me.txtNOTCH.Size = New System.Drawing.Size(48, 26)
        Me.txtNOTCH.TabIndex = 181
        Me.txtNOTCH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNOTCH
        '
        Me.chkNOTCH.AutoSize = True
        Me.chkNOTCH.Location = New System.Drawing.Point(6, 79)
        Me.chkNOTCH.Name = "chkNOTCH"
        Me.chkNOTCH.Size = New System.Drawing.Size(86, 23)
        Me.chkNOTCH.TabIndex = 180
        Me.chkNOTCH.Text = "NOTCH"
        Me.chkNOTCH.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(190, 387)
        Me.txtComments.MaxLength = 45
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(442, 135)
        Me.txtComments.TabIndex = 186
        Me.txtComments.Text = "012345678901234567890123456789012345678901234567890"
        '
        'gbAddOnServices
        '
        Me.gbAddOnServices.Controls.Add(Me.lblMiterInch)
        Me.gbAddOnServices.Controls.Add(Me.lblShapePolishInch)
        Me.gbAddOnServices.Controls.Add(Me.lblRegularPolishInch)
        Me.gbAddOnServices.Controls.Add(Me.txtHoleSmallerThan1Inch)
        Me.gbAddOnServices.Controls.Add(Me.chkHoleSmallerThan1Inch)
        Me.gbAddOnServices.Controls.Add(Me.txtHoleLargerThan1Inch)
        Me.gbAddOnServices.Controls.Add(Me.chkHoleLargerThan1Inch)
        Me.gbAddOnServices.Controls.Add(Me.txtMiter)
        Me.gbAddOnServices.Controls.Add(Me.chkMiter)
        Me.gbAddOnServices.Controls.Add(Me.txtShapePolish)
        Me.gbAddOnServices.Controls.Add(Me.chkShapePolish)
        Me.gbAddOnServices.Controls.Add(Me.txtRegularPolish)
        Me.gbAddOnServices.Controls.Add(Me.chkRegularPolish)
        Me.gbAddOnServices.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAddOnServices.Location = New System.Drawing.Point(190, 186)
        Me.gbAddOnServices.Name = "gbAddOnServices"
        Me.gbAddOnServices.Size = New System.Drawing.Size(369, 93)
        Me.gbAddOnServices.TabIndex = 174
        Me.gbAddOnServices.TabStop = False
        Me.gbAddOnServices.Text = "Add on Services"
        '
        'lblMiterInch
        '
        Me.lblMiterInch.AutoSize = True
        Me.lblMiterInch.BackColor = System.Drawing.Color.Transparent
        Me.lblMiterInch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiterInch.Location = New System.Drawing.Point(344, 176)
        Me.lblMiterInch.Name = "lblMiterInch"
        Me.lblMiterInch.Size = New System.Drawing.Size(16, 20)
        Me.lblMiterInch.TabIndex = 182
        Me.lblMiterInch.Text = """"
        Me.lblMiterInch.Visible = False
        '
        'lblShapePolishInch
        '
        Me.lblShapePolishInch.AutoSize = True
        Me.lblShapePolishInch.BackColor = System.Drawing.Color.Transparent
        Me.lblShapePolishInch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShapePolishInch.Location = New System.Drawing.Point(344, 143)
        Me.lblShapePolishInch.Name = "lblShapePolishInch"
        Me.lblShapePolishInch.Size = New System.Drawing.Size(16, 20)
        Me.lblShapePolishInch.TabIndex = 181
        Me.lblShapePolishInch.Text = """"
        Me.lblShapePolishInch.Visible = False
        '
        'lblRegularPolishInch
        '
        Me.lblRegularPolishInch.AutoSize = True
        Me.lblRegularPolishInch.BackColor = System.Drawing.Color.Transparent
        Me.lblRegularPolishInch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegularPolishInch.Location = New System.Drawing.Point(344, 110)
        Me.lblRegularPolishInch.Name = "lblRegularPolishInch"
        Me.lblRegularPolishInch.Size = New System.Drawing.Size(16, 20)
        Me.lblRegularPolishInch.TabIndex = 180
        Me.lblRegularPolishInch.Text = """"
        Me.lblRegularPolishInch.Visible = False
        '
        'txtHoleSmallerThan1Inch
        '
        Me.txtHoleSmallerThan1Inch.Enabled = False
        Me.txtHoleSmallerThan1Inch.Location = New System.Drawing.Point(292, 60)
        Me.txtHoleSmallerThan1Inch.Name = "txtHoleSmallerThan1Inch"
        Me.txtHoleSmallerThan1Inch.Size = New System.Drawing.Size(48, 26)
        Me.txtHoleSmallerThan1Inch.TabIndex = 179
        Me.txtHoleSmallerThan1Inch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoleSmallerThan1Inch.Visible = False
        '
        'chkHoleSmallerThan1Inch
        '
        Me.chkHoleSmallerThan1Inch.AutoSize = True
        Me.chkHoleSmallerThan1Inch.Location = New System.Drawing.Point(14, 62)
        Me.chkHoleSmallerThan1Inch.Name = "chkHoleSmallerThan1Inch"
        Me.chkHoleSmallerThan1Inch.Size = New System.Drawing.Size(106, 23)
        Me.chkHoleSmallerThan1Inch.TabIndex = 178
        Me.chkHoleSmallerThan1Inch.Text = "Hole <= 1"""
        Me.chkHoleSmallerThan1Inch.UseVisualStyleBackColor = True
        Me.chkHoleSmallerThan1Inch.Visible = False
        '
        'txtHoleLargerThan1Inch
        '
        Me.txtHoleLargerThan1Inch.Enabled = False
        Me.txtHoleLargerThan1Inch.Location = New System.Drawing.Point(292, 27)
        Me.txtHoleLargerThan1Inch.Name = "txtHoleLargerThan1Inch"
        Me.txtHoleLargerThan1Inch.Size = New System.Drawing.Size(48, 26)
        Me.txtHoleLargerThan1Inch.TabIndex = 177
        Me.txtHoleLargerThan1Inch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoleLargerThan1Inch.Visible = False
        '
        'chkHoleLargerThan1Inch
        '
        Me.chkHoleLargerThan1Inch.AutoSize = True
        Me.chkHoleLargerThan1Inch.Location = New System.Drawing.Point(14, 29)
        Me.chkHoleLargerThan1Inch.Name = "chkHoleLargerThan1Inch"
        Me.chkHoleLargerThan1Inch.Size = New System.Drawing.Size(97, 23)
        Me.chkHoleLargerThan1Inch.TabIndex = 175
        Me.chkHoleLargerThan1Inch.Text = "Hole > 1"""
        Me.chkHoleLargerThan1Inch.UseVisualStyleBackColor = True
        Me.chkHoleLargerThan1Inch.Visible = False
        '
        'txtMiter
        '
        Me.txtMiter.Enabled = False
        Me.txtMiter.Location = New System.Drawing.Point(292, 176)
        Me.txtMiter.Name = "txtMiter"
        Me.txtMiter.ReadOnly = True
        Me.txtMiter.Size = New System.Drawing.Size(48, 26)
        Me.txtMiter.TabIndex = 174
        Me.txtMiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMiter.Visible = False
        '
        'chkMiter
        '
        Me.chkMiter.AutoSize = True
        Me.chkMiter.Location = New System.Drawing.Point(14, 178)
        Me.chkMiter.Name = "chkMiter"
        Me.chkMiter.Size = New System.Drawing.Size(99, 23)
        Me.chkMiter.TabIndex = 173
        Me.chkMiter.Text = "MITER 1"""
        Me.chkMiter.UseVisualStyleBackColor = True
        Me.chkMiter.Visible = False
        '
        'txtShapePolish
        '
        Me.txtShapePolish.Enabled = False
        Me.txtShapePolish.Location = New System.Drawing.Point(292, 143)
        Me.txtShapePolish.Name = "txtShapePolish"
        Me.txtShapePolish.ReadOnly = True
        Me.txtShapePolish.Size = New System.Drawing.Size(48, 26)
        Me.txtShapePolish.TabIndex = 172
        Me.txtShapePolish.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtShapePolish.Visible = False
        '
        'chkShapePolish
        '
        Me.chkShapePolish.AutoSize = True
        Me.chkShapePolish.Location = New System.Drawing.Point(14, 145)
        Me.chkShapePolish.Name = "chkShapePolish"
        Me.chkShapePolish.Size = New System.Drawing.Size(129, 23)
        Me.chkShapePolish.TabIndex = 171
        Me.chkShapePolish.Text = "Shape Polish"
        Me.chkShapePolish.UseVisualStyleBackColor = True
        Me.chkShapePolish.Visible = False
        '
        'txtRegularPolish
        '
        Me.txtRegularPolish.Enabled = False
        Me.txtRegularPolish.Location = New System.Drawing.Point(292, 110)
        Me.txtRegularPolish.Name = "txtRegularPolish"
        Me.txtRegularPolish.ReadOnly = True
        Me.txtRegularPolish.Size = New System.Drawing.Size(48, 26)
        Me.txtRegularPolish.TabIndex = 170
        Me.txtRegularPolish.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRegularPolish.Visible = False
        '
        'chkRegularPolish
        '
        Me.chkRegularPolish.AutoSize = True
        Me.chkRegularPolish.Location = New System.Drawing.Point(14, 112)
        Me.chkRegularPolish.Name = "chkRegularPolish"
        Me.chkRegularPolish.Size = New System.Drawing.Size(140, 23)
        Me.chkRegularPolish.TabIndex = 169
        Me.chkRegularPolish.Text = "Regular Polish"
        Me.chkRegularPolish.UseVisualStyleBackColor = True
        Me.chkRegularPolish.Visible = False
        '
        'btnAddProduct
        '
        Me.btnAddProduct.BackColor = System.Drawing.Color.GreenYellow
        Me.btnAddProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProduct.Location = New System.Drawing.Point(757, 462)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(103, 52)
        Me.btnAddProduct.TabIndex = 188
        Me.btnAddProduct.Text = "Add"
        Me.btnAddProduct.UseVisualStyleBackColor = False
        '
        'gbDimensions
        '
        Me.gbDimensions.Controls.Add(Me.txtHeight_3)
        Me.gbDimensions.Controls.Add(Me.txtHeight_2)
        Me.gbDimensions.Controls.Add(Me.Label6)
        Me.gbDimensions.Controls.Add(Me.txtHeight_1)
        Me.gbDimensions.Controls.Add(Me.txtWidth_3)
        Me.gbDimensions.Controls.Add(Me.txtWidth_2)
        Me.gbDimensions.Controls.Add(Me.Label5)
        Me.gbDimensions.Controls.Add(Me.lblQTY)
        Me.gbDimensions.Controls.Add(Me.txtQTY)
        Me.gbDimensions.Controls.Add(Me.lblWidth)
        Me.gbDimensions.Controls.Add(Me.txtWidth_1)
        Me.gbDimensions.Controls.Add(Me.lblHeight)
        Me.gbDimensions.Controls.Add(Me.Label3)
        Me.gbDimensions.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDimensions.Location = New System.Drawing.Point(401, 79)
        Me.gbDimensions.Name = "gbDimensions"
        Me.gbDimensions.Size = New System.Drawing.Size(458, 101)
        Me.gbDimensions.TabIndex = 172
        Me.gbDimensions.TabStop = False
        Me.gbDimensions.Text = "Dimensions"
        '
        'txtHeight_3
        '
        Me.txtHeight_3.Location = New System.Drawing.Point(338, 53)
        Me.txtHeight_3.Name = "txtHeight_3"
        Me.txtHeight_3.Size = New System.Drawing.Size(30, 29)
        Me.txtHeight_3.TabIndex = 167
        '
        'txtHeight_2
        '
        Me.txtHeight_2.Location = New System.Drawing.Point(292, 53)
        Me.txtHeight_2.Name = "txtHeight_2"
        Me.txtHeight_2.Size = New System.Drawing.Size(30, 29)
        Me.txtHeight_2.TabIndex = 166
        Me.txtHeight_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(322, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 20)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = "/"
        '
        'txtHeight_1
        '
        Me.txtHeight_1.Location = New System.Drawing.Point(221, 53)
        Me.txtHeight_1.Name = "txtHeight_1"
        Me.txtHeight_1.Size = New System.Drawing.Size(48, 29)
        Me.txtHeight_1.TabIndex = 165
        Me.txtHeight_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWidth_3
        '
        Me.txtWidth_3.Location = New System.Drawing.Point(136, 55)
        Me.txtWidth_3.Name = "txtWidth_3"
        Me.txtWidth_3.Size = New System.Drawing.Size(30, 29)
        Me.txtWidth_3.TabIndex = 164
        '
        'txtWidth_2
        '
        Me.txtWidth_2.Location = New System.Drawing.Point(90, 55)
        Me.txtWidth_2.Name = "txtWidth_2"
        Me.txtWidth_2.Size = New System.Drawing.Size(30, 29)
        Me.txtWidth_2.TabIndex = 163
        Me.txtWidth_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(120, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 20)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "/"
        '
        'lblQTY
        '
        Me.lblQTY.AutoSize = True
        Me.lblQTY.BackColor = System.Drawing.Color.Transparent
        Me.lblQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQTY.Location = New System.Drawing.Point(398, 25)
        Me.lblQTY.Name = "lblQTY"
        Me.lblQTY.Size = New System.Drawing.Size(44, 20)
        Me.lblQTY.TabIndex = 168
        Me.lblQTY.Text = "QTY"
        '
        'txtQTY
        '
        Me.txtQTY.Location = New System.Drawing.Point(402, 53)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(40, 29)
        Me.txtQTY.TabIndex = 168
        Me.txtQTY.Text = "1"
        Me.txtQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(64, 25)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(55, 20)
        Me.lblWidth.TabIndex = 166
        Me.lblWidth.Text = "Width"
        '
        'txtWidth_1
        '
        Me.txtWidth_1.Location = New System.Drawing.Point(19, 55)
        Me.txtWidth_1.Name = "txtWidth_1"
        Me.txtWidth_1.Size = New System.Drawing.Size(48, 29)
        Me.txtWidth_1.TabIndex = 162
        Me.txtWidth_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(265, 22)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(62, 20)
        Me.lblHeight.TabIndex = 167
        Me.lblHeight.Text = "Height"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 20)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "X"
        '
        'gbThickness
        '
        Me.gbThickness.Controls.Add(Me.rbTemp)
        Me.gbThickness.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbThickness.Location = New System.Drawing.Point(3, 165)
        Me.gbThickness.Name = "gbThickness"
        Me.gbThickness.Size = New System.Drawing.Size(181, 349)
        Me.gbThickness.TabIndex = 161
        Me.gbThickness.TabStop = False
        Me.gbThickness.Text = "Thickness ( OA )"
        '
        'rbTemp
        '
        Me.rbTemp.AutoSize = True
        Me.rbTemp.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTemp.Location = New System.Drawing.Point(24, 36)
        Me.rbTemp.Name = "rbTemp"
        Me.rbTemp.Size = New System.Drawing.Size(138, 26)
        Me.rbTemp.TabIndex = 0
        Me.rbTemp.TabStop = True
        Me.rbTemp.Text = "1234567890"
        Me.rbTemp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rbTemp.UseVisualStyleBackColor = True
        Me.rbTemp.Visible = False
        '
        'cboProduct
        '
        Me.cboProduct.Enabled = False
        Me.cboProduct.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(3, 37)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(303, 30)
        Me.cboProduct.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 20)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Glass Description"
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.BackColor = System.Drawing.Color.GreenYellow
        Me.txtOrderNumber.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderNumber.Location = New System.Drawing.Point(499, 29)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.ReadOnly = True
        Me.txtOrderNumber.Size = New System.Drawing.Size(194, 32)
        Me.txtOrderNumber.TabIndex = 129
        Me.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(538, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 20)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Order Number"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.txtJobSite)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.cboDeliveryMethod)
        Me.Panel3.Controls.Add(Me.txtDeliveryCharge)
        Me.Panel3.Controls.Add(Me.txtCustomerPONumber)
        Me.Panel3.Controls.Add(Me.lblCustomerPO)
        Me.Panel3.Controls.Add(Me.btnComfirmOrder)
        Me.Panel3.Controls.Add(Me.rbDelivery)
        Me.Panel3.Controls.Add(Me.rbPickup)
        Me.Panel3.Controls.Add(Me.txtCustomerName)
        Me.Panel3.Controls.Add(Me.dtDelieveryDate)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblCustomerCompanyName)
        Me.Panel3.Controls.Add(Me.txtCustomerCompanyName)
        Me.Panel3.Controls.Add(Me.txtOrderNumber)
        Me.Panel3.Controls.Add(Me.btnFindCustomer)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtCustomerZip)
        Me.Panel3.Controls.Add(Me.txtCustomerState)
        Me.Panel3.Controls.Add(Me.txtCustomerAddress)
        Me.Panel3.Controls.Add(Me.txtCustomerCity)
        Me.Panel3.Controls.Add(Me.txtPhoneNumber)
        Me.Panel3.Location = New System.Drawing.Point(12, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(871, 201)
        Me.Panel3.TabIndex = 2
        '
        'txtJobSite
        '
        Me.txtJobSite.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobSite.Location = New System.Drawing.Point(595, 139)
        Me.txtJobSite.MaxLength = 50
        Me.txtJobSite.Name = "txtJobSite"
        Me.txtJobSite.Size = New System.Drawing.Size(269, 26)
        Me.txtJobSite.TabIndex = 171
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Khaki
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(497, 142)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 19)
        Me.Label15.TabIndex = 170
        Me.Label15.Text = "Job Name:"
        '
        'cboDeliveryMethod
        '
        Me.cboDeliveryMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeliveryMethod.FormattingEnabled = True
        Me.cboDeliveryMethod.Location = New System.Drawing.Point(495, 171)
        Me.cboDeliveryMethod.Name = "cboDeliveryMethod"
        Me.cboDeliveryMethod.Size = New System.Drawing.Size(228, 23)
        Me.cboDeliveryMethod.TabIndex = 169
        '
        'txtDeliveryCharge
        '
        Me.txtDeliveryCharge.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDeliveryCharge.Location = New System.Drawing.Point(729, 168)
        Me.txtDeliveryCharge.Name = "txtDeliveryCharge"
        Me.txtDeliveryCharge.Size = New System.Drawing.Size(130, 26)
        Me.txtDeliveryCharge.TabIndex = 168
        Me.ToolTip.SetToolTip(Me.txtDeliveryCharge, "Delivery Charge")
        '
        'txtCustomerPONumber
        '
        Me.txtCustomerPONumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerPONumber.Location = New System.Drawing.Point(496, 105)
        Me.txtCustomerPONumber.MaxLength = 50
        Me.txtCustomerPONumber.Name = "txtCustomerPONumber"
        Me.txtCustomerPONumber.Size = New System.Drawing.Size(231, 26)
        Me.txtCustomerPONumber.TabIndex = 167
        '
        'lblCustomerPO
        '
        Me.lblCustomerPO.AutoSize = True
        Me.lblCustomerPO.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerPO.Location = New System.Drawing.Point(538, 79)
        Me.lblCustomerPO.Name = "lblCustomerPO"
        Me.lblCustomerPO.Size = New System.Drawing.Size(130, 19)
        Me.lblCustomerPO.TabIndex = 166
        Me.lblCustomerPO.Text = "Customer PO #:"
        '
        'btnComfirmOrder
        '
        Me.btnComfirmOrder.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnComfirmOrder.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
        Me.btnComfirmOrder.Location = New System.Drawing.Point(705, 9)
        Me.btnComfirmOrder.Name = "btnComfirmOrder"
        Me.btnComfirmOrder.Size = New System.Drawing.Size(158, 52)
        Me.btnComfirmOrder.TabIndex = 165
        Me.btnComfirmOrder.Text = "Comfirm Order"
        Me.btnComfirmOrder.UseVisualStyleBackColor = False
        '
        'rbDelivery
        '
        Me.rbDelivery.AutoSize = True
        Me.rbDelivery.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDelivery.Location = New System.Drawing.Point(630, 169)
        Me.rbDelivery.Name = "rbDelivery"
        Me.rbDelivery.Size = New System.Drawing.Size(89, 23)
        Me.rbDelivery.TabIndex = 164
        Me.rbDelivery.Text = "Delivery"
        Me.rbDelivery.UseVisualStyleBackColor = True
        Me.rbDelivery.Visible = False
        '
        'rbPickup
        '
        Me.rbPickup.AutoSize = True
        Me.rbPickup.Checked = True
        Me.rbPickup.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPickup.Location = New System.Drawing.Point(519, 169)
        Me.rbPickup.Name = "rbPickup"
        Me.rbPickup.Size = New System.Drawing.Size(113, 23)
        Me.rbPickup.TabIndex = 163
        Me.rbPickup.TabStop = True
        Me.rbPickup.Text = "Self Pickup"
        Me.rbPickup.UseVisualStyleBackColor = True
        Me.rbPickup.Visible = False
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(143, 6)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(341, 26)
        Me.txtCustomerName.TabIndex = 162
        '
        'dtDelieveryDate
        '
        Me.dtDelieveryDate.CustomFormat = "MM/dd/yyyy"
        Me.dtDelieveryDate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.dtDelieveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDelieveryDate.Location = New System.Drawing.Point(733, 105)
        Me.dtDelieveryDate.Name = "dtDelieveryDate"
        Me.dtDelieveryDate.Size = New System.Drawing.Size(130, 26)
        Me.dtDelieveryDate.TabIndex = 161
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(752, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Due Date"
        '
        'lblCustomerCompanyName
        '
        Me.lblCustomerCompanyName.AutoSize = True
        Me.lblCustomerCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerCompanyName.Location = New System.Drawing.Point(3, 45)
        Me.lblCustomerCompanyName.Name = "lblCustomerCompanyName"
        Me.lblCustomerCompanyName.Size = New System.Drawing.Size(134, 20)
        Me.lblCustomerCompanyName.TabIndex = 158
        Me.lblCustomerCompanyName.Text = "Company Name"
        '
        'txtCustomerCompanyName
        '
        Me.txtCustomerCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerCompanyName.Location = New System.Drawing.Point(143, 42)
        Me.txtCustomerCompanyName.Name = "txtCustomerCompanyName"
        Me.txtCustomerCompanyName.ReadOnly = True
        Me.txtCustomerCompanyName.Size = New System.Drawing.Size(341, 26)
        Me.txtCustomerCompanyName.TabIndex = 159
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(9, 3)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(124, 31)
        Me.btnFindCustomer.TabIndex = 157
        Me.btnFindCustomer.Text = "Customer"
        Me.btnFindCustomer.UseVisualStyleBackColor = True
        '
        'txtCustomerZip
        '
        Me.txtCustomerZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerZip.Location = New System.Drawing.Point(376, 136)
        Me.txtCustomerZip.Name = "txtCustomerZip"
        Me.txtCustomerZip.ReadOnly = True
        Me.txtCustomerZip.Size = New System.Drawing.Size(108, 26)
        Me.txtCustomerZip.TabIndex = 154
        '
        'txtCustomerState
        '
        Me.txtCustomerState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerState.Location = New System.Drawing.Point(304, 136)
        Me.txtCustomerState.Name = "txtCustomerState"
        Me.txtCustomerState.ReadOnly = True
        Me.txtCustomerState.Size = New System.Drawing.Size(66, 26)
        Me.txtCustomerState.TabIndex = 153
        '
        'txtCustomerAddress
        '
        Me.txtCustomerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerAddress.Location = New System.Drawing.Point(3, 104)
        Me.txtCustomerAddress.Name = "txtCustomerAddress"
        Me.txtCustomerAddress.ReadOnly = True
        Me.txtCustomerAddress.Size = New System.Drawing.Size(481, 26)
        Me.txtCustomerAddress.TabIndex = 152
        '
        'txtCustomerCity
        '
        Me.txtCustomerCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerCity.Location = New System.Drawing.Point(3, 136)
        Me.txtCustomerCity.Name = "txtCustomerCity"
        Me.txtCustomerCity.ReadOnly = True
        Me.txtCustomerCity.Size = New System.Drawing.Size(295, 26)
        Me.txtCustomerCity.TabIndex = 151
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhoneNumber.Location = New System.Drawing.Point(3, 72)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.ReadOnly = True
        Me.txtPhoneNumber.Size = New System.Drawing.Size(481, 26)
        Me.txtPhoneNumber.TabIndex = 150
        '
        'frmOrderInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1484, 762)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gbPurchaseItems)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrderInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Order Input"
        Me.gbPurchaseItems.ResumeLayout(False)
        Me.gbPurchaseItems.PerformLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gbSetShipAddress.ResumeLayout(False)
        Me.gbExtra.ResumeLayout(False)
        Me.gbExtra.PerformLayout()
        Me.gbAddOnServices.ResumeLayout(False)
        Me.gbAddOnServices.PerformLayout()
        Me.gbDimensions.ResumeLayout(False)
        Me.gbDimensions.PerformLayout()
        Me.gbThickness.ResumeLayout(False)
        Me.gbThickness.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPurchaseItems As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtOrderNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents btnDeleteWholeOrder As System.Windows.Forms.Button
    Friend WithEvents txtCustomerZip As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCustomerState As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCustomerAddress As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCustomerCity As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCustomerCompanyName As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCompanyName As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDelieveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblQTY As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents txtQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWidth_1 As System.Windows.Forms.TextBox
    Friend WithEvents gbThickness As System.Windows.Forms.GroupBox
    Friend WithEvents rbTemp As System.Windows.Forms.RadioButton
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents gbExtra As System.Windows.Forms.GroupBox
    Friend WithEvents gbAddOnServices As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegularPolish As System.Windows.Forms.TextBox
    Friend WithEvents chkRegularPolish As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents gbDimensions As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHoleSmallerThan1Inch As System.Windows.Forms.TextBox
    Friend WithEvents chkHoleSmallerThan1Inch As System.Windows.Forms.CheckBox
    Friend WithEvents txtHoleLargerThan1Inch As System.Windows.Forms.TextBox
    Friend WithEvents chkHoleLargerThan1Inch As System.Windows.Forms.CheckBox
    Friend WithEvents txtMiter As System.Windows.Forms.TextBox
    Friend WithEvents chkMiter As System.Windows.Forms.CheckBox
    Friend WithEvents txtShapePolish As System.Windows.Forms.TextBox
    Friend WithEvents chkShapePolish As System.Windows.Forms.CheckBox
    Friend WithEvents txtPATCH As System.Windows.Forms.TextBox
    Friend WithEvents chkPATCH As System.Windows.Forms.CheckBox
    Friend WithEvents txtHINGE As System.Windows.Forms.TextBox
    Friend WithEvents chkHINGE As System.Windows.Forms.CheckBox
    Friend WithEvents txtNOTCH As System.Windows.Forms.TextBox
    Friend WithEvents chkNOTCH As System.Windows.Forms.CheckBox
    Friend WithEvents txtHeight_3 As System.Windows.Forms.TextBox
    Friend WithEvents txtHeight_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHeight_1 As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth_3 As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDeposit As System.Windows.Forms.Button
    Friend WithEvents lblProdctPrice As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnDiscount As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtProductPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdateTotal As System.Windows.Forms.Button
    Friend WithEvents chk2S As System.Windows.Forms.CheckBox
    Friend WithEvents chk1S As System.Windows.Forms.CheckBox
    Friend WithEvents chk2L As System.Windows.Forms.CheckBox
    Friend WithEvents chk1L As System.Windows.Forms.CheckBox
    Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
    Friend WithEvents txtDeposit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents rbDelivery As System.Windows.Forms.RadioButton
    Friend WithEvents rbPickup As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRemoveItems As System.Windows.Forms.Button
    Friend WithEvents chkTaxExemption As System.Windows.Forms.CheckBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblMiterInch As System.Windows.Forms.Label
    Friend WithEvents lblShapePolishInch As System.Windows.Forms.Label
    Friend WithEvents lblRegularPolishInch As System.Windows.Forms.Label
    Friend WithEvents txtCustomizeService As System.Windows.Forms.TextBox
    Friend WithEvents chkCustomizeService As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOrderComment As System.Windows.Forms.TextBox
    Friend WithEvents btnComfirmOrder As System.Windows.Forms.Button
    Friend WithEvents btnRefund As System.Windows.Forms.Button
    Friend WithEvents txtCustomerPONumber As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomerPO As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryCharge As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
    Friend WithEvents gbSetShipAddress As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetShippingAddress As System.Windows.Forms.Button
    Friend WithEvents cboDeliveryMethod As System.Windows.Forms.ComboBox
    Friend WithEvents chkUseOption2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseOption1 As System.Windows.Forms.CheckBox
    Friend WithEvents cboProduct_2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtJobSite As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAdditionalAddonPrice As System.Windows.Forms.TextBox
    Friend WithEvents cboAdditionalAddon As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
