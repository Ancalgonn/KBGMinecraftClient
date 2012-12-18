Imports System.Net
Public Class Update

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
End Class
