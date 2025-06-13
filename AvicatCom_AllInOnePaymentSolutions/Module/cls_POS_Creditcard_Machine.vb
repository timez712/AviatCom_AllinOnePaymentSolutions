Imports POSLink
Imports POSLink.PosLink


Public Class cls_POS_Creditcard_Machine
    Friend CARD_TYPES() As String = {"CREDIT", "DEBIT", "CHECK", "EBT_FOODSTAMP", "EBT_CASHBENEFIT", "GIFT", "LOYALTY", "CASH", "EBT"}
    Friend TRANS_TYPE() As String = {"UNKNOWN", "AUTH", "SALE", "RETURN", "VOID", "POSTAUTH", "FORCEAUTH", "ADJUST", "INQUIRY", "ACTIVATE", "DEACTIVATE", "RELOAD", "VOID SALE", "VOID RETURN", "VOID AUTH", "VOID POSTAUTH", "VOID FORCEAUTH", "VOID WITHDRAWAL", "REVERSAL", "WITHDRAWAL", "ISSUE", "CASHOUT", "REPLACE", "MERGE", "REPORTLOST", "REDEEM", "VERIFY", "REACTIVATE", "FORCE ISSUE", "FORCE ADD", "UNLOAD", "RENEW"}

    Friend Enum CardType
        CREDIT = 1
        DEBIT = 2
        CHECK = 3
        EBT_FOODSTAMP = 4
        EBT_CASHBENEFIT = 5
        GIFT = 6
        LOYALTY = 7
        CASH = 8
        EBT = 9
    End Enum
    Friend Enum TransactionType
        UNKNOWN = 0 'Ask the terminal to select transaction type.
        AUTH = 1 'Verify/Authorize a payment. Do not put into the batch.
        SALE = 2 'To make a purchase with a card or Echeck/ACH with a check. Puts card payment into the open batch.
        ReturnPayment = 3 'Returns payment amount to the card open to buy.
        VOID = 4 'Removes a transaction from an unsettled batch.
        POSTAUTH = 5 'Completes an Authorization Only transaction.
        FORCEAUTH = 6 'Forces a transaction into an open batch. Typically used for voice authorizations.
        CAPTURE = 7 ''–U
        REPEATSALE = 8 '–U Performs a repeat sale, using the PnRef, on a previously processed card.
        CAPTUREALL = 9 '–U Performs a settlement or batch close.
        ADJUST = 10 'Adjusts a previously processed transaction. Typically used for tip adjustment
        INQUIRY = 11 'Performs an inquiry to the host. Typically used to obtain the balance on a food stamp card or gift card.
        ACTIVATE = 12 'Activates a payment card. Typically used for gift card activation.
        DEACTIVATE = 13 'Deactivates an active card account. Typically used for gift cards.
        RELOAD = 14 'Adds value to a card account. Typically used for gift cards.
        VOID_SALE = 15
        VOID_RETURN = 16
        VOID_AUTH = 17
        VOID_POSTAUTH = 18
        VOID_FORCEAUTH = 19
        VOID_WITHDRAWAL = 20
        REVERSAL = 21 'Used to for partial auth reversal, not all the host support this feature.
        WITHDRAWAL = 22
        ISSUE = 23
        CASHOUT = 24
    End Enum

    Friend sDestIP As String = ""
    Friend sDestPort As String = "10009"
    Friend sTimeOut As String = "50000"
    Friend sCommType As String = "TCP" 'Use only on Eternet
    Friend Sub TestSample(ByVal cmbCardType As ComboBox, ByVal cmbTransType As ComboBox, ByVal txtRef As TextBox, ByVal txtAmount As TextBox)
        Try
            'Dim posl As POSLink.PosLink = New POSLink.PosLink()
            'Dim payRequest As PaymentRequest = New PaymentRequest()  ' Setup a request object.
            'Dim com1 As CommSetting = New CommSetting()
            ''  use uart to communicate
            ''com1.CommType = "UART"
            ''com1.SerialPort = "COM16"
            ''com1.TimeOut = "50000"
            ''posl.CommSetting = com1
            ''  use tcp to communicate
            ''com1.CommType = "TCP"
            ''com1.DestIP = "127.0.0.1"
            ''com1.DestPort = "10009"
            ''com1.TimeOut = "50000"
            ''posl.CommSetting = com1

            'payRequest.TenderType = payRequest.ParseTenderType(cmbCardType.SelectedItem)
            'payRequest.TransType = payRequest.ParseTransType(cmbTransType.SelectedItem)
            'payRequest.ECRRefNum = txtRef.Text
            'payRequest.Amount = txtAmount.Text

            'posl.PaymentRequest = payRequest

            'Dim result As ProcessTransResult = posl.ProcessTrans() '// Blocking call, will return when the transaction is complete.



            '' There will be 2 separate results that you must handle.  First is the ProcessTransResult, this will give you the result of the 
            '' request to call poslink.  PaymentResponse should only be checked if ShowPageResult.Code == OK.  
            '' PaymentResponse is the result of the financial transaction to the payment server.
            'Select Case (result.Code)

            '    Case ProcessTransResultCode.OK
            '        Dim r As PaymentResponse = posl.PaymentResponse
            '        MessageBox.Show("ResultCode : " + r.ResultCode + vbCrLf + "ResultTxt :" + r.ResultTxt + vbCrLf + "ExtData :" + r.ExtData, result.Msg)

            '    Case ProcessTransResultCode.ERROR
            '        MessageBox.Show(result.Msg, "Error Processing Payment")

            '    Case Else
            '        MessageBox.Show("Action Timeout.")

            'End Select
        Catch ex As Exception

        End Try
    End Sub
    Friend Sub ProcessPayment_CreditCard(ByVal sCardType As CardType, ByVal sTransactionType As TransactionType, ByVal sInvoiceID As String, ByVal iAmount As Integer)
        Try
            'Dim posl As POSLink.PosLink = New POSLink.PosLink()
            'Dim payRequest As PaymentRequest = New PaymentRequest()  ' Setup a request object.
            'Dim com1 As CommSetting = New CommSetting()
            'com1.CommType = sCommType
            'com1.DestIP = sDestIP
            'com1.DestPort = sDestPort
            'com1.TimeOut = sTimeOut
            'posl.CommSetting = com1

            'payRequest.TenderType = payRequest.ParseTenderType(sCardType)
            'payRequest.TransType = payRequest.ParseTransType(sTransactionType)
            'payRequest.InvNum = sInvoiceID
            'payRequest.Amount = iAmount

            'posl.PaymentRequest = payRequest

            'Dim result As ProcessTransResult = posl.ProcessTrans() '// Blocking call, will return when the transaction is complete.



            '' There will be 2 separate results that you must handle.  First is the ProcessTransResult, this will give you the result of the 
            '' request to call poslink.  PaymentResponse should only be checked if ShowPageResult.Code == OK.  
            '' PaymentResponse is the result of the financial transaction to the payment server.
            'Select Case (result.Code)

            '    Case ProcessTransResultCode.OK
            '        Dim r As PaymentResponse = posl.PaymentResponse
            '        MessageBox.Show("ResultCode : " + r.ResultCode + vbCrLf + "ResultTxt :" + r.ResultTxt + vbCrLf + "ExtData :" + r.ExtData, result.Msg)

            '    Case ProcessTransResultCode.ERROR
            '        MessageBox.Show(result.Msg, "Error Processing Payment")

            '    Case Else
            '        MessageBox.Show("Action Timeout.")

            'End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
