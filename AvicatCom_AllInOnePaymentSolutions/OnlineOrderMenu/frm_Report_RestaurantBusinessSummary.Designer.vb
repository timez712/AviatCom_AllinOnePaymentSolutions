<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Report_RestaurantBusinessSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Report_RestaurantBusinessSummary))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCurrentActiveCustomerOnly = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLastMonth = New System.Windows.Forms.Button()
        Me.btnPreviousMonth = New System.Windows.Forms.Button()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.btnGetSummary = New System.Windows.Forms.Button()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.C1TrueDBGrid1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(740, 474)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnGetSummary)
        Me.GroupBox1.Controls.Add(Me.btnNextMonth)
        Me.GroupBox1.Controls.Add(Me.btnPreviousMonth)
        Me.GroupBox1.Controls.Add(Me.btnLastMonth)
        Me.GroupBox1.Controls.Add(Me.dtDateTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkCurrentActiveCustomerOnly)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters"
        '
        'chkCurrentActiveCustomerOnly
        '
        Me.chkCurrentActiveCustomerOnly.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkCurrentActiveCustomerOnly.Checked = True
        Me.chkCurrentActiveCustomerOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCurrentActiveCustomerOnly.Location = New System.Drawing.Point(6, 19)
        Me.chkCurrentActiveCustomerOnly.Name = "chkCurrentActiveCustomerOnly"
        Me.chkCurrentActiveCustomerOnly.Size = New System.Drawing.Size(82, 53)
        Me.chkCurrentActiveCustomerOnly.TabIndex = 0
        Me.chkCurrentActiveCustomerOnly.Text = "Current Active Customer Only"
        Me.chkCurrentActiveCustomerOnly.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(94, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From"
        '
        'dtDateFrom
        '
        Me.dtDateFrom.CustomFormat = "MM/dd/yyyy"
        Me.dtDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDateFrom.Location = New System.Drawing.Point(140, 33)
        Me.dtDateFrom.Name = "dtDateFrom"
        Me.dtDateFrom.Size = New System.Drawing.Size(121, 23)
        Me.dtDateFrom.TabIndex = 2
        '
        'dtDateTo
        '
        Me.dtDateTo.CustomFormat = "MM/dd/yyyy"
        Me.dtDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDateTo.Location = New System.Drawing.Point(298, 33)
        Me.dtDateTo.Name = "dtDateTo"
        Me.dtDateTo.Size = New System.Drawing.Size(121, 23)
        Me.dtDateTo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(267, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To"
        '
        'btnLastMonth
        '
        Me.btnLastMonth.Location = New System.Drawing.Point(425, 25)
        Me.btnLastMonth.Name = "btnLastMonth"
        Me.btnLastMonth.Size = New System.Drawing.Size(47, 39)
        Me.btnLastMonth.TabIndex = 5
        Me.btnLastMonth.Text = "Last Month"
        Me.btnLastMonth.UseVisualStyleBackColor = True
        '
        'btnPreviousMonth
        '
        Me.btnPreviousMonth.Location = New System.Drawing.Point(478, 25)
        Me.btnPreviousMonth.Name = "btnPreviousMonth"
        Me.btnPreviousMonth.Size = New System.Drawing.Size(56, 39)
        Me.btnPreviousMonth.TabIndex = 6
        Me.btnPreviousMonth.Text = "Previous Month"
        Me.btnPreviousMonth.UseVisualStyleBackColor = True
        '
        'btnNextMonth
        '
        Me.btnNextMonth.Location = New System.Drawing.Point(540, 25)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(49, 39)
        Me.btnNextMonth.TabIndex = 7
        Me.btnNextMonth.Text = "Next Month"
        Me.btnNextMonth.UseVisualStyleBackColor = True
        '
        'btnGetSummary
        '
        Me.btnGetSummary.Location = New System.Drawing.Point(612, 25)
        Me.btnGetSummary.Name = "btnGetSummary"
        Me.btnGetSummary.Size = New System.Drawing.Size(103, 39)
        Me.btnGetSummary.TabIndex = 8
        Me.btnGetSummary.Text = "Get Restaurant Summary"
        Me.btnGetSummary.UseVisualStyleBackColor = True
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid1.CaptionHeight = 17
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(3, 81)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(730, 376)
        Me.C1TrueDBGrid1.TabIndex = 71
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'frm_Report_RestaurantBusinessSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(764, 498)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Report_RestaurantBusinessSummary"
        Me.Text = "Restaurant Business Summary"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtDateTo As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtDateFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents chkCurrentActiveCustomerOnly As CheckBox
    Friend WithEvents btnNextMonth As Button
    Friend WithEvents btnPreviousMonth As Button
    Friend WithEvents btnLastMonth As Button
    Friend WithEvents btnGetSummary As Button
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
