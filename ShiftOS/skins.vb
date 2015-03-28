Imports System.IO
Module Skins
#Region "Declarations"
    Dim savepath As String = ShiftOSDesktop.ShiftOSPath
    Dim firstrun As Boolean = True
    'WINDOW SETTINGS/IMAGES
    'images
    Public titlebar As Image = Nothing
    Public titlebarlayout As String = 3
    Public borderleft As Image = Nothing
    Public borderleftlayout As String = 3
    Public borderright As Image = Nothing
    Public borderrightlayout As String = 3
    Public borderbottom As Image = Nothing
    Public borderbottomlayout As String = 3
    Public closebtn As Image = Nothing
    Public closebtnlayout As String = 3
    Public closebtnhover As Image = Nothing
    Public closebtnclick As Image = Nothing
    Public rollbtn As Image = Nothing
    Public rollbtnlayout As String = 3
    Public rollbtnhover As Image = Nothing
    Public rollbtnclick As Image = Nothing
    Public minbtn As Image = Nothing
    Public minbtnlayout As String = 3
    Public minbtnhover As Image = Nothing
    Public minbtnclick As Image = Nothing
    Public rightcorner As Image = Nothing
    Public rightcornerlayout As String = 3
    Public leftcorner As Image = Nothing
    Public leftcornerlayout As String = 3
    ' Late entry: need to fix window code to include this
    Public bottomleftcorner As Image = Nothing
    Public bottomleftcornerlayout As String = 3
    Public bottomrightcorner As Image = Nothing
    Public bottomrightcornerlayout As String = 3
    Public bottomleftcornercolour As Color = Color.Gray
    Public bottomrightcornercolour As Color = Color.Gray

    Public enablebordercorners As Boolean = False

    ' settings
    Public closebtnsize As Size = New Size(22, 22)
    Public rollbtnsize As Size = New Size(22, 22)
    Public minbtnsize As Size = New Size(22, 22)
    Public titlebarheight As Integer = 30
    Public closebtnfromtop As Integer = 5
    Public closebtnfromside As Integer = 2
    Public rollbtnfromtop As Integer = 5
    Public rollbtnfromside As Integer = 26
    Public minbtnfromtop As Integer = 5
    Public minbtnfromside As Integer = 52
    Public borderwidth As Integer = 2
    Public enablecorners As Boolean = False
    Public titlebarcornerwidth As Integer = 5
    Public titleiconfromside As Integer = 4
    Public titleiconfromtop As Integer = 4
    'colours
    Public titlebarcolour As Color = Color.Gray
    Public borderleftcolour As Color = Color.Gray
    Public borderrightcolour As Color = Color.Gray
    Public borderbottomcolour As Color = Color.Gray
    Public closebtncolour As Color = Color.Black
    Public closebtnhovercolour As Color = Color.Black
    Public closebtnclickcolour As Color = Color.Black
    Public rollbtncolour As Color = Color.Black
    Public rollbtnhovercolour As Color = Color.Black
    Public rollbtnclickcolour As Color = Color.Black
    Public minbtncolour As Color = Color.Black
    Public minbtnhovercolour As Color = Color.Black
    Public minbtnclickcolour As Color = Color.Black
    Public rightcornercolour As Color = Color.Gray
    Public leftcornercolour As Color = Color.Gray
    ' Text
    Public titletextfontfamily As String = "Microsoft Sans Serif"
    Public titletextfontsize As Integer = 10
    Public titletextfontstyle As String = FontStyle.Bold
    Public titletextpos As String = "Left"
    Public titletextfromtop As Integer = 3
    Public titletextfromside As Integer = 24
    Public titletextcolour As Color = Color.White

    'DESKTOP
    Public desktoppanelcolour As Color = Color.Gray
    Public desktopbackgroundcolour As Color
    Public desktoppanelheight As Integer = 24
    Public desktoppanelposition As String = "Top"
    Public clocktextcolour As Color = Color.Black
    Public clockbackgroundcolor As Color = Color.Gray
    Public panelclocktexttop As Integer = 3
    Public panelclocktextsize As Integer = 10
    Public panelclocktextfont As String = "Byington"
    Public panelclocktextstyle As FontStyle = FontStyle.Bold
    Public applauncherbuttoncolour As Color = Color.Gray
    Public applauncherbuttonclickedcolour As Color = Color.Gray
    Public applauncherbackgroundcolour As Color = Color.Gray
    Public applaunchermouseovercolour As Color = Color.Gray
    Public applicationsbuttontextcolour As Color = Color.Black
    Public applicationbuttonheight As Integer = 24
    Public applicationbuttontextsize As Integer = 10
    Public applicationbuttontextfont As String = "Byington"
    Public applicationbuttontextstyle As FontStyle = FontStyle.Bold
    Public applicationlaunchername As String = "Applications"
    Public titletextposition As String = "Left"
    Public applaunchermenuholderwidth As Integer = 100
    Public panelbuttonicontop As Integer = 3
    Public panelbuttoniconside As Integer = 4
    Public panelbuttoniconsize As Integer = 16
    Public panelbuttonheight As Integer = 20
    Public panelbuttonwidth As Integer = 185
    Public panelbuttoncolour As Color = Color.Black
    Public panelbuttontextcolour As Color = Color.White
    Public panelbuttontextsize As Integer = 10
    Public panelbuttontextfont As String = "Byington"
    Public panelbuttontextstyle As FontStyle = FontStyle.Regular
    Public panelbuttontextside As Integer = 16
    Public panelbuttontexttop As Integer = 2
    Public panelbuttongap As Integer = 4
    Public panelbuttonfromtop As Integer = 2
    Public panelbuttoninitialgap As Integer = 8

    Public launcheritemsize As Integer = 10
    Public launcheritemfont As String = "Byington"
    Public launcheritemstyle As FontStyle = FontStyle.Regular
    Public launcheritemcolour As Color = Color.Black

    ' Images
    Public desktoppanel As Image = Nothing
    Public desktoppanellayout As String = 3
    Public desktopbackground As Image = Nothing
    Public desktopbackgroundlayout As String = 3
    Public panelclock As Image = Nothing
    Public panelclocklayout As String = 3
    Public applaunchermouseover As Image = Nothing
    Public applauncher As Image = Nothing
    Public applauncherlayout As String = 3
    Public applauncherclick As Image = Nothing
    Public panelbutton As Image = Nothing
    Public panelbuttonlayout As String = 3

    'Below is all for the Desktop Icons patch.

    Public enabledraggableicons As Boolean = True
    Public icontextcolor As Color = Color.White
    Public showicons As Boolean = True
    Public iconview1 As View = View.LargeIcon
    Public iconview2 As View = View.Tile

    'DevX's Advanced App Launcher (coded by The Ultimate Hacker)

    Public topBarHeight As Integer = 50
    Public bottomBarHeight As Integer = 50
    Public placesSide As String = "Left"
    Public startHeight As Integer = 526
    Public startWidth As Integer = 320
    Public shutdownstring As String = "Shut Down ShiftOS"
    Public userNamePosition = "Middle, Right"
    Public recentIconsHorizontal As Boolean = False
    Public usernametextcolor As Color = Color.White
    Public usernamefont As String = "Trebuchet MS"
    Public usernamefontsize As Integer = 12
    Public usernamefontstyle As FontStyle = FontStyle.Bold
    Public userNamePanelBackgroundColor As Color = Color.Gray
    Public userNamePanelBackground As Image
    Public powerPanelBackgroundColor As Color = Color.Gray
    Public powerPanelBackgroundImage As Image
    Public shutdownTextColor As Color = Color.White
    Public shutdownTextFont As String = "Trebuchet MS"
    Public shutdownTextSize As Integer = 12
    Public shutdownTextStyle As FontStyle = FontStyle.Italic
    Public usrPanelBackgroundLayout As ImageLayout = ImageLayout.Stretch
    Public pwrPanelBackgroundLayout As ImageLayout = ImageLayout.Stretch
    Public useClassicAppLauncher As Boolean = True


    '0.0.9 ALPHA 2

    'Login Screen

    Public autologin As Boolean = True
    Public fullScreen As Boolean = False
    Public inputfont As String = "Trebuchet MS"
    Public inputfontsize As Integer = 12
    Public inputfontstyle As FontStyle = FontStyle.Regular
    Public inputforecolor As Color = Color.Gray
    Public inputbackcolor As Color = Color.Black
    Public buttonfont As String = "Trebuchet MS"
    Public buttonfontsize As Integer = 12
    Public buttonfontstyle As FontStyle = FontStyle.Italic

    Public userimagesize As Integer = 128
    Public userimagelocation As Point = New Point(36, 202)
    Public userimage As Image
    Public userimagelayout As ImageLayout = ImageLayout.Stretch

    Public loginbg As Image
    Public loginbgcolor As Color = Color.Black
    Public loginbglayout As ImageLayout = ImageLayout.Stretch

    'Locations...

    Public userTextboxX As Integer = 171
    Public userTextBoxY As Integer = 202
    Public passTextBoxX As Integer = 171
    Public passTextBoxY As Integer = 243
    Public loginbtnX As Integer = 268
    Public loginbtnY As Integer = 286
    Public shutdownbtnX As Integer = 1755
    Public shutdownbtnY As Integer = 979


    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        Return ret
    End Function

