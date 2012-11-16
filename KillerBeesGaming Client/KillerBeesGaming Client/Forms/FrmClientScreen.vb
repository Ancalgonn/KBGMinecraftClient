Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Mail
Imports System.Xml
Imports System.ComponentModel
Public Class FrmClientScreen
  

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
        If ServerPing("198.154.108.218", 25586) = True Then 'terraferma
            Label4.Text = "Online"
            Label4.ForeColor = Color.Green
        Else
            Label4.Text = "Offline"
            Label4.ForeColor = Color.Red
        End If

        ProgressUpdate(100, 100)
        If ServerPing("198.154.108.218", 25566) = True Then 'test Server
            Label5.Text = "Online"
            Label5.ForeColor = Color.Green
        Else
            Label5.Text = "Offline"
            Label5.ForeColor = Color.Red
        End If
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



    Private Sub btnLogin_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click

        Try

            If chkRememberMe.Checked = True Then
                My.Settings.Username = CboUser.Text
                My.Settings.Password = txtPassword.Text
                My.Settings.RememberUserPass = True
            Else
                My.Settings.RememberUserPass = False
                My.Settings.Username = Nothing
                My.Settings.Password = Nothing
            End If

            If My.Settings.AutoLogin = False Then
                Process.Start(Application.StartupPath & "\minecraft.exe", CboUser.Text & " " & txtPassword.Text)
            Else
                Process.Start(Application.StartupPath & "\minecraft.exe", CboUser.Text & " " & txtPassword.Text & " " & My.Settings.LastServer)
            End If
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Function gettwitter()

        'Check to see if file is there and replace it
        If My.Computer.FileSystem.FileExists(loc & "\Load\IN.xml") = True Then
            My.Computer.FileSystem.DeleteFile(loc & "\Load\IN.xml")
            My.Computer.Network.DownloadFile("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=KB_Gaming", loc & "\Load\IN.xml")
        Else
            My.Computer.Network.DownloadFile("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=KB_Gaming", loc & "\Load\IN.xml")

        End If
        'Actually finds la tweet date and txt

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
    End Function
    Private Sub FrmClientScreen_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
     
        PingAllServers()
    End Sub

    Private Sub FrmClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            gettwitter()
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


End Class