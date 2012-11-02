Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Mail
Public Class FrmClientScreen

#Region "Loadup Actions"
    Private MinecraftExists As Boolean = My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\minecraft.exe")

    Private Sub FrmClientScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            If My.Settings.RememberUserPass = True Then

                ChkboxRememberMe.Checked = True
                txtUsername.Text = My.Settings.Username
                txtPassword.Text = My.Settings.Password
                btnLogin.Focus()
            Else
                ChkboxRememberMe.Checked = False
                txtUsername.Text = My.Settings.Username
                txtPassword.Text = My.Settings.Password
                txtUsername.Focus()
            End If

          

            If CheckServerStatus("google.com", 80) = False Then
                MessageBox.Show("You are not connected to the internet. Please connect and restart application.")

            Else

            End If
            If CheckServerStatus("Login.minecraft.net", 80) = True Then

                btnLogin.Enabled = True
                lblMinecraftServer.ForeColor = Color.Green
                lblMinecraftServer.Text = "Minecraft login servers are up!"
            Else
                lblMinecraftServer.ForeColor = Color.Red
                lblMinecraftServer.Text = "Minecraft login servers are down!"

                btnLogin.Enabled = False
            End If


            If CheckServerStatus("ir.industrial-craft.net", 25565) = True Then
                lblIR.Visible = True
                lblIR.Text = "Industrial-Rage is up!"
                lblIR.ForeColor = Color.Green
            Else

                lblIR.Text = "Industrial-Rage is down!"
                lblIR.ForeColor = Color.Red
            End If


        Catch ex As Exception
            If MessageBox.Show("An error has occured send error report? No personal information is send to the developer", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.EnableSsl = True
                SmtpServer.Credentials = New  _
      Net.NetworkCredential("supportforcodemaster@gmail.com", "codemaster1221715523")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.From = New MailAddress("supportforcodemaster@gmail.com")
                mail.To.Add("supportforcodemaster@gmail.com")
                mail.Subject = "Error Report"
                mail.Body = (ex.Message)
                SmtpServer.Send(mail)
            End If

        End Try

    End Sub
#End Region

#Region "Buttons"
    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
    
        Try

            If ChkboxRememberMe.Checked = True Then
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
            If MessageBox.Show("An error has occured send error report? No personal information is send to the developer", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.EnableSsl = True
                SmtpServer.Credentials = New  _
      Net.NetworkCredential("supportforcodemaster@gmail.com", "codemaster1221715523")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.From = New MailAddress("supportforcodemaster@gmail.com")
                mail.To.Add("supportforcodemaster@gmail.com")
                mail.Subject = "Error Report"
                mail.Body = (ex.Message)
                SmtpServer.Send(mail)
            End If
        End Try

    End Sub

    Private Sub btnOptions_Click(sender As System.Object, e As System.EventArgs) Handles btnOptions.Click
        FrmOption.Show()
    End Sub

#End Region

#Region "Functions"
    Public Function Te()

    End Function

    Public Function CheckServerStatus(IP As String, Port As Integer)
        'Connects to the server via a Tcp packet on a specified port, returns true if connection secessful
        Dim Server As New TcpClient
        Try
            Server.Connect(IP, Port)
            Return True
        Catch Excep As Exception
            Return False
        End Try
    End Function

    Sub download()
        My.Computer.Network.DownloadFile("https://s3.amazonaws.com/MinecraftDownload/launcher/Minecraft.exe", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\minecraft.exe")
    End Sub
#End Region


    Private Sub lblMinecraftServer_Click(sender As System.Object, e As System.EventArgs) Handles lblMinecraftServer.Click
        MsgBox(My.Settings.LastServer & vbNewLine & My.Settings.AutoLogin)
    End Sub
End Class
