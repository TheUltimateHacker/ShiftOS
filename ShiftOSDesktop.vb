Public Class ShiftOSDesktop
    Public codepoints As Integer
    Public log As String
    Public forceclose As Boolean = False
    Public movablewindownumber As Integer = 50
    Public terminalfullscreen As Boolean = True
    Public unitymode As Boolean = False
    Public savelines(2000) As String
    Public loadlines(2000) As String
    Public skinlines(200) As String
    Public newgame As Boolean = False
    Public lastcolourpick As Color = Color.Gray
    Public programsopen As Integer = 0
    Private actualshiftversion As String = "0.0.7"

    'Shiftorium Upgrades
    Public boughttitlebar As Boolean = False
    Public boughtgray As Boolean = False
    Public boughtsecondspastmidnight As Boolean = False
    Public boughtminutespastmidnight As Boolean = False
    Public boughthourspastmidnight As Boolean = False
    Public boughtcustomusername As Boolean = False
    Public boughtwindowsanywhere As Boolean = False
    Public boughtmultitasking As Boolean = False
    Public boughtautoscrollterminal As Boolean = False
    Public boughtmovablewindows As Boolean = False
    Public boughtdraggablewindows As Boolean = False
    Public boughtwindowborders As Boolean = False
    Public boughtpmandam As Boolean = False
    Public boughtminuteaccuracytime As Boolean = False
    Public boughtsplitsecondtime As Boolean = False
    Public boughttitletext As Boolean = False
    Public boughtclosebutton As Boolean = False
    Public boughtdesktoppanel As Boolean = False
    Public boughtclock As Boolean = False
    Public boughtwindowedterminal As Boolean = False
    Public boughtapplaunchermenu As Boolean = False
    Public boughtalknowledgeinput As Boolean = False
    Public boughtalclock As Boolean = False
    Public boughtalshiftorium As Boolean = False
    Public boughtapplaunchershutdown As Boolean = False
    Public boughtdesktoppanelclock As Boolean = False
    Public boughtterminalscrollbar As Boolean = False
    Public boughtkiaddons As Boolean = False
    Public boughtkicarbrands As Boolean = False
    Public boughtkigameconsoles As Boolean = False
    Public boughtshifter As Boolean = False
    Public boughtalshifter As Boolean = False
    Public boughtrollupcommand As Boolean = False
    Public boughtrollupbutton As Boolean = False
    Public boughtshiftdesktop As Boolean = False
    Public boughtshiftpanelclock As Boolean = False
    Public boughtshiftapplauncher As Boolean = False
    Public boughtshiftdesktoppanel As Boolean = False
    Public boughtshifttitlebar As Boolean = False
    Public boughtshifttitletext As Boolean = False
    Public boughtshifttitlebuttons As Boolean = False
    Public boughtshiftborders As Boolean = False
    Public boughtgray2 As Boolean = False
    Public boughtgray3 As Boolean = False
    Public boughtgray4 As Boolean = False
    Public boughtanycolour As Boolean = False
    Public boughtanycolour2 As Boolean = False
    Public boughtanycolour3 As Boolean = False
    Public boughtanycolour4 As Boolean = False
    Public boughtpurple As Boolean = False
    Public boughtpurple2 As Boolean = False
    Public boughtpurple3 As Boolean = False
    Public boughtpurple4 As Boolean = False
    Public boughtblue As Boolean = False
    Public boughtblue2 As Boolean = False
    Public boughtblue3 As Boolean = False
    Public boughtblue4 As Boolean = False
    Public boughtgreen As Boolean = False
    Public boughtgreen2 As Boolean = False
    Public boughtgreen3 As Boolean = False
    Public boughtgreen4 As Boolean = False
    Public boughtyellow As Boolean = False
    Public boughtyellow2 As Boolean = False
    Public boughtyellow3 As Boolean = False
    Public boughtyellow4 As Boolean = False
    Public boughtorange As Boolean = False
    Public boughtorange2 As Boolean = False
    Public boughtorange3 As Boolean = False
    Public boughtorange4 As Boolean = False
    Public boughtbrown As Boolean = False
    Public boughtbrown2 As Boolean = False
    Public boughtbrown3 As Boolean = False
    Public boughtbrown4 As Boolean = False
    Public boughtred As Boolean = False
    Public boughtred2 As Boolean = False
    Public boughtred3 As Boolean = False
    Public boughtred4 As Boolean = False
    Public boughtpink As Boolean = False
    Public boughtpink2 As Boolean = False
    Public boughtpink3 As Boolean = False
    Public boughtpink4 As Boolean = False
    'new 0.0.6 content
    Public boughtpong As Boolean = False
    Public boughtknowledgeinputicon As Boolean = False
    Public boughtshiftericon As Boolean = False
    Public boughtshiftoriumicon As Boolean = False
    Public boughtclockicon As Boolean = False
    Public boughtshutdownicon As Boolean = False
    Public boughtpongicon As Boolean = False
    Public boughtterminalicon As Boolean = False
    Public boughtalpong As Boolean = False
    Public boughtfileskimmer As Boolean = False
    Public boughtalfileskimmer As Boolean = False
    Public boughttextpad As Boolean = False
    Public boughtaltextpad As Boolean = False
    Public boughtfileskimmericon As Boolean = False
    Public boughttextpadicon As Boolean = False
    Public boughttextpadnew As Boolean = False
    Public boughttextpadsave As Boolean = False
    Public boughttextpadopen As Boolean = False
    Public boughtfileskimmernewfolder As Boolean = False
    Public boughtfileskimmerdelete As Boolean = False
    Public boughtkielements As Boolean = False
    Public boughtcolourpickericon As Boolean = False
    Public boughtinfoboxicon As Boolean = False
    'new 0.0.7 content
    Public boughtskinloader As Boolean = False
    Public boughtminimizebutton As Boolean = False
    Public boughtpanelbuttons As Boolean = False
    Public boughtshiftpanelbuttons As Boolean = False
    Public boughtartpad As Boolean = False
    Public boughtalartpad As Boolean = False
    Public boughtartpadicon As Boolean = False
    Public boughtskinning As Boolean = False
    Public boughtminimizecommand As Boolean = False
    Public boughtusefulpanelbuttons As Boolean = False
    Public boughtunitymode As Boolean = False
    Public boughtartpadpixellimit4 As Boolean = False
    Public boughtartpadpixellimit8 As Boolean = False
    Public boughtartpadpixellimit16 As Boolean = False
    Public boughtartpadpixellimit64 As Boolean = False
    Public boughtartpadpixellimit256 As Boolean = False
    Public boughtartpadpixellimit1024 As Boolean = False
    Public boughtartpadpixellimit4096 As Boolean = False
    Public boughtartpadpixellimit16384 As Boolean = False
    Public boughtartpadpixellimit65536 As Boolean = False
    Public boughtartpadlimitlesspixels As Boolean = False
    Public boughtartpad4colorpallets As Boolean = False
    Public boughtartpad8colorpallets As Boolean = False
    Public boughtartpad16colorpallets As Boolean = False
    Public boughtartpad32colorpallets As Boolean = False
    Public boughtartpad64colorpallets As Boolean = False
    Public boughtartpad128colorpallets As Boolean = False
    Public boughtartpadcustompallets As Boolean = False
    Public boughtartpadnew As Boolean = False
    Public boughtartpadpixelplacer As Boolean = False
    Public boughtartpadpixelplacermovementmode As Boolean = False
    Public boughtartpadpencil As Boolean = False
    Public boughtartpadpaintbrush As Boolean = False
    Public boughtartpadlinetool As Boolean = False
    Public boughtartpadovaltool As Boolean = False
    Public boughtartpadrectangletool As Boolean = False
    Public boughtartpaderaser As Boolean = False
    Public boughtartpadfilltool As Boolean = False
    Public boughtartpadtexttool As Boolean = False
    Public boughtartpadundo As Boolean = False
    Public boughtartpadredo As Boolean = False
    Public boughtartpadsave As Boolean = False
    Public boughtartpadload As Boolean = False
    'new 0.0.8 features
    Public boughtresizablewindows As Boolean = True
    Public boughtcalculator As Boolean = True
    Public boughtaudioplayer As Boolean = True
    Public boughtchangeosnamecommand As Boolean = True
    Public boughtwebbrowser As Boolean = True
    Public boughtvideoplayer As Boolean = True
    Public boughtnamechanger As Boolean = True
    Public boughticonmanager As Boolean = True
    Public boughtbitnotewallet As Boolean = True
    Public boughtbitnotedigger As Boolean = True
    Public boughtskinshifter As Boolean = True
    Public boughtshiftnet As Boolean = True
    Public boughtdownloader As Boolean = True
    Public boughtshiftneticon As Boolean = True
    Public boughtalshiftnet As Boolean = True

    'new 0.0.9 features
    Public boughtskinstates As Boolean = False

    'Colour Picker Memories
    Public anymemory(15) As Color
    Public graymemory(15) As Color
    Public purplememory(15) As Color
    Public bluememory(15) As Color
    Public greenmemory(15) As Color
    Public yellowmemory(15) As Color
    Public orangememory(15) As Color
    Public brownmemory(15) As Color
    Public redmemory(15) As Color
    Public pinkmemory(15) As Color

    'ShiftOS UI Settings
    Public titlebarcolour As Color = Color.Gray
    Public windowbordercolour As Color = Color.Gray
    Public windowbordersize As Integer = 2
    Public titlebarheight As Integer = 30
    Public closebuttoncolour As Color = Color.Black
    Public closebuttonheight As Integer = 22
    Public closebuttonwidth As Integer = 22
    Public closebuttonside As Integer = 5
    Public closebuttontop As Integer = 4
    Public titletextcolour As Color = Color.White
    Public titletexttop As Integer = 7
    Public titletextside As Integer = 4
    Public titletextsize As Integer = 11
    Public titletextfont As String = "Felix Titling"
    Public titletextstyle As FontStyle = FontStyle.Bold
    Public desktoppanelcolour As Color = Color.Gray
    Public desktopbackgroundcolour As Color = Color.Black
    Public desktoppanelheight As Integer = 24
    Public desktoppanelposition As String = "Top"
    Public clocktextcolour As Color = Color.Black
    Public clockbackgroundcolor As Color = Color.Gray
    Public panelclocktexttop As Integer = 0
    Public panelclocktextsize As Integer = 14
    Public panelclocktextfont As String = "Trebuchet MS"
    Public panelclocktextstyle As FontStyle = FontStyle.Regular
    Public applauncherbuttoncolour As Color = Color.Gray
    Public applauncherbuttonclickedcolour = Color.Gray
    Public applauncherbackgroundcolour As Color = Color.Gray
    Public applaunchermouseovercolour As Color = Color.Gray
    Public applicationsbuttontextcolour As Color = Color.Black
    Public applicationbuttonheight As Integer = 24
    Public applicationbuttontextsize As Integer = 10
    Public applicationbuttontextfont As String = "Byington"
    Public applicationbuttontextstyle As FontStyle = FontStyle.Bold
    Public applicationlaunchername As String = "Applications"
    Public titletextposition As String = "Left"
    Public rollupbuttoncolour As Color = Color.Black
    Public rollupbuttonheight As Integer = 22
    Public rollupbuttonwidth As Integer = 22
    Public rollupbuttonside As Integer = 32
    Public rollupbuttontop As Integer = 4
    'new 0.0.7
    Public titlebariconside As Integer = 8
    Public titlebaricontop As Integer = 8
    Public showwindowcorners As Boolean = False
    Public titlebarcornerwidth As Integer = 2
    Public titlebarrightcornercolour As Color = Color.White
    Public titlebarleftcornercolour As Color = Color.White
    Public applaunchermenuholderwidth As Integer = 100
    Public windowborderleftcolour As Color = Color.Gray
    Public windowborderrightcolour As Color = Color.Gray
    Public windowborderbottomcolour As Color = Color.Gray
    Public windowborderbottomrightcolour As Color = Color.Gray
    Public windowborderbottomleftcolour As Color = Color.Gray
    Public fileopenerlastdirectory As String
    Public panelbuttonicontop As Integer = 3
    Public panelbuttoniconside As Integer = 4
    'Public panelbuttoniconsize As Integer = 16 'duplicated
    'Public panelbuttoniconsize As Integer = 16 'duplicated
    Public panelbuttonheight As Integer = 22
    Public panelbuttonwidth As Integer = 186
    Public panelbuttoncolour As Color = Color.Black
    Public panelbuttontextcolour As Color = Color.White
    Public panelbuttontextsize As Integer = 10
    Public panelbuttontextfont As String = "Microsoft Sans Serif"
    Public panelbuttontextstyle As FontStyle = FontStyle.Bold
    Public panelbuttontextside As Integer = 22
    Public panelbuttontexttop As Integer = 2
    Public panelbuttongap As Integer = 1
    Public panelbuttonfromtop As Integer = 1
    Public panelbuttoninitialgap As Integer = 5
    Public minimizebuttoncolour As Color = Color.Black
    Public minimizebuttonheight As Integer = 22
    Public minimizebuttonwidth As Integer = 22
    Public minimizebuttonside As Integer = 59
    Public minimizebuttontop As Integer = 4


    'ShiftOS Skin Settings
    'finsih up checking for skin changes with states in the clock app before copying across to other apps
    Public globaltransparencycolour As Color = Color.FromArgb(1, 0, 1)
    Public skinimages(100) As String
    Public skinclosebutton(2) As Image
    Public skinclosebuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skintitlebar(2) As Image
    Public skintitlebarstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktopbackground(2) As Image
    Public skindesktopbackgroundstyle As ImageLayout = ImageLayout.Stretch
    Public skinrollupbutton(2) As Image
    Public skinrollupbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skintitlebarrightcorner(2) As Image
    Public skintitlebarrightcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skintitlebarleftcorner(2) As Image
    Public skintitlebarleftcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktoppanel(2) As Image
    Public skindesktoppanelstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktoppaneltime(2) As Image
    Public skindesktoppaneltimestyle As ImageLayout = ImageLayout.Stretch
    Public skinapplauncherbutton(2) As Image
    Public skinapplauncherbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderleft(2) As Image
    Public skinwindowborderleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderright(2) As Image
    Public skinwindowborderrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottom(2) As Image
    Public skinwindowborderbottomstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottomright(2) As Image
    Public skinwindowborderbottomrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottomleft(2) As Image
    Public skinwindowborderbottomleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinpanelbutton(2) As Image
    Public skinpanelbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinminimizebutton(2) As Image
    Public skinminimizebuttonstyle As ImageLayout = ImageLayout.Stretch

    'Program settings
    Public artpadcolorpalletwidth As Integer = 105
    Public artpadcolorpalletheight As Integer = 69
    Public artpadcolorpalletsidegap As Integer = 4
    Public artpadcolorpallettopgap As Integer = 4
    Public artpadvisiblepallets As Integer = 2
    Public artpadpixellimit As Integer = 2
    Public artpadcolourpallets(128) As Color

    Public webbrowserhomepage As String = "www.google.com"

    Public iconmanagericondatalines(50) As String

    Public bitnotebalance As Decimal = 2.64028
    Public bitnotebalanceappscape As Decimal = 0.0
    Public bitnoteaddress As String = "1LgZUWQNYWZ7Qhc1hScZieC3GWnPLzaqSd"
    Public bitnoteaddressappscape As String = "1JB97iocfdv6zVMeKxXAHdahbfdoYWNyUh"

    Public downloadspeedcap As Integer = 32

    'Main ShiftOS settings
    Public username As String = "user"
    Public osname As String = "shiftos"
    Public artpadname As String = "Artpad"
    Public audioplayername As String = "Audio Player"
    Public calculatorname As String = "Calculator"
    Public clockname As String = "Clock"
    Public colourpickername As String = "Colour Picker"
    Public fileopenername As String = "File Opener"
    Public filesavername As String = "File Saver"
    Public fileskimmername As String = "File Skimmer"
    Public graphicpickername As String = "Graphic Picker"
    Public knowledgeinputname As String = "Knowledge Input"
    Public pongname As String = "Pong"
    Public shiftername As String = "Shifter"
    Public shiftoriumname As String = "Shiftorium"
    Public skinloadername As String = "Skin Loader"
    Public terminalname As String = "Terminal"
    Public textpadname As String = "TextPad"
    Public videoplayername As String = "Video Player"
    Public webbrowsername As String = "Web Browser"
    Public namechangername As String = "Name Changer"
    Public iconmanagername As String = "Icon Manager"
    Public bitnotewalletname As String = "Bitnote Wallet"
    Public bitnotediggername As String = "Bitnote Digger"
    Public skinshiftername As String = "Skin Shifter"
    Public shiftnetname As String = "Shiftnet"
    Public downloadername As String = "Downloader"

    'Icons
    Public titlebariconsize As Integer = 16
    Public panelbuttoniconsize As Integer = 16
    Public launchericonsize As Integer = 16

    Public artpadicontitlebar As Image = My.Resources.iconArtpad
    Public audioplayericontitlebar As Image = My.Resources.iconAudioPlayer
    Public calculatoricontitlebar As Image = My.Resources.iconCalculator
    Public clockicontitlebar As Image = My.Resources.iconClock
    Public colourpickericontitlebar As Image = My.Resources.iconColourPicker
    Public fileopenericontitlebar As Image = My.Resources.iconFileOpener
    Public filesavericontitlebar As Image = My.Resources.iconFileSaver
    Public fileskimmericontitlebar As Image = My.Resources.iconFileSkimmer
    Public graphicpickericontitlebar As Image = My.Resources.iconGraphicPicker
    Public infoboxicontitlebar As Image = My.Resources.iconInfoBox
    Public knowledgeinputicontitlebar As Image = My.Resources.iconKnowledgeInput
    Public pongicontitlebar As Image = My.Resources.iconPong
    Public shiftericontitlebar As Image = My.Resources.iconShifter
    Public shiftoriumicontitlebar As Image = My.Resources.iconShiftorium
    Public skinloadericontitlebar As Image = My.Resources.iconSkinLoader
    Public terminalicontitlebar As Image = My.Resources.iconTerminal
    Public textpadicontitlebar As Image = My.Resources.iconTextPad
    Public videoplayericontitlebar As Image = My.Resources.iconVideoPlayer
    Public webbrowsericontitlebar As Image = My.Resources.iconWebBrowser
    Public namechangericontitlebar As Image = My.Resources.iconNameChanger
    Public iconmanagericontitlebar As Image = My.Resources.iconIconManager
    Public bitnotewalleticontitlebar As Image = My.Resources.iconBitnoteWallet
    Public bitnotediggericontitlebar As Image = My.Resources.iconBitnoteDigger
    Public skinshiftericontitlebar As Image = My.Resources.iconSkinShifter
    Public shiftneticontitlebar As Image = My.Resources.iconShiftnet
    Public downloadericontitlebar As Image = My.Resources.iconDownloader

    Public artpadiconpanelbutton As Image = My.Resources.iconArtpad
    Public audioplayericonpanelbutton As Image = My.Resources.iconAudioPlayer
    Public calculatoriconpanelbutton As Image = My.Resources.iconCalculator
    Public clockiconpanelbutton As Image = My.Resources.iconClock
    Public colourpickericonpanelbutton As Image = My.Resources.iconColourPicker
    Public fileopenericonpanelbutton As Image = My.Resources.iconFileOpener
    Public filesavericonpanelbutton As Image = My.Resources.iconFileSaver
    Public fileskimmericonpanelbutton As Image = My.Resources.iconFileSkimmer
    Public graphicpickericonpanelbutton As Image = My.Resources.iconGraphicPicker
    Public infoboxiconpanelbutton As Image = My.Resources.iconInfoBox
    Public knowledgeinputiconpanelbutton As Image = My.Resources.iconKnowledgeInput
    Public pongiconpanelbutton As Image = My.Resources.iconPong
    Public shiftericonpanelbutton As Image = My.Resources.iconShifter
    Public shiftoriumiconpanelbutton As Image = My.Resources.iconShiftorium
    Public skinloadericonpanelbutton As Image = My.Resources.iconSkinLoader
    Public terminaliconpanelbutton As Image = My.Resources.iconTerminal
    Public textpadiconpanelbutton As Image = My.Resources.iconTextPad
    Public videoplayericonpanelbutton As Image = My.Resources.iconVideoPlayer
    Public webbrowsericonpanelbutton As Image = My.Resources.iconWebBrowser
    Public namechangericonpanelbutton As Image = My.Resources.iconNameChanger
    Public iconmanagericonpanelbutton As Image = My.Resources.iconIconManager
    Public bitnotewalleticonpanelbutton As Image = My.Resources.iconBitnoteWallet
    Public bitnotediggericonpanelbutton As Image = My.Resources.iconBitnoteDigger
    Public skinshiftericonpanelbutton As Image = My.Resources.iconSkinShifter
    Public shiftneticonpanelbutton As Image = My.Resources.iconShiftnet
    Public downloadericonpanelbutton As Image = My.Resources.iconDownloader

    Public artpadiconlauncher As Image = My.Resources.iconArtpad
    Public audioplayericonlauncher As Image = My.Resources.iconAudioPlayer
    Public calculatoriconlauncher As Image = My.Resources.iconCalculator
    Public clockiconlauncher As Image = My.Resources.iconClock
    Public colourpickericonlauncher As Image = My.Resources.iconColourPicker
    Public fileopenericonlauncher As Image = My.Resources.iconFileOpener
    Public filesavericonlauncher As Image = My.Resources.iconFileSaver
    Public fileskimmericonlauncher As Image = My.Resources.iconFileSkimmer
    Public graphicpickericonlauncher As Image = My.Resources.iconGraphicPicker
    Public infoboxiconlauncher As Image = My.Resources.iconInfoBox
    Public knowledgeinputiconlauncher As Image = My.Resources.iconKnowledgeInput
    Public pongiconlauncher As Image = My.Resources.iconPong
    Public shiftericonlauncher As Image = My.Resources.iconShifter
    Public shiftoriumiconlauncher As Image = My.Resources.iconShiftorium
    Public skinloadericonlauncher As Image = My.Resources.iconSkinLoader
    Public terminaliconlauncher As Image = My.Resources.iconTerminal
    Public textpadiconlauncher As Image = My.Resources.iconTextPad
    Public videoplayericonlauncher As Image = My.Resources.iconVideoPlayer
    Public webbrowsericonlauncher As Image = My.Resources.iconWebBrowser
    Public namechangericonlauncher As Image = My.Resources.iconNameChanger
    Public iconmanagericonlauncher As Image = My.Resources.iconIconManager
    Public bitnotewalleticonlauncher As Image = My.Resources.iconBitnoteWallet
    Public bitnotediggericonlauncher As Image = My.Resources.iconBitnoteDigger
    Public skinshiftericonlauncher As Image = My.Resources.iconSkinShifter
    Public shiftneticonlauncher As Image = My.Resources.iconShiftnet
    Public downloadericonlauncher As Image = My.Resources.iconDownloader

    Public shutdowniconlauncher As Image = My.Resources.iconshutdown

    'Required for encryption of save files
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer
    Public Const sSecretKey As String = "Password"

    'When adding a new program you need to do the following:
    'Copy over Template and Template Code 
    'Make program upmost/alway on top
    'Add the panelbutton
    'Add Open and Close command in terminal as well as info and commands such as move to
    'Add desktop launcher menu item
    'Add buy from shiftorium and lanucher buy from shiftorium
    'Add to all ShiftOSDesktop.vb things

    Public Sub savegame()
        If boughttitlebar = True Then savelines(0) = 11 Else savelines(0) = 10
        If boughtgray = True Then savelines(1) = 11 Else savelines(1) = 10
        If boughtsecondspastmidnight = True Then savelines(2) = 11 Else savelines(2) = 10
        If boughtminutespastmidnight = True Then savelines(3) = 11 Else savelines(3) = 10
        If boughthourspastmidnight = True Then savelines(4) = 11 Else savelines(4) = 10
        If boughtcustomusername = True Then savelines(5) = 11 Else savelines(5) = 10
        If boughtwindowsanywhere = True Then savelines(6) = 11 Else savelines(6) = 10
        If boughtmultitasking = True Then savelines(7) = 11 Else savelines(7) = 10
        If boughtautoscrollterminal = True Then savelines(8) = 11 Else savelines(8) = 10
        savelines(9) = codepoints
        If boughtmovablewindows = True Then savelines(10) = 11 Else savelines(10) = 10
        If boughtdraggablewindows = True Then savelines(11) = 11 Else savelines(11) = 10
        If boughtwindowborders = True Then savelines(12) = 11 Else savelines(12) = 10
        If boughtpmandam = True Then savelines(13) = 11 Else savelines(13) = 10
        If boughtminuteaccuracytime = True Then savelines(14) = 11 Else savelines(14) = 10
        If boughtsplitsecondtime = True Then savelines(15) = 11 Else savelines(15) = 10
        If boughttitletext = True Then savelines(16) = 11 Else savelines(16) = 10
        If boughtclosebutton = True Then savelines(17) = 11 Else savelines(17) = 10
        If boughtdesktoppanel = True Then savelines(18) = 11 Else savelines(18) = 10
        If boughtclock = True Then savelines(19) = 11 Else savelines(19) = 10
        If boughtwindowedterminal = True Then savelines(20) = 11 Else savelines(20) = 10
        If boughtapplaunchermenu = True Then savelines(21) = 11 Else savelines(21) = 10
        If boughtalknowledgeinput = True Then savelines(22) = 11 Else savelines(22) = 10
        If boughtalclock = True Then savelines(23) = 11 Else savelines(23) = 10
        If boughtalshiftorium = True Then savelines(24) = 11 Else savelines(24) = 10
        If boughtapplaunchershutdown = True Then savelines(25) = 11 Else savelines(25) = 10
        If boughtdesktoppanelclock = True Then savelines(26) = 11 Else savelines(26) = 10
        If boughtterminalscrollbar = True Then savelines(27) = 11 Else savelines(27) = 10
        If boughtkiaddons = True Then savelines(28) = 11 Else savelines(28) = 10
        If boughtkicarbrands = True Then savelines(29) = 11 Else savelines(29) = 10
        If boughtkigameconsoles = True Then savelines(30) = 11 Else savelines(30) = 10
        savelines(31) = username
        If terminalfullscreen = True Then savelines(32) = 11 Else savelines(32) = 10
        If boughtshifter = True Then savelines(33) = 11 Else savelines(33) = 10
        If boughtalshifter = True Then savelines(34) = 11 Else savelines(34) = 10
        If boughtrollupcommand = True Then savelines(35) = 11 Else savelines(35) = 10
        If boughtrollupbutton = True Then savelines(36) = 11 Else savelines(36) = 10
        If boughtshiftdesktop = True Then savelines(37) = 11 Else savelines(37) = 10
        If boughtshiftpanelclock = True Then savelines(38) = 11 Else savelines(38) = 10
        If boughtshiftapplauncher = True Then savelines(39) = 11 Else savelines(39) = 10
        If boughtshiftdesktoppanel = True Then savelines(40) = 11 Else savelines(40) = 10
        If boughtshifttitlebar = True Then savelines(41) = 11 Else savelines(41) = 10
        If boughtshifttitletext = True Then savelines(42) = 11 Else savelines(42) = 10
        If boughtshifttitlebuttons = True Then savelines(43) = 11 Else savelines(43) = 10
        If boughtshiftborders = True Then savelines(44) = 11 Else savelines(44) = 10
        If boughtgray2 = True Then savelines(45) = 11 Else savelines(45) = 10
        If boughtgray3 = True Then savelines(46) = 11 Else savelines(46) = 10
        If boughtgray4 = True Then savelines(47) = 11 Else savelines(47) = 10
        If boughtanycolour = True Then savelines(48) = 11 Else savelines(48) = 10
        If boughtanycolour2 = True Then savelines(49) = 11 Else savelines(49) = 10
        If boughtanycolour3 = True Then savelines(50) = 11 Else savelines(50) = 10
        If boughtanycolour4 = True Then savelines(51) = 11 Else savelines(51) = 10
        If boughtpurple = True Then savelines(52) = 11 Else savelines(52) = 10
        If boughtpurple2 = True Then savelines(53) = 11 Else savelines(53) = 10
        If boughtpurple3 = True Then savelines(54) = 11 Else savelines(54) = 10
        If boughtpurple4 = True Then savelines(55) = 11 Else savelines(55) = 10
        If boughtblue = True Then savelines(56) = 11 Else savelines(56) = 10
        If boughtblue2 = True Then savelines(57) = 11 Else savelines(57) = 10
        If boughtblue3 = True Then savelines(58) = 11 Else savelines(58) = 10
        If boughtblue4 = True Then savelines(59) = 11 Else savelines(59) = 10
        If boughtgreen = True Then savelines(60) = 11 Else savelines(60) = 10
        If boughtgreen2 = True Then savelines(61) = 11 Else savelines(61) = 10
        If boughtgreen3 = True Then savelines(62) = 11 Else savelines(62) = 10
        If boughtgreen4 = True Then savelines(63) = 11 Else savelines(63) = 10
        If boughtyellow = True Then savelines(64) = 11 Else savelines(64) = 10
        If boughtyellow2 = True Then savelines(65) = 11 Else savelines(65) = 10
        If boughtyellow3 = True Then savelines(66) = 11 Else savelines(66) = 10
        If boughtyellow4 = True Then savelines(67) = 11 Else savelines(67) = 10
        If boughtorange = True Then savelines(68) = 11 Else savelines(68) = 10
        If boughtorange2 = True Then savelines(69) = 11 Else savelines(69) = 10
        If boughtorange3 = True Then savelines(70) = 11 Else savelines(70) = 10
        If boughtorange4 = True Then savelines(71) = 11 Else savelines(71) = 10
        If boughtbrown = True Then savelines(72) = 11 Else savelines(72) = 10
        If boughtbrown2 = True Then savelines(73) = 11 Else savelines(73) = 10
        If boughtbrown3 = True Then savelines(74) = 11 Else savelines(74) = 10
        If boughtbrown4 = True Then savelines(75) = 11 Else savelines(75) = 10
        If boughtred = True Then savelines(76) = 11 Else savelines(76) = 10
        If boughtred2 = True Then savelines(77) = 11 Else savelines(77) = 10
        If boughtred3 = True Then savelines(78) = 11 Else savelines(78) = 10
        If boughtred4 = True Then savelines(79) = 11 Else savelines(79) = 10
        If boughtpink = True Then savelines(80) = 11 Else savelines(80) = 10
        If boughtpink2 = True Then savelines(81) = 11 Else savelines(81) = 10
        If boughtpink3 = True Then savelines(82) = 11 Else savelines(82) = 10
        If boughtpink4 = True Then savelines(83) = 11 Else savelines(83) = 10
        savelines(84) = anymemory(0).ToArgb
        savelines(85) = anymemory(1).ToArgb
        savelines(86) = anymemory(2).ToArgb
        savelines(87) = anymemory(3).ToArgb
        savelines(88) = anymemory(4).ToArgb
        savelines(89) = anymemory(5).ToArgb
        savelines(90) = anymemory(6).ToArgb
        savelines(91) = anymemory(7).ToArgb
        savelines(92) = anymemory(8).ToArgb
        savelines(93) = anymemory(9).ToArgb
        savelines(94) = anymemory(10).ToArgb
        savelines(95) = anymemory(11).ToArgb
        savelines(96) = anymemory(12).ToArgb
        savelines(97) = anymemory(13).ToArgb
        savelines(98) = anymemory(14).ToArgb
        savelines(99) = anymemory(15).ToArgb
        savelines(100) = graymemory(0).ToArgb
        savelines(101) = graymemory(1).ToArgb
        savelines(102) = graymemory(2).ToArgb
        savelines(103) = graymemory(3).ToArgb
        savelines(104) = graymemory(4).ToArgb
        savelines(105) = graymemory(5).ToArgb
        savelines(106) = graymemory(6).ToArgb
        savelines(107) = graymemory(7).ToArgb
        savelines(108) = graymemory(8).ToArgb
        savelines(109) = graymemory(9).ToArgb
        savelines(110) = graymemory(10).ToArgb
        savelines(111) = graymemory(11).ToArgb
        savelines(112) = graymemory(12).ToArgb
        savelines(113) = graymemory(13).ToArgb
        savelines(114) = graymemory(14).ToArgb
        savelines(115) = graymemory(15).ToArgb
        savelines(116) = purplememory(0).ToArgb
        savelines(117) = purplememory(1).ToArgb
        savelines(118) = purplememory(2).ToArgb
        savelines(119) = purplememory(3).ToArgb
        savelines(120) = purplememory(4).ToArgb
        savelines(121) = purplememory(5).ToArgb
        savelines(122) = purplememory(6).ToArgb
        savelines(123) = purplememory(7).ToArgb
        savelines(124) = purplememory(8).ToArgb
        savelines(125) = purplememory(9).ToArgb
        savelines(126) = purplememory(10).ToArgb
        savelines(127) = purplememory(11).ToArgb
        savelines(128) = purplememory(12).ToArgb
        savelines(129) = purplememory(13).ToArgb
        savelines(130) = purplememory(14).ToArgb
        savelines(131) = purplememory(15).ToArgb
        savelines(132) = bluememory(0).ToArgb
        savelines(133) = bluememory(1).ToArgb
        savelines(134) = bluememory(2).ToArgb
        savelines(135) = bluememory(3).ToArgb
        savelines(136) = bluememory(4).ToArgb
        savelines(137) = bluememory(5).ToArgb
        savelines(138) = bluememory(6).ToArgb
        savelines(139) = bluememory(7).ToArgb
        savelines(140) = bluememory(8).ToArgb
        savelines(141) = bluememory(9).ToArgb
        savelines(142) = bluememory(10).ToArgb
        savelines(143) = bluememory(11).ToArgb
        savelines(144) = bluememory(12).ToArgb
        savelines(145) = bluememory(13).ToArgb
        savelines(146) = bluememory(14).ToArgb
        savelines(147) = bluememory(15).ToArgb
        savelines(148) = greenmemory(0).ToArgb
        savelines(149) = greenmemory(1).ToArgb
        savelines(150) = greenmemory(2).ToArgb
        savelines(151) = greenmemory(3).ToArgb
        savelines(152) = greenmemory(4).ToArgb
        savelines(153) = greenmemory(5).ToArgb
        savelines(154) = greenmemory(6).ToArgb
        savelines(155) = greenmemory(7).ToArgb
        savelines(156) = greenmemory(8).ToArgb
        savelines(157) = greenmemory(9).ToArgb
        savelines(158) = greenmemory(10).ToArgb
        savelines(159) = greenmemory(11).ToArgb
        savelines(160) = greenmemory(12).ToArgb
        savelines(161) = greenmemory(13).ToArgb
        savelines(162) = greenmemory(14).ToArgb
        savelines(163) = greenmemory(15).ToArgb
        savelines(164) = yellowmemory(0).ToArgb
        savelines(165) = yellowmemory(1).ToArgb
        savelines(166) = yellowmemory(2).ToArgb
        savelines(167) = yellowmemory(3).ToArgb
        savelines(168) = yellowmemory(4).ToArgb
        savelines(169) = yellowmemory(5).ToArgb
        savelines(170) = yellowmemory(6).ToArgb
        savelines(171) = yellowmemory(7).ToArgb
        savelines(172) = yellowmemory(8).ToArgb
        savelines(173) = yellowmemory(9).ToArgb
        savelines(174) = yellowmemory(10).ToArgb
        savelines(175) = yellowmemory(11).ToArgb
        savelines(176) = yellowmemory(12).ToArgb
        savelines(177) = yellowmemory(13).ToArgb
        savelines(178) = yellowmemory(14).ToArgb
        savelines(179) = yellowmemory(15).ToArgb
        savelines(180) = orangememory(0).ToArgb
        savelines(181) = orangememory(1).ToArgb
        savelines(182) = orangememory(2).ToArgb
        savelines(183) = orangememory(3).ToArgb
        savelines(184) = orangememory(4).ToArgb
        savelines(185) = orangememory(5).ToArgb
        savelines(186) = orangememory(6).ToArgb
        savelines(187) = orangememory(7).ToArgb
        savelines(188) = orangememory(8).ToArgb
        savelines(189) = orangememory(9).ToArgb
        savelines(190) = orangememory(10).ToArgb
        savelines(191) = orangememory(11).ToArgb
        savelines(192) = orangememory(12).ToArgb
        savelines(193) = orangememory(13).ToArgb
        savelines(194) = orangememory(14).ToArgb
        savelines(195) = orangememory(15).ToArgb
        savelines(196) = brownmemory(0).ToArgb
        savelines(197) = brownmemory(1).ToArgb
        savelines(198) = brownmemory(2).ToArgb
        savelines(199) = brownmemory(3).ToArgb
        savelines(200) = brownmemory(4).ToArgb
        savelines(201) = brownmemory(5).ToArgb
        savelines(202) = brownmemory(6).ToArgb
        savelines(203) = brownmemory(7).ToArgb
        savelines(204) = brownmemory(8).ToArgb
        savelines(205) = brownmemory(9).ToArgb
        savelines(206) = brownmemory(10).ToArgb
        savelines(207) = brownmemory(11).ToArgb
        savelines(208) = brownmemory(12).ToArgb
        savelines(209) = brownmemory(13).ToArgb
        savelines(210) = brownmemory(14).ToArgb
        savelines(211) = brownmemory(15).ToArgb
        savelines(212) = redmemory(0).ToArgb
        savelines(213) = redmemory(1).ToArgb
        savelines(214) = redmemory(2).ToArgb
        savelines(215) = redmemory(3).ToArgb
        savelines(216) = redmemory(4).ToArgb
        savelines(217) = redmemory(5).ToArgb
        savelines(218) = redmemory(6).ToArgb
        savelines(219) = redmemory(7).ToArgb
        savelines(220) = redmemory(8).ToArgb
        savelines(221) = redmemory(9).ToArgb
        savelines(222) = redmemory(10).ToArgb
        savelines(223) = redmemory(11).ToArgb
        savelines(224) = redmemory(12).ToArgb
        savelines(225) = redmemory(13).ToArgb
        savelines(226) = redmemory(14).ToArgb
        savelines(227) = redmemory(15).ToArgb
        savelines(228) = pinkmemory(0).ToArgb
        savelines(229) = pinkmemory(1).ToArgb
        savelines(230) = pinkmemory(2).ToArgb
        savelines(231) = pinkmemory(3).ToArgb
        savelines(232) = pinkmemory(4).ToArgb
        savelines(233) = pinkmemory(5).ToArgb
        savelines(234) = pinkmemory(6).ToArgb
        savelines(235) = pinkmemory(7).ToArgb
        savelines(236) = pinkmemory(8).ToArgb
        savelines(237) = pinkmemory(9).ToArgb
        savelines(238) = pinkmemory(10).ToArgb
        savelines(239) = pinkmemory(11).ToArgb
        savelines(240) = pinkmemory(12).ToArgb
        savelines(241) = pinkmemory(13).ToArgb
        savelines(242) = pinkmemory(14).ToArgb
        savelines(243) = pinkmemory(15).ToArgb
        savelines(244) = titlebarcolour.ToArgb
        savelines(245) = windowbordercolour.ToArgb
        savelines(246) = windowbordersize
        savelines(247) = titlebarheight
        savelines(248) = closebuttoncolour.ToArgb
        savelines(249) = closebuttonheight
        savelines(250) = closebuttonwidth
        savelines(251) = closebuttonside
        savelines(252) = closebuttontop
        savelines(253) = titletextcolour.ToArgb
        savelines(254) = titletexttop
        savelines(255) = titletextside
        savelines(256) = titletextsize
        savelines(257) = titletextfont
        savelines(258) = titletextstyle
        savelines(259) = desktoppanelcolour.ToArgb
        savelines(260) = desktopbackgroundcolour.ToArgb
        savelines(261) = desktoppanelheight
        savelines(262) = desktoppanelposition
        savelines(263) = clocktextcolour.ToArgb
        savelines(264) = clockbackgroundcolor.ToArgb
        savelines(265) = panelclocktexttop
        savelines(266) = panelclocktextsize
        savelines(267) = panelclocktextfont
        savelines(268) = panelclocktextstyle
        savelines(269) = applauncherbuttoncolour.ToArgb
        savelines(270) = applauncherbuttonclickedcolour.ToArgb
        savelines(271) = applauncherbackgroundcolour.ToArgb
        savelines(272) = applaunchermouseovercolour.ToArgb
        savelines(273) = applicationsbuttontextcolour.ToArgb
        savelines(274) = applicationbuttonheight
        savelines(275) = applicationbuttontextsize
        savelines(276) = applicationbuttontextfont
        savelines(277) = applicationbuttontextstyle
        savelines(278) = applicationlaunchername
        savelines(279) = titletextposition
        savelines(280) = rollupbuttoncolour.ToArgb
        savelines(281) = rollupbuttonheight
        savelines(282) = rollupbuttonwidth
        savelines(283) = rollupbuttonside
        savelines(284) = rollupbuttontop
        If boughtpong = True Then savelines(285) = 11 Else savelines(285) = 10
        If boughtknowledgeinputicon = True Then savelines(286) = 11 Else savelines(286) = 10
        If boughtshiftericon = True Then savelines(287) = 11 Else savelines(287) = 10
        If boughtshiftoriumicon = True Then savelines(288) = 11 Else savelines(288) = 10
        If boughtclockicon = True Then savelines(289) = 11 Else savelines(289) = 10
        If boughtshutdownicon = True Then savelines(290) = 11 Else savelines(290) = 10
        If boughtpongicon = True Then savelines(291) = 11 Else savelines(291) = 10
        If boughtterminalicon = True Then savelines(292) = 11 Else savelines(292) = 10
        If boughtalpong = True Then savelines(293) = 11 Else savelines(293) = 10
        If boughtfileskimmer = True Then savelines(294) = 11 Else savelines(294) = 10
        If boughtalfileskimmer = True Then savelines(295) = 11 Else savelines(295) = 10
        If boughttextpad = True Then savelines(296) = 11 Else savelines(296) = 10
        If boughtaltextpad = True Then savelines(297) = 11 Else savelines(297) = 10
        If boughtfileskimmericon = True Then savelines(298) = 11 Else savelines(298) = 10
        If boughttextpadicon = True Then savelines(299) = 11 Else savelines(299) = 10
        If boughttextpadnew = True Then savelines(300) = 11 Else savelines(300) = 10
        If boughttextpadsave = True Then savelines(301) = 11 Else savelines(301) = 10
        If boughttextpadopen = True Then savelines(302) = 11 Else savelines(302) = 10
        If boughtfileskimmernewfolder = True Then savelines(303) = 11 Else savelines(303) = 10
        If boughtfileskimmerdelete = True Then savelines(304) = 11 Else savelines(304) = 10
        If boughtkielements = True Then savelines(305) = 11 Else savelines(305) = 10
        If boughtcolourpickericon = True Then savelines(306) = 11 Else savelines(306) = 10
        If boughtinfoboxicon = True Then savelines(307) = 11 Else savelines(307) = 10
        savelines(308) = artpadcolorpalletwidth
        savelines(309) = artpadcolorpalletheight
        savelines(310) = artpadcolorpalletsidegap
        savelines(311) = artpadcolorpallettopgap
        savelines(312) = artpadvisiblepallets
        savelines(313) = artpadpixellimit
        If boughtskinloader = True Then savelines(314) = 11 Else savelines(314) = 10
        If boughtminimizebutton = True Then savelines(315) = 11 Else savelines(315) = 10
        If boughtpanelbuttons = True Then savelines(316) = 11 Else savelines(316) = 10
        If boughtshiftpanelbuttons = True Then savelines(317) = 11 Else savelines(317) = 10
        If boughtartpad = True Then savelines(318) = 11 Else savelines(318) = 10
        If boughtalartpad = True Then savelines(319) = 11 Else savelines(319) = 10
        If boughtartpadicon = True Then savelines(320) = 11 Else savelines(320) = 10
        If boughtskinning = True Then savelines(321) = 11 Else savelines(321) = 10
        If boughtminimizecommand = True Then savelines(322) = 11 Else savelines(322) = 10
        If boughtusefulpanelbuttons = True Then savelines(323) = 11 Else savelines(323) = 10
        If boughtunitymode = True Then savelines(324) = 11 Else savelines(324) = 10
        If boughtartpadpixellimit4 = True Then savelines(325) = 11 Else savelines(325) = 10
        If boughtartpadpixellimit8 = True Then savelines(326) = 11 Else savelines(326) = 10
        If boughtartpadpixellimit16 = True Then savelines(327) = 11 Else savelines(327) = 10
        If boughtartpadpixellimit64 = True Then savelines(328) = 11 Else savelines(328) = 10
        If boughtartpadpixellimit256 = True Then savelines(329) = 11 Else savelines(329) = 10
        If boughtartpadpixellimit1024 = True Then savelines(330) = 11 Else savelines(330) = 10
        If boughtartpadpixellimit4096 = True Then savelines(331) = 11 Else savelines(331) = 10
        If boughtartpadpixellimit16384 = True Then savelines(332) = 11 Else savelines(332) = 10
        If boughtartpadpixellimit65536 = True Then savelines(333) = 11 Else savelines(333) = 10
        If boughtartpadlimitlesspixels = True Then savelines(334) = 11 Else savelines(334) = 10
        If boughtartpad4colorpallets = True Then savelines(335) = 11 Else savelines(335) = 10
        If boughtartpad8colorpallets = True Then savelines(336) = 11 Else savelines(336) = 10
        If boughtartpad16colorpallets = True Then savelines(337) = 11 Else savelines(337) = 10
        If boughtartpad32colorpallets = True Then savelines(338) = 11 Else savelines(338) = 10
        If boughtartpad64colorpallets = True Then savelines(339) = 11 Else savelines(339) = 10
        If boughtartpad128colorpallets = True Then savelines(340) = 11 Else savelines(340) = 10
        If boughtartpadcustompallets = True Then savelines(341) = 11 Else savelines(341) = 10
        If boughtartpadpixelplacer = True Then savelines(342) = 11 Else savelines(342) = 10
        If boughtartpadpixelplacermovementmode = True Then savelines(343) = 11 Else savelines(343) = 10
        If boughtartpadpencil = True Then savelines(344) = 11 Else savelines(344) = 10
        If boughtartpadpaintbrush = True Then savelines(345) = 11 Else savelines(345) = 10
        If boughtartpadlinetool = True Then savelines(346) = 11 Else savelines(346) = 10
        If boughtartpadovaltool = True Then savelines(347) = 11 Else savelines(347) = 10
        If boughtartpadrectangletool = True Then savelines(348) = 11 Else savelines(348) = 10
        If boughtartpaderaser = True Then savelines(349) = 11 Else savelines(349) = 10
        If boughtartpadfilltool = True Then savelines(350) = 11 Else savelines(350) = 10
        If boughtartpadtexttool = True Then savelines(351) = 11 Else savelines(351) = 10
        If boughtartpadundo = True Then savelines(352) = 11 Else savelines(352) = 10
        If boughtartpadredo = True Then savelines(353) = 11 Else savelines(353) = 10
        If boughtartpadsave = True Then savelines(354) = 11 Else savelines(354) = 10
        If boughtartpadload = True Then savelines(355) = 11 Else savelines(355) = 10
        For i = 0 To 127 : savelines(356 + i) = artpadcolourpallets(i).ToArgb : Next
        If boughtartpadnew = True Then savelines(484) = 11 Else savelines(484) = 10

        IO.File.WriteAllLines("C:\ShiftOS\Shiftum42\Drivers\HDD.dri", savelines)
        File_Crypt.EncryptFile("C:\ShiftOS\Shiftum42\Drivers\HDD.dri", "C:/ShiftOS/Shiftum42/SKernal.sft", sSecretKey)

        Dim objWriter As New System.IO.StreamWriter("C:/ShiftOS/Shiftum42/HDAccess.sft", False)
        objWriter.Write(actualshiftversion)
        objWriter.Close()

    End Sub

    Private Sub loadgame()
        File_Crypt.DecryptFile("C:/ShiftOS/Shiftum42/SKernal.sft", "C:\ShiftOS\Shiftum42\Drivers\HDD.dri", sSecretKey)
        loadlines = IO.File.ReadAllLines("C:\ShiftOS\Shiftum42\Drivers\HDD.dri")

        If loadlines(0) = 11 Then boughttitlebar = True Else boughttitlebar = False
        If loadlines(1) = 11 Then boughtgray = True Else boughtgray = False
        If loadlines(2) = 11 Then boughtsecondspastmidnight = True Else boughtsecondspastmidnight = False
        If loadlines(3) = 11 Then boughtminutespastmidnight = True Else boughtminutespastmidnight = False
        If loadlines(4) = 11 Then boughthourspastmidnight = True Else boughthourspastmidnight = False
        If loadlines(5) = 11 Then boughtcustomusername = True Else boughtcustomusername = False
        If loadlines(6) = 11 Then boughtwindowsanywhere = True Else boughtwindowsanywhere = False
        If loadlines(7) = 11 Then boughtmultitasking = True Else boughtmultitasking = False
        If loadlines(8) = 11 Then boughtautoscrollterminal = True Else boughtautoscrollterminal = False
        codepoints = loadlines(9)
        If loadlines(10) = 11 Then boughtmovablewindows = True Else boughtmovablewindows = False
        If loadlines(11) = 11 Then boughtdraggablewindows = True Else boughtdraggablewindows = False
        If loadlines(12) = 11 Then boughtwindowborders = True Else boughtwindowborders = False
        If loadlines(13) = 11 Then boughtpmandam = True Else boughtpmandam = False
        If loadlines(14) = 11 Then boughtminuteaccuracytime = True Else boughtminuteaccuracytime = False
        If loadlines(15) = 11 Then boughtsplitsecondtime = True Else boughtsplitsecondtime = False
        If loadlines(16) = 11 Then boughttitletext = True Else boughttitletext = False
        If loadlines(17) = 11 Then boughtclosebutton = True Else boughtclosebutton = False
        If loadlines(18) = 11 Then boughtdesktoppanel = True Else boughtdesktoppanel = False
        If loadlines(19) = 11 Then boughtclock = True Else boughtclock = False
        If loadlines(20) = 11 Then boughtwindowedterminal = True Else boughtwindowedterminal = False
        If loadlines(21) = 11 Then boughtapplaunchermenu = True Else boughtapplaunchermenu = False
        If loadlines(22) = 11 Then boughtalknowledgeinput = True Else boughtalknowledgeinput = False
        If loadlines(23) = 11 Then boughtalclock = True Else boughtalclock = False
        If loadlines(24) = 11 Then boughtalshiftorium = True Else boughtalshiftorium = False
        If loadlines(25) = 11 Then boughtapplaunchershutdown = True Else boughtapplaunchershutdown = False
        If loadlines(26) = 11 Then boughtdesktoppanelclock = True Else boughtdesktoppanelclock = False
        If loadlines(27) = 11 Then boughtterminalscrollbar = True Else boughtterminalscrollbar = False
        If loadlines(28) = 11 Then boughtkiaddons = True Else boughtkiaddons = False
        If loadlines(29) = 11 Then boughtkicarbrands = True Else boughtkicarbrands = False
        If loadlines(30) = 11 Then boughtkigameconsoles = True Else boughtkigameconsoles = False
        username = loadlines(31)
        If loadlines(32) = 11 Then terminalfullscreen = True Else terminalfullscreen = False
        If loadlines(33) = 11 Then boughtshifter = True Else boughtshifter = False
        If loadlines(34) = 11 Then boughtalshifter = True Else boughtalshifter = False
        If loadlines(35) = 11 Then boughtrollupcommand = True Else boughtrollupcommand = False
        If loadlines(36) = 11 Then boughtrollupbutton = True Else boughtrollupbutton = False
        If loadlines(37) = 11 Then boughtshiftdesktop = True Else boughtshiftdesktop = False
        If loadlines(38) = 11 Then boughtshiftpanelclock = True Else boughtshiftpanelclock = False
        If loadlines(39) = 11 Then boughtshiftapplauncher = True Else boughtshiftapplauncher = False
        If loadlines(40) = 11 Then boughtshiftdesktoppanel = True Else boughtshiftdesktoppanel = False
        If loadlines(41) = 11 Then boughtshifttitlebar = True Else boughtshifttitlebar = False
        If loadlines(42) = 11 Then boughtshifttitletext = True Else boughtshifttitletext = False
        If loadlines(43) = 11 Then boughtshifttitlebuttons = True Else boughtshifttitlebuttons = False
        If loadlines(44) = 11 Then boughtshiftborders = True Else boughtshiftborders = False
        If loadlines(45) = 11 Then boughtgray2 = True Else boughtgray2 = False
        If loadlines(46) = 11 Then boughtgray3 = True Else boughtgray3 = False
        If loadlines(47) = 11 Then boughtgray4 = True Else boughtgray4 = False
        If loadlines(48) = 11 Then boughtanycolour = True Else boughtanycolour = False
        If loadlines(49) = 11 Then boughtanycolour2 = True Else boughtanycolour2 = False
        If loadlines(50) = 11 Then boughtanycolour3 = True Else boughtanycolour3 = False
        If loadlines(51) = 11 Then boughtanycolour4 = True Else boughtanycolour4 = False
        If loadlines(52) = 11 Then boughtpurple = True Else boughtpurple = False
        If loadlines(53) = 11 Then boughtpurple2 = True Else boughtpurple2 = False
        If loadlines(54) = 11 Then boughtpurple3 = True Else boughtpurple3 = False
        If loadlines(55) = 11 Then boughtpurple4 = True Else boughtpurple4 = False
        If loadlines(56) = 11 Then boughtblue = True Else boughtblue = False
        If loadlines(57) = 11 Then boughtblue2 = True Else boughtblue2 = False
        If loadlines(58) = 11 Then boughtblue3 = True Else boughtblue3 = False
        If loadlines(59) = 11 Then boughtblue4 = True Else boughtblue4 = False
        If loadlines(60) = 11 Then boughtgreen = True Else boughtgreen = False
        If loadlines(61) = 11 Then boughtgreen2 = True Else boughtgreen2 = False
        If loadlines(62) = 11 Then boughtgreen3 = True Else boughtgreen3 = False
        If loadlines(63) = 11 Then boughtgreen4 = True Else boughtgreen4 = False
        If loadlines(64) = 11 Then boughtyellow = True Else boughtyellow = False
        If loadlines(65) = 11 Then boughtyellow2 = True Else boughtyellow2 = False
        If loadlines(66) = 11 Then boughtyellow3 = True Else boughtyellow3 = False
        If loadlines(67) = 11 Then boughtyellow4 = True Else boughtyellow4 = False
        If loadlines(68) = 11 Then boughtorange = True Else boughtorange = False
        If loadlines(69) = 11 Then boughtorange2 = True Else boughtorange2 = False
        If loadlines(70) = 11 Then boughtorange3 = True Else boughtorange3 = False
        If loadlines(71) = 11 Then boughtorange4 = True Else boughtorange4 = False
        If loadlines(72) = 11 Then boughtbrown = True Else boughtbrown = False
        If loadlines(73) = 11 Then boughtbrown2 = True Else boughtbrown2 = False
        If loadlines(74) = 11 Then boughtbrown3 = True Else boughtbrown3 = False
        If loadlines(75) = 11 Then boughtbrown4 = True Else boughtbrown4 = False
        If loadlines(76) = 11 Then boughtred = True Else boughtred = False
        If loadlines(77) = 11 Then boughtred2 = True Else boughtred2 = False
        If loadlines(78) = 11 Then boughtred3 = True Else boughtred3 = False
        If loadlines(79) = 11 Then boughtred4 = True Else boughtred4 = False
        If loadlines(80) = 11 Then boughtpink = True Else boughtpink = False
        If loadlines(81) = 11 Then boughtpink2 = True Else boughtpink2 = False
        If loadlines(82) = 11 Then boughtpink3 = True Else boughtpink3 = False
        If loadlines(83) = 11 Then boughtpink4 = True Else boughtpink4 = False
        anymemory(0) = Color.FromArgb(loadlines(84))
        anymemory(1) = Color.FromArgb(loadlines(85))
        anymemory(2) = Color.FromArgb(loadlines(86))
        anymemory(3) = Color.FromArgb(loadlines(87))
        anymemory(4) = Color.FromArgb(loadlines(88))
        anymemory(5) = Color.FromArgb(loadlines(89))
        anymemory(6) = Color.FromArgb(loadlines(90))
        anymemory(7) = Color.FromArgb(loadlines(91))
        anymemory(8) = Color.FromArgb(loadlines(92))
        anymemory(9) = Color.FromArgb(loadlines(93))
        anymemory(10) = Color.FromArgb(loadlines(94))
        anymemory(11) = Color.FromArgb(loadlines(95))
        anymemory(12) = Color.FromArgb(loadlines(96))
        anymemory(13) = Color.FromArgb(loadlines(97))
        anymemory(14) = Color.FromArgb(loadlines(98))
        anymemory(15) = Color.FromArgb(loadlines(99))
        graymemory(0) = Color.FromArgb(loadlines(100))
        graymemory(1) = Color.FromArgb(loadlines(101))
        graymemory(2) = Color.FromArgb(loadlines(102))
        graymemory(3) = Color.FromArgb(loadlines(103))
        graymemory(4) = Color.FromArgb(loadlines(104))
        graymemory(5) = Color.FromArgb(loadlines(105))
        graymemory(6) = Color.FromArgb(loadlines(106))
        graymemory(7) = Color.FromArgb(loadlines(107))
        graymemory(8) = Color.FromArgb(loadlines(108))
        graymemory(9) = Color.FromArgb(loadlines(109))
        graymemory(10) = Color.FromArgb(loadlines(110))
        graymemory(11) = Color.FromArgb(loadlines(111))
        graymemory(12) = Color.FromArgb(loadlines(112))
        graymemory(13) = Color.FromArgb(loadlines(113))
        graymemory(14) = Color.FromArgb(loadlines(114))
        graymemory(15) = Color.FromArgb(loadlines(115))
        purplememory(0) = Color.FromArgb(loadlines(116))
        purplememory(1) = Color.FromArgb(loadlines(117))
        purplememory(2) = Color.FromArgb(loadlines(118))
        purplememory(3) = Color.FromArgb(loadlines(119))
        purplememory(4) = Color.FromArgb(loadlines(120))
        purplememory(5) = Color.FromArgb(loadlines(121))
        purplememory(6) = Color.FromArgb(loadlines(122))
        purplememory(7) = Color.FromArgb(loadlines(123))
        purplememory(8) = Color.FromArgb(loadlines(124))
        purplememory(9) = Color.FromArgb(loadlines(125))
        purplememory(10) = Color.FromArgb(loadlines(126))
        purplememory(11) = Color.FromArgb(loadlines(127))
        purplememory(12) = Color.FromArgb(loadlines(128))
        purplememory(13) = Color.FromArgb(loadlines(129))
        purplememory(14) = Color.FromArgb(loadlines(130))
        purplememory(15) = Color.FromArgb(loadlines(131))
        bluememory(0) = Color.FromArgb(loadlines(132))
        bluememory(1) = Color.FromArgb(loadlines(133))
        bluememory(2) = Color.FromArgb(loadlines(134))
        bluememory(3) = Color.FromArgb(loadlines(135))
        bluememory(4) = Color.FromArgb(loadlines(136))
        bluememory(5) = Color.FromArgb(loadlines(137))
        bluememory(6) = Color.FromArgb(loadlines(138))
        bluememory(7) = Color.FromArgb(loadlines(139))
        bluememory(8) = Color.FromArgb(loadlines(140))
        bluememory(9) = Color.FromArgb(loadlines(141))
        bluememory(10) = Color.FromArgb(loadlines(142))
        bluememory(11) = Color.FromArgb(loadlines(143))
        bluememory(12) = Color.FromArgb(loadlines(144))
        bluememory(13) = Color.FromArgb(loadlines(145))
        bluememory(14) = Color.FromArgb(loadlines(146))
        bluememory(15) = Color.FromArgb(loadlines(147))
        greenmemory(0) = Color.FromArgb(loadlines(148))
        greenmemory(1) = Color.FromArgb(loadlines(149))
        greenmemory(2) = Color.FromArgb(loadlines(150))
        greenmemory(3) = Color.FromArgb(loadlines(151))
        greenmemory(4) = Color.FromArgb(loadlines(152))
        greenmemory(5) = Color.FromArgb(loadlines(153))
        greenmemory(6) = Color.FromArgb(loadlines(154))
        greenmemory(7) = Color.FromArgb(loadlines(155))
        greenmemory(8) = Color.FromArgb(loadlines(156))
        greenmemory(9) = Color.FromArgb(loadlines(157))
        greenmemory(10) = Color.FromArgb(loadlines(158))
        greenmemory(11) = Color.FromArgb(loadlines(159))
        greenmemory(12) = Color.FromArgb(loadlines(160))
        greenmemory(13) = Color.FromArgb(loadlines(161))
        greenmemory(14) = Color.FromArgb(loadlines(162))
        greenmemory(15) = Color.FromArgb(loadlines(163))
        yellowmemory(0) = Color.FromArgb(loadlines(164))
        yellowmemory(1) = Color.FromArgb(loadlines(165))
        yellowmemory(2) = Color.FromArgb(loadlines(166))
        yellowmemory(3) = Color.FromArgb(loadlines(167))
        yellowmemory(4) = Color.FromArgb(loadlines(168))
        yellowmemory(5) = Color.FromArgb(loadlines(169))
        yellowmemory(6) = Color.FromArgb(loadlines(170))
        yellowmemory(7) = Color.FromArgb(loadlines(171))
        yellowmemory(8) = Color.FromArgb(loadlines(172))
        yellowmemory(9) = Color.FromArgb(loadlines(173))
        yellowmemory(10) = Color.FromArgb(loadlines(174))
        yellowmemory(11) = Color.FromArgb(loadlines(175))
        yellowmemory(12) = Color.FromArgb(loadlines(176))
        yellowmemory(13) = Color.FromArgb(loadlines(177))
        yellowmemory(14) = Color.FromArgb(loadlines(178))
        yellowmemory(15) = Color.FromArgb(loadlines(179))
        orangememory(0) = Color.FromArgb(loadlines(180))
        orangememory(1) = Color.FromArgb(loadlines(181))
        orangememory(2) = Color.FromArgb(loadlines(182))
        orangememory(3) = Color.FromArgb(loadlines(183))
        orangememory(4) = Color.FromArgb(loadlines(184))
        orangememory(5) = Color.FromArgb(loadlines(185))
        orangememory(6) = Color.FromArgb(loadlines(186))
        orangememory(7) = Color.FromArgb(loadlines(187))
        orangememory(8) = Color.FromArgb(loadlines(188))
        orangememory(9) = Color.FromArgb(loadlines(189))
        orangememory(10) = Color.FromArgb(loadlines(190))
        orangememory(11) = Color.FromArgb(loadlines(191))
        orangememory(12) = Color.FromArgb(loadlines(192))
        orangememory(13) = Color.FromArgb(loadlines(193))
        orangememory(14) = Color.FromArgb(loadlines(194))
        orangememory(15) = Color.FromArgb(loadlines(195))
        brownmemory(0) = Color.FromArgb(loadlines(196))
        brownmemory(1) = Color.FromArgb(loadlines(197))
        brownmemory(2) = Color.FromArgb(loadlines(198))
        brownmemory(3) = Color.FromArgb(loadlines(199))
        brownmemory(4) = Color.FromArgb(loadlines(200))
        brownmemory(5) = Color.FromArgb(loadlines(201))
        brownmemory(6) = Color.FromArgb(loadlines(202))
        brownmemory(7) = Color.FromArgb(loadlines(203))
        brownmemory(8) = Color.FromArgb(loadlines(204))
        brownmemory(9) = Color.FromArgb(loadlines(205))
        brownmemory(10) = Color.FromArgb(loadlines(206))
        brownmemory(11) = Color.FromArgb(loadlines(207))
        brownmemory(12) = Color.FromArgb(loadlines(208))
        brownmemory(13) = Color.FromArgb(loadlines(209))
        brownmemory(14) = Color.FromArgb(loadlines(210))
        brownmemory(15) = Color.FromArgb(loadlines(211))
        redmemory(0) = Color.FromArgb(loadlines(212))
        redmemory(1) = Color.FromArgb(loadlines(213))
        redmemory(2) = Color.FromArgb(loadlines(214))
        redmemory(3) = Color.FromArgb(loadlines(215))
        redmemory(4) = Color.FromArgb(loadlines(216))
        redmemory(5) = Color.FromArgb(loadlines(217))
        redmemory(6) = Color.FromArgb(loadlines(218))
        redmemory(7) = Color.FromArgb(loadlines(219))
        redmemory(8) = Color.FromArgb(loadlines(220))
        redmemory(9) = Color.FromArgb(loadlines(221))
        redmemory(10) = Color.FromArgb(loadlines(222))
        redmemory(11) = Color.FromArgb(loadlines(223))
        redmemory(12) = Color.FromArgb(loadlines(224))
        redmemory(13) = Color.FromArgb(loadlines(225))
        redmemory(14) = Color.FromArgb(loadlines(226))
        redmemory(15) = Color.FromArgb(loadlines(227))
        pinkmemory(0) = Color.FromArgb(loadlines(228))
        pinkmemory(1) = Color.FromArgb(loadlines(229))
        pinkmemory(2) = Color.FromArgb(loadlines(230))
        pinkmemory(3) = Color.FromArgb(loadlines(231))
        pinkmemory(4) = Color.FromArgb(loadlines(232))
        pinkmemory(5) = Color.FromArgb(loadlines(233))
        pinkmemory(6) = Color.FromArgb(loadlines(234))
        pinkmemory(7) = Color.FromArgb(loadlines(235))
        pinkmemory(8) = Color.FromArgb(loadlines(236))
        pinkmemory(9) = Color.FromArgb(loadlines(237))
        pinkmemory(10) = Color.FromArgb(loadlines(238))
        pinkmemory(11) = Color.FromArgb(loadlines(239))
        pinkmemory(12) = Color.FromArgb(loadlines(240))
        pinkmemory(13) = Color.FromArgb(loadlines(241))
        pinkmemory(14) = Color.FromArgb(loadlines(242))
        pinkmemory(15) = Color.FromArgb(loadlines(243))
        titlebarcolour = Color.FromArgb(loadlines(244))
        windowbordercolour = Color.FromArgb(loadlines(245))
        windowbordersize = loadlines(246)
        titlebarheight = loadlines(247)
        closebuttoncolour = Color.FromArgb(loadlines(248))
        closebuttonheight = loadlines(249)
        closebuttonwidth = loadlines(250)
        closebuttonside = loadlines(251)
        closebuttontop = loadlines(252)
        titletextcolour = Color.FromArgb(loadlines(253))
        titletexttop = loadlines(254)
        titletextside = loadlines(255)
        titletextsize = loadlines(256)
        titletextfont = loadlines(257)
        titletextstyle = loadlines(258)
        desktoppanelcolour = Color.FromArgb(loadlines(259))
        desktopbackgroundcolour = Color.FromArgb(loadlines(260))
        desktoppanelheight = loadlines(261)
        desktoppanelposition = loadlines(262)
        clocktextcolour = Color.FromArgb(loadlines(263))
        clockbackgroundcolor = Color.FromArgb(loadlines(264))
        panelclocktexttop = loadlines(265)
        panelclocktextsize = loadlines(266)
        panelclocktextfont = loadlines(267)
        panelclocktextstyle = loadlines(268)
        applauncherbuttoncolour = Color.FromArgb(loadlines(269))
        applauncherbuttonclickedcolour = Color.FromArgb(loadlines(270))
        applauncherbackgroundcolour = Color.FromArgb(loadlines(271))
        applaunchermouseovercolour = Color.FromArgb(loadlines(272))
        applicationsbuttontextcolour = Color.FromArgb(loadlines(273))
        applicationbuttonheight = loadlines(274)
        applicationbuttontextsize = loadlines(275)
        applicationbuttontextfont = loadlines(276)
        applicationbuttontextstyle = loadlines(277)
        applicationlaunchername = loadlines(278)
        titletextposition = loadlines(279)
        rollupbuttoncolour = Color.FromArgb(loadlines(280))
        rollupbuttonheight = loadlines(281)
        rollupbuttonwidth = loadlines(282)
        rollupbuttonside = loadlines(283)
        rollupbuttontop = loadlines(284)
        If loadlines(285) = 11 Then boughtpong = True Else boughtpong = False
        If loadlines(286) = 11 Then boughtknowledgeinputicon = True Else boughtknowledgeinputicon = False
        If loadlines(287) = 11 Then boughtshiftericon = True Else boughtshiftericon = False
        If loadlines(288) = 11 Then boughtshiftoriumicon = True Else boughtshiftoriumicon = False
        If loadlines(289) = 11 Then boughtclockicon = True Else boughtclockicon = False
        If loadlines(290) = 11 Then boughtshutdownicon = True Else boughtshutdownicon = False
        If loadlines(291) = 11 Then boughtpongicon = True Else boughtpongicon = False
        If loadlines(292) = 11 Then boughtterminalicon = True Else boughtterminalicon = False
        If loadlines(293) = 11 Then boughtalpong = True Else boughtalpong = False
        If loadlines(294) = 11 Then boughtfileskimmer = True Else boughtfileskimmer = False
        If loadlines(295) = 11 Then boughtalfileskimmer = True Else boughtalfileskimmer = False
        If loadlines(296) = 11 Then boughttextpad = True Else boughttextpad = False
        If loadlines(297) = 11 Then boughtaltextpad = True Else boughtaltextpad = False
        If loadlines(298) = 11 Then boughtfileskimmericon = True Else boughtfileskimmericon = False
        If loadlines(299) = 11 Then boughttextpadicon = True Else boughttextpadicon = False
        If loadlines(300) = 11 Then boughttextpadnew = True Else boughttextpadnew = False
        If loadlines(301) = 11 Then boughttextpadsave = True Else boughttextpadsave = False
        If loadlines(302) = 11 Then boughttextpadopen = True Else boughttextpadopen = False
        If loadlines(303) = 11 Then boughtfileskimmernewfolder = True Else boughtfileskimmernewfolder = False
        If loadlines(304) = 11 Then boughtfileskimmerdelete = True Else boughtfileskimmerdelete = False
        If loadlines(305) = 11 Then boughtkielements = True Else boughtkielements = False
        If loadlines(306) = 11 Then boughtcolourpickericon = True Else boughtcolourpickericon = False
        If loadlines(307) = 11 Then boughtinfoboxicon = True Else boughtinfoboxicon = False
        artpadcolorpalletwidth = loadlines(308)
        artpadcolorpalletheight = loadlines(309)
        artpadcolorpalletsidegap = loadlines(310)
        artpadcolorpallettopgap = loadlines(311)
        artpadvisiblepallets = loadlines(312)
        artpadpixellimit = loadlines(313)
        If loadlines(314) = 11 Then boughtskinloader = True Else boughtskinloader = False
        If loadlines(315) = 11 Then boughtminimizebutton = True Else boughtminimizebutton = False
        If loadlines(316) = 11 Then boughtpanelbuttons = True Else boughtpanelbuttons = False
        If loadlines(317) = 11 Then boughtshiftpanelbuttons = True Else boughtshiftpanelbuttons = False
        If loadlines(318) = 11 Then boughtartpad = True Else boughtartpad = False
        If loadlines(319) = 11 Then boughtalartpad = True Else boughtalartpad = False
        If loadlines(320) = 11 Then boughtartpadicon = True Else boughtartpadicon = False
        If loadlines(321) = 11 Then boughtskinning = True Else boughtskinning = False
        If loadlines(322) = 11 Then boughtminimizecommand = True Else boughtminimizecommand = False
        If loadlines(323) = 11 Then boughtusefulpanelbuttons = True Else boughtusefulpanelbuttons = False
        If loadlines(324) = 11 Then boughtunitymode = True Else boughtunitymode = False
        If loadlines(325) = 11 Then boughtartpadpixellimit4 = True Else boughtartpadpixellimit4 = False
        If loadlines(326) = 11 Then boughtartpadpixellimit8 = True Else boughtartpadpixellimit8 = False
        If loadlines(327) = 11 Then boughtartpadpixellimit16 = True Else boughtartpadpixellimit16 = False
        If loadlines(328) = 11 Then boughtartpadpixellimit64 = True Else boughtartpadpixellimit64 = False
        If loadlines(329) = 11 Then boughtartpadpixellimit256 = True Else boughtartpadpixellimit256 = False
        If loadlines(330) = 11 Then boughtartpadpixellimit1024 = True Else boughtartpadpixellimit1024 = False
        If loadlines(331) = 11 Then boughtartpadpixellimit4096 = True Else boughtartpadpixellimit4096 = False
        If loadlines(332) = 11 Then boughtartpadpixellimit16384 = True Else boughtartpadpixellimit16384 = False
        If loadlines(333) = 11 Then boughtartpadpixellimit65536 = True Else boughtartpadpixellimit65536 = False
        If loadlines(334) = 11 Then boughtartpadlimitlesspixels = True Else boughtartpadlimitlesspixels = False
        If loadlines(335) = 11 Then boughtartpad4colorpallets = True Else boughtartpad4colorpallets = False
        If loadlines(336) = 11 Then boughtartpad8colorpallets = True Else boughtartpad8colorpallets = False
        If loadlines(337) = 11 Then boughtartpad16colorpallets = True Else boughtartpad16colorpallets = False
        If loadlines(338) = 11 Then boughtartpad32colorpallets = True Else boughtartpad32colorpallets = False
        If loadlines(339) = 11 Then boughtartpad64colorpallets = True Else boughtartpad64colorpallets = False
        If loadlines(340) = 11 Then boughtartpad128colorpallets = True Else boughtartpad128colorpallets = False
        If loadlines(341) = 11 Then boughtartpadcustompallets = True Else boughtartpadcustompallets = False
        If loadlines(342) = 11 Then boughtartpadpixelplacer = True Else boughtartpadpixelplacer = False
        If loadlines(343) = 11 Then boughtartpadpixelplacermovementmode = True Else boughtartpadpixelplacermovementmode = False
        If loadlines(344) = 11 Then boughtartpadpencil = True Else boughtartpadpencil = False
        If loadlines(345) = 11 Then boughtartpadpaintbrush = True Else boughtartpadpaintbrush = False
        If loadlines(346) = 11 Then boughtartpadlinetool = True Else boughtartpadlinetool = False
        If loadlines(347) = 11 Then boughtartpadovaltool = True Else boughtartpadovaltool = False
        If loadlines(348) = 11 Then boughtartpadrectangletool = True Else boughtartpadrectangletool = False
        If loadlines(349) = 11 Then boughtartpaderaser = True Else boughtartpaderaser = False
        If loadlines(350) = 11 Then boughtartpadfilltool = True Else boughtartpadfilltool = False
        If loadlines(351) = 11 Then boughtartpadtexttool = True Else boughtartpadtexttool = False
        If loadlines(352) = 11 Then boughtartpadundo = True Else boughtartpadundo = False
        If loadlines(353) = 11 Then boughtartpadredo = True Else boughtartpadredo = False
        If loadlines(354) = 11 Then boughtartpadsave = True Else boughtartpadsave = False
        If loadlines(355) = 11 Then boughtartpadload = True Else boughtartpadload = False
        For i = 0 To 127 : artpadcolourpallets(i) = Color.FromArgb(loadlines(356 + i)) : Next
        If loadlines(484) = "" Then  Else If loadlines(484) = 11 Then boughtartpadnew = True Else boughtartpadnew = False

        If IO.File.Exists("C:\ShiftOS\Shiftum42\Skins\Current\skindata.dat") Then loadcurrentskin()
        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Icons") Then setupicons()
    End Sub

    Private Sub ShiftOSDesktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If newgame = True Then
            savegame()
        Else
            loadgame()
        End If
        ToolStripManager.Renderer = New MyToolStripRenderer()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        loadskinfiles()
        setupdesktop()
        setupskins()
    End Sub

    Public Sub loadcurrentskin()
        skinlines = IO.File.ReadAllLines("C:\ShiftOS\Shiftum42\Skins\Current\skindata.dat")
        titlebarcolour = Color.FromArgb(skinlines(0))
        windowbordercolour = Color.FromArgb(skinlines(1))
        windowbordersize = skinlines(2)
        titlebarheight = skinlines(3)
        closebuttoncolour = Color.FromArgb(skinlines(4))
        closebuttonheight = skinlines(5)
        closebuttonwidth = skinlines(6)
        closebuttonside = skinlines(7)
        closebuttontop = skinlines(8)
        titletextcolour = Color.FromArgb(skinlines(9))
        titletexttop = skinlines(10)
        titletextside = skinlines(11)
        titletextsize = skinlines(12)
        titletextfont = skinlines(13)
        titletextstyle = skinlines(14)
        desktoppanelcolour = Color.FromArgb(skinlines(15))
        desktopbackgroundcolour = Color.FromArgb(skinlines(16))
        desktoppanelheight = skinlines(17)
        desktoppanelposition = skinlines(18)
        clocktextcolour = Color.FromArgb(skinlines(19))
        clockbackgroundcolor = Color.FromArgb(skinlines(20))
        panelclocktexttop = skinlines(21)
        panelclocktextsize = skinlines(22)
        panelclocktextfont = skinlines(23)
        panelclocktextstyle = skinlines(24)
        applauncherbuttoncolour = Color.FromArgb(skinlines(25))
        applauncherbuttonclickedcolour = Color.FromArgb(skinlines(26))
        applauncherbackgroundcolour = Color.FromArgb(skinlines(27))
        applaunchermouseovercolour = Color.FromArgb(skinlines(28))
        applicationsbuttontextcolour = Color.FromArgb(skinlines(29))
        applicationbuttonheight = skinlines(30)
        applicationbuttontextsize = skinlines(31)
        applicationbuttontextfont = skinlines(32)
        applicationbuttontextstyle = skinlines(33)
        applicationlaunchername = skinlines(34)
        titletextposition = skinlines(35)
        rollupbuttoncolour = Color.FromArgb(skinlines(36))
        If skinlines(37) = "" Then  Else rollupbuttonheight = skinlines(37)
        If skinlines(38) = "" Then  Else rollupbuttonwidth = skinlines(38)
        If skinlines(39) = "" Then  Else rollupbuttonside = skinlines(39)
        If skinlines(40) = "" Then  Else rollupbuttontop = skinlines(40)
        If skinlines(41) = "" Then  Else titlebariconside = skinlines(41)
        If skinlines(42) = "" Then  Else titlebaricontop = skinlines(42)
        If skinlines(43) = "" Then  Else showwindowcorners = skinlines(43)
        If skinlines(44) = "" Then  Else titlebarcornerwidth = skinlines(44)
        If skinlines(45) = "" Then  Else titlebarrightcornercolour = Color.FromArgb(skinlines(45))
        If skinlines(46) = "" Then  Else titlebarleftcornercolour = Color.FromArgb(skinlines(46))
        If skinlines(47) = "" Then  Else applaunchermenuholderwidth = skinlines(47)
        If skinlines(48) = "" Then  Else windowborderleftcolour = Color.FromArgb(skinlines(48))
        If skinlines(49) = "" Then  Else windowborderrightcolour = Color.FromArgb(skinlines(49))
        If skinlines(50) = "" Then  Else windowborderbottomcolour = Color.FromArgb(skinlines(50))
        If skinlines(51) = "" Then  Else windowborderbottomrightcolour = Color.FromArgb(skinlines(51))
        If skinlines(52) = "" Then  Else windowborderbottomleftcolour = Color.FromArgb(skinlines(52))
        If skinlines(53) = "" Then  Else panelbuttonicontop = skinlines(53)
        If skinlines(54) = "" Then  Else panelbuttoniconside = skinlines(54)
        If skinlines(55) = "" Then  Else panelbuttoniconsize = skinlines(55)
        If skinlines(56) = "" Then  Else panelbuttoniconsize = skinlines(56)
        If skinlines(57) = "" Then  Else panelbuttonheight = skinlines(57)
        If skinlines(58) = "" Then  Else panelbuttonwidth = skinlines(58)
        If skinlines(59) = "" Then  Else panelbuttoncolour = Color.FromArgb(skinlines(59))
        If skinlines(60) = "" Then  Else panelbuttontextcolour = Color.FromArgb(skinlines(60))
        If skinlines(61) = "" Then  Else panelbuttontextsize = skinlines(61)
        If skinlines(62) = "" Then  Else panelbuttontextfont = skinlines(62)
        If skinlines(63) = "" Then  Else panelbuttontextstyle = skinlines(63)
        If skinlines(64) = "" Then  Else panelbuttontextside = skinlines(64)
        If skinlines(65) = "" Then  Else panelbuttontexttop = skinlines(65)
        If skinlines(66) = "" Then  Else panelbuttongap = skinlines(66)
        If skinlines(67) = "" Then  Else panelbuttonfromtop = skinlines(67)
        If skinlines(68) = "" Then  Else panelbuttoninitialgap = skinlines(68)
        If skinlines(69) = "" Then  Else minimizebuttoncolour = Color.FromArgb(skinlines(69))
        If skinlines(70) = "" Then  Else minimizebuttonheight = skinlines(70)
        If skinlines(71) = "" Then  Else minimizebuttonwidth = skinlines(71)
        If skinlines(72) = "" Then  Else minimizebuttonside = skinlines(72)
        If skinlines(73) = "" Then  Else minimizebuttontop = skinlines(73)

        skinimages(0) = skinlines(100)
        skinimages(1) = skinlines(101)
        skinimages(2) = skinlines(102)
        skinimages(3) = skinlines(103)
        skinimages(4) = skinlines(104)
        skinimages(5) = skinlines(105)
        skinimages(6) = skinlines(106)
        skinimages(7) = skinlines(107)
        skinimages(8) = skinlines(108)
        skinimages(9) = skinlines(109)
        skinimages(10) = skinlines(110)
        skinimages(11) = skinlines(111)
        skinimages(12) = skinlines(112)
        skinimages(13) = skinlines(113)
        skinimages(14) = skinlines(114)
        skinimages(15) = skinlines(115)
        skinimages(16) = skinlines(116)
        skinimages(17) = skinlines(117)
        skinimages(18) = skinlines(118)
        skinimages(19) = skinlines(119)
        skinimages(20) = skinlines(120)
        skinimages(21) = skinlines(121)
        skinimages(22) = skinlines(122)
        skinimages(23) = skinlines(123)
        skinimages(24) = skinlines(124)
        skinimages(25) = skinlines(125)
        skinimages(26) = skinlines(126)
        skinimages(27) = skinlines(127)
        skinimages(28) = skinlines(128)
        skinimages(29) = skinlines(129)
        skinimages(30) = skinlines(130)
        skinimages(31) = skinlines(131)
        skinimages(32) = skinlines(132)
        skinimages(33) = skinlines(133)
        skinimages(34) = skinlines(134)
        skinimages(35) = skinlines(135)
        skinimages(36) = skinlines(136)
        skinimages(37) = skinlines(137)
        skinimages(38) = skinlines(138)
        skinimages(39) = skinlines(139)
        skinimages(40) = skinlines(140)
        skinimages(41) = skinlines(141)
        skinimages(42) = skinlines(142)
        skinimages(43) = skinlines(143)
        skinimages(44) = skinlines(144)
        skinimages(45) = skinlines(145)
        skinimages(46) = skinlines(146)
        skinimages(47) = skinlines(147)
        skinimages(48) = skinlines(148)
        skinimages(49) = skinlines(149)
        skinimages(50) = skinlines(150)
    End Sub


    Public Sub disposeoldskindata(ByVal fromwhere As String)

        'mostly disabled due to issues with disposing causing red X's

        Select Case fromwhere
            Case "skinloaderapplyskin"
                shortdisposecode(Skin_Loader.skinloaderskinclosebutton, Me.skinclosebutton, Shifter.skinclosebutton, True)
                shortdisposecode(Skin_Loader.skinloaderskintitlebar, Me.skintitlebar, Shifter.shifterskintitlebar, True)
                shortdisposecode(Skin_Loader.skinloaderskindesktopbackground, Me.skindesktopbackground, Shifter.skindesktopbackground, True)
                shortdisposecode(Skin_Loader.skinloaderskinrollupbutton, Me.skinrollupbutton, Shifter.skinrollupbutton, True)
                shortdisposecode(Skin_Loader.skinloaderskintitlebarrightcorner, Me.skintitlebarrightcorner, Shifter.skintitlebarrightcorner, True)
                shortdisposecode(Skin_Loader.skinloaderskintitlebarleftcorner, Me.skintitlebarleftcorner, Shifter.skintitlebarleftcorner, True)
                shortdisposecode(Skin_Loader.skinloaderskindesktoppanel, Me.skindesktoppanel, Shifter.skindesktoppanel, True)
                shortdisposecode(Skin_Loader.skinloaderskindesktoppaneltime, Me.skindesktoppaneltime, Shifter.skindesktoppaneltime, True)
                shortdisposecode(Skin_Loader.skinloaderskinapplauncherbutton, Me.skinapplauncherbutton, Shifter.skinapplauncherbutton, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderleft, Me.skinwindowborderleft, Shifter.skinwindowborderleft, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderright, Me.skinwindowborderright, Shifter.skinwindowborderright, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottom, Me.skinwindowborderbottom, Shifter.skinwindowborderbottom, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottomright, Me.skinwindowborderbottomright, Shifter.skinwindowborderbottomright, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottomleft, Me.skinwindowborderbottomleft, Shifter.skinwindowborderbottomleft, True)
                shortdisposecode(Skin_Loader.skinloaderskinpanelbutton, Me.skinpanelbutton, Shifter.skinpanelbutton, True)
                shortdisposecode(Skin_Loader.skinloaderskinminimizebutton, Me.skinminimizebutton, Shifter.skinminimizebutton, True)

                'If Me.BackgroundImage Is Nothing Then  Else Me.BackgroundImage.Dispose()
                'If Me.ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then  Else Me.ApplicationsToolStripMenuItem.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonholder.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonholder.BackgroundImage.Dispose()
                'If Me.desktoppanel.BackgroundImage Is Nothing Then  Else Me.desktoppanel.BackgroundImage.Dispose()
                'If Me.timepanel.BackgroundImage Is Nothing Then  Else Me.timepanel.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonclock.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonclock.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonskinloader.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonskinloader.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonfileskimmer.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonfileskimmer.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonfileopener.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonfileopener.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoninfobox.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoninfobox.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonknowledgeinput.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonknowledgeinput.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoncolourpicker.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoncolourpicker.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonshiftorium.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonshiftorium.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonfilesaver.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonfilesaver.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonshifter.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonshifter.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonpong.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonpong.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonterminal.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonterminal.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttontextpad.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttontextpad.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttongraphicpicker.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttongraphicpicker.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonartpad.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonartpad.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoncalculator.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoncalculator.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonaudioplayer.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonaudioplayer.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonwebbrowser.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonwebbrowser.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonvideoplayer.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonvideoplayer.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonnamechanger.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonnamechanger.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoniconmanager.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoniconmanager.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonbitnotewallet.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonbitnotewallet.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonbitnotedigger.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonbitnotedigger.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonskinshifter.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonskinshifter.BackgroundImage.Dispose()
                'If Me.tbclockicon.BackgroundImage Is Nothing Then  Else Me.tbclockicon.BackgroundImage.Dispose()
                'If Me.tbskinloadericon.BackgroundImage Is Nothing Then  Else Me.tbskinloadericon.BackgroundImage.Dispose()
                'If Me.tbfileskimmericon.BackgroundImage Is Nothing Then  Else Me.tbfileskimmericon.BackgroundImage.Dispose()
                'If Me.tbfileopenericon.BackgroundImage Is Nothing Then  Else Me.tbfileopenericon.BackgroundImage.Dispose()
                'If Me.tbinfoboxicon.BackgroundImage Is Nothing Then  Else Me.tbinfoboxicon.BackgroundImage.Dispose()
                'If Me.tbknowledgeinputicon.BackgroundImage Is Nothing Then  Else Me.tbknowledgeinputicon.BackgroundImage.Dispose()
                'If Me.tbcolourpickericon.BackgroundImage Is Nothing Then  Else Me.tbcolourpickericon.BackgroundImage.Dispose()
                'If Me.tbshiftoriumicon.BackgroundImage Is Nothing Then  Else Me.tbshiftoriumicon.BackgroundImage.Dispose()
                'If Me.tbfilesavericon.BackgroundImage Is Nothing Then  Else Me.tbfilesavericon.BackgroundImage.Dispose()
                'If Me.tbshiftericon.BackgroundImage Is Nothing Then  Else Me.tbshiftericon.BackgroundImage.Dispose()
                'If Me.tbpongicon.BackgroundImage Is Nothing Then  Else Me.tbpongicon.BackgroundImage.Dispose()
                'If Me.tbterminalicon.BackgroundImage Is Nothing Then  Else Me.tbterminalicon.BackgroundImage.Dispose()
                'If Me.tbtextpadicon.BackgroundImage Is Nothing Then  Else Me.tbtextpadicon.BackgroundImage.Dispose()
                'If Me.tbgraphicpickericon.BackgroundImage Is Nothing Then  Else Me.tbgraphicpickericon.BackgroundImage.Dispose()
                'If Me.tbartpadicon.BackgroundImage Is Nothing Then  Else Me.tbartpadicon.BackgroundImage.Dispose()
                'If Me.tbcalculatoricon.BackgroundImage Is Nothing Then  Else Me.tbcalculatoricon.BackgroundImage.Dispose()
                'If Me.tbaudioplayericon.BackgroundImage Is Nothing Then  Else Me.tbaudioplayericon.BackgroundImage.Dispose()
                'If Me.tbwebbrowsericon.BackgroundImage Is Nothing Then  Else Me.tbwebbrowsericon.BackgroundImage.Dispose()
                'If Me.tbvideoplayericon.BackgroundImage Is Nothing Then  Else Me.tbvideoplayericon.BackgroundImage.Dispose()
                'If Me.tbnamechangericon.BackgroundImage Is Nothing Then  Else Me.tbnamechangericon.BackgroundImage.Dispose()
                'If Me.tbiconmanagericon.BackgroundImage Is Nothing Then  Else Me.tbiconmanagericon.BackgroundImage.Dispose()
                'If Me.tbbitnotewalleticon.BackgroundImage Is Nothing Then  Else Me.tbbitnotewalleticon.BackgroundImage.Dispose()
                'If Me.tbbitnotediggericon.BackgroundImage Is Nothing Then  Else Me.tbbitnotediggericon.BackgroundImage.Dispose()
                'If Me.tbskinshiftericon.BackgroundImage Is Nothing Then  Else Me.tbskinshiftericon.BackgroundImage.Dispose()

                Me.BackgroundImage = Nothing
                Me.ApplicationsToolStripMenuItem.BackgroundImage = Nothing
                Me.pnlpanelbuttonholder.BackgroundImage = Nothing
                Me.desktoppanel.BackgroundImage = Nothing
                Me.timepanel.BackgroundImage = Nothing
                Me.pnlpanelbuttonclock.BackgroundImage = Nothing
                Me.pnlpanelbuttonskinloader.BackgroundImage = Nothing
                Me.pnlpanelbuttonfileskimmer.BackgroundImage = Nothing
                Me.pnlpanelbuttonfileopener.BackgroundImage = Nothing
                Me.pnlpanelbuttoninfobox.BackgroundImage = Nothing
                Me.pnlpanelbuttonknowledgeinput.BackgroundImage = Nothing
                Me.pnlpanelbuttoncolourpicker.BackgroundImage = Nothing
                Me.pnlpanelbuttonshiftorium.BackgroundImage = Nothing
                Me.pnlpanelbuttonfilesaver.BackgroundImage = Nothing
                Me.pnlpanelbuttonshifter.BackgroundImage = Nothing
                Me.pnlpanelbuttonpong.BackgroundImage = Nothing
                Me.pnlpanelbuttonterminal.BackgroundImage = Nothing
                Me.pnlpanelbuttontextpad.BackgroundImage = Nothing
                Me.pnlpanelbuttongraphicpicker.BackgroundImage = Nothing
                Me.pnlpanelbuttonartpad.BackgroundImage = Nothing
                Me.pnlpanelbuttoncalculator.BackgroundImage = Nothing
                Me.pnlpanelbuttonaudioplayer.BackgroundImage = Nothing
                Me.pnlpanelbuttonwebbrowser.BackgroundImage = Nothing
                Me.pnlpanelbuttonvideoplayer.BackgroundImage = Nothing
                Me.pnlpanelbuttonnamechanger.BackgroundImage = Nothing
                Me.pnlpanelbuttoniconmanager.BackgroundImage = Nothing
                Me.pnlpanelbuttonbitnotewallet.BackgroundImage = Nothing
                Me.pnlpanelbuttonbitnotedigger.BackgroundImage = Nothing
                Me.pnlpanelbuttonskinshifter.BackgroundImage = Nothing
                Me.pnlpanelbuttonshiftnet.BackgroundImage = Nothing
                Me.pnlpanelbuttondownloader.BackgroundImage = Nothing
                Me.tbclockicon.BackgroundImage = Nothing
                Me.tbskinloadericon.BackgroundImage = Nothing
                Me.tbfileskimmericon.BackgroundImage = Nothing
                Me.tbfileopenericon.BackgroundImage = Nothing
                Me.tbinfoboxicon.BackgroundImage = Nothing
                Me.tbknowledgeinputicon.BackgroundImage = Nothing
                Me.tbcolourpickericon.BackgroundImage = Nothing
                Me.tbshiftoriumicon.BackgroundImage = Nothing
                Me.tbfilesavericon.BackgroundImage = Nothing
                Me.tbshiftericon.BackgroundImage = Nothing
                Me.tbpongicon.BackgroundImage = Nothing
                Me.tbterminalicon.BackgroundImage = Nothing
                Me.tbtextpadicon.BackgroundImage = Nothing
                Me.tbgraphicpickericon.BackgroundImage = Nothing
                Me.tbartpadicon.BackgroundImage = Nothing
                Me.tbcalculatoricon.BackgroundImage = Nothing
                Me.tbaudioplayericon.BackgroundImage = Nothing
                Me.tbwebbrowsericon.BackgroundImage = Nothing
                Me.tbvideoplayericon.BackgroundImage = Nothing
                Me.tbnamechangericon.BackgroundImage = Nothing
                Me.tbiconmanagericon.BackgroundImage = Nothing
                Me.tbbitnotewalleticon.BackgroundImage = Nothing
                Me.tbbitnotediggericon.BackgroundImage = Nothing
                Me.tbskinshiftericon.BackgroundImage = Nothing
                Me.tbshiftneticon.BackgroundImage = Nothing
                Me.tbdownloadericon.BackgroundImage = Nothing

                'For i = 0 To 50
                '    skinimages(i) = ""
                'Next

                'If Skin_Loader.pgleft.BackgroundImage Is Nothing Then  Else Skin_Loader.pgleft.BackgroundImage.Dispose()
                'If Skin_Loader.pgright.BackgroundImage Is Nothing Then  Else Skin_Loader.pgright.BackgroundImage.Dispose()
                'If Skin_Loader.pgbottom.BackgroundImage Is Nothing Then  Else Skin_Loader.pgbottom.BackgroundImage.Dispose()
                'If Skin_Loader.pgbottomlcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.pgbottomlcorner.BackgroundImage.Dispose()
                'If Skin_Loader.pgbottomrcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.pgbottomrcorner.BackgroundImage.Dispose()

                'If Clock.Visible = True Then
                '    If Clock.titlebar.BackgroundImage Is Nothing Then  Else Clock.titlebar.BackgroundImage.Dispose()
                '    Clock.titlebar.BackgroundImage = Nothing
                'End If

                Skin_Loader.pgleft.BackgroundImage = Nothing
                Skin_Loader.pgright.BackgroundImage = Nothing
                Skin_Loader.pgbottom.BackgroundImage = Nothing
                Skin_Loader.pgbottomlcorner.BackgroundImage = Nothing
                Skin_Loader.pgbottomrcorner.BackgroundImage = Nothing

                GC.Collect()

                While My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Current\")
                    Try
                        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Current\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\Current\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Catch ex As Exception
                    End Try
                End While

                My.Computer.FileSystem.CreateDirectory("C:\ShiftOS\Shiftum42\Skins\Current\")
                If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Preview\") Then My.Computer.FileSystem.CopyDirectory("C:\ShiftOS\Shiftum42\Skins\Preview\", "C:\ShiftOS\Shiftum42\Skins\Current\")
                My.Computer.FileSystem.WriteAllText("C:\ShiftOS\Shiftum42\Skins\Current\skindata.dat", My.Computer.FileSystem.ReadAllText("C:\ShiftOS\Shiftum42\Skins\Current\skindata.dat").Replace("\Preview", "\Current"), False)

            Case "shifterapply"
                shortdisposecode(Skin_Loader.skinloaderskinclosebutton, Me.skinclosebutton, Shifter.skinclosebutton, True)
                shortdisposecode(Skin_Loader.skinloaderskintitlebar, Me.skintitlebar, Shifter.shifterskintitlebar, True)
                shortdisposecode(Skin_Loader.skinloaderskindesktopbackground, Me.skindesktopbackground, Shifter.skindesktopbackground, True)
                shortdisposecode(Skin_Loader.skinloaderskinrollupbutton, Me.skinrollupbutton, Shifter.skinrollupbutton, True)
                shortdisposecode(Skin_Loader.skinloaderskintitlebarrightcorner, Me.skintitlebarrightcorner, Shifter.skintitlebarrightcorner, True)
                shortdisposecode(Skin_Loader.skinloaderskintitlebarleftcorner, Me.skintitlebarleftcorner, Shifter.skintitlebarleftcorner, True)
                shortdisposecode(Skin_Loader.skinloaderskindesktoppanel, Me.skindesktoppanel, Shifter.skindesktoppanel, True)
                shortdisposecode(Skin_Loader.skinloaderskindesktoppaneltime, Me.skindesktoppaneltime, Shifter.skindesktoppaneltime, True)
                shortdisposecode(Skin_Loader.skinloaderskinapplauncherbutton, Me.skinapplauncherbutton, Shifter.skinapplauncherbutton, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderleft, Me.skinwindowborderleft, Shifter.skinwindowborderleft, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderright, Me.skinwindowborderright, Shifter.skinwindowborderright, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottom, Me.skinwindowborderbottom, Shifter.skinwindowborderbottom, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottomright, Me.skinwindowborderbottomright, Shifter.skinwindowborderbottomright, True)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottomleft, Me.skinwindowborderbottomleft, Shifter.skinwindowborderbottomleft, True)
                shortdisposecode(Skin_Loader.skinloaderskinpanelbutton, Me.skinpanelbutton, Shifter.skinpanelbutton, True)
                shortdisposecode(Skin_Loader.skinloaderskinminimizebutton, Me.skinminimizebutton, Shifter.skinminimizebutton, True)

                'If Skin_Loader.Visible Then
                '    If Skin_Loader.preclosebutton.BackgroundImage Is Nothing Then  Else Skin_Loader.preclosebutton.BackgroundImage.Dispose()
                '    If Skin_Loader.pretitlebar.BackgroundImage Is Nothing Then  Else Skin_Loader.pretitlebar.BackgroundImage.Dispose()
                '    If Skin_Loader.pnldesktoppreview.BackgroundImage Is Nothing Then  Else Skin_Loader.pnldesktoppreview.BackgroundImage.Dispose()
                '    If Skin_Loader.prerollupbutton.BackgroundImage Is Nothing Then  Else Skin_Loader.prerollupbutton.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgtoprcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgtoprcorner.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgtoplcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgtoplcorner.BackgroundImage.Dispose()
                '    If Skin_Loader.predesktoppanel.BackgroundImage Is Nothing Then  Else Skin_Loader.predesktoppanel.BackgroundImage.Dispose()
                '    If Skin_Loader.prepnlpanelbuttonholder.BackgroundImage Is Nothing Then  Else Skin_Loader.prepnlpanelbuttonholder.BackgroundImage.Dispose()
                '    If Skin_Loader.pretimepanel.BackgroundImage Is Nothing Then  Else Skin_Loader.pretimepanel.BackgroundImage.Dispose()
                '    If Skin_Loader.ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then  Else Skin_Loader.ApplicationsToolStripMenuItem.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgleft.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgleft.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgright.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgright.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgbottom.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgbottom.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgbottomrcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgbottomrcorner.BackgroundImage.Dispose()
                '    If Skin_Loader.prepgbottomlcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgbottomlcorner.BackgroundImage.Dispose()
                '    If Skin_Loader.prepnlpanelbutton.BackgroundImage Is Nothing Then  Else Skin_Loader.prepnlpanelbutton.BackgroundImage.Dispose()
                '    If Skin_Loader.preminimizebutton.BackgroundImage Is Nothing Then  Else Skin_Loader.preminimizebutton.BackgroundImage.Dispose()

                Skin_Loader.preclosebutton.BackgroundImage = Nothing
                Skin_Loader.pretitlebar.BackgroundImage = Nothing
                Skin_Loader.pnldesktoppreview.BackgroundImage = Nothing
                Skin_Loader.prerollupbutton.BackgroundImage = Nothing
                Skin_Loader.prepgtoprcorner.BackgroundImage = Nothing
                Skin_Loader.prepgtoplcorner.BackgroundImage = Nothing
                Skin_Loader.predesktoppanel.BackgroundImage = Nothing
                Skin_Loader.prepnlpanelbuttonholder.BackgroundImage = Nothing
                Skin_Loader.pretimepanel.BackgroundImage = Nothing
                Skin_Loader.ApplicationsToolStripMenuItem.BackgroundImage = Nothing
                Skin_Loader.prepgleft.BackgroundImage = Nothing
                Skin_Loader.prepgright.BackgroundImage = Nothing
                Skin_Loader.prepgbottom.BackgroundImage = Nothing
                Skin_Loader.prepgbottomrcorner.BackgroundImage = Nothing
                Skin_Loader.prepgbottomlcorner.BackgroundImage = Nothing
                Skin_Loader.prepnlpanelbutton.BackgroundImage = Nothing
                Skin_Loader.preminimizebutton.BackgroundImage = Nothing
                'End If

                'If Shifter.preclosebutton.BackgroundImage Is Nothing Then  Else Shifter.preclosebutton.BackgroundImage.Dispose()
                'If Shifter.pretitlebar.BackgroundImage Is Nothing Then  Else Shifter.pretitlebar.BackgroundImage.Dispose()
                'If Shifter.pnldesktoppreview.BackgroundImage Is Nothing Then  Else Shifter.pnldesktoppreview.BackgroundImage.Dispose()
                'If Shifter.prerollupbutton.BackgroundImage Is Nothing Then  Else Shifter.prerollupbutton.BackgroundImage.Dispose()
                'If Shifter.prepgtoprcorner.BackgroundImage Is Nothing Then  Else Shifter.prepgtoprcorner.BackgroundImage.Dispose()
                'If Shifter.prepgtoplcorner.BackgroundImage Is Nothing Then  Else Shifter.prepgtoplcorner.BackgroundImage.Dispose()
                'If Shifter.predesktoppanel.BackgroundImage Is Nothing Then  Else Shifter.predesktoppanel.BackgroundImage.Dispose()
                'If Shifter.prepnlpanelbuttonholder.BackgroundImage Is Nothing Then  Else Shifter.prepnlpanelbuttonholder.BackgroundImage.Dispose()
                'If Shifter.pretimepanel.BackgroundImage Is Nothing Then  Else Shifter.pretimepanel.BackgroundImage.Dispose()
                'If Shifter.ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then  Else Shifter.ApplicationsToolStripMenuItem.BackgroundImage.Dispose()
                'If Shifter.prepgleft.BackgroundImage Is Nothing Then  Else Shifter.prepgleft.BackgroundImage.Dispose()
                'If Shifter.prepgright.BackgroundImage Is Nothing Then  Else Shifter.prepgright.BackgroundImage.Dispose()
                'If Shifter.prepgbottom.BackgroundImage Is Nothing Then  Else Shifter.prepgbottom.BackgroundImage.Dispose()
                'If Shifter.prepgbottomrcorner.BackgroundImage Is Nothing Then  Else Shifter.prepgbottomrcorner.BackgroundImage.Dispose()
                'If Shifter.prepgbottomlcorner.BackgroundImage Is Nothing Then  Else Shifter.prepgbottomlcorner.BackgroundImage.Dispose()
                'If Shifter.prepnlpanelbutton.BackgroundImage Is Nothing Then  Else Shifter.prepnlpanelbutton.BackgroundImage.Dispose()
                'If Shifter.preminimizebutton.BackgroundImage Is Nothing Then  Else Shifter.preminimizebutton.BackgroundImage.Dispose()

                Shifter.preclosebutton.BackgroundImage = Nothing
                Shifter.pretitlebar.BackgroundImage = Nothing
                Shifter.pnldesktoppreview.BackgroundImage = Nothing
                Shifter.prerollupbutton.BackgroundImage = Nothing
                Shifter.prepgtoprcorner.BackgroundImage = Nothing
                Shifter.prepgtoplcorner.BackgroundImage = Nothing
                Shifter.predesktoppanel.BackgroundImage = Nothing
                Shifter.prepnlpanelbuttonholder.BackgroundImage = Nothing
                Shifter.pretimepanel.BackgroundImage = Nothing
                Shifter.ApplicationsToolStripMenuItem.BackgroundImage = Nothing
                Shifter.prepgleft.BackgroundImage = Nothing
                Shifter.prepgright.BackgroundImage = Nothing
                Shifter.prepgbottom.BackgroundImage = Nothing
                Shifter.prepgbottomrcorner.BackgroundImage = Nothing
                Shifter.prepgbottomlcorner.BackgroundImage = Nothing
                Shifter.prepnlpanelbutton.BackgroundImage = Nothing
                Shifter.preminimizebutton.BackgroundImage = Nothing

                ''prevent shifter red x images appearing
                If Shifter.titlebar.BackgroundImage Is Nothing Then  Else Shifter.titlebar.BackgroundImage.Dispose() : Shifter.titlebar.BackgroundImage = Nothing
                If Shifter.pgtoplcorner.BackgroundImage Is Nothing Then  Else Shifter.pgtoplcorner.BackgroundImage.Dispose() : Shifter.pgtoplcorner.BackgroundImage = Nothing
                If Shifter.pgtoprcorner.BackgroundImage Is Nothing Then  Else Shifter.pgtoprcorner.BackgroundImage.Dispose() : Shifter.pgtoprcorner.BackgroundImage = Nothing
                If Shifter.closebutton.BackgroundImage Is Nothing Then  Else Shifter.closebutton.BackgroundImage.Dispose() : Shifter.closebutton.BackgroundImage = Nothing
                If Shifter.minimizebutton.BackgroundImage Is Nothing Then  Else Shifter.minimizebutton.BackgroundImage.Dispose() : Shifter.minimizebutton.BackgroundImage = Nothing
                If Shifter.rollupbutton.BackgroundImage Is Nothing Then  Else Shifter.rollupbutton.BackgroundImage.Dispose() : Shifter.rollupbutton.BackgroundImage = Nothing

                'If Clock.Visible = True Then
                '    If Clock.titlebar.BackgroundImage Is Nothing Then  Else Clock.titlebar.BackgroundImage.Dispose()
                '    Clock.titlebar.BackgroundImage = Nothing
                'End If

                'If Me.BackgroundImage Is Nothing Then  Else Me.BackgroundImage.Dispose()
                'If Me.ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then  Else Me.ApplicationsToolStripMenuItem.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonholder.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonholder.BackgroundImage.Dispose()
                'If Me.desktoppanel.BackgroundImage Is Nothing Then  Else Me.desktoppanel.BackgroundImage.Dispose()
                'If Me.timepanel.BackgroundImage Is Nothing Then  Else Me.timepanel.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonclock.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonclock.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonskinloader.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonskinloader.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonfileskimmer.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonfileskimmer.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonfileopener.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonfileopener.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoninfobox.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoninfobox.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonknowledgeinput.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonknowledgeinput.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoncolourpicker.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoncolourpicker.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonshiftorium.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonshiftorium.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonfilesaver.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonfilesaver.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonshifter.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonshifter.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonpong.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonpong.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonterminal.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonterminal.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttontextpad.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttontextpad.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttongraphicpicker.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttongraphicpicker.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonartpad.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonartpad.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoncalculator.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoncalculator.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonaudioplayer.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonaudioplayer.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonwebbrowser.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonwebbrowser.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonvideoplayer.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonvideoplayer.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonnamechanger.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonnamechanger.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttoniconmanager.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttoniconmanager.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonbitnotewallet.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonbitnotewallet.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonbitnotedigger.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonbitnotedigger.BackgroundImage.Dispose()
                'If Me.pnlpanelbuttonskinshifter.BackgroundImage Is Nothing Then  Else Me.pnlpanelbuttonskinshifter.BackgroundImage.Dispose()
                'If Me.tbclockicon.BackgroundImage Is Nothing Then  Else Me.tbclockicon.BackgroundImage.Dispose()
                'If Me.tbskinloadericon.BackgroundImage Is Nothing Then  Else Me.tbskinloadericon.BackgroundImage.Dispose()
                'If Me.tbfileskimmericon.BackgroundImage Is Nothing Then  Else Me.tbfileskimmericon.BackgroundImage.Dispose()
                'If Me.tbfileopenericon.BackgroundImage Is Nothing Then  Else Me.tbfileopenericon.BackgroundImage.Dispose()
                'If Me.tbinfoboxicon.BackgroundImage Is Nothing Then  Else Me.tbinfoboxicon.BackgroundImage.Dispose()
                'If Me.tbknowledgeinputicon.BackgroundImage Is Nothing Then  Else Me.tbknowledgeinputicon.BackgroundImage.Dispose()
                'If Me.tbcolourpickericon.BackgroundImage Is Nothing Then  Else Me.tbcolourpickericon.BackgroundImage.Dispose()
                'If Me.tbshiftoriumicon.BackgroundImage Is Nothing Then  Else Me.tbshiftoriumicon.BackgroundImage.Dispose()
                'If Me.tbfilesavericon.BackgroundImage Is Nothing Then  Else Me.tbfilesavericon.BackgroundImage.Dispose()
                'If Me.tbshiftericon.BackgroundImage Is Nothing Then  Else Me.tbshiftericon.BackgroundImage.Dispose()
                'If Me.tbpongicon.BackgroundImage Is Nothing Then  Else Me.tbpongicon.BackgroundImage.Dispose()
                'If Me.tbterminalicon.BackgroundImage Is Nothing Then  Else Me.tbterminalicon.BackgroundImage.Dispose()
                'If Me.tbtextpadicon.BackgroundImage Is Nothing Then  Else Me.tbtextpadicon.BackgroundImage.Dispose()
                'If Me.tbgraphicpickericon.BackgroundImage Is Nothing Then  Else Me.tbgraphicpickericon.BackgroundImage.Dispose()
                'If Me.tbartpadicon.BackgroundImage Is Nothing Then  Else Me.tbartpadicon.BackgroundImage.Dispose()
                'If Me.tbcalculatoricon.BackgroundImage Is Nothing Then  Else Me.tbcalculatoricon.BackgroundImage.Dispose()
                'If Me.tbaudioplayericon.BackgroundImage Is Nothing Then  Else Me.tbaudioplayericon.BackgroundImage.Dispose()
                'If Me.tbwebbrowsericon.BackgroundImage Is Nothing Then  Else Me.tbwebbrowsericon.BackgroundImage.Dispose()
                'If Me.tbvideoplayericon.BackgroundImage Is Nothing Then  Else Me.tbvideoplayericon.BackgroundImage.Dispose()
                'If Me.tbnamechangericon.BackgroundImage Is Nothing Then  Else Me.tbnamechangericon.BackgroundImage.Dispose()
                'If Me.tbiconmanagericon.BackgroundImage Is Nothing Then  Else Me.tbiconmanagericon.BackgroundImage.Dispose()
                'If Me.tbbitnotewalleticon.BackgroundImage Is Nothing Then  Else Me.tbbitnotewalleticon.BackgroundImage.Dispose()
                'If Me.tbbitnotediggericon.BackgroundImage Is Nothing Then  Else Me.tbbitnotediggericon.BackgroundImage.Dispose()
                'If Me.tbskinshiftericon.BackgroundImage Is Nothing Then  Else Me.tbskinshiftericon.BackgroundImage.Dispose()

                Me.BackgroundImage = Nothing
                Me.ApplicationsToolStripMenuItem.BackgroundImage = Nothing
                Me.pnlpanelbuttonholder.BackgroundImage = Nothing
                Me.desktoppanel.BackgroundImage = Nothing
                Me.timepanel.BackgroundImage = Nothing
                Me.pnlpanelbuttonclock.BackgroundImage = Nothing
                Me.pnlpanelbuttonskinloader.BackgroundImage = Nothing
                Me.pnlpanelbuttonfileskimmer.BackgroundImage = Nothing
                Me.pnlpanelbuttonfileopener.BackgroundImage = Nothing
                Me.pnlpanelbuttoninfobox.BackgroundImage = Nothing
                Me.pnlpanelbuttonknowledgeinput.BackgroundImage = Nothing
                Me.pnlpanelbuttoncolourpicker.BackgroundImage = Nothing
                Me.pnlpanelbuttonshiftorium.BackgroundImage = Nothing
                Me.pnlpanelbuttonfilesaver.BackgroundImage = Nothing
                Me.pnlpanelbuttonshifter.BackgroundImage = Nothing
                Me.pnlpanelbuttonpong.BackgroundImage = Nothing
                Me.pnlpanelbuttonterminal.BackgroundImage = Nothing
                Me.pnlpanelbuttontextpad.BackgroundImage = Nothing
                Me.pnlpanelbuttongraphicpicker.BackgroundImage = Nothing
                Me.pnlpanelbuttonartpad.BackgroundImage = Nothing
                Me.pnlpanelbuttoncalculator.BackgroundImage = Nothing
                Me.pnlpanelbuttonaudioplayer.BackgroundImage = Nothing
                Me.pnlpanelbuttonwebbrowser.BackgroundImage = Nothing
                Me.pnlpanelbuttonvideoplayer.BackgroundImage = Nothing
                Me.pnlpanelbuttonnamechanger.BackgroundImage = Nothing
                Me.pnlpanelbuttoniconmanager.BackgroundImage = Nothing
                Me.pnlpanelbuttonbitnotewallet.BackgroundImage = Nothing
                Me.pnlpanelbuttonbitnotedigger.BackgroundImage = Nothing
                Me.pnlpanelbuttonskinshifter.BackgroundImage = Nothing
                Me.pnlpanelbuttonshiftnet.BackgroundImage = Nothing
                Me.pnlpanelbuttondownloader.BackgroundImage = Nothing
                Me.tbclockicon.BackgroundImage = Nothing
                Me.tbskinloadericon.BackgroundImage = Nothing
                Me.tbfileskimmericon.BackgroundImage = Nothing
                Me.tbfileopenericon.BackgroundImage = Nothing
                Me.tbinfoboxicon.BackgroundImage = Nothing
                Me.tbknowledgeinputicon.BackgroundImage = Nothing
                Me.tbcolourpickericon.BackgroundImage = Nothing
                Me.tbshiftoriumicon.BackgroundImage = Nothing
                Me.tbfilesavericon.BackgroundImage = Nothing
                Me.tbshiftericon.BackgroundImage = Nothing
                Me.tbpongicon.BackgroundImage = Nothing
                Me.tbterminalicon.BackgroundImage = Nothing
                Me.tbtextpadicon.BackgroundImage = Nothing
                Me.tbgraphicpickericon.BackgroundImage = Nothing
                Me.tbartpadicon.BackgroundImage = Nothing
                Me.tbcalculatoricon.BackgroundImage = Nothing
                Me.tbaudioplayericon.BackgroundImage = Nothing
                Me.tbwebbrowsericon.BackgroundImage = Nothing
                Me.tbvideoplayericon.BackgroundImage = Nothing
                Me.tbnamechangericon.BackgroundImage = Nothing
                Me.tbiconmanagericon.BackgroundImage = Nothing
                Me.tbbitnotewalleticon.BackgroundImage = Nothing
                Me.tbbitnotediggericon.BackgroundImage = Nothing
                Me.tbskinshiftericon.BackgroundImage = Nothing
                Me.tbshiftneticon.BackgroundImage = Nothing
                Me.tbdownloadericon.BackgroundImage = Nothing

                GC.Collect()

                While My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Current\")
                    Try
                        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Current\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\Current\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Catch ex As Exception
                    End Try
                End While
                My.Computer.FileSystem.CreateDirectory("C:\ShiftOS\Shiftum42\Skins\Current\")

            Case "skinloaderemovepreview"
                shortdisposecode(Skin_Loader.skinloaderskinclosebutton, Me.skinclosebutton, Shifter.skinclosebutton, False)
                shortdisposecode(Skin_Loader.skinloaderskintitlebar, Me.skintitlebar, Shifter.shifterskintitlebar, False)
                shortdisposecode(Skin_Loader.skinloaderskindesktopbackground, Me.skindesktopbackground, Shifter.skindesktopbackground, False)
                shortdisposecode(Skin_Loader.skinloaderskinrollupbutton, Me.skinrollupbutton, Shifter.skinrollupbutton, False)
                shortdisposecode(Skin_Loader.skinloaderskintitlebarrightcorner, Me.skintitlebarrightcorner, Shifter.skintitlebarrightcorner, False)
                shortdisposecode(Skin_Loader.skinloaderskintitlebarleftcorner, Me.skintitlebarleftcorner, Shifter.skintitlebarleftcorner, False)
                shortdisposecode(Skin_Loader.skinloaderskindesktoppanel, Me.skindesktoppanel, Shifter.skindesktoppanel, False)
                shortdisposecode(Skin_Loader.skinloaderskindesktoppaneltime, Me.skindesktoppaneltime, Shifter.skindesktoppaneltime, False)
                shortdisposecode(Skin_Loader.skinloaderskinapplauncherbutton, Me.skinapplauncherbutton, Shifter.skinapplauncherbutton, False)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderleft, Me.skinwindowborderleft, Shifter.skinwindowborderleft, False)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderright, Me.skinwindowborderright, Shifter.skinwindowborderright, False)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottom, Me.skinwindowborderbottom, Shifter.skinwindowborderbottom, False)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottomright, Me.skinwindowborderbottomright, Shifter.skinwindowborderbottomright, False)
                shortdisposecode(Skin_Loader.skinloaderskinwindowborderbottomleft, Me.skinwindowborderbottomleft, Shifter.skinwindowborderbottomleft, False)
                shortdisposecode(Skin_Loader.skinloaderskinpanelbutton, Me.skinpanelbutton, Shifter.skinpanelbutton, False)
                shortdisposecode(Skin_Loader.skinloaderskinminimizebutton, Me.skinminimizebutton, Shifter.skinminimizebutton, False)

                'If Skin_Loader.preclosebutton.BackgroundImage Is Nothing Then  Else Skin_Loader.preclosebutton.BackgroundImage.Dispose()
                'If Skin_Loader.pretitlebar.BackgroundImage Is Nothing Then  Else Skin_Loader.pretitlebar.BackgroundImage.Dispose()
                'If Skin_Loader.pnldesktoppreview.BackgroundImage Is Nothing Then  Else Skin_Loader.pnldesktoppreview.BackgroundImage.Dispose()
                'If Skin_Loader.prerollupbutton.BackgroundImage Is Nothing Then  Else Skin_Loader.prerollupbutton.BackgroundImage.Dispose()
                'If Skin_Loader.prepgtoprcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgtoprcorner.BackgroundImage.Dispose()
                'If Skin_Loader.prepgtoplcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgtoplcorner.BackgroundImage.Dispose()
                'If Skin_Loader.predesktoppanel.BackgroundImage Is Nothing Then  Else Skin_Loader.predesktoppanel.BackgroundImage.Dispose()
                'If Skin_Loader.prepnlpanelbuttonholder.BackgroundImage Is Nothing Then  Else Skin_Loader.prepnlpanelbuttonholder.BackgroundImage.Dispose()
                'If Skin_Loader.pretimepanel.BackgroundImage Is Nothing Then  Else Skin_Loader.pretimepanel.BackgroundImage.Dispose()
                'If Skin_Loader.ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then  Else Skin_Loader.ApplicationsToolStripMenuItem.BackgroundImage.Dispose()
                'If Skin_Loader.prepgleft.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgleft.BackgroundImage.Dispose()
                'If Skin_Loader.prepgright.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgright.BackgroundImage.Dispose()
                'If Skin_Loader.prepgbottom.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgbottom.BackgroundImage.Dispose()
                'If Skin_Loader.prepgbottomrcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgbottomrcorner.BackgroundImage.Dispose()
                'If Skin_Loader.prepgbottomlcorner.BackgroundImage Is Nothing Then  Else Skin_Loader.prepgbottomlcorner.BackgroundImage.Dispose()
                'If Skin_Loader.prepnlpanelbutton.BackgroundImage Is Nothing Then  Else Skin_Loader.prepnlpanelbutton.BackgroundImage.Dispose()
                'If Skin_Loader.preminimizebutton.BackgroundImage Is Nothing Then  Else Skin_Loader.preminimizebutton.BackgroundImage.Dispose()

                Skin_Loader.preclosebutton.BackgroundImage = Nothing
                Skin_Loader.pretitlebar.BackgroundImage = Nothing
                Skin_Loader.pnldesktoppreview.BackgroundImage = Nothing
                Skin_Loader.prerollupbutton.BackgroundImage = Nothing
                Skin_Loader.prepgtoprcorner.BackgroundImage = Nothing
                Skin_Loader.prepgtoplcorner.BackgroundImage = Nothing
                Skin_Loader.predesktoppanel.BackgroundImage = Nothing
                Skin_Loader.prepnlpanelbuttonholder.BackgroundImage = Nothing
                Skin_Loader.pretimepanel.BackgroundImage = Nothing
                Skin_Loader.ApplicationsToolStripMenuItem.BackgroundImage = Nothing
                Skin_Loader.prepgleft.BackgroundImage = Nothing
                Skin_Loader.prepgright.BackgroundImage = Nothing
                Skin_Loader.prepgbottom.BackgroundImage = Nothing
                Skin_Loader.prepgbottomrcorner.BackgroundImage = Nothing
                Skin_Loader.prepgbottomlcorner.BackgroundImage = Nothing
                Skin_Loader.prepnlpanelbutton.BackgroundImage = Nothing
                Skin_Loader.preminimizebutton.BackgroundImage = Nothing

                For i = 0 To 50
                    Skin_Loader.skinloaderskinimages(i) = ""
                Next

                GC.Collect()

                While My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Preview\")
                    Try
                        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Preview\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\Preview\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End While
                My.Computer.FileSystem.CreateDirectory("C:\ShiftOS\Shiftum42\Skins\Preview\")
        End Select

    End Sub

    Private Sub shortdisposecode(ByVal skinloadervarible As Array, ByVal shiftosdesktopvarible As Array, ByVal shiftervarible As Array, ByVal includedesktop As Boolean)
        If includedesktop = True Then
            If shiftosdesktopvarible(0) Is Nothing Then  Else shiftosdesktopvarible(0).Dispose()
            If shiftosdesktopvarible(1) Is Nothing Then  Else shiftosdesktopvarible(1).Dispose()
            If shiftosdesktopvarible(2) Is Nothing Then  Else shiftosdesktopvarible(2).Dispose()
            shiftosdesktopvarible(0) = Nothing
            shiftosdesktopvarible(1) = Nothing
            shiftosdesktopvarible(2) = Nothing
        End If
        If Shifter.Visible Then
            If shiftervarible(0) Is Nothing Then  Else shiftervarible(0).Dispose()
            If shiftervarible(1) Is Nothing Then  Else shiftervarible(1).Dispose()
            If shiftervarible(2) Is Nothing Then  Else shiftervarible(2).Dispose()
            shiftervarible(0) = Nothing
            shiftervarible(1) = Nothing
            shiftervarible(2) = Nothing
        End If
        If Skin_Loader.Visible Then
            If skinloadervarible(0) Is Nothing Then  Else skinloadervarible(0).Dispose()
            If skinloadervarible(1) Is Nothing Then  Else skinloadervarible(1).Dispose()
            If skinloadervarible(2) Is Nothing Then  Else skinloadervarible(2).Dispose()
            skinloadervarible(0) = Nothing
            skinloadervarible(1) = Nothing
            skinloadervarible(2) = Nothing
        End If
    End Sub

    Public Sub setupdesktop()

        If unitymode = False Then
            Me.BackColor = desktopbackgroundcolour
            If skindesktopbackground(0) Is Nothing Then Me.BackgroundImage = Nothing Else Me.BackgroundImage = skindesktopbackground(0)
            Me.BackgroundImageLayout = skindesktopbackgroundstyle
        Else
            Me.BackColor = globaltransparencycolour
            Me.BackgroundImage = Nothing
            Me.TransparencyKey = globaltransparencycolour
        End If

        shiftwindowsontop()
        ToolStripManager.Renderer = New MyToolStripRenderer()

        If boughtdesktoppanel = True Then
            If skindesktoppanel(0) Is Nothing Then
                desktoppanel.BackColor = desktoppanelcolour
                desktoppanel.BackgroundImage = Nothing
            Else
                desktoppanel.BackgroundImage = skindesktoppanel(0)
                desktoppanel.BackgroundImageLayout = skindesktoppanelstyle
                desktoppanel.BackColor = Color.Transparent
            End If

            desktoppanel.Size = New Size(desktoppanel.Size.Width, desktoppanelheight)
            Select Case desktoppanelposition
                Case "Top"
                    desktoppanel.Dock = DockStyle.Top
                    desktopappmenu.Dock = DockStyle.Top
                Case "Bottom"
                    desktoppanel.Dock = DockStyle.Bottom
                    desktopappmenu.Dock = DockStyle.Bottom
            End Select
            desktoppanel.Show()
        Else
            desktoppanel.Hide()
        End If

        If boughtapplaunchermenu = True Then

            ApplicationsToolStripMenuItem.Font = New Font(applicationbuttontextfont, applicationbuttontextsize, applicationbuttontextstyle)
            ApplicationsToolStripMenuItem.Text = applicationlaunchername
            KnowledgeInputToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            ShiftoriumToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            ClockToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            ShifterToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            TerminalToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            PongToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            FileSkimmerToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            TextPadToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            SkinLoaderToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            ArtpadToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            CalculatorToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            AudioplayerToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            WebBrowserToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            VideoplayerToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            NameChangerToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            IconManagerToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            BitnoteWalletToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            BitnoteDiggerToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            SkinShifterToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            ShiftnetToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            ShutdownToolStripMenuItem.Font = New Font("Byington", 10, FontStyle.Bold)
            desktopappmenu.ImageScalingSize = New Size(launchericonsize, launchericonsize)
            KnowledgeInputToolStripMenuItem.Text = knowledgeinputname
            ShiftoriumToolStripMenuItem.Text = shiftoriumname
            ClockToolStripMenuItem.Text = clockname
            ShifterToolStripMenuItem.Text = shiftername
            TerminalToolStripMenuItem.Text = terminalname
            PongToolStripMenuItem.Text = pongname
            FileSkimmerToolStripMenuItem.Text = fileskimmername
            TextPadToolStripMenuItem.Text = textpadname
            SkinLoaderToolStripMenuItem.Text = skinloadername
            ArtpadToolStripMenuItem.Text = artpadname
            CalculatorToolStripMenuItem.Text = calculatorname
            AudioplayerToolStripMenuItem.Text = audioplayername
            WebBrowserToolStripMenuItem.Text = webbrowsername
            VideoplayerToolStripMenuItem.Text = videoplayername
            NameChangerToolStripMenuItem.Text = namechangername
            IconManagerToolStripMenuItem.Text = iconmanagername
            BitnoteWalletToolStripMenuItem.Text = bitnotewalletname
            BitnoteDiggerToolStripMenuItem.Text = bitnotediggername
            SkinShifterToolStripMenuItem.Text = skinshiftername
            ShiftnetToolStripMenuItem.Text = shiftnetname
            KnowledgeInputToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ShiftoriumToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ClockToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ShiftoriumToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ShifterToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            TerminalToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            PongToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            FileSkimmerToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            TextPadToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            SkinLoaderToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ArtpadToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            CalculatorToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            AudioplayerToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            WebBrowserToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            VideoplayerToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            NameChangerToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            IconManagerToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            BitnoteWalletToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            BitnoteDiggerToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            SkinShifterToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ShiftnetToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ShutdownToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            applaunchermenuholder.Size = ApplicationsToolStripMenuItem.Size
            ApplicationsToolStripMenuItem.ForeColor = applicationsbuttontextcolour
            ApplicationsToolStripMenuItem.BackColor = applauncherbuttoncolour
            applaunchermenuholder.Height = applicationbuttonheight
            desktopappmenu.Height = applicationbuttonheight
            ApplicationsToolStripMenuItem.Height = applicationbuttonheight
            ApplicationsToolStripMenuItem.Visible = True
            TerminalToolStripMenuItem.Visible = True

            applaunchermenuholder.Width = applaunchermenuholderwidth
            desktopappmenu.Width = applaunchermenuholderwidth
            ApplicationsToolStripMenuItem.Width = applaunchermenuholderwidth

            If skinapplauncherbutton(0) Is Nothing Then
                ApplicationsToolStripMenuItem.BackColor = applauncherbuttoncolour
                ApplicationsToolStripMenuItem.BackgroundImage = Nothing
            Else
                ApplicationsToolStripMenuItem.BackColor = Color.Transparent
                desktopappmenu.BackColor = Color.Transparent
                ApplicationsToolStripMenuItem.BackgroundImage = skinapplauncherbutton(0)
                ApplicationsToolStripMenuItem.Text = ""
            End If

        Else
            ApplicationsToolStripMenuItem.Visible = False
        End If

        If boughtalclock = True Then
            ClockToolStripMenuItem.Visible = True
            If boughtclockicon = True Then
                ClockToolStripMenuItem.Image = clockiconlauncher
            End If
        Else
            ClockToolStripMenuItem.Visible = False
        End If

        If boughtalknowledgeinput = True Then
            KnowledgeInputToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                KnowledgeInputToolStripMenuItem.Image = knowledgeinputiconlauncher
            End If
        Else
            KnowledgeInputToolStripMenuItem.Visible = False
        End If

        If boughtalshiftorium = True Then
            ShiftoriumToolStripMenuItem.Visible = True
            If boughtshiftoriumicon = True Then
                ShiftoriumToolStripMenuItem.Image = shiftoriumiconlauncher
            End If
        Else
            ShiftoriumToolStripMenuItem.Visible = False
        End If

        If boughtalshifter = True Then
            ShifterToolStripMenuItem.Visible = True
            If boughtshiftericon = True Then
                ShifterToolStripMenuItem.Image = shiftericonlauncher
            End If
        Else
            ShifterToolStripMenuItem.Visible = False
        End If

        If boughtalpong = True Then
            PongToolStripMenuItem.Visible = True
            If boughtpongicon = True Then
                PongToolStripMenuItem.Image = pongiconlauncher
            End If
        Else
            PongToolStripMenuItem.Visible = False
        End If

        If boughtalfileskimmer = True Then
            FileSkimmerToolStripMenuItem.Visible = True
            If boughtfileskimmericon = True Then
                FileSkimmerToolStripMenuItem.Image = fileskimmericonlauncher
            End If
        Else
            FileSkimmerToolStripMenuItem.Visible = False
        End If

        If boughtaltextpad = True Then
            TextPadToolStripMenuItem.Visible = True
            If boughttextpadicon = True Then
                TextPadToolStripMenuItem.Image = textpadiconlauncher
            End If
        Else
            TextPadToolStripMenuItem.Visible = False
        End If

        If boughtskinning = True Then
            SkinLoaderToolStripMenuItem.Visible = True
            SkinLoaderToolStripMenuItem.Image = skinloadericonlauncher
        Else
            SkinLoaderToolStripMenuItem.Visible = False
        End If

        If boughtalartpad = True Then
            ArtpadToolStripMenuItem.Visible = True
            If boughtartpadicon = True Then
                ArtpadToolStripMenuItem.Image = artpadiconlauncher
            End If
        Else
            ArtpadToolStripMenuItem.Visible = False
        End If

        If boughtcalculator = True Then
            CalculatorToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                CalculatorToolStripMenuItem.Image = calculatoriconlauncher
            End If
        Else
            CalculatorToolStripMenuItem.Visible = False
        End If

        If boughtaudioplayer = True Then
            AudioplayerToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                AudioplayerToolStripMenuItem.Image = audioplayericonlauncher
            End If
        Else
            AudioplayerToolStripMenuItem.Visible = False
        End If

        If boughtwebbrowser = True Then
            WebBrowserToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                WebBrowserToolStripMenuItem.Image = webbrowsericonlauncher
            End If
        Else
            WebBrowserToolStripMenuItem.Visible = False
        End If

        If boughtvideoplayer = True Then
            VideoplayerToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                VideoplayerToolStripMenuItem.Image = videoplayericonlauncher
            End If
        Else
            VideoplayerToolStripMenuItem.Visible = False
        End If

        If boughtnamechanger = True Then
            NameChangerToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                NameChangerToolStripMenuItem.Image = namechangericonlauncher
            End If
        Else
            NameChangerToolStripMenuItem.Visible = False
        End If

        If boughticonmanager = True Then
            IconManagerToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                IconManagerToolStripMenuItem.Image = iconmanagericonlauncher
            End If
        Else
            IconManagerToolStripMenuItem.Visible = False
        End If

        If boughtbitnotewallet = True Then
            BitnoteWalletToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                BitnoteWalletToolStripMenuItem.Image = bitnotewalleticonlauncher
            End If
        Else
            BitnoteWalletToolStripMenuItem.Visible = False
        End If

        If boughtbitnotedigger = True Then
            BitnoteDiggerToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                BitnoteDiggerToolStripMenuItem.Image = bitnotediggericonlauncher
            End If
        Else
            BitnoteDiggerToolStripMenuItem.Visible = False
        End If

        If boughtskinshifter = True Then
            SkinShifterToolStripMenuItem.Visible = True
            If boughtknowledgeinputicon = True Then
                SkinShifterToolStripMenuItem.Image = skinshiftericonlauncher
            End If
        Else
            SkinShifterToolStripMenuItem.Visible = False
        End If

        If boughtshiftnet = True Then
            SkinShifterToolStripMenuItem.Visible = True
            If boughtshiftneticon = True Then
                ShiftnetToolStripMenuItem.Image = shiftneticonlauncher
            End If
        Else
            ShiftnetToolStripMenuItem.Visible = False
        End If

        If boughtdesktoppanelclock = True Then
            setclocktime()
            paneltimetext.ForeColor = clocktextcolour

            If skindesktoppaneltime(0) Is Nothing Then
                timepanel.BackColor = clockbackgroundcolor
                timepanel.BackgroundImage = Nothing
            Else
                timepanel.BackColor = Color.Transparent
                timepanel.BackgroundImage = skindesktoppaneltime(0)
                timepanel.BackgroundImageLayout = skindesktoppaneltimestyle
            End If
            paneltimetext.Font = New Font(panelclocktextfont, panelclocktextsize, panelclocktextstyle)
            timepanel.Size = New Size(paneltimetext.Width + 3, timepanel.Height)
            paneltimetext.Location = New Point(0, panelclocktexttop)
            timepanel.Show()
        Else
            timepanel.Hide()
        End If

        If boughtapplaunchershutdown = True Then
            ShutdownToolStripMenuItem.Visible = True
            ToolStripSeparator1.Visible = True
            If boughtshutdownicon = True Then
                ShutdownToolStripMenuItem.Image = shutdowniconlauncher
            End If
        Else
            ShutdownToolStripMenuItem.Visible = False
            ToolStripSeparator1.Visible = False
        End If

        If boughtterminalicon = True Then
            TerminalToolStripMenuItem.Image = terminaliconlauncher
        End If

        If boughttitlebar = False Then
            titlebarheight = 0
        End If

        If boughtwindowborders = False Then
            windowbordersize = 0
        End If

        setuppanelbuttons()

    End Sub

    Public Sub setuppanelbuttons()
        If boughtpanelbuttons Then
            If Knowledge_Input.Visible Then pnlpanelbuttonknowledgeinput.Show() Else pnlpanelbuttonknowledgeinput.Hide()
            If Shiftorium.Visible Then pnlpanelbuttonshiftorium.Show() Else pnlpanelbuttonshiftorium.Hide()
            If Clock.Visible Then pnlpanelbuttonclock.Show() Else pnlpanelbuttonclock.Hide()
            If Shifter.Visible Then pnlpanelbuttonshifter.Show() Else pnlpanelbuttonshifter.Hide()
            If Colour_Picker.Visible Then pnlpanelbuttoncolourpicker.Show() Else pnlpanelbuttoncolourpicker.Hide()
            If infobox.Visible Then pnlpanelbuttoninfobox.Show() Else pnlpanelbuttoninfobox.Hide()
            If Pong.Visible Then pnlpanelbuttonpong.Show() Else pnlpanelbuttonpong.Hide()
            If File_Skimmer.Visible Then pnlpanelbuttonfileskimmer.Show() Else pnlpanelbuttonfileskimmer.Hide()
            If File_Opener.Visible Then pnlpanelbuttonfileopener.Show() Else pnlpanelbuttonfileopener.Hide()
            If File_Saver.Visible Then pnlpanelbuttonfilesaver.Show() Else pnlpanelbuttonfilesaver.Hide()
            If TextPad.Visible Then pnlpanelbuttontextpad.Show() Else pnlpanelbuttontextpad.Hide()
            If Graphic_Picker.Visible Then pnlpanelbuttongraphicpicker.Show() Else pnlpanelbuttongraphicpicker.Hide()
            If Skin_Loader.Visible Then pnlpanelbuttonskinloader.Show() Else pnlpanelbuttonskinloader.Hide()
            If ArtPad.Visible Then pnlpanelbuttonartpad.Show() Else pnlpanelbuttonartpad.Hide()
            If Calculator.Visible Then pnlpanelbuttoncalculator.Show() Else pnlpanelbuttoncalculator.Hide()
            If Audio_Player.Visible Then pnlpanelbuttonaudioplayer.Show() Else pnlpanelbuttonaudioplayer.Hide()
            If Web_Browser.Visible Then pnlpanelbuttonwebbrowser.Show() Else pnlpanelbuttonwebbrowser.Hide()
            If Video_Player.Visible Then pnlpanelbuttonvideoplayer.Show() Else pnlpanelbuttonvideoplayer.Hide()
            If Name_Changer.Visible Then pnlpanelbuttonnamechanger.Show() Else pnlpanelbuttonnamechanger.Hide()
            If Icon_Manager.Visible Then pnlpanelbuttoniconmanager.Show() Else pnlpanelbuttoniconmanager.Hide()
            If Bitnote_Wallet.Visible Then pnlpanelbuttonbitnotewallet.Show() Else pnlpanelbuttonbitnotewallet.Hide()
            If Bitnote_Digger.Visible Then pnlpanelbuttonbitnotedigger.Show() Else pnlpanelbuttonbitnotedigger.Hide()
            If Skinshifter.Visible Then pnlpanelbuttonskinshifter.Show() Else pnlpanelbuttonskinshifter.Hide()
            If Shiftnet.Visible Then pnlpanelbuttonshiftnet.Show() Else pnlpanelbuttonshiftnet.Hide()
            If Downloader.Visible Then pnlpanelbuttondownloader.Show() Else pnlpanelbuttondownloader.Hide()
            If Terminal.Visible Then pnlpanelbuttonterminal.Show() Else pnlpanelbuttonterminal.Hide()

            tbknowledgeinputicon.Image = knowledgeinputiconpanelbutton.Clone

            tbknowledgeinputtext.Text = knowledgeinputname
            tbshiftoriumtext.Text = shiftoriumname
            tbclocktext.Text = clockname
            tbshiftertext.Text = shiftername
            tbcolourpickertext.Text = colourpickername
            tbpongtext.Text = pongname
            tbfileskimmertext.Text = fileskimmername
            tbfileopenertext.Text = fileopenername
            tbfilesavertext.Text = filesavername
            tbtextpadtext.Text = textpadname
            tbgraphicpickertext.Text = graphicpickername
            tbskinloadertext.Text = skinloadername
            tbartpadtext.Text = artpadname
            tbcalculatortext.Text = calculatorname
            tbaudioplayertext.Text = audioplayername
            tbwebbrowsertext.Text = webbrowsername
            tbvideoplayertext.Text = videoplayername
            tbnamechangertext.Text = namechangername
            tbiconmanagertext.Text = iconmanagername
            tbbitnotewallettext.Text = bitnotewalletname
            tbbitnotediggertext.Text = bitnotediggername
            tbskinshiftertext.Text = skinshiftername
            tbshiftnettext.Text = shiftnetname
            tbdownloadertext.Text = downloadername
            tbterminaltext.Text = terminalname

            pnlpanelbuttonknowledgeinput.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonshiftorium.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonclock.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonshifter.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttoncolourpicker.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttoninfobox.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonpong.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonfileskimmer.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonfileopener.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonfilesaver.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttontextpad.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttongraphicpicker.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonskinloader.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonartpad.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttoncalculator.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonaudioplayer.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonwebbrowser.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonvideoplayer.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonnamechanger.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttoniconmanager.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonbitnotewallet.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonbitnotedigger.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonskinshifter.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonshiftnet.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttondownloader.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
            pnlpanelbuttonterminal.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)

            setpanelbuttonappearnce(pnlpanelbuttonknowledgeinput, tbknowledgeinputicon, tbknowledgeinputtext, False)
            setpanelbuttonappearnce(pnlpanelbuttonshiftorium, tbshiftoriumicon, tbshiftoriumtext, False)
            setpanelbuttonappearnce(pnlpanelbuttonclock, tbclockicon, tbclocktext, False)
            setpanelbuttonappearnce(pnlpanelbuttonshifter, tbshiftericon, tbshiftertext, False)
            setpanelbuttonappearnce(pnlpanelbuttoncolourpicker, tbcolourpickericon, tbcolourpickertext, False)
            setpanelbuttonappearnce(pnlpanelbuttoninfobox, tbinfoboxicon, tbinfoboxtext, False)
            setpanelbuttonappearnce(pnlpanelbuttonpong, tbpongicon, tbpongtext, False)
            setpanelbuttonappearnce(pnlpanelbuttonfileskimmer, tbfileskimmericon, tbfileskimmertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonfileopener, tbfileopenericon, tbfileopenertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonfilesaver, tbfilesavericon, tbfilesavertext, False)
            setpanelbuttonappearnce(pnlpanelbuttontextpad, tbtextpadicon, tbtextpadtext, False)
            setpanelbuttonappearnce(pnlpanelbuttongraphicpicker, tbgraphicpickericon, tbgraphicpickertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonskinloader, tbskinloadericon, tbskinloadertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonartpad, tbartpadicon, tbartpadtext, False)
            setpanelbuttonappearnce(pnlpanelbuttoncalculator, tbcalculatoricon, tbcalculatortext, False)
            setpanelbuttonappearnce(pnlpanelbuttonaudioplayer, tbaudioplayericon, tbaudioplayertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonwebbrowser, tbwebbrowsericon, tbwebbrowsertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonvideoplayer, tbvideoplayericon, tbvideoplayertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonnamechanger, tbnamechangericon, tbnamechangertext, False)
            setpanelbuttonappearnce(pnlpanelbuttoniconmanager, tbiconmanagericon, tbiconmanagertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonbitnotewallet, tbbitnotewalleticon, tbbitnotewallettext, False)
            setpanelbuttonappearnce(pnlpanelbuttonbitnotedigger, tbbitnotediggericon, tbbitnotediggertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonskinshifter, tbskinshiftericon, tbskinshiftertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonshiftnet, tbshiftneticon, tbshiftnettext, False)
            setpanelbuttonappearnce(pnlpanelbuttondownloader, tbdownloadericon, tbdownloadertext, False)
            setpanelbuttonappearnce(pnlpanelbuttonterminal, tbterminalicon, tbterminaltext, False)

            setuppanelbuttonicons(tbknowledgeinputicon, knowledgeinputiconpanelbutton)
            setuppanelbuttonicons(tbshiftoriumicon, shiftoriumiconpanelbutton)
            setuppanelbuttonicons(tbclockicon, clockiconpanelbutton)
            setuppanelbuttonicons(tbshiftericon, shiftericonpanelbutton)
            setuppanelbuttonicons(tbcolourpickericon, colourpickericonpanelbutton)
            setuppanelbuttonicons(tbinfoboxicon, infoboxiconpanelbutton)
            setuppanelbuttonicons(tbpongicon, pongiconpanelbutton)
            setuppanelbuttonicons(tbfileskimmericon, fileskimmericonpanelbutton)
            setuppanelbuttonicons(tbfileopenericon, fileopenericonpanelbutton)
            setuppanelbuttonicons(tbfilesavericon, filesavericonpanelbutton)
            setuppanelbuttonicons(tbtextpadicon, textpadiconpanelbutton)
            setuppanelbuttonicons(tbgraphicpickericon, graphicpickericonpanelbutton)
            setuppanelbuttonicons(tbskinloadericon, skinloadericonpanelbutton)
            setuppanelbuttonicons(tbartpadicon, artpadiconpanelbutton)
            setuppanelbuttonicons(tbcalculatoricon, calculatoriconpanelbutton)
            setuppanelbuttonicons(tbaudioplayericon, audioplayericonpanelbutton)
            setuppanelbuttonicons(tbwebbrowsericon, webbrowsericonpanelbutton)
            setuppanelbuttonicons(tbvideoplayericon, videoplayericonpanelbutton)
            setuppanelbuttonicons(tbnamechangericon, namechangericonpanelbutton)
            setuppanelbuttonicons(tbiconmanagericon, iconmanagericonpanelbutton)
            setuppanelbuttonicons(tbbitnotewalleticon, bitnotewalleticonpanelbutton)
            setuppanelbuttonicons(tbbitnotediggericon, bitnotediggericonpanelbutton)
            setuppanelbuttonicons(tbskinshiftericon, skinshiftericonpanelbutton)
            setuppanelbuttonicons(tbshiftneticon, shiftneticonpanelbutton)
            setuppanelbuttonicons(tbdownloadericon, downloadericonpanelbutton)
            setuppanelbuttonicons(tbterminalicon, terminaliconpanelbutton)

            pnlpanelbuttonholder.Padding = New Padding(panelbuttoninitialgap, 0, 0, 0)
        End If
    End Sub

    Public Sub setuppanelbuttonicons(ByVal tbicon As PictureBox, ByVal image As Image)
        tbicon.Image = image
        tbicon.Size = New Size(panelbuttoniconsize, panelbuttoniconsize)
    End Sub

    Public Sub setpanelbuttonappearnce(ByVal panelbutton As Panel, ByVal icon As PictureBox, ByVal text As Label, ByVal sendback As Boolean)
        If sendback = True Then panelbutton.SendToBack()
        icon.Location = New Point(panelbuttoniconside, panelbuttonicontop)
        icon.Size = New Size(panelbuttoniconsize, panelbuttoniconsize)
        panelbutton.Size = New Size(panelbuttonwidth, panelbuttonheight)
        panelbutton.BackColor = panelbuttoncolour
        panelbutton.BackgroundImage = skinpanelbutton(0)
        If skinpanelbutton(0) Is Nothing Then  Else panelbutton.BackColor = Color.Transparent
        panelbutton.BackgroundImageLayout = skinpanelbuttonstyle
        text.ForeColor = panelbuttontextcolour
        text.Font = New Font(panelbuttontextfont, panelbuttontextsize, panelbuttontextstyle)
        text.Location = New Point(panelbuttontextside, panelbuttontexttop)
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.T AndAlso e.Control Then
            Terminal.Show()
            Terminal.BringToFront()
            If terminalfullscreen = True Then Terminal.fullterminal()
        End If
    End Sub

    Public Sub closeeverything()

        If boughtmultitasking = False Then
            'Knowledge_Input.Close()
            'Shiftorium.Close()
            'Clock.Close()
            'Shifter.Close()
            'Colour_Picker.Close()
            'infobox.Close()
            'Pong.Close()
            'File_Skimmer.Close()
            'File_Opener.Close()
            'File_Saver.Close()
            'TextPad.Close()
            'Graphic_Picker.Close()
            'Skin_Loader.Close()
            'ArtPad.Close()
            'Calculator.Close()
            'Audio_Player.Close()
            'Web_Browser.Close()
            'Video_Player.Close()
            'Name_Changer.Close()
            'Icon_Manager.Close()
            'Bitnote_Wallet.Close()
            'Bitnote_Digger.Close()
            'Skinshifter.Close()
            'Shiftnet.Close()
            'Downloader.Close()
            'template.Close()

            For Each f In My.Application.OpenForms.Cast(Of Form)().ToArray()
                Select Case f.Name
                    Case "ShiftOSDesktop", "HijackScreen", "ShiftOS Save File Converter"
                        'do nothing
                    Case Else
                        f.Close()
                End Select
            Next

        End If

        If forceclose = True Then
            'Knowledge_Input.Close()
            'Shiftorium.Close()
            'Clock.Close()
            'Shifter.Close()
            'Colour_Picker.Close()
            'infobox.Close()
            'Pong.Close()
            'File_Skimmer.Close()
            'TextPad.Close()
            'File_Opener.Close()
            'File_Saver.Close()
            'Graphic_Picker.Close()
            'Skin_Loader.Close()
            'ArtPad.Close()
            'Calculator.Close()
            'Audio_Player.Close()
            'Web_Browser.Close()
            'Video_Player.Close()
            'Name_Changer.Close()
            'Icon_Manager.Close()
            'Bitnote_Wallet.Close()
            'Bitnote_Digger.Close()
            'Skinshifter.Close()
            'Shiftnet.Close()
            'Downloader.Close()
            'template.Close()

            For Each f In My.Application.OpenForms.Cast(Of Form)().ToArray()
                Select Case f.Name
                    Case "ShiftOSDesktop", "HijackScreen", "ShiftOS Save File Converter"
                        'do nothing
                    Case Else
                        f.Close()
                End Select
            Next

        End If
        forceclose = False
    End Sub

    Public Sub shutdownshiftos()
        forceclose = True
        closeeverything()
        Terminal.txtterm.Text = Terminal.txtterm.Text & Environment.NewLine & "System Is Shutting Down..." & Environment.NewLine
        log = log & My.Computer.Clock.LocalTime & " ShutDown ShiftOS with " & codepoints & " Code Points!" & Environment.NewLine
        savegame()
        Terminal.tmrshutdown.Start()
    End Sub

    Public Sub addtitlebars()

        'attempted future code to dramatically increase development time and simplify code
        'For Each f In My.Application.OpenForms.Cast(Of Form)().ToArray()
        '    Select Case f.Name
        '        Case "ShiftOSDesktop", "HijackScreen", "ShiftOS Save File Converter"
        '            'do nothing
        '        Case Else
        '            If f.Visible = True Then
        '                f.titlebar.Show()
        '                f.setuptitlebar()
        '                f.Size = New Size(f.Width, f.Size.Height + f.titlebar.Height)
        '            End If
        '    End Select
        'Next

        If Knowledge_Input.Visible = True Then
            Knowledge_Input.titlebar.Show()
            Knowledge_Input.setuptitlebar()
            Knowledge_Input.Size = New Size(Knowledge_Input.Width, Knowledge_Input.Size.Height + Knowledge_Input.titlebar.Height)
        End If

        If Shiftorium.Visible = True Then
            Shiftorium.titlebar.Show()
            Shiftorium.setuptitlebar()
            Shiftorium.Size = New Size(Shiftorium.Width, Shiftorium.Size.Height + Shiftorium.titlebar.Height)
        End If

        If Clock.Visible = True Then
            Clock.titlebar.Show()
            Clock.setuptitlebar()
            Clock.Size = New Size(Clock.Width, Clock.Size.Height + Clock.titlebar.Height)
        End If

        If Shifter.Visible = True Then
            Shifter.titlebar.Show()
            Shifter.setuptitlebar()
            Shifter.Size = New Size(Shifter.Width, Shifter.Size.Height + Shifter.titlebar.Height)
        End If

        If Colour_Picker.Visible = True Then
            Colour_Picker.titlebar.Show()
            Colour_Picker.setuptitlebar()
            Colour_Picker.Size = New Size(Colour_Picker.Width, Colour_Picker.Size.Height + Colour_Picker.titlebar.Height)
        End If

        If infobox.Visible = True Then
            infobox.titlebar.Show()
            infobox.setuptitlebar()
            infobox.Size = New Size(infobox.Width, infobox.Size.Height + infobox.titlebar.Height)
        End If

        If Pong.Visible = True Then
            Pong.titlebar.Show()
            Pong.setuptitlebar()
            Pong.Size = New Size(Pong.Width, Pong.Size.Height + Pong.titlebar.Height)
        End If

        If File_Skimmer.Visible = True Then
            File_Skimmer.titlebar.Show()
            File_Skimmer.setuptitlebar()
            File_Skimmer.Size = New Size(File_Skimmer.Width, File_Skimmer.Size.Height + File_Skimmer.titlebar.Height)
        End If

        If TextPad.Visible = True Then
            TextPad.titlebar.Show()
            TextPad.setuptitlebar()
            TextPad.Size = New Size(TextPad.Width, TextPad.Size.Height + TextPad.titlebar.Height)
        End If

        If File_Opener.Visible = True Then
            File_Opener.titlebar.Show()
            File_Opener.setuptitlebar()
            File_Opener.Size = New Size(File_Opener.Width, File_Opener.Size.Height + File_Opener.titlebar.Height)
        End If

        If File_Saver.Visible = True Then
            File_Saver.titlebar.Show()
            File_Saver.setuptitlebar()
            File_Saver.Size = New Size(File_Saver.Width, File_Saver.Size.Height + File_Saver.titlebar.Height)
        End If

        If Graphic_Picker.Visible = True Then
            Graphic_Picker.titlebar.Show()
            Graphic_Picker.setuptitlebar()
            Graphic_Picker.Size = New Size(Graphic_Picker.Width, Graphic_Picker.Size.Height + Graphic_Picker.titlebar.Height)
        End If

        If Skin_Loader.Visible = True Then
            Skin_Loader.titlebar.Show()
            Skin_Loader.setuptitlebar()
            Skin_Loader.Size = New Size(Skin_Loader.Width, Skin_Loader.Size.Height + Skin_Loader.titlebar.Height)
        End If

        If ArtPad.Visible = True Then
            ArtPad.titlebar.Show()
            ArtPad.setuptitlebar()
            ArtPad.Size = New Size(ArtPad.Width, ArtPad.Size.Height + ArtPad.titlebar.Height)
        End If

        If Calculator.Visible = True Then
            Calculator.titlebar.Show()
            Calculator.setuptitlebar()
            Calculator.Size = New Size(Calculator.Width, Calculator.Size.Height + Calculator.titlebar.Height)
        End If

        If Audio_Player.Visible = True Then
            Audio_Player.titlebar.Show()
            Audio_Player.setuptitlebar()
            Audio_Player.Size = New Size(Audio_Player.Width, Audio_Player.Size.Height + Audio_Player.titlebar.Height)
        End If

        If Web_Browser.Visible = True Then
            Web_Browser.titlebar.Show()
            Web_Browser.setuptitlebar()
            Web_Browser.Size = New Size(Web_Browser.Width, Web_Browser.Size.Height + Web_Browser.titlebar.Height)
        End If

        If Name_Changer.Visible = True Then
            Name_Changer.titlebar.Show()
            Name_Changer.setuptitlebar()
            Name_Changer.Size = New Size(Name_Changer.Width, Name_Changer.Size.Height + Name_Changer.titlebar.Height)
        End If

        If Icon_Manager.Visible = True Then
            Icon_Manager.titlebar.Show()
            Icon_Manager.setuptitlebar()
            Icon_Manager.Size = New Size(Icon_Manager.Width, Icon_Manager.Size.Height + Icon_Manager.titlebar.Height)
        End If

        If Bitnote_Wallet.Visible = True Then
            Bitnote_Wallet.titlebar.Show()
            Bitnote_Wallet.setuptitlebar()
            Bitnote_Wallet.Size = New Size(Bitnote_Wallet.Width, Bitnote_Wallet.Size.Height + Bitnote_Wallet.titlebar.Height)
        End If

        If Bitnote_Digger.Visible = True Then
            Bitnote_Digger.titlebar.Show()
            Bitnote_Digger.setuptitlebar()
            Bitnote_Digger.Size = New Size(Bitnote_Digger.Width, Bitnote_Digger.Size.Height + Bitnote_Digger.titlebar.Height)
        End If

        If Skinshifter.Visible = True Then
            Skinshifter.titlebar.Show()
            Skinshifter.setuptitlebar()
            Skinshifter.Size = New Size(Skinshifter.Width, Skinshifter.Size.Height + Skinshifter.titlebar.Height)
        End If

        If Shiftnet.Visible = True Then
            Shiftnet.titlebar.Show()
            Shiftnet.setuptitlebar()
            Shiftnet.Size = New Size(Shiftnet.Width, Shiftnet.Size.Height + Shiftnet.titlebar.Height)
        End If

        If Downloader.Visible = True Then
            Downloader.titlebar.Show()
            Downloader.setuptitlebar()
            Downloader.Size = New Size(Downloader.Width, Downloader.Size.Height + Downloader.titlebar.Height)
        End If

        If template.Visible = True Then
            template.titlebar.Show()
            template.setuptitlebar()
            template.Size = New Size(ArtPad.Width, ArtPad.Size.Height + ArtPad.titlebar.Height)
        End If

        If terminalfullscreen = False Then
            If Terminal.Visible = True Then
                Terminal.titlebar.Show()
                Terminal.setuptitlebar()
                Terminal.Size = New Size(Terminal.Width, Terminal.Size.Height + Terminal.titlebar.Height)
            End If
        End If
    End Sub

    Public Sub addborders()
        Knowledge_Input.pgleft.Show()
        Knowledge_Input.pgbottom.Show()
        Knowledge_Input.pgright.Show()
        Knowledge_Input.Size = New Size(Knowledge_Input.Width + Knowledge_Input.pgleft.Width + Knowledge_Input.pgright.Width, Knowledge_Input.Height + Knowledge_Input.pgbottom.Height)
        If boughttitlebar = True Then Knowledge_Input.setuptitlebar()

        Shiftorium.pgleft.Show()
        Shiftorium.pgbottom.Show()
        Shiftorium.pgright.Show()
        Shiftorium.Size = New Size(Shiftorium.Width + Shiftorium.pgleft.Width + Shiftorium.pgright.Width, Shiftorium.Height + Shiftorium.pgbottom.Height)
        If boughttitlebar = True Then Shiftorium.setuptitlebar()

        Clock.pgleft.Show()
        Clock.pgbottom.Show()
        Clock.pgright.Show()
        Clock.Size = New Size(Clock.Width + Clock.pgleft.Width + Clock.pgright.Width, Clock.Height + Clock.pgbottom.Height)
        If boughttitlebar = True Then Clock.setuptitlebar()

        Shifter.pgleft.Show()
        Shifter.pgbottom.Show()
        Shifter.pgright.Show()
        Shifter.Size = New Size(Shifter.Width + Shifter.pgleft.Width + Shifter.pgright.Width, Shifter.Height + Shifter.pgbottom.Height)
        If boughttitlebar = True Then Shifter.setuptitlebar()

        Colour_Picker.pgleft.Show()
        Colour_Picker.pgbottom.Show()
        Colour_Picker.pgright.Show()
        Colour_Picker.Size = New Size(Colour_Picker.Width + Colour_Picker.pgleft.Width + Colour_Picker.pgright.Width, Colour_Picker.Height + Colour_Picker.pgbottom.Height)
        If boughttitlebar = True Then Colour_Picker.setuptitlebar()

        infobox.pgleft.Show()
        infobox.pgbottom.Show()
        infobox.pgright.Show()
        infobox.Size = New Size(infobox.Width + infobox.pgleft.Width + infobox.pgright.Width, infobox.Height + infobox.pgbottom.Height)
        If boughttitlebar = True Then infobox.setuptitlebar()

        Pong.pgleft.Show()
        Pong.pgbottom.Show()
        Pong.pgright.Show()
        Pong.Size = New Size(Pong.Width + Pong.pgleft.Width + Pong.pgright.Width, Pong.Height + Pong.pgbottom.Height)
        If boughttitlebar = True Then Pong.setuptitlebar()

        File_Skimmer.pgleft.Show()
        File_Skimmer.pgbottom.Show()
        File_Skimmer.pgright.Show()
        File_Skimmer.Size = New Size(File_Skimmer.Width + File_Skimmer.pgleft.Width + File_Skimmer.pgright.Width, File_Skimmer.Height + File_Skimmer.pgbottom.Height)
        If boughttitlebar = True Then File_Skimmer.setuptitlebar()

        TextPad.pgleft.Show()
        TextPad.pgbottom.Show()
        TextPad.pgright.Show()
        TextPad.Size = New Size(File_Skimmer.Width + TextPad.pgleft.Width + TextPad.pgright.Width, TextPad.Height + TextPad.pgbottom.Height)
        If boughttitlebar = True Then TextPad.setuptitlebar()

        File_Opener.pgleft.Show()
        File_Opener.pgbottom.Show()
        File_Opener.pgright.Show()
        File_Opener.Size = New Size(File_Skimmer.Width + File_Opener.pgleft.Width + File_Opener.pgright.Width, File_Opener.Height + File_Opener.pgbottom.Height)
        If boughttitlebar = True Then File_Opener.setuptitlebar()

        File_Saver.pgleft.Show()
        File_Saver.pgbottom.Show()
        File_Saver.pgright.Show()
        File_Saver.Size = New Size(File_Skimmer.Width + File_Saver.pgleft.Width + File_Saver.pgright.Width, File_Saver.Height + File_Saver.pgbottom.Height)
        If boughttitlebar = True Then File_Saver.setuptitlebar()

        Graphic_Picker.pgleft.Show()
        Graphic_Picker.pgbottom.Show()
        Graphic_Picker.pgright.Show()
        Graphic_Picker.Size = New Size(Graphic_Picker.Width + Graphic_Picker.pgleft.Width + Graphic_Picker.pgright.Width, Graphic_Picker.Height + Graphic_Picker.pgbottom.Height)
        If boughttitlebar = True Then Graphic_Picker.setuptitlebar()

        Skin_Loader.pgleft.Show()
        Skin_Loader.pgbottom.Show()
        Skin_Loader.pgright.Show()
        Skin_Loader.Size = New Size(Skin_Loader.Width + Skin_Loader.pgleft.Width + Skin_Loader.pgright.Width, Skin_Loader.Height + Skin_Loader.pgbottom.Height)
        If boughttitlebar = True Then Skin_Loader.setuptitlebar()

        ArtPad.pgleft.Show()
        ArtPad.pgbottom.Show()
        ArtPad.pgright.Show()
        ArtPad.Size = New Size(ArtPad.Width + ArtPad.pgleft.Width + ArtPad.pgright.Width, ArtPad.Height + ArtPad.pgbottom.Height)
        If boughttitlebar = True Then ArtPad.setuptitlebar()

        Calculator.pgleft.Show()
        Calculator.pgbottom.Show()
        Calculator.pgright.Show()
        Calculator.Size = New Size(Calculator.Width + Calculator.pgleft.Width + Calculator.pgright.Width, Calculator.Height + Calculator.pgbottom.Height)
        If boughttitlebar = True Then Calculator.setuptitlebar()

        Audio_Player.pgleft.Show()
        Audio_Player.pgbottom.Show()
        Audio_Player.pgright.Show()
        Audio_Player.Size = New Size(Audio_Player.Width + Audio_Player.pgleft.Width + Audio_Player.pgright.Width, Audio_Player.Height + Audio_Player.pgbottom.Height)
        If boughttitlebar = True Then Audio_Player.setuptitlebar()

        Web_Browser.pgleft.Show()
        Web_Browser.pgbottom.Show()
        Web_Browser.pgright.Show()
        Web_Browser.Size = New Size(Web_Browser.Width + Web_Browser.pgleft.Width + Web_Browser.pgright.Width, Web_Browser.Height + Web_Browser.pgbottom.Height)
        If boughttitlebar = True Then Web_Browser.setuptitlebar()

        Video_Player.pgleft.Show()
        Video_Player.pgbottom.Show()
        Video_Player.pgright.Show()
        Video_Player.Size = New Size(Video_Player.Width + Video_Player.pgleft.Width + Video_Player.pgright.Width, Video_Player.Height + Video_Player.pgbottom.Height)
        If boughttitlebar = True Then Video_Player.setuptitlebar()

        Name_Changer.pgleft.Show()
        Name_Changer.pgbottom.Show()
        Name_Changer.pgright.Show()
        Name_Changer.Size = New Size(Name_Changer.Width + Name_Changer.pgleft.Width + Name_Changer.pgright.Width, Name_Changer.Height + Name_Changer.pgbottom.Height)
        If boughttitlebar = True Then Name_Changer.setuptitlebar()

        Icon_Manager.pgleft.Show()
        Icon_Manager.pgbottom.Show()
        Icon_Manager.pgright.Show()
        Icon_Manager.Size = New Size(Icon_Manager.Width + Icon_Manager.pgleft.Width + Icon_Manager.pgright.Width, Icon_Manager.Height + Icon_Manager.pgbottom.Height)
        If boughttitlebar = True Then Icon_Manager.setuptitlebar()

        Bitnote_Wallet.pgleft.Show()
        Bitnote_Wallet.pgbottom.Show()
        Bitnote_Wallet.pgright.Show()
        Bitnote_Wallet.Size = New Size(Bitnote_Wallet.Width + Bitnote_Wallet.pgleft.Width + Bitnote_Wallet.pgright.Width, Bitnote_Wallet.Height + Bitnote_Wallet.pgbottom.Height)
        If boughttitlebar = True Then Bitnote_Wallet.setuptitlebar()

        Bitnote_Digger.pgleft.Show()
        Bitnote_Digger.pgbottom.Show()
        Bitnote_Digger.pgright.Show()
        Bitnote_Digger.Size = New Size(Bitnote_Digger.Width + Bitnote_Digger.pgleft.Width + Bitnote_Digger.pgright.Width, Bitnote_Digger.Height + Bitnote_Digger.pgbottom.Height)
        If boughttitlebar = True Then Bitnote_Digger.setuptitlebar()

        Skinshifter.pgleft.Show()
        Skinshifter.pgbottom.Show()
        Skinshifter.pgright.Show()
        Skinshifter.Size = New Size(Skinshifter.Width + Skinshifter.pgleft.Width + Skinshifter.pgright.Width, Skinshifter.Height + Skinshifter.pgbottom.Height)
        If boughttitlebar = True Then Skinshifter.setuptitlebar()

        Shiftnet.pgleft.Show()
        Shiftnet.pgbottom.Show()
        Shiftnet.pgright.Show()
        Shiftnet.Size = New Size(Shiftnet.Width + Shiftnet.pgleft.Width + Shiftnet.pgright.Width, Shiftnet.Height + Shiftnet.pgbottom.Height)
        If boughttitlebar = True Then Shiftnet.setuptitlebar()

        Downloader.pgleft.Show()
        Downloader.pgbottom.Show()
        Downloader.pgright.Show()
        Downloader.Size = New Size(Downloader.Width + Downloader.pgleft.Width + Downloader.pgright.Width, Downloader.Height + Downloader.pgbottom.Height)
        If boughttitlebar = True Then Downloader.setuptitlebar()

        template.pgleft.Show()
        template.pgbottom.Show()
        template.pgright.Show()
        template.Size = New Size(template.Width + template.pgleft.Width + template.pgright.Width, template.Height + template.pgbottom.Height)
        If boughttitlebar = True Then ArtPad.setuptitlebar()

        If terminalfullscreen = False Then
            Terminal.pgleft.Show()
            Terminal.pgbottom.Show()
            Terminal.pgright.Show()
            Terminal.Size = New Size(Terminal.Width + Terminal.pgleft.Width + Terminal.pgright.Width, Terminal.Height + Terminal.pgbottom.Height)
            If boughttitlebar = True Then Terminal.setuptitlebar()
        End If
    End Sub

    Public Sub setupalltitlebars()
        Knowledge_Input.setuptitlebar()
        Shiftorium.setuptitlebar()
        Clock.setuptitlebar()
        Shifter.setuptitlebar()
        Colour_Picker.setuptitlebar()
        infobox.setuptitlebar()
        Pong.setuptitlebar()
        File_Skimmer.setuptitlebar()
        TextPad.setuptitlebar()
        File_Opener.setuptitlebar()
        File_Saver.setuptitlebar()
        Graphic_Picker.setuptitlebar()
        Skin_Loader.setuptitlebar()
        ArtPad.setuptitlebar()
        Calculator.setuptitlebar()
        Audio_Player.setuptitlebar()
        Web_Browser.setuptitlebar()
        Video_Player.setuptitlebar()
        Name_Changer.setuptitlebar()
        Icon_Manager.setuptitlebar()
        Bitnote_Wallet.setuptitlebar()
        Bitnote_Digger.setuptitlebar()
        Skinshifter.setuptitlebar()
        Shiftnet.setuptitlebar()
        Downloader.setuptitlebar()
        template.setuptitlebar()
        If terminalfullscreen = False Then Terminal.setuptitlebar()
    End Sub

    Public Sub setupskins()
        Knowledge_Input.setskin()
        Shiftorium.setskin()
        Clock.setskin()
        Shifter.setskin()
        Colour_Picker.setskin()
        infobox.setskin()
        Pong.setskin()
        File_Skimmer.setskin()
        TextPad.setskin()
        File_Opener.setskin()
        File_Saver.setskin()
        Graphic_Picker.setskin()
        Skin_Loader.setskin()
        ArtPad.setskin()
        Calculator.setskin()
        Audio_Player.setskin()
        Web_Browser.setskin()
        Video_Player.setskin()
        Name_Changer.setskin()
        Icon_Manager.setskin()
        Bitnote_Wallet.setskin()
        Bitnote_Digger.setskin()
        Skinshifter.setskin()
        Shiftnet.setskin()
        Downloader.setskin()
        template.setskin()
        If terminalfullscreen = False Then Terminal.setskin()
    End Sub

    Public Sub shiftwindowsontop()
        If unitymode = True Then
            Knowledge_Input.TopMost = False
            Shiftorium.TopMost = False
            Clock.TopMost = False
            Shifter.TopMost = False
            Colour_Picker.TopMost = False
            infobox.TopMost = False
            Pong.TopMost = False
            File_Skimmer.TopMost = False
            TextPad.TopMost = False
            File_Opener.TopMost = False
            File_Saver.TopMost = False
            Graphic_Picker.TopMost = False
            Skin_Loader.TopMost = False
            ArtPad.TopMost = False
            Calculator.TopMost = False
            Audio_Player.TopMost = False
            Web_Browser.TopMost = False
            Video_Player.TopMost = False
            Name_Changer.TopMost = False
            Icon_Manager.TopMost = False
            Bitnote_Wallet.TopMost = False
            Bitnote_Digger.TopMost = False
            Skinshifter.TopMost = False
            Shiftnet.TopMost = False
            Downloader.TopMost = False
            template.TopMost = False
            Terminal.TopMost = False
        Else
            Me.BringToFront()
            Knowledge_Input.TopMost = True
            Shiftorium.TopMost = True
            Clock.TopMost = True
            Shifter.TopMost = True
            Colour_Picker.TopMost = True
            infobox.TopMost = True
            Pong.TopMost = True
            File_Skimmer.TopMost = True
            TextPad.TopMost = True
            File_Opener.TopMost = True
            File_Saver.TopMost = True
            Graphic_Picker.TopMost = True
            Skin_Loader.TopMost = True
            ArtPad.TopMost = True
            Calculator.TopMost = True
            Audio_Player.TopMost = True
            Web_Browser.TopMost = True
            Video_Player.TopMost = True
            Name_Changer.TopMost = True
            Icon_Manager.TopMost = True
            Bitnote_Wallet.TopMost = True
            Bitnote_Digger.TopMost = True
            Skinshifter.TopMost = True
            Shiftnet.TopMost = True
            Downloader.TopMost = True
            template.TopMost = True
            Terminal.TopMost = True
        End If
    End Sub

    Public Sub loadskinfiles()
        If skinimages(0) = "" Then  Else skinclosebutton(0) = GetImage(skinimages(0))
        If skinimages(1) = "" Then  Else skinclosebutton(1) = GetImage(skinimages(1))
        If skinimages(2) = "" Then  Else skinclosebutton(2) = GetImage(skinimages(2))
        If skinimages(3) = "" Then  Else skintitlebar(0) = GetImage(skinimages(3))
        If skinimages(4) = "" Then  Else skintitlebar(1) = GetImage(skinimages(4))
        If skinimages(5) = "" Then  Else skintitlebar(2) = GetImage(skinimages(5))
        If skinimages(6) = "" Then  Else skindesktopbackground(0) = GetImage(skinimages(6))
        If skinimages(7) = "" Then  Else skindesktopbackground(1) = GetImage(skinimages(7))
        If skinimages(8) = "" Then  Else skindesktopbackground(2) = GetImage(skinimages(8))
        If skinimages(9) = "" Then  Else skinrollupbutton(0) = GetImage(skinimages(9))
        If skinimages(10) = "" Then  Else skinrollupbutton(1) = GetImage(skinimages(10))
        If skinimages(11) = "" Then  Else skinrollupbutton(2) = GetImage(skinimages(11))
        If skinimages(12) = "" Then  Else skintitlebarrightcorner(0) = GetImage(skinimages(12))
        If skinimages(13) = "" Then  Else skintitlebarrightcorner(1) = GetImage(skinimages(13))
        If skinimages(14) = "" Then  Else skintitlebarrightcorner(2) = GetImage(skinimages(14))
        If skinimages(15) = "" Then  Else skintitlebarleftcorner(0) = GetImage(skinimages(15))
        If skinimages(16) = "" Then  Else skintitlebarleftcorner(1) = GetImage(skinimages(16))
        If skinimages(17) = "" Then  Else skintitlebarleftcorner(2) = GetImage(skinimages(17))
        If skinimages(18) = "" Then  Else skindesktoppanel(0) = GetImage(skinimages(18))
        If skinimages(19) = "" Then  Else skindesktoppanel(1) = GetImage(skinimages(19))
        If skinimages(20) = "" Then  Else skindesktoppanel(2) = GetImage(skinimages(20))
        If skinimages(21) = "" Then  Else skindesktoppaneltime(0) = GetImage(skinimages(21))
        If skinimages(22) = "" Then  Else skindesktoppaneltime(1) = GetImage(skinimages(22))
        If skinimages(23) = "" Then  Else skindesktoppaneltime(2) = GetImage(skinimages(23))
        If skinimages(24) = "" Then  Else skinapplauncherbutton(0) = GetImage(skinimages(24))
        If skinimages(25) = "" Then  Else skinapplauncherbutton(1) = GetImage(skinimages(25))
        If skinimages(26) = "" Then  Else skinapplauncherbutton(2) = GetImage(skinimages(26))
        If skinimages(27) = "" Then  Else skinwindowborderleft(0) = GetImage(skinimages(27))
        If skinimages(28) = "" Then  Else skinwindowborderleft(1) = GetImage(skinimages(28))
        If skinimages(29) = "" Then  Else skinwindowborderleft(2) = GetImage(skinimages(29))
        If skinimages(30) = "" Then  Else skinwindowborderright(0) = GetImage(skinimages(30))
        If skinimages(31) = "" Then  Else skinwindowborderright(1) = GetImage(skinimages(31))
        If skinimages(32) = "" Then  Else skinwindowborderright(2) = GetImage(skinimages(32))
        If skinimages(33) = "" Then  Else skinwindowborderbottom(0) = GetImage(skinimages(33))
        If skinimages(34) = "" Then  Else skinwindowborderbottom(1) = GetImage(skinimages(34))
        If skinimages(35) = "" Then  Else skinwindowborderbottom(2) = GetImage(skinimages(35))
        If skinimages(36) = "" Then  Else skinwindowborderbottomright(0) = GetImage(skinimages(36))
        If skinimages(37) = "" Then  Else skinwindowborderbottomright(1) = GetImage(skinimages(37))
        If skinimages(38) = "" Then  Else skinwindowborderbottomright(2) = GetImage(skinimages(38))
        If skinimages(39) = "" Then  Else skinwindowborderbottomleft(0) = GetImage(skinimages(39))
        If skinimages(40) = "" Then  Else skinwindowborderbottomleft(1) = GetImage(skinimages(40))
        If skinimages(41) = "" Then  Else skinwindowborderbottomleft(2) = GetImage(skinimages(41))
        If skinimages(42) = "" Then  Else skinminimizebutton(0) = GetImage(skinimages(42))
        If skinimages(43) = "" Then  Else skinminimizebutton(1) = GetImage(skinimages(43))
        If skinimages(44) = "" Then  Else skinminimizebutton(2) = GetImage(skinimages(44))
        If skinimages(45) = "" Then  Else skinpanelbutton(0) = GetImage(skinimages(45))
        If skinimages(46) = "" Then  Else skinpanelbutton(1) = GetImage(skinimages(46))
        If skinimages(47) = "" Then  Else skinpanelbutton(2) = GetImage(skinimages(47))
    End Sub

    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        Return ret
    End Function

    Public Sub setcolours()
        If Shiftorium.Visible = True Then
            Shiftorium.titlebar.BackColor = titlebarcolour
            Shiftorium.pgtoplcorner.BackColor = titlebarleftcornercolour
            Shiftorium.pgtoprcorner.BackColor = titlebarrightcornercolour
            Shiftorium.pgleft.BackColor = windowborderleftcolour
            Shiftorium.pgleft.BackgroundImage = skinwindowborderleft(0)
            Shiftorium.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Shiftorium.pgright.BackColor = windowborderrightcolour
            Shiftorium.pgright.BackgroundImage = skinwindowborderright(0)
            Shiftorium.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Shiftorium.pgbottom.BackColor = windowborderbottomcolour
            Shiftorium.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Shiftorium.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Shiftorium.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Shiftorium.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Shiftorium.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Shiftorium.pgbottomlcorner.Height = windowbordersize
            Shiftorium.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Shiftorium.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Shiftorium.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Shiftorium.pgbottomrcorner.Height = windowbordersize
        Else
            Shiftorium.Close()
        End If

        If Knowledge_Input.Visible = True Then
            Knowledge_Input.titlebar.BackColor = titlebarcolour
            Knowledge_Input.pgtoplcorner.BackColor = titlebarleftcornercolour
            Knowledge_Input.pgtoprcorner.BackColor = titlebarrightcornercolour
            Knowledge_Input.pgleft.BackColor = windowborderleftcolour
            Knowledge_Input.pgleft.BackgroundImage = skinwindowborderleft(0)
            Knowledge_Input.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Knowledge_Input.pgright.BackColor = windowborderrightcolour
            Knowledge_Input.pgright.BackgroundImage = skinwindowborderright(0)
            Knowledge_Input.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Knowledge_Input.pgbottom.BackColor = windowborderbottomcolour
            Knowledge_Input.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Knowledge_Input.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Knowledge_Input.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Knowledge_Input.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Knowledge_Input.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Knowledge_Input.pgbottomlcorner.Height = windowbordersize
            Knowledge_Input.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Knowledge_Input.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Knowledge_Input.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Knowledge_Input.pgbottomrcorner.Height = windowbordersize
        Else
            Knowledge_Input.Close()
        End If

        If Clock.Visible = True Then
            Clock.titlebar.BackColor = titlebarcolour
            Clock.pgtoplcorner.BackColor = titlebarleftcornercolour
            Clock.pgtoprcorner.BackColor = titlebarrightcornercolour
            Clock.pgleft.BackColor = windowborderleftcolour
            Clock.pgleft.BackgroundImage = skinwindowborderleft(0)
            Clock.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Clock.pgright.BackColor = windowborderrightcolour
            Clock.pgright.BackgroundImage = skinwindowborderright(0)
            Clock.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Clock.pgbottom.BackColor = windowborderbottomcolour
            Clock.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Clock.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Clock.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Clock.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Clock.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Clock.pgbottomlcorner.Height = windowbordersize
            Clock.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Clock.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Clock.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Clock.pgbottomrcorner.Height = windowbordersize
        Else
            Clock.Close()
        End If

        If Shifter.Visible = True Then
            Shifter.titlebar.BackColor = titlebarcolour
            Shifter.pgtoplcorner.BackColor = titlebarleftcornercolour
            Shifter.pgtoprcorner.BackColor = titlebarrightcornercolour
            Shifter.pgleft.BackColor = windowborderleftcolour
            Shifter.pgleft.BackgroundImage = skinwindowborderleft(0)
            Shifter.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Shifter.pgright.BackColor = windowborderrightcolour
            Shifter.pgright.BackgroundImage = skinwindowborderright(0)
            Shifter.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Shifter.pgbottom.BackColor = windowborderbottomcolour
            Shifter.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Shifter.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Shifter.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Shifter.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Shifter.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Shifter.pgbottomlcorner.Height = windowbordersize
            Shifter.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Shifter.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Shifter.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Shifter.pgbottomrcorner.Height = windowbordersize
        Else
            Shifter.Close()
        End If

        If Colour_Picker.Visible = True Then
            Colour_Picker.titlebar.BackColor = titlebarcolour
            Colour_Picker.pgtoplcorner.BackColor = titlebarleftcornercolour
            Colour_Picker.pgtoprcorner.BackColor = titlebarrightcornercolour
            Colour_Picker.pgleft.BackColor = windowborderleftcolour
            Colour_Picker.pgleft.BackgroundImage = skinwindowborderleft(0)
            Colour_Picker.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Colour_Picker.pgright.BackColor = windowborderrightcolour
            Colour_Picker.pgright.BackgroundImage = skinwindowborderright(0)
            Colour_Picker.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Colour_Picker.pgbottom.BackColor = windowborderbottomcolour
            Colour_Picker.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Colour_Picker.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Colour_Picker.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Colour_Picker.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Colour_Picker.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Colour_Picker.pgbottomlcorner.Height = windowbordersize
            Colour_Picker.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Colour_Picker.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Colour_Picker.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Colour_Picker.pgbottomrcorner.Height = windowbordersize
        Else
            Colour_Picker.Close()
        End If

        If infobox.Visible = True Then
            infobox.titlebar.BackColor = titlebarcolour
            infobox.pgtoplcorner.BackColor = titlebarleftcornercolour
            infobox.pgtoprcorner.BackColor = titlebarrightcornercolour
            infobox.pgleft.BackColor = windowborderleftcolour
            infobox.pgleft.BackgroundImage = skinwindowborderleft(0)
            infobox.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            infobox.pgright.BackColor = windowborderrightcolour
            infobox.pgright.BackgroundImage = skinwindowborderright(0)
            infobox.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            infobox.pgbottom.BackColor = windowborderbottomcolour
            infobox.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            infobox.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            infobox.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            infobox.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            infobox.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            infobox.pgbottomlcorner.Height = windowbordersize
            infobox.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            infobox.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            infobox.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            infobox.pgbottomrcorner.Height = windowbordersize
        Else
            infobox.Close()
        End If

        If Pong.Visible = True Then
            Pong.titlebar.BackColor = titlebarcolour
            Pong.pgtoplcorner.BackColor = titlebarleftcornercolour
            Pong.pgtoprcorner.BackColor = titlebarrightcornercolour
            Pong.pgleft.BackColor = windowborderleftcolour
            Pong.pgleft.BackgroundImage = skinwindowborderleft(0)
            Pong.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Pong.pgright.BackColor = windowborderrightcolour
            Pong.pgright.BackgroundImage = skinwindowborderright(0)
            Pong.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Pong.pgbottom.BackColor = windowborderbottomcolour
            Pong.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Pong.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Pong.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Pong.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Pong.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Pong.pgbottomlcorner.Height = windowbordersize
            Pong.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Pong.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Pong.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Pong.pgbottomrcorner.Height = windowbordersize
        Else
            Pong.Close()
        End If

        If File_Skimmer.Visible = True Then
            File_Skimmer.titlebar.BackColor = titlebarcolour
            File_Skimmer.pgtoplcorner.BackColor = titlebarleftcornercolour
            File_Skimmer.pgtoprcorner.BackColor = titlebarrightcornercolour
            File_Skimmer.pgleft.BackColor = windowborderleftcolour
            File_Skimmer.pgleft.BackgroundImage = skinwindowborderleft(0)
            File_Skimmer.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            File_Skimmer.pgright.BackColor = windowborderrightcolour
            File_Skimmer.pgright.BackgroundImage = skinwindowborderright(0)
            File_Skimmer.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            File_Skimmer.pgbottom.BackColor = windowborderbottomcolour
            File_Skimmer.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            File_Skimmer.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            File_Skimmer.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            File_Skimmer.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            File_Skimmer.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            File_Skimmer.pgbottomlcorner.Height = windowbordersize
            File_Skimmer.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            File_Skimmer.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            File_Skimmer.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            File_Skimmer.pgbottomrcorner.Height = windowbordersize
        Else
            File_Skimmer.Close()
        End If

        If TextPad.Visible = True Then
            TextPad.titlebar.BackColor = titlebarcolour
            TextPad.pgtoplcorner.BackColor = titlebarleftcornercolour
            TextPad.pgtoprcorner.BackColor = titlebarrightcornercolour
            TextPad.pgleft.BackColor = windowborderleftcolour
            TextPad.pgleft.BackgroundImage = skinwindowborderleft(0)
            TextPad.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            TextPad.pgright.BackColor = windowborderrightcolour
            TextPad.pgright.BackgroundImage = skinwindowborderright(0)
            TextPad.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            TextPad.pgbottom.BackColor = windowborderbottomcolour
            TextPad.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            TextPad.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            TextPad.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            TextPad.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            TextPad.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            TextPad.pgbottomlcorner.Height = windowbordersize
            TextPad.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            TextPad.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            TextPad.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            TextPad.pgbottomrcorner.Height = windowbordersize
        Else
            TextPad.Close()
        End If


        If File_Opener.Visible = True Then
            File_Opener.titlebar.BackColor = titlebarcolour
            File_Opener.pgtoplcorner.BackColor = titlebarleftcornercolour
            File_Opener.pgtoprcorner.BackColor = titlebarrightcornercolour
            File_Opener.pgleft.BackColor = windowborderleftcolour
            File_Opener.pgleft.BackgroundImage = skinwindowborderleft(0)
            File_Opener.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            File_Opener.pgright.BackColor = windowborderrightcolour
            File_Opener.pgright.BackgroundImage = skinwindowborderright(0)
            File_Opener.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            File_Opener.pgbottom.BackColor = windowborderbottomcolour
            File_Opener.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            File_Opener.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            File_Opener.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            File_Opener.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            File_Opener.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            File_Opener.pgbottomlcorner.Height = windowbordersize
            File_Opener.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            File_Opener.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            File_Opener.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            File_Opener.pgbottomrcorner.Height = windowbordersize
        Else
            File_Opener.Close()
        End If

        If File_Saver.Visible = True Then
            File_Saver.titlebar.BackColor = titlebarcolour
            File_Saver.pgtoplcorner.BackColor = titlebarleftcornercolour
            File_Saver.pgtoprcorner.BackColor = titlebarrightcornercolour
            File_Saver.pgleft.BackColor = windowborderleftcolour
            File_Saver.pgleft.BackgroundImage = skinwindowborderleft(0)
            File_Saver.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            File_Saver.pgright.BackColor = windowborderrightcolour
            File_Saver.pgright.BackgroundImage = skinwindowborderright(0)
            File_Saver.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            File_Saver.pgbottom.BackColor = windowborderbottomcolour
            File_Saver.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            File_Saver.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            File_Saver.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            File_Saver.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            File_Saver.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            File_Saver.pgbottomlcorner.Height = windowbordersize
            File_Saver.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            File_Saver.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            File_Saver.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            File_Saver.pgbottomrcorner.Height = windowbordersize
        Else
            File_Saver.Close()
        End If

        If Graphic_Picker.Visible = True Then
            Graphic_Picker.titlebar.BackColor = titlebarcolour
            Graphic_Picker.pgtoplcorner.BackColor = titlebarleftcornercolour
            Graphic_Picker.pgtoprcorner.BackColor = titlebarrightcornercolour
            Graphic_Picker.pgleft.BackColor = windowborderleftcolour
            Graphic_Picker.pgleft.BackgroundImage = skinwindowborderleft(0)
            Graphic_Picker.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Graphic_Picker.pgright.BackColor = windowborderrightcolour
            Graphic_Picker.pgright.BackgroundImage = skinwindowborderright(0)
            Graphic_Picker.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Graphic_Picker.pgbottom.BackColor = windowborderbottomcolour
            Graphic_Picker.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Graphic_Picker.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Graphic_Picker.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Graphic_Picker.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Graphic_Picker.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Graphic_Picker.pgbottomlcorner.Height = windowbordersize
            Graphic_Picker.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Graphic_Picker.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Graphic_Picker.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Graphic_Picker.pgbottomrcorner.Height = windowbordersize
        Else
            Graphic_Picker.Close()
        End If

        If Skin_Loader.Visible = True Then
            Skin_Loader.titlebar.BackColor = titlebarcolour
            Skin_Loader.pgtoplcorner.BackColor = titlebarleftcornercolour
            Skin_Loader.pgtoprcorner.BackColor = titlebarrightcornercolour
            Skin_Loader.pgleft.BackColor = windowborderleftcolour
            Skin_Loader.pgleft.BackgroundImage = skinwindowborderleft(0)
            Skin_Loader.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Skin_Loader.pgright.BackColor = windowborderrightcolour
            Skin_Loader.pgright.BackgroundImage = skinwindowborderright(0)
            Skin_Loader.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Skin_Loader.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Skin_Loader.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Skin_Loader.pgbottom.BackColor = windowborderbottomcolour
            Skin_Loader.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Skin_Loader.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Skin_Loader.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Skin_Loader.pgbottomlcorner.Height = windowbordersize
            Skin_Loader.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Skin_Loader.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Skin_Loader.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Skin_Loader.pgbottomrcorner.Height = windowbordersize
        Else
            Skin_Loader.Close()
        End If

        If ArtPad.Visible = True Then
            ArtPad.titlebar.BackColor = titlebarcolour
            ArtPad.pgtoplcorner.BackColor = titlebarleftcornercolour
            ArtPad.pgtoprcorner.BackColor = titlebarrightcornercolour
            ArtPad.pgleft.BackColor = windowborderleftcolour
            ArtPad.pgleft.BackgroundImage = skinwindowborderleft(0)
            ArtPad.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            ArtPad.pgright.BackColor = windowborderrightcolour
            ArtPad.pgright.BackgroundImage = skinwindowborderright(0)
            ArtPad.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            ArtPad.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            ArtPad.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            ArtPad.pgbottom.BackColor = windowborderbottomcolour
            ArtPad.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            ArtPad.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            ArtPad.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            ArtPad.pgbottomlcorner.Height = windowbordersize
            ArtPad.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            ArtPad.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            ArtPad.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            ArtPad.pgbottomrcorner.Height = windowbordersize
        Else
            ArtPad.Close()
        End If

        If Calculator.Visible = True Then
            Calculator.titlebar.BackColor = titlebarcolour
            Calculator.pgtoplcorner.BackColor = titlebarleftcornercolour
            Calculator.pgtoprcorner.BackColor = titlebarrightcornercolour
            Calculator.pgleft.BackColor = windowborderleftcolour
            Calculator.pgleft.BackgroundImage = skinwindowborderleft(0)
            Calculator.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Calculator.pgright.BackColor = windowborderrightcolour
            Calculator.pgright.BackgroundImage = skinwindowborderright(0)
            Calculator.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Calculator.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Calculator.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Calculator.pgbottom.BackColor = windowborderbottomcolour
            Calculator.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Calculator.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Calculator.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Calculator.pgbottomlcorner.Height = windowbordersize
            Calculator.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Calculator.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Calculator.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Calculator.pgbottomrcorner.Height = windowbordersize
        Else
            Calculator.Close()
        End If

        If Audio_Player.Visible = True Then
            Audio_Player.titlebar.BackColor = titlebarcolour
            Audio_Player.pgtoplcorner.BackColor = titlebarleftcornercolour
            Audio_Player.pgtoprcorner.BackColor = titlebarrightcornercolour
            Audio_Player.pgleft.BackColor = windowborderleftcolour
            Audio_Player.pgleft.BackgroundImage = skinwindowborderleft(0)
            Audio_Player.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Audio_Player.pgright.BackColor = windowborderrightcolour
            Audio_Player.pgright.BackgroundImage = skinwindowborderright(0)
            Audio_Player.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Audio_Player.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Audio_Player.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Audio_Player.pgbottom.BackColor = windowborderbottomcolour
            Audio_Player.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Audio_Player.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Audio_Player.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Audio_Player.pgbottomlcorner.Height = windowbordersize
            Audio_Player.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Audio_Player.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Audio_Player.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Audio_Player.pgbottomrcorner.Height = windowbordersize
        Else
            Audio_Player.Close()
        End If

        If Web_Browser.Visible = True Then
            Web_Browser.titlebar.BackColor = titlebarcolour
            Web_Browser.pgtoplcorner.BackColor = titlebarleftcornercolour
            Web_Browser.pgtoprcorner.BackColor = titlebarrightcornercolour
            Web_Browser.pgleft.BackColor = windowborderleftcolour
            Web_Browser.pgleft.BackgroundImage = skinwindowborderleft(0)
            Web_Browser.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Web_Browser.pgright.BackColor = windowborderrightcolour
            Web_Browser.pgright.BackgroundImage = skinwindowborderright(0)
            Web_Browser.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Web_Browser.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Web_Browser.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Web_Browser.pgbottom.BackColor = windowborderbottomcolour
            Web_Browser.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Web_Browser.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Web_Browser.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Web_Browser.pgbottomlcorner.Height = windowbordersize
            Web_Browser.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Web_Browser.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Web_Browser.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Web_Browser.pgbottomrcorner.Height = windowbordersize
        Else
            Web_Browser.Close()
        End If

        If Video_Player.Visible = True Then
            Video_Player.titlebar.BackColor = titlebarcolour
            Video_Player.pgtoplcorner.BackColor = titlebarleftcornercolour
            Video_Player.pgtoprcorner.BackColor = titlebarrightcornercolour
            Video_Player.pgleft.BackColor = windowborderleftcolour
            Video_Player.pgleft.BackgroundImage = skinwindowborderleft(0)
            Video_Player.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Video_Player.pgright.BackColor = windowborderrightcolour
            Video_Player.pgright.BackgroundImage = skinwindowborderright(0)
            Video_Player.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Video_Player.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Video_Player.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Video_Player.pgbottom.BackColor = windowborderbottomcolour
            Video_Player.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Video_Player.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Video_Player.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Video_Player.pgbottomlcorner.Height = windowbordersize
            Video_Player.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Video_Player.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Video_Player.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Video_Player.pgbottomrcorner.Height = windowbordersize
        Else
            Video_Player.Close()
        End If

        If Name_Changer.Visible = True Then
            Name_Changer.titlebar.BackColor = titlebarcolour
            Name_Changer.pgtoplcorner.BackColor = titlebarleftcornercolour
            Name_Changer.pgtoprcorner.BackColor = titlebarrightcornercolour
            Name_Changer.pgleft.BackColor = windowborderleftcolour
            Name_Changer.pgleft.BackgroundImage = skinwindowborderleft(0)
            Name_Changer.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Name_Changer.pgright.BackColor = windowborderrightcolour
            Name_Changer.pgright.BackgroundImage = skinwindowborderright(0)
            Name_Changer.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Name_Changer.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Name_Changer.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Name_Changer.pgbottom.BackColor = windowborderbottomcolour
            Name_Changer.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Name_Changer.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Name_Changer.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Name_Changer.pgbottomlcorner.Height = windowbordersize
            Name_Changer.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Name_Changer.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Name_Changer.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Name_Changer.pgbottomrcorner.Height = windowbordersize
        Else
            Name_Changer.Close()
        End If

        If Icon_Manager.Visible = True Then
            Icon_Manager.titlebar.BackColor = titlebarcolour
            Icon_Manager.pgtoplcorner.BackColor = titlebarleftcornercolour
            Icon_Manager.pgtoprcorner.BackColor = titlebarrightcornercolour
            Icon_Manager.pgleft.BackColor = windowborderleftcolour
            Icon_Manager.pgleft.BackgroundImage = skinwindowborderleft(0)
            Icon_Manager.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Icon_Manager.pgright.BackColor = windowborderrightcolour
            Icon_Manager.pgright.BackgroundImage = skinwindowborderright(0)
            Icon_Manager.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Icon_Manager.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Icon_Manager.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Icon_Manager.pgbottom.BackColor = windowborderbottomcolour
            Icon_Manager.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Icon_Manager.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Icon_Manager.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Icon_Manager.pgbottomlcorner.Height = windowbordersize
            Icon_Manager.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Icon_Manager.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Icon_Manager.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Icon_Manager.pgbottomrcorner.Height = windowbordersize
        Else
            Icon_Manager.Close()
        End If

        If Bitnote_Wallet.Visible = True Then
            Bitnote_Wallet.titlebar.BackColor = titlebarcolour
            Bitnote_Wallet.pgtoplcorner.BackColor = titlebarleftcornercolour
            Bitnote_Wallet.pgtoprcorner.BackColor = titlebarrightcornercolour
            Bitnote_Wallet.pgleft.BackColor = windowborderleftcolour
            Bitnote_Wallet.pgleft.BackgroundImage = skinwindowborderleft(0)
            Bitnote_Wallet.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Bitnote_Wallet.pgright.BackColor = windowborderrightcolour
            Bitnote_Wallet.pgright.BackgroundImage = skinwindowborderright(0)
            Bitnote_Wallet.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Bitnote_Wallet.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Bitnote_Wallet.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Bitnote_Wallet.pgbottom.BackColor = windowborderbottomcolour
            Bitnote_Wallet.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Bitnote_Wallet.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Bitnote_Wallet.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Bitnote_Wallet.pgbottomlcorner.Height = windowbordersize
            Bitnote_Wallet.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Bitnote_Wallet.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Bitnote_Wallet.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Bitnote_Wallet.pgbottomrcorner.Height = windowbordersize
        Else
            Bitnote_Wallet.Close()
        End If

        If Bitnote_Digger.Visible = True Then
            Bitnote_Digger.titlebar.BackColor = titlebarcolour
            Bitnote_Digger.pgtoplcorner.BackColor = titlebarleftcornercolour
            Bitnote_Digger.pgtoprcorner.BackColor = titlebarrightcornercolour
            Bitnote_Digger.pgleft.BackColor = windowborderleftcolour
            Bitnote_Digger.pgleft.BackgroundImage = skinwindowborderleft(0)
            Bitnote_Digger.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Bitnote_Digger.pgright.BackColor = windowborderrightcolour
            Bitnote_Digger.pgright.BackgroundImage = skinwindowborderright(0)
            Bitnote_Digger.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Bitnote_Digger.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Bitnote_Digger.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Bitnote_Digger.pgbottom.BackColor = windowborderbottomcolour
            Bitnote_Digger.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Bitnote_Digger.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Bitnote_Digger.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Bitnote_Digger.pgbottomlcorner.Height = windowbordersize
            Bitnote_Digger.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Bitnote_Digger.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Bitnote_Digger.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Bitnote_Digger.pgbottomrcorner.Height = windowbordersize
        Else
            Bitnote_Digger.Close()
        End If

        If Skinshifter.Visible = True Then
            Skinshifter.titlebar.BackColor = titlebarcolour
            Skinshifter.pgtoplcorner.BackColor = titlebarleftcornercolour
            Skinshifter.pgtoprcorner.BackColor = titlebarrightcornercolour
            Skinshifter.pgleft.BackColor = windowborderleftcolour
            Skinshifter.pgleft.BackgroundImage = skinwindowborderleft(0)
            Skinshifter.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Skinshifter.pgright.BackColor = windowborderrightcolour
            Skinshifter.pgright.BackgroundImage = skinwindowborderright(0)
            Skinshifter.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Skinshifter.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Skinshifter.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Skinshifter.pgbottom.BackColor = windowborderbottomcolour
            Skinshifter.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Skinshifter.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Skinshifter.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Skinshifter.pgbottomlcorner.Height = windowbordersize
            Skinshifter.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Skinshifter.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Skinshifter.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Skinshifter.pgbottomrcorner.Height = windowbordersize
        Else
            Skinshifter.Close()
        End If

        If Shiftnet.Visible = True Then
            Shiftnet.titlebar.BackColor = titlebarcolour
            Shiftnet.pgtoplcorner.BackColor = titlebarleftcornercolour
            Shiftnet.pgtoprcorner.BackColor = titlebarrightcornercolour
            Shiftnet.pgleft.BackColor = windowborderleftcolour
            Shiftnet.pgleft.BackgroundImage = skinwindowborderleft(0)
            Shiftnet.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Shiftnet.pgright.BackColor = windowborderrightcolour
            Shiftnet.pgright.BackgroundImage = skinwindowborderright(0)
            Shiftnet.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Shiftnet.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Shiftnet.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Shiftnet.pgbottom.BackColor = windowborderbottomcolour
            Shiftnet.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Shiftnet.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Shiftnet.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Shiftnet.pgbottomlcorner.Height = windowbordersize
            Shiftnet.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Shiftnet.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Shiftnet.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Shiftnet.pgbottomrcorner.Height = windowbordersize
        Else
            Shiftnet.Close()
        End If

        If Downloader.Visible = True Then
            Downloader.titlebar.BackColor = titlebarcolour
            Downloader.pgtoplcorner.BackColor = titlebarleftcornercolour
            Downloader.pgtoprcorner.BackColor = titlebarrightcornercolour
            Downloader.pgleft.BackColor = windowborderleftcolour
            Downloader.pgleft.BackgroundImage = skinwindowborderleft(0)
            Downloader.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Downloader.pgright.BackColor = windowborderrightcolour
            Downloader.pgright.BackgroundImage = skinwindowborderright(0)
            Downloader.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Downloader.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Downloader.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Downloader.pgbottom.BackColor = windowborderbottomcolour
            Downloader.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Downloader.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Downloader.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Downloader.pgbottomlcorner.Height = windowbordersize
            Downloader.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Downloader.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Downloader.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Downloader.pgbottomrcorner.Height = windowbordersize
        Else
            Downloader.Close()
        End If

        If template.Visible = True Then
            template.titlebar.BackColor = titlebarcolour
            template.pgtoplcorner.BackColor = titlebarleftcornercolour
            template.pgtoprcorner.BackColor = titlebarrightcornercolour
            template.pgleft.BackColor = windowborderleftcolour
            template.pgleft.BackgroundImage = skinwindowborderleft(0)
            template.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            template.pgright.BackColor = windowborderrightcolour
            template.pgright.BackgroundImage = skinwindowborderright(0)
            template.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            template.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            template.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            template.pgbottom.BackColor = windowborderbottomcolour
            template.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            template.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            template.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            template.pgbottomlcorner.Height = windowbordersize
            template.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            template.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            template.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            template.pgbottomrcorner.Height = windowbordersize
        Else
            template.Close()
        End If

        If Terminal.Visible = True Then
            Terminal.titlebar.BackColor = titlebarcolour
            Terminal.pgtoplcorner.BackColor = titlebarleftcornercolour
            Terminal.pgtoprcorner.BackColor = titlebarrightcornercolour
            Terminal.pgleft.BackColor = windowborderleftcolour
            Terminal.pgleft.BackgroundImage = skinwindowborderleft(0)
            Terminal.pgleft.BackgroundImageLayout = skinwindowborderleftstyle
            Terminal.pgright.BackColor = windowborderrightcolour
            Terminal.pgright.BackgroundImage = skinwindowborderright(0)
            Terminal.pgright.BackgroundImageLayout = skinwindowborderrightstyle
            Terminal.pgbottom.BackColor = windowborderbottomcolour
            Terminal.pgbottom.BackgroundImage = skinwindowborderbottom(0)
            Terminal.pgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
            Terminal.pgbottomlcorner.BackColor = windowborderbottomleftcolour
            Terminal.pgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
            Terminal.pgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
            Terminal.pgbottomlcorner.Height = windowbordersize
            Terminal.pgbottomrcorner.BackColor = windowborderbottomrightcolour
            Terminal.pgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
            Terminal.pgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
            Terminal.pgbottomrcorner.Height = windowbordersize
        Else
            Terminal.Close()
        End If
    End Sub

    Public Sub setupiconprocess(ByVal location As String, ByRef imagetochange As Image)
        If IO.File.Exists("C:\ShiftOS\Shiftum42\Icons\" & location & ".pic") Then
            imagetochange = GetImage("C:\ShiftOS\Shiftum42\Icons\" & location & ".pic")
        End If
    End Sub

    Public Sub setupicons()

        iconmanagericondatalines = IO.File.ReadAllLines("C:\ShiftOS\Shiftum42\Icons\icondata.dat")
        titlebariconsize = iconmanagericondatalines(0)
        panelbuttoniconsize = iconmanagericondatalines(1)
        launchericonsize = iconmanagericondatalines(2)

        setupiconprocess("titlebarartpadicon", artpadicontitlebar)
        setupiconprocess("titlebaraudioplayericon", audioplayericontitlebar)
        setupiconprocess("titlebarcalculatoricon", calculatoricontitlebar)
        setupiconprocess("titlebarclockicon", clockicontitlebar)
        setupiconprocess("titlebarcolourpickericon", colourpickericontitlebar)
        setupiconprocess("titlebarfileopenericon", fileopenericontitlebar)
        setupiconprocess("titlebarfilesavericon", filesavericontitlebar)
        setupiconprocess("titlebarfileskimmericon", fileskimmericontitlebar)
        setupiconprocess("titlebargraphicpickericon", graphicpickericontitlebar)
        setupiconprocess("titlebarinfoboxicon", infoboxicontitlebar)
        setupiconprocess("titlebarknowledgeinputicon", knowledgeinputicontitlebar)
        setupiconprocess("titlebarpongicon", pongicontitlebar)
        setupiconprocess("titlebarshiftericon", shiftericontitlebar)
        setupiconprocess("titlebarshiftoriumicon", shiftoriumicontitlebar)
        setupiconprocess("titlebarskinloadericon", skinloadericontitlebar)
        setupiconprocess("titlebarterminalicon", terminalicontitlebar)
        setupiconprocess("titlebartextpadicon", textpadicontitlebar)
        setupiconprocess("titlebarvideoplayericon", videoplayericontitlebar)
        setupiconprocess("titlebarwebbrowsericon", webbrowsericontitlebar)
        setupiconprocess("titlebarnamechangericon", namechangericontitlebar)
        setupiconprocess("titlebariconmanagericon", iconmanagericontitlebar)
        setupiconprocess("titlebarbitnotewalleticon", bitnotewalleticontitlebar)
        setupiconprocess("titlebarbitnotediggericon", bitnotediggericontitlebar)
        setupiconprocess("titlebarbitnotediggericon", bitnotediggericontitlebar)

        setupiconprocess("panelbuttonartpadicon", artpadiconpanelbutton)
        setupiconprocess("panelbuttonaudioplayericon", audioplayericonpanelbutton)
        setupiconprocess("panelbuttoncalculatoricon", calculatoriconpanelbutton)
        setupiconprocess("panelbuttonclockicon", clockiconpanelbutton)
        setupiconprocess("panelbuttoncolourpickericon", colourpickericonpanelbutton)
        setupiconprocess("panelbuttonfileopenericon", fileopenericonpanelbutton)
        setupiconprocess("panelbuttonfilesavericon", filesavericonpanelbutton)
        setupiconprocess("panelbuttonfileskimmericon", fileskimmericonpanelbutton)
        setupiconprocess("panelbuttongraphicpickericon", graphicpickericonpanelbutton)
        setupiconprocess("panelbuttoninfoboxicon", infoboxiconpanelbutton)
        setupiconprocess("panelbuttonknowledgeinputicon", knowledgeinputiconpanelbutton)
        setupiconprocess("panelbuttonpongicon", pongiconpanelbutton)
        setupiconprocess("panelbuttonshiftericon", shiftericonpanelbutton)
        setupiconprocess("panelbuttonshiftoriumicon", shiftoriumiconpanelbutton)
        setupiconprocess("panelbuttonskinloadericon", skinloadericonpanelbutton)
        setupiconprocess("panelbuttonterminalicon", terminaliconpanelbutton)
        setupiconprocess("panelbuttontextpadicon", textpadiconpanelbutton)
        setupiconprocess("panelbuttonvideoplayericon", videoplayericonpanelbutton)
        setupiconprocess("panelbuttonwebbrowsericon", webbrowsericonpanelbutton)
        setupiconprocess("panelbuttonnamechangericon", namechangericonpanelbutton)
        setupiconprocess("panelbuttoniconmanagericon", iconmanagericonpanelbutton)
        setupiconprocess("panelbuttonbitnotewalleticon", bitnotewalleticonpanelbutton)
        setupiconprocess("panelbuttonbitnotediggericon", bitnotediggericonpanelbutton)
        setupiconprocess("panelbuttonbitnotediggericon", bitnotediggericonpanelbutton)

        setupiconprocess("launcherartpadicon", artpadiconlauncher)
        setupiconprocess("launcheraudioplayericon", audioplayericonlauncher)
        setupiconprocess("launchercalculatoricon", calculatoriconlauncher)
        setupiconprocess("launcherclockicon", clockiconlauncher)
        setupiconprocess("launchercolourpickericon", colourpickericonlauncher)
        setupiconprocess("launcherfileopenericon", fileopenericonlauncher)
        setupiconprocess("launcherfilesavericon", filesavericonlauncher)
        setupiconprocess("launcherfileskimmericon", fileskimmericonlauncher)
        setupiconprocess("launchergraphicpickericon", graphicpickericonlauncher)
        setupiconprocess("launcherinfoboxicon", infoboxiconlauncher)
        setupiconprocess("launcherknowledgeinputicon", knowledgeinputiconlauncher)
        setupiconprocess("launcherpongicon", pongiconlauncher)
        setupiconprocess("launchershiftericon", shiftericonlauncher)
        setupiconprocess("launchershiftoriumicon", shiftoriumiconlauncher)
        setupiconprocess("launcherskinloadericon", skinloadericonlauncher)
        setupiconprocess("launcherterminalicon", terminaliconlauncher)
        setupiconprocess("launchertextpadicon", textpadiconlauncher)
        setupiconprocess("launchervideoplayericon", videoplayericonlauncher)
        setupiconprocess("launcherwebbrowsericon", webbrowsericonlauncher)
        setupiconprocess("launchernamechangericon", namechangericonlauncher)
        setupiconprocess("launchericonmanagericon", iconmanagericonlauncher)
        setupiconprocess("launcherbitnotewalleticon", bitnotewalleticonlauncher)
        setupiconprocess("launcherbitnotediggericon", bitnotediggericonlauncher)
        setupiconprocess("launcherbitnotediggericon", bitnotediggericonlauncher)

        setupiconprocess("launchershutdownicon", shutdowniconlauncher)
    End Sub

    Private Sub KnowledgeInputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KnowledgeInputToolStripMenuItem.Click
        closeeverything()
        log = log & My.Computer.Clock.LocalTime & " User opened Knowledge Input from the app launcher" & Environment.NewLine
        Knowledge_Input.Show()
        Knowledge_Input.BringToFront()
    End Sub

    Private Sub ShiftoriumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShiftoriumToolStripMenuItem.Click
        closeeverything()
        log = log & My.Computer.Clock.LocalTime & " User opened Shiftorium from the app launcher" & Environment.NewLine
        Shiftorium.Show()
        Shiftorium.BringToFront()
    End Sub

    Private Sub ClockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClockToolStripMenuItem.Click
        closeeverything()
        log = log & My.Computer.Clock.LocalTime & " User opened Clock from the app launcher" & Environment.NewLine
        Clock.Show()
        Clock.BringToFront()
    End Sub

    Private Sub TerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalToolStripMenuItem.Click
        closeeverything()
        log = log & My.Computer.Clock.LocalTime & " User opened Terminal from the app launcher" & Environment.NewLine
        Terminal.Show()
        Terminal.BringToFront()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculatorToolStripMenuItem.Click
        closeeverything()
        Calculator.Show()
        Calculator.BringToFront()
    End Sub

    Private Sub ApplicationsToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.MouseEnter
        Me.Focus()
        ToolStripManager.Renderer = New MyToolStripRenderer()
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownToolStripMenuItem.Click
        Terminal.Show()
        Terminal.BringToFront()
        log = log & My.Computer.Clock.LocalTime & " User Shut Down ShiftOS from the app launcher" & Environment.NewLine
        shutdownshiftos()
    End Sub

    Private Sub clocktick_Tick(sender As Object, e As EventArgs) Handles clocktick.Tick
        setclocktime()
    End Sub

    Private Sub setclocktime()
        If boughtsplitsecondtime = True Then
            paneltimetext.Text = TimeOfDay
        Else
            If boughtminuteaccuracytime = True Then
                If Date.Now.Hour < 12 Then
                    paneltimetext.Text = TimeOfDay.Hour & ":" & Format(TimeOfDay.Minute, "00") & " AM"
                Else
                    paneltimetext.Text = TimeOfDay.Hour - 12 & ":" & Format(TimeOfDay.Minute, "00") & " PM"
                End If
            Else
                If boughtpmandam = True Then
                    If Date.Now.Hour < 12 Then
                        paneltimetext.Text = TimeOfDay.Hour & " AM"
                    Else
                        paneltimetext.Text = TimeOfDay.Hour - 12 & " PM"
                    End If
                Else
                    If boughthourspastmidnight = True Then
                        paneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60 / 60)
                    Else
                        If boughtminutespastmidnight = True Then
                            paneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60)
                        Else
                            If boughtsecondspastmidnight = True Then
                                paneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ShifterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShifterToolStripMenuItem.Click
        closeeverything()
        log = log & My.Computer.Clock.LocalTime & " User opened Shifter from the app launcher" & Environment.NewLine
        Shifter.Show()
        Shifter.BringToFront()
    End Sub

    Private Sub PongToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PongToolStripMenuItem.Click
        closeeverything()
        Pong.Show()
        Pong.BringToFront()
    End Sub

    Private Sub FileSkimmerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileSkimmerToolStripMenuItem.Click
        closeeverything()
        File_Skimmer.Show()
        File_Skimmer.BringToFront()
    End Sub

    Private Sub TextPadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextPadToolStripMenuItem.Click
        closeeverything()
        TextPad.Show()
        TextPad.BringToFront()
    End Sub

    Private Sub SkinLoaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkinLoaderToolStripMenuItem.Click
        closeeverything()
        Skin_Loader.Show()
        Skin_Loader.BringToFront()
    End Sub

    Private Sub ArtpadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtpadToolStripMenuItem.Click
        closeeverything()
        ArtPad.Show()
        ArtPad.BringToFront()
    End Sub

    Private Sub AudioplayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AudioplayerToolStripMenuItem.Click
        closeeverything()
        Audio_Player.Show()
        Audio_Player.BringToFront()
    End Sub

    Private Sub WebBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebBrowserToolStripMenuItem.Click
        closeeverything()
        Web_Browser.Show()
        Web_Browser.BringToFront()
        If Web_Browser.Location.Y <= 0 Then Web_Browser.Location = New Point(Web_Browser.Location.X, Web_Browser.Location.Y + 5000)
        Web_Browser.resettitlebar()
    End Sub

    Private Sub VideoplayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VideoplayerToolStripMenuItem.Click
        closeeverything()
        Video_Player.Show()
        Video_Player.BringToFront()
    End Sub

    Private Sub NameChangerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NameChangerToolStripMenuItem.Click
        closeeverything()
        Name_Changer.Show()
        Name_Changer.BringToFront()
    End Sub

    Private Sub IconManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IconManagerToolStripMenuItem.Click
        closeeverything()
        Icon_Manager.Show()
        Icon_Manager.BringToFront()
    End Sub

    Private Sub bitnotewalletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitnoteWalletToolStripMenuItem.Click
        closeeverything()
        Bitnote_Wallet.Show()
        Bitnote_Wallet.BringToFront()
    End Sub

    Private Sub bitnotediggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitnoteDiggerToolStripMenuItem.Click
        closeeverything()
        Bitnote_Digger.Show()
        Bitnote_Digger.BringToFront()
    End Sub

    Private Sub SkinshifterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkinShifterToolStripMenuItem.Click
        closeeverything()
        Skinshifter.Show()
        Skinshifter.BringToFront()
    End Sub

    Private Sub ShiftnetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShiftnetToolStripMenuItem.Click
        closeeverything()
        Shiftnet.Show()
        Shiftnet.BringToFront()
    End Sub

    Private Sub autosave_Tick(sender As Object, e As EventArgs) Handles autosave.Tick
        savegame()
    End Sub

    Public Sub ApplicationsToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles ApplicationsToolStripMenuItem.Paint
        If skinapplauncherbutton(0) Is Nothing Then
        Else
            e.Graphics.DrawImage(skinapplauncherbutton(0), 0, 0, skinapplauncherbutton(0).Width, skinapplauncherbutton(0).Height)
        End If
    End Sub

    Public Sub minimizeprogram(ByVal whatprogram As Form)
        If whatprogram.Location.Y > 0 Then
            whatprogram.Location = New Point(whatprogram.Location.X, whatprogram.Location.Y - 5000)
        Else
            whatprogram.Location = New Point(whatprogram.Location.X, whatprogram.Location.Y + 5000)
            whatprogram.BringToFront()
        End If
    End Sub

    Private Sub pnlpanelbuttonclock_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonclock.Click, tbclockicon.Click, tbclocktext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Clock)
        End If
    End Sub

    Private Sub pnlpanelbuttoncolourpicker_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttoncolourpicker.Click, tbcolourpickericon.Click, tbcolourpickertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Colour_Picker)
        End If
    End Sub

    Private Sub pnlpanelbuttonfileopener_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonfileopener.Click, tbfileopenericon.Click, tbfileopenertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(File_Opener)
        End If
    End Sub

    Private Sub pnlpanelbuttonfilesaver_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonfilesaver.Click, tbfilesavericon.Click, tbfilesavertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(File_Saver)
        End If
    End Sub

    Private Sub pnlpanelbuttonfileskimmer_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonfileskimmer.Click, tbfileskimmericon.Click, tbfileskimmertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(File_Skimmer)
        End If
    End Sub

    Private Sub pnlpanelbuttongraphicpicker_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttongraphicpicker.Click, tbgraphicpickericon.Click, tbgraphicpickertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Graphic_Picker)
        End If
    End Sub

    Private Sub pnlpanelbuttoninfobox_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttoninfobox.Click, tbinfoboxicon.Click, tbinfoboxtext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(infobox)
        End If
    End Sub

    Private Sub pnlpanelbuttonknowledgeinput_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonknowledgeinput.Click, tbknowledgeinputicon.Click, tbknowledgeinputtext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Knowledge_Input)
        End If
    End Sub

    Private Sub pnlpanelbuttonpong_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonpong.Click, tbpongicon.Click, tbpongtext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Pong)
        End If
    End Sub

    Private Sub pnlpanelbuttonshifter_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonshifter.Click, tbshiftericon.Click, tbshiftertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Shifter)
        End If
    End Sub

    Private Sub pnlpanelbuttonshiftorium_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonshiftorium.Click, tbshiftoriumicon.Click, tbshiftoriumtext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Shiftorium)
        End If
    End Sub

    Private Sub pnlpanelbuttonskinloader_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonskinloader.Click, tbskinloadericon.Click, tbskinloadertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Skin_Loader)
        End If
    End Sub

    Private Sub pnlpanelbuttonterminal_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonterminal.Click, tbterminalicon.Click, tbterminaltext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Terminal)
        End If
    End Sub

    Private Sub pnlpanelbuttontextpad_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttontextpad.Click, tbtextpadicon.Click, tbtextpadtext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(TextPad)
        End If
    End Sub

    Private Sub pnlpanelbuttonartpad_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonartpad.Click, tbartpadicon.Click, tbartpadtext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(ArtPad)
        End If
    End Sub

    Private Sub pnlpanelbuttoncalculator_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttoncalculator.Click, tbcalculatoricon.Click, tbcalculatortext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Calculator)
        End If
    End Sub

    Private Sub pnlpanelbuttonaudioplayer_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonaudioplayer.Click, tbaudioplayericon.Click, tbaudioplayertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Audio_Player)
        End If
    End Sub

    Private Sub pnlpanelbuttonwebbrowser_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonwebbrowser.Click, tbwebbrowsericon.Click, tbwebbrowsertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Web_Browser)
        End If
    End Sub

    Private Sub pnlpanelbuttonvideoplayer_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonvideoplayer.Click, tbvideoplayericon.Click, tbvideoplayertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Video_Player)
        End If
    End Sub

    Private Sub pnlpanelbuttonnamechanger_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonnamechanger.Click, tbnamechangericon.Click, tbnamechangertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Name_Changer)
        End If
    End Sub

    Private Sub pnlpanelbuttoniconmanager_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttoniconmanager.Click, tbiconmanagericon.Click, tbiconmanagertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Icon_Manager)
        End If
    End Sub

    Private Sub pnlpanelbuttonbitnotewallet_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonbitnotewallet.Click, tbbitnotewalleticon.Click, tbbitnotewallettext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Bitnote_Wallet)
        End If
    End Sub

    Private Sub pnlpanelbuttonbitnotedigger_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonbitnotedigger.Click, tbbitnotediggericon.Click, tbbitnotediggertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Bitnote_Digger)
        End If
    End Sub

    Private Sub pnlpanelbuttonskinshifter_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonskinshifter.Click, tbskinshiftericon.Click, tbskinshiftertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Skinshifter)
        End If
    End Sub

    Private Sub pnlpanelbuttonShiftnet_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttonshiftnet.Click, tbshiftneticon.Click, tbshiftnettext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Shiftnet)
        End If
    End Sub

    Private Sub pnlpanelbuttonDownloader_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttondownloader.Click, tbdownloadericon.Click, tbdownloadertext.Click
        If boughtusefulpanelbuttons = True Then
            minimizeprogram(Downloader)
        End If
    End Sub
End Class