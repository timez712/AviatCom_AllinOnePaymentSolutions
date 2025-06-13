<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOnline_Menu_Export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOnline_Menu_Export))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.gbDatabase = New System.Windows.Forms.GroupBox()
        Me.cboDatabase = New System.Windows.Forms.ComboBox()
        Me.gbSelectCompany = New System.Windows.Forms.GroupBox()
        Me.cboCompanyName = New System.Windows.Forms.ComboBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtMenuRecordCount = New System.Windows.Forms.TextBox()
        Me.lblProcessStatus = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbProcessingInfo = New System.Windows.Forms.GroupBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lisProcessingLog = New System.Windows.Forms.ListBox()
        Me.gbProcessSpeicalMenu = New System.Windows.Forms.GroupBox()
        Me.btnExportSpeicalMenu = New System.Windows.Forms.Button()
        Me.gbExportMenu = New System.Windows.Forms.GroupBox()
        Me.btnExportMenu = New System.Windows.Forms.Button()
        Me.gbExportCompanyInfo = New System.Windows.Forms.GroupBox()
        Me.btnExportCompanyInfo = New System.Windows.Forms.Button()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Panel.SuspendLayout()
        Me.gbDatabase.SuspendLayout()
        Me.gbSelectCompany.SuspendLayout()
        Me.gbProcessingInfo.SuspendLayout()
        Me.gbProcessSpeicalMenu.SuspendLayout()
        Me.gbExportMenu.SuspendLayout()
        Me.gbExportCompanyInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.gbDatabase)
        Me.Panel.Controls.Add(Me.gbSelectCompany)
        Me.Panel.Controls.Add(Me.btnTest)
        Me.Panel.Controls.Add(Me.txtMenuRecordCount)
        Me.Panel.Controls.Add(Me.lblProcessStatus)
        Me.Panel.Controls.Add(Me.btnClose)
        Me.Panel.Controls.Add(Me.gbProcessingInfo)
        Me.Panel.Controls.Add(Me.gbProcessSpeicalMenu)
        Me.Panel.Controls.Add(Me.gbExportMenu)
        Me.Panel.Controls.Add(Me.gbExportCompanyInfo)
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(607, 577)
        Me.Panel.TabIndex = 2
        '
        'gbDatabase
        '
        Me.gbDatabase.Controls.Add(Me.cboDatabase)
        Me.gbDatabase.Location = New System.Drawing.Point(5, 3)
        Me.gbDatabase.Name = "gbDatabase"
        Me.gbDatabase.Size = New System.Drawing.Size(600, 62)
        Me.gbDatabase.TabIndex = 9
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
        Me.cboDatabase.Size = New System.Drawing.Size(588, 28)
        Me.cboDatabase.TabIndex = 0
        '
        'gbSelectCompany
        '
        Me.gbSelectCompany.Controls.Add(Me.cboCompanyName)
        Me.gbSelectCompany.Location = New System.Drawing.Point(11, 71)
        Me.gbSelectCompany.Name = "gbSelectCompany"
        Me.gbSelectCompany.Size = New System.Drawing.Size(583, 75)
        Me.gbSelectCompany.TabIndex = 8
        Me.gbSelectCompany.TabStop = False
        Me.gbSelectCompany.Text = "Select a Company"
        '
        'cboCompanyName
        '
        Me.cboCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompanyName.FormattingEnabled = True
        Me.cboCompanyName.Location = New System.Drawing.Point(15, 19)
        Me.cboCompanyName.Name = "cboCompanyName"
        Me.cboCompanyName.Size = New System.Drawing.Size(551, 39)
        Me.cboCompanyName.TabIndex = 0
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(259, 539)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(50, 20)
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
        Me.txtMenuRecordCount.Location = New System.Drawing.Point(315, 539)
        Me.txtMenuRecordCount.Name = "txtMenuRecordCount"
        Me.txtMenuRecordCount.ReadOnly = True
        Me.txtMenuRecordCount.Size = New System.Drawing.Size(186, 22)
        Me.txtMenuRecordCount.TabIndex = 6
        '
        'lblProcessStatus
        '
        Me.lblProcessStatus.AutoSize = True
        Me.lblProcessStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessStatus.Location = New System.Drawing.Point(13, 535)
        Me.lblProcessStatus.Name = "lblProcessStatus"
        Me.lblProcessStatus.Size = New System.Drawing.Size(117, 24)
        Me.lblProcessStatus.TabIndex = 5
        Me.lblProcessStatus.Text = "Ready........"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(507, 538)
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
        Me.gbProcessingInfo.Location = New System.Drawing.Point(11, 258)
        Me.gbProcessingInfo.Name = "gbProcessingInfo"
        Me.gbProcessingInfo.Size = New System.Drawing.Size(577, 274)
        Me.gbProcessingInfo.TabIndex = 3
        Me.gbProcessingInfo.TabStop = False
        Me.gbProcessingInfo.Text = "Processing Infomation"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(6, 237)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(565, 29)
        Me.ProgressBar.TabIndex = 1
        '
        'lisProcessingLog
        '
        Me.lisProcessingLog.FormattingEnabled = True
        Me.lisProcessingLog.ItemHeight = 15
        Me.lisProcessingLog.Location = New System.Drawing.Point(6, 19)
        Me.lisProcessingLog.Name = "lisProcessingLog"
        Me.lisProcessingLog.Size = New System.Drawing.Size(565, 199)
        Me.lisProcessingLog.TabIndex = 0
        '
        'gbProcessSpeicalMenu
        '
        Me.gbProcessSpeicalMenu.Controls.Add(Me.btnExportSpeicalMenu)
        Me.gbProcessSpeicalMenu.Location = New System.Drawing.Point(420, 152)
        Me.gbProcessSpeicalMenu.Name = "gbProcessSpeicalMenu"
        Me.gbProcessSpeicalMenu.Size = New System.Drawing.Size(174, 100)
        Me.gbProcessSpeicalMenu.TabIndex = 2
        Me.gbProcessSpeicalMenu.TabStop = False
        Me.gbProcessSpeicalMenu.Text = "Process Speical Menu"
        '
        'btnExportSpeicalMenu
        '
        Me.btnExportSpeicalMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportSpeicalMenu.Location = New System.Drawing.Point(15, 19)
        Me.btnExportSpeicalMenu.Name = "btnExportSpeicalMenu"
        Me.btnExportSpeicalMenu.Size = New System.Drawing.Size(142, 60)
        Me.btnExportSpeicalMenu.TabIndex = 0
        Me.btnExportSpeicalMenu.Text = "Export Speical Menu"
        Me.btnExportSpeicalMenu.UseVisualStyleBackColor = True
        '
        'gbExportMenu
        '
        Me.gbExportMenu.Controls.Add(Me.btnExportMenu)
        Me.gbExportMenu.Location = New System.Drawing.Point(218, 152)
        Me.gbExportMenu.Name = "gbExportMenu"
        Me.gbExportMenu.Size = New System.Drawing.Size(174, 100)
        Me.gbExportMenu.TabIndex = 1
        Me.gbExportMenu.TabStop = False
        Me.gbExportMenu.Text = "Export Menu"
        '
        'btnExportMenu
        '
        Me.btnExportMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportMenu.Location = New System.Drawing.Point(15, 19)
        Me.btnExportMenu.Name = "btnExportMenu"
        Me.btnExportMenu.Size = New System.Drawing.Size(142, 60)
        Me.btnExportMenu.TabIndex = 0
        Me.btnExportMenu.Text = "Export Menu"
        Me.btnExportMenu.UseVisualStyleBackColor = True
        '
        'gbExportCompanyInfo
        '
        Me.gbExportCompanyInfo.Controls.Add(Me.btnExportCompanyInfo)
        Me.gbExportCompanyInfo.Location = New System.Drawing.Point(11, 152)
        Me.gbExportCompanyInfo.Name = "gbExportCompanyInfo"
        Me.gbExportCompanyInfo.Size = New System.Drawing.Size(174, 100)
        Me.gbExportCompanyInfo.TabIndex = 0
        Me.gbExportCompanyInfo.TabStop = False
        Me.gbExportCompanyInfo.Text = "Export Company Info"
        '
        'btnExportCompanyInfo
        '
        Me.btnExportCompanyInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportCompanyInfo.Location = New System.Drawing.Point(15, 19)
        Me.btnExportCompanyInfo.Name = "btnExportCompanyInfo"
        Me.btnExportCompanyInfo.Size = New System.Drawing.Size(132, 60)
        Me.btnExportCompanyInfo.TabIndex = 0
        Me.btnExportCompanyInfo.Text = "Export Company Info"
        Me.btnExportCompanyInfo.UseVisualStyleBackColor = True
        '
        'frmOnline_Menu_Export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(627, 599)
        Me.Controls.Add(Me.Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOnline_Menu_Export"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Online Menu Import"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.gbDatabase.ResumeLayout(False)
        Me.gbSelectCompany.ResumeLayout(False)
        Me.gbProcessingInfo.ResumeLayout(False)
        Me.gbProcessSpeicalMenu.ResumeLayout(False)
        Me.gbExportMenu.ResumeLayout(False)
        Me.gbExportCompanyInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents gbDatabase As GroupBox
    Friend WithEvents cboDatabase As ComboBox
    Friend WithEvents gbSelectCompany As GroupBox
    Friend WithEvents cboCompanyName As ComboBox
    Friend WithEvents btnTest As Button
    Friend WithEvents txtMenuRecordCount As TextBox
    Friend WithEvents lblProcessStatus As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents gbProcessingInfo As GroupBox
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents lisProcessingLog As ListBox
    Friend WithEvents gbProcessSpeicalMenu As GroupBox
    Friend WithEvents btnExportSpeicalMenu As Button
    Friend WithEvents gbExportMenu As GroupBox
    Friend WithEvents btnExportMenu As Button
    Friend WithEvents gbExportCompanyInfo As GroupBox
    Friend WithEvents btnExportCompanyInfo As Button
    Friend WithEvents SaveFile As SaveFileDialog
End Class
