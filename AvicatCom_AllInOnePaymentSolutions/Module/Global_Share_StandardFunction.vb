Module Global_Share_StandardKeyMethod
    Public Sub Textbox_KeyPress_NumbersOnly(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        'Asc(e.KeyChar) <> 46 - Allow dot
        'And Asc(e.KeyChar) <> 45 - Allow negative

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub Textbox_KeyPress_NumbersWithDot(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        'Asc(e.KeyChar) <> 46 - Allow dot
        'And Asc(e.KeyChar) <> 45 - Allow negative

        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub Textbox_KeyPress_NumbersWithDotAndNegative(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        'Asc(e.KeyChar) <> 46 - Allow dot
        'And Asc(e.KeyChar) <> 45 - Allow negative

        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 45 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Module
