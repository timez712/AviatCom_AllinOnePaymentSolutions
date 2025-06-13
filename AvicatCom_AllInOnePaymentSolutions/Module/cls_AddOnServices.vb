Imports System
Imports System.Data

Friend Class AddOnServices
    Private iID_Index As Integer = 0
    Private sServiceID As String = ""
    Private sServiceName As String = ""
    Private dPrice As Double = 0.0

    ''' <summary>
    ''' Get or Set table ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Index As Integer
        Get
            Return iID_Index
        End Get
        Set(value As Integer)
            iID_Index = value
        End Set
    End Property
    ''' <summary>
    ''' Get or Set Service ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property ServiceID As Integer
        Get
            Return sServiceID
        End Get
        Set(value As Integer)
            sServiceID = value
        End Set
    End Property
    ''' <summary>
    ''' Get or Set Service Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property ServiceName As Integer
        Get
            Return sServiceName
        End Get
        Set(value As Integer)
            sServiceName = value
        End Set
    End Property
    ''' <summary>
    ''' Get or Set Service Price
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Price As Integer
        Get
            Return dPrice
        End Get
        Set(value As Integer)
            dPrice = value
        End Set
    End Property
End Class

