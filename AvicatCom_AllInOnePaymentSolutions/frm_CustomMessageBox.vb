'Imports DWL_Lib.DWL_Lib
Public Class frm_CustomMessageBox
    ''' <summary>
    ''' Set Button1 Display Text
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetButton1_Text
        Set(value)
            btn1.Visible = True
            btn1.Text = value
        End Set
    End Property
    ''' <summary>
    ''' Set button press return
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetButton1_ReturnExpected
        Set(value)
            btn1.Tag = value
        End Set
    End Property
    ''' <summary>
    ''' Set Button2 Display Text
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetButton2_Text
        Set(value)
            btn2.Visible = True
            btn2.Text = value
        End Set
    End Property
    ''' <summary>
    ''' Set button press return
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetButton2_ReturnExpected
        Set(value)
            btn2.Tag = value
        End Set
    End Property

    ''' <summary>
    ''' Set Button3 Display Text
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetButton3_Text
        Set(value)
            btn3.Visible = True
            btn3.Text = value
        End Set
    End Property
    ''' <summary>
    ''' Set button press return
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetButton3_ReturnExpected
        Set(value)
            btn3.Tag = value
        End Set
    End Property
    ''' <summary>
    ''' Set MSG Display header
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetDisplayMSGHeader
        Set(value)
            lblDisplayHeader.Text = value
        End Set
    End Property
    ''' <summary>
    ''' Set Detail MSG for display box
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetDisplayMSGDetail
        Set(value)
            txtMessageDetail.Text = value
        End Set
    End Property
    ''' <summary>
    ''' Set back color for custom MSG box
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property SetPanelBackColor As Color
        Set(value As Color)
            Panel1.BackColor = value
        End Set
    End Property

    Friend WriteOnly Property SetButton1_BackColor As Color
        Set(value As Color)
            btn1.BackColor = value
        End Set
    End Property
    Friend WriteOnly Property SetButton2_BackColor As Color
        Set(value As Color)
            btn2.BackColor = value
        End Set
    End Property
    Friend WriteOnly Property SetButton3_BackColor As Color
        Set(value As Color)
            btn3.BackColor = value
        End Set
    End Property
    ''' <summary>
    ''' Set Display Icon for message box.  Default is 2 - Information.
    ''' </summary>
    ''' <value>Integer for 0 to 5</value>
    ''' <remarks>0-Confirm, 1-Exclamation, 2-Information, 3-Okay, 4-Question, 5-Warning</remarks>
    Friend WriteOnly Property SetDisplayIcon As Integer
        Set(value As Integer)
            If value < 0 And value > 5 Then value = 2
            PictureBox.Image = ImageList.Images(value)
        End Set
    End Property
    Private Sub frmCustomMessageBox_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi
        'AutoSize = True
        'AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        If PictureBox.Image Is Nothing Then
            PictureBox.Image = ImageList.Images(2)
        End If
    End Sub

    Private Sub btn1_Click(sender As System.Object, e As System.EventArgs) Handles btn1.Click
        gsCustomMSGReturn = btn1.Tag
        Me.Close()
    End Sub

    Private Sub btn2_Click(sender As System.Object, e As System.EventArgs) Handles btn2.Click
        gsCustomMSGReturn = btn2.Tag
        Me.Close()
    End Sub

    Private Sub btn3_Click(sender As System.Object, e As System.EventArgs) Handles btn3.Click
        gsCustomMSGReturn = btn3.Tag
        Me.Close()
    End Sub
End Class