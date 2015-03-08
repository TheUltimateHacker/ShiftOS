Imports System.Diagnostics
Imports System.Math
Module crash

    Public Sub ForceCrash()
        crash_pic.Show()

        ShiftOSDesktop.Close()
        ArtPad.Close()
        Audio_Player.Close()
        Bitnote_Digger.Close()
        Bitnote_Wallet.Close()
        Calculator.Close()
        Clock.Close()
        coherencemodeform.Close()
        Colour_Picker.Close()
        Dodge.Close()
        Downloader.Close()
        Downloadmanager.Close()
        File_Opener.Close()
        File_Saver.Close()
        File_Skimmer.Close()
        FloodGate_Manager.Close()
        Graphic_Picker.Close()
        Icon_Manager.Close()
        infobox.Close()
        Installer.Close()
        Knowledge_Input.Close()
        Labyrinth.Close()
        Name_Changer.Close()
        OrcWrite.Close()
        Pong.Close()
        ShiftDock.Close()
        Shifter.Close()
        Shiftnet.Close()
        Shiftorium.Close()
        Skin_Loader.Close()
        Skinshifter.Close()
        Snakey.Close()
        SystemInfo.Close()
        Terminal.Close()
        TextPad.Close()
        Video_Player.Close()
        VirusScanner.Close()
        Web_Browser.Close()

        crash_pic.pic_crash.Image = My.Resources.crash_force
    End Sub

    Public Sub OutOfMemory()
        crash_pic.Show()

        ShiftOSDesktop.Close()
        ArtPad.Close()
        Audio_Player.Close()
        Bitnote_Digger.Close()
        Bitnote_Wallet.Close()
        Calculator.Close()
        Clock.Close()
        coherencemodeform.Close()
        Colour_Picker.Close()
        Dodge.Close()
        Downloader.Close()
        Downloadmanager.Close()
        File_Opener.Close()
        File_Saver.Close()
        File_Skimmer.Close()
        FloodGate_Manager.Close()
        Graphic_Picker.Close()
        Icon_Manager.Close()
        infobox.Close()
        Installer.Close()
        Knowledge_Input.Close()
        Labyrinth.Close()
        Name_Changer.Close()
        OrcWrite.Close()
        Pong.Close()
        ShiftDock.Close()
        Shifter.Close()
        Shiftnet.Close()
        Shiftorium.Close()
        Skin_Loader.Close()
        Skinshifter.Close()
        Snakey.Close()
        SystemInfo.Close()
        Terminal.Close()
        TextPad.Close()
        Video_Player.Close()
        VirusScanner.Close()
        Web_Browser.Close()

        crash_pic.pic_crash.Image = My.Resources.crash_ofm
    End Sub

    Public Sub ThePlagueBSOD()
        crash_pic.Show()

        ShiftOSDesktop.Close()
        ArtPad.Close()
        Audio_Player.Close()
        Bitnote_Digger.Close()
        Bitnote_Wallet.Close()
        Calculator.Close()
        Clock.Close()
        coherencemodeform.Close()
        Colour_Picker.Close()
        Dodge.Close()
        Downloader.Close()
        Downloadmanager.Close()
        File_Opener.Close()
        File_Saver.Close()
        File_Skimmer.Close()
        FloodGate_Manager.Close()
        Graphic_Picker.Close()
        Icon_Manager.Close()
        infobox.Close()
        Installer.Close()
        Knowledge_Input.Close()
        Labyrinth.Close()
        Name_Changer.Close()
        OrcWrite.Close()
        Pong.Close()
        ShiftDock.Close()
        Shifter.Close()
        Shiftnet.Close()
        Shiftorium.Close()
        Skin_Loader.Close()
        Skinshifter.Close()
        Snakey.Close()
        systeminfo.Close()
        Terminal.Close()
        TextPad.Close()
        Video_Player.Close()
        VirusScanner.Close()
        Web_Browser.Close()

        crash_pic.pic_crash.Image = My.Resources.crash
    End Sub

    Public Sub FindProc()
        Dim myProcesses() As Process = Process.GetProcesses

        For Each p As Process In myProcesses
            If p.MainWindowTitle.Contains("Cheat Engine") Then
                If My.Settings.ShouldCrashOccur = 3 Then
                    crash_pic.Show()

                    ShiftOSDesktop.Close()
                    ArtPad.Close()
                    Audio_Player.Close()
                    Bitnote_Digger.Close()
                    Bitnote_Wallet.Close()
                    Calculator.Close()
                    Clock.Close()
                    coherencemodeform.Close()
                    Colour_Picker.Close()
                    Dodge.Close()
                    Downloader.Close()
                    Downloadmanager.Close()
                    File_Opener.Close()
                    File_Saver.Close()
                    File_Skimmer.Close()
                    FloodGate_Manager.Close()
                    Graphic_Picker.Close()
                    Icon_Manager.Close()
                    infobox.Close()
                    Installer.Close()
                    Knowledge_Input.Close()
                    Labyrinth.Close()
                    Name_Changer.Close()
                    OrcWrite.Close()
                    Pong.Close()
                    ShiftDock.Close()
                    Shifter.Close()
                    Shiftnet.Close()
                    Shiftorium.Close()
                    Skin_Loader.Close()
                    Skinshifter.Close()
                    Snakey.Close()
                    SystemInfo.Close()
                    Terminal.Close()
                    TextPad.Close()
                    Video_Player.Close()
                    VirusScanner.Close()
                    Web_Browser.Close()

                    crash_pic.pic_crash.Image = My.Resources.crash_force
                Else
                    If My.Settings.ShouldCrashOccur = 0 Then
                        My.Settings.ShouldCrashOccur = 1
                    ElseIf My.Settings.ShouldCrashOccur = 1 Then
                        My.Settings.ShouldCrashOccur = 2
                    ElseIf My.Settings.ShouldCrashOccur = 2 Then
                        My.Settings.ShouldCrashOccur = 3
                    End If
                    p.CloseMainWindow()
                    infobox.title = "System Modification Detected!"
                    infobox.textinfo = "A dangerous modification to ShiftOS has been detected. It has been terminated."
                    infobox.Show()
                End If
            End If
        Next

    End Sub
End Module
