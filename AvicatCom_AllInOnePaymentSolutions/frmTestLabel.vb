Public Class frmTestLabel

    Private Sub frmTestLabel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTestPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnTestPrint.Click
        'Dim objPrinter As New BrotherPrinter
        'objPrinter.SetCompanyName = txtYourCompanyName.Text
        'objPrinter.SetCustomerCompanyName = txtCustomerCompanyName.Text
        ''objPrinter.SetOrderDate = txtOrderDate.Text
        ''objPrinter.SetDueDate = txtDueDate.Text
        'objPrinter.SetOrderNumber = txtOrderNumber.Text
        'objPrinter.SetGlassName = txtItemNumber.Text
        'objPrinter.SetDimensions = txtDimensions.Text
        'objPrinter.SetsWorkDesc = txtPolish.Text
        'objPrinter.SetBarcode = txtBarcode.Text
        'objPrinter.SetQTY = Val(txtQTY.Text)
        'objPrinter.PrintLabel()
        'objPrinter = Nothing
    End Sub

    Private Sub btnQuit_Click(sender As System.Object, e As System.EventArgs) Handles btnQuit.Click
        CloseAllMDIChildForms(gfrmMDI)
        frmGeneral.MdiParent = gfrmMDI
        frmGeneral.Show()
    End Sub
End Class