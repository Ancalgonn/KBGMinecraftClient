Imports System.Net
Imports System.Net.Sockets
Imports System.Xml
Imports System.ComponentModel
Imports KillerBeesGaming_Client.Update
Imports KillerBeesGaming_Client.Bn.Classes
Public Class FrmClientScreen
    Private WithEvents downloader As New FileDownloader
    Dim LauncherFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Killerbees Gaming Client\"
#Region "Loadup Actions"
    Private MinecraftExists As Boolean = My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\minecraft.exe")
    Dim Blank, laname, txttweet, createdat, link, fileloc, filename As String
    Dim count, filesize, ammount As Integer
    Dim wc As WebClient
    Dim loc As String = Application.StartupPath
    Private Property java As Object
#End Region

#Region "Functions"
    Private Sub PingAllServers()
        ProgressUpdate(14.2, 14.2)
        lblProgressInfo.Text = "Pinging Servers..."
        If ServerPing("Login.minecraft.net", 80) = True Then
            Label7.Text = "Online"
            Label7.ForeColor = Color.Green
        Else
            Label7.Text = "Offline"
            Label7.ForeColor = Color.Red
        End If

        ProgressUpdate(24.4, 28.4)
        If ServerPing("Minecraft.Net", 80) = True Then
            Label6.Text = "Online"
            Label6.ForeColor = Color.Green
        Else
            Label6.Text = "Offline"
            Label6.ForeColor = Color.Red
        End If

        ProgressUpdate(42.6, 42.6)
        If ServerPing("ir.industrial-craft.net", 25565) = True Then
            Label1.Text = "Online"
            Label1.ForeColor = Color.Green
        Else
            Label1.Text = "Offline"
            Label1.ForeColor = Color.Red
        End If

        ProgressUpdate(56.8, 56.8)
        If ServerPing("mining.industrial-craft.net", 25565) = True Then
            Label2.Text = "Online"
            Label2.ForeColor = Color.Green
        Else
            Label2.Text = "Offline"
            Label2.ForeColor = Color.Red
        End If

        ProgressUpdate(71, 71)
        If ServerPing("209.105.230.53", 25565) = True Then 'endless rage
            Label3.Text = "Online"
            Label3.ForeColor = Color.Green
        Else
            Label3.Text = "Offline"
            Label3.ForeColor = Color.Red
        End If

        ProgressUpdate(85.2, 85.2)
        If ServerPing("209.105.230.51", 25565) = True Then 'terraferma
            Label4.Text = "Online"
            Label4.ForeColor = Color.Green
        Else
            Label4.Text = "Offline"
            Label4.ForeColor = Color.Red
        End If

        ProgressUpdate(100, 100)
   
        lblProgressInfo.Text = "Server Pings Complete!"
    End Sub
    Private Sub ProgressUpdate(ByVal ProgressBar As Integer, ByVal Label As Integer)
        lblProgress.Text = Label & "%"
        lblTotalProgress.Text = Label & "%"
        PbrProgress.Value = ProgressBar
        PbrTotal.Value = ProgressBar
    End Sub
    Public Function ServerPing(ByVal IP As String, ByVal Port As Integer)
        'Connects to the server via a Tcp packet on a specified port, returns true if connection secessful
        Dim Server As New TcpClient
        Try
            Server.Connect(IP, Port)
            Return True
        Catch Excep As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Download"
    Dim UpdateLink As New Update
    Dim whereToSave As String 'Where the program save the file

    Delegate Sub ChangeTextsSafe(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)
    Delegate Sub DownloadCompleteSafe(ByVal cancelled As Boolean)


    Public Sub ChangeTexts(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

        Me.Label3.Text = "File Size: " & Math.Round((length / 1024), 2) & " KB"

        '   Me.Label5.Text = "Downloading: " & Me.txtFileName.Text

        'Me.Label4.Text = "Downloaded " & Math.Round((position / 1024), 2) & " KB of " & Math.Round((length / 1024), 2) & "KB (" & Me.ProgressBar1.Value & "%)"

        If speed = -1 Then
            Me.Label2.Text = "Speed: calculating..."
        Else
            Me.Label2.Text = "Speed: " & Math.Round((speed / 1024), 2) & " KB/s"
        End If

        ' Me.ProgressBar1.Value = percent


    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        'Creating the request and getting the response
        Dim theResponse As HttpWebResponse
        Dim theRequest As HttpWebRequest
        Try 'Checks if the file exist

            theRequest = WebRequest.Create(UpdateLink.GetDynamicLink)
            theResponse = theRequest.GetResponse
        Catch ex As Exception

            MessageBox.Show("An error occurred while downloading file. Possibe causes:" & ControlChars.CrLf & _
                            "1) File doesn't exist" & ControlChars.CrLf & _
                            "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

            Me.Invoke(cancelDelegate, True)

            Exit Sub
        End Try
        Dim length As Long = theResponse.ContentLength 'Size of the response (in bytes)

        Dim safedelegate As New ChangeTextsSafe(AddressOf ChangeTexts)
        Me.Invoke(safedelegate, length, 0, 0, 0) 'Invoke the TreadsafeDelegate

        Dim writeStream As New IO.FileStream(Me.whereToSave, IO.FileMode.Create)

        'Replacement for Stream.Position (webResponse stream doesn't support seek)
        Dim nRead As Integer

        'To calculate the download speed
        Dim speedtimer As New Stopwatch
        Dim currentspeed As Double = -1
        Dim readings As Integer = 0

        Do

            If BackgroundWorker1.CancellationPending Then 'If user abort download
                Exit Do
            End If

            speedtimer.Start()

            Dim readBytes(4095) As Byte
            Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)

            nRead += bytesread
            Dim percent As Short = (nRead * 100) / length

            Me.Invoke(safedelegate, length, nRead, percent, currentspeed)

            If bytesread = 0 Then Exit Do

            writeStream.Write(readBytes, 0, bytesread)

            speedtimer.Stop()

            readings += 1
            If readings >= 5 Then 'For increase precision, the speed it's calculated only every five cicles
                currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                speedtimer.Reset()
                readings = 0
            End If
        Loop

        'Close the streams
        theResponse.GetResponseStream.Close()
        writeStream.Close()

        If Me.BackgroundWorker1.CancellationPending Then

            IO.File.Delete(Me.whereToSave)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

            Me.Invoke(cancelDelegate, True)

            Exit Sub

        End If

        Dim completeDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

        Me.Invoke(completeDelegate, False)

    End Sub

    Sub BtnDownloadClick(sender As Object, e As EventArgs)

    End Sub
    Public Sub DownloadComplete(ByVal cancelled As Boolean)

    End Sub
