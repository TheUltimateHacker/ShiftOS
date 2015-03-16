Imports ShiftOS.Helper
Imports ShiftOS.Paths
Public Class infobox
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Public textinfo As String
    Public title As String
    Public state As String
    Public sendyesno As String
    Public txtString As String
    Public showTextBox As Boolean

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()

        txtmessage.Text = textinfo
        lbtitletext.Text = title

        If showTextBox Then
            txtuserinput.Visible = True
        End If
        ShiftOSDesktop.pnlpanelbuttoninfobox.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttoninfobox, ShiftOSDesktop.tbinfoboxicon, ShiftOSDesktop.tbinfoboxtext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1
        Try
            playSound(sounddir & "infobox.wav", AudioPlayMode.Background)
        Catch

        End Try
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
            Me.Size = New Size(371, 154) 'put the default size of your window here
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
        If ShiftOSDesktop.boughtinfoboxicon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.infoboxicontitlebar  'Replace with the correct icon for the program.
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

    Private Sub makeinfobox()
        txtmessage.Text = textinfo
        lbtitletext.Text = title
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If txtuserinput.Visible = True Then
            txtuserinput.Hide()
            lblintructtext.Hide()
            If state = "makingfolder" Then
                File_Skimmer.makefolder()
            ElseIf state = "makingdesktopfolder" Then
                ShiftOSDesktop.makefolder()
            ElseIf state = "generatingskin" Then
                Skins.saveskin("C:/ShiftOS/Home/Desktop" & " / " & txtuserinput.Text & ".skn")
                ShiftOSDesktop.refreshIcons()
                Me.Close()
            ElseIf state = "generatingdump" Then
                Dim sw As New IO.StreamWriter("C:/ShiftOS/Home/Desktop/" & txtuserinput.Text & ".txt")
                sw.WriteLine("### SHIFTOS SYSTEM INFORMATION DUMP ###")
                sw.WriteLine(" ")
                sw.WriteLine("ShiftOS Version: " & ShiftOSDesktop.ingameversion)
                sw.WriteLine("User Name: " & ShiftOSDesktop.username)
                Dim PrcName As String

                PrcName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", Nothing)
                sw.WriteLine("CPU: " & PrcName)
                sw.WriteLine("Random Access Memory (RAM): " & (String.Format("{0} Megabytes", System.Math.Round(My.Computer.Info.TotalPhysicalMemory / (1024 * 1024)), 2).ToString))
                sw.Close()
                Me.Close()
                ShiftOSDesktop.refreshIcons()
            ElseIf state = "newtextdocondesktop" Then
                Dim sw As New IO.StreamWriter("C:/ShiftOS/Home/Desktop/" & txtuserinput.Text & ".txt")
                sw.Write("[New Text Document]")
                sw.Close()
                Me.Close()
                ShiftOSDesktop.refreshIcons()
            ElseIf state = "generatingshortcut" Then
                ShiftOSDesktop.generateShortCut(txtuserinput.Text, txtString)
                ShiftOSDesktop.refreshIcons()
                Me.Close()
            Else
                txtString = txtuserinput.Text
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Public Sub showyesno()
        pnlyesno.Show()
    End Sub

    Private Sub btnyes_Click(sender As Object, e As EventArgs) Handles btnyes.Click
        Select Case sendyesno
            Case "textpad"
                TextPad.needtosave = False
                TextPad.Close()
                Me.Close()
            Case "textpadnew"
                TextPad.makenewdoc()
                Me.Close()
            Case "artpad"
                ArtPad.needtosave = False
                ArtPad.Close()
                Me.Close()
            Case "fileskimmertextpad"
                TextPad.txtuserinput.Text = My.Computer.FileSystem.ReadAllText(File_Skimmer.lbllocation.Text & "/" & File_Skimmer.lvfiles.SelectedItems(0).Text)
                TextPad.needtosave = False
                Me.Close()
            Case "fileopenertextpad"
                TextPad.txtuserinput.Text = My.Computer.FileSystem.ReadAllText(File_Opener.lbllocation.Text & "/" & File_Opener.lvfiles.SelectedItems(0).Text)
                TextPad.needtosave = False
                File_Opener.Close()
                Me.Close()
            Case "fileskimmerartpad"
                ArtPad.savelocation = File_Skimmer.lbllocation.Text & "/" & File_Skimmer.lvfiles.SelectedItems(0).Text
                ArtPad.openpic()
                ArtPad.needtosave = False
                Me.Close()
            Case "fileopenerartpad"
                ArtPad.savelocation = File_Skimmer.lbllocation.Text & "/" & File_Skimmer.lvfiles.SelectedItems(0).Text
                ArtPad.needtosave = False
                File_Opener.Close()
                Me.Close()
            Case "shiftnetdodge"
                startdownload("Dodge.stp", "shiftnet.main.minimatch/filetrans.dwnld?file=dodge.stp", 500) 'WHY???
                sendyesno = ""
                Me.Close()
            Case "shiftnetwebbrowser"
                startdownload("WebBrowser.stp", "shiftnet.main.appsacpe/filetrans.dwnld?file=WebBrowser.stp", 20000)
                sendyesno = ""
                Me.Close()
            Case "shiftnetaudioplayer"
                startdownload("Audioplayer.stp", "shiftnet.main.appsacpe/filetrans.dwnld?file=AudioPlayer.stp", 1500)
                sendyesno = ""
                Me.Close()
            Case "shiftnetvideoplayer"
                startdownload("VideoPlayer.stp", "shiftnet.main.appsacpe/filetrans.dwnld?file=VideoPlayer.stp", 2000)
                sendyesno = ""
                Me.Close()
            Case "shiftnetcalculator"
                startdownload("Calculator.stp", "shiftnet.main.appsacpe/filetrans.dwnld?file=Calculator.stp", 100)
                sendyesno = ""
                Me.Close()
            Case "shiftnetwallet"
                startdownload("BitnoteWallet.stp", "shiftnet.main.bitnote/filetrans.dwnld?file=BitnoteWallet.stp", 1000)
                sendyesno = ""
                Me.Close()
            Case "shiftnetdigger"
                startdownload("BitnoteDigger.stp", "shiftnet.main.bitnote/filetrans.dwnld?file=BitnoteDigger.stp", 1000)
                sendyesno = ""
                Me.Close()
            Case "shiftnetfg"
                startdownload("FloodGate.stp", "shiftnet.main.floodgate/filetrans.dwnld?file=FloodGate.stp", 25000)
                sendyesno = ""
                Me.Close()
            Case "shiftnetlinuxmintskn"
                startdownload("LinuxMint7.skn", "shiftnet.main.shiftomizer/filetrans.dwnld?file=LinuxMint7.skn", 3590)
                Me.Close()
            Case "shiftnetindustrialskn"
                startdownload("Industrial.skn", "shiftnet.main.shiftomizer/filetrans.dwnld?file=Industrial.skn", 3590)
                Me.Close()
            Case "shiftnetskinchanger"
                startdownload("SkinChanger.stp", "shiftnet.main.shiftomizer/filetrans.dwnld?file=SC", 3000)
                Me.Close()
            Case "shiftnetnamechanger"
                startdownload("NameChanger.stp", "shiftnet.main.shiftomizer/filetrans.dwnld?file=NC", 3000)
                Me.Close()
            Case "shiftneticonmanager"
                startdownload("IconManager.stp", "shiftnet.main.shiftomizer/filetrans.dwnld?file=IM", 3000)
                Me.Close()
            Case "shiftnetfloodgate"
                startdownload("FloodGate.stp", "shiftnet.pirateboat/filetrans.dwnld?file=floodgate", 5000)
                Me.Close()
            Case "shiftnetmaze"
                startdownload("Labyrinth.stp", "shiftnet.main.minimatch/filetrans.dwnld?file=maze", 5000)
                Me.Close()
            Case "shiftnetorcwrite"
                startdownload("OrcWrite.stp", "shiftnet.main.appscape/filetrans.dwnld?file=OW", 7000)
                Me.Close()
            Case "orcwritesave"
                OrcWrite.Show()
                OrcWrite.RichTextBox1.Rtf = state
                state = ""
                File_Saver.savingprogram = "orcwrite"
                File_Saver.saveextention = ".owd"
                File_Saver.Show()
                sendyesno = ""
                Me.Close()
        End Select
    End Sub

    Private Sub btnno_Click(sender As Object, e As EventArgs) Handles btnno.Click
        Select Case sendyesno
            Case "textpad"
                TextPad.showsavedialog()
                Me.Close()
            Case "textpadnew"
                TextPad.showsavedialog()
                Me.Close()
            Case "artpad"
                ArtPad.showsavedialog()
                Me.Close()
            Case "fileskimmertextpad"
                TextPad.showsavedialog()
                Me.Close()
            Case "fileopenertextpad"
                File_Opener.Close()
                Me.Close()
            Case "fileskimmerartpad"
                ArtPad.showsavedialog()
                Me.Close()
            Case "fileopenerartpad"
                ArtPad.showsavedialog()
                Me.Close()
            Case "orcwritesave"
                state = ""
                Me.Close()
            Case Else
                Me.Close()
        End Select
    End Sub

    Private Sub startdownload(ByVal name As String, ByVal source As String, ByVal size As Integer)
        If ShiftOSDesktop.boughtdownloadmanager = True Then
            Downloadmanager.Show()
            Downloadmanager.adddownload(name, source, size)
        Else
            title = "Program not found"
            textinfo = "The program 'Download Manager' cannot be found. Unable to download the requested file." '
            Me.Show()
        End If
    End Sub

    'Just loads the infobox and resizes it.
    Public Sub resizeAndLoad(x As Integer, y As Integer)
        Me.Show()
        Me.Size = New Size(x, y)
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
    End Sub

    Public Sub showinfo(ByVal titletxt As String, ByVal msg As String)
        title = titletxt
        textinfo = msg
        Me.Show()
    End Sub
End Class