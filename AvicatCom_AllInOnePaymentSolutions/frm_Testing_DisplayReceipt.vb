Public Class frm_Testing_DisplayReceipt

    Private Sub frm_Testing_DisplayReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    'Public Function DrawRecipt(ByVal Rows As DataGridViewRowCollection, ByVal ReciptNo As String, ByVal ReciptDate As String, ByVal ReciptTotal As Decimal, ByVal UnitWidth As Integer, ByVal UnitHeight As Integer, ByVal Fontize As Integer) As Bitmap
    Public Function DrawRecipt(ByVal ReciptNo As String, ByVal ReciptDate As String, ByVal ReciptTotal As Decimal, ByVal UnitWidth As Integer, ByVal UnitHeight As Integer, ByVal Fontize As Integer) As Bitmap
        Dim ReciptWidth As Integer = 13 * UnitWidth
        Dim ReciptDetailsHeight As Integer = 13 * UnitHeight
        Dim ReciptHeight As Integer = 19 * UnitWidth + ReciptDetailsHeight
        Dim BMP As New Bitmap(ReciptWidth + 1, ReciptHeight)
        Dim GR As Graphics = Graphics.FromImage(BMP)
        ' GR.FillRectangle(Brushes.White, 0, 0, ReciptWidth, ReciptHeight)
        GR.Clear(Color.White)
        Dim LNHeaderYStart = 3 * UnitHeight
        Dim LNDetailsStart = LNHeaderYStart + UnitHeight
        GR.DrawRectangle(Pens.Black, UnitWidth * 0, LNHeaderYStart, UnitWidth, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 1, LNHeaderYStart, UnitWidth * 5, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 6, LNHeaderYStart, UnitWidth * 2, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 8, LNHeaderYStart, UnitWidth * 2, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 10, LNHeaderYStart, UnitWidth * 3, UnitHeight)

        GR.DrawRectangle(Pens.Black, UnitWidth * 0, LNDetailsStart, UnitWidth * 1, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 1, LNDetailsStart, UnitWidth * 5, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 6, LNDetailsStart, UnitWidth * 2, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 8, LNDetailsStart, UnitWidth * 2, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 10, LNDetailsStart, UnitWidth * 3, ReciptDetailsHeight)

        Dim FNT As New Font("Times", Fontize, FontStyle.Bold)
        Dim YLOC = UnitHeight * 1 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 2 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 3 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 4 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 5 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 6 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 7 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        YLOC = UnitHeight * 8 + LNDetailsStart
        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Count", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)


        GR.DrawString("ABC", FNT, Brushes.Black, UnitWidth * 1, YLOC)
        GR.DrawString("ABC", FNT, Brushes.Black, UnitWidth * 6, YLOC)
        GR.DrawString("ABC", FNT, Brushes.Black, UnitWidth * 8, YLOC)
        GR.DrawString("ABC", FNT, Brushes.Black, UnitWidth * 10, YLOC)

        'Dim I As Integer
        'For I = 0 To Rows.Count - 1
        '    Dim YLOC = UnitHeight * I + LNDetailsStart
        '    GR.DrawString(I, FNT, Brushes.Black, UnitWidth * 0, YLOC)

        '    GR.DrawString(Rows(I).Cells(1).Value, FNT, Brushes.Black, UnitWidth * 1, YLOC)
        '    GR.DrawString(Rows(I).Cells(3).Value, FNT, Brushes.Black, UnitWidth * 6, YLOC)
        '    GR.DrawString(Rows(I).Cells(4).Value, FNT, Brushes.Black, UnitWidth * 8, YLOC)
        '    GR.DrawString(Rows(I).Cells(5).Value, FNT, Brushes.Black, UnitWidth * 10, YLOC)

        'Next
        GR.DrawString("Total:" & ReciptTotal, FNT, Brushes.Black, 0, LNDetailsStart + ReciptDetailsHeight)

        GR.DrawString("Receipt No:" & ReciptNo, FNT, Brushes.Black, 0, 0)
        GR.DrawString("Receipt Date:" & ReciptDate, FNT, Brushes.Black, 0, UnitHeight)

        Return BMP
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.Image = DrawRecipt(737, DateString, 999, 20, 13, 10)
    End Sub
End Class