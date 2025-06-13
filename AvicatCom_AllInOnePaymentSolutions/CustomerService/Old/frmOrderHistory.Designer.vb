<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrderHistory))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSaveUnwantedOrder = New System.Windows.Forms.Button()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.tpOrderHistory = New System.Windows.Forms.TabPage()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tpTempOrderHistory = New System.Windows.Forms.TabPage()
        Me.C1TrueDBGrid2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCloseOrder = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbClosed = New System.Windows.Forms.RadioButton()
        Me.rbReady = New System.Windows.Forms.RadioButton()
        Me.rbDeleted = New System.Windows.Forms.RadioButton()
        Me.rbNew = New System.Windows.Forms.RadioButton()
        Me.dtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.dtDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.tpOrderHistory.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTempOrderHistory.SuspendLayout()
        CType(Me.C1TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnSaveUnwantedOrder)
        Me.Panel1.Controls.Add(Me.TabControl)
        Me.Panel1.Controls.Add(Me.btnCloseOrder)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnQuit)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1460, 738)
        Me.Panel1.TabIndex = 0
        '
        'btnSaveUnwantedOrder
        '
        Me.btnSaveUnwantedOrder.BackColor = System.Drawing.SystemColors.Control
        Me.btnSaveUnwantedOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveUnwantedOrder.Location = New System.Drawing.Point(672, 686)
        Me.btnSaveUnwantedOrder.Name = "btnSaveUnwantedOrder"
        Me.btnSaveUnwantedOrder.Size = New System.Drawing.Size(203, 45)
        Me.btnSaveUnwantedOrder.TabIndex = 178
        Me.btnSaveUnwantedOrder.Text = "Save Unwanted Orders"
        Me.btnSaveUnwantedOrder.UseVisualStyleBackColor = False
        Me.btnSaveUnwantedOrder.Visible = False
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.tpOrderHistory)
        Me.TabControl.Controls.Add(Me.tpTempOrderHistory)
        Me.TabControl.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl.ItemSize = New System.Drawing.Size(500, 25)
        Me.TabControl.Location = New System.Drawing.Point(3, 90)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1450, 590)
        Me.TabControl.TabIndex = 177
        '
        'tpOrderHistory
        '
        Me.tpOrderHistory.BackColor = System.Drawing.Color.Transparent
        Me.tpOrderHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpOrderHistory.Controls.Add(Me.C1TrueDBGrid1)
        Me.tpOrderHistory.Location = New System.Drawing.Point(4, 29)
        Me.tpOrderHistory.Name = "tpOrderHistory"
        Me.tpOrderHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrderHistory.Size = New System.Drawing.Size(1442, 557)
        Me.tpOrderHistory.TabIndex = 0
        Me.tpOrderHistory.Text = "          Order History          "
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowRowSelect = False
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
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(1430, 531)
        Me.C1TrueDBGrid1.TabIndex = 60
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid2"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'tpTempOrderHistory
        '
        Me.tpTempOrderHistory.BackColor = System.Drawing.Color.Transparent
        Me.tpTempOrderHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpTempOrderHistory.Controls.Add(Me.C1TrueDBGrid2)
        Me.tpTempOrderHistory.Location = New System.Drawing.Point(4, 29)
        Me.tpTempOrderHistory.Name = "tpTempOrderHistory"
        Me.tpTempOrderHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTempOrderHistory.Size = New System.Drawing.Size(1442, 557)
        Me.tpTempOrderHistory.TabIndex = 1
        Me.tpTempOrderHistory.Text = "Quote History          "
        '
        'C1TrueDBGrid2
        '
        Me.C1TrueDBGrid2.AllowRowSelect = False
        Me.C1TrueDBGrid2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid2.CaptionHeight = 34
        Me.C1TrueDBGrid2.ExtendRightColumn = True
        Me.C1TrueDBGrid2.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid2.Images.Add(CType(resources.GetObject("C1TrueDBGrid2.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid2.Location = New System.Drawing.Point(4, 6)
        Me.C1TrueDBGrid2.Name = "C1TrueDBGrid2"
        Me.C1TrueDBGrid2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid2.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid2.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid2.RowHeight = 15
        Me.C1TrueDBGrid2.Size = New System.Drawing.Size(1430, 529)
        Me.C1TrueDBGrid2.TabIndex = 61
        Me.C1TrueDBGrid2.Text = "C1TrueDBGrid2"
        Me.C1TrueDBGrid2.PropBag = resources.GetString("C1TrueDBGrid2.PropBag")
        '
        'btnCloseOrder
        '
        Me.btnCloseOrder.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnCloseOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseOrder.Location = New System.Drawing.Point(7, 686)
        Me.btnCloseOrder.Name = "btnCloseOrder"
        Me.btnCloseOrder.Size = New System.Drawing.Size(147, 45)
        Me.btnCloseOrder.TabIndex = 176
        Me.btnCloseOrder.Text = "Close Order"
        Me.btnCloseOrder.UseVisualStyleBackColor = False
        Me.btnCloseOrder.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.GreenYellow
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(1219, 700)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(103, 31)
        Me.btnRefresh.TabIndex = 175
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        Me.btnRefresh.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbFilter)
        Me.GroupBox1.Controls.Add(Me.dtDateTo)
        Me.GroupBox1.Controls.Add(Me.lblDateTo)
        Me.GroupBox1.Controls.Add(Me.dtDateFrom)
        Me.GroupBox1.Controls.Add(Me.lblDateFrom)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1450, 81)
        Me.GroupBox1.TabIndex = 136
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.rbAll)
        Me.gbFilter.Controls.Add(Me.rbClosed)
        Me.gbFilter.Controls.Add(Me.rbReady)
        Me.gbFilter.Controls.Add(Me.rbDeleted)
        Me.gbFilter.Controls.Add(Me.rbNew)
        Me.gbFilter.Location = New System.Drawing.Point(975, 13)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(469, 62)
        Me.gbFilter.TabIndex = 4
        Me.gbFilter.TabStop = False
        Me.gbFilter.Text = "Filter"
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Location = New System.Drawing.Point(6, 30)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(51, 26)
        Me.rbAll.TabIndex = 4
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbClosed
        '
        Me.rbClosed.AutoSize = True
        Me.rbClosed.Location = New System.Drawing.Point(255, 30)
        Me.rbClosed.Name = "rbClosed"
        Me.rbClosed.Size = New System.Drawing.Size(93, 26)
        Me.rbClosed.TabIndex = 3
        Me.rbClosed.Text = "Closed"
        Me.rbClosed.UseVisualStyleBackColor = True
        '
        'rbReady
        '
        Me.rbReady.AutoSize = True
        Me.rbReady.Location = New System.Drawing.Point(154, 30)
        Me.rbReady.Name = "rbReady"
        Me.rbReady.Size = New System.Drawing.Size(86, 26)
        Me.rbReady.TabIndex = 2
        Me.rbReady.Text = "Ready"
        Me.rbReady.UseVisualStyleBackColor = True
        '
        'rbDeleted
        '
        Me.rbDeleted.AutoSize = True
        Me.rbDeleted.Location = New System.Drawing.Point(363, 30)
        Me.rbDeleted.Name = "rbDeleted"
        Me.rbDeleted.Size = New System.Drawing.Size(98, 26)
        Me.rbDeleted.TabIndex = 1
        Me.rbDeleted.Text = "Deleted"
        Me.rbDeleted.UseVisualStyleBackColor = True
        '
        'rbNew
        '
        Me.rbNew.AutoSize = True
        Me.rbNew.Checked = True
        Me.rbNew.Location = New System.Drawing.Point(72, 30)
        Me.rbNew.Name = "rbNew"
        Me.rbNew.Size = New System.Drawing.Size(67, 26)
        Me.rbNew.TabIndex = 0
        Me.rbNew.TabStop = True
        Me.rbNew.Text = "New"
        Me.rbNew.UseVisualStyleBackColor = True
        '
        'dtDateTo
        '
        Me.dtDateTo.Location = New System.Drawing.Point(607, 32)
        Me.dtDateTo.Name = "dtDateTo"
        Me.dtDateTo.Size = New System.Drawing.Size(348, 29)
        Me.dtDateTo.TabIndex = 3
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(508, 37)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(93, 22)
        Me.lblDateTo.TabIndex = 2
        Me.lblDateTo.Text = "Date To :"
        '
        'dtDateFrom
        '
        Me.dtDateFrom.Location = New System.Drawing.Point(130, 32)
        Me.dtDateFrom.Name = "dtDateFrom"
        Me.dtDateFrom.Size = New System.Drawing.Size(348, 29)
        Me.dtDateFrom.TabIndex = 1
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(6, 37)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(118, 22)
        Me.lblDateFrom.TabIndex = 0
        Me.lblDateFrom.Text = "Date From :"
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.Red
        Me.btnQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(1350, 686)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(103, 45)
        Me.btnQuit.TabIndex = 135
        Me.btnQuit.Text = "Exit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'frmOrderHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1484, 762)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmOrderHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOrderHistory"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.tpOrderHistory.ResumeLayout(False)
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTempOrderHistory.ResumeLayout(False)
        CType(Me.C1TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents dtDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCloseOrder As System.Windows.Forms.Button
    Friend WithEvents gbFilter As System.Windows.Forms.GroupBox
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbClosed As System.Windows.Forms.RadioButton
    Friend WithEvents rbReady As System.Windows.Forms.RadioButton
    Friend WithEvents rbDeleted As System.Windows.Forms.RadioButton
    Friend WithEvents rbNew As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents tpOrderHistory As System.Windows.Forms.TabPage
    Friend WithEvents tpTempOrderHistory As System.Windows.Forms.TabPage
    Friend WithEvents C1TrueDBGrid2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnSaveUnwantedOrder As System.Windows.Forms.Button
End Class
