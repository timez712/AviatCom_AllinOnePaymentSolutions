<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Customer_FollowupConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Customer_FollowupConfig))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMerchantNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnUpdateFollowup = New System.Windows.Forms.Button()
        Me.btnCloseFollowup = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRemindDate_NextMonth = New System.Windows.Forms.Button()
        Me.btnRemindDate_NextWeek = New System.Windows.Forms.Button()
        Me.btnRemindDate_NextTwoDays = New System.Windows.Forms.Button()
        Me.btnRemindDate_Tomorrow = New System.Windows.Forms.Button()
        Me.btnRemindDate_Today = New System.Windows.Forms.Button()
        Me.dtRemindDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkReminder = New System.Windows.Forms.CheckBox()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.txtMerchantName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFolloupID = New System.Windows.Forms.Label()
        Me.cboFollowupEmployee = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFollowUpType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtMerchantNumber)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtCreatedBy)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboPriority)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnUpdateFollowup)
        Me.Panel1.Controls.Add(Me.btnCloseFollowup)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtDetails)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtHeader)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnCustomer)
        Me.Panel1.Controls.Add(Me.txtMerchantName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblFolloupID)
        Me.Panel1.Controls.Add(Me.cboFollowupEmployee)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboFollowUpType)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 496)
        Me.Panel1.TabIndex = 0
        '
        'txtMerchantNumber
        '
        Me.txtMerchantNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtMerchantNumber.Location = New System.Drawing.Point(558, 99)
        Me.txtMerchantNumber.Name = "txtMerchantNumber"
        Me.txtMerchantNumber.ReadOnly = True
        Me.txtMerchantNumber.Size = New System.Drawing.Size(160, 23)
        Me.txtMerchantNumber.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(427, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 17)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Merchant Number:"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtCreatedBy.Location = New System.Drawing.Point(3, 40)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(178, 23)
        Me.txtCreatedBy.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(0, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 17)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Created By:"
        '
        'cboPriority
        '
        Me.cboPriority.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Location = New System.Drawing.Point(375, 3)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(242, 24)
        Me.cboPriority.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(313, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Priority:"
        '
        'btnUpdateFollowup
        '
        Me.btnUpdateFollowup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnUpdateFollowup.Location = New System.Drawing.Point(-27, 400)
        Me.btnUpdateFollowup.Name = "btnUpdateFollowup"
        Me.btnUpdateFollowup.Size = New System.Drawing.Size(175, 30)
        Me.btnUpdateFollowup.TabIndex = 23
        Me.btnUpdateFollowup.Text = "Add New Followup"
        Me.btnUpdateFollowup.UseVisualStyleBackColor = True
        '
        'btnCloseFollowup
        '
        Me.btnCloseFollowup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnCloseFollowup.Location = New System.Drawing.Point(3, 459)
        Me.btnCloseFollowup.Name = "btnCloseFollowup"
        Me.btnCloseFollowup.Size = New System.Drawing.Size(145, 30)
        Me.btnCloseFollowup.TabIndex = 22
        Me.btnCloseFollowup.Text = "Close Followup"
        Me.btnCloseFollowup.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRemindDate_NextMonth)
        Me.GroupBox1.Controls.Add(Me.btnRemindDate_NextWeek)
        Me.GroupBox1.Controls.Add(Me.btnRemindDate_NextTwoDays)
        Me.GroupBox1.Controls.Add(Me.btnRemindDate_Tomorrow)
        Me.GroupBox1.Controls.Add(Me.btnRemindDate_Today)
        Me.GroupBox1.Controls.Add(Me.dtRemindDate)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.chkReminder)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(68, 332)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(832, 116)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reminder"
        '
        'btnRemindDate_NextMonth
        '
        Me.btnRemindDate_NextMonth.Location = New System.Drawing.Point(590, 68)
        Me.btnRemindDate_NextMonth.Name = "btnRemindDate_NextMonth"
        Me.btnRemindDate_NextMonth.Size = New System.Drawing.Size(117, 30)
        Me.btnRemindDate_NextMonth.TabIndex = 14
        Me.btnRemindDate_NextMonth.Text = "Next Month"
        Me.btnRemindDate_NextMonth.UseVisualStyleBackColor = True
        '
        'btnRemindDate_NextWeek
        '
        Me.btnRemindDate_NextWeek.Location = New System.Drawing.Point(467, 68)
        Me.btnRemindDate_NextWeek.Name = "btnRemindDate_NextWeek"
        Me.btnRemindDate_NextWeek.Size = New System.Drawing.Size(117, 30)
        Me.btnRemindDate_NextWeek.TabIndex = 13
        Me.btnRemindDate_NextWeek.Text = "Next Mondy"
        Me.btnRemindDate_NextWeek.UseVisualStyleBackColor = True
        '
        'btnRemindDate_NextTwoDays
        '
        Me.btnRemindDate_NextTwoDays.Location = New System.Drawing.Point(344, 68)
        Me.btnRemindDate_NextTwoDays.Name = "btnRemindDate_NextTwoDays"
        Me.btnRemindDate_NextTwoDays.Size = New System.Drawing.Size(117, 30)
        Me.btnRemindDate_NextTwoDays.TabIndex = 12
        Me.btnRemindDate_NextTwoDays.Text = "Next Two Days"
        Me.btnRemindDate_NextTwoDays.UseVisualStyleBackColor = True
        '
        'btnRemindDate_Tomorrow
        '
        Me.btnRemindDate_Tomorrow.Location = New System.Drawing.Point(221, 68)
        Me.btnRemindDate_Tomorrow.Name = "btnRemindDate_Tomorrow"
        Me.btnRemindDate_Tomorrow.Size = New System.Drawing.Size(117, 30)
        Me.btnRemindDate_Tomorrow.TabIndex = 11
        Me.btnRemindDate_Tomorrow.Text = "Tomorrow"
        Me.btnRemindDate_Tomorrow.UseVisualStyleBackColor = True
        '
        'btnRemindDate_Today
        '
        Me.btnRemindDate_Today.Location = New System.Drawing.Point(532, 25)
        Me.btnRemindDate_Today.Name = "btnRemindDate_Today"
        Me.btnRemindDate_Today.Size = New System.Drawing.Size(117, 30)
        Me.btnRemindDate_Today.TabIndex = 10
        Me.btnRemindDate_Today.Text = "Today (Always)"
        Me.btnRemindDate_Today.UseVisualStyleBackColor = True
        '
        'dtRemindDate
        '
        Me.dtRemindDate.CustomFormat = "MM/dd/yyyy"
        Me.dtRemindDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtRemindDate.Location = New System.Drawing.Point(344, 26)
        Me.dtRemindDate.Name = "dtRemindDate"
        Me.dtRemindDate.Size = New System.Drawing.Size(182, 24)
        Me.dtRemindDate.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label11.Location = New System.Drawing.Point(212, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 17)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Next Remind Date:"
        '
        'chkReminder
        '
        Me.chkReminder.AutoSize = True
        Me.chkReminder.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkReminder.Location = New System.Drawing.Point(28, 43)
        Me.chkReminder.Name = "chkReminder"
        Me.chkReminder.Size = New System.Drawing.Size(102, 36)
        Me.chkReminder.TabIndex = 0
        Me.chkReminder.Text = "Set Reminder"
        Me.chkReminder.UseVisualStyleBackColor = True
        '
        'txtDetails
        '
        Me.txtDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDetails.Location = New System.Drawing.Point(68, 184)
        Me.txtDetails.MaxLength = 1000
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(832, 142)
        Me.txtDetails.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(7, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Details:"
        '
        'txtHeader
        '
        Me.txtHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtHeader.Location = New System.Drawing.Point(68, 128)
        Me.txtHeader.MaxLength = 100
        Me.txtHeader.Multiline = True
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(832, 50)
        Me.txtHeader.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(3, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Header:"
        '
        'btnCustomer
        '
        Me.btnCustomer.Location = New System.Drawing.Point(724, 99)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(176, 23)
        Me.btnCustomer.TabIndex = 7
        Me.btnCustomer.Text = "Select Merchant"
        Me.btnCustomer.UseVisualStyleBackColor = True
        Me.btnCustomer.Visible = False
        '
        'txtMerchantName
        '
        Me.txtMerchantName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtMerchantName.Location = New System.Drawing.Point(179, 99)
        Me.txtMerchantName.Name = "txtMerchantName"
        Me.txtMerchantName.ReadOnly = True
        Me.txtMerchantName.Size = New System.Drawing.Size(242, 23)
        Me.txtMerchantName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(65, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Merchant Name:"
        '
        'lblFolloupID
        '
        Me.lblFolloupID.AutoSize = True
        Me.lblFolloupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblFolloupID.Location = New System.Drawing.Point(3, 3)
        Me.lblFolloupID.Name = "lblFolloupID"
        Me.lblFolloupID.Size = New System.Drawing.Size(16, 17)
        Me.lblFolloupID.TabIndex = 4
        Me.lblFolloupID.Text = "0"
        '
        'cboFollowupEmployee
        '
        Me.cboFollowupEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboFollowupEmployee.FormattingEnabled = True
        Me.cboFollowupEmployee.Location = New System.Drawing.Point(375, 69)
        Me.cboFollowupEmployee.Name = "cboFollowupEmployee"
        Me.cboFollowupEmployee.Size = New System.Drawing.Size(242, 24)
        Me.cboFollowupEmployee.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(234, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FollowUp Employee:"
        '
        'cboFollowUpType
        '
        Me.cboFollowUpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboFollowUpType.FormattingEnabled = True
        Me.cboFollowUpType.Location = New System.Drawing.Point(375, 39)
        Me.cboFollowUpType.Name = "cboFollowUpType"
        Me.cboFollowUpType.Size = New System.Drawing.Size(242, 24)
        Me.cboFollowUpType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(264, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FollowUp Type:"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Button1.Location = New System.Drawing.Point(724, 459)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(175, 30)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Button2.Location = New System.Drawing.Point(542, 459)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(175, 30)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CheckBox1.Location = New System.Drawing.Point(645, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(101, 31)
        Me.CheckBox1.TabIndex = 32
        Me.CheckBox1.Text = "Show All Employee"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(623, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(275, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Select muiltple employees and create indevidual followup"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Pending", "Shipped"})
        Me.cboStatus.Location = New System.Drawing.Point(316, 457)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(157, 32)
        Me.cboStatus.TabIndex = 105
        Me.cboStatus.TabStop = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(226, 457)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 32)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Status:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_Customer_FollowupConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 520)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Customer_FollowupConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Customer_FollowupConfig"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtHeader As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents txtMerchantName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFolloupID As System.Windows.Forms.Label
    Friend WithEvents cboFollowupEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFollowUpType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUpdateFollowup As System.Windows.Forms.Button
    Friend WithEvents btnCloseFollowup As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemindDate_NextMonth As System.Windows.Forms.Button
    Friend WithEvents btnRemindDate_NextWeek As System.Windows.Forms.Button
    Friend WithEvents btnRemindDate_NextTwoDays As System.Windows.Forms.Button
    Friend WithEvents btnRemindDate_Tomorrow As System.Windows.Forms.Button
    Friend WithEvents btnRemindDate_Today As System.Windows.Forms.Button
    Friend WithEvents dtRemindDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkReminder As System.Windows.Forms.CheckBox
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMerchantNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
