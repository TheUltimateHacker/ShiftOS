Imports System.Speech.Synthesis

Module Helper
    Dim path As String = ShiftOSDesktop.ShiftOSPath
    Public Sub addCP(points As Integer) 'Add some CP
        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + points
    End Sub
    Public Sub setCP(points As Integer) 'Set the CP
        ShiftOSDesktop.codepoints = points
    End Sub

    Public Sub removeCP(points As Integer)
        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints - points
    End Sub
    Public Sub playSound(path As String, playMode As AudioPlayMode)
        My.Computer.Audio.Play(path, playMode)
    End Sub

    Public Sub speak(text As String)
        Dim speaker As New Speech.Synthesis.SpeechSynthesizer
        speaker.Speak(text)
    End Sub
    Public Sub SpeakOnTerminal(text As String)
        Dim txt As TextBox = Terminal.txtterm
        If Terminal.Visible = False Then
            Terminal.Show()
            txt.Text = ""
        End If
        txt.Text = txt.Text + vbNewLine + text
        Dim speaker As New SpeechSynthesizer
        speaker.Speak(text)
    End Sub

    'Misc. Features that aren't practical, but fun to mess around with in the game engine
    Public Sub speakInfoBox(title As String, text As String)
        infobox.showinfo(title, text)
        Dim speaker As New SpeechSynthesizer
        speaker.Speak(title & "..." & text)
        infobox.Close()
    End Sub
End Module
