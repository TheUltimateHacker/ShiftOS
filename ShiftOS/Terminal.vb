Imports System.Net.Mail

Public Class Terminal
    Public cmds As String()
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 350
    Public minimumsizeheight As Integer = 200

    Dim CreatingAlias1 As Boolean
    Dim CreatingAlias2 As Boolean

    Dim Part1Alias As String
    Dim Part2Alias As String

    Public StartOfAlias As String
    Public EndOfAlias As String

    Dim alltext As String
    Dim command As String
    Dim trackpos As Integer
    Dim firstrun As Integer
    Dim testing As Boolean = True
    Dim further As Boolean = True

    Public sendinputtomod As Boolean = False

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.TerminalCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttonterminal.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonterminal, ShiftOSDesktop.tbterminalicon, ShiftOSDesktop.tbterminaltext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        txtterm.Text = txtterm.Text + ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
        txtterm.Select(txtterm.Text.Length, 0)
        txtterm.Cursor = Nothing

        'transparancy key moved here from set skin to avoid cropped terminal bug
        Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour

        If ShiftOSDesktop.terminalfullscreen = True Then
            fullterminal()
        Else
            miniterminal()
        End If

    End Sub

    Public Sub setupall()
        setuptitlebar()
        setupborders()
        setskin()
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Go back to desktop on control + T
        If e.KeyCode = Keys.T AndAlso e.Control Then
            ShiftOSDesktop.Show()
            ShiftOSDesktop.Visible = True
            ShiftOSDesktop.BringToFront()
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
            Me.Size = New Size(650, 400) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.terminalname 'Remember to change to name of program!!!!
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
        If ShiftOSDesktop.boughtterminalicon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(Skins.titleiconfromside, Skins.titleiconfromtop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.terminalicontitlebar  'Replace with the correct icon for the program.
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

    Private Sub pullside_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pullside.Tick
        Me.Width = Cursor.Position.X - Me.Location.X
        resettitlebar()
    End Sub

    Private Sub pullbottom_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pullbottom.Tick
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub pullbs_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pullbs.Tick
        Me.Width = Cursor.Position.X - Me.Location.X
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    'delete this for non-resizable windows
    Private Sub Rightpull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgright.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullside.Start()
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

    Private Sub rightpull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgright.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullside.Stop()
        End If
    End Sub

    Private Sub bottompull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottom.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbottom.Start()
        End If
    End Sub

    Private Sub buttompull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottom.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbottom.Stop()
        End If
    End Sub

    Private Sub bspull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottomrcorner.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbs.Start()
        End If
    End Sub

    Private Sub bspull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottomrcorner.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbs.Stop()
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

    Public Sub miniterminal()
        Me.WindowState = FormWindowState.Normal
        If ShiftOSDesktop.boughttitlebar = True Then
            titlebar.Show()
        End If
        If ShiftOSDesktop.boughtwindowborders = True Then
            pgright.Show()
            pgleft.Show()
            pgbottom.Show()
        End If
        If ShiftOSDesktop.boughtterminalscrollbar = True Then
            txtterm.ScrollBars = ScrollBars.Vertical
        End If
        setuptitlebar()
        setupborders()
        'ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()
    End Sub

    Public Sub fullterminal()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        txtterm.ScrollBars = ScrollBars.None
        titlebar.Hide()
        pgright.Hide()
        pgleft.Hide()
        pgbottom.Hide()
        Me.BringToFront()
    End Sub


    Private Sub ReadCommand()
        command = txtterm.Lines(txtterm.Lines.Length - 1)
        command = command.Replace(ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> ", "")
        command = command.ToLower()
    End Sub

    Private Sub txtterm_Click(sender As Object, e As EventArgs) Handles txtterm.Click, txtterm.MouseDoubleClick
        txtterm.Select(txtterm.TextLength, 0)
        txtterm.ScrollToCaret()
    End Sub

    Private Sub txtterm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtterm.KeyDown
        If e.KeyCode = Keys.T AndAlso e.Control Then
            Me.Hide()
            e.SuppressKeyPress = True
        End If

        Select Case e.KeyCode
            Case Keys.ShiftKey
                trackpos = trackpos - 1
            Case Keys.Alt
                trackpos = trackpos - 1
            Case Keys.CapsLock
                trackpos = trackpos - 1
            Case Keys.ControlKey
                trackpos = trackpos - 1
            Case Keys.LWin
                trackpos = trackpos - 1
            Case Keys.RWin
                trackpos = trackpos - 1
            Case Keys.Right
                If txtterm.SelectionStart = txtterm.TextLength Then
                    trackpos = trackpos - 1
                End If
            Case Keys.Left
                If trackpos < 1 Then
                    e.SuppressKeyPress = True
                    trackpos = trackpos - 1
                Else
                    trackpos = trackpos - 2
                End If
            Case Keys.Up
                e.SuppressKeyPress = True
                trackpos = trackpos - 1
            Case Keys.Down
                e.SuppressKeyPress = True
                trackpos = trackpos - 1
        End Select

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ReadCommand()
            DoCommand()

            If command = "clear" Then
                txtterm.Text = txtterm.Text + ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                txtterm.Select(txtterm.Text.Length, 0)

            Else
                txtterm.Text = txtterm.Text + Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                txtterm.Select(txtterm.Text.Length, 0)
            End If

            trackpos = 0
        Else
            If e.KeyCode = Keys.Back Then
            Else
                trackpos = trackpos + 1
            End If
        End If

        If e.KeyCode = Keys.Back Then
            If trackpos < 1 Then
                e.SuppressKeyPress = True
            Else
                If txtterm.SelectedText.Length < 1 Then
                    trackpos = trackpos - 1
                Else
                    e.SuppressKeyPress = True
                End If
            End If
        End If

        If ShiftOSDesktop.boughtautoscrollterminal = True Then
            txtterm.Select(txtterm.TextLength, 0)
            txtterm.ScrollToCaret()
        End If

    End Sub

    Private Sub DoCommand()
        If command Like "speak_infobox ""*"" ""*""" Then
            Dim findwords() As String = command.Split("""")
            Helper.speakInfoBox(findwords(1), findwords(3))
            further = False
        End If
        If command Like "speak ""*""" Then
            Dim findwords() As String = command.Split("""")
            If Not findwords(1) = "" Then
                Helper.speak(findwords(1))
            Else
                Helper.speak("I'm sorry, but you didn't enter anything for me to speak.")
            End If
            further = False
        End If
        If command Like "alias *" Then
            CreatingAlias1 = False
            CreatingAlias2 = False
            txtterm.Text = txtterm.Text & Environment.NewLine & "Now type in the alias, start the alias with 'al' and leave a space." & Environment.NewLine
            CreatingAlias1 = True
        End If

        If command Like "al *" And CreatingAlias1 = True Then
            Part1Alias = command.Substring(5)
            txtterm.Text = txtterm.Text & Environment.NewLine & "Saved the first part of the alias, now type in the command you want it to execute, starting with 'co' and a space" & Environment.NewLine
            CreatingAlias1 = False
            CreatingAlias2 = True
        ElseIf CreatingAlias1 = False And command Like "al* " Then
            wrongcommand()
        End If

        If command Like "co *" And CreatingAlias2 = True Then
            Part2Alias = command.Substring(5)
            My.Computer.FileSystem.CreateDirectory(ShiftOSDesktop.ShiftOSPath + "\SoftwareData\Terminal-Aliases")
            My.Computer.FileSystem.WriteAllText(ShiftOSDesktop.ShiftOSPath + "\SoftwareData\Terminal_Aliases\Alias1.txt", Part1Alias, False)
            My.Computer.FileSystem.WriteAllText(ShiftOSDesktop.ShiftOSPath + "\SoftwareData\Terminal_Aliases\Alias2.txt", Part2Alias, False)
            txtterm.Text = txtterm.Text & Environment.NewLine & "Saved the alias successfully."
            CreatingAlias1 = False
            CreatingAlias2 = False
        ElseIf CreatingAlias2 = False And command Like "co *" Then
            wrongcommand()
        End If
        Try
            StartOfAlias = My.Computer.FileSystem.ReadAllText(ShiftOSDesktop.ShiftOSPath & "\SoftwareData\Terminal-Aliases\Alias1.txt")

            EndOfAlias = My.Computer.FileSystem.ReadAllText(ShiftOSDesktop.ShiftOSPath & "\SoftwareData\Terminal-Aliases\Alias2.txt")
        Catch ex As Exception
        End Try
        Try
            If command Like StartOfAlias.ToString And EndOfAlias.ToString Then
                infobox.Show()
                infobox.lbtitletext.Text = "Critical Error - Terminal"
                infobox.lblintructtext.Text = "The command did not respond in time, stopping command"
                ShiftOSDesktop.log = ShiftOSDesktop.log & ShiftOSDesktop.username & " found seceret in the game, may has access to source-code."
            End If
        Catch ex As Exception
        End Try

        If command Like "log *" Then
            txtterm.Text = ""
            ShiftOSDesktop.log = ShiftOSDesktop.log & "Log was shown to " & ShiftOSDesktop.username & " at " & TimeOfDay
            txtterm.Text = ShiftOSDesktop.log
        End If

        If command Like "ctd" Then
            ForceCrash()
        End If

        If command Like "join *" Then
            coherencemode.setupwindows(command.Substring(5))
            txtterm.Text = txtterm.Text & Environment.NewLine & "Enabling Coherence Mode for " & (command.Substring(5)) & Environment.NewLine
        End If

        If command Like "set username *" Then
            If ShiftOSDesktop.boughtcustomusername = True Then
                ShiftOSDesktop.username = command.Substring(command.LastIndexOf(" ") + 1, command.Length - (command.LastIndexOf(" ") + 1))
                further = False
            End If
        End If

        If command Like "set osname *" Then
            If ShiftOSDesktop.boughtchangeosnamecommand = True Then
                ShiftOSDesktop.osname = command.Substring(command.LastIndexOf(" ") + 1, command.Length - (command.LastIndexOf(" ") + 1))
                further = False
            End If
        End If

        If command Like "give me *" Then
            ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + command.Substring(command.LastIndexOf(" ") + 1, command.Length - (command.LastIndexOf(" ") + 1))
            further = False
        End If

        If command Like "dig me *" Then
            Dim amount As Decimal = command.Substring(command.LastIndexOf(" ") + 1, command.Length - (command.LastIndexOf(" ") + 1))
            ShiftOSDesktop.bitnotebalance = ShiftOSDesktop.bitnotebalance + amount
            Bitnote_Wallet.logtransaction(amount, "Credit From", "ShiftOS Devs - Thanks for donating!")
            Bitnote_Wallet.setupbitnotestats()
            further = False
        End If
        If command Like "show me *, *" Then
            Dim term As String()
            term = command.Remove(0, 8).Split(", ")
            infobox.title = term(0)
            infobox.textinfo = term(1)
            infobox.Show()
        End If
        If ShiftOSDesktop.boughtwindowsanywhere = True Then
            If command Like "move *" Then
                command = command.Replace(", ", ",")
                Dim coords As String() = command.Split(" ")
                Dim xandy As String = coords(coords.Length - 1)
                Dim spxandy() As String = xandy.Split(",")
                Select Case coords(1)
                    Case "knowledge", ShiftOSDesktop.knowledgeinputname.ToLower
                        Knowledge_Input.Location = New Point(spxandy(0), spxandy(1))
                    Case "terminal", ShiftOSDesktop.terminalname.ToLower
                        Me.Location = New Point(spxandy(0), spxandy(1))
                    Case "shiftorium", ShiftOSDesktop.shiftoriumname.ToLower
                        Shiftorium.Location = New Point(spxandy(0), spxandy(1))
                    Case "clock", ShiftOSDesktop.clockname.ToLower
                        Clock.Location = New Point(spxandy(0), spxandy(1))
                    Case "shifter", ShiftOSDesktop.shiftername.ToLower
                        Shifter.Location = New Point(spxandy(0), spxandy(1))
                    Case "colour", "color", ShiftOSDesktop.colourpickername.ToLower
                        Colour_Picker.Location = New Point(spxandy(0), spxandy(1))
                    Case "info", "infobox"
                        infobox.Location = New Point(spxandy(0), spxandy(1))
                    Case "pong", ShiftOSDesktop.pongname.ToLower
                        Pong.Location = New Point(spxandy(0), spxandy(1))
                    Case "file", ShiftOSDesktop.fileskimmername.ToLower
                        File_Skimmer.Location = New Point(spxandy(0), spxandy(1))
                    Case "textpad", ShiftOSDesktop.textpadname.ToLower
                        TextPad.Location = New Point(spxandy(0), spxandy(1))
                    Case "fileopener", ShiftOSDesktop.fileopenername.ToLower
                        File_Opener.Location = New Point(spxandy(0), spxandy(1))
                    Case "filesaver", ShiftOSDesktop.filesavername.ToLower
                        File_Saver.Location = New Point(spxandy(0), spxandy(1))
                    Case "graphicpicker", "graphic", ShiftOSDesktop.graphicpickername.ToLower
                        Graphic_Picker.Location = New Point(spxandy(0), spxandy(1))
                    Case "skinloader", "skin", ShiftOSDesktop.skinloadername.ToLower
                        Skin_Loader.Location = New Point(spxandy(0), spxandy(1))
                    Case "artpad", "art", ShiftOSDesktop.artpadname.ToLower
                        ArtPad.Location = New Point(spxandy(0), spxandy(1))
                    Case "calculator", "calc", ShiftOSDesktop.calculatorname.ToLower
                        Calculator.Location = New Point(spxandy(0), spxandy(1))
                    Case "webbrowser", "web", ShiftOSDesktop.webbrowsername.ToLower
                        Web_Browser.Location = New Point(spxandy(0), spxandy(1))
                    Case "videoplayer", "video", ShiftOSDesktop.videoplayername.ToLower
                        Web_Browser.Location = New Point(spxandy(0), spxandy(1))
                    Case "namechanger", "name", ShiftOSDesktop.namechangername.ToLower
                        Name_Changer.Location = New Point(spxandy(0), spxandy(1))
                    Case "iconmanager", "icon", ShiftOSDesktop.iconmanagername.ToLower
                        Icon_Manager.Location = New Point(spxandy(0), spxandy(1))
                    Case "bitnotewallet", "wallet", ShiftOSDesktop.bitnotewalletname.ToLower
                        Bitnote_Wallet.Location = New Point(spxandy(0), spxandy(1))
                    Case "bitnotedigger", "digger", ShiftOSDesktop.bitnotediggername.ToLower
                        Bitnote_Digger.Location = New Point(spxandy(0), spxandy(1))
                    Case "skinshifter", ShiftOSDesktop.skinshiftername.ToLower
                        Skinshifter.Location = New Point(spxandy(0), spxandy(1))
                    Case "shiftnet", ShiftOSDesktop.shiftnetname.ToLower
                        Shiftnet.Location = New Point(spxandy(0), spxandy(1))
                    Case "dodge", ShiftOSDesktop.dodgename.ToLower
                        Dodge.Location = New Point(spxandy(0), spxandy(1))
                    Case "downloadmanager", ShiftOSDesktop.downloadmanagername.ToLower
                        Downloadmanager.Location = New Point(spxandy(0), spxandy(1))
                    Case "installer", ShiftOSDesktop.installername.ToLower
                        Installer.Location = New Point(spxandy(0), spxandy(1))
                    Case "snakey", ShiftOSDesktop.snakeyname.ToLower
                        Snakey.Location = New Point(spxandy(0), spxandy(1))
                    Case "orcwrite", ShiftOSDesktop.orcwritename.ToLower
                        OrcWrite.Location = New Point(spxandy(0), spxandy(1))
                End Select
                further = False
            End If
        End If

        If ShiftOSDesktop.boughtmultitasking = True Then
            If command Like "switch to *" Then
                Dim findwords() As String = command.Split(" ")
                Select Case findwords(2)
                    Case "knowledge", ShiftOSDesktop.knowledgeinputname.ToLower
                        Knowledge_Input.BringToFront()
                    Case "shiftorium", ShiftOSDesktop.shiftoriumname.ToLower
                        Shiftorium.BringToFront()
                    Case "clock", ShiftOSDesktop.clockname.ToLower
                        Clock.BringToFront()
                    Case "shifter", ShiftOSDesktop.shiftername.ToLower
                        Shifter.BringToFront()
                    Case "colour", ShiftOSDesktop.colourpickername.ToLower
                        Colour_Picker.BringToFront()
                    Case "info"
                        infobox.BringToFront()
                    Case "pong", ShiftOSDesktop.pongname.ToLower
                        Pong.BringToFront()
                    Case "file", ShiftOSDesktop.fileskimmername.ToLower
                        File_Skimmer.BringToFront()
                    Case "textpad", ShiftOSDesktop.textpadname.ToLower
                        TextPad.BringToFront()
                    Case "fileopener", ShiftOSDesktop.fileopenername.ToLower
                        File_Opener.BringToFront()
                    Case "filesaver", ShiftOSDesktop.filesavername.ToLower
                        File_Saver.BringToFront()
                    Case "graphic", ShiftOSDesktop.graphicpickername.ToLower
                        Graphic_Picker.BringToFront()
                    Case "skin", ShiftOSDesktop.skinloadername.ToLower
                        Skin_Loader.BringToFront()
                    Case "artpad", ShiftOSDesktop.artpadname.ToLower
                        ArtPad.BringToFront()
                    Case "calculator", ShiftOSDesktop.calculatorname.ToLower
                        Calculator.BringToFront()
                    Case "webbrowser", "web", ShiftOSDesktop.webbrowsername.ToLower
                        Web_Browser.BringToFront()
                    Case "videoplayer", "video", "video player", ShiftOSDesktop.videoplayername.ToLower
                        Video_Player.BringToFront()
                    Case "namechanger", "name", "name changer", ShiftOSDesktop.namechangername.ToLower
                        Name_Changer.BringToFront()
                    Case "iconmanager", "icon", ShiftOSDesktop.iconmanagername.ToLower
                        Name_Changer.BringToFront()
                    Case "bitnotewallet", "wallet", ShiftOSDesktop.bitnotewalletname.ToLower
                        Bitnote_Wallet.BringToFront()
                    Case "bitnotedigger", "digger", ShiftOSDesktop.bitnotediggername.ToLower
                        Bitnote_Digger.BringToFront()
                    Case "skinshifter", ShiftOSDesktop.skinshiftername.ToLower
                        Skinshifter.BringToFront()
                    Case "shiftnet", ShiftOSDesktop.shiftnetname.ToLower
                        Shiftnet.BringToFront()
                    Case "dodge", ShiftOSDesktop.dodgename.ToLower
                        Dodge.BringToFront()
                    Case "downloadmanager", ShiftOSDesktop.downloadmanagername.ToLower
                        Downloadmanager.BringToFront()
                    Case "installer", ShiftOSDesktop.installername.ToLower
                        Installer.BringToFront()
                    Case "snakey", ShiftOSDesktop.snakeyname.ToLower
                        Snakey.BringToFront()
                    Case "orcwrite", ShiftOSDesktop.orcwritename.ToLower
                        OrcWrite.BringToFront()
                End Select
                further = False
                Me.BringToFront()
            End If
        End If

        If ShiftOSDesktop.boughtrollupcommand = True Then
            If command Like "roll *" Then
                Dim findwords() As String = command.Split(" ")
                Select Case findwords(1)
                    Case "knowledge", ShiftOSDesktop.knowledgeinputname.ToLower
                        Knowledge_Input.rollupanddown()
                    Case "shiftorium", ShiftOSDesktop.shiftoriumname.ToLower
                        Shiftorium.rollupanddown()
                    Case "clock", ShiftOSDesktop.clockname.ToLower
                        Clock.rollupanddown()
                    Case "shifter", ShiftOSDesktop.shiftername.ToLower
                        Shifter.rollupanddown()
                    Case "colour", ShiftOSDesktop.colourpickername.ToLower
                        Colour_Picker.rollupanddown()
                    Case "info", "infobox"
                        infobox.rollupanddown()
                    Case "pong", ShiftOSDesktop.pongname.ToLower
                        Pong.rollupanddown()
                    Case "file", ShiftOSDesktop.fileskimmername.ToLower
                        File_Skimmer.rollupanddown()
                    Case "textpad", ShiftOSDesktop.textpadname.ToLower
                        TextPad.rollupanddown()
                    Case "fileopener", ShiftOSDesktop.fileopenername.ToLower
                        File_Opener.rollupanddown()
                    Case "filesaver", ShiftOSDesktop.filesavername.ToLower
                        File_Saver.rollupanddown()
                    Case "graphic", ShiftOSDesktop.graphicpickername.ToLower
                        Graphic_Picker.rollupanddown()
                    Case "skin", ShiftOSDesktop.skinloadername.ToLower
                        Skin_Loader.rollupanddown()
                    Case "artpad", ShiftOSDesktop.artpadname.ToLower
                        ArtPad.rollupanddown()
                    Case "calculator", ShiftOSDesktop.calculatorname.ToLower
                        Calculator.rollupanddown()
                    Case "webbrowser", "web", ShiftOSDesktop.webbrowsername.ToLower
                        Web_Browser.rollupanddown()
                    Case "videoplayer", "video", "video player", ShiftOSDesktop.videoplayername.ToLower
                        Video_Player.rollupanddown()
                    Case "namechanger", "name", "name changer", ShiftOSDesktop.namechangername.ToLower
                        Name_Changer.rollupanddown()
                    Case "iconmanager", "icon", ShiftOSDesktop.iconmanagername.ToLower
                        Name_Changer.rollupanddown()
                    Case "bitnotewallet", "wallet", ShiftOSDesktop.bitnotewalletname.ToLower
                        Bitnote_Wallet.rollupanddown()
                    Case "bitnotedigger", "digger", ShiftOSDesktop.bitnotediggername.ToLower
                        Bitnote_Digger.rollupanddown()
                    Case "skinshifter", ShiftOSDesktop.skinshiftername.ToLower
                        Skinshifter.rollupanddown()
                    Case "shiftnet", ShiftOSDesktop.shiftnetname.ToLower
                        Shiftnet.rollupanddown()
                    Case "dodge", ShiftOSDesktop.dodgename.ToLower
                        Dodge.rollupanddown()
                    Case "downloadmanager", ShiftOSDesktop.downloadmanagername.ToLower
                        Downloadmanager.rollupanddown()
                    Case "installer", ShiftOSDesktop.installername.ToLower
                        Installer.rollupanddown()
                    Case "snakey", ShiftOSDesktop.snakeyname.ToLower
                        Snakey.rollupanddown()
                    Case "orcwrite", ShiftOSDesktop.orcwritename.ToLower
                        OrcWrite.rollupanddown()
                End Select
                further = False
                Me.BringToFront()
            End If
        End If

        If ShiftOSDesktop.boughtminimizecommand = True Then
            If command Like "minimize *" Then
                Dim findwords() As String = command.Split(" ")
                Select Case findwords(1)
                    Case "knowledge", ShiftOSDesktop.knowledgeinputname.ToLower
                        ShiftOSDesktop.minimizeprogram(Knowledge_Input, False)
                    Case "shiftorium", ShiftOSDesktop.shiftoriumname.ToLower
                        ShiftOSDesktop.minimizeprogram(Shiftorium, False)
                    Case "clock", ShiftOSDesktop.clockname.ToLower
                        ShiftOSDesktop.minimizeprogram(Clock, False)
                    Case "shifter", ShiftOSDesktop.shiftername.ToLower
                        ShiftOSDesktop.minimizeprogram(Shifter, False)
                    Case "colour", ShiftOSDesktop.colourpickername.ToLower
                        ShiftOSDesktop.minimizeprogram(Colour_Picker, False)
                    Case "info", "infobox"
                        ShiftOSDesktop.minimizeprogram(infobox, False)
                    Case "pong", ShiftOSDesktop.pongname.ToLower
                        ShiftOSDesktop.minimizeprogram(Pong, False)
                    Case "file", ShiftOSDesktop.fileskimmername.ToLower
                        ShiftOSDesktop.minimizeprogram(File_Skimmer, False)
                    Case "textpad", ShiftOSDesktop.textpadname.ToLower
                        ShiftOSDesktop.minimizeprogram(TextPad, False)
                    Case "fileopener", ShiftOSDesktop.fileopenername.ToLower
                        ShiftOSDesktop.minimizeprogram(File_Opener, False)
                    Case "filesaver", ShiftOSDesktop.filesavername.ToLower
                        ShiftOSDesktop.minimizeprogram(File_Saver, False)
                    Case "graphic", ShiftOSDesktop.graphicpickername.ToLower
                        ShiftOSDesktop.minimizeprogram(Graphic_Picker, False)
                    Case "skin", ShiftOSDesktop.skinloadername.ToLower
                        ShiftOSDesktop.minimizeprogram(Skin_Loader, False)
                    Case "artpad", ShiftOSDesktop.artpadname.ToLower
                        ShiftOSDesktop.minimizeprogram(ArtPad, False)
                    Case "calculator", ShiftOSDesktop.calculatorname.ToLower
                        ShiftOSDesktop.minimizeprogram(Calculator, False)
                    Case "webbrowser", "web", ShiftOSDesktop.webbrowsername.ToLower
                        ShiftOSDesktop.minimizeprogram(Web_Browser, False)
                    Case "videoplayer", "video", "video player", ShiftOSDesktop.videoplayername.ToLower
                        ShiftOSDesktop.minimizeprogram(Video_Player, False)
                    Case "namechanger", "name", "name changer", ShiftOSDesktop.namechangername.ToLower
                        ShiftOSDesktop.minimizeprogram(Name_Changer, False)
                    Case "iconmanager", "icon", ShiftOSDesktop.iconmanagername.ToLower
                        ShiftOSDesktop.minimizeprogram(Name_Changer, False)
                    Case "bitnotewallet", "wallet", ShiftOSDesktop.bitnotewalletname.ToLower
                        ShiftOSDesktop.minimizeprogram(Bitnote_Wallet, False)
                    Case "bitnotedigger", "digger", ShiftOSDesktop.bitnotediggername.ToLower
                        ShiftOSDesktop.minimizeprogram(Bitnote_Digger, False)
                    Case "skinshifter", ShiftOSDesktop.skinshiftername.ToLower
                        ShiftOSDesktop.minimizeprogram(Skinshifter, False)
                    Case "shiftnet", ShiftOSDesktop.shiftnetname.ToLower
                        ShiftOSDesktop.minimizeprogram(Shiftnet, False)
                    Case "dodge", ShiftOSDesktop.dodgename.ToLower
                        ShiftOSDesktop.minimizeprogram(Dodge, False)
                    Case "downloadmanager", ShiftOSDesktop.downloadmanagername.ToLower
                        ShiftOSDesktop.minimizeprogram(Downloadmanager, False)
                    Case "installer", ShiftOSDesktop.installername.ToLower
                        ShiftOSDesktop.minimizeprogram(Installer, False)
                    Case "snakey", ShiftOSDesktop.snakeyname.ToLower
                        ShiftOSDesktop.minimizeprogram(Snakey, False)
                    Case "orcwrite", ShiftOSDesktop.orcwritename.ToLower
                        ShiftOSDesktop.minimizeprogram(OrcWrite, False)
                End Select
                further = False
                Me.BringToFront()
            End If
        End If

        If further = True Then
            Select Case command
                Case "test fullscreen login customizer"
                    FullScreenLoginCustomizer.Show()
                Case "test fullscreen login"
                    FullScreenLogin.Show()
                Case "adv app launcher on"
                    ShiftOSDesktop.boughtadvapplauncher = True
                    ShiftOSDesktop.savegame()
                    ShiftOSDesktop.setupdesktop()
                    WriteLine("Advanced App Launcher has been turned on successfully. Use ""adv app launcher off"" to turn it off again.")
                Case "adv app launcher off"
                    ShiftOSDesktop.boughtadvapplauncher = False
                    ShiftOSDesktop.savegame()
                    ShiftOSDesktop.setupdesktop()
                    WriteLine("Advanced App Launcher has been turned off. Use ""adv app launcher on"" to turn it on again.")

                Case "clear"
                    txtterm.Text = ""
                Case "time"
                    If ShiftOSDesktop.boughtsplitsecondtime = True Then
                        txtterm.Text = txtterm.Text & Environment.NewLine & "The time is " & TimeOfDay & Environment.NewLine
                    Else
                        If ShiftOSDesktop.boughtminuteaccuracytime = True Then
                            If Date.Now.Hour < 12 Then
                                txtterm.Text = txtterm.Text & Environment.NewLine & "The time is " & TimeOfDay.Hour & ":" & Format(TimeOfDay.Minute, "00") & " AM" & Environment.NewLine
                            Else
                                txtterm.Text = txtterm.Text & Environment.NewLine & "The time is " & TimeOfDay.Hour - 12 & ":" & Format(TimeOfDay.Minute, "00") & " PM" & Environment.NewLine
                            End If
                        Else
                            If ShiftOSDesktop.boughtpmandam = True Then
                                If Date.Now.Hour < 12 Then
                                    txtterm.Text = txtterm.Text & Environment.NewLine & "The time is " & TimeOfDay.Hour & " AM" & Environment.NewLine
                                Else
                                    txtterm.Text = txtterm.Text & Environment.NewLine & "The time is " & TimeOfDay.Hour - 12 & " PM" & Environment.NewLine
                                End If
                            Else
                                If ShiftOSDesktop.boughthourspastmidnight = True Then
                                    txtterm.Text = txtterm.Text & Environment.NewLine & "Since midnight " & Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60 / 60) & " hours have passed" & Environment.NewLine
                                Else
                                    If ShiftOSDesktop.boughtminutespastmidnight = True Then
                                        txtterm.Text = txtterm.Text & Environment.NewLine & "Since midnight " & Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60) & " minutes have passed" & Environment.NewLine
                                    Else
                                        If ShiftOSDesktop.boughtsecondspastmidnight = True Then
                                            txtterm.Text = txtterm.Text & Environment.NewLine & "Since midnight " & Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds) & " seconds have passed" & Environment.NewLine
                                        Else
                                            wrongcommand()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case "shutdown", "shut down"
                    ShiftOSDesktop.shutdownshiftos()
                Case "save", "save game"
                    ShiftOSDesktop.savegame()
                    txtterm.Text = txtterm.Text & Environment.NewLine & "The game has been saved!" & Environment.NewLine
                Case "code points"
                    txtterm.Text = txtterm.Text & Environment.NewLine & "You Have " & ShiftOSDesktop.codepoints & " Code Points!" & Environment.NewLine
                    ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User has " & ShiftOSDesktop.codepoints & " Code Points!" & Environment.NewLine
                Case "codepoints"
                    txtterm.Text = txtterm.Text & Environment.NewLine & "You Have " & ShiftOSDesktop.codepoints & " Code Points!" & Environment.NewLine
                    ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User has " & ShiftOSDesktop.codepoints & " Code Points!" & Environment.NewLine
                Case "fullscreen terminal", "full screen terminal"
                    If ShiftOSDesktop.boughtwindowedterminal = True Then
                        fullterminal()
                        ShiftOSDesktop.terminalfullscreen = True
                    Else
                        wrongcommand()
                    End If
                Case "windowed terminal"
                    If ShiftOSDesktop.boughtwindowedterminal = True Then
                        miniterminal()
                        ShiftOSDesktop.terminalfullscreen = False
                    Else
                        wrongcommand()
                    End If
                Case "open terminal"
                    txtterm.Text = txtterm.Text & Environment.NewLine & "Terminal is already running!" & Environment.NewLine
                Case "open knowledge input", "knowledge input", "open " & ShiftOSDesktop.knowledgeinputname.ToLower, ShiftOSDesktop.knowledgeinputname.ToLower
                    ShiftOSDesktop.closeeverything()
                    If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                    Knowledge_Input.Show()
                Case "close knowledge input", "close " & ShiftOSDesktop.knowledgeinputname.ToLower, ShiftOSDesktop.knowledgeinputname.ToLower
                    Knowledge_Input.Close()
                Case "open shiftorium", "shiftorium", "open " & ShiftOSDesktop.shiftoriumname.ToLower, ShiftOSDesktop.shiftoriumname.ToLower
                    ShiftOSDesktop.closeeverything()
                    If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                    Shiftorium.Show()
                Case "close shiftorium", "close " & ShiftOSDesktop.shiftoriumname.ToLower, ShiftOSDesktop.shiftoriumname.ToLower
                    Shiftorium.Close()
                Case "open shifter", "shifter", "open " & ShiftOSDesktop.shiftername.ToLower, ShiftOSDesktop.shiftername.ToLower
                    If ShiftOSDesktop.boughtshifter = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Shifter.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close shifter", "close " & ShiftOSDesktop.shiftername.ToLower, ShiftOSDesktop.shiftername.ToLower
                    If ShiftOSDesktop.boughtshifter = True Then
                        Shifter.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open pong", "pong", "open " & ShiftOSDesktop.pongname.ToLower, ShiftOSDesktop.pongname.ToLower
                    If ShiftOSDesktop.boughtpong = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Pong.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close pong", "close " & ShiftOSDesktop.pongname.ToLower, ShiftOSDesktop.pongname.ToLower
                    If ShiftOSDesktop.boughtpong = True Then
                        Pong.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open file skimmer", "file skimmer", "open " & ShiftOSDesktop.fileskimmername.ToLower, ShiftOSDesktop.fileskimmername.ToLower
                    If ShiftOSDesktop.boughtfileskimmer = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        File_Skimmer.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close file skimmer", "close " & ShiftOSDesktop.fileskimmername.ToLower, ShiftOSDesktop.fileskimmername.ToLower
                    If ShiftOSDesktop.boughtfileskimmer = True Then
                        File_Skimmer.Close()
                    Else
                        wrongcommand()
                    End If
                Case "close file opener", "close " & ShiftOSDesktop.fileopenername.ToLower, ShiftOSDesktop.fileopenername.ToLower
                    If ShiftOSDesktop.boughtfileskimmer = True Then
                        File_Opener.Close()
                    Else
                        wrongcommand()
                    End If
                Case "close file saver", "close " & ShiftOSDesktop.filesavername.ToLower, ShiftOSDesktop.filesavername.ToLower
                    If ShiftOSDesktop.boughtfileskimmer = True Then
                        File_Saver.Close()
                    Else
                        wrongcommand()
                    End If
                Case "close graphic picker", "close graphic", "close " & ShiftOSDesktop.graphicpickername.ToLower, ShiftOSDesktop.graphicpickername.ToLower
                    If ShiftOSDesktop.boughtfileskimmer = True Then
                        Graphic_Picker.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open textpad", "open text pad", "textpad", "text pad", "open " & ShiftOSDesktop.textpadname.ToLower, ShiftOSDesktop.textpadname.ToLower
                    If ShiftOSDesktop.boughttextpad = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        TextPad.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close textpad", "close text pad", "close " & ShiftOSDesktop.textpadname.ToLower, ShiftOSDesktop.textpadname.ToLower
                    If ShiftOSDesktop.boughttextpad = True Then
                        TextPad.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open skinloader", "open skin loader", "skin loader", "skinloader", "open " & ShiftOSDesktop.skinloadername.ToLower, ShiftOSDesktop.skinloadername.ToLower
                    If ShiftOSDesktop.boughtskinning = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Skin_Loader.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close skinloader", "close skin loader", "close " & ShiftOSDesktop.skinloadername.ToLower, ShiftOSDesktop.skinloadername.ToLower
                    If ShiftOSDesktop.boughtskinloader = True Then
                        Skin_Loader.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open art", "open artpad", "artpad", "open " & ShiftOSDesktop.artpadname.ToLower, ShiftOSDesktop.artpadname.ToLower
                    If ShiftOSDesktop.boughtartpad = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        ArtPad.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close art", "close artpad", "close " & ShiftOSDesktop.artpadname.ToLower, ShiftOSDesktop.artpadname.ToLower
                    If ShiftOSDesktop.boughtartpad = True Then
                        ArtPad.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open calc", "open calculator", "calculator", "open " & ShiftOSDesktop.calculatorname.ToLower, ShiftOSDesktop.calculatorname.ToLower
                    If ShiftOSDesktop.boughtcalculator = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Calculator.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close calc", "close calculator", "close " & ShiftOSDesktop.calculatorname.ToLower, ShiftOSDesktop.calculatorname.ToLower
                    If ShiftOSDesktop.boughtcalculator = True Then
                        Calculator.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open audio", "open audioplayer", "audioplayer", "audio", "open " & ShiftOSDesktop.audioplayername.ToLower, ShiftOSDesktop.audioplayername.ToLower
                    If ShiftOSDesktop.boughtaudioplayer = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Audio_Player.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close audio", "close audioplayer", "close " & ShiftOSDesktop.audioplayername.ToLower, ShiftOSDesktop.audioplayername.ToLower
                    If ShiftOSDesktop.boughtaudioplayer = True Then
                        Audio_Player.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open web", "open webbrowser", "open web browser", "web", "webbrowser", "web browser", "open " & ShiftOSDesktop.webbrowsername.ToLower, ShiftOSDesktop.webbrowsername.ToLower
                    If ShiftOSDesktop.boughtwebbrowser = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Web_Browser.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close web", "close webbrowser", "close web browser", "close " & ShiftOSDesktop.webbrowsername.ToLower, ShiftOSDesktop.webbrowsername.ToLower
                    If ShiftOSDesktop.boughtwebbrowser = True Then
                        Web_Browser.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open video", "open videoplayer", "open video player", "open " & ShiftOSDesktop.videoplayername.ToLower, ShiftOSDesktop.videoplayername.ToLower
                    If ShiftOSDesktop.boughtvideoplayer = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Video_Player.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close video", "close videoplayer", "close video player", "close " & ShiftOSDesktop.videoplayername.ToLower, ShiftOSDesktop.videoplayername.ToLower
                    If ShiftOSDesktop.boughtvideoplayer = True Then
                        Video_Player.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open name", "open namechanger", "open name changer", "open " & ShiftOSDesktop.namechangername.ToLower, ShiftOSDesktop.namechangername.ToLower
                    If ShiftOSDesktop.boughtnamechanger = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Name_Changer.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close name", "close namechanger", "close name changer", "close " & ShiftOSDesktop.namechangername.ToLower, ShiftOSDesktop.namechangername.ToLower
                    If ShiftOSDesktop.boughtnamechanger = True Then
                        Name_Changer.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open icon", "open iconmanager", "open icon manager", "open " & ShiftOSDesktop.iconmanagername.ToLower, ShiftOSDesktop.iconmanagername.ToLower
                    If ShiftOSDesktop.boughticonmanager = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Icon_Manager.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close icon", "close iconmanager", "close icon manager", "close " & ShiftOSDesktop.iconmanagername.ToLower, ShiftOSDesktop.iconmanagername.ToLower
                    If ShiftOSDesktop.boughticonmanager = True Then
                        Icon_Manager.Close()
                    Else
                        wrongcommand()
                    End If
                Case "open clock", "clock", "open " & ShiftOSDesktop.clockname.ToLower, ShiftOSDesktop.clockname.ToLower
                    If ShiftOSDesktop.boughtclock = True Then
                        ShiftOSDesktop.closeeverything()
                        If ShiftOSDesktop.terminalfullscreen = True Then Me.Hide()
                        Clock.Show()
                    Else
                        wrongcommand()
                    End If
                Case "close clock", "close " & ShiftOSDesktop.clockname.ToLower, ShiftOSDesktop.clockname.ToLower
                    Clock.Close()
                Case "close colourpicker", "close colour", "close color", "close color picker", "close colour picker", "close colorpicker", "close " & ShiftOSDesktop.colourpickername.ToLower, ShiftOSDesktop.colourpickername.ToLower
                    Colour_Picker.Close()
                Case "close infobox", "close info", "close info box"
                    infobox.Close()
                Case "close terminal", "close " & ShiftOSDesktop.terminalname.ToLower, ShiftOSDesktop.terminalname.ToLower
                    txtterm.Text = ""
                    txtterm.Text = txtterm.Text + ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    txtterm.Select(txtterm.Text.Length, 0)
                    Me.Close()
                Case "roll terminal"
                    txtterm.Text = txtterm.Text & Environment.NewLine & "Terminal has just tried to perform an illegal operation!" & Environment.NewLine
                    ShiftOSDesktop.log = ShiftOSDesktop.log & "Terminal attempted to peform a illegal command at " & TimeOfDay
                Case "programs", "program"
                    listprograms()
                Case "unity mode on"
                    If ShiftOSDesktop.boughtunitymode = True Then
                        ShiftOSDesktop.unitymode = True
                        ShiftOSDesktop.setupdesktop()
                        ShiftOSDesktop.log = ShiftOSDesktop.log & "Unity mode was activated at " & TimeOfDay
                    Else
                        wrongcommand()
                    End If
                Case "unity mode off"
                    If ShiftOSDesktop.boughtunitymode = True Then
                        ShiftOSDesktop.unitymode = False
                        ShiftOSDesktop.setupdesktop()
                        ShiftOSDesktop.log = ShiftOSDesktop.log & "Unity mode was disabled at " & TimeOfDay
                    Else
                        wrongcommand()
                    End If
                Case "template"
                    template.Show()
                Case "05tray"
                    ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + 500
                    txtterm.Text = txtterm.Text & Environment.NewLine & "You have just cheated. Here is your 500 codepoints" & Environment.NewLine
                    ShiftOSDesktop.log = ShiftOSDesktop.log & ShiftOSDesktop.username & " cheated and got 500 codepoints, damn cheaters..."
                    'txtterm.Text = txtterm.Text & Environment.NewLine & "Due to attempting to cheat you have lost all your codepoints... Kidding, but that command is disabled." & Environment.NewLine 'Wow, I don't know devX put that in! 'Talk about lolz
                Case "cherryblue"
                    ShiftOSDesktop.bitnotebalance = ShiftOSDesktop.bitnotebalance + 1
                    ShiftOSDesktop.log = ShiftOSDesktop.log & "Hacked by CherryBlue, given 1 bitnote at " & TimeOfDay
                    Bitnote_Wallet.logtransaction(1.0, "Credit From", "CherryBlue - The Hacker!")
                    Bitnote_Wallet.setupbitnotestats()
                    'Case "pullme"
                    '    ShiftOSDesktop.boughtresizablewindows = True
                    '    txtterm.Text = txtterm.Text & Environment.NewLine & "Remember the resize windows feature is not refined yet (Test with Artpad)!" & Environment.NewLine
                Case "infect zero.th1"
                    Viruses.zerogravity = True
                    Viruses.zerogravitythreatlevel = 1
                    Viruses.setupzerovirus()
                Case "infect zero.th2"
                    Viruses.zerogravity = True
                    Viruses.zerogravitythreatlevel = 2
                    Viruses.setupzerovirus()
                Case "infect zero.th3"
                    Viruses.zerogravity = True
                    Viruses.zerogravitythreatlevel = 3
                    Viruses.setupzerovirus()
                Case "infect zero.th4"
                    Viruses.zerogravity = True
                    Viruses.zerogravitythreatlevel = 4
                    Viruses.setupzerovirus()
                Case "zero.heal"
                    Viruses.removezerovirus()
                Case "infect mousetrap.th1"
                    Viruses.mousetrap = True
                    Viruses.mousetrapthreatlevel = 1
                    Viruses.setupmousetrapvirus()
                Case "infect mousetrap.th2"
                    Viruses.mousetrap = True
                    Viruses.mousetrapthreatlevel = 2
                    Viruses.setupmousetrapvirus()
                Case "infect mousetrap.th3"
                    Viruses.mousetrap = True
                    Viruses.mousetrapthreatlevel = 3
                    Viruses.setupmousetrapvirus()
                Case "infect mousetrap.th4"
                    Viruses.mousetrap = True
                    Viruses.mousetrapthreatlevel = 4
                    Viruses.setupmousetrapvirus()
                Case "mousetrap.heal"
                    Viruses.removemousetrapvirus()
                Case "infect beeper.th1"
                    Viruses.beeper = True
                    Viruses.beeperthreatlevel = 1
                    Viruses.setupbeepervirus()
                Case "infect beeper.th2"
                    Viruses.beeper = True
                    Viruses.beeperthreatlevel = 2
                    Viruses.setupbeepervirus()
                Case "infect beeper.th3"
                    Viruses.beeper = True
                    Viruses.beeperthreatlevel = 3
                    Viruses.setupbeepervirus()
                Case "infect beeper.th4"
                    Viruses.beeper = True
                    Viruses.beeperthreatlevel = 4
                    Viruses.setupbeepervirus()
                Case "beeper.heal"
                    Viruses.removebeepervirus()
                Case "infect plague.th1"
                    Viruses.ThePlague = True
                    Viruses.theplaguethreatlevel = 1
                    Viruses.setuptheplague()
                Case "infect plague.th2"
                    Viruses.ThePlague = True
                    Viruses.theplaguethreatlevel = 2
                    Viruses.setuptheplague()
                Case "infect plague.th3"
                    Viruses.ThePlague = True
                    Viruses.theplaguethreatlevel = 3
                    Viruses.setuptheplague()
                Case "infect plague.th4"
                    Viruses.ThePlague = True
                    Viruses.theplaguethreatlevel = 4
                    Viruses.setuptheplague()
                Case "plague.heal"
                    Viruses.removetheplague()
                Case "get all 0.0.8" 'disable in full
                    ShiftOSDesktop.boughtresizablewindows = True
                    ShiftOSDesktop.boughtcalculator = True
                    ShiftOSDesktop.boughtaudioplayer = True
                    ShiftOSDesktop.boughtchangeosnamecommand = True
                    ShiftOSDesktop.boughtwebbrowser = True
                    ShiftOSDesktop.boughtvideoplayer = True
                    ShiftOSDesktop.boughtnamechanger = True
                    ShiftOSDesktop.boughticonmanager = True
                    ShiftOSDesktop.boughtbitnotewallet = True
                    ShiftOSDesktop.boughtbitnotedigger = True
                    ShiftOSDesktop.boughtskinshifter = True
                    ShiftOSDesktop.boughtshiftnet = True
                    ShiftOSDesktop.boughtshiftneticon = True
                    ShiftOSDesktop.boughtalshiftnet = True
                    ShiftOSDesktop.boughtdodge = True
                    ShiftOSDesktop.boughtdownloadmanager = True
                    ShiftOSDesktop.boughtinstaller = True
                    ShiftOSDesktop.installedsysinfo = True
                    ShiftOSDesktop.boughtorcwrite = True
                    ShiftOSDesktop.boughtfloodgate = True
                    ShiftOSDesktop.boughtmaze = True
                    ShiftOSDesktop.boughtunitymodetoggle = True
                    ShiftOSDesktop.boughtunitytoggleicon = True
                    ShiftOSDesktop.installedvirusscanner = True
                    ShiftOSDesktop.boughttextpadtrm = True
                    ShiftOSDesktop.boughtshiftapplauncheritems = True
                    ShiftOSDesktop.installedcalculator = True
                    ShiftOSDesktop.installedaudioplayer = True
                    ShiftOSDesktop.installedwebbrowser = True
                    ShiftOSDesktop.installedvideoplayer = True
                    ShiftOSDesktop.installeddodge = True
                    ShiftOSDesktop.installedsysinfo = True
                    ShiftOSDesktop.installedorcwrite = True
                    ShiftOSDesktop.installedfloodgate = True
                    ShiftOSDesktop.installedfloodgatenow = True
                    ShiftOSDesktop.installedmaze = True
                    ShiftOSDesktop.installedvirusscanner = True
                    ShiftOSDesktop.setupdesktop()
                Case "yes"
                    If storyline = "getshiftnet" Then
                        getshiftnetstoryyes = True
                    Else
                        wrongcommand()
                    End If
                Case "no"
                    If storyline = "getshiftnet" Then
                        txtterm.Text = txtterm.Text & "Connection declined" & Environment.NewLine
                        storyline = ""
                    Else
                        wrongcommand()
                    End If
                Case "help"
                    txtterm.Text = txtterm.Text & Environment.NewLine & Environment.NewLine & ShiftOSDesktop.osname & " Terminal Help:" & _
                    Environment.NewLine & Environment.NewLine
                    txtterm.Text = txtterm.Text & "Tips: " & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- Click on the desktop then press Ctrl + t to bring up the terminal (only works if you click on the desktop first)!" & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- The terminal is not case sensitive so using or not using capital letters does not make a difference." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- " & ShiftOSDesktop.osname & " saves progress upon shutdown so feel free to open the terminal and type ""Shutdown"" anytime you like." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- This guide will evolve as you buy upgrades for " & ShiftOSDesktop.osname & " to help you understand newly unlocked features." & Environment.NewLine
                    txtterm.Text = txtterm.Text & Environment.NewLine & Environment.NewLine
                    txtterm.Text = txtterm.Text & "Terminal Commands:" & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Programs' - Lists all programs on your computer." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Open [insert program name here]' - Opens the specified program and closes all others." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Close [insert program name here]' - Closes the specified program. For example 'close knowledge input'." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Code Points' - Shows the amount of codepoints you have." & Environment.NewLine
                    If ShiftOSDesktop.boughtsplitsecondtime = True Then
                        txtterm.Text = txtterm.Text & "'Time' - Shows the time with split second accuracy." & Environment.NewLine
                    Else
                        If ShiftOSDesktop.boughtminuteaccuracytime = True Then
                            txtterm.Text = txtterm.Text & "'Time' - Shows the time with minute accuracy." & Environment.NewLine
                        Else
                            If ShiftOSDesktop.boughtpmandam = True Then
                                txtterm.Text = txtterm.Text & "'Time' - Shows the time with hour accuracy." & Environment.NewLine
                            Else
                                If ShiftOSDesktop.boughthourspastmidnight = True Then
                                    txtterm.Text = txtterm.Text & "'Time' - Shows the amount of hours that have passed since midnight." & Environment.NewLine
                                Else
                                    If ShiftOSDesktop.boughtminutespastmidnight = True Then
                                        txtterm.Text = txtterm.Text & "'Time' - Shows the amount of minutes that have passed since midnight." & Environment.NewLine
                                    Else
                                        If ShiftOSDesktop.boughtsecondspastmidnight = True Then
                                            txtterm.Text = txtterm.Text & "'Time' - Shows the amount of seconds that have passed since midnight." & Environment.NewLine
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If ShiftOSDesktop.boughtcustomusername = True Then
                        txtterm.Text = txtterm.Text & "'Set Username [insert name here]' - Sets the system username to anything (e.g. Set Username hacker)." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtmultitasking = True Then
                        txtterm.Text = txtterm.Text & "'Switch To [insert program here]' - Brings the specified window to the front of the screen (e.g. Switch To Shiftorium)." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtwindowsanywhere = True Then
                        txtterm.Text = txtterm.Text & "'Move [insert program here] to [x-coordinate, y-coodinate]' - Moves the specified window to the chosen point (e.g. move shiftorium to 120, 300)." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtwindowedterminal = True Then
                        txtterm.Text = txtterm.Text & "'Windowed Terminal' - Turns the terminal into a normal windowed application." & Environment.NewLine
                        txtterm.Text = txtterm.Text & "'Fullscreen Terminal' - Turns the terminal into a fullscreen application." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtrollupcommand = True Then
                        txtterm.Text = txtterm.Text & "'Roll [insert program here]' - Rolls up a window to it's titlebar or rolls a window down if it's already rolled up." & Environment.NewLine
                    End If
                    txtterm.Text = txtterm.Text & "'Clear' - Removes all text displayed on the terminal." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Help' - Shows commands used in terminal and " & ShiftOSDesktop.osname & " tips." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Save' - Saves all data. Note that data will automatically be saved when you shutdown " & ShiftOSDesktop.osname & "" & Environment.NewLine
                    txtterm.Text = txtterm.Text & "'Shutdown' - Turns off computer safely and saves all data." & Environment.NewLine
                    txtterm.Text = txtterm.Text & Environment.NewLine & Environment.NewLine
                    txtterm.Text = txtterm.Text & "" & ShiftOSDesktop.osname & " Usage Tips:" & Environment.NewLine
                    If ShiftOSDesktop.boughttitlebar = False Then
                        txtterm.Text = txtterm.Text & "- Open programs have no title bar." & Environment.NewLine
                    Else
                        txtterm.Text = txtterm.Text & "- Open programs have a title bar that may have useful features" & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtwindowborders = False Then
                        txtterm.Text = txtterm.Text & "- Open programs have no borders making them difficult to distinguish between other open programs." & Environment.NewLine
                    Else
                        txtterm.Text = txtterm.Text & "- Open programs have borders making them easy to distinguish between other open programs." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtdesktoppanel = True Then
                        txtterm.Text = txtterm.Text & "- Programs that don't open full screen will be centred on the desktop." & Environment.NewLine
                    Else
                        txtterm.Text = txtterm.Text & "- Programs that don't fit full screen will be centred with a black background." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtwindowedterminal = True Then
                        txtterm.Text = txtterm.Text & "- Terminal can run windowed or full screen." & Environment.NewLine
                    Else
                        txtterm.Text = txtterm.Text & "- Terminal runs full screen." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtmultitasking = False Then
                        txtterm.Text = txtterm.Text & "- Only one program can be open at a time (excluding terminal) and can not be moved around the screen." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtanycolour4 Then
                        txtterm.Text = txtterm.Text & "- The screen can display the full range of 16,777,216 RGB colours." & Environment.NewLine
                    Else
                        If ShiftOSDesktop.boughtgray4 = True Then
                            txtterm.Text = txtterm.Text & "- The screen can display all shades of gray. It can also display: "
                            If ShiftOSDesktop.boughtpurple = True Then txtterm.Text = txtterm.Text & "purple, "
                            If ShiftOSDesktop.boughtblue = True Then txtterm.Text = txtterm.Text & "blue, "
                            If ShiftOSDesktop.boughtgreen = True Then txtterm.Text = txtterm.Text & "green, "
                            If ShiftOSDesktop.boughtyellow = True Then txtterm.Text = txtterm.Text & "yellow, "
                            If ShiftOSDesktop.boughtorange = True Then txtterm.Text = txtterm.Text & "orange, "
                            If ShiftOSDesktop.boughtbrown = True Then txtterm.Text = txtterm.Text & "brown, "
                            If ShiftOSDesktop.boughtred = True Then txtterm.Text = txtterm.Text & "red, "
                            If ShiftOSDesktop.boughtpink = True Then txtterm.Text = txtterm.Text & "pink, "
                            txtterm.Text = txtterm.Text & " and nothing else" & Environment.NewLine
                        Else
                            If ShiftOSDesktop.boughtgray = True Then
                                txtterm.Text = txtterm.Text & "- Only Black, White and Gray can be displayed on screen, no program can use any other colour." & Environment.NewLine
                            Else
                                txtterm.Text = txtterm.Text & "- Only Black and White can be displayed on screen, no program can use any other colour." & Environment.NewLine
                            End If
                        End If
                    End If
                    If ShiftOSDesktop.boughtapplaunchermenu = True Then
                        txtterm.Text = txtterm.Text & "- Applications can be opened from the application launcher on the desktop panel." & Environment.NewLine
                    Else
                        txtterm.Text = txtterm.Text & "- Applications can be opened by typing ""open (program name)"" in the terminal." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtclosebutton = True Then
                        txtterm.Text = txtterm.Text & "- Applications can be closed by clicking the close button in their title bar." & Environment.NewLine
                    Else
                        txtterm.Text = txtterm.Text & "- Applications can be closed by typing ""close (program name)"" in the terminal." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtmovablewindows = True Then
                        If ShiftOSDesktop.boughtdraggablewindows = True Then
                            txtterm.Text = txtterm.Text & "- Windows can be dragged around the screen by left clicking and holding a window by it's titlebar." & Environment.NewLine
                        Else
                            txtterm.Text = txtterm.Text & "- Windows can be moved around the screen by holding Ctrl and pressing the wasd keys." & Environment.NewLine
                        End If
                    End If

                    txtterm.Text = txtterm.Text & Environment.NewLine & Environment.NewLine
                    txtterm.Text = txtterm.Text & "CodePoints:" & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- Codepoints can be earned by performing certain tasks in various programs." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- Codepoints can be spent on GUI upgrades and new programs." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- Upgrades can be bought in the 'Shiftorium' Program." & Environment.NewLine
                    txtterm.Text = txtterm.Text & "- You can earn codepoints by playing knowledge input." & Environment.NewLine
                    If ShiftOSDesktop.boughtshifter = True Then
                        txtterm.Text = txtterm.Text & "- You can earn codepoints by customizing " & ShiftOSDesktop.osname & " in the 'Shifter' program." & Environment.NewLine
                    End If
                    If ShiftOSDesktop.boughtpong = True Then
                        txtterm.Text = txtterm.Text & "- You can earn heaps of codepoints playing pong if you cash out on a high level." & Environment.NewLine
                    End If
                Case Else
                    wrongcommand()
            End Select
        End If

        'cmds(UBound(cmds)) = command
        further = True
        ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " Typed Command In Terminal: " & command & Environment.NewLine
    End Sub

    Private Sub wrongcommand()
        txtterm.Text = txtterm.Text & Environment.NewLine & "Command not recognized - Type 'help' for a list of commands!" & Environment.NewLine
    End Sub

    Private Sub listprograms()
        txtterm.Text = txtterm.Text & Environment.NewLine & Environment.NewLine & "Programs Currently Installed:" & Environment.NewLine & _
            ShiftOSDesktop.terminalname & " - A text based command-line interface that allows you to type commands to run programs and manage your computer." & Environment.NewLine & _
            ShiftOSDesktop.knowledgeinputname & " - A game that rewards Code Points when you list enough words within a category such as fruits." & Environment.NewLine & _
            ShiftOSDesktop.shiftoriumname & " - A program that allows you to spend your codepoints on a range of upgrades for " & ShiftOSDesktop.osname & "." & Environment.NewLine
        If ShiftOSDesktop.boughtclock = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.clockname & " - An application that displays the time." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtshifter = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.shiftername & " - A settings manager that allows you to modify the appearance of " & ShiftOSDesktop.osname & "" & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtshifter = True Then
            txtterm.Text = txtterm.Text & "Infobox - A small box with a message that pops up every now and then to guide you." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtshiftdesktop = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.colourpickername & " - A colour manager that allows you to access a range of colours within other programs" & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtfileskimmer = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.fileskimmername & " - A file manager that allows you to skim through the folders and files on your hard drive." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughttextpad = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.textpadname & " - A simple text editor that allows you to write basic text files." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtpong = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.pongname & " - A game that simulates table tennis that rewards you more codepoints for surviving longer." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtskinning = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.skinloadername & " - A program that allows you to load and save skins you have made with the Shifter." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtartpad = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.artpadname & " - A bitmap graphics editor that allows you to draw your own images." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtcalculator = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.calculatorname & " - A simple calculator application that allows you to perform basic mathematical calculations." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtaudioplayer = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.audioplayername & " - A basic application that allows you to load up .mp3 files and output the audio through your speakers." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtwebbrowser = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.webbrowsername & " - An application that allows you to access the world wide web also known as the international network (internet)." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtvideoplayer = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.videoplayername & " - A simple program that allows you load and watch video files on your pc." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtnamechanger = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.namechangername & " - A system modification tool that allows you to alter the names of the programs installed on your pc." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughticonmanager = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.iconmanagername & " - A tool that allows you to modify the icon images and their sizes that are displayed next to programs." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtbitnotewallet = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.bitnotewalletname & " - An application to track all your Bitnote transactions." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtbitnotedigger = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.bitnotediggername & " - A tool for digging bitnotes, it can be upgraded for faster speeds better performance." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtskinshifter = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.skinshiftername & " - A customization program that changes your skin after a given interval." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtshiftnet = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.shiftnetname & " - An application named after the network it is made to access, the shiftnet, a international network made specifically for ShiftOS." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtdodge = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.dodgename & " - A game of dodging falling objects, earn code points for playing." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtdownloadmanager = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.downloadmanagername & " - A tool to download files, to start a download, click a download link in the shiftnet." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtinstaller = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.installername & " - A system tool that installs STP files as programs on your computer." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtorcwrite = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.orcwritename & " - A text editing application with advanced formating options." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtfloodgate = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.floodgatename & " - A Flooding client application." & Environment.NewLine
        End If
        If ShiftOSDesktop.boughtmaze = True Then
            txtterm.Text = txtterm.Text & ShiftOSDesktop.mazename & " - A simple maze escape game." & Environment.NewLine
        End If
    End Sub


    Private Sub tmrfirstrun_Tick(sender As Object, e As EventArgs) Handles tmrfirstrun.Tick
        Select Case firstrun
            Case 1
                txtterm.Text = txtterm.Text + "Installation Successfull" & Environment.NewLine

            Case 2
                txtterm.Text = txtterm.Text + "IP 199.108.232.1 Connecting..." & Environment.NewLine & "User@" & ShiftOSDesktop.osname & " $> "
                My.Computer.Audio.Play(My.Resources.dial_up_modem_02, AudioPlayMode.Background)
            Case 12
                txtterm.Text = txtterm.Text + "IP 199.108.232.1 Connected!" & Environment.NewLine & "User@" & ShiftOSDesktop.osname & " $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)

                For i = 0 To 127
                    ShiftOSDesktop.artpadcolourpallets(i) = Color.FromArgb(-16777216)
                Next
            Case 15
                txtterm.Text = txtterm.Text + "DevX: Hi, my name is DevX and you are now using an early version of my operating system ""ShiftOS""." & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 22
                txtterm.Text = txtterm.Text + "DevX: Currently the terminal is open and I am using it to communicate with you remotely." & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 28
                txtterm.Text = txtterm.Text + "DevX: ShiftOS is going to be the most revolutionary operating system in the world that will run on every electronic device you can think of." & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 36
                txtterm.Text = txtterm.Text + "DevX: I can't tell you much about my future plans right now but if you can help me then I may tell you more in future" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 44
                txtterm.Text = txtterm.Text + "DevX: ShiftOS is barely usable in it's current state so I need you to help me evolve it using codepoints" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 50
                txtterm.Text = txtterm.Text + "DevX: Once you acquire codepoints you can use them to upgrade certain components of ShiftOS or add new software" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 59
                txtterm.Text = txtterm.Text + "DevX: I'll close the terminal now and send you to the blank ShiftOS desktop" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 65
                txtterm.Text = txtterm.Text + "DevX: You can open and close the terminal at any time by pressing CTRL + T" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 70
                txtterm.Text = txtterm.Text + "DevX: Once you are on the desktop open the terminal, type ""help"" and then press enter for a guide on using ShiftOS" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 80
                txtterm.Text = txtterm.Text + "DevX: Gotta run now but I'll contact you soon to see how you are going with evolving ShiftOS for me while I... Work on something else" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 89
                txtterm.Text = txtterm.Text + "DevX: Remember to always click the black desktop first and then press press CTRL + T to open the terminal otherwise the terminal won't open!" & Environment.NewLine & "User@ShiftOS $> "
                My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
            Case 94
                My.Computer.Audio.Play(My.Resources.typesound, AudioPlayMode.Background)
                txtterm.Text = "User@" & ShiftOSDesktop.osname & " $> "
                tmrfirstrun.Stop()
                Me.Close()
        End Select
        firstrun = firstrun + 1
        txtterm.SelectionStart = txtterm.TextLength
    End Sub

    Public Sub runterminalfile(ByVal path As String)
        Dim sr As System.IO.StreamReader
        If My.Computer.FileSystem.FileExists(path) Then
            sr = My.Computer.FileSystem.OpenTextFileReader(path)
            Dim linenum As Integer = IO.File.ReadAllLines(path).Length
            Dim i As Integer = 1
            While i <= linenum
                command = sr.ReadLine()
                DoCommand()
                i = i + 1
            End While
            sr.Close()
        End If
    End Sub

    Private Sub tmrshutdown_Tick(sender As Object, e As EventArgs) Handles tmrshutdown.Tick
        ShiftOSDesktop.Close()
        Me.Close()
        tmrshutdown.Stop()
    End Sub

    Public storyline As String
    Dim getshiftnetstoryyes As Boolean
    Dim getshiftnetwait As Boolean = False
    Private Sub tmrstorylineupdate_Tick(sender As Object, e As EventArgs) Handles tmrstorylineupdate.Tick
        'put all storyline subs in here, they will be updated every second
        Select Case storyline
            Case "getshiftnet"
                getshiftnetstory()
            Case "storyline here"
                'storyline function
        End Select
    End Sub

    Dim shiftnetstorylinetiming As Integer
    Private Sub getshiftnetstory()
        Dim delay As Integer = 6 ' Delay between each message (in seconds)
        If getshiftnetwait = False Then
            txtterm.Text = txtterm.Text & "User 'MF' is trying to connect from IP:174.384.23.45 for subject: 'Shiftnet' Allow connection? yes/no" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
            getshiftnetwait = True
        End If
        If getshiftnetstoryyes = True Then
            txtterm.ReadOnly = True
            Select Case shiftnetstorylinetiming
                Case 1
                    txtterm.Text = txtterm.Text & "MF: Thanks for accepting my connection." & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + delay
                    txtterm.Text = txtterm.Text & "MF: Hi, I'm Maureen Fenn. I run a website called 'Minimatch'" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (2 * delay)
                    txtterm.Text = txtterm.Text & "MF: Shiftnet is network browser designed to access the Shiftnet network, specially the 'main' subnetwork." & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (3 * delay)
                    txtterm.Text = txtterm.Text & "MF: It is a great way of finding information and applications for ShiftOS" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (4 * delay)
                    txtterm.Text = txtterm.Text & "MF: However, some people use it... Irresponsibly." & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (5 * delay)
                    txtterm.Text = txtterm.Text & "MF: I had quite a big argument with myself about giving it to you..." & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (6 * delay)
                    txtterm.Text = txtterm.Text & "MF: DevX was against the idea" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (7 * delay)
                    txtterm.Text = txtterm.Text & "MF: But my pro side won, I'm installing shiftnet for you right now" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (8 * delay)
                    txtterm.Text = txtterm.Text & "MF: If the website address starts with 'shiftnet.main' then you safe. Don't leave the main servers." & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (9 * delay)
                    txtterm.Text = txtterm.Text & "MF: All installed, Gotta run now but I'll contact you soon to see how your liking the Shiftnet. While I... work on something else" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                    ShiftOSDesktop.boughtshiftnet = True
                    ShiftOSDesktop.boughtshiftneticon = True
                    ShiftOSDesktop.boughtalshiftnet = True
                    ShiftOSDesktop.boughtdownloadmanager = True
                    ShiftOSDesktop.boughtinstaller = True
                    ShiftOSDesktop.setupdesktop()
                Case 1 + (10 * delay)
                    txtterm.Text = txtterm.Text & "MF: Make sure you check out shiftnet.main.minimatch/home.rnp. Bye" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                Case 1 + (11 * delay)
                    txtterm.Text = txtterm.Text & "IP:174.384.23.45 disconnected" & Environment.NewLine & ShiftOSDesktop.username & "@" & ShiftOSDesktop.osname & " $> "
                    storyline = ""
                    shiftnetstorylinetiming = 0
                    tmrstorylineupdate.Stop()
                    getshiftnetstoryyes = False
                    txtterm.ReadOnly = False
            End Select
            shiftnetstorylinetiming = shiftnetstorylinetiming + 1
        End If
    End Sub

    Public Sub WriteLine(text As String)
        txtterm.Text = txtterm.Text + vbNewLine + text
    End Sub
End Class