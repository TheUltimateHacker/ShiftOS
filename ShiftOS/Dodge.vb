Public Class Dodge
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 453   'replace with minimum size
    Public minimumsizeheight As Integer = 522  'replace with minimum size

    Dim speed As Decimal 'the speed the game runs at
    Dim score As Integer 'the score/code points the player gets
    Dim usingkeys As Boolean = False 'user can use mouse or keyboard, mouse by default, chnages to true if key pressed
    Dim time As Decimal = 0 'Records the time spent playing, used for codepoints formula
    Dim bonusesfound As Integer 'Number or bonus play collects
    Dim keyboardinput As Integer = 0 'for smooth keyboard gameplay, 1=left, 2=right, 0=none

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.DodgeCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttondodge.SendToBack() 'modfiy to proper name
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttondodge, ShiftOSDesktop.tbdodgeicon, ShiftOSDesktop.tbdodgetext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1
    End Sub

    Public Sub setupall()
        setuptitlebar()
        setupborders()
        setskin()
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
            End If
            If e.KeyCode = Keys.D AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X + ShiftOSDesktop.movablewindownumber, Me.Location.Y)
            End If
            If e.KeyCode = Keys.W AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y - ShiftOSDesktop.movablewindownumber)
            End If
            If e.KeyCode = Keys.S AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y + ShiftOSDesktop.movablewindownumber)
            End If
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User moved " & Me.Name & " to " & Me.Location.ToString & " with " & e.KeyCode.ToString & Environment.NewLine
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
        closebutton.BackgroundImage = Skins.closebtnhover
    End Sub

    Private Sub closebutton_MouseLeave(sender As Object, e As EventArgs) Handles closebutton.MouseLeave
        closebutton.BackgroundImage = Skins.closebtn
    End Sub

    Private Sub closebutton_MouseDown(sender As Object, e As EventArgs) Handles closebutton.MouseDown
        closebutton.BackgroundImage = Skins.closebtnclick
    End Sub

    Private Sub minimizebutton_Click(sender As Object, e As EventArgs) Handles minimizebutton.Click
        ShiftOSDesktop.minimizeprogram(Me, False)
    End Sub

    'Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
    '    If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    'End Sub

    'Private Sub titlebar_MouseLeave(sender As Object, e As EventArgs) Handles titlebar.MouseLeave, lbtitletext.MouseLeave, pnlicon.MouseLeave, closebutton.MouseLeave, rollupbutton.MouseLeave
    '    If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0)
    'End Sub

    Private Sub rollupbutton_Click(sender As Object, e As EventArgs) Handles rollupbutton.Click
        rollupanddown()
    End Sub

    Private Sub rollupbutton_MouseEnter(sender As Object, e As EventArgs) Handles rollupbutton.MouseEnter, rollupbutton.MouseUp
        rollupbutton.BackgroundImage = Skins.rollbtnhover
    End Sub

    Private Sub rollupbutton_MouseLeave(sender As Object, e As EventArgs) Handles rollupbutton.MouseLeave
        rollupbutton.BackgroundImage = Skins.rollbtn
    End Sub

    Private Sub rollupbutton_MouseDown(sender As Object, e As EventArgs) Handles rollupbutton.MouseDown
        rollupbutton.BackgroundImage = Skins.rollbtnclick
    End Sub

    Public Sub setuptitlebar()

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = Skins.borderwidth
        pgright.Width = Skins.borderwidth
        pgbottom.Height = Skins.borderwidth
        titlebar.Height = Skins.titlebarheight

        If justopened = True Then
            Me.Size = New Size(420, 510) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
            Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
            oldbordersize = Skins.borderwidth
            oldtitlebarheight = Skins.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                Me.Size = New Size(Me.Width - (2 * oldbordersize) + (2 * Skins.borderwidth), (Me.Height - oldtitlebarheight - oldbordersize) + Skins.titlebarheight + Skins.borderwidth)
                oldbordersize = Skins.borderwidth
                oldtitlebarheight = Skins.titlebarheight
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
            End If
        End If

            If Skins.enablecorners = True Then
                pgtoplcorner.Show()
                pgtoprcorner.Show()
            pgtoprcorner.Width = Skins.titlebarcornerwidth
            pgtoplcorner.Width = Skins.titlebarcornerwidth
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
            lbtitletext.Font = New Font(Skins.titletextfontfamily, Skins.titletextfontsize, Skins.titletextfontstyle, GraphicsUnit.Point)
                lbtitletext.Text = ShiftOSDesktop.dodgename 'Remember to change to name of program!!!!
                lbtitletext.Show()
            End If

            If ShiftOSDesktop.boughtclosebutton = False Then
                closebutton.Hide()
            Else
            closebutton.BackColor = Skins.closebtncolour
                closebutton.Size = Skins.closebtnsize
                closebutton.Show()
            End If

            If ShiftOSDesktop.boughtrollupbutton = False Then
                rollupbutton.Hide()
            Else
            rollupbutton.BackColor = Skins.rollbtncolour
                rollupbutton.Size = Skins.rollbtnsize
                rollupbutton.Show()
            End If

            If ShiftOSDesktop.boughtminimizebutton = False Then
                minimizebutton.Hide()
            Else
            minimizebutton.BackColor = Skins.minbtncolour
                minimizebutton.Size = Skins.minbtnsize
                minimizebutton.Show()
            End If

            If ShiftOSDesktop.boughtwindowborders = True Then
                closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - closebutton.Size.Width, Skins.closebtnfromtop)
                rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - rollupbutton.Size.Width, Skins.rollbtnfromtop)
                minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
            Else
                closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, Skins.closebtnfromtop)
                rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, Skins.rollbtnfromtop)
                minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside + pgtoplcorner.Width, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
            End If

        'Change when Icon skinning complete
        If ShiftOSDesktop.boughtshiftneticon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.dodgeicontitlebar  'Replace with the correct icon for the program.
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

    Public Sub resettitlebar()
        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - closebutton.Size.Width, Skins.closebtnfromtop)
            rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - rollupbutton.Size.Width, Skins.rollbtnfromtop)
            minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - Skins.closebtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, Skins.closebtnfromtop)
            rollupbutton.Location = New Point(titlebar.Size.Width - Skins.rollbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, Skins.rollbtnfromtop)
            minimizebutton.Location = New Point(titlebar.Size.Width - Skins.minbtnfromside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, Skins.minbtnfromtop)
            Select Case Skins.titletextpos
                Case "Left"
                    lbtitletext.Location = New Point(Skins.titletextfromside + pgtoplcorner.Width, Skins.titletextfromtop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, Skins.titletextfromtop)
            End Select
            lbtitletext.ForeColor = Skins.titletextcolour
        End If
    End Sub

    Private Sub pullside_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Width = Cursor.Position.X - Me.Location.X
        resettitlebar()
    End Sub

    Private Sub pullbottom_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub pullbs_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Width = Cursor.Position.X - Me.Location.X
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub RightCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgright.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeWE
        End If
    End Sub

    Private Sub bottomCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgbottom.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeNS
        End If
    End Sub

    Private Sub CornerCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgbottomrcorner.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeNWSE
        End If
    End Sub

    Private Sub SizeCursoroff_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgright.MouseLeave, pgbottom.MouseLeave, pgbottomrcorner.MouseLeave
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.Default
        End If
    End Sub


    Public Sub setskin()
        'disposals
        closebutton.BackgroundImage = Nothing
        titlebar.BackgroundImage = Nothing
        rollupbutton.BackgroundImage = Nothing
        pgtoplcorner.BackgroundImage = Nothing
        pgtoprcorner.BackgroundImage = Nothing
        minimizebutton.BackgroundImage = Nothing
        'apply new skin
        If Skins.closebtn Is Nothing Then closebutton.BackColor = Skins.closebtncolour Else closebutton.BackgroundImage = Skins.closebtn
        closebutton.BackgroundImageLayout = Skins.closebtnlayout
        If Skins.titlebar Is Nothing Then titlebar.BackColor = Skins.titlebarcolour Else titlebar.BackgroundImage = Skins.titlebar
        titlebar.BackgroundImageLayout = Skins.titlebarlayout
        If Skins.rollbtn Is Nothing Then rollupbutton.BackColor = Skins.rollbtncolour Else rollupbutton.BackgroundImage = Skins.rollbtn
        rollupbutton.BackgroundImageLayout = Skins.rollbtnlayout
        If Skins.leftcorner Is Nothing Then pgtoplcorner.BackColor = Skins.leftcornercolour Else pgtoplcorner.BackgroundImage = Skins.leftcorner
        pgtoplcorner.BackgroundImageLayout = Skins.leftcornerlayout
        If Skins.rightcorner Is Nothing Then pgtoprcorner.BackColor = Skins.rightcornercolour Else pgtoprcorner.BackgroundImage = Skins.rightcorner
        pgtoprcorner.BackgroundImageLayout = Skins.rightcornerlayout
        If Skins.minbtn Is Nothing Then minimizebutton.BackColor = Skins.minbtncolour Else minimizebutton.BackgroundImage = Skins.minbtn
        minimizebutton.BackgroundImageLayout = Skins.minbtnlayout
        If Skins.borderleft Is Nothing Then pgleft.BackColor = Skins.borderleftcolour Else pgleft.BackgroundImage = Skins.borderleft
        pgleft.BackgroundImageLayout = Skins.borderleftlayout
        If Skins.borderright Is Nothing Then pgright.BackColor = Skins.borderrightcolour Else pgright.BackgroundImage = Skins.borderright
        pgleft.BackgroundImageLayout = Skins.borderrightlayout
        If Skins.borderbottom Is Nothing Then pgbottom.BackColor = Skins.borderbottomcolour Else pgbottom.BackgroundImage = Skins.borderbottom
        pgbottom.BackgroundImageLayout = Skins.borderbottomlayout
        If enablebordercorners = True Then
            If Skins.bottomleftcorner Is Nothing Then pgbottomlcorner.BackColor = Skins.bottomleftcornercolour Else pgbottomlcorner.BackgroundImage = Skins.bottomleftcorner
            pgbottomlcorner.BackgroundImageLayout = Skins.bottomleftcornerlayout
            If Skins.bottomrightcorner Is Nothing Then pgbottomrcorner.BackColor = Skins.bottomrightcornercolour Else pgbottomrcorner.BackgroundImage = Skins.bottomrightcorner
            pgbottomrcorner.BackgroundImageLayout = Skins.bottomrightcornerlayout
        Else
            pgbottomlcorner.BackColor = Skins.borderrightcolour
            pgbottomrcorner.BackColor = Skins.borderrightcolour
            pgbottomlcorner.BackgroundImage = Nothing
            pgbottomrcorner.BackgroundImage = Nothing
        End If

        'set bottom border corner size
        pgbottomlcorner.Size = New Size(Skins.borderwidth, Skins.borderwidth)
        pgbottomrcorner.Size = New Size(Skins.borderwidth, Skins.borderwidth)
        pgbottomlcorner.Location = New Point(0, Me.Height - Skins.borderwidth)
        pgbottomrcorner.Location = New Point(Me.Width, Me.Height - Skins.borderwidth)

        Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour
    End Sub

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
        Me.Hide()
        ShiftOSDesktop.setuppanelbuttons()
    End Sub

    'end of general setup

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click 'When quit clicked
        Me.Close() 'quits the game (In case user donsn't have close button)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keyboardinput = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        player.Visible = False ' hide player and score until game starts
        scorelabel.Visible = False
        DescriptionLabel.Text = "Welcome to Dodge. Dodge is a simple arcade game with one objective: survive the falling objects! Use the arrow or mouse to move the player and avoid as many objects as you can. The longer you survive, the more code point you will be rewarded with. Beware, it gets harder..." ' set the description text

        'to impliment skinning, simply set the picturebox to the new skinned image.
        'For example:
        'player.Image = Image.FromFile("PATH TO SKINNED IMAGE")
    End Sub

    Private Sub BeginButton_Click(sender As Object, e As EventArgs) Handles BeginButton.Click 'When begin click

        'Hide buttons
        BeginButton.Visible = False
        QuitButton.Visible = False
        DescriptionLabel.Visible = False

        player.Visible = True ' show the player
        speed = 2 ' controls speed of game, will increase as game progresses
        scorelabel.Visible = True ' show score label
        bonusesfound = 0

        'Make sure all objects are in the correct position
        object_small.Location = New Point((Math.Ceiling(Rnd() * 453)), 300)
        object_small2.Location = New Point((Math.Ceiling(Rnd() * 453)), 49)
        object_mid.Location = New Point((Math.Ceiling(Rnd() * 453)), 377)
        object_mid2.Location = New Point((Math.Ceiling(Rnd() * 453)), 140)
        object_large.Location = New Point((Math.Ceiling(Rnd() * 453)), 214)
        PicBonus.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)

        'Reset time
        time = 0

        usingkeys = False

        System.Threading.Thread.Sleep(100) ' slight delay before game starts (in milliseconds)

        main() ' start the main game sub

        'sig() 'infobox sigs - COMMENT THIS OUT
    End Sub

    Public Sub Form1_keydown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Right ' detect right key press
                usingkeys = True ' turn off mouse control
                keyboardinput = 2
            Case Keys.Left
                usingkeys = True
                keyboardinput = 1
        End Select

    End Sub

    Private Sub main()
        clock.Start() 'the timer restart this sub every tick, making an endless loop between them.

        'score system
        scorelabel.Text = score
        score = (speed / 10) + (time / 20) + bonusesfound

        'Speed increase
        speed = speed + (speed * 0.001)

        'increase time
        time = time + 0.05 'loops every 0.05 seconds so time increases by 1 every second (have I done the maths correctly?)

        'Make objects fall
        object_large.Location = New Point(object_large.Location.X, object_large.Location.Y + speed)
        object_mid.Location = New Point(object_mid.Location.X, object_mid.Location.Y + speed)
        object_mid2.Location = New Point(object_mid2.Location.X, object_mid2.Location.Y + speed)
        object_small.Location = New Point(object_small.Location.X, object_small.Location.Y + speed)
        object_small2.Location = New Point(object_small2.Location.X, object_small2.Location.Y + speed)

        'mouse controls
        If usingkeys = False Then ' tests if mouse control is enabled
            player.Location = New Point(MousePosition.X - Me.Location.X - (player.Size.Width / 2) - 5, player.Location.Y) 'sets the x location to that of the mouse
        End If

        'keyboard controls
        If usingkeys = True Then
            If keyboardinput = 1 Then
                player.Location = New Point(player.Location.X - (speed * 4), player.Location.Y)
            End If
            If keyboardinput = 2 Then
                player.Location = New Point(player.Location.X + (speed * 4), player.Location.Y) ' move right
            End If
        End If

        'move object back to the top of the screen
        If object_small.Location.Y > 522 Then
            object_small.Location = New Point((Math.Ceiling(Rnd() * 453)), -20) 'picks a random number between 0 and 453 (window width) and sets the x position to this value. uses -20 for y as it is above the top of window
        End If
        If object_small2.Location.Y > 522 Then
            object_small2.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)
        End If
        If object_mid.Location.Y > 522 Then
            object_mid.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)
        End If
        If object_mid2.Location.Y > 522 Then
            object_mid2.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)
        End If
        If object_large.Location.Y > 522 Then
            object_large.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)
        End If

        'Makes sure the player is on the screen (Anti-cheating)
        If player.Location.X > 375 Then
            player.Location = New Point(385, player.Location.Y)
        End If
        If player.Location.X < 0 Then
            player.Location = New Point(0, player.Location.Y)
        End If

        'Bonus
        If PicBonus.Visible = False Then
            Dim ran As Integer = Math.Ceiling(Rnd() * 300) 'random 1 in 500 chance
            If ran = 1 Then
                PicBonus.Visible = True
            End If
        Else
            PicBonus.Location = New Point(PicBonus.Location.X, PicBonus.Location.Y + speed)
            If PicBonus.Location.Y > 522 Then
                PicBonus.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)
                PicBonus.Visible = False
            End If
        End If

        'check collisions
        If player.Bounds.IntersectsWith(object_mid.Bounds) Or player.Bounds.IntersectsWith(object_mid2.Bounds) Or player.Bounds.IntersectsWith(object_large.Bounds) Or player.Bounds.IntersectsWith(object_small.Bounds) Or player.Bounds.IntersectsWith(object_small2.Bounds) Then
            clock.Stop() 'breaks loop
            System.Threading.Thread.Sleep(333) 'delay for a third of a second
            player.Visible = False 'hide game
            DescriptionLabel.Text = "Sorry, you just lost the game, however, you earnt a total of " & score & " code points. To earn more code points, press the begin button now. To exit, press the quit button" ' change the description to the die message
            ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + score
            DescriptionLabel.Visible = True 'show non-game elements
            BeginButton.Visible = True
            QuitButton.Visible = True
            scorelabel.Visible = False
        End If
        If player.Bounds.IntersectsWith(PicBonus.Bounds) Then
            PicBonus.Visible = False
            bonusesfound = bonusesfound + 1
            PicBonus.Location = New Point((Math.Ceiling(Rnd() * 453)), -20)
        End If

    End Sub

    Private Sub clock_Tick(sender As Object, e As EventArgs) Handles clock.Tick
        main() 'repeat the main sub (endless loop)
    End Sub

    Private Sub sig()
        infobox.title = "FLAG"
        infobox.textinfo = "There is no foul on the play, the punt was blocked."
        infobox.Show()
    End Sub
End Class