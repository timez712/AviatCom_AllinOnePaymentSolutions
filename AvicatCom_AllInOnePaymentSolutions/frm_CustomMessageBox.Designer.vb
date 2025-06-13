<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CustomMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CustomMessageBox))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.lblDisplayHeader = New System.Windows.Forms.Label()
        Me.txtMessageDetail = New System.Windows.Forms.TextBox()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox)
        Me.Panel1.Controls.Add(Me.lblDisplayHeader)
        Me.Panel1.Controls.Add(Me.txtMessageDetail)
        Me.Panel1.Controls.Add(Me.btn3)
        Me.Panel1.Controls.Add(Me.btn2)
        Me.Panel1.Controls.Add(Me.btn1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(960, 638)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(876, 3)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(77, 77)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 6
        Me.PictureBox.TabStop = False
        '
        'lblDisplayHeader
        '
        Me.lblDisplayHeader.AutoSize = True
        Me.lblDisplayHeader.Location = New System.Drawing.Point(55, 26)
        Me.lblDisplayHeader.Name = "lblDisplayHeader"
        Me.lblDisplayHeader.Size = New System.Drawing.Size(116, 43)
        Me.lblDisplayHeader.TabIndex = 5
        Me.lblDisplayHeader.Text = "Label1"
        '
        'txtMessageDetail
        '
        Me.txtMessageDetail.BackColor = System.Drawing.SystemColors.ControlText
        Me.txtMessageDetail.ForeColor = System.Drawing.SystemColors.Window
        Me.txtMessageDetail.Location = New System.Drawing.Point(63, 87)
        Me.txtMessageDetail.Multiline = True
        Me.txtMessageDetail.Name = "txtMessageDetail"
        Me.txtMessageDetail.Size = New System.Drawing.Size(828, 353)
        Me.txtMessageDetail.TabIndex = 4
        Me.txtMessageDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn3
        '
        Me.btn3.Location = New System.Drawing.Point(649, 473)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(304, 158)
        Me.btn3.TabIndex = 2
        Me.btn3.Text = "Button3"
        Me.btn3.UseVisualStyleBackColor = True
        Me.btn3.Visible = False
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(328, 473)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(304, 158)
        Me.btn2.TabIndex = 1
        Me.btn2.Text = "Button2"
        Me.btn2.UseVisualStyleBackColor = True
        Me.btn2.Visible = False
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(3, 473)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(304, 158)
        Me.btn1.TabIndex = 0
        Me.btn1.Text = "Button1"
        Me.btn1.UseVisualStyleBackColor = True
        Me.btn1.Visible = False
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "confirm.png")
        Me.ImageList.Images.SetKeyName(1, "Exclamation.png")
        Me.ImageList.Images.SetKeyName(2, "Information.png")
        Me.ImageList.Images.SetKeyName(3, "Okay.png")
        Me.ImageList.Images.SetKeyName(4, "Question.png")
        Me.ImageList.Images.SetKeyName(5, "Warning.png")
        '
        'frm_CustomMessageBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(9)
        Me.Name = "frm_CustomMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCustomMessageBox"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDisplayHeader As System.Windows.Forms.Label
    Friend WithEvents txtMessageDetail As System.Windows.Forms.TextBox
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
End Class
