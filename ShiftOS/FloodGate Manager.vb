Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class FloodGate_Manager
    Dim itemGood As Integer()
    Dim itemPrice As Decimal()
    Dim itemName As String()
    Dim itemDesc As String()
    Dim itemSize As Integer()
    Dim itemURL As String()
    Dim item As Integer
    Dim time As Integer
    Dim seeders As Integer
    Dim progpop As Integer
    Dim daysafterrelease As Integer


    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        FloodRegistry.registerItems()
        ShiftOSDesktop.pnlpanelbuttonfloodgate.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonfloodgate, ShiftOSDesktop.tbfloodgateicon, ShiftOSDesktop.tbfloodgatetext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1
        If ShiftOSDesktop.FloodGateManagerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        pnlSearch.Dock = DockStyle.Fill
        If (ShiftOSDesktop.installedfloodgatenow) Then

            dnloadtimer.Start()
            pnlPackages.BringToFront()
            pnlPackages.Dock = DockStyle.Fill
        End If

        Me.MinimumSize = New Size(minimumsizewidth, minimumsizeheight)

        shouldnotneedtoexist.Start()
    End Sub

#Region "Template Code"
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 300   'replace with minimum size
    Public minimumsizeheight As Integer = 200  'replace with minimum size

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
            Me.Size = New Size(851, 468) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.floodgatename 'Remember to change to name of program!!!!
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
            pnlicon.Image = ShiftOSDesktop.floodgateicontitlebar  'Replace with the correct icon for the program.
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
#Region "Add Items"
    Private Sub addItems(repl As Boolean)


        'See http://shiftos.net/topic1162.html for the updated tutorial







        If (repl) Then
            dnlBox.Items.Clear()
        End If
    End Sub