#End Region

    ' LOAD SKIN FROM SKN FILE
    Public Sub loadsknfile(ByVal filepath As String)
        If Directory.Exists(loadedskin) Then My.Computer.FileSystem.DeleteDirectory(savepath + "Shiftum42\Skins\Loaded", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Directory.CreateDirectory(savepath + "Shiftum42\Skins\Loaded")
        System.IO.Compression.ZipFile.ExtractToDirectory(filepath, savepath + "Shiftum42\Skins\Loaded")
        loadimages()
    End Sub
    ' LOAD SKIN FROM SAVE FOLDER
    Public Sub loadimages()
        If File.Exists(loadedskin & "userpic") Then
            userimage = GetImage(loadedskin & "userpic")
        End If
        If File.Exists(loadedskin & "loginbg") Then
            loginbg = GetImage(loadedskin & "loginbg")
        End If
        If File.Exists(loadedskin & "userbar") Then
            userNamePanelBackground = GetImage(loadedskin & "userbar")
        End If
        If File.Exists(loadedskin & "powerbar") Then
            powerPanelBackgroundImage = GetImage(loadedskin & "powerbar")
        End If
        If File.Exists(loadedskin & "titlebar") Then
            titlebar = GetImage(loadedskin & "titlebar")
        Else : titlebar = Nothing
        End If
        If File.Exists(loadedskin & "borderleft") Then
            borderleft = GetImage(loadedskin & "borderleft")
        Else : borderleft = Nothing
        End If
        If File.Exists(loadedskin & "borderright") Then
            borderright = GetImage(loadedskin & "borderright".Clone)
        Else : borderright = Nothing
        End If
        If File.Exists(loadedskin & "borderbottom") Then
            borderbottom = GetImage(loadedskin & "borderbottom".Clone)
        Else : borderbottom = Nothing
        End If
        If File.Exists(loadedskin & "closebtn") Then
            closebtn = GetImage(loadedskin & "closebtn".Clone)
        Else : closebtn = Nothing
        End If
        If File.Exists(loadedskin & "closebtnhover") Then
            closebtnhover = GetImage(loadedskin & "closebtnhover".Clone)
        Else : closebtnhover = Nothing
        End If
        If File.Exists(loadedskin & "closebtnclick") Then
            closebtnclick = GetImage(loadedskin & "closebtnclick".Clone)
        Else : closebtnclick = Nothing
        End If
        If File.Exists(loadedskin & "rollbtn") Then
            rollbtn = GetImage(loadedskin & "rollbtn".Clone)
        Else : rollbtn = Nothing
        End If
        If File.Exists(loadedskin & "rollbtnhover") Then
            rollbtnhover = GetImage(loadedskin & "rollbtnhover".Clone)
        Else : rollbtnhover = Nothing
        End If
        If File.Exists(loadedskin & "rollbtnclick") Then
            rollbtnclick = GetImage(loadedskin & "rollbtnclick".Clone)
        Else : rollbtnclick = Nothing
        End If
        If File.Exists(loadedskin & "minbtn") Then
            minbtn = GetImage(loadedskin & "minbtn".Clone)
        Else : minbtn = Nothing
        End If
        If File.Exists(loadedskin & "minbtnhover") Then
            minbtnhover = GetImage(loadedskin & "minbtnhover".Clone)
        Else : minbtnhover = Nothing
        End If
        If File.Exists(loadedskin & "minbtnclick") Then
            minbtnclick = GetImage(loadedskin & "minbtnclick".Clone)
        Else : minbtnclick = Nothing
        End If
        If File.Exists(loadedskin & "rightcorner") Then
            rightcorner = GetImage(loadedskin & "rightcorner".Clone)
        Else : rightcorner = Nothing
        End If
        If File.Exists(loadedskin & "leftcorner") Then
            leftcorner = GetImage(loadedskin & "leftcorner".Clone)
        Else : leftcorner = Nothing
        End If
        If File.Exists(loadedskin & "desktoppanel") Then
            desktoppanel = GetImage(loadedskin & "desktoppanel".Clone)
        Else : desktoppanel = Nothing
        End If
        If File.Exists(loadedskin & "desktopbackground") Then
            desktopbackground = GetImage(loadedskin & "desktopbackground".Clone)
        Else : desktopbackground = Nothing
        End If
        If File.Exists(loadedskin & "panelbutton") Then
            panelbutton = GetImage(loadedskin & "panelbutton".Clone)
        Else : panelbutton = Nothing
        End If
        If File.Exists(loadedskin & "applaunchermouseover") Then
            applaunchermouseover = GetImage(loadedskin & "applaunchermouseover".Clone)
        Else : applaunchermouseover = Nothing
        End If
        If File.Exists(loadedskin & "applauncher") Then
            applauncher = GetImage(loadedskin & "applauncher".Clone)
        Else : applauncher = Nothing
        End If
        If File.Exists(loadedskin & "applauncherclick") Then
            applauncherclick = GetImage(loadedskin & "applauncherclick".Clone)
        Else : applauncherclick = Nothing
        End If
        If File.Exists(loadedskin & "panelclock") Then
            panelclock = GetImage(loadedskin & "panelclock".Clone)
        Else : panelclock = Nothing
        End If
        If File.Exists(loadedskin & "bottomleftcorner") Then
            bottomleftcorner = GetImage(loadedskin & "bottomleftcorner".Clone)
        Else : bottomleftcorner = Nothing
        End If
        If File.Exists(loadedskin & "bottomrightcorner") Then
            bottomrightcorner = GetImage(loadedskin & "bottomrightcorner".Clone)
        Else : bottomrightcorner = Nothing
        End If
        'load settings
        Dim loaddata(200) As String
        If File.Exists(loadedskin & "data.dat") Then
            Dim sr As StreamReader = New StreamReader(loadedskin & "data.dat")

            For i As Integer = 0 To 200 Step 1
                loaddata(i) = sr.ReadLine
                If i = 200 Then
                    sr.Close()
                    Exit For
                End If
            Next

            ' settings


            closebtnsize = New Size(loaddata(1), loaddata(2))
            rollbtnsize = New Size(loaddata(3), loaddata(4))
            minbtnsize = New Size(loaddata(5), loaddata(6))
            titlebarheight = loaddata(7)
            closebtnfromtop = loaddata(8)
            closebtnfromside = loaddata(9)
            rollbtnfromtop = loaddata(10)
            rollbtnfromside = loaddata(11)
            minbtnfromtop = loaddata(12)
            minbtnfromside = loaddata(13)
            borderwidth = loaddata(14)
            enablecorners = loaddata(15)
            titlebarcornerwidth = loaddata(16)
            titleiconfromside = loaddata(17)
            titleiconfromtop = loaddata(18)
            titlebarcolour = Color.FromArgb(loaddata(19))
            borderleftcolour = Color.FromArgb(loaddata(20))
            borderrightcolour = Color.FromArgb(loaddata(21))
            borderbottomcolour = Color.FromArgb(loaddata(22))
            closebtncolour = Color.FromArgb(loaddata(23))
            closebtnhovercolour = Color.FromArgb(loaddata(24))
            closebtnclickcolour = Color.FromArgb(loaddata(25))
            rollbtncolour = Color.FromArgb(loaddata(26))
            rollbtnhovercolour = Color.FromArgb(loaddata(27))
            rollbtnclickcolour = Color.FromArgb(loaddata(28))
            minbtncolour = Color.FromArgb(loaddata(29))
            minbtnhovercolour = Color.FromArgb(loaddata(30))
            minbtnclickcolour = Color.FromArgb(loaddata(31))
            rightcornercolour = Color.FromArgb(loaddata(32))
            leftcornercolour = Color.FromArgb(loaddata(33))
            bottomrightcornercolour = Color.FromArgb(loaddata(34))
            bottomleftcornercolour = Color.FromArgb(loaddata(35))
            titletextfontfamily = loaddata(36)
            titletextfontsize = loaddata(37)
            titletextfontstyle = loaddata(38)
            titletextpos = loaddata(39)
            titletextfromtop = loaddata(40)
            titletextfromside = loaddata(41)
            titletextcolour = Color.FromArgb(loaddata(42))
            desktoppanelcolour = Color.FromArgb(loaddata(43))
            desktopbackgroundcolour = Color.FromArgb(loaddata(44))
            desktoppanelheight = loaddata(45)
            desktoppanelposition = loaddata(46)
            clocktextcolour = Color.FromArgb(loaddata(47))
            clockbackgroundcolor = Color.FromArgb(loaddata(48))
            panelclocktexttop = loaddata(49)
            panelclocktextsize = loaddata(50)
            panelclocktextfont = loaddata(51)
            panelclocktextstyle = loaddata(52)
            applauncherbuttoncolour = Color.FromArgb(loaddata(53))
            applauncherbuttonclickedcolour = Color.FromArgb(loaddata(54))
            applauncherbackgroundcolour = Color.FromArgb(loaddata(55))
            applaunchermouseovercolour = Color.FromArgb(loaddata(56))
            applicationsbuttontextcolour = Color.FromArgb(loaddata(57))
            applicationbuttonheight = loaddata(58)
            applicationbuttontextsize = loaddata(59)
            applicationbuttontextfont = loaddata(60)
            applicationbuttontextstyle = loaddata(61)
            applicationlaunchername = loaddata(62)
            titletextposition = loaddata(63)
            applaunchermenuholderwidth = loaddata(64)
            panelbuttonicontop = loaddata(65)
            panelbuttoniconside = loaddata(66)
            panelbuttoniconsize = loaddata(67)
            panelbuttonheight = loaddata(68)
            panelbuttonwidth = loaddata(69)
            panelbuttoncolour = Color.FromArgb(loaddata(70))
            panelbuttontextcolour = Color.FromArgb(loaddata(71))
            panelbuttontextsize = loaddata(72)
            panelbuttontextfont = loaddata(73)
            panelbuttontextstyle = loaddata(74)
            panelbuttontextside = loaddata(75)
            panelbuttontexttop = loaddata(76)
            panelbuttongap = loaddata(77)
            panelbuttonfromtop = loaddata(78)
            panelbuttoninitialgap = loaddata(79)

            'layout stuff
            titlebarlayout = loaddata(89)
            borderleftlayout = loaddata(90)
            borderrightlayout = loaddata(91)
            borderbottomlayout = loaddata(92)
            closebtnlayout = loaddata(93)
            rollbtnlayout = loaddata(94)
            minbtnlayout = loaddata(95)
            rightcornerlayout = loaddata(96)
            leftcornerlayout = loaddata(97)
            desktoppanellayout = loaddata(98)
            desktopbackgroundlayout = loaddata(99)
            panelclocklayout = loaddata(100)
            applauncherlayout = loaddata(101)
            panelbuttonlayout = loaddata(102)
            bottomleftcornerlayout = loaddata(103)
            bottomrightcornerlayout = loaddata(104)
            ' End of 0.0.8 beta 6 save file, check if exists for future features 
            If Not loaddata(105) = "" Then launcheritemcolour = Color.FromArgb(loaddata(105))
            If Not loaddata(106) = "" Then launcheritemfont = loaddata(106)
            If Not loaddata(107) = "" Then launcheritemsize = loaddata(107)
            If Not loaddata(108) = "" Then launcheritemstyle = loaddata(108)
            If Not loaddata(109) = "" Then enablebordercorners = loaddata(109)

            'for adding extra features, check:

            If loaddata(110) = "" Or loaddata(110) = "End of skin data" Then loaddata(110) = enabledraggableicons Else enabledraggableicons = loaddata(110)
            If loaddata(111) = "" Or loaddata(111) = "End of skin data" Then loaddata(111) = icontextcolor.ToArgb Else icontextcolor = Color.FromArgb(loaddata(111))
            If loaddata(112) = "" Or loaddata(112) = "End of skin data" Then loaddata(112) = showicons Else showicons = loaddata(112)
            If loaddata(113) = "" Or loaddata(113) = "End of skin data" Then loaddata(113) = iconview1 Else iconview1 = loaddata(113)
            Try
                If loaddata(114) = "" Then topBarHeight = 50 Else topBarHeight = loaddata(114)
            Catch ex As Exception
                topBarHeight = 50
                infobox.showinfo("Error - Bad Skin File", "It appears that there was an error loading parts of this skin. The unloadable data has been reset to default values.")
            End Try
            If loaddata(115) = "" Then bottomBarHeight = 50 Else bottomBarHeight = loaddata(115)
            If loaddata(116) = "" Then placesSide = "Left" Else placesSide = loaddata(116)
            If loaddata(117) = "" Then startHeight = 526 Else startHeight = loaddata(117)
            If loaddata(118) = "" Then startWidth = 320 Else startWidth = loaddata(118)
            If loaddata(119) = "" Then shutdownstring = "Shut Down ShiftOS" Else shutdownstring = loaddata(119)
            If loaddata(120) = "" Then userNamePosition = "Middle, Right" Else userNamePosition = loaddata(120)
            If loaddata(121) = "" Then recentIconsHorizontal = False Else recentIconsHorizontal = loaddata(121)
            If loaddata(122) = "" Then usernametextcolor = Color.White Else usernametextcolor = Color.FromArgb(loaddata(122))
            If loaddata(123) = "" Then usernamefont = "Trebuchet MS" Else usernamefont = loaddata(123)
            If loaddata(124) = "" Then usernamefontsize = 12 Else usernamefontsize = loaddata(124)
            If loaddata(125) = "" Then usernamefontstyle = FontStyle.Bold Else usernamefontstyle = loaddata(125)
            If loaddata(126) = "" Then userNamePanelBackgroundColor = Color.Gray Else userNamePanelBackgroundColor = Color.FromArgb(loaddata(126))
            If loaddata(127) = "" Then powerPanelBackgroundColor = Color.Gray Else powerPanelBackgroundColor = Color.FromArgb(loaddata(127))
            If loaddata(128) = "" Then shutdownTextColor = Color.White Else shutdownTextColor = Color.FromArgb(loaddata(128))
            If loaddata(129) = "" Then shutdownTextFont = "Trebuchet MS" Else shutdownTextFont = loaddata(129)
            If loaddata(130) = "" Then shutdownTextSize = 12 Else shutdownTextSize = loaddata(130)
            If loaddata(131) = "" Then shutdownTextStyle = FontStyle.Italic Else shutdownTextStyle = loaddata(132)
            If loaddata(132) = "" Then usrPanelBackgroundLayout = ImageLayout.Stretch Else usrPanelBackgroundLayout = loaddata(132)
            If loaddata(133) = "" Then pwrPanelBackgroundLayout = ImageLayout.Stretch Else pwrPanelBackgroundLayout = loaddata(133)
            If loaddata(134) = "" Then useClassicAppLauncher = False Else useClassicAppLauncher = loaddata(134)
            If loaddata(135) = "" Then autologin = True Else autologin = loaddata(135)
            If loaddata(136) = "" Then fullScreen = False Else fullScreen = loaddata(136)
            If loaddata(137) = "" Then inputfont = "Trebuchet MS" Else inputfont = loaddata(137)
            If loaddata(138) = "" Then inputfontsize = 12 Else inputfontsize = loaddata(138)
            If loaddata(139) = "" Then inputfontstyle = FontStyle.Regular Else inputfontstyle = loaddata(139)
            If loaddata(140) = "" Then inputforecolor = Color.Gray Else inputforecolor = Color.FromArgb(loaddata(140))
            If loaddata(141) = "" Then inputbackcolor = Color.Black Else inputbackcolor = Color.FromArgb(loaddata(141))
            If loaddata(142) = "" Then buttonfont = "Trebuchet MS" Else buttonfont = loaddata(142)
            If loaddata(143) = "" Then buttonfontsize = 12 Else buttonfontsize = loaddata(143)
            If loaddata(144) = "" Then buttonfontstyle = FontStyle.Italic Else buttonfontstyle = loaddata(144)
            If loaddata(145) = "" Then userimagesize = 128 Else userimagesize = loaddata(145)
            If loaddata(146) = "" And loaddata(147) = "" Then userimagelocation = New Point(36, 202) Else userimagelocation = New Point(loaddata(146), loaddata(147))
            If loaddata(148) = "" Then userimagelayout = ImageLayout.Stretch Else userimagelayout = loaddata(148)
            If loaddata(149) = "" Then loginbgcolor = Color.Black Else loginbgcolor = Color.FromArgb(loaddata(149))
            If loaddata(150) = "" Then loginbglayout = ImageLayout.Stretch Else loginbglayout = loaddata(150)

        Else
            setupdefaults()
        End If
        ' Christmas easteregg
        Try ' If user's PC uses weird/non-numeric dating system - eg: http://puu.sh/eFq6l/8da8a03617.png
            Dim d() As String = Split(Date.Today, "/")
            If (d(0) = 25 And d(1) = 12) Or (d(0) = 12 And d(1) = 25) Then
                desktopbackground = My.Resources.christmaseasteregg
                desktopbackgroundlayout = 2
                desktopbackgroundcolour = Color.Black
            End If
        Catch ex As Exception
        End Try
        applyskin()
    End Sub
    ' SET SKIN
    Public Sub applyskin()
        ShiftOSDesktop.addtitlebars()
        ShiftOSDesktop.setupdesktop()
    End Sub
    ' SAVE TO SKN FILE
    Public Sub saveskin(ByVal path As String)
        If Not File.Exists(path) Then
            Dim sw As StreamWriter = New StreamWriter(Paths.loadedskin & "SKN-version") 'tells skin loader which system to use when openning the file
            sw.WriteLine("Name of skinning system used to create this skn file:")
            sw.WriteLine("2.0 disposal-free skinning")
            sw.WriteLine("Skinning system created by william.1008 on December 2014, based on 1.0 system by DevX")
            sw.Close()
            saveskinfiles(False)
            Compression.ZipFile.CreateFromDirectory(Paths.loadedskin, path)
            File.Delete(Paths.loadedskin & "SKN-version")
        Else
            infobox.showinfo("File Exists", "That file location is already taken, please choose another.")
        End If
    End Sub
    ' SAVE TO SAVE FOLDER
    Public Sub saveskinfiles(ByVal apply As Boolean)
        If File.Exists(Paths.loadedskin) Then
            Directory.Delete(Paths.loadedskin)
        End If
        Directory.CreateDirectory(Paths.loadedskin)
        saveimage(titlebar, "titlebar")
        saveimage(borderleft, "borderleft")
        saveimage(borderright, "borderright")
        saveimage(borderbottom, "borderbottom")
        saveimage(closebtn, "closebtn")
        saveimage(closebtnhover, "closebtnhover")
        saveimage(closebtnclick, "closebtnclick")
        saveimage(rollbtn, "rollbtn")
        saveimage(rollbtnhover, "rollbtnhover")
        saveimage(rollbtnclick, "rollbtnclick")
        saveimage(minbtn, "minbtn")
        saveimage(minbtnhover, "minbtnhover")
        saveimage(minbtnclick, "minbtnclick")
        saveimage(rightcorner, "rightcorner")
        saveimage(leftcorner, "leftcorner")
        saveimage(desktoppanel, "desktoppanel")
        saveimage(desktopbackground, "desktopbackground")
        saveimage(panelclock, "panelclock")
        saveimage(applaunchermouseover, "applaunchermouseover")
        saveimage(applauncher, "applauncher")
        saveimage(applauncherclick, "applauncherclick")
        saveimage(panelbutton, "panelbutton")
        saveimage(bottomleftcorner, "bottomleftcorner")
        saveimage(bottomrightcorner, "bottomrightcorner")
        saveimage(userNamePanelBackground, "userbar")
        saveimage(powerPanelBackgroundImage, "powerbar")
        saveimage(userimage, "userpic")
        saveimage(loginbg, "loginbg")
        'save settings to dat file
        Dim savedata(200) As String
        ' setting and colour as saved in the order they are declared, image's are saved in sepporate preset files,
        ' image layout options are saved at the end of file
        savedata(0) = "ShiftOS skin data - Beware: Editing may result in skinning errors"
        savedata(2) = closebtnsize.Height
        savedata(1) = closebtnsize.Width
        savedata(4) = rollbtnsize.Height
        savedata(3) = rollbtnsize.Width
        savedata(6) = minbtnsize.Height
        savedata(5) = minbtnsize.Width
        savedata(7) = titlebarheight
        savedata(8) = closebtnfromtop
        savedata(9) = closebtnfromside
        savedata(10) = rollbtnfromtop
        savedata(11) = rollbtnfromside
        savedata(12) = minbtnfromtop
        savedata(13) = minbtnfromside
        savedata(14) = borderwidth
        savedata(15) = enablecorners
        savedata(16) = titlebarcornerwidth
        savedata(17) = titleiconfromside
        savedata(18) = titleiconfromtop
        savedata(19) = titlebarcolour.ToArgb
        savedata(20) = borderleftcolour.ToArgb
        savedata(21) = borderrightcolour.ToArgb
        savedata(22) = borderbottomcolour.ToArgb
        savedata(23) = closebtncolour.ToArgb
        savedata(24) = closebtnhovercolour.ToArgb
        savedata(25) = closebtnclickcolour.ToArgb
        savedata(26) = rollbtncolour.ToArgb
        savedata(27) = rollbtnhovercolour.ToArgb
        savedata(28) = rollbtnclickcolour.ToArgb
        savedata(29) = minbtncolour.ToArgb
        savedata(30) = minbtnhovercolour.ToArgb
        savedata(31) = minbtnclickcolour.ToArgb
        savedata(32) = rightcornercolour.ToArgb
        savedata(33) = leftcornercolour.ToArgb
        savedata(34) = bottomrightcornercolour.ToArgb
        savedata(35) = bottomleftcornercolour.ToArgb
        savedata(36) = titletextfontfamily
        savedata(37) = titletextfontsize
        savedata(38) = titletextfontstyle
        savedata(39) = titletextpos
        savedata(40) = titletextfromtop
        savedata(41) = titletextfromside
        savedata(42) = titletextcolour.ToArgb
        savedata(43) = desktoppanelcolour.ToArgb
        savedata(44) = desktopbackgroundcolour.ToArgb
        savedata(45) = desktoppanelheight
        savedata(46) = desktoppanelposition
        savedata(47) = clocktextcolour.ToArgb
        savedata(48) = clockbackgroundcolor.ToArgb
        savedata(49) = panelclocktexttop
        savedata(50) = panelclocktextsize
        savedata(51) = panelclocktextfont
        savedata(52) = panelclocktextstyle
        savedata(53) = applauncherbuttoncolour.ToArgb
        savedata(54) = applauncherbuttonclickedcolour.ToArgb
        savedata(55) = applauncherbackgroundcolour.ToArgb
        savedata(56) = applaunchermouseovercolour.ToArgb
        savedata(57) = applicationsbuttontextcolour.ToArgb
        savedata(58) = applicationbuttonheight
        savedata(59) = applicationbuttontextsize
        savedata(60) = applicationbuttontextfont
        savedata(61) = applicationbuttontextstyle
        savedata(62) = applicationlaunchername
        savedata(63) = titletextposition
        savedata(64) = applaunchermenuholderwidth
        savedata(65) = panelbuttonicontop
        savedata(66) = panelbuttoniconside
        savedata(67) = panelbuttoniconsize
        savedata(68) = panelbuttonheight
        savedata(69) = panelbuttonwidth
        savedata(70) = panelbuttoncolour.ToArgb
        savedata(71) = panelbuttontextcolour.ToArgb
        savedata(72) = panelbuttontextsize
        savedata(73) = panelbuttontextfont
        savedata(74) = panelbuttontextstyle
        savedata(75) = panelbuttontextside
        savedata(76) = panelbuttontexttop
        savedata(77) = panelbuttongap
        savedata(78) = panelbuttonfromtop
        savedata(79) = panelbuttoninitialgap
        'Image layout options
        savedata(89) = titlebarlayout
        savedata(90) = borderleftlayout
        savedata(91) = borderrightlayout
        savedata(92) = borderbottomlayout
        savedata(93) = closebtnlayout
        savedata(94) = rollbtnlayout
        savedata(95) = minbtnlayout
        savedata(96) = rightcornerlayout
        savedata(97) = leftcornerlayout
        savedata(98) = desktoppanellayout
        savedata(99) = desktopbackgroundlayout
        savedata(100) = panelclocklayout
        savedata(101) = applauncherlayout
        savedata(102) = panelbuttonlayout
        savedata(103) = bottomleftcornerlayout
        savedata(104) = bottomrightcornerlayout

        savedata(105) = launcheritemcolour.ToArgb
        savedata(106) = launcheritemfont
        savedata(107) = launcheritemsize
        savedata(108) = launcheritemstyle
        savedata(109) = enablebordercorners
        savedata(110) = enabledraggableicons
        savedata(111) = icontextcolor.ToArgb
        savedata(112) = showicons
        savedata(113) = iconview1
        savedata(114) = topBarHeight
        savedata(115) = bottomBarHeight
        savedata(116) = placesSide
        savedata(117) = startHeight
        savedata(118) = startWidth
        savedata(119) = shutdownstring
        savedata(120) = userNamePosition
        savedata(121) = recentIconsHorizontal
        savedata(122) = usernametextcolor.ToArgb
        savedata(123) = usernamefont
        savedata(124) = usernamefontsize
        savedata(125) = usernamefontstyle
        savedata(126) = userNamePanelBackgroundColor.ToArgb
        savedata(127) = powerPanelBackgroundColor.ToArgb
        savedata(128) = shutdownTextColor.ToArgb
        savedata(129) = shutdownTextFont
        savedata(130) = shutdownTextSize
        savedata(131) = shutdownTextStyle
        savedata(132) = usrPanelBackgroundLayout
        savedata(133) = pwrPanelBackgroundLayout
        savedata(134) = useClassicAppLauncher
        savedata(135) = autologin
        savedata(136) = fullScreen
        savedata(137) = inputfont
        savedata(138) = inputfontsize
        savedata(139) = inputfontstyle
        savedata(140) = inputforecolor.ToArgb
        savedata(141) = inputbackcolor.ToArgb
        savedata(142) = buttonfont
        savedata(143) = buttonfontsize
        savedata(144) = buttonfontstyle
        savedata(145) = userimagesize
        savedata(146) = userimagelocation.X
        savedata(147) = userimagelocation.Y
        savedata(148) = userimagelayout
        savedata(149) = loginbgcolor.ToArgb
        savedata(150) = loginbglayout


        ' End of skin data text was at line 110, if adding future items, check for "End of skin data" on line 110
        savedata(200) = "End of skin data"
        File.WriteAllLines(Paths.loadedskin & "data.dat", savedata)
        If apply = True Then
            applyskin()
        End If
    End Sub
    Public Sub setupdefaults()
        titlebar = Nothing
        titlebarlayout = 3
        borderleft = Nothing
        borderleftlayout = 3
        borderright = Nothing
        borderrightlayout = 3
        borderbottom = Nothing
        borderbottomlayout = 3
        closebtn = Nothing
        closebtnlayout = 3
        closebtnhover = Nothing
        closebtnclick = Nothing
        rollbtn = Nothing
        rollbtnlayout = 3
        rollbtnhover = Nothing
        rollbtnclick = Nothing
        minbtn = Nothing
        minbtnlayout = 3
        minbtnhover = Nothing
        minbtnclick = Nothing
        rightcorner = Nothing
        rightcornerlayout = 3
        leftcorner = Nothing
        leftcornerlayout = 3
        bottomleftcorner = Nothing
        bottomleftcornerlayout = 3
        bottomrightcorner = Nothing
        bottomrightcornerlayout = 3
        bottomleftcornercolour = Color.Gray
        bottomrightcornercolour = Color.Gray
        enablebordercorners = False
        closebtnsize = New Size(22, 22)
        rollbtnsize = New Size(22, 22)
        minbtnsize = New Size(22, 22)
        titlebarheight = 30
        closebtnfromtop = 5
        closebtnfromside = 2
        rollbtnfromtop = 5
        rollbtnfromside = 26
        minbtnfromtop = 5
        minbtnfromside = 52
        borderwidth = 2
        enablecorners = False
        titlebarcornerwidth = 5
        titleiconfromside = 4
        titleiconfromtop = 4
        titlebarcolour = Color.Gray
        borderleftcolour = Color.Gray
        borderrightcolour = Color.Gray
        borderbottomcolour = Color.Gray
        closebtncolour = Color.Black
        closebtnhovercolour = Color.Black
        closebtnclickcolour = Color.Black
        rollbtncolour = Color.Black
        rollbtnhovercolour = Color.Black
        rollbtnclickcolour = Color.Black
        minbtncolour = Color.Black
        minbtnhovercolour = Color.Black
        minbtnclickcolour = Color.Black
        rightcornercolour = Color.Gray
        leftcornercolour = Color.Gray
        titletextfontfamily = "Microsoft Sans Serif"
        titletextfontsize = 10
        titletextfontstyle = FontStyle.Bold
        titletextpos = "Left"
        titletextfromtop = 3
        titletextfromside = 24
        titletextcolour = Color.White
        desktoppanelcolour = Color.Gray
        desktopbackgroundcolour = Color.Black
        desktoppanelheight = 24
        desktoppanelposition = "Top"
        clocktextcolour = Color.Black
        clockbackgroundcolor = Color.Gray
        panelclocktexttop = 3
        panelclocktextsize = 10
        panelclocktextfont = "Byington"
        panelclocktextstyle = FontStyle.Bold
        applauncherbuttoncolour = Color.Gray
        applauncherbuttonclickedcolour = Color.Gray
        applauncherbackgroundcolour = Color.Gray
        applaunchermouseovercolour = Color.Gray
        applicationsbuttontextcolour = Color.Black
        applicationbuttonheight = 24
        applicationbuttontextsize = 10
        applicationbuttontextfont = "Byington"
        applicationbuttontextstyle = FontStyle.Bold
        applicationlaunchername = "Applications"
        titletextposition = "Left"
        applaunchermenuholderwidth = 100
        panelbuttonicontop = 3
        panelbuttoniconside = 4
        panelbuttoniconsize = 16
        panelbuttonheight = 20
        panelbuttonwidth = 185
        panelbuttoncolour = Color.Black
        panelbuttontextcolour = Color.White
        panelbuttontextsize = 10
        panelbuttontextfont = "Byington"
        panelbuttontextstyle = FontStyle.Regular
        panelbuttontextside = 16
        panelbuttontexttop = 2
        panelbuttongap = 4
        panelbuttonfromtop = 2
        panelbuttoninitialgap = 8
        launcheritemsize = 10
        launcheritemfont = "Byington"
        launcheritemstyle = FontStyle.Regular
        launcheritemcolour = Color.Black
        desktoppanel = Nothing
        desktoppanellayout = 3
        desktopbackground = Nothing
        desktopbackgroundlayout = 3
        panelclock = Nothing
        panelclocklayout = 3
        applaunchermouseover = Nothing
        applauncher = Nothing
        applauncherlayout = 3
        applauncherclick = Nothing
        panelbutton = Nothing
        panelbuttonlayout = 3
        enabledraggableicons = True
    End Sub
    Private Sub saveimage(ByVal img As Image, ByVal name As String)
        If Not IsNothing(img) Then
            If File.Exists(loadedskin & name) Then File.Delete(loadedskin & name)
            Try
                img.Save(loadedskin & name, System.Drawing.Imaging.ImageFormat.Png)
            Catch ex As Exception
                infobox.showinfo("Saving Error", "Oops, an error occured when saving the file " & loadedskin & name & ". Please contact the devs to report the problem.")
            End Try
        Else
            If File.Exists(loadedskin & name) Then File.Delete(loadedskin & name)
        End If
    End Sub
End Module