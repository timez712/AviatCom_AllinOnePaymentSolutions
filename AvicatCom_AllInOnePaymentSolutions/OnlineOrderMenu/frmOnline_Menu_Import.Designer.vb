<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOnline_Menu_Import
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOnline_Menu_Import))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.gbSelectCompany = New System.Windows.Forms.GroupBox()
        Me.cboCompanyName = New System.Windows.Forms.ComboBox()
        Me.btnRemoveMenu = New System.Windows.Forms.Button()
        Me.gbProcessRestaurantCoupon = New System.Windows.Forms.GroupBox()
        Me.btnImportRestaurantCoupons = New System.Windows.Forms.Button()
        Me.gbDatabase = New System.Windows.Forms.GroupBox()
        Me.cboDatabase = New System.Windows.Forms.ComboBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtMenuRecordCount = New System.Windows.Forms.TextBox()
        Me.lblProcessStatus = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbProcessingInfo = New System.Windows.Forms.GroupBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lisProcessingLog = New System.Windows.Forms.ListBox()
        Me.gbProcessSpeicalMenu = New System.Windows.Forms.GroupBox()
        Me.btnImportSpeicalMenu = New System.Windows.Forms.Button()
        Me.gbProcessMenu = New System.Windows.Forms.GroupBox()
        Me.btnImportMenu = New System.Windows.Forms.Button()
        Me.gbProcessCompanyInfo = New System.Windows.Forms.GroupBox()
        Me.btnImportCompanyInfo = New System.Windows.Forms.Button()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.Panel.SuspendLayout()
        Me.gbSelectCompany.SuspendLayout()
        Me.gbProcessRestaurantCoupon.SuspendLayout()
        Me.gbDatabase.SuspendLayout()
        Me.gbProcessingInfo.SuspendLayout()
        Me.gbProcessSpeicalMenu.SuspendLayout()
        Me.gbProcessMenu.SuspendLayout()
        Me.gbProcessCompanyInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.gbSelectCompany)
        Me.Panel.Controls.Add(Me.gbProcessRestaurantCoupon)
        Me.Panel.Controls.Add(Me.gbDatabase)
        Me.Panel.Controls.Add(Me.btnTest)
        Me.Panel.Controls.Add(Me.txtMenuRecordCount)
        Me.Panel.Controls.Add(Me.lblProcessStatus)
        Me.Panel.Controls.Add(Me.btnClose)
        Me.Panel.Controls.Add(Me.gbProcessingInfo)
        Me.Panel.Controls.Add(Me.gbProcessSpeicalMenu)
        Me.Panel.Controls.Add(Me.gbProcessMenu)
        Me.Panel.Controls.Add(Me.gbProcessCompanyInfo)
        Me.Panel.Location = New System.Drawing.Point(14, 14)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(956, 571)
        Me.Panel.TabIndex = 1
        '
        'gbSelectCompany
        '
        Me.gbSelectCompany.Controls.Add(Me.cboCompanyName)
        Me.gbSelectCompany.Controls.Add(Me.btnRemoveMenu)
        Me.gbSelectCompany.Location = New System.Drawing.Point(607, 82)
        Me.gbSelectCompany.Name = "gbSelectCompany"
        Me.gbSelectCompany.Size = New System.Drawing.Size(332, 115)
        Me.gbSelectCompany.TabIndex = 11
        Me.gbSelectCompany.TabStop = False
        Me.gbSelectCompany.Text = "Select a Company"
        '
        'cboCompanyName
        '
        Me.cboCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboCompanyName.FormattingEnabled = True
        Me.cboCompanyName.Location = New System.Drawing.Point(7, 22)
        Me.cboCompanyName.Name = "cboCompanyName"
        Me.cboCompanyName.Size = New System.Drawing.Size(318, 24)
        Me.cboCompanyName.TabIndex = 0
        '
        'btnRemoveMenu
        '
        Me.btnRemoveMenu.Location = New System.Drawing.Point(7, 73)
        Me.btnRemoveMenu.Name = "btnRemoveMenu"
        Me.btnRemoveMenu.Size = New System.Drawing.Size(318, 36)
        Me.btnRemoveMenu.TabIndex = 10
        Me.btnRemoveMenu.Text = "Remove Menu"
        Me.btnRemoveMenu.UseVisualStyleBackColor = True
        '
        'gbProcessRestaurantCoupon
        '
        Me.gbProcessRestaurantCoupon.Controls.Add(Me.btnImportRestaurantCoupons)
        Me.gbProcessRestaurantCoupon.Location = New System.Drawing.Point(444, 82)
        Me.gbProcessRestaurantCoupon.Name = "gbProcessRestaurantCoupon"
        Me.gbProcessRestaurantCoupon.Size = New System.Drawing.Size(155, 115)
        Me.gbProcessRestaurantCoupon.TabIndex = 9
        Me.gbProcessRestaurantCoupon.TabStop = False
        Me.gbProcessRestaurantCoupon.Text = "Process Restaurant Coupon"
        '
        'btnImportRestaurantCoupons
        '
        Me.btnImportRestaurantCoupons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportRestaurantCoupons.Location = New System.Drawing.Point(10, 39)
        Me.btnImportRestaurantCoupons.Name = "btnImportRestaurantCoupons"
        Me.btnImportRestaurantCoupons.Size = New System.Drawing.Size(121, 69)
        Me.btnImportRestaurantCoupons.TabIndex = 0
        Me.btnImportRestaurantCoupons.Text = "Import Restaurant Coupon"
        Me.btnImportRestaurantCoupons.UseVisualStyleBackColor = True
        '
        'gbDatabase
        '
        Me.gbDatabase.Controls.Add(Me.cboDatabase)
        Me.gbDatabase.Location = New System.Drawing.Point(3, 3)
        Me.gbDatabase.Name = "gbDatabase"
        Me.gbDatabase.Size = New System.Drawing.Size(936, 72)
        Me.gbDatabase.TabIndex = 8
        Me.gbDatabase.TabStop = False
        Me.gbDatabase.Text = "Select Database"
        '
        'cboDatabase
        '
        Me.cboDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDatabase.FormattingEnabled = True
        Me.cboDatabase.Items.AddRange(New Object() {"Backup Database", "Production Database"})
        Me.cboDatabase.Location = New System.Drawing.Point(7, 22)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Size = New System.Drawing.Size(921, 28)
        Me.cboDatabase.TabIndex = 0
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(586, 525)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(58, 28)
        Me.btnTest.TabIndex = 7
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        Me.btnTest.Visible = False
        '
        'txtMenuRecordCount
        '
        Me.txtMenuRecordCount.BackColor = System.Drawing.Color.Black
        Me.txtMenuRecordCount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenuRecordCount.ForeColor = System.Drawing.Color.White
        Me.txtMenuRecordCount.Location = New System.Drawing.Point(651, 527)
        Me.txtMenuRecordCount.Name = "txtMenuRecordCount"
        Me.txtMenuRecordCount.ReadOnly = True
        Me.txtMenuRecordCount.Size = New System.Drawing.Size(193, 22)
        Me.txtMenuRecordCount.TabIndex = 6
        '
        'lblProcessStatus
        '
        Me.lblProcessStatus.AutoSize = True
        Me.lblProcessStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessStatus.Location = New System.Drawing.Point(13, 524)
        Me.lblProcessStatus.Name = "lblProcessStatus"
        Me.lblProcessStatus.Size = New System.Drawing.Size(117, 24)
        Me.lblProcessStatus.TabIndex = 5
        Me.lblProcessStatus.Text = "Ready........"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(852, 524)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbProcessingInfo
        '
        Me.gbProcessingInfo.Controls.Add(Me.ProgressBar)
        Me.gbProcessingInfo.Controls.Add(Me.lisProcessingLog)
        Me.gbProcessingInfo.Location = New System.Drawing.Point(10, 204)
        Me.gbProcessingInfo.Name = "gbProcessingInfo"
        Me.gbProcessingInfo.Size = New System.Drawing.Size(929, 316)
        Me.gbProcessingInfo.TabIndex = 3
        Me.gbProcessingInfo.TabStop = False
        Me.gbProcessingInfo.Text = "Processing Infomation"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(7, 273)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(915, 33)
        Me.ProgressBar.TabIndex = 1
        '
        'lisProcessingLog
        '
        Me.lisProcessingLog.FormattingEnabled = True
        Me.lisProcessingLog.ItemHeight = 15
        Me.lisProcessingLog.Location = New System.Drawing.Point(7, 22)
        Me.lisProcessingLog.Name = "lisProcessingLog"
        Me.lisProcessingLog.Size = New System.Drawing.Size(914, 244)
        Me.lisProcessingLog.TabIndex = 0
        '
        'gbProcessSpeicalMenu
        '
        Me.gbProcessSpeicalMenu.Controls.Add(Me.btnImportSpeicalMenu)
        Me.gbProcessSpeicalMenu.Location = New System.Drawing.Point(301, 82)
        Me.gbProcessSpeicalMenu.Name = "gbProcessSpeicalMenu"
        Me.gbProcessSpeicalMenu.Size = New System.Drawing.Size(136, 115)
        Me.gbProcessSpeicalMenu.TabIndex = 2
        Me.gbProcessSpeicalMenu.TabStop = False
        Me.gbProcessSpeicalMenu.Text = "Process Speical Menu"
        '
        'btnImportSpeicalMenu
        '
        Me.btnImportSpeicalMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportSpeicalMenu.Location = New System.Drawing.Point(7, 39)
        Me.btnImportSpeicalMenu.Name = "btnImportSpeicalMenu"
        Me.btnImportSpeicalMenu.Size = New System.Drawing.Size(121, 69)
        Me.btnImportSpeicalMenu.TabIndex = 0
        Me.btnImportSpeicalMenu.Text = "Import Speical Menu"
        Me.btnImportSpeicalMenu.UseVisualStyleBackColor = True
        '
        'gbProcessMenu
        '
        Me.gbProcessMenu.Controls.Add(Me.btnImportMenu)
        Me.gbProcessMenu.Location = New System.Drawing.Point(156, 82)
        Me.gbProcessMenu.Name = "gbProcessMenu"
        Me.gbProcessMenu.Size = New System.Drawing.Size(138, 115)
        Me.gbProcessMenu.TabIndex = 1
        Me.gbProcessMenu.TabStop = False
        Me.gbProcessMenu.Text = "Process Menu"
        '
        'btnImportMenu
        '
        Me.btnImportMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportMenu.Location = New System.Drawing.Point(7, 39)
        Me.btnImportMenu.Name = "btnImportMenu"
        Me.btnImportMenu.Size = New System.Drawing.Size(121, 69)
        Me.btnImportMenu.TabIndex = 0
        Me.btnImportMenu.Text = "Import Menu"
        Me.btnImportMenu.UseVisualStyleBackColor = True
        '
        'gbProcessCompanyInfo
        '
        Me.gbProcessCompanyInfo.Controls.Add(Me.btnImportCompanyInfo)
        Me.gbProcessCompanyInfo.Location = New System.Drawing.Point(10, 82)
        Me.gbProcessCompanyInfo.Name = "gbProcessCompanyInfo"
        Me.gbProcessCompanyInfo.Size = New System.Drawing.Size(139, 115)
        Me.gbProcessCompanyInfo.TabIndex = 0
        Me.gbProcessCompanyInfo.TabStop = False
        Me.gbProcessCompanyInfo.Text = "Process Company Info"
        '
        'btnImportCompanyInfo
        '
        Me.btnImportCompanyInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportCompanyInfo.Location = New System.Drawing.Point(7, 39)
        Me.btnImportCompanyInfo.Name = "btnImportCompanyInfo"
        Me.btnImportCompanyInfo.Size = New System.Drawing.Size(121, 69)
        Me.btnImportCompanyInfo.TabIndex = 0
        Me.btnImportCompanyInfo.Text = "Import Company Info"
        Me.btnImportCompanyInfo.UseVisualStyleBackColor = True
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFileDialog1"
        '
        'frmOnline_Menu_Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(982, 598)
        Me.Controls.Add(Me.Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOnline_Menu_Import"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Online Menu Import"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.gbSelectCompany.ResumeLayout(False)
        Me.gbProcessRestaurantCoupon.ResumeLayout(False)
        Me.gbDatabase.ResumeLayout(False)
        Me.gbProcessingInfo.ResumeLayout(False)
        Me.gbProcessSpeicalMenu.ResumeLayout(False)
        Me.gbProcessMenu.ResumeLayout(False)
        Me.gbProcessCompanyInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents gbSelectCompany As GroupBox
    Friend WithEvents cboCompanyName As ComboBox
    Friend WithEvents btnRemoveMenu As Button
    Friend WithEvents gbProcessRestaurantCoupon As GroupBox
    Friend WithEvents btnImportRestaurantCoupons As Button
    Friend WithEvents gbDatabase As GroupBox
    Friend WithEvents cboDatabase As ComboBox
    Friend WithEvents btnTest As Button
    Friend WithEvents txtMenuRecordCount As TextBox
    Friend WithEvents lblProcessStatus As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents gbProcessingInfo As GroupBox
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents lisProcessingLog As ListBox
    Friend WithEvents gbProcessSpeicalMenu As GroupBox
    Friend WithEvents btnImportSpeicalMenu As Button
    Friend WithEvents gbProcessMenu As GroupBox
    Friend WithEvents btnImportMenu As Button
    Friend WithEvents gbProcessCompanyInfo As GroupBox
    Friend WithEvents btnImportCompanyInfo As Button
    Friend WithEvents OpenFile As OpenFileDialog
End Class
