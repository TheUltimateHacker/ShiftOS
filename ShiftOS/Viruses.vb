Module Viruses

    Public Sub startactiveviruses()
        If zerogravity Then setupzerovirus()
        If mousetrap Then setupmousetrapvirus()
        If beeper Then setupbeepervirus()
        If ThePlague Then setuptheplague()
    End Sub

    'Zero Varibles
    Public WithEvents zerogravitytimer As New Timer
    Public zerogravity As Boolean = False
    Public zerogravitythreatlevel As Integer = 1
    Public zerogravityxspeed(33) As Integer
    Public zerogravityyspeed(33) As Integer
    Public zerogravityspeedth1 = 1
    Public zerogravityspeedth2 = 2
    Public zerogravityspeedth3 = 4
    Public zerogravityspeedth4 = 8


    'Mouse Trap Varibles
    Public WithEvents mousetraptimer As New Timer
    Public WithEvents cooldowntraptimer As New Timer
    Public mousetrap As Boolean = False
    Public mousetrapthreatlevel As Integer = 1
    Public mousetraped As Boolean = False
    Public bangstoescape As Integer = 20
    Public trappedwindow As Integer = 0
    Public bangvelocity As Integer
    Public bangforceneeded As Integer = 30
    Public trapcooldown As Integer = 20
    Public trap1 As Boolean = False
    Public trap2 As Boolean = False
    Public trap3 As Boolean = False
    Public trap4 As Boolean = False
    Public alreadytrapped As Boolean = False
    Public trappedprogram As Form
    Public bangstoescapeth1 As Integer = 20
    Public bangstoescapeth2 As Integer = 40
    Public bangstoescapeth3 As Integer = 60
    Public bangstoescapeth4 As Integer = 80
    Public bangforceneeded1 As Integer = 30
    Public bangforceneeded2 As Integer = 50
    Public bangforceneeded3 As Integer = 80
    Public bangforceneeded4 As Integer = 120
    Public trapcooldown1 As Integer = 60
    Public trapcooldown2 As Integer = 30
    Public trapcooldown3 As Integer = 15
    Public trapcooldown4 As Integer = 10

    'Beeper Varibles
    Public WithEvents beepertimer As New Timer
    Public beeper As Boolean = False
    Public beeperthreatlevel As Integer = 1
    Public beepercountdown As Integer
    Dim ResourceFilePath As String
    Dim soundplayer As AxWMPLib.AxWindowsMediaPlayer
    Dim beeperinterval As Integer = 5

    'ThePlague Variables
    Public WithEvents theplaguebsod As New Timer
    Public WithEvents theplaguetimer As New Timer
    Public RandomApplicationName As String
    Public theplaguethreatlevel As Integer = 1
    Public ThePlague As Boolean = False
    Public ChanceOfDestroyThePlague As Integer

    'Zero Virus
    Public Sub setupzerovirus()
        setupzerogravityspeeds()
        zerogravitytimer.Start()
        zerogravitytimer.Interval = 20
    End Sub

    Public Sub setupzerogravityspeeds()
        For i = 0 To 33
            If i Mod 2 <> 0 Then
                Select Case zerogravitythreatlevel
                    Case 1
                        zerogravityxspeed(i) = zerogravityspeedth1
                        zerogravityyspeed(i) = zerogravityspeedth1
                    Case 2
                        zerogravityxspeed(i) = zerogravityspeedth2
                        zerogravityyspeed(i) = zerogravityspeedth2
                    Case 3
                        zerogravityxspeed(i) = zerogravityspeedth3
                        zerogravityyspeed(i) = zerogravityspeedth3
                    Case 4
                        zerogravityxspeed(i) = zerogravityspeedth4
                        zerogravityyspeed(i) = zerogravityspeedth4
                End Select

            Else
                Select Case zerogravitythreatlevel
                    Case 1
                        zerogravityxspeed(i) = -zerogravityspeedth1
                        zerogravityyspeed(i) = -zerogravityspeedth1
                    Case 2
                        zerogravityxspeed(i) = -zerogravityspeedth2
                        zerogravityyspeed(i) = -zerogravityspeedth2
                    Case 3
                        zerogravityxspeed(i) = -zerogravityspeedth3
                        zerogravityyspeed(i) = -zerogravityspeedth3
                    Case 4
                        zerogravityxspeed(i) = -zerogravityspeedth4
                        zerogravityyspeed(i) = -zerogravityspeedth4
                End Select
            End If
        Next
    End Sub

    Public Sub floatingwindows() Handles zerogravitytimer.Tick
        If Knowledge_Input.Visible = True Then calculatelocations(Knowledge_Input, 0)
        If Shiftorium.Visible = True Then calculatelocations(Shiftorium, 1)
        If Clock.Visible = True Then calculatelocations(Clock, 2)
        If Shifter.Visible = True Then calculatelocations(Shifter, 3)
        If Colour_Picker.Visible = True Then calculatelocations(Colour_Picker, 4)
        If infobox.Visible = True Then calculatelocations(infobox, 5)
        If Pong.Visible = True Then calculatelocations(Pong, 6)
        If File_Skimmer.Visible = True Then calculatelocations(File_Skimmer, 7)
        If File_Opener.Visible = True Then calculatelocations(File_Opener, 8)
        If File_Saver.Visible = True Then calculatelocations(File_Saver, 9)
        If TextPad.Visible = True Then calculatelocations(TextPad, 10)
        If Graphic_Picker.Visible = True Then calculatelocations(Graphic_Picker, 11)
        If Skin_Loader.Visible = True Then calculatelocations(Skin_Loader, 12)
        If ArtPad.Visible = True Then calculatelocations(ArtPad, 13)
        If Calculator.Visible = True Then calculatelocations(Calculator, 14)
        If Audio_Player.Visible = True Then calculatelocations(Audio_Player, 15)
        If Web_Browser.Visible = True Then calculatelocations(Web_Browser, 16)
        If Video_Player.Visible = True Then calculatelocations(Video_Player, 17)
        If Name_Changer.Visible = True Then calculatelocations(Name_Changer, 18)
        If Icon_Manager.Visible = True Then calculatelocations(Icon_Manager, 19)
        If Bitnote_Wallet.Visible = True Then calculatelocations(Bitnote_Wallet, 20)
        If Bitnote_Digger.Visible = True Then calculatelocations(Bitnote_Digger, 21)
        If Skinshifter.Visible = True Then calculatelocations(Skinshifter, 22)
        If Shiftnet.Visible = True Then calculatelocations(Shiftnet, 23)
        If Downloader.Visible = True Then calculatelocations(Downloader, 24)
        If Dodge.Visible = True Then calculatelocations(Dodge, 25)
        If Downloadmanager.Visible = True Then calculatelocations(Downloadmanager, 26)
        If Installer.Visible = True Then calculatelocations(Installer, 27)
        If systeminfo.Visible = True Then calculatelocations(systeminfo, 28)
        If OrcWrite.Visible = True Then calculatelocations(OrcWrite, 29)
        If FloodGate_Manager.Visible = True Then calculatelocations(FloodGate_Manager, 30)
        If Labyrinth.Visible = True Then calculatelocations(Labyrinth, 31)
        If VirusScanner.Visible = True Then calculatelocations(VirusScanner, 32)
        If Terminal.Visible = True Then calculatelocations(Terminal, 33)
    End Sub

    Public Sub calculatelocations(ByVal program As Form, ByVal number As Integer)
        If zerogravityxspeed(number) > 0 Then
            If (program.Location.X + program.Size.Width) > Screen.PrimaryScreen.Bounds.Width Then
                zerogravityxspeed(number) = zerogravityxspeed(number) * -1
            End If
        End If
        If zerogravityxspeed(number) < 0 Then
            If program.Location.X < 0 Then
                zerogravityxspeed(number) = zerogravityxspeed(number) * -1
            End If
        End If
        If zerogravityyspeed(number) > 0 Then
            If (program.Location.Y + program.Size.Height) > Screen.PrimaryScreen.Bounds.Height Then
                zerogravityyspeed(number) = zerogravityyspeed(number) * -1
            End If
        End If
        If zerogravityyspeed(number) < 0 Then
            If program.Location.Y < 0 Then
                zerogravityyspeed(number) = zerogravityyspeed(number) * -1
            End If
        End If
        program.Location = New Point(program.Location.X + zerogravityxspeed(number), program.Location.Y + zerogravityyspeed(number))
    End Sub

    Public Sub removezerovirus()
        zerogravitytimer.Stop()
        Viruses.zerogravity = False
    End Sub

    'Mouse Trap Virus
    Public Sub setupmousetrapvirus()
        mousetraptimer.Start()
        mousetraptimer.Interval = 20
        cooldowntraptimer.Start()
        cooldowntraptimer.Interval = 1000
        Select Case mousetrapthreatlevel
            Case 1
                trapcooldown = trapcooldown1
                bangforceneeded = bangforceneeded1
                bangstoescape = bangstoescapeth1
            Case 2
                trapcooldown = trapcooldown2
                bangforceneeded = bangforceneeded2
                bangstoescape = bangstoescapeth2
            Case 3
                trapcooldown = trapcooldown3
                bangforceneeded = bangforceneeded3
                bangstoescape = bangstoescapeth3
            Case 4
                trapcooldown = trapcooldown4
                bangforceneeded = bangforceneeded4
                bangstoescape = bangstoescapeth4
        End Select

    End Sub

    Public Sub seeifcantrap(ByVal sender As Object, ByVal e As EventArgs) Handles cooldowntraptimer.Tick
        If trapcooldown < 0 Then
            mousetraped = True
        Else
            trapcooldown = trapcooldown - 1
        End If
    End Sub

    Public Sub trapmouse(ByVal sender As Object, ByVal e As EventArgs) Handles mousetraptimer.Tick
        If mousetraped = True Then
            If alreadytrapped = False Then detectprogramtotrap(Knowledge_Input)
            If alreadytrapped = False Then detectprogramtotrap(Shiftorium)
            If alreadytrapped = False Then detectprogramtotrap(Clock)
            If alreadytrapped = False Then detectprogramtotrap(Shifter)
            If alreadytrapped = False Then detectprogramtotrap(Colour_Picker)
            If alreadytrapped = False Then detectprogramtotrap(infobox)
            If alreadytrapped = False Then detectprogramtotrap(Pong)
            If alreadytrapped = False Then detectprogramtotrap(File_Skimmer)
            If alreadytrapped = False Then detectprogramtotrap(File_Opener)
            If alreadytrapped = False Then detectprogramtotrap(File_Saver)
            If alreadytrapped = False Then detectprogramtotrap(TextPad)
            If alreadytrapped = False Then detectprogramtotrap(Graphic_Picker)
            If alreadytrapped = False Then detectprogramtotrap(Skin_Loader)
            If alreadytrapped = False Then detectprogramtotrap(ArtPad)
            If alreadytrapped = False Then detectprogramtotrap(Calculator)
            If alreadytrapped = False Then detectprogramtotrap(Audio_Player)
            If alreadytrapped = False Then detectprogramtotrap(Web_Browser)
            If alreadytrapped = False Then detectprogramtotrap(Video_Player)
            If alreadytrapped = False Then detectprogramtotrap(Name_Changer)
            If alreadytrapped = False Then detectprogramtotrap(Icon_Manager)
            If alreadytrapped = False Then detectprogramtotrap(Bitnote_Wallet)
            If alreadytrapped = False Then detectprogramtotrap(Bitnote_Digger)
            If alreadytrapped = False Then detectprogramtotrap(Skinshifter)
            If alreadytrapped = False Then detectprogramtotrap(Shiftnet)
            If alreadytrapped = False Then detectprogramtotrap(Dodge)
            If alreadytrapped = False Then detectprogramtotrap(Downloadmanager)
            If alreadytrapped = False Then detectprogramtotrap(Installer)
            If alreadytrapped = False Then detectprogramtotrap(systeminfo)
            If alreadytrapped = False Then detectprogramtotrap(OrcWrite)
            If alreadytrapped = False Then detectprogramtotrap(FloodGate_Manager)
            If alreadytrapped = False Then detectprogramtotrap(Labyrinth)
            If alreadytrapped = False Then detectprogramtotrap(VirusScanner)
            If trappedprogram Is Nothing Then  Else trapmouseinprogram(trappedprogram)
            If bangstoescape < 0 Then
                mousetraped = False
                Select Case mousetrapthreatlevel
                    Case 1
                        trapcooldown = trapcooldown1
                        bangstoescape = bangstoescapeth1
                    Case 2
                        trapcooldown = trapcooldown2
                        bangstoescape = bangstoescapeth2
                    Case 3
                        trapcooldown = trapcooldown3
                        bangstoescape = bangstoescapeth3
                    Case 4
                        trapcooldown = trapcooldown4
                        bangstoescape = bangstoescapeth4
                End Select
                alreadytrapped = False
                trappedprogram = Nothing
            End If
        End If
    End Sub

    Private Sub detectprogramtotrap(ByVal program As Form)
        If program.Visible = True Then
            If Cursor.Position.X < program.Location.X + program.Width - ShiftOSDesktop.windowbordersize Then
                trap1 = True
            End If
            If Cursor.Position.X > program.Location.X + ShiftOSDesktop.windowbordersize Then
                trap2 = True
            End If
            If Cursor.Position.Y > program.Location.Y + ShiftOSDesktop.titlebarheight Then
                trap3 = True
            End If
            If Cursor.Position.Y < program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize Then
                trap4 = True
            End If
            If trap1 = True AndAlso trap2 = True AndAlso trap3 = True AndAlso trap4 = True Then
                alreadytrapped = True
                trappedprogram = program
            End If
        End If
        trap1 = False
        trap2 = False
        trap3 = False
        trap4 = False
    End Sub

    Public Sub trapmouseinprogram(ByVal program As Form)
        If Cursor.Position.X > program.Location.X + program.Width - ShiftOSDesktop.windowbordersize Then
            bangvelocity = Math.Abs(Cursor.Position.X - (program.Location.X + program.Width - ShiftOSDesktop.windowbordersize))
            Cursor.Position = New Point(program.Location.X + program.Width - ShiftOSDesktop.windowbordersize, Cursor.Position.Y)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
        If Cursor.Position.X < program.Location.X + ShiftOSDesktop.windowbordersize Then
            bangvelocity = Math.Abs(Cursor.Position.X - (program.Location.X + ShiftOSDesktop.windowbordersize))
            Cursor.Position = New Point(program.Location.X + ShiftOSDesktop.windowbordersize, Cursor.Position.Y)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
        If Cursor.Position.Y < program.Location.Y + ShiftOSDesktop.titlebarheight Then
            bangvelocity = Math.Abs(Cursor.Position.Y - (program.Location.Y + ShiftOSDesktop.titlebarheight))
            Cursor.Position = New Point(Cursor.Position.X, program.Location.Y + ShiftOSDesktop.titlebarheight)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
        If Cursor.Position.Y > program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize Then
            bangvelocity = Math.Abs(Cursor.Position.Y - (program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize))
            Cursor.Position = New Point(Cursor.Position.X, program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
    End Sub

    Public Sub removemousetrapvirus()
        Viruses.mousetrap = False
        mousetraptimer.Stop()
        mousetraped = False
        cooldowntraptimer.Stop()
    End Sub

    'Beeper Virus
    Public Sub setupbeepervirus()
        setupbeeperintervals()
        'If System.Diagnostics.Debugger.IsAttached() Then
        '    ResourceFilePath = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\resources\")
        'Else
        '    ResourceFilePath = Application.StartupPath & "\resources\"
        'End If
        beepertimer.Start()
        beepertimer.Interval = 500
        beepercountdown = beeperinterval
    End Sub

    Private Sub setupbeeperintervals()
        Select Case beeperthreatlevel
            Case 1 : beeperinterval = 60
            Case 2 : beeperinterval = 24
            Case 3 : beeperinterval = 8
            Case 4 : beeperinterval = 1
        End Select
    End Sub

    Public Sub beepermakesound(ByVal sender As Object, ByVal e As EventArgs) Handles beepertimer.Tick
        If beepercountdown = 0 Then
            My.Computer.Audio.Play(My.Resources._3beepvirus, AudioPlayMode.Background)
            beepercountdown = beeperinterval
        Else
            beepercountdown = beepercountdown - 1
        End If
    End Sub

    Public Sub removebeepervirus()
        Viruses.beeper = False
        beepertimer.Stop()
    End Sub

    Public Sub setuptheplague()
        If theplaguethreatlevel = 1 Then
            theplaguetimer.Start()
            theplaguetimer.Interval = 10000
            ChanceOfDestroyThePlague = 10
        ElseIf theplaguethreatlevel = 2 Then
            theplaguetimer.Start()
            theplaguetimer.Interval = 10000
            ChanceOfDestroyThePlague = 20
        ElseIf theplaguethreatlevel = 3 Then
            theplaguetimer.Start()
            theplaguetimer.Interval = 7000
            ChanceOfDestroyThePlague = 35
        ElseIf theplaguethreatlevel = 4 Then
            theplaguetimer.Start()
            theplaguetimer.Interval = 5000
            ChanceOfDestroyThePlague = 60
        End If
    End Sub

    Public Sub theplaguedestroy(ByVal sender As Object, ByVal e As EventArgs) Handles theplaguetimer.Tick
        Randomize()
        Dim Chance As Integer = CInt(Math.Ceiling(Rnd() * 100))
        If Chance = ChanceOfDestroyThePlague Or Chance > ChanceOfDestroyThePlague Then
            GetRandomApplication()
        End If
    End Sub

    Public Sub GetRandomApplication()
        Dim Chooser As Integer = ShiftOSDesktop.NumberOn
        Select Case chooser
            Case 1
                InfectApplication(ArtPad, ShiftOSDesktop.ArtpadCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 2
                InfectApplication(File_Skimmer, ShiftOSDesktop.FileSkimmerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 3
                InfectApplication(Audio_Player, ShiftOSDesktop.AudioPlayerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 4
                InfectApplication(Bitnote_Digger, ShiftOSDesktop.BitNoteDiggerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 5
                InfectApplication(Bitnote_Wallet, ShiftOSDesktop.BitNoteWalletCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 6
                InfectApplication(Calculator, ShiftOSDesktop.CalculatorCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 7
                InfectApplication(Clock, ShiftOSDesktop.ClockCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 8
                InfectApplication(coherencemodeform, ShiftOSDesktop.CoherenceModeCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 9
                InfectApplication(Colour_Picker, ShiftOSDesktop.ColourPickerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 10
                InfectApplication(Dodge, ShiftOSDesktop.DodgeCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 11
                InfectApplication(Downloadmanager, ShiftOSDesktop.DownloadManagerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 12
                InfectApplication(FloodGate_Manager, ShiftOSDesktop.FloodGateManagerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 13
                InfectApplication(Graphic_Picker, ShiftOSDesktop.GraphicPickerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 14
                InfectApplication(Icon_Manager, ShiftOSDesktop.IconManagerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 15
                InfectApplication(Installer, ShiftOSDesktop.InstallerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 16
                InfectApplication(Knowledge_Input, ShiftOSDesktop.KnowledgeInputCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 17
                InfectApplication(Labyrinth, ShiftOSDesktop.LabyrinthCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 18
                InfectApplication(Name_Changer, ShiftOSDesktop.NameChangerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 19
                InfectApplication(OrcWrite, ShiftOSDesktop.OrcWriteCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 20
                InfectApplication(Pong, ShiftOSDesktop.PongCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 21
                InfectApplication(Shifter, ShiftOSDesktop.ShifterCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 22
                InfectApplication(Shiftnet, ShiftOSDesktop.ShiftNetCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 23
                InfectApplication(Shiftorium, ShiftOSDesktop.ShiftoriumCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 24
                InfectApplication(Skin_Loader, ShiftOSDesktop.SkinLoaderCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 25
                InfectApplication(Skinshifter, ShiftOSDesktop.SkinShifterCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 26
                InfectApplication(systeminfo, ShiftOSDesktop.SystemInfoCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 27
                InfectApplication(Terminal, ShiftOSDesktop.TerminalCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 28
                InfectApplication(TextPad, ShiftOSDesktop.TextpadCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 29
                InfectApplication(Video_Player, ShiftOSDesktop.VideoPlayerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 30
                InfectApplication(VirusScanner, ShiftOSDesktop.VirusScannerCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 31
                InfectApplication(Web_Browser, ShiftOSDesktop.WebBrowserCorrupted)
                ShiftOSDesktop.NumberOn = ShiftOSDesktop.NumberOn + 1
            Case 32
                crash.ThePlagueBSOD()
        End Select
        ' Insert code to get a random application here, use the variable RandomApplicationName
        ' For example, if the randomizer chooses artpad, it should be
        ' RandomApplicationName = "Artpad"
        ' NOT
        ' RandomApplicationName = Artpad
    End Sub

    Public Sub InfectApplication(application As Form, infectvar As Boolean)
        If application.Visible = True Then
            If infectvar = False Then
                infectvar = True
                application.Close()
                infobox.showinfo("The Plague.", application.Name & " has been corrupted by The Plague.")
            End If
        Else : GetRandomApplication()
        End If
        ' Insert code to infect the application, RandomApplicationName is where the application name is stored
        ' The corrupted variables are booleans, they are the applications name and then corrupted,
        ' e.g. FileSkimmerCorrupted
        ' When the variable for the random application chosen is set to true, use this code at the end
        ' 'Application Name Here'.Close
        ' DO NOT USE
        ' RandomApplicationName.Close
        ' The RandomApplicationName variable is a string, so if a random application of artpad was chosen
        ' and you put MsgBox(RandomApplicationName) in this sub, if you had this virus and it chose
        ' to infect artpad, a msgbox would come up with the word artpad in that msgbox.

        ' Yea... I didn't exactly stuck to your plans...
    End Sub

    Public Sub removetheplague()
        Viruses.ThePlague = False
        theplaguetimer.Stop()
        ShiftOSDesktop.FileSkimmerCorrupted = False
        ShiftOSDesktop.ArtpadCorrupted = False
        ShiftOSDesktop.AudioPlayerCorrupted = False
        ShiftOSDesktop.BitNoteDiggerCorrupted = False
        ShiftOSDesktop.BitNoteWalletCorrupted = False
        ShiftOSDesktop.CalculatorCorrupted = False
        ShiftOSDesktop.ClockCorrupted = False
        ShiftOSDesktop.CoherenceModeCorrupted = False
        ShiftOSDesktop.ColourPickerCorrupted = False
        ShiftOSDesktop.DodgeCorrupted = False
        ShiftOSDesktop.DownloadManagerCorrupted = False
        ShiftOSDesktop.FloodGateManagerCorrupted = False
        ShiftOSDesktop.GraphicPickerCorrupted = False
        ShiftOSDesktop.IconManagerCorrupted = False
        ShiftOSDesktop.InstallerCorrupted = False
        ShiftOSDesktop.KnowledgeInputCorrupted = False
        ShiftOSDesktop.LabyrinthCorrupted = False
        ShiftOSDesktop.NameChangerCorrupted = False
        ShiftOSDesktop.OrcWriteCorrupted = False
        ShiftOSDesktop.PongCorrupted = False
        ShiftOSDesktop.ShifterCorrupted = False
        ShiftOSDesktop.ShiftNetCorrupted = False
        ShiftOSDesktop.ShiftoriumCorrupted = False
        ShiftOSDesktop.SkinLoaderCorrupted = False
        ShiftOSDesktop.SkinShifterCorrupted = False
        ShiftOSDesktop.SnakeyCorrupted = False
        ShiftOSDesktop.SystemInfoCorrupted = False
        ShiftOSDesktop.TerminalCorrupted = False
        ShiftOSDesktop.TextpadCorrupted = False
        ShiftOSDesktop.VideoPlayerCorrupted = False
        ShiftOSDesktop.VirusScannerCorrupted = False
        ShiftOSDesktop.WebBrowserCorrupted = False
    End Sub
End Module
