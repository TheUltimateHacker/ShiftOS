Public Class Bitnote_Digger
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0   'replace with minimum size
    Public minimumsizeheight As Integer = 0  'replace with minimum size

    Public bitnotesmined As Decimal = 0
    Public miningspeed As Decimal = 0.00001

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()

        ShiftOSDesktop.pnlpanelbuttonbitnotedigger.SendToBack() 'modfiy to proper name
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonbitnotedigger, ShiftOSDesktop.tbbitnotediggericon, ShiftOSDesktop.tbbitnotediggertext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1
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
            Me.Size = New Size(552, 253) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.bitnotediggername 'Remember to change to name of program!!!!
            If tmrcalcbitnotesmined.Enabled = True Then lbtitletext.Text = lbtitletext.Text & " - Activated" Else lbtitletext.Text = lbtitletext.Text & " - Deactivated"
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

        If ShiftOSDesktop.boughtknowledgeinputicon = True Then
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.bitnotediggericontitlebar  'Replace with the correct icon for the program.
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

    Private Sub tmrcalcbitnotesmined_Tick(sender As Object, e As EventArgs) Handles tmrcalcbitnotesmined.Tick
        bitnotesmined = bitnotesmined + miningspeed
        lbltotalbitcoinsmined.Text = FormatNumber(Math.Round(bitnotesmined, 5), 5)
    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        tmrcalcbitnotesmined.Start()
        lbtitletext.Text = ShiftOSDesktop.bitnotediggername & " - Activated"
    End Sub

    Private Sub btnstop_Click(sender As Object, e As EventArgs) Handles btnstop.Click
        tmrcalcbitnotesmined.Stop()
        lbtitletext.Text = ShiftOSDesktop.bitnotediggername & " - Deactivated"
    End Sub

    Private Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
        If txtsendaddress.Text = ShiftOSDesktop.bitnoteaddress Then
            ShiftOSDesktop.bitnotebalance = ShiftOSDesktop.bitnotebalance + bitnotesmined
            Bitnote_Wallet.logtransaction(bitnotesmined, "Credit From", "Bitnote Digger - Surface Scratcher")
        End If
        bitnotesmined = 0
        lbltotalbitcoinsmined.Text = FormatNumber(Math.Round(bitnotesmined, 5), 5)
        If Bitnote_Wallet.Visible Then Bitnote_Wallet.setupbitnotestats()
    End Sub
End Class