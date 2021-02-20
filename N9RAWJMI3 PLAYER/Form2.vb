Public Class Form2

    Public canExit As Boolean = False

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If canExit = False Then

            e.Cancel = True

            Me.Hide()

        End If

    End Sub

End Class