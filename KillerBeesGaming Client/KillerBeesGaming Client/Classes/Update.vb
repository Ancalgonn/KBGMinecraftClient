Imports System.Net
Imports Ionic.Zip
Public Class Update
    Dim WithEvents Wc2 As New WebClient
    Dim LauncherFolder As String = Application.StartupPath & "\Killerbees Gaming Client\"
    Dim PackFolder As String = Application.StartupPath & "\Killerbees Gaming Client\Packs\"
    Dim CurrentPack As String
    'use these classes to find version of current pack online,
    ' the actual version that the user has in the pack folder itself and can be used to compare the two.
    Public Function GetLauncherLink()
        Dim web As New Net.WebClient
        Dim updatelink As String = "http://dl.dropbox.com/u/95912365/DynamicLink.txt"
        Return web.DownloadString(updatelink)
    End Function
    Public Function Update()
        Dim web As New Net.WebClient
        Dim updatelink As String = "http://dl.dropbox.com/u/95912365/Update.txt"
        Return web.DownloadString(updatelink)
    End Function
    Public Function CheckIRPackVersion()
        Dim web As New Net.WebClient
        Dim updatelink As String = "https://dl.dropbox.com/u/32095369/IR.txt"
        Return web.DownloadString(updatelink)
    End Function
    Public Function CheckTFRPackVersion()
        Dim web As New Net.WebClient
        Dim updatelink As String = "https://dl.dropbox.com/u/32095369/TFR.txt"
        Return web.DownloadString(updatelink)
    End Function
    Public Function ForceUpdate()


        If My.Computer.FileSystem.DirectoryExists(LauncherFolder & "packs\" & FrmClientScreen.CboMinecraftVersion.SelectedItem) Then
            My.Computer.FileSystem.DeleteDirectory(PackFolder & FrmClientScreen.CboMinecraftVersion.SelectedItem, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)


        End If

        Select Case FrmClientScreen.CboMinecraftVersion.SelectedItem

            Case "Industrial Rage"

                My.Computer.FileSystem.CreateDirectory(LauncherFolder & "packs\")
                My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                CurrentPack = "IRpack.zip"
                Wc2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/IRpack.zip"), LauncherFolder & "install\" & CurrentPack)

            Case "TerraFirma Craft"
                My.Computer.FileSystem.CreateDirectory(LauncherFolder & "packs\")
                My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                CurrentPack = "TFRpack.zip"
                Wc2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/TFRpack.zip"), LauncherFolder & "install\" & CurrentPack)



        End Select
    End Function
    Public Sub DownloadComplete() Handles Wc2.DownloadFileCompleted
        'extract files!
        MsgBox("Download Complete, please wait while we extract. During this time the launcher may freeze, this is normal just let it finish. When the force update is done you can login.")
        ' Dim oZipHelper As ZipHelper = New ZipHelper()
        FrmClientScreen.lblProgressInfo.Text = "Extracting Files To " & LauncherFolder & "packs\" & FrmClientScreen.CboMinecraftVersion.SelectedItem
        If My.Computer.FileSystem.FileExists(LauncherFolder & "packs\" & FrmClientScreen.CboMinecraftVersion.SelectedItem & "\version.txt") Then
            My.Computer.FileSystem.DeleteFile(LauncherFolder & "packs\" & FrmClientScreen.CboMinecraftVersion.SelectedItem & "\version.txt")
        End If
        Extract(LauncherFolder & "install\" & CurrentPack, LauncherFolder & "packs\" & FrmClientScreen.CboMinecraftVersion.SelectedItem & "\")
        ' PbrProgress.
        'oZipHelper.ExtractFilesFromZip(LauncherFolder & "install\" & CurrentPack, LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\", "")


    End Sub
    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles Wc2.DownloadProgressChanged
        FrmClientScreen.PbrProgress.Value = e.ProgressPercentage
        FrmClientScreen.PbrTotal.Value = e.ProgressPercentage
        FrmClientScreen.lblProgress.Text = e.ProgressPercentage & "%"
        FrmClientScreen.lblTotalProgress.Text = e.ProgressPercentage & "%"
        FrmClientScreen.lblProgressInfo.Text = "Downloading " & FrmClientScreen.CboMinecraftVersion.SelectedItem & " Pack please wait."
    End Sub
    Private Sub Extract(ZipToUnpack As String, UnpackDirectory As String)


        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            Dim e As ZipEntry
            ' here, we extract every entry, but we could extract conditionally,
            ' based on entry name, size, date, checkbox status, etc. 

            For Each e In zip1
                e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using
    End Sub
End Class
