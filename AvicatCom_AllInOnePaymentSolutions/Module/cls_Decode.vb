Imports AviatCom_Lib.AviatCom_Lib
Public Class cls_Decode
    Implements IDisposable
    Friend msClassName As String = "Global_Share"
    Friend objDriverLicenseInformation As New cls_DriverLicenseInformation
    Friend Function GetDriverLicenseInformation(ByVal sBarcode As String) As cls_DriverLicenseInformation
        Dim sFullName As String = ""
        Dim arrData As Array = sBarcode.Split(vbNewLine)
        Dim iDriverLicenseLength As Integer = Len(sBarcode)
        ' 346 - New Driver License



        Try
           
            Select Case iDriverLicenseLength
                Case 346    'New Driver License
                    objDriverLicenseInformation.LastName = sBarcode.Substring(83, 25).Trim
                    objDriverLicenseInformation.FirstName = sBarcode.Substring(111, 25).Trim
                    objDriverLicenseInformation.IDNumber = sBarcode.Substring(250, 9).Trim
                    objDriverLicenseInformation.Address = sBarcode.Substring(180, 25).Trim
                    objDriverLicenseInformation.City = sBarcode.Substring(208, 20).Trim
                    objDriverLicenseInformation.State = sBarcode.Substring(231, 2)
                    objDriverLicenseInformation.Zipcode = sBarcode.Substring(236, 5).Trim
                    objDriverLicenseInformation.DateOfBirth = sBarcode.Substring(150, 8)
                    objDriverLicenseInformation.dtDateOfBirth = sBarcode.Substring(150, 2) & "/" & sBarcode.Substring(152, 2) & "/" & sBarcode.Substring(154, 4)
                    objDriverLicenseInformation.ExpirationDate = sBarcode.Substring(72, 8)
                    objDriverLicenseInformation.dtExpirationDate = sBarcode.Substring(72, 2) & "/" & sBarcode.Substring(74, 2) & "/" & sBarcode.Substring(76, 4)
                Case 303   '2008 Driver License
                    objDriverLicenseInformation.LastName = sBarcode.Substring(83, 25).Trim
                    objDriverLicenseInformation.FirstName = sBarcode.Substring(111, 25).Trim
                    objDriverLicenseInformation.IDNumber = sBarcode.Substring(250, 9).Trim
                    objDriverLicenseInformation.Address = sBarcode.Substring(180, 25).Trim
                    objDriverLicenseInformation.City = sBarcode.Substring(208, 20).Trim
                    objDriverLicenseInformation.State = sBarcode.Substring(231, 2)
                    objDriverLicenseInformation.Zipcode = sBarcode.Substring(236, 5).Trim
                    objDriverLicenseInformation.DateOfBirth = sBarcode.Substring(150, 8)
                    objDriverLicenseInformation.dtDateOfBirth = sBarcode.Substring(150, 2) & "/" & sBarcode.Substring(152, 2) & "/" & sBarcode.Substring(154, 4)
                    objDriverLicenseInformation.ExpirationDate = sBarcode.Substring(72, 8)
                    objDriverLicenseInformation.dtExpirationDate = sBarcode.Substring(72, 2) & "/" & sBarcode.Substring(74, 2) & "/" & sBarcode.Substring(76, 4)
                Case 255    'Before 2000 Driver License
                    sFullName = sBarcode.Substring(29, 35)
                    Dim arrFullName As Array = sFullName.Split("@")
                    For j As Integer = 0 To arrFullName.Length - 1
                        If j = 0 Then
                            objDriverLicenseInformation.LastName = arrFullName(j).ToString.Trim
                        ElseIf j = 1 Then
                            objDriverLicenseInformation.FirstName = arrFullName(j).ToString.Trim
                        Else
                            objDriverLicenseInformation.FirstName = objDriverLicenseInformation.FirstName & ", " & arrFullName(j).ToString.Trim
                        End If
                    Next


                    objDriverLicenseInformation.IDNumber = sBarcode.Substring(127, 25).Trim
                    objDriverLicenseInformation.Address = sBarcode.Substring(67, 20).Trim
                    objDriverLicenseInformation.City = sBarcode.Substring(90, 15).Trim
                    objDriverLicenseInformation.State = sBarcode.Substring(108, 2).Trim
                    objDriverLicenseInformation.Zipcode = sBarcode.Substring(113, 5).Trim
                    objDriverLicenseInformation.DateOfBirth = sBarcode.Substring(159, 2) & sBarcode.Substring(161, 2) & sBarcode.Substring(155, 4).Trim
                    objDriverLicenseInformation.dtDateOfBirth = sBarcode.Substring(159, 2) & "/" & sBarcode.Substring(161, 2) & "/" & sBarcode.Substring(155, 4)
                    objDriverLicenseInformation.ExpirationDate = sBarcode.Substring(181, 2) & sBarcode.Substring(183, 2) & sBarcode.Substring(177, 4)
                    objDriverLicenseInformation.dtExpirationDate = sBarcode.Substring(181, 2) & "/" & sBarcode.Substring(183, 2) & "/" & sBarcode.Substring(177, 4)

            End Select
            objDriverLicenseInformation.StateLicense = objDriverLicenseInformation.State & " License"
            Return objDriverLicenseInformation
        Catch exp As Exception
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "ScannedBarcode Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogToFile(msClassName & ".log", "ScannedBarcode Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            Return objDriverLicenseInformation
        End Try
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

Friend Class cls_DriverLicenseInformation
    Friend IDNumber As String = ""
    Friend FirstName As String = ""
    Friend LastName As String = ""
    Friend DateOfBirth As String = ""
    Friend dtDateOfBirth As Date = "01/01/1900"
    Friend Address As String = ""
    Friend City As String = ""
    Friend State As String = ""
    Friend Zipcode As String = ""
    Friend ExpirationDate As String = ""
    Friend dtExpirationDate As Date = "01/01/1900"
    Friend isAgeOf21 As Boolean = False
    Friend StateLicense As String = "License"
End Class
