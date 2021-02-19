Public Class Form1

    Public isPlaying As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPlayPause.Click

        If isPlaying = True Then

            isPlaying = False

        ElseIf isPlaying = False Then

            isPlaying = True

        End If

    End Sub

    Private Sub always_Tick(sender As Object, e As EventArgs) Handles always.Tick

        If isPlaying = True Then

            btnPlayPause.Text = "⏸"

        ElseIf isPlaying = False Then

            btnPlayPause.Text = "▶"

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        MessageBox.Show("N9RAWJMI3 PLAYER: Made by DD2476 for N9RAWJMI3.", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
