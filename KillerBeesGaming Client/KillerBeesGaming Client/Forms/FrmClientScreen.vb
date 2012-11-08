Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Mail
Imports System.Xml

Public Class FrmClientScreen

#Region "Loadup Actions"
    Private MinecraftExists As Boolean = My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\minecraft.exe")

    Private Sub FrmClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            PingAllServers()
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try

    End Sub
#End Region

#Region "Buttons"
    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs)

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

    Private Sub btnOptions_Click(sender As System.Object, e As System.EventArgs)
        FrmOption.Show()
    End Sub

#End Region

#Region "Functions"
    Private Function PingAllServers()
        If ServerPing("Minecraft.Login.Net", 80) = True Then
            Label7.Text = "Online"
            Label7.ForeColor = Color.Green
        Else
            Label7.Text = "Offline"
            Label7.ForeColor = Color.Red
        End If

        If ServerPing("Minecraft.Login.Net", 80) = True Then
            Label6.Text = "Online"
            Label6.ForeColor = Color.Green
        Else
            Label6.Text = "Offline"
            Label6.ForeColor = Color.Red
        End If

        If ServerPing("ir.industrial-craft.net", 25565) = True Then
            Label1.Text = "Online"
            Label1.ForeColor = Color.Green
        Else
            Label1.Text = "Offline"
            Label1.ForeColor = Color.Red
        End If

        If ServerPing("mining.industrial-craft.net", 25565) = True Then
            Label2.Text = "Online"
            Label2.ForeColor = Color.Green
        Else
            Label2.Text = "Offline"
            Label2.ForeColor = Color.Red
        End If

        If ServerPing("209.105.230.53", 25565) = True Then 'endless rage
            Label3.Text = "Online"
            Label3.ForeColor = Color.Green
        Else
            Label3.Text = "Offline"
            Label3.ForeColor = Color.Red
        End If

        If ServerPing("108.166.189.186:25651", 25651) = True Then 'terraferma
            Label4.Text = "Online"
            Label4.ForeColor = Color.Green
        Else
            Label4.Text = "Offline"
            Label4.ForeColor = Color.Red
        End If

        If ServerPing("198.154.108.218:25566", 25565) = True Then 'Event Server
            Label5.Text = "Online"
            Label5.ForeColor = Color.Green
        Else
            Label5.Text = "Offline"
            Label5.ForeColor = Color.Red
        End If

    End Function

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
        MsgBox(ServerPing("IR.industrial-craft.net", 25565))
    End Sub
End Class