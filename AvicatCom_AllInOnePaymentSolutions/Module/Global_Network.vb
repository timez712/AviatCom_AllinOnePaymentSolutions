Module Global_Network
    Private ObjNetwork As IWshRuntimeLibrary.IWshNetwork_Class = New IWshRuntimeLibrary.IWshNetwork_Class
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sMappedDriveLetter">"J:"</param>
    ''' <param name="sNetworkPath">"\\192.168.1.1\MyShare</param>
    ''' <param name="sUserName"></param>
    ''' <param name="sPassword"></param>
    ''' <remarks></remarks>
    Friend Sub CreateNetworkDrive(sMappedDriveLetter As String, sNetworkPath As String, sUserName As String, sPassword As String)

        Try
            ObjNetwork.MapNetworkDrive(sMappedDriveLetter, sNetworkPath, Type.Missing, sUserName, sPassword)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sMappedDriveLetter">"J:")</param>
    ''' <remarks></remarks>
    Friend Sub RemoveNetworkDrive(sMappedDriveLetter As String)
        Try
            ObjNetwork.RemoveNetworkDrive(sMappedDriveLetter)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Module
