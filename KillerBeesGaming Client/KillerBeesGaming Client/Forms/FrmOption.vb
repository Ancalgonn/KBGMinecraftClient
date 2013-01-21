Public Class FrmOption



    Private Sub btnok_Click_1(sender As System.Object, e As System.EventArgs) Handles btnok.Click
 
        Me.Close()
    End Sub



    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnForceUpdate.Click
        Dim Force As New Update
        MsgBox("Force Updating! This will overwrite everthing including your saved settings!" & vbNewLine & vbNewLine & "Please wait while the update completes.")

        Force.ForceUpdate()

    End Sub

    Private Sub chkCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCheck.CheckedChanged
        If chkCheck.Checked = True Then
            My.Settings.PingServers = True
        Else
            My.Settings.PingServers = False
        End If
    End Sub

    Private Sub chktwitter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chktwitter.CheckedChanged
        If chktwitter.Checked = True Then
            My.Settings.GetTwitter = True
        Else
            My.Settings.GetTwitter = False
        End If
    End Sub
End Class