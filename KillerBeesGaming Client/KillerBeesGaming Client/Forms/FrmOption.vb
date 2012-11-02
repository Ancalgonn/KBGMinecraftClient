Public Class FrmOption



    Private Sub btnok_Click_1(sender As System.Object, e As System.EventArgs) Handles btnok.Click
 
        Me.Close()
    End Sub



    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub FrmOption_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Select Case My.Settings.LastIndexServer

            Case 0
                ComboBox1.SelectedIndex = 0
            Case 1
                ComboBox1.SelectedIndex = 1
        End Select
        If My.Settings.AutoLogin = True Then

            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.AutoLogin = True

        Else
            My.Settings.AutoLogin = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex

            Case 0
                My.Settings.LastServer = "ir.industrial-craft.net"
                My.Settings.LastIndexServer = 0
            Case 1
                My.Settings.LastIndexServer = 1
                My.Settings.LastServer = "mining.industrial-craft.net"

        End Select
    End Sub
End Class