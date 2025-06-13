Imports System.Net.Mail
Imports System.Net
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data
Public Class cls_GlobalTables
    Implements IDisposable
    Private msModuleName As String = "Global_Security_Phoenix"
    Private Shared mdt_Products As DataTable = Nothing
    Private Shared mdtLastUpdate As Date = Now.Date
    Friend ReadOnly Property GetSetLastUpdate
        Get
            Return mdtLastUpdate
        End Get
    End Property
    Friend Function RefreshProductTable() As Boolean
        Try
            QueryProductTable()
            Return True
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msModuleName & ".log", "RefreshProductTable Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "RefreshProductTable Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Friend ReadOnly Property GetProductTable
        Get
            If mdt_Products Is Nothing Then QueryProductTable()
            Return mdt_Products
        End Get
    End Property
    Private Sub QueryProductTable()
        Try
            If Not mdt_Products Is Nothing Then
                mdt_Products.Dispose()
                mdt_Products = Nothing
            End If
            mdt_Products = SQL_GetAllTableData_New("tb_Product")
            mdtLastUpdate = Now.Date
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msModuleName & ".log", "QueryProductTable Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            MessageBox.Show(exp.StackTrace & vbNewLine & exp.Message, "QueryProductTable Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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
