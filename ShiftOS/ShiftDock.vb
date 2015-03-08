Public Class ShiftDock
    Dim uod As Integer = 5
    Private Sub ShiftDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mousecheck.Start()
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Me.Width / 2), Screen.PrimaryScreen.Bounds.Height - Me.Height)
    End Sub

    Private Sub icn1_Click(sender As Object, e As EventArgs) Handles icn1.Click
        Downloader.Show()
    End Sub

    Private Sub icn2_Click(sender As Object, e As EventArgs) Handles icn2.Click

    End Sub

    Private Sub icn3_Click(sender As Object, e As EventArgs) Handles icn3.Click

    End Sub

    Private Sub icn4_Click(sender As Object, e As EventArgs) Handles icn4.Click

    End Sub

    Private Sub icn5_Click(sender As Object, e As EventArgs) Handles icn5.Click

    End Sub

    Private Sub icn6_Click(sender As Object, e As EventArgs) Handles icn6.Click

    End Sub

    Private Sub icn7_Click(sender As Object, e As EventArgs) Handles icn7.Click

    End Sub

    Private Sub icn8_Click(sender As Object, e As EventArgs) Handles icn8.Click

    End Sub

    Private Sub icn9_Click(sender As Object, e As EventArgs) Handles icn9.Click

    End Sub

    Private Sub mousecheck_Tick(sender As Object, e As EventArgs) Handles mousecheck.Tick
        If (Cursor.Position.Y > Screen.PrimaryScreen.Bounds.Height - 20) And uod > 1 Then
            uod = -5
            dockanimate.Start()
            mousecheck.Stop()
        ElseIf (Cursor.Position.Y < Screen.PrimaryScreen.Bounds.Height - Me.Height) And uod < 1 Then
            uod = 5
            dockanimate.Start()
            mousecheck.Stop()
        End If
        dockimg.Width = Me.Width
        dockimg.Height = Me.Height
        Content.Width = Me.Width
        Content.Height = Me.Height
    End Sub

    Private Sub dockanimate_Tick(sender As Object, e As EventArgs) Handles dockanimate.Tick
        Content.Location = New Point(Content.Location.X, Content.Location.Y + uod)
        uod = uod + uod
        If (Content.Location.Y < 0) Then
            Content.Location = New Point(Content.Location.X, 0)
            dockanimate.Stop()
            mousecheck.Start()
        ElseIf (Content.Location.Y > Me.Height) Then
            Content.Location = New Point(Content.Location.X, Me.Height)
            dockanimate.Stop()
            mousecheck.Start()
        End If
    End Sub
End Class