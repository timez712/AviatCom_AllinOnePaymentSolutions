Imports System.Net.Mail
Imports System.Net
Imports AviatCom_Lib.AviatCom_Lib
Public Class cls_EMail
    Implements IDisposable
    Public Function SentEMail(ByVal SMTP As String, ByVal nSMTP_Port As Integer, ByVal sUserName As String, ByVal sPassword As String, ByVal sMailFrom As String, ByVal sMailTo As String, ByVal sCCto As String, ByVal sBCCto As String, ByVal sMailSubject As String, ByVal sMailBody As String, ByVal sMailPriority As String, ByVal sMailAttechmentLocation As String) As String
        Dim vParam As New ArrayList
        Dim tempMailPriority As MailPriority = MailPriority.Normal
        Dim AnEmailMessage As New MailMessage

        Dim sResult As String = Nothing
        Dim nPort As Integer = 0
        Try


            'SMTP.gmail.com
            'SMTP.mail.yahoo.com
            'SMTP.live.com
            'SMTP.isp.netscape.com

            If nSMTP_Port = 0 Then
                If SMTP.ToUpper.Contains("GMAIL") Then
                    nSMTP_Port = 587
                ElseIf SMTP.ToUpper.Contains("LIVE") Then
                    nSMTP_Port = 587
                ElseIf SMTP.ToUpper.Contains("YAHOO") Then
                    nSMTP_Port = 465
                ElseIf SMTP.ToUpper.Contains("NETSCAPE") Then
                    nSMTP_Port = 25
                Else
                    If gbDebugDisplayMSG Then MessageBox.Show("Error SentEMail")
                    LogToSystemEvent(gsApplicationClientID, "Global_Share", "SMTP Send port ", "Error")
                    Return Nothing
                End If

                nPort = nSMTP_Port
            End If

            Select Case sMailPriority.ToUpper
                Case "HIGH"
                    tempMailPriority = MailPriority.High
                Case "LOW"
                    tempMailPriority = MailPriority.Low
            End Select

            AnEmailMessage.To.Add(sMailTo)
            If sCCto.Contains("@") Then AnEmailMessage.CC.Add(sCCto)
            If sBCCto.Contains("@") Then AnEmailMessage.Bcc.Add(sBCCto)
            AnEmailMessage.From = New MailAddress(sMailFrom)
            AnEmailMessage.Subject = (sMailSubject)
            AnEmailMessage.Body = (sMailBody)
            AnEmailMessage.Priority = tempMailPriority 'sMailPriority



            If Not sMailAttechmentLocation.Trim = "" Then
                'Dim temFilePath As String = sMailSubject & Now.Year.ToString & Now.Month.ToString & Now.ToString("HH:MM:SS") & ""
                'Dim temResult As String = ExportReportToLocal("", "", "", "", "")
                If LocalFileExist(sMailAttechmentLocation) Then
                    Dim attachment As New Mail.Attachment(sMailAttechmentLocation) 'create the attachment
                    AnEmailMessage.Attachments.Add(attachment)
                Else
                    MessageBox.Show("The file not found!", "File Not Found", MessageBoxButtons.OK)
                    'If gbDebugDisplayMSG Then MessageBox.Show("Error SentEMail")
                    'LogToSystemEvent(gsApplicationClientID, "Global_Share", "SentEMail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
                End If
            End If
            'Dim SimpleSMTP As New SmtpClient("smtp.gmail.com")
            Dim SimpleSMTP As New SmtpClient(SMTP)
            With SimpleSMTP

                .Port = nPort
                .EnableSsl = True
                .DeliveryMethod = SmtpDeliveryMethod.Network
                '.Credentials = New NetworkCredential("ninglu1962", "teddylu")
                .Credentials = New NetworkCredential(sUserName, sPassword)

                .Send(AnEmailMessage)
            End With
            sResult = "You E-Mail had been successfully sent!"
            Return sResult

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error SentEMail")
            LogToSystemEvent(gsApplicationClientID, "Global_Share", "SentEMail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")

            Return Nothing
        Finally
            If Not AnEmailMessage Is Nothing Then AnEmailMessage.Dispose()
        End Try
    End Function
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub
#End Region
    'DISPOSE CODE============DISPOSE CODE============DISPOSE CODE============DISPOSE CODE============DISPOSE CODE============
    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' Pointer to an external unmanaged resource.
    Private handle As IntPtr = Me.handle

    ' Use interop to call the method necessary  
    ' to clean up the unmanaged resource.
    <System.Runtime.InteropServices.DllImport("Kernel32")> _
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As [Boolean]
    End Function

    ' This finalizer will run only if the Dispose method 
    ' does not get called.
    ' It gives your base class the opportunity to finalize.
    ' Do not provide finalize methods in types derived from this class.
    Protected Overrides Sub Finalize()
        ' Do not re-create Dispose clean-up code here.
        ' Calling Dispose(false) is optimal in terms of
        ' readability and maintainability.
        Dispose(False)
        MyBase.Finalize()
    End Sub


    ' IDisposable
    ' Dispose(bool disposing) executes in two distinct scenarios.
    ' If disposing equals true, the method has been called directly
    ' or indirectly by a user's code. Managed and unmanaged resources
    ' can be disposed.
    ' If disposing equals false, the method has been called by the 
    ' runtime from inside the finalizer and you should not reference 
    ' other objects. Only unmanaged resources can be disposed
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        Dim ExitCount As Integer = 0
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free managed resources when explicitly called
                'check OPC channels status to disconnect

                Dim arrlog As ArrayList = New ArrayList


            End If
            ' TODO: free shared unmanaged resources
            ' Call the appropriate methods to clean up 
            ' unmanaged resources here.
            ' If disposing is false, 
            ' only the following code is executed.
            CloseHandle(handle)
            handle = IntPtr.Zero
        End If
        Me.disposedValue = True
    End Sub
End Class
