Imports System.Data.SqlClient
Imports AviatCom_Lib.AviatCom_Lib
Imports System.Data
Public Class frm_Security_AccessControl
    Private mCmd_GetProfiles As SqlCommand
    Private mCmd_GetProfileAccessCode As SqlCommand
    Private mCmd_GetUsers As SqlCommand
    Private mCmd_GetUserProfile As SqlCommand
    Private mCmd_UpdateProfileAccess As SqlCommand
    Private mCmd_UpdateUserProfile As SqlCommand
    Private bLoading As Boolean = False
    WithEvents MyGrid As AviatCom_DefaultGrid
    WithEvents MyGrid2 As AviatCom_DefaultGrid
    WithEvents MyGrid3 As AviatCom_DefaultGrid

    Private Sub frmAccessControl_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not mCmd_GetProfiles Is Nothing Then mCmd_GetProfiles.Dispose()
        If Not mCmd_GetProfileAccessCode Is Nothing Then mCmd_GetProfileAccessCode.Dispose()
        If Not mCmd_GetUsers Is Nothing Then mCmd_GetUsers.Dispose()
        If Not mCmd_UpdateProfileAccess Is Nothing Then mCmd_UpdateProfileAccess.Dispose()
        If Not mCmd_GetUserProfile Is Nothing Then mCmd_GetUserProfile.Dispose()

        If Not MyGrid Is Nothing Then MyGrid.Dispose()
        If Not MyGrid2 Is Nothing Then MyGrid.Dispose()
        If Not MyGrid3 Is Nothing Then MyGrid.Dispose()
    End Sub
    Private Sub frmAccessControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bLoading = True
            mCmd_GetProfiles = gObjAdo.GetADOCommand("sp_Secuity_GetProfiles")
            mCmd_GetProfileAccessCode = gObjAdo.GetADOCommand("sp_Secuity_GetAccessCode")
            mCmd_UpdateProfileAccess = gObjAdo.GetADOCommand("sp_Secuity_UpdateAccessCode")
            mCmd_UpdateUserProfile = gObjAdo.GetADOCommand("sp_Secuity_UpdateUserProfile")

            mCmd_GetUsers = gObjAdo.GetADOCommand("sp_Secuity_GetUsers")
            mCmd_GetUserProfile = gObjAdo.GetADOCommand("sp_GetUserProfile")


            'MyGrid Setup
            MyGrid = New AviatCom_DefaultGrid(C1TrueDBGrid1)
            MyGrid.AC_AllowFilter = False
            MyGrid.AllowSort = True
            MyGrid.FetchRowStyles = False
            MyGrid.AllowColMove = False
            MyGrid.AllowRowSizing = False
            MyGrid.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            MyGrid.Parent = gbAccessAssign
            MyGrid.BorderStyle = BorderStyle.Fixed3D
            MyGrid.Splits(0).ColumnCaptionHeight = MyGrid.RowHeight * 3

            'MyGrid.Height = MyGrid.RowHeight * (23 - 0.4)
            'MyGrid.Height = MyGrid.Splits(0).ColumnCaptionHeight * 10
            MyGrid.Show()
            C1TrueDBGrid1.Dispose()

            'MyGrid2 Setup
            MyGrid2 = New AviatCom_DefaultGrid(C1TrueDBGrid2)
            MyGrid2.AC_AllowFilter = False
            MyGrid2.AllowSort = True
            MyGrid2.FetchRowStyles = False
            MyGrid2.AllowColMove = False
            MyGrid2.AllowRowSizing = False
            MyGrid2.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            MyGrid2.Parent = gbAccessAssign
            MyGrid2.BorderStyle = BorderStyle.Fixed3D
            MyGrid2.Splits(0).ColumnCaptionHeight = MyGrid2.RowHeight * 3
            'MyGrid2.Height = MyGrid2.RowHeight * (23 - 0.4)
            'MyGrid.Height = MyGrid.Splits(0).ColumnCaptionHeight * 10
            MyGrid2.Show()
            C1TrueDBGrid2.Dispose()

            'MyGrid3 Setup
            MyGrid3 = New AviatCom_DefaultGrid(C1TrueDBGrid3)
            MyGrid3.AC_AllowFilter = False
            MyGrid3.AllowSort = True
            MyGrid3.FetchRowStyles = True
            MyGrid3.AllowColMove = False
            MyGrid3.AllowRowSizing = False
            MyGrid3.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            MyGrid3.Parent = gbAssignProfile
            MyGrid3.BorderStyle = BorderStyle.Fixed3D

            'MyGrid3.Splits(0).ColumnCaptionHeight = MyGrid3.RowHeight * 3

            'MyGrid.Height = MyGrid.RowHeight * (23 - 0.4)
            'MyGrid.Height = MyGrid.Splits(0).ColumnCaptionHeight * 10
            MyGrid3.Show()
            C1TrueDBGrid3.Dispose()


        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error frmAccessControl_Load")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "frmAccessControl_Load" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        Finally
            bLoading = False
            RefreshUsers()
            RefreshUserProfile()
            RefreshData()
        End Try
    End Sub
    Private Sub RefreshUsers()
        Try
            If bLoading Then Exit Sub
            'Dim DT As New DataTable
            'DT = gObjAdo.GetTable(mCmd_GetProfiles)
            Dim DSet As DataSet

            DSet = gObjAdo.GetResults(Nothing, mCmd_GetUsers)
            If Not DSet Is Nothing Then


                FillComboBox(cboUserName, DSet.Tables(0), " ")


            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error RefreshUsers")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "RefreshUsers" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub GetUserProifle(ByVal sUserName As String)
        Try
            Dim DT As DataTable = gObjAdo.GetTable(mCmd_GetUserProfile, GetParam(sUserName))

            If Not DT Is Nothing Then
                txtUserProfile.Text = DT.Rows(0).Item(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshData()
        Try
            If bLoading Then Exit Sub
            'If cboProfiles.Text.Trim = "" Then Exit Sub
            Dim DSetDenied As DataSet
            Dim DSetGranted As DataSet

            DSetGranted = gObjAdo.GetResults(GetParam("GRANTED", cboProfiles.Text), mCmd_GetProfileAccessCode)
            DSetDenied = gObjAdo.GetResults(GetParam("DENIED", cboProfiles.Text), mCmd_GetProfileAccessCode)

            MyGrid.AC_GridDataSet = DSetDenied
            DSetDenied.Dispose()
            If MyGrid.AC_GridDataSet Is Nothing Then
                MessageBox.Show("DataSet Contain No Data", "Refresh Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            MyGrid.AC_SortDirectionReset()
            MyGrid.AC_ColumnWidthMultipler_Disable = True
            MyGrid.AC_RefreshGrid()



            MyGrid2.AC_GridDataSet = DSetGranted
            DSetGranted.Dispose()

            If MyGrid2.AC_GridDataSet Is Nothing Then
                MessageBox.Show("DataSet Contain No Data", "Refresh Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            MyGrid2.AC_SortDirectionReset()
            MyGrid2.AC_ColumnWidthMultipler_Disable = True
            MyGrid2.AC_RefreshGrid()




            'For j As Integer = 0 To DSetGranted.Tables(0).Rows.Count - 1
            '    lisGrantedAccess.Items.Add(DSetGranted.Tables(0).Rows(j).Item(0).ToString)
            'Next
            'For i As Integer = 0 To DSetDenied.Tables(0).Rows.Count - 1
            '    lisDeniedAccess.Items.Add(DSetDenied.Tables(0).Rows(i).Item(0).ToString)
            'Next
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error RefreshData")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "RefreshData" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub UpdateAccessRight(ByVal sProfileName As String, ByVal sAccessCode As String, ByVal sAccessAllow As String)
        Try
            gObjAdo.ExecuteSP(GetParam(sProfileName, sAccessCode, sAccessAllow), mCmd_UpdateProfileAccess)
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error UpdateAccessRight")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "UpdateAccessRight" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub UpdateUserProfile(ByVal sUserName As String, ByVal sUserNewProfile As String)
        Try
            gObjAdo.ExecuteSP(GetParam(sUserName, sUserNewProfile), mCmd_UpdateUserProfile)
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error UpdateAccessRight")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "UpdateUserProfile" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub RefreshUserProfile()
        Try
            If bLoading Then Exit Sub
            'Dim DT As New DataTable
            'DT = gObjAdo.GetTable(mCmd_GetProfiles)
            Dim DSet As DataSet

            DSet = gObjAdo.GetResults(Nothing, mCmd_GetProfiles)
            If Not DSet Is Nothing Then


                FillComboBox(cboProfiles, DSet.Tables(0), " ")


                MyGrid3.AC_GridDataSet = DSet
                DSet.Dispose()
                If MyGrid3.AC_GridDataSet Is Nothing Then
                    MessageBox.Show("DataSet Contain No Data", "Refresh Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                MyGrid3.AC_SortDirectionReset()
                MyGrid3.AC_ColumnWidthMultipler_Disable = True
                MyGrid3.AC_RefreshGrid()
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error RefreshUserProfile")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "RefreshUserProfile" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub


    Private Sub btnUpdateProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateProfile.Click
        Try
            If cboUserName.Text.Trim <> "" Then
                UpdateUserProfile(cboUserName.Text, MyGrid3.Item(MyGrid3.Row, 0).ToString)
                MyGrid3.SelectedRows.Clear()
                RefreshUsers()
            End If
        Catch exp As Exception
            If gbDebugDisplayMSG Then MessageBox.Show("Error btnUpdateProfile_Click")
            LogToSystemEvent(gsApplicationClientID, Me.Text, "btnUpdateProfile_Click" & Chr(13) & exp.Message & Chr(13) & Chr(13) & exp.ToString, "Error")
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cboProfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProfiles.SelectedIndexChanged
        RefreshData()
    End Sub


    Private Sub btnDenied_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDenied.Click
        btnDenied.Enabled = False

        For j As Integer = 0 To MyGrid2.SelectedRows.Count - 1
            UpdateAccessRight(cboProfiles.Text, MyGrid2.Item(MyGrid2.SelectedRows.Item(j), 0).ToString, "F")
        Next

        MyGrid2.SelectedRows.Clear()

        RefreshData()
    End Sub
    Private Sub btnGrantAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrantAccess.Click
        btnGrantAccess.Enabled = False

        For j As Integer = 0 To MyGrid.SelectedRows.Count - 1
            UpdateAccessRight(cboProfiles.Text, MyGrid.Item(MyGrid.SelectedRows.Item(j), 0).ToString, "T")
        Next
        MyGrid.SelectedRows.Clear()
        RefreshData()
    End Sub


    Private Sub MyGrid_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MyGrid.SelChange
        If MyGrid.SelectedRows.Count > 0 And cboProfiles.Text.Trim <> "" Then
            btnGrantAccess.Enabled = True
        Else
            btnGrantAccess.Enabled = False
        End If

    End Sub


    Private Sub MyGrid2_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MyGrid2.SelChange
        If MyGrid2.SelectedRows.Count > 0 And cboProfiles.Text.Trim <> "" Then
            btnDenied.Enabled = True
        Else
            btnDenied.Enabled = False
        End If

    End Sub


    Private Sub MyGrid3_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MyGrid3.SelChange
        If MyGrid3.SelectedRows.Count > 0 Then
            btnUpdateProfile.Enabled = True
        Else
            btnUpdateProfile.Enabled = False
        End If
    End Sub

    Private Sub cboUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUserName.SelectedIndexChanged
        If Not cboUserName.Text = "" Then GetUserProifle(cboUserName.Text)
    End Sub
End Class