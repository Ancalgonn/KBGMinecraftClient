Imports System.Net
Imports System.Net.Sockets
Imports System.Xml
Imports System.IO
Imports Ionic.Zip

Public Class FrmClientScreen


#Region "Loadup Actions"

    Dim Blank, laname, txttweet, createdat, link, fileloc, filename As String
    Dim count, filesize, ammount As Integer
    Dim wc As WebClient
    Dim loc As String = Application.StartupPath
    Public Property java As Object
    Dim Update As New Update
    Dim LauncherFolder As String = Application.StartupPath & "\Killerbees Gaming Client\"
    Public WithEvents WC2 As New WebClient
    Dim Backupfolder As String = LauncherFolder & "backup\"
    Dim currentpack As String
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

    Public Function LocalPackVersion()

        Return My.Computer.FileSystem.ReadAllText(Application.StartupPath & _
                                                  "\Killerbees Gaming Client\packs\" & CboMinecraftVersion.SelectedItem & _
"\version.txt")


    End Function
#End Region

    Sub MoveMinecraftSettingsToBackup()
        Dim CurrentMinecraftPackFolder As String = Application.StartupPath & "\Killerbees Gaming Client\packs\" & CboMinecraftVersion.SelectedItem & "\.minecraft\"
        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "Backup")
        If My.Computer.FileSystem.FileExists(CurrentMinecraftPackFolder & "options.txt") Then
            My.Computer.FileSystem.MoveFile(CurrentMinecraftPackFolder & "options.txt", Backupfolder & "options.txt", True)
        End If
        If My.Computer.FileSystem.FileExists(CurrentMinecraftPackFolder & "servers.dat") Then
            My.Computer.FileSystem.MoveFile(CurrentMinecraftPackFolder & "servers.dat", Backupfolder & "servers.dat", True)
        End If
        If My.Computer.FileSystem.FileExists(CurrentMinecraftPackFolder & "optionsof.txt") Then
            My.Computer.FileSystem.MoveFile(CurrentMinecraftPackFolder & "optionsof.txt", Backupfolder & "optionsof.txt", True)
        End If
        If My.Computer.FileSystem.FileExists(CurrentMinecraftPackFolder & "mods\rei_minimap\keyconfig.txt") Then
            My.Computer.FileSystem.CreateDirectory(LauncherFolder & "Backup\mods\rei_minimap\")
            My.Computer.FileSystem.MoveFile(CurrentMinecraftPackFolder & "mods\rei_minimap\keyconfig.txt", Backupfolder & "mods\rei_minimap\keyconfig.txt", True)
        End If
    End Sub

    Sub MoveMinecraftSettingsToOriginalFolder()
        Dim CurrentMinecraftPackFolder As String = Application.StartupPath & "\Killerbees Gaming Client\packs\" & CboMinecraftVersion.SelectedItem & "\.minecraft\"
        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "Backup")
        If My.Computer.FileSystem.FileExists(Backupfolder & "options.txt") Then
            My.Computer.FileSystem.MoveFile(Backupfolder & "options.txt", CurrentMinecraftPackFolder & "options.txt", True)
        End If
        If My.Computer.FileSystem.FileExists(Backupfolder & "servers.dat") Then
            My.Computer.FileSystem.MoveFile(Backupfolder & "servers.dat", CurrentMinecraftPackFolder & "servers.dat", True)
        End If
        If My.Computer.FileSystem.FileExists(Backupfolder & "optionsof.txt") Then
            My.Computer.FileSystem.MoveFile(Backupfolder & "optionsof.txt", CurrentMinecraftPackFolder & "optionsof.txt", True)
        End If
        If My.Computer.FileSystem.FileExists(Backupfolder & "mods\rei_minimap\keyconfig.txt") Then
            My.Computer.FileSystem.MoveFile(Backupfolder & "mods\rei_minimap\keyconfig.txt", CurrentMinecraftPackFolder & "mods\rei_minimap\keyconfig.txt", True)
        End If
        'delete the saved files so they can't cause an issue
        My.Computer.FileSystem.DeleteDirectory(LauncherFolder & "Backup\", FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Function RunMinecraft(Optional ByVal CloseOnOpen As Boolean = True)

        java = CreateObject("WScript.Shell")
        java.Environment("PROCESS")("APPDATA") = LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\"
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

                    If My.Computer.FileSystem.DirectoryExists(LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\.minecraft\mods\") = False Then

                        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "packs\")
                        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                        currentPack = "IRpack.zip"
                        MoveMinecraftSettingsToBackup()
                        WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/" & currentpack), LauncherFolder & "install\IRpack.zip")

                    Else
                        If Update.CheckIRPackVersion > LocalPackVersion() Then
                            My.Computer.FileSystem.CreateDirectory(LauncherFolder & "packs\")
                            My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                            MoveMinecraftSettingsToBackup()
                            CurrentPack = "IRpack.zip"
                            WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/" & currentpack), LauncherFolder & "install\IRpack.zip")

                        Else
                            RunMinecraft()
                        End If

                    End If
                Case "TerraFirma Craft"

                    If My.Computer.FileSystem.DirectoryExists(LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\.minecraft\mods\") = False Then

                        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "packs\")
                        My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                        CurrentPack = "TFRpack.zip"
                        MoveMinecraftSettingsToBackup()
                        WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/" & currentpack), LauncherFolder & "install\" & currentpack)

                    Else
                        If Update.CheckTFRPackVersion > LocalPackVersion() Then
                            My.Computer.FileSystem.CreateDirectory(LauncherFolder & "packs\")
                            My.Computer.FileSystem.CreateDirectory(LauncherFolder & "install\")
                            CurrentPack = "TFRpack.zip"
                            MoveMinecraftSettingsToBackup()
                            WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/" & currentpack), LauncherFolder & "install\TFRpack.zip")

                        Else
                            RunMinecraft()
                        End If
                    End If

                Case Else
                    RunMinecraft()
            End Select

            'RunMinecraft()


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
        If My.Settings.PingServers = True Then
            FrmOption.chkCheck.Checked = True
        Else
            FrmOption.chkCheck.Checked = False

        End If
        If My.Settings.GetTwitter = True Then
            FrmOption.chktwitter.Checked = True
        Else
            FrmOption.chktwitter.Checked = False

        End If
    End Sub
    Public Function CheckVersion(Link As String)
        Dim web As New Net.WebClient
        Dim updaterlink As String = Link
        Return web.DownloadString(updaterlink)
    End Function

    Private Sub FrmClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        'remember user settings
        Remember()

        'this is updater stuffs
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

        'check for updaters!
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
            If My.Settings.PingServers = True Then
                PingAllServers()
            Else

            End If
            If My.Settings.GetTwitter = True Then
                gettwitter()
            Else

            End If

            If Update.Update > Application.ProductVersion Then
                'Stop the timer from repeating endlessly
                UpdateTimer.Enabled = False
                UpdateTimer.Stop()
                'Do Update Stuff
                MsgBox("New launcher updater! Downloading.")
                lblProgressInfo.Text = "Downloading new launcher."


                WC2.DownloadFile(New Uri(Update.GetLauncherLink), Application.StartupPath & "\KillerBeesGaming Client2.exe")


                ' MsgBox("Done now restarting to apply updaters.")
                MsgBox("Done now restarting to apply updaters.")
                Process.Start(Application.StartupPath & "\KillerBeesGaming Client2.exe")

                '  Application.ExitThread()

            Else

                UpdateTimer.Enabled = False
                ' UpdateTimer.Stop()
                Exit Sub
            End If
            If Update.CheckIRPackVersion > LocalPackVersion() Then
                WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/IRpack.zip"), LauncherFolder & "install\" & CurrentPack)
            Else
                UpdateTimer.Enabled = False
                ' UpdateTimer.Stop()
            End If
            If Update.CheckTFRPackVersion > LocalPackVersion() Then
                WC2.DownloadFileAsync(New Uri("https://dl.dropbox.com/u/32095369/TFRpack.zip"), LauncherFolder & "install\" & CurrentPack)
            Else
                UpdateTimer.Enabled = False
                UpdateTimer.Stop()
                Application.ExitThread()
                Exit Sub
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Try
            PingAllServers()
            gettwitter()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC2.DownloadProgressChanged
        PbrProgress.Value = e.ProgressPercentage
        PbrTotal.Value = e.ProgressPercentage
        lblProgress.Text = e.ProgressPercentage & "%"
        lblTotalProgress.Text = e.ProgressPercentage & "%"
        lblProgressInfo.Text = "Downloading " & CboMinecraftVersion.SelectedItem & " Pack please wait."
    End Sub

    Public Sub DownloadComplete() Handles WC2.DownloadFileCompleted
        'extract files!
        MsgBox("Download Complete, please wait while we extract. During this time the launcher may freeze, this is normal just let it finish. When it is done it will run Minecraft.")
        ' Dim oZipHelper As ZipHelper = New ZipHelper()
        lblProgressInfo.Text = "Extracting Files To " & LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem
        If My.Computer.FileSystem.FileExists(LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\version.txt") Then
            My.Computer.FileSystem.DeleteFile(LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem & "\version.txt")
        End If
        Extract(LauncherFolder & "install\" & CurrentPack, LauncherFolder & "packs\" & CboMinecraftVersion.SelectedItem)
        MoveMinecraftSettingsToOriginalFolder()

        RunMinecraft()
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

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("http://www.killerbeesgaming.com")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        System.Diagnostics.Process.Start("https://twitter.com/KB_Gaming")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("http://www.killerbeesgaming.com")
    End Sub
End Class