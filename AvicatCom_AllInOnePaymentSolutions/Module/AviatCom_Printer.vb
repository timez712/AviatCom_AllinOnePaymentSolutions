Imports System.Data
Imports System.Drawing.Printing

Public Class AviatCom_Printer
    Private mPrinter As New Printing.PrintDocument
    Private TextToBePrinted As String = ""
    Private Sub GetPrinter()
        Try
            Dim PrinterName As String
            Dim objDefaultPrinter As New Printing.PrintDocument
            PrinterName = Printing.PrinterSettings.InstalledPrinters(0)
            PrinterName = objDefaultPrinter.PrinterSettings.PrinterName


            For Each PrinterName In Printing.PrinterSettings.InstalledPrinters
                Debug.WriteLine(PrinterName)

            Next


        Catch exp As Exception

        End Try

    End Sub
    Private Function GetReceipt() As String
        Try
            Dim sReceipt As String = Nothing
            Dim txtReader As System.IO.StreamReader = New System.IO.StreamReader("D:\Test.txt")
            sReceipt = txtReader.ReadToEnd
            txtReader.Close()
            'e.Graphics.DrawString(textOfFile, New Font("Arial", 16), Brushes.Black, 100, 500)


            'For j As Integer = 0 To C1TrueDBGrid1.RowCount - 1
            '    Dim sDescription As String = C1TrueDBGrid1.Item(j, 0).ToString
            '    Dim sPrice As String = C1TrueDBGrid1.Item(j, 1).ToString
            '    TextToBePrinted = sDescription & "-----" & sPrice & Chr(10)
            'Next

            Return sReceipt
        Catch ex As Exception

            Return Nothing
        End Try
    End Function


    'Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
    '    Try
    '        Dim newImage As Image = Image.FromFile("E:\VBproject\Gap.bmp")
    '        e.Graphics.DrawImage(newImage, 100, 100)

    '        ' You need to specify codepage for Hebrew encoding.

    '        'Code(Block)
    '        'Dim txtReader As System.IO.StreamReader = New System.IO.StreamReader("D:\Text.txt", System.Text.Encoding.GetEncoding(862))
    '        'Dim textOfFile As String = txtReader.ReadToEnd
    '        'txtReader.Close()


    '        Dim txtReader As System.IO.StreamReader = New System.IO.StreamReader("D:\Test.txt")
    '        Dim textOfFile As String = txtReader.ReadToEnd
    '        TextToBePrinted = txtReader.ReadToEnd
    '        txtReader.Close()
    '        e.Graphics.DrawString(textOfFile, New Font("Arial", 16), Brushes.Black, 100, 500)



    '        ''$$$$$$$$$$   1   $$$$$$$$$$$$$$$$$$$$$$$$
    '        '' please check this code snippet.
    '        'Dim strToPrint As String
    '        'Dim linesPerPage As Integer = 0
    '        'Dim charsOnPage As Integer = 0
    '        'e.Graphics.MeasureString(strToPrint, Me.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, charsOnPage, linesPerPage)
    '        'e.Graphics.DrawString(strToPrint, Me.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic)
    '        'strToPrint = strToPrint.Substring(charsOnPage)
    '        'e.HasMorePages = (strToPrint.Length > 0)



    '        '$$$$$$    2    $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    '        'Private Sub btnPrint_Click(ByVal sender As System.Object, _
    '        '    ByVal e As System.EventArgs) _
    '        '    Handles btnPrint.Click
    '        'Dim pd AsNew PrintDocument()
    '        'pd.OriginAtMargins = TrueAddHandler pd.PrintPage, AddressOf PrintPageEvent
    '        '    pd.DefaultPageSettings.Color = False
    '        '    pd.Print()
    '        'End Sub
    '        'Private Sub PrintPageEvent(ByVal sender AsObject, _
    '        '              ByVal ev As PrintPageEventArgs)
    '        '        ev.Graphics.DrawString("Thank You for Dining At Joe's!", _
    '        '                    New Font("Arial", _
    '        '                        12.0, _
    '        '                        FontStyle.Bold, _
    '        '                        GraphicsUnit.Point), _
    '        '                    Brushes.Blue, _
    '        '                    16, _
    '        '                    16)
    '        '        ev.HasMorePages = FalseEndSubEndClass

    '        '$$$$$$$$$$$$$$$$$    3    $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    '        'Dim pd = New Printing.PrintDocument
    '        'Dim printControl = New Printing.StandardPrintController
    '        'pd.PrintController = printControl
    '        'pd.Print()


    '        ''$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    '    Catch ex As Exception

    '    End Try


    'End Sub

    Private Sub SetupPrinter(ByVal sPrinterName As String, ByVal bSetup As Boolean)
        Try
            If bSetup Then
                mPrinter.PrinterSettings.PrinterName = sPrinterName
                Dim stemp As String = "" 'mPrinter.PrinterSettings.PaperSizes
                mPrinter.DefaultPageSettings.PaperSize = mPrinter.PrinterSettings.PaperSizes.Item(0)
                AddHandler mPrinter.PrintPage, _
                    AddressOf Me.PrintPageHandler
            Else
                RemoveHandler mPrinter.PrintPage, _
                    AddressOf Me.PrintPageHandler
            End If

        Catch exp As Exception

        End Try
    End Sub
    Private Sub PrintOrder(ByVal sPrint As String)
        mPrinter.Print()

        'Using (mPrinter)
        '    mPrinter.PrinterSettings.PrinterName = gsPrinterName

        '    '= "Software - HP LaserJet 4050 Series PCL 5" 'Printer Name


        '    AddHandler mPrinter.PrintPage, _
        '        AddressOf Me.PrintPageHandler

        '    mPrinter.Print()

        '    RemoveHandler mPrinter.PrintPage, _
        '        AddressOf Me.PrintPageHandler
        'End Using
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, _
        ByVal args As Printing.PrintPageEventArgs)
        'Dim myFont As New Font("Microsoft San Serif", 10)
        'args.Graphics.DrawString(TextToBePrinted, _
        '   New Font(myFont, FontStyle.Regular), _
        '   Brushes.Black, 50, 50)

        'For display Image
        'Dim newImage As Image = Image.FromFile("c:\Temp\test.bmp")
        'args.Graphics.DrawImage(newImage, 0, 0)

        Dim myFont As New Font("Times New Roman", 10)
        args.Graphics.DrawString(TextToBePrinted, _
            New Font(myFont, FontStyle.Regular), _
            Brushes.Black, 0, 0)


    End Sub

    Private Sub DisplayInputForReceipt(ByVal dtProduct As DataTable)
        Try
            Dim objPrinterDialog As New PrintDialog
            Dim objPrintDocument As New PrintDocument()
            objPrinterDialog.Document = objPrintDocument
            AddHandler objPrintDocument.PrintPage, AddressOf PrintDocument_PrintPage
            'objPrintDocument.p = New PrintPageEventHandler(AddressOf PrintDocument_PrintPage)



        Catch exp As Exception

        End Try
    End Sub
    Friend Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Try

            Dim imgGraphic As Graphics = e.Graphics
            Dim MyFont As New Font("Courier New", 12)
            Dim iMyFontHeight As Integer = MyFont.GetHeight
            Dim iStartX As Integer = 10
            Dim iStartY As Integer = 10
            Dim iOffSet As Integer = 40
            imgGraphic.DrawString("Welcome", New Font("Courier New", 18), New SolidBrush(Color.Black), iStartX, iStartY)

            iOffSet = iOffSet + iMyFontHeight + 5

            'For Each dRow As DataRow In dtProduct.Rows
            '    imgGraphic.DrawString(dRow("ProductID").ToString.PadRight(30) & FormatCurrency(Val(dRow("UnitPrice")), 2), MyFont, New SolidBrush(Color.Black), iStartX, iStartY + iOffSet)
            '    iOffSet = iOffSet + iMyFontHeight + 5
            'Next

            imgGraphic.DrawString("Total Amount: " & "TEst", MyFont, New SolidBrush(Color.Black), iStartX, iStartY + iOffSet)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub TestPrint()
        Try
            Dim objPrinterDialog As New PrintDialog
            Dim objPrintDocument As New PrintDocument()
            objPrinterDialog.Document = objPrintDocument
            AddHandler objPrintDocument.PrintPage, AddressOf PrintDocument_PrintPage

            objPrintDocument.PrinterSettings.PrinterName = "P-822DB"

            If objPrinterDialog.ShowDialog = DialogResult.OK Then
                objPrintDocument.Print()

            End If
        Catch ex As Exception

        End Try
    End Sub
    'Public Sub GiftReceipt()
    '    Try

    '        Dim rptt As String = "The receipt is mine"
    '        Dim ss As System.IO.StreamWriter
    '        ss = New System.IO.StreamWriter("C:/Program Files/COT/Selorm/Receipt.txt")
    '        ss.Write("")
    '        ss.Write(rptt)
    '        ss.Close()


    '        Me.PrintDocument1.DocumentName = "C:\Program Files\COT\Selorm\Receipt"

    '        Me.PrintDocument1.Print()

    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Public Sub GiftReceipt()

    '    Try

    '        Dim displayString As String

    '        Dim ESC As String = Chr(&H1B)

    '        displayString = ESC + "!" + Chr(1) + ESC + "|cA" + "Store Name" + ESC + "|1lF"

    '        displayString += ESC + "|cA" + "Store Address" + ESC + "|1lF"

    '        displayString += ESC + "|2C" + ESC + "|cA" + ESC + "|bC" + "Gift Receipt" + ESC + "|1lF" + ESC + "|1lF"

    '        displayString += ESC + "|N" + ESC + "!" + Chr(1) + "  Transaction #:  " + vbTab.ToString() + "105" + ESC + "|1lF"

    '        displayString += "  Date:  " + Date.Today() + vbTab.ToString() + "Time: "

    '        displayString += DateAndTime.Now().ToLongTimeString() + ESC + "|1lF"

    '        displayString += "  Cashier:  " + CStr(
    '            _ currSess.Cashier.Number) + vbTab.ToString() + "Register:  " + CStr(
    '            _ currSess.Register.Number) + ESC + "|1lF" + ESC + "|1lF"

    '        displayString += ESC + "|2uC" + "  Item               Description           Quantity" + ESC + "|N" + ESC + "!" + Chr(1) + ESC + "|1lF" + ESC + "|1lF" + "  "

    '        'Iterate loop for each row of the Data Set.

    '        For k As Integer = 0 To TransactionSet1.TransactionEntry.Rows.Count - 1

    '            'Checking for each row which has selected in DataGrid item.

    '            If CType(dgTransactionList.Item(k, 0), System.String) = "True" Then
    '                'Get the Item value from selected row.

    '                Dim item As String = dgTransactionList.Item(k, 1).ToString()

    '                Dim itemValue As String = String.Empty

    '                If item.Length > 11 Then

    '                    'if Item length is greater then 11, then take substring of item 0 to 11.

    '                    item = item.Substring(0, 11)

    '                Else

    '                    'Adding " " in Item string until length 11.

    '                    While item.Length <= 11

    '                        item += " "

    '                    End While

    '                End If

    '                displayString += item + vbTab.ToString()

    '                Dim desc As String = dgTransactionList.Item(k, 2).ToString()

    '                Dim descValue As String = String.Empty
    '                If desc.Length > 20 Then

    '                    'If Description length is greater then 20, then take substring of item 0 to 20.

    '                    desc = desc.Substring(0, 20)

    '                Else

    '                    While desc.Length <= 20

    '                        'Adding " " in Description string until length 20.

    '                        desc += " "

    '                    End While

    '                End If

    '                displayString += desc + vbTab.ToString()

    '                Dim qnty As String = dgTransactionList.Item(k, 3).ToString()

    '                Dim qntyValue As String = String.Empty

    '                If qnty.Length > 3 Then

    '                    'If Quantity length is greater then 20, then take substring of quantity 0 to 3.

    '                    qnty = qnty.Substring(0, 3)

    '                Else

    '                    While qnty.Length <= 3

    '                        'Adding " " in Quantity string until length 20.

    '                        qntyValue += " "

    '                        qnty += " "

    '                    End While

    '                End If

    '                qntyValue += qnty.Trim()

    '                displayString += qntyValue

    '                displayString += ESC + "|1lF" + "  "

    '            End If

    '        Next k

    '        displayString += ESC + "|1lF"

    '        displayString += ESC + "|cA" + "Thank You for shopping" + ESC + "|1lF"

    '        displayString += ESC + "|cA" + currSess.Configuration.StoreName + ESC + "|1lF"

    '        displayString += ESC + "|cA" + "We hope you'll come back soon!" + ESC + "|1lF" + ESC + "|1lF" + ESC + "|fP"
    '        _ currSess.Register.SetActivePrinterNumber(0)

    '        Dim objRp As Object = _ currSess.Register.ReceiptPrinter

    '        objRp.PrintNormal(2, displayString))

    '        objRp.Release()
    '        MsgBox("Gift Receipt printed Successfully.")

    '    Catch ex As Exception


    '        MsgBox(ex.ToString())

    '    End Try

    'End Sub


End Class