#End Region
#Region "Download Programs"
    Dim speed As Decimal
    Private Sub progDownload_Click(sender As Object, e As EventArgs) Handles progDownload.Click
        If (Not System.IO.Directory.Exists(ShiftOSDesktop.ShiftOSPath & "\Home\Downloads")) Then
            System.IO.Directory.CreateDirectory(ShiftOSDesktop.ShiftOSPath & "\Home\Downloads")
        End If
        Randomize()
        Dim value As Integer = CInt(Int(100 * Rnd()))
        If (value > itemGood(item)) Then
            'do progress delay thing
            '(use itemSize(item) to get file size for whoever wants to implement it)
            'make the download speed faster than download manager downloads
            Select Case progLabel.Text.ToLower
                'Case "program name all lowercase"
                '   code to install program
                Case "bitnote hack"
                    ShiftOSDesktop.bitnotebalance = ShiftOSDesktop.bitnotebalance + 5
                    Bitnote_Wallet.logtransaction(5, "ShifterHacker", "Check out my other ShiftOS hacks at shiftnet.shifterhacker/home.rnp")
                    Bitnote_Wallet.setupbitnotestats()
                Case Else
                    If seeders > 0 Then
                        lblstatusinfo.Text = "Connecting to " & seeders & " seeders"
                        speed = seeders * (Math.Ceiling(Rnd() * 10))
                        progress.MaxValue = itemSize(item)
                        tmrdwnld.Start()
                    Else
                        infobox.showinfo("No Seeders", "There are no seeders to complete the file transfer")
                    End If
                    'infobox.title = "FloodGate Manager - Error"
                    'infobox.textinfo = "Program Not Found: " & progLabel.Text & Environment.NewLine & "Make sure you have the correct address and there are enough seeders."
                    'infobox.Show()
            End Select
        Else
            Dim x As Integer = Math.Ceiling(Rnd() * 4)
            Select Case x
                Case 1
                    Viruses.zerogravity = True
                    Viruses.zerogravitythreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                    Viruses.setupzerovirus()
                Case 2
                    Viruses.mousetrap = True
                    Viruses.mousetrapthreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                    Viruses.setupmousetrapvirus()
                Case 3
                    Viruses.beeper = True
                    Viruses.beeperthreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                    Viruses.setupbeepervirus()
                Case Else
                    Viruses.ThePlague = True
                    Viruses.theplaguethreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                    Viruses.setuptheplague()
            End Select
            'Possible non-virus viruses:
            'Take away codepoints
            'Take away bitnotes
        End If
    End Sub
    Dim i As Integer
    Private Sub tmrdwnld_Tick(sender As Object, e As EventArgs) Handles tmrdwnld.Tick
        If i < progress.MaxValue Then
            progress.Value = i
            i = i + speed
            lblstatusinfo.Text = "Receiving " & speed & "kb/s from " & seeders & " seeders. File transferred " & progress.Value & "/" & progress.MaxValue & "kb"
        Else
            progress.Value = progress.MaxValue
            progress.Value = 0
            i = 0
            lblstatusinfo.Text = "Ready"
            successinfo(progLabel.Text) 'This both writes the file and show the success infobox message
            tmrdwnld.Stop()
        End If
    End Sub
    Private Sub successinfo(ByVal item As String)
        'WRITES FILE
        Dim sw As StreamWriter
        sw = New StreamWriter(ShiftOSDesktop.ShiftOSPath & "Shiftum42\Drivers\HDD.dri")
        sw.WriteLine(item)
        sw.Close()
        File_Crypt.EncryptFile(ShiftOSDesktop.ShiftOSPath + "Shiftum42\Drivers\HDD.dri", ShiftOSDesktop.ShiftOSPath & "\Home\Downloads\" & item & ".saa", ShiftOSDesktop.sSecretKey) 'saa = stand alone application
        'SHOWS SUCCESS INFO
        infobox.title = item & " Download successfully"
        infobox.textinfo = item & " has been successfully downloaded to your downloads folder (C:\ShiftOS\Home\Downloads)"
        infobox.Show()
    End Sub
#End Region
#Region "The code"
    Public Sub setup()
        ReDim itemGood(0 To 0)
        addItems(True)
    End Sub
    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        pnlSearch.BringToFront()
        dosize()
        dnlBox.View = View.List
    End Sub
    Public Sub addItem(item As String, chance As Double, author As String, desc As String, url As String, size As String, li As Boolean)
        ReDim Preserve itemGood(0 To itemGood.Length)
        ReDim Preserve itemURL(0 To itemGood.Length)
        ReDim Preserve itemName(0 To itemGood.Length)
        ReDim Preserve itemDesc(0 To itemGood.Length)
        ReDim Preserve itemSize(0 To itemGood.Length)
        If li Then dnlBox.Items.Add(item)
        itemName(itemGood.Length - 2) = item
        itemGood(itemGood.Length - 2) = chance
        itemSize(itemGood.Length - 2) = size
        itemDesc(itemGood.Length - 2) = "Submitted by: " & author & "\" & desc
        itemURL(itemGood.Length - 2) = url
    End Sub

    Private Sub dnlBox_click(sender As Object, e As EventArgs) Handles dnlBox.Click
        item = dnlBox.FocusedItem.Index
        dnl(dnlBox.FocusedItem.Text, item)
        'progLabel.Text = dnlBox.FocusedItem.Text
        'progDesc.Text = "URL: " & itemURL(item) & ControlChars.NewLine & itemDesc(item).Replace("\"c, ControlChars.NewLine)
        'progDownload.Text = "Download: " & CStr(itemSize(item)) & "kb"
        'pnlDownload.BringToFront()
        'pnlDownload.Dock = DockStyle.Fill
        'setupseeders()
        'updatestats(dnlBox.FocusedItem.Index)
    End Sub
    Private Sub dnl(name As String, item As String)
        progLabel.Text = name
        progDesc.Text = "URL: " & itemURL(item) & ControlChars.NewLine & itemDesc(item).Replace("\"c, ControlChars.NewLine)
        progDownload.Text = "Download: " & CStr(itemSize(item)) & "kb"
        pnlDownload.BringToFront()
        pnlDownload.Dock = DockStyle.Fill
        setupseeders()
        updatestats(item)
    End Sub
    Private Sub dosize()
        progDownload.Location = New Point(Me.Width - 193 - 7, 7)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlSearch.BringToFront()
        pnlSearch.Dock = DockStyle.Fill
    End Sub
    Public Sub download(url As String)
        Me.Show()
        Me.BringToFront()
        If itemURL.Contains(url) Then
            For i As Integer = 0 To itemURL.Length - 1
                If (itemURL(i) = url) Then
                    item = i
                    Exit For
                End If
            Next
            dnl(itemName(item), item)
            'progLabel.Text = itemName(item) & " (" & url & ")"
            'progDesc.Text = itemDesc(item).Replace("\", ControlChars.NewLine)
            'pnlDownload.BringToFront()
        End If
    End Sub
    Private Sub urlbox_Press(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles urlBox.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            download(urlBox.Text)
        End If
    End Sub

    Private Sub shouldnotneedtoexist_Tick(sender As Object, e As EventArgs) Handles shouldnotneedtoexist.Tick
        dosize()
    End Sub

    Private Sub updatestats(ByVal item As String)
        Select Case item
            Case "program1" 'Program name
                lblstatusinfo.Text = "Viewing flood: " & item & "  |  Flood Seeders: " & seeders
        End Select
    End Sub

    Private Sub progDesc_Click(sender As Object, e As EventArgs) Handles progDesc.Click

        If (progDesc.Text.Contains("ƒ")) Then
            Shiftnet.loadsite(progDesc.Text.Split("ƒ")(1))
        End If
    End Sub

    Private Sub dnloadtimer_Tick(sender As Object, e As EventArgs) Handles dnloadtimer.Tick
        time = time + 1
        If (ShiftOSDesktop.installedfloodgatenow) Then
            pnlPackages.BringToFront()
            pnlPackages.Dock = DockStyle.Fill
            pkgprogress.Value = time
            If (time = 100) Then
                ShiftOSDesktop.installedfloodgatenow = False
                dnloadtimer.Stop()
                time = 0
                pnlSearch.Dock = DockStyle.Fill
                pnlSearch.BringToFront()
            End If
        Else
            If (time > itemSize(item)) Then
                'do stuff
            End If
        End If
    End Sub

    Private Sub setupseeders()
        Select Case progLabel.Text.ToLower
            Case "dodge"
                progpop = 67
                Dim i() As String = Split(Date.Today, "/")
                daysafterrelease = i(0) - 6
            Case "Web browser"
                progpop = 94
                Dim i() As String = Split(Date.Today, "/")
                daysafterrelease = i(0) - 11
            Case "b1n0t3 h4ck"
                progpop = 69
                Dim i() As String = Split(Date.Today, "/")
                daysafterrelease = i(0) - 0
            Case "virus scanner"
                progpop = 56
                Dim i() As String = Split(Date.Today, "/")
                daysafterrelease = i(0) - 30
                'Case "program name"
                'How popular is the program scale of 1 - 100
                'Dim i() As String = Split(Date.Today, "/")
                'daysafterrelease = i(0) - release day(random constant)
            Case Else 'For anyone who forgets because I tried to move the entire process into FloodRegistry
                progpop = 99
                Dim i() As String = Split(Date.Today, "/")
                daysafterrelease = i(0) - 50
        End Select
        seeders = Math.Ceiling(Rnd() * (2 * progpop)) - daysafterrelease
        If seeders < 0 Then
            seeders = 0
        End If
    End Sub
#End Region

End Class