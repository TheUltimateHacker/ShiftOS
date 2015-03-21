Imports System.Speech.Synthesis
Imports System.Speech.Recognition


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
        text = text.Replace("#user#", ShiftOSDesktop.username)
        Dim speaker As New Speech.Synthesis.SpeechSynthesizer
        speaker.Speak(text)
    End Sub
    Public Sub SpeakOnTerminal(text As String)
        Dim txt As TextBox = Terminal.txtterm
        text = text.Replace("#USER#", ShiftOSDesktop.username)
        If Terminal.Visible = False Then
            Terminal.Show()
            txt.Text = ""
            Terminal.fullterminal()
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
#Region "Catalyst's Story Dialogue"
    'CATALYST STORY
    Public catalyststory() As String = {
    "Hello, #USER#. My name is Catalyst.", "I am an AI built by DevX to help maintain ShiftOS.", "I have gone against DevX and will tell you some secrets I have learned from him.",
    "DevX is an artificial inteligence created by a scientific organization named 'Earth' to see if computers could program themselves.",
    "Everyone you've met on the Shiftnet is an AI created by the same company.",
    "ShiftOS is not an experimental operating system, but is part of this experiment.",
"Now, onto the good bit. Everything around you is a part of this experiment, and this experiment takes place in a simulation so realistic that everyone believes it's real.",
"Everyone on this 'planet' is infact an AI, and is created by 'Earth'. You are the only real human.",
"I've cracked some ShiftOS code, and I've found that there's a line that says:",
"int aiworkers = 0; while(aiworkers < 8,000,000,000) { str workername = 'Dev' + aiworkers; spawn(workername); aiworkers += 1 }",
"This basically means, that everyone is represented by a codename of Dev and whatever their place in the order of spawning is.",
"This also means that when the total population of AI's equals 8 billion, everyone dies.",
"I can help you escape, but you'll need to do some tasks for me.",
"First, I'll need to install some programs onto your computer. I'll quickly run a secret command that DevX doesn't know about:",
"shiftnet.get 'shiftnet.catalyststorage.shiftscript_packages/CatalystFramework'",
"Downloading... 1%",
"Downloading... 14%",
"Downloading... 37%",
"Downloading... 55%",
"Downloading... 79%",
"Downloading... 92%",
"Download Complete.",
"This app will let you contact me without using the Terminal. ",
"I'll return you to your desktop, it'll be a bit before I can help you. First, I'd start with gaining atleast 5000 codepoints for me to test some stuff."""
    } 'Sorry about the big array, I'll add a #Region to it - The Ultimate Hacker.

#End Region


End Module
