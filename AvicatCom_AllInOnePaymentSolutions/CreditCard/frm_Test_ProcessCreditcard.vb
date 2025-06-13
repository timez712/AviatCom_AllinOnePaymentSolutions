Imports POSLink
Public Class frm_Test_ProcessCreditcard
    'Private CARD_TYPES() As String = {"CREDIT", "DEBIT", "CHECK", "EBT_FOODSTAMP", "EBT_CASHBENEFIT", "GIFT", "LOYALTY", "CASH", "EBT"}
    'Private TRANS_TYPE() As String = {"UNKNOWN", "AUTH", "SALE", "RETURN", "VOID", "POSTAUTH", "FORCEAUTH", "ADJUST", "INQUIRY", "ACTIVATE", "DEACTIVATE", "RELOAD", "VOID SALE", "VOID RETURN", "VOID AUTH", "VOID POSTAUTH", "VOID FORCEAUTH", "VOID WITHDRAWAL", "REVERSAL", "WITHDRAWAL", "ISSUE", "CASHOUT", "REPLACE", "MERGE", "REPORTLOST", "REDEEM", "VERIFY", "REACTIVATE", "FORCE ISSUE", "FORCE ADD", "UNLOAD", "RENEW"}

    'Private Sub btnProcessTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessTransaction.Click
    '    Try
    '        Dim posl As POSLink.PosLink = New POSLink.PosLink()

    '        Dim payRequest As PaymentRequest = New PaymentRequest()  ' Setup a request object.

    '        Dim com1 As CommSetting = New CommSetting()
    '        '  use uart to communicate
    '        'com1.CommType = "UART"
    '        'com1.SerialPort = "COM16"
    '        'com1.TimeOut = "50000"
    '        'posl.CommSetting = com1
    '        '  use tcp to communicate
    '        com1.CommType = "TCP"
    '        com1.DestIP = "127.0.0.1"
    '        com1.DestPort = "10009"
    '        com1.TimeOut = "50000"
    '        posl.CommSetting = com1

    '        payRequest.TenderType = payRequest.ParseTenderType(cboCreditCardType.SelectedItem)
    '        payRequest.TransType = payRequest.ParseTransType(cboTransactionType.SelectedItem)
    '        payRequest.OrigRefNum = "MyOrderID"
    '        payRequest.ECRRefNum = txtRefID.Text
    '        payRequest.Amount = txtAmount.Text



    '        posl.PaymentRequest = payRequest

    '        Dim result As ProcessTransResult = posl.ProcessTrans() '// Blocking call, will return when the transaction is complete.



    '        ' There will be 2 separate results that you must handle.  First is the ProcessTransResult, this will give you the result of the 
    '        ' request to call poslink.  PaymentResponse should only be checked if ShowPageResult.Code == OK.  
    '        ' PaymentResponse is the result of the financial transaction to the payment server.
    '        Select Case (result.Code)

    '            Case ProcessTransResultCode.OK
    '                Dim r As PaymentResponse = posl.PaymentResponse

    '                MessageBox.Show("ResultCode : " + r.ResultCode + vbCrLf + "ResultTxt :" + r.ResultTxt + vbCrLf + "ExtData :" + r.ExtData, result.Msg)

    '            Case ProcessTransResultCode.ERROR
    '                MessageBox.Show(result.Msg, "Error Processing Payment")

    '            Case Else
    '                MessageBox.Show("Action Timeout.")

    '        End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Try
    '        Dim posl As POSLink.PosLink = New POSLink.PosLink()

    '        Dim payRequest As PaymentRequest = New PaymentRequest()  ' Setup a request object.

    '        Dim com1 As CommSetting = New CommSetting()
    '        '  use uart to communicate
    '        'com1.CommType = "UART"
    '        'com1.SerialPort = "COM16"
    '        'com1.TimeOut = "50000"
    '        'posl.CommSetting = com1
    '        '  use tcp to communicate
    '        'com1.CommType = "TCP"
    '        'com1.DestIP = "127.0.0.1"
    '        'com1.DestPort = "10009"
    '        'com1.TimeOut = "50000"
    '        'posl.CommSetting = com1

    '        payRequest.TenderType = payRequest.ParseTenderType(cboCreditCardType.SelectedItem)
    '        payRequest.TransType = payRequest.ParseTransType(cboTransactionType.SelectedItem)
    '        payRequest.ECRRefNum = txtRefID.Text
    '        payRequest.Amount = txtAmount.Text



    '        posl.PaymentRequest = payRequest

    '        Dim result As ProcessTransResult = posl.ProcessTrans() '// Blocking call, will return when the transaction is complete.



    '        ' There will be 2 separate results that you must handle.  First is the ProcessTransResult, this will give you the result of the 
    '        ' request to call poslink.  PaymentResponse should only be checked if ShowPageResult.Code == OK.  
    '        ' PaymentResponse is the result of the financial transaction to the payment server.
    '        Select Case (result.Code)

    '            Case ProcessTransResultCode.OK
    '                Dim r As PaymentResponse = posl.PaymentResponse
    '                MessageBox.Show("ResultCode : " + r.ResultCode + vbCrLf + "ResultTxt :" + r.ResultTxt + vbCrLf + "ExtData :" + r.ExtData, result.Msg)

    '            Case ProcessTransResultCode.ERROR
    '                MessageBox.Show(result.Msg, "Error Processing Payment")

    '            Case Else
    '                MessageBox.Show("Action Timeout.")

    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub frm_Test_ProcessCreditcard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        cboCreditCardType.Items.Clear()
    '        cboTransactionType.Items.Clear()

    '        cboCreditCardType.Items.AddRange(CARD_TYPES.ToArray)
    '        cboTransactionType.Items.AddRange(TRANS_TYPE.ToArray)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
End Class