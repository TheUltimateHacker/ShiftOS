Public Class Pong
    Public oldsize As Integer
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Dim RolledUp As Boolean = False
    Dim rndInst As New Random() ' Random instance
    Dim xVel As Single = 7
    Dim yVel As Single = 8
    Dim computerspeed = 8
    Dim rand As New Random
    Dim level As Integer = 1
    Dim secondsleft As Integer = 60
    Dim casualposition As Integer
    Dim xveldec As Double = 3.0
    Dim yveldec As Double = 3.0
    Dim incrementx As Double = 0.4
    Dim incrementy As Double = 0.2
    Dim levelxspeed As Integer = 3
    Dim levelyspeed As Integer = 3
    Dim beatairewardtotal As Integer
    Dim beataireward As Integer = 1
    Dim levelrewards(50) As Integer
    Dim totalreward As Integer
    Dim countdown As Integer = 3
    Dim paused As Boolean = False

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.PongCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        setuplevelrewards()

        If ShiftOSDesktop.boughtgray4 = True And ShiftOSDesktop.boughtshiftnet = False Then tmrstoryline.Start()

        ShiftOSDesktop.pnlpanelbuttonpong.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonpong, ShiftOSDesktop.tbpongicon, ShiftOSDesktop.tbpongtext, True) 'modify to proper name
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

    'Old skinning system - No idea what this does
    ''Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
    ''    If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    ''End Sub

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

        setupborders()

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = Skins.borderwidth
        pgright.Width = Skins.borderwidth
        pgbottom.Height = Skins.borderwidth
        titlebar.Height = Skins.titlebarheight

        If justopened = True Then
            Me.Size = New Size(700, 400) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
            Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
            oldbordersize = Skins.borderwidth
            oldtitlebarheight = Skins.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                'Me.Hide()
                Me.Size = New Size(Me.Width - (2 * oldbordersize) + (2 * Skins.borderwidth), (Me.Height - oldtitlebarheight - oldbordersize) + Skins.titlebarheight + Skins.borderwidth)
                'Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize) 'Just put a little algebra in the first size setting and comment out the mess
                oldbordersize = Skins.borderwidth
                oldtitlebarheight = Skins.titlebarheight
                'Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
                'Me.Size = New Size(Me.Width + Skins. borderwidth + Skins. borderwidth, Me.Height + Skins. borderwidth)
                'rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                'Me.Show()
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
            lbtitletext.Text = ShiftOSDesktop.pongname 'Remember to change to name of program!!!!
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
        If ShiftOSDesktop.boughtpongicon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.pongicontitlebar  'Replace with the correct icon for the program.
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
#End Region

    ' Move the paddle according to the mouse position.
    Private Sub pongMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, pgcontents.MouseMove, titlebar.MouseMove, ball.MouseMove, paddleComputer.MouseMove, paddleHuman.MouseMove, lblstatsX.MouseMove, lbllevelandtime.MouseMove, lblstatsY.MouseMove, lblstatscodepoints.MouseMove, pnlintro.MouseMove, Label6.MouseMove, Label8.MouseMove, btnstartgame.MouseMove
        paddleHuman.Location = New Point(paddleHuman.Location.X, (MousePosition.Y - Me.Location.Y - ShiftOSDesktop.titlebarheight - ShiftOSDesktop.windowbordersize) - (paddleHuman.Height / 2))
    End Sub

    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick

        'Set the computer player to move according to the ball's position.
        If ball.Location.X > 500 - xVel * 10 AndAlso xVel > 0 Then
            If ball.Location.Y > paddleComputer.Location.Y + 50 Then
                paddleComputer.Location = New Point(paddleComputer.Location.X, paddleComputer.Location.Y + computerspeed)
            End If
            If ball.Location.Y < paddleComputer.Location.Y + 50 Then
                paddleComputer.Location = New Point(paddleComputer.Location.X, paddleComputer.Location.Y - computerspeed)
            End If
            casualposition = rand.Next(-150, 201)
        Else
            If paddleComputer.Location.Y > Me.Size.Height / 2 - paddleComputer.Height + casualposition Then 'used to be me.location.y
                paddleComputer.Location = New Point(paddleComputer.Location.X, paddleComputer.Location.Y - computerspeed)
            End If
            If paddleComputer.Location.Y < Me.Size.Height / 2 - paddleComputer.Height + casualposition Then 'used to be me.location.y
                paddleComputer.Location = New Point(paddleComputer.Location.X, paddleComputer.Location.Y + computerspeed)
            End If
        End If

        'Set Xvel and Yvel speeds from decimal
        If xVel > 0 Then xVel = Math.Round(xveldec)
        If xVel < 0 Then xVel = -Math.Round(xveldec)
        If yVel > 0 Then yVel = Math.Round(yveldec)
        If yVel < 0 Then yVel = -Math.Round(yveldec)

        ' Move the game ball.
        ball.Location = New Point(ball.Location.X + xVel, ball.Location.Y + yVel)

        ' Check for top wall.
        If ball.Location.Y < 0 Then
            ball.Location = New Point(ball.Location.X, 0)
            yVel = -yVel
        End If

        ' Check for bottom wall.
        If ball.Location.Y > Me.Height - ball.Size.Height - titlebar.Height - pgbottom.Height Then
            ball.Location = New Point(ball.Location.X, Me.Height - ball.Size.Height - titlebar.Height - pgbottom.Height)
            yVel = -yVel
        End If

        ' Check for player paddle.
        If ball.Bounds.IntersectsWith(paddleHuman.Bounds) Then
            ball.Location = New Point(paddleHuman.Location.X + ball.Size.Width, ball.Location.Y)
            'randomly increase x or y speed of ball
            Select Case rand.Next(1, 3)
                Case 1
                    xveldec = xveldec + incrementx
                Case 2
                    If yveldec > 0 Then yveldec = yveldec + incrementy
                    If yveldec < 0 Then yveldec = yveldec - incrementy
            End Select
            xVel = -xVel
            My.Computer.Audio.Play(My.Resources.typesound, AudioPlayMode.Background)
        End If

        ' Check for computer paddle.
        If ball.Bounds.IntersectsWith(paddleComputer.Bounds) Then
            ball.Location = New Point(paddleComputer.Location.X - paddleComputer.Size.Width + 1, ball.Location.Y)
            xveldec = xveldec + incrementx
            xVel = -xVel
            My.Computer.Audio.Play(My.Resources.typesound, AudioPlayMode.Background)
        End If

        ' Check for left wall.
        If ball.Location.X < -100 Then
            ball.Location = New Point(Me.Size.Width / 2 + 200, Me.Size.Height / 2)
            paddleComputer.Location = New Point(paddleComputer.Location.X, ball.Location.Y)
            If xVel > 0 Then xVel = -xVel
            pnllose.Show()
            gameTimer.Stop()
            counter.Stop()
            lblmissedout.Text = "You Missed Out On:" & Environment.NewLine & levelrewards(level - 1) + beatairewardtotal & " Codepoints"
        End If

        ' Check for right wall.
        If ball.Location.X > Me.Width - ball.Size.Width - paddleComputer.Width + 100 Then
            ball.Location = New Point(Me.Size.Width / 2 + 200, Me.Size.Height / 2)
            paddleComputer.Location = New Point(paddleComputer.Location.X, ball.Location.Y)
            If xVel > 0 Then xVel = -xVel
            beatairewardtotal = beatairewardtotal + beataireward
            lblbeatai.Show()
            lblbeatai.Text = "You got " & beataireward & " codepoints for beating the Computer!"
            tmrcountdown.Start()
            gameTimer.Stop()
            counter.Stop()
        End If

        'lblstats.Text = "Xspeed: " & Math.Abs(xVel) & " Yspeed: " & Math.Abs(yVel) & " Human Location: " & paddleHuman.Location.ToString & " Computer Location: " & paddleComputer.Location.ToString & Environment.NewLine & " Ball Location: " & ball.Location.ToString & " Xdec: " & xveldec & " Ydec: " & yveldec & " Xinc: " & incrementx & " Yinc: " & incrementy
        lblstatsX.Text = "Xspeed: " & xveldec
        lblstatsY.Text = "Yspeed: " & yveldec
        lblstatscodepoints.Text = "Codepoints earned: " & levelrewards(level - 1) + beatairewardtotal

        lbllevelandtime.Text = "Level: " & level & " - " & secondsleft & " Seconds Left"

        If xVel > 20 OrElse xVel < -20 Then
            paddleHuman.Width = Math.Abs(xVel)
            paddleComputer.Width = Math.Abs(xVel)
        Else
            paddleHuman.Width = 20
            paddleComputer.Width = 20
        End If

        computerspeed = Math.Abs(yVel)

        '  pgcontents.Refresh()
        ' pgcontents.CreateGraphics.FillRectangle(Brushes.Black, ball.Location.X, ball.Location.Y, ball.Width, ball.Height)

    End Sub

    Private Sub counter_Tick(sender As Object, e As EventArgs) Handles counter.Tick
        secondsleft = secondsleft - 1
        If secondsleft = -1 Then
            secondsleft = 60
            level = level + 1
            generatenextlevel()
            pnlgamestats.Show()
            counter.Stop()
            gameTimer.Stop()
        End If
        lblstatscodepoints.Text = "Codepoints earned: " & levelrewards(level - 1) + beatairewardtotal
    End Sub

    Private Sub btnplayon_Click(sender As Object, e As EventArgs) Handles btnplayon.Click
        xveldec = levelxspeed
        yveldec = levelyspeed

        secondsleft = 60

        tmrcountdown.Start()
        lblbeatai.Text = "Get " & beataireward & " codepoints for beating the Computer!"
        pnlgamestats.Hide()
        lblbeatai.Show()
        ball.Location = New Point(paddleHuman.Location.X + paddleHuman.Width + 50, paddleHuman.Location.Y + paddleHuman.Height / 2)
        If xVel < 0 Then xVel = Math.Abs(xVel)
        lbllevelandtime.Text = "Level: " & level & " - " & secondsleft & " Seconds Left"
    End Sub

    'Increase the ball speed stats for the next level
    Private Sub generatenextlevel()
        lbllevelreached.Text = "You Reached Level " & level & "!"

        lblpreviousstats.Text = "Initial Ball X Speed: " & levelxspeed & Environment.NewLine & _
        "Initial Ball Y Speed: " & levelyspeed & Environment.NewLine & _
        "Increment X Speed: " & incrementx & Environment.NewLine & _
        "Increment Y Speed: " & incrementy

        Select Case rand.Next(1, 3)
            Case 1
                levelxspeed = levelxspeed + 1
            Case 2
                levelxspeed = levelxspeed + 2
        End Select

        Select Case rand.Next(1, 3)
            Case 1
                levelyspeed = levelyspeed + 1
            Case 2
                levelyspeed = levelyspeed + 2
        End Select

        Select Case rand.Next(1, 6)
            Case 1
                incrementx = incrementx + 0.1
            Case 2
                incrementx = incrementx + 0.2
            Case 3
                incrementy = incrementy + 0.1
            Case 4
                incrementy = incrementy + 0.2
            Case 5
                incrementy = incrementy + 0.3
        End Select

        lblnextstats.Text = "Initial Ball X Speed: " & levelxspeed & Environment.NewLine & _
        "Initial Ball Y Speed: " & levelyspeed & Environment.NewLine & _
        "Increment X Speed: " & incrementx & Environment.NewLine & _
        "Increment Y Speed: " & incrementy

        If level < 15 Then
            beataireward = level * 2
        Else
            beataireward = Math.Round(levelrewards(level) / 10)
        End If

        totalreward = levelrewards(level - 1) + beatairewardtotal

        btncashout.Text = "Cash out with " & totalreward & " codepoints!"
        btnplayon.Text = "Play on for " & levelrewards(level) + beatairewardtotal & " codepoints!"
    End Sub

    Private Sub setuplevelrewards()
        levelrewards(0) = 0
        levelrewards(1) = 1
        levelrewards(2) = 3
        levelrewards(3) = 7
        levelrewards(4) = 13
        levelrewards(5) = 20
        levelrewards(6) = 30
        levelrewards(7) = 45
        levelrewards(8) = 60
        levelrewards(9) = 80
        levelrewards(10) = 100
        levelrewards(11) = 125
        levelrewards(12) = 150
        levelrewards(13) = 200
        levelrewards(14) = 250
        levelrewards(15) = 300
        levelrewards(16) = 400
        levelrewards(17) = 500
        levelrewards(18) = 650
        levelrewards(19) = 800
        levelrewards(20) = 1000
        levelrewards(21) = 1250
        levelrewards(22) = 1600
        levelrewards(23) = 2000
        levelrewards(24) = 2500
        levelrewards(25) = 3000
        levelrewards(26) = 3750
        levelrewards(27) = 4500
        levelrewards(28) = 5500
        levelrewards(29) = 7000
        levelrewards(30) = 9000
        levelrewards(31) = 11000
        levelrewards(32) = 13500
        levelrewards(33) = 16000
        levelrewards(34) = 20000
        levelrewards(35) = 25000
        levelrewards(36) = 32000
        levelrewards(37) = 40000
        levelrewards(38) = 50000
        levelrewards(39) = 75000
        levelrewards(40) = 100000
    End Sub

    Private Sub countdown_Tick(sender As Object, e As EventArgs) Handles tmrcountdown.Tick
        Select Case countdown
            Case 0
                countdown = 3
                lblcountdown.Hide()
                lblbeatai.Hide()
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                gameTimer.Start()
                counter.Start()
                tmrcountdown.Stop()
            Case 1
                lblcountdown.Text = "1"
                countdown = countdown - 1
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 2
                lblcountdown.Text = "2"
                countdown = countdown - 1
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 3
                lblcountdown.Text = "3"
                countdown = countdown - 1
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                lblcountdown.Show()
        End Select
    End Sub

    Private Sub btncashout_Click(sender As Object, e As EventArgs) Handles btncashout.Click
        pnlgamestats.Hide()
        pnlfinalstats.Show()
        lblfinalcodepointswithtext.Text = "You cashed out with " & totalreward & " codepoints!"
        lblfinallevelreached.Text = "Codepoints rewarded for reaching level " & level - 1
        lblfinallevelreward.Text = levelrewards(level - 1)
        lblfinalcomputerreward.Text = beatairewardtotal
        lblfinalcodepoints.Text = totalreward & " CP"
        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + totalreward
    End Sub

    Private Sub newgame()
        pnlfinalstats.Hide()
        pnllose.Hide()
        pnlintro.Hide()

        level = 1
        totalreward = 0
        beataireward = 2
        beatairewardtotal = 0
        secondsleft = 60
        lblstatscodepoints.Text = "Codepoints: " 'reset stats text
        lblstatsX.Text = "Xspeed: "
        lblstatsY.Text = "Yspeed: "

        levelxspeed = 3
        levelyspeed = 3

        incrementx = 0.4
        incrementy = 0.2

        xveldec = levelxspeed
        yveldec = levelyspeed

        tmrcountdown.Start()
        lblbeatai.Text = "Get " & beataireward & " codepoints for beating the Computer!"
        pnlgamestats.Hide()
        lblbeatai.Show()
        ball.Location = New Point(paddleHuman.Location.X + paddleHuman.Width + 50, paddleHuman.Location.Y + paddleHuman.Height / 2)
        If xVel < 0 Then xVel = Math.Abs(xVel)
        lbllevelandtime.Text = "Level: " & level & " - " & secondsleft & " Seconds Left"
    End Sub

    Private Sub btnplayagain_Click(sender As Object, e As EventArgs) Handles btnplayagain.Click
        newgame()
    End Sub

    Private Sub btnlosetryagain_Click(sender As Object, e As EventArgs) Handles btnlosetryagain.Click
        newgame()
    End Sub

    Private Sub btnstartgame_Click(sender As Object, e As EventArgs) Handles btnstartgame.Click
        newgame()
    End Sub

    Dim chance As Integer = 101
    Private Sub tmrstoryline_Tick(sender As Object, e As EventArgs) Handles tmrstoryline.Tick
        ' Random chance of showing getshiftnet storyline
        If gameTimer.Enabled = False Then ' Can't show if in middle of game
            chance = chance - 1
            If chance < 25 Then
                chance = 25
            End If
            Dim i As Integer = Math.Ceiling(Rnd() * chance)
            lblstorylinechancedebug.Text = i
            If i = 1 Then
                Terminal.Show()
                Terminal.BringToFront()
                Terminal.storyline = "getshiftnet"
                Terminal.tmrstorylineupdate.Start()
                tmrstoryline.Stop()
            End If
        End If
    End Sub

    Private Sub me_closing() Handles Me.FormClosing
        tmrstoryline.Stop()
    End Sub
End Class