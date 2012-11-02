Imports System.Net
Imports System.IO
Imports System.Environment

Public Class MinecraftLib

    Private specialFolders As New Dictionary(Of SpecialFolder, String)

    ' This function is the login function(obviously), it returns a LoginReturn object that stores the result
    Public Function doLogin(ByVal username As String, ByVal password As String) As LoginReturn
        Dim response As HttpWebResponse
        Dim request As HttpWebRequest = WebRequest.Create("https://login.minecraft.net/?user=" + username + "&password=" + password + "&version=12")
        Try
            response = request.GetResponse()
        Catch
            Return New LoginReturn(False, True, Nothing)
        End Try
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
        Dim result As String = reader.ReadToEnd
        Dim arr As String() = result.Split(":")
        If result.Contains("Bad login") Then
            Return New LoginReturn(False, False, Nothing)
        ElseIf arr.Length < 4 Then
            Return New LoginReturn(False, True, Nothing)
        End If

        Return New LoginReturn(True, arr(3), arr(2))
    End Function

    ' Ignore this function, it was made for another guy who needed it
    Private Function GetFolderPath(ByVal specialFolder As SpecialFolder) As String
        If specialFolders.ContainsKey(specialFolder) Then
            Return specialFolders.Item(specialFolder)
        End If
        Return System.Environment.GetFolderPath(specialFolder)
    End Function

    ' Same for this one, they were made so it should be possible to change AppData to your own folder, for the possibility of a portable Minecraft, or for mod packs and stuff
    Public Sub SetFolderPath(ByVal specialFolder As SpecialFolder, ByVal newValue As String)
        specialFolders.Add(specialFolder, newValue)
    End Sub

    ' This function starts the game, however if I'm not wrong Java needs to be in the PATH environment variable
    Public Sub startGame(ByVal username As String, ByVal session As String, ByVal jar As String)
        Dim process As New Process
        Dim info As New ProcessStartInfo
        info.FileName = "javaw"
        info.CreateNoWindow = True
        info.Arguments = "-cp " & Chr(34) & jar & ";%APPDATA%\.minecraft\bin/lwjgl.jar;%APPDATA%\.minecraft\bin/lwjgl_util.jar;%APPDATA%\.minecraft\bin/jinput.jar;" & Chr(34) & " " & Chr(34) & "-Djava.library.path=%APPDATA%\.minecraft\bin\natives" & Chr(34) & " -Xmx1024M -Xms512M net.minecraft.client.Minecraft " + username + " " + session
        info.Arguments = info.Arguments.Replace("%APPDATA%", GetFolderPath(SpecialFolder.ApplicationData))
        process.StartInfo = info
        process.Start()
    End Sub

    Class LoginReturn
        Private valid = False
        Private failed = False
        Private session = Nothing
        Private username = Nothing

        Public Sub New(ByVal b As Boolean, ByVal s As String, ByVal s1 As String)
            valid = b
            failed = False
            session = s
            username = s1
        End Sub

        Public Sub New(ByVal b As Boolean, ByVal b1 As Boolean, ByVal s As String)
            valid = b
            failed = b1
            session = s
            If failed Then
                username = "Player" & My.Computer.Clock.LocalTime.Millisecond
            End If
        End Sub

        Public Function getSession() As String
            Return session
        End Function

        Public Function getUsername() As String
            Return username
        End Function

        Public Function hasFailed() As Boolean
            Return failed
        End Function

        Public Function isValid() As Boolean
            If failed Then
                Return False
            End If
            Return valid
        End Function
    End Class

End Class
