Imports System.Data
Imports C1.Win.C1TrueDBGrid
Imports System.Windows.Forms
Imports C1.C1Preview
Imports C1.Win.C1Report
Friend Class AviatCom_DefaultGrid
    Inherits C1TrueDBGrid
    Private msClassName = "DefaultGrid"
    Private mDefaultLayout As C1TrueDBGrid
    Private miColumnRedRowStyle As Integer
    Private miColumnYellowRowStyle As Integer
    Private miColumnGreyRowStyle As Integer

    Private miGridWidth As Integer = 5
    ''' <summary>
    ''' Transfer Current data count in the grid and Total Data received from dataset
    ''' </summary>
    ''' <param name="DisplayRecords"></param>
    ''' <param name="TotalRecords"></param>
    ''' <remarks></remarks>
    Public Event AC_Rows(ByVal DisplayRecords As Integer, ByVal TotalRecords As Integer)
    Private mnSplitsCount As Integer = 1
    Private mnSplitsParam As ArrayList = Nothing
    Private mGridColColl() As C1DisplayColumnCollection
    Private mfrmGUI As Form
    Private mSQLDataTable As DataTable, mSQLTempdt As New DataTable
    Private mSQLDataSet As DataSet, mSQLTempDS As New DataSet
    Private marrTableColWidth As Array
    Private marrTableColFormat As Array
    Private marrListCombobox As New ArrayList
    Private marrListTranslate As New ArrayList
    Private marrListButton As New ArrayList
    Private marrListCheckBox As New ArrayList
    Private mnRows As Integer
    Private mnCurrentRows As Integer
    Private mbColumnWidthMultipler_Disable As Boolean
    Private mnTotalWidth As Integer
    Private mbAtemptToChoose As Boolean
    Private mnCol As Integer
    Private mbISGridLoaded As Boolean
    Private mbscroll As Boolean = False
    Private mnscrollCount As Integer
    Private mnscrollfETCHCount As Integer
    Private mnFirstTimeRecordsShow As Integer = 3000
    Private mnNextRecordsToAdd As Integer = 1000
    Private mnLeftoverRows As Integer = 300
    Private mbBookmarkTopRowOnScroll As Boolean = False
    Private mnSortCount As Integer = 0

    Private mbGridInserting As Boolean = False

    Private mbGridDisplayFormatLoad As Boolean = False
    Private mbCopyHiddenFields As Boolean = False
    Private mbGridFilterFocused As Boolean = False

    '$$$$$$ Display different color when data changed
    Private mMatchedCellColor As Color = Color.LightYellow
    Private mlisEditedCells As New List(Of Point)

    Private marrFilterText As New ArrayList
    Private miFirstRow As Integer = 0
    Private miBookmark As Integer = 0
    Private msMyKey As String = ""
    Friend Property isInserting As Boolean
        Get
            Return mbGridInserting
        End Get
        Set(ByVal value As Boolean)
            mbGridInserting = value
        End Set
    End Property

    Friend Property GetSetCopyHiddenFields As Boolean
        Get
            Return mbCopyHiddenFields
        End Get
        Set(ByVal value As Boolean)
            mbCopyHiddenFields = value
        End Set
    End Property
    Friend ReadOnly Property CheckFilterFocused As Boolean
        Get
            Return mbGridFilterFocused
        End Get

    End Property

    Friend Property GetSetGridDisplayFormatLoad As Boolean
        Get
            Return mbGridDisplayFormatLoad
        End Get
        Set(ByVal value As Boolean)
            mbGridDisplayFormatLoad = value
        End Set
    End Property
    Private Sub AC_LoadAllData(ByRef SourceTable As DataTable, ByVal NewData As DataTable)
        Try
            Dim lStart As Integer = Environment.TickCount
            For R As Integer = SourceTable.Rows.Count To SourceTable.Rows.Count - 1 + mnNextRecordsToAdd
                '    'Me.Row = R
                If NewData.Rows.Count <= R Then
                    Exit For
                End If

                If SourceTable.Rows.Count < R + 1 Then
                    Dim dr As DataRow = SourceTable.NewRow
                    SourceTable.Rows.InsertAt(dr, SourceTable.Rows.Count) '.Add(dr)
                End If

                For c As Integer = 0 To NewData.Columns.Count - 1
                    SourceTable.Rows(R).Item(c) = NewData.Rows(R).Item(c)
                Next
                mnCurrentRows = mnCurrentRows + 1
            Next
            RaiseEvent AC_Rows(mnCurrentRows, mnRows)

        Catch exp As Exception
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".AC_LoadAllData: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_LoadAllData Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Public Overridable Property AC_GetSetGridWidth() As Integer
        Get
            Return miGridWidth
        End Get
        Set(ByVal Value As Integer)
            miGridWidth = Value
        End Set
    End Property

    ''' <summary>
    ''' Get or Set the flag to move bookmark to the top row when scroll(example: LaneStats timer driven refresh)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AC_BookmarkTopRowOnScroll() As Boolean
        Get
            Return mbBookmarkTopRowOnScroll
        End Get
        Set(ByVal Value As Boolean)
            mbBookmarkTopRowOnScroll = Value
        End Set
    End Property
    ''' <summary>
    ''' Get or Set How many max rows load to grid first time.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AC_RowsLoadFirst() As Integer
        Get
            Return mnFirstTimeRecordsShow
        End Get
        Set(ByVal Value As Integer)
            mnFirstTimeRecordsShow = Value
        End Set
    End Property
    ''' <summary>
    ''' Get or Set How many rows add to view when scroll or move down through the records.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AC_RowsLoadNext() As Integer
        Get
            Return mnNextRecordsToAdd
        End Get
        Set(ByVal Value As Integer)
            mnNextRecordsToAdd = Value
        End Set
    End Property
    ''' <summary>
    ''' Get or Set How many rows leave at the bottom of the grid before trigger to get a next set.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AC_RowsToBottom() As Integer
        Get
            Return mnLeftoverRows
        End Get
        Set(ByVal Value As Integer)
            mnLeftoverRows = Value
        End Set
    End Property

    ''' <summary>
    ''' Set or Get Load format status. (Set FALSE and call AC_RefreshGrid if need to reload grid HEADER with out to unload grid)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AC_RenewFormat() As Boolean
        Get
            Return mbISGridLoaded
        End Get
        Set(ByVal Value As Boolean)
            mbISGridLoaded = Value
        End Set
    End Property

    ''' <summary>
    ''' Set or Get Grid filter status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AC_AllowFilter() As Boolean
        Get
            Return Me.AllowFilter
        End Get
        Set(ByVal Value As Boolean)
            Me.AllowFilter = Value
            Me.FilterBar = Value
            Me.FilterBarStyle.BackColor = System.Drawing.Color.LightSkyBlue
        End Set
    End Property
    Public Overridable Property AC_GetSetCustomFilter() As Integer
        Get
            Return Me.FilterBar
        End Get
        Set(ByVal Value As Integer)
            Me.FilterBar = Value
        End Set
    End Property
    ''' <summary>
    ''' Set new grid
    ''' </summary>
    ''' <param name="GridLayout">Set form default grid control </param>
    ''' <param name="DataSet">Optional: Set Dataset with data to format grid</param>
    ''' <param name="nSplits">Optional: number of Splits</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef GridLayout As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
    Optional ByVal DataSet As DataSet = Nothing, Optional ByVal nSplits As Integer = 0)
        Try
            mDefaultLayout = GridLayout
            mSQLDataSet = DataSet
            AC_SplitsCount = nSplits
            AC_SetGridDefaultValues()
            mDefaultLayout.Dispose()
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "Public New Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".Public New: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Set new grid
    ''' </summary>
    ''' <param name="GridLayout">Set form default grid control</param>
    ''' <param name="ColumnYellowRowStyle">Column number that will have data (0 or 1) to fetch YELLOW color</param>
    ''' <param name="ColumnRedRowStyle">Column number that will have data (0 or 1) to fetch RED color</param>
    ''' <param name="ColumnGreyRowStyle">Column number that will have data (0 or 1) to fetch GREY color</param>
    ''' <param name="DataSet">Optional: Set Dataset with data to format grid</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef GridLayout As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColumnYellowRowStyle As Integer, _
                ByVal ColumnRedRowStyle As Integer, ByVal ColumnGreyRowStyle As Integer, Optional ByVal DataSet As DataSet = Nothing)
        Try
            mDefaultLayout = GridLayout
            miColumnYellowRowStyle = ColumnYellowRowStyle
            miColumnRedRowStyle = ColumnRedRowStyle
            miColumnGreyRowStyle = ColumnGreyRowStyle
            mSQLDataSet = DataSet
            AC_SetGridDefaultValues()

            mDefaultLayout.Dispose()
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "Public New Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".New Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub AC_SetGridDefaultValues()
        'Setup some default grid properties 
        Try
            If Me.Columns.Count = 0 And Not mDefaultLayout Is Nothing Then
                With mDefaultLayout
                    'AI
                    Me.AC_AllowFilter = False
                    Me.ScrollTips = True
                    Me.ScrollTrack = True
                    Me.AllowAddNew = .AllowAddNew
                    Me.AllowDelete = .AllowDelete
                    Me.AllowUpdate = .AllowUpdate
                    Me.AllowSort = .AllowSort

                    Me.RowHeight = .RowHeight
                    Me.CaptionHeight = .CaptionHeight
                    Me.HeadingStyle.HorizontalAlignment = .HeadingStyle.HorizontalAlignment
                    Me.HeadingStyle.VerticalAlignment = .HeadingStyle.VerticalAlignment
                    Me.Top = .Top
                    'calculate 
                    Me.Height = Math.Ceiling(.Height / .RowHeight) * .RowHeight
                    Me.Left = .Left
                    Me.Width = .Width
                    Me.AllowHorizontalSplit = .AllowHorizontalSplit
                    Me.AllowVerticalSplit = .AllowVerticalSplit
                    Me.AC_SplitsCount = .Splits.Count
                    ReDim mGridColColl(Me.AC_SplitsCount - 1)
                    Dim i As Integer
                    For i = 0 To Me.AC_SplitsCount - 1
                        If i > 0 And Me.AllowVerticalSplit Then Me.InsertVerticalSplit(i)
                        If Me.AllowVerticalSplit Then Me.Splits(i).VScrollBar.Width = Me.RowHeight

                        If i > 0 And Me.AllowHorizontalSplit Then Me.InsertHorizontalSplit(i)
                        If Me.AllowHorizontalSplit Then Me.Splits(i).HScrollBar.Height = Me.RowHeight

                        Me.Splits(i).ColumnCaptionHeight = .Splits(i).ColumnCaptionHeight
                        Me.Splits(i).FetchRowStyles = .Splits(i).FetchRowStyles
                        Me.Splits(i).ExtendRightColumn = True
                        mGridColColl(i) = Me.Splits(i).DisplayColumns
                    Next i
                    Me.Parent = .Parent
                    Me.BringToFront()
                End With

                If mSQLDataSet Is Nothing Then
                    FormatDefaultGrid()
                End If
            End If
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_SetGridDefaultValues Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".SetGridDefaultValue Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub FormatDefaultGrid()
        Dim DS As New DataSet
        Dim DC As New DataColumn
        Dim DCWidth As DataColumn
        Dim i As Integer
        Dim j As Integer
        Dim DT As New DataTable
        Dim DTWidth As New DataTable
        Try
            For j = 0 To Me.AC_SplitsCount - 1


                For i = 0 To mDefaultLayout.Columns.Count - 1
                    mDefaultLayout.Splits(j).DisplayColumns(i).Visible = True
                    DC = New DataColumn
                    DC.ColumnName = mDefaultLayout.Splits(j).DisplayColumns.Item(i).Name

                    DCWidth = New DataColumn
                    DCWidth.Caption = IIf(i = 0, "Width", i)
                    DT.Columns.Add(DC)
                    DTWidth.Columns.Add(DCWidth)
                Next i

                DS.Tables.Add(DTWidth)
                DS.Tables.Add(DT)
            Next j
            mSQLDataSet = DS
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "FormatDefaultGrid Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".FormatDefaultGrid Error: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        Finally
            If Not DT Is Nothing Then
                DT.Dispose()
                DT = Nothing
            End If

            If Not DTWidth Is Nothing Then
                DTWidth.Dispose()
                DTWidth = Nothing
            End If

        End Try
    End Sub

    Private Sub FormatUnbound(ByVal dt As DataTable)
        Try
            Me.ClearFields()

            For c As Integer = 0 To dt.Columns.Count - 1
                Me.Columns.Add(New C1.Win.C1TrueDBGrid.C1DataColumn(dt.Columns(c).Caption, GetType(String)))
                Me.SetDataBinding()
                Me.Splits(0).DisplayColumns(c).Visible = True
            Next

            SetColumns()

            For R As Integer = 0 To dt.Rows.Count - 1
                Dim Data As String = ""
                For c As Integer = 0 To dt.Columns.Count - 1

                    Data = Data & dt.Rows(R).Item(c)
                    If c < dt.Columns.Count - 1 Then
                        Data = Data & ";"
                    End If
                Next
                Me.AddRow(Data)
            Next

        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "FormatUnbound Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".FormatUnbound Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub SplitConfig(ByVal NumberSplits As Integer, ByVal SplitsCollumArray As ArrayList)
        Try
            Me.InsertHorizontalSplit(NumberSplits - 1)
            Me.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact

            For nColSplit As Integer = 0 To SplitsCollumArray.Count - 1
                Dim vArr As Array = SplitsCollumArray(nColSplit)
                Dim nFound As Integer = 0
                For nCol As Integer = 0 To Me.Splits(nColSplit).DisplayColumns.Count - 1
                    For nVisCol As Integer = 0 To vArr.GetLength(0) - 1
                        If nFound < vArr.GetLength(0) Then
                            If vArr(nVisCol) <> nCol Then
                                Me.Splits(nColSplit).DisplayColumns.Item(nCol).Visible = False
                            Else
                                If marrTableColFormat.GetValue(nCol).ToString.IndexOf("@") >= 0 Then

                                Else
                                    Me.Splits(nColSplit).DisplayColumns.Item(nCol).Visible = True
                                    If nColSplit = 0 And Me.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact Then
                                        Me.Splits(nColSplit).SplitSize = Me.Splits(nColSplit).SplitSize + Me.Splits(nColSplit).DisplayColumns.Item(nCol).Width + 20
                                    End If
                                    nFound += 1
                                End If



                                Exit For
                            End If
                        Else
                            Me.Splits(nColSplit).DisplayColumns.Item(nCol).Visible = False
                        End If
                    Next
                Next
            Next

        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "SplitConfig Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".SplitConfig Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub SetColumns()
        Dim n, i As Integer
        Dim ColumnsNumber As Integer
        Dim nTotalWidth As Integer = 0
        Dim sngMultiplier As Single = 0

        'This Porcedure resize colunms
        'and uses mGridColColl(0) for split 0 asumming all other splits will have a same structure
        Try
            If Not marrTableColWidth Is Nothing Then
                'Resize collumns in the grid
                ColumnsNumber = IIf(Me.Columns.Count - 1 >= marrTableColWidth.GetLength(0) - 1, _
                                    marrTableColWidth.GetLength(0) - 1, _
                                   Me.Columns.Count - 1)

                For i = 0 To ColumnsNumber
                    nTotalWidth = nTotalWidth + CType(marrTableColWidth.GetValue(i), Integer) * 10
                Next
                If mbColumnWidthMultipler_Disable Then
                    sngMultiplier = 1
                Else
                    If nTotalWidth > Me.Width And nTotalWidth <> 0 Then
                        sngMultiplier = (Me.Width - 70) / nTotalWidth
                    Else
                        sngMultiplier = 1
                    End If
                End If
                nTotalWidth = 0
                For nSplit As Integer = 0 To mGridColColl.GetLength(0) - 1
                    Dim nStart As Integer = 0
                    Dim nEnd As Integer = ColumnsNumber
                    'If Not mnSplitsParam Is Nothing Then
                    '    nEnd = IIf(mnSplitsParam.Count <= 1, 0, mnSplitsParam(mnSplitsParam.Count - 1)(mnSplitsParam(mnSplitsParam.Count - 1).getlength(0) - 1)) - 1
                    'End If
                    'Dim nEnd As Integer = IIf(mnSplitsParam.Count <= 1, 0, mnSplitsParam(mnSplitsParam.Count - 1)(mnSplitsParam(mnSplitsParam.Count - 1).getlength(0) - 1))
                    For i = nStart To nEnd 'ColumnsNumber
                        'Change Width
                        If Not mGridColColl(nSplit).Item(i) Is Nothing Then
                            mGridColColl(nSplit).Item(i).Width = CType(marrTableColWidth.GetValue(i), Integer) * 10 * sngMultiplier
                            nTotalWidth = nTotalWidth + mGridColColl(nSplit).Item(i).Width
                            mGridColColl(nSplit).Item(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            mGridColColl(nSplit).Item(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                            'Change visibility and Locking options on the columns.
                            If Not marrTableColFormat Is Nothing Then

                                If marrTableColFormat.GetValue(i).ToString.IndexOf("~C") >= 0 Then
                                    mGridColColl(nSplit).Item(i).Locked = True
                                    mGridColColl(nSplit).Item(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                    mGridColColl(nSplit).Item(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                ElseIf marrTableColFormat.GetValue(i).ToString.IndexOf("~") >= 0 Then
                                    mGridColColl(nSplit).Item(i).Locked = True
                                Else
                                    mGridColColl(nSplit).Item(i).Locked = False
                                End If

                                If marrTableColFormat.GetValue(i).ToString.IndexOf("@") >= 0 Then
                                    mGridColColl(nSplit).Item(i).Visible = False
                                    mGridColColl(nSplit).Item(i).Locked = True
                                    mGridColColl(nSplit).Item(i).HeadingStyle.ForeColor = Color.DarkBlue
                                Else
                                    mGridColColl(nSplit).Item(i).Visible = True
                                End If
                                If marrTableColFormat.GetValue(i).ToString.IndexOf("%") >= 0 Then
                                    mGridColColl(nSplit).Item(i).HeadingStyle.Font = SystemFonts.CaptionFont
                                Else
                                    mGridColColl(nSplit).Item(i).HeadingStyle.Font = SystemFonts.DefaultFont
                                End If
                            Else
                                mGridColColl(nSplit).Item(i).Locked = True
                            End If

                            'Change combobox options
                            If Not marrListCombobox Is Nothing Then
                                Dim arrComboList(1, 0) As String
                                For n = 0 To marrListCombobox.Count - 1
                                    arrComboList = marrListCombobox.Item(n)
                                    If arrComboList(0, 0) = i Then
                                        Me.Columns(i).ValueItems.Presentation = PresentationEnum.ComboBox
                                        Me.Columns(i).ValueItems.Values.Clear()
                                        Dim l As Integer
                                        For l = 0 To UBound(arrComboList, 2)
                                            If arrComboList(1, l) <> "" Or UBound(arrComboList, 2) > 0 Then
                                                Dim VIT As New ValueItem
                                                VIT.Value = arrComboList(1, l)
                                                VIT.DisplayValue = arrComboList(1, l)
                                                Me.Columns(i).ValueItems.Values.Add(VIT)
                                            End If
                                        Next
                                        Exit For
                                    Else
                                        Me.Columns(i).ValueItems.Presentation = PresentationEnum.Normal
                                    End If
                                Next
                            Else
                                Me.Columns(i).ValueItems.Presentation = PresentationEnum.Normal
                            End If
                            'Translate
                            If Not marrListTranslate Is Nothing Then
                                For t As Integer = 0 To marrListTranslate.Count - 1
                                    If marrListTranslate(t)(0, 0) = i Then
                                        Me.Columns(i).ValueItems.Values.Clear()
                                        For tCount As Integer = 0 To marrListTranslate(t).getlength(1) - 1
                                            Me.Columns(i).ValueItems.Translate = True
                                            Dim VIT As New ValueItem
                                            VIT.Value = (marrListTranslate(t)(2, tCount))
                                            VIT.DisplayValue = (marrListTranslate(t)(1, tCount))
                                            Me.Columns(i).ValueItems.Values.Add(VIT)
                                        Next
                                    End If
                                Next
                            End If
                            'Change Button options
                            If Not marrListButton Is Nothing Then
                                Dim arrButtonList(0) As String
                                For n = 0 To marrListButton.Count - 1
                                    arrButtonList = marrListButton.Item(n)
                                    For l As Integer = 0 To UBound(arrButtonList, 1)
                                        If arrButtonList(l) <> "" Or UBound(arrButtonList, 1) > 0 Then
                                            If arrButtonList(l) = i Then
                                                'Add below any necessary grid custom settings for this form
                                                'Me.Splits(0).DisplayColumns(CType(arrButtonList(l), Integer)).Button = True
                                                'Me.Splits(0).DisplayColumns(CType(arrButtonList(l), Integer)).ButtonAlways = True
                                                'Me.Splits(0).DisplayColumns(CType(arrButtonList(l), Integer)).ButtonText = True
                                                'Me.Splits(0).DisplayColumns(CType(arrButtonList(l), Integer)).Style.HorizontalAlignment = AlignHorzEnum.Center
                                                mGridColColl(nSplit)(CType(arrButtonList(l), Integer)).Button = True
                                                mGridColColl(nSplit)(CType(arrButtonList(l), Integer)).ButtonAlways = True
                                                mGridColColl(nSplit)(CType(arrButtonList(l), Integer)).ButtonText = True
                                                mGridColColl(nSplit)(CType(arrButtonList(l), Integer)).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                                            End If
                                        End If
                                    Next
                                Next
                            End If
                            'Change CheckBox options
                            If Not marrListCheckBox Is Nothing Then
                                For t As Integer = 0 To marrListCheckBox.Count - 1
                                    If marrListCheckBox(t)(0, 0) = i Then
                                        Me.Columns(i).ValueItems.Values.Clear()
                                        Me.Columns(i).ValueItems.Presentation = PresentationEnum.CheckBox
                                        Me.Columns(i).ValueItems.Translate = True
                                        For tCount As Integer = 0 To marrListCheckBox(t).getlength(1) - 1
                                            Dim VIT As New ValueItem
                                            VIT.Value = (marrListCheckBox(t)(2, tCount))
                                            VIT.DisplayValue = (marrListCheckBox(t)(1, tCount))
                                            Me.Columns(i).ValueItems.Values.Add(VIT)
                                        Next
                                        mGridColColl(nSplit)(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                                        'Me.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = AlignHorzEnum.Center
                                    End If
                                Next
                            End If
                        End If
                    Next
                Next


                For i = 1 To Me.AC_SplitsCount - 1
                    mGridColColl(i) = mGridColColl(0)
                Next i
            End If
            mnTotalWidth = nTotalWidth
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "SetColumns Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".SetColumns Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try

    End Sub

    Private Sub GetFormatGrid()
        Dim i As Integer
        Dim n As Integer
        Dim DTable As DataTable = Nothing
        Dim DataRow As DataRow = Nothing
        Try
            If mSQLDataSet Is Nothing Then Exit Sub

            For i = 0 To mSQLDataSet.Tables.Count - 1
                DTable = mSQLDataSet.Tables(i).Clone
                For n = 0 To mSQLDataSet.Tables(i).Rows.Count - 1
                    DTable.Rows.Add(mSQLDataSet.Tables(i).Rows(n).ItemArray)
                Next
                Dim scase() As String = DTable.Columns(0).Caption.ToString.Split("-")
                Select Case scase(0).ToUpper
                    Case "WIDTH"
                        'Get Row Array
                        If DTable.Rows.Count > 0 Then
                            DataRow = DTable.Rows(0) 'Get Width from firet row.
                            ''$$$ 8/21/2013, Base on GridWith to get default size of the column
                            'Dim iDefaultWidth As Integer = 0
                            'Dim iIncreaseWidth As Integer = 0
                            'For j As Integer = 0 To DataRow.ItemArray.Count - 1
                            '    iDefaultWidth = iDefaultWidth + Val(DataRow.Item(j))
                            'Next
                            'If (miGridWidth / 11) > iDefaultWidth Then
                            '    iIncreaseWidth = (miGridWidth / iDefaultWidth)
                            '    For j As Integer = 0 To DataRow.ItemArray.Count - 1
                            '        DataRow.Item(j) = (DataRow.Item(j) * (iIncreaseWidth / 10))
                            '    Next
                            'End If
                            ''$$$$$$$$$
                            marrTableColWidth = DataRow.ItemArray
                        End If
                    Case "FORMAT" '   ~, @ 'Disable, Not Visible
                        If DTable.Rows.Count > 0 Then
                            DataRow = DTable.Rows(0)
                            marrTableColFormat = DataRow.ItemArray
                        End If
                    Case "TRANSLATE" 'not finished
                        If DTable.Rows.Count > 0 Then
                            Dim arrComboTranslate(1, 0) As String
                            Dim arrImage(0) As System.Drawing.Image
                            ReDim arrComboTranslate(2, DTable.Rows.Count - 1)
                            ReDim arrImage(DTable.Rows.Count - 1)
                            For n = 0 To UBound(arrComboTranslate, 1) - 2
                                arrComboTranslate(0, n) = scase(1).ToUpper 'Column number
                                arrComboTranslate(1, n) = DTable.Rows.Item(n).Item(0) 'Translate
                                arrComboTranslate(2, n) = DTable.Rows.Item(n).Item(1) 'Data
                                'arrImage(n) = DTable.Rows.Item(n).Item(2) 'Immage
                            Next
                            marrListTranslate.Add(arrComboTranslate)
                        End If
                    Case "COMBO"
                        If DTable.Rows.Count > 0 Then
                            Dim arrComboList(1, 0) As String
                            ReDim arrComboList(1, DTable.Rows.Count - 1)

                            For n = 0 To UBound(arrComboList, 2)
                                arrComboList(0, n) = scase(1).ToUpper 'Column number
                                arrComboList(1, n) = DTable.Rows.Item(n).Item(0) 'Data
                            Next
                            marrListCombobox.Add(arrComboList)
                        End If
                    Case "BUTTON"
                        If DTable.Rows.Count > 0 Then
                            Dim arrButtonList(0) As String
                            ReDim arrButtonList(DTable.Rows.Count - 1)

                            For n = 0 To UBound(arrButtonList, 1)
                                arrButtonList(n) = scase(1).ToUpper 'Column number
                            Next
                            marrListButton.Add(arrButtonList)
                        End If
                    Case "CHECKBOX"
                        If DTable.Rows.Count > 0 Then
                            Dim arrCheckList(1, 0) As String
                            ReDim arrCheckList(2, DTable.Rows.Count - 1)

                            For n = 0 To UBound(arrCheckList, 1)
                                arrCheckList(0, n) = scase(1).ToUpper 'Column number
                                arrCheckList(2, n) = DTable.Rows.Item(n).Item(0) 'Translate
                                arrCheckList(1, n) = DTable.Rows.Item(n).Item(1) 'Data
                            Next
                            marrListCheckBox.Add(arrCheckList)
                        End If
                    Case Else
                        'get data
                        mSQLDataTable = mSQLDataSet.Tables.Item(mSQLDataSet.Tables.Count - 1)
                End Select
            Next
            DTable.Clear()
            DTable.Dispose()
            DTable = Nothing
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "GetFormatGrid Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".GetFormatGrid Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Refresh grid based on data set (DataMember is the Datatable) 
    ''' </summary>
    ''' <param name="bPopulateByRow">Optional. Set to True, Will use method to override data row by row. Otherwise will replace bound source.</param>
    ''' <param name="bDisplayAllRows">Optional. Set to True, Return all records from datasource. Otherwise will display preset records(Check value in AC_RowsLoadFirst).</param>
    ''' <remarks></remarks>
    Public Overridable Sub AC_RefreshGrid(Optional ByVal bPopulateByRow As Boolean = False, Optional ByVal bDisplayAllRows As Boolean = False)
        Dim bFatchStyle As Boolean = False
        Try
            If mbAtemptToChoose And mbBookmarkTopRowOnScroll Then Exit Sub
            If Not mbISGridLoaded Then
                Me.ClearFields()
            End If
            If marrListCombobox.Count > 0 Then marrListCombobox.Clear()
            If marrListTranslate.Count > 0 Then marrListTranslate.Clear()
            If marrListButton.Count > 0 Then marrListButton.Clear()
            If marrListCheckBox.Count > 0 Then marrListCheckBox.Clear()
            GetFormatGrid()

            mSQLDataTable = mSQLDataSet.Tables(mSQLDataSet.Tables.Count - 1)

            If Not mSQLDataTable Is Nothing Then
                mSQLTempDS = Me.DataSource

                mnRows = mSQLDataTable.Rows.Count
                If mnRows = 0 Then
                    If Not mSQLTempDS Is Nothing Then
                        mSQLTempDS.Tables(mSQLDataSet.Tables.Count - 1).Clear()
                    End If
                End If
                If mSQLDataTable.Rows.Count <= mnFirstTimeRecordsShow Then
                    mnCurrentRows = mSQLDataTable.Rows.Count
                Else
                    If bDisplayAllRows Or Not bPopulateByRow Then
                        mnCurrentRows = mSQLDataTable.Rows.Count
                    Else
                        mnCurrentRows = mSQLDataTable.Rows.Count - (mSQLDataTable.Rows.Count - mnFirstTimeRecordsShow)
                    End If

                End If
                If Not mSQLTempDS Is Nothing Then
                    If mSQLTempDS.Tables(mSQLDataSet.Tables.Count - 1).Rows.Count > mnFirstTimeRecordsShow Then
                        mSQLTempDS.Tables(mSQLDataSet.Tables.Count - 1).Clear()
                    End If
                End If
                'Reset FetchRowStile
                If Me.FetchRowStyles = True Then
                    bFatchStyle = Me.FetchRowStyles
                    Me.FetchRowStyles = False
                End If
                Dim ds As DataSet = Me.DataSource

                If Not mbISGridLoaded Or ds Is Nothing Or Not bPopulateByRow Then
                    Me.DataMember = mSQLDataSet.Tables(mSQLDataSet.Tables.Count - 1).TableName
                    Me.DataSource = mSQLDataSet
                    mSQLTempDS = Me.DataSource
                    mnCurrentRows = mSQLDataSet.Tables(mSQLDataSet.Tables.Count - 1).Rows.Count
                Else
                    mSQLTempDS.RejectChanges()
                    Dim R As Integer
                    For R = 0 To mnCurrentRows - 1
                        'Add row if Needed
                        If mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).Rows.Count < R + 1 Then
                            Dim dr As DataRow = mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).NewRow
                            mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).Rows.Add(dr)
                        End If
                        'Load Data to rwo
                        For c As Integer = 0 To mSQLDataTable.Columns.Count - 1
                            mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).Rows(R).Item(c) = mSQLDataTable.Rows(R).Item(c)
                        Next
                    Next
                    'extra row remove 
                    For nTemp As Integer = mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).Rows.Count - 1 To R Step -1
                        mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).Rows.RemoveAt(nTemp)
                    Next
                    mSQLTempDS.Tables(mSQLTempDS.Tables.Count - 1).AcceptChanges()
                End If
            End If

            SetColumns()

            For n As Integer = Me.Splits.Count - 1 To 1 Step -1
                Me.RemoveHorizontalSplit(n)
            Next
            If Me.mnSplitsCount > Me.Splits.Count Then
                SplitConfig(mnSplitsCount, mnSplitsParam)
            End If
            Rebind(True)
            mbISGridLoaded = True
            ' set fetchStyle
            Me.FetchRowStyles = bFatchStyle
            RaiseEvent AC_Rows(mnCurrentRows, mnRows)
            If Not mlisEditedCells Is Nothing Then
                mlisEditedCells = Nothing
                mlisEditedCells = New List(Of Point)
            End If
            Dim S As New C1.Win.C1TrueDBGrid.Style()
            S.Borders.BorderType = BorderTypeEnum.Raised
            S.BackColor = Color.LightSkyBlue
            Dim myfont As Font

            myfont = New Font(Me.Font.Name, Me.Font.Size - 1, FontStyle.Bold)
            S.Font = myfont
            S.ForeColor = System.Drawing.Color.DarkBlue
            Me.AddCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.CurrentCell, S)

        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_RefreshGrid Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".AC_RefreshGrid Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")

        End Try
    End Sub

    ''' <summary>
    ''' Reset Grid Sort direction (Use CurrencyManager and IBindingList)
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub AC_SortDirectionReset()
        Try
            If DataSource Is Nothing Then Exit Sub
            If Columns.Count > 0 Then
                For i As Integer = 0 To Me.Columns.Count - 1
                    If Me.Columns(i).SortDirection <> SortDirEnum.None Then
                        Me.Columns(i).SortDirection = SortDirEnum.None
                    End If
                Next
                Dim CM As CurrencyManager = Me.BindingContext(DataSource, DataMember)
                Dim BL As System.ComponentModel.IBindingList = CM.List
                If BL.IsSorted Then BL.RemoveSort()
            End If
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_SortDirectionReset Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".AC_ResetSortDirection1 Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Manualy Set Grid Sort direction (Use CurrencyManager and IBindingList)
    ''' </summary>
    ''' <param name="DataField"> Column caption </param>
    ''' <param name="ListSortDir">Sort Direction</param>
    ''' <remarks></remarks>
    Public Overridable Sub AC_SortDirection(ByVal DataField As String, _
        Optional ByVal ListSortDir As System.ComponentModel.ListSortDirection = _
        System.ComponentModel.ListSortDirection.Ascending)
        Try
            If Columns.Count > 0 Then
                Dim CM As CurrencyManager = Me.BindingContext(DataSource, DataMember)
                Dim BL As System.ComponentModel.IBindingList = CM.List
                If BL.SupportsSorting Then
                    Dim PD As System.ComponentModel.PropertyDescriptor = CM.GetItemProperties()(DataField)
                    BL.ApplySort(PD, ListSortDir)
                    Columns(Col).SortDirection = ListSortDir
                End If
            End If
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_SortDirection Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".AC_ResetSortDirection2 Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Get rows count
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AC_TotalRecords() As Integer
        Get
            Return mnRows
        End Get
    End Property
    ''' <summary>
    ''' Set or Get grid Dataset
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AC_GridDataSet() As DataSet
        Get
            Return mSQLTempDS 'mSQLDataSet
        End Get
        Set(ByVal Value As DataSet)
            mSQLDataSet = Value
        End Set
    End Property

    ''' <summary>
    ''' Set how many horizontal splits on the grid
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AC_SplitsCount() As Integer
        Get
            Return mnSplitsCount
        End Get
        Set(ByVal Value As Integer)
            mnSplitsCount = Value
        End Set
    End Property

    ''' <summary>
    ''' Get Grid columns width
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AC_ColumnsWidth() As Integer
        Get
            Return mnTotalWidth
        End Get
    End Property
    ''' <summary>
    ''' Set or Get arraylist of split-array numbers of visible column in the particular
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AC_SplitsParam() As ArrayList
        Get
            Return mnSplitsParam
        End Get
        Set(ByVal value As ArrayList)
            Try
                mnSplitsParam = value
                ReDim mGridColColl(value.Count - 1)

                Me.InsertHorizontalSplit(value.Count - 1)
                Me.Splits(0).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                Dim i As Integer
                For i = 0 To value.Count - 1
                    If i > 0 And Me.AllowVerticalSplit Then Me.InsertVerticalSplit(i)
                    If Me.AllowVerticalSplit Then Me.Splits(i).VScrollBar.Width = Me.RowHeight

                    If i > 0 And Me.AllowHorizontalSplit Then Me.InsertHorizontalSplit(i)
                    If Me.AllowHorizontalSplit Then Me.Splits(i).HScrollBar.Height = Me.RowHeight
                    If mDefaultLayout.Splits.Count - 1 >= i Then
                        Me.Splits(i).ColumnCaptionHeight = mDefaultLayout.Splits(i).ColumnCaptionHeight
                    Else
                        Me.Splits(i).ColumnCaptionHeight = mDefaultLayout.Splits(0).ColumnCaptionHeight
                        Me.Splits(i).FetchRowStyles = mDefaultLayout.Splits(0).FetchRowStyles
                    End If

                    Me.Splits(i).ExtendRightColumn = True
                    mGridColColl(i) = Me.Splits(i).DisplayColumns
                Next i


            Catch exp As Exception
                AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_SplitsParam Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
                '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_AC_SplitsParam Error: " & ex.ToString, "Error")
            End Try
        End Set
    End Property


    Public Property AC_ColumnWidthMultipler_Disable() As Boolean
        Get
            Return mbColumnWidthMultipler_Disable
        End Get
        Set(ByVal Value As Boolean)
            mbColumnWidthMultipler_Disable = Value
        End Set
    End Property

    Private Sub DefaultGrid_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles Me.AfterColEdit
        mlisEditedCells.Add(New Point(Me.Row, Me.Col))

    End Sub

    Private Sub DefaultGrid_AfterInsert(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AfterInsert
        mbGridInserting = False
    End Sub

    Private Sub DefaultGrid_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles Me.BeforeColEdit
        mbAtemptToChoose = True
    End Sub

    Private Sub DefaultGrid_BeforeInsert(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles Me.BeforeInsert
        mbGridInserting = True
    End Sub

    Private Sub DefaultGrid_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles Me.ButtonClick
        mbAtemptToChoose = True
    End Sub

    Private Sub DefaultGrid_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles Me.ComboSelect
        mbAtemptToChoose = False
    End Sub


    Private Sub DefaultGrid_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            If Not mSQLDataTable Is Nothing Then
                mSQLDataTable.Clear()
                mSQLDataTable.Dispose()
                mSQLDataTable = Nothing
            End If

            If Not mSQLDataSet Is Nothing Then
                mSQLDataSet.Clear()
                mSQLDataSet.Dispose()
                mSQLDataSet = Nothing
            End If

            If Not mDefaultLayout Is Nothing Then
                mDefaultLayout.Dispose()
                mDefaultLayout = Nothing
            End If
            If Not mnSplitsParam Is Nothing Then
                mnSplitsParam.Clear()
                mnSplitsParam = Nothing
            End If
            If Not marrListCombobox Is Nothing Then
                marrListCombobox.Clear()
                marrListCombobox = Nothing
            End If
            If Not marrListTranslate Is Nothing Then
                marrListTranslate.Clear()
                marrListTranslate = Nothing
            End If
            If Not marrListButton Is Nothing Then
                marrListButton.Clear()
                marrListButton = Nothing
            End If
            If Not marrListCheckBox Is Nothing Then
                marrListCheckBox.Clear()
                marrListCheckBox = Nothing
            End If
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "DefaultGrid_Disposed Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_Disposed Error: " & ex.ToString, "Error")
        End Try
    End Sub

    Private Sub DefaultGrid_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles MyBase.FetchRowStyle
        Try
            'If Me.Columns(miColumnGreyRowStyle).CellValue(e.Row).ToString.ToUpper = "DISABLED" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.LightGray  'disable
            'ElseIf Me.Columns(miColumnRedRowStyle).CellValue(e.Row).ToString = "1" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Red 'jam
            'ElseIf Me.Columns(miColumnYellowRowStyle).CellValue(e.Row).ToString = "1" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Yellow 'full
            'ElseIf Me.Columns(miColumnGreyRowStyle).CellValue(e.Row).ToString = "1" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Gray 'disable
            'ElseIf Me.Columns(miColumnRedRowStyle).CellValue(e.Row).ToString = "1" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Red 'jam
            'ElseIf Me.Columns(miColumnYellowRowStyle).CellValue(e.Row).ToString.ToUpper = "T" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Yellow 'full
            'ElseIf Me.Columns(miColumnRedRowStyle).CellValue(e.Row).ToString.ToUpper = "T" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Red 'jam
            'ElseIf Me.Columns(miColumnGreyRowStyle).CellValue(e.Row).ToString.ToUpper = "T" Then
            '    e.CellStyle.BackColor = System.Drawing.Color.Gray 'disable
            'Else
            '    e.CellStyle.BackColor = System.Drawing.Color.White
            'End If
        Catch exp As Exception
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_FetchRowStyle Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try

    End Sub

    Private Sub DefaultGrid_FetchScrollTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchScrollTipsEventArgs) Handles MyBase.FetchScrollTips
        ' Set the ScrollTip depending on which
        ' scroll bar was moved
        mbscroll = False
        mnscrollfETCHCount = mnscrollfETCHCount + 1
        Try
            Select Case e.ScrollBar

                Case C1.Win.C1TrueDBGrid.ScrollBarEnum.Horizontal

                    e.ScrollTip = Me.Columns(e.ColIndex).Caption

                Case C1.Win.C1TrueDBGrid.ScrollBarEnum.Vertical
                    Dim sTempValue As String = ""
                    Dim sTempText As String = ""
                    If Me.Columns(1) Is Nothing Then
                        If Not Me.Columns(0) Is Nothing Then
                            sTempValue = Me.Columns(0).Caption
                            sTempText = Me.Columns(0).CellText(e.Row)
                        End If
                    Else
                        sTempValue = Me.Columns(1).Caption
                        sTempText = Me.Columns(1).CellText(e.Row)
                    End If
                    e.ScrollTip = "Record: " & CStr(e.Row + Me.VisibleRows) & " of " & Me.Splits(0).Rows.Count() & vbCrLf
                    If mbBookmarkTopRowOnScroll Then
                        Me.Bookmark = CStr(e.Row + 1)
                    End If
            End Select
            e.TipStyle.ForeColor = System.Drawing.Color.Blue
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "DefaultGrid_FetchScrollTips Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_FetchScrollTips Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Print preview grid 
    ''' </summary>
    ''' <param name="Title">Set title to display</param>
    ''' <param name="size">Set form size to print on</param>
    ''' <remarks></remarks>
    Public Overridable Sub AC_Print(ByVal Title As String, ByVal size As System.Drawing.Size, Optional ByVal Preview As Boolean = True)
        Dim P As New Point(100, 100)
        Try
            Me.PreviewInfo.Size = size
            PreviewInfo.Caption = Title
            PreviewInfo.Location = P
            PreviewInfo.AllowSizing = True

            With Me.PrintInfo
                Dim fntHeader As System.Drawing.Font
                Dim fntFooter As System.Drawing.Font
                fntHeader = New System.Drawing.Font(.PageHeaderStyle.Font.Name, 16, System.Drawing.FontStyle.Bold)
                fntFooter = New System.Drawing.Font(.PageHeaderStyle.Font.Name, .PageHeaderStyle.Font.Size, System.Drawing.FontStyle.Italic)
                'Header properties
                .PageHeaderStyle.Font = fntHeader
                .PageHeader = vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & Title & vbCrLf
                .PageHeaderHeight = 50
                'column headers will be on every page
                .RepeatColumnHeaders = True

                .VarRowHeight = PrintInfo.RowHeightEnum.LikeGrid

                'Footer properties
                'display page numbers (centered)
                .PageFooter = "Page: \p" & vbCrLf & "Print Date/Time:      " & Now & vbCrLf & vbCrLf & "Designed by Winco DWL."
                .PageFooterStyle.Font = fntFooter
                .PageFooterHeight = 70

                'page setting
                .PageSettings.Landscape = True ' False
                .PageSettings.Margins.Top = 20
                .PageSettings.Margins.Bottom = 20
                .PageSettings.Margins.Left = 10
                .PageSettings.Margins.Right = 10
                .MaxRowHeight = Me.RowHeight

                If Me.AC_SplitsCount > 0 Then
                    .PrintHorizontalSplits = True
                End If
                If Preview = True Then
                    'invoke print preview
                    .UseGridColors = True
                    .PrintPreview()
                Else
                    .Print()
                End If

            End With
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "AC_Print Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            'MessageBox.Show(exp.StackTrace & vbnewline & exp.Message, "AC_Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".AC_Print Error: " & vbNewLine & exp.StackTrace & vbnewline & vbNewLine & exp.message & vbnewline & vbnewline & exp.ToString, "Error")
        End Try
    End Sub

    Private Sub DefaultGrid_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FilterChange

        Try

            'Dim sb As New System.Text.StringBuilder()
            'Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            'For Each dc In Me.Columns
            '    If dc.FilterText.Length > 0 Then
            '        If sb.Length > 0 Then
            '            sb.Append(" AND ")
            '        End If
            '        sb.Append((dc.DataField + " like " + "'*" + dc.FilterText + "*'"))
            '    End If
            'Next dc
            '' Filter the data.
            'Dim dSet As DataSet = Me.DataSource

            'dSet.Tables(dSet.Tables.Count - 1).DefaultView.RowFilter = sb.ToString()



        Catch ex As Exception
            MsgBox(Err.ToString)
        End Try
        ' Build our filter expression.
    End Sub


    Private Sub DefaultGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            ' Cursor = Cursors.WaitCursor
            If e.KeyCode = Keys.F4 Then
                If Me.SelectedRows.Count < 1 Then Exit Sub
                'Cursor = Cursors.WaitCursor
                Dim strTemp As New System.Text.StringBuilder   'string to be copied to the clipboard
                For j As Integer = 0 To Me.Columns.Count - 1
                    If mbCopyHiddenFields Then
                        strTemp.Append(Me.Columns(j).Caption & vbTab)
                    Else
                        If Me.Splits(0).DisplayColumns(Me.Columns(j)).Visible Then strTemp.Append(Me.Columns(j).Caption & vbTab)
                    End If

                Next
                strTemp.Append(vbCrLf)
                'Dim iCount As Integer = 0
                For Each drow As Integer In Me.SelectedRows
                    For j As Integer = 0 To Me.Columns.Count - 1
                        If mbCopyHiddenFields Then
                            strTemp.Append(Me.Item(drow, j).ToString & vbTab)
                        Else
                            If Me.Splits(0).DisplayColumns(Me.Columns(j)).Visible Then strTemp.Append(Me.Item(drow, j).ToString & vbTab)
                        End If
                        'strTemp.Append(Me.Item(drow, j).ToString & vbTab)
                    Next
                    strTemp.Append(vbCrLf)
                    'iCount = iCount + 1
                    'Debug.WriteLine("Rocord: " & iCount.ToString)
                Next
                ' System.Windows.Forms.Clipboard.SetDataObject( strTemp.ToString, True)
                System.Windows.Forms.Clipboard.SetDataObject(strTemp.ToString, True)
                'Clipboard.SetText(strTemp.ToString)
                'Cursor = Cursors.Default
                'Debug.WriteLine(My.Computer.Clipboard.GetText())
                'Debug.WriteLine(My.Computer.Clipboard.GetText())
            ElseIf e.KeyCode = Keys.Escape Then
                If mbGridInserting Then
                    If MessageBox.Show("Do you wants to remove this new row?", "Confirm Delete New Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.Delete()
                        Me.Col = 1
                        mbGridInserting = False
                        Exit Sub
                    End If
                End If
                For n As Integer = 0 To Me.Columns.Count - 1
                    If Not Me.Columns(n).ValueItems.Presentation = PresentationEnum.ComboBox Then
                        mnCol = Me.Col
                        Me.Col = n
                        Me.Col = mnCol
                        mbAtemptToChoose = False
                        Exit For
                    End If
                Next
            End If
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "DefaultGrid_KeyDown Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_KeyDown Error: " & ex.ToString, "Error")
        Finally
            ' Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DefaultGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If Me.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtFilterBar Or Me.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtColumnHeader Then
            mbGridFilterFocused = True
        Else
            mbGridFilterFocused = False
        End If
    End Sub

    Private Sub DefaultGrid_OwnerDrawCell(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.OwnerDrawCellEventArgs) Handles Me.OwnerDrawCell
        Try

            Dim mc As Point = New Point(e.Row, e.Col)
            If mlisEditedCells.Contains(mc) Then e.Style.BackColor = mMatchedCellColor

        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "DefaultGrid_KeyDown Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try



    End Sub

    Private Sub DefaultGrid_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles Me.RowColChange
        Try
            mbAtemptToChoose = False
            mnCol = Me.Col
            'Load next mnNextRecordAdd  from Dataset
            If Me.Splits(0).Rows.Count - (Me.FirstRow + Me.VisibleRows) < mnLeftoverRows And Me.Splits(0).Rows.Count >= mnFirstTimeRecordsShow Then
                If mbscroll And mnscrollCount > 0 Then
                    AC_LoadAllData(Me.DataSource.Tables(mSQLDataSet.Tables.Count - 1), mSQLDataTable)
                    mnscrollCount = 0
                    mnscrollfETCHCount = 0
                    mbscroll = False
                ElseIf (Not mbscroll) And mnscrollfETCHCount = 0 Then
                    AC_LoadAllData(Me.DataSource.Tables(mSQLDataSet.Tables.Count - 1), mSQLDataTable)
                End If
            Else
                mnscrollCount = 0
                mbscroll = False
            End If
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "DefaultGrid_RowColChange Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_RowColChange Error: " & ex.ToString, "Error")
        End Try
    End Sub

    Private Sub DefaultGrid_Scroll(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles Me.Scroll
        Try


            If mbBookmarkTopRowOnScroll Then
                Me.Bookmark = Me.FirstRow
            End If
            mbscroll = True

            mnscrollCount = mnscrollCount + 1
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "DefaultGrid_Scroll Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "Grid_default", Me.Name & ".DefaultGrid_Scroll Error: " & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Format data mask base on last special charactor %,$,Amt
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatColumeDisplayMask()
        Try
            For j As Integer = 0 To Me.Columns.Count - 1
                If Me.Columns(j).Caption.ToString.EndsWith("%") Then
                    Me.Columns(j).NumberFormat = "0.00%"
                ElseIf Me.Columns(j).ToString.EndsWith("$") Then
                    Me.Columns(j).NumberFormat = "Currency"
                ElseIf Me.Columns(j).ToString.EndsWith("Amt") Then
                    Me.Columns(j).NumberFormat = "Currency"
                End If
            Next
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "FormatColumeDisplayMask Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "FormatColumeDisplayMask", Me.Name & ".FormatColumeDisplayMask Error: " & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Format data mask base on last special charactor %,$,Amt
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetAutoRowSize()
        Try
            For j As Integer = 0 To Me.RowCount - 1
                'MyGrid.RowHeight = 0
                Me.Splits(0).Rows(j).AutoSize()
                'MyGrid.Splits(0).Rows(j).Height = MyGrid.RowHeight
            Next
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "FormatColumeDisplayMask Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "FormatColumeDisplayMask", Me.Name & ".FormatColumeDisplayMask Error: " & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Save current grid filters
    ''' </summary>
    ''' <param name="sKay">Before Refresh Kay Value, Base on kay match to recover filters</param>
    ''' <remarks></remarks>
    Public Sub FilterSaveGridFilters(Optional ByVal sKay As String = "")
        Try
            marrFilterText.Clear()
            For j As Integer = 0 To Me.Columns.Count - 1
                marrFilterText.Add(Me.Columns(j).FilterText.ToString)
            Next
            miFirstRow = Me.FirstRow
            miBookmark = Me.Bookmark
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "SaveGridFilters Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "FormatColumeDisplayMask", Me.Name & ".FormatColumeDisplayMask Error: " & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Restall save grid filters
    ''' </summary>
    ''' <param name="sKay">After Refresh Kay Value, Base on kay match to recover filters</param>
    ''' <remarks></remarks>
    Public Sub FilterRestallFilters(Optional ByVal sKay As String = "")
        Try
            If msMyKey <> sKay Then
                msMyKey = sKay
                FilterResetFilter()
                Exit Sub
            End If
            If marrFilterText.Count > 0 Then
                For j As Integer = 0 To Columns.Count - 1
                    Columns(j).FilterText = marrFilterText.Item(j).ToString
                Next
            End If

            Me.FirstRow = miFirstRow
            Me.Bookmark = miBookmark
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "RestallFilters Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "FormatColumeDisplayMask", Me.Name & ".FormatColumeDisplayMask Error: " & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Reset save grid filters information
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FilterResetFilter()
        Try
            marrFilterText.Clear()
            miFirstRow = 0
            miBookmark = 0
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "FilterResetFilter Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "FormatColumeDisplayMask", Me.Name & ".FormatColumeDisplayMask Error: " & ex.ToString, "Error")
        End Try
    End Sub
    ''' <summary>
    ''' Set Grid allow Null values
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetAllowNULL()
        Try
            For j As Integer = 0 To Me.AC_GridDataSet.Tables(Me.AC_GridDataSet.Tables.Count - 1).Columns.Count - 1
                Me.AC_GridDataSet.Tables(Me.AC_GridDataSet.Tables.Count - 1).Columns(j).AllowDBNull = True
            Next
        Catch exp As Exception
            AviatCom_Lib.AviatCom_Lib.LogToFile(msClassName & ".log", "SetAllowNULL Error - " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
            '            AviatCom_Lib.AviatCom_Lib.LogToSystemEvent("DefaultGrid", "FormatColumeDisplayMask", Me.Name & ".FormatColumeDisplayMask Error: " & ex.ToString, "Error")
        End Try
    End Sub
End Class
