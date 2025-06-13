<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessAddData
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
        Me.Panel = New System.Windows.Forms.Panel()
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
        Me.btnRemoveMenu = New System.Windows.Forms.Button()
        Me.gbSelectCompany = New System.Windows.Forms.GroupBox()
        Me.cboCompanyName = New System.Windows.Forms.ComboBox()
        Me.Panel.SuspendLayout()
        Me.gbProcessRestaurantCoupon.SuspendLayout()
        Me.gbDatabase.SuspendLayout()
        Me.gbProcessingInfo.SuspendLayout()
        Me.gbProcessSpeicalMenu.SuspendLayout()
        Me.gbProcessMenu.SuspendLayout()
        Me.gbProcessCompanyInfo.SuspendLayout()
        Me.gbSelectCompany.SuspendLayout()
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
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(820, 495)
        Me.Panel.TabIndex = 0
        '
        'gbProcessRestaurantCoupon
        '
        Me.gbProcessRestaurantCoupon.Controls.Add(Me.btnImportRestaurantCoupons)
        Me.gbProcessRestaurantCoupon.Location = New System.Drawing.Point(381, 71)
        Me.gbProcessRestaurantCoupon.Name = "gbProcessRestaurantCoupon"
        Me.gbProcessRestaurantCoupon.Size = New System.Drawing.Size(133, 100)
        Me.gbProcessRestaurantCoupon.TabIndex = 9
        Me.gbProcessRestaurantCoupon.TabStop = False
        Me.gbProcessRestaurantCoupon.Text = "Process Restaurant Coupon"
        '
        'btnImportRestaurantCoupons
        '
        Me.btnImportRestaurantCoupons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportRestaurantCoupons.Location = New System.Drawing.Point(9, 34)
        Me.btnImportRestaurantCoupons.Name = "btnImportRestaurantCoupons"
        Me.btnImportRestaurantCoupons.Size = New System.Drawing.Size(104, 60)
        Me.btnImportRestaurantCoupons.TabIndex = 0
        Me.btnImportRestaurantCoupons.Text = "Import Restaurant Coupon"
        Me.btnImportRestaurantCoupons.UseVisualStyleBackColor = True
        '
        'gbDatabase
        '
        Me.gbDatabase.Controls.Add(Me.cboDatabase)
        Me.gbDatabase.Location = New System.Drawing.Point(3, 3)
        Me.gbDatabase.Name = "gbDatabase"
        Me.gbDatabase.Size = New System.Drawing.Size(802, 62)
        Me.gbDatabase.TabIndex = 8
        Me.gbDatabase.TabStop = False
        Me.gbDatabase.Text = "Select Database"
        '
        'cboDatabase
        '
        Me.cboDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDatabase.FormattingEnabled = True
        Me.cboDatabase.Items.AddRange(New Object() {"Backup Database", "Production Database"})
        Me.cboDatabase.Location = New System.Drawing.Point(6, 19)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Size = New System.Drawing.Size(790, 28)
        Me.cboDatabase.TabIndex = 0
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(502, 455)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(50, 24)
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
        Me.txtMenuRecordCount.Location = New System.Drawing.Point(558, 457)
        Me.txtMenuRecordCount.Name = "txtMenuRecordCount"
        Me.txtMenuRecordCount.ReadOnly = True
        Me.txtMenuRecordCount.Size = New System.Drawing.Size(166, 22)
        Me.txtMenuRecordCount.TabIndex = 6
        '
        'lblProcessStatus
        '
        Me.lblProcessStatus.AutoSize = True
        Me.lblProcessStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessStatus.Location = New System.Drawing.Point(11, 454)
        Me.lblProcessStatus.Name = "lblProcessStatus"
        Me.lblProcessStatus.Size = New System.Drawing.Size(117, 24)
        Me.lblProcessStatus.TabIndex = 5
        Me.lblProcessStatus.Text = "Ready........"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(730, 454)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbProcessingInfo
        '
        Me.gbProcessingInfo.Controls.Add(Me.ProgressBar)
        Me.gbProcessingInfo.Controls.Add(Me.lisProcessingLog)
        Me.gbProcessingInfo.Location = New System.Drawing.Point(9, 177)
        Me.gbProcessingInfo.Name = "gbProcessingInfo"
        Me.gbProcessingInfo.Size = New System.Drawing.Size(796, 274)
        Me.gbProcessingInfo.TabIndex = 3
        Me.gbProcessingInfo.TabStop = False
        Me.gbProcessingInfo.Text = "Processing Infomation"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(6, 237)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(784, 29)
        Me.ProgressBar.TabIndex = 1
        '
        'lisProcessingLog
        '
        Me.lisProcessingLog.FormattingEnabled = True
        Me.lisProcessingLog.Location = New System.Drawing.Point(6, 19)
        Me.lisProcessingLog.Name = "lisProcessingLog"
        Me.lisProcessingLog.Size = New System.Drawing.Size(784, 212)
        Me.lisProcessingLog.TabIndex = 0
        '
        'gbProcessSpeicalMenu
        '
        Me.gbProcessSpeicalMenu.Controls.Add(Me.btnImportSpeicalMenu)
        Me.gbProcessSpeicalMenu.Location = New System.Drawing.Point(258, 71)
        Me.gbProcessSpeicalMenu.Name = "gbProcessSpeicalMenu"
        Me.gbProcessSpeicalMenu.Size = New System.Drawing.Size(117, 100)
        Me.gbProcessSpeicalMenu.TabIndex = 2
        Me.gbProcessSpeicalMenu.TabStop = False
        Me.gbProcessSpeicalMenu.Text = "Process Speical Menu"
        '
        'btnImportSpeicalMenu
        '
        Me.btnImportSpeicalMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportSpeicalMenu.Location = New System.Drawing.Point(6, 34)
        Me.btnImportSpeicalMenu.Name = "btnImportSpeicalMenu"
        Me.btnImportSpeicalMenu.Size = New System.Drawing.Size(104, 60)
        Me.btnImportSpeicalMenu.TabIndex = 0
        Me.btnImportSpeicalMenu.Text = "Import Speical Menu"
        Me.btnImportSpeicalMenu.UseVisualStyleBackColor = True
        '
        'gbProcessMenu
        '
        Me.gbProcessMenu.Controls.Add(Me.btnImportMenu)
        Me.gbProcessMenu.Location = New System.Drawing.Point(134, 71)
        Me.gbProcessMenu.Name = "gbProcessMenu"
        Me.gbProcessMenu.Size = New System.Drawing.Size(118, 100)
        Me.gbProcessMenu.TabIndex = 1
        Me.gbProcessMenu.TabStop = False
        Me.gbProcessMenu.Text = "Process Menu"
        '
        'btnImportMenu
        '
        Me.btnImportMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportMenu.Location = New System.Drawing.Point(6, 34)
        Me.btnImportMenu.Name = "btnImportMenu"
        Me.btnImportMenu.Size = New System.Drawing.Size(104, 60)
        Me.btnImportMenu.TabIndex = 0
        Me.btnImportMenu.Text = "Import Menu"
        Me.btnImportMenu.UseVisualStyleBackColor = True
        '
        'gbProcessCompanyInfo
        '
        Me.gbProcessCompanyInfo.Controls.Add(Me.btnImportCompanyInfo)
        Me.gbProcessCompanyInfo.Location = New System.Drawing.Point(9, 71)
        Me.gbProcessCompanyInfo.Name = "gbProcessCompanyInfo"
        Me.gbProcessCompanyInfo.Size = New System.Drawing.Size(119, 100)
        Me.gbProcessCompanyInfo.TabIndex = 0
        Me.gbProcessCompanyInfo.TabStop = False
        Me.gbProcessCompanyInfo.Text = "Process Company Info"
        '
        'btnImportCompanyInfo
        '
        Me.btnImportCompanyInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportCompanyInfo.Location = New System.Drawing.Point(6, 34)
        Me.btnImportCompanyInfo.Name = "btnImportCompanyInfo"
        Me.btnImportCompanyInfo.Size = New System.Drawing.Size(104, 60)
        Me.btnImportCompanyInfo.TabIndex = 0
        Me.btnImportCompanyInfo.Text = "Import Company Info"
        Me.btnImportCompanyInfo.UseVisualStyleBackColor = True
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFile"
        '
        'btnRemoveMenu
        '
        Me.btnRemoveMenu.Location = New System.Drawing.Point(6, 63)
        Me.btnRemoveMenu.Name = "btnRemoveMenu"
        Me.btnRemoveMenu.Size = New System.Drawing.Size(273, 31)
        Me.btnRemoveMenu.TabIndex = 10
        Me.btnRemoveMenu.Text = "Remove Menu"
        Me.btnRemoveMenu.UseVisualStyleBackColor = True
        '
        'gbSelectCompany
        '
        Me.gbSelectCompany.Controls.Add(Me.cboCompanyName)
        Me.gbSelectCompany.Controls.Add(Me.btnRemoveMenu)
        Me.gbSelectCompany.Location = New System.Drawing.Point(520, 71)
        Me.gbSelectCompany.Name = "gbSelectCompany"
        Me.gbSelectCompany.Size = New System.Drawing.Size(285, 100)
        Me.gbSelectCompany.TabIndex = 11
        Me.gbSelectCompany.TabStop = False
        Me.gbSelectCompany.Text = "Select a Company"
        '
        'cboCompanyName
        '
        Me.cboCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboCompanyName.FormattingEnabled = True
        Me.cboCompanyName.Location = New System.Drawing.Point(6, 19)
        Me.cboCompanyName.Name = "cboCompanyName"
        Me.cboCompanyName.Size = New System.Drawing.Size(273, 24)
        Me.cboCompanyName.TabIndex = 0
        '
        'frmProcessAddData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 518)
        Me.Controls.Add(Me.Panel)
        Me.Name = "frmProcessAddData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Data"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.gbProcessRestaurantCoupon.ResumeLayout(False)
        Me.gbDatabase.ResumeLayout(False)
        Me.gbProcessingInfo.ResumeLayout(False)
        Me.gbProcessSpeicalMenu.ResumeLayout(False)
        Me.gbProcessMenu.ResumeLayout(False)
        Me.gbProcessCompanyInfo.ResumeLayout(False)
        Me.gbSelectCompany.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents gbProcessingInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lisProcessingLog As System.Windows.Forms.ListBox
    Friend WithEvents gbProcessSpeicalMenu As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportSpeicalMenu As System.Windows.Forms.Button
    Friend WithEvents gbProcessMenu As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportMenu As System.Windows.Forms.Button
    Friend WithEvents gbProcessCompanyInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportCompanyInfo As System.Windows.Forms.Button
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblProcessStatus As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtMenuRecordCount As System.Windows.Forms.TextBox
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents gbDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents cboDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents gbProcessRestaurantCoupon As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportRestaurantCoupons As System.Windows.Forms.Button
    Friend WithEvents btnRemoveMenu As System.Windows.Forms.Button
    Friend WithEvents gbSelectCompany As System.Windows.Forms.GroupBox
    Friend WithEvents cboCompanyName As System.Windows.Forms.ComboBox
End Class
