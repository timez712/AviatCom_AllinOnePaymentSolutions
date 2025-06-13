<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneral))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnMerchant = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnPaperRequest = New System.Windows.Forms.Button()
        Me.btnExpressInput = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Blue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnPaperRequest)
        Me.Panel1.Controls.Add(Me.btnExpressInput)
        Me.Panel1.Controls.Add(Me.btnMerchant)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnQuit)
        Me.Panel1.Location = New System.Drawing.Point(12, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(578, 243)
        Me.Panel1.TabIndex = 0
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.Red
        Me.btnQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(431, 182)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(137, 52)
        Me.btnQuit.TabIndex = 133
        Me.btnQuit.Text = "EXIT"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'btnMerchant
        '
        Me.btnMerchant.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMerchant.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMerchant.Location = New System.Drawing.Point(399, 3)
        Me.btnMerchant.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMerchant.Name = "btnMerchant"
        Me.btnMerchant.Size = New System.Drawing.Size(169, 172)
        Me.btnMerchant.TabIndex = 147
        Me.btnMerchant.Text = "Merchant"
        Me.btnMerchant.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 172)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 146
        Me.PictureBox1.TabStop = False
        '
        'btnPaperRequest
        '
        Me.btnPaperRequest.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPaperRequest.Enabled = False
        Me.btnPaperRequest.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaperRequest.Location = New System.Drawing.Point(201, 4)
        Me.btnPaperRequest.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPaperRequest.Name = "btnPaperRequest"
        Me.btnPaperRequest.Size = New System.Drawing.Size(192, 69)
        Me.btnPaperRequest.TabIndex = 149
        Me.btnPaperRequest.Text = "Paper Request"
        Me.btnPaperRequest.UseVisualStyleBackColor = False
        Me.btnPaperRequest.Visible = False
        '
        'btnExpressInput
        '
        Me.btnExpressInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnExpressInput.Enabled = False
        Me.btnExpressInput.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpressInput.Location = New System.Drawing.Point(201, 103)
        Me.btnExpressInput.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExpressInput.Name = "btnExpressInput"
        Me.btnExpressInput.Size = New System.Drawing.Size(192, 73)
        Me.btnExpressInput.TabIndex = 148
        Me.btnExpressInput.Text = "Express Input"
        Me.btnExpressInput.UseVisualStyleBackColor = False
        Me.btnExpressInput.Visible = False
        '
        'frmGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 263)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "General Selection"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnPaperRequest As System.Windows.Forms.Button
    Friend WithEvents btnExpressInput As System.Windows.Forms.Button
    Friend WithEvents btnMerchant As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
