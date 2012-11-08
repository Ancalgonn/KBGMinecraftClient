<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientScreen))
        Me.PbrTotal = New System.Windows.Forms.ProgressBar()
        Me.PbrProgress = New System.Windows.Forms.ProgressBar()
        Me.lblTotalProgress = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboUser = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.BtnOptions = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMinecraftLoginServers = New System.Windows.Forms.Label()
        Me.lblMinecraftdotnet = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEventServer = New System.Windows.Forms.Label()
        Me.lblTFCR = New System.Windows.Forms.Label()
        Me.lblER = New System.Windows.Forms.Label()
        Me.lblMining = New System.Windows.Forms.Label()
        Me.lblIR = New System.Windows.Forms.Label()
        Me.chkRememberMe = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PbrTotal
        '
        Me.PbrTotal.Location = New System.Drawing.Point(12, 383)
        Me.PbrTotal.Name = "PbrTotal"
        Me.PbrTotal.Size = New System.Drawing.Size(291, 23)
        Me.PbrTotal.TabIndex = 12
        '
        'PbrProgress
        '
        Me.PbrProgress.Location = New System.Drawing.Point(12, 354)
        Me.PbrProgress.Name = "PbrProgress"
        Me.PbrProgress.Size = New System.Drawing.Size(291, 23)
        Me.PbrProgress.TabIndex = 11
        '
        'lblTotalProgress
        '
        Me.lblTotalProgress.AutoSize = True
        Me.lblTotalProgress.Location = New System.Drawing.Point(309, 383)
        Me.lblTotalProgress.Name = "lblTotalProgress"
        Me.lblTotalProgress.Size = New System.Drawing.Size(21, 13)
        Me.lblTotalProgress.TabIndex = 14
        Me.lblTotalProgress.Text = "0%"
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(309, 354)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(13, 13)
        Me.lblProgress.TabIndex = 15
        Me.lblProgress.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkRememberMe)
        Me.GroupBox2.Controls.Add(Me.CboUser)
        Me.GroupBox2.Controls.Add(Me.txtPassword)
        Me.GroupBox2.Controls.Add(Me.BtnOptions)
        Me.GroupBox2.Controls.Add(Me.btnLogin)
        Me.GroupBox2.Location = New System.Drawing.Point(336, 335)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(285, 93)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Login"
        '
        'CboUser
        '
        Me.CboUser.FormattingEnabled = True
        Me.CboUser.Location = New System.Drawing.Point(6, 19)
        Me.CboUser.Name = "CboUser"
        Me.CboUser.Size = New System.Drawing.Size(181, 21)
        Me.CboUser.TabIndex = 18
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(6, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(181, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'BtnOptions
        '
        Me.BtnOptions.Location = New System.Drawing.Point(193, 19)
        Me.BtnOptions.Name = "BtnOptions"
        Me.BtnOptions.Size = New System.Drawing.Size(75, 23)
        Me.BtnOptions.TabIndex = 1
        Me.BtnOptions.Text = "Option"
        Me.BtnOptions.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(193, 48)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 0
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(312, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 181)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Twitter"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblMinecraftLoginServers)
        Me.GroupBox3.Controls.Add(Me.lblMinecraftdotnet)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lblEventServer)
        Me.GroupBox3.Controls.Add(Me.lblTFCR)
        Me.GroupBox3.Controls.Add(Me.lblER)
        Me.GroupBox3.Controls.Add(Me.lblMining)
        Me.GroupBox3.Controls.Add(Me.lblIR)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(291, 181)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Server Statuses"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(135, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Offline"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(135, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Offline"
        '
        'lblMinecraftLoginServers
        '
        Me.lblMinecraftLoginServers.AutoSize = True
        Me.lblMinecraftLoginServers.Location = New System.Drawing.Point(11, 160)
        Me.lblMinecraftLoginServers.Name = "lblMinecraftLoginServers"
        Me.lblMinecraftLoginServers.Size = New System.Drawing.Size(122, 13)
        Me.lblMinecraftLoginServers.TabIndex = 11
        Me.lblMinecraftLoginServers.Text = "Minecraft Login Servers:"
        '
        'lblMinecraftdotnet
        '
        Me.lblMinecraftdotnet.AutoSize = True
        Me.lblMinecraftdotnet.Location = New System.Drawing.Point(61, 137)
        Me.lblMinecraftdotnet.Name = "lblMinecraftdotnet"
        Me.lblMinecraftdotnet.Size = New System.Drawing.Size(72, 13)
        Me.lblMinecraftdotnet.TabIndex = 10
        Me.lblMinecraftdotnet.Text = "Minecraft.net:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(135, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Offline"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(135, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Offline"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(135, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Offline"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(135, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Offline"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(135, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Offline"
        '
        'lblEventServer
        '
        Me.lblEventServer.AutoSize = True
        Me.lblEventServer.Location = New System.Drawing.Point(67, 115)
        Me.lblEventServer.Name = "lblEventServer"
        Me.lblEventServer.Size = New System.Drawing.Size(65, 13)
        Me.lblEventServer.TabIndex = 4
        Me.lblEventServer.Text = "Test Server:"
        '
        'lblTFCR
        '
        Me.lblTFCR.AutoSize = True
        Me.lblTFCR.Location = New System.Drawing.Point(39, 93)
        Me.lblTFCR.Name = "lblTFCR"
        Me.lblTFCR.Size = New System.Drawing.Size(93, 13)
        Me.lblTFCR.TabIndex = 3
        Me.lblTFCR.Text = "TerraFerma Rage:"
        '
        'lblER
        '
        Me.lblER.AutoSize = True
        Me.lblER.Location = New System.Drawing.Point(57, 71)
        Me.lblER.Name = "lblER"
        Me.lblER.Size = New System.Drawing.Size(76, 13)
        Me.lblER.TabIndex = 2
        Me.lblER.Text = "Endless Rage:"
        '
        'lblMining
        '
        Me.lblMining.AutoSize = True
        Me.lblMining.Location = New System.Drawing.Point(61, 49)
        Me.lblMining.Name = "lblMining"
        Me.lblMining.Size = New System.Drawing.Size(72, 13)
        Me.lblMining.TabIndex = 1
        Me.lblMining.Text = "Mining World:"
        '
        'lblIR
        '
        Me.lblIR.AutoSize = True
        Me.lblIR.Location = New System.Drawing.Point(52, 26)
        Me.lblIR.Name = "lblIR"
        Me.lblIR.Size = New System.Drawing.Size(81, 13)
        Me.lblIR.TabIndex = 0
        Me.lblIR.Text = "Industrial Rage:"
        '
        'chkRememberMe
        '
        Me.chkRememberMe.AutoSize = True
        Me.chkRememberMe.Location = New System.Drawing.Point(6, 74)
        Me.chkRememberMe.Name = "chkRememberMe"
        Me.chkRememberMe.Size = New System.Drawing.Size(92, 17)
        Me.chkRememberMe.TabIndex = 18
        Me.chkRememberMe.Text = "RememberMe"
        Me.chkRememberMe.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(313, 193)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(308, 136)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Forum Posts"
        '
        'FrmClientScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(633, 440)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.PbrProgress)
        Me.Controls.Add(Me.lblTotalProgress)
        Me.Controls.Add(Me.PbrTotal)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmClientScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KBG Client v1.1 Beta"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PbrTotal As System.Windows.Forms.ProgressBar
    Friend WithEvents PbrProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTotalProgress As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents BtnOptions As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblIR As System.Windows.Forms.Label
    Friend WithEvents lblMining As System.Windows.Forms.Label
    Friend WithEvents lblER As System.Windows.Forms.Label
    Friend WithEvents lblTFCR As System.Windows.Forms.Label
    Friend WithEvents lblEventServer As System.Windows.Forms.Label
    Friend WithEvents CboUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMinecraftdotnet As System.Windows.Forms.Label
    Friend WithEvents lblMinecraftLoginServers As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkRememberMe As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox

End Class
