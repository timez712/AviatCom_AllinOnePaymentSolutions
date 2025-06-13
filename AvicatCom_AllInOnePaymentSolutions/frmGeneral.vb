Imports System
Imports System.Net
Imports AviatCom_Lib.AviatCom_Lib
Public Class frmGeneral

    Private Sub btnQuit_Click(sender As System.Object, e As System.EventArgs) Handles btnQuit.Click
        Application.Exit()
    End Sub





    Private Sub btnSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CloseAllMDIChildForms(gfrmMDI)
            If Not IsActiveOpenedForm(frm_Security_EmployeeInformation) Then
                Dim frm As New frm_Security_EmployeeInformation
                frm.MdiParent = gfrmMDI
                frm.Show()
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error btnSecurity_Click", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            LogToFile(Me.Name & ".log", "btnSecurity_Click Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub

    Private Sub frmGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.Dpi

            'If Not Add_NewAccessCode("NET:Order:Retail", "Retail", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:Order:Retail ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnRetailOrder.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:Order:Retail") Then
            '    btnRetailOrder.Enabled = False
            'Else
            '    btnRetailOrder.Enabled = True
            'End If

            'If Not Add_NewAccessCode("NET:Wholesale", "Wholesale", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:Wholesale ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnWholesaleOrder.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:Wholesale") Then
            '    btnWholesaleOrder.Enabled = False
            'Else
            '    btnWholesaleOrder.Enabled = True
            'End If

            'If Not Add_NewAccessCode("NET:Purchase", "Purchase", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:Purchase ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnPurchaseOrder.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:Purchase") Then
            '    btnPurchaseOrder.Enabled = False
            'Else
            '    btnPurchaseOrder.Enabled = True
            'End If

            'If Not Add_NewAccessCode("NET:OrderHistory", "OrderHistory", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:OrderHistory ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnOrderHistory.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:OrderHistory") Then
            '    btnOrderHistory.Enabled = False
            'Else
            '    btnOrderHistory.Enabled = True
            'End If

            'If Not Add_NewAccessCode("NET:CustomerInformation", "CustomerInformation", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:CustomerInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnCustomerInformation.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:CustomerInformation") Then
            '    btnCustomerInformation.Enabled = False
            'Else
            '    btnCustomerInformation.Enabled = True
            'End If

            'If Not Add_NewAccessCode("NET:VendorInformation", "VendorInformation", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:VendorInformation ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnVendorInformation.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:VendorInformation") Then
            '    btnVendorInformation.Enabled = False
            'Else
            '    btnVendorInformation.Enabled = True
            'End If


            'If Not Add_NewAccessCode("NET:Product", "Product", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:Product ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnProductInformation.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:Product") Then
            '    btnProductInformation.Enabled = False
            'Else
            '    btnProductInformation.Enabled = True
            'End If


            'If Not Add_NewAccessCode("NET:CompanyMisc", "CompanyMisc", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:CompanyMisc ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnCompany.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:CompanyMic") Then
            '    btnCompany.Enabled = False
            'Else
            '    btnCompany.Enabled = True
            'End If


            'If Not Add_NewAccessCode("NET:Security", "Security", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:Security ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnSecurity.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:Security") Then
            '    btnSecurity.Enabled = False
            'Else
            '    btnSecurity.Enabled = True
            'End If

            'If Not Add_NewAccessCode("NET:Accounting", "Accounting", "") Then
            '    MessageBox.Show("Please assign role access for ( NET:Accounting ).", "New Role Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    btnAccounting.Enabled = False
            'End If
            'If Not CheckAccessRight("NET:Accounting") Then
            '    btnAccounting.Enabled = False
            'Else
            '    btnAccounting.Enabled = True
            'End If


        Catch exp As Exception
            MessageBox.Show(exp.Message & vbNewLine & vbNewLine & exp.ToString, "Error frmGeneral_Load", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            LogToFile(Me.Name & ".log", "frmGeneral_Load Processing : " & vbNewLine & exp.Message & vbNewLine & vbNewLine & exp.ToString, Now)
        End Try
    End Sub


    Private Sub btnMerchant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerchant.Click

        If Not IsActiveOpenedForm(frm_CustomerService_CustomerInformation) Then
            Dim frm As New frm_CustomerService_CustomerInformation
            'frm.Anchor = AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Bottom

            frm.Show()
        End If
    End Sub

    Private Sub btnPaperRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaperRequest.Click

    End Sub

    Private Sub btnExpressInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpressInput.Click

    End Sub
End Class