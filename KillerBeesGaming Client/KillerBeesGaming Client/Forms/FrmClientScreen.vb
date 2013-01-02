Imports System.Net
Imports System.Net.Sockets
Imports System.Xml
Imports System.ComponentModel
Imports KillerBeesGaming_Client.Update
Imports System.IO
Imports Ionic.Zip


Public Class FrmClientScreen
    Dim LauncherFolder As String = Application.StartupPath & "\Killerbees Gaming Client\"
    Dim WithEvents WC2 As New WebClient
    Dim CurrentPack As String

#Region "Loadup Actions"
    Private MinecraftExists As Boolean = My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\minecraft.exe")
    Dim Blank, laname, txttweet, createdat, link, fileloc, filename As String
    Dim count, filesize, ammount As Integer
    Dim wc As WebClient
    Dim loc As String = Application.StartupPath
    Public Property java As Object
    Dim update As New Update
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

#Region "Zip Functions"
    Private Sub extract(folder As String)

        Using zip As ZipFile = ZipFile.Read(FilePath)
            zip.StatusMessageTextWriter = System.Console.Out
            'Status Messages will be sent to the console during extraction
            zip.ExtractAll(folder)
        End Using
    End Sub
#End Region

    Public Function RunMinecraft(Optional ByVal CloseOnOpen As Boolean = True)
        java = CreateObject("WScript.Shell")
        java.Environment("PROCESS")("APPDATA") = LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem
        java.Run("Minecraft.exe " + txtUsername.Text + " " + txtPassword.Text)


        If CloseOnOpen = True Then
            Me.Close()
        Else
            Exit Function
        End If
    End Function
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

            My.Settings.LastIndexServer = CboMinecraftVersion.SelectedIndex

            Select Case CboMinecraftVersion.SelectedItem

                Case "Industrial Rage"
                    btnLogin.Enabled = False
                    If My.Computer.FileSystem.DirectoryExists(LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\.minecraft\bin\") = False Then
                        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                        WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/IRpack.zip"), LauncherFolder & "install\IRpack.zip")

                    Else
                        Exit Select
                    End If
                Case "TerraFirma Craft"
                    btnLogin.Enabled = False
                    If My.Computer.FileSystem.DirectoryExists(LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\.minecraft\bin\") = False Then
                        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                        WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/TFRpack.zip"), LauncherFolder & "install\TFRpack.zip")

                    Else
                        Exit Select
                    End If

                Case Else
                    Exit Select
            End Select

            RunMinecraft()


        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Sub gettwitter()
        If My.Computer.Network.Ping("www.google.com") = True Then
            'Check to see if file is there and replace it
            If My.Computer.FileSystem.FileExists(LauncherFolder & "Twitter.xml") = True Then
                My.Computer.FileSystem.DeleteFile(LauncherFolder & "Twitter.xml")
                My.Computer.Network.DownloadFile("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=KB_Gaming", LauncherFolder & "Twitter.xml")
            Else
                My.Computer.Network.DownloadFile("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=KB_Gaming", LauncherFolder & "Twitter.xml")

            End If

        Else

            Exit Sub


            'Actually finds la tweet date and txt
        End If
        count = 1
        If System.IO.File.Exists(LauncherFolder & "Twitter.xml") And count <= 6 Then
            Dim Doc As XmlReader = New XmlTextReader(LauncherFolder & "Twitter.xml")
            While (Doc.Read())
                Dim type = Doc.NodeType
                If (type = XmlNodeType.Element) Then
                    If Doc.Name = "created_at" Then
                        txttweet = Doc.ReadInnerXml.ToString()
                        If count = 1 Then

                            'rtxtTwitter.Text = txttweet + vbNewLine
                        End If
                        count += 1
                    End If
                    If Doc.Name = "text" Then
                        createdat = Doc.ReadInnerXml.ToString

                        ' rtxtTwitter.Text = +createdat

                        ' If count = 2 Then
                        rtxtTwitter.AppendText(System.Environment.NewLine + createdat + System.Environment.NewLine)

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
    Public Function CheckVersion(Link As String)
        Dim web As New Net.WebClient
        Dim updatelink As String = Link
        Return web.DownloadString(updatelink)
    End Function

    Private Sub FrmClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        'remember user settings
        Remember()

        'this is update stuffs
        If My.Computer.FileSystem.DirectoryExists(LauncherFolder & "Packs") = False Then
            My.Computer.FileSystem.CreateDirectory(LauncherFolder & "Packs")
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\KillerBeesGaming Client2.exe") = True Then

            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\KillerBeesGaming Client.exe")
            My.Computer.FileSystem.RenameFile(Application.StartupPath & "\KillerBeesGaming Client2.exe", "KillerBeesGaming Client.exe")
        Else

        End If
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo(LauncherFolder & "Packs\")
        ' Get a reference to each directory in that directory.
        Dim diArr As DirectoryInfo() = di.GetDirectories()
        ' Populate Combobox.
        Dim dri As DirectoryInfo
        For Each dri In diArr
            CboMinecraftVersion.Items.Add(dri.Name)
        Next dri
        'make the first item selected
        CboMinecraftVersion.SelectedIndex = My.Settings.LastIndexServer
        'get and display twitter

        '  gettwitter()

        'ping all minecraft servers

        'PingAllServers()

        'check for updates!
        UpdateTimer.Start()

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
        Try
            Me.Text = "KBG Client v" & Application.ProductVersion & " Beta"
            UpdateTimer.Enabled = False
            PingAllServers()
            gettwitter()

            If update.Update > Application.ProductVersion Then
                'Stop the timer from repeating endlessly
                UpdateTimer.Enabled = False
                UpdateTimer.Stop()
                'Do Update Stuff
                MsgBox("New launcher update! Downloading.")
                lblProgressInfo.Text = "Downloading new launcher."


                WC2.DownloadFile(New Uri(update.GetLauncherLink), Application.StartupPath & "\KillerBeesGaming Client2.exe")


                ' MsgBox("Done now restarting to apply updates.")
                MsgBox("Done now restarting to apply updates.")
                Process.Start(Application.StartupPath & "\KillerBeesGaming Client2.exe")

                Application.ExitThread()

            Else

                UpdateTimer.Enabled = False
                UpdateTimer.Stop()
                Exit Sub
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Try
            PingAllServers()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC2.DownloadProgressChanged
        PbrProgress.Value = e.ProgressPercentage
        PbrTotal.Value = e.ProgressPercentage / 2
        lblProgress.Text = e.ProgressPercentage & "%"
        lblTotalProgress.Text = e.ProgressPercentage / 2 & "%"
       
    End Sub

    Public Sub DownloadComplete() Handles WC2.DownloadFileCompleted
        'extract files!
        MsgBox("Download Complete")
    End Sub
End Class