<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MerchantPaperRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MerchantPaperRequest))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboShipper = New System.Windows.Forms.ComboBox()
        Me.lblDisplayRequestID = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAddtionalRolls = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalRollsRequested = New System.Windows.Forms.TextBox()
        Me.cboRollsInOneBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTotalBoxRequest = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkConfirmedShipped = New System.Windows.Forms.CheckBox()
        Me.dtConfirmedShippedDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSetToday = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbCompanyAddress = New System.Windows.Forms.GroupBox()
        Me.txtCompanyAddress = New System.Windows.Forms.TextBox()
        Me.lblCompanyAddress = New System.Windows.Forms.Label()
        Me.txtMerchantName = New System.Windows.Forms.TextBox()
        Me.lblMerchantName = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbCompanyAddress.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.GroupBox5)
        Me.Panel.Controls.Add(Me.btnDelete)
        Me.Panel.Controls.Add(Me.GroupBox4)
        Me.Panel.Controls.Add(Me.cboRollsInOneBox)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.lblDisplayRequestID)
        Me.Panel.Controls.Add(Me.GroupBox2)
        Me.Panel.Controls.Add(Me.GroupBox1)
        Me.Panel.Controls.Add(Me.Label8)
        Me.Panel.Controls.Add(Me.txtRemarks)
        Me.Panel.Controls.Add(Me.cboStatus)
        Me.Panel.Controls.Add(Me.Label7)
        Me.Panel.Controls.Add(Me.gbCompanyAddress)
        Me.Panel.Controls.Add(Me.txtMerchantName)
        Me.Panel.Controls.Add(Me.lblMerchantName)
        Me.Panel.Controls.Add(Me.btnSave)
        Me.Panel.Controls.Add(Me.btnExit)
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(942, 578)
        Me.Panel.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.CheckBox1)
        Me.GroupBox5.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Location = New System.Drawing.Point(415, 157)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(514, 71)
        Me.GroupBox5.TabIndex = 118
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Billing Informaiton"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(341, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Bill Amount"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(340, 38)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 26)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.TabStop = False
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CheckBox1.Location = New System.Drawing.Point(7, 22)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 36)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Billed?"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(104, 29)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 26)
        Me.DateTimePicker1.TabIndex = 0
        Me.DateTimePicker1.TabStop = False
        Me.DateTimePicker1.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(233, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.TabStop = False
        Me.Button1.Text = "Set Today"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(577, 369)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(101, 49)
        Me.btnDelete.TabIndex = 117
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboShipper)
        Me.GroupBox4.Location = New System.Drawing.Point(633, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 71)
        Me.GroupBox4.TabIndex = 116
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Shipper"
        '
        'cboShipper
        '
        Me.cboShipper.AutoCompleteCustomSource.AddRange(New String() {"", "UPS", "Amazon", "Self Pickup", "Hand Delivery", "Fedex", "USPS", "Other"})
        Me.cboShipper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShipper.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboShipper.FormattingEnabled = True
        Me.cboShipper.Items.AddRange(New Object() {"UPS", "Amazon", "Self Pickup", "Hand Delivery", "USPS", "Fedex", "Other"})
        Me.cboShipper.Location = New System.Drawing.Point(7, 28)
        Me.cboShipper.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboShipper.Name = "cboShipper"
        Me.cboShipper.Size = New System.Drawing.Size(289, 32)
        Me.cboShipper.TabIndex = 2
        Me.cboShipper.TabStop = False
        '
        'lblDisplayRequestID
        '
        Me.lblDisplayRequestID.AutoSize = True
        Me.lblDisplayRequestID.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblDisplayRequestID.Location = New System.Drawing.Point(4, 0)
        Me.lblDisplayRequestID.Name = "lblDisplayRequestID"
        Me.lblDisplayRequestID.Size = New System.Drawing.Size(78, 16)
        Me.lblDisplayRequestID.TabIndex = 115
        Me.lblDisplayRequestID.Text = "RequestID:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtTotalRollsRequested)
        Me.GroupBox2.Controls.Add(Me.cboTotalBoxRequest)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 18.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(33, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(580, 131)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Order QTY"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAddtionalRolls)
        Me.GroupBox3.Location = New System.Drawing.Point(203, 26)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(173, 77)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rolls"
        '
        'txtAddtionalRolls
        '
        Me.txtAddtionalRolls.Location = New System.Drawing.Point(6, 35)
        Me.txtAddtionalRolls.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddtionalRolls.Name = "txtAddtionalRolls"
        Me.txtAddtionalRolls.Size = New System.Drawing.Size(147, 35)
        Me.txtAddtionalRolls.TabIndex = 0
        Me.txtAddtionalRolls.TabStop = False
        Me.txtAddtionalRolls.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(393, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 34)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total Rolls"
        '
        'txtTotalRollsRequested
        '
        Me.txtTotalRollsRequested.BackColor = System.Drawing.Color.MintCream
        Me.txtTotalRollsRequested.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRollsRequested.Location = New System.Drawing.Point(389, 53)
        Me.txtTotalRollsRequested.Name = "txtTotalRollsRequested"
        Me.txtTotalRollsRequested.ReadOnly = True
        Me.txtTotalRollsRequested.Size = New System.Drawing.Size(166, 50)
        Me.txtTotalRollsRequested.TabIndex = 4
        Me.txtTotalRollsRequested.TabStop = False
        Me.txtTotalRollsRequested.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboRollsInOneBox
        '
        Me.cboRollsInOneBox.FormattingEnabled = True
        Me.cboRollsInOneBox.Items.AddRange(New Object() {"50", "10", "20"})
        Me.cboRollsInOneBox.Location = New System.Drawing.Point(114, 369)
        Me.cboRollsInOneBox.Name = "cboRollsInOneBox"
        Me.cboRollsInOneBox.Size = New System.Drawing.Size(121, 26)
        Me.cboRollsInOneBox.TabIndex = 1
        Me.cboRollsInOneBox.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(241, 373)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Rolls In One Box"
        Me.Label2.Visible = False
        '
        'cboTotalBoxRequest
        '
        Me.cboTotalBoxRequest.FormattingEnabled = True
        Me.cboTotalBoxRequest.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboTotalBoxRequest.Location = New System.Drawing.Point(11, 61)
        Me.cboTotalBoxRequest.Name = "cboTotalBoxRequest"
        Me.cboTotalBoxRequest.Size = New System.Drawing.Size(121, 35)
        Me.cboTotalBoxRequest.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Box"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkConfirmedShipped)
        Me.GroupBox1.Controls.Add(Me.dtConfirmedShippedDate)
        Me.GroupBox1.Controls.Add(Me.btnSetToday)
        Me.GroupBox1.Location = New System.Drawing.Point(415, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 71)
        Me.GroupBox1.TabIndex = 113
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Confirmed Shipped Date"
        '
        'chkConfirmedShipped
        '
        Me.chkConfirmedShipped.AutoSize = True
        Me.chkConfirmedShipped.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkConfirmedShipped.Location = New System.Drawing.Point(7, 22)
        Me.chkConfirmedShipped.Name = "chkConfirmedShipped"
        Me.chkConfirmedShipped.Size = New System.Drawing.Size(76, 36)
        Me.chkConfirmedShipped.TabIndex = 2
        Me.chkConfirmedShipped.Text = "Confirm?"
        Me.chkConfirmedShipped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkConfirmedShipped.UseVisualStyleBackColor = True
        '
        'dtConfirmedShippedDate
        '
        Me.dtConfirmedShippedDate.CustomFormat = "MM/dd/yyyy"
        Me.dtConfirmedShippedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtConfirmedShippedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtConfirmedShippedDate.Location = New System.Drawing.Point(104, 29)
        Me.dtConfirmedShippedDate.Name = "dtConfirmedShippedDate"
        Me.dtConfirmedShippedDate.Size = New System.Drawing.Size(121, 26)
        Me.dtConfirmedShippedDate.TabIndex = 0
        Me.dtConfirmedShippedDate.TabStop = False
        Me.dtConfirmedShippedDate.Visible = False
        '
        'btnSetToday
        '
        Me.btnSetToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetToday.Location = New System.Drawing.Point(233, 20)
        Me.btnSetToday.Name = "btnSetToday"
        Me.btnSetToday.Size = New System.Drawing.Size(80, 40)
        Me.btnSetToday.TabIndex = 1
        Me.btnSetToday.TabStop = False
        Me.btnSetToday.Text = "Set Today"
        Me.btnSetToday.UseVisualStyleBackColor = True
        Me.btnSetToday.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 396)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 25)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Remarks :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(7, 424)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(922, 141)
        Me.txtRemarks.TabIndex = 2
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Pending", "Shipped"})
        Me.cboStatus.Location = New System.Drawing.Point(468, 36)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(157, 32)
        Me.cboStatus.TabIndex = 1
        Me.cboStatus.TabStop = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(378, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 32)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Status:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbCompanyAddress
        '
        Me.gbCompanyAddress.Controls.Add(Me.txtCompanyAddress)
        Me.gbCompanyAddress.Controls.Add(Me.lblCompanyAddress)
        Me.gbCompanyAddress.Location = New System.Drawing.Point(33, 75)
        Me.gbCompanyAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbCompanyAddress.Name = "gbCompanyAddress"
        Me.gbCompanyAddress.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbCompanyAddress.Size = New System.Drawing.Size(376, 150)
        Me.gbCompanyAddress.TabIndex = 0
        Me.gbCompanyAddress.TabStop = False
        Me.gbCompanyAddress.Text = "Shipping Address"
        '
        'txtCompanyAddress
        '
        Me.txtCompanyAddress.Location = New System.Drawing.Point(90, 27)
        Me.txtCompanyAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompanyAddress.Multiline = True
        Me.txtCompanyAddress.Name = "txtCompanyAddress"
        Me.txtCompanyAddress.Size = New System.Drawing.Size(263, 110)
        Me.txtCompanyAddress.TabIndex = 0
        '
        'lblCompanyAddress
        '
        Me.lblCompanyAddress.AutoSize = True
        Me.lblCompanyAddress.Location = New System.Drawing.Point(18, 30)
        Me.lblCompanyAddress.Name = "lblCompanyAddress"
        Me.lblCompanyAddress.Size = New System.Drawing.Size(75, 18)
        Me.lblCompanyAddress.TabIndex = 42
        Me.lblCompanyAddress.Text = "Address :"
        '
        'txtMerchantName
        '
        Me.txtMerchantName.Location = New System.Drawing.Point(171, 41)
        Me.txtMerchantName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMerchantName.Name = "txtMerchantName"
        Me.txtMerchantName.ReadOnly = True
        Me.txtMerchantName.Size = New System.Drawing.Size(202, 26)
        Me.txtMerchantName.TabIndex = 95
        Me.txtMerchantName.TabStop = False
        '
        'lblMerchantName
        '
        Me.lblMerchantName.AutoSize = True
        Me.lblMerchantName.Location = New System.Drawing.Point(41, 44)
        Me.lblMerchantName.Name = "lblMerchantName"
        Me.lblMerchantName.Size = New System.Drawing.Size(126, 18)
        Me.lblMerchantName.TabIndex = 96
        Me.lblMerchantName.Text = "Merchant Name :"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(702, 369)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 49)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(828, 369)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(101, 49)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frm_MerchantPaperRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 599)
        Me.Controls.Add(Me.Panel)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm_MerchantPaperRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Merchant Paper Request"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbCompanyAddress.ResumeLayout(False)
        Me.gbCompanyAddress.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtMerchantName As System.Windows.Forms.TextBox
    Friend WithEvents lblMerchantName As System.Windows.Forms.Label
    Friend WithEvents gbCompanyAddress As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompanyAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblCompanyAddress As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetToday As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalRollsRequested As System.Windows.Forms.TextBox
    Friend WithEvents cboRollsInOneBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTotalBoxRequest As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAddtionalRolls As System.Windows.Forms.TextBox
    Friend WithEvents dtConfirmedShippedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayRequestID As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboShipper As System.Windows.Forms.ComboBox
    Friend WithEvents chkConfirmedShipped As System.Windows.Forms.CheckBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
