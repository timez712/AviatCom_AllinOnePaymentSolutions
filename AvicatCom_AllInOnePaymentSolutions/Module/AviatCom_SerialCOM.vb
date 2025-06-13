Imports System.IO.Ports
Imports system.Threading

Public Class AviatCom_SerialCOM

    Implements IDisposable
    Public Event ISDirty(ByVal Status As Boolean, ByVal COMStatus As Boolean)
    Public Event MessageReceived(ByVal Message As String)
    Public Event MessageSended(ByVal Message As String)
    Public Event ReturnEndFile(ByVal Status As Boolean)
    Public Event ReturnProgressFile(ByVal Progress As Integer)
    Private mbFileProcessReset As Boolean
    Private ObjNumber As Integer
    Private mbInformationChanged As Boolean = False
    Private mbThreadOUT As Boolean = False

    Private m_serialPort As SerialPort
    Private m_continue As Boolean
    Private mreadThread As Thread
    'Private mRunThread As Thread
    Private msSorterName As String
    Private msConveyorID As String

    Private Enum Prefix_Suffix
        _NULL = 0
        _SOH = 1
        _STX = 2
        _ETX = 3
        _EOT = 4
        _ENQ = 5
        _ACK = 6
        _BEL = 7
        _BS = 8
        _HT = 9
        _LF = 10
        _VT = 11
        _FF = 12
        _CR = 13
        _SO = 14
        _SI = 15
        _DLE = 16
        _DC1 = 17
        _DC2 = 18
        _DC3 = 19
        _DC4 = 20
        _NAK = 21
        _SYN = 22
        _ETB = 23
        _CAN = 24
        _EM = 25
        _SUB = 26
        _ESC = 27
        _FS = 28
        _GS = 29
        _RS = 30
        _US = 31
    End Enum

    Private Structure strParammeters
        Dim sCOM_ID As String
        Dim sBitsrate As Integer
        Dim sDataBits As String
        Dim sParity As String
        Dim sStopBit As String
        Dim sFlowControl As String
        Dim bConnStatus As Boolean
        Dim nInterval As String
        Dim sFileNamePath As String
        Dim bStarted As Boolean
        Dim bReseted As Boolean
        Dim sMessageOut As String
        Dim sSuffix As String
        Dim sPrefix As String
        Dim sID As String
    End Structure
    Private strParam As New strParammeters

    Public Property Changed() As Boolean
        Get
            Return mbInformationChanged
        End Get
        Set(ByVal value As Boolean)
            mbInformationChanged = value
            If mbInformationChanged Then
                RaiseEvent ISDirty(True, Me.m_continue)
            Else
                RaiseEvent ISDirty(False, Me.m_continue)
            End If
        End Set
    End Property
    Public ReadOnly Property COM_Status()
        Get
            Return m_continue
        End Get
    End Property
    'Public Property ConveyorID() As String
    '    Get
    '        Return msConveyorID
    '    End Get
    '    Set(ByVal value As String)
    '        msConveyorID = value
    '    End Set
    'End Property
    'Public Property SName() As String
    '    Get
    '        Return msSorterName
    '    End Get
    '    Set(ByVal value As String)
    '        msSorterName = value
    '    End Set
    'End Property

    Public Property ID() As String
        Get
            Return strParam.sID
        End Get
        Set(ByVal value As String)
            strParam.sID = value
            Changed = True
        End Set
    End Property

    Public Property COM_ID() As String
        Get
            Return strParam.sCOM_ID
        End Get
        Set(ByVal value As String)
            strParam.sCOM_ID = value
            Changed = True
        End Set
    End Property
    Public Property COMBitsrate() As Integer
        Get
            Return strParam.sBitsrate
        End Get
        Set(ByVal value As Integer)
            strParam.sBitsrate = value
            Changed = True
        End Set
    End Property
    Public Property COMDataBits() As String
        Get
            Return strParam.sDataBits
        End Get
        Set(ByVal value As String)
            strParam.sDataBits = value
            Changed = True
        End Set
    End Property

    Public Property COMFlowControl() As String
        Get
            Return strParam.sFlowControl
        End Get
        Set(ByVal value As String)
            strParam.sFlowControl = value
            Changed = True
        End Set
    End Property
    Public Property COMParity() As String
        Get
            Return strParam.sParity
        End Get
        Set(ByVal value As String)
            strParam.sParity = value
            Changed = True
        End Set
    End Property
    Public Property COMStopBit() As String
        Get
            Return strParam.sStopBit
        End Get
        Set(ByVal value As String)
            strParam.sStopBit = value
            Changed = True
        End Set
    End Property
    Public Property Interval() As Integer
        Get
            Return strParam.nInterval
        End Get
        Set(ByVal value As Integer)
            strParam.nInterval = value
            'Changed = True
        End Set
    End Property
    Public Property ConnStatus() As Boolean
        Get
            Return strParam.bConnStatus
        End Get
        Set(ByVal value As Boolean)
            strParam.bConnStatus = value
            Changed = True
        End Set
    End Property

    Public Property COM_RunFile() As Boolean
        Get
            Return strParam.bStarted
        End Get
        Set(ByVal value As Boolean)
            If value And strParam.bReseted Then
                mbFileProcessReset = True
            End If
            strParam.bStarted = value
            'Changed = True
        End Set
    End Property
    Public Property COM_ResetFile() As Boolean
        Get
            Return strParam.bReseted
        End Get
        Set(ByVal value As Boolean)
            strParam.bReseted = value
            'Changed = True
        End Set
    End Property

    Public Property FileNamePath() As String
        Get
            Return strParam.sFileNamePath
        End Get
        Set(ByVal value As String)
            strParam.sFileNamePath = value
            'Changed = True
        End Set
    End Property
    Public Property MessageOut() As String
        Get
            Return strParam.sMessageOut
        End Get
        Set(ByVal value As String)
            strParam.sMessageOut = value
            Changed = True
        End Set
    End Property
    Public Property Message_Suffix() As String
        Get
            Return strParam.sSuffix
        End Get
        Set(ByVal value As String)
            strParam.sSuffix = GetPreSuffix(value)
            'Changed = True
        End Set
    End Property
    Public Property Message_Prefix() As String
        Get
            Return strParam.sPrefix
        End Get
        Set(ByVal value As String)
            strParam.sPrefix = GetPreSuffix(value)
            'Changed = True
        End Set
    End Property


    Public Function COM_Open() As Boolean
        Dim name As String = ""
        Dim message As String = ""
        Dim sComparer As StringComparer = StringComparer.OrdinalIgnoreCase
        mreadThread = New Thread(AddressOf Read)
        'mRunThread = New Thread(AddressOf ProcessFile)
        Try

            '' Create a new SerialPort object with default settings.
            m_serialPort = New SerialPort()

            ' Allow the user to set the appropriate properties.
            m_serialPort.PortName = strParam.sCOM_ID
            m_serialPort.BaudRate = strParam.sBitsrate
            m_serialPort.Parity = CType([Enum].Parse(GetType(Parity), strParam.sParity), Parity)
            m_serialPort.DataBits = strParam.sDataBits
            m_serialPort.StopBits = CType([Enum].Parse(GetType(StopBits), strParam.sStopBit), StopBits)
            m_serialPort.Handshake = CType([Enum].Parse(GetType(Handshake), strParam.sFlowControl), Handshake)

            ' Set the read/write timeouts
            m_serialPort.ReadTimeout = 500
            m_serialPort.WriteTimeout = 500

            Try
                m_serialPort.Open()
                m_continue = True
                Me.Changed = False
                mbThreadOUT = False
                mreadThread.Start()
                'Me.mRunThread.Start()
                Return True
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub COM_Close()
        Dim i As Integer = Math.Abs(Environment.TickCount)
        If m_continue Then
            m_continue = False
            Debug.WriteLine(strParam.sCOM_ID & " - " & "COM_Close")
            Do While Not mbThreadOUT
                If Math.Abs(Math.Abs(Environment.TickCount) - i) > 10000 Then
                    If mreadThread.IsAlive Then
                        mreadThread.Abort()
                    End If
                    mbThreadOUT = True
                    Exit Do
                End If
                Threading.Thread.Sleep(50)
                Debug.WriteLine(strParam.sCOM_ID & " - " & "COM_Close Do " & "50")
            Loop
            If mbThreadOUT Then
                mreadThread.Join()
                'Me.mRunThread.Join()
                'mreadThread.Abort()
                'Me.mRunThread.Abort()
                m_serialPort.Close()
                Changed = False
                Debug.WriteLine(strParam.sCOM_ID & " - " & "COM_Close OUT")
            End If
        End If
    End Sub
    Private Sub Read()
        Dim sMessage As String = ""
        Dim sTempMessage As String = ""
        While (m_continue)
            Try
                'Receive message
                Dim stemp As String = m_serialPort.ReadExisting()
                'Add new to old
                If Not stemp = "" Then
                    sTempMessage = sTempMessage + stemp
                    'm_serialPort.c()

                    If Me.strParam.sSuffix <> "" Then
                        While sTempMessage.IndexOf(strParam.sSuffix) > 0
                            'Find delimeter(SUFFIX)
                            Dim nPos As Integer = sTempMessage.IndexOf(strParam.sSuffix)
                            If nPos > 0 Then
                                'Get the message
                                sMessage = sTempMessage.Substring(0, nPos + 1)
                                If sTempMessage.Length > nPos + 1 Then
                                    'store partial new message
                                    sTempMessage = sTempMessage.Substring(nPos + 1)
                                Else
                                    sTempMessage = ""
                                End If
                            Else
                                sMessage = ""
                            End If
                            Debug.WriteLine(sMessage)
                            If sMessage <> "" Then
                                'trasfer the message
                                RaiseEvent MessageReceived(sMessage)
                                sMessage = ""
                                sTempMessage = ""
                                Debug.WriteLine(sMessage)
                            End If
                        End While
                    Else
                        sMessage = stemp.Trim
                        If sMessage <> "" Then
                            'trasfer the message
                            RaiseEvent MessageReceived(sMessage)
                            sMessage = ""
                            sTempMessage = ""
                            Debug.WriteLine(sMessage)
                        End If
                    End If

                End If
            Catch ex As TimeoutException
                ' Do nothing
            End Try
            Thread.Sleep(10)
        End While
        mbThreadOUT = True
    End Sub
    Public Sub COM_Write(ByVal Message As String)
        Try
            If m_continue Then

                m_serialPort.WriteLine(strParam.sPrefix & Message & strParam.sSuffix)
                RaiseEvent MessageSended(Message)
            End If

        Catch ex As TimeoutException
            ' Do nothing
        End Try
    End Sub

    Private Function GetPreSuffix(ByVal Message As String) As String

        Try
            Dim sPrefix_Suffix As New Prefix_Suffix
            Dim arrName As String() = [Enum].GetNames(GetType(Prefix_Suffix))
            Dim arrValue As Integer() = [Enum].GetValues(GetType(Prefix_Suffix))
            Dim sN As String = ""
            Dim sV As String = ""
            Dim n As Integer = 0
            For Each sN In arrName
                If "_" & Message = sN Then
                    sV = Chr(arrValue(n))
                    Exit For
                End If
                n += 1
            Next
            Return sV
        Catch ex As TimeoutException
            ' Do nothing
            Return ""
        End Try

    End Function

    '    Private Sub ProcessFile()
    '        Dim objADO As WHADO.ADO = Nothing
    '        Dim Cmd As New System.Data.SqlClient.SqlCommand
    '        Dim CmdAddHistory As New System.Data.SqlClient.SqlCommand
    '        Try
    '            Dim ADOConnection As New System.Data.SqlClient.SqlConnection
    '            If objADO Is Nothing Then
    '                objADO = New WHADO.ADO("W&H " & strParam.sCOM_ID)
    '                ADOConnection = objADO.InitialConnection(gsConnectionstring, True, False)
    '                If Not ADOConnection Is Nothing Then
    '                    Cmd = gobjADO.GetADOCommand("whspSorterGetTAG", ADOConnection)
    '                    CmdAddHistory = gobjADO.GetADOCommand("whspSorterSimulation_AddProductHistory", ADOConnection)
    '                End If
    '            End If

    '            While (m_continue)
    '                Dim sFile As String = ""
    '                Dim arrData As Array
    '                Dim n As Integer = 0
    '                Try
    '                    If Not strParam.sFileNamePath Is Nothing And strParam.bStarted Then
    '                        arrData =  ReadFileToArray(strParam.sFileNamePath)
    '                        If Not arrData Is Nothing Then

    '                            mbFileProcessReset = False
    '                            Dim sLine As String
    '                            RaiseEvent ReturnProgressFile(0)
    '                            Do While n <= arrData.GetLength(0) - 1
    '                                If strParam.bStarted Then
    '                                    If mbFileProcessReset Then
    '                                        Exit Do
    '                                    End If

    '                                    sLine = CType(arrData(n), String)
    '                                    Dim sRet As String = ""
    '                                    Dim sRet_QuipNumber As String = ""
    '                                    sRet = FormatFileLine(sLine, msSorterName, msConveyorID, _
    '                                    sRet_QuipNumber, strParam.sCOM_ID, strParam.sID, Cmd, CmdAddHistory)
    '                                    If sRet <> "" Then
    '                                        Me.COM_Write(sRet)
    '                                    End If

    '                                    RaiseEvent ReturnProgressFile(CType((n * 100) / (arrData.GetLength(0) - 1), Integer))
    '                                    n += 1
    '                                    Thread.Sleep(Me.strParam.nInterval)
    '                                Else
    '                                    Thread.Sleep(100)
    '                                End If

    '                                If Not strParam.bReseted And n = arrData.GetLength(0) - 1 Then
    '                                    n = 0
    '                                End If
    '                                If Not m_continue Then
    '                                    Debug.WriteLine(strParam.sCOM_ID & " - " & "ProcessFile OUT")
    '                                    GoTo exitThread
    '                                End If
    '                            Loop
    '                            If Not mbFileProcessReset Then
    '                                strParam.bStarted = False
    '                                RaiseEvent ReturnEndFile(True)
    '                            End If
    '                        End If
    '                    End If
    '                Catch ex As Exception

    '                     LogToSystemEvent("WHSerialCOM", "SerialClass", _
    '                    "PORT: " & Me.strParam.sCOM_ID & " ProcessFile: " & ex.ToString, "Error")

    '                End Try

    '                Thread.Sleep(10)
    'exitThread:
    '            End While
    '        Catch ex As Exception
    '        Finally
    '            If Not Cmd Is Nothing Then Cmd.Dispose()
    '            If Not CmdAddHistory Is Nothing Then CmdAddHistory.Dispose()
    '            If Not objADO Is Nothing Then objADO.Dispose()
    '            mbThreadOUT = True
    '            Debug.WriteLine(strParam.sCOM_ID & " - " & "ProcessFile Finally")
    '        End Try
    '    End Sub
    'Private Function FormatFileLine(ByVal FileLine As String, ByVal SorterName As String, _
    '                           ByVal ConveyorID As String, ByRef ReturnEquipNumber As String, _
    '                            ByVal Port As String, ByVal Scanner As String, _
    '                            Optional ByRef cmd As System.Data.SqlClient.SqlCommand = Nothing, _
    '                            Optional ByRef CmdAddHistory As System.Data.SqlClient.SqlCommand = Nothing) As String
    '    Dim sNewLine As String = ""
    '    Dim arrFileLine As String()
    '    Dim DSet As DataSet = Nothing

    '    Try
    '        arrFileLine = FileLine.Split(",")
    '        Dim stype As String = arrFileLine(0)
    '        'For n As Integer = 0 To arrFileLine.GetLength(0) - 1
    '        Select Case stype
    '            Case "1" 'Serial message
    '                If arrFileLine.GetLength(0) > 22 Then
    '                    ReturnEquipNumber = arrFileLine(1).ToString
    '                    sNewLine = Scanner & ";" & arrFileLine(3) & ";" & arrFileLine(5) & ";" & arrFileLine(6) & ";" & _
    '                    arrFileLine(7) & ";" & arrFileLine(8) & ";" & arrFileLine(9) & ";" & _
    '                    arrFileLine(10) & ";" & arrFileLine(11) & ";" & arrFileLine(12) & ";" & arrFileLine(13) & ";" & _
    '                    arrFileLine(14) & ";" & arrFileLine(15) & ";" & arrFileLine(18) & ";" & arrFileLine(19) & ";" & _
    '                    arrFileLine(20) & ";" & arrFileLine(21) & ";" & arrFileLine(22)

    '                    gobjADO.ExecuteSP(GetSorterParam(SorterName, FileLine, sNewLine, Scanner, Port), CmdAddHistory)
    '                    '@SorterName, @Carton, @CustomerNumber, @Route --Scanner, @ShippingDock	--PORT
    '                End If
    '            Case "5", "6" 'Status Changes
    '                If arrFileLine.GetLength(0) >= 3 Then
    '                    Dim nLane As Integer = CType(arrFileLine(1), Integer)
    '                    Dim nStatus As String = CType(arrFileLine(2), Integer)
    '                    Select Case nStatus
    '                        ''LaneFullStatus00100' --'LaneEnableDisable00100' 'LaneJamStatus00100'
    '                        Case 0 ' reset all (JAM, FULL, Enable)
    '                            'FULL IS OFF
    '                            DSet = gobjADO.GetResults(GetSorterParam(SorterName, "LaneFullStatus" & ConveyorID, nLane), cmd)
    '                            If DSet Is Nothing Then
    '                                MessageBox.Show("Error Getting Tag for " & SorterName & " LaneFullStatus" & ConveyorID, _
    '                                "FormatFileLine: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            End If
    '                            Debug.Print(nStatus & " LaneFullStatus - " & DSet.Tables.Count.ToString)
    '                            If DSet.Tables.Count > 0 Then
    '                                If DSet.Tables(0).Rows.Count > 0 Then
    '                                    WriteOneTagToPLC(SorterName, "0", "LaneFullStatus" & ConveyorID, DSet.Tables(0).Rows(0).Item(0))
    '                                End If
    '                            End If
    '                            'CJam is OFF
    '                            DSet = gobjADO.GetResults(GetSorterParam(SorterName, "LaneJamStatus" & ConveyorID, nLane), cmd)
    '                            If DSet Is Nothing Then
    '                                MessageBox.Show("Error Getting Tag for " & SorterName & " LaneJamStatus" & ConveyorID, _
    '                                "FormatFileLine: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            End If
    '                            Debug.Print(nStatus & " LaneJamStatus - " & DSet.Tables.Count.ToString)
    '                            If DSet.Tables.Count > 0 Then
    '                                If DSet.Tables(0).Rows.Count > 0 Then
    '                                    WriteOneTagToPLC(SorterName, "0", "LaneJamStatus" & ConveyorID, DSet.Tables(0).Rows(0).Item(0))
    '                                End If
    '                            End If
    '                            'Disable id OFF

    '                            DSet = gobjADO.GetResults(GetSorterParam(SorterName, "LaneEnableDisable" & ConveyorID, nLane), cmd)
    '                            If DSet Is Nothing Then
    '                                MessageBox.Show("Error Getting Tag for " & SorterName & " LaneEnableDisable" & ConveyorID, _
    '                                "FormatFileLine: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            End If
    '                            Debug.Print(nStatus & " LaneEnableDisable - " & DSet.Tables.Count.ToString)
    '                            If DSet.Tables.Count > 0 Then
    '                                If DSet.Tables(0).Rows.Count > 0 Then
    '                                    WriteOneTagToPLC(SorterName, "0", "LaneEnableDisable" & ConveyorID, DSet.Tables(0).Rows(0).Item(0))
    '                                End If
    '                            End If
    '                        Case 4 'Full is ON
    '                            DSet = gobjADO.GetResults(GetSorterParam(SorterName, "LaneFullStatus" & ConveyorID, nLane), cmd)
    '                            If DSet Is Nothing Then
    '                                MessageBox.Show("Error Getting Tag for " & SorterName & " LaneFullStatus" & ConveyorID, _
    '                                "FormatFileLine: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            End If
    '                            Debug.Print(nStatus & " LaneFullStatus - " & DSet.Tables.Count.ToString)
    '                            If DSet.Tables.Count > 0 Then
    '                                If DSet.Tables(0).Rows.Count > 0 Then
    '                                    WriteOneTagToPLC(SorterName, "1", "LaneFullStatus" & ConveyorID, DSet.Tables(0).Rows(0).Item(0))
    '                                End If
    '                            End If
    '                        Case 5 'Jam is ON
    '                            DSet = gobjADO.GetResults(GetSorterParam(SorterName, "LaneJamStatus" & ConveyorID, nLane), cmd)
    '                            If DSet Is Nothing Then
    '                                MessageBox.Show("Error Getting Tag for " & SorterName & " LaneJamStatus" & ConveyorID, _
    '                                "FormatFileLine: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            End If
    '                            Debug.Print(nStatus & " LaneJamStatus - " & DSet.Tables.Count.ToString)
    '                            If DSet.Tables.Count > 0 Then
    '                                If DSet.Tables(0).Rows.Count > 0 Then
    '                                    WriteOneTagToPLC(SorterName, "1", "LaneJamStatus" & ConveyorID, DSet.Tables(0).Rows(0).Item(0))
    '                                End If
    '                            End If
    '                        Case 6 'Disable id on
    '                            DSet = gobjADO.GetResults(GetSorterParam(SorterName, "LaneEnableDisable" & ConveyorID, nLane), cmd)
    '                            If DSet Is Nothing Then
    '                                MessageBox.Show("Error Getting Tag for " & SorterName & " LaneEnableDisable" & ConveyorID, _
    '                                "FormatFileLine: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            End If
    '                            Debug.Print(nStatus & " LaneEnableDisable - " & DSet.Tables.Count.ToString)
    '                            If DSet.Tables.Count > 0 Then
    '                                If DSet.Tables(0).Rows.Count > 0 Then
    '                                    WriteOneTagToPLC(SorterName, "0", "LaneEnableDisable" & ConveyorID, DSet.Tables(0).Rows(0).Item(0))
    '                                End If
    '                            End If

    '                    End Select
    '                    sNewLine = ""
    '                End If
    '            Case "6" 'Status Changes
    '            Case Else
    '                'Exit For
    '        End Select
    '        'Next
    '        If Not DSet Is Nothing Then
    '            DSet.Dispose()
    '        End If
    '        Return sNewLine
    '    Catch exp As Exception
    '        MessageBox.Show(exp.Message, " FormatFileLine Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        If Not gobjErrorLog Is Nothing Then
    '            gobjErrorLog.LogError(gsConnectionstring, gsApplicationClientID, exp.Message, exp.ToString, _
    '             StripCurrentDomain(System.AppDomain.CurrentDomain.ToString) & " " & "Global.FormatFileLine", Now)
    '        End If
    '         LogToSystemEvent("WHGUIClient", "GUIClient", _
    '        gsApplicationClientID & " " & "Global.FormatFileLine: " & exp.ToString, "Error")
    '        If Not DSet Is Nothing Then
    '            DSet.Dispose()
    '        End If
    '        Return ""
    '    End Try
    'End Function
#Region " IDisposable "
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        Dim i As Integer = Math.Abs(Environment.TickCount)
        If Not Me.disposedValue Then
            If disposing Then
                If Not m_serialPort Is Nothing Then
                    If m_serialPort.IsOpen Then
                        m_serialPort.Close()
                        m_serialPort.Dispose()
                        m_serialPort = Nothing
                    End If
                End If
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub


    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
