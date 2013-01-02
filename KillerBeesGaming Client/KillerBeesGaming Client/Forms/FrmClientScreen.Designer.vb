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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientScreen))
        Me.PbrTotal = New System.Windows.Forms.ProgressBar()
        Me.PbrProgress = New System.Windows.Forms.ProgressBar()
        Me.lblTotalProgress = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.chkRememberMe = New System.Windows.Forms.CheckBox()
        Me.CboMinecraftVersion = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.BtnOptions = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtxtTwitter = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMinecraftLoginServers = New System.Windows.Forms.Label()
        Me.lblMinecraftdotnet = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTFCR = New System.Windows.Forms.Label()
        Me.lblER = New System.Windows.Forms.Label()
        Me.lblMining = New System.Windows.Forms.Label()
        Me.lblIR = New System.Windows.Forms.Label()
        Me.lblProgressInfo = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PbrTotal
        '
        Me.PbrTotal.Location = New System.Drawing.Point(6, 48)
        Me.PbrTotal.Name = "PbrTotal"
        Me.PbrTotal.Size = New System.Drawing.Size(267, 23)
        Me.PbrTotal.TabIndex = 12
        '
        'PbrProgress
        '
        Me.PbrProgress.Location = New System.Drawing.Point(6, 19)
        Me.PbrProgress.Name = "PbrProgress"
        Me.PbrProgress.Size = New System.Drawing.Size(267, 23)
        Me.PbrProgress.TabIndex = 11
        '
        'lblTotalProgress
        '
        Me.lblTotalProgress.AutoSize = True
        Me.lblTotalProgress.Location = New System.Drawing.Point(279, 51)
        Me.lblTotalProgress.Name = "lblTotalProgress"
        Me.lblTotalProgress.Size = New System.Drawing.Size(21, 13)
        Me.lblTotalProgress.TabIndex = 14
        Me.lblTotalProgress.Text = "0%"
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(279, 22)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(21, 13)
        Me.lblProgress.TabIndex = 15
        Me.lblProgress.Text = "0%"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUsername)
        Me.GroupBox2.Controls.Add(Me.btnEdit)
        Me.GroupBox2.Controls.Add(Me.chkRememberMe)
        Me.GroupBox2.Controls.Add(Me.CboMinecraftVersion)
        Me.GroupBox2.Controls.Add(Me.txtPassword)
        Me.GroupBox2.Controls.Add(Me.BtnOptions)
        Me.GroupBox2.Controls.Add(Me.btnLogin)
        Me.GroupBox2.Location = New System.Drawing.Point(337, 181)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 121)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Login"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(6, 48)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(181, 20)
        Me.txtUsername.TabIndex = 1
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(193, 17)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'chkRememberMe
        '
        Me.chkRememberMe.AutoSize = True
        Me.chkRememberMe.Location = New System.Drawing.Point(6, 101)
        Me.chkRememberMe.Name = "chkRememberMe"
        Me.chkRememberMe.Size = New System.Drawing.Size(95, 17)
        Me.chkRememberMe.TabIndex = 18
        Me.chkRememberMe.Text = "Remember Me"
        Me.chkRememberMe.UseVisualStyleBackColor = True
        '
        'CboMinecraftVersion
        '
        Me.CboMinecraftVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMinecraftVersion.FormattingEnabled = True
        Me.CboMinecraftVersion.Location = New System.Drawing.Point(6, 19)
        Me.CboMinecraftVersion.MaxDropDownItems = 10
        Me.CboMinecraftVersion.Name = "CboMinecraftVersion"
        Me.CboMinecraftVersion.Size = New System.Drawing.Size(181, 21)
        Me.CboMinecraftVersion.TabIndex = 18
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(6, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(181, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'BtnOptions
        '
        Me.BtnOptions.Location = New System.Drawing.Point(193, 46)
        Me.BtnOptions.Name = "BtnOptions"
        Me.BtnOptions.Size = New System.Drawing.Size(75, 23)
        Me.BtnOptions.TabIndex = 4
        Me.BtnOptions.Text = "Option"
        Me.BtnOptions.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(193, 75)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtxtTwitter)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 163)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Twitter"
        '
        'rtxtTwitter
        '
        Me.rtxtTwitter.BackColor = System.Drawing.Color.White
        Me.rtxtTwitter.Location = New System.Drawing.Point(7, 15)
        Me.rtxtTwitter.Name = "rtxtTwitter"
        Me.rtxtTwitter.ReadOnly = True
        Me.rtxtTwitter.Size = New System.Drawing.Size(313, 142)
        Me.rtxtTwitter.TabIndex = 0
        Me.rtxtTwitter.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnRefresh)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblMinecraftLoginServers)
        Me.GroupBox3.Controls.Add(Me.lblMinecraftdotnet)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lblTFCR)
        Me.GroupBox3.Controls.Add(Me.lblER)
        Me.GroupBox3.Controls.Add(Me.lblMining)
        Me.GroupBox3.Controls.Add(Me.lblIR)
        Me.GroupBox3.Location = New System.Drawing.Point(337, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 163)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Server Statuses"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(193, 19)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(133, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Offline"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(133, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Offline"
        '
        'lblMinecraftLoginServers
        '
        Me.lblMinecraftLoginServers.AutoSize = True
        Me.lblMinecraftLoginServers.Location = New System.Drawing.Point(9, 134)
        Me.lblMinecraftLoginServers.Name = "lblMinecraftLoginServers"
        Me.lblMinecraftLoginServers.Size = New System.Drawing.Size(122, 13)
        Me.lblMinecraftLoginServers.TabIndex = 11
        Me.lblMinecraftLoginServers.Text = "Minecraft Login Servers:"
        '
        'lblMinecraftdotnet
        '
        Me.lblMinecraftdotnet.AutoSize = True
        Me.lblMinecraftdotnet.Location = New System.Drawing.Point(59, 111)
        Me.lblMinecraftdotnet.Name = "lblMinecraftdotnet"
        Me.lblMinecraftdotnet.Size = New System.Drawing.Size(72, 13)
        Me.lblMinecraftdotnet.TabIndex = 10
        Me.lblMinecraftdotnet.Text = "Minecraft.net:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(133, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Offline"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(133, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Offline"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(133, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Offline"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(133, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Offline"
        '
        'lblTFCR
        '
        Me.lblTFCR.AutoSize = True
        Me.lblTFCR.Location = New System.Drawing.Point(37, 89)
        Me.lblTFCR.Name = "lblTFCR"
        Me.lblTFCR.Size = New System.Drawing.Size(93, 13)
        Me.lblTFCR.TabIndex = 3
        Me.lblTFCR.Text = "TerraFerma Rage:"
        '
        'lblER
        '
        Me.lblER.AutoSize = True
        Me.lblER.Location = New System.Drawing.Point(55, 67)
        Me.lblER.Name = "lblER"
        Me.lblER.Size = New System.Drawing.Size(76, 13)
        Me.lblER.TabIndex = 2
        Me.lblER.Text = "Endless Rage:"
        '
        'lblMining
        '
        Me.lblMining.AutoSize = True
        Me.lblMining.Location = New System.Drawing.Point(59, 45)
        Me.lblMining.Name = "lblMining"
        Me.lblMining.Size = New System.Drawing.Size(72, 13)
        Me.lblMining.TabIndex = 1
        Me.lblMining.Text = "Mining World:"
        '
        'lblIR
        '
        Me.lblIR.AutoSize = True
        Me.lblIR.Location = New System.Drawing.Point(50, 22)
        Me.lblIR.Name = "lblIR"
        Me.lblIR.Size = New System.Drawing.Size(81, 13)
        Me.lblIR.TabIndex = 0
        Me.lblIR.Text = "Industrial Rage:"
        '
        'lblProgressInfo
        '
        Me.lblProgressInfo.AutoSize = True
        Me.lblProgressInfo.Location = New System.Drawing.Point(6, 83)
        Me.lblProgressInfo.Name = "lblProgressInfo"
        Me.lblProgressInfo.Size = New System.Drawing.Size(138, 13)
        Me.lblProgressInfo.TabIndex = 18
        Me.lblProgressInfo.Text = "Progress Info Goes Here....."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.PbrProgress)
        Me.GroupBox4.Controls.Add(Me.lblProgressInfo)
        Me.GroupBox4.Controls.Add(Me.PbrTotal)
        Me.GroupBox4.Controls.Add(Me.lblTotalProgress)
        Me.GroupBox4.Controls.Add(Me.lblProgress)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(319, 116)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Progress"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Rock Texture.bmp")
        Me.ImageList1.Images.SetKeyName(1, "Sand Texture.bmp")
        Me.ImageList1.Images.SetKeyName(2, "t.bmp")
        Me.ImageList1.Images.SetKeyName(3, "keen.jpg")
        '
        'UpdateTimer
        '
        Me.UpdateTimer.Interval = 500
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        '
        'FrmClientScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(633, 309)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaximizeBox = False
        Me.Name = "FrmClientScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KBG Client v2.0 Beta"
        Me.TransparencyKey = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents CboMinecraftVersion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMinecraftdotnet As System.Windows.Forms.Label
    Friend WithEvents lblMinecraftLoginServers As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkRememberMe As System.Windows.Forms.CheckBox
    Friend WithEvents lblProgressInfo As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents rtxtTwitter As System.Windows.Forms.RichTextBox
    Friend WithEvents UpdateTimer As System.Windows.Forms.Timer
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
