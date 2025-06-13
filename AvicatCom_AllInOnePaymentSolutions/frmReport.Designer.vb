<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport))
        Me.CR_ReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CR_ReportViewer
        '
        Me.CR_ReportViewer.ActiveViewIndex = -1
        Me.CR_ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CR_ReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CR_ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CR_ReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CR_ReportViewer.Name = "CR_ReportViewer"
        Me.CR_ReportViewer.ShowGroupTreeButton = False
        Me.CR_ReportViewer.ShowParameterPanelButton = False
        Me.CR_ReportViewer.Size = New System.Drawing.Size(966, 585)
        Me.CR_ReportViewer.TabIndex = 0
        Me.CR_ReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 585)
        Me.Controls.Add(Me.CR_ReportViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReport"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CR_ReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
