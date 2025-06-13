Imports System.IO.Ports
Imports System.Threading
Public Class cls_SerialPort
    Private Shared sComPortName As String = "COM1"
    Friend Shared Property SetGetComportName As String
        Get
            Return sComPortName
        End Get
        Set(ByVal value As String)
            sComPortName = value
        End Set
    End Property
    ''' <summary>
    ''' Display MSG on POS Display Pole though Serial Port
    ''' </summary>
    ''' <param name="sDisplayMSG">Display MSG</param>
    ''' <param name="iLine">Display on specific line</param>
    ''' <remarks></remarks>
    Friend Shared Sub DisplayOnPole(ByVal sDisplayMSG As String, Optional ByVal iLine As Integer = 1)
        Try
            'Using com1 As IO.Ports.SerialPort =
            '   My.Computer.Ports.OpenSerialPort("COM1")
            '    com1.WriteLine(Chr(27) & Chr(91))
            'End Using
            ' Send strings to a serial port.
            Using com1 As IO.Ports.SerialPort =
                    My.Computer.Ports.OpenSerialPort(sComPortName)
                If Val(iLine) = 2 Then
                    com1.WriteLine(Chr(27) + Chr(64))
                Else
                    com1.WriteLine(Chr(27) & Chr(91))
                End If
                com1.WriteLine(sDisplayMSG)
            End Using
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Friend Shared Sub SetClearDisplay()
        Try
            Using com1 As IO.Ports.SerialPort =
              My.Computer.Ports.OpenSerialPort(sComPortName)
                com1.WriteLine(Convert.ToString(Chr(12)))
            End Using
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

End Class
