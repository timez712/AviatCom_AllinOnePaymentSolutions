
Public Class frmVirtualKeyboard

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
    Public WriteOnly Property IsPassword As Boolean
        Set(ByVal value As Boolean)
            txtInputText.UseSystemPasswordChar = value
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
        If txtInputText.Text.Trim.Length = 0 Then BtnUpLowCase.BackColor = Color.LightCyan

        Me.CenterToParent()
        txtInputText.Select()
    End Sub
    Private Sub DisplayLowerCase(ByVal sAction As String)
        Try
            If sAction.ToUpper = "UPPER" Then
                BtnA.Text = "A"
                BtnB.Text = "B"
                BtnC.Text = "C"
                BtnD.Text = "D"
                BtnE.Text = "E"
                BtnF.Text = "F"
                BtnG.Text = "G"
                BtnH.Text = "H"
                BtnI.Text = "I"
                BtnJ.Text = "J"
                BtnK.Text = "K"
                BtnL.Text = "L"
                BtnM.Text = "M"
                BtnN.Text = "N"
                BtnO.Text = "O"
                BtnP.Text = "P"
                btnQ.Text = "Q"
                BtnR.Text = "R"
                BtnS.Text = "S"
                BtnT.Text = "T"
                BtnU.Text = "U"
                BtnV.Text = "V"
                BtnW.Text = "W"
                BtnX.Text = "X"
                BtnY.Text = "Y"
                BtnZ.Text = "Z"
                BtnUpLowCase.BackColor = Color.LightCyan
                'BtnUpLowCase.Text = ""
                'BtnNumChar.Text = ""

            ElseIf sAction.ToUpper = "LOWER" Then
                BtnA.Text = "a"
                BtnB.Text = "b"
                BtnC.Text = "c"
                BtnD.Text = "d"
                BtnE.Text = "e"
                BtnF.Text = "f"
                BtnG.Text = "g"
                BtnH.Text = "h"
                BtnI.Text = "i"
                BtnJ.Text = "j"
                BtnK.Text = "k"
                BtnL.Text = "l"
                BtnM.Text = "m"
                BtnN.Text = "n"
                BtnO.Text = "o"
                BtnP.Text = "p"
                btnQ.Text = "q"
                BtnR.Text = "r"
                BtnS.Text = "s"
                BtnT.Text = "t"
                BtnU.Text = "u"
                BtnV.Text = "v"
                BtnW.Text = "w"
                BtnX.Text = "x"
                BtnY.Text = "y"
                BtnZ.Text = "z"
                BtnUpLowCase.BackColor = Color.Bisque
                'BtnUpLowCase.Text = ""
                'BtnNumChar.Text = ""
                'Else
                '    BtnA.Text = "a"
                '    BtnB.Text = "b"
                '    BtnC.Text = "c"
                '    BtnD.Text = "d"
                '    BtnE.Text = "3"
                '    BtnF.Text = "f"
                '    BtnG.Text = "g"
                '    BtnH.Text = "h"
                '    BtnI.Text = "i"
                '    BtnJ.Text = "j"
                '    BtnK.Text = "k"
                '    BtnL.Text = "l"
                '    BtnM.Text = "m"
                '    BtnN.Text = "n"
                '    BtnO.Text = "o"
                '    BtnP.Text = "p"
                '    BtnQ.Text = "1"
                '    BtnR.Text = "4"
                '    BtnS.Text = "s"
                '    BtnT.Text = "5"
                '    BtnU.Text = "u"
                '    BtnV.Text = "v"
                '    BtnW.Text = "2"
                '    BtnX.Text = "x"
                '    BtnY.Text = "y"
                '    BtnZ.Text = "Z"
                '    'BtnUpLowCase.Text = ""
                '    'BtnNumChar.Text = ""
            End If
        Catch exp As Exception
            'If gbDebugDisplayMSG Then MessageBox.Show("Error - " & Me.Text & "DisplayLowerCase" & Chr(13) & exp.ToString)
            'LogToSystemEvent("AC_InventorySystems", Me.Text, "DisplayLowerCase" & Chr(13) & exp.Message & Chr(13) & Chr(13) & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub EditInput(ByVal sChar As String)
        Try
            Dim iStart As Integer = txtInputText.SelectionStart
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
                If txtInputText.Text.Trim.Length = 1 Then
                    DisplayLowerCase("LOWER")
                End If
                If sChar.ToUpper = "00" Then
                    txtInputText.SelectionStart = iStart + 2
                Else
                    txtInputText.SelectionStart = iStart + 1
                End If
            End If
            txtInputText.Focus()

        Catch exp As Exception
            'If gbDebugDisplayMSG Then MessageBox.Show("Error - " & Me.Text & "EditInput" & Chr(13) & exp.ToString)
            'LogToSystemEvent("AC_InventorySystems", Me.Text, "EditInput" & Chr(13) & exp.Message & Chr(13) & Chr(13) & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub BtnA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnA.Click
        EditInput(BtnA.Text)
    End Sub

    Private Sub BtnB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnB.Click
        EditInput(BtnB.Text)
    End Sub

    Private Sub BtnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnC.Click
        EditInput(BtnC.Text)
    End Sub

    Private Sub BtnD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnD.Click
        EditInput(BtnD.Text)
    End Sub

    Private Sub BtnE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnE.Click
        EditInput(BtnE.Text)
    End Sub

    Private Sub BtnF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnF.Click
        EditInput(BtnF.Text)
    End Sub

    Private Sub BtnG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnG.Click
        EditInput(BtnG.Text)
    End Sub

    Private Sub BtnH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnH.Click
        EditInput(BtnH.Text)
    End Sub

    Private Sub BtnI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnI.Click
        EditInput(BtnI.Text)
    End Sub

    Private Sub BtnJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJ.Click
        EditInput(BtnJ.Text)
    End Sub

    Private Sub BtnK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnK.Click
        EditInput(BtnK.Text)
    End Sub

    Private Sub BtnL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnL.Click
        EditInput(BtnL.Text)
    End Sub

    Private Sub BtnM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnM.Click
        EditInput(BtnM.Text)
    End Sub

    Private Sub BtnN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnN.Click
        EditInput(BtnN.Text)
    End Sub

    Private Sub BtnO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnO.Click
        EditInput(BtnO.Text)
    End Sub

    Private Sub BtnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnP.Click
        EditInput(BtnP.Text)
    End Sub

    Private Sub BtnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnR.Click
        EditInput(BtnR.Text)
    End Sub

    Private Sub BtnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnS.Click
        EditInput(BtnS.Text)
    End Sub

    Private Sub BtnT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnT.Click
        EditInput(BtnT.Text)
    End Sub

    Private Sub BtnU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnU.Click
        EditInput(BtnU.Text)
    End Sub

    Private Sub BtnV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnV.Click
        EditInput(BtnV.Text)
    End Sub

    Private Sub BtnW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnW.Click
        EditInput(BtnW.Text)
    End Sub
    Private Sub BtnX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnX.Click
        EditInput(BtnX.Text)
    End Sub


    Private Sub BtnY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnY.Click
        EditInput(BtnY.Text)
    End Sub

    Private Sub BtnZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZ.Click
        EditInput(BtnZ.Text)
    End Sub

    Private Sub BtnComma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComma.Click
        EditInput(BtnComma.Text)
    End Sub

    Private Sub btnPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriod.Click
        EditInput(btnPeriod.Text)
    End Sub

    Private Sub BtnBackSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBackSpace.Click
        EditInput(BtnBackSpace.Text)
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

    Private Sub BtnSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSpace.Click
        EditInput(BtnSpace.Text)
    End Sub

    Private Sub BtnCarToNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCarToNumber.Click
        tabVirtualKeyboradTab.SelectedIndex = 1
    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        EditInput(Btn0.Text)
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        EditInput(Btn1.Text)
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        EditInput(Btn2.Text)
    End Sub


    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        EditInput(Btn3.Text)
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        EditInput(Btn4.Text)
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        EditInput(Btn5.Text)
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        EditInput(Btn6.Text)
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        EditInput(Btn7.Text)
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        EditInput(Btn8.Text)
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        EditInput(Btn9.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        gsVirtualKeyboardData = txtInputText.Text
        Me.Close()
    End Sub

    Private Sub btn00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn00.Click
        EditInput(btn00.Text)
    End Sub

    Private Sub BtnUpLowCase_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnUpLowCase.MouseUp

        If BtnUpLowCase.BackColor = Color.Blue Then

            DisplayLowerCase("LOWER")

        Else
            BtnUpLowCase.BackColor = Color.Blue
            DisplayLowerCase("UPPER")

        End If
    End Sub


    Private Sub BtnNumToChar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNumToChar.Click
        tabVirtualKeyboradTab.SelectedIndex = 0
    End Sub

    Private Sub btnQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQ.Click
        EditInput(btnQ.Text)
    End Sub

    Private Sub BtnDot_Click(sender As System.Object, e As System.EventArgs) Handles BtnDot.Click
        EditInput(BtnDot.Text)
    End Sub

    Private Sub btnDash_Click(sender As System.Object, e As System.EventArgs) Handles btnDash.Click
        EditInput(btnDash.Text)
    End Sub

    Private Sub btnBackspace_Number_Click(sender As System.Object, e As System.EventArgs) Handles btnBackspace_Number.Click
        EditInput(BtnBackSpace.Text)
    End Sub

    Private Sub btnDelete_Number_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete_Number.Click
        EditInput(btnDelete_Number.Text)
    End Sub

    Private Sub btnOne_Click(sender As System.Object, e As System.EventArgs) Handles btnOne.Click
        EditInput(btnOne.Text)
    End Sub

    Private Sub btntwo_Click(sender As System.Object, e As System.EventArgs) Handles btntwo.Click
        EditInput(btntwo.Text)
    End Sub

    Private Sub btnThree_Click(sender As System.Object, e As System.EventArgs) Handles btnThree.Click
        EditInput(btnThree.Text)
    End Sub

    Private Sub btnFour_Click(sender As System.Object, e As System.EventArgs) Handles btnFour.Click
        EditInput(btnFour.Text)
    End Sub

    Private Sub btnFive_Click(sender As System.Object, e As System.EventArgs) Handles btnFive.Click
        EditInput(btnFive.Text)
    End Sub

    Private Sub btnSix_Click(sender As System.Object, e As System.EventArgs) Handles btnSix.Click
        EditInput(btnSix.Text)
    End Sub

    Private Sub btnSeven_Click(sender As System.Object, e As System.EventArgs) Handles btnSeven.Click
        EditInput(btnSeven.Text)
    End Sub

    Private Sub btnEight_Click(sender As System.Object, e As System.EventArgs) Handles btnEight.Click
        EditInput(btnEight.Text)
    End Sub

    Private Sub btnNine_Click(sender As System.Object, e As System.EventArgs) Handles btnNine.Click
        EditInput(btnNine.Text)
    End Sub

    Private Sub btnZero_Click(sender As System.Object, e As System.EventArgs) Handles btnZero.Click
        EditInput(btnZero.Text)
    End Sub

    Private Sub btnTash_1_Click(sender As System.Object, e As System.EventArgs) Handles btnTash_1.Click
        EditInput(btnTash_1.Text)
    End Sub

    Private Sub btnDash_2_Click(sender As System.Object, e As System.EventArgs) Handles btnDash_2.Click
        EditInput(btnDash_2.Text)
    End Sub

    Private Sub txtInputText_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtInputText.KeyUp
        If e.KeyCode = Keys.Enter Then BtnEnter.PerformClick()
    End Sub

End Class