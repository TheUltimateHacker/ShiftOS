Public Class Graphic_Picker
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0
    Public ShiftOSPath As String = "C:\ShiftOS"

    Public graphictochange
    Dim imagestyle As ImageLayout = ImageLayout.Stretch
    Dim images(2) As Image
    Public imagelocations(2) As String
    Dim skinimages(100) As String
    Dim firstrun As Boolean = True
#Region "Template Code"
    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        GC.Collect()
        'ShiftOSDesktop.setcolours()
        If ShiftOSDesktop.GraphicPickerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttongraphicpicker.SendToBack()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttongraphicpicker, ShiftOSDesktop.tbgraphicpickericon, ShiftOSDesktop.tbgraphicpickertext, True)
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        Array.Copy(Shifter.shifterskinimages, skinimages, Shifter.shifterskinimages.Length)
        'For a = 0 To skinimages.Length - 1
        '    skinimages(a) = Shifter.shifterskinimages(a).Clone
        'Next

        setupgraphics()

        If ShiftOSDesktop.boughtskinstates = False Then
            picmouseover.Hide()
            txtmouseoverfile.Hide()
            Label3.Hide()
            btnmouseoverbrowse.Hide()
            picmousedown.Hide()
            Label4.Hide()
            txtmousedownfile.Hide()
            btnmousedownbrowse.Hide()
            Me.Height = Me.Height - 150
        End If
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
            Me.Size = New Size(390, 570) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.graphicpickername 'Remember to change to name of program!!!!
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
        If ShiftOSDesktop.boughtcolourpickericon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.graphicpickericontitlebar  'Replace with the correct icon for the program.
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

    Private Sub setupgraphics()
        lblobjecttoskin.Text = graphictochange
        picgraphic.Dock = DockStyle.None

        Select Case graphictochange
            Case "Shutdown Button Background"
                setpreviewsizes(Shifter.startWidth, Shifter.startHeight, Shifter.skinshutdownbutton, Shifter.pwrbglayout, 51, 52, 53)
            Case "Username Panel Background"
                setpreviewsizes(Shifter.startWidth, Shifter.startHeight, Shifter.skinuserpanel, Shifter.usrbglayout, 48, 49, 50)
            Case "Close Button"
                setpreviewsizes(Shifter.closebuttonwidth, Shifter.closebuttonheight, Shifter.skinclosebutton, Shifter.skinclosebuttonstyle, 0, 1, 2)
            Case "Title Bar"
                setpreviewsizes(pnlgraphicholder.Width, Shifter.titlebarheight, Shifter.shifterskintitlebar, Shifter.skintitlebarstyle, 3, 4, 5)
            Case "Desktop Background"
                setpreviewsizes(pnlgraphicholder.Width, picgraphic.Height, Shifter.skindesktopbackground, Shifter.skindesktopbackgroundstyle, 6, 7, 8)
            Case "Roll Up Button"
                setpreviewsizes(Shifter.rollupbuttonwidth, Shifter.rollupbuttonheight, Shifter.skinrollupbutton, Shifter.skinrollupbuttonstyle, 9, 10, 11)
            Case "Title Bar Right Corner"
                setpreviewsizes(Shifter.titlebarcornerwidth, Shifter.titlebarheight, Shifter.skintitlebarrightcorner, Shifter.skintitlebarrightcornerstyle, 12, 13, 14)
            Case "Title Bar Left Corner"
                setpreviewsizes(Shifter.titlebarcornerwidth, Shifter.titlebarheight, Shifter.skintitlebarleftcorner, Shifter.skintitlebarleftcornerstyle, 15, 16, 17)
            Case "Desktop Panel"
                setpreviewsizes(pnlgraphicholder.Width, Shifter.desktoppanelheight, Shifter.skindesktoppanel, Shifter.skindesktoppanelstyle, 18, 19, 20)
            Case "Desktop Clock"
                setpreviewsizes(Shifter.pretimepanel.Width, Shifter.desktoppanelheight, Shifter.skindesktoppaneltime, Shifter.skindesktoppaneltimestyle, 21, 22, 23)
            Case "App Launcher Button"
                setpreviewsizes(Shifter.applaunchermenuholderwidth, Shifter.applicationbuttonheight, Shifter.skinapplauncherbutton, Shifter.skinapplauncherbuttonstyle, 24, 25, 26)
            Case "Border Left"
                setpreviewsizes(Shifter.windowbordersize, picgraphic.Height, Shifter.skinwindowborderleft, Shifter.skinwindowborderleftstyle, 27, 28, 29)
            Case "Border Right"
                setpreviewsizes(Shifter.windowbordersize, picgraphic.Height, Shifter.skinwindowborderright, Shifter.skinwindowborderrightstyle, 30, 31, 32)
            Case "Border Bottom"
                setpreviewsizes(picgraphic.Width, Shifter.windowbordersize, Shifter.skinwindowborderbottom, Shifter.skinwindowborderbottomstyle, 33, 34, 35)
            Case "Border Bottom Right"
                setpreviewsizes(Shifter.windowbordersize, Shifter.windowbordersize, Shifter.skinwindowborderbottomright, Shifter.skinwindowborderbottomrightstyle, 36, 37, 38)
            Case "Border Bottom Left"
                setpreviewsizes(Shifter.windowbordersize, Shifter.windowbordersize, Shifter.skinwindowborderbottomleft, Shifter.skinwindowborderbottomleftstyle, 39, 40, 41)
            Case "Minimize Button"
                setpreviewsizes(Shifter.minimizebuttonwidth, Shifter.minimizebuttonheight, Shifter.skinminimizebutton, Shifter.skinminimizebuttonstyle, 42, 43, 44)
            Case "Panel Button"
                setpreviewsizes(Shifter.panelbuttonwidth, Shifter.panelbuttonheight, Shifter.skinpanelbutton, Shifter.skinpanelbuttonstyle, 45, 46, 47)
        End Select

        setbuttongraphics()
    End Sub

    Private Sub btnapply_Click(sender As Object, e As EventArgs) Handles btnapply.Click
        Select Case graphictochange
            Case "Shutdown Button Background"
                Array.Copy(images, Shifter.skinshutdownbutton, Shifter.pwrbglayout)
                Shifter.skinshutdownbutton(0) = Image.FromFile(imagelocations(0).Clone)
                Shifter.pwrbglayout = imagestyle
            Case "Username Panel Background"
                Array.Copy(images, Shifter.skinuserpanel, Shifter.usrbglayout)
                Shifter.skinuserpanel(0) = Image.FromFile(imagelocations(0).Clone)
                Shifter.usrbglayout = imagestyle
            Case "Close Button"
                Array.Copy(images, Shifter.skinclosebutton, Shifter.skinclosebutton.Length)
                Shifter.shifterskinimages(0) = imagelocations(0).Clone
                Shifter.shifterskinimages(1) = imagelocations(1).Clone
                Shifter.shifterskinimages(2) = imagelocations(2).Clone
                Shifter.skinclosebuttonstyle = imagestyle
            Case "Title Bar"
                Array.Copy(images, Shifter.shifterskintitlebar, Shifter.shifterskintitlebar.Length)
                Shifter.shifterskinimages(3) = imagelocations(0).Clone
                Shifter.shifterskinimages(4) = imagelocations(1).Clone
                Shifter.shifterskinimages(5) = imagelocations(2).Clone
                Shifter.skintitlebarstyle = imagestyle
            Case "Desktop Background"
                Array.Copy(images, Shifter.skindesktopbackground, Shifter.skindesktopbackground.Length)
                If Not imagelocations(0) = "" Then Shifter.shifterskinimages(6) = imagelocations(0).Clone
                If Not imagelocations(1) = "" Then Shifter.shifterskinimages(7) = imagelocations(1).Clone
                If Not imagelocations(2) = "" Then Shifter.shifterskinimages(8) = imagelocations(2).Clone
                Shifter.skindesktopbackgroundstyle = imagestyle
            Case "Roll Up Button"
                Array.Copy(images, Shifter.skinrollupbutton, Shifter.skinrollupbutton.Length)
                Shifter.shifterskinimages(9) = imagelocations(0).Clone
                Shifter.shifterskinimages(10) = imagelocations(1).Clone
                Shifter.shifterskinimages(11) = imagelocations(2).Clone
                Shifter.skinrollupbuttonstyle = imagestyle
            Case "Title Bar Right Corner"
                Array.Copy(images, Shifter.skintitlebarrightcorner, Shifter.skintitlebarrightcorner.Length)
                Shifter.shifterskinimages(12) = imagelocations(0).Clone
                Shifter.shifterskinimages(13) = imagelocations(1).Clone
                Shifter.shifterskinimages(14) = imagelocations(2).Clone
                Shifter.skintitlebarrightcornerstyle = imagestyle
            Case "Title Bar Left Corner"
                Array.Copy(images, Shifter.skintitlebarleftcorner, Shifter.skintitlebarleftcorner.Length)
                Shifter.shifterskinimages(15) = imagelocations(0).Clone
                Shifter.shifterskinimages(16) = imagelocations(1).Clone
                Shifter.shifterskinimages(17) = imagelocations(2).Clone
                Shifter.skintitlebarleftcornerstyle = imagestyle
            Case "Desktop Panel"
                Array.Copy(images, Shifter.skindesktoppanel, Shifter.skindesktoppanel.Length)
                Shifter.shifterskinimages(18) = imagelocations(0).Clone
                Shifter.shifterskinimages(19) = imagelocations(1).Clone
                Shifter.shifterskinimages(20) = imagelocations(2).Clone
                Shifter.skindesktoppanelstyle = imagestyle
            Case "Clock Background"
                Array.Copy(images, Shifter.skindesktoppaneltime, Shifter.skindesktoppaneltime.Length)
                Shifter.shifterskinimages(21) = imagelocations(0).Clone
                Shifter.shifterskinimages(22) = imagelocations(1).Clone
                Shifter.shifterskinimages(23) = imagelocations(2).Clone
                Shifter.skindesktoppaneltimestyle = imagestyle
            Case "App Launcher Button"
                Array.Copy(images, Shifter.skinapplauncherbutton, Shifter.skinapplauncherbutton.Length)
                Shifter.shifterskinimages(24) = imagelocations(0).Clone
                Shifter.shifterskinimages(25) = imagelocations(1).Clone
                Shifter.shifterskinimages(26) = imagelocations(2).Clone
                Shifter.skinapplauncherbuttonstyle = imagestyle
            Case "Border Left"
                Array.Copy(images, Shifter.skinwindowborderleft, Shifter.skinwindowborderleft.Length)
                Shifter.shifterskinimages(27) = imagelocations(0).Clone
                Shifter.shifterskinimages(28) = imagelocations(1).Clone
                Shifter.shifterskinimages(29) = imagelocations(2).Clone
                Shifter.skinwindowborderleftstyle = imagestyle
            Case "Border Right"
                Array.Copy(images, Shifter.skinwindowborderright, Shifter.skinwindowborderright.Length)
                Shifter.shifterskinimages(30) = imagelocations(0).Clone
                Shifter.shifterskinimages(31) = imagelocations(1).Clone
                Shifter.shifterskinimages(32) = imagelocations(2).Clone
                Shifter.skinwindowborderrightstyle = imagestyle
            Case "Border Bottom"
                Array.Copy(images, Shifter.skinwindowborderbottom, Shifter.skinwindowborderbottom.Length)
                Shifter.shifterskinimages(33) = imagelocations(0).Clone
                Shifter.shifterskinimages(34) = imagelocations(1).Clone
                Shifter.shifterskinimages(35) = imagelocations(2).Clone
                Shifter.skinwindowborderbottomstyle = imagestyle
            Case "Border Bottom Right"
                Array.Copy(images, Shifter.skinwindowborderbottomright, Shifter.skinwindowborderbottomright.Length)
                Shifter.shifterskinimages(36) = imagelocations(0).Clone
                Shifter.shifterskinimages(37) = imagelocations(1).Clone
                Shifter.shifterskinimages(38) = imagelocations(2).Clone
                Shifter.skinwindowborderbottomrightstyle = imagestyle
            Case "Border Bottom Left"
                Array.Copy(images, Shifter.skinwindowborderbottomleft, Shifter.skinwindowborderbottomleft.Length)
                Shifter.shifterskinimages(39) = imagelocations(0).Clone
                Shifter.shifterskinimages(40) = imagelocations(1).Clone
                Shifter.shifterskinimages(41) = imagelocations(2).Clone
                Shifter.skinwindowborderbottomleftstyle = imagestyle
            Case "Minimize Button"
                Array.Copy(images, Shifter.skinminimizebutton, Shifter.skinminimizebutton.Length)
                Shifter.shifterskinimages(42) = imagelocations(0).Clone
                Shifter.shifterskinimages(43) = imagelocations(1).Clone
                Shifter.shifterskinimages(44) = imagelocations(2).Clone
                Shifter.skinminimizebuttonstyle = imagestyle
            Case "Panel Button"
                Array.Copy(images, Shifter.skinpanelbutton, Shifter.skinpanelbutton.Length)
                Shifter.shifterskinimages(45) = imagelocations(0).Clone
                Shifter.shifterskinimages(46) = imagelocations(1).Clone
                Shifter.shifterskinimages(47) = imagelocations(2).Clone
                Shifter.skinpanelbuttonstyle = imagestyle
        End Select

        Shifter.setuppreshifterstuff()

        Me.Close()
    End Sub

    Private Sub setpreviewsizes(ByVal width As Integer, ByVal height As Integer, ByVal skinwhat As Array, ByVal skinstyle As ImageLayout, ByVal imagenumber1 As Integer, ByVal imagenumber2 As Integer, ByVal imagenumber3 As Integer)
        ReDim Preserve skinimages(200)
        picgraphic.Size = New Size(width, height)

        Array.Copy(images, skinwhat, skinwhat.Length)
        'For a = 0 To skinwhat.Length - 1
        '    skinwhat(a) = images(a).Clone
        'Next

        If firstrun = True Then
            firstrun = False

            GC.Collect()

            'fix a hang issue when the image isn't changed
            ' If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Skins\Temp") Then My.Computer.FileSystem.DeleteDirectory(ShiftOSPath + "Shiftum42\Skins\Temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If skinimages(imagenumber1) = "" Then
            Else
                Try
                    My.Computer.FileSystem.CopyFile(skinimages(imagenumber1), ShiftOSPath + "Shiftum42\Skins\Temp\" & skinimages(imagenumber1).Substring(skinimages(imagenumber1).LastIndexOf("\")), True)
                    skinimages(imagenumber1) = ShiftOSPath + "Shiftum42\Skins\Temp" & skinimages(imagenumber1).Substring(skinimages(imagenumber1).LastIndexOf("\"))
                    skinimages(imagenumber2) = ShiftOSPath + "Shiftum42\Skins\Temp" & skinimages(imagenumber1).Substring(skinimages(imagenumber1).LastIndexOf("\"))
                    skinimages(imagenumber3) = ShiftOSPath + "Shiftum42\Skins\Temp" & skinimages(imagenumber1).Substring(skinimages(imagenumber1).LastIndexOf("\"))
                Catch ex As Exception
                    'infobox.showinfo("Error", "An internal error has occured with ShiftOS, please alert DevX")
                End Try
            End If

            GC.Collect()

            imagelocations(0) = skinimages(imagenumber1)
            If imagelocations(0) = Nothing Then
            Else
                picgraphic.BackgroundImage = Image.FromFile(imagelocations(0))
                picidle.BackgroundImage = Image.FromFile(imagelocations(0))
                images(0) = Image.FromFile(imagelocations(0))
                txtidlefile.Text = imagelocations(0).Substring(imagelocations(0).LastIndexOf("/") + 1)
            End If

            imagelocations(1) = skinimages(imagenumber2)
            If imagelocations(1) = Nothing Then
            Else
                picgraphic.BackgroundImage = Image.FromFile(imagelocations(1))
                picmouseover.BackgroundImage = Image.FromFile(imagelocations(1))
                images(1) = Image.FromFile(imagelocations(1))
                txtmouseoverfile.Text = imagelocations(1).Substring(imagelocations(1).LastIndexOf("/") + 1)
            End If

            imagelocations(2) = skinimages(imagenumber3)
            If imagelocations(2) = Nothing Then
            Else
                picgraphic.BackgroundImage = Image.FromFile(imagelocations(2))
                picmousedown.BackgroundImage = Image.FromFile(imagelocations(2))
                images(2) = Image.FromFile(imagelocations(2))
                txtmousedownfile.Text = imagelocations(2).Substring(imagelocations(2).LastIndexOf("/") + 1)
                imagestyle = skinstyle
            End If
        End If

        If picgraphic.Height > 100 Then
            picgraphic.Dock = DockStyle.Fill
            picgraphic.BackgroundImageLayout = ImageLayout.Stretch
        Else
            picgraphic.Location = New Point((pnlgraphicholder.Width / 2) - (picgraphic.Width / 2), (pnlgraphicholder.Height / 2) - (picgraphic.Height / 2))
            picgraphic.BackgroundImageLayout = imagestyle
        End If

        If imagelocations(0) = "" Then  Else picgraphic.BackgroundImage = Image.FromFile(imagelocations(0))
    End Sub

    Private Sub cloneidle()
        txtmouseoverfile.Text = txtidlefile.Text
        picmouseover.BackgroundImage = Image.FromFile(imagelocations(0))
        images(1) = Image.FromFile(imagelocations(0))
        imagelocations(1) = imagelocations(0)
        txtmousedownfile.Text = txtidlefile.Text
        picmousedown.BackgroundImage = Image.FromFile(imagelocations(0))
        images(2) = Image.FromFile(imagelocations(0))
        imagelocations(2) = imagelocations(0)
    End Sub

    Private Sub btnidlebrowse_Click(sender As Object, e As EventArgs) Handles btnidlebrowse.Click
        File_Opener.Show() ' I moved this from the bottom at 3:13pm 24.05.14
        File_Opener.openingprogram = "graphicpicker1"
        File_Opener.openextention = ".pic"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub

    Private Sub btnmouseoverbrowse_Click(sender As Object, e As EventArgs) Handles btnmouseoverbrowse.Click
        File_Opener.Show()
        File_Opener.openingprogram = "graphicpicker2"
        File_Opener.openextention = ".pic"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub

    Private Sub btnmousedownbrowse_Click(sender As Object, e As EventArgs) Handles btnmousedownbrowse.Click
        File_Opener.Show()
        File_Opener.openingprogram = "graphicpicker3"
        File_Opener.openextention = ".pic"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub

    Public Sub setgraphicsidle()
        picgraphic.BackgroundImage = Image.FromFile(imagelocations(0))
        picidle.BackgroundImage = Image.FromFile(imagelocations(0))
        images(0) = Image.FromFile(imagelocations(0))
        cloneidle()
        setupgraphics()
    End Sub

    Public Sub setgraphicsmouseover()
        picgraphic.BackgroundImage = Image.FromFile(imagelocations(1))
        picmouseover.BackgroundImage = Image.FromFile(imagelocations(1))
        images(1) = Image.FromFile(imagelocations(1))
        setupgraphics()
    End Sub

    Public Sub setgraphicsmousedown()
        picgraphic.BackgroundImage = Image.FromFile(imagelocations(2))
        picmousedown.BackgroundImage = Image.FromFile(imagelocations(2))
        images(2) = Image.FromFile(imagelocations(2))
        setupgraphics()
    End Sub

    Private Sub btntile_Click(sender As Object, e As EventArgs) Handles btntile.Click
        imagestyle = ImageLayout.Tile
        setupgraphics()
    End Sub

    Private Sub btncentre_Click(sender As Object, e As EventArgs) Handles btncentre.Click
        imagestyle = ImageLayout.Center
        setupgraphics()
    End Sub

    Private Sub btnstretch_Click(sender As Object, e As EventArgs) Handles btnstretch.Click
        imagestyle = ImageLayout.Stretch
        setupgraphics()
    End Sub

    Private Sub btnzoom_Click(sender As Object, e As EventArgs) Handles btnzoom.Click
        imagestyle = ImageLayout.Zoom
        setupgraphics()
    End Sub

    Private Sub setbuttongraphics()
        Select Case imagestyle
            Case ImageLayout.Tile
                setblankbuttons()
                btntile.BackgroundImage = My.Resources.tilebuttonpressed
            Case ImageLayout.Center
                setblankbuttons()
                btncentre.BackgroundImage = My.Resources.centrebuttonpressed
            Case ImageLayout.Stretch
                setblankbuttons()
                btnstretch.BackgroundImage = My.Resources.stretchbuttonpressed
            Case ImageLayout.Zoom
                setblankbuttons()
                btnzoom.BackgroundImage = My.Resources.zoombuttonpressed
        End Select
    End Sub

    Private Sub setblankbuttons()
        btntile.BackgroundImage = My.Resources.tilebutton
        btncentre.BackgroundImage = My.Resources.centrebutton
        btnstretch.BackgroundImage = My.Resources.stretchbutton
        btnzoom.BackgroundImage = My.Resources.zoombutton
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        picgraphic.BackgroundImage.Dispose()
        picidle.BackgroundImage.Dispose()
        picmousedown.BackgroundImage.Dispose()
        picmouseover.BackgroundImage.Dispose()
        picgraphic.BackgroundImage = Nothing
        picidle.BackgroundImage = Nothing
        picmousedown.BackgroundImage = Nothing
        picmouseover.BackgroundImage = Nothing
        images(0).Dispose()
        images(1).Dispose()
        images(2).Dispose()
        images(0) = Nothing
        images(1) = Nothing
        images(2) = Nothing
        GC.Collect()
        imagelocations(0) = ""
        imagelocations(1) = ""
        imagelocations(2) = ""
        txtidlefile.Text = ""
        txtmousedownfile.Text = ""
        txtmouseoverfile.Text = ""
        setupgraphics()
    End Sub
End Class