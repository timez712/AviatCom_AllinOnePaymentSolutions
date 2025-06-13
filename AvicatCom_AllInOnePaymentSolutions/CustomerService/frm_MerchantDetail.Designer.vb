<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MerchantDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MerchantDetail))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.btnPaperRequest = New System.Windows.Forms.Button()
        Me.gbMerchantInfo = New System.Windows.Forms.GroupBox()
        Me.txtCompanyID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnViewAllTerminals = New System.Windows.Forms.Button()
        Me.txtTotalTerminals = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnUseCompanyName = New System.Windows.Forms.Button()
        Me.txtEMail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSaleRep = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMerchantName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtActivationDate = New System.Windows.Forms.DateTimePicker()
        Me.cboTeminalType = New System.Windows.Forms.ComboBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTerminalType = New System.Windows.Forms.Label()
        Me.txtMerchantID = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSNNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.txtCreateDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSNNumber = New System.Windows.Forms.Label()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.txtEinNumber = New System.Windows.Forms.TextBox()
        Me.txtMerchantNumber = New System.Windows.Forms.TextBox()
        Me.lblEinNumber = New System.Windows.Forms.Label()
        Me.lblMerchantNumber = New System.Windows.Forms.Label()
        Me.txtMMO = New System.Windows.Forms.TextBox()
        Me.lblMMO = New System.Windows.Forms.Label()
        Me.lblActivationDate = New System.Windows.Forms.Label()
        Me.btnNewLog = New System.Windows.Forms.Button()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnUploadDocument = New System.Windows.Forms.Button()
        Me.Panel.SuspendLayout()
        Me.gbMerchantInfo.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.btnUploadDocument)
        Me.Panel.Controls.Add(Me.btnPaperRequest)
        Me.Panel.Controls.Add(Me.gbMerchantInfo)
        Me.Panel.Controls.Add(Me.btnNewLog)
        Me.Panel.Controls.Add(Me.C1TrueDBGrid1)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.txtRemarks)
        Me.Panel.Controls.Add(Me.btnSave)
        Me.Panel.Controls.Add(Me.btnClear)
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(1200, 638)
        Me.Panel.TabIndex = 1
        '
        'btnPaperRequest
        '
        Me.btnPaperRequest.Location = New System.Drawing.Point(737, 596)
        Me.btnPaperRequest.Name = "btnPaperRequest"
        Me.btnPaperRequest.Size = New System.Drawing.Size(143, 35)
        Me.btnPaperRequest.TabIndex = 91
        Me.btnPaperRequest.Text = "Paper Request"
        Me.btnPaperRequest.UseVisualStyleBackColor = True
        '
        'gbMerchantInfo
        '
        Me.gbMerchantInfo.Controls.Add(Me.txtCompanyID)
        Me.gbMerchantInfo.Controls.Add(Me.Label11)
        Me.gbMerchantInfo.Controls.Add(Me.btnViewAllTerminals)
        Me.gbMerchantInfo.Controls.Add(Me.txtTotalTerminals)
        Me.gbMerchantInfo.Controls.Add(Me.Label10)
        Me.gbMerchantInfo.Controls.Add(Me.btnUseCompanyName)
        Me.gbMerchantInfo.Controls.Add(Me.txtEMail)
        Me.gbMerchantInfo.Controls.Add(Me.Label9)
        Me.gbMerchantInfo.Controls.Add(Me.cboSaleRep)
        Me.gbMerchantInfo.Controls.Add(Me.Label2)
        Me.gbMerchantInfo.Controls.Add(Me.cboStatus)
        Me.gbMerchantInfo.Controls.Add(Me.Label7)
        Me.gbMerchantInfo.Controls.Add(Me.txtMerchantName)
        Me.gbMerchantInfo.Controls.Add(Me.Label1)
        Me.gbMerchantInfo.Controls.Add(Me.dtActivationDate)
        Me.gbMerchantInfo.Controls.Add(Me.cboTeminalType)
        Me.gbMerchantInfo.Controls.Add(Me.txtFax)
        Me.gbMerchantInfo.Controls.Add(Me.Label6)
        Me.gbMerchantInfo.Controls.Add(Me.lblTerminalType)
        Me.gbMerchantInfo.Controls.Add(Me.txtMerchantID)
        Me.gbMerchantInfo.Controls.Add(Me.txtPhone)
        Me.gbMerchantInfo.Controls.Add(Me.Label4)
        Me.gbMerchantInfo.Controls.Add(Me.txtSNNumber)
        Me.gbMerchantInfo.Controls.Add(Me.Label5)
        Me.gbMerchantInfo.Controls.Add(Me.txtURL)
        Me.gbMerchantInfo.Controls.Add(Me.txtCreateDate)
        Me.gbMerchantInfo.Controls.Add(Me.Label3)
        Me.gbMerchantInfo.Controls.Add(Me.lblSNNumber)
        Me.gbMerchantInfo.Controls.Add(Me.lblURL)
        Me.gbMerchantInfo.Controls.Add(Me.txtEinNumber)
        Me.gbMerchantInfo.Controls.Add(Me.txtMerchantNumber)
        Me.gbMerchantInfo.Controls.Add(Me.lblEinNumber)
        Me.gbMerchantInfo.Controls.Add(Me.lblMerchantNumber)
        Me.gbMerchantInfo.Controls.Add(Me.txtMMO)
        Me.gbMerchantInfo.Controls.Add(Me.lblMMO)
        Me.gbMerchantInfo.Controls.Add(Me.lblActivationDate)
        Me.gbMerchantInfo.Location = New System.Drawing.Point(7, 4)
        Me.gbMerchantInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbMerchantInfo.Name = "gbMerchantInfo"
        Me.gbMerchantInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbMerchantInfo.Size = New System.Drawing.Size(707, 474)
        Me.gbMerchantInfo.TabIndex = 90
        Me.gbMerchantInfo.TabStop = False
        Me.gbMerchantInfo.Text = "Merchant Information"
        '
        'txtCompanyID
        '
        Me.txtCompanyID.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyID.Location = New System.Drawing.Point(512, 94)
        Me.txtCompanyID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompanyID.MaxLength = 15
        Me.txtCompanyID.Name = "txtCompanyID"
        Me.txtCompanyID.ReadOnly = True
        Me.txtCompanyID.Size = New System.Drawing.Size(169, 29)
        Me.txtCompanyID.TabIndex = 109
        Me.txtCompanyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(376, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 25)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Company ID :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnViewAllTerminals
        '
        Me.btnViewAllTerminals.Location = New System.Drawing.Point(368, 426)
        Me.btnViewAllTerminals.Name = "btnViewAllTerminals"
        Me.btnViewAllTerminals.Size = New System.Drawing.Size(160, 35)
        Me.btnViewAllTerminals.TabIndex = 106
        Me.btnViewAllTerminals.Text = "View All Terminals"
        Me.btnViewAllTerminals.UseVisualStyleBackColor = True
        '
        'txtTotalTerminals
        '
        Me.txtTotalTerminals.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTerminals.Location = New System.Drawing.Point(242, 428)
        Me.txtTotalTerminals.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalTerminals.MaxLength = 15
        Me.txtTotalTerminals.Name = "txtTotalTerminals"
        Me.txtTotalTerminals.ReadOnly = True
        Me.txtTotalTerminals.Size = New System.Drawing.Size(109, 29)
        Me.txtTotalTerminals.TabIndex = 104
        Me.txtTotalTerminals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(83, 430)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 25)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Total Terminals :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUseCompanyName
        '
        Me.btnUseCompanyName.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnUseCompanyName.Location = New System.Drawing.Point(558, 15)
        Me.btnUseCompanyName.Name = "btnUseCompanyName"
        Me.btnUseCompanyName.Size = New System.Drawing.Size(135, 35)
        Me.btnUseCompanyName.TabIndex = 103
        Me.btnUseCompanyName.Text = "Use Company Name"
        Me.btnUseCompanyName.UseVisualStyleBackColor = True
        '
        'txtEMail
        '
        Me.txtEMail.Location = New System.Drawing.Point(149, 385)
        Me.txtEMail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.Size = New System.Drawing.Size(532, 26)
        Me.txtEMail.TabIndex = 99
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(78, 388)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 18)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "E-Mail  :"
        '
        'cboSaleRep
        '
        Me.cboSaleRep.DropDownWidth = 300
        Me.cboSaleRep.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboSaleRep.FormattingEnabled = True
        Me.cboSaleRep.Items.AddRange(New Object() {"", "Active", "Cancel", "Rewrite"})
        Me.cboSaleRep.Location = New System.Drawing.Point(512, 138)
        Me.cboSaleRep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboSaleRep.Name = "cboSaleRep"
        Me.cboSaleRep.Size = New System.Drawing.Size(157, 32)
        Me.cboSaleRep.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(388, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Salse Rep :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"", "Active", "Cancel", "Rewrite"})
        Me.cboStatus.Location = New System.Drawing.Point(169, 106)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(157, 32)
        Me.cboStatus.TabIndex = 97
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(79, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 32)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Status:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMerchantName
        '
        Me.txtMerchantName.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMerchantName.Location = New System.Drawing.Point(209, 20)
        Me.txtMerchantName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMerchantName.Name = "txtMerchantName"
        Me.txtMerchantName.Size = New System.Drawing.Size(343, 29)
        Me.txtMerchantName.TabIndex = 65
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 22)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Merchant Name :"
        '
        'dtActivationDate
        '
        Me.dtActivationDate.BackColor = System.Drawing.SystemColors.Window
        Me.dtActivationDate.CalendarForeColor = System.Drawing.SystemColors.WindowText
        Me.dtActivationDate.CustomFormat = "dddd MM/dd/yyyy"
        Me.dtActivationDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dtActivationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtActivationDate.Location = New System.Drawing.Point(149, 200)
        Me.dtActivationDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtActivationDate.Name = "dtActivationDate"
        Me.dtActivationDate.Size = New System.Drawing.Size(202, 26)
        Me.dtActivationDate.TabIndex = 1
        Me.dtActivationDate.Value = New Date(2011, 5, 14, 0, 0, 0, 0)
        '
        'cboTeminalType
        '
        Me.cboTeminalType.FormattingEnabled = True
        Me.cboTeminalType.Location = New System.Drawing.Point(149, 264)
        Me.cboTeminalType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboTeminalType.Name = "cboTeminalType"
        Me.cboTeminalType.Size = New System.Drawing.Size(202, 26)
        Me.cboTeminalType.TabIndex = 5
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(507, 351)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(174, 26)
        Me.txtFax.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(455, 354)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 18)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "Fax  :"
        '
        'lblTerminalType
        '
        Me.lblTerminalType.AutoSize = True
        Me.lblTerminalType.Location = New System.Drawing.Point(32, 270)
        Me.lblTerminalType.Name = "lblTerminalType"
        Me.lblTerminalType.Size = New System.Drawing.Size(111, 18)
        Me.lblTerminalType.TabIndex = 64
        Me.lblTerminalType.Text = "Terminal Type :"
        '
        'txtMerchantID
        '
        Me.txtMerchantID.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMerchantID.Location = New System.Drawing.Point(169, 57)
        Me.txtMerchantID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMerchantID.MaxLength = 15
        Me.txtMerchantID.Name = "txtMerchantID"
        Me.txtMerchantID.ReadOnly = True
        Me.txtMerchantID.Size = New System.Drawing.Size(169, 29)
        Me.txtMerchantID.TabIndex = 79
        Me.txtMerchantID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(149, 351)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(174, 26)
        Me.txtPhone.TabIndex = 93
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 354)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 18)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Phone  :"
        '
        'txtSNNumber
        '
        Me.txtSNNumber.Location = New System.Drawing.Point(507, 267)
        Me.txtSNNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSNNumber.Name = "txtSNNumber"
        Me.txtSNNumber.Size = New System.Drawing.Size(174, 26)
        Me.txtSNNumber.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 25)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Merchant ID :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(149, 298)
        Me.txtURL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtURL.Multiline = True
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(532, 45)
        Me.txtURL.TabIndex = 7
        '
        'txtCreateDate
        '
        Me.txtCreateDate.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateDate.Location = New System.Drawing.Point(512, 57)
        Me.txtCreateDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCreateDate.MaxLength = 15
        Me.txtCreateDate.Name = "txtCreateDate"
        Me.txtCreateDate.ReadOnly = True
        Me.txtCreateDate.Size = New System.Drawing.Size(169, 29)
        Me.txtCreateDate.TabIndex = 75
        Me.txtCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(384, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 25)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Create Date :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSNNumber
        '
        Me.lblSNNumber.AutoSize = True
        Me.lblSNNumber.Location = New System.Drawing.Point(446, 270)
        Me.lblSNNumber.Name = "lblSNNumber"
        Me.lblSNNumber.Size = New System.Drawing.Size(55, 18)
        Me.lblSNNumber.TabIndex = 61
        Me.lblSNNumber.Text = "S/N # :"
        '
        'lblURL
        '
        Me.lblURL.AutoSize = True
        Me.lblURL.Location = New System.Drawing.Point(101, 301)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(46, 18)
        Me.lblURL.TabIndex = 60
        Me.lblURL.Text = "URL :"
        '
        'txtEinNumber
        '
        Me.txtEinNumber.Location = New System.Drawing.Point(507, 235)
        Me.txtEinNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEinNumber.Name = "txtEinNumber"
        Me.txtEinNumber.Size = New System.Drawing.Size(174, 26)
        Me.txtEinNumber.TabIndex = 4
        '
        'txtMerchantNumber
        '
        Me.txtMerchantNumber.Location = New System.Drawing.Point(507, 203)
        Me.txtMerchantNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMerchantNumber.Name = "txtMerchantNumber"
        Me.txtMerchantNumber.Size = New System.Drawing.Size(174, 26)
        Me.txtMerchantNumber.TabIndex = 2
        '
        'lblEinNumber
        '
        Me.lblEinNumber.AutoSize = True
        Me.lblEinNumber.Location = New System.Drawing.Point(449, 238)
        Me.lblEinNumber.Name = "lblEinNumber"
        Me.lblEinNumber.Size = New System.Drawing.Size(52, 18)
        Me.lblEinNumber.TabIndex = 57
        Me.lblEinNumber.Text = "Ein # :"
        '
        'lblMerchantNumber
        '
        Me.lblMerchantNumber.AutoSize = True
        Me.lblMerchantNumber.Location = New System.Drawing.Point(385, 206)
        Me.lblMerchantNumber.Name = "lblMerchantNumber"
        Me.lblMerchantNumber.Size = New System.Drawing.Size(116, 18)
        Me.lblMerchantNumber.TabIndex = 56
        Me.lblMerchantNumber.Text = "Merchant Num :"
        '
        'txtMMO
        '
        Me.txtMMO.Location = New System.Drawing.Point(149, 232)
        Me.txtMMO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMMO.Name = "txtMMO"
        Me.txtMMO.Size = New System.Drawing.Size(202, 26)
        Me.txtMMO.TabIndex = 3
        '
        'lblMMO
        '
        Me.lblMMO.AutoSize = True
        Me.lblMMO.Location = New System.Drawing.Point(89, 238)
        Me.lblMMO.Name = "lblMMO"
        Me.lblMMO.Size = New System.Drawing.Size(54, 18)
        Me.lblMMO.TabIndex = 53
        Me.lblMMO.Text = "MMO :"
        '
        'lblActivationDate
        '
        Me.lblActivationDate.AutoSize = True
        Me.lblActivationDate.Location = New System.Drawing.Point(21, 206)
        Me.lblActivationDate.Name = "lblActivationDate"
        Me.lblActivationDate.Size = New System.Drawing.Size(122, 18)
        Me.lblActivationDate.TabIndex = 52
        Me.lblActivationDate.Text = "Activation Date :"
        '
        'btnNewLog
        '
        Me.btnNewLog.Location = New System.Drawing.Point(942, 596)
        Me.btnNewLog.Name = "btnNewLog"
        Me.btnNewLog.Size = New System.Drawing.Size(251, 35)
        Me.btnNewLog.TabIndex = 89
        Me.btnNewLog.Text = "&New Log"
        Me.btnNewLog.UseVisualStyleBackColor = True
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowRowSelect = False
        Me.C1TrueDBGrid1.BackColor = System.Drawing.SystemColors.Control
        Me.C1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid1.CaptionHeight = 34
        Me.C1TrueDBGrid1.ExtendRightColumn = True
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(720, 4)
        Me.C1TrueDBGrid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(473, 574)
        Me.C1TrueDBGrid1.TabIndex = 87
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 482)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 25)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Remarks :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(7, 510)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(707, 80)
        Me.txtRemarks.TabIndex = 85
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(605, 596)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 35)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "&Save/Exit"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(3, 596)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(101, 35)
        Me.btnClear.TabIndex = 69
        Me.btnClear.Text = "&Cancel"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnUploadDocument
        '
        Me.btnUploadDocument.Location = New System.Drawing.Point(448, 596)
        Me.btnUploadDocument.Name = "btnUploadDocument"
        Me.btnUploadDocument.Size = New System.Drawing.Size(151, 35)
        Me.btnUploadDocument.TabIndex = 92
        Me.btnUploadDocument.Text = "Upload Document"
        Me.btnUploadDocument.UseVisualStyleBackColor = True
        '
        'frm_MerchantDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 662)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm_MerchantDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Merchant Detail"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.gbMerchantInfo.ResumeLayout(False)
        Me.gbMerchantInfo.PerformLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents btnNewLog As System.Windows.Forms.Button
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtMerchantID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents gbMerchantInfo As System.Windows.Forms.GroupBox
    Friend WithEvents dtActivationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTeminalType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTerminalType As System.Windows.Forms.Label
    Friend WithEvents txtSNNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents lblSNNumber As System.Windows.Forms.Label
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents txtEinNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtMerchantNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblEinNumber As System.Windows.Forms.Label
    Friend WithEvents lblMerchantNumber As System.Windows.Forms.Label
    Friend WithEvents txtMMO As System.Windows.Forms.TextBox
    Friend WithEvents lblMMO As System.Windows.Forms.Label
    Friend WithEvents lblActivationDate As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMerchantName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEMail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSaleRep As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnViewAllTerminals As System.Windows.Forms.Button
    Friend WithEvents txtTotalTerminals As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnUseCompanyName As System.Windows.Forms.Button
    Friend WithEvents txtCompanyID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnPaperRequest As System.Windows.Forms.Button
    Friend WithEvents btnUploadDocument As Button
End Class
