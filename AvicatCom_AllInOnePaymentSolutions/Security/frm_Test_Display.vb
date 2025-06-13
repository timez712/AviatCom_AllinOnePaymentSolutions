Imports System.IO.Ports
Public Class frm_Test_Display

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Using com1 As IO.Ports.SerialPort =
                My.Computer.Ports.OpenSerialPort("COM1")
            com1.WriteLine(Convert.ToString(Chr(8)))
        End Using

        'Using com1 As IO.Ports.SerialPort =
        '       My.Computer.Ports.OpenSerialPort("COM1")
        '    com1.WriteLine(Convert.ToString(Chr(12)))
        'End Using

    End Sub

    Private Sub frm_Test_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        btnClear.PerformClick()
        Using com1 As IO.Ports.SerialPort =
               My.Computer.Ports.OpenSerialPort("COM1")
            com1.WriteLine(Chr(27) & Chr(91))
        End Using
        ' Send strings to a serial port.
        Using com1 As IO.Ports.SerialPort =
                My.Computer.Ports.OpenSerialPort("COM1")
            com1.WriteLine(txtDisplay.Text)
        End Using
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Using com1 As IO.Ports.SerialPort =
               My.Computer.Ports.OpenSerialPort("COM1")
            com1.WriteLine(Convert.ToString(Chr(12)))
        End Using

        'Using com1 As IO.Ports.SerialPort =
        '    My.Computer.Ports.OpenSerialPort("COM1")
        '    'com1.WriteLine(Convert.ToString(Chr(27)) & " " & Convert.ToString(Chr(95)) & " " & 1)

        '    com1.WriteLine(Chr(27) + Chr(95) & Chr(1))
        'End Using

    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        'Using com1 As IO.Ports.SerialPort =
        '   My.Computer.Ports.OpenSerialPort("COM1")
        '    'com1.WriteLine(Convert.ToString(Chr(27)) & " " & Convert.ToString(Chr(95)) & " " & 1)

        '    com1.WriteLine(Chr(27) + Chr(64))
        'End Using
    End Sub

    Private Sub btnResetDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetDisplay.Click
        Using com1 As IO.Ports.SerialPort =
           My.Computer.Ports.OpenSerialPort("COM1")
            'com1.WriteLine(Convert.ToString(Chr(27)) & " " & Convert.ToString(Chr(95)) & " " & 1)

            com1.WriteLine(Chr(11))
        End Using
    End Sub

    Private Sub btnHomePosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomePosition.Click
        Using com1 As IO.Ports.SerialPort =
           My.Computer.Ports.OpenSerialPort("COM1")
            'com1.WriteLine(Convert.ToString(Chr(27)) & " " & Convert.ToString(Chr(95)) & " " & 1)

            com1.WriteLine(Chr(27) & Chr(95) & 1)
        End Using
    End Sub
End Class