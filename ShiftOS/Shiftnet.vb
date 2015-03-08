Public Class Shiftnet


#Region "Template Code"
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 500   'replace with minimum size
    Public minimumsizeheight As Integer = 300  'replace with minimum size
    Public loadsitenow As Boolean = False

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.ShiftNetCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        If IO.File.Exists(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\History.lst") Then
            Dim sr As New IO.StreamReader(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\History.lst")
            Dim lineCount As Integer = System.Text.RegularExpressions.Regex.Split(sr.ReadToEnd(), Environment.NewLine).Length
            sr.Close()
            Dim hist() As String = IO.File.ReadAllLines(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\History.lst")
            Try
                For a As Integer = 0 To lineCount
                    lbhomehistoryhistory.Items.Add(hist(a))
                Next
            Catch ex As Exception
            End Try
        End If

        loadsite("home:shiftnet")
        'ShiftOSDesktop.setcolours()
        shiftomizerupdatesliders()

        ShiftOSDesktop.pnlpanelbuttonshiftnet.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonshiftnet, ShiftOSDesktop.tbshiftneticon, ShiftOSDesktop.tbshiftnettext, True) 'modify to proper name
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
            Me.Size = New Size(820, 600) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.shiftnetname 'Remember to change to name of program!!!!
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
            pnlicon.Location = New Point(Skins.titleiconfromside, Skins.titleiconfromtop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.shiftneticontitlebar  'Replace with the correct icon for the program.
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

        Dim histsave(lbhomehistoryhistory.Items.Count) As String
        Try
            For a As Integer = 0 To (lbhomehistoryhistory.Items.Count)
                histsave(a) = lbhomehistoryhistory.Items(a).Text
            Next
        Catch ex As Exception
        End Try
        If IO.Directory.Exists(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\") Then IO.File.WriteAllLines(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\History.lst", histsave) Else IO.Directory.CreateDirectory(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\") : IO.File.WriteAllLines(ShiftOSDesktop.ShiftOSPath & "SoftwareData\Shiftnet\History.lst", histsave)
    End Sub

    'end of general setup
#End Region

    Private Sub txtlocation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtlocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadsitenow = True
        End If
    End Sub

    Private Sub hideallsites()
        pnlmainsiteappscape.Hide()
        appscapehomepage.Hide()
        appscapeaudioplayerinfopage.Hide()
    End Sub

    Private Sub opensite(ByVal mainsite As Panel, ByVal page As Panel, ByVal site As String)
        hideallsites()
        mainsite.Show()
        mainsite.BringToFront()
        mainsite.Dock = DockStyle.Fill
        page.Show()
        page.BringToFront()
        page.Dock = DockStyle.Fill
        txtlocation.Clear()
        txtlocation.Text = site
        addToHistory(mainsite, page, site)
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        hideallsites()
        txtlocation.Text = ""
        opensite(pnlhome, pnlhomehome, "home:shiftnet")
    End Sub
#Region "Define Websites"
    Public Sub loadsite(url As String)



        Me.Show()
        Me.BringToFront()

        url = Replace$(url, vbCrLf, "")
        url = url.ToLower
        ShiftOSDesktop.logit("Shiftnet went to: " + url)
        Select Case url
            Case "shiftnet.main.appscape/home.rnp"
                opensite(pnlmainsiteappscape, appscapehomepage, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.appscape/audioplayerinfo.rnp"
                opensite(pnlmainsiteappscape, appscapeaudioplayerinfopage, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.appscape/videoplayerinfo.rnp"
                opensite(pnlmainsiteappscape, appscapevideoplayerinfopage, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.appscape/calculatorinfo.rnp"
                opensite(pnlmainsiteappscape, appscapecalculatorinfopage, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.appscape/webbrowserinfo.rnp"
                opensite(pnlmainsiteappscape, appscapewebbrowserinfopage, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.appscape/deposit.rnp"
                opensite(pnlmainsiteappscape, pnlappscapedeposit, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.appscape/orcwrite.rnp"
                opensite(pnlmainsiteappscape, pnlappscapeoprcwrite, url)
                setupappscapeaccountinfo()
            Case "shiftnet.main.minimatch/home.rnp"
                opensite(pnlmainsiteminimatch, pnlminimatchhomepage, url)
                minimatchinfosetup()
            Case "shiftnet.main.minimatch/dodge.rnp"
                opensite(pnlmainsiteminimatch, pnlminimatchdodgeinfopage, url)
                minimatchinfosetup()
                'opensite(pnl404, pnl404home, url)
            Case "shiftnet.main.minimatch/labyrinth.rnp"
                opensite(pnlmainsiteminimatch, pnlminimatchlabyrinth, "shiftnet.main.minimatch/labyrinth.rnp")
                minimatchinfosetup()
            Case "shiftnet.main.bitnote/home.rnp"
                opensite(pnlbitnotemainpage, pnlbitnotehome, url)
            Case "shiftnet.main.bitnote/wallet.rnp"
                opensite(pnlbitnotemainpage, pnlbitnotebuywallet, url)
            Case "shiftnet.main.bitnote/digger.rnp"
                opensite(pnlbitnotemainpage, pnlbitnotedigger, url)
            Case "shiftnet.main.bitnote/currencyexchange.rnp"
                opensite(pnlbitnotemainpage, pnlbitnotecurrencyexchange, url)
                updatecurrencyexchange()
            Case "shiftnet.pirateboat"
                loadsite("shiftnet.pirateboat/home.rnp")
            Case "shiftnet.pirateboat/home.rnp"
                FloodRegistry.registerItems()
                opensite(pnlpirateboat, pnlpirateboatmain, url)
            Case "shiftnet.main.floodnet/home.rnp"
                opensite(pnlshiftnet, pnlshiftnethome, url)
            Case "shiftnet.main.shiftnet/home.rnp"
                opensite(pnlshiftnet, pnlshiftnethome, url)
            Case "shiftnet.main.utilsweb/home.rnp"
                opensite(pnlutilsweb, pnlutilswebhome, url)
            Case "shiftnet.main.utilsweb/backuputility.rnp"
                opensite(pnlutilsweb, pnlutilswebbackuputility, url)
            Case "shiftnet.main.utilsweb/virusutil.rnp"
                opensite(pnlutilsweb, pnlutilswebvirusscan, url)
            Case "shiftnet.main.shiftomizer/home.rnp"
                opensite(pnlshiftomizer, pnlshiftomizerhome, url)
                lblshiftomizerpaymentsclear_Click()
            Case "shiftnet.main.shiftomizer/payment.rnp"
                opensite(pnlshiftomizer, pnlshiftomizerpayments, url)
                lblshiftomizerpaymentsclear_Click()
            Case "shiftnet.shifterhacker/home.rnp"
                opensite(pnlshifterhacker, pnlshifterhackerhome, url)
            Case "shiftnet.main.postspot/home.rnp"
                opensite(pnlpostspot, pnlpostspothome, url)
            Case "shiftnet.main.xenonh/home.rnp"
                opensite(pnlxenonh, pnlxenonhhome, url)
            Case "shiftnet.quickchat/home.rnp"
                opensite(pnlquickchat, pnlquickchathome, url)
                qcmain()
            Case "shiftnet.quickchat/user/xenonh.rnp"
                opensite(pnlquickchat, pnlquickchatoffline, url)
            Case "home:shiftnet"
                opensite(pnlhome, pnlhomehome, "home:shiftnet")
            Case "history:shiftnet"
                opensite(pnlhome, pnlhomehistory, "history:shiftnet")
            Case "download:shiftnet.main.floodgate/install.stp"
                infobox.showinfo("Shiftnet - Allow Download", "Would you like to download the file 'Floodgate.stp' from shiftnet.pirateboat/filetrans.dwnld?file=floodgate")
                infobox.showyesno()
                infobox.sendyesno = "shiftnetfloodgate"
            Case Else
                If (url.Contains("/")) And url.StartsWith("shiftnet.main.utilsweb") Or url.StartsWith("shiftnet.pirateboat") Or url.StartsWith("shiftnet.main.floodnet") Or (url.StartsWith("shiftnet.main.appscape") Or url.StartsWith("shiftnet.main.minimatch") Or url.StartsWith("shiftnet.main.bitnote") Or url.StartsWith("shiftnet.floodnet") Or url.StartsWith("shiftnet.main.shiftnet")) Then
                    opensite(pnl404, pnl404home, url)
                    Try
                        tb404homenotfound.Text = "The requested page /" & url.Split("/")(1) & " can not be found on our server. Make sure you typed it correctly"
                    Catch ex As Exception
                        tb404homenotfound.Text = "The requested page / can not be found on our server. Make sure you typed it correctly"
                    End Try
                Else
                    opensite(pnlnotfound, pnlnotfoundsite, url)
                    Try
                        tbnotfound.Text = "Shiftnet can not find the web server at " & url.Split("/")(0)
                    Catch ex As Exception
                        tbnotfound.Text = "Shiftnet can not find the web server at " & url
                    End Try
                End If
        End Select
    End Sub
#End Region

    Private Sub tmrloadsite_Tick(sender As Object, e As EventArgs) Handles tmrloadsite.Tick
        If loadsitenow = True Then
            loadsite(txtlocation.Text)
            loadsitenow = False
            btnhome.Focus()
        End If
    End Sub

#Region "Appscape Functions"
    'Appscape Website functions

    Public Sub setupappscapeaccountinfo()
        lbappscapehello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lbappscapeaudioplayerinfohello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lbappscapecalculatorinfohello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lbappscapevideoplayerinfohello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lbappscapepayinfohello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lbappscapewebbroswerinfohello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lblappscapeorcwritehellotext.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        txtappscapedepositeaddress.Text = ShiftOSDesktop.bitnoteaddressappscape
    End Sub

    Private Sub btnaudioplayerinfo_MouseEnter(sender As Object, e As EventArgs) Handles btnaudioplayerinfo.MouseEnter
        btnaudioplayerinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnaudioplayerinfo_MouseLeave(sender As Object, e As EventArgs) Handles btnaudioplayerinfo.MouseLeave
        btnaudioplayerinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnvideolayerinfo_MouseEnter(sender As Object, e As EventArgs) Handles btnvideoplayerinfo.MouseEnter
        btnvideoplayerinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnvideoplayerinfo_MouseLeave(sender As Object, e As EventArgs) Handles btnvideoplayerinfo.MouseLeave
        btnvideoplayerinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnwebbrowserinfo_MouseEnter(sender As Object, e As EventArgs) Handles btnwebbrowserinfo.MouseEnter
        btnwebbrowserinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnwebbrowserinfo_MouseLeave(sender As Object, e As EventArgs) Handles btnwebbrowserinfo.MouseLeave
        btnwebbrowserinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btncalculatorinfo_MouseEnter(sender As Object, e As EventArgs) Handles btncalculatorinfo.MouseEnter
        btncalculatorinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btncalculatorinfo_MouseLeave(sender As Object, e As EventArgs) Handles btncalculatorinfo.MouseLeave
        btncalculatorinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnmoresoftware1info_MouseEnter(sender As Object, e As EventArgs) Handles btnmoresoftware1info.MouseEnter
        btnmoresoftware1info.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnmoresoftware1info_MouseLeave(sender As Object, e As EventArgs) Handles btnmoresoftware1info.MouseLeave
        btnmoresoftware1info.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnmoresoftware2info_MouseEnter(sender As Object, e As EventArgs) Handles btnmoresoftware2info.MouseEnter
        btnmoresoftware2info.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnmoresoftware2info_MouseLeave(sender As Object, e As EventArgs) Handles btnmoresoftware2info.MouseLeave
        btnmoresoftware2info.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnbuyaudioplayer_MouseEnter(sender As Object, e As EventArgs) Handles btnbuyaudioplayer.MouseEnter
        btnbuyaudioplayer.BackgroundImage = My.Resources.appscapeaudioplayerpricepressed
    End Sub

    Private Sub btnbuyaudioplayer_MouseLeave(sender As Object, e As EventArgs) Handles btnbuyaudioplayer.MouseLeave
        btnbuyaudioplayer.BackgroundImage = My.Resources.appscapeaudioplayerprice
    End Sub

    Private Sub btnbuyvideoplayer_MouseEnter(sender As Object, e As EventArgs) Handles btnbuyvideoplayer.MouseEnter
        btnbuyvideoplayer.BackgroundImage = My.Resources.appscapevideoplayerpricepressed
    End Sub

    Private Sub btnbuyvideoplayer_MouseLeave(sender As Object, e As EventArgs) Handles btnbuyvideoplayer.MouseLeave
        btnbuyvideoplayer.BackgroundImage = My.Resources.appscapevideoplayerprice
    End Sub

    Private Sub btnbuywebbrowser_MouseEnter(sender As Object, e As EventArgs) Handles btnbuywebbrowser.MouseEnter
        btnbuywebbrowser.BackgroundImage = My.Resources.appscapewebbrowserpricepressed
    End Sub

    Private Sub btnbuywebbrowser_MouseLeave(sender As Object, e As EventArgs) Handles btnbuywebbrowser.MouseLeave
        btnbuywebbrowser.BackgroundImage = My.Resources.appscapewebbrowserprice
    End Sub

    Private Sub btnbuycalculator_MouseEnter(sender As Object, e As EventArgs) Handles btnbuycalculator.MouseEnter
        btnbuycalculator.BackgroundImage = My.Resources.appscapecalculatorpricepressed
    End Sub

    Private Sub btnbuycalculator_MouseLeave(sender As Object, e As EventArgs) Handles btnbuycalculator.MouseLeave
        btnbuycalculator.BackgroundImage = My.Resources.appscapecalculatorprice
    End Sub

    Private Sub btnbuymoresoftware1_MouseEnter(sender As Object, e As EventArgs) Handles btnbuyorcwrite.MouseEnter
        btnbuyorcwrite.BackgroundImage = My.Resources.appscapevideoplayerpricepressed
    End Sub

    Private Sub btnbuymoresoftware1_MouseLeave(sender As Object, e As EventArgs) Handles btnbuyorcwrite.MouseLeave
        btnbuyorcwrite.BackgroundImage = My.Resources.appscapevideoplayerprice
    End Sub

    Private Sub btnbuymoresoftware2_MouseEnter(sender As Object, e As EventArgs) Handles btnbuymoresoftware2.MouseEnter
        btnbuymoresoftware2.BackgroundImage = My.Resources.appscapeundefinedpricepressed
    End Sub

    Private Sub btnbuymoresoftware2_MouseLeave(sender As Object, e As EventArgs) Handles btnbuymoresoftware2.MouseLeave
        btnbuymoresoftware2.BackgroundImage = My.Resources.appscapeundefinedprice
    End Sub

    Private Sub btnaudioplayerinfoback_Click(sender As Object, e As EventArgs) Handles btnaudioplayerinfoback.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btnaudioplayerinfo_Click(sender As Object, e As EventArgs) Handles btnaudioplayerinfo.Click
        loadsite("shiftnet.main.appscape/audioplayerinfo.rnp")
    End Sub

    Private Sub btnvideoplayerinfoback_Click(sender As Object, e As EventArgs) Handles btnvideoplayerinfoback.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btnvideoplayerinfo_Click(sender As Object, e As EventArgs) Handles btnvideoplayerinfo.Click
        loadsite("shiftnet.main.appscape/videoplayerinfo.rnp")
    End Sub

    Private Sub btncalculatorinfoback_Click(sender As Object, e As EventArgs) Handles btncalculatorinfoback.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btncalculatorinfo_Click(sender As Object, e As EventArgs) Handles btncalculatorinfo.Click
        loadsite("shiftnet.main.appscape/calculatorinfo.rnp")
    End Sub

    Private Sub btnwebbrowserinfoback_Click(sender As Object, e As EventArgs) Handles btnwebbrowserinfoback.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btnwebbrowserinfo_Click(sender As Object, e As EventArgs) Handles btnwebbrowserinfo.Click
        loadsite("shiftnet.main.appscape/webbrowserinfo.rnp")
    End Sub

    Private Sub btnappscapedeposit_Click(sender As Object, e As EventArgs) Handles btnappscapedeposit.Click
        loadsite("shiftnet.main.appscape/deposit.rnp")
    End Sub

    Private Sub homepageorcwritebuyclicked() Handles btnbuyorcwrite.Click
        appscapebuy("orcwrite", 2.5, ShiftOSDesktop.boughtorcwrite)
    End Sub

    Private Sub btnappscapeorcwritedeposit_Paint(sender As Object, e As EventArgs) Handles btnappscapeorcwritedeposit.Click
        loadsite("shiftnet.main.appscape/deposit.rnp")
    End Sub

    Private Sub Panel21_Paint(sender As Object, e As EventArgs) Handles btnappscapeorcwriteback.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub Panel18_Paint(sender As Object, e As EventArgs) Handles btnappscapeorcwritebuy.Click
        appscapebuy("orcwrite", 2.5, ShiftOSDesktop.boughtorcwrite)
    End Sub

    Private Sub btnmoresoftware1info_Paint(sender As Object, e As EventArgs) Handles btnmoresoftware1info.Click
        loadsite("shiftnet.main.appscape/orcwrite.rnp")
    End Sub

    Private Sub appscapebuy(ByVal item As String, ByVal price As Decimal, ByVal bought As Boolean)
        If bought = False Then
            If price <= ShiftOSDesktop.bitnotebalanceappscape Then
                Select Case item
                    Case "webbrowser"
                        ShiftOSDesktop.boughtwebbrowser = True
                        infobox.title = "Shiftnet - Allow Download?"
                        infobox.textinfo = "Thanks you shopping with Appscape, " & price & " has been subtracted from your account." & Environment.NewLine & Environment.NewLine & "Would you like to download WebBrowser.stp using the Download Manager?"
                        infobox.sendyesno = "shiftnetwebbrowser"
                        infobox.showyesno()
                        infobox.Show()
                    Case "audioplayer"
                        ShiftOSDesktop.boughtaudioplayer = True
                        infobox.title = "Shiftnet - Allow Download?"
                        infobox.textinfo = "Thanks you shopping with Appscape, " & price & " has been subtracted from your account." & Environment.NewLine & Environment.NewLine & "Would you like to download AudioPlayer.stp using the Download Manager?"
                        infobox.sendyesno = "shiftnetaudioplayer"
                        infobox.showyesno()
                        infobox.Show()
                    Case "videoplayer"
                        ShiftOSDesktop.boughtvideoplayer = True
                        infobox.title = "Shiftnet - Allow Download?"
                        infobox.textinfo = "Thanks you shopping with Appscape, " & price & " has been subtracted from your account." & Environment.NewLine & Environment.NewLine & "Would you like to download VideoPlayer.stp using the Download Manager?"
                        infobox.sendyesno = "shiftnetvideoplayer"
                        infobox.showyesno()
                        infobox.Show()
                    Case "calculator"
                        ShiftOSDesktop.boughtcalculator = True
                        infobox.title = "Shiftnet - Allow Download?"
                        infobox.textinfo = "Thanks you shopping with Appscape, " & price & " has been subtracted from your account." & Environment.NewLine & Environment.NewLine & "Would you like to download Calculator.stp using the Download Manager?"
                        infobox.sendyesno = "shiftnetcalculator"
                        infobox.showyesno()
                        infobox.Show()
                    Case "orcwrite"
                        ShiftOSDesktop.boughtorcwrite = True
                        infobox.title = "Shiftnet - Allow Download?"
                        infobox.textinfo = "Thanks you shopping with Appscape, " & price & " has been subtracted from your account." & Environment.NewLine & Environment.NewLine & "Would you like to download OrcWrite.stp using the Download Manager?"
                        infobox.sendyesno = "shiftnetorcwrite"
                        infobox.showyesno()
                        infobox.Show()
                End Select
                ShiftOSDesktop.bitnotebalanceappscape = ShiftOSDesktop.bitnotebalanceappscape - price
            Else
                infobox.title = "Shiftnet - Message from webpage:"
                infobox.textinfo = "Error, insuficent funds. Please send more bitnotes to " & ShiftOSDesktop.bitnoteaddressappscape
                infobox.Show()
            End If
        Else
            Select Case item
                Case "webbrowser"
                    ShiftOSDesktop.boughtwebbrowser = True
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "You all ready own this app!" & Environment.NewLine & Environment.NewLine & "Would you like to download the stp package now?"
                    infobox.sendyesno = "shiftnetwebbrowser"
                    infobox.showyesno()
                    infobox.Show()
                Case "audioplayer"
                    ShiftOSDesktop.boughtaudioplayer = True
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "You all ready own this app!" & Environment.NewLine & Environment.NewLine & "Would you like to download the stp package now?"
                    infobox.sendyesno = "shiftnetaudioplayer"
                    infobox.showyesno()
                    infobox.Show()
                Case "videoplayer"
                    ShiftOSDesktop.boughtvideoplayer = True
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "You all ready own this app!" & Environment.NewLine & Environment.NewLine & "Would you like to download the stp package now?"
                    infobox.sendyesno = "shiftnetvideoplayer"
                    infobox.showyesno()
                    infobox.Show()
                Case "calculator"
                    ShiftOSDesktop.boughtcalculator = True
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "You all ready own this app!" & Environment.NewLine & Environment.NewLine & "Would you like to download the stp package now?"
                    infobox.sendyesno = "shiftnetcalculator"
                    infobox.showyesno()
                    infobox.Show()
                Case "orcwrite"
                    ShiftOSDesktop.boughtorcwrite = True
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "You all ready own this app!" & Environment.NewLine & Environment.NewLine & "Would you like to download the stp package now?"
                    infobox.sendyesno = "shiftnetorcwrite"
                    infobox.showyesno()
                    infobox.Show()
            End Select
        End If
    End Sub

    Private Sub btnbuyaudioplayer_Click(sender As Object, e As EventArgs) Handles btnbuyaudioplayer.Click
        appscapebuy("audioplayer", 1, ShiftOSDesktop.boughtaudioplayer)
    End Sub

    Private Sub btnbuywebbrowser_Click(sender As Object, e As EventArgs) Handles btnbuywebbrowser.Click
        appscapebuy("webbrowser", 5, ShiftOSDesktop.boughtwebbrowser)
    End Sub

    Private Sub btnbuyvideoplayer_Click(sender As Object, e As EventArgs) Handles btnbuyvideoplayer.Click
        appscapebuy("videoplayer", 2.5, ShiftOSDesktop.boughtvideoplayer)
    End Sub

    Private Sub btnbuycalculator_Click(sender As Object, e As EventArgs) Handles btnbuycalculator.Click
        appscapebuy("calculator", 0.2, ShiftOSDesktop.boughtcalculator)
    End Sub

    Private Sub btnaudioplayerinfobuy_Click(sender As Object, e As EventArgs) Handles btnaudioplayerinfobuy.Click
        appscapebuy("audioplayer", 1, ShiftOSDesktop.boughtaudioplayer)
    End Sub

    Private Sub btnwebbrowserinfobuy_Click(sender As Object, e As EventArgs) Handles btnwebbrowserinfobuy.Click
        appscapebuy("webbrowser", 5, ShiftOSDesktop.boughtwebbrowser)
    End Sub

    Private Sub btnvideoplayerinfobuy_Click(sender As Object, e As EventArgs) Handles btnvideoplayerinfobuy.Click
        appscapebuy("videoplayer", 2.5, ShiftOSDesktop.boughtvideoplayer)
    End Sub

    Private Sub btncalculatorinfobuy_Click(sender As Object, e As EventArgs) Handles btncalculatorinfobuy.Click
        appscapebuy("calculator", 0.2, ShiftOSDesktop.boughtcalculator)
    End Sub

    Private Sub btnappscapedepositeback_Click(sender As Object, e As EventArgs) Handles btnappscapedepositeback.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub appscapeaudioplayerinfodepositbtn_Click(sender As Object, e As EventArgs) Handles appscapeaudioplayerinfodepositbtn.Click
        loadsite("shiftnet.main.appscape/deposit.rnp")
    End Sub

    Private Sub appscapevideoplayerinfodepositbtn_Click(sender As Object, e As EventArgs) Handles appscapevideoplayerinfodepositbtn.Click
        loadsite("shiftnet.main.appscape/deposit.rnp")
    End Sub

    Private Sub appscapewebbrowserinfodepositbtn_Click(sender As Object, e As EventArgs) Handles appscapewebbrowserinfodepositbtn.Click
        loadsite("shiftnet.main.appscape/deposit.rnp")
    End Sub

    Private Sub appscapecalcinfodepositbtn_Click(sender As Object, e As EventArgs) Handles appscapecalcinfodepositbtn.Click
        loadsite("shiftnet.main.appscape/deposit.rnp")
    End Sub
#End Region

#Region "Minimatch Functions"

    'Minimatch variables
    Public minimatchbitnoteaddress As String = "PU4GisNT30UkOQBOkqcyWUhoW"
    Public minimatchdodgeprice As Decimal = 1.59
    Dim tpbitems As String()
    Dim tpburls As String()
    Dim minimatchitem As String


    'Minimatch functions

    Private Sub minimatchinfosetup()
        lblminimatchuserwelcome.Text = "Welcome " & ShiftOSDesktop.username & vbCrLf & vbCrLf & "Your balance is: " & Math.Round(ShiftOSDesktop.bitnotebalanceminimatch, 2) & " BTN"
        Label20.Text = "Welcome " & ShiftOSDesktop.username & vbCrLf & vbCrLf & "Your balance is: " & Math.Round(ShiftOSDesktop.bitnotebalanceminimatch, 2) & " BTN"
        lblminimatchdodgehow2buydetails.Text = "Dodge can be purchased using Bitnotes, to buy Dodge, simply send Bitnotes the minimatch website Bitnote address, puting your account in credit. You should see you balance in the top left hand corner and below." & vbCrLf & vbCrLf & "Your current balance is: " & ShiftOSDesktop.bitnotebalanceminimatch & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Below is the Minimatch bitnote address, to send bitnote to your account, simply copy and paste it to your bitnote wallet."
        txtminimatchbitnoteaddress.Text = minimatchbitnoteaddress
        lblminimatchmainpagewelcome.Text = "Welcome " & ShiftOSDesktop.username & vbCrLf & vbCrLf & "Your balance is: " & Math.Round(ShiftOSDesktop.bitnotebalanceminimatch, 2) & " BTN"
        btnminimatchdodgepagebuy.Text = minimatchdodgeprice & " BTN"
        bntminimatchdodgebuy.Text = minimatchdodgeprice & " BTN"
        lblminimatchlabyrinthbuyinstuct.Text = "Labyrinth can be purchased using Bitnotes, to buy Labyrinth, simply send Bitnotes the minimatch website Bitnote address, puting your account in credit. You should see you balance in the top left hand corner and below." & vbCrLf & vbCrLf & "Your current balance is: " & ShiftOSDesktop.bitnotebalanceminimatch & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Below is the Minimatch bitnote address, to send bitnote to your account, simply copy and paste it to your bitnote wallet."
        txtminimatchlabrinthaddress.Text = minimatchbitnoteaddress
        If ShiftOSDesktop.boughtdodge = True Then
            bntminimatchdodgebuy.Text = "Already Bought"
            btnminimatchdodgepagebuy.Text = "Already Bought"
        End If
        If ShiftOSDesktop.boughtmaze = True Then
            lblminimatchinfopagebuy.Text = "Already Bought"
            bntminimatchcomingsoonbuy.Text = "Already Bought"
        End If
    End Sub

    Private Sub minimatchbuy(ByVal item As String, ByVal price As Decimal, ByVal paid As Boolean)
        If price <= ShiftOSDesktop.bitnotebalanceminimatch Or paid = True Then
            Select Case item
                Case "dodge"
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "Would you like to download Dodge.stp using the Download Manager?"
                    infobox.sendyesno = "shiftnetdodge"
                    infobox.showyesno()
                    infobox.Show()
                Case "labyrinth"
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "Would you like to download Labyrinth.stp using the Download Manager?"
                    infobox.sendyesno = "shiftnetmaze"
                    infobox.showyesno()
                    infobox.Show()
            End Select
            If paid = False Then
                ShiftOSDesktop.bitnotebalanceminimatch = ShiftOSDesktop.bitnotebalanceminimatch - price
            End If
        Else
            infobox.title = "Shiftnet - Message from webpage:"
            infobox.textinfo = "Error, insufficient funds. Please send more bitnotes to " & minimatchbitnoteaddress
            infobox.Show()
        End If
    End Sub

    Private Sub bntminimatchdodgeinfo_Click(sender As Object, e As EventArgs) Handles bntminimatchdodgeinfo.Click
        opensite(pnlmainsiteminimatch, pnlminimatchdodgeinfopage, "shiftnet.main.minimatch/dodge.rnp") 'opens site(panel)
    End Sub

    Private Sub bntminimatchdodgepageback_Click(sender As Object, e As EventArgs) Handles bntminimatchdodgepageback.Click
        opensite(pnlmainsiteminimatch, pnlminimatchhomepage, "shiftnet.main.minimatch/home.rnp")
    End Sub

    Private Sub bntminimatchdodgepagebuy_Click(sender As Object, e As EventArgs) Handles btnminimatchdodgepagebuy.Click
        minimatchitem = "dodge"
        minimatchbuy(minimatchitem, minimatchdodgeprice, ShiftOSDesktop.boughtdodge)
    End Sub

    Private Sub bntminimatchdodgebuy_Click(sender As Object, e As EventArgs) Handles bntminimatchdodgebuy.Click
        minimatchitem = "dodge"
        minimatchbuy(minimatchitem, minimatchdodgeprice, ShiftOSDesktop.boughtdodge)
    End Sub

    Private Sub bntminimatchcomingsoonbuy_Click(sender As Object, e As EventArgs) Handles bntminimatchcomingsoonbuy.Click
        minimatchitem = "labyrinth"
        minimatchbuy(minimatchitem, 1, ShiftOSDesktop.boughtmaze)
    End Sub
    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
        opensite(pnlmainsiteminimatch, pnlminimatchhomepage, "shiftnet.main.minimatch/home.rnp")
    End Sub
    Private Sub bntminimatchcomingsooninfo_Click(sender As Object, e As EventArgs) Handles bntminimatchcomingsooninfo.Click
        opensite(pnlmainsiteminimatch, pnlminimatchlabyrinth, "shiftnet.main.minimatch/labyrinth.rnp")
    End Sub

    Private Sub lblminimatchinfopagebuy_Click(sender As Object, e As EventArgs) Handles lblminimatchinfopagebuy.Click
        minimatchitem = "labyrinth"
        minimatchbuy(minimatchitem, 1, ShiftOSDesktop.boughtmaze)
    End Sub
#End Region

#Region "Bitnote Functions"
    'Bitnote website functions

    Dim bitnoteexchangerate As Integer = (17 + (Math.Ceiling(Rnd() * 6)))

    Public Sub bitnotebuy(ByVal item As String, ByVal price As Decimal, ByVal paid As Boolean)
        If price <= ShiftOSDesktop.bitnotebalanceminimatch Or paid = True Then
            Select Case item
                Case "wallet"
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "Would you like to download BitnoteWallet.stp using the Download Manager?"
                    infobox.sendyesno = "shiftnetwallet"
                    infobox.showyesno()
                    infobox.Show()
                Case "digger"
                    infobox.title = "Shiftnet - Allow Download?"
                    infobox.textinfo = "Would you like to download BitnoteDigger.stp using the Download Manager?"
                    infobox.sendyesno = "shiftnetdigger"
                    infobox.showyesno()
                    infobox.Show()
            End Select
            If paid = False Then
                ShiftOSDesktop.bitnotebalanceminimatch = ShiftOSDesktop.bitnotebalanceminimatch - price
            End If
        Else
            infobox.title = "Shiftnet - Message from webpage:"
            infobox.textinfo = "Error, insufficient funds."
            infobox.Show()
        End If
    End Sub

    Private Sub updatecurrencyexchange()
        lblbitnotecurrencyexchangetodaysrate.Text = "Exchange rate for " & Date.Today & " - 1 BTN : " & bitnoteexchangerate & " CP"
        lblbitnotecurrencyexchangeprice.Text = "BTN for " & (txtbitnotecurrencyexchangebitnoteamout.Text * bitnoteexchangerate) & " CP"
    End Sub

    Private Sub txtbitnotecurrencyexchangebitnoteamout_TextChanged(sender As Object, e As EventArgs) Handles txtbitnotecurrencyexchangebitnoteamout.TextChanged
        If IsNumeric(txtbitnotecurrencyexchangebitnoteamout.Text) Then
            lblbitnotecurrencyexchangeprice.Text = "BTN for " & (txtbitnotecurrencyexchangebitnoteamout.Text * bitnoteexchangerate) & " CP"
        Else
            txtbitnotecurrencyexchangebitnoteamout.Text = 1
        End If
    End Sub

    Private Sub btnbitnotecurrencyexchangebuy_Click(sender As Object, e As EventArgs) Handles btnbitnotecurrencyexchangebuy.Click
        If ShiftOSDesktop.codepoints >= (txtbitnotecurrencyexchangebitnoteamout.Text * bitnoteexchangerate) Then
            ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints - (txtbitnotecurrencyexchangebitnoteamout.Text * bitnoteexchangerate)
            ShiftOSDesktop.bitnotebalance = ShiftOSDesktop.bitnotebalance + txtbitnotecurrencyexchangebitnoteamout.Text
            Bitnote_Wallet.logtransaction(txtbitnotecurrencyexchangebitnoteamout.Text, " Credit From ", "Bitnote Currency Exchnage")
            Bitnote_Wallet.setupbitnotestats()
            infobox.showinfo("Message from website:", "Your purchase has been successful!" & Environment.NewLine & Environment.NewLine & "You updated Bitnote balance is " & ShiftOSDesktop.bitnotebalance & " BTN. You have " & ShiftOSDesktop.codepoints & " CP remaining.")
        Else
            infobox.title = "Insuficent Funds"
            infobox.textinfo = "You do not currently have enough Code Points to complete this purchase. Please come back latter"
            infobox.Show()
        End If
    End Sub

    Private Sub lblbitnotehomewalletlink_Click(sender As Object, e As EventArgs) Handles lblbitnotehomewalletlink.Click
        loadsite("shiftnet.main.bitnote/wallet.rnp")
    End Sub

    Private Sub lblbitnotewalletpagefooterhomelink_Click(sender As Object, e As EventArgs) Handles lblbitnotewalletpagefooterhomelink.Click
        loadsite("shiftnet.main.bitnote/home.rnp")
    End Sub

    Private Sub lblbitnotewalletwalletdownloadlink_Click(sender As Object, e As EventArgs) Handles lblbitnotewalletwalletdownloadlink.Click
        loadsite("shiftnet.main.bitnote/wallet.rnp")
    End Sub

    Private Sub lblbitnotewalletdiggerdownloadlink_Click(sender As Object, e As EventArgs) Handles lblbitnotewalletdiggerdownloadlink.Click
        loadsite("shiftnet.main.bitnote/digger.rnp")
    End Sub

    Private Sub lblbitnotehomediggerdownloadlink_Click(sender As Object, e As EventArgs) Handles lblbitnotehomediggerlink.Click
        loadsite("shiftnet.main.bitnote/digger.rnp")
    End Sub

    Private Sub lblbitnotediggerfooterhomelink_Click(sender As Object, e As EventArgs) Handles lblbitnotediggerfooterhomelink.Click
        loadsite("shiftnet.main.bitnote/home.rnp")
    End Sub

    Private Sub lblbitnotediggerfooterwalletlink_Click(sender As Object, e As EventArgs) Handles lblbitnotediggerfooterwalletlink.Click
        loadsite("shiftnet.main.bitnote/wallet.rnp")
    End Sub

    Private Sub lblbitnotediggerfooterdiggerlink_Click(sender As Object, e As EventArgs) Handles lblbitnotediggerfooterdiggerlink.Click
        loadsite("shiftnet.main.bitnote/digger.rnp")
    End Sub

    Private Sub lblbitnotehomefootergetlink_Click(sender As Object, e As EventArgs) Handles lblbitnotehomefootergetlink.Click
        loadsite("shiftnet.main.bitnote/currencyexchange.rnp")
        updatecurrencyexchange()
    End Sub

    Private Sub lblbitnotewalletfootergetlink_Click(sender As Object, e As EventArgs) Handles lblbitnotewalletfootergetlink.Click
        loadsite("shiftnet.main.bitnote/currencyexchange.rnp")
        updatecurrencyexchange()
    End Sub

    Private Sub lblbitnotediggerfootergetlink_Click(sender As Object, e As EventArgs) Handles lblbitnotediggerfootergetlink.Click
        loadsite("shiftnet.main.bitnote/currencyexchange.rnp")
        updatecurrencyexchange()
    End Sub

    Private Sub lblbitnotecurrencyexchangefootergetlink_Click(sender As Object, e As EventArgs) Handles lblbitnotecurrencyexchangefootergetlink.Click
        loadsite("shiftnet.main.bitnote/currencyexchange.rnp")
        updatecurrencyexchange()
    End Sub

    Private Sub lblbitnotecurrencyexchangefooterhomelink_Click(sender As Object, e As EventArgs) Handles lblbitnotecurrencyexchangefooterhomelink.Click
        loadsite("shiftnet.main.bitnote/home.rnp")
    End Sub

    Private Sub lblbitnotecurrencyexchangefooterwalletlink_Click(sender As Object, e As EventArgs) Handles lblbitnotecurrencyexchangefooterwalletlink.Click
        loadsite("shiftnet.main.bitnote/wallet.rnp")
    End Sub

    Private Sub lblbitnotecurrencyexchangefooterdiggerlink_Click(sender As Object, e As EventArgs) Handles lblbitnotecurrencyexchangefooterdiggerlink.Click
        loadsite("shiftnet.main.bitnote/digger.rnp")
    End Sub

    Private Sub picbitnotewalletdownloadbtn_Click(sender As Object, e As EventArgs) Handles picbitnotewalletdownloadbtn.Click
        bitnotebuy("wallet", 0, True)
    End Sub

    ' Buy bitnote digger / upgrades
    Private Sub btnbitnotediggergrade1buy_Click(sender As Object, e As EventArgs) Handles btnbitnotediggergrade1buy.Click
        bitnotebuy("digger", 0, True)
        'Bitnote_Digger.updategrade(1, 0, "Surface Scratcher")
        Bitnote_Digger.updatestats()
    End Sub

    Private Sub btnbitnotediggergrade2buy_Click(sender As Object, e As EventArgs) Handles btnbitnotediggergrade2buy.Click
        Bitnote_Digger.updategrade(2, 5, "Sediment Mover")
        Bitnote_Digger.updatestats()
    End Sub

    Private Sub btnbitnotediggergrade3buy_Click(sender As Object, e As EventArgs) Handles btnbitnotediggergrade3buy.Click
        Bitnote_Digger.updategrade(3, 10, "Rock Crusher")
        Bitnote_Digger.updatestats()
    End Sub

    Private Sub btnbitnotediggergrade4buy_Click(sender As Object, e As EventArgs) Handles btnbitnotediggergrade4buy.Click
        Bitnote_Digger.updategrade(4, 20, "Massive Drill")
        Bitnote_Digger.updatestats()
    End Sub

    Private Sub btnbitnotediggergrade5buy_Click(sender As Object, e As EventArgs) Handles btnbitnotediggergrade5buy.Click
        Bitnote_Digger.updategrade(5, 35, "Kola")
        Bitnote_Digger.updatestats()
    End Sub

#End Region

#Region "FloodGate/Pirate Boat Functions"

    Private Sub tbdnlfloodgate_Click(sender As Object, e As EventArgs) Handles tbdnlfloodgate.Click
        loadsite("download:shiftnet.main.floodgate/install.stp")
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)
        loadsite("download:shiftnet.main.floodgate/install.stp")
    End Sub

    Private Sub tbpbfglink1_Click(sender As Object, e As EventArgs) Handles tbpbfglink1.Click
        FloodGate_Manager.download("shiftnet.pirate.pirateboat/floods/dodge")
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        FloodGate_Manager.download("shiftnet.pirate.pirateboat/floods/virusscanner")
    End Sub

    Public Sub tpb_addItem(name As String, url As String)
        ReDim Preserve tpbitems(0 To tpbitems.Length)
        ReDim Preserve tpburls(0 To tpbitems.Length)
        tpbitems(tpbitems.Length - 2) = name
        tpburls(tpbitems.Length - 2) = url
        tpbsearchresults.Items.Add(name)
        tpbsearchresults.View = View.List
    End Sub
    Public Sub tpbsetup()
        tpbsearchresults.Items.Clear()
        ReDim tpbitems(0 To 0)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles tpbsearch.TextChanged
        tpbsearchresults.Items.Clear()
        For Each name As String In tpbitems
            If (name = Nothing) Then
            Else
                If (tpbsearch.Text = "") Then
                    tpbsearchresults.Items.Add(name)
                Else
                    If (name.Contains(tpbsearch.Text)) Then
                        tpbsearchresults.Items.Add(name)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub tpbsearchresults_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tpbsearchresults.Click
        Try
            Dim item As Integer = tpbsearchresults.FocusedItem.Index
            Dim itemname As String = tpbsearchresults.FocusedItem.Name
            pnlpirateboatdownlaod.BringToFront()
            tpburlbox.Text = tpburls(item)
        Catch ex As Exception
            infobox.showinfo("RNP Error", "The remote network page 'home' failed to display the selected item")
        End Try
    End Sub

    Private Sub tpbfloodgate_Click(sender As Object, e As EventArgs) Handles tpbfloodgate.Click
        FloodGate_Manager.download(tpburlbox.Text)
    End Sub
    Private Sub tpbbackbtn_Click(sender As Object, e As EventArgs) Handles tpbbackbtn.Click
        pnlpirateboatmain.BringToFront()
    End Sub
#End Region

#Region "Home Page Functions"
    'Home page Functions
    Private Sub lblhomehomeappscapelink_Click(sender As Object, e As EventArgs) Handles lblhomehomeappscapelink.Click
        loadsite("shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub lblhomehomeminimatchlink_Click(sender As Object, e As EventArgs) Handles lblhomehomeminimatchlink.Click
        loadsite("shiftnet.main.minimatch/home.rnp")
    End Sub

    Private Sub lblhomehomebitnotelink_Click(sender As Object, e As EventArgs) Handles lblhomehomebitnotelink.Click
        loadsite("shiftnet.main.bitnote/home.rnp")
    End Sub

    Private Sub lblhomehomebackuplink_Click(sender As Object, e As EventArgs) Handles lblhomehomebackuplink.Click
        loadsite("shiftnet.main.shiftomizer/home.rnp")
    End Sub

    Private Sub lblhomehomehistorylink_Click(sender As Object, e As EventArgs) Handles lblhomehomehistorylink.Click
        loadsite("history:shiftnet")
    End Sub
    'History
    Private Sub addToHistory(ByVal mainsite As Panel, ByVal page As Panel, url As String)
        lbhomehistoryhistory.Items.Add(url)
        'Does not save yet
        lbhomehistoryhistory.View = View.List
    End Sub

    Private Sub lbhomehistoryhistory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbhomehistoryhistory.SelectedIndexChanged
        loadsite(lbhomehistoryhistory.FocusedItem.Text)
    End Sub
#End Region

#Region "UtilsWeb Functions"
    Private Sub utilswebbackuputil_Click(sender As Object, e As EventArgs) Handles utilswebbackuputil.Click
        loadsite("shiftnet.main.utilsweb/backuputility.rnp")
    End Sub

    Private Sub utilswebvirusscanner_Click(sender As Object, e As EventArgs) Handles utilswebvirusscanner.Click
        loadsite("shiftnet.main.utilsweb/virusutil.rnp")
    End Sub
#End Region

#Region "Shiftomizer Functions"

    Dim shiftomizerskinsliderimageindex As Integer = 0
    Dim shiftomizerboughtprogram(2) As Boolean
    Private Sub Label18_Click(sender As Object, e As EventArgs)
        ShiftDock.Show()
    End Sub

    Private Sub picshiftomizerhomeskinsliderright_Click(sender As Object, e As EventArgs) Handles picshiftomizerhomeskinsliderright.Click
        shiftomizerskinsliderimageindex = +1
        shiftomizerupdatesliders()
    End Sub

    Private Sub picshiftomizerhomeskinssliderleft_Click(sender As Object, e As EventArgs) Handles picshiftomizerhomeskinssliderleft.Click
        shiftomizerskinsliderimageindex = +-1
        shiftomizerupdatesliders()
    End Sub

    Private Sub shiftomizerupdatesliders()
        ReDim Preserve shiftomizerboughtprogram(2)
        Select Case shiftomizerskinsliderimageindex
            Case 0
                picshiftomizerhomeskinsliderimage.Image = My.Resources.shiftomizerlinuxmintskinpreview
                lblshiftomizerhomeskinname.Text = "Skins - Linux Mint 7 Skin"
                lblshiftomizerhomeskinsliderdescription.Text = "This skin was ripped from another operating system known as Linux Mint. Luckly, you can now expirance its theme directly from ShiftOS"
                lblshiftomizerhomeskinsliderdownload.Text = "Download Linux Mint 7 skin"
            Case 1
                picshiftomizerhomeskinsliderimage.Image = My.Resources.shiftomizerindustrialskinpreview
                lblshiftomizerhomeskinname.Text = "Skins - Industrial Skin"
                lblshiftomizerhomeskinsliderdescription.Text = "This skin is a remake of Ubuntu and Tails. It gives an industrial theme to you desktop."
                lblshiftomizerhomeskinsliderdownload.Text = "Download Industrial skin"
            Case Else
                shiftomizerskinsliderimageindex = 0
                shiftomizerupdatesliders()
        End Select
        Select Case shiftomizerappsliderimageindex
            Case 0
                picshiftomizerhomeappsliderimg.BackgroundImage = My.Resources.shiftomizerskinchangerpreview
                lblshiftomizerhomeappname.Text = "Programs - Skin Shifter"
                lblshiftomizerhomeappdescription.Text = "This program can changes your skin every few seconds, allowing you to have an ever changing desktop."
                If shiftomizerboughtprogram(0) Then lblshiftomizerhomeappdownload.Text = "Bought - Go to checkout" Else lblshiftomizerhomeappdownload.Text = "Buy Skin Shifter program"
            Case 1
                picshiftomizerhomeappsliderimg.BackgroundImage = My.Resources.shiftomizernamechangerpreview
                lblshiftomizerhomeappname.Text = "Programs - Name Changer"
                lblshiftomizerhomeappdescription.Text = "Don't like boring names like knowledge input, what to change it to 'EPiCquIZ4u' Well, now you can! Name chnager changes the name of ShiftOS programs."
                If shiftomizerboughtprogram(1) Then lblshiftomizerhomeappdownload.Text = "Bought - Go to checkout" Else lblshiftomizerhomeappdownload.Text = "Buy Name Changer program"
            Case 2
                picshiftomizerhomeappsliderimg.BackgroundImage = My.Resources.shiftomizericonpreview
                lblshiftomizerhomeappname.Text = "Programs - Icon Manager"
                lblshiftomizerhomeappdescription.Text = "Sick of have the same old black and white icons? With Icon Manager, you can change the icons to whatever you like. Make sure you swap them out for something a little more colourful!"
                If shiftomizerboughtprogram(2) Then lblshiftomizerhomeappdownload.Text = "Bought - Go to checkout" Else lblshiftomizerhomeappdownload.Text = "Buy Icon Manager program"
                'Case 3
                '    picshiftomizerhomeappsliderimg.BackgroundImage = My.Resources.shiftomizericonpreview
                '    lblshiftomizerhomeappname.Text = "Programs - Dock"
                '    lblshiftomizerhomeappdescription.Text = "Need a simple place to store your programs? With the dock, you can open a program right from the bottom of your screen!"
                '    lblshiftomizerhomeappdownload.Text = "Buy Dock program"
            Case Else
                shiftomizerappsliderimageindex = 0
                shiftomizerupdatesliders()
        End Select
        picshiftomizerhomeappsliderimg.BackgroundImageLayout = ImageLayout.Stretch
        picshiftomizerhomeappsliderimg.Image = Nothing
        lblshiftomizerhomeappdescription.Size = New Size(393, 50)
        lblshiftomizerhomeappdownload.Location = New Point(347, 512)
    End Sub

    Private Sub lblshiftomizerhomeskinsliderdownload_Click(sender As Object, e As EventArgs) Handles lblshiftomizerhomeskinsliderdownload.Click
        Select Case shiftomizerskinsliderimageindex
            Case 0
                infobox.title = "Shiftnet - allow download?"
                infobox.textinfo = "Would you like to download LinuxMint7.skn from shiftnet.main.shiftomizer/filetrans.dwnld?file=LinuxMint7.skn"
                infobox.showyesno()
                infobox.sendyesno = "shiftnetlinuxmintskn"
                infobox.Show()
            Case 1
                infobox.title = "Shiftnet - allow download?"
                infobox.textinfo = "Would you like to download Industrial.skn from shiftnet.main.shiftomizer/filetrans.dwnld?file=Industrial.skn"
                infobox.showyesno()
                infobox.sendyesno = "shiftnetindustrialskn"
                infobox.Show()
        End Select
    End Sub

    Dim shiftomizerappsliderimageindex As Integer
    Private Sub picshiftomizerhomeappsliderback_Click(sender As Object, e As EventArgs) Handles picshiftomizerhomeappsliderback.Click
        shiftomizerappsliderimageindex = shiftomizerappsliderimageindex - 1
        shiftomizerupdatesliders()
    End Sub

    Private Sub picshiftomizerhomeappslidernext_Click(sender As Object, e As EventArgs) Handles picshiftomizerhomeappslidernext.Click
        shiftomizerappsliderimageindex = shiftomizerappsliderimageindex + 1
        shiftomizerupdatesliders()
    End Sub

    Private Sub lblshiftomizerhomappdownload_Click(sender As Object, e As EventArgs) Handles lblshiftomizerhomeappdownload.Click
        ReDim Preserve shiftomizerboughtprogram(2)
        Select Case lblshiftomizerhomeappdownload.Text
            Case "Buy Skin Shifter program"
                makeshiftomizerpayment(2, "Skin Changer")
                lblshiftomizerhomeappdownload.Text = "Bought - Go to checkout"
                shiftomizerboughtprogram(0) = True
            Case "Buy Name Changer program"
                makeshiftomizerpayment(1, "Name Changer")
                lblshiftomizerhomeappdownload.Text = "Bought - Go to checkout"
                shiftomizerboughtprogram(1) = True
            Case "Buy Icon Manager program"
                makeshiftomizerpayment(1.5, "Icon Manager")
                lblshiftomizerhomeappdownload.Text = "Bought - Go to checkout"
                shiftomizerboughtprogram(2) = True
            Case "Bought - Go to checkout"
                opensite(pnlshiftomizer, pnlshiftomizerpayments, "shiftnet.main.shiftomizer/payment.rnp")
        End Select
    End Sub

    Dim shiftomizerpaymenttotal As Decimal
    Dim shiftomizerpaymentitemprice(10) As String
    Dim shiftomizerpaymentname(10) As String
    Dim shiftomizerpaymentitemnumber As Integer = -1
    Public shiftomizeractivepayment As Boolean = False

    Private Sub makeshiftomizerpayment(ByVal price As Decimal, ByVal name As String)
        ReDim Preserve shiftomizerpaymentname(9)
        ReDim Preserve shiftomizerpaymentitemprice(9)
        shiftomizeractivepayment = True
        shiftomizerpaymentitemnumber = shiftomizerpaymentitemnumber + 1
        shiftomizerpaymentname(shiftomizerpaymentitemnumber) = name
        shiftomizerpaymentitemprice(shiftomizerpaymentitemnumber) = price
        shiftomizerpaymenttotal = shiftomizerpaymenttotal + shiftomizerpaymentitemprice(shiftomizerpaymentitemnumber)
        lblshiftomizerpaymentorder.Text = "Order details" & Environment.NewLine & Environment.NewLine & shiftomizerpaymentname(0) & "   " & shiftomizerpaymentitemprice(0) & Environment.NewLine & shiftomizerpaymentname(1) & "   " & shiftomizerpaymentitemprice(1) & Environment.NewLine & shiftomizerpaymentname(2) & "   " & shiftomizerpaymentitemprice(2) & Environment.NewLine & shiftomizerpaymentname(3) & "   " & shiftomizerpaymentitemprice(3) & Environment.NewLine & shiftomizerpaymentname(4) & "   " & shiftomizerpaymentitemprice(4) & Environment.NewLine & shiftomizerpaymentname(5) & "   " & shiftomizerpaymentitemprice(5) & Environment.NewLine & shiftomizerpaymentname(6) & "   " & shiftomizerpaymentitemprice(6) & Environment.NewLine & shiftomizerpaymentname(7) & "   " & shiftomizerpaymentitemprice(7) & Environment.NewLine & shiftomizerpaymentname(8) & "   " & shiftomizerpaymentitemprice(8) & Environment.NewLine & shiftomizerpaymentname(9) & "   " & shiftomizerpaymentitemprice(9) & Environment.NewLine & Environment.NewLine & "Total Cost: " & shiftomizerpaymenttotal
        lblshiftomizerpaymentinstruct.Text = "Complete payment by sending " & shiftomizerpaymenttotal & " Bitnotes to " & ShiftOSDesktop.bitnoteaddressshiftomizer & Environment.NewLine & Environment.NewLine & "We do not give change, overpayment will be counted as a tip towards the developers." & Environment.NewLine & Environment.NewLine & "Once we have recived " & shiftomizerpaymenttotal & " bitnotes and verified the senders ip as yours, a download link will appear on screen."
        'opensite(pnlshiftomizer, pnlshiftomizerpayments, "shiftnet.main.shiftomizer/payment.rnp")
    End Sub

    Dim i As Integer
    Public Sub completeshiftomizerpayment(ByVal credit As Decimal)
        If credit >= shiftomizerpaymenttotal Then
            shiftomizeractivepayment = False
            If Not infobox.Visible Then
                Select Case shiftomizerpaymentname(i)
                    Case "Skin Changer"
                        infobox.title = "Shiftnet - allow download?"
                        infobox.textinfo = "Would you like to download SkinChnager.skn from shiftnet.main.shiftomizer/filetrans.dwnld?file=SC.skn"
                        infobox.showyesno()
                        infobox.sendyesno = "shiftnetskinchanger"
                        infobox.Show()
                    Case "Name Changer"
                        infobox.title = "Shiftnet - allow download?"
                        infobox.textinfo = "Would you like to download NameChanger.stp from shiftnet.main.shiftomizer/filetrans.dwnld?file=NC"
                        infobox.showyesno()
                        infobox.sendyesno = "shiftnetnamechanger"
                        infobox.Show()
                    Case "Icon Manager"
                        infobox.title = "Shiftnet - allow download?"
                        infobox.textinfo = "Would you like to download IconManager.stp from shiftnet.main.shiftomizer/filetrans.dwnld?file=IM"
                        infobox.showyesno()
                        infobox.sendyesno = "shiftneticonmanager"
                        infobox.Show()
                End Select
                If i = 0 Then tmrshiftomizerwaitinglist.Start()
                i = i + 1
            End If
        End If
    End Sub

    Private Sub tmrshiftomizerwaitinglist_Tick(sender As Object, e As EventArgs) Handles tmrshiftomizerwaitinglist.Tick
        If i = 11 Then
            tmrshiftomizerwaitinglist.Stop()
        Else
            completeshiftomizerpayment(shiftomizerpaymenttotal)
        End If
    End Sub

    Private Sub btnshiftomizerhomecheckout_Click(sender As Object, e As EventArgs) Handles btnshiftomizerhomecheckout.Click
        opensite(pnlshiftomizer, pnlshiftomizerpayments, "shiftnet.main.shiftomizer/payment.rnp")
    End Sub

    Private Sub lblshiftomizerpaymentsback_Click(sender As Object, e As EventArgs) Handles lblshiftomizerpaymentsback.Click
        opensite(pnlshiftomizer, pnlshiftomizerhome, "shiftnet.main.shiftomizer/home.rnp")
    End Sub

    Private Sub lblshiftomizerpaymentsclear_Click() Handles lblshiftomizerpaymentsclear.Click
        shiftomizeractivepayment = False
        shiftomizerpaymentitemnumber = 0
        shiftomizerpaymentname = Nothing
        shiftomizerpaymentitemprice = Nothing
        shiftomizerpaymenttotal = 0
        shiftomizerboughtprogram = Nothing
        shiftomizerupdatesliders()
        lblshiftomizerpaymentorder.Text = "order details" & Environment.NewLine & Environment.NewLine & "Not Items in cart." & Environment.NewLine & "Total Cost: " & shiftomizerpaymenttotal
        lblshiftomizerpaymentinstruct.Text = "Complete payment by sending " & shiftomizerpaymenttotal & " Bitnotes to " & ShiftOSDesktop.bitnoteaddressshiftomizer & Environment.NewLine & Environment.NewLine & "We do not give change, overpayment will be counted as a tip towards the developers." & Environment.NewLine & Environment.NewLine & "Once we have recived " & shiftomizerpaymenttotal & " bitnotes and verified the senders ip as yours, a download link will appear on screen."
    End Sub

#End Region

#Region "ShifterHacker Functions"
    Private Sub tbshifterhackerhomefloodgatead_Click(sender As Object, e As EventArgs) Handles tbshifterhackerhomefloodgatead.Click
        loadsite("download:shiftnet.main.floodgate/install.stp")
    End Sub

    Private Sub tbshifterhackerhomepostspotwatermark_Click(sender As Object, e As EventArgs) Handles tbshifterhackerhomepostspotwatermark.Click
        loadsite("shiftnet.main.postspot/home.rnp")
    End Sub
    Private Sub tbxenonhurl_Click(sender As Object, e As EventArgs) Handles tbxenonhurl.Click
        loadsite("shiftnet.main.xenonh/home.rnp")
    End Sub

    Private Sub tbshifterhackerhomefloodgatelink1_Click(sender As Object, e As EventArgs) Handles tbshifterhackerhomefloodgatelink1.Click
        FloodGate_Manager.download("shiftnet.shifterhacker/hacks/codepointhack.flood")
    End Sub
#End Region

#Region "XenonH Functions"
    Private Sub tbxenonhquickchat_Click(sender As Object, e As EventArgs) Handles tbxenonhquickchat.Click
        loadsite("shiftnet.quickchat/user/xenonh.rnp")
    End Sub
#End Region

#Region "QuickChat Functions"
    Private Sub qchome_Click(sender As Object, e As EventArgs) Handles qchome.Click
        loadsite("shiftnet.quickchat/user/xenonh.rnp")
    End Sub

    Private Sub qchomebtn_Click(sender As Object, e As EventArgs) Handles tbqchomebtn.Click
        loadsite("shiftnet.quickchat/home.rnp")
    End Sub

    Private Sub qcmain()
        qctext.Start()
        For Each story As String In QuickChatStory.qcmain
            tbqcchat.Text = tbqcchat.Text & ControlChars.NewLine & story
            tbqcchat.Select(tbqcchat.TextLength, 0)
            tbqcchat.ScrollToCaret()
        Next
    End Sub

    Private Sub qctext_Tick(sender As Object, e As EventArgs) Handles qctext.Tick
        QuickChatStory.i = QuickChatStory.i + 1
        qctext.Stop()

    End Sub
#End Region

#Region "PostSpot Functions"
    Private Sub tbpostspothomeshifterhackerlink_Click(sender As Object, e As EventArgs) Handles tbpostspothomeshifterhackerlink.Click
        loadsite("shiftnet.shifterhacker/home.rnp")
    End Sub
#End Region




    Private Sub homepageorcwritebuyclicked(sender As Object, e As EventArgs) Handles btnbuyorcwrite.Click

    End Sub
End Class