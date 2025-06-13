Imports System.Data.SqlClient
Imports System.Drawing
Imports System.ComponentModel
Imports AviatCom_Lib.AviatCom_Lib

Public Class frm_TaskDetail
    Private sFollowupType As String = ""
    Private sEmployeeID As String = ""

    Private Sub frm_TaskDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim arrTemp() As String = Nothing
            If sFollowupType.ToUpper = "CUSTOMER" Then
                ReDim arrTemp(4)
                arrTemp(0) = "Follow_Up"
                arrTemp(1) = "Processing"
                arrTemp(2) = "Opened"
                arrTemp(3) = "Completed"
                arrTemp(4) = "Lost_Customer"
            ElseIf sFollowupType.ToUpper = "MERCHANT" Then
                ReDim arrTemp(2)
                arrTemp(0) = "Active"
                arrTemp(1) = "Cancel"
                arrTemp(2) = "Rewrite"
            Else
                ReDim arrTemp(1)
                arrTemp(0) = "Open"
                arrTemp(1) = "Done"
            End If
            cboStatus.Items.AddRange(arrTemp)

        Catch exp As Exception
            LogToSystemEvent(gsApplicationClientID, Me.Name, _
            gsApplicationClientID & vbNewLine & Me.Name & " - frm_TaskDetail_Load: " & vbNewLine & exp.StackTrace & vbNewLine & vbNewLine & exp.ToString, "Error")
            MessageBox.Show(exp.ToString)
        End Try
    End Sub
End Class