<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Security_AccessControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Security_AccessControl))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.gbAssignProfile = New System.Windows.Forms.GroupBox()
        Me.C1TrueDBGrid3 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnUpdateProfile = New System.Windows.Forms.Button()
        Me.cboUserName = New System.Windows.Forms.ComboBox()
        Me.lblCurrentProfile = New System.Windows.Forms.Label()
        Me.txtUserProfile = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.gbAccessAssign = New System.Windows.Forms.GroupBox()
        Me.C1TrueDBGrid2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.gbSelectProfile = New System.Windows.Forms.GroupBox()
        Me.cboProfiles = New System.Windows.Forms.ComboBox()
        Me.lblAccessGranted = New System.Windows.Forms.Label()
        Me.lblAccessDenied = New System.Windows.Forms.Label()
        Me.btnDenied = New System.Windows.Forms.Button()
        Me.btnGrantAccess = New System.Windows.Forms.Button()
        Me.Panel.SuspendLayout()
        Me.gbAssignProfile.SuspendLayout()
        CType(Me.C1TrueDBGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAccessAssign.SuspendLayout()
        CType(Me.C1TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSelectProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.gbAssignProfile)
        Me.Panel.Controls.Add(Me.btnExit)
        Me.Panel.Controls.Add(Me.gbAccessAssign)
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(976, 556)
        Me.Panel.TabIndex = 0
        '
        'gbAssignProfile
        '
        Me.gbAssignProfile.Controls.Add(Me.C1TrueDBGrid3)
        Me.gbAssignProfile.Controls.Add(Me.btnUpdateProfile)
        Me.gbAssignProfile.Controls.Add(Me.cboUserName)
        Me.gbAssignProfile.Controls.Add(Me.lblCurrentProfile)
        Me.gbAssignProfile.Controls.Add(Me.txtUserProfile)
        Me.gbAssignProfile.Controls.Add(Me.lblUserName)
        Me.gbAssignProfile.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAssignProfile.Location = New System.Drawing.Point(3, 3)
        Me.gbAssignProfile.Name = "gbAssignProfile"
        Me.gbAssignProfile.Size = New System.Drawing.Size(966, 98)
        Me.gbAssignProfile.TabIndex = 6
        Me.gbAssignProfile.TabStop = False
        Me.gbAssignProfile.Text = "Profile Assign"
        '
        'C1TrueDBGrid3
        '
        Me.C1TrueDBGrid3.AllowRowSelect = False
        Me.C1TrueDBGrid3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid3.CaptionHeight = 34
        Me.C1TrueDBGrid3.ExtendRightColumn = True
        Me.C1TrueDBGrid3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TrueDBGrid3.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid3.Images.Add(CType(resources.GetObject("C1TrueDBGrid3.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid3.Location = New System.Drawing.Point(531, 16)
        Me.C1TrueDBGrid3.Name = "C1TrueDBGrid3"
        Me.C1TrueDBGrid3.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid3.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid3.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid3.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid3.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid3.RowHeight = 20
        Me.C1TrueDBGrid3.Size = New System.Drawing.Size(336, 76)
        Me.C1TrueDBGrid3.TabIndex = 59
        Me.C1TrueDBGrid3.Text = "C1TrueDBGrid3"
        Me.C1TrueDBGrid3.PropBag = resources.GetString("C1TrueDBGrid3.PropBag")
        '
        'btnUpdateProfile
        '
        Me.btnUpdateProfile.Enabled = False
        Me.btnUpdateProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateProfile.Location = New System.Drawing.Point(873, 16)
        Me.btnUpdateProfile.Name = "btnUpdateProfile"
        Me.btnUpdateProfile.Size = New System.Drawing.Size(87, 76)
        Me.btnUpdateProfile.TabIndex = 58
        Me.btnUpdateProfile.Text = "Update Profile"
        Me.btnUpdateProfile.UseVisualStyleBackColor = True
        '
        'cboUserName
        '
        Me.cboUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUserName.FormattingEnabled = True
        Me.cboUserName.Location = New System.Drawing.Point(96, 16)
        Me.cboUserName.Name = "cboUserName"
        Me.cboUserName.Size = New System.Drawing.Size(407, 32)
        Me.cboUserName.TabIndex = 9
        '
        'lblCurrentProfile
        '
        Me.lblCurrentProfile.AutoSize = True
        Me.lblCurrentProfile.Location = New System.Drawing.Point(13, 60)
        Me.lblCurrentProfile.Name = "lblCurrentProfile"
        Me.lblCurrentProfile.Size = New System.Drawing.Size(58, 20)
        Me.lblCurrentProfile.TabIndex = 8
        Me.lblCurrentProfile.Text = "Profile :"
        '
        'txtUserProfile
        '
        Me.txtUserProfile.Location = New System.Drawing.Point(96, 57)
        Me.txtUserProfile.Name = "txtUserProfile"
        Me.txtUserProfile.ReadOnly = True
        Me.txtUserProfile.Size = New System.Drawing.Size(407, 26)
        Me.txtUserProfile.TabIndex = 7
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(6, 22)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(84, 20)
        Me.lblUserName.TabIndex = 6
        Me.lblUserName.Text = "User Name :"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(879, 495)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(90, 54)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'gbAccessAssign
        '
        Me.gbAccessAssign.Controls.Add(Me.C1TrueDBGrid2)
        Me.gbAccessAssign.Controls.Add(Me.C1TrueDBGrid1)
        Me.gbAccessAssign.Controls.Add(Me.gbSelectProfile)
        Me.gbAccessAssign.Controls.Add(Me.lblAccessGranted)
        Me.gbAccessAssign.Controls.Add(Me.lblAccessDenied)
        Me.gbAccessAssign.Controls.Add(Me.btnDenied)
        Me.gbAccessAssign.Controls.Add(Me.btnGrantAccess)
        Me.gbAccessAssign.Location = New System.Drawing.Point(3, 107)
        Me.gbAccessAssign.Name = "gbAccessAssign"
        Me.gbAccessAssign.Size = New System.Drawing.Size(966, 372)
        Me.gbAccessAssign.TabIndex = 3
        Me.gbAccessAssign.TabStop = False
        Me.gbAccessAssign.Text = "Access Assign"
        '
        'C1TrueDBGrid2
        '
        Me.C1TrueDBGrid2.AllowRowSelect = False
        Me.C1TrueDBGrid2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid2.CaptionHeight = 34
        Me.C1TrueDBGrid2.ExtendRightColumn = True
        Me.C1TrueDBGrid2.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid2.Images.Add(CType(resources.GetObject("C1TrueDBGrid2.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid2.Location = New System.Drawing.Point(531, 144)
        Me.C1TrueDBGrid2.Name = "C1TrueDBGrid2"
        Me.C1TrueDBGrid2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid2.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid2.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid2.Size = New System.Drawing.Size(421, 222)
        Me.C1TrueDBGrid2.TabIndex = 57
        Me.C1TrueDBGrid2.Text = "C1TrueDBGrid2"
        Me.C1TrueDBGrid2.PropBag = resources.GetString("C1TrueDBGrid2.PropBag")
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowRowSelect = False
        Me.C1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid1.CaptionHeight = 34
        Me.C1TrueDBGrid1.ExtendRightColumn = True
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(11, 144)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(421, 222)
        Me.C1TrueDBGrid1.TabIndex = 56
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'gbSelectProfile
        '
        Me.gbSelectProfile.Controls.Add(Me.cboProfiles)
        Me.gbSelectProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSelectProfile.Location = New System.Drawing.Point(160, 19)
        Me.gbSelectProfile.Name = "gbSelectProfile"
        Me.gbSelectProfile.Size = New System.Drawing.Size(603, 85)
        Me.gbSelectProfile.TabIndex = 10
        Me.gbSelectProfile.TabStop = False
        Me.gbSelectProfile.Text = "Select Profile"
        '
        'cboProfiles
        '
        Me.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProfiles.FormattingEnabled = True
        Me.cboProfiles.Location = New System.Drawing.Point(98, 30)
        Me.cboProfiles.Name = "cboProfiles"
        Me.cboProfiles.Size = New System.Drawing.Size(407, 32)
        Me.cboProfiles.TabIndex = 4
        '
        'lblAccessGranted
        '
        Me.lblAccessGranted.AutoSize = True
        Me.lblAccessGranted.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessGranted.Location = New System.Drawing.Point(464, 116)
        Me.lblAccessGranted.Name = "lblAccessGranted"
        Me.lblAccessGranted.Size = New System.Drawing.Size(179, 25)
        Me.lblAccessGranted.TabIndex = 9
        Me.lblAccessGranted.Text = "Access Granted"
        '
        'lblAccessDenied
        '
        Me.lblAccessDenied.AutoSize = True
        Me.lblAccessDenied.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessDenied.Location = New System.Drawing.Point(6, 116)
        Me.lblAccessDenied.Name = "lblAccessDenied"
        Me.lblAccessDenied.Size = New System.Drawing.Size(169, 25)
        Me.lblAccessDenied.TabIndex = 8
        Me.lblAccessDenied.Text = "Access Denied"
        '
        'btnDenied
        '
        Me.btnDenied.Enabled = False
        Me.btnDenied.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDenied.Location = New System.Drawing.Point(438, 256)
        Me.btnDenied.Name = "btnDenied"
        Me.btnDenied.Size = New System.Drawing.Size(87, 89)
        Me.btnDenied.TabIndex = 7
        Me.btnDenied.Text = "Denied  <<<<<<"
        Me.btnDenied.UseVisualStyleBackColor = True
        '
        'btnGrantAccess
        '
        Me.btnGrantAccess.Enabled = False
        Me.btnGrantAccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrantAccess.Location = New System.Drawing.Point(438, 161)
        Me.btnGrantAccess.Name = "btnGrantAccess"
        Me.btnGrantAccess.Size = New System.Drawing.Size(87, 89)
        Me.btnGrantAccess.TabIndex = 6
        Me.btnGrantAccess.Text = "Granted   >>>>>>"
        Me.btnGrantAccess.UseVisualStyleBackColor = True
        '
        'frmAccessControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 580)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAccessControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAccessControl"
        Me.Panel.ResumeLayout(False)
        Me.gbAssignProfile.ResumeLayout(False)
        Me.gbAssignProfile.PerformLayout()
        CType(Me.C1TrueDBGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAccessAssign.ResumeLayout(False)
        Me.gbAccessAssign.PerformLayout()
        CType(Me.C1TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSelectProfile.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents gbAccessAssign As System.Windows.Forms.GroupBox
    Friend WithEvents gbSelectProfile As System.Windows.Forms.GroupBox
    Friend WithEvents cboProfiles As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccessGranted As System.Windows.Forms.Label
    Friend WithEvents lblAccessDenied As System.Windows.Forms.Label
    Friend WithEvents btnDenied As System.Windows.Forms.Button
    Friend WithEvents btnGrantAccess As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents C1TrueDBGrid2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents gbAssignProfile As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdateProfile As System.Windows.Forms.Button
    Friend WithEvents cboUserName As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrentProfile As System.Windows.Forms.Label
    Friend WithEvents txtUserProfile As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents C1TrueDBGrid3 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
