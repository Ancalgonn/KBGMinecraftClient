Imports System.Net
Public Class Update
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
End Class
