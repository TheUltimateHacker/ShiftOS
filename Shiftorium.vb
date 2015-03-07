Imports System.IO

Public Class Shiftorium
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Dim pricegrab As String
    Dim started As Boolean = False
    Dim fs As FileStream



    Private Sub Shiftorium_Load(sender As Object, e As EventArgs) Handles Me.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()

        ShiftOSDesktop.pnlpanelbuttonshiftorium.SendToBack()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonshiftorium, ShiftOSDesktop.tbshiftoriumicon, ShiftOSDesktop.tbshiftoriumtext, True)
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        handleupgradelist()
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Make terminal appear
        If e.KeyCode = Keys.T AndAlso e.Control Then
            Terminal.Show()
            Terminal.Visible = True
            Terminal.BringToFront()
        End If

        'Movable Windows
        If ShiftOSDesktop.boughtmovablewindows = True Then
            If e.KeyCode = Keys.A AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X - ShiftOSDesktop.movablewindownumber, Me.Location.Y)
                ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User moved " & Me.Name & " left to " & Me.Location.ToString & Environment.NewLine
            End If
            If e.KeyCode = Keys.D AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X + ShiftOSDesktop.movablewindownumber, Me.Location.Y)
                e.SuppressKeyPress = True
            End If
            If e.KeyCode = Keys.W AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y - ShiftOSDesktop.movablewindownumber)
                e.SuppressKeyPress = True
            End If
            If e.KeyCode = Keys.S AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y + ShiftOSDesktop.movablewindownumber)
                ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User moved " & Me.Name & " down to " & Me.Location.ToString & Environment.NewLine
            End If

        End If
    End Sub

    Private Sub titlebar_MouseDown(sender As Object, e As MouseEventArgs) Handles titlebar.MouseDown, lbtitletext.MouseDown, pnlicon.MouseDown, pgtoplcorner.MouseDown, pgtoprcorner.MouseDown
        ' Handle Draggable Windows
        If ShiftOSDesktop.boughtdraggablewindows = True Then
            If e.Button = MouseButtons.Left Then
                titlebar.Capture = False
                lbtitletext.Capture = False
                pnlicon.Capture = False
                pgtoplcorner.Capture = False
                pgtoprcorner.Capture = False
                Const WM_NCLBUTTONDOWN As Integer = &HA1S
                Const HTCAPTION As Integer = 2
                Dim msg As Message = _
                    Message.Create(Me.Handle, WM_NCLBUTTONDOWN, _
                        New IntPtr(HTCAPTION), IntPtr.Zero)
                Me.DefWndProc(msg)
            End If
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User dragged " & Me.Name & " to " & Me.Location.ToString & Environment.NewLine
        End If
    End Sub

    Public Sub setupborders()
        If ShiftOSDesktop.boughtwindowborders = False Then
            pgleft.Hide()
            pgbottom.Hide()
            pgright.Hide()
            Me.Size = New Size(Me.Width - pgleft.Width - pgright.Width, Me.Height - pgbottom.Height)
        End If
    End Sub

    Private Sub closebutton_Click(sender As Object, e As EventArgs) Handles closebutton.Click
        Me.Close()
    End Sub

    Private Sub closebutton_MouseEnter(sender As Object, e As EventArgs) Handles closebutton.MouseEnter, closebutton.MouseUp
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(1)
    End Sub

    Private Sub closebutton_MouseLeave(sender As Object, e As EventArgs) Handles closebutton.MouseLeave
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(0)
    End Sub

    Private Sub closebutton_MouseDown(sender As Object, e As EventArgs) Handles closebutton.MouseDown
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(2)
    End Sub

    Private Sub minimizebutton_Click(sender As Object, e As EventArgs) Handles minimizebutton.Click
        ShiftOSDesktop.minimizeprogram(Me)
    End Sub

    Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
        If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    End Sub

    Private Sub titlebar_MouseLeave(sender As Object, e As EventArgs) Handles titlebar.MouseLeave, lbtitletext.MouseLeave, pnlicon.MouseLeave, closebutton.MouseLeave, rollupbutton.MouseLeave
        If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0)
    End Sub

    Private Sub rollupbutton_Click(sender As Object, e As EventArgs) Handles rollupbutton.Click
        rollupanddown()
    End Sub

    Private Sub rollupbutton_MouseEnter(sender As Object, e As EventArgs) Handles rollupbutton.MouseEnter, rollupbutton.MouseUp
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(1)
    End Sub

    Private Sub rollupbutton_MouseLeave(sender As Object, e As EventArgs) Handles rollupbutton.MouseLeave
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(0)
    End Sub

    Private Sub rollupbutton_MouseDown(sender As Object, e As EventArgs) Handles rollupbutton.MouseDown
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(2)
    End Sub

    Public Sub setuptitlebar()

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = ShiftOSDesktop.windowbordersize
        pgright.Width = ShiftOSDesktop.windowbordersize
        pgbottom.Height = ShiftOSDesktop.windowbordersize
        titlebar.Height = ShiftOSDesktop.titlebarheight

        If justopened = True Then
            Me.Size = New Size(701, 462) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
            Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
            oldbordersize = ShiftOSDesktop.windowbordersize
            oldtitlebarheight = ShiftOSDesktop.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                Me.Hide()
                Me.Size = New Size(Me.Width, Me.Height - oldtitlebarheight + 30)
                Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize)
                oldbordersize = ShiftOSDesktop.windowbordersize
                oldtitlebarheight = ShiftOSDesktop.titlebarheight
                Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
                Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
                rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                Me.Show()
            End If
        End If

        If ShiftOSDesktop.showwindowcorners = True Then
            pgtoplcorner.Show()
            pgtoprcorner.Show()
            pgtoprcorner.Width = ShiftOSDesktop.titlebarcornerwidth
            pgtoplcorner.Width = ShiftOSDesktop.titlebarcornerwidth
        Else
            pgtoplcorner.Hide()
            pgtoprcorner.Hide()
        End If

        If ShiftOSDesktop.boughttitlebar = False Then
            titlebar.Hide()
            Me.Size = New Size(Me.Width, Me.Size.Height - titlebar.Height)
        End If

        If ShiftOSDesktop.boughttitletext = False Then
            lbtitletext.Hide()
        Else
            lbtitletext.Font = New Font(ShiftOSDesktop.titletextfont, ShiftOSDesktop.titletextsize, ShiftOSDesktop.titletextstyle)
            lbtitletext.Text = ShiftOSDesktop.shiftoriumname
            lbtitletext.Show()
        End If

        If ShiftOSDesktop.boughtclosebutton = False Then
            closebutton.Hide()
        Else
            closebutton.BackColor = ShiftOSDesktop.closebuttoncolour
            closebutton.Height = ShiftOSDesktop.closebuttonheight
            closebutton.Width = ShiftOSDesktop.closebuttonwidth
            closebutton.Show()
        End If

        If ShiftOSDesktop.boughtrollupbutton = False Then
            rollupbutton.Hide()
        Else
            rollupbutton.BackColor = ShiftOSDesktop.rollupbuttoncolour
            rollupbutton.Height = ShiftOSDesktop.rollupbuttonheight
            rollupbutton.Width = ShiftOSDesktop.rollupbuttonwidth
            rollupbutton.Show()
        End If

        If ShiftOSDesktop.boughtminimizebutton = False Then
            minimizebutton.Hide()
        Else
            minimizebutton.BackColor = ShiftOSDesktop.minimizebuttoncolour
            minimizebutton.Height = ShiftOSDesktop.minimizebuttonheight
            minimizebutton.Width = ShiftOSDesktop.minimizebuttonwidth
            minimizebutton.Show()
        End If

        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside + pgtoplcorner.Width, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        End If

        If ShiftOSDesktop.boughtshiftoriumicon = True Then
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.shiftoriumicontitlebar 'Replace with the correct icon for the program.
        End If

    End Sub

    Public Sub rollupanddown()
        If Me.Height = Me.titlebar.Height Then
            pgleft.Show()
            pgbottom.Show()
            pgright.Show()
            Me.Height = rolldownsize
            Me.MinimumSize = New Size(minimumsizewidth, minimumsizeheight)
        Else
            Me.MinimumSize = New Size(0, 0)
            pgleft.Hide()
            pgbottom.Hide()
            pgright.Hide()
            rolldownsize = Me.Height
            Me.Height = Me.titlebar.Height
        End If
    End Sub

    Public Sub setskin()
        If ShiftOSDesktop.skinclosebutton(0) Is Nothing Then  Else closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(0).Clone
        closebutton.BackgroundImageLayout = ShiftOSDesktop.skinclosebuttonstyle
        If ShiftOSDesktop.skintitlebar(0) Is Nothing Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0).Clone
        titlebar.BackgroundImageLayout = ShiftOSDesktop.skintitlebarstyle
        If ShiftOSDesktop.skinrollupbutton(0) Is Nothing Then  Else rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(0).Clone
        rollupbutton.BackgroundImageLayout = ShiftOSDesktop.skinrollupbuttonstyle
        If ShiftOSDesktop.skintitlebarleftcorner(0) Is Nothing Then  Else pgtoplcorner.BackgroundImage = ShiftOSDesktop.skintitlebarleftcorner(0).Clone
        pgtoplcorner.BackgroundImageLayout = ShiftOSDesktop.skintitlebarleftcornerstyle
        If ShiftOSDesktop.skintitlebarrightcorner(0) Is Nothing Then  Else pgtoprcorner.BackgroundImage = ShiftOSDesktop.skintitlebarrightcorner(0).Clone
        pgtoprcorner.BackgroundImageLayout = ShiftOSDesktop.skintitlebarrightcornerstyle
        If ShiftOSDesktop.skinminimizebutton(0) Is Nothing Then  Else minimizebutton.BackgroundImage = ShiftOSDesktop.skinminimizebutton(0).Clone
        minimizebutton.BackgroundImageLayout = ShiftOSDesktop.skinminimizebuttonstyle

        'remove background colour when image is present
        If closebutton.BackgroundImage Is Nothing Then  Else closebutton.BackColor = Color.Transparent
        If titlebar.BackgroundImage Is Nothing Then  Else titlebar.BackColor = Color.Transparent
        If rollupbutton.BackgroundImage Is Nothing Then  Else rollupbutton.BackColor = Color.Transparent
        If pgtoplcorner.BackgroundImage Is Nothing Then  Else pgtoplcorner.BackColor = Color.Transparent
        If pgtoprcorner.BackgroundImage Is Nothing Then  Else pgtoprcorner.BackColor = Color.Transparent
        If minimizebutton.BackgroundImage Is Nothing Then  Else minimizebutton.BackColor = Color.Transparent

        Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour
    End Sub

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
        Me.Hide()
        ShiftOSDesktop.setuppanelbuttons()
    End Sub

    'end of general setup

    Private Sub lbupgrades_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lbupgrades.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.Black, e.Bounds)
        End If
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        On Error Resume Next
        Using b As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(lbupgrades.GetItemText(lbupgrades.Items(e.Index)), e.Font, b, e.Bounds, sf)
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub lbupgrades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbupgrades.SelectedIndexChanged
        If Me.lbupgrades.SelectedIndex >= 0 Then
            If started = False Then
                pnlinfo.Location = New Point(351, 0)
                pnlintro.Hide()
                started = True
            End If

            handleupgradedescription("Gray - 20 CP", My.Resources.upgradegray, "Everything doesn't always have to be black and white. Give your programs and GUI some depth by mixing black and white together to form grey." & Environment.NewLine & Environment.NewLine & "Note: You are unable to make controls grey until you buy the Shifter.")
            handleupgradedescription("Title Bar - 80 CP", My.Resources.upgradetitlebar, "Your windows are looking extremely bare right now. You know what they need? A gray bar on top of them! What is the gray bar for you ask?" & Environment.NewLine & Environment.NewLine & "Depending on what kind of person you are it either ""Does Nothing"" or ""Looks Pretty"". The Title Bar has a lot of future potential though…")
            handleupgradedescription("Seconds Since Midnight - 10 CP", My.Resources.upgradesecondssincemidnight, "Ever wondered how many seconds have passed since the clock struck midnight? No?" & Environment.NewLine & Environment.NewLine & "Well for just 9.99 codepoints (rounded to the nearest codepoint) you will finally have the answer to that question you have no intention of knowing the answer to.")
            handleupgradedescription("Minutes Since Midnight - 20 CP", My.Resources.upgrademinutesssincemidnight, "Most people would find looking out their window a better indication of what time it is than being told how many seconds have passed since midnight." & Environment.NewLine & Environment.NewLine & "If you are like most people then enhancing the computers ability to tell the time is critical.")
            handleupgradedescription("Hours Since Midnight - 40 CP", My.Resources.upgradehoursssincemidnight, "Need a somewhat normal method of time tracking? Well now you can have it with the Hours Past Midnight time format." & Environment.NewLine & Environment.NewLine & "It's not perfectly accurate but it's easier than trying to work out the time from how many seconds or minutes have passed since midnight.")
            handleupgradedescription("Custom Username - 15 CP", My.Resources.upgradecustomusername, "Sick of being known as ""User""? Want to be recognized and labeled? Then you need to replace the default username with your own!" & Environment.NewLine & Environment.NewLine & "If you want ShiftOS to refer to you by name then you are going to need this upgrade.")
            handleupgradedescription("Windows Anywhere - 25 CP", My.Resources.upgradewindowsanywhere, "Having all windows open in the center of the screen is seriously limiting when it comes to multitasking." & Environment.NewLine & Environment.NewLine & "Buying this upgrade is essential if you plan on multitasking or even if you just hate having windows centered in the middle of screen.")
            handleupgradedescription("Multitasking - 50 CP", My.Resources.upgrademultitasking, "These days people have many windows up on their computer so they can edit photos while they watch videos and chat to their friends about how good at multitasking they are." & Environment.NewLine & Environment.NewLine & "If you like multitasking and having lots of windows open then buy this upgrade!")
            handleupgradedescription("Auto Scroll Terminal - 5 CP", My.Resources.upgradeautoscrollterminal, "Getting sick of the terminal filling up with text leaving you not knowing what you have typed unless you start typing more?" & Environment.NewLine & Environment.NewLine & "Then buy this upgrade to keep the terminal scrolled to the bottom so you can always see the latest stuff you've typed.")
            handleupgradedescription("Movable Windows - 75 CP", My.Resources.upgrademoveablewindows, "Although it's nice to be able to type commands in the terminal to teleport windows to any spot on the screen it’s a little time consuming and difficult at times." & Environment.NewLine & Environment.NewLine & "Well, with Movable Windows you can move Windows with the keyboard WASD keys.")
            handleupgradedescription("Draggable Windows - 150 CP", My.Resources.upgradedraggablewindows, "So... I heard you have a Title Bar? I also heard that you have Movable Windows. Although Movable Windows are nice they aren't perfect." & Environment.NewLine & Environment.NewLine & "Buy this upgrade if you want to drag windows around by their Title Bar! Trust me... Its ultra-efficient!")
            handleupgradedescription("Window Borders - 40 CP", My.Resources.upgradewindowborders, "A borderless window on your desktop is like a picture hung on the wall without a frame. It looks completely out of place and awful!" & Environment.NewLine & Environment.NewLine & "Without this upgrade your overlapping windows will look extremely messy and appear to merge with each other,")
            handleupgradedescription("PM and AM - 60 CP", My.Resources.upgradeamandpm, "You may be able read the time as it is now but by splitting the time into two 12 hour periods other less intelligent people around you will have an easier time reading the time." & Environment.NewLine & Environment.NewLine & "This upgrade is necessary to stop your families and friends brains exploding!")
            handleupgradedescription("Minute Accuracy Time - 80 CP", My.Resources.upgrademinuteaccuracytime, "Want to be completely normal for once? Well Shift your time format into one 60x more accurate. " & Environment.NewLine & Environment.NewLine & "Most people these days make plans to meet at certain times such as 5:30pm so knowing the exact minute of the exact hour is very important.")
            handleupgradedescription("Split Second Time - 100 CP", My.Resources.upgradesplitsecondaccuracy, "You already know the exact time down to the very last minute. Do you really need to know the exact second?" & Environment.NewLine & Environment.NewLine & "If so then give this upgrade a whirl but I'm sure you have better things to do than throw 100 codepoints away like this.")
            handleupgradedescription("Title Text - 40 CP", My.Resources.upgradetitletext, "Since looking at a program won't tell you the name of it you need Title Text. Unless of course you want to go through the trouble of remembering the name of the program..." & Environment.NewLine & Environment.NewLine & "Title Text sits in the top left hand corner of the title bar to label each program.")
            handleupgradedescription("Close Button - 90 CP", My.Resources.upgradeclosebutton, "Closing a program should be as easy as pressing a button. Opening up the terminal and typing ""Close [Program name]"" is just Ridiculous." & Environment.NewLine & Environment.NewLine & "Please, for your own sake... Buy this close button before you waste another second opening up that terminal!")
            handleupgradedescription("Desktop Panel - 150 CP", My.Resources.upgradedesktoppanel, "Got a boring blank desktop? Feel it doesn't really serve a purpose? Then you need a desktop panel!" & Environment.NewLine & Environment.NewLine & "This beautiful gray desktop panel will sit at the top of your desktop and do absolutely nothing for only 150 codepoints!")
            handleupgradedescription("Clock - 50 CP", My.Resources.upgradeclock, "You could type ""time"" in the terminal every time you wanted to know what the time was but that's a little inefficient don't you think?" & Environment.NewLine & Environment.NewLine & "Ever wish you could just have the time on the screen all the time? Well, there’s an app for that!")
            handleupgradedescription("App Launcher Menu - 120 CP", My.Resources.upgradeapplaunchermenu, "Launching programs by typing their names in the terminal is very counterproductive especially if you are bad at spelling." & Environment.NewLine & Environment.NewLine & "A menu on the desktop that displays all programs on your computer and allows you to launch them would be a huge time saver.")
            handleupgradedescription("AL Knowledge Input - 20 CP", My.Resources.upgradeknowledgeinput, "What's the point of an App Launcher if it can't launch all your apps?" & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to knowledge input in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("AL Clock - 20 CP", My.Resources.upgradealclock, "What's the point of an App Launcher if it can't launch all your apps?" & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to the clock in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("AL Shiftorium - 20 CP", My.Resources.upgradealshiftorium, "What's the point of an App Launcher if it can't launch all your apps?" & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to shiftorium in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("App Launcher Shutdown - 40 CP", My.Resources.upgradeapplaunchershutdown, "You want a complete graphical interface with no reliance on the terminal right? That means every possible function of the operating system must be achievable graphically." & Environment.NewLine & Environment.NewLine & "You may not shut down too often but hey, it beats opening the terminal...")
            handleupgradedescription("Windowed Terminal - 45 CP", My.Resources.upgradewindowedterminal, "A nice big terminal is useful however it can sometimes get in the way of what you are doing." & Environment.NewLine & Environment.NewLine & "With a few tweaks we may be able to program a command that allows the terminal to switch between a full screen and windowed state.")
            handleupgradedescription("Desktop Panel Clock - 75 CP", My.Resources.upgradedesktoppanelclock, "Want to always know what the time is without typing ""time"" in the terminal or opening up an entire application?" & Environment.NewLine & Environment.NewLine & "Well, with this somewhat expensive but extremely affordable clock you will know what the time is no matter what you are doing.")
            handleupgradedescription("Terminal Scrollbar - 20 CP", My.Resources.upgradeterminalscrollbar, "It’s great having the terminal windowed so it doesn't block the view of your desktop but at the same time size can be an issue." & Environment.NewLine & Environment.NewLine & "This problem can easily be fixed however by adding a scrollbar to the terminal when it's windowed.")
            handleupgradedescription("KI Addons - 15 CP", My.Resources.upgradekiaddons, "Knowledge input is a great game to play if you want to earn codepoints but what happens when you run out of things to guess?" & Environment.NewLine & Environment.NewLine & "This upgrade will allow you to install add-ons for knowledge input.")
            handleupgradedescription("KI Car Brands - 10 CP", My.Resources.upgradeskicarbrands, "Need some more lists for Knowledge input? Why not add a list of automobile manufacturers to guess?" & Environment.NewLine & Environment.NewLine & "You know the brand of car you drive right? Toyota Maybe? Suzuki? Or maybe you have a Ferrari... come on you can do this!")
            handleupgradedescription("KI Game Consoles - 10 CP", My.Resources.upgradesgameconsoles, "Need some more lists for Knowledge input? Why not add a list of game consoles to guess?" & Environment.NewLine & Environment.NewLine & "You know the name of your game console right? Playstation 4 Maybe? Xbox one? Or maybe you have a Ouya... come on you can do this!")
            handleupgradedescription("Gray Shades - 40 CP", My.Resources.upgradegrayshades, "Seeing gray on your computer screen may be a nice break from  black and white but why have just one shade of gray when you can have 3?" & Environment.NewLine & Environment.NewLine & "More shades of gray increase the uniqueness of your ShiftOS interface by expanding your range of colour options in the Shifter.")
            handleupgradedescription("Full Gray Shade Set - 60 CP", My.Resources.upgradegrayshadeset, "3 Shades of gray may be better than 1 shade but why not get a full gray shade set complete with 8 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of gray.")
            handleupgradedescription("Custom Gray Shades - 100 CP", My.Resources.upgradegraycustom, "Forget about having 8 shades of gray because this upgrade will allow you to crack the colour value code giving you the ability to create your own custom shades of gray." & Environment.NewLine & Environment.NewLine & "Further research may even allow us to create other basic colours.")
            handleupgradedescription("Purple - 20 CP", My.Resources.upgradepurple, "Now that we have the RBG colours ""Red"" and ""Blue"" we are able to mix them together to form purple which symbolizes spirituality, royalty, magic and mystery." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Purple.")
            handleupgradedescription("Purple Shades - 40 CP", My.Resources.upgradepurpleshades, "Having a splash of purple may be cool but why have just one shade of purple when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of purple.")
            handleupgradedescription("Full Purple Shade Set - 60 CP", My.Resources.upgradepurpleshadeset, "3 Shades of purple may be better than 1 shade but why not get a full purple shade set complete with 16 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of purple.")
            handleupgradedescription("Custom Purple Shades - 100 CP", My.Resources.upgradepurplecustom, "16 shades of purple gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own purple shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Blue - 20 CP", My.Resources.upgradeblue, "Blue may be the colour of the sky and the ocean but it’s also an important colour that may allow us to create more colours if we mix it with red." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Blue.")
            handleupgradedescription("Blue Shades - 40 CP", My.Resources.upgradeblueshades, "Having a splash of blue may be cool but why have just one shade of blue when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of blue.")
            handleupgradedescription("Full Blue Shade Set - 60 CP", My.Resources.upgradeblueshadeset, "3 Shades of blue may be better than 1 shade but why not get a full blue shade set complete with 16 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of blue.")
            handleupgradedescription("Custom Blue Shades - 100 CP", My.Resources.upgradebluecustom, "16 shades of blue gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own blue shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Green - 20 CP", My.Resources.upgradegreen, "Green may be the colour of nature and life but it’s also an important colour that may allow us to create more colours if we mix it with red." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Green.")
            handleupgradedescription("Green Shades - 40 CP", My.Resources.upgradegreenshades, "Having a splash of green may be cool but why have just one shade of green when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of green.")
            handleupgradedescription("Full Green Shade Set - 60 CP", My.Resources.upgradegreenshadeset, "3 Shades of green may be better than 1 shade but why not get a full green shade set complete with 16 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of green.")
            handleupgradedescription("Custom Green Shades - 100 CP", My.Resources.upgradegreencustom, "16 shades of green gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own green shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Yellow - 20 CP", My.Resources.upgradeyellow, "Now that we have the RBG colours ""Red"" and ""Green"" we are able to mix them together to form yellow which symbolizes happiness, creativity and high intellect." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Yellow.")
            handleupgradedescription("Yellow Shades - 40 CP", My.Resources.upgradeyellowshades, "Having a splash of yellow may be cool but why have just one shade of yellow when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of yellow.")
            handleupgradedescription("Full Yellow Shade Set - 60 CP", My.Resources.upgradeyellowshadeset, "3 Shades of yellow may be better than 1 shade but why not get a full yellow shade set complete with 10 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of yellow.")
            handleupgradedescription("Custom Yellow Shades - 100 CP", My.Resources.upgradeyellowcustom, "10 shades of yellow gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own yellow shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Orange - 20 CP", My.Resources.upgradeorange, "Now that we have the RBG colours ""Red"" and ""Green"" we are able to mix them together to form orange which symbolizes enthusiasm and creativity." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Orange.")
            handleupgradedescription("Orange Shades - 40 CP", My.Resources.upgradeorangeshades, "Having a splash of orange may be cool but why have just one shade of orange when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of orange.")
            handleupgradedescription("Full Orange Shade Set - 60 CP", My.Resources.upgradeorangeshadeset, "3 Shades of orange may be better than 1 shade but why not get a full orange shade set complete with 6 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of orange.")
            handleupgradedescription("Custom Orange Shades - 100 CP", My.Resources.upgradeorangecustom, "6 shades of orange gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own orange shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Brown - 20 CP", My.Resources.upgradebrown, "Now that we have the all the RBG colours we are able to mix them together to form brown which symbolizes laziness and the earth." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Brown.")
            handleupgradedescription("Brown Shades - 40 CP", My.Resources.upgradebrownshades, "Having a splash of brown may be cool but why have just one shade of brown when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of brown.")
            handleupgradedescription("Full Brown Shade Set - 60 CP", My.Resources.upgradebrownshadeset, "3 Shades of brown may be better than 1 shade but why not get a full brown shade set complete with 16 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of brown.")
            handleupgradedescription("Custom Brown Shades - 100 CP", My.Resources.upgradebrowncustom, "16 shades of brown gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own brown shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Red - 20 CP", My.Resources.upgradered, "Red may be a demonic and evil colour that symbolizes hate and rage but it’s a very important colour that may allow us to create more colours if we mix it with Blue or Green." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to red.")
            handleupgradedescription("Red Shades - 40 CP", My.Resources.upgraderedshades, "Having a splash of red may be cool but why have just one shade of red when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of red.")
            handleupgradedescription("Full Red Shade Set - 60 CP", My.Resources.upgraderedshadeset, "3 Shades of red may be better than 1 shade but why not get a full red shade set complete with 9 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of red.")
            handleupgradedescription("Custom Red Shades - 100 CP", My.Resources.upgraderedcustom, "9 shades of red gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own red shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Pink - 20 CP", My.Resources.upgradepink, "Now that we have the all the RBG colours we are able to mix them together to form pink which symbolizes universal love and beauty." & Environment.NewLine & Environment.NewLine & "Buying this upgrade would enable you to set various UI elements in ShiftOS to Pink.")
            handleupgradedescription("Pink Shades - 40 CP", My.Resources.upgradepinkshades, "Having a splash of pink may be cool but why have just one shade of pink when you can have 3?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to get more shades of pink.")
            handleupgradedescription("Full Pink Shade Set - 60 CP", My.Resources.upgradepinkshadeset, "3 Shades of pink may be better than 1 shade but why not get a full pink shade set complete with 6 shades?" & Environment.NewLine & Environment.NewLine & "Further upgrades may even allow you to create your own custom shades of pink.")
            handleupgradedescription("Custom Pink Shades - 100 CP", My.Resources.upgradepinkcustom, "6 shades of pink gives you plenty of customization options but further investigation into the RBG colour system will allow you to make your own pink shades." & Environment.NewLine & Environment.NewLine & "Eventually we may be able to limitlessly create shades of any colour.")
            handleupgradedescription("Basic Custom shade - 50 CP", My.Resources.upgradeanycolourshade, "Now that we can create shades of colours based on certain rules our level of customization is very high." & Environment.NewLine & Environment.NewLine & "With further research ShiftOS may be able to support the ability to make a shade not linked to the rules of a certain colour.")
            handleupgradedescription("General Custom Shades - 100 CP", My.Resources.upgradeanycolourshade2, "There isn’t much use making a single custom colour that looks mostly gray. Further research into optimizing ShiftOS may improve its compatibility with the RGB colour system." & Environment.NewLine & Environment.NewLine & "This would lead to a higher range in values and shades being stored.")
            handleupgradedescription("Advanced Custom Shades - 250 CP", My.Resources.upgradeanycolourshade3, "4 savable shade spaces is nowhere near decent for storing custom colours and with RGB limits of 100 to 200 the colours are still looking quite dull." & Environment.NewLine & Environment.NewLine & "More research into optimizing ShiftOS may further break these limits.")
            handleupgradedescription("Limitless Custom Shades - 500 CP", My.Resources.upgradeanycolourshade4, "It’s time to break all RGB colour limits forever! This upgrade may be expensive but it will allow us to master the RGB colour system." & Environment.NewLine & Environment.NewLine & "With total native RGB colour support in ShiftOS we will limitlessly be able to make millions of shades of colours.")
            handleupgradedescription("Shifter - 40 CP", My.Resources.upgradeshifter, "For system compatibility reasons practically all ShiftOS elements are designed to display in gray style and look dull." & Environment.NewLine & Environment.NewLine & "We may be able to overcome this dull interface however if the user is given the option to customize it through the use of an application.")
            handleupgradedescription("AL Shifter - 20 CP", My.Resources.upgradealshifter, "What's the point of an App Launcher if it can't launch all your apps? " & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to the shifter in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("Roll Up Command - 10 CP", My.Resources.upgraderollupcommand, "Running out of space on your desktop? Wish you could keep a window running in the background without completely closing it?" & Environment.NewLine & Environment.NewLine & "Well you 're in luck. The roll up command will allow you to roll windows up to their title bar when you want to save space.")
            handleupgradedescription("Roll Up Button - 45 CP", My.Resources.upgraderollupbutton, "Are you a fan of the Roll Up functionality? Are you absolutely sick of opening up the terminal and typing in a command every time you want to roll up a window?" & Environment.NewLine & Environment.NewLine & "This upgrade will making rolling up windows much quicker!")
            handleupgradedescription("Shift Desktop - 20 CP", My.Resources.upgradeshiftdesktop, "The shifter is currently unable to change any settings but this simple upgrade may be able to add a module that allows you to change the colour of the desktop background." & Environment.NewLine & Environment.NewLine & "This may even unlock further Shifter functionality.")
            handleupgradedescription("Shift Panel Clock - 20 CP", My.Resources.upgradeshiftpanelclock, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Desktop Panel Clock.")
            handleupgradedescription("Shift App Launcher - 20 CP", My.Resources.upgradeshiftapplauncher, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the App Launcher.")
            handleupgradedescription("Shift Desktop Panel - 20 CP", My.Resources.upgradeshiftdesktoppanel, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Desktop Panel.")
            handleupgradedescription("Shift Title Bar - 20 CP", My.Resources.upgradeshifttitlebar, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Title Bar.")
            handleupgradedescription("Shift Title Text - 20 CP", My.Resources.upgradeshifttitletext, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Title Text.")
            handleupgradedescription("Shift Title Buttons - 20 CP", My.Resources.upgradeshiftbuttons, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Title Buttons.")
            handleupgradedescription("Shift Borders - 20 CP", My.Resources.upgradeshiftborders, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Window Borders.")
            handleupgradedescription("Pong - 70 CP", My.Resources.upgradepong, "Finding it difficult to list more words with knowledge input? Everyone has their limits right? Well how about a game of pong?" & Environment.NewLine & Environment.NewLine & "This game is sure to get your adrenalin going and you can earn codepoints as you play it!")
            handleupgradedescription("Knowledge Input Icon - 15 CP", My.Resources.upgradeknowledgeinputicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for knowledge input.")
            handleupgradedescription("Shifter Icon - 15 CP", My.Resources.upgradeshiftericon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for shifter.")
            handleupgradedescription("Shiftorium Icon - 15 CP", My.Resources.upgradeshiftoriumicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for shiftorium.")
            handleupgradedescription("Clock Icon - 15 CP", My.Resources.upgradeclockicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for clock.")
            handleupgradedescription("Shutdown Icon - 15 CP", My.Resources.upgradeshutdownicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for shutdown.")
            handleupgradedescription("Pong Icon - 15 CP", My.Resources.upgradepongicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for pong.")
            handleupgradedescription("Terminal Icon - 15 CP", My.Resources.upgradeterminalicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for terminal.")
            handleupgradedescription("File Skimmer Icon - 15 CP", My.Resources.upgradefileskimmericon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for file skimmer.")
            handleupgradedescription("Textpad Icon - 15 CP", My.Resources.upgradetextpadicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for textpad.")
            handleupgradedescription("AL Pong - 20 CP", My.Resources.upgradealpong, "What's the point of an App Launcher if it can't launch all your apps? " & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to pong in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("AL File Skimmer - 20 CP", My.Resources.upgradealfileskimmer, "What's the point of an App Launcher if it can't launch all your apps? " & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to the file skimmer in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("AL Textpad - 20 CP", My.Resources.upgradealtextpad, "What's the point of an App Launcher if it can't launch all your apps? " & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to textpad in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("File Skimmer - 60 CP", My.Resources.upgradefileskimmer, "Almost all computers come with some form of permanent data storage." & Environment.NewLine & Environment.NewLine & "ShiftOS is storing data on your storage device (e.g. HDD or SSD) however without a way to view and browse through these files you are practically locked out of your own computer.")
            handleupgradedescription("Textpad - 65 CP", My.Resources.upgradetextpad, "Need to quickly jot down something but you can’t find a pen and paper nearby? There’s an app for that!" & Environment.NewLine & Environment.NewLine & "With the Textpad you will be able to jot down whatever you like and have it displayed in all its glory on your computer screen.")
            handleupgradedescription("Textpad New - 25 CP", My.Resources.upgradetextpadnew, "Have you ever been typing a document and thought ‘I don’t like what I’m writing’. Closing and opening the entire application to clear the text is too much effort right?" & Environment.NewLine & Environment.NewLine & "Well if you get this upgrade clearing the text can be as easy as pressing a button.")
            handleupgradedescription("Textpad Save - 25 CP", My.Resources.upgradetextpadsave, "Have you just written something worth keeping with Textpad? Well, what a shame you can’t save it…" & Environment.NewLine & Environment.NewLine & "Or can you? That’s right, with this upgrade your award winning documents can sit safely on your storage device.")
            handleupgradedescription("Textpad Open - 25 CP", My.Resources.upgradetextpadopen, "Sure you can open your text files by going to all the effort of opening File Skimmer and then clicking on the file you want to open but it doesn’t have to be that hard." & Environment.NewLine & Environment.NewLine & "Wouldn't an open button make life much easier?")
            handleupgradedescription("FS New Folder - 25 CP", My.Resources.upgradefileskimmernew, "There are a few folders within the ShiftOS file system that you can sort your data into but why limit yourself?" & Environment.NewLine & Environment.NewLine & "In an operating system that you can shift to your liking surely you should be able to create your own folders right?")
            handleupgradedescription("FS Delete - 25 CP", My.Resources.upgradefileskimmerdelete, "You’re not a hoarder are you? If you are stop reading this and go look for another upgrade." & Environment.NewLine & Environment.NewLine & "If you keep every file you create your storage device is sure to get cluttered… seriously, you need a delete button!")
            handleupgradedescription("KI Elements - 10 CP", My.Resources.upgradekielements, "Need some more lists for Knowledge input? Why not add a list of Elements to guess?" & Environment.NewLine & Environment.NewLine & "You studied the periodic table of elements in highschool right? Hydrogen, oxygen, lead, silver… you can do this!")
            handleupgradedescription("Colour Picker Icon - 15 CP", My.Resources.upgradecolourpickericon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for the Colour Picker.")
            handleupgradedescription("Infobox Icon - 15 CP", My.Resources.upgradeinfoboxicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for the InfoBox.")
            'new
            handleupgradedescription("Panel Buttons - 75 CP", My.Resources.upgradepanelbuttons, "A desktop panel seems like it could be useful for a variety of different features." & Environment.NewLine & Environment.NewLine & "Maybe with a little more research we could find a way to display the names of all your open programs in the desktop panel")
            handleupgradedescription("Minimize Command - 20 CP", My.Resources.upgrademinimizecommand, "Ever wanted to completely remove a program from the screen without actually closing it?" & Environment.NewLine & Environment.NewLine & "Well with a minimize command this may actually become possible and allow you to save the state of hidden programs in the process!")
            handleupgradedescription("Minimize Button - 50 CP", My.Resources.upgrademinimizebutton, "As useful as the minimize feature is you still have to go to all the effort of opening the terminal and typing in a command to use it." & Environment.NewLine & Environment.NewLine & "Wouldn’t a button in the title of each window be more efficient?")
            handleupgradedescription("Useful Panel Buttons - 40 CP", My.Resources.upgradeusefulpanelbuttons, "How can you call those things on the desktop panel ‘panel buttons’ when they aren’t even clickable?." & Environment.NewLine & Environment.NewLine & "A graphical unminimize feature would be handy and those panel buttons might help us…")
            handleupgradedescription("Artpad - 75 CP", My.Resources.upgradeartpad, "Ever wanted to play around with pixels on your screen?" & Environment.NewLine & Environment.NewLine & "Well it looks like your newest companion may become the Artpad but be sure you know your x and y coordinates!")
            handleupgradedescription("Artpad Pixel Limit 4 - 10 CP", My.Resources.upgradeartpadpixellimit4, "With just two pixels you can’t make very interesting artworks." & Environment.NewLine & Environment.NewLine & "Doubling the pixel limit to 4 should more than double the variety of unique creations you can make with the artpad.")
            handleupgradedescription("Artpad Pixel Limit 8 - 20 CP", My.Resources.upgradeartpadpixellimit8, "Earlier I lied about 4 pixels giving you many different types of unique artistic opportunities." & Environment.NewLine & Environment.NewLine & "A pixel limit of 8 may be a little limiting though and its still dirt cheap.")
            handleupgradedescription("Artpad Pixel Limit 16 - 30 CP", My.Resources.upgradeartpadpixellimit16, "8 pixels may not be great but 16 is looking a little more pristine." & Environment.NewLine & Environment.NewLine & "It may be a silly rhyme but it’s true.")
            handleupgradedescription("Artpad Pixel Limit 64 - 50 CP", My.Resources.upgradeartpadpixellimit64, "Step right up to a pixel limit 4x greater than your current one." & Environment.NewLine & Environment.NewLine & "Isn’t it usually double you say? Well this time around its quadruple but unfortunately it does come with a dearer price.")
            handleupgradedescription("Artpad Pixel Limit 256 - 75 CP", My.Resources.upgradeartpadpixellimit256, "Finally we are on the verge on a decent pixel limit. Think of what you could do with 256 pixels" & Environment.NewLine & Environment.NewLine & "The width and height of your canvas could be huge!")
            handleupgradedescription("Artpad Pixel Limit 1024 - 100 CP", My.Resources.upgradeartpadpixellimit1024, "Ahh, now we’re talking. This is an upgrade that will do you a world of good." & Environment.NewLine & Environment.NewLine & "It’s a shame it’s is so expensive but good things always come at a cost.")
            handleupgradedescription("Artpad Pixel Limit 4096 - 150 CP", My.Resources.upgradeartpadpixellimit4096, " With a pixel limit of 4096 you would have the ability to make canvases 64 by 64 pixels." & Environment.NewLine & Environment.NewLine & "Do you really think you will need this high of a pixel limit?")
            handleupgradedescription("Artpad Pixel Limit 16384 - 200 CP", My.Resources.upgradeartpadpixellimit16384, "You may think your current pixel limit is good but you aren’t seen nothing yet." & Environment.NewLine & Environment.NewLine & "For some true 4x zoomed freehand drawing don’t miss this upgrade.")
            handleupgradedescription("Artpad Pixel Limit 65536 - 250 CP", My.Resources.upgradeartpadpixellimit65536, "Oh come on how much higher can the pixel limit go?" & Environment.NewLine & Environment.NewLine & "I doubt you actually need it but aren’t you curious how much higher this goes?")
            handleupgradedescription("Artpad Limitless Pixels - 350 CP", My.Resources.upgradeartpadlimitlesspixels, "This is what you’ve been waiting for all this time after purchasing all those pixel limit upgrades" & Environment.NewLine & Environment.NewLine & "It may be ultra-expensive but you won’t have to ever get another after this one.")
            handleupgradedescription("Artpad New - 10 CP", My.Resources.upgradeartpadnew, "Ever wanted to start a fresh with a new canvas without restarting Artpad" & Environment.NewLine & Environment.NewLine & "With a little research it may be possible to add a button to do just that whenever you want.")
            handleupgradedescription("Artpad Save - 50 CP", My.Resources.upgradeartpadsave, "Artpad may be fun to play around with but wouldn’t saving be an amazing feature?" & Environment.NewLine & Environment.NewLine & "Saving your pictures may even generate codepoints and the saved pictures might be able to be used for something.")
            handleupgradedescription("Artpad Load - 50 CP", My.Resources.upgradeartpadload, "Sometimes after making something and saving it you wish to alter it slightly to enhance it" & Environment.NewLine & Environment.NewLine & "A load feature in the Artpad should let you modify saved .pic files by allowing you to load them up again with the click of a button.")
            handleupgradedescription("Artpad Undo - 40 CP", My.Resources.upgradeartpadundo, "Ever spilt your paint over your masterpiece? It’s an awful feeling right?" & Environment.NewLine & Environment.NewLine & "Well in situations like these an undo feature would be very useful so for backup I would definitely get this upgrade.")
            handleupgradedescription("Artpad Redo - 40 CP", My.Resources.upgradeartpadredo, "Ever clicked undo too many times and found that you have lost a large portion of work" & Environment.NewLine & Environment.NewLine & "For cases like these a redo button can be quite handy but obviously you could save your codepoints by just being careful with the undo button.")
            handleupgradedescription("Artpad Pixel Placer - 20 CP", My.Resources.upgradeartpadpixelplacer, "The pixel setter allows you to set pixels but do you really want to go around trying to pinpoint and calculate x and y coordinates" & Environment.NewLine & Environment.NewLine & "Clicking the pixel you want to change directly would be much more efficient don’t you agree?")
            handleupgradedescription("Artpad PP Movement Mode - 20 CP", My.Resources.upgradeartpadpixelplacermovementmode, "Constantly clicking each individual pixel on your canvas using the Pixel Placer can be very time consuming and tiring for your hands" & Environment.NewLine & Environment.NewLine & "Wouldn’t it be easier to just click and drag? Well there’s an upgrade for that!")
            handleupgradedescription("Artpad Pencil - 30 CP", My.Resources.upgradeartpadpenciltool, "Does the buggy Pixel placer movement mode annoy you when it skips pixels?" & Environment.NewLine & Environment.NewLine & "Well with a little more research we may be able to develop a new tool that can draw much more smoothly.")
            handleupgradedescription("Artpad Paint Brush - 30 CP", My.Resources.upgradeartpadpaintbrushtool, "Ever wanted to paint with a tool that can paint free handedly and be big, small, circular or square?" & Environment.NewLine & Environment.NewLine & "This paint brush tool may be the tool you want then and its pretty cheap too.")
            handleupgradedescription("Artpad Line Tool - 30 CP", My.Resources.upgradeartpadlinetool, "Having difficulty drawing strait lines? Then you obviously need a line tool." & Environment.NewLine & Environment.NewLine & "With a line tool you will be able to draw straight lines from any point to any point on your canvas.")
            handleupgradedescription("Artpad Oval Tool - 40 CP", My.Resources.upgradeartpadovaltool, "Drawing perfect circles is a very tricky process especially if zoomed right in on the canvas" & Environment.NewLine & Environment.NewLine & "With a bit of research we may be able to discover a tool that calculates how to draw circles without much effort on our side.")
            handleupgradedescription("Artpad Rectangle Tool - 40 CP", My.Resources.upgradeartpadrectangletool, "Drawing perfect squares is a time consuming process especially if you are trying to draw them perfectly straight" & Environment.NewLine & Environment.NewLine & "With a bit of research we may be able to discover a tool that calculates how to draw squares without much effort on our side.")
            handleupgradedescription("Artpad Eraser - 20 CP", My.Resources.upgradeartpaderaser, "Made a little mistake and want to erase it? Sounds like you need an eraser" & Environment.NewLine & Environment.NewLine & "With a little bit of research an eraser tool may not be too far away as overall its just a paintbrush set to the colour of the canvas.")
            handleupgradedescription("Artpad Fill Tool - 60 CP", My.Resources.upgradeartpadfilltool, "Instead of coloring in every single individual pixel sometimes it is more appropriate to simply draw an outline and instantly fill a space in." & Environment.NewLine & Environment.NewLine & "If that’s a feature you’re interested in then you should definitely buy this upgrade.")
            handleupgradedescription("Artpad Text Tool - 45 CP", My.Resources.upgradeartpadtexttool, "drawing text is very difficult but if you can pull it off then well done, nice accomplishment!" & Environment.NewLine & Environment.NewLine & "For those who can’t though research into a text drawing tool would be very handy unless you don’t require text in your artwork.")
            handleupgradedescription("Artpad 4 Color Pallets - 10 CP", My.Resources.upgradeartpad4colorpallets, "Having just 2 colours in your work may give it an interesting style but overall its very limiting." & Environment.NewLine & Environment.NewLine & "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.")
            handleupgradedescription("Artpad 8 Color Pallets - 20 CP", My.Resources.upgradeartpad8colorpallets, "4 colour pallets is still very limiting and a lot less than your average paint program." & Environment.NewLine & Environment.NewLine & "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.")
            handleupgradedescription("Artpad 16 Color Pallets - 35 CP", My.Resources.upgradeartpad16colorpallets, "8 colours is still going to leave you changing the colour of your pallets quite often." & Environment.NewLine & Environment.NewLine & "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.")
            handleupgradedescription("Artpad 32 Color Pallets - 50 CP", My.Resources.upgradeartpad32colorpallets, "16 colours is definitely usable but it certainly could get better than that right?" & Environment.NewLine & Environment.NewLine & "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.")
            handleupgradedescription("Artpad 64 Color Pallets - 100 CP", My.Resources.upgradeartpad64colorpallets, "32 colours is slightly more than average for a paint program but don’t you want extreme?" & Environment.NewLine & Environment.NewLine & "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.")
            handleupgradedescription("Artpad 128 Color Pallets - 150 CP", My.Resources.upgradeartpad128colorpallets, "For some people 64 colour pallets may already be overkill but for the extremists like yourself it’s just not enough." & Environment.NewLine & Environment.NewLine & "This upgrade will double the amount of usable colour pallets in the Artpad to allow you quick access to a wider range of colours.")
            handleupgradedescription("Artpad Custom Pallets - 75 CP", My.Resources.updatecustomcolourpallets, "It can be annoying when things are set in stone and can’t be changed." & Environment.NewLine & Environment.NewLine & "Let’s not let that happen to the Artpad by programming the colour pallets to be resizable by the user.")
            handleupgradedescription("Skinning - 80 CP", My.Resources.upgradeskinning, "Static colours of the windows and desktop in ShiftOS are beginning to look boring and unprofessional." & Environment.NewLine & Environment.NewLine & "Since the artpad is able to save .pic file we may be able to use them as UI elements.")
            handleupgradedescription("Unity Mode - 1000 CP", My.Resources.upgradeunitymode, "ShiftOS uses Microsoft Windows as nothing more than supportive boot code however further research could enhance interactivity between operating systems." & Environment.NewLine & Environment.NewLine & "The Full RGB colour system support should enable better compatibility allowing ShiftOS to run in Unity with Windows.")
            handleupgradedescription("AL Artpad - 20 CP", My.Resources.upgradealartpad, "What's the point of an App Launcher if it can't launch all your apps? " & Environment.NewLine & Environment.NewLine & "Use this tweak to add a shortcut to artpad in your app launcher so you can launch it at any time with just a few clicks.")
            handleupgradedescription("Artpad Icon - 15 CP", My.Resources.upgradeartpadicon, "Having the name of a program in its title bar or in an app launcher is always great as it helps you remember what each program is." & Environment.NewLine & Environment.NewLine & "Text however is a little plain don’t you think? What we really need is an icon for artpad.")
            handleupgradedescription("Shift Panel Buttons - 20 CP", My.Resources.upgradeshiftpanelbuttons, "The Shifter may have some functionality but why not add more modules to it so you can customize even more elements of ShiftOS?" & Environment.NewLine & Environment.NewLine & "This module will allow you to modify the Desktop Panel Buttons.")

        End If
    End Sub

    Private Sub btnbuy_Click(sender As Object, e As EventArgs) Handles btnbuy.Click
        If Me.lbupgrades.SelectedIndex >= 0 Then
            handlebuy("Gray - 20 CP", ShiftOSDesktop.boughtgray, "Originally the screen could only display black and white but now with the ability to display gray it's easier and more efficient to display more information and controls on the screen." & Environment.NewLine & Environment.NewLine & "You can now set the colour of screen controls including the background to gray using Shifter and even draw in gray within Artpad.")
            handlebuy("Title Bar - 80 CP", ShiftOSDesktop.boughttitlebar, "Congratulations, windows will now have a gray, 30 pixel high title bar at the top of them!" & Environment.NewLine & Environment.NewLine & "It may not seem like much now but you've just opened up the ShiftOS GUI to a huge range of future upgrades that could turn this title bar into a very useful tool for window information and enhanced control.")
            handlebuy("Seconds Since Midnight - 10 CP", ShiftOSDesktop.boughtsecondspastmidnight, "Interesting, the bios appears to have the ability to track how many seconds have passed since midnight. With further calculations we may be able to convert this format of time tracking to a more convenient one." & Environment.NewLine & Environment.NewLine & "You can now find out how many seconds have passed since midnight by typing ""time"" in the terminal.")
            handlebuy("Minutes Since Midnight - 20 CP", ShiftOSDesktop.boughtminutespastmidnight, "Wow, isn't this amazing? Simply by dividing how many seconds have passed since midnight by 60 the computer is now able to tell you how many minutes have passed since midnight." & Environment.NewLine & Environment.NewLine & "Typing ""time"" in the terminal will now give you a better indication of what time it is.")
            handlebuy("Hours Since Midnight - 40 CP", ShiftOSDesktop.boughthourspastmidnight, "Incredible! If you divide the amount of minutes that have passed since midnight by 60 you are able to determine a somewhat proper time in 24 hour format." & Environment.NewLine & Environment.NewLine & "Typing ""time"" in the terminal will now tell you the time in a not so accurate but very understandable format.")
            handlebuy("Custom Username - 15 CP", ShiftOSDesktop.boughtcustomusername, "Well, isn't this special? The terminal will now display any name you want it to. Even the ShiftOS desktop and some other applications will refer to you by the username you set." & Environment.NewLine & Environment.NewLine & "To set your username simply type ""set username"" in the terminal followed by the name you want (spaces not allowed).")
            handlebuy("Windows Anywhere - 25 CP", ShiftOSDesktop.boughtwindowsanywhere, "Congratulations! You can now move windows to any point on the screen... As long as you understand the concept of X and Y coordinates and screen resolution." & Environment.NewLine & Environment.NewLine & "Type ""Move [insert program name here] to [xcoordinate],[ycoordinate]"" to teleport windows to any point on the screen.")
            handlebuy("Multitasking - 50 CP", ShiftOSDesktop.boughtmultitasking, "Congratulations! You can now open as many applications as you want on your computer. Remember that all applications are 'single instance applications' so you can't open two versions of the same application." & Environment.NewLine & Environment.NewLine & "To switch between open programs/bring a window to the front type ""switch to"" followed by the application name.")
            handlebuy("Auto Scroll Terminal - 5 CP", ShiftOSDesktop.boughtautoscrollterminal, "Buggy terminal Fixed! Although your terminal may not get filled up that much when it's full screen it certainly will if you find a way to make the terminal smaller." & Environment.NewLine & Environment.NewLine & "Every time you press enter the terminal will now automatically scroll you to bottom so you can always see the latest terminal output.")
            handlebuy("Movable Windows - 75 CP", ShiftOSDesktop.boughtmovablewindows, "You can now move windows without total reliance on the terminal however movement is far from smooth and not fully efficient." & Environment.NewLine & Environment.NewLine & "To move windows simply click once anywhere on the window you wish to move and hold the Ctrl key while tapping the WASD keys to move it 50 (customizable in Shifter) pixels in that direction.")
            handlebuy("Draggable Windows - 150 CP", ShiftOSDesktop.boughtdraggablewindows, "You have just taken a major step in the right direction. You no longer have to worry about relying on the keyboard to move windows around on the screen." & Environment.NewLine & Environment.NewLine & "From this point on you can use the pin point accuracy of your mouse to smoothly drag windows to any spot on the screen by pulling on their title bars.")
            handlebuy("Window Borders - 40 CP", ShiftOSDesktop.boughtwindowborders, "Now with your freshly framed windows you will no longer have issues distinguishing them from each other. Those borders may even perform a function other than looking pretty in a future upgrade." & Environment.NewLine & Environment.NewLine & "Borders only cover the right, left and bottom of windows so if you haven't bought a Title Bar your windows won't have a top border.")
            handlebuy("PM and AM - 60 CP", ShiftOSDesktop.boughtpmandam, "Congratulations, you have just saved anyone who looks at your computer for the time a few seconds converting it from 24 hour time to 12 hour time. Good Job!" & Environment.NewLine & Environment.NewLine & "It may not be totally accurate but now people won't think you are a complete nerd with a strange time format.")
            handlebuy("Minute Accuracy Time - 80 CP", ShiftOSDesktop.boughtminuteaccuracytime, "Finally you have a great time format. You may not know the exact second of each minute but knowing the minute of the hour is good enough right?" & Environment.NewLine & Environment.NewLine & "If you haven't already buy a desktop clock or title bar clock to show off the time so you don't have to type ""time"" in the terminal all the time.")
            handlebuy("Split Second Time - 100 CP", ShiftOSDesktop.boughtsplitsecondtime, "Ok, looks like you just couldn't resist so here you go... Typing ""time"" in the terminal will now tell you the hour, minute and second of the day." & Environment.NewLine & Environment.NewLine & "If you have any other clock like programs these will also now tell you the time to the exact second. Now go upgrade something that matters!")
            handlebuy("Title Text - 40 CP", ShiftOSDesktop.boughttitletext, "Fantastic! You now have some beautiful title text that sits in the title bar and tells you the name of all open programs." & Environment.NewLine & Environment.NewLine & "If you are unhappy with the font, size, colour or even position of the Title Text you are free to change it in the Shifter or even turn off Title Text all together if you don't like it.")
            handlebuy("Close Button - 90 CP", ShiftOSDesktop.boughtclosebutton, "What a relief! Finally programs can be closed with the click of a button. This is a big step forwards towards total graphical functionality without a terminal." & Environment.NewLine & Environment.NewLine & "If you havn't already now would be a great time to start building up a desktop interface to free yourself from the terminal.")
            handlebuy("Desktop Panel - 150 CP", ShiftOSDesktop.boughtdesktoppanel, "Now wasn't that worth it? Your desktop looks like it could actually do something now even though it can't. Doesn't this make your life feel totally complete now?" & Environment.NewLine & Environment.NewLine & "No? Well then... go buy some more upgrades and maybe that gray bar at the top of the screen will actually serve a purpose!")
            handlebuy("Clock - 50 CP", ShiftOSDesktop.boughtclock, "Great Work! You can now use your expensive computer as a cheap clock that hopefully displays the time in a nice format." & Environment.NewLine & Environment.NewLine & "Now you can sit back spending the day watching the time or even play knowledge input while the time is being displayed if your computer can multitask.")
            handlebuy("App Launcher Menu - 120 CP", ShiftOSDesktop.boughtapplaunchermenu, "Fantastic! Your desktop panel now contains an application launcher. You can now use it at any time to open the terminal by clicking the application launcher menu and then selecting terminal from the dropdown list." & Environment.NewLine & Environment.NewLine & "Further upgrades may add more programs you have installed on your computer to the launcher.")
            handlebuy("AL Knowledge Input - 20 CP", ShiftOSDesktop.boughtalknowledgeinput, "Your App Launcher is now more complete and will allow you to launch Knowledge input at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("AL Clock - 20 CP", ShiftOSDesktop.boughtalclock, "Your App Launcher is now more complete and will allow you to launch the clock at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("AL Shiftorium - 20 CP", ShiftOSDesktop.boughtalshiftorium, "Your App Launcher is now more complete and will allow you to launch shiftorium at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("App Launcher Shutdown - 40 CP", ShiftOSDesktop.boughtapplaunchershutdown, "Congratulations! Under your programs in the program launcher you will now see an option to shut down your computer." & Environment.NewLine & Environment.NewLine & "You may now instantly shutdown ShiftOS any time you want with just a few clicks! Be sure not to accidently click it though otherwise you may lose unsaved work or exit out of something before you're done.")
            handlebuy("Windowed Terminal - 45 CP", ShiftOSDesktop.boughtwindowedterminal, "Excellent! The terminal no longer has to be a huge barrier between you and your desktop." & Environment.NewLine & Environment.NewLine & "You can now type ""windowed terminal"" to turn the terminal into a normal windowed program. You can also type ""fullscreen terminal"" to restore the terminal to it’s original state.")
            handlebuy("Desktop Panel Clock - 75 CP", ShiftOSDesktop.boughtdesktoppanelclock, "Well Done! You now will know what the time is whenever you want as long as the desktop panel is visible." & Environment.NewLine & Environment.NewLine & "Feel free to spend the next hour starring at the top right corner of your desktop panel admiring your new clock. At least you will know how much time is passing...")
            handlebuy("Terminal Scrollbar - 20 CP", ShiftOSDesktop.boughtterminalscrollbar, "Well, Isn't this heaven! The terminal will now display a scroll bar when windowed! It may not seem like much but it will certainly help if you need to backtrack on previous output in the terminal." & Environment.NewLine & Environment.NewLine & "Please note that the scrollbar will only appear when the terminal is windowed and can't display all text at once.")
            handlebuy("KI Addons - 15 CP", ShiftOSDesktop.boughtkiaddons, "Fantastic! Knowledge input can now be expanded with Add-ons. If you ever run out of Fruits, Countries or Animals to guess you will be able to buy more lists in the Shiftorium." & Environment.NewLine & Environment.NewLine & "Be careful not to spend all your codepoints on lists you can't guess otherwise you will be losing rather than earning codepoints!")
            handlebuy("KI Car Brands - 10 CP", ShiftOSDesktop.boughtkicarbrands, "Now that you have added a list of car brands/companies to Knowledge Input open it now and start guessing as many car brands as you can think of!" & Environment.NewLine & Environment.NewLine & "If you are playing on a tablet computer take a walk down the road looking at the backs or fronts of cars for their names/brands.")
            handlebuy("KI Game Consoles - 10 CP", ShiftOSDesktop.boughtkigameconsoles, "Now that you have added a list of video game consoles to Knowledge Input open it now and start guessing as many game consoles as you can think of!" & Environment.NewLine & Environment.NewLine & "If you are playing on a tablet computer take a walk down to the shops and see what consoles you can find there.")
            handlebuy("Gray Shades - 40 CP", ShiftOSDesktop.boughtgray2, "Now with a more lively, illuminated light gray and a more dramatic dim gray your interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "To use these new shades of gray just open the shifter and click on a colour customization box. Once the colour picker appears you will see these new shades of gray ready to be used wherever you want.")
            handlebuy("Full Gray Shade Set - 60 CP", ShiftOSDesktop.boughtgray3, "Now with the complete gray shade set you can greatly alter the appearance of your ShiftOS desktop." & Environment.NewLine & Environment.NewLine & "It appears that there is a pattern with these different shades of gray. The higher the numeric RGB value is the lighter the shade is. Further research may allow us to make our own custom shades of gray.")
            handlebuy("Custom Gray Shades - 100 CP", ShiftOSDesktop.boughtgray4, "It appears black has an RGB value of 0 and white has an RGB value of 255. Values between 0 – 255 are different shades of gray from 0 being the darkest to 255 being the lightest." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of gray in the colour picker by typing in a custom value and then right clicking any colour box in the gray shades area.")
            handlebuy("Purple - 20 CP", ShiftOSDesktop.boughtpurple, "Purple is an interesting colour as it is a mix of the warmest red colour and coolest blue colour. Now that you have it you are free to use it throughout ShiftOS." & Environment.NewLine & Environment.NewLine & "Once we have discovered all the basic colours we may be able to use our knowledge to create more shades of the colours we have.")
            handlebuy("Purple Shades - 40 CP", ShiftOSDesktop.boughtpurple2, "Now with a darker purple and lighter purple shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Purple Shade Set - 60 CP", ShiftOSDesktop.boughtpurple3, "Now with the complete purple shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this purple set we are very close to discovering how to make our own custom shades of purple.")
            handlebuy("Custom Purple Shades - 100 CP", ShiftOSDesktop.boughtpurple4, "To make a purple shade with the RGB colour system Blue must have the highest value followed by red. Green must then have the lowest value." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of purple in the colour picker by typing in custom values that follow the purple rules.")
            handlebuy("Blue - 20 CP", ShiftOSDesktop.boughtblue, "Blue is a vital part of the RGB colour system and now that we can use it we should be able to create Purple if we mix it with red." & Environment.NewLine & Environment.NewLine & "With all 3 RGB colours we may be able to start creating different shades of various other colours.")
            handlebuy("Blue Shades - 40 CP", ShiftOSDesktop.boughtblue2, "Now with a darker blue and lighter blue shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Blue Shade Set - 60 CP", ShiftOSDesktop.boughtblue3, "Now with the complete blue shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this blue set we are very close to discovering how to make our own custom shades of blue.")
            handlebuy("Custom Blue Shades - 100 CP", ShiftOSDesktop.boughtblue4, "To make a Blue shade with the RGB colour system blue must have the highest value followed by red. Green must then have the lowest value." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of blue in the colour picker by typing in custom values that follow the blue rules.")
            handlebuy("Green - 20 CP", ShiftOSDesktop.boughtgreen, "Green is a vital part of the RGB colour system and now that we can use it we should be able to create yellow and orange if we mix it with red." & Environment.NewLine & Environment.NewLine & "With all 3 RGB colours we may be able to start creating different shades of various other colours.")
            handlebuy("Green Shades - 40 CP", ShiftOSDesktop.boughtgreen2, "Now with a darker green and lighter green shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Green Shade Set - 60 CP", ShiftOSDesktop.boughtgreen3, "Now with the complete green shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this green set we are very close to discovering how to make our own custom shades of green.")
            handlebuy("Custom Green Shades - 100 CP", ShiftOSDesktop.boughtgreen4, "To make a green shade with the RGB colour system green must have the highest value. Red and Blue need to have values within 150 of each other." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of green in the colour picker by typing in custom values that follow the green rules.")
            handlebuy("Yellow - 20 CP", ShiftOSDesktop.boughtyellow, "Yellow is a great colour to have up on your screen to improve your concentration and make you more alert. Now that you have it you are free to use it throughout ShiftOS." & Environment.NewLine & Environment.NewLine & "Once we have discovered all the basic colours we may be able to use our knowledge to create more shades of the colours we have.")
            handlebuy("Yellow Shades - 40 CP", ShiftOSDesktop.boughtyellow2, "Now with a darker yellow and lighter yellow shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Yellow Shade Set - 60 CP", ShiftOSDesktop.boughtyellow3, "Now with the complete yellow shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this yellow set we are very close to discovering how to make our own custom shades of yellow.")
            handlebuy("Custom Yellow Shades - 100 CP", ShiftOSDesktop.boughtyellow4, "To make a yellow shade with the RGB colour system red must have the highest value and be over 180. Green must be within 30 values of red. Blue must be the lowest value." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of yellow in the colour picker by typing in custom values that follow the yellow rules.")
            handlebuy("Orange - 20 CP", ShiftOSDesktop.boughtorange, "Orange is apparently a color that can increase the desire for humans to eat food. Now that you have it you are free to eat, er… use it throughout ShiftOS." & Environment.NewLine & Environment.NewLine & "Once we have discovered all the basic colours we may be able to use our knowledge to create more shades of the colours we have.")
            handlebuy("Orange Shades - 40 CP", ShiftOSDesktop.boughtorange2, "Now with a darker orange and lighter orange shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Orange Shade Set - 60 CP", ShiftOSDesktop.boughtorange3, "Now with the complete orange shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this orange set we are very close to discovering how to make our own custom shades of orange.")
            handlebuy("Custom Orange Shades - 100 CP", ShiftOSDesktop.boughtorange4, "To make an orange shade with the RGB colour system red must have a value of 255. Green must be 100 or more values less than red. Blue must be 30 or more values less than green." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of orange in the colour picker by typing in custom values that follow the orange rules.")
            handlebuy("Brown - 20 CP", ShiftOSDesktop.boughtbrown, "People who like brown are usually conventional, orderly  and sometimes lazy and repressed. Use it in ShiftOS if you must..." & Environment.NewLine & Environment.NewLine & "Once we have discovered all the basic colours we may be able to use our knowledge to create more shades of the colours we have.")
            handlebuy("Brown Shades - 40 CP", ShiftOSDesktop.boughtbrown2, "Now with a darker brown and lighter brown shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Brown Shade Set - 60 CP", ShiftOSDesktop.boughtbrown3, "Now with the complete brown shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this brown set we are very close to discovering how to make our own custom shades of brown.")
            handlebuy("Custom Brown Shades - 100 CP", ShiftOSDesktop.boughtbrown4, "To make a brown shade with the RGB colour system red must have the highest value. Green must be 30 - 128 values lower than red. Blue must be 60 or more values less than green." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of brown in the colour picker by typing in custom values that follow the brown rules.")
            handlebuy("Red - 20 CP", ShiftOSDesktop.boughtred, "Red is a vital part of the RGB colour system and now that we can use it we may be able to create Purple if we mix it with Blue. If we mix it with Green we may be able to create yellow and orange." & Environment.NewLine & Environment.NewLine & "With all 3 RGB colours we may be able to start creating different shades of various other colours.")
            handlebuy("Red Shades - 40 CP", ShiftOSDesktop.boughtred2, "Now with a darker red and lighter red shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Red Shade Set - 60 CP", ShiftOSDesktop.boughtred3, "Now with the complete red shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this red set we are very close to discovering how to make our own custom shades of red.")
            handlebuy("Custom Red Shades - 100 CP", ShiftOSDesktop.boughtred4, "To make a red shade with the RGB colour system red must have the highest value. Green and blue must be 80 or more values less than red but within 50 values of each other." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of red in the colour picker by typing in custom values that follow the red rules.")
            handlebuy("Pink - 20 CP", ShiftOSDesktop.boughtpink, "Pink is apparently a color that can decrease aggressive behavior. Now that you have it you are free use it throughout ShiftOS if you can handle it ;)" & Environment.NewLine & Environment.NewLine & "Once we have discovered all the basic colours we may be able to use our knowledge to create more shades of the colours we have.")
            handlebuy("Pink Shades - 40 CP", ShiftOSDesktop.boughtpink2, "Now with a darker pink and lighter pink shade at your disposal your ShiftOS interface can be designed with more depth and variety." & Environment.NewLine & Environment.NewLine & "Discovering more of these predefined colour shades may allow us to eventually use the RGB colour system to limitlessly create our own custom colours.")
            handlebuy("Full Pink Shade Set - 60 CP", ShiftOSDesktop.boughtpink3, "Now with the complete pink shade set you can seriously customize your ShiftOS desktop to your liking." & Environment.NewLine & Environment.NewLine & "With the knowledge of the RGB values of this pink set we are very close to discovering how to make our own custom shades of pink.")
            handlebuy("Custom Pink Shades - 100 CP", ShiftOSDesktop.boughtpink4, "To make a pink shade with the RGB colour system red must have the highest value. Blue must be 50 or more values less than red. Green must have the lowest value." & Environment.NewLine & Environment.NewLine & "Now you can make your own shades of pink in the colour picker by typing in custom values that follow the pink rules.")
            handlebuy("Basic Custom shade - 50 CP", ShiftOSDesktop.boughtanycolour, "Amazing! The colour picker can now support the ability to make a single shade not linked to any colour rules." & Environment.NewLine & Environment.NewLine & "Due to system limitations though only one custom shade can be stored and that shade must have an RGB value between 100 and 150. Further research may improve this systems compatibility with the RGB colour system.")
            handlebuy("General Custom Shades - 100 CP", ShiftOSDesktop.boughtanycolour2, "Fantastic, We are now one step closer to complete control over the RGB colour system without any limitations." & Environment.NewLine & Environment.NewLine & "We can now have up to 4 custom shades not linked to certain colour rules. The custom RGB range has now increased to values between 100 and 200. A little more research will continue to break these limits.")
            handlebuy("Advanced Custom Shades - 250 CP", ShiftOSDesktop.boughtanycolour3, "Brilliant! It looks like we are just around the corner from having the full RGB colour system supported natively in ShiftOS." & Environment.NewLine & Environment.NewLine & "You can now have up to 8 custom colours stored in the colour picker but they must have RGB values of 75 to 225.")
            handlebuy("Limitless Custom Shades - 500 CP", ShiftOSDesktop.boughtanycolour4, "This is EPIC! ShiftOS now supports the ability to display 16,777,216 shades of colour. Yes many of them may look the same but now you can have them all!" & Environment.NewLine & Environment.NewLine & "You can now have a full set of 16 stored colours in the colour picker set to any RGB values between 0 and 255. This native RGB support opens up a lot of cross compatibility opportunities in the future.")
            handlebuy("Shifter - 40 CP", ShiftOSDesktop.boughtshifter, "Fantastic! The Shifter can now be opened by typing 'open shifter' in the terminal. In its current state the shifter is simply a basic layout that has no UI Shifting functionality." & Environment.NewLine & Environment.NewLine & "With further research we may be able to add some functionally to it allowing the user to modify the sizes and colours of various UI elements.")
            handlebuy("AL Shifter - 20 CP", ShiftOSDesktop.boughtalshifter, "Your App Launcher is now more complete and will allow you to launch the shifter at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("Roll Up Command - 10 CP", ShiftOSDesktop.boughtrollupcommand, "Great! You can now roll windows up to their title bar whenever you want simply by bringing up the terminal and typing 'roll' followed by the program you want to roll up." & Environment.NewLine & Environment.NewLine & "Typing 'roll shiftorium' will roll the shiftorium application up to its title bar while keeping all its data stored safely. Typing the command again will roll the shiftorium back down.")
            handlebuy("Roll Up Button - 45 CP", ShiftOSDesktop.boughtrollupbutton, "Now isn’t this nice? All your windows now have a black square button on them that will roll windows up and down if you click on it." & Environment.NewLine & Environment.NewLine & "It functions well but if I were you I would attempt to alter its appearance or change its colour so you can better distinguish it from any other buttons you may or may not have.")
            handlebuy("Shift Desktop - 20 CP", ShiftOSDesktop.boughtshiftdesktop, "Brilliant! The Shifter can change your desktop background colour but unfortunately you only use the colours 'Black', 'Gray' and 'White'." & Environment.NewLine & Environment.NewLine & "Further research may allow us to decipher the mysterious colour code allowing us to use more colours throughout ShiftOS with the Colour Picker application.")
            handlebuy("Shift Panel Clock - 20 CP", ShiftOSDesktop.boughtshiftpanelclock, "You can now click on the Panel clock option within the main desktop options to modify various features of the desktop panel clock such as the text size, font and colour." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Shift App Launcher - 20 CP", ShiftOSDesktop.boughtshiftapplauncher, "You can now click on the App Launcher option within the main desktop options to modify various features of the App Launcher such as its name, font and colour." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Shift Desktop Panel - 20 CP", ShiftOSDesktop.boughtshiftdesktoppanel, "You can now click on the Desktop Panel option within the main desktop options to modify various features of the desktop panel such as the position, colour and height." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Shift Title Bar - 20 CP", ShiftOSDesktop.boughtshifttitlebar, "You can now click on the Title Bar option within the Windows options to modify various features of the Title Bar such as the colour and height." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Shift Title Text - 20 CP", ShiftOSDesktop.boughtshifttitletext, "You can now click on the Title Text option within the Windows options to modify various features of the Title Text such as the text size, font and colour." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Shift Title Buttons - 20 CP", ShiftOSDesktop.boughtshifttitlebuttons, "You can now click on the Buttons option within the Windows options to modify various features of the Title Buttons such as their colour and size." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Shift Borders - 20 CP", ShiftOSDesktop.boughtshiftborders, "You can now click on the Borders option within the Windows options to modify various features of the Window Borders such as the colour and size." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")
            handlebuy("Pong - 70 CP", ShiftOSDesktop.boughtpong, "Now, finally time to have a bit of fun! It’s you vs the computer in this mouse controlled game of pong. Simply move your paddle on the left up and down to prevent the ball going past it." & Environment.NewLine & Environment.NewLine & "The longer you survive the faster the ball will get. Survive a minute to make it to the next level. The higher the level you make it to the more codepoints you will earn.")
            handlebuy("Knowledge Input Icon - 15 CP", ShiftOSDesktop.boughtknowledgeinputicon, "Fantastic! We now have an icon for knowledge input that will appear on the left side of the knowledge input window. If you have bought an app launcher with knowledge input on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Shifter Icon - 15 CP", ShiftOSDesktop.boughtshiftericon, "Fantastic! We now have an icon for shifter that will appear on the left side of the shifter window. If you have bought an app launcher with shifter on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Shiftorium Icon - 15 CP", ShiftOSDesktop.boughtshiftoriumicon, "Fantastic! We now have an icon for shiftorium that will appear on the left side of the shiftorium window. If you have bought an app launcher with shiftorium on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Clock Icon - 15 CP", ShiftOSDesktop.boughtclockicon, "Fantastic! We now have an icon for clock that will appear on the left side of the clock window. If you have bought an app launcher with clock on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Shutdown Icon - 15 CP", ShiftOSDesktop.boughtshutdownicon, "Fantastic! We now have an icon for shutdown that will appear on the left side of the shutdown window. If you have bought an app launcher with shutdown on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Pong Icon - 15 CP", ShiftOSDesktop.boughtpongicon, "Fantastic! We now have an icon for pong that will appear on the left side of the pong window. If you have bought an app launcher with pong on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Terminal Icon - 15 CP", ShiftOSDesktop.boughtterminalicon, "Fantastic! We now have an icon for terminal that will appear on the left side of the terminal window. If you have bought an app launcher with terminal on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("File Skimmer Icon - 15 CP", ShiftOSDesktop.boughtfileskimmericon, "Fantastic! We now have an icon for file skimmer that will appear on the left side of the file skimmer window. If you have bought an app launcher with file skimmer on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Textpad Icon - 15 CP", ShiftOSDesktop.boughttextpadicon, "Fantastic! We now have an icon for textpad that will appear on the left side of the textpad window. If you have bought an app launcher with textpad on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("AL Pong - 20 CP", ShiftOSDesktop.boughtalpong, "Your App Launcher is now more complete and will allow you to launch Knowledge input at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("AL File Skimmer - 20 CP", ShiftOSDesktop.boughtalfileskimmer, "Your App Launcher is now more complete and will allow you to launch Knowledge input at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("AL Textpad - 20 CP", ShiftOSDesktop.boughtaltextpad, "Your App Launcher is now more complete and will allow you to launch Knowledge input at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("File Skimmer - 60 CP", ShiftOSDesktop.boughtfileskimmer, "With the File Skimmer application you can freely browse through the files stored on your computer as long as they aren’t system files due to the closed source nature of ShiftOS." & Environment.NewLine & Environment.NewLine & "If you had a text or image editing application you could save files onto your storage device and use the file skimmer to load them up whenever you want.")
            handlebuy("Textpad - 65 CP", ShiftOSDesktop.boughttextpad, "Now whenever you need to remember something or you just feel like writing stuff down you are free to open the Textpad application and type away." & Environment.NewLine & Environment.NewLine & "If you have a program that allows you to access and manage the files on your storage device then with further upgrades you may be able to save and load text files.")
            handlebuy("Textpad New - 25 CP", ShiftOSDesktop.boughttextpadnew, "Gone are the days you need to backspace your text document until all the text is removed. Gone are the days when you used to have to open and close the textpad every time you wanted to write a new document." & Environment.NewLine & Environment.NewLine & "Click the arrow at the bottom of textpad to display a button that will clear your entire text document the moment you click on it.")
            handlebuy("Textpad Save - 25 CP", ShiftOSDesktop.boughttextpadsave, "Now you can save your precious text files onto your storage device knowing that they are totally safe unless you throw your computer out of the window or kick it while its running." & Environment.NewLine & Environment.NewLine & "Click the expander arrow at the bottom of textpad to display the save button. After clicking save simply name your file and it’s yours to keep forever.")
            handlebuy("Textpad Open - 25 CP", ShiftOSDesktop.boughttextpadopen, "See, I know you couldn’t resist making it a few seconds quicker to open your text documents. Either that or you think Textpad looks better with more options at the bottom…" & Environment.NewLine & Environment.NewLine & "To open a file click the expander arrow at the bottom of textpad to display the open button. After clicking open select the file that you wish to view.")
            handlebuy("FS New Folder - 25 CP", ShiftOSDesktop.boughtfileskimmernewfolder, "Now this is more like it! Let’s say you have a few categories of documents. You can now create folders to store them in within the documents folder. Same goes for whatever other files you can think of." & Environment.NewLine & Environment.NewLine & "Simply open File Skimmer and click on the expander arrow at the bottom of the window to find the new folder button.")
            handlebuy("FS Delete - 25 CP", ShiftOSDesktop.boughtfileskimmerdelete, "You now have the power to delete files on your hard drive however proceed with caution because deleting system files will corrupt vital parts of your system causing you to lose your save data." & Environment.NewLine & Environment.NewLine & "At the bottom of the file skimmer click the expander arrow to see delete button. Click a folder or file and then click delete to delete it.")
            handlebuy("KI Elements - 10 CP", ShiftOSDesktop.boughtkielements, "Now that you have added a list of elements to Knowledge Input open it and start guessing as many elements as you can think of!" & Environment.NewLine & Environment.NewLine & "If you still have your old highschool notes from science class have a little skim through them and I’m sure you will strike gold.")
            handlebuy("Colour Picker Icon - 15 CP", ShiftOSDesktop.boughtcolourpickericon, "Fantastic! We now have an icon for colour picker that will appear on the left side of the Colour Picker window. Since the colour picker isn’t a part of the app launcher the icon won’t appear on the app launcher." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Infobox Icon - 15 CP", ShiftOSDesktop.boughtinfoboxicon, "Fantastic! We now have an icon for the Infobox that will appear on the left side of its window. Since the InfoBox isn’t a part of the app launcher the icon won’t appear on the app launcher." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            'new
            handlebuy("Panel Buttons - 75 CP", ShiftOSDesktop.boughtpanelbuttons, "Great! From now on you can simply look at the panel buttons on your desktop panel to see what programs you have open." & Environment.NewLine & Environment.NewLine & "That’s right, the panel buttons don’t do anything when you click them but maybe they will after a few more upgrades…")
            handlebuy("Minimize Command - 20 CP", ShiftOSDesktop.boughtminimizecommand, "Now whenever you have a program open that you wish to hide simply type 'minimize [program name]' and it will be hidden." & Environment.NewLine & Environment.NewLine & "To unhide a program just type the same command again and it will be reappear in the same state you left it in earlier.")
            handlebuy("Minimize Button - 50 CP", ShiftOSDesktop.boughtminimizebutton, "Isn’t this nifty! Each window now has its own minimize button in its title bar so hiding windows is a breeze." & Environment.NewLine & Environment.NewLine & "Unfortunately to you will still need to use the terminal to make windows reappear but maybe another upgrade could provide an alternative.")
            handlebuy("Useful Panel Buttons - 40 CP", ShiftOSDesktop.boughtusefulpanelbuttons, "Finally the panel buttons have a purpose. You can now click on them to unminimize minimized programs." & Environment.NewLine & Environment.NewLine & "Simply click on the panel button labeled with the program you want to unminimize and it will reappear before your eyes.")
            handlebuy("Artpad - 75 CP", ShiftOSDesktop.boughtartpad, "Ah, I knew you were an artist at heart. Get your pixel setter ready and your magnifying glass, you’ll need it to see your 2 pixel masterpiece." & Environment.NewLine & Environment.NewLine & "More tools, more pixels and more colours would be helpful though so be on the lookout for more upgrades.")
            handlebuy("Artpad Pixel Limit 4 - 10 CP", ShiftOSDesktop.boughtartpadpixellimit4, "This increased pixel limit has unlocked the ability to make canvases in artpad totaling 4 whole pixels." & Environment.NewLine & Environment.NewLine & "You can make a variety of interesting artworks such as um, a 4 pixel high tower or a 4 pixel tower lying on its side and err, other stuff.")
            handlebuy("Artpad Pixel Limit 8 - 20 CP", ShiftOSDesktop.boughtartpadpixellimit8, "Great you can now have canvases with a total of 8 pixels." & Environment.NewLine & Environment.NewLine & "It may not seem like much but… oh I give up, it’s still hopeless. On the bright side you can always buy another upgrade.")
            handlebuy("Artpad Pixel Limit 16 - 30 CP", ShiftOSDesktop.boughtartpadpixellimit16, "You’ve just doubled your pixel limit from 8 to 16." & Environment.NewLine & Environment.NewLine & "You can now make a very cramped smiley face without a nose or a quarter of a chess board if you put your mind to it.")
            handlebuy("Artpad Pixel Limit 64 - 50 CP", ShiftOSDesktop.boughtartpadpixellimit64, "Finally you are starting to make it into deeper waters." & Environment.NewLine & Environment.NewLine & "I’m not quite sure what I meant by that but if you’re drawing ocean scenes you could make them deeper and if you’re up to it you could draw a full chessboard without and pieces on it.")
            handlebuy("Artpad Pixel Limit 256 - 75 CP", ShiftOSDesktop.boughtartpadpixellimit256, "Actually I just realized that with 256 pixels the biggest canvas size you can make is 16 by 16 pixels." & Environment.NewLine & Environment.NewLine & "Still that’s enough pixels to make a picture of a grave yard with gravestones and sad faces right?")
            handlebuy("Artpad Pixel Limit 1024 - 100 CP", ShiftOSDesktop.boughtartpadpixellimit1024, "Designing things like UI elements should be a breeze with this limit." & Environment.NewLine & Environment.NewLine & "Many icon designers used to make their icons at a resolution of 32 by 32 pixels so if you want to make those kind of icons then you’re all set.")
            handlebuy("Artpad Pixel Limit 4096 - 150 CP", ShiftOSDesktop.boughtartpadpixellimit4096, "Finally we are nearing the point where you are able to draw freely at a zoom level of 1x." & Environment.NewLine & Environment.NewLine & "Overall though 4096 pixels is still not good for large free hand sketch-like drawings.")
            handlebuy("Artpad Pixel Limit 16384 - 200 CP", ShiftOSDesktop.boughtartpadpixellimit16384, "Awesome! Now you can try and do some free hand drawing at 4x magnification with a canvas size of 160 by 100" & Environment.NewLine & Environment.NewLine & "You may even be able to design tiny website banners.")
            handlebuy("Artpad Pixel Limit 65536 - 250 CP", ShiftOSDesktop.boughtartpadpixellimit65536, "Go ahead and celebrate your seemingly limitless pixel limit for a moment and don’t look at the upgrade list." & Environment.NewLine & Environment.NewLine & "You couldn’t resist looking and making this upgrade seem so small could you? That’s right, you’re an upgrade away from truly limitless pixels.")
            handlebuy("Artpad Limitless Pixels - 350 CP", ShiftOSDesktop.boughtartpadlimitlesspixels, "Congratulations you now have absolutely no pixel limit and can create canvases as big as you want as long as your own computer can handle it." & Environment.NewLine & Environment.NewLine & "Go ahead and make yourself a native resolution desktop background to celebrate!")
            handlebuy("Artpad New - 10 CP", ShiftOSDesktop.boughtartpadnew, "Much better. A new button that looks like a folded page should now be in your tool set." & Environment.NewLine & Environment.NewLine & "By clicking the button you should be able create a new canvas and even type in a new size for it as many times as you like without opening and closing Artpad.")
            handlebuy("Artpad Save - 50 CP", ShiftOSDesktop.boughtartpadsave, "Now with your new saving ability you can save all those amazing artpad creations to be viewed at any point in the future" & Environment.NewLine & Environment.NewLine & "Every time you save a picture the amount of codepoints you earned for making it will appear briefly as title text or in an info box.")
            handlebuy("Artpad Load - 50 CP", ShiftOSDesktop.boughtartpadload, "You should now be able to load old .pic files by clicking the load button in your tool box and choosing the file you want with the file opener" & Environment.NewLine & Environment.NewLine & "The image will then pop up in artpad and you can get right to editing.")
            handlebuy("Artpad Undo - 40 CP", ShiftOSDesktop.boughtartpadundo, "From now on a line draw too long or the wrong splash of colour can’t hurt you anymore." & Environment.NewLine & Environment.NewLine & "An undo button has been added to your toolbox and any time you make a mistake on your canvas you can fix it with a single click of that button.")
            handlebuy("Artpad Redo - 40 CP", ShiftOSDesktop.boughtartpadredo, "Now that you can redo any undone actions you are totally free to cycle forwards and backwards through your work." & Environment.NewLine & Environment.NewLine & "If you really wanted you could undo all your work then keep clicking redo to watch the creation of your entire picture.")
            handlebuy("Artpad Pixel Placer - 20 CP", ShiftOSDesktop.boughtartpadpixelplacer, "Now with the new Pixel Placer you have the power to simply click any pixel to change its colour." & Environment.NewLine & Environment.NewLine & "Simply left click a colour pallet then click any pixel on your canvas to set it to that colour. You can also right click your colour pallets to change their colour.")
            handlebuy("Artpad PP Movement Mode - 20 CP", ShiftOSDesktop.boughtartpadpixelplacermovementmode, "The Pixel Placer now has a movement mode option. Simply Click the Pixel Placer tool and you will see the Movement Mode Switch in the options panel." & Environment.NewLine & Environment.NewLine & "When movement mode is on you can click and drag slowly to draw pixels with the mouse. Be slow otherwise it may skip pixels though.")
            handlebuy("Artpad Pencil - 30 CP", ShiftOSDesktop.boughtartpadpencil, "Fantastic! You now have a new pencil tool which you can access from the toolbox." & Environment.NewLine & Environment.NewLine & "You can now draw as fast as you want freehand and it won’t skip a single pixel. You can also draw with three different levels of thickness which can be set in the pencil’s option panel.")
            handlebuy("Artpad Paint Brush - 30 CP", ShiftOSDesktop.boughtartpadpaintbrush, "You now have access to the paintbrush tool which you can use simply by clicking on its icon in the tool box." & Environment.NewLine & Environment.NewLine & "A good thing about the paint brush is that you can set its size to a specific value in pixels making it perfect for a variety of different situations.")
            handlebuy("Artpad Line Tool - 30 CP", ShiftOSDesktop.boughtartpadlinetool, "Great! You got a line tool. You can begin using it by selecting the tool from your toolbox." & Environment.NewLine & Environment.NewLine & "Simply click and drag on your canvas to draw a horizontal, vertical or diagonal line on your canvas.")
            handlebuy("Artpad Oval Tool - 40 CP", ShiftOSDesktop.boughtartpadovaltool, "The new oval tool now allows you to draw circles and ovals with the mouse just by clicking and dragging on the canvas." & Environment.NewLine & Environment.NewLine & "You can also change the inside and outside colour of the ovals and change their border width in the options panel.")
            handlebuy("Artpad Rectangle Tool - 40 CP", ShiftOSDesktop.boughtartpadrectangletool, "The new rectangle tool now allows you to draw squares and rectangles with the mouse just by clicking and dragging on the canvas." & Environment.NewLine & Environment.NewLine & "You can also change the inside and outside colour of the rectangles and change their border width in the options panel.")
            handlebuy("Artpad Eraser - 20 CP", ShiftOSDesktop.boughtartpaderaser, "Your toolbox now has a new addition to it, An Eraser!" & Environment.NewLine & Environment.NewLine & "The eraser tool can be circular or square and any size you want. Clicking and dragging on the canvas will remove any colour on it and replace it with the default canvas colour which in most cases will be white.")
            handlebuy("Artpad Fill Tool - 60 CP", ShiftOSDesktop.boughtartpadfilltool, "Fantastic! You now have a new fill tool which you can access from the toolbox." & Environment.NewLine & Environment.NewLine & "To use the fill tool you simply have to click it, choose a colour then click a pixel on the canvas and it and every surrounding pixel matching its colour will become the new colour you set.")
            handlebuy("Artpad Text Tool - 45 CP", ShiftOSDesktop.boughtartpadtexttool, "A text tool is now sitting in your toolbox waiting patiently for you to use it." & Environment.NewLine & Environment.NewLine & "Simply choose a font, colour and size then type something in and click and drag the mouse to move the text around on the canvas until you are happy with its position. Once you’re done release the mouse and the text will be placed in the spot you chose.")
            handlebuy("Artpad 4 Color Pallets - 10 CP", ShiftOSDesktop.boughtartpad4colorpallets, "Two new black colour pallets are available for you to use in the artpad." & Environment.NewLine & Environment.NewLine & "If you would like to change the colour of any of the colour pallets you can do so by right clicking them and then selecting a colour you would like to be from the colour picker.")
            handlebuy("Artpad 8 Color Pallets - 20 CP", ShiftOSDesktop.boughtartpad8colorpallets, "Four new black colour pallets are available for you to use in the artpad." & Environment.NewLine & Environment.NewLine & "If you would like to change the colour of any of the colour pallets you can do so by right clicking them and then selecting a colour you would like to be from the colour picker.")
            handlebuy("Artpad 16 Color Pallets - 35 CP", ShiftOSDesktop.boughtartpad16colorpallets, "Eight new black colour pallets are available for you to use in the artpad." & Environment.NewLine & Environment.NewLine & "If you would like to change the colour of any of the colour pallets you can do so by right clicking them and then selecting a colour you would like to be from the colour picker.")
            handlebuy("Artpad 32 Color Pallets - 50 CP", ShiftOSDesktop.boughtartpad32colorpallets, "Sixteen new black colour pallets are available for you to use in the artpad." & Environment.NewLine & Environment.NewLine & "If you would like to change the colour of any of the colour pallets you can do so by right clicking them and then selecting a colour you would like to be from the colour picker.")
            handlebuy("Artpad 64 Color Pallets - 100 CP", ShiftOSDesktop.boughtartpad64colorpallets, "Thirty Two new black colour pallets are available for you to use in the artpad." & Environment.NewLine & Environment.NewLine & "If you would like to change the colour of any of the colour pallets you can do so by right clicking them and then selecting a colour you would like to be from the colour picker.")
            handlebuy("Artpad 128 Color Pallets - 150 CP", ShiftOSDesktop.boughtartpad128colorpallets, "Sixty Four new black colour pallets are available for you to use in the artpad." & Environment.NewLine & Environment.NewLine & "If you would like to change the colour of any of the colour pallets you can do so by right clicking them and then selecting a colour you would like to be from the colour picker.")
            handlebuy("Artpad Custom Pallets - 75 CP", ShiftOSDesktop.boughtartpadcustompallets, "Nice! The colour pallets are now able to be resized any time you like and you can even adjust the spaces between pallets." & Environment.NewLine & Environment.NewLine & "To resize the colour pallets simply middle click any of them and a special settings window will pop up.")
            handlebuy("Skinning - 80 CP", ShiftOSDesktop.boughtskinning, "Brilliant! A skinning system is now in place. You now have a new graphic picker and skin loader at your disposal." & Environment.NewLine & Environment.NewLine & "Right click colour boxes in the Shifter to bring up the graphic picker instead of the colour picker.")
            handlebuy("Unity Mode - 1000 CP", ShiftOSDesktop.boughtunitymode, "Amazing! A new mode called ‘unity mode’ can be turned on and off in the terminal by typing ‘unity mode on’ or ‘unity mode off’." & Environment.NewLine & Environment.NewLine & "With unity mode on you should be able to run ShiftOS applications and Windows applications side by side.")
            handlebuy("AL Artpad - 20 CP", ShiftOSDesktop.boughtalartpad, "Your App Launcher is now more complete and will allow you to launch artpad at any time you like." & Environment.NewLine & Environment.NewLine & "Be sure to buy tweaks to add all your installed programs to the app launcher so you never have to use the terminal to open up a program ever again!")
            handlebuy("Artpad Icon - 15 CP", ShiftOSDesktop.boughtartpadicon, "Fantastic! We now have an icon for artpad that will appear on the left side of the artpad window. If you have bought an app launcher with clock on it then an icon will appear there as well." & Environment.NewLine & Environment.NewLine & "The occasional icon here and there looks a little out of place though so be sure to buy more icons for the other programs!")
            handlebuy("Shift Panel Buttons - 20 CP", ShiftOSDesktop.boughtshiftpanelbuttons, "You can now click on the Panel Buttons option within the desktop panel options to modify various features of the panel buttons such as the text size, font and colour." & Environment.NewLine & Environment.NewLine & "Modifying these various settings will earn you codepoints. The longer spend tinkering with the options the more codepoints you will earn when you click 'Apply Changes.")

            handleupgradelist()
        End If
    End Sub

    Private Sub handleupgradelist()
        lbupgrades.Items.Clear()
        lbcodepoints.Text = "Codepoints: " & ShiftOSDesktop.codepoints
        If ShiftOSDesktop.boughtgray = False Then lbupgrades.Items.Add("Gray - 20 CP")
        If ShiftOSDesktop.boughtsecondspastmidnight = False Then lbupgrades.Items.Add("Seconds Since Midnight - 10 CP")
        If ShiftOSDesktop.boughtcustomusername = False Then lbupgrades.Items.Add("Custom Username - 15 CP")
        If ShiftOSDesktop.boughtwindowsanywhere = False Then lbupgrades.Items.Add("Windows Anywhere - 25 CP")
        If ShiftOSDesktop.boughtmultitasking = False Then lbupgrades.Items.Add("Multitasking - 50 CP")
        If ShiftOSDesktop.boughtautoscrollterminal = False Then lbupgrades.Items.Add("Auto Scroll Terminal - 5 CP")
        If ShiftOSDesktop.boughtkiaddons = False Then lbupgrades.Items.Add("KI Addons - 15 CP")
        If ShiftOSDesktop.boughtpong = False Then lbupgrades.Items.Add("Pong - 70 CP")
        If ShiftOSDesktop.boughtfileskimmer = False Then lbupgrades.Items.Add("File Skimmer - 60 CP")
        If ShiftOSDesktop.boughttextpad = False Then lbupgrades.Items.Add("Textpad - 65 CP")

        If ShiftOSDesktop.boughttextpad = True Then
            If ShiftOSDesktop.boughttextpadnew = False Then lbupgrades.Items.Add("Textpad New - 25 CP")
            If ShiftOSDesktop.boughtfileskimmer = True Then
                If ShiftOSDesktop.boughttextpadsave = False Then lbupgrades.Items.Add("Textpad Save - 25 CP")
                If ShiftOSDesktop.boughttextpadopen = False Then lbupgrades.Items.Add("Textpad Open - 25 CP")
            End If
        End If

        If ShiftOSDesktop.boughtfileskimmer = True Then
            If ShiftOSDesktop.boughtfileskimmernewfolder = False Then lbupgrades.Items.Add("FS New Folder - 25 CP")
            If ShiftOSDesktop.boughtfileskimmerdelete = False Then lbupgrades.Items.Add("FS Delete - 25 CP")
        End If

        If ShiftOSDesktop.boughtkiaddons = True Then
            If ShiftOSDesktop.boughtkicarbrands = False Then lbupgrades.Items.Add("KI Car Brands - 10 CP")
            If ShiftOSDesktop.boughtkigameconsoles = False Then lbupgrades.Items.Add("KI Game Consoles - 10 CP")
            If ShiftOSDesktop.boughtkielements = False Then lbupgrades.Items.Add("KI Elements - 10 CP")
        End If

        If ShiftOSDesktop.boughtmultitasking = True Then
            If ShiftOSDesktop.boughtwindowedterminal = False Then lbupgrades.Items.Add("Windowed Terminal - 45 CP")
            If ShiftOSDesktop.boughtwindowedterminal = True Then
                If ShiftOSDesktop.boughtterminalscrollbar = False Then lbupgrades.Items.Add("Terminal Scrollbar - 20 CP")
            End If
        End If

        If ShiftOSDesktop.boughtgray = True Then
            If ShiftOSDesktop.boughtshifter = False Then lbupgrades.Items.Add("Shifter - 40 CP")
            If ShiftOSDesktop.boughtshifter = True Then
                If ShiftOSDesktop.boughtshiftdesktop = False Then lbupgrades.Items.Add("Shift Desktop - 20 CP")
                If ShiftOSDesktop.boughtshiftdesktop = True Then
                    If ShiftOSDesktop.boughtdesktoppanelclock = True Then
                        If ShiftOSDesktop.boughtshiftpanelclock = False Then lbupgrades.Items.Add("Shift Panel Clock - 20 CP")
                    End If
                    If ShiftOSDesktop.boughtapplaunchermenu = True Then
                        If ShiftOSDesktop.boughtshiftapplauncher = False Then lbupgrades.Items.Add("Shift App Launcher - 20 CP")
                    End If
                    If ShiftOSDesktop.boughtdesktoppanel = True Then
                        If ShiftOSDesktop.boughtshiftdesktoppanel = False Then lbupgrades.Items.Add("Shift Desktop Panel - 20 CP")
                    End If
                    If ShiftOSDesktop.boughttitlebar = True Then
                        If ShiftOSDesktop.boughtshifttitlebar = False Then lbupgrades.Items.Add("Shift Title Bar - 20 CP")
                    End If
                    If ShiftOSDesktop.boughttitletext = True Then
                        If ShiftOSDesktop.boughtshifttitletext = False Then lbupgrades.Items.Add("Shift Title Text - 20 CP")
                    End If
                    If ShiftOSDesktop.boughtclosebutton = True OrElse ShiftOSDesktop.boughtrollupbutton = True Then
                        If ShiftOSDesktop.boughtshifttitlebuttons = False Then lbupgrades.Items.Add("Shift Title Buttons - 20 CP")
                    End If
                    If ShiftOSDesktop.boughtwindowborders = True Then
                        If ShiftOSDesktop.boughtshiftborders = False Then lbupgrades.Items.Add("Shift Borders - 20 CP")
                    End If
                End If
            End If
            If ShiftOSDesktop.boughttitlebar = False Then lbupgrades.Items.Add("Title Bar - 80 CP")
            If ShiftOSDesktop.boughtdesktoppanel = False Then lbupgrades.Items.Add("Desktop Panel - 150 CP")
            If ShiftOSDesktop.boughtwindowborders = False Then lbupgrades.Items.Add("Window Borders - 40 CP")
            If ShiftOSDesktop.boughtshiftdesktop = True Then
                If ShiftOSDesktop.boughtgray2 = False Then lbupgrades.Items.Add("Gray Shades - 40 CP")
            End If
            If ShiftOSDesktop.boughtgray2 = True Then
                If ShiftOSDesktop.boughtgray3 = False Then lbupgrades.Items.Add("Full Gray Shade Set - 60 CP")
                If ShiftOSDesktop.boughtgray3 = True Then
                    If ShiftOSDesktop.boughtgray4 = False Then lbupgrades.Items.Add("Custom Gray Shades - 100 CP")
                End If
            End If
        End If

        If ShiftOSDesktop.boughtgray4 = True Then
            If ShiftOSDesktop.boughtblue = True Then
                If ShiftOSDesktop.boughtred = True Then
                    If ShiftOSDesktop.boughtpurple = False Then lbupgrades.Items.Add("Purple - 20 CP")
                    If ShiftOSDesktop.boughtpurple = True Then
                        If ShiftOSDesktop.boughtblue = True Then
                            If ShiftOSDesktop.boughtgreen = True Then
                                If ShiftOSDesktop.boughtyellow = True Then
                                    If ShiftOSDesktop.boughtorange = True Then
                                        If ShiftOSDesktop.boughtbrown = True Then
                                            If ShiftOSDesktop.boughtred = True Then
                                                If ShiftOSDesktop.boughtpink = True Then
                                                    If ShiftOSDesktop.boughtpurple2 = False Then lbupgrades.Items.Add("Purple Shades - 40 CP")
                                                    If ShiftOSDesktop.boughtpurple2 = True Then
                                                        If ShiftOSDesktop.boughtpurple3 = False Then lbupgrades.Items.Add("Full Purple Shade Set - 60 CP")
                                                        If ShiftOSDesktop.boughtpurple3 = True Then
                                                            If ShiftOSDesktop.boughtpurple4 = False Then lbupgrades.Items.Add("Custom Purple Shades - 100 CP")
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtblue = False Then lbupgrades.Items.Add("Blue - 20 CP")
            If ShiftOSDesktop.boughtblue = True Then
                If ShiftOSDesktop.boughtpurple = True Then
                    If ShiftOSDesktop.boughtblue = True Then
                        If ShiftOSDesktop.boughtgreen = True Then
                            If ShiftOSDesktop.boughtyellow = True Then
                                If ShiftOSDesktop.boughtorange = True Then
                                    If ShiftOSDesktop.boughtbrown = True Then
                                        If ShiftOSDesktop.boughtred = True Then
                                            If ShiftOSDesktop.boughtpink = True Then
                                                If ShiftOSDesktop.boughtblue2 = False Then lbupgrades.Items.Add("Blue Shades - 40 CP")
                                                If ShiftOSDesktop.boughtblue2 = True Then
                                                    If ShiftOSDesktop.boughtblue3 = False Then lbupgrades.Items.Add("Full Blue Shade Set - 60 CP")
                                                    If ShiftOSDesktop.boughtblue3 = True Then
                                                        If ShiftOSDesktop.boughtblue4 = False Then lbupgrades.Items.Add("Custom Blue Shades - 100 CP")
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If ShiftOSDesktop.boughtgreen = False Then lbupgrades.Items.Add("Green - 20 CP")
            If ShiftOSDesktop.boughtgreen = True Then
                If ShiftOSDesktop.boughtpurple = True Then
                    If ShiftOSDesktop.boughtblue = True Then
                        If ShiftOSDesktop.boughtgreen = True Then
                            If ShiftOSDesktop.boughtyellow = True Then
                                If ShiftOSDesktop.boughtorange = True Then
                                    If ShiftOSDesktop.boughtbrown = True Then
                                        If ShiftOSDesktop.boughtred = True Then
                                            If ShiftOSDesktop.boughtpink = True Then
                                                If ShiftOSDesktop.boughtgreen2 = False Then lbupgrades.Items.Add("Green Shades - 40 CP")
                                                If ShiftOSDesktop.boughtgreen2 = True Then
                                                    If ShiftOSDesktop.boughtgreen3 = False Then lbupgrades.Items.Add("Full Green Shade Set - 60 CP")
                                                    If ShiftOSDesktop.boughtgreen3 = True Then
                                                        If ShiftOSDesktop.boughtgreen4 = False Then lbupgrades.Items.Add("Custom Green Shades - 100 CP")
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtgreen = True Then
                If ShiftOSDesktop.boughtred = True Then
                    If ShiftOSDesktop.boughtyellow = False Then lbupgrades.Items.Add("Yellow - 20 CP")
                    If ShiftOSDesktop.boughtpurple = True Then
                        If ShiftOSDesktop.boughtblue = True Then
                            If ShiftOSDesktop.boughtgreen = True Then
                                If ShiftOSDesktop.boughtyellow = True Then
                                    If ShiftOSDesktop.boughtorange = True Then
                                        If ShiftOSDesktop.boughtbrown = True Then
                                            If ShiftOSDesktop.boughtred = True Then
                                                If ShiftOSDesktop.boughtpink = True Then
                                                    If ShiftOSDesktop.boughtyellow2 = False Then lbupgrades.Items.Add("Yellow Shades - 40 CP")
                                                    If ShiftOSDesktop.boughtyellow2 = True Then
                                                        If ShiftOSDesktop.boughtyellow3 = False Then lbupgrades.Items.Add("Full Yellow Shade Set - 60 CP")
                                                        If ShiftOSDesktop.boughtyellow3 = True Then
                                                            If ShiftOSDesktop.boughtyellow4 = False Then lbupgrades.Items.Add("Custom Yellow Shades - 100 CP")
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtgreen = True Then
                If ShiftOSDesktop.boughtred = True Then
                    If ShiftOSDesktop.boughtorange = False Then lbupgrades.Items.Add("Orange - 20 CP")
                    If ShiftOSDesktop.boughtpurple = True Then
                        If ShiftOSDesktop.boughtblue = True Then
                            If ShiftOSDesktop.boughtgreen = True Then
                                If ShiftOSDesktop.boughtyellow = True Then
                                    If ShiftOSDesktop.boughtorange = True Then
                                        If ShiftOSDesktop.boughtbrown = True Then
                                            If ShiftOSDesktop.boughtred = True Then
                                                If ShiftOSDesktop.boughtpink = True Then
                                                    If ShiftOSDesktop.boughtorange2 = False Then lbupgrades.Items.Add("Orange Shades - 40 CP")
                                                    If ShiftOSDesktop.boughtorange2 = True Then
                                                        If ShiftOSDesktop.boughtorange3 = False Then lbupgrades.Items.Add("Full Orange Shade Set - 60 CP")
                                                        If ShiftOSDesktop.boughtorange3 = True Then
                                                            If ShiftOSDesktop.boughtorange4 = False Then lbupgrades.Items.Add("Custom Orange Shades - 100 CP")
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtgreen = True Then
                If ShiftOSDesktop.boughtred = True Then
                    If ShiftOSDesktop.boughtblue = True Then
                        If ShiftOSDesktop.boughtbrown = False Then lbupgrades.Items.Add("Brown - 20 CP")
                        If ShiftOSDesktop.boughtpurple = True Then
                            If ShiftOSDesktop.boughtblue = True Then
                                If ShiftOSDesktop.boughtgreen = True Then
                                    If ShiftOSDesktop.boughtyellow = True Then
                                        If ShiftOSDesktop.boughtorange = True Then
                                            If ShiftOSDesktop.boughtbrown = True Then
                                                If ShiftOSDesktop.boughtred = True Then
                                                    If ShiftOSDesktop.boughtpink = True Then
                                                        If ShiftOSDesktop.boughtbrown2 = False Then lbupgrades.Items.Add("Brown Shades - 40 CP")
                                                        If ShiftOSDesktop.boughtbrown2 = True Then
                                                            If ShiftOSDesktop.boughtbrown3 = False Then lbupgrades.Items.Add("Full Brown Shade Set - 60 CP")
                                                            If ShiftOSDesktop.boughtbrown3 = True Then
                                                                If ShiftOSDesktop.boughtbrown4 = False Then lbupgrades.Items.Add("Custom Brown Shades - 100 CP")
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtred = False Then lbupgrades.Items.Add("Red - 20 CP")
            If ShiftOSDesktop.boughtred = True Then
                If ShiftOSDesktop.boughtpurple = True Then
                    If ShiftOSDesktop.boughtblue = True Then
                        If ShiftOSDesktop.boughtgreen = True Then
                            If ShiftOSDesktop.boughtyellow = True Then
                                If ShiftOSDesktop.boughtorange = True Then
                                    If ShiftOSDesktop.boughtbrown = True Then
                                        If ShiftOSDesktop.boughtred = True Then
                                            If ShiftOSDesktop.boughtpink = True Then
                                                If ShiftOSDesktop.boughtred2 = False Then lbupgrades.Items.Add("Red Shades - 40 CP")
                                                If ShiftOSDesktop.boughtred2 = True Then
                                                    If ShiftOSDesktop.boughtred3 = False Then lbupgrades.Items.Add("Full Red Shade Set - 60 CP")
                                                    If ShiftOSDesktop.boughtred3 = True Then
                                                        If ShiftOSDesktop.boughtred4 = False Then lbupgrades.Items.Add("Custom Red Shades - 100 CP")
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtblue = True Then
                If ShiftOSDesktop.boughtred = True Then
                    If ShiftOSDesktop.boughtgreen = True Then
                        If ShiftOSDesktop.boughtpink = False Then lbupgrades.Items.Add("Pink - 20 CP")
                        If ShiftOSDesktop.boughtpurple = True Then
                            If ShiftOSDesktop.boughtblue = True Then
                                If ShiftOSDesktop.boughtgreen = True Then
                                    If ShiftOSDesktop.boughtyellow = True Then
                                        If ShiftOSDesktop.boughtorange = True Then
                                            If ShiftOSDesktop.boughtbrown = True Then
                                                If ShiftOSDesktop.boughtred = True Then
                                                    If ShiftOSDesktop.boughtpink = True Then
                                                        If ShiftOSDesktop.boughtpink2 = False Then lbupgrades.Items.Add("Pink Shades - 40 CP")
                                                        If ShiftOSDesktop.boughtpink2 = True Then
                                                            If ShiftOSDesktop.boughtpink3 = False Then lbupgrades.Items.Add("Full Pink Shade Set - 60 CP")
                                                            If ShiftOSDesktop.boughtpink3 = True Then
                                                                If ShiftOSDesktop.boughtpink4 = False Then lbupgrades.Items.Add("Custom Pink Shades - 100 CP")
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If ShiftOSDesktop.boughtpurple4 = True Then
                If ShiftOSDesktop.boughtblue4 = True Then
                    If ShiftOSDesktop.boughtgreen4 = True Then
                        If ShiftOSDesktop.boughtyellow4 = True Then
                            If ShiftOSDesktop.boughtorange4 = True Then
                                If ShiftOSDesktop.boughtbrown4 = True Then
                                    If ShiftOSDesktop.boughtred4 = True Then
                                        If ShiftOSDesktop.boughtpink4 = True Then
                                            If ShiftOSDesktop.boughtanycolour = False Then lbupgrades.Items.Add("Basic Custom shade - 50 CP")
                                            If ShiftOSDesktop.boughtanycolour = True Then
                                                If ShiftOSDesktop.boughtanycolour2 = False Then lbupgrades.Items.Add("General Custom Shades - 100 CP")
                                                If ShiftOSDesktop.boughtanycolour2 = True Then
                                                    If ShiftOSDesktop.boughtanycolour3 = False Then lbupgrades.Items.Add("Advanced Custom Shades - 250 CP")
                                                    If ShiftOSDesktop.boughtanycolour3 = True Then
                                                        If ShiftOSDesktop.boughtanycolour4 = False Then lbupgrades.Items.Add("Limitless Custom Shades - 500 CP")
                                                        If ShiftOSDesktop.boughtanycolour4 = True Then
                                                            If ShiftOSDesktop.boughtunitymode = False Then lbupgrades.Items.Add("Unity Mode - 1000 CP")
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If


        If ShiftOSDesktop.boughtdesktoppanel = True Then
            If ShiftOSDesktop.boughtapplaunchermenu = False Then lbupgrades.Items.Add("App Launcher Menu - 120 CP")
            If ShiftOSDesktop.boughtsecondspastmidnight = True Then
                If ShiftOSDesktop.boughtdesktoppanelclock = False Then lbupgrades.Items.Add("Desktop Panel Clock - 75 CP")
            End If
            If ShiftOSDesktop.boughtpanelbuttons = False Then lbupgrades.Items.Add("Panel Buttons - 75 CP")
            If ShiftOSDesktop.boughtpanelbuttons = True Then
                If ShiftOSDesktop.boughtusefulpanelbuttons = False Then lbupgrades.Items.Add("Useful Panel Buttons - 40 CP")
                If ShiftOSDesktop.boughtshiftpanelbuttons = False Then lbupgrades.Items.Add("Shift Panel Buttons - 20 CP")
            End If
        End If

        If ShiftOSDesktop.boughtapplaunchermenu = True Then
            If ShiftOSDesktop.boughtalknowledgeinput = False Then lbupgrades.Items.Add("AL Knowledge Input - 20 CP")
            If ShiftOSDesktop.boughtclock = True Then
                If ShiftOSDesktop.boughtalclock = False Then lbupgrades.Items.Add("AL Clock - 20 CP")
            End If
            If ShiftOSDesktop.boughtpong = True Then
                If ShiftOSDesktop.boughtalpong = False Then lbupgrades.Items.Add("AL Pong - 20 CP")
            End If
            If ShiftOSDesktop.boughtfileskimmer = True Then
                If ShiftOSDesktop.boughtalfileskimmer = False Then lbupgrades.Items.Add("AL File Skimmer - 20 CP")
            End If
            If ShiftOSDesktop.boughttextpad = True Then
                If ShiftOSDesktop.boughtaltextpad = False Then lbupgrades.Items.Add("AL Textpad - 20 CP")
            End If
            If ShiftOSDesktop.boughtartpad = True Then
                If ShiftOSDesktop.boughtalartpad = False Then lbupgrades.Items.Add("AL Artpad - 20 CP")
            End If
            If ShiftOSDesktop.boughtshifter = True Then
                If ShiftOSDesktop.boughtalshifter = False Then lbupgrades.Items.Add("AL Shifter - 20 CP")
            End If
            If ShiftOSDesktop.boughtalshiftorium = False Then lbupgrades.Items.Add("AL Shiftorium - 20 CP")
            If ShiftOSDesktop.boughtapplaunchershutdown = False Then lbupgrades.Items.Add("App Launcher Shutdown - 40 CP")
        End If

        If ShiftOSDesktop.boughtsecondspastmidnight = True Then
            If ShiftOSDesktop.boughtclock = False Then lbupgrades.Items.Add("Clock - 50 CP")
            If ShiftOSDesktop.boughtminutespastmidnight = False Then lbupgrades.Items.Add("Minutes Since Midnight - 20 CP")
            If ShiftOSDesktop.boughtminutespastmidnight = True Then
                If ShiftOSDesktop.boughthourspastmidnight = False Then lbupgrades.Items.Add("Hours Since Midnight - 40 CP")
                If ShiftOSDesktop.boughthourspastmidnight = True Then
                    If ShiftOSDesktop.boughtpmandam = False Then lbupgrades.Items.Add("PM and AM - 60 CP")
                    If ShiftOSDesktop.boughtpmandam = True Then
                        If ShiftOSDesktop.boughtminuteaccuracytime = False Then lbupgrades.Items.Add("Minute Accuracy Time - 80 CP")
                        If ShiftOSDesktop.boughtminuteaccuracytime = True Then
                            If ShiftOSDesktop.boughtsplitsecondtime = False Then lbupgrades.Items.Add("Split Second Time - 100 CP")
                        End If
                    End If
                End If
            End If
        End If

        If ShiftOSDesktop.boughtwindowsanywhere = True Then
            If ShiftOSDesktop.boughtmovablewindows = False Then lbupgrades.Items.Add("Movable Windows - 75 CP")
        End If

        If ShiftOSDesktop.boughttitlebar = True Then
            If ShiftOSDesktop.boughttitletext = False Then lbupgrades.Items.Add("Title Text - 40 CP")
            If ShiftOSDesktop.boughtclosebutton = False Then lbupgrades.Items.Add("Close Button - 90 CP")
            If ShiftOSDesktop.boughtrollupcommand = False Then lbupgrades.Items.Add("Roll Up Command - 10 CP")
            If ShiftOSDesktop.boughtrollupcommand = True Then
                If ShiftOSDesktop.boughtrollupbutton = False Then lbupgrades.Items.Add("Roll Up Button - 45 CP")
                If ShiftOSDesktop.boughtminimizecommand = False Then lbupgrades.Items.Add("Minimize Command - 20 CP")
                If ShiftOSDesktop.boughtminimizecommand = True Then
                    If ShiftOSDesktop.boughtminimizebutton = False Then lbupgrades.Items.Add("Minimize Button - 50 CP")
                End If
            End If
            If ShiftOSDesktop.boughtmovablewindows = True Then
                If ShiftOSDesktop.boughtdraggablewindows = False Then lbupgrades.Items.Add("Draggable Windows - 150 CP")
            End If
        End If

        If ShiftOSDesktop.boughttitletext = True Then
            If ShiftOSDesktop.boughtknowledgeinputicon = False Then lbupgrades.Items.Add("Knowledge Input Icon - 15 CP")
            If ShiftOSDesktop.boughtknowledgeinputicon = True Then
                If ShiftOSDesktop.boughtshiftoriumicon = False Then lbupgrades.Items.Add("Shiftorium Icon - 15 CP")
                If ShiftOSDesktop.boughtterminalicon = False Then lbupgrades.Items.Add("Terminal Icon - 15 CP")
                If ShiftOSDesktop.boughtshifter = True Then
                    If ShiftOSDesktop.boughtshiftericon = False Then lbupgrades.Items.Add("Shifter Icon - 15 CP")
                    If ShiftOSDesktop.boughtinfoboxicon = False Then lbupgrades.Items.Add("Infobox Icon - 15 CP")
                    If ShiftOSDesktop.boughtcolourpickericon = False Then lbupgrades.Items.Add("Colour Picker Icon - 15 CP")
                End If
                If ShiftOSDesktop.boughtclock = True Then
                    If ShiftOSDesktop.boughtclockicon = False Then lbupgrades.Items.Add("Clock Icon - 15 CP")
                End If
                If ShiftOSDesktop.boughtapplaunchershutdown = True Then
                    If ShiftOSDesktop.boughtshutdownicon = False Then lbupgrades.Items.Add("Shutdown Icon - 15 CP")
                End If
                If ShiftOSDesktop.boughtpong = True Then
                    If ShiftOSDesktop.boughtpongicon = False Then lbupgrades.Items.Add("Pong Icon - 15 CP")
                End If
                If ShiftOSDesktop.boughttextpad = True Then
                    If ShiftOSDesktop.boughttextpadicon = False Then lbupgrades.Items.Add("Textpad Icon - 15 CP")
                End If
                If ShiftOSDesktop.boughtfileskimmer = True Then
                    If ShiftOSDesktop.boughtfileskimmericon = False Then lbupgrades.Items.Add("File Skimmer Icon - 15 CP")
                End If
                If ShiftOSDesktop.boughtartpad = True Then
                    If ShiftOSDesktop.boughtartpadicon = False Then lbupgrades.Items.Add("Artpad Icon - 15 CP")
                End If
            End If
        End If

        If ShiftOSDesktop.boughtgray = True Then
            If ShiftOSDesktop.boughtartpad = False Then lbupgrades.Items.Add("Artpad - 75 CP")
            If ShiftOSDesktop.boughtartpad = True Then
                If ShiftOSDesktop.boughtartpadnew = False Then lbupgrades.Items.Add("Artpad New - 10 CP")
                If ShiftOSDesktop.boughtartpadpixelplacer = False Then lbupgrades.Items.Add("Artpad Pixel Placer - 20 CP")
                If ShiftOSDesktop.boughtartpadpixelplacer = True Then
                    If ShiftOSDesktop.boughtartpadpixelplacermovementmode = False Then lbupgrades.Items.Add("Artpad PP Movement Mode - 20 CP")
                    If ShiftOSDesktop.boughtartpadpixelplacermovementmode = True Then
                        If ShiftOSDesktop.boughtartpadpencil = False Then lbupgrades.Items.Add("Artpad Pencil - 30 CP")
                        If ShiftOSDesktop.boughtartpadpencil = True Then
                            If ShiftOSDesktop.boughtartpadpaintbrush = False Then lbupgrades.Items.Add("Artpad Paint Brush - 30 CP")
                            If ShiftOSDesktop.boughtartpadlinetool = False Then lbupgrades.Items.Add("Artpad Line Tool - 30 CP")
                            If ShiftOSDesktop.boughtartpadovaltool = False Then lbupgrades.Items.Add("Artpad Oval Tool - 40 CP")
                            If ShiftOSDesktop.boughtartpadrectangletool = False Then lbupgrades.Items.Add("Artpad Rectangle Tool - 40 CP")
                            If ShiftOSDesktop.boughtartpaderaser = False Then lbupgrades.Items.Add("Artpad Eraser - 20 CP")
                            If ShiftOSDesktop.boughtartpadfilltool = False Then lbupgrades.Items.Add("Artpad Fill Tool - 60 CP")
                            If ShiftOSDesktop.boughtartpadtexttool = False Then lbupgrades.Items.Add("Artpad Text Tool - 45 CP")
                        End If
                    End If
                    If ShiftOSDesktop.boughtartpadundo = False Then lbupgrades.Items.Add("Artpad Undo - 40 CP")
                    If ShiftOSDesktop.boughtartpadundo = True Then
                        If ShiftOSDesktop.boughtartpadredo = False Then lbupgrades.Items.Add("Artpad Redo - 40 CP")
                    End If
                    If ShiftOSDesktop.boughtartpadsave = False Then lbupgrades.Items.Add("Artpad Save - 50 CP")
                    If ShiftOSDesktop.boughtartpadsave = True Then
                        If ShiftOSDesktop.boughtartpadload = False Then lbupgrades.Items.Add("Artpad Load - 50 CP")
                        If ShiftOSDesktop.boughtskinning = False Then lbupgrades.Items.Add("Skinning - 80 CP")
                    End If
                End If
                If ShiftOSDesktop.boughtartpadpixellimit4 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 4 - 10 CP")
                If ShiftOSDesktop.boughtartpadpixellimit4 = True Then
                    If ShiftOSDesktop.boughtartpadpixellimit8 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 8 - 20 CP")
                    If ShiftOSDesktop.boughtartpadpixellimit8 = True Then
                        If ShiftOSDesktop.boughtartpadpixellimit16 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 16 - 30 CP")
                        If ShiftOSDesktop.boughtartpadpixellimit16 = True Then
                            If ShiftOSDesktop.boughtartpadpixellimit64 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 64 - 50 CP")
                            If ShiftOSDesktop.boughtartpadpixellimit64 = True Then
                                If ShiftOSDesktop.boughtartpadpixellimit256 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 256 - 75 CP")
                                If ShiftOSDesktop.boughtartpadpixellimit256 = True Then
                                    If ShiftOSDesktop.boughtartpadpixellimit1024 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 1024 - 100 CP")
                                    If ShiftOSDesktop.boughtartpadpixellimit1024 = True Then
                                        If ShiftOSDesktop.boughtartpadpixellimit4096 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 4096 - 150 CP")
                                        If ShiftOSDesktop.boughtartpadpixellimit4096 = True Then
                                            If ShiftOSDesktop.boughtartpadpixellimit16384 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 16384 - 200 CP")
                                            If ShiftOSDesktop.boughtartpadpixellimit16384 = True Then
                                                If ShiftOSDesktop.boughtartpadpixellimit65536 = False Then lbupgrades.Items.Add("Artpad Pixel Limit 65536 - 250 CP")
                                                If ShiftOSDesktop.boughtartpadpixellimit65536 = True Then
                                                    If ShiftOSDesktop.boughtartpadlimitlesspixels = False Then lbupgrades.Items.Add("Artpad Limitless Pixels - 350 CP")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If


                If ShiftOSDesktop.boughtartpad4colorpallets = False Then lbupgrades.Items.Add("Artpad 4 Color Pallets - 10 CP")
                If ShiftOSDesktop.boughtartpad4colorpallets = True Then
                    If ShiftOSDesktop.boughtartpad8colorpallets = False Then lbupgrades.Items.Add("Artpad 8 Color Pallets - 20 CP")
                    If ShiftOSDesktop.boughtartpad8colorpallets = True Then
                        If ShiftOSDesktop.boughtartpad16colorpallets = False Then lbupgrades.Items.Add("Artpad 16 Color Pallets - 35 CP")
                        If ShiftOSDesktop.boughtartpad16colorpallets = True Then
                            If ShiftOSDesktop.boughtartpad32colorpallets = False Then lbupgrades.Items.Add("Artpad 32 Color Pallets - 50 CP")
                            If ShiftOSDesktop.boughtartpad32colorpallets = True Then
                                If ShiftOSDesktop.boughtartpadcustompallets = False Then lbupgrades.Items.Add("Artpad Custom Pallets - 75 CP")
                                If ShiftOSDesktop.boughtartpad64colorpallets = False Then lbupgrades.Items.Add("Artpad 64 Color Pallets - 100 CP")
                                If ShiftOSDesktop.boughtartpad64colorpallets = True Then
                                    If ShiftOSDesktop.boughtartpad128colorpallets = False Then lbupgrades.Items.Add("Artpad 128 Color Pallets - 150 CP")
                                End If

                            End If
                        End If
                    End If
                End If
            End If
        End If

        lbupgrades.Sorted = True
    End Sub

    Private Sub handlebuy(ByVal name As String, ByRef bought As Boolean, ByVal boughttutorial As String)

        On Error Resume Next
        If lbupgrades.SelectedItem.ToString = name Then
            If btnbuy.Text = "Buy" Then
                pricegrab = lbprice.Text.Substring(0, lbprice.Text.Length - 3)
                ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints - Convert.ToInt32(pricegrab)
                bought = True
                lbupgradename.Font = New Font("teen", 13, FontStyle.Bold)
                lbupgradename.Text = "Purchased " & lbupgrades.SelectedItem.ToString.Substring(0, lbupgrades.SelectedItem.ToString.IndexOf("-"))
                lbudescription.Text = boughttutorial
                lbudescription.Size = New Size(321, 180)
                lbudescription.Location = New Point(24, 47)
                lbprice.Size = New Size(340, 49)
                lbprice.Location = New Point(10, 372)
                lbprice.Font = New Font("teen", 16, FontStyle.Bold)
                picpreview.Location = New Point(25, 237)
                lbprice.Text = "Bought for " & lbprice.Text.Substring(0, lbprice.Text.IndexOf(" ")) & " codepoints"
                btnbuy.Hide()
                lbupgradename.Location = New Point(5, 10)
                checkspecial()
                ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " Used Shiftorium to buy: " & name & Environment.NewLine
                ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User has " & ShiftOSDesktop.codepoints & " Code Points!" & Environment.NewLine
            End If
        End If
    End Sub

    Private Sub handleupgradedescription(ByVal itemname As String, ByVal itempic As Image, ByVal itemdescription As String)
        On Error Resume Next
        If lbupgrades.SelectedItem.ToString = itemname Then
            lbupgradename.Font = New Font("teen", 20, FontStyle.Bold)
            lbupgradename.Text = lbupgrades.SelectedItem.ToString.Substring(0, lbupgrades.SelectedItem.ToString.IndexOf("-"))
            lbudescription.Text = itemdescription
            picpreview.Image = itempic
            lbprice.Text = lbupgrades.SelectedItem.ToString.Substring(lbupgrades.SelectedItem.ToString.IndexOf("-") + 2, lbupgrades.SelectedItem.ToString.Length - lbupgradename.Text.Length - 2)
            lbprice.Size = New Size(139, 59)
            lbprice.Location = New Point(3, 362)
            lbprice.Font = New Font("teen", 26, FontStyle.Bold)
            picpreview.Location = New Point(25, 218)
            lbudescription.Location = New Point(24, 61)
            lbudescription.Size = New Size(321, 144)
            lbupgradename.Location = New Point(5, 17)
            btnbuy.Show()
            If ShiftOSDesktop.codepoints > Convert.ToInt32(lbprice.Text.Substring(0, lbprice.Text.Length - 3) - 1) Then
                btnbuy.Text = "Buy"
            Else
                btnbuy.Text = "Can't Afford"
            End If
        End If
    End Sub

    Private Sub tmrcodepointsupdate_Tick(sender As Object, e As EventArgs) Handles tmrcodepointsupdate.Tick
        lbcodepoints.Text = "Codepoints: " & ShiftOSDesktop.codepoints
    End Sub

    Private Sub checkspecial()
        If lbupgrades.SelectedItem.ToString = "Title Bar - 80 CP" Then
            ShiftOSDesktop.titlebarheight = 30
            ShiftOSDesktop.addtitlebars()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
            ShiftOSDesktop.setupdesktop()
        End If
        If lbupgrades.SelectedItem.ToString = "Window Borders - 40 CP" Then
            ShiftOSDesktop.windowbordersize = 2
            ShiftOSDesktop.addborders()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
            ShiftOSDesktop.setupdesktop()
        End If
        If lbupgrades.SelectedItem.ToString = "Title Text - 40 CP" Then
            ShiftOSDesktop.setupalltitlebars()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Close Button - 90 CP" Then
            ShiftOSDesktop.setupalltitlebars()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Desktop Panel - 150 CP" Then
            ShiftOSDesktop.setupdesktop()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "App Launcher Menu - 120 CP" Then
            ShiftOSDesktop.setupdesktop()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Desktop Panel Clock - 75 CP" Then
            ShiftOSDesktop.setupdesktop()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Skinning - 80 CP" Then
            ShiftOSDesktop.setupdesktop()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Panel Buttons - 75 CP" Then
            ShiftOSDesktop.setupdesktop()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
            Skin_Loader.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Roll Up Button - 45 CP" Then
            ShiftOSDesktop.setupalltitlebars()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "Minimize Button - 50 CP" Then
            ShiftOSDesktop.setupalltitlebars()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
            Skin_Loader.determinevisibleobjects()
        End If
        If lbupgrades.SelectedItem.ToString = "AL Knowledge Input - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL Clock - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL Shiftorium - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL Shifter - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL Pong - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL File Skimmer - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL Textpad - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "AL Artpad - 20 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "App Launcher Shutdown - 40 CP" Then ShiftOSDesktop.setupdesktop()
        If lbupgrades.SelectedItem.ToString = "Windowed Terminal - 45 CP" Then
            ShiftOSDesktop.terminalfullscreen = False
            Terminal.miniterminal()
        End If
        If lbupgrades.SelectedItem.ToString = "Terminal Scrollbar - 20 CP" Then
            If ShiftOSDesktop.terminalfullscreen = False Then Terminal.txtterm.ScrollBars = ScrollBars.Vertical
        End If

        If lbupgrades.SelectedItem.ToString = "KI Car Brands - 10 CP" Then
            If System.IO.File.Exists("C:/ShiftOS/SoftwareData/KnowledgeInput/Car Brands.lst") Then
            Else
                fs = File.Create("C:/ShiftOS/SoftwareData/KnowledgeInput/Car Brands.lst")
                fs.Close()
                Knowledge_Input.ListBox1.Items.Add("Car Brands")
                Knowledge_Input.makecarbrandslist()
            End If
        End If
        If lbupgrades.SelectedItem.ToString = "KI Game Consoles - 10 CP" Then
            If System.IO.File.Exists("C:/ShiftOS/SoftwareData/KnowledgeInput/Game Consoles.lst") Then
            Else
                fs = File.Create("C:/ShiftOS/SoftwareData/KnowledgeInput/Game Consoles.lst")
                fs.Close()
                Knowledge_Input.ListBox1.Items.Add("Game Consoles")
                Knowledge_Input.makegameconsoleslist()
            End If
        End If
        If lbupgrades.SelectedItem.ToString = "KI Elements - 10 CP" Then
            If System.IO.File.Exists("C:/ShiftOS/SoftwareData/KnowledgeInput/Elements.lst") Then
            Else
                fs = File.Create("C:/ShiftOS/SoftwareData/KnowledgeInput/Elements.lst")
                fs.Close()
                Knowledge_Input.ListBox1.Items.Add("Elements")
                Knowledge_Input.makeelementslist()
            End If
        End If
        If lbupgrades.SelectedItem.ToString = "Knowledge Input Icon - 15 CP" Then
            ShiftOSDesktop.titletextside = ShiftOSDesktop.titletextside + 22
            ShiftOSDesktop.setupalltitlebars()
            Shifter.setupbuttons()
            Shifter.determinevisibleobjects()
            ShiftOSDesktop.setupdesktop()
            If Knowledge_Input.Visible = True Then Knowledge_Input.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Shifter Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If Shifter.Visible = True Then Shifter.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Shiftorium Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If Me.Visible = True Then Me.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Clock Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If Clock.Visible = True Then Clock.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Shutdown Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
        End If
        If lbupgrades.SelectedItem.ToString = "Pong Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If Pong.Visible = True Then Pong.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Terminal Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If Terminal.Visible = True Then Terminal.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "File Skimmer Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If File_Skimmer.Visible = True Then File_Skimmer.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Textpad Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If TextPad.Visible = True Then TextPad.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Artpad Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If ArtPad.Visible = True Then ArtPad.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Colour Picker Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If Colour_Picker.Visible = True Then Colour_Picker.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Infobox Icon - 15 CP" Then
            ShiftOSDesktop.setupdesktop()
            If infobox.Visible = True Then infobox.pnlicon.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "FS New Folder - 25 CP" Then
            If File_Skimmer.Visible = True Then File_Skimmer.btnnewfolder.Show()
            If File_Skimmer.pnlbreak.Visible = False Then File_Skimmer.pnlbreak.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "FS Delete - 25 CP" Then
            If File_Skimmer.Visible = True Then File_Skimmer.btndeletefile.Show()
            If File_Skimmer.pnlbreak.Visible = False Then File_Skimmer.pnlbreak.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Textpad New - 25 CP" Then
            If TextPad.Visible = True Then TextPad.btnnew.Show()
            If TextPad.pnlbreak.Visible = False Then TextPad.pnlbreak.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Textpad Save - 25 CP" Then
            If TextPad.Visible = True Then TextPad.btnsave.Show()
            If TextPad.pnlbreak.Visible = False Then TextPad.pnlbreak.Show()
        End If
        If lbupgrades.SelectedItem.ToString = "Textpad Open - 25 CP" Then
            If TextPad.Visible = True Then TextPad.btnopen.Show()
            If TextPad.pnlbreak.Visible = False Then TextPad.pnlbreak.Show()
        End If

        If lbupgrades.SelectedItem.ToString = "Artpad 4 Color Pallets - 10 CP" Then
            ShiftOSDesktop.artpadcolorpalletwidth = 105
            ShiftOSDesktop.artpadcolorpalletheight = 32
            ShiftOSDesktop.artpadcolorpalletsidegap = 4
            ShiftOSDesktop.artpadcolorpallettopgap = 4
            ShiftOSDesktop.artpadvisiblepallets = 4
            ArtPad.determinevisiblepallets()
            ArtPad.setuppallets()
        End If
        If lbupgrades.SelectedItem.ToString = "Artpad 8 Color Pallets - 20 CP" Then
            ShiftOSDesktop.artpadcolorpalletwidth = 50
            ShiftOSDesktop.artpadcolorpalletheight = 32
            ShiftOSDesktop.artpadcolorpalletsidegap = 4
            ShiftOSDesktop.artpadcolorpallettopgap = 4
            ShiftOSDesktop.artpadvisiblepallets = 8
            ArtPad.determinevisiblepallets()
            ArtPad.setuppallets()
        End If
        If lbupgrades.SelectedItem.ToString = "Artpad 16 Color Pallets - 35 CP" Then
            ShiftOSDesktop.artpadcolorpalletwidth = 50
            ShiftOSDesktop.artpadcolorpalletheight = 14
            ShiftOSDesktop.artpadcolorpalletsidegap = 4
            ShiftOSDesktop.artpadcolorpallettopgap = 4
            ShiftOSDesktop.artpadvisiblepallets = 16
            ArtPad.determinevisiblepallets()
            ArtPad.setuppallets()
        End If
        If lbupgrades.SelectedItem.ToString = "Artpad 32 Color Pallets - 50 CP" Then
            ShiftOSDesktop.artpadcolorpalletwidth = 23
            ShiftOSDesktop.artpadcolorpalletheight = 14
            ShiftOSDesktop.artpadcolorpalletsidegap = 4
            ShiftOSDesktop.artpadcolorpallettopgap = 4
            ShiftOSDesktop.artpadvisiblepallets = 32
            ArtPad.determinevisiblepallets()
            ArtPad.setuppallets()
        End If
        If lbupgrades.SelectedItem.ToString = "Artpad 64 Color Pallets - 100 CP" Then
            ShiftOSDesktop.artpadcolorpalletwidth = 23
            ShiftOSDesktop.artpadcolorpalletheight = 7
            ShiftOSDesktop.artpadcolorpalletsidegap = 4
            ShiftOSDesktop.artpadcolorpallettopgap = 2
            ShiftOSDesktop.artpadvisiblepallets = 64
            ArtPad.determinevisiblepallets()
            ArtPad.setuppallets()
        End If
        If lbupgrades.SelectedItem.ToString = "Artpad 128 Color Pallets - 150 CP" Then
            ShiftOSDesktop.artpadcolorpalletwidth = 12
            ShiftOSDesktop.artpadcolorpalletheight = 8
            ShiftOSDesktop.artpadcolorpalletsidegap = 1
            ShiftOSDesktop.artpadcolorpallettopgap = 1
            ShiftOSDesktop.artpadvisiblepallets = 128
            ArtPad.determinevisiblepallets()
            ArtPad.setuppallets()
        End If

        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 4 - 10 CP" Then ShiftOSDesktop.artpadpixellimit = 4
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 8 - 20 CP" Then ShiftOSDesktop.artpadpixellimit = 8
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 16 - 30 CP" Then ShiftOSDesktop.artpadpixellimit = 16
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 64 - 50 CP" Then ShiftOSDesktop.artpadpixellimit = 64
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 256 - 75 CP" Then ShiftOSDesktop.artpadpixellimit = 256
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 1024 - 100 CP" Then ShiftOSDesktop.artpadpixellimit = 1024
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 4096 - 150 CP" Then ShiftOSDesktop.artpadpixellimit = 4096
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 16384 - 200 CP" Then ShiftOSDesktop.artpadpixellimit = 16384
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Limit 65536 - 250 CP" Then ShiftOSDesktop.artpadpixellimit = 65536
        If lbupgrades.SelectedItem.ToString = "Artpad Limitless Pixels - 350 CP" Then ShiftOSDesktop.artpadpixellimit = 1000000

        If lbupgrades.SelectedItem.ToString = "Artpad New - 10 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Pixel Placer - 20 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad PP Movement Mode - 20 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Pencil - 30 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Paint Brush - 30 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Line Tool - 30 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Oval Tool - 40 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Rectangle Tool - 40 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Eraser - 20 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Fill Tool - 60 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Text Tool - 45 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Undo - 40 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Redo - 40 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Save - 50 CP" Then ArtPad.setuptoolbox()
        If lbupgrades.SelectedItem.ToString = "Artpad Load - 50 CP" Then ArtPad.setuptoolbox()

        ShiftOSDesktop.setcolours()
    End Sub
End Class