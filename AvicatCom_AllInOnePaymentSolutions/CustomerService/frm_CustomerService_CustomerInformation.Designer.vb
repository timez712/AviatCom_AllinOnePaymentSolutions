<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CustomerService_CustomerInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CustomerService_CustomerInformation))
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnNewMerchant = New System.Windows.Forms.Button()
        Me.btnRefreshData = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUnActive = New System.Windows.Forms.Label()
        Me.lblActiveLegend = New System.Windows.Forms.Label()
        Me.btnFollowupTask = New System.Windows.Forms.Button()
        Me.btnRequestPaperHistory = New System.Windows.Forms.Button()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid1.CaptionHeight = 34
        Me.C1TrueDBGrid1.ExtendRightColumn = True
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(12, 51)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(916, 426)
        Me.C1TrueDBGrid1.TabIndex = 60
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'btnNewMerchant
        '
        Me.btnNewMerchant.Location = New System.Drawing.Point(12, 12)
        Me.btnNewMerchant.Name = "btnNewMerchant"
        Me.btnNewMerchant.Size = New System.Drawing.Size(210, 23)
        Me.btnNewMerchant.TabIndex = 61
        Me.btnNewMerchant.Text = "New Merchant"
        Me.btnNewMerchant.UseVisualStyleBackColor = True
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshData.Location = New System.Drawing.Point(802, 12)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(126, 23)
        Me.btnRefreshData.TabIndex = 62
        Me.btnRefreshData.Text = "RefreshData"
        Me.btnRefreshData.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUnActive)
        Me.GroupBox1.Controls.Add(Me.lblActiveLegend)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 483)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 34)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color Legend"
        '
        'lblUnActive
        '
        Me.lblUnActive.AutoSize = True
        Me.lblUnActive.BackColor = System.Drawing.Color.LightPink
        Me.lblUnActive.Location = New System.Drawing.Point(59, 16)
        Me.lblUnActive.Name = "lblUnActive"
        Me.lblUnActive.Size = New System.Drawing.Size(51, 13)
        Me.lblUnActive.TabIndex = 1
        Me.lblUnActive.Text = "UnActive"
        '
        'lblActiveLegend
        '
        Me.lblActiveLegend.AutoSize = True
        Me.lblActiveLegend.BackColor = System.Drawing.Color.LightCyan
        Me.lblActiveLegend.Location = New System.Drawing.Point(16, 16)
        Me.lblActiveLegend.Name = "lblActiveLegend"
        Me.lblActiveLegend.Size = New System.Drawing.Size(37, 13)
        Me.lblActiveLegend.TabIndex = 0
        Me.lblActiveLegend.Text = "Active"
        '
        'btnFollowupTask
        '
        Me.btnFollowupTask.Location = New System.Drawing.Point(586, 12)
        Me.btnFollowupTask.Name = "btnFollowupTask"
        Me.btnFollowupTask.Size = New System.Drawing.Size(210, 23)
        Me.btnFollowupTask.TabIndex = 64
        Me.btnFollowupTask.Text = "New Followup Tasks"
        Me.btnFollowupTask.UseVisualStyleBackColor = True
        '
        'btnRequestPaperHistory
        '
        Me.btnRequestPaperHistory.Location = New System.Drawing.Point(370, 12)
        Me.btnRequestPaperHistory.Name = "btnRequestPaperHistory"
        Me.btnRequestPaperHistory.Size = New System.Drawing.Size(210, 23)
        Me.btnRequestPaperHistory.TabIndex = 65
        Me.btnRequestPaperHistory.Text = "Request Paper History"
        Me.btnRequestPaperHistory.UseVisualStyleBackColor = True
        '
        'frm_CustomerService_CustomerInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(942, 523)
        Me.Controls.Add(Me.btnRequestPaperHistory)
        Me.Controls.Add(Me.btnFollowupTask)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.C1TrueDBGrid1)
        Me.Controls.Add(Me.btnRefreshData)
        Me.Controls.Add(Me.btnNewMerchant)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(950, 550)
        Me.Name = "frm_CustomerService_CustomerInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_CustomerService_CustomerInformation"
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnNewMerchant As System.Windows.Forms.Button
    Friend WithEvents btnRefreshData As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUnActive As System.Windows.Forms.Label
    Friend WithEvents lblActiveLegend As System.Windows.Forms.Label
    Friend WithEvents btnFollowupTask As System.Windows.Forms.Button
    Friend WithEvents btnRequestPaperHistory As System.Windows.Forms.Button
End Class
