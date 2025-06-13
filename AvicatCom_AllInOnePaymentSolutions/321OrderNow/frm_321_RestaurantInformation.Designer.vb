<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_321_RestaurantInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_321_RestaurantInformation))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSearchRestaurant = New System.Windows.Forms.TabPage()
        Me.btnCreateNameRestaurant = New System.Windows.Forms.Button()
        Me.btnRefreshData = New System.Windows.Forms.Button()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tpRestaurantInformation = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.tpSearchRestaurant.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpRestaurantInformation.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpSearchRestaurant)
        Me.TabControl1.Controls.Add(Me.tpRestaurantInformation)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(916, 496)
        Me.TabControl1.TabIndex = 0
        '
        'tpSearchRestaurant
        '
        Me.tpSearchRestaurant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpSearchRestaurant.Controls.Add(Me.btnCreateNameRestaurant)
        Me.tpSearchRestaurant.Controls.Add(Me.btnRefreshData)
        Me.tpSearchRestaurant.Controls.Add(Me.C1TrueDBGrid1)
        Me.tpSearchRestaurant.Location = New System.Drawing.Point(4, 22)
        Me.tpSearchRestaurant.Name = "tpSearchRestaurant"
        Me.tpSearchRestaurant.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearchRestaurant.Size = New System.Drawing.Size(908, 470)
        Me.tpSearchRestaurant.TabIndex = 0
        Me.tpSearchRestaurant.Text = "Search Restaurant"
        Me.tpSearchRestaurant.UseVisualStyleBackColor = True
        '
        'btnCreateNameRestaurant
        '
        Me.btnCreateNameRestaurant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCreateNameRestaurant.Location = New System.Drawing.Point(6, 437)
        Me.btnCreateNameRestaurant.Name = "btnCreateNameRestaurant"
        Me.btnCreateNameRestaurant.Size = New System.Drawing.Size(175, 23)
        Me.btnCreateNameRestaurant.TabIndex = 63
        Me.btnCreateNameRestaurant.Text = "Create New Restaurant"
        Me.btnCreateNameRestaurant.UseVisualStyleBackColor = True
        Me.btnCreateNameRestaurant.Visible = False
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshData.Location = New System.Drawing.Point(791, 442)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(107, 23)
        Me.btnRefreshData.TabIndex = 62
        Me.btnRefreshData.Text = "Refresh Data"
        Me.btnRefreshData.UseVisualStyleBackColor = True
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
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(6, 6)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(892, 414)
        Me.C1TrueDBGrid1.TabIndex = 61
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'tpRestaurantInformation
        '
        Me.tpRestaurantInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpRestaurantInformation.Controls.Add(Me.TabControl2)
        Me.tpRestaurantInformation.Location = New System.Drawing.Point(4, 22)
        Me.tpRestaurantInformation.Name = "tpRestaurantInformation"
        Me.tpRestaurantInformation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRestaurantInformation.Size = New System.Drawing.Size(908, 470)
        Me.tpRestaurantInformation.TabIndex = 1
        Me.tpRestaurantInformation.Text = "Restaurant Information"
        Me.tpRestaurantInformation.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Location = New System.Drawing.Point(6, 6)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(892, 454)
        Me.TabControl2.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(884, 428)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(192, 74)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frm_321_RestaurantInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 520)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_321_RestaurantInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restaurant Information"
        Me.TabControl1.ResumeLayout(False)
        Me.tpSearchRestaurant.ResumeLayout(False)
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpRestaurantInformation.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpSearchRestaurant As System.Windows.Forms.TabPage
    Friend WithEvents tpRestaurantInformation As System.Windows.Forms.TabPage
    Friend WithEvents btnCreateNameRestaurant As System.Windows.Forms.Button
    Friend WithEvents btnRefreshData As System.Windows.Forms.Button
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class