#End Region


    Private Sub btnLogin_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click

        Try

            If chkRememberMe.Checked = True Then
                My.Settings.Username = txtUsername.Text
                My.Settings.Password = txtPassword.Text
                My.Settings.RememberUserPass = True
            Else
                My.Settings.RememberUserPass = False
                My.Settings.Username = Nothing
                My.Settings.Password = Nothing
            End If

            If My.Settings.AutoLogin = False Then
                Process.Start(Application.StartupPath & "\minecraft.exe", txtUsername.Text & " " & txtPassword.Text)
            Else
                Process.Start(Application.StartupPath & "\minecraft.exe", txtUsername.Text & " " & txtPassword.Text & " " & My.Settings.LastServer)
            End If
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Function GetTwitterMyCode()
        Dim apppath As String = Application.StartupPath
        Dim Doc As XmlReader = New XmlTextReader(apppath & "\load\IN.xml")


    End Function
    Sub gettwitter()
        If My.Computer.Network.Ping("www.google.com") = True Then
            'Check to see if file is there and replace it
            If My.Computer.FileSystem.FileExists(loc & "\Load\IN.xml") = True Then
                My.Computer.FileSystem.DeleteFile(loc & "\Load\IN.xml")
                My.Computer.Network.DownloadFile("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=KB_Gaming", loc & "\Load\IN.xml")
            Else
                My.Computer.Network.DownloadFile("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=KB_Gaming", loc & "\Load\IN.xml")

            End If

        Else

            Exit Sub
            'Actually finds la tweet date and txt
        End If
        count = 1
        If System.IO.File.Exists(loc & "\Load\IN.xml") And count <= 6 Then
            Dim Doc As XmlReader = New XmlTextReader(loc & "\Load\IN.xml")
            While (Doc.Read())
                Dim type = Doc.NodeType
                If (type = XmlNodeType.Element) Then
                    If Doc.Name = "created_at" Then
                        txttweet = Doc.ReadInnerXml.ToString()
                        If count = 1 Then

                            rtxtTwitter.Text = txttweet + vbNewLine
                        End If
                        count += 1
                    End If
                    If Doc.Name = "text" Then
                        createdat = Doc.ReadInnerXml.ToString

                        'rtxtTwitter.Text = +createdat

                        'If count = 2 Then
                        rtxtTwitter.AppendText(System.Environment.NewLine + createdat + System.Environment.NewLine)
                        'rtxtTwitter.Text = createdat
                        'End If
                        '    If count = 3 Then
                        'rtxtTwitter.Text = createdat
                        'End If
                        'If count = 4 Then
                        'rtxtTwitter.Text = createdat
                        '  End If
                        'If count = 5 Then
                        '       rtxtTwitter.Text = createdat
                        'End If
                        '      If count = 6 Then
                        'rtxtTwitter.Text = createdat
                        '   End If
                    End If

                End If
            End While
        Else
            MessageBox.Show("Cannot Find Twitter Feed")
        End If
    End Sub
    Private Sub Remember()
        If My.Settings.RememberUserPass = True Then
            txtPassword.Text = My.Settings.Password
            txtUsername.Text = My.Settings.Username
            chkRememberMe.Checked = True
        Else
            chkRememberMe.Checked = False
        End If
    End Sub

    Sub FirstInstall()

        'CreateFolders
        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "\Packs")
        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "\Backup")
        If My.Computer.FileSystem.DirectoryExists(LauncherFolder) Then

        End If
    End Sub

    Private Sub FrmClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
           

            Remember()
            CboMinecraftVersion.SelectedIndex = 0
            gettwitter()

            PingAllServers()
            UpdateTimer.Start()
            If My.Computer.FileSystem.FileExists(Application.ExecutablePath & ".old") Then
                My.Computer.FileSystem.DeleteFile(Application.ExecutablePath & ".old")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
    End Sub

    Private Sub rtxtTwitter_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles rtxtTwitter.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub BtnOptions_Click(sender As System.Object, e As System.EventArgs) Handles BtnOptions.Click
        FrmOption.Show()
    End Sub


    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        FrmMinecraftLocations.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles UpdateTimer.Tick
        Dim SAPI
        SAPI = CreateObject("SAPI.spvoice")


        Dim AppName As String = Application.ExecutablePath
        Dim AppNameNew As String = Application.StartupPath + "launcher.old"
        Dim update As New Update
        If update.Update > Application.ProductVersion Then
            SAPI.Speak("Hey a new update is availible I'm going to start downloading it.")
            'Stop the timer from repeating endlessly
            UpdateTimer.Enabled = False
            'Do Update Stuff
            MsgBox("New update availible at " & update.GetDynamicLink)

            'rename & delete the old file 

            'download
            MsgBox("Restarting to finish updates to client.", MsgBoxStyle.Information)
            Application.Restart()
            'Me.BackgroundWorker1.RunWorkerAsync() 'run download
        Else

            UpdateTimer.Enabled = False
            UpdateTimer.Stop()
            Exit Sub
        End If

    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        PingAllServers()
    End Sub

    Function DownloadFile()

    End Function
End Class