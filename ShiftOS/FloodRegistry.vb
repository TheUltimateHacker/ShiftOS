Public Class FloodRegistry
    Dim items As String
    Public Sub registerItems()
        FloodGate_Manager.setup()
        Shiftnet.tpbsetup()
        'Format:
        'registerItem("Program Name", "Author name", Percent chance to be a virus, "Program Description \ for Newline", "URL", File size in kb, Places the program is (Seperated by commas)
        'Example:
        'registerItem("SomeProgram",95,"ImakePIRATES","This Is the description\with a newline","shiftnet.pirate.pirateboat/floods/flood.flood",256,"FloodGate" ' This program will be added to PirateBoat and to Floodgate (a shiftnet.pirate.pirateboat/ link will add it to pirate boat)
        'registerItem("SomeProg2222",0,"MYPROGS","This Is the description\with a newline\and another","sssss.floods/.flood",100,"" ' This program will not be added to pirateboat or to floodgate
        registerItem("Dodge", 20, "ThePirateMaster", "Dodge is a program where you earn code point for dodging falling objects\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/dodge.flood", 500, "FloodGate") 'Not adding to floodgate will still be downloadable by floodgate with the URL
        registerItem("Codepoint Hack", 20, "ShifterHacker101", "Created by: ShifterHacker\This hack gives you 5 codepoints\Check out my other hacks at shiftnet.shifterhacker/home.rnp \ƒshiftnet.shifterhacker/home.rnp", "shiftnet.shifterhacker/hacks/codepointhack.flood", 243, "FloodGate")
        registerItem("B1N0T3 H4CK", 0, "31T3 H4CKER", "Created by ME\This hack gives you 10 B1TN0T3!\!!!!S000000000 C000000L.", "shiftnet.leethackz/deezhax/bitnotehackorz.flood", 100, "FloodGate")
        registerItem("Virus Scanner", 50, "ThePirateMaster", "This Virus Scanner is a program that helps you fend off nasty infections that could harm your computer!\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/virusscanner.flood", 10000, "FloodGate")
        registerItem("Labyrinth", 20, "ThePirateMaster", "Labytinth is a game where you run through mazes to collect codepoints in limited time\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/labyrinth.flood", 500, "FloodGate")
        registerItem("Calculator", 20, "ThePirateMaster", "Calculator is a utility application that lets you add, subtract, multiply, and devide, all in your OS\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/calculator.flood", 500, "FloodGate")
        registerItem("Audio Player", 20, "ThePirateMaster", "Audio player is an app that lets you play audio\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/audio_player.flood", 500, "FloodGate")
        registerItem("Video Player", 20, "ThePirateMaster", "Video player is an app that lets you play video\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/video_player.flood", 500, "FloodGate")
        registerItem("Web Browser", 20, "MF", "The web browser is an app that lets you browse the World Wide Web... with internet explorer.\Pirate it for free, download now.", "shiftnet.pirate.pirateboat/floods/web_browser.flood", 500, "")
        registerItem("Virus Grade 1 removal unlocker", 75, "ShiftHacker102", "This unlocks the virus removal feature of grade 1 viruses in the virus scanner", "shiftnet.pirate.pirateboat/floods/Virus_remove-1", 500, "")
        registerItem("Virus Grade 2 removal unlocker", 80, "ShiftHacker102", "This unlocks the virus removal feature of grade 2 viruses in the virus scanner", "shiftnet.pirate.pirateboat/floods/Virus_remove-2", 500, "")
        registerItem("Virus Grade 3 removal unlocker", 85, "ShiftHacker102", "This unlocks the virus removal feature of grade 3 viruses in the virus scanner", "shiftnet.pirate.pirateboat/floods/Virus_remove-3", 500, "")
        registerItem("Virus Grade 4 removal unlocker", 90, "ShiftHacker102", "This unlocks the virus removal feature of grade 4 viruses in the virus scanner", "shiftnet.pirate.pirateboat/floods/Virus_remove-4", 500, "")
    End Sub
    Private Sub registerItem(name As String, virus As Double, author As String, desc As String, url As String, size As String, places As String)
        If (places.Contains("FloodGate")) Then
            'MsgBox("how...")
            FloodGate_Manager.addItem(name, virus, author, desc, url, size, True)
        Else
            FloodGate_Manager.addItem(name, virus, author, desc, url, size, False) ' Because of how FloodGate works, this is required
        End If
        If (url.StartsWith("shiftnet.pirate.pirateboat/")) Then
            Shiftnet.tpb_addItem(name, url)
        End If
        items = items & "|" & name & "#" & CStr(virus) & "#" & author & "#" & desc & "#" & url & "#" & size & "#" & places
    End Sub
End Class