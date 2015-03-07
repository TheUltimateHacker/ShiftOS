Public Class Icon_Manager
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0   'replace with minimum size
    Public minimumsizeheight As Integer = 0  'replace with minimum size

    Public openedfilelocation As String
    Public icontochange As Object
    Public over64 As Boolean = False
    Public needtosetupdesktop As Boolean = False
    Public savelines(50) As String
    Public unsavedchanges As Boolean = False

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()

        ShiftOSDesktop.pnlpanelbuttonclock.SendToBack() 'modfiy to proper name
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonshiftorium, ShiftOSDesktop.tbshiftoriumicon, ShiftOSDesktop.tbshiftoriumtext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        loadsettings()
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
            Me.Size = New Size(400, 500) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.iconmanagername  'Remember to change to name of program!!!!
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

    Private Sub resettitlebar()
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

        checkbackgroundimagesize()

        If needtosetupdesktop = True Then
            ShiftOSDesktop.setupalltitlebars()
            ShiftOSDesktop.setuppanelbuttons()
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

        ShiftOSDesktop.shutdowniconlauncher = pnllaunchershutdownicon.BackgroundImage.Clone

        ShiftOSDesktop.setupalltitlebars()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setupdesktop()
        If Name_Changer.Visible = True Then Name_Changer.loadicons()

        While My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Icons")
            Try
                If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Icons") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Icons", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
            End Try
        End While

        My.Computer.FileSystem.CreateDirectory("C:\ShiftOS\Shiftum42\Icons")

        savelines(0) = ShiftOSDesktop.titlebariconsize
        savelines(1) = ShiftOSDesktop.panelbuttoniconsize
        savelines(2) = ShiftOSDesktop.launchericonsize
        IO.File.WriteAllLines("C:\ShiftOS\Shiftum42\Icons\icondata.dat", savelines)

        saveappliedicons()
    End Sub

    Private Sub ChangeImage(sender As Object, e As MouseEventArgs) Handles pnltitlebarknowledgeinputicon.MouseClick, pnlpanelbuttonknowledgeinputicon.MouseClick, pnllauncherknowledgeinputicon.MouseClick, pnltitlebarshiftoriumicon.MouseClick, pnlpanelbuttonshiftoriumicon.MouseClick, pnllaunchershiftoriumicon.MouseClick, pnltitlebarclockicon.MouseClick, pnlpanelbuttonclockicon.MouseClick, pnllauncherclockicon.MouseClick, pnltitlebarshiftericon.MouseClick, pnlpanelbuttonshiftericon.MouseClick, pnllaunchershiftericon.MouseClick, pnltitlebarcolourpickericon.MouseClick, pnlpanelbuttoncolourpickericon.MouseClick, pnllaunchercolourpickericon.MouseClick, pnltitlebarinfoboxicon.MouseClick, pnlpanelbuttoninfoboxicon.MouseClick, pnllauncherinfoboxicon.MouseClick, pnltitlebarpongicon.MouseClick, pnlpanelbuttonpongicon.MouseClick, pnllauncherpongicon.MouseClick, pnltitlebarfileskimmericon.MouseClick, pnlpanelbuttonfileskimmericon.MouseClick, pnllauncherfileskimmericon.MouseClick, pnltitlebartextpadicon.MouseClick, pnlpanelbuttontextpadicon.MouseClick, pnllaunchertextpadicon.MouseClick, pnltitlebarfileopenericon.MouseClick, pnlpanelbuttonfileopenericon.MouseClick, pnllauncherfileopenericon.MouseClick, pnltitlebarfilesavericon.MouseClick, pnlpanelbuttonfilesavericon.MouseClick, pnllauncherfilesavericon.MouseClick, pnltitlebargraphicpickericon.MouseClick, pnlpanelbuttongraphicpickericon.MouseClick, pnllaunchergraphicpickericon.MouseClick, pnltitlebarskinloadericon.MouseClick, pnlpanelbuttonskinloadericon.MouseClick, pnllauncherskinloadericon.MouseClick, pnltitlebarartpadicon.MouseClick, pnlpanelbuttonartpadicon.MouseClick, pnllauncherartpadicon.MouseClick, pnltitlebarcalculatoricon.MouseClick, pnlpanelbuttoncalculatoricon.MouseClick, pnllaunchercalculatoricon.MouseClick, pnltitlebaraudioplayericon.MouseClick, pnlpanelbuttonaudioplayericon.MouseClick, pnllauncheraudioplayericon.MouseClick, pnltitlebarwebbrowsericon.MouseClick, pnlpanelbuttonwebbrowsericon.MouseClick, pnllauncherwebbrowsericon.MouseClick, pnltitlebarvideoplayericon.MouseClick, pnlpanelbuttonvideoplayericon.MouseClick, pnllaunchervideoplayericon.MouseClick, pnltitlebarnamechangericon.MouseClick, pnlpanelbuttonnamechangericon.MouseClick, pnllaunchernamechangericon.MouseClick, pnltitlebariconmanagericon.MouseClick, pnlpanelbuttoniconmanagericon.MouseClick, pnllaunchericonmanagericon.MouseClick, pnltitlebarterminalicon.MouseClick, pnlpanelbuttonterminalicon.MouseClick, pnllauncherterminalicon.MouseClick, pnllaunchershutdownicon.MouseClick
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
            icontochange.backgroundimagelayout = BackgroundImageLayout.Stretch
            over64 = False
        Else
            icontochange.backgroundimagelayout = BackgroundImageLayout.Center
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

        ShiftOSDesktop.shutdowniconlauncher = My.Resources.iconshutdown

        ShiftOSDesktop.setupalltitlebars()
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

        saveprocess(pnllaunchershutdownicon)
    End Sub

    Public Sub saveprocess(ByVal panel As Panel)
        panel.BackgroundImage.Save("C:\ShiftOS\Shiftum42\Icons\" & panel.Name.Substring(3) & ".pic", Imaging.ImageFormat.Png)
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