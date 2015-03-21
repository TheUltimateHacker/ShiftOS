Module Paths



    ' Paths:
    '  Root path - Paths.root - DO NOT USE UNLESS NECISARY (Opening files from the file skimmer, blocking the user from going above C:\ShiftOS, ect)
    '    Software Data - Paths.progdata - This is the base path for all program data. If you are adding a folder to this path, add a variable in here
    '      AdvStart - Paths.advda - Stores stuff like recent files, for example if you go to Paths.advstart\Recent in Explorer, you'll see the same files you see in the Advanced AL's Recent section.
    '      Knowledge Input Data - Paths.kidata - Knowledge Input uses this to save your lists of words you've found
    '      Shiftnet Data - Paths.shiftnetdata - This is where the shiftnet currently saves it's history
    '      Download Manager Data - Paths.dnldata - Not sure what this does
    '    Save Data - Paths.savedata - The game has it's save file in here
    '      Skin Directory - Paths.skindir - Self explanatory.
    '        Loaded Skin Directory - Paths.loadedskin - Where the contents of .skn files are extracted to.
    '          Sound Directory - Paths.sounddir - Where sound files (such as Infobox chime) are stored, coming soon.
    '        Current Skin Directory - Paths.currentskin - ??????????
    '    Home Directory - Paths.home - This is the folder that contains all the user's files
    '      Desktop - Paths.desktop - All the files that appear on your desktop should be stored here
    '      Documents - Paths.documents - The documents folder is where the user puts their documents
    '      Downloads - Paths.downloads - The downloads folder is where the downloader downloads downloads from the Shiftnet
    '      Music - Paths.music - The music folder is where the user puts their music
    '      Pictures - Paths.pictures - The pictures folder is where the user puts their pictures
    '      Skins - Paths.skins - The skins folder is where the user puts their skins



    'Declaration Hierarchy

    Public root As String = "C:\ShiftOS\" 'Do NOT use this unless it is for files that must go DIRECTLY in C:\ShiftOS\

    Public progdata As String = root & "SoftwareData\"

    Public advdata As String = progdata & "AdvStart\"
    Public kidata As String = progdata & "KnowledgeInput\"
    Public shiftnetdata As String = progdata & "Shiftnet\"
    Public dnldata As String = progdata & "DownloadManager\"

    Public savedata As String = root & "Shiftum42\"

    Public skindir As String = savedata & "Skins\"

    Public loadedskin As String = skindir & "Loaded\"
    Public currentskin As String = skindir & "Current\"

    Public sounddir As String = loadedskin & "Sounds\"

    Public home As String = root & "Home\"

    Public desktop As String = home & "Desktop\"
    Public documents As String = home & "Documents\"
    Public downloads As String = home & "Documents\"
    Public music As String = home & "Music\"
    Public pictures As String = home & "Pictures\"
    Public skins As String = home & "Skins\"
End Module
