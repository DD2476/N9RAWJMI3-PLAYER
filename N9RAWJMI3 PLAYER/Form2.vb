Public Class Form2

    Public canExit As Boolean = False

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If canExit = False Then

            e.Cancel = True

            Me.Hide()

        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Form1.isPlaying = False

        Form1.mp.URL = ListBox1.SelectedItem

        Form1.isPlaying = True

        Form1.mp.controls.play()

    End Sub

End Class