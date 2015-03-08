Imports System.IO

Public Class VirusScanner
#Region "Template Code"
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0   'replace with minimum size
    Public minimumsizeheight As Integer = 0  'replace with minimum size

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.VirusScannerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        setupinfo()

        ShiftOSDesktop.pnlpanelbuttonvirusscanner.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonvirusscanner, ShiftOSDesktop.tbvirusscannericon, ShiftOSDesktop.tbvirusscannertext, True) 'modify to proper name
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
            Me.Size = New Size(345, 324) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.virusscannername 'Remember to change to name of program!!!!
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
        If ShiftOSDesktop.boughtvirusscannericon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(Skins.titleiconfromside, Skins.titleiconfromtop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.virusscannericontitlebar  'Replace with the correct icon for the program.
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

    'get directory sizes
    Private Overloads Function DirectorySize(ByVal sPath As String, ByVal bRecursive As Boolean) As Long
        Dim lngNumberOfDirectories As Long = 0
        Dim Size As Long = 0

        Try
            Dim fil As FileInfo
            Dim diDir As New DirectoryInfo(sPath)

            For Each fil In diDir.GetFiles()
                Size += fil.Length
            Next fil

            If bRecursive = True Then
                Dim diSubDir As DirectoryInfo
                For Each diSubDir In diDir.GetDirectories()
                    Size += DirectorySize(diSubDir.FullName, True)
                    lngNumberOfDirectories += 1
                Next

            End If

            Return Size

        Catch fex As System.IO.FileNotFoundException

            ' File not found. Take no action
            Return 0

        Catch ex As Exception
            ' Another error occurred
            Return 0

        End Try
    End Function

    Dim scantype As String
    Dim virusesfound As Integer = 0
    Dim zerofound As Boolean
    Dim trapfound As Boolean
    Dim beeperfound As Boolean
    Dim plaguefound As Boolean
    Dim virusesremoved As Integer

    Private Sub setupinfo()
        lblabout.Text = "Scanner Grade: " & ShiftOSDesktop.virusscannergrade & Environment.NewLine & Environment.NewLine
        If ShiftOSDesktop.virusscannergrade = 0 Then
            lblabout.Text = lblabout.Text & "Additional Info: Grade 0 Scanners are unable to remove viruses, they can only detect them. Please upgrade to a higher grade of Virus Scanner." & ShiftOSDesktop.virusscannergrade & Environment.NewLine & Environment.NewLine
        Else
            lblabout.Text = lblabout.Text & "Additional Info: Grade " & ShiftOSDesktop.virusscannergrade & " scanners can remove threat level " & ShiftOSDesktop.virusscannergrade & " viruses. Anything higher and the scanner will detect but be unable to remove." & ShiftOSDesktop.virusscannergrade & Environment.NewLine & Environment.NewLine
        End If
        lblabout.Text = lblabout.Text & "Copyright Info: Any downloading, uploading or sharing this application is strictly forbbiden. Failure to comply will result legal action."
    End Sub

    Private Sub btnfullscan_Click(sender As Object, e As EventArgs) Handles btnfullscan.Click
        Dim dirsize As Integer = DirectorySize(ShiftOSDesktop.ShiftOSPath, True)
        If dirsize > 10000 Then
            tmrprogress.Interval = (dirsize / 10000)
        Else
            tmrprogress.Interval = 1000
        End If
        tmrprogress.Start()
        scantype = "full"
        btnremoveviruses.Visible = False
    End Sub

    Private Sub btnhomescan_Click(sender As Object, e As EventArgs) Handles btnhomescan.Click
        Dim dirsize As Integer = DirectorySize(ShiftOSDesktop.ShiftOSPath & "Home", True)
        If dirsize > 10000 Then
            tmrprogress.Interval = (dirsize / 10000)
        Else
            tmrprogress.Interval = 1000
        End If
        tmrprogress.Start()
        scantype = "home"
        btnremoveviruses.Visible = False
    End Sub

    Private Sub btnsysscan_Click(sender As Object, e As EventArgs) Handles btnsysscan.Click
        Dim dirsize As Integer = DirectorySize(ShiftOSDesktop.ShiftOSPath & "Shiftum42", True)
        If dirsize > 10000 Then
            tmrprogress.Interval = (dirsize / 10000)
        Else
            tmrprogress.Interval = 1000
        End If
        tmrprogress.Start()
        scantype = "sys"
    End Sub

    Private Sub tmrprogress_Tick(sender As Object, e As EventArgs) Handles tmrprogress.Tick
        Select Case scantype
            Case "full"
                lblresults.Text = "Starting full scan..." & Environment.NewLine
                If ProgressBar.Value > 50 Then
                    If Viruses.zerogravity = True Then
                        lblresults.Text = lblresults.Text & "Found ZeroGravity.th" & Viruses.zerogravitythreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        zerofound = True
                    End If
                    If Viruses.mousetrap = True Then
                        lblresults.Text = lblresults.Text & "Found MouseTrap.th" & Viruses.mousetrapthreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        trapfound = True
                    End If
                    If Viruses.beeper = True Then
                        lblresults.Text = lblresults.Text & "Found Beeper.th" & Viruses.beeperthreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        beeperfound = True
                    End If
                    If Viruses.ThePlague = True Then
                        lblresults.Text = lblresults.Text & "Found ThePlague.th" & Viruses.theplaguethreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        plaguefound = True
                    End If
                End If
            Case "home"
                lblresults.Text = "Starting Home folder scan..." & Environment.NewLine
                If ProgressBar.Value > 50 Then
                    Dim chance As Integer = Math.Ceiling(Rnd() * 2)
                    If Viruses.zerogravity = True And chance = 1 Then
                        lblresults.Text = lblresults.Text & "Found ZeroGravity.th" & Viruses.zerogravitythreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        zerofound = True
                    End If
                    chance = Math.Ceiling(Rnd() * 2)
                    If Viruses.mousetrap = True And chance = 1 Then
                        lblresults.Text = lblresults.Text & "Found MouseTrap.th" & Viruses.mousetrapthreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        trapfound = True
                    End If
                    chance = Math.Ceiling(Rnd() * 2)
                    If Viruses.beeper = True And chance = 1 Then
                        lblresults.Text = lblresults.Text & "Found Beeper.th" & Viruses.beeperthreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        beeperfound = True
                    End If
                    chance = Math.Ceiling(Rnd() * 2)
                    If Viruses.ThePlague = True Then
                        lblresults.Text = lblresults.Text & "Found ThePlague.th" & Viruses.theplaguethreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        plaguefound = True
                    End If
                End If
            Case "sys"
                lblresults.Text = "Starting System files scan..." & Environment.NewLine
                If ProgressBar.Value > 50 Then
                    Dim chance As Integer = Math.Ceiling(Rnd() * 2)
                    If Viruses.zerogravity = True And chance = 1 Then
                        lblresults.Text = lblresults.Text & "Found ZeroGravity.th" & Viruses.zerogravitythreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        zerofound = True
                    End If
                    chance = Math.Ceiling(Rnd() * 2)
                    If Viruses.mousetrap = True And chance = 1 Then
                        lblresults.Text = lblresults.Text & "Found MouseTrap.th" & Viruses.mousetrapthreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        trapfound = True
                    End If
                    chance = Math.Ceiling(Rnd() * 2)
                    If Viruses.beeper = True And chance = 1 Then
                        lblresults.Text = lblresults.Text & "Found Beeper.th" & Viruses.beeperthreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        beeperfound = True
                    End If
                    chance = Math.Ceiling(Rnd() * 2)
                    If Viruses.ThePlague = True Then
                        lblresults.Text = lblresults.Text & "Found ThePlague.th" & Viruses.theplaguethreatlevel & Environment.NewLine
                        virusesfound = virusesfound + 1
                        plaguefound = True
                    End If
                End If
        End Select
        If ProgressBar.Value < 100 Then
            ProgressBar.Value = ProgressBar.Value + 10
        Else
            lblresults.Text = lblresults.Text & "Scan completed."
            ProgressBar.Value = 0
            tmrprogress.Stop()
            If virusesfound >= 1 Then
                If ShiftOSDesktop.virusscannergrade Then
                    btnremoveviruses.Visible = True
                Else
                    infobox.title = "Upgrade required"
                    infobox.textinfo = "Viruses scanners of grade 0 are not able to remove any viruses. Please upgrade to grade 1 or above."
                    infobox.Show()
                End If
            End If
        End If
    End Sub

    Private Sub btnremoveviruses_Click(sender As Object, e As EventArgs) Handles btnremoveviruses.Click
        lblresults.Text = ""
        If zerofound = True And Viruses.zerogravitythreatlevel <= ShiftOSDesktop.virusscannergrade Then Viruses.removezerovirus() Else If Viruses.zerogravitythreatlevel > ShiftOSDesktop.virusscannergrade Then lblresults.Text = lblresults.Text & "ERROR: ZeroGravity Threat level too great" & Environment.NewLine
        If trapfound = True And Viruses.mousetrapthreatlevel <= ShiftOSDesktop.virusscannergrade Then Viruses.removemousetrapvirus() Else If Viruses.mousetrapthreatlevel > ShiftOSDesktop.virusscannergrade Then lblresults.Text = lblresults.Text & "ERROR: MouseTrap Threat level too great" & Environment.NewLine
        If beeperfound = True And Viruses.beeperthreatlevel <= ShiftOSDesktop.virusscannergrade Then Viruses.removebeepervirus() Else If Viruses.beeperthreatlevel > ShiftOSDesktop.virusscannergrade Then lblresults.Text = lblresults.Text & "ERROR: Beeper Threat level too great" & Environment.NewLine
        If plaguefound = True And Viruses.theplaguethreatlevel <= ShiftOSDesktop.virusscannergrade Then Viruses.removetheplague() Else If Viruses.theplaguethreatlevel > ShiftOSDesktop.virusscannergrade Then lblresults.Text = lblresults.Text & "ERROR: ThePlague threat level too great" & Environment.NewLine
        lblresults.Text = lblresults.Text & "Complete... " & virusesremoved & " Viruses were removed"
        btnremoveviruses.Visible = False
    End Sub
End Class