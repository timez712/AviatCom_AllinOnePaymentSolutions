Imports System.Data
Imports System.Security.Cryptography
Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Public NotInheritable Class cls_Security
    Implements IDisposable

    Private TripleDes As New TripleDESCryptoServiceProvider
    'Private msKey As String = "YJ$Aviat#Com2012"
    Private msKey As String = "YJ$Aviat#Com2012"

    Friend Structure StrUserInformation
        Friend FirstName As String
        Friend LastName As String
        Friend UserName As String
        Friend Password As String
        Friend Profile As String
        Friend UserRole As String
        Friend EmployeeDepartment As String
        Friend ComputerName As String
        Friend htAccessRights As Hashtable
        Friend htAccessCodes As Hashtable
        Friend tbAccessRights As DataTable
    End Structure
    Friend gObjEmployeeInformation As New StrUserInformation


    ''' <summary>
    ''' method that creates a byte array of a specified length from the hash of the specified key.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider
        ' Hash the key. 
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)
        ' Truncate or pad the hash. 
        ReDim Preserve hash(length - 1)
        Return hash
    End Function
    ''' <summary>
    ''' The key parameter controls the EncryptData and DecryptData methods.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(msKey, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub
    ''' <summary>
    ''' Friend method that encrypts a string.
    ''' </summary>
    ''' <param name="plaintext"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function EncryptData(ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array. 
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream. 
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream. 
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string. 
        Return Convert.ToBase64String(ms.ToArray)
    End Function
    ''' <summary>
    ''' Friend method that decrypts a string.
    ''' </summary>
    ''' <param name="encryptedtext"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function DecryptData(ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array. 
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream. 
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream. 
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string. 
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    Sub TestEncoding()
        Dim plainText As String = InputBox("Enter the plain text:")
        'Dim password As String = InputBox("Enter the password:")

        Dim wrapper As New cls_Security()
        Dim cipherText As String = wrapper.EncryptData(plainText)

        MsgBox("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
            "\cipherText.txt", cipherText, False)
    End Sub

    Sub TestDecoding()
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
                "\cipherText.txt")
        'Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New cls_Security()

        ' DecryptData throws if the wrong password is used. 
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub
    Friend Function GetUserSecurityAccessRight(ByVal iEmployeeID As Integer) As Data.DataTable
        Try
            Dim sSQLStr As String = " SELECT AppPermID,AppPermName FROM LDAppPerm WITH (NOLOCK) WHERE (AppPermID  IN  "
            sSQLStr = sSQLStr & " (SELECT DISTINCT rp.AppPermID FROM LDAppEmpRole er WITH (NOLOCK) INNER JOIN LDAppRolePerm rp WITH (NOLOCK)  ON er.AppRoleID = rp.AppRoleID WHERE er.EmployeeID = " & iEmployeeID & " )  "
            sSQLStr = sSQLStr & " OR AppPermID  IN "
            sSQLStr = sSQLStr & " ( SELECT AppPermID FROM LDAppEmpPerm WITH (NOLOCK)   WHERE Inclusive <> 0 AND  EmployeeID = " & iEmployeeID & " ) )  "
            sSQLStr = sSQLStr & " AND AppPermID  NOT IN "
            sSQLStr = sSQLStr & " ( SELECT AppPermID FROM LDAppEmpPerm WITH (NOLOCK)   WHERE Inclusive = 0 AND EmployeeID =  " & iEmployeeID & " )  "

            Return SQL_QueryGetTableResult(sSQLStr)

        Catch exp As Exception
            LogToFile(msModuleName & ".log", "GetUserSecurity Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "GetUserSecurity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Friend Function CheckAccessRight(ByVal sAppPermName As String) As Boolean
        Try
            Dim dRow As Data.DataRow() = gObjEmployeeInformation.tbAccessRights.Select("AppPermName = '" & sAppPermName & "'")
            If dRow Is Nothing Then Return False
            If dRow.Count <= 0 Then Return False
            Return True
        Catch exp As Exception
            LogToFile(msModuleName & ".log", "CheckAccessRight Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "CheckAccessRight Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Sub Dispose(ByVal disposing As Boolean)
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
