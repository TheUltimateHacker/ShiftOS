Public Class Name_Changer
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 300
    Public minimumsizeheight As Integer = 400

    Public savelines(200) As String
    Public loadlines(200) As String

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.NameChangerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        loadnames()
        loadicons()
        showboughtitems()

        ShiftOSDesktop.pnlpanelbuttonnamechanger.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonnamechanger, ShiftOSDesktop.tbnamechangericon, ShiftOSDesktop.tbnamechangertext, True) 'modify to proper name
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
            Me.Size = New Size(334, 644) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.namechangername 'Remember to change to name of program!!!!
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
            pnlicon.Image = ShiftOSDesktop.namechangericontitlebar  'Replace with the correct icon for the program.
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

    Public Sub loadnames()
        txtknowledgeinputname.Text = ShiftOSDesktop.knowledgeinputname
        txtshiftoriumname.Text = ShiftOSDesktop.shiftoriumname
        txtclockname.Text = ShiftOSDesktop.clockname
        txtshiftername.Text = ShiftOSDesktop.shiftername
        txtcolourpickername.Text = ShiftOSDesktop.colourpickername
        txtpongname.Text = ShiftOSDesktop.pongname
        txtfileskimmername.Text = ShiftOSDesktop.fileskimmername
        txtfileopenername.Text = ShiftOSDesktop.fileopenername
        txtfilesavername.Text = ShiftOSDesktop.filesavername
        txttextpadname.Text = ShiftOSDesktop.textpadname
        txtgraphicpickername.Text = ShiftOSDesktop.graphicpickername
        txtskinloadername.Text = ShiftOSDesktop.skinloadername
        txtartpadname.Text = ShiftOSDesktop.artpadname
        txtcalculatorname.Text = ShiftOSDesktop.calculatorname
        txtaudioplayername.Text = ShiftOSDesktop.audioplayername
        txtwebbrowsername.Text = ShiftOSDesktop.webbrowsername
        txtvideoplayername.Text = ShiftOSDesktop.videoplayername
        txtnamechanger.Text = ShiftOSDesktop.namechangername
        txticonmanager.Text = ShiftOSDesktop.iconmanagername
        txtterminalname.Text = ShiftOSDesktop.terminalname
        txtwallet.Text = ShiftOSDesktop.bitnotewalletname
        txtdigger.Text = ShiftOSDesktop.bitnotediggername
        txtskinshifter.Text = ShiftOSDesktop.skinshiftername
        txtshiftnet.Text = ShiftOSDesktop.shiftnetname
        txtdodge.Text = ShiftOSDesktop.dodgename
        txtdownload.Text = ShiftOSDesktop.downloadmanagername
        txtinstaller.Text = ShiftOSDesktop.installername
        txtsysinfo.Text = ShiftOSDesktop.sysinfoname
        txtfloodgate.Text = ShiftOSDesktop.floodgatename
        txtorcwrite.Text = ShiftOSDesktop.orcwritename
        txtmaze.Text = ShiftOSDesktop.mazename
        txtvirusscanner.Text = ShiftOSDesktop.virusscannername
    End Sub

    Public Sub loadicons()
        picknowledgeinputicon.BackgroundImage = ShiftOSDesktop.knowledgeinputicontitlebar
        picshiftoriumicon.BackgroundImage = ShiftOSDesktop.shiftoriumicontitlebar
        picclockicon.BackgroundImage = ShiftOSDesktop.clockicontitlebar
        picshiftericon.BackgroundImage = ShiftOSDesktop.shiftericontitlebar
        piccolourpickericon.BackgroundImage = ShiftOSDesktop.colourpickericontitlebar
        picpongicon.BackgroundImage = ShiftOSDesktop.pongicontitlebar
        picfileskimmericon.BackgroundImage = ShiftOSDesktop.fileskimmericontitlebar
        picfileopenericon.BackgroundImage = ShiftOSDesktop.fileopenericontitlebar
        picfilesavericon.BackgroundImage = ShiftOSDesktop.filesavericontitlebar
        pictextpadicon.BackgroundImage = ShiftOSDesktop.textpadicontitlebar
        picgraphicpickericon.BackgroundImage = ShiftOSDesktop.graphicpickericontitlebar
        picskinloadericon.BackgroundImage = ShiftOSDesktop.skinloadericontitlebar
        picartpadicon.BackgroundImage = ShiftOSDesktop.artpadicontitlebar
        piccalculatoricon.BackgroundImage = ShiftOSDesktop.calculatoricontitlebar
        picaudioplayericon.BackgroundImage = ShiftOSDesktop.audioplayericontitlebar
        picwebbrowsericon.BackgroundImage = ShiftOSDesktop.webbrowsericontitlebar
        picvideoplayericon.BackgroundImage = ShiftOSDesktop.videoplayericontitlebar
        picnamechangericon.BackgroundImage = ShiftOSDesktop.namechangericontitlebar
        piciconmanagericon.BackgroundImage = ShiftOSDesktop.iconmanagericontitlebar
        picterminalicon.BackgroundImage = ShiftOSDesktop.terminalicontitlebar
        picwallet.BackgroundImage = ShiftOSDesktop.bitnotewalleticontitlebar
        picdigger.BackgroundImage = ShiftOSDesktop.bitnotediggericontitlebar
        picskinshifter.BackgroundImage = ShiftOSDesktop.skinshiftericontitlebar
        picshiftnet.BackgroundImage = ShiftOSDesktop.shiftneticontitlebar
        picdodge.BackgroundImage = ShiftOSDesktop.dodgeicontitlebar
        picdownload.BackgroundImage = ShiftOSDesktop.downloadmanagericontitlebar
        picinstaller.BackgroundImage = ShiftOSDesktop.installericontitlebar
        picsysinfo.BackgroundImage = ShiftOSDesktop.sysinfoicontitlebar
        picfloodgate.BackgroundImage = ShiftOSDesktop.floodgateicontitlebar
        picorcwrite.BackgroundImage = ShiftOSDesktop.orcwriteicontitlebar
        picmaze.BackgroundImage = ShiftOSDesktop.mazeicontitlebar
        picvirusscanner.BackgroundImage = ShiftOSDesktop.virusscannericontitlebar
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        applychanges()
    End Sub

    Public Sub applychanges()
        ShiftOSDesktop.knowledgeinputname = txtknowledgeinputname.Text
        ShiftOSDesktop.shiftoriumname = txtshiftoriumname.Text
        ShiftOSDesktop.clockname = txtclockname.Text
        ShiftOSDesktop.shiftername = txtshiftername.Text
        ShiftOSDesktop.colourpickername = txtcolourpickername.Text
        ShiftOSDesktop.pongname = txtpongname.Text
        ShiftOSDesktop.fileskimmername = txtfileskimmername.Text
        ShiftOSDesktop.fileopenername = txtfileopenername.Text
        ShiftOSDesktop.filesavername = txtfilesavername.Text
        ShiftOSDesktop.textpadname = txttextpadname.Text
        ShiftOSDesktop.graphicpickername = txtgraphicpickername.Text
        ShiftOSDesktop.skinloadername = txtskinloadername.Text
        ShiftOSDesktop.artpadname = txtartpadname.Text
        ShiftOSDesktop.calculatorname = txtcalculatorname.Text
        ShiftOSDesktop.audioplayername = txtaudioplayername.Text
        ShiftOSDesktop.webbrowsername = txtwebbrowsername.Text
        ShiftOSDesktop.videoplayername = txtvideoplayername.Text
        ShiftOSDesktop.namechangername = txtnamechanger.Text
        ShiftOSDesktop.iconmanagername = txticonmanager.Text
        ShiftOSDesktop.terminalname = txtterminalname.Text
        ShiftOSDesktop.bitnotewalletname = txtwallet.Text
        ShiftOSDesktop.bitnotediggername = txtdigger.Text
        ShiftOSDesktop.skinshiftername = txtskinshifter.Text
        ShiftOSDesktop.shiftnetname = txtshiftnet.Text
        ShiftOSDesktop.dodgename = txtdodge.Text
        ShiftOSDesktop.downloadmanagername = txtdownload.Text
        ShiftOSDesktop.installername = txtinstaller.Text
        ShiftOSDesktop.sysinfoname = txtsysinfo.Text
        ShiftOSDesktop.floodgatename = txtfloodgate.Text
        ShiftOSDesktop.orcwritename = txtorcwrite.Text
        ShiftOSDesktop.mazename = txtmaze.Text
        ShiftOSDesktop.virusscannername = txtvirusscanner.Text

        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setupdesktop()
        If Icon_Manager.Visible = True Then Icon_Manager.loadsettings()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        savelines(0) = ShiftOSDesktop.artpadname
        savelines(1) = ShiftOSDesktop.audioplayername
        savelines(2) = ShiftOSDesktop.calculatorname
        savelines(3) = ShiftOSDesktop.clockname
        savelines(4) = ShiftOSDesktop.colourpickername
        savelines(5) = ShiftOSDesktop.fileopenername
        savelines(6) = ShiftOSDesktop.filesavername
        savelines(7) = ShiftOSDesktop.fileskimmername
        savelines(8) = ShiftOSDesktop.graphicpickername
        savelines(9) = ShiftOSDesktop.knowledgeinputname
        savelines(10) = ShiftOSDesktop.pongname
        savelines(11) = ShiftOSDesktop.shiftername
        savelines(12) = ShiftOSDesktop.shiftoriumname
        savelines(13) = ShiftOSDesktop.skinloadername
        savelines(14) = ShiftOSDesktop.terminalname
        savelines(15) = ShiftOSDesktop.textpadname
        savelines(16) = ShiftOSDesktop.videoplayername
        savelines(17) = ShiftOSDesktop.webbrowsername
        savelines(18) = ShiftOSDesktop.namechangername
        savelines(19) = ShiftOSDesktop.iconmanagername
        savelines(20) = ShiftOSDesktop.bitnotewalletname
        savelines(21) = ShiftOSDesktop.bitnotediggername
        savelines(22) = ShiftOSDesktop.skinshiftername
        savelines(23) = ShiftOSDesktop.shiftnetname
        savelines(24) = ShiftOSDesktop.dodgename
        savelines(25) = ShiftOSDesktop.downloadmanagername
        savelines(26) = ShiftOSDesktop.installername
        savelines(27) = ShiftOSDesktop.sysinfoname
        savelines(28) = ShiftOSDesktop.floodgatename
        savelines(29) = ShiftOSDesktop.orcwritename
        savelines(30) = ShiftOSDesktop.mazename
        savelines(31) = ShiftOSDesktop.virusscannername

        File_Saver.savingprogram = "namechanger"
        File_Saver.saveextention = ".nls"
        File_Saver.Show()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        File_Opener.Show()
        File_Opener.openingprogram = "namechanger"
        File_Opener.openextention = ".nls"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub

    Public Sub loadnamesfromfile()
        If loadlines(0) = "" Then  Else ShiftOSDesktop.artpadname = loadlines(0)
        If loadlines(1) = "" Then  Else ShiftOSDesktop.audioplayername = loadlines(1)
        If loadlines(2) = "" Then  Else ShiftOSDesktop.calculatorname = loadlines(2)
        If loadlines(3) = "" Then  Else ShiftOSDesktop.clockname = loadlines(3)
        If loadlines(4) = "" Then  Else ShiftOSDesktop.colourpickername = loadlines(4)
        If loadlines(5) = "" Then  Else ShiftOSDesktop.fileopenername = loadlines(5)
        If loadlines(6) = "" Then  Else ShiftOSDesktop.filesavername = loadlines(6)
        If loadlines(7) = "" Then  Else ShiftOSDesktop.fileskimmername = loadlines(7)
        If loadlines(8) = "" Then  Else ShiftOSDesktop.graphicpickername = loadlines(8)
        If loadlines(9) = "" Then  Else ShiftOSDesktop.knowledgeinputname = loadlines(9)
        If loadlines(10) = "" Then  Else ShiftOSDesktop.pongname = loadlines(10)
        If loadlines(11) = "" Then  Else ShiftOSDesktop.shiftername = loadlines(11)
        If loadlines(12) = "" Then  Else ShiftOSDesktop.shiftoriumname = loadlines(12)
        If loadlines(13) = "" Then  Else ShiftOSDesktop.skinloadername = loadlines(13)
        If loadlines(14) = "" Then  Else ShiftOSDesktop.terminalname = loadlines(14)
        If loadlines(15) = "" Then  Else ShiftOSDesktop.textpadname = loadlines(15)
        If loadlines(16) = "" Then  Else ShiftOSDesktop.videoplayername = loadlines(16)
        If loadlines(17) = "" Then  Else ShiftOSDesktop.webbrowsername = loadlines(17)
        If loadlines(18) = "" Then  Else ShiftOSDesktop.namechangername = loadlines(18)
        If loadlines(19) = "" Then  Else ShiftOSDesktop.iconmanagername = loadlines(19)
        If loadlines(20) = "" Then  Else ShiftOSDesktop.bitnotewalletname = loadlines(20)
        If loadlines(21) = "" Then  Else ShiftOSDesktop.bitnotediggername = loadlines(21)
        If loadlines(22) = "" Then  Else ShiftOSDesktop.skinshiftername = loadlines(22)
        If loadlines(23) = "" Then  Else ShiftOSDesktop.shiftnetname = loadlines(23)
        If loadlines(24) = "" Then  Else ShiftOSDesktop.dodgename = loadlines(24)
        If loadlines(25) = "" Then  Else ShiftOSDesktop.downloadmanagername = loadlines(25)
        If loadlines(26) = "" Then  Else ShiftOSDesktop.installername = loadlines(26)
        If loadlines(27) = "" Then  Else ShiftOSDesktop.sysinfoname = loadlines(27)
        If loadlines(28) = "" Then  Else ShiftOSDesktop.floodgatename = loadlines(28)
        If loadlines(29) = "" Then  Else ShiftOSDesktop.orcwritename = loadlines(29)
        If loadlines(30) = "" Then  Else ShiftOSDesktop.mazename = loadlines(30)
        If loadlines(31) = "" Then  Else ShiftOSDesktop.virusscannername = loadlines(31)
        loadnames()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setupdesktop()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ShiftOSDesktop.artpadname = "Artpad"
        ShiftOSDesktop.audioplayername = "Audio Player"
        ShiftOSDesktop.calculatorname = "Calculator"
        ShiftOSDesktop.clockname = "Clock"
        ShiftOSDesktop.colourpickername = "Colour Picker"
        ShiftOSDesktop.fileopenername = "File Opener"
        ShiftOSDesktop.filesavername = "File Saver"
        ShiftOSDesktop.fileskimmername = "File Skimmer"
        ShiftOSDesktop.graphicpickername = "Graphic Picker"
        ShiftOSDesktop.knowledgeinputname = "Knowledge Input"
        ShiftOSDesktop.pongname = "Pong"
        ShiftOSDesktop.shiftername = "Shifter"
        ShiftOSDesktop.shiftoriumname = "Shiftorium"
        ShiftOSDesktop.skinloadername = "Skin Loader"
        ShiftOSDesktop.terminalname = "Terminal"
        ShiftOSDesktop.textpadname = "TextPad"
        ShiftOSDesktop.videoplayername = "Video Player"
        ShiftOSDesktop.webbrowsername = "Web Browser"
        ShiftOSDesktop.namechangername = "Name Changer"
        ShiftOSDesktop.iconmanagername = "Icon Manager"
        ShiftOSDesktop.bitnotewalletname = "Bitnote Wallet"
        ShiftOSDesktop.bitnotediggername = "Bitnote Digger"
        ShiftOSDesktop.skinshiftername = "Skin Shifter"
        ShiftOSDesktop.shiftnetname = "Shiftnet"
        ShiftOSDesktop.downloadername = "Downloader"
        ShiftOSDesktop.dodgename = "Dodge"
        ShiftOSDesktop.downloadmanagername = "Download Manager"
        ShiftOSDesktop.installername = "Installer"
        ShiftOSDesktop.snakeyname = "Snakey"
        ShiftOSDesktop.sysinfoname = "System Information"
        ShiftOSDesktop.orcwritename = "OrcWrite"
        ShiftOSDesktop.floodgatename = "FloodGate Manager"
        ShiftOSDesktop.mazename = "Labyrinth"
        ShiftOSDesktop.virusscannername = "Virus Scanner"
        loadnames()
        loadicons()
        applychanges()
    End Sub

    Private Sub showboughtitems()
        If ShiftOSDesktop.boughtclock = True Then pnlclocksettings.Show()
        If ShiftOSDesktop.boughtshifter = True Then pnlshiftersettings.Show()
        If ShiftOSDesktop.boughtshifter = True Then pnlcolourpickersettings.Show()
        If ShiftOSDesktop.boughtpong = True Then pnlpongsettings.Show()
        If ShiftOSDesktop.boughtfileskimmer = True Then pnlfileskimmersettings.Show()
        If ShiftOSDesktop.boughtfileskimmer = True Then pnlfileopenersettings.Show()
        If ShiftOSDesktop.boughtfileskimmer = True Then pnlfilesaversettings.Show()
        If ShiftOSDesktop.boughttextpad = True Then pnltextpadsettings.Show()
        If ShiftOSDesktop.boughtskinning = True Then pnlgraphicpickersettings.Show()
        If ShiftOSDesktop.boughtskinloader = True Then pnlskinloadersettings.Show()
        If ShiftOSDesktop.boughtartpad = True Then pnlartpadsettings.Show()
        If ShiftOSDesktop.boughtcalculator = True Then pnlcalculatorsettings.Show()
        If ShiftOSDesktop.boughtaudioplayer = True Then pnlaudioplayersettings.Show()
        If ShiftOSDesktop.boughtwebbrowser = True Then pnlwebbrowsersettings.Show()
        If ShiftOSDesktop.boughtvideoplayer = True Then pnlvideoplayersettings.Show()
        If ShiftOSDesktop.boughtnamechanger = True Then pnlnamechangersettings.Show()
        If ShiftOSDesktop.boughticonmanager = True Then pnliconmanagersettings.Show()
        If ShiftOSDesktop.boughtbitnotewallet = True Then pnlwallet.Show()
        If ShiftOSDesktop.boughtbitnotedigger = True Then pnldigger.Show()
        If ShiftOSDesktop.boughtskinshifter = True Then pnlskinshifter.Show()
        If ShiftOSDesktop.boughtshiftnet = True Then pnlshiftnet.Show()
        If ShiftOSDesktop.boughtdownloadmanager = True Then pnldownload.Show()
        If ShiftOSDesktop.boughtdodge = True Then pnldodge.Show()
        If ShiftOSDesktop.boughtinstaller = True Then pnlinstaller.Show()
        If ShiftOSDesktop.installedsysinfo = True Then pnlsysinfo.Show()
        If ShiftOSDesktop.boughtorcwrite = True Then pnlorcwrite.Show()
        If ShiftOSDesktop.boughtfloodgate = True Then pnlfloodgate.Show()
        If ShiftOSDesktop.boughtmaze = True Then pnlmaze.Show()
        If ShiftOSDesktop.installedvirusscanner = True Then pnlvirusscanner.Show()
    End Sub
End Class