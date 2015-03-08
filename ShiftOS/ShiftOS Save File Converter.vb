Public Class ShiftOS_Save_File_Converter
    Dim loadlines(2000) As String
    Public ShiftOSPath As String = "C:\ShiftOS\"

    'Required for encryption of save files
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer
    Public Const sSecretKey As String = "Password"

    Private Sub btnconvert_Click(sender As Object, e As EventArgs) Handles btnconvert.Click

        'This converter works by loading the 0.0.7 save file with old 0.0.7 code, then calling the shiftosdesktop.savegame sub. This saves the old data in new format since it is loaded into public variables as well as saving the new stuff with their default values.

        loadold()
        Me.Close()
    End Sub

    Private Sub loadold()
        If IO.File.ReadAllText("C:/ShiftOS/Shiftum42/HDAccess.sft") = "0.0.7" Then
            File_Crypt.DecryptFile("C:/ShiftOS/Shiftum42/SKernal.sft", ShiftOSPath + "Shiftum42\Drivers\HDD.dri", sSecretKey)
            loadlines = IO.File.ReadAllLines(ShiftOSPath + "Shiftum42\Drivers\HDD.dri")

            If loadlines(0) = 11 Then ShiftOSDesktop.boughttitlebar = True Else ShiftOSDesktop.boughttitlebar = False
            If loadlines(1) = 11 Then ShiftOSDesktop.boughtgray = True Else ShiftOSDesktop.boughtgray = False
            If loadlines(2) = 11 Then ShiftOSDesktop.boughtsecondspastmidnight = True Else ShiftOSDesktop.boughtsecondspastmidnight = False
            If loadlines(3) = 11 Then ShiftOSDesktop.boughtminutespastmidnight = True Else ShiftOSDesktop.boughtminutespastmidnight = False
            If loadlines(4) = 11 Then ShiftOSDesktop.boughthourspastmidnight = True Else ShiftOSDesktop.boughthourspastmidnight = False
            If loadlines(5) = 11 Then ShiftOSDesktop.boughtcustomusername = True Else ShiftOSDesktop.boughtcustomusername = False
            If loadlines(6) = 11 Then ShiftOSDesktop.boughtwindowsanywhere = True Else ShiftOSDesktop.boughtwindowsanywhere = False
            If loadlines(7) = 11 Then ShiftOSDesktop.boughtmultitasking = True Else ShiftOSDesktop.boughtmultitasking = False
            If loadlines(8) = 11 Then ShiftOSDesktop.boughtautoscrollterminal = True Else ShiftOSDesktop.boughtautoscrollterminal = False
            ShiftOSDesktop.codepoints = loadlines(9)
            If loadlines(10) = 11 Then ShiftOSDesktop.boughtmovablewindows = True Else ShiftOSDesktop.boughtmovablewindows = False
            If loadlines(11) = 11 Then ShiftOSDesktop.boughtdraggablewindows = True Else ShiftOSDesktop.boughtdraggablewindows = False
            If loadlines(12) = 11 Then ShiftOSDesktop.boughtwindowborders = True Else ShiftOSDesktop.boughtwindowborders = False
            If loadlines(13) = 11 Then ShiftOSDesktop.boughtpmandam = True Else ShiftOSDesktop.boughtpmandam = False
            If loadlines(14) = 11 Then ShiftOSDesktop.boughtminuteaccuracytime = True Else ShiftOSDesktop.boughtminuteaccuracytime = False
            If loadlines(15) = 11 Then ShiftOSDesktop.boughtsplitsecondtime = True Else ShiftOSDesktop.boughtsplitsecondtime = False
            If loadlines(16) = 11 Then ShiftOSDesktop.boughttitletext = True Else ShiftOSDesktop.boughttitletext = False
            If loadlines(17) = 11 Then ShiftOSDesktop.boughtclosebutton = True Else ShiftOSDesktop.boughtclosebutton = False
            If loadlines(18) = 11 Then ShiftOSDesktop.boughtdesktoppanel = True Else ShiftOSDesktop.boughtdesktoppanel = False
            If loadlines(19) = 11 Then ShiftOSDesktop.boughtclock = True Else ShiftOSDesktop.boughtclock = False
            If loadlines(20) = 11 Then ShiftOSDesktop.boughtwindowedterminal = True Else ShiftOSDesktop.boughtwindowedterminal = False
            If loadlines(21) = 11 Then ShiftOSDesktop.boughtapplaunchermenu = True Else ShiftOSDesktop.boughtapplaunchermenu = False
            If loadlines(22) = 11 Then ShiftOSDesktop.boughtalknowledgeinput = True Else ShiftOSDesktop.boughtalknowledgeinput = False
            If loadlines(23) = 11 Then ShiftOSDesktop.boughtalclock = True Else ShiftOSDesktop.boughtalclock = False
            If loadlines(24) = 11 Then ShiftOSDesktop.boughtalshiftorium = True Else ShiftOSDesktop.boughtalshiftorium = False
            If loadlines(25) = 11 Then ShiftOSDesktop.boughtapplaunchershutdown = True Else ShiftOSDesktop.boughtapplaunchershutdown = False
            If loadlines(26) = 11 Then ShiftOSDesktop.boughtdesktoppanelclock = True Else ShiftOSDesktop.boughtdesktoppanelclock = False
            If loadlines(27) = 11 Then ShiftOSDesktop.boughtterminalscrollbar = True Else ShiftOSDesktop.boughtterminalscrollbar = False
            If loadlines(28) = 11 Then ShiftOSDesktop.boughtkiaddons = True Else ShiftOSDesktop.boughtkiaddons = False
            If loadlines(29) = 11 Then ShiftOSDesktop.boughtkicarbrands = True Else ShiftOSDesktop.boughtkicarbrands = False
            If loadlines(30) = 11 Then ShiftOSDesktop.boughtkigameconsoles = True Else ShiftOSDesktop.boughtkigameconsoles = False
            ShiftOSDesktop.username = loadlines(31)
            If loadlines(32) = 11 Then ShiftOSDesktop.terminalfullscreen = True Else ShiftOSDesktop.terminalfullscreen = False
            If loadlines(33) = 11 Then ShiftOSDesktop.boughtshifter = True Else ShiftOSDesktop.boughtshifter = False
            If loadlines(34) = 11 Then ShiftOSDesktop.boughtalshifter = True Else ShiftOSDesktop.boughtalshifter = False
            If loadlines(35) = 11 Then ShiftOSDesktop.boughtrollupcommand = True Else ShiftOSDesktop.boughtrollupcommand = False
            If loadlines(36) = 11 Then ShiftOSDesktop.boughtrollupbutton = True Else ShiftOSDesktop.boughtrollupbutton = False
            If loadlines(37) = 11 Then ShiftOSDesktop.boughtshiftdesktop = True Else ShiftOSDesktop.boughtshiftdesktop = False
            If loadlines(38) = 11 Then ShiftOSDesktop.boughtshiftpanelclock = True Else ShiftOSDesktop.boughtshiftpanelclock = False
            If loadlines(39) = 11 Then ShiftOSDesktop.boughtshiftapplauncher = True Else ShiftOSDesktop.boughtshiftapplauncher = False
            If loadlines(40) = 11 Then ShiftOSDesktop.boughtshiftdesktoppanel = True Else ShiftOSDesktop.boughtshiftdesktoppanel = False
            If loadlines(41) = 11 Then ShiftOSDesktop.boughtshifttitlebar = True Else ShiftOSDesktop.boughtshifttitlebar = False
            If loadlines(42) = 11 Then ShiftOSDesktop.boughtshifttitletext = True Else ShiftOSDesktop.boughtshifttitletext = False
            If loadlines(43) = 11 Then ShiftOSDesktop.boughtshifttitlebuttons = True Else ShiftOSDesktop.boughtshifttitlebuttons = False
            If loadlines(44) = 11 Then ShiftOSDesktop.boughtshiftborders = True Else ShiftOSDesktop.boughtshiftborders = False
            If loadlines(45) = 11 Then ShiftOSDesktop.boughtgray2 = True Else ShiftOSDesktop.boughtgray2 = False
            If loadlines(46) = 11 Then ShiftOSDesktop.boughtgray3 = True Else ShiftOSDesktop.boughtgray3 = False
            If loadlines(47) = 11 Then ShiftOSDesktop.boughtgray4 = True Else ShiftOSDesktop.boughtgray4 = False
            If loadlines(48) = 11 Then ShiftOSDesktop.boughtanycolour = True Else ShiftOSDesktop.boughtanycolour = False
            If loadlines(49) = 11 Then ShiftOSDesktop.boughtanycolour2 = True Else ShiftOSDesktop.boughtanycolour2 = False
            If loadlines(50) = 11 Then ShiftOSDesktop.boughtanycolour3 = True Else ShiftOSDesktop.boughtanycolour3 = False
            If loadlines(51) = 11 Then ShiftOSDesktop.boughtanycolour4 = True Else ShiftOSDesktop.boughtanycolour4 = False
            If loadlines(52) = 11 Then ShiftOSDesktop.boughtpurple = True Else ShiftOSDesktop.boughtpurple = False
            If loadlines(53) = 11 Then ShiftOSDesktop.boughtpurple2 = True Else ShiftOSDesktop.boughtpurple2 = False
            If loadlines(54) = 11 Then ShiftOSDesktop.boughtpurple3 = True Else ShiftOSDesktop.boughtpurple3 = False
            If loadlines(55) = 11 Then ShiftOSDesktop.boughtpurple4 = True Else ShiftOSDesktop.boughtpurple4 = False
            If loadlines(56) = 11 Then ShiftOSDesktop.boughtblue = True Else ShiftOSDesktop.boughtblue = False
            If loadlines(57) = 11 Then ShiftOSDesktop.boughtblue2 = True Else ShiftOSDesktop.boughtblue2 = False
            If loadlines(58) = 11 Then ShiftOSDesktop.boughtblue3 = True Else ShiftOSDesktop.boughtblue3 = False
            If loadlines(59) = 11 Then ShiftOSDesktop.boughtblue4 = True Else ShiftOSDesktop.boughtblue4 = False
            If loadlines(60) = 11 Then ShiftOSDesktop.boughtgreen = True Else ShiftOSDesktop.boughtgreen = False
            If loadlines(61) = 11 Then ShiftOSDesktop.boughtgreen2 = True Else ShiftOSDesktop.boughtgreen2 = False
            If loadlines(62) = 11 Then ShiftOSDesktop.boughtgreen3 = True Else ShiftOSDesktop.boughtgreen3 = False
            If loadlines(63) = 11 Then ShiftOSDesktop.boughtgreen4 = True Else ShiftOSDesktop.boughtgreen4 = False
            If loadlines(64) = 11 Then ShiftOSDesktop.boughtyellow = True Else ShiftOSDesktop.boughtyellow = False
            If loadlines(65) = 11 Then ShiftOSDesktop.boughtyellow2 = True Else ShiftOSDesktop.boughtyellow2 = False
            If loadlines(66) = 11 Then ShiftOSDesktop.boughtyellow3 = True Else ShiftOSDesktop.boughtyellow3 = False
            If loadlines(67) = 11 Then ShiftOSDesktop.boughtyellow4 = True Else ShiftOSDesktop.boughtyellow4 = False
            If loadlines(68) = 11 Then ShiftOSDesktop.boughtorange = True Else ShiftOSDesktop.boughtorange = False
            If loadlines(69) = 11 Then ShiftOSDesktop.boughtorange2 = True Else ShiftOSDesktop.boughtorange2 = False
            If loadlines(70) = 11 Then ShiftOSDesktop.boughtorange3 = True Else ShiftOSDesktop.boughtorange3 = False
            If loadlines(71) = 11 Then ShiftOSDesktop.boughtorange4 = True Else ShiftOSDesktop.boughtorange4 = False
            If loadlines(72) = 11 Then ShiftOSDesktop.boughtbrown = True Else ShiftOSDesktop.boughtbrown = False
            If loadlines(73) = 11 Then ShiftOSDesktop.boughtbrown2 = True Else ShiftOSDesktop.boughtbrown2 = False
            If loadlines(74) = 11 Then ShiftOSDesktop.boughtbrown3 = True Else ShiftOSDesktop.boughtbrown3 = False
            If loadlines(75) = 11 Then ShiftOSDesktop.boughtbrown4 = True Else ShiftOSDesktop.boughtbrown4 = False
            If loadlines(76) = 11 Then ShiftOSDesktop.boughtred = True Else ShiftOSDesktop.boughtred = False
            If loadlines(77) = 11 Then ShiftOSDesktop.boughtred2 = True Else ShiftOSDesktop.boughtred2 = False
            If loadlines(78) = 11 Then ShiftOSDesktop.boughtred3 = True Else ShiftOSDesktop.boughtred3 = False
            If loadlines(79) = 11 Then ShiftOSDesktop.boughtred4 = True Else ShiftOSDesktop.boughtred4 = False
            If loadlines(80) = 11 Then ShiftOSDesktop.boughtpink = True Else ShiftOSDesktop.boughtpink = False
            If loadlines(81) = 11 Then ShiftOSDesktop.boughtpink2 = True Else ShiftOSDesktop.boughtpink2 = False
            If loadlines(82) = 11 Then ShiftOSDesktop.boughtpink3 = True Else ShiftOSDesktop.boughtpink3 = False
            If loadlines(83) = 11 Then ShiftOSDesktop.boughtpink4 = True Else ShiftOSDesktop.boughtpink4 = False
            ShiftOSDesktop.anymemory(0) = Color.FromArgb(loadlines(84))
            ShiftOSDesktop.anymemory(1) = Color.FromArgb(loadlines(85))
            ShiftOSDesktop.anymemory(2) = Color.FromArgb(loadlines(86))
            ShiftOSDesktop.anymemory(3) = Color.FromArgb(loadlines(87))
            ShiftOSDesktop.anymemory(4) = Color.FromArgb(loadlines(88))
            ShiftOSDesktop.anymemory(5) = Color.FromArgb(loadlines(89))
            ShiftOSDesktop.anymemory(6) = Color.FromArgb(loadlines(90))
            ShiftOSDesktop.anymemory(7) = Color.FromArgb(loadlines(91))
            ShiftOSDesktop.anymemory(8) = Color.FromArgb(loadlines(92))
            ShiftOSDesktop.anymemory(9) = Color.FromArgb(loadlines(93))
            ShiftOSDesktop.anymemory(10) = Color.FromArgb(loadlines(94))
            ShiftOSDesktop.anymemory(11) = Color.FromArgb(loadlines(95))
            ShiftOSDesktop.anymemory(12) = Color.FromArgb(loadlines(96))
            ShiftOSDesktop.anymemory(13) = Color.FromArgb(loadlines(97))
            ShiftOSDesktop.anymemory(14) = Color.FromArgb(loadlines(98))
            ShiftOSDesktop.anymemory(15) = Color.FromArgb(loadlines(99))
            ShiftOSDesktop.graymemory(0) = Color.FromArgb(loadlines(100))
            ShiftOSDesktop.graymemory(1) = Color.FromArgb(loadlines(101))
            ShiftOSDesktop.graymemory(2) = Color.FromArgb(loadlines(102))
            ShiftOSDesktop.graymemory(3) = Color.FromArgb(loadlines(103))
            ShiftOSDesktop.graymemory(4) = Color.FromArgb(loadlines(104))
            ShiftOSDesktop.graymemory(5) = Color.FromArgb(loadlines(105))
            ShiftOSDesktop.graymemory(6) = Color.FromArgb(loadlines(106))
            ShiftOSDesktop.graymemory(7) = Color.FromArgb(loadlines(107))
            ShiftOSDesktop.graymemory(8) = Color.FromArgb(loadlines(108))
            ShiftOSDesktop.graymemory(9) = Color.FromArgb(loadlines(109))
            ShiftOSDesktop.graymemory(10) = Color.FromArgb(loadlines(110))
            ShiftOSDesktop.graymemory(11) = Color.FromArgb(loadlines(111))
            ShiftOSDesktop.graymemory(12) = Color.FromArgb(loadlines(112))
            ShiftOSDesktop.graymemory(13) = Color.FromArgb(loadlines(113))
            ShiftOSDesktop.graymemory(14) = Color.FromArgb(loadlines(114))
            ShiftOSDesktop.graymemory(15) = Color.FromArgb(loadlines(115))
            ShiftOSDesktop.purplememory(0) = Color.FromArgb(loadlines(116))
            ShiftOSDesktop.purplememory(1) = Color.FromArgb(loadlines(117))
            ShiftOSDesktop.purplememory(2) = Color.FromArgb(loadlines(118))
            ShiftOSDesktop.purplememory(3) = Color.FromArgb(loadlines(119))
            ShiftOSDesktop.purplememory(4) = Color.FromArgb(loadlines(120))
            ShiftOSDesktop.purplememory(5) = Color.FromArgb(loadlines(121))
            ShiftOSDesktop.purplememory(6) = Color.FromArgb(loadlines(122))
            ShiftOSDesktop.purplememory(7) = Color.FromArgb(loadlines(123))
            ShiftOSDesktop.purplememory(8) = Color.FromArgb(loadlines(124))
            ShiftOSDesktop.purplememory(9) = Color.FromArgb(loadlines(125))
            ShiftOSDesktop.purplememory(10) = Color.FromArgb(loadlines(126))
            ShiftOSDesktop.purplememory(11) = Color.FromArgb(loadlines(127))
            ShiftOSDesktop.purplememory(12) = Color.FromArgb(loadlines(128))
            ShiftOSDesktop.purplememory(13) = Color.FromArgb(loadlines(129))
            ShiftOSDesktop.purplememory(14) = Color.FromArgb(loadlines(130))
            ShiftOSDesktop.purplememory(15) = Color.FromArgb(loadlines(131))
            ShiftOSDesktop.bluememory(0) = Color.FromArgb(loadlines(132))
            ShiftOSDesktop.bluememory(1) = Color.FromArgb(loadlines(133))
            ShiftOSDesktop.bluememory(2) = Color.FromArgb(loadlines(134))
            ShiftOSDesktop.bluememory(3) = Color.FromArgb(loadlines(135))
            ShiftOSDesktop.bluememory(4) = Color.FromArgb(loadlines(136))
            ShiftOSDesktop.bluememory(5) = Color.FromArgb(loadlines(137))
            ShiftOSDesktop.bluememory(6) = Color.FromArgb(loadlines(138))
            ShiftOSDesktop.bluememory(7) = Color.FromArgb(loadlines(139))
            ShiftOSDesktop.bluememory(8) = Color.FromArgb(loadlines(140))
            ShiftOSDesktop.bluememory(9) = Color.FromArgb(loadlines(141))
            ShiftOSDesktop.bluememory(10) = Color.FromArgb(loadlines(142))
            ShiftOSDesktop.bluememory(11) = Color.FromArgb(loadlines(143))
            ShiftOSDesktop.bluememory(12) = Color.FromArgb(loadlines(144))
            ShiftOSDesktop.bluememory(13) = Color.FromArgb(loadlines(145))
            ShiftOSDesktop.bluememory(14) = Color.FromArgb(loadlines(146))
            ShiftOSDesktop.bluememory(15) = Color.FromArgb(loadlines(147))
            ShiftOSDesktop.greenmemory(0) = Color.FromArgb(loadlines(148))
            ShiftOSDesktop.greenmemory(1) = Color.FromArgb(loadlines(149))
            ShiftOSDesktop.greenmemory(2) = Color.FromArgb(loadlines(150))
            ShiftOSDesktop.greenmemory(3) = Color.FromArgb(loadlines(151))
            ShiftOSDesktop.greenmemory(4) = Color.FromArgb(loadlines(152))
            ShiftOSDesktop.greenmemory(5) = Color.FromArgb(loadlines(153))
            ShiftOSDesktop.greenmemory(6) = Color.FromArgb(loadlines(154))
            ShiftOSDesktop.greenmemory(7) = Color.FromArgb(loadlines(155))
            ShiftOSDesktop.greenmemory(8) = Color.FromArgb(loadlines(156))
            ShiftOSDesktop.greenmemory(9) = Color.FromArgb(loadlines(157))
            ShiftOSDesktop.greenmemory(10) = Color.FromArgb(loadlines(158))
            ShiftOSDesktop.greenmemory(11) = Color.FromArgb(loadlines(159))
            ShiftOSDesktop.greenmemory(12) = Color.FromArgb(loadlines(160))
            ShiftOSDesktop.greenmemory(13) = Color.FromArgb(loadlines(161))
            ShiftOSDesktop.greenmemory(14) = Color.FromArgb(loadlines(162))
            ShiftOSDesktop.greenmemory(15) = Color.FromArgb(loadlines(163))
            ShiftOSDesktop.yellowmemory(0) = Color.FromArgb(loadlines(164))
            ShiftOSDesktop.yellowmemory(1) = Color.FromArgb(loadlines(165))
            ShiftOSDesktop.yellowmemory(2) = Color.FromArgb(loadlines(166))
            ShiftOSDesktop.yellowmemory(3) = Color.FromArgb(loadlines(167))
            ShiftOSDesktop.yellowmemory(4) = Color.FromArgb(loadlines(168))
            ShiftOSDesktop.yellowmemory(5) = Color.FromArgb(loadlines(169))
            ShiftOSDesktop.yellowmemory(6) = Color.FromArgb(loadlines(170))
            ShiftOSDesktop.yellowmemory(7) = Color.FromArgb(loadlines(171))
            ShiftOSDesktop.yellowmemory(8) = Color.FromArgb(loadlines(172))
            ShiftOSDesktop.yellowmemory(9) = Color.FromArgb(loadlines(173))
            ShiftOSDesktop.yellowmemory(10) = Color.FromArgb(loadlines(174))
            ShiftOSDesktop.yellowmemory(11) = Color.FromArgb(loadlines(175))
            ShiftOSDesktop.yellowmemory(12) = Color.FromArgb(loadlines(176))
            ShiftOSDesktop.yellowmemory(13) = Color.FromArgb(loadlines(177))
            ShiftOSDesktop.yellowmemory(14) = Color.FromArgb(loadlines(178))
            ShiftOSDesktop.yellowmemory(15) = Color.FromArgb(loadlines(179))
            ShiftOSDesktop.orangememory(0) = Color.FromArgb(loadlines(180))
            ShiftOSDesktop.orangememory(1) = Color.FromArgb(loadlines(181))
            ShiftOSDesktop.orangememory(2) = Color.FromArgb(loadlines(182))
            ShiftOSDesktop.orangememory(3) = Color.FromArgb(loadlines(183))
            ShiftOSDesktop.orangememory(4) = Color.FromArgb(loadlines(184))
            ShiftOSDesktop.orangememory(5) = Color.FromArgb(loadlines(185))
            ShiftOSDesktop.orangememory(6) = Color.FromArgb(loadlines(186))
            ShiftOSDesktop.orangememory(7) = Color.FromArgb(loadlines(187))
            ShiftOSDesktop.orangememory(8) = Color.FromArgb(loadlines(188))
            ShiftOSDesktop.orangememory(9) = Color.FromArgb(loadlines(189))
            ShiftOSDesktop.orangememory(10) = Color.FromArgb(loadlines(190))
            ShiftOSDesktop.orangememory(11) = Color.FromArgb(loadlines(191))
            ShiftOSDesktop.orangememory(12) = Color.FromArgb(loadlines(192))
            ShiftOSDesktop.orangememory(13) = Color.FromArgb(loadlines(193))
            ShiftOSDesktop.orangememory(14) = Color.FromArgb(loadlines(194))
            ShiftOSDesktop.orangememory(15) = Color.FromArgb(loadlines(195))
            ShiftOSDesktop.brownmemory(0) = Color.FromArgb(loadlines(196))
            ShiftOSDesktop.brownmemory(1) = Color.FromArgb(loadlines(197))
            ShiftOSDesktop.brownmemory(2) = Color.FromArgb(loadlines(198))
            ShiftOSDesktop.brownmemory(3) = Color.FromArgb(loadlines(199))
            ShiftOSDesktop.brownmemory(4) = Color.FromArgb(loadlines(200))
            ShiftOSDesktop.brownmemory(5) = Color.FromArgb(loadlines(201))
            ShiftOSDesktop.brownmemory(6) = Color.FromArgb(loadlines(202))
            ShiftOSDesktop.brownmemory(7) = Color.FromArgb(loadlines(203))
            ShiftOSDesktop.brownmemory(8) = Color.FromArgb(loadlines(204))
            ShiftOSDesktop.brownmemory(9) = Color.FromArgb(loadlines(205))
            ShiftOSDesktop.brownmemory(10) = Color.FromArgb(loadlines(206))
            ShiftOSDesktop.brownmemory(11) = Color.FromArgb(loadlines(207))
            ShiftOSDesktop.brownmemory(12) = Color.FromArgb(loadlines(208))
            ShiftOSDesktop.brownmemory(13) = Color.FromArgb(loadlines(209))
            ShiftOSDesktop.brownmemory(14) = Color.FromArgb(loadlines(210))
            ShiftOSDesktop.brownmemory(15) = Color.FromArgb(loadlines(211))
            ShiftOSDesktop.redmemory(0) = Color.FromArgb(loadlines(212))
            ShiftOSDesktop.redmemory(1) = Color.FromArgb(loadlines(213))
            ShiftOSDesktop.redmemory(2) = Color.FromArgb(loadlines(214))
            ShiftOSDesktop.redmemory(3) = Color.FromArgb(loadlines(215))
            ShiftOSDesktop.redmemory(4) = Color.FromArgb(loadlines(216))
            ShiftOSDesktop.redmemory(5) = Color.FromArgb(loadlines(217))
            ShiftOSDesktop.redmemory(6) = Color.FromArgb(loadlines(218))
            ShiftOSDesktop.redmemory(7) = Color.FromArgb(loadlines(219))
            ShiftOSDesktop.redmemory(8) = Color.FromArgb(loadlines(220))
            ShiftOSDesktop.redmemory(9) = Color.FromArgb(loadlines(221))
            ShiftOSDesktop.redmemory(10) = Color.FromArgb(loadlines(222))
            ShiftOSDesktop.redmemory(11) = Color.FromArgb(loadlines(223))
            ShiftOSDesktop.redmemory(12) = Color.FromArgb(loadlines(224))
            ShiftOSDesktop.redmemory(13) = Color.FromArgb(loadlines(225))
            ShiftOSDesktop.redmemory(14) = Color.FromArgb(loadlines(226))
            ShiftOSDesktop.redmemory(15) = Color.FromArgb(loadlines(227))
            ShiftOSDesktop.pinkmemory(0) = Color.FromArgb(loadlines(228))
            ShiftOSDesktop.pinkmemory(1) = Color.FromArgb(loadlines(229))
            ShiftOSDesktop.pinkmemory(2) = Color.FromArgb(loadlines(230))
            ShiftOSDesktop.pinkmemory(3) = Color.FromArgb(loadlines(231))
            ShiftOSDesktop.pinkmemory(4) = Color.FromArgb(loadlines(232))
            ShiftOSDesktop.pinkmemory(5) = Color.FromArgb(loadlines(233))
            ShiftOSDesktop.pinkmemory(6) = Color.FromArgb(loadlines(234))
            ShiftOSDesktop.pinkmemory(7) = Color.FromArgb(loadlines(235))
            ShiftOSDesktop.pinkmemory(8) = Color.FromArgb(loadlines(236))
            ShiftOSDesktop.pinkmemory(9) = Color.FromArgb(loadlines(237))
            ShiftOSDesktop.pinkmemory(10) = Color.FromArgb(loadlines(238))
            ShiftOSDesktop.pinkmemory(11) = Color.FromArgb(loadlines(239))
            ShiftOSDesktop.pinkmemory(12) = Color.FromArgb(loadlines(240))
            ShiftOSDesktop.pinkmemory(13) = Color.FromArgb(loadlines(241))
            ShiftOSDesktop.pinkmemory(14) = Color.FromArgb(loadlines(242))
            ShiftOSDesktop.pinkmemory(15) = Color.FromArgb(loadlines(243))
            ShiftOSDesktop.titlebarcolour = Color.FromArgb(loadlines(244))
            ShiftOSDesktop.windowbordercolour = Color.FromArgb(loadlines(245))
            ShiftOSDesktop.windowbordersize = loadlines(246)
            ShiftOSDesktop.titlebarheight = loadlines(247)
            ShiftOSDesktop.closebuttoncolour = Color.FromArgb(loadlines(248))
            ShiftOSDesktop.closebuttonheight = loadlines(249)
            ShiftOSDesktop.closebuttonwidth = loadlines(250)
            ShiftOSDesktop.closebuttonside = loadlines(251)
            ShiftOSDesktop.closebuttontop = loadlines(252)
            ShiftOSDesktop.titletextcolour = Color.FromArgb(loadlines(253))
            ShiftOSDesktop.titletexttop = loadlines(254)
            ShiftOSDesktop.titletextside = loadlines(255)
            ShiftOSDesktop.titletextsize = loadlines(256)
            ShiftOSDesktop.titletextfont = loadlines(257)
            ShiftOSDesktop.titletextstyle = loadlines(258)
            ShiftOSDesktop.desktoppanelcolour = Color.FromArgb(loadlines(259))
            ShiftOSDesktop.desktopbackgroundcolour = Color.FromArgb(loadlines(260))
            ShiftOSDesktop.desktoppanelheight = loadlines(261)
            ShiftOSDesktop.desktoppanelposition = loadlines(262)
            ShiftOSDesktop.clocktextcolour = Color.FromArgb(loadlines(263))
            ShiftOSDesktop.clockbackgroundcolor = Color.FromArgb(loadlines(264))
            ShiftOSDesktop.panelclocktexttop = loadlines(265)
            ShiftOSDesktop.panelclocktextsize = loadlines(266)
            ShiftOSDesktop.panelclocktextfont = loadlines(267)
            ShiftOSDesktop.panelclocktextstyle = loadlines(268)
            ShiftOSDesktop.applauncherbuttoncolour = Color.FromArgb(loadlines(269))
            ShiftOSDesktop.applauncherbuttonclickedcolour = Color.FromArgb(loadlines(270))
            ShiftOSDesktop.applauncherbackgroundcolour = Color.FromArgb(loadlines(271))
            ShiftOSDesktop.applaunchermouseovercolour = Color.FromArgb(loadlines(272))
            ShiftOSDesktop.applicationsbuttontextcolour = Color.FromArgb(loadlines(273))
            ShiftOSDesktop.applicationbuttonheight = loadlines(274)
            ShiftOSDesktop.applicationbuttontextsize = loadlines(275)
            ShiftOSDesktop.applicationbuttontextfont = loadlines(276)
            ShiftOSDesktop.applicationbuttontextstyle = loadlines(277)
            ShiftOSDesktop.applicationlaunchername = loadlines(278)
            ShiftOSDesktop.titletextposition = loadlines(279)
            ShiftOSDesktop.rollupbuttoncolour = Color.FromArgb(loadlines(280))
            ShiftOSDesktop.rollupbuttonheight = loadlines(281)
            ShiftOSDesktop.rollupbuttonwidth = loadlines(282)
            ShiftOSDesktop.rollupbuttonside = loadlines(283)
            ShiftOSDesktop.rollupbuttontop = loadlines(284)
            If loadlines(285) = 11 Then ShiftOSDesktop.boughtpong = True Else ShiftOSDesktop.boughtpong = False
            If loadlines(286) = 11 Then ShiftOSDesktop.boughtknowledgeinputicon = True Else ShiftOSDesktop.boughtknowledgeinputicon = False
            If loadlines(287) = 11 Then ShiftOSDesktop.boughtshiftericon = True Else ShiftOSDesktop.boughtshiftericon = False
            If loadlines(288) = 11 Then ShiftOSDesktop.boughtshiftoriumicon = True Else ShiftOSDesktop.boughtshiftoriumicon = False
            If loadlines(289) = 11 Then ShiftOSDesktop.boughtclockicon = True Else ShiftOSDesktop.boughtclockicon = False
            If loadlines(290) = 11 Then ShiftOSDesktop.boughtshutdownicon = True Else ShiftOSDesktop.boughtshutdownicon = False
            If loadlines(291) = 11 Then ShiftOSDesktop.boughtpongicon = True Else ShiftOSDesktop.boughtpongicon = False
            If loadlines(292) = 11 Then ShiftOSDesktop.boughtterminalicon = True Else ShiftOSDesktop.boughtterminalicon = False
            If loadlines(293) = 11 Then ShiftOSDesktop.boughtalpong = True Else ShiftOSDesktop.boughtalpong = False
            If loadlines(294) = 11 Then ShiftOSDesktop.boughtfileskimmer = True Else ShiftOSDesktop.boughtfileskimmer = False
            If loadlines(295) = 11 Then ShiftOSDesktop.boughtalfileskimmer = True Else ShiftOSDesktop.boughtalfileskimmer = False
            If loadlines(296) = 11 Then ShiftOSDesktop.boughttextpad = True Else ShiftOSDesktop.boughttextpad = False
            If loadlines(297) = 11 Then ShiftOSDesktop.boughtaltextpad = True Else ShiftOSDesktop.boughtaltextpad = False
            If loadlines(298) = 11 Then ShiftOSDesktop.boughtfileskimmericon = True Else ShiftOSDesktop.boughtfileskimmericon = False
            If loadlines(299) = 11 Then ShiftOSDesktop.boughttextpadicon = True Else ShiftOSDesktop.boughttextpadicon = False
            If loadlines(300) = 11 Then ShiftOSDesktop.boughttextpadnew = True Else ShiftOSDesktop.boughttextpadnew = False
            If loadlines(301) = 11 Then ShiftOSDesktop.boughttextpadsave = True Else ShiftOSDesktop.boughttextpadsave = False
            If loadlines(302) = 11 Then ShiftOSDesktop.boughttextpadopen = True Else ShiftOSDesktop.boughttextpadopen = False
            If loadlines(303) = 11 Then ShiftOSDesktop.boughtfileskimmernewfolder = True Else ShiftOSDesktop.boughtfileskimmernewfolder = False
            If loadlines(304) = 11 Then ShiftOSDesktop.boughtfileskimmerdelete = True Else ShiftOSDesktop.boughtfileskimmerdelete = False
            If loadlines(305) = 11 Then ShiftOSDesktop.boughtkielements = True Else ShiftOSDesktop.boughtkielements = False
            If loadlines(306) = 11 Then ShiftOSDesktop.boughtcolourpickericon = True Else ShiftOSDesktop.boughtcolourpickericon = False
            If loadlines(307) = 11 Then ShiftOSDesktop.boughtinfoboxicon = True Else ShiftOSDesktop.boughtinfoboxicon = False
            ShiftOSDesktop.artpadcolorpalletwidth = loadlines(308)
            ShiftOSDesktop.artpadcolorpalletheight = loadlines(309)
            ShiftOSDesktop.artpadcolorpalletsidegap = loadlines(310)
            ShiftOSDesktop.artpadcolorpallettopgap = loadlines(311)
            ShiftOSDesktop.artpadvisiblepallets = loadlines(312)
            ShiftOSDesktop.artpadpixellimit = loadlines(313)
            If loadlines(314) = 11 Then ShiftOSDesktop.boughtskinloader = True Else ShiftOSDesktop.boughtskinloader = False
            If loadlines(315) = 11 Then ShiftOSDesktop.boughtminimizebutton = True Else ShiftOSDesktop.boughtminimizebutton = False
            If loadlines(316) = 11 Then ShiftOSDesktop.boughtpanelbuttons = True Else ShiftOSDesktop.boughtpanelbuttons = False
            If loadlines(317) = 11 Then ShiftOSDesktop.boughtshiftpanelbuttons = True Else ShiftOSDesktop.boughtshiftpanelbuttons = False
            If loadlines(318) = 11 Then ShiftOSDesktop.boughtartpad = True Else ShiftOSDesktop.boughtartpad = False
            If loadlines(319) = 11 Then ShiftOSDesktop.boughtalartpad = True Else ShiftOSDesktop.boughtalartpad = False
            If loadlines(320) = 11 Then ShiftOSDesktop.boughtartpadicon = True Else ShiftOSDesktop.boughtartpadicon = False
            If loadlines(321) = 11 Then ShiftOSDesktop.boughtskinning = True Else ShiftOSDesktop.boughtskinning = False
            If loadlines(322) = 11 Then ShiftOSDesktop.boughtminimizecommand = True Else ShiftOSDesktop.boughtminimizecommand = False
            If loadlines(323) = 11 Then ShiftOSDesktop.boughtusefulpanelbuttons = True Else ShiftOSDesktop.boughtusefulpanelbuttons = False
            If loadlines(324) = 11 Then ShiftOSDesktop.boughtunitymode = True Else ShiftOSDesktop.boughtunitymode = False
            If loadlines(325) = 11 Then ShiftOSDesktop.boughtartpadpixellimit4 = True Else ShiftOSDesktop.boughtartpadpixellimit4 = False
            If loadlines(326) = 11 Then ShiftOSDesktop.boughtartpadpixellimit8 = True Else ShiftOSDesktop.boughtartpadpixellimit8 = False
            If loadlines(327) = 11 Then ShiftOSDesktop.boughtartpadpixellimit16 = True Else ShiftOSDesktop.boughtartpadpixellimit16 = False
            If loadlines(328) = 11 Then ShiftOSDesktop.boughtartpadpixellimit64 = True Else ShiftOSDesktop.boughtartpadpixellimit64 = False
            If loadlines(329) = 11 Then ShiftOSDesktop.boughtartpadpixellimit256 = True Else ShiftOSDesktop.boughtartpadpixellimit256 = False
            If loadlines(330) = 11 Then ShiftOSDesktop.boughtartpadpixellimit1024 = True Else ShiftOSDesktop.boughtartpadpixellimit1024 = False
            If loadlines(331) = 11 Then ShiftOSDesktop.boughtartpadpixellimit4096 = True Else ShiftOSDesktop.boughtartpadpixellimit4096 = False
            If loadlines(332) = 11 Then ShiftOSDesktop.boughtartpadpixellimit16384 = True Else ShiftOSDesktop.boughtartpadpixellimit16384 = False
            If loadlines(333) = 11 Then ShiftOSDesktop.boughtartpadpixellimit65536 = True Else ShiftOSDesktop.boughtartpadpixellimit65536 = False
            If loadlines(334) = 11 Then ShiftOSDesktop.boughtartpadlimitlesspixels = True Else ShiftOSDesktop.boughtartpadlimitlesspixels = False
            If loadlines(335) = 11 Then ShiftOSDesktop.boughtartpad4colorpallets = True Else ShiftOSDesktop.boughtartpad4colorpallets = False
            If loadlines(336) = 11 Then ShiftOSDesktop.boughtartpad8colorpallets = True Else ShiftOSDesktop.boughtartpad8colorpallets = False
            If loadlines(337) = 11 Then ShiftOSDesktop.boughtartpad16colorpallets = True Else ShiftOSDesktop.boughtartpad16colorpallets = False
            If loadlines(338) = 11 Then ShiftOSDesktop.boughtartpad32colorpallets = True Else ShiftOSDesktop.boughtartpad32colorpallets = False
            If loadlines(339) = 11 Then ShiftOSDesktop.boughtartpad64colorpallets = True Else ShiftOSDesktop.boughtartpad64colorpallets = False
            If loadlines(340) = 11 Then ShiftOSDesktop.boughtartpad128colorpallets = True Else ShiftOSDesktop.boughtartpad128colorpallets = False
            If loadlines(341) = 11 Then ShiftOSDesktop.boughtartpadcustompallets = True Else ShiftOSDesktop.boughtartpadcustompallets = False
            If loadlines(342) = 11 Then ShiftOSDesktop.boughtartpadpixelplacer = True Else ShiftOSDesktop.boughtartpadpixelplacer = False
            If loadlines(343) = 11 Then ShiftOSDesktop.boughtartpadpixelplacermovementmode = True Else ShiftOSDesktop.boughtartpadpixelplacermovementmode = False
            If loadlines(344) = 11 Then ShiftOSDesktop.boughtartpadpencil = True Else ShiftOSDesktop.boughtartpadpencil = False
            If loadlines(345) = 11 Then ShiftOSDesktop.boughtartpadpaintbrush = True Else ShiftOSDesktop.boughtartpadpaintbrush = False
            If loadlines(346) = 11 Then ShiftOSDesktop.boughtartpadlinetool = True Else ShiftOSDesktop.boughtartpadlinetool = False
            If loadlines(347) = 11 Then ShiftOSDesktop.boughtartpadovaltool = True Else ShiftOSDesktop.boughtartpadovaltool = False
            If loadlines(348) = 11 Then ShiftOSDesktop.boughtartpadrectangletool = True Else ShiftOSDesktop.boughtartpadrectangletool = False
            If loadlines(349) = 11 Then ShiftOSDesktop.boughtartpaderaser = True Else ShiftOSDesktop.boughtartpaderaser = False
            If loadlines(350) = 11 Then ShiftOSDesktop.boughtartpadfilltool = True Else ShiftOSDesktop.boughtartpadfilltool = False
            If loadlines(351) = 11 Then ShiftOSDesktop.boughtartpadtexttool = True Else ShiftOSDesktop.boughtartpadtexttool = False
            If loadlines(352) = 11 Then ShiftOSDesktop.boughtartpadundo = True Else ShiftOSDesktop.boughtartpadundo = False
            If loadlines(353) = 11 Then ShiftOSDesktop.boughtartpadredo = True Else ShiftOSDesktop.boughtartpadredo = False
            If loadlines(354) = 11 Then ShiftOSDesktop.boughtartpadsave = True Else ShiftOSDesktop.boughtartpadsave = False
            If loadlines(355) = 11 Then ShiftOSDesktop.boughtartpadload = True Else ShiftOSDesktop.boughtartpadload = False
            For i = 0 To 127 : ShiftOSDesktop.artpadcolourpallets(i) = Color.FromArgb(loadlines(356 + i)) : Next
            If loadlines(484) = "" Then  Else If loadlines(484) = 11 Then ShiftOSDesktop.boughtartpadnew = True Else ShiftOSDesktop.boughtartpadnew = False

            If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Icons") Then ShiftOSDesktop.setupicons()

            Dim objWriter As New System.IO.StreamWriter(ShiftOSPath + "Shiftum42/HDAccess.sft", False)
            objWriter.Write("0.0.8")
            objWriter.Close()

            MessageBox.Show("Convertion Complete, welcome to 0.0.8!" & Environment.NewLine & Environment.NewLine & "ShiftOS will now start, please wait while we load the ShiftOS desktop", "Complete")
            ShiftOSDesktop.justconverted = True
            ShiftOSDesktop.Show()
            HijackScreen.conversationtimer.Start()
            HijackScreen.Close()
            Me.Close()
        Else
            If MsgBox("This is not a 0.0.7 save file, unable to convert - aborting." & Environment.NewLine & Environment.NewLine & "Press 'OK' to quit", MsgBoxStyle.Information, "Incorrect Version") = Windows.Forms.DialogResult.OK Then
                Me.Close()
                ShiftOSDesktop.Close()
                HijackScreen.Close()
            End If
        End If
    End Sub

    Private Sub addlines()
        ReDim Preserve loadlines(2000)
        loadlines(308) = 105
        loadlines(309) = 69
        loadlines(310) = 4
        loadlines(311) = 4
        loadlines(312) = 2
        loadlines(313) = 2
        loadlines(314) = 10
        loadlines(315) = 10
        loadlines(316) = 10
        loadlines(317) = 10
        loadlines(318) = 10
        loadlines(319) = 10
        loadlines(320) = 10
        loadlines(321) = 10
        loadlines(322) = 10
        loadlines(323) = 10
        loadlines(324) = 10
        loadlines(325) = 10
        loadlines(326) = 10
        loadlines(327) = 10
        loadlines(328) = 10
        loadlines(329) = 10
        loadlines(330) = 10
        loadlines(331) = 10
        loadlines(332) = 10
        loadlines(333) = 10
        loadlines(334) = 10
        loadlines(335) = 10
        loadlines(336) = 10
        loadlines(337) = 10
        loadlines(338) = 10
        loadlines(339) = 10
        loadlines(340) = 10
        loadlines(341) = 10
        loadlines(342) = 10
        loadlines(343) = 10
        loadlines(344) = 10
        loadlines(345) = 10
        loadlines(346) = 10
        loadlines(347) = 10
        loadlines(348) = 10
        loadlines(349) = 10
        loadlines(350) = 10
        loadlines(351) = 10
        loadlines(352) = 10
        loadlines(353) = 10
        loadlines(354) = 10
        loadlines(355) = 10
        loadlines(356) = -16777216
        loadlines(357) = -16777216
        loadlines(358) = -16777216
        loadlines(359) = -16777216
        loadlines(360) = -16777216
        loadlines(361) = -16777216
        loadlines(362) = -16777216
        loadlines(363) = -16777216
        loadlines(364) = -16777216
        loadlines(365) = -16777216
        loadlines(366) = -16777216
        loadlines(367) = -16777216
        loadlines(368) = -16777216
        loadlines(369) = -16777216
        loadlines(370) = -16777216
        loadlines(371) = -16777216
        loadlines(372) = -16777216
        loadlines(373) = -16777216
        loadlines(374) = -16777216
        loadlines(375) = -16777216
        loadlines(376) = -16777216
        loadlines(377) = -16777216
        loadlines(378) = -16777216
        loadlines(379) = -16777216
        loadlines(380) = -16777216
        loadlines(381) = -16777216
        loadlines(382) = -16777216
        loadlines(383) = -16777216
        loadlines(384) = -16777216
        loadlines(385) = -16777216
        loadlines(386) = -16777216
        loadlines(387) = -16777216
        loadlines(388) = -16777216
        loadlines(389) = -16777216
        loadlines(390) = -16777216
        loadlines(391) = -16777216
        loadlines(392) = -16777216
        loadlines(393) = -16777216
        loadlines(394) = -16777216
        loadlines(395) = -16777216
        loadlines(396) = -16777216
        loadlines(397) = -16777216
        loadlines(398) = -16777216
        loadlines(399) = -16777216
        loadlines(400) = -16777216
        loadlines(401) = -16777216
        loadlines(402) = -16777216
        loadlines(403) = -16777216
        loadlines(404) = -16777216
        loadlines(405) = -16777216
        loadlines(406) = -16777216
        loadlines(407) = -16777216
        loadlines(408) = -16777216
        loadlines(409) = -16777216
        loadlines(410) = -16777216
        loadlines(411) = -16777216
        loadlines(412) = -16777216
        loadlines(413) = -16777216
        loadlines(414) = -16777216
        loadlines(415) = -16777216
        loadlines(416) = -16777216
        loadlines(417) = -16777216
        loadlines(418) = -16777216
        loadlines(419) = -16777216
        loadlines(420) = -16777216
        loadlines(421) = -16777216
        loadlines(422) = -16777216
        loadlines(423) = -16777216
        loadlines(424) = -16777216
        loadlines(425) = -16777216
        loadlines(426) = -16777216
        loadlines(427) = -16777216
        loadlines(428) = -16777216
        loadlines(429) = -16777216
        loadlines(430) = -16777216
        loadlines(431) = -16777216
        loadlines(432) = -16777216
        loadlines(433) = -16777216
        loadlines(434) = -16777216
        loadlines(435) = -16777216
        loadlines(436) = -16777216
        loadlines(437) = -16777216
        loadlines(438) = -16777216
        loadlines(439) = -16777216
        loadlines(440) = -16777216
        loadlines(441) = -16777216
        loadlines(442) = -16777216
        loadlines(443) = -16777216
        loadlines(444) = -16777216
        loadlines(445) = -16777216
        loadlines(446) = -16777216
        loadlines(447) = -16777216
        loadlines(448) = -16777216
        loadlines(449) = -16777216
        loadlines(450) = -16777216
        loadlines(451) = -16777216
        loadlines(452) = -16777216
        loadlines(453) = -16777216
        loadlines(454) = -16777216
        loadlines(455) = -16777216
        loadlines(456) = -16777216
        loadlines(457) = -16777216
        loadlines(458) = -16777216
        loadlines(459) = -16777216
        loadlines(460) = -16777216
        loadlines(461) = -16777216
        loadlines(462) = -16777216
        loadlines(463) = -16777216
        loadlines(464) = -16777216
        loadlines(465) = -16777216
        loadlines(466) = -16777216
        loadlines(467) = -16777216
        loadlines(468) = -16777216
        loadlines(469) = -16777216
        loadlines(470) = -16777216
        loadlines(471) = -16777216
        loadlines(472) = -16777216
        loadlines(473) = -16777216
        loadlines(474) = -16777216
        loadlines(475) = -16777216
        loadlines(476) = -16777216
        loadlines(477) = -16777216
        loadlines(478) = -16777216
        loadlines(479) = -16777216
        loadlines(480) = -16777216
        loadlines(481) = -16777216
        loadlines(482) = -16777216
        loadlines(483) = -16777216
        loadlines(484) = 10
    End Sub

    Private Sub convertfile()
        IO.File.WriteAllLines(ShiftOSPath + "\Shiftum42\Drivers\HDD.dri", loadlines)
        File_Crypt.EncryptFile(ShiftOSPath + "\Shiftum42\Drivers\HDD.dri", ShiftOSPath + "/Shiftum42/SKernal.sft", sSecretKey)
        Dim objWriter As New System.IO.StreamWriter(ShiftOSPath + "/Shiftum42/HDAccess.sft", False)
        objWriter.Write("0.0.7")
        objWriter.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
        HijackScreen.Close()
    End Sub
End Class