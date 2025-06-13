Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Module Global_Reports
    Friend Sub Report_SalesOrder(ByVal sOrderID As String, ByVal sCustomerID As String, Optional ByVal bWithItemCode As Boolean = False)
        Try
            Using dSet As New DataSet
                'Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                '                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                '                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                '                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                '                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                '                                                    " ,Contact_ShipTo,CONVERT(VARCHAR(20),OrderDate,101),InvoiceDate,CostAmount,DiscountAmount * -1 AS 'DiscountAmount' " &
                '                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,RequiredShipDate " &
                '                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                '                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                '                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                '                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate " &
                '                                                    " , TotalTax "), " WHERE  OrderID = '" & sOrderID & "'")

                Using dt_Order As DataTable = SQL_QueryGetTableResult("SELECT tb_Order.ID,tb_Order.OrderID,tb_Order.InvoiceNumber,tb_Order.CustomerPo,tb_Order.CustomerID " &
                                                                    " ,tb_Order.InputerID,tb_Order.SalesID,tb_Order.DriverID,tb_Order.Company_BillTo,tb_Order.Address_BillTo " &
                                                                    " ,tb_Order.Address_2_BillTo,tb_Order.City_BillTo,tb_Order.State_BillTo,tb_Order.ZipCode_BillTo,tb_Order.Phone_BillTo " &
                                                                    " ,tb_Order.Fax_BillTo,tb_Order.Contact_BillTo,tb_Order.Company_ShipTo,tb_Order.Address_ShipTo,tb_Order.Address_2_ShipTo " &
                                                                    " ,tb_Order.City_ShipTo,tb_Order.State_ShipTo,tb_Order.ZipCode_ShipTo,tb_Order.Phone_ShipTo,tb_Order.Fax_ShipTo " &
                                                                    " ,tb_Order.Contact_ShipTo,CONVERT(VARCHAR(20),tb_Order.OrderDate,101),tb_Order.InvoiceDate,tb_Order.CostAmount,tb_Order.DiscountAmount  AS 'DiscountAmount' " &
                                                                    " ,tb_Order.DiscountPercentage,tb_Order.SubTotal,tb_Order.Amount,tb_Order.DeliveryCharge,CONVERT(VARCHAR(20),tb_Order.RequiredShipDate,101) " &
                                                                    " ,tb_Order.TotalCase,tb_Order.TotalLossCase,tb_Order.Balance,tb_Order.PaidAmount,tb_Order.PaymentStatus " &
                                                                    " ,tb_Order.ShippingInstruction,tb_Order.Remark,tb_Order.Remark_Display,tb_Order.TermID,tb_Order.isRetail " &
                                                                    " ,tb_Order.isReleased,tb_Order.ReleasedDatetime,tb_Order.isPosted,tb_Order.PostDatetime,tb_Order.IsVoid " &
                                                                    " ,tb_Order.VoidDate,tb_Order.VoidEmployeeID,tb_Order.DueDate,tb_Order.Location,tb_Order.PaymentDate " &
                                                                    " , tb_Order.TotalTax,tb_Order.BottleDepositAmount,tb_Order.LicenseNumber,tb_Customer.TaxID " &
                                                                    " FROM tb_Order WITH (NOLOCK) " &
                                                                    " INNER JOIN tb_Customer WITH (NOLOCK) " &
                                                                    " ON tb_Order.CustomerID = tb_Customer.CustomerID " &
                                                                    " WHERE  tb_Order.OrderID = '" & sOrderID & "' ORDER BY ID")
                    Using dt_OrderDetails As DataTable = SQL_QueryGetTableResult(" SELECT  tb_OrderDetails.ID,tb_OrderDetails.OrderID,tb_OrderDetails.ProductID,tb_OrderDetails.Unit,tb_OrderDetails.UnitPrice  " &
                                                                                " ,tb_OrderDetails.StandardPrice,tb_OrderDetails.Cost,tb_OrderDetails.OrderQTY,tb_OrderDetails.ShipQTY,tb_OrderDetails.isDiscount " &
                                                                                " ,tb_OrderDetails.DiscountPercentage ,tb_OrderDetails.CreateDate,tb_OrderDetails.LastUpdate,UPPER(tb_OrderDetails.ProductID),(tb_OrderDetails.BottleDepositAmount * tb_OrderDetails.SubUnitQTY ) * tb_OrderDetails.ShipQTY AS 'BottleDepositAmount' " &
                                                                                " , (tb_OrderDetails.BottleDepositAmount * tb_OrderDetails.SubUnitQTY ) AS 'UnitBottleDepositAmount',CASE WHEN tb_Product.IsCommission <> 0 THEN tb_OrderDetails.OrderQTY ELSE 0 END AS 'CommissionQTY',tb_OrderDetails.ItemCode " &
                                                                                " FROM tb_OrderDetails  WITH (NOLOCK) LEFT JOIN tb_Product WITH (NOLOCK) ON tb_OrderDetails.ProductID = tb_Product.ProductID " &
                                                                                " WHERE OrderID = '" & sOrderID & "' ORDER BY ID")
                        Using dt_Order_UnpayStatement As DataTable = SQL_QueryGetTableResult("SELECT CustomerID ,Company_BillTo, CONVERT(VARCHAR(20),RequiredShipDate,101),OrderID,Amount,Balance " &
                                                                      " FROM tb_Order WITH (NOLOCK) WHERE CustomerID LIKE '" & sCustomerID.Replace("'", "''") & "' AND Balance >0 Order By RequiredShipDate ")

                            dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                            dSet.Tables.Add(dt_Order)
                            dSet.Tables.Add(dt_OrderDetails)
                            dSet.Tables.Add(dt_Order_UnpayStatement)
                            Using frm As New frmReport
                                frm.SetReportName = IIf(bWithItemCode, "SALESORDER_WITHITEMCODE", "SALESORDER")
                                frm.SetReportDataSet = dSet
                                frm.ShowDialog()
                                frm.Dispose()
                            End Using
                        End Using

                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_SalesOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_SalesOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub

    Friend Sub Report_POS_SalesOrder(ByVal sOrderID As String, ByVal bDisplayOnly As Boolean)
        Try
            Using dSet As New DataSet
                'Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                '                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                '                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                '                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                '                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                '                                                    " ,Contact_ShipTo,OrderDate,InvoiceDate,CostAmount,DiscountAmount " &
                '                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,RequiredShipDate " &
                '                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                '                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                '                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                '                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate "), " WHERE  OrderID = '" & sOrderID & "'")
                '    Using dt_OrderDetails As DataTable = SQL_GetTableColumns("tb_OrderDetails", GetParam(" ID,OrderID,ProductID,Unit,UnitPrice " &
                '                                                                " ,Cost,OrderQTY,ShipQTY,isDiscount,DiscountPercentage " &
                '                                                                " ,CreateDate,LastUpdate,StandardPrice "), " WHERE OrderID = '" & sOrderID & "'")

                Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                                                                   " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                                                                   " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                                                                   " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                                                                   " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                                                                   " ,Contact_ShipTo,CONVERT(VARCHAR(20),OrderDate,101),InvoiceDate,CostAmount,DiscountAmount * -1 AS 'DiscountAmount' " &
                                                                   " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,RequiredShipDate " &
                                                                   " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                                                                   " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                                                                   " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                                                                   " ,VoidDate,VoidEmployeeID,DueDate,Location, TotalTax " &
                                                                   " ,PaymentDate,RetailCustomerPaidAmount,RetailCustomerPaidAmount - Amount AS 'Change' , PaymentType,BottleDepositAmount "), " WHERE  OrderID = '" & sOrderID & "'")
                    Using dt_OrderDetails As DataTable = SQL_QueryGetTableResult(" SELECT  tb_OrderDetails.ID,tb_OrderDetails.OrderID,tb_OrderDetails.ProductID,tb_OrderDetails.Unit,tb_OrderDetails.UnitPrice  " &
                                                                                " ,tb_OrderDetails.StandardPrice,tb_OrderDetails.Cost,tb_OrderDetails.OrderQTY,tb_OrderDetails.ShipQTY,tb_OrderDetails.isDiscount " &
                                                                                " ,tb_OrderDetails.DiscountPercentage ,tb_OrderDetails.CreateDate,tb_OrderDetails.LastUpdate,tb_Product.DisplayOnReceipt,(tb_OrderDetails.BottleDepositAmount * tb_OrderDetails.SubUnitQTY ) * tb_OrderDetails.ShipQTY AS 'ItemTotalAmount' " &
                                                                                " , (tb_OrderDetails.BottleDepositAmount * tb_OrderDetails.SubUnitQTY ) AS 'SaleUnitBottleDeposit'" &
                                                                                " FROM tb_OrderDetails  WITH (NOLOCK) LEFT JOIN tb_Product WITH (NOLOCK) ON tb_OrderDetails.ProductID = tb_Product.ProductID " &
                                                                                " WHERE OrderID = '" & sOrderID & "'")

                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_Order)
                        dSet.Tables.Add(dt_OrderDetails)
                        Using frm As New frmReport
                            frm.SetReportName = "POS_SALESORDER"
                            frm.SetReportDataSet = dSet
                            frm.SetDisplayOnly = StrEmployeeInformation.POS_Printer_NotAvailable
                            If StrEmployeeInformation.POS_Printer_NotAvailable Then
                                frm.ShowDialog()
                            Else
                                frm.Show()
                            End If

                            'frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            'If gbDebugDisplayMSG Then MessageBox.Show("Error Report_POS_SalesOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_POS_SalesOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_Management_SalesOrder(dtDateFrom As Date, dtDateTo As Date)
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                                                                    " ,Contact_ShipTo,OrderDate,InvoiceDate,CostAmount,DiscountAmount " &
                                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,RequiredShipDate " &
                                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate " &
                                                                    " ,BottleDepositAmount "), " WHERE  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59'")
                    Using dt_OrderDetails As DataTable = SQL_GetTableColumns("tb_OrderDetails", GetParam(" ID,OrderID,ProductID,Unit,UnitPrice " &
                                                                                " ,Cost,OrderQTY,ShipQTY,isDiscount,DiscountPercentage " &
                                                                                " ,CreateDate,LastUpdate,StandardPrice,SubUnitQTY,CASE WHEN isCommission = 0 THEN 0 ELSE OrderQTY END "), " WHERE OrderID IN ( SELECT OrderID FROM tb_Order WITH (NOLOCK) WHERE  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59')")
                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_Order)
                        dSet.Tables.Add(dt_OrderDetails)
                        Using frm As New frmReport
                            frm.SetReportName = "MANAGEMENT_SALESORDER"
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_Management_SalesOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_Management_SalesOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_Management_SalesPerformanceReport(dtDateFrom As Date, dtDateTo As Date, iSalesID As Integer)
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                                                                    " ,Contact_ShipTo,CONVERT(VARCHAR(20),OrderDate,101),InvoiceDate,CostAmount,DiscountAmount " &
                                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,CONVERT(VARCHAR(20),RequiredShipDate,101) " &
                                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate " &
                                                                    " ,BottleDepositAmount "), " WHERE SalesID = " & iSalesID & " AND  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59'")
                    Using dt_OrderDetails As DataTable = SQL_GetTableColumns("tb_OrderDetails", GetParam(" ID,OrderID,ProductID,Unit,UnitPrice " &
                                                                                " ,Cost,OrderQTY,ShipQTY,isDiscount,DiscountPercentage " &
                                                                                " ,CreateDate,LastUpdate,StandardPrice,SubUnitQTY,CASE WHEN isCommission = 0 THEN 0 ELSE OrderQTY END "), " WHERE OrderID IN ( SELECT OrderID FROM tb_Order WITH (NOLOCK) WHERE SalesID = " & iSalesID & " AND  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59')")
                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_Order)
                        dSet.Tables.Add(dt_OrderDetails)
                        Using frm As New frmReport
                            frm.SetReportName = "MANAGEMENT_SALESPERFORMANCEORDER"
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_Management_SalesOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_Management_SalesOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_Management_SalesPerformanceReportWithDetail(ByVal dtDateFrom As Date, ByVal dtDateTo As Date, ByVal iSalesID As Integer)
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                                                                    " ,Contact_ShipTo,CONVERT(VARCHAR(20),OrderDate,101),InvoiceDate,CostAmount,DiscountAmount " &
                                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,CONVERT(VARCHAR(20),RequiredShipDate,101) " &
                                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate " &
                                                                    " ,BottleDepositAmount "), " WHERE SalesID = " & iSalesID & " AND  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59'")
                    Using dt_OrderDetails As DataTable = SQL_GetTableColumns("tb_OrderDetails", GetParam(" ID,OrderID,ProductID,Unit,UnitPrice " &
                                                                                " ,Cost,OrderQTY,ShipQTY,isDiscount,DiscountPercentage " &
                                                                                " ,CreateDate,LastUpdate,StandardPrice,SubUnitQTY,CASE WHEN isCommission = 0 THEN 0 ELSE OrderQTY END "), " WHERE OrderID IN ( SELECT OrderID FROM tb_Order WITH (NOLOCK) WHERE SalesID = " & iSalesID & " AND  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59')")
                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_Order)
                        dSet.Tables.Add(dt_OrderDetails)
                        Using frm As New frmReport
                            frm.SetReportName = "MANAGEMENT_SALESPERFORMANCEORDER_WITHDETAIL"
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_Management_SalesPerformanceReportWithDetail")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_Management_SalesPerformanceReportWithDetail - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_Management_ExpenseTransaction(ByVal dtDateFrom As Date, ByVal dtDateTo As Date)
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_QueryGetTableResult(" SELECT TransactionID,TransactionName,CONVERT(VARCHAR(20),TransactionDate,101),TransactionDescription,AccountName " &
                                                                        " ,Credit,Debit,isTaxable,Inputer,Amount " &
                                                                        " ,Createtime " &
                                                                        " FROM tb_System_Accounting_Transaction WITH (NOLOCK) " &
                                                                        "  WHERE  TransactionDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59'")

                    dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                    dSet.Tables.Add(dt_Order)
                    Using frm As New frmReport
                        frm.SetReportName = "MANAGEMENT_EXPENSETRANSACTION"
                        frm.SetDisplayReportDate = dtDateFrom.ToShortDateString & " - " & dtDateTo.ToShortDateString
                        frm.SetReportDataSet = dSet
                        frm.ShowDialog()
                        frm.Dispose()
                    End Using
                End Using
            End Using

        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_Management_SalesOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_Management_SalesOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_Purchasing_PurchaseOrder(sPurchaseOrderID As String)
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_QueryGetTableResult(" SELECT PurchaseID,VenderID,VenderID_Company,VenderID_Address,VenderID_Address_2 " &
                                                                                        " ,VenderID_City,VenderID_State,VenderID_ZipCode,VenderID_Phone,VenderID_Fax " &
                                                                                        " ,VenderID_Contact,CONVERT(VARCHAR(20),ExpectedDeliveryDate,101) AS 'ExpectedDeliveryDate',PreviousOrderedPrice " &
                                                                                        " ,TotalAmount,ReceivingDate,InputerID,isPosted,IsVoid " &
                                                                                        " ,VoidDate,VoidEmployeeID,Remark,Remark_Display,CreateDate " &
                                                                                        " ,LastUpdate FROM tb_Purchase WITH (NOLOCK)  WHERE  PurchaseID = '" & sPurchaseOrderID & "'")
                    Using dt_OrderDetails As DataTable = SQL_QueryGetTableResult(" SELECT PurchaseID,ProductID,Unit,OrderQTY,SubUnitQTY " &
                                                                                " ,Price,BottleDepositAmount * SubUnitQTY as 'BottleDepositAmount',PreviousOrderedPrice,Price * OrderQTY AS 'ItemTotalAmount',(BottleDepositAmount * SubUnitQTY) * OrderQTY AS 'ItemTotalDeposit' " &
                                                                                " FROM tb_PurchaseDetails WITH (NOLOCK)  WHERE PurchaseID = '" & sPurchaseOrderID & "'")
                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_Order)
                        dSet.Tables.Add(dt_OrderDetails)
                        Using frm As New frmReport
                            frm.SetReportName = "PURCHASE_ORDER"
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_SalesOrder")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_SalesOrder - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_CustomerService_SalesHistory(dtDateFrom As Date, dtDateTo As Date, Optional sCustomerID As String = "%")
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                                                                    " ,Contact_ShipTo,CONVERT(VARCHAR(20),OrderDate,101) AS 'OrderDate',InvoiceDate,CostAmount,DiscountAmount " &
                                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,RequiredShipDate " &
                                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate " &
                                                                    " ,TotalTax,BottleDepositAmount "), " WHERE  OrderDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59' AND CustomerID LIKE '" & sCustomerID & "'")

                    dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                    dSet.Tables.Add(dt_Order)
                    Using frm As New frmReport
                        frm.SetReportName = "CUSTOMERSERVICE_ORDERHISTORY"
                        frm.SetReportDataSet = dSet
                        frm.ShowDialog()
                        frm.Dispose()
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_CustomerService_SalesHistory")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_CustomerService_SalesHistory - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_CustomerService_PaymentHistory(dtDateFrom As Date, dtDateTo As Date, Optional sCustomerID As String = "%")
        Try
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_GetTableColumns("tb_Order", GetParam(" ID,OrderID,InvoiceNumber,CustomerPo,CustomerID " &
                                                                    " ,InputerID,SalesID,DriverID,Company_BillTo,Address_BillTo " &
                                                                    " ,Address_2_BillTo,City_BillTo,State_BillTo,ZipCode_BillTo,Phone_BillTo " &
                                                                    " ,Fax_BillTo,Contact_BillTo,Company_ShipTo,Address_ShipTo,Address_2_ShipTo " &
                                                                    " ,City_ShipTo,State_ShipTo,ZipCode_ShipTo,Phone_ShipTo,Fax_ShipTo " &
                                                                    " ,Contact_ShipTo,OrderDate,InvoiceDate,CostAmount,DiscountAmount " &
                                                                    " ,DiscountPercentage,SubTotal,Amount,DeliveryCharge,RequiredShipDate " &
                                                                    " ,TotalCase,TotalLossCase,Balance,PaidAmount,PaymentStatus " &
                                                                    " ,ShippingInstruction,Remark,Remark_Display,TermID,isRetail " &
                                                                    " ,isReleased,ReleasedDatetime,isPosted,PostDatetime,IsVoid " &
                                                                    " ,VoidDate,VoidEmployeeID,DueDate,Location,PaymentDate "), " WHERE  PaymentDate BETWEEN '" & dtDateFrom.ToShortDateString & "' AND '" & dtDateTo.ToShortDateString & " 23:59:59' AND CustomerID LIKE '" & sCustomerID & "'")

                    dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                    dSet.Tables.Add(dt_Order)
                    Using frm As New frmReport
                        frm.SetReportName = "CUSTOMERSERVICE_PAYMENTHISTORY"
                        frm.SetReportDataSet = dSet
                        frm.ShowDialog()
                        frm.Dispose()
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_CustomerService_PaymentHistory")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_CustomerService_PaymentHistory - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_Order_KegPurchaserAffirmation(ByVal iOrderLineNumber As Integer, ByVal sProductID As String, ByVal sProductSize As String, ByVal dKegPrice As Decimal, ByVal dTubPrice As Decimal, _
                                                    ByVal sIDType As String, ByVal sIDState As String, ByVal sIDNumber As String, ByVal sFirstName As String, ByVal sLastName As String, _
                                                    ByVal sAddress As String, ByVal sCity As String, ByVal sState As String, ByVal sZipCode As String, ByVal dtExpiredDate As Date, _
                                                    ByVal dtDOB As String, ByVal sOrderID As String, ByVal dPrice As Decimal, ByVal sBrand As String)
        Try
            If SQL_QueryCheckRecordExsits("SELECT ID FROM tb_KegPurchaserAffirmation WITH (NOLOCK) WHERE OrderID = '" & sOrderID & "' AND OrderLineNumber = " & iOrderLineNumber) = 0 Then
                SQL_ExecuteSP(" INSERT INTO tb_KegPurchaserAffirmation " &
                                " (OrderLineNumber,OrderID,ProductID,ProductSize,KegPrice " &
                                " ,TubPrice,IDType,IDState,IDNumber,FirstName " &
                                " ,LastName,Address,City,State,Zipcode " &
                                " , ExpirationDate,DateOfBrith,Price ,Brand) VALUES ( " &
                                iOrderLineNumber & ",'" & sOrderID & "','" & sProductID & "','" & sProductSize & "'," & dKegPrice &
                                "," & dTubPrice & ",'" & sIDType & "','" & sIDState & "','" & sIDNumber & "','" & sFirstName & "'" &
                                ", '" & sLastName & "','" & sAddress & "','" & sCity & "','" & sState & "','" & sZipCode & "'" &
                                ", '" & dtExpiredDate & "','" & dtDOB & "', " & dPrice & ",'" & sBrand & "')")
            Else
                SQL_ExecuteSP(" UPDATE tb_KegPurchaserAffirmation " &
                                " SET OrderLineNumber =  " & iOrderLineNumber &
                                " ,OrderID =  '" & sOrderID & "'" &
                                " ,ProductID =  '" & sProductID & "'" &
                                " ,ProductSize =  '" & sProductSize & "'" &
                                " ,KegPrice =  " & Val(dKegPrice) &
                                " ,TubPrice =  " & Val(dTubPrice) &
                                " ,IDType =  '" & sIDType & "'" &
                                " ,IDState =  '" & sIDState & "'" &
                                " ,IDNumber =  '" & sIDNumber & "'" &
                                " ,FirstName =  '" & sFirstName & "'" &
                                " ,LastName =  '" & sLastName & "'" &
                                " ,Address =  '" & sAddress & "'" &
                                " ,City =  '" & sCity & "'" &
                                " ,State = '" & sState & "'" &
                                " ,Zipcode =  '" & sZipCode & "'" &
                                " ,ExpirationDate =  '" & dtExpiredDate & "'" &
                                " ,DateOfBrith = '" & dtDOB & "'" &
                                " ,Price =  " & dPrice &
                                " ,Brand = '" & sBrand & "'" &
                                " WHERE OrderID = '" & sOrderID & "' AND OrderLineNumber = " & iOrderLineNumber)

            End If
            Using dSet As New DataSet
                Using dt_Order As DataTable = SQL_QueryGetTableResult(" SELECT OrderLineNumber,OrderID,ProductID,ProductSize,KegPrice " &
                                                                        " ,TubPrice,IDType,IDState,IDNumber,FirstName " &
                                                                        " ,LastName,Address,City,State,Zipcode " &
                                                                        " , ExpirationDate,DateOfBrith,Price,CreateDate,Brand  " &
                                                                        " FROM tb_KegPurchaserAffirmation WITH (NOLOCK) WHERE OrderID = '" & sOrderID & "' AND OrderLineNumber = " & iOrderLineNumber)
                    dSet.Tables.Add(dt_Order)
                    Using frm As New frmReport
                        frm.SetReportName = "ORDER_KEGPURCHASERAFFIRMATION"
                        frm.SetReportDataSet = dSet
                        frm.ShowDialog()
                        frm.Dispose()
                    End Using
                End Using

            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_CustomerService_PaymentHistory")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_CustomerService_PaymentHistory - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_WholesaleSummary(ByVal dtDateFrom As Date, ByVal dtDateTo As Date)
        Try
            Using dSet As New DataSet
                Using dt_SaleSummary As DataTable = SQL_QueryGetTableResult(" Select ProductType " &
                                                                        " ,SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) AS 'TotalAmount'  " &
                                                                        " ,SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)) AS 'TotalCost'  " &
                                                                        " , SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) - SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)) AS 'GR_Prof' " &
                                                                        " ,CEILING(((SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) - SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)))/SUM(tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) *1000)/10 AS 'GP%' " &
                                                                        " ,SUM((tb_OrderDetails.BottleDepositAmount * tb_Product.UnitQTY) * tb_OrderDetails.OrderQTY) AS 'TotalDeposit' " &
                                                                        " ,SUM( tb_Product.UnitQTY * tb_OrderDetails.OrderQTY) AS 'TotalSubUnit' " &
                                                                        " FROM tb_OrderDetails WITH (NOLOCK) " &
                                                                        " LEFT JOIN tb_Product WITH (NOLOCK) " &
                                                                        " ON tb_OrderDetails.ProductID = tb_Product.ProductID " &
                                                                        " LEFT JOIN tb_Order WITH (NOLOCK) " &
                                                                        " ON tb_OrderDetails.OrderID = tb_Order.OrderID  " &
                                                                        " WHERE tb_Order.OrderDate BETWEEN '" & dtDateFrom & "' AND '" & dtDateTo & " 23:59:59' " &
                                                                        " AND tb_Order.isRetail=0 " &
                                                                        " AND  tb_OrderDetails.OrderQTY <> 0 " &
                                                                        " AND tb_OrderDetails.UnitPrice <>0 " &
                                                                        " AND tb_Order.IsVoid =0 " &
                                                                        " GROUP BY ProductType ")

                    dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                    dSet.Tables.Add(dt_SaleSummary)
                    Using frm As New frmReport
                        frm.SetReportName = "WHOLESALE_SUMMARY"
                        frm.SetDisplayReportDate = dtDateFrom.ToShortDateString & " - " & dtDateTo.ToShortDateString
                        frm.SetReportDataSet = dSet
                        frm.ShowDialog()
                        frm.Dispose()
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_WholesaleSummary")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_WholesaleSummary - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_RetailSaleSummary(ByVal dtDateFrom As Date, ByVal dtDateTo As Date)
        Try
            Using dSet As New DataSet
                Using dt_SaleSummary As DataTable = SQL_QueryGetTableResult(" Select ProductType " &
                                                                        " ,SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) AS 'TotalAmount'  " &
                                                                        " ,SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)) AS 'TotalCost'  " &
                                                                        " , SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) - SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)) AS 'GR Prof' " &
                                                                        " ,CEILING(((SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) - SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)))/SUM(tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) *1000)/10 AS 'GP %' " &
                                                                        " ,SUM((tb_OrderDetails.BottleDepositAmount * tb_Product.UnitQTY) * tb_OrderDetails.OrderQTY) AS 'TotalDeposit' " &
                                                                        " ,SUM( tb_Product.UnitQTY * tb_OrderDetails.OrderQTY) AS 'TotalSubUnit' " &
                                                                        " FROM tb_OrderDetails WITH (NOLOCK) " &
                                                                        " LEFT JOIN tb_Product WITH (NOLOCK) " &
                                                                        " ON tb_OrderDetails.ProductID = tb_Product.ProductID " &
                                                                        " LEFT JOIN tb_Order WITH (NOLOCK) " &
                                                                        " ON tb_OrderDetails.OrderID = tb_Order.OrderID  " &
                                                                        " WHERE tb_Order.PostDatetime BETWEEN '" & dtDateFrom & "' AND '" & dtDateTo & " 23:59:59' " &
                                                                        " and tb_Order.isRetail<>0 " &
                                                                        " AND  tb_OrderDetails.OrderQTY <> 0 " &
                                                                        " AND tb_OrderDetails.UnitPrice <>0 " &
                                                                        " AND tb_Order.IsVoid =0 " &
                                                                        " GROUP BY ProductType ")
                    Using dt_RetailTransactionSummary As DataTable = SQL_QueryGetTableResult(" SELECT Inputer,PaymentType,SUM(PaidAmount) AS 'TotalReceivedAmount' " &
                                                                                                " FROM tb_Payment WITH (NOLOCK) " &
                                                                                                " where IsVoid = 0  and isRetail <> 0 and CreateDate BETWEEN '" & dtDateFrom & "' AND '" & dtDateTo & " 23:59:59' " &
                                                                                                " GROUP BY PaymentType ,Inputer ORDER BY Inputer,PaymentType ")






                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_SaleSummary)
                        dSet.Tables.Add(dt_RetailTransactionSummary)
                        Using frm As New frmReport
                            frm.SetReportName = "RETAILSALE_SUMMARY"
                            frm.SetDisplayReportDate = dtDateFrom.ToShortDateString & " - " & dtDateTo.ToShortDateString
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_WholesaleSummary")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_WholesaleSummary - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_WholeSaleEOFSummary(ByVal dtDateFrom As Date, ByVal dtDateTo As Date)
        Try
            Using dSet As New DataSet
                Using dt_SaleSummary As DataTable = SQL_QueryGetTableResult(" Select ProductType " &
                                                                        " ,SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) AS 'TotalAmount'  " &
                                                                        " ,SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)) AS 'TotalCost'  " &
                                                                        " , SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) - SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)) AS 'GR Prof' " &
                                                                        " ,CEILING(((SUM((tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) - SUM((tb_OrderDetails.Cost*tb_OrderDetails.OrderQTY)))/SUM(tb_OrderDetails.UnitPrice*tb_OrderDetails.OrderQTY)) *1000)/10 AS 'GP %' " &
                                                                        " ,SUM((tb_OrderDetails.BottleDepositAmount * tb_Product.UnitQTY) * tb_OrderDetails.OrderQTY) AS 'TotalDeposit' " &
                                                                        " ,SUM( tb_Product.UnitQTY * tb_OrderDetails.OrderQTY) AS 'TotalSubUnit' " &
                                                                        " FROM tb_OrderDetails WITH (NOLOCK) " &
                                                                        " LEFT JOIN tb_Product WITH (NOLOCK) " &
                                                                        " ON tb_OrderDetails.ProductID = tb_Product.ProductID " &
                                                                        " LEFT JOIN tb_Order WITH (NOLOCK) " &
                                                                        " ON tb_OrderDetails.OrderID = tb_Order.OrderID  " &
                                                                        " WHERE tb_Order.PostDatetime BETWEEN '" & dtDateFrom & "' AND '" & dtDateTo & " 23:59:59' " &
                                                                        " and tb_Order.isRetail=0 " &
                                                                        " AND  tb_OrderDetails.OrderQTY <> 0 " &
                                                                        " AND tb_OrderDetails.UnitPrice <>0 " &
                                                                        " AND tb_Order.IsVoid =0 " &
                                                                        " GROUP BY ProductType ")
                    Using dt_RetailTransactionSummary As DataTable = SQL_QueryGetTableResult(" SELECT Inputer,PaymentType,SUM(PaidAmount) AS 'TotalReceivedAmount' " &
                                                                                                " FROM tb_Payment WITH (NOLOCK) " &
                                                                                                " where IsVoid = 0  and isRetail = 0 and CreateDate BETWEEN '" & dtDateFrom & "' AND '" & dtDateTo & " 23:59:59' " &
                                                                                                " GROUP BY PaymentType ,Inputer ORDER BY Inputer,PaymentType ")






                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_SaleSummary)
                        dSet.Tables.Add(dt_RetailTransactionSummary)
                        Using frm As New frmReport
                            frm.SetReportName = "WHOLESALE_EOF_SUMMARY"
                            frm.SetDisplayReportDate = dtDateFrom.ToShortDateString & " - " & dtDateTo.ToShortDateString
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_WholesaleSummary")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_WholesaleSummary - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Friend Sub Report_SalesOrder_UnpayStatement(Optional ByVal sCustomerID As String = "%")
        Try
            Using dSet As New DataSet

                Using dt_Order As DataTable = SQL_QueryGetTableResult("SELECT CustomerID AS 'Cust ID',Company_BillTo AS 'Company', CONVERT(VARCHAR(20),RequiredShipDate,101) AS 'Ship Date',OrderID AS 'Order ID',Amount,Balance " &
                                                                        " FROM tb_Order WITH (NOLOCK) WHERE CustomerID LIKE '" & sCustomerID.Replace("'", "''") & "' Balance >0 Order By RequiredShipDate ")
                    Using dt_Payment As DataTable = SQL_QueryGetTableResult(" SELECT PaymentID,PaymentType,RefNo,Amount,PaidAmount FROM tb_Payment WITH (NOLOCK) " &
                                                                                    " WHERE RefNo IN (SELECT CAST(OrderID AS VARCHAR(30))FROM tb_Order WITH (NOLOCK) WHERE CustomerID LIKE '" & sCustomerID.Replace("'", "''") & "' AND Balance >0 AND IsVoid = 0 )ORDER BY PaymentID DESC ")
                        dSet.Tables.Add(strSystemConfig.tb_SystemConfig.Copy)
                        dSet.Tables.Add(dt_Order)
                        dSet.Tables.Add(dt_Payment)
                        Using frm As New frmReport
                            frm.SetReportName = "UNPAY_STATEMENT"
                            frm.SetReportDataSet = dSet
                            frm.ShowDialog()
                            frm.Dispose()
                        End Using
                    End Using
                End Using
            End Using
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error Report_SalesOrder_UnpayStatement")
            LogToSystemEvent(gsApplicationClientID, msModuleName, "Report_SalesOrder_UnpayStatement - " & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
End Module
