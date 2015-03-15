Public Class Icon_Manager
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 400   'replace with minimum size
    Public minimumsizeheight As Integer = 500  'replace with minimum size
    Public ShiftOSPath As String = "C:\ShiftOS"

    Public openedfilelocation As String
    Public icontochange As Object
    Public over64 As Boolean = False
    Public needtosetupdesktop As Boolean = False
    Public savelines(50) As String
    Public unsavedchanges As Boolean = False

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        loadsettings()
        Me.Size = New Size(400, 500)
        If ShiftOSDesktop.IconManagerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttoniconmanager.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttoniconmanager, ShiftOSDesktop.tbiconmanagericon, ShiftOSDesktop.tbiconmanagertext, True) 'modify to proper name
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

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = Skins.borderwidth
        pgright.Width = Skins.borderwidth
        pgbottom.Height = Skins.borderwidth
        titlebar.Height = Skins.titlebarheight

        If justopened = True Then
            Me.Size = New Size(400, 500) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
            Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
            oldbordersize = Skins.borderwidth
            oldtitlebarheight = Skins.titlebarheight
            justopened = False
        Else
            Me.Size = New Size((Me.Size.Width - (2 * oldbordersize)) + (2 * Skins.borderwidth), (Me.Size.Width - oldbordersize - oldtitlebarheight) + Skins.borderwidth + Skins.titlebarheight)
            oldbordersize = Skins.borderwidth
            oldtitlebarheight = Skins.titlebarheight
            rolldownsize = Me.Height
            If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
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
            lbtitletext.Text = ShiftOSDesktop.iconmanagername 'Remember to change to name of program!!!!
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
            pnlicon.Image = ShiftOSDesktop.iconmanagericontitlebar  'Replace with the correct icon for the program.
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

    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        If ret.Width > 64 Then over64 = True
        Return ret
    End Function

    Public Sub loadsettings()
        txttitlebariconsize.Text = ShiftOSDesktop.panelbuttoniconsize
        txtpanelbuttoniconsize.Text = ShiftOSDesktop.panelbuttoniconsize
        txtlaunchericonsize.Text = ShiftOSDesktop.launchericonsize

        pnltitlebarknowledgeinputicon.BackgroundImage = ShiftOSDesktop.knowledgeinputicontitlebar.Clone
        pnlpanelbuttonknowledgeinputicon.BackgroundImage = ShiftOSDesktop.knowledgeinputiconpanelbutton.Clone
        pnllauncherknowledgeinputicon.BackgroundImage = ShiftOSDesktop.knowledgeinputiconlauncher.Clone

        pnltitlebarshiftoriumicon.BackgroundImage = ShiftOSDesktop.shiftoriumicontitlebar.Clone
        pnlpanelbuttonshiftoriumicon.BackgroundImage = ShiftOSDesktop.shiftoriumiconpanelbutton.Clone
        pnllaunchershiftoriumicon.BackgroundImage = ShiftOSDesktop.shiftoriumiconlauncher.Clone

        pnltitlebarclockicon.BackgroundImage = ShiftOSDesktop.clockicontitlebar.Clone
        pnlpanelbuttonclockicon.BackgroundImage = ShiftOSDesktop.clockiconpanelbutton.Clone
        pnllauncherclockicon.BackgroundImage = ShiftOSDesktop.clockiconlauncher.Clone

        pnltitlebarshiftericon.BackgroundImage = ShiftOSDesktop.shiftericontitlebar.Clone
        pnlpanelbuttonshiftericon.BackgroundImage = ShiftOSDesktop.shiftericonpanelbutton.Clone
        pnllaunchershiftericon.BackgroundImage = ShiftOSDesktop.shiftericonlauncher.Clone

        pnltitlebarcolourpickericon.BackgroundImage = ShiftOSDesktop.colourpickericontitlebar.Clone
        pnlpanelbuttoncolourpickericon.BackgroundImage = ShiftOSDesktop.colourpickericonpanelbutton.Clone
        pnllaunchercolourpickericon.BackgroundImage = ShiftOSDesktop.colourpickericonlauncher.Clone

        pnltitlebarinfoboxicon.BackgroundImage = ShiftOSDesktop.infoboxicontitlebar.Clone
        pnlpanelbuttoninfoboxicon.BackgroundImage = ShiftOSDesktop.infoboxiconpanelbutton.Clone
        pnllauncherinfoboxicon.BackgroundImage = ShiftOSDesktop.infoboxiconlauncher.Clone

        pnltitlebarpongicon.BackgroundImage = ShiftOSDesktop.pongicontitlebar.Clone
        pnlpanelbuttonpongicon.BackgroundImage = ShiftOSDesktop.pongiconpanelbutton.Clone
        pnllauncherpongicon.BackgroundImage = ShiftOSDesktop.pongiconlauncher.Clone

        pnltitlebarfileskimmericon.BackgroundImage = ShiftOSDesktop.fileskimmericontitlebar.Clone
        pnlpanelbuttonfileskimmericon.BackgroundImage = ShiftOSDesktop.fileskimmericonpanelbutton.Clone
        pnllauncherfileskimmericon.BackgroundImage = ShiftOSDesktop.fileskimmericonlauncher.Clone

        pnltitlebartextpadicon.BackgroundImage = ShiftOSDesktop.textpadicontitlebar.Clone
        pnlpanelbuttontextpadicon.BackgroundImage = ShiftOSDesktop.textpadiconpanelbutton.Clone
        pnllaunchertextpadicon.BackgroundImage = ShiftOSDesktop.textpadiconlauncher.Clone

        pnltitlebarfileopenericon.BackgroundImage = ShiftOSDesktop.fileopenericontitlebar.Clone
        pnlpanelbuttonfileopenericon.BackgroundImage = ShiftOSDesktop.fileopenericonpanelbutton.Clone
        pnllauncherfileopenericon.BackgroundImage = ShiftOSDesktop.fileopenericonlauncher.Clone

        pnltitlebarfilesavericon.BackgroundImage = ShiftOSDesktop.filesavericontitlebar.Clone
        pnlpanelbuttonfilesavericon.BackgroundImage = ShiftOSDesktop.filesavericonpanelbutton.Clone
        pnllauncherfilesavericon.BackgroundImage = ShiftOSDesktop.filesavericonlauncher.Clone

        pnltitlebargraphicpickericon.BackgroundImage = ShiftOSDesktop.graphicpickericontitlebar.Clone
        pnlpanelbuttongraphicpickericon.BackgroundImage = ShiftOSDesktop.graphicpickericonpanelbutton.Clone
        pnllaunchergraphicpickericon.BackgroundImage = ShiftOSDesktop.graphicpickericonlauncher.Clone

        pnltitlebarskinloadericon.BackgroundImage = ShiftOSDesktop.skinloadericontitlebar.Clone
        pnlpanelbuttonskinloadericon.BackgroundImage = ShiftOSDesktop.skinloadericonpanelbutton.Clone
        pnllauncherskinloadericon.BackgroundImage = ShiftOSDesktop.skinloadericonlauncher.Clone

        pnltitlebarartpadicon.BackgroundImage = ShiftOSDesktop.artpadicontitlebar.Clone
        pnlpanelbuttonartpadicon.BackgroundImage = ShiftOSDesktop.artpadiconpanelbutton.Clone
        pnllauncherartpadicon.BackgroundImage = ShiftOSDesktop.artpadiconlauncher.Clone

        pnltitlebarcalculatoricon.BackgroundImage = ShiftOSDesktop.calculatoricontitlebar.Clone
        pnlpanelbuttoncalculatoricon.BackgroundImage = ShiftOSDesktop.calculatoriconpanelbutton.Clone
        pnllaunchercalculatoricon.BackgroundImage = ShiftOSDesktop.calculatoriconlauncher.Clone

        pnltitlebaraudioplayericon.BackgroundImage = ShiftOSDesktop.audioplayericontitlebar.Clone
        pnlpanelbuttonaudioplayericon.BackgroundImage = ShiftOSDesktop.audioplayericonpanelbutton.Clone
        pnllauncheraudioplayericon.BackgroundImage = ShiftOSDesktop.audioplayericonlauncher.Clone

        pnltitlebarwebbrowsericon.BackgroundImage = ShiftOSDesktop.webbrowsericontitlebar.Clone
        pnlpanelbuttonwebbrowsericon.BackgroundImage = ShiftOSDesktop.webbrowsericonpanelbutton.Clone
        pnllauncherwebbrowsericon.BackgroundImage = ShiftOSDesktop.webbrowsericonlauncher.Clone

        pnltitlebarvideoplayericon.BackgroundImage = ShiftOSDesktop.videoplayericontitlebar.Clone
        pnlpanelbuttonvideoplayericon.BackgroundImage = ShiftOSDesktop.videoplayericonpanelbutton.Clone
        pnllaunchervideoplayericon.BackgroundImage = ShiftOSDesktop.videoplayericonlauncher.Clone

        pnltitlebarnamechangericon.BackgroundImage = ShiftOSDesktop.namechangericontitlebar.Clone
        pnlpanelbuttonnamechangericon.BackgroundImage = ShiftOSDesktop.namechangericonpanelbutton.Clone
        pnllaunchernamechangericon.BackgroundImage = ShiftOSDesktop.namechangericonlauncher.Clone

        pnltitlebariconmanagericon.BackgroundImage = ShiftOSDesktop.iconmanagericontitlebar.Clone
        pnlpanelbuttoniconmanagericon.BackgroundImage = ShiftOSDesktop.iconmanagericonpanelbutton.Clone
        pnllaunchericonmanagericon.BackgroundImage = ShiftOSDesktop.iconmanagericonlauncher.Clone

        pnltitlebarterminalicon.BackgroundImage = ShiftOSDesktop.terminalicontitlebar.Clone
        pnlpanelbuttonterminalicon.BackgroundImage = ShiftOSDesktop.terminaliconpanelbutton.Clone
        pnllauncherterminalicon.BackgroundImage = ShiftOSDesktop.terminaliconlauncher.Clone

        pnltitlebarbitnotewalleticon.BackgroundImage = ShiftOSDesktop.bitnotewalleticontitlebar.Clone
        pnlpanelbuttonbitnotewalleticon.BackgroundImage = ShiftOSDesktop.bitnotewalleticonpanelbutton.Clone
        pnllauncherbitnotewalleticon.BackgroundImage = ShiftOSDesktop.bitnotewalleticonlauncher.Clone

        pnltitlebarbitnotediggericon.BackgroundImage = ShiftOSDesktop.bitnotediggericontitlebar.Clone
        pnlpanelbuttonbitnotediggericon.BackgroundImage = ShiftOSDesktop.bitnotediggericonpanelbutton.Clone
        pnllauncherbitnotediggericon.BackgroundImage = ShiftOSDesktop.bitnotediggericonlauncher.Clone

        pnltitlebarskinshiftericon.BackgroundImage = ShiftOSDesktop.skinshiftericontitlebar.Clone
        pnlpanelbuttonskinshiftericon.BackgroundImage = ShiftOSDesktop.skinshiftericonpanelbutton.Clone
        pnllauncherskinshiftericon.BackgroundImage = ShiftOSDesktop.skinshiftericonlauncher.Clone

        pnltitlebarshiftneticon.BackgroundImage = ShiftOSDesktop.shiftneticontitlebar.Clone
        pnlpanelbuttonshiftneticon.BackgroundImage = ShiftOSDesktop.shiftneticonpanelbutton.Clone
        pnllaunchershiftneticon.BackgroundImage = ShiftOSDesktop.shiftneticonlauncher.Clone

        pnltitlebardodgeicon.BackgroundImage = ShiftOSDesktop.dodgeicontitlebar.Clone
        pnlpanelbuttondodgeicon.BackgroundImage = ShiftOSDesktop.dodgeiconpanelbutton.Clone
        pnllauncherdodgeicon.BackgroundImage = ShiftOSDesktop.dodgeiconlauncher.Clone

        pnltitlebardownloadicon.BackgroundImage = ShiftOSDesktop.downloadmanagericontitlebar.Clone
        pnlpanelbuttondownloadicon.BackgroundImage = ShiftOSDesktop.downloadmanagericonpanelbutton.Clone
        pnllauncherdownloadicon.BackgroundImage = ShiftOSDesktop.downloadmanagericonlauncher.Clone

        pnltitlebarinstallericon.BackgroundImage = ShiftOSDesktop.installericontitlebar.Clone
        pnlpanelbuttoninstallericon.BackgroundImage = ShiftOSDesktop.installericonpanelbutton.Clone
        pnllauncherinstallericon.BackgroundImage = ShiftOSDesktop.installericonlauncher.Clone

        pnltitlebarsysinfoicon.BackgroundImage = ShiftOSDesktop.sysinfoicontitlebar.Clone
        pnlpanelbuttonsysinfoicon.BackgroundImage = ShiftOSDesktop.sysinfoiconpanelbutton.Clone
        pnllaunchersysinfoicon.BackgroundImage = ShiftOSDesktop.sysinfoiconlauncher.Clone

        pnltitlebarorcwriteicon.BackgroundImage = ShiftOSDesktop.orcwriteicontitlebar.Clone
        pnlpanelbuttonorcwriteicon.BackgroundImage = ShiftOSDesktop.orcwriteiconpanelbutton.Clone
        pnllauncherorcwriteicon.BackgroundImage = ShiftOSDesktop.orcwriteiconlauncher.Clone

        pnltitlebarfloodgateicon.BackgroundImage = ShiftOSDesktop.floodgateicontitlebar.Clone
        pnlpanelbuttonfloodgateicon.BackgroundImage = ShiftOSDesktop.floodgateiconpanelbutton.Clone
        pnllauncherfloodgateicon.BackgroundImage = ShiftOSDesktop.floodgateiconlauncher.Clone

        pnltitlebarmazeicon.BackgroundImage = ShiftOSDesktop.mazeicontitlebar.Clone
        pnlpanelbuttonmazeicon.BackgroundImage = ShiftOSDesktop.mazeiconpanelbutton.Clone
        pnllaunchermazeicon.BackgroundImage = ShiftOSDesktop.mazeiconlauncher.Clone

        pnltitlebarvirusscannericon.BackgroundImage = ShiftOSDesktop.virusscannericontitlebar.Clone
        pnlpanelbuttonvirusscannericon.BackgroundImage = ShiftOSDesktop.virusscannericonpanelbutton.Clone
        pnllaunchervirusscannericon.BackgroundImage = ShiftOSDesktop.virusscannericonlauncher.Clone

        pnllaunchershutdownicon.BackgroundImage = ShiftOSDesktop.shutdowniconlauncher.Clone

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
        txtnamechangername.Text = ShiftOSDesktop.namechangername
        txticonmanagername.Text = ShiftOSDesktop.iconmanagername
        txtterminalname.Text = ShiftOSDesktop.terminalname

        lblbitnotewallet.Text = ShiftOSDesktop.bitnotewalletname
        lblbitnotedigger.Text = ShiftOSDesktop.bitnotediggername
        lblskinshifter.Text = ShiftOSDesktop.skinshiftername
        lblshiftnet.Text = ShiftOSDesktop.shiftnetname
        lbldodge.Text = ShiftOSDesktop.dodgename
        lbldownload.Text = ShiftOSDesktop.downloadmanagername
        lblinstaller.Text = ShiftOSDesktop.installername
        lblsysinfo.Text = ShiftOSDesktop.sysinfoname
        lblorcwrite.Text = ShiftOSDesktop.orcwritename
        lblfloodgate.Text = ShiftOSDesktop.floodgatename
        lblmaze.Text = ShiftOSDesktop.mazename
        lblvirusscanner.Text = ShiftOSDesktop.virusscannername

        checkbackgroundimagesize()

        If needtosetupdesktop = True Then
            'ShiftOSDesktop.setupalltitlebars()
            'ShiftOSDesktop.setuppanelbuttons()
            ShiftOSDesktop.setupdesktop()
            needtosetupdesktop = False
        End If

        unsavedchanges = False
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        unsavedchanges = False

        ShiftOSDesktop.titlebariconsize = txttitlebariconsize.Text
        ShiftOSDesktop.panelbuttoniconsize = txtpanelbuttoniconsize.Text
        ShiftOSDesktop.launchericonsize = txtlaunchericonsize.Text

        ShiftOSDesktop.knowledgeinputicontitlebar = pnltitlebarknowledgeinputicon.BackgroundImage.Clone
        ShiftOSDesktop.knowledgeinputiconpanelbutton = pnlpanelbuttonknowledgeinputicon.BackgroundImage.Clone
        ShiftOSDesktop.knowledgeinputiconlauncher = pnllauncherknowledgeinputicon.BackgroundImage.Clone

        ShiftOSDesktop.shiftoriumicontitlebar = pnltitlebarshiftoriumicon.BackgroundImage.Clone
        ShiftOSDesktop.shiftoriumiconpanelbutton = pnlpanelbuttonshiftoriumicon.BackgroundImage.Clone
        ShiftOSDesktop.shiftoriumiconlauncher = pnllaunchershiftoriumicon.BackgroundImage.Clone

        ShiftOSDesktop.clockicontitlebar = pnltitlebarclockicon.BackgroundImage.Clone
        ShiftOSDesktop.clockiconpanelbutton = pnlpanelbuttonclockicon.BackgroundImage.Clone
        ShiftOSDesktop.clockiconlauncher = pnllauncherclockicon.BackgroundImage.Clone

        ShiftOSDesktop.shiftericontitlebar = pnltitlebarshiftericon.BackgroundImage.Clone
        ShiftOSDesktop.shiftericonpanelbutton = pnlpanelbuttonshiftericon.BackgroundImage.Clone
        ShiftOSDesktop.shiftericonlauncher = pnllaunchershiftericon.BackgroundImage.Clone

        ShiftOSDesktop.colourpickericontitlebar = pnltitlebarcolourpickericon.BackgroundImage.Clone
        ShiftOSDesktop.colourpickericonpanelbutton = pnlpanelbuttoncolourpickericon.BackgroundImage.Clone
        ShiftOSDesktop.colourpickericonlauncher = pnllaunchercolourpickericon.BackgroundImage.Clone

        ShiftOSDesktop.infoboxicontitlebar = pnltitlebarinfoboxicon.BackgroundImage.Clone
        ShiftOSDesktop.infoboxiconpanelbutton = pnlpanelbuttoninfoboxicon.BackgroundImage.Clone
        ShiftOSDesktop.infoboxiconlauncher = pnllauncherinfoboxicon.BackgroundImage.Clone

        ShiftOSDesktop.pongicontitlebar = pnltitlebarpongicon.BackgroundImage.Clone
        ShiftOSDesktop.pongiconpanelbutton = pnlpanelbuttonpongicon.BackgroundImage.Clone
        ShiftOSDesktop.pongiconlauncher = pnllauncherpongicon.BackgroundImage.Clone

        ShiftOSDesktop.fileskimmericontitlebar = pnltitlebarfileskimmericon.BackgroundImage.Clone
        ShiftOSDesktop.fileskimmericonpanelbutton = pnlpanelbuttonfileskimmericon.BackgroundImage.Clone
        ShiftOSDesktop.fileskimmericonlauncher = pnllauncherfileskimmericon.BackgroundImage.Clone

        ShiftOSDesktop.textpadicontitlebar = pnltitlebartextpadicon.BackgroundImage.Clone
        ShiftOSDesktop.textpadiconpanelbutton = pnlpanelbuttontextpadicon.BackgroundImage.Clone
        ShiftOSDesktop.textpadiconlauncher = pnllaunchertextpadicon.BackgroundImage.Clone

        ShiftOSDesktop.fileopenericontitlebar = pnltitlebarfileopenericon.BackgroundImage.Clone
        ShiftOSDesktop.fileopenericonpanelbutton = pnlpanelbuttonfileopenericon.BackgroundImage.Clone
        ShiftOSDesktop.fileopenericonlauncher = pnllauncherfileopenericon.BackgroundImage.Clone

        ShiftOSDesktop.filesavericontitlebar = pnltitlebarfilesavericon.BackgroundImage.Clone
        ShiftOSDesktop.filesavericonpanelbutton = pnlpanelbuttonfilesavericon.BackgroundImage.Clone
        ShiftOSDesktop.filesavericonlauncher = pnllauncherfilesavericon.BackgroundImage.Clone

        ShiftOSDesktop.graphicpickericontitlebar = pnltitlebargraphicpickericon.BackgroundImage.Clone
        ShiftOSDesktop.graphicpickericonpanelbutton = pnlpanelbuttongraphicpickericon.BackgroundImage.Clone
        ShiftOSDesktop.graphicpickericonlauncher = pnllaunchergraphicpickericon.BackgroundImage.Clone

        ShiftOSDesktop.skinloadericontitlebar = pnltitlebarskinloadericon.BackgroundImage.Clone
        ShiftOSDesktop.skinloadericonpanelbutton = pnlpanelbuttonskinloadericon.BackgroundImage.Clone
        ShiftOSDesktop.skinloadericonlauncher = pnllauncherskinloadericon.BackgroundImage.Clone

        ShiftOSDesktop.artpadicontitlebar = pnltitlebarartpadicon.BackgroundImage.Clone
        ShiftOSDesktop.artpadiconpanelbutton = pnlpanelbuttonartpadicon.BackgroundImage.Clone
        ShiftOSDesktop.artpadiconlauncher = pnllauncherartpadicon.BackgroundImage.Clone

        ShiftOSDesktop.calculatoricontitlebar = pnltitlebarcalculatoricon.BackgroundImage.Clone
        ShiftOSDesktop.calculatoriconpanelbutton = pnlpanelbuttoncalculatoricon.BackgroundImage.Clone
        ShiftOSDesktop.calculatoriconlauncher = pnllaunchercalculatoricon.BackgroundImage.Clone

        ShiftOSDesktop.audioplayericontitlebar = pnltitlebaraudioplayericon.BackgroundImage.Clone
        ShiftOSDesktop.audioplayericonpanelbutton = pnlpanelbuttonaudioplayericon.BackgroundImage.Clone
        ShiftOSDesktop.audioplayericonlauncher = pnllauncheraudioplayericon.BackgroundImage.Clone

        ShiftOSDesktop.webbrowsericontitlebar = pnltitlebarwebbrowsericon.BackgroundImage.Clone
        ShiftOSDesktop.webbrowsericonpanelbutton = pnlpanelbuttonwebbrowsericon.BackgroundImage.Clone
        ShiftOSDesktop.webbrowsericonlauncher = pnllauncherwebbrowsericon.BackgroundImage.Clone

        ShiftOSDesktop.videoplayericontitlebar = pnltitlebarvideoplayericon.BackgroundImage.Clone
        ShiftOSDesktop.videoplayericonpanelbutton = pnlpanelbuttonvideoplayericon.BackgroundImage.Clone
        ShiftOSDesktop.videoplayericonlauncher = pnllaunchervideoplayericon.BackgroundImage.Clone

        ShiftOSDesktop.namechangericontitlebar = pnltitlebarnamechangericon.BackgroundImage.Clone
        ShiftOSDesktop.namechangericonpanelbutton = pnlpanelbuttonnamechangericon.BackgroundImage.Clone
        ShiftOSDesktop.namechangericonlauncher = pnllaunchernamechangericon.BackgroundImage.Clone

        ShiftOSDesktop.iconmanagericontitlebar = pnltitlebariconmanagericon.BackgroundImage.Clone
        ShiftOSDesktop.iconmanagericonpanelbutton = pnlpanelbuttoniconmanagericon.BackgroundImage.Clone
        ShiftOSDesktop.iconmanagericonlauncher = pnllaunchericonmanagericon.BackgroundImage.Clone

        ShiftOSDesktop.terminalicontitlebar = pnltitlebarterminalicon.BackgroundImage.Clone
        ShiftOSDesktop.terminaliconpanelbutton = pnlpanelbuttonterminalicon.BackgroundImage.Clone
        ShiftOSDesktop.terminaliconlauncher = pnllauncherterminalicon.BackgroundImage.Clone

        ShiftOSDesktop.bitnotewalleticontitlebar = pnltitlebarbitnotewalleticon.BackgroundImage.Clone
        ShiftOSDesktop.bitnotewalleticonpanelbutton = pnlpanelbuttonbitnotewalleticon.BackgroundImage.Clone
        ShiftOSDesktop.bitnotewalleticonlauncher = pnllauncherbitnotewalleticon.BackgroundImage.Clone

        ShiftOSDesktop.bitnotediggericontitlebar = pnltitlebarbitnotediggericon.BackgroundImage.Clone
        ShiftOSDesktop.bitnotediggericonpanelbutton = pnlpanelbuttonbitnotediggericon.BackgroundImage.Clone
        ShiftOSDesktop.bitnotediggericonlauncher = pnllauncherbitnotediggericon.BackgroundImage.Clone

        ShiftOSDesktop.skinshiftericontitlebar = pnltitlebarskinshiftericon.BackgroundImage.Clone
        ShiftOSDesktop.skinshiftericonpanelbutton = pnlpanelbuttonskinshiftericon.BackgroundImage.Clone
        ShiftOSDesktop.skinshiftericonlauncher = pnllauncherskinshiftericon.BackgroundImage.Clone

        ShiftOSDesktop.shiftneticontitlebar = pnltitlebarshiftneticon.BackgroundImage.Clone
        ShiftOSDesktop.shiftneticonpanelbutton = pnlpanelbuttonshiftneticon.BackgroundImage.Clone
        ShiftOSDesktop.shiftneticonlauncher = pnllaunchershiftneticon.BackgroundImage.Clone

        ShiftOSDesktop.dodgeicontitlebar = pnltitlebardodgeicon.BackgroundImage.Clone
        ShiftOSDesktop.dodgeiconpanelbutton = pnlpanelbuttondodgeicon.BackgroundImage.Clone
        ShiftOSDesktop.dodgeiconlauncher = pnllauncherdodgeicon.BackgroundImage.Clone

        ShiftOSDesktop.downloadmanagericontitlebar = pnltitlebardownloadicon.BackgroundImage.Clone
        ShiftOSDesktop.downloadmanagericonpanelbutton = pnlpanelbuttondownloadicon.BackgroundImage.Clone
        ShiftOSDesktop.downloadmanagericonlauncher = pnllauncherdownloadicon.BackgroundImage.Clone

        ShiftOSDesktop.installericontitlebar = pnltitlebarinstallericon.BackgroundImage.Clone
        ShiftOSDesktop.installericonpanelbutton = pnlpanelbuttoninstallericon.BackgroundImage.Clone
        ShiftOSDesktop.installericonlauncher = pnllauncherinstallericon.BackgroundImage.Clone

        ShiftOSDesktop.sysinfoicontitlebar = pnltitlebarsysinfoicon.BackgroundImage.Clone
        ShiftOSDesktop.sysinfoiconpanelbutton = pnlpanelbuttonsysinfoicon.BackgroundImage.Clone
        ShiftOSDesktop.sysinfoiconlauncher = pnllaunchersysinfoicon.BackgroundImage.Clone

        ShiftOSDesktop.orcwriteicontitlebar = pnltitlebarorcwriteicon.BackgroundImage.Clone
        ShiftOSDesktop.orcwriteiconpanelbutton = pnlpanelbuttonorcwriteicon.BackgroundImage.Clone
        ShiftOSDesktop.orcwriteiconlauncher = pnllauncherorcwriteicon.BackgroundImage.Clone

        ShiftOSDesktop.floodgateicontitlebar = pnltitlebarfloodgateicon.BackgroundImage.Clone
        ShiftOSDesktop.floodgateiconpanelbutton = pnlpanelbuttonfloodgateicon.BackgroundImage.Clone
        ShiftOSDesktop.floodgateiconlauncher = pnllauncherfloodgateicon.BackgroundImage.Clone

        ShiftOSDesktop.mazeicontitlebar = pnltitlebarmazeicon.BackgroundImage.Clone
        ShiftOSDesktop.mazeiconpanelbutton = pnlpanelbuttonmazeicon.BackgroundImage.Clone
        ShiftOSDesktop.mazeiconlauncher = pnllaunchermazeicon.BackgroundImage.Clone

        ShiftOSDesktop.virusscannericontitlebar = pnltitlebarvirusscannericon.BackgroundImage.Clone
        ShiftOSDesktop.virusscannericonpanelbutton = pnlpanelbuttonvirusscannericon.BackgroundImage.Clone
        ShiftOSDesktop.virusscannericonlauncher = pnllaunchervirusscannericon.BackgroundImage.Clone

        ShiftOSDesktop.shutdowniconlauncher = pnllaunchershutdownicon.BackgroundImage.Clone

        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setupdesktop()
        If Name_Changer.Visible = True Then Name_Changer.loadicons()

        While My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Icons")
            Try
                If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Icons") Then My.Computer.FileSystem.DeleteDirectory(ShiftOSPath + "Shiftum42\Icons", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
            End Try
        End While

        My.Computer.FileSystem.CreateDirectory(ShiftOSPath + "Shiftum42\Icons")

        savelines(0) = ShiftOSDesktop.titlebariconsize
        savelines(1) = ShiftOSDesktop.panelbuttoniconsize
        savelines(2) = ShiftOSDesktop.launchericonsize
        IO.File.WriteAllLines(ShiftOSPath + "Shiftum42\Icons\icondata.dat", savelines)

        saveappliedicons()
    End Sub

    Private Sub ChangeImage(sender As Object, e As MouseEventArgs) Handles pnltitlebarknowledgeinputicon.MouseClick, pnlpanelbuttonknowledgeinputicon.MouseClick, pnllauncherknowledgeinputicon.MouseClick, pnltitlebarshiftoriumicon.MouseClick, pnlpanelbuttonshiftoriumicon.MouseClick, pnllaunchershiftoriumicon.MouseClick, pnltitlebarclockicon.MouseClick, pnlpanelbuttonclockicon.MouseClick, pnllauncherclockicon.MouseClick, pnltitlebarshiftericon.MouseClick, pnlpanelbuttonshiftericon.MouseClick, pnllaunchershiftericon.MouseClick, pnltitlebarcolourpickericon.MouseClick, pnlpanelbuttoncolourpickericon.MouseClick, pnllaunchercolourpickericon.MouseClick, pnltitlebarinfoboxicon.MouseClick, pnlpanelbuttoninfoboxicon.MouseClick, pnllauncherinfoboxicon.MouseClick, pnltitlebarpongicon.MouseClick, pnlpanelbuttonpongicon.MouseClick, pnllauncherpongicon.MouseClick, pnltitlebarfileskimmericon.MouseClick, pnlpanelbuttonfileskimmericon.MouseClick, pnllauncherfileskimmericon.MouseClick, pnltitlebartextpadicon.MouseClick, pnlpanelbuttontextpadicon.MouseClick, pnllaunchertextpadicon.MouseClick, pnltitlebarfileopenericon.MouseClick, pnlpanelbuttonfileopenericon.MouseClick, pnllauncherfileopenericon.MouseClick, pnltitlebarfilesavericon.MouseClick, pnlpanelbuttonfilesavericon.MouseClick, pnllauncherfilesavericon.MouseClick, pnltitlebargraphicpickericon.MouseClick, pnlpanelbuttongraphicpickericon.MouseClick, pnllaunchergraphicpickericon.MouseClick, pnltitlebarskinloadericon.MouseClick, pnlpanelbuttonskinloadericon.MouseClick, pnllauncherskinloadericon.MouseClick, pnltitlebarartpadicon.MouseClick, pnlpanelbuttonartpadicon.MouseClick, pnllauncherartpadicon.MouseClick, pnltitlebarcalculatoricon.MouseClick, pnlpanelbuttoncalculatoricon.MouseClick, pnllaunchercalculatoricon.MouseClick, pnltitlebaraudioplayericon.MouseClick, pnlpanelbuttonaudioplayericon.MouseClick, pnllauncheraudioplayericon.MouseClick, pnltitlebarwebbrowsericon.MouseClick, pnlpanelbuttonwebbrowsericon.MouseClick, pnllauncherwebbrowsericon.MouseClick, pnltitlebarvideoplayericon.MouseClick, pnlpanelbuttonvideoplayericon.MouseClick, pnllaunchervideoplayericon.MouseClick, pnltitlebarnamechangericon.MouseClick, pnlpanelbuttonnamechangericon.MouseClick, pnllaunchernamechangericon.MouseClick, pnltitlebariconmanagericon.MouseClick, pnlpanelbuttoniconmanagericon.MouseClick, pnllaunchericonmanagericon.MouseClick, pnltitlebarterminalicon.MouseClick, pnlpanelbuttonterminalicon.MouseClick, pnllauncherterminalicon.MouseClick, pnltitlebarbitnotewalleticon.MouseClick, pnltitlebarbitnotediggericon.MouseClick, pnlpanelbuttonbitnotewalleticon.MouseClick, pnlpanelbuttonbitnotediggericon.MouseClick, pnllauncherbitnotewalleticon.MouseClick, pnllauncherbitnotediggericon.MouseClick, pnltitlebarskinshiftericon.MouseClick, pnlpanelbuttonskinshiftericon.MouseClick, pnllauncherskinshiftericon.MouseClick, pnltitlebarshiftneticon.MouseClick, pnlpanelbuttonshiftneticon.MouseClick, pnllaunchershiftneticon.MouseClick, pnltitlebardodgeicon.MouseClick, pnlpanelbuttondodgeicon.MouseClick, pnllauncherdodgeicon.MouseClick, pnltitlebardownloadicon.MouseClick, pnlpanelbuttondownloadicon.MouseClick, pnllauncherdownloadicon.MouseClick, pnltitlebarinstallericon.MouseClick, pnlpanelbuttoninstallericon.MouseClick, pnllauncherinstallericon.MouseClick, pnltitlebarsysinfoicon.MouseClick, pnlpanelbuttonsysinfoicon.MouseClick, pnllaunchersysinfoicon.MouseClick, pnltitlebarorcwriteicon.MouseClick, pnlpanelbuttonorcwriteicon.MouseClick, pnlpanelbuttonorcwriteicon.MouseClick, pnllauncherorcwriteicon.MouseClick, pnltitlebarfloodgateicon.MouseClick, pnlpanelbuttonfloodgateicon.MouseClick, pnllauncherfloodgateicon.MouseClick, pnltitlebarmazeicon.MouseClick, pnlpanelbuttonmazeicon.MouseClick, pnllaunchermazeicon.MouseClick, pnltitlebarvirusscannericon.MouseClick, pnlpanelbuttonvirusscannericon.MouseClick, pnllaunchervirusscannericon.MouseClick
        File_Opener.Show()
        File_Opener.openingprogram = "iconmanager"
        File_Opener.openextention = ".pic"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
        icontochange = sender
        unsavedchanges = True
    End Sub

    Public Sub loadicon()

        icontochange.BackgroundImage = GetImage(openedfilelocation)
        If over64 = True Then
            icontochange.backgroundimagelayout = ImageLayout.Stretch
            over64 = False
        Else
            icontochange.backgroundimagelayout = ImageLayout.Center
        End If

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ShiftOSDesktop.titlebariconsize = 16
        ShiftOSDesktop.panelbuttoniconsize = 16
        ShiftOSDesktop.launchericonsize = 16

        disposebackgrounds()
        needtosetupdesktop = True
        loadsettings()

        ShiftOSDesktop.artpadicontitlebar = My.Resources.iconArtpad
        ShiftOSDesktop.audioplayericontitlebar = My.Resources.iconAudioPlayer
        ShiftOSDesktop.calculatoricontitlebar = My.Resources.iconCalculator
        ShiftOSDesktop.clockicontitlebar = My.Resources.iconClock
        ShiftOSDesktop.colourpickericontitlebar = My.Resources.iconColourPicker
        ShiftOSDesktop.fileopenericontitlebar = My.Resources.iconFileOpener
        ShiftOSDesktop.filesavericontitlebar = My.Resources.iconFileSaver
        ShiftOSDesktop.fileskimmericontitlebar = My.Resources.iconFileSkimmer
        ShiftOSDesktop.graphicpickericontitlebar = My.Resources.iconGraphicPicker
        ShiftOSDesktop.infoboxicontitlebar = My.Resources.iconInfoBox
        ShiftOSDesktop.knowledgeinputicontitlebar = My.Resources.iconKnowledgeInput
        ShiftOSDesktop.pongicontitlebar = My.Resources.iconPong
        ShiftOSDesktop.shiftericontitlebar = My.Resources.iconShifter
        ShiftOSDesktop.shiftoriumicontitlebar = My.Resources.iconShiftorium
        ShiftOSDesktop.skinloadericontitlebar = My.Resources.iconSkinLoader
        ShiftOSDesktop.terminalicontitlebar = My.Resources.iconTerminal
        ShiftOSDesktop.textpadicontitlebar = My.Resources.iconTextPad
        ShiftOSDesktop.videoplayericontitlebar = My.Resources.iconVideoPlayer
        ShiftOSDesktop.webbrowsericontitlebar = My.Resources.iconWebBrowser
        ShiftOSDesktop.namechangericontitlebar = My.Resources.iconNameChanger
        ShiftOSDesktop.iconmanagericontitlebar = My.Resources.iconIconManager
        ShiftOSDesktop.bitnotewalleticontitlebar = My.Resources.iconBitnoteWallet
        ShiftOSDesktop.bitnotediggericontitlebar = My.Resources.iconBitnoteDigger
        ShiftOSDesktop.skinshiftericontitlebar = My.Resources.iconSkinShifter
        ShiftOSDesktop.shiftneticontitlebar = My.Resources.iconShiftnet
        ShiftOSDesktop.downloadericontitlebar = My.Resources.iconDownloader
        ShiftOSDesktop.dodgeicontitlebar = My.Resources.iconDodge
        ShiftOSDesktop.downloadmanagericontitlebar = My.Resources.icondownloadmanager
        ShiftOSDesktop.installericontitlebar = My.Resources.iconinstaller
        ShiftOSDesktop.snakeyicontitlebar = My.Resources.iconSnakey
        ShiftOSDesktop.sysinfoicontitlebar = My.Resources.iconSysinfo
        ShiftOSDesktop.orcwriteicontitlebar = My.Resources.iconorcwrite
        ShiftOSDesktop.floodgateicontitlebar = My.Resources.iconfloodgate
        ShiftOSDesktop.mazeicontitlebar = My.Resources.iconmaze
        ShiftOSDesktop.virusscannericontitlebar = My.Resources.iconvirusscanner

        ShiftOSDesktop.artpadiconpanelbutton = My.Resources.iconArtpad
        ShiftOSDesktop.audioplayericonpanelbutton = My.Resources.iconAudioPlayer
        ShiftOSDesktop.calculatoriconpanelbutton = My.Resources.iconCalculator
        ShiftOSDesktop.clockiconpanelbutton = My.Resources.iconClock
        ShiftOSDesktop.colourpickericonpanelbutton = My.Resources.iconColourPicker
        ShiftOSDesktop.fileopenericonpanelbutton = My.Resources.iconFileOpener
        ShiftOSDesktop.filesavericonpanelbutton = My.Resources.iconFileSaver
        ShiftOSDesktop.fileskimmericonpanelbutton = My.Resources.iconFileSkimmer
        ShiftOSDesktop.graphicpickericonpanelbutton = My.Resources.iconGraphicPicker
        ShiftOSDesktop.infoboxiconpanelbutton = My.Resources.iconInfoBox
        ShiftOSDesktop.knowledgeinputiconpanelbutton = My.Resources.iconKnowledgeInput
        ShiftOSDesktop.pongiconpanelbutton = My.Resources.iconPong
        ShiftOSDesktop.shiftericonpanelbutton = My.Resources.iconShifter
        ShiftOSDesktop.shiftoriumiconpanelbutton = My.Resources.iconShiftorium
        ShiftOSDesktop.skinloadericonpanelbutton = My.Resources.iconSkinLoader
        ShiftOSDesktop.terminaliconpanelbutton = My.Resources.iconTerminal
        ShiftOSDesktop.textpadiconpanelbutton = My.Resources.iconTextPad
        ShiftOSDesktop.videoplayericonpanelbutton = My.Resources.iconVideoPlayer
        ShiftOSDesktop.webbrowsericonpanelbutton = My.Resources.iconWebBrowser
        ShiftOSDesktop.namechangericonpanelbutton = My.Resources.iconNameChanger
        ShiftOSDesktop.iconmanagericonpanelbutton = My.Resources.iconIconManager
        ShiftOSDesktop.bitnotewalleticonpanelbutton = My.Resources.iconBitnoteWallet
        ShiftOSDesktop.bitnotediggericonpanelbutton = My.Resources.iconBitnoteDigger
        ShiftOSDesktop.skinshiftericonpanelbutton = My.Resources.iconSkinShifter
        ShiftOSDesktop.shiftneticonpanelbutton = My.Resources.iconShiftnet
        ShiftOSDesktop.downloadericonpanelbutton = My.Resources.iconDownloader
        ShiftOSDesktop.dodgeiconpanelbutton = My.Resources.iconDodge
        ShiftOSDesktop.downloadmanagericonpanelbutton = My.Resources.icondownloadmanager
        ShiftOSDesktop.installericonpanelbutton = My.Resources.iconinstaller
        ShiftOSDesktop.snakeyiconpanelbutton = My.Resources.iconSnakey
        ShiftOSDesktop.sysinfoiconpanelbutton = My.Resources.iconSysinfo
        ShiftOSDesktop.orcwriteiconpanelbutton = My.Resources.iconorcwrite
        ShiftOSDesktop.floodgateiconpanelbutton = My.Resources.iconfloodgate
        ShiftOSDesktop.mazeiconpanelbutton = My.Resources.iconmaze
        ShiftOSDesktop.virusscannericonpanelbutton = My.Resources.iconvirusscanner

        ShiftOSDesktop.artpadiconlauncher = My.Resources.iconArtpad
        ShiftOSDesktop.audioplayericonlauncher = My.Resources.iconAudioPlayer
        ShiftOSDesktop.calculatoriconlauncher = My.Resources.iconCalculator
        ShiftOSDesktop.clockiconlauncher = My.Resources.iconClock
        ShiftOSDesktop.colourpickericonlauncher = My.Resources.iconColourPicker
        ShiftOSDesktop.fileopenericonlauncher = My.Resources.iconFileOpener
        ShiftOSDesktop.filesavericonlauncher = My.Resources.iconFileSaver
        ShiftOSDesktop.fileskimmericonlauncher = My.Resources.iconFileSkimmer
        ShiftOSDesktop.graphicpickericonlauncher = My.Resources.iconGraphicPicker
        ShiftOSDesktop.infoboxiconlauncher = My.Resources.iconInfoBox
        ShiftOSDesktop.knowledgeinputiconlauncher = My.Resources.iconKnowledgeInput
        ShiftOSDesktop.pongiconlauncher = My.Resources.iconPong
        ShiftOSDesktop.shiftericonlauncher = My.Resources.iconShifter
        ShiftOSDesktop.shiftoriumiconlauncher = My.Resources.iconShiftorium
        ShiftOSDesktop.skinloadericonlauncher = My.Resources.iconSkinLoader
        ShiftOSDesktop.terminaliconlauncher = My.Resources.iconTerminal
        ShiftOSDesktop.textpadiconlauncher = My.Resources.iconTextPad
        ShiftOSDesktop.videoplayericonlauncher = My.Resources.iconVideoPlayer
        ShiftOSDesktop.webbrowsericonlauncher = My.Resources.iconWebBrowser
        ShiftOSDesktop.namechangericonlauncher = My.Resources.iconNameChanger
        ShiftOSDesktop.iconmanagericonlauncher = My.Resources.iconIconManager
        ShiftOSDesktop.bitnotewalleticonlauncher = My.Resources.iconBitnoteWallet
        ShiftOSDesktop.bitnotediggericonlauncher = My.Resources.iconBitnoteDigger
        ShiftOSDesktop.skinshiftericonlauncher = My.Resources.iconSkinShifter
        ShiftOSDesktop.shiftneticonlauncher = My.Resources.iconShiftnet
        ShiftOSDesktop.downloadericonlauncher = My.Resources.iconDownloader
        ShiftOSDesktop.dodgeiconlauncher = My.Resources.iconDodge
        ShiftOSDesktop.downloadmanagericonlauncher = My.Resources.icondownloadmanager
        ShiftOSDesktop.installericonlauncher = My.Resources.iconinstaller
        ShiftOSDesktop.snakeyiconlauncher = My.Resources.iconSnakey
        ShiftOSDesktop.sysinfoiconlauncher = My.Resources.iconSysinfo
        ShiftOSDesktop.orcwriteiconlauncher = My.Resources.iconorcwrite
        ShiftOSDesktop.floodgateiconlauncher = My.Resources.iconfloodgate
        ShiftOSDesktop.mazeiconlauncher = My.Resources.iconmaze
        ShiftOSDesktop.virusscannericonlauncher = My.Resources.iconvirusscanner

        ShiftOSDesktop.shutdowniconlauncher = My.Resources.iconshutdown

        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setupdesktop()

        loadsettings()
    End Sub

    Public Sub disposebackgrounds()
        pnltitlebarknowledgeinputicon.BackgroundImage.Dispose()
        pnlpanelbuttonknowledgeinputicon.BackgroundImage.Dispose()
        pnllauncherknowledgeinputicon.BackgroundImage.Dispose()

        pnltitlebarshiftoriumicon.BackgroundImage.Dispose()
        pnlpanelbuttonshiftoriumicon.BackgroundImage.Dispose()
        pnllaunchershiftoriumicon.BackgroundImage.Dispose()

        pnltitlebarclockicon.BackgroundImage.Dispose()
        pnlpanelbuttonclockicon.BackgroundImage.Dispose()
        pnllauncherclockicon.BackgroundImage.Dispose()

        pnltitlebarshiftericon.BackgroundImage.Dispose()
        pnlpanelbuttonshiftericon.BackgroundImage.Dispose()
        pnllaunchershiftericon.BackgroundImage.Dispose()

        pnltitlebarcolourpickericon.BackgroundImage.Dispose()
        pnlpanelbuttoncolourpickericon.BackgroundImage.Dispose()
        pnllaunchercolourpickericon.BackgroundImage.Dispose()

        pnltitlebarinfoboxicon.BackgroundImage.Dispose()
        pnlpanelbuttoninfoboxicon.BackgroundImage.Dispose()
        pnllauncherinfoboxicon.BackgroundImage.Dispose()

        pnltitlebarpongicon.BackgroundImage.Dispose()
        pnlpanelbuttonpongicon.BackgroundImage.Dispose()
        pnllauncherpongicon.BackgroundImage.Dispose()

        pnltitlebarfileskimmericon.BackgroundImage.Dispose()
        pnlpanelbuttonfileskimmericon.BackgroundImage.Dispose()
        pnllauncherfileskimmericon.BackgroundImage.Dispose()

        pnltitlebartextpadicon.BackgroundImage.Dispose()
        pnlpanelbuttontextpadicon.BackgroundImage.Dispose()
        pnllaunchertextpadicon.BackgroundImage.Dispose()

        pnltitlebarfileopenericon.BackgroundImage.Dispose()
        pnlpanelbuttonfileopenericon.BackgroundImage.Dispose()
        pnllauncherfileopenericon.BackgroundImage.Dispose()

        pnltitlebarfilesavericon.BackgroundImage.Dispose()
        pnlpanelbuttonfilesavericon.BackgroundImage.Dispose()
        pnllauncherfilesavericon.BackgroundImage.Dispose()

        pnltitlebargraphicpickericon.BackgroundImage.Dispose()
        pnlpanelbuttongraphicpickericon.BackgroundImage.Dispose()
        pnllaunchergraphicpickericon.BackgroundImage.Dispose()

        pnltitlebarskinloadericon.BackgroundImage.Dispose()
        pnlpanelbuttonskinloadericon.BackgroundImage.Dispose()
        pnllauncherskinloadericon.BackgroundImage.Dispose()

        pnltitlebarartpadicon.BackgroundImage.Dispose()
        pnlpanelbuttonartpadicon.BackgroundImage.Dispose()
        pnllauncherartpadicon.BackgroundImage.Dispose()

        pnltitlebarcalculatoricon.BackgroundImage.Dispose()
        pnlpanelbuttoncalculatoricon.BackgroundImage.Dispose()
        pnllaunchercalculatoricon.BackgroundImage.Dispose()

        pnltitlebaraudioplayericon.BackgroundImage.Dispose()
        pnlpanelbuttonaudioplayericon.BackgroundImage.Dispose()
        pnllauncheraudioplayericon.BackgroundImage.Dispose()

        pnltitlebarwebbrowsericon.BackgroundImage.Dispose()
        pnlpanelbuttonwebbrowsericon.BackgroundImage.Dispose()
        pnllauncherwebbrowsericon.BackgroundImage.Dispose()

        pnltitlebarvideoplayericon.BackgroundImage.Dispose()
        pnlpanelbuttonvideoplayericon.BackgroundImage.Dispose()
        pnllaunchervideoplayericon.BackgroundImage.Dispose()

        pnltitlebarnamechangericon.BackgroundImage.Dispose()
        pnlpanelbuttonnamechangericon.BackgroundImage.Dispose()
        pnllaunchernamechangericon.BackgroundImage.Dispose()

        pnltitlebariconmanagericon.BackgroundImage.Dispose()
        pnlpanelbuttoniconmanagericon.BackgroundImage.Dispose()
        pnllaunchericonmanagericon.BackgroundImage.Dispose()

        pnltitlebarterminalicon.BackgroundImage.Dispose()
        pnlpanelbuttonterminalicon.BackgroundImage.Dispose()
        pnllauncherterminalicon.BackgroundImage.Dispose()

        pnllaunchershutdownicon.BackgroundImage.Dispose()
    End Sub

    Public Sub checkbackgroundimagesize()
        minicheckresize(pnltitlebarknowledgeinputicon)
        minicheckresize(pnlpanelbuttonknowledgeinputicon)
        minicheckresize(pnllauncherknowledgeinputicon)

        minicheckresize(pnltitlebarshiftoriumicon)
        minicheckresize(pnlpanelbuttonshiftoriumicon)
        minicheckresize(pnllaunchershiftoriumicon)

        minicheckresize(pnltitlebarclockicon)
        minicheckresize(pnlpanelbuttonclockicon)
        minicheckresize(pnllauncherclockicon)

        minicheckresize(pnltitlebarshiftericon)
        minicheckresize(pnlpanelbuttonshiftericon)
        minicheckresize(pnllaunchershiftericon)

        minicheckresize(pnltitlebarcolourpickericon)
        minicheckresize(pnlpanelbuttoncolourpickericon)
        minicheckresize(pnllaunchercolourpickericon)

        minicheckresize(pnltitlebarinfoboxicon)
        minicheckresize(pnlpanelbuttoninfoboxicon)
        minicheckresize(pnllauncherinfoboxicon)

        minicheckresize(pnltitlebarpongicon)
        minicheckresize(pnlpanelbuttonpongicon)
        minicheckresize(pnllauncherpongicon)

        minicheckresize(pnltitlebarfileskimmericon)
        minicheckresize(pnlpanelbuttonfileskimmericon)
        minicheckresize(pnllauncherfileskimmericon)

        minicheckresize(pnltitlebartextpadicon)
        minicheckresize(pnlpanelbuttontextpadicon)
        minicheckresize(pnllaunchertextpadicon)

        minicheckresize(pnltitlebarfileopenericon)
        minicheckresize(pnlpanelbuttonfileopenericon)
        minicheckresize(pnllauncherfileopenericon)

        minicheckresize(pnltitlebarfilesavericon)
        minicheckresize(pnlpanelbuttonfilesavericon)
        minicheckresize(pnllauncherfilesavericon)

        minicheckresize(pnltitlebargraphicpickericon)
        minicheckresize(pnlpanelbuttongraphicpickericon)
        minicheckresize(pnllaunchergraphicpickericon)

        minicheckresize(pnltitlebarskinloadericon)
        minicheckresize(pnlpanelbuttonskinloadericon)
        minicheckresize(pnllauncherskinloadericon)

        minicheckresize(pnltitlebarartpadicon)
        minicheckresize(pnlpanelbuttonartpadicon)
        minicheckresize(pnllauncherartpadicon)

        minicheckresize(pnltitlebarcalculatoricon)
        minicheckresize(pnlpanelbuttoncalculatoricon)
        minicheckresize(pnllaunchercalculatoricon)

        minicheckresize(pnltitlebaraudioplayericon)
        minicheckresize(pnlpanelbuttonaudioplayericon)
        minicheckresize(pnllauncheraudioplayericon)

        minicheckresize(pnltitlebarwebbrowsericon)
        minicheckresize(pnlpanelbuttonwebbrowsericon)
        minicheckresize(pnllauncherwebbrowsericon)

        minicheckresize(pnltitlebarvideoplayericon)
        minicheckresize(pnlpanelbuttonvideoplayericon)
        minicheckresize(pnllaunchervideoplayericon)

        minicheckresize(pnltitlebarnamechangericon)
        minicheckresize(pnlpanelbuttonnamechangericon)
        minicheckresize(pnllaunchernamechangericon)

        minicheckresize(pnltitlebariconmanagericon)
        minicheckresize(pnlpanelbuttoniconmanagericon)
        minicheckresize(pnllaunchericonmanagericon)

        minicheckresize(pnltitlebarterminalicon)
        minicheckresize(pnlpanelbuttonterminalicon)
        minicheckresize(pnllauncherterminalicon)

        minicheckresize(pnllaunchershutdownicon)
    End Sub

    Public Sub minicheckresize(ByVal panel As Panel)
        If panel.BackgroundImage.Width > 64 Then panel.BackgroundImageLayout = ImageLayout.Stretch Else panel.BackgroundImageLayout = ImageLayout.Center
    End Sub

    Public Sub saveappliedicons()
        saveprocess(pnltitlebarknowledgeinputicon)
        saveprocess(pnlpanelbuttonknowledgeinputicon)
        saveprocess(pnllauncherknowledgeinputicon)

        saveprocess(pnltitlebarshiftoriumicon)
        saveprocess(pnlpanelbuttonshiftoriumicon)
        saveprocess(pnllaunchershiftoriumicon)

        saveprocess(pnltitlebarclockicon)
        saveprocess(pnlpanelbuttonclockicon)
        saveprocess(pnllauncherclockicon)

        saveprocess(pnltitlebarshiftericon)
        saveprocess(pnlpanelbuttonshiftericon)
        saveprocess(pnllaunchershiftericon)

        saveprocess(pnltitlebarcolourpickericon)
        saveprocess(pnlpanelbuttoncolourpickericon)
        saveprocess(pnllaunchercolourpickericon)

        saveprocess(pnltitlebarinfoboxicon)
        saveprocess(pnlpanelbuttoninfoboxicon)
        saveprocess(pnllauncherinfoboxicon)

        saveprocess(pnltitlebarpongicon)
        saveprocess(pnlpanelbuttonpongicon)
        saveprocess(pnllauncherpongicon)

        saveprocess(pnltitlebarfileskimmericon)
        saveprocess(pnlpanelbuttonfileskimmericon)
        saveprocess(pnllauncherfileskimmericon)

        saveprocess(pnltitlebartextpadicon)
        saveprocess(pnlpanelbuttontextpadicon)
        saveprocess(pnllaunchertextpadicon)

        saveprocess(pnltitlebarfileopenericon)
        saveprocess(pnlpanelbuttonfileopenericon)
        saveprocess(pnllauncherfileopenericon)

        saveprocess(pnltitlebarfilesavericon)
        saveprocess(pnlpanelbuttonfilesavericon)
        saveprocess(pnllauncherfilesavericon)

        saveprocess(pnltitlebargraphicpickericon)
        saveprocess(pnlpanelbuttongraphicpickericon)
        saveprocess(pnllaunchergraphicpickericon)

        saveprocess(pnltitlebarskinloadericon)
        saveprocess(pnlpanelbuttonskinloadericon)
        saveprocess(pnllauncherskinloadericon)

        saveprocess(pnltitlebarartpadicon)
        saveprocess(pnlpanelbuttonartpadicon)
        saveprocess(pnllauncherartpadicon)

        saveprocess(pnltitlebarcalculatoricon)
        saveprocess(pnlpanelbuttoncalculatoricon)
        saveprocess(pnllaunchercalculatoricon)

        saveprocess(pnltitlebaraudioplayericon)
        saveprocess(pnlpanelbuttonaudioplayericon)
        saveprocess(pnllauncheraudioplayericon)

        saveprocess(pnltitlebarwebbrowsericon)
        saveprocess(pnlpanelbuttonwebbrowsericon)
        saveprocess(pnllauncherwebbrowsericon)

        saveprocess(pnltitlebarvideoplayericon)
        saveprocess(pnlpanelbuttonvideoplayericon)
        saveprocess(pnllaunchervideoplayericon)

        saveprocess(pnltitlebarnamechangericon)
        saveprocess(pnlpanelbuttonnamechangericon)
        saveprocess(pnllaunchernamechangericon)

        saveprocess(pnltitlebariconmanagericon)
        saveprocess(pnlpanelbuttoniconmanagericon)
        saveprocess(pnllaunchericonmanagericon)

        saveprocess(pnltitlebarterminalicon)
        saveprocess(pnlpanelbuttonterminalicon)
        saveprocess(pnllauncherterminalicon)

        saveprocess(pnltitlebarbitnotewalleticon)
        saveprocess(pnlpanelbuttonbitnotewalleticon)
        saveprocess(pnllauncherbitnotewalleticon)

        saveprocess(pnltitlebarbitnotediggericon)
        saveprocess(pnlpanelbuttonbitnotediggericon)
        saveprocess(pnllauncherbitnotediggericon)

        saveprocess(pnltitlebarskinshiftericon)
        saveprocess(pnlpanelbuttonskinshiftericon)
        saveprocess(pnllauncherskinshiftericon)

        saveprocess(pnltitlebarshiftneticon)
        saveprocess(pnlpanelbuttonshiftneticon)
        saveprocess(pnllaunchershiftneticon)

        saveprocess(pnltitlebardodgeicon)
        saveprocess(pnlpanelbuttondodgeicon)
        saveprocess(pnllauncherdodgeicon)

        saveprocess(pnltitlebardownloadicon)
        saveprocess(pnlpanelbuttondownloadicon)
        saveprocess(pnllauncherdownloadicon)

        saveprocess(pnltitlebarinstallericon)
        saveprocess(pnlpanelbuttoninstallericon)
        saveprocess(pnllauncherinstallericon)

        saveprocess(pnltitlebarsysinfoicon)
        saveprocess(pnlpanelbuttonsysinfoicon)
        saveprocess(pnllaunchersysinfoicon)

        saveprocess(pnltitlebarorcwriteicon)
        saveprocess(pnlpanelbuttonorcwriteicon)
        saveprocess(pnllauncherorcwriteicon)

        saveprocess(pnltitlebarfloodgateicon)
        saveprocess(pnlpanelbuttonfloodgateicon)
        saveprocess(pnllauncherfloodgateicon)

        saveprocess(pnltitlebarmazeicon)
        saveprocess(pnlpanelbuttonmazeicon)
        saveprocess(pnllaunchermazeicon)

        saveprocess(pnltitlebarvirusscannericon)
        saveprocess(pnlpanelbuttonvirusscannericon)
        saveprocess(pnllaunchervirusscannericon)

        saveprocess(pnllaunchershutdownicon)
    End Sub

    Public Sub saveprocess(ByVal panel As Panel)
        panel.BackgroundImage.Save(ShiftOSPath + "Shiftum42\Icons\" & panel.Name.Substring(3) & ".pic", Imaging.ImageFormat.Png)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If unsavedchanges = False Then
            File_Saver.savingprogram = "iconmanager"
            File_Saver.saveextention = ".icp"
            File_Saver.Show()
        Else
            infobox.title = "Icon Manager - Error!"
            infobox.textinfo = "You must apply the changes to your system before saving the icon pack as a file." & Environment.NewLine & Environment.NewLine & "Please click the apply button first before attempting to save again."
            infobox.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        File_Opener.Show()
        File_Opener.openingprogram = "iconmanagerpack"
        File_Opener.openextention = ".icp"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub
End Class