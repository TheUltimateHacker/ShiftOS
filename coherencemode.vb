Module coherencemode
    Dim fakeform As New template

    Public Sub setupwindows(ByVal programname As String)
        Dim win As Window = Window.Find(programname)
        win.Style(Window.Styles.Border) = False
        win.Style(Window.Styles.Sizable) = False
        win.Size = New Size(win.Size.Width + 1, win.Size.Height + 1)
        win.Invalidate()

        fakeform.Show()
        fakeform.Location = win.Location
        fakeform.Size = win.Size
        fakeform.lbtitletext.Text = win.Text
        fakeform.resettitlebar()
        fakeform.pgcontents.BackColor = Color.FromArgb(1, 0, 1)
    End Sub

End Module
