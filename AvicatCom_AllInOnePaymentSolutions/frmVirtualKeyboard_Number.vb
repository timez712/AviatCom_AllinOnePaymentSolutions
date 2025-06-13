
Public Class frmVirtualKeyboard_Number

    ' ''' <summary>
    ' ''' Set the decription of the data you want to be edit.  Usually will be the label text for the textbox
    ' ''' </summary>
    ' ''' <value>Display discrption</value>
    ' ''' <remarks></remarks>
    'Public WriteOnly Property InputDecription() As String
    '    Set(ByVal value)
    '        gbImput.Text = value
    '    End Set
    'End Property
    ' ''' <summary>
    ' ''' Set the data as string for virtual Keyboard to edit.
    ' ''' </summary>
    ' ''' <value>Data as string that you want to edit</value>
    ' ''' <remarks></remarks>
    'Public WriteOnly Property InputData() As String
    '    Set(ByVal value)
    '        txtInputText.Text = value
    '    End Set
    'End Property

    'Public WriteOnly Property SetInputDecription As String
    '    Set(ByVal value As String)
    '        SetInputDisplay(value)
    '    End Set
    'End Property
    Private mbDisplayMoney As Boolean = False
    Private mbReverseFill As Boolean = False
    Public WriteOnly Property SetDisplayMoney As Boolean
        Set(ByVal value As Boolean)
            mbDisplayMoney = value
            mbReverseFill = value
        End Set
    End Property
    Public Sub SetInputDisplay(ByVal sDisplayInfo As String)
        Try
            gbInput.Text = sDisplayInfo
        Catch exp As Exception

        End Try
    End Sub
    Public WriteOnly Property SetEditText As String
        Set(ByVal value As String)
            txtInputText.Text = value
            txtInputText.SelectionStart = txtInputText.Text.Length
        End Set
    End Property
    Public WriteOnly Property SetEditText_Highlight As String
        Set(ByVal value As String)
            txtInputText.Text = value
            txtInputText.Focus()
            txtInputText.SelectAll()
        End Set
    End Property
    Public WriteOnly Property IsPassword As Boolean
        Set(ByVal value As Boolean)
            txtInputText.UseSystemPasswordChar = value
        End Set
    End Property
    Public WriteOnly Property SetDashVisble As Boolean
        Set(ByVal value As Boolean)
            btnDash.Visible = value
            If value Then
                Btn0.Width = Btn1.Width
            Else
                Btn0.Width = Btn1.Width * 3
            End If
        End Set
    End Property
    Private Sub frmVirtualKeyboard_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        txtInputText.UseSystemPasswordChar = False
    End Sub

    Private Sub frmVirtualKeyboard_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        txtInputText.UseSystemPasswordChar = False
    End Sub

    Private Sub VirtualKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi
        'AutoSize = True
        'AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        Me.CenterToParent()
        txtInputText.Select()
    End Sub


    Private Sub EditInput(ByVal sChar As String)
        Try

            Dim iStart As Integer = txtInputText.SelectionStart
            txtInputText.SelectedText = ""
            Dim sStartText As String = Mid(txtInputText.Text, 1, iStart)
            Dim sEndText As String = Mid(txtInputText.Text, iStart + 1)
            If sChar.ToUpper = "DELETE" Then
                txtInputText.Text = sStartText & Mid(sEndText, 2)
                txtInputText.SelectionStart = iStart
            ElseIf sChar.ToUpper = "BACKSPACE" Then
                txtInputText.Text = Mid(sStartText, 1, sStartText.Length - 1) & sEndText
                txtInputText.SelectionStart = iStart - 1
            ElseIf sChar.ToUpper = "SPACE" Then
                txtInputText.Text = sStartText & " " & sEndText
                txtInputText.SelectionStart = iStart + 1
            Else

                txtInputText.Text = sStartText & sChar & sEndText

                txtInputText.SelectionStart = iStart + 1

            End If
            txtInputText.Focus()

        Catch exp As Exception
            'If gbDebugDisplayMSG Then MessageBox.Show("Error - " & Me.Text & "EditInput" & Chr(13) & exp.ToString)
            'LogToSystemEvent("AC_InventorySystems", Me.Text, "EditInput" & Chr(13) & exp.Message & Chr(13) & Chr(13) & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub



    Private Sub BtnBackSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        If mbDisplayMoney Then
            'If Not txtInputText.Text = "" Then txtInputText.Text = GetAmountFromString(txtInputText.Text, "BACKSPACE", True)
            txtInputText.Text = "$0.00"
        Else
            EditInput("Backspace")
        End If


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        EditInput(btnDelete.Text)
    End Sub

    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        gsVirtualKeyboardData = txtInputText.Text
        txtInputText.Text = ""
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        gsVirtualKeyboardData = ""
        txtInputText.Text = ""
        Me.Close()
    End Sub


    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
         If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub


    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub btn00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDash.Click
        If mbDisplayMoney Then
            txtInputText.Text = GetAmountFromString(txtInputText.Text, CType(sender, Button).Text, True)
        Else
            EditInput(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub txtInputText_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtInputText.KeyUp
        'If e.KeyCode = Keys.Enter Then BtnEnter.PerformClick()
    End Sub

End Class