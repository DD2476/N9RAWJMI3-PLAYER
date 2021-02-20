
Imports System
Imports System.IO
Imports System.Drawing
Imports System.IO.Compression
Imports NAudio.Wave
Imports WMPLib 'Media Player in virtual form

Public Class Form1

    Public isPlaying As Boolean = False
    Public ofd As New OpenFileDialog
    Public WithEvents mp As New WindowsMediaPlayer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPlayPause.Click

        If isPlaying = True Then

            isPlaying = False

            mp.controls.pause()

        ElseIf isPlaying = False Then

            If Form2.ListBox1.Items.Count <> 0 Then

                isPlaying = True

                If mp.URL = "" Then

                    If Form2.ListBox1.SelectedIndex = -1 Then

                        Form2.ListBox1.SelectedIndex = 0

                        mp.URL = Form2.ListBox1.SelectedItem

                    Else

                        mp.URL = Form2.ListBox1.SelectedItem

                    End If

                Else

                    mp.controls.play()

                End If

            End If

        Else

            isPlaying = False

        End If

    End Sub

    Private Sub always_Tick(sender As Object, e As EventArgs) Handles always.Tick

        If isPlaying = True Then

            btnPlayPause.Text = "⏸"

        ElseIf isPlaying = False Then

            btnPlayPause.Text = "▶"

        End If

        If TrackBar1.Capture = False Then

            TrackBar1.Value = mp.controls.currentPosition

        End If

        If mp.URL <> "" Then

            TrackBar1.Maximum = mp.currentMedia.duration

            If mp.playState = WMPLib.WMPPlayState.wmppsStopped Then

                isPlaying = False

            End If

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        MessageBox.Show("N9RAWJMI3 PLAYER: Made by DD2476 for N9RAWJMI3.", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ofd.ShowDialog = DialogResult.OK Then

            For Each a As String In ofd.FileNames

                Form2.ListBox1.Items.Add(a)

            Next

            MessageBox.Show("Music added to playlist.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Form2.Show()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ofd.Filter = "Music Files|*.MP4A; *.M4A; *.MP3; *.WAV; *.WMA; *.OGG"
        ofd.Multiselect = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Form2.ListBox1.Items.RemoveAt(Form2.ListBox1.SelectedIndex)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        If Form2.ListBox1.SelectedIndex > 0 Then

            'If isPlaying = True Then

            'btnPlayPause.PerformClick()

            'End If

            Form2.ListBox1.SelectedIndex -= 1

            mp.URL = Form2.ListBox1.SelectedItem

            If isPlaying = False Then

                btnPlayPause.PerformClick()

            End If

        End If

    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click

        If Form2.ListBox1.SelectedIndex < (Form2.ListBox1.Items.Count - 1) Then

            'If isPlaying = True Then

            'btnPlayPause.PerformClick()

            'End If

            Form2.ListBox1.SelectedIndex += 1

            mp.URL = Form2.ListBox1.SelectedItem

            If isPlaying = False Then

                btnPlayPause.PerformClick()

            End If

        End If

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        mp.controls.currentPosition = TrackBar1.Value

    End Sub

End Class