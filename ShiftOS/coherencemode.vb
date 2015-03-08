Module coherencemode
    Private CoherenceModeProgramForm As New coherencemodeform
    Public AnyOtherProgram As Boolean = False

    Public Sub setupwindows(ByVal programname As String)
        If AnyOtherProgram = False Then
            Try
                Dim NewProgramName As String = programname.ToLower
                Dim win As Window = Window.Find(NewProgramName)
                Dim PreviouwWindowSize As System.Drawing.Size = win.Size
                CoherenceModeProgramForm.programnametokeep = win
                win.Style(Window.Styles.Border) = False
                win.Style(Window.Styles.Sizable) = False
                win.Invalidate()
                'win.Size = New Size(0, 0)
                'win.Size = PreviouwWindowSize

                CoherenceModeProgramForm.Show()
                win.Location = New Point(CoherenceModeProgramForm.Location.X, CoherenceModeProgramForm.Location.Y + ShiftOSDesktop.titlebarheight)
                win.TopMost = True
                CoherenceModeProgramForm.TopMost = True
                CoherenceModeProgramForm.Focus()
                CoherenceModeProgramForm.Size = PreviouwWindowSize
                win.Text = CoherenceModeProgramForm.lbtitletext.Text
                CoherenceModeProgramForm.resettitlebar()
                CoherenceModeProgramForm.setuptitlebar()
                CoherenceModeProgramForm.setupborders()
                CoherenceModeProgramForm.pgcontents.BackColor = Color.FromArgb(1, 0, 1)

                AnyOtherProgram = True
            Catch ex As Exception
                infobox.showinfo("Critical Error - Coherence Mode", "A Critical error occured whilst attempting to join the program")
            End Try
        Else
            infobox.showinfo("Information - Coherence Mode", "You can only have one program within coherence mode at any given time, this includes only one mod open for the moment, this is soon to change")
        End If
    End Sub

End Module
