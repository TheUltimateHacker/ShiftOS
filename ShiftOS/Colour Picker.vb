Public Class Colour_Picker
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Public oldcolour As Color

    Public colourtochange As String
    Public anylevel As Integer
    Public graylevel As Integer
    Public purplelevel As Integer
    Public bluelevel As Integer
    Public greenlevel As Integer
    Public yellowlevel As Integer
    Public orangelevel As Integer
    Public brownlevel As Integer
    Public redlevel As Integer
    Public pinklevel As Integer

    Public sendToMod = False ' If true will output the rgb value for use of mod

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.ColourPickerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttoncolourpicker.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttoncolourpicker, ShiftOSDesktop.tbcolourpickericon, ShiftOSDesktop.tbcolourpickertext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        getoldcolour()
        determinelevels()
        shrinktosizebasedoncoloursbought()
        setupboughtcolours()
        loadmemory()
        'ShiftOSDesktop.setcolours()
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
            Me.Size = New Size(447, 600) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.colourpickername 'Remember to change to name of program!!!!
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
            pnlicon.Location = New Point(Skins.titleiconfromside, Skins.titleiconfromtop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.colourpickericontitlebar  'Replace with the correct icon for the program.
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

        'Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour
    End Sub

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
            Me.Hide()
            ShiftOSDesktop.setuppanelbuttons()
        Catch
        End Try
    End Sub

    'end of general setup
#End Region

    Public Sub loadmemory()
        If ShiftOSDesktop.anymemory(0).ToArgb.ToString = "0" Then  Else pnlany1.BackColor = ShiftOSDesktop.anymemory(0)
        If ShiftOSDesktop.anymemory(1).ToArgb.ToString = "0" Then  Else pnlany2.BackColor = ShiftOSDesktop.anymemory(1)
        If ShiftOSDesktop.anymemory(2).ToArgb.ToString = "0" Then  Else pnlany3.BackColor = ShiftOSDesktop.anymemory(2)
        If ShiftOSDesktop.anymemory(3).ToArgb.ToString = "0" Then  Else pnlany4.BackColor = ShiftOSDesktop.anymemory(3)
        If ShiftOSDesktop.anymemory(4).ToArgb.ToString = "0" Then  Else pnlany5.BackColor = ShiftOSDesktop.anymemory(4)
        If ShiftOSDesktop.anymemory(5).ToArgb.ToString = "0" Then  Else pnlany6.BackColor = ShiftOSDesktop.anymemory(5)
        If ShiftOSDesktop.anymemory(6).ToArgb.ToString = "0" Then  Else pnlany7.BackColor = ShiftOSDesktop.anymemory(6)
        If ShiftOSDesktop.anymemory(7).ToArgb.ToString = "0" Then  Else pnlany8.BackColor = ShiftOSDesktop.anymemory(7)
        If ShiftOSDesktop.anymemory(8).ToArgb.ToString = "0" Then  Else pnlany9.BackColor = ShiftOSDesktop.anymemory(8)
        If ShiftOSDesktop.anymemory(9).ToArgb.ToString = "0" Then  Else pnlany10.BackColor = ShiftOSDesktop.anymemory(9)
        If ShiftOSDesktop.anymemory(10).ToArgb.ToString = "0" Then  Else pnlany11.BackColor = ShiftOSDesktop.anymemory(10)
        If ShiftOSDesktop.anymemory(11).ToArgb.ToString = "0" Then  Else pnlany12.BackColor = ShiftOSDesktop.anymemory(11)
        If ShiftOSDesktop.anymemory(12).ToArgb.ToString = "0" Then  Else pnlany13.BackColor = ShiftOSDesktop.anymemory(12)
        If ShiftOSDesktop.anymemory(13).ToArgb.ToString = "0" Then  Else pnlany14.BackColor = ShiftOSDesktop.anymemory(13)
        If ShiftOSDesktop.anymemory(14).ToArgb.ToString = "0" Then  Else pnlany15.BackColor = ShiftOSDesktop.anymemory(14)
        If ShiftOSDesktop.anymemory(15).ToArgb.ToString = "0" Then  Else pnlany16.BackColor = ShiftOSDesktop.anymemory(15)

        If ShiftOSDesktop.graymemory(0).ToArgb.ToString = "0" Then  Else pnlgray1.BackColor = ShiftOSDesktop.graymemory(0)
        If ShiftOSDesktop.graymemory(1).ToArgb.ToString = "0" Then  Else pnlgray2.BackColor = ShiftOSDesktop.graymemory(1)
        If ShiftOSDesktop.graymemory(2).ToArgb.ToString = "0" Then  Else pnlgray3.BackColor = ShiftOSDesktop.graymemory(2)
        If ShiftOSDesktop.graymemory(3).ToArgb.ToString = "0" Then  Else pnlgray4.BackColor = ShiftOSDesktop.graymemory(3)
        If ShiftOSDesktop.graymemory(4).ToArgb.ToString = "0" Then  Else pnlgray5.BackColor = ShiftOSDesktop.graymemory(4)
        If ShiftOSDesktop.graymemory(5).ToArgb.ToString = "0" Then  Else pnlgray6.BackColor = ShiftOSDesktop.graymemory(5)
        If ShiftOSDesktop.graymemory(6).ToArgb.ToString = "0" Then  Else pnlgray7.BackColor = ShiftOSDesktop.graymemory(6)
        If ShiftOSDesktop.graymemory(7).ToArgb.ToString = "0" Then  Else pnlgray8.BackColor = ShiftOSDesktop.graymemory(7)
        If ShiftOSDesktop.graymemory(8).ToArgb.ToString = "0" Then  Else pnlgray9.BackColor = ShiftOSDesktop.graymemory(8)
        If ShiftOSDesktop.graymemory(9).ToArgb.ToString = "0" Then  Else pnlgray10.BackColor = ShiftOSDesktop.graymemory(9)
        If ShiftOSDesktop.graymemory(10).ToArgb.ToString = "0" Then  Else pnlgray11.BackColor = ShiftOSDesktop.graymemory(10)
        If ShiftOSDesktop.graymemory(11).ToArgb.ToString = "0" Then  Else pnlgray12.BackColor = ShiftOSDesktop.graymemory(11)
        If ShiftOSDesktop.graymemory(12).ToArgb.ToString = "0" Then  Else pnlgray13.BackColor = ShiftOSDesktop.graymemory(12)
        If ShiftOSDesktop.graymemory(13).ToArgb.ToString = "0" Then  Else pnlgray14.BackColor = ShiftOSDesktop.graymemory(13)
        If ShiftOSDesktop.graymemory(14).ToArgb.ToString = "0" Then  Else pnlgray15.BackColor = ShiftOSDesktop.graymemory(14)
        If ShiftOSDesktop.graymemory(15).ToArgb.ToString = "0" Then  Else pnlgray16.BackColor = ShiftOSDesktop.graymemory(15)

        If ShiftOSDesktop.purplememory(0).ToArgb.ToString = "0" Then  Else pnlpurple1.BackColor = ShiftOSDesktop.purplememory(0)
        If ShiftOSDesktop.purplememory(1).ToArgb.ToString = "0" Then  Else pnlpurple2.BackColor = ShiftOSDesktop.purplememory(1)
        If ShiftOSDesktop.purplememory(2).ToArgb.ToString = "0" Then  Else pnlpurple3.BackColor = ShiftOSDesktop.purplememory(2)
        If ShiftOSDesktop.purplememory(3).ToArgb.ToString = "0" Then  Else pnlpurple4.BackColor = ShiftOSDesktop.purplememory(3)
        If ShiftOSDesktop.purplememory(4).ToArgb.ToString = "0" Then  Else pnlpurple5.BackColor = ShiftOSDesktop.purplememory(4)
        If ShiftOSDesktop.purplememory(5).ToArgb.ToString = "0" Then  Else pnlpurple6.BackColor = ShiftOSDesktop.purplememory(5)
        If ShiftOSDesktop.purplememory(6).ToArgb.ToString = "0" Then  Else pnlpurple7.BackColor = ShiftOSDesktop.purplememory(6)
        If ShiftOSDesktop.purplememory(7).ToArgb.ToString = "0" Then  Else pnlpurple8.BackColor = ShiftOSDesktop.purplememory(7)
        If ShiftOSDesktop.purplememory(8).ToArgb.ToString = "0" Then  Else pnlpurple9.BackColor = ShiftOSDesktop.purplememory(8)
        If ShiftOSDesktop.purplememory(9).ToArgb.ToString = "0" Then  Else pnlpurple10.BackColor = ShiftOSDesktop.purplememory(9)
        If ShiftOSDesktop.purplememory(10).ToArgb.ToString = "0" Then  Else pnlpurple11.BackColor = ShiftOSDesktop.purplememory(10)
        If ShiftOSDesktop.purplememory(11).ToArgb.ToString = "0" Then  Else pnlpurple12.BackColor = ShiftOSDesktop.purplememory(11)
        If ShiftOSDesktop.purplememory(12).ToArgb.ToString = "0" Then  Else pnlpurple13.BackColor = ShiftOSDesktop.purplememory(12)
        If ShiftOSDesktop.purplememory(13).ToArgb.ToString = "0" Then  Else pnlpurple14.BackColor = ShiftOSDesktop.purplememory(13)
        If ShiftOSDesktop.purplememory(14).ToArgb.ToString = "0" Then  Else pnlpurple15.BackColor = ShiftOSDesktop.purplememory(14)
        If ShiftOSDesktop.purplememory(15).ToArgb.ToString = "0" Then  Else pnlpurple16.BackColor = ShiftOSDesktop.purplememory(15)

        If ShiftOSDesktop.bluememory(0).ToArgb.ToString = "0" Then  Else pnlblue1.BackColor = ShiftOSDesktop.bluememory(0)
        If ShiftOSDesktop.bluememory(1).ToArgb.ToString = "0" Then  Else pnlblue2.BackColor = ShiftOSDesktop.bluememory(1)
        If ShiftOSDesktop.bluememory(2).ToArgb.ToString = "0" Then  Else pnlblue3.BackColor = ShiftOSDesktop.bluememory(2)
        If ShiftOSDesktop.bluememory(3).ToArgb.ToString = "0" Then  Else pnlblue4.BackColor = ShiftOSDesktop.bluememory(3)
        If ShiftOSDesktop.bluememory(4).ToArgb.ToString = "0" Then  Else pnlblue5.BackColor = ShiftOSDesktop.bluememory(4)
        If ShiftOSDesktop.bluememory(5).ToArgb.ToString = "0" Then  Else pnlblue6.BackColor = ShiftOSDesktop.bluememory(5)
        If ShiftOSDesktop.bluememory(6).ToArgb.ToString = "0" Then  Else pnlblue7.BackColor = ShiftOSDesktop.bluememory(6)
        If ShiftOSDesktop.bluememory(7).ToArgb.ToString = "0" Then  Else pnlblue8.BackColor = ShiftOSDesktop.bluememory(7)
        If ShiftOSDesktop.bluememory(8).ToArgb.ToString = "0" Then  Else pnlblue9.BackColor = ShiftOSDesktop.bluememory(8)
        If ShiftOSDesktop.bluememory(9).ToArgb.ToString = "0" Then  Else pnlblue10.BackColor = ShiftOSDesktop.bluememory(9)
        If ShiftOSDesktop.bluememory(10).ToArgb.ToString = "0" Then  Else pnlblue11.BackColor = ShiftOSDesktop.bluememory(10)
        If ShiftOSDesktop.bluememory(11).ToArgb.ToString = "0" Then  Else pnlblue12.BackColor = ShiftOSDesktop.bluememory(11)
        If ShiftOSDesktop.bluememory(12).ToArgb.ToString = "0" Then  Else pnlblue13.BackColor = ShiftOSDesktop.bluememory(12)
        If ShiftOSDesktop.bluememory(13).ToArgb.ToString = "0" Then  Else pnlblue14.BackColor = ShiftOSDesktop.bluememory(13)
        If ShiftOSDesktop.bluememory(14).ToArgb.ToString = "0" Then  Else pnlblue15.BackColor = ShiftOSDesktop.bluememory(14)
        If ShiftOSDesktop.bluememory(15).ToArgb.ToString = "0" Then  Else pnlblue16.BackColor = ShiftOSDesktop.bluememory(15)

        If ShiftOSDesktop.greenmemory(0).ToArgb.ToString = "0" Then  Else pnlgreen1.BackColor = ShiftOSDesktop.greenmemory(0)
        If ShiftOSDesktop.greenmemory(1).ToArgb.ToString = "0" Then  Else pnlgreen2.BackColor = ShiftOSDesktop.greenmemory(1)
        If ShiftOSDesktop.greenmemory(2).ToArgb.ToString = "0" Then  Else pnlgreen3.BackColor = ShiftOSDesktop.greenmemory(2)
        If ShiftOSDesktop.greenmemory(3).ToArgb.ToString = "0" Then  Else pnlgreen4.BackColor = ShiftOSDesktop.greenmemory(3)
        If ShiftOSDesktop.greenmemory(4).ToArgb.ToString = "0" Then  Else pnlgreen5.BackColor = ShiftOSDesktop.greenmemory(4)
        If ShiftOSDesktop.greenmemory(5).ToArgb.ToString = "0" Then  Else pnlgreen6.BackColor = ShiftOSDesktop.greenmemory(5)
        If ShiftOSDesktop.greenmemory(6).ToArgb.ToString = "0" Then  Else pnlgreen7.BackColor = ShiftOSDesktop.greenmemory(6)
        If ShiftOSDesktop.greenmemory(7).ToArgb.ToString = "0" Then  Else pnlgreen8.BackColor = ShiftOSDesktop.greenmemory(7)
        If ShiftOSDesktop.greenmemory(8).ToArgb.ToString = "0" Then  Else pnlgreen9.BackColor = ShiftOSDesktop.greenmemory(8)
        If ShiftOSDesktop.greenmemory(9).ToArgb.ToString = "0" Then  Else pnlgreen10.BackColor = ShiftOSDesktop.greenmemory(9)
        If ShiftOSDesktop.greenmemory(10).ToArgb.ToString = "0" Then  Else pnlgreen11.BackColor = ShiftOSDesktop.greenmemory(10)
        If ShiftOSDesktop.greenmemory(11).ToArgb.ToString = "0" Then  Else pnlgreen12.BackColor = ShiftOSDesktop.greenmemory(11)
        If ShiftOSDesktop.greenmemory(12).ToArgb.ToString = "0" Then  Else pnlgreen13.BackColor = ShiftOSDesktop.greenmemory(12)
        If ShiftOSDesktop.greenmemory(13).ToArgb.ToString = "0" Then  Else pnlgreen14.BackColor = ShiftOSDesktop.greenmemory(13)
        If ShiftOSDesktop.greenmemory(14).ToArgb.ToString = "0" Then  Else pnlgreen15.BackColor = ShiftOSDesktop.greenmemory(14)
        If ShiftOSDesktop.greenmemory(15).ToArgb.ToString = "0" Then  Else pnlgreen16.BackColor = ShiftOSDesktop.greenmemory(15)

        If ShiftOSDesktop.yellowmemory(0).ToArgb.ToString = "0" Then  Else pnlyellow1.BackColor = ShiftOSDesktop.yellowmemory(0)
        If ShiftOSDesktop.yellowmemory(1).ToArgb.ToString = "0" Then  Else pnlyellow2.BackColor = ShiftOSDesktop.yellowmemory(1)
        If ShiftOSDesktop.yellowmemory(2).ToArgb.ToString = "0" Then  Else pnlyellow3.BackColor = ShiftOSDesktop.yellowmemory(2)
        If ShiftOSDesktop.yellowmemory(3).ToArgb.ToString = "0" Then  Else pnlyellow4.BackColor = ShiftOSDesktop.yellowmemory(3)
        If ShiftOSDesktop.yellowmemory(4).ToArgb.ToString = "0" Then  Else pnlyellow5.BackColor = ShiftOSDesktop.yellowmemory(4)
        If ShiftOSDesktop.yellowmemory(5).ToArgb.ToString = "0" Then  Else pnlyellow6.BackColor = ShiftOSDesktop.yellowmemory(5)
        If ShiftOSDesktop.yellowmemory(6).ToArgb.ToString = "0" Then  Else pnlyellow7.BackColor = ShiftOSDesktop.yellowmemory(6)
        If ShiftOSDesktop.yellowmemory(7).ToArgb.ToString = "0" Then  Else pnlyellow8.BackColor = ShiftOSDesktop.yellowmemory(7)
        If ShiftOSDesktop.yellowmemory(8).ToArgb.ToString = "0" Then  Else pnlyellow9.BackColor = ShiftOSDesktop.yellowmemory(8)
        If ShiftOSDesktop.yellowmemory(9).ToArgb.ToString = "0" Then  Else pnlyellow10.BackColor = ShiftOSDesktop.yellowmemory(9)
        If ShiftOSDesktop.yellowmemory(10).ToArgb.ToString = "0" Then  Else pnlyellow11.BackColor = ShiftOSDesktop.yellowmemory(10)
        If ShiftOSDesktop.yellowmemory(11).ToArgb.ToString = "0" Then  Else pnlyellow12.BackColor = ShiftOSDesktop.yellowmemory(11)
        If ShiftOSDesktop.yellowmemory(12).ToArgb.ToString = "0" Then  Else pnlyellow13.BackColor = ShiftOSDesktop.yellowmemory(12)
        If ShiftOSDesktop.yellowmemory(13).ToArgb.ToString = "0" Then  Else pnlyellow14.BackColor = ShiftOSDesktop.yellowmemory(13)
        If ShiftOSDesktop.yellowmemory(14).ToArgb.ToString = "0" Then  Else pnlyellow15.BackColor = ShiftOSDesktop.yellowmemory(14)
        If ShiftOSDesktop.yellowmemory(15).ToArgb.ToString = "0" Then  Else pnlyellow16.BackColor = ShiftOSDesktop.yellowmemory(15)

        If ShiftOSDesktop.orangememory(0).ToArgb.ToString = "0" Then  Else pnlorange1.BackColor = ShiftOSDesktop.orangememory(0)
        If ShiftOSDesktop.orangememory(1).ToArgb.ToString = "0" Then  Else pnlorange2.BackColor = ShiftOSDesktop.orangememory(1)
        If ShiftOSDesktop.orangememory(2).ToArgb.ToString = "0" Then  Else pnlorange3.BackColor = ShiftOSDesktop.orangememory(2)
        If ShiftOSDesktop.orangememory(3).ToArgb.ToString = "0" Then  Else pnlorange4.BackColor = ShiftOSDesktop.orangememory(3)
        If ShiftOSDesktop.orangememory(4).ToArgb.ToString = "0" Then  Else pnlorange5.BackColor = ShiftOSDesktop.orangememory(4)
        If ShiftOSDesktop.orangememory(5).ToArgb.ToString = "0" Then  Else pnlorange6.BackColor = ShiftOSDesktop.orangememory(5)
        If ShiftOSDesktop.orangememory(6).ToArgb.ToString = "0" Then  Else pnlorange7.BackColor = ShiftOSDesktop.orangememory(6)
        If ShiftOSDesktop.orangememory(7).ToArgb.ToString = "0" Then  Else pnlorange8.BackColor = ShiftOSDesktop.orangememory(7)
        If ShiftOSDesktop.orangememory(8).ToArgb.ToString = "0" Then  Else pnlorange9.BackColor = ShiftOSDesktop.orangememory(8)
        If ShiftOSDesktop.orangememory(9).ToArgb.ToString = "0" Then  Else pnlorange10.BackColor = ShiftOSDesktop.orangememory(9)
        If ShiftOSDesktop.orangememory(10).ToArgb.ToString = "0" Then  Else pnlorange11.BackColor = ShiftOSDesktop.orangememory(10)
        If ShiftOSDesktop.orangememory(11).ToArgb.ToString = "0" Then  Else pnlorange12.BackColor = ShiftOSDesktop.orangememory(11)
        If ShiftOSDesktop.orangememory(12).ToArgb.ToString = "0" Then  Else pnlorange13.BackColor = ShiftOSDesktop.orangememory(12)
        If ShiftOSDesktop.orangememory(13).ToArgb.ToString = "0" Then  Else pnlorange14.BackColor = ShiftOSDesktop.orangememory(13)
        If ShiftOSDesktop.orangememory(14).ToArgb.ToString = "0" Then  Else pnlorange15.BackColor = ShiftOSDesktop.orangememory(14)
        If ShiftOSDesktop.orangememory(15).ToArgb.ToString = "0" Then  Else pnlorange16.BackColor = ShiftOSDesktop.orangememory(15)

        If ShiftOSDesktop.brownmemory(0).ToArgb.ToString = "0" Then  Else pnlbrown1.BackColor = ShiftOSDesktop.brownmemory(0)
        If ShiftOSDesktop.brownmemory(1).ToArgb.ToString = "0" Then  Else pnlbrown2.BackColor = ShiftOSDesktop.brownmemory(1)
        If ShiftOSDesktop.brownmemory(2).ToArgb.ToString = "0" Then  Else pnlbrown3.BackColor = ShiftOSDesktop.brownmemory(2)
        If ShiftOSDesktop.brownmemory(3).ToArgb.ToString = "0" Then  Else pnlbrown4.BackColor = ShiftOSDesktop.brownmemory(3)
        If ShiftOSDesktop.brownmemory(4).ToArgb.ToString = "0" Then  Else pnlbrown5.BackColor = ShiftOSDesktop.brownmemory(4)
        If ShiftOSDesktop.brownmemory(5).ToArgb.ToString = "0" Then  Else pnlbrown6.BackColor = ShiftOSDesktop.brownmemory(5)
        If ShiftOSDesktop.brownmemory(6).ToArgb.ToString = "0" Then  Else pnlbrown7.BackColor = ShiftOSDesktop.brownmemory(6)
        If ShiftOSDesktop.brownmemory(7).ToArgb.ToString = "0" Then  Else pnlbrown8.BackColor = ShiftOSDesktop.brownmemory(7)
        If ShiftOSDesktop.brownmemory(8).ToArgb.ToString = "0" Then  Else pnlbrown9.BackColor = ShiftOSDesktop.brownmemory(8)
        If ShiftOSDesktop.brownmemory(9).ToArgb.ToString = "0" Then  Else pnlbrown10.BackColor = ShiftOSDesktop.brownmemory(9)
        If ShiftOSDesktop.brownmemory(10).ToArgb.ToString = "0" Then  Else pnlbrown11.BackColor = ShiftOSDesktop.brownmemory(10)
        If ShiftOSDesktop.brownmemory(11).ToArgb.ToString = "0" Then  Else pnlbrown12.BackColor = ShiftOSDesktop.brownmemory(11)
        If ShiftOSDesktop.brownmemory(12).ToArgb.ToString = "0" Then  Else pnlbrown13.BackColor = ShiftOSDesktop.brownmemory(12)
        If ShiftOSDesktop.brownmemory(13).ToArgb.ToString = "0" Then  Else pnlbrown14.BackColor = ShiftOSDesktop.brownmemory(13)
        If ShiftOSDesktop.brownmemory(14).ToArgb.ToString = "0" Then  Else pnlbrown15.BackColor = ShiftOSDesktop.brownmemory(14)
        If ShiftOSDesktop.brownmemory(15).ToArgb.ToString = "0" Then  Else pnlbrown16.BackColor = ShiftOSDesktop.brownmemory(15)

        If ShiftOSDesktop.redmemory(0).ToArgb.ToString = "0" Then  Else pnlred1.BackColor = ShiftOSDesktop.redmemory(0)
        If ShiftOSDesktop.redmemory(1).ToArgb.ToString = "0" Then  Else pnlred2.BackColor = ShiftOSDesktop.redmemory(1)
        If ShiftOSDesktop.redmemory(2).ToArgb.ToString = "0" Then  Else pnlred3.BackColor = ShiftOSDesktop.redmemory(2)
        If ShiftOSDesktop.redmemory(3).ToArgb.ToString = "0" Then  Else pnlred4.BackColor = ShiftOSDesktop.redmemory(3)
        If ShiftOSDesktop.redmemory(4).ToArgb.ToString = "0" Then  Else pnlred5.BackColor = ShiftOSDesktop.redmemory(4)
        If ShiftOSDesktop.redmemory(5).ToArgb.ToString = "0" Then  Else pnlred6.BackColor = ShiftOSDesktop.redmemory(5)
        If ShiftOSDesktop.redmemory(6).ToArgb.ToString = "0" Then  Else pnlred7.BackColor = ShiftOSDesktop.redmemory(6)
        If ShiftOSDesktop.redmemory(7).ToArgb.ToString = "0" Then  Else pnlred8.BackColor = ShiftOSDesktop.redmemory(7)
        If ShiftOSDesktop.redmemory(8).ToArgb.ToString = "0" Then  Else pnlred9.BackColor = ShiftOSDesktop.redmemory(8)
        If ShiftOSDesktop.redmemory(9).ToArgb.ToString = "0" Then  Else pnlred10.BackColor = ShiftOSDesktop.redmemory(9)
        If ShiftOSDesktop.redmemory(10).ToArgb.ToString = "0" Then  Else pnlred11.BackColor = ShiftOSDesktop.redmemory(10)
        If ShiftOSDesktop.redmemory(11).ToArgb.ToString = "0" Then  Else pnlred12.BackColor = ShiftOSDesktop.redmemory(11)
        If ShiftOSDesktop.redmemory(12).ToArgb.ToString = "0" Then  Else pnlred13.BackColor = ShiftOSDesktop.redmemory(12)
        If ShiftOSDesktop.redmemory(13).ToArgb.ToString = "0" Then  Else pnlred14.BackColor = ShiftOSDesktop.redmemory(13)
        If ShiftOSDesktop.redmemory(14).ToArgb.ToString = "0" Then  Else pnlred15.BackColor = ShiftOSDesktop.redmemory(14)
        If ShiftOSDesktop.redmemory(15).ToArgb.ToString = "0" Then  Else pnlred16.BackColor = ShiftOSDesktop.redmemory(15)

        If ShiftOSDesktop.pinkmemory(0).ToArgb.ToString = "0" Then  Else pnlpink1.BackColor = ShiftOSDesktop.pinkmemory(0)
        If ShiftOSDesktop.pinkmemory(1).ToArgb.ToString = "0" Then  Else pnlpink2.BackColor = ShiftOSDesktop.pinkmemory(1)
        If ShiftOSDesktop.pinkmemory(2).ToArgb.ToString = "0" Then  Else pnlpink3.BackColor = ShiftOSDesktop.pinkmemory(2)
        If ShiftOSDesktop.pinkmemory(3).ToArgb.ToString = "0" Then  Else pnlpink4.BackColor = ShiftOSDesktop.pinkmemory(3)
        If ShiftOSDesktop.pinkmemory(4).ToArgb.ToString = "0" Then  Else pnlpink5.BackColor = ShiftOSDesktop.pinkmemory(4)
        If ShiftOSDesktop.pinkmemory(5).ToArgb.ToString = "0" Then  Else pnlpink6.BackColor = ShiftOSDesktop.pinkmemory(5)
        If ShiftOSDesktop.pinkmemory(6).ToArgb.ToString = "0" Then  Else pnlpink7.BackColor = ShiftOSDesktop.pinkmemory(6)
        If ShiftOSDesktop.pinkmemory(7).ToArgb.ToString = "0" Then  Else pnlpink8.BackColor = ShiftOSDesktop.pinkmemory(7)
        If ShiftOSDesktop.pinkmemory(8).ToArgb.ToString = "0" Then  Else pnlpink9.BackColor = ShiftOSDesktop.pinkmemory(8)
        If ShiftOSDesktop.pinkmemory(9).ToArgb.ToString = "0" Then  Else pnlpink10.BackColor = ShiftOSDesktop.pinkmemory(9)
        If ShiftOSDesktop.pinkmemory(10).ToArgb.ToString = "0" Then  Else pnlpink11.BackColor = ShiftOSDesktop.pinkmemory(10)
        If ShiftOSDesktop.pinkmemory(11).ToArgb.ToString = "0" Then  Else pnlpink12.BackColor = ShiftOSDesktop.pinkmemory(11)
        If ShiftOSDesktop.pinkmemory(12).ToArgb.ToString = "0" Then  Else pnlpink13.BackColor = ShiftOSDesktop.pinkmemory(12)
        If ShiftOSDesktop.pinkmemory(13).ToArgb.ToString = "0" Then  Else pnlpink14.BackColor = ShiftOSDesktop.pinkmemory(13)
        If ShiftOSDesktop.pinkmemory(14).ToArgb.ToString = "0" Then  Else pnlpink15.BackColor = ShiftOSDesktop.pinkmemory(14)
        If ShiftOSDesktop.pinkmemory(15).ToArgb.ToString = "0" Then  Else pnlpink16.BackColor = ShiftOSDesktop.pinkmemory(15)
    End Sub

    Public Sub saveanymemory()
        ShiftOSDesktop.anymemory(0) = pnlany1.BackColor
        ShiftOSDesktop.anymemory(1) = pnlany2.BackColor
        ShiftOSDesktop.anymemory(2) = pnlany3.BackColor
        ShiftOSDesktop.anymemory(3) = pnlany4.BackColor
        ShiftOSDesktop.anymemory(4) = pnlany5.BackColor
        ShiftOSDesktop.anymemory(5) = pnlany6.BackColor
        ShiftOSDesktop.anymemory(6) = pnlany7.BackColor
        ShiftOSDesktop.anymemory(7) = pnlany8.BackColor
        ShiftOSDesktop.anymemory(8) = pnlany9.BackColor
        ShiftOSDesktop.anymemory(9) = pnlany10.BackColor
        ShiftOSDesktop.anymemory(10) = pnlany11.BackColor
        ShiftOSDesktop.anymemory(11) = pnlany12.BackColor
        ShiftOSDesktop.anymemory(12) = pnlany13.BackColor
        ShiftOSDesktop.anymemory(13) = pnlany14.BackColor
        ShiftOSDesktop.anymemory(14) = pnlany15.BackColor
        ShiftOSDesktop.anymemory(15) = pnlany16.BackColor
    End Sub

    Public Sub savegraymemory()
        ShiftOSDesktop.graymemory(0) = pnlgray1.BackColor
        ShiftOSDesktop.graymemory(1) = pnlgray2.BackColor
        ShiftOSDesktop.graymemory(2) = pnlgray3.BackColor
        ShiftOSDesktop.graymemory(3) = pnlgray4.BackColor
        ShiftOSDesktop.graymemory(4) = pnlgray5.BackColor
        ShiftOSDesktop.graymemory(5) = pnlgray6.BackColor
        ShiftOSDesktop.graymemory(6) = pnlgray7.BackColor
        ShiftOSDesktop.graymemory(7) = pnlgray8.BackColor
        ShiftOSDesktop.graymemory(8) = pnlgray9.BackColor
        ShiftOSDesktop.graymemory(9) = pnlgray10.BackColor
        ShiftOSDesktop.graymemory(10) = pnlgray11.BackColor
        ShiftOSDesktop.graymemory(11) = pnlgray12.BackColor
        ShiftOSDesktop.graymemory(12) = pnlgray13.BackColor
        ShiftOSDesktop.graymemory(13) = pnlgray14.BackColor
        ShiftOSDesktop.graymemory(14) = pnlgray15.BackColor
        ShiftOSDesktop.graymemory(15) = pnlgray16.BackColor
    End Sub

    Public Sub savepurplememory()
        ShiftOSDesktop.purplememory(0) = pnlpurple1.BackColor
        ShiftOSDesktop.purplememory(1) = pnlpurple2.BackColor
        ShiftOSDesktop.purplememory(2) = pnlpurple3.BackColor
        ShiftOSDesktop.purplememory(3) = pnlpurple4.BackColor
        ShiftOSDesktop.purplememory(4) = pnlpurple5.BackColor
        ShiftOSDesktop.purplememory(5) = pnlpurple6.BackColor
        ShiftOSDesktop.purplememory(6) = pnlpurple7.BackColor
        ShiftOSDesktop.purplememory(7) = pnlpurple8.BackColor
        ShiftOSDesktop.purplememory(8) = pnlpurple9.BackColor
        ShiftOSDesktop.purplememory(9) = pnlpurple10.BackColor
        ShiftOSDesktop.purplememory(10) = pnlpurple11.BackColor
        ShiftOSDesktop.purplememory(11) = pnlpurple12.BackColor
        ShiftOSDesktop.purplememory(12) = pnlpurple13.BackColor
        ShiftOSDesktop.purplememory(13) = pnlpurple14.BackColor
        ShiftOSDesktop.purplememory(14) = pnlpurple15.BackColor
        ShiftOSDesktop.purplememory(15) = pnlpurple16.BackColor
    End Sub

    Public Sub savebluememory()
        ShiftOSDesktop.bluememory(0) = pnlblue1.BackColor
        ShiftOSDesktop.bluememory(1) = pnlblue2.BackColor
        ShiftOSDesktop.bluememory(2) = pnlblue3.BackColor
        ShiftOSDesktop.bluememory(3) = pnlblue4.BackColor
        ShiftOSDesktop.bluememory(4) = pnlblue5.BackColor
        ShiftOSDesktop.bluememory(5) = pnlblue6.BackColor
        ShiftOSDesktop.bluememory(6) = pnlblue7.BackColor
        ShiftOSDesktop.bluememory(7) = pnlblue8.BackColor
        ShiftOSDesktop.bluememory(8) = pnlblue9.BackColor
        ShiftOSDesktop.bluememory(9) = pnlblue10.BackColor
        ShiftOSDesktop.bluememory(10) = pnlblue11.BackColor
        ShiftOSDesktop.bluememory(11) = pnlblue12.BackColor
        ShiftOSDesktop.bluememory(12) = pnlblue13.BackColor
        ShiftOSDesktop.bluememory(13) = pnlblue14.BackColor
        ShiftOSDesktop.bluememory(14) = pnlblue15.BackColor
        ShiftOSDesktop.bluememory(15) = pnlblue16.BackColor
    End Sub

    Public Sub savegreenmemory()
        ShiftOSDesktop.greenmemory(0) = pnlgreen1.BackColor
        ShiftOSDesktop.greenmemory(1) = pnlgreen2.BackColor
        ShiftOSDesktop.greenmemory(2) = pnlgreen3.BackColor
        ShiftOSDesktop.greenmemory(3) = pnlgreen4.BackColor
        ShiftOSDesktop.greenmemory(4) = pnlgreen5.BackColor
        ShiftOSDesktop.greenmemory(5) = pnlgreen6.BackColor
        ShiftOSDesktop.greenmemory(6) = pnlgreen7.BackColor
        ShiftOSDesktop.greenmemory(7) = pnlgreen8.BackColor
        ShiftOSDesktop.greenmemory(8) = pnlgreen9.BackColor
        ShiftOSDesktop.greenmemory(9) = pnlgreen10.BackColor
        ShiftOSDesktop.greenmemory(10) = pnlgreen11.BackColor
        ShiftOSDesktop.greenmemory(11) = pnlgreen12.BackColor
        ShiftOSDesktop.greenmemory(12) = pnlgreen13.BackColor
        ShiftOSDesktop.greenmemory(13) = pnlgreen14.BackColor
        ShiftOSDesktop.greenmemory(14) = pnlgreen15.BackColor
        ShiftOSDesktop.greenmemory(15) = pnlgreen16.BackColor
    End Sub

    Public Sub saveyellowmemory()
        ShiftOSDesktop.yellowmemory(0) = pnlyellow1.BackColor
        ShiftOSDesktop.yellowmemory(1) = pnlyellow2.BackColor
        ShiftOSDesktop.yellowmemory(2) = pnlyellow3.BackColor
        ShiftOSDesktop.yellowmemory(3) = pnlyellow4.BackColor
        ShiftOSDesktop.yellowmemory(4) = pnlyellow5.BackColor
        ShiftOSDesktop.yellowmemory(5) = pnlyellow6.BackColor
        ShiftOSDesktop.yellowmemory(6) = pnlyellow7.BackColor
        ShiftOSDesktop.yellowmemory(7) = pnlyellow8.BackColor
        ShiftOSDesktop.yellowmemory(8) = pnlyellow9.BackColor
        ShiftOSDesktop.yellowmemory(9) = pnlyellow10.BackColor
        ShiftOSDesktop.yellowmemory(10) = pnlyellow11.BackColor
        ShiftOSDesktop.yellowmemory(11) = pnlyellow12.BackColor
        ShiftOSDesktop.yellowmemory(12) = pnlyellow13.BackColor
        ShiftOSDesktop.yellowmemory(13) = pnlyellow14.BackColor
        ShiftOSDesktop.yellowmemory(14) = pnlyellow15.BackColor
        ShiftOSDesktop.yellowmemory(15) = pnlyellow16.BackColor
    End Sub

    Public Sub saveorangememory()
        ShiftOSDesktop.orangememory(0) = pnlorange1.BackColor
        ShiftOSDesktop.orangememory(1) = pnlorange2.BackColor
        ShiftOSDesktop.orangememory(2) = pnlorange3.BackColor
        ShiftOSDesktop.orangememory(3) = pnlorange4.BackColor
        ShiftOSDesktop.orangememory(4) = pnlorange5.BackColor
        ShiftOSDesktop.orangememory(5) = pnlorange6.BackColor
        ShiftOSDesktop.orangememory(6) = pnlorange7.BackColor
        ShiftOSDesktop.orangememory(7) = pnlorange8.BackColor
        ShiftOSDesktop.orangememory(8) = pnlorange9.BackColor
        ShiftOSDesktop.orangememory(9) = pnlorange10.BackColor
        ShiftOSDesktop.orangememory(10) = pnlorange11.BackColor
        ShiftOSDesktop.orangememory(11) = pnlorange12.BackColor
        ShiftOSDesktop.orangememory(12) = pnlorange13.BackColor
        ShiftOSDesktop.orangememory(13) = pnlorange14.BackColor
        ShiftOSDesktop.orangememory(14) = pnlorange15.BackColor
        ShiftOSDesktop.orangememory(15) = pnlorange16.BackColor
    End Sub

    Public Sub savebrownmemory()
        ShiftOSDesktop.brownmemory(0) = pnlbrown1.BackColor
        ShiftOSDesktop.brownmemory(1) = pnlbrown2.BackColor
        ShiftOSDesktop.brownmemory(2) = pnlbrown3.BackColor
        ShiftOSDesktop.brownmemory(3) = pnlbrown4.BackColor
        ShiftOSDesktop.brownmemory(4) = pnlbrown5.BackColor
        ShiftOSDesktop.brownmemory(5) = pnlbrown6.BackColor
        ShiftOSDesktop.brownmemory(6) = pnlbrown7.BackColor
        ShiftOSDesktop.brownmemory(7) = pnlbrown8.BackColor
        ShiftOSDesktop.brownmemory(8) = pnlbrown9.BackColor
        ShiftOSDesktop.brownmemory(9) = pnlbrown10.BackColor
        ShiftOSDesktop.brownmemory(10) = pnlbrown11.BackColor
        ShiftOSDesktop.brownmemory(11) = pnlbrown12.BackColor
        ShiftOSDesktop.brownmemory(12) = pnlbrown13.BackColor
        ShiftOSDesktop.brownmemory(13) = pnlbrown14.BackColor
        ShiftOSDesktop.brownmemory(14) = pnlbrown15.BackColor
        ShiftOSDesktop.brownmemory(15) = pnlbrown16.BackColor
    End Sub

    Public Sub saveredmemory()
        ShiftOSDesktop.redmemory(0) = pnlred1.BackColor
        ShiftOSDesktop.redmemory(1) = pnlred2.BackColor
        ShiftOSDesktop.redmemory(2) = pnlred3.BackColor
        ShiftOSDesktop.redmemory(3) = pnlred4.BackColor
        ShiftOSDesktop.redmemory(4) = pnlred5.BackColor
        ShiftOSDesktop.redmemory(5) = pnlred6.BackColor
        ShiftOSDesktop.redmemory(6) = pnlred7.BackColor
        ShiftOSDesktop.redmemory(7) = pnlred8.BackColor
        ShiftOSDesktop.redmemory(8) = pnlred9.BackColor
        ShiftOSDesktop.redmemory(9) = pnlred10.BackColor
        ShiftOSDesktop.redmemory(10) = pnlred11.BackColor
        ShiftOSDesktop.redmemory(11) = pnlred12.BackColor
        ShiftOSDesktop.redmemory(12) = pnlred13.BackColor
        ShiftOSDesktop.redmemory(13) = pnlred14.BackColor
        ShiftOSDesktop.redmemory(14) = pnlred15.BackColor
        ShiftOSDesktop.redmemory(15) = pnlred16.BackColor
    End Sub

    Public Sub savepinkmemory()
        ShiftOSDesktop.pinkmemory(0) = pnlpink1.BackColor
        ShiftOSDesktop.pinkmemory(1) = pnlpink2.BackColor
        ShiftOSDesktop.pinkmemory(2) = pnlpink3.BackColor
        ShiftOSDesktop.pinkmemory(3) = pnlpink4.BackColor
        ShiftOSDesktop.pinkmemory(4) = pnlpink5.BackColor
        ShiftOSDesktop.pinkmemory(5) = pnlpink6.BackColor
        ShiftOSDesktop.pinkmemory(6) = pnlpink7.BackColor
        ShiftOSDesktop.pinkmemory(7) = pnlpink8.BackColor
        ShiftOSDesktop.pinkmemory(8) = pnlpink9.BackColor
        ShiftOSDesktop.pinkmemory(9) = pnlpink10.BackColor
        ShiftOSDesktop.pinkmemory(10) = pnlpink11.BackColor
        ShiftOSDesktop.pinkmemory(11) = pnlpink12.BackColor
        ShiftOSDesktop.pinkmemory(12) = pnlpink13.BackColor
        ShiftOSDesktop.pinkmemory(13) = pnlpink14.BackColor
        ShiftOSDesktop.pinkmemory(14) = pnlpink15.BackColor
        ShiftOSDesktop.pinkmemory(15) = pnlpink16.BackColor
    End Sub

    Private Sub getoldcolour()
        lblobjecttocolour.Text = colourtochange
        pnloldcolour.BackColor = oldcolour
        If pnloldcolour.BackColor.IsNamedColor Then
            lbloldcolourname.Text = pnloldcolour.BackColor.Name & " :Name"
        Else
            lbloldcolourname.Text = "Custom :Name"
        End If
        lbloldcolourrgb.Text = pnloldcolour.BackColor.R & ", " & pnloldcolour.BackColor.G & ", " & pnloldcolour.BackColor.B & " :RGB"

        pnlnewcolour.BackColor = ShiftOSDesktop.lastcolourpick
        If pnlnewcolour.BackColor.IsNamedColor Then
            lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
        Else
            lblnewcolourname.Text = "Name: Custom"
        End If
        lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
    End Sub

    Private Sub determinelevels()
        If ShiftOSDesktop.boughtgray = True Then graylevel = 1
        If ShiftOSDesktop.boughtgray2 = True Then graylevel = 2
        If ShiftOSDesktop.boughtgray3 = True Then graylevel = 3
        If ShiftOSDesktop.boughtgray4 = True Then graylevel = 4
        If ShiftOSDesktop.boughtanycolour = True Then anylevel = 1
        If ShiftOSDesktop.boughtanycolour2 = True Then anylevel = 2
        If ShiftOSDesktop.boughtanycolour3 = True Then anylevel = 3
        If ShiftOSDesktop.boughtanycolour4 = True Then anylevel = 4
        If ShiftOSDesktop.boughtpurple = True Then purplelevel = 1
        If ShiftOSDesktop.boughtpurple2 = True Then purplelevel = 2
        If ShiftOSDesktop.boughtpurple3 = True Then purplelevel = 3
        If ShiftOSDesktop.boughtpurple4 = True Then purplelevel = 4
        If ShiftOSDesktop.boughtblue = True Then bluelevel = 1
        If ShiftOSDesktop.boughtblue2 = True Then bluelevel = 2
        If ShiftOSDesktop.boughtblue3 = True Then bluelevel = 3
        If ShiftOSDesktop.boughtblue4 = True Then bluelevel = 4
        If ShiftOSDesktop.boughtgreen = True Then greenlevel = 1
        If ShiftOSDesktop.boughtgreen2 = True Then greenlevel = 2
        If ShiftOSDesktop.boughtgreen3 = True Then greenlevel = 3
        If ShiftOSDesktop.boughtgreen4 = True Then greenlevel = 4
        If ShiftOSDesktop.boughtyellow = True Then yellowlevel = 1
        If ShiftOSDesktop.boughtyellow2 = True Then yellowlevel = 2
        If ShiftOSDesktop.boughtyellow3 = True Then yellowlevel = 3
        If ShiftOSDesktop.boughtyellow4 = True Then yellowlevel = 4
        If ShiftOSDesktop.boughtorange = True Then orangelevel = 1
        If ShiftOSDesktop.boughtorange2 = True Then orangelevel = 2
        If ShiftOSDesktop.boughtorange3 = True Then orangelevel = 3
        If ShiftOSDesktop.boughtorange4 = True Then orangelevel = 4
        If ShiftOSDesktop.boughtbrown = True Then brownlevel = 1
        If ShiftOSDesktop.boughtbrown2 = True Then brownlevel = 2
        If ShiftOSDesktop.boughtbrown3 = True Then brownlevel = 3
        If ShiftOSDesktop.boughtbrown4 = True Then brownlevel = 4
        If ShiftOSDesktop.boughtred = True Then redlevel = 1
        If ShiftOSDesktop.boughtred2 = True Then redlevel = 2
        If ShiftOSDesktop.boughtred3 = True Then redlevel = 3
        If ShiftOSDesktop.boughtred4 = True Then redlevel = 4
        If ShiftOSDesktop.boughtpink = True Then pinklevel = 1
        If ShiftOSDesktop.boughtpink2 = True Then pinklevel = 2
        If ShiftOSDesktop.boughtpink3 = True Then pinklevel = 3
        If ShiftOSDesktop.boughtpink4 = True Then pinklevel = 4
    End Sub

    Private Sub shrinktosizebasedoncoloursbought()
        If ShiftOSDesktop.boughtpink = False Then
            Me.Height = Me.Height - 46
        Else
            pnlpinkcolours.Show()
        End If
        If ShiftOSDesktop.boughtred = False Then
            Me.Height = Me.Height - 46
        Else
            pnlredcolours.Show()
        End If
        If ShiftOSDesktop.boughtbrown = False Then
            Me.Height = Me.Height - 46
        Else
            pnlbrowncolours.Show()
        End If
        If ShiftOSDesktop.boughtorange = False Then
            Me.Height = Me.Height - 46
        Else
            pnlorangecolours.Show()
        End If
        If ShiftOSDesktop.boughtyellow = False Then
            Me.Height = Me.Height - 46
        Else
            pnlyellowcolours.Show()
        End If
        If ShiftOSDesktop.boughtgreen = False Then
            Me.Height = Me.Height - 46
        Else
            pnlgreencolours.Show()
        End If
        If ShiftOSDesktop.boughtblue = False Then
            Me.Height = Me.Height - 46
        Else
            pnlbluecolours.Show()
        End If
        If ShiftOSDesktop.boughtpurple = False Then
            Me.Height = Me.Height - 46
        Else
            pnlpurplecolours.Show()
        End If
        If ShiftOSDesktop.boughtgray = False Then
            Me.Height = Me.Height - 46
        Else
            pnlgraycolours.Show()
        End If
        If ShiftOSDesktop.boughtanycolour = False Then
            Me.Height = Me.Height - 46
        Else
            pnlanycolours.Show()
        End If
    End Sub

    Private Sub setupboughtcolours()
        Select Case graylevel
            Case 1
                lblgraylevel.Text = "Level 1"
                pnlgray1.BackColor = Color.Black
                pnlgray1.Show()
                pnlgray2.BackColor = Color.Gray
                pnlgray2.Show()
                pnlgray3.BackColor = Color.White
                pnlgray3.Show()
            Case 2
                lblgraylevel.Text = "Level 2"
                pnlgray1.BackColor = Color.Black
                pnlgray1.Show()
                pnlgray2.BackColor = Color.DimGray
                pnlgray2.Show()
                pnlgray3.BackColor = Color.Gray
                pnlgray3.Show()
                pnlgray4.BackColor = Color.LightGray
                pnlgray4.Show()
                pnlgray5.BackColor = Color.White
                pnlgray5.Show()
            Case 3
                lblgraylevel.Text = "Level 3"
                pnlgray1.BackColor = Color.Black
                pnlgray1.Show()
                pnlgray2.BackColor = Color.DimGray
                pnlgray2.Show()
                pnlgray3.BackColor = Color.Gray
                pnlgray3.Show()
                pnlgray4.BackColor = Color.DarkGray
                pnlgray4.Show()
                pnlgray5.BackColor = Color.Silver
                pnlgray5.Show()
                pnlgray6.BackColor = Color.LightGray
                pnlgray6.Show()
                pnlgray7.BackColor = Color.Gainsboro
                pnlgray7.Show()
                pnlgray8.BackColor = Color.WhiteSmoke
                pnlgray8.Show()
                pnlgray9.BackColor = Color.White
                pnlgray9.Show()
            Case 4
                lblgraylevel.Text = "Level 4"
                pnlgray1.BackColor = Color.Black
                pnlgray1.Show()
                pnlgray2.BackColor = Color.DimGray
                pnlgray2.Show()
                pnlgray3.BackColor = Color.Gray
                pnlgray3.Show()
                pnlgray4.BackColor = Color.DarkGray
                pnlgray4.Show()
                pnlgray5.BackColor = Color.Silver
                pnlgray5.Show()
                pnlgray6.BackColor = Color.LightGray
                pnlgray6.Show()
                pnlgray7.BackColor = Color.Gainsboro
                pnlgray7.Show()
                pnlgray8.BackColor = Color.WhiteSmoke
                pnlgray8.Show()
                pnlgray9.BackColor = Color.White
                pnlgray9.Show()
                pnlgray10.BackColor = Color.White
                pnlgray10.Show()
                pnlgray11.BackColor = Color.White
                pnlgray11.Show()
                pnlgray12.BackColor = Color.White
                pnlgray12.Show()
                pnlgray13.BackColor = Color.White
                pnlgray13.Show()
                pnlgray14.BackColor = Color.White
                pnlgray14.Show()
                pnlgray15.BackColor = Color.White
                pnlgray15.Show()
                pnlgray16.BackColor = Color.White
                pnlgray16.Show()
                pnlgraycustomcolour.Show()
                lblcustomshadetut.Show()
                txtcustomgrayshade.Show()
        End Select

        Select Case purplelevel
            Case 1
                lblpurplelevel.Text = "Level 1"
                pnlpurple1.BackColor = Color.Purple
                pnlpurple1.Show()
            Case 2
                lblpurplelevel.Text = "Level 2"
                pnlpurple1.BackColor = Color.Indigo
                pnlpurple1.Show()
                pnlpurple2.BackColor = Color.Purple
                pnlpurple2.Show()
                pnlpurple3.BackColor = Color.MediumPurple
                pnlpurple3.Show()
            Case 3
                lblpurplelevel.Text = "Level 3"
                pnlpurple1.BackColor = Color.Indigo
                pnlpurple1.Show()
                pnlpurple2.BackColor = Color.DarkSlateBlue
                pnlpurple2.Show()
                pnlpurple3.BackColor = Color.Purple
                pnlpurple3.Show()
                pnlpurple4.BackColor = Color.DarkOrchid
                pnlpurple4.Show()
                pnlpurple5.BackColor = Color.DarkViolet
                pnlpurple5.Show()
                pnlpurple6.BackColor = Color.BlueViolet
                pnlpurple6.Show()
                pnlpurple7.BackColor = Color.SlateBlue
                pnlpurple7.Show()
                pnlpurple8.BackColor = Color.MediumSlateBlue
                pnlpurple8.Show()
                pnlpurple9.BackColor = Color.MediumPurple
                pnlpurple9.Show()
                pnlpurple10.BackColor = Color.MediumOrchid
                pnlpurple10.Show()
                pnlpurple11.BackColor = Color.Magenta
                pnlpurple11.Show()
                pnlpurple12.BackColor = Color.Orchid
                pnlpurple12.Show()
                pnlpurple13.BackColor = Color.Violet
                pnlpurple13.Show()
                pnlpurple14.BackColor = Color.Plum
                pnlpurple14.Show()
                pnlpurple15.BackColor = Color.Thistle
                pnlpurple15.Show()
                pnlpurple16.BackColor = Color.Lavender
                pnlpurple16.Show()
            Case 4
                lblpurplelevel.Text = "Level 4"
                pnlpurple1.BackColor = Color.Indigo
                pnlpurple1.Show()
                pnlpurple2.BackColor = Color.DarkSlateBlue
                pnlpurple2.Show()
                pnlpurple3.BackColor = Color.Purple
                pnlpurple3.Show()
                pnlpurple4.BackColor = Color.DarkOrchid
                pnlpurple4.Show()
                pnlpurple5.BackColor = Color.DarkViolet
                pnlpurple5.Show()
                pnlpurple6.BackColor = Color.BlueViolet
                pnlpurple6.Show()
                pnlpurple7.BackColor = Color.SlateBlue
                pnlpurple7.Show()
                pnlpurple8.BackColor = Color.MediumSlateBlue
                pnlpurple8.Show()
                pnlpurple9.BackColor = Color.MediumPurple
                pnlpurple9.Show()
                pnlpurple10.BackColor = Color.MediumOrchid
                pnlpurple10.Show()
                pnlpurple11.BackColor = Color.Magenta
                pnlpurple11.Show()
                pnlpurple12.BackColor = Color.Orchid
                pnlpurple12.Show()
                pnlpurple13.BackColor = Color.Violet
                pnlpurple13.Show()
                pnlpurple14.BackColor = Color.Plum
                pnlpurple14.Show()
                pnlpurple15.BackColor = Color.Thistle
                pnlpurple15.Show()
                pnlpurple16.BackColor = Color.Lavender
                pnlpurple16.Show()
                pnlpurplecustomcolour.Show()
                pnlpurpleoptions.Show()
        End Select

        Select Case bluelevel
            Case 1
                lblbluelevel.Text = "Level 1"
                pnlblue1.BackColor = Color.Blue
                pnlblue1.Show()
            Case 2
                lblbluelevel.Text = "Level 2"
                pnlblue1.BackColor = Color.Navy
                pnlblue1.Show()
                pnlblue2.BackColor = Color.Blue
                pnlblue2.Show()
                pnlblue3.BackColor = Color.LightBlue
                pnlblue3.Show()
            Case 3
                lblbluelevel.Text = "Level 3"
                pnlblue1.BackColor = Color.MidnightBlue
                pnlblue1.Show()
                pnlblue2.BackColor = Color.Navy
                pnlblue2.Show()
                pnlblue3.BackColor = Color.Blue
                pnlblue3.Show()
                pnlblue4.BackColor = Color.RoyalBlue
                pnlblue4.Show()
                pnlblue5.BackColor = Color.CornflowerBlue
                pnlblue5.Show()
                pnlblue6.BackColor = Color.DeepSkyBlue
                pnlblue6.Show()
                pnlblue7.BackColor = Color.SkyBlue
                pnlblue7.Show()
                pnlblue8.BackColor = Color.LightBlue
                pnlblue8.Show()
                pnlblue9.BackColor = Color.LightSteelBlue
                pnlblue9.Show()
                pnlblue10.BackColor = Color.Cyan
                pnlblue10.Show()
                pnlblue11.BackColor = Color.Aquamarine
                pnlblue11.Show()
                pnlblue12.BackColor = Color.DarkTurquoise
                pnlblue12.Show()
                pnlblue13.BackColor = Color.LightSeaGreen
                pnlblue13.Show()
                pnlblue14.BackColor = Color.MediumAquamarine
                pnlblue14.Show()
                pnlblue15.BackColor = Color.CadetBlue
                pnlblue15.Show()
                pnlblue16.BackColor = Color.Teal
                pnlblue16.Show()
            Case 4
                lblbluelevel.Text = "Level 4"
                pnlblue1.BackColor = Color.MidnightBlue
                pnlblue1.Show()
                pnlblue2.BackColor = Color.Navy
                pnlblue2.Show()
                pnlblue3.BackColor = Color.Blue
                pnlblue3.Show()
                pnlblue4.BackColor = Color.RoyalBlue
                pnlblue4.Show()
                pnlblue5.BackColor = Color.CornflowerBlue
                pnlblue5.Show()
                pnlblue6.BackColor = Color.DeepSkyBlue
                pnlblue6.Show()
                pnlblue7.BackColor = Color.SkyBlue
                pnlblue7.Show()
                pnlblue8.BackColor = Color.LightBlue
                pnlblue8.Show()
                pnlblue9.BackColor = Color.LightSteelBlue
                pnlblue9.Show()
                pnlblue10.BackColor = Color.Cyan
                pnlblue10.Show()
                pnlblue11.BackColor = Color.Aquamarine
                pnlblue11.Show()
                pnlblue12.BackColor = Color.DarkTurquoise
                pnlblue12.Show()
                pnlblue13.BackColor = Color.LightSeaGreen
                pnlblue13.Show()
                pnlblue14.BackColor = Color.MediumAquamarine
                pnlblue14.Show()
                pnlblue15.BackColor = Color.CadetBlue
                pnlblue15.Show()
                pnlblue16.BackColor = Color.Teal
                pnlblue16.Show()
                pnlbluecustomcolour.Show()
                pnlblueoptions.Show()
        End Select

        Select Case greenlevel
            Case 1
                lblgreenlevel.Text = "Level 1"
                pnlgreen1.BackColor = Color.Green
                pnlgreen1.Show()
            Case 2
                lblgreenlevel.Text = "Level 2"
                pnlgreen1.BackColor = Color.DarkGreen
                pnlgreen1.Show()
                pnlgreen2.BackColor = Color.Green
                pnlgreen2.Show()
                pnlgreen3.BackColor = Color.LightGreen
                pnlgreen3.Show()
            Case 3
                lblgreenlevel.Text = "Level 3"
                pnlgreen1.BackColor = Color.DarkGreen
                pnlgreen1.Show()
                pnlgreen2.BackColor = Color.Green
                pnlgreen2.Show()
                pnlgreen3.BackColor = Color.SeaGreen
                pnlgreen3.Show()
                pnlgreen4.BackColor = Color.MediumSeaGreen
                pnlgreen4.Show()
                pnlgreen5.BackColor = Color.DarkSeaGreen
                pnlgreen5.Show()
                pnlgreen6.BackColor = Color.LightGreen
                pnlgreen6.Show()
                pnlgreen7.BackColor = Color.MediumSpringGreen
                pnlgreen7.Show()
                pnlgreen8.BackColor = Color.SpringGreen
                pnlgreen8.Show()
                pnlgreen9.BackColor = Color.GreenYellow
                pnlgreen9.Show()
                pnlgreen10.BackColor = Color.LawnGreen
                pnlgreen10.Show()
                pnlgreen11.BackColor = Color.Lime
                pnlgreen11.Show()
                pnlgreen12.BackColor = Color.LimeGreen
                pnlgreen12.Show()
                pnlgreen13.BackColor = Color.YellowGreen
                pnlgreen13.Show()
                pnlgreen14.BackColor = Color.OliveDrab
                pnlgreen14.Show()
                pnlgreen15.BackColor = Color.Olive
                pnlgreen15.Show()
                pnlgreen16.BackColor = Color.DarkOliveGreen
                pnlgreen16.Show()
            Case 4
                lblgreenlevel.Text = "Level 4"
                pnlgreen1.BackColor = Color.DarkGreen
                pnlgreen1.Show()
                pnlgreen2.BackColor = Color.Green
                pnlgreen2.Show()
                pnlgreen3.BackColor = Color.SeaGreen
                pnlgreen3.Show()
                pnlgreen4.BackColor = Color.MediumSeaGreen
                pnlgreen4.Show()
                pnlgreen5.BackColor = Color.DarkSeaGreen
                pnlgreen5.Show()
                pnlgreen6.BackColor = Color.LightGreen
                pnlgreen6.Show()
                pnlgreen7.BackColor = Color.MediumSpringGreen
                pnlgreen7.Show()
                pnlgreen8.BackColor = Color.SpringGreen
                pnlgreen8.Show()
                pnlgreen9.BackColor = Color.GreenYellow
                pnlgreen9.Show()
                pnlgreen10.BackColor = Color.LawnGreen
                pnlgreen10.Show()
                pnlgreen11.BackColor = Color.Lime
                pnlgreen11.Show()
                pnlgreen12.BackColor = Color.LimeGreen
                pnlgreen12.Show()
                pnlgreen13.BackColor = Color.YellowGreen
                pnlgreen13.Show()
                pnlgreen14.BackColor = Color.OliveDrab
                pnlgreen14.Show()
                pnlgreen15.BackColor = Color.Olive
                pnlgreen15.Show()
                pnlgreen16.BackColor = Color.DarkOliveGreen
                pnlgreen16.Show()
                pnlgreencustomcolour.Show()
                pnlgreenoptions.Show()
        End Select

        Select Case yellowlevel
            Case 1
                lblyellowlevel.Text = "Level 1"
                pnlyellow1.BackColor = Color.Yellow
                pnlyellow1.Show()
            Case 2
                lblyellowlevel.Text = "Level 2"
                pnlyellow1.BackColor = Color.DarkKhaki
                pnlyellow1.Show()
                pnlyellow2.BackColor = Color.Yellow
                pnlyellow2.Show()
                pnlyellow3.BackColor = Color.PaleGoldenrod
                pnlyellow3.Show()
            Case 3
                lblyellowlevel.Text = "Level 3"
                pnlyellow1.BackColor = Color.DarkKhaki
                pnlyellow1.Show()
                pnlyellow2.BackColor = Color.Yellow
                pnlyellow2.Show()
                pnlyellow3.BackColor = Color.Khaki
                pnlyellow3.Show()
                pnlyellow4.BackColor = Color.PaleGoldenrod
                pnlyellow4.Show()
                pnlyellow5.BackColor = Color.PeachPuff
                pnlyellow5.Show()
                pnlyellow6.BackColor = Color.Moccasin
                pnlyellow6.Show()
                pnlyellow7.BackColor = Color.PapayaWhip
                pnlyellow7.Show()
                pnlyellow8.BackColor = Color.LightGoldenrodYellow
                pnlyellow8.Show()
                pnlyellow9.BackColor = Color.LemonChiffon
                pnlyellow9.Show()
                pnlyellow10.BackColor = Color.LightYellow
                pnlyellow10.Show()
            Case 4
                lblyellowlevel.Text = "Level 4"
                pnlyellow1.BackColor = Color.DarkKhaki
                pnlyellow1.Show()
                pnlyellow2.BackColor = Color.Yellow
                pnlyellow2.Show()
                pnlyellow3.BackColor = Color.Khaki
                pnlyellow3.Show()
                pnlyellow4.BackColor = Color.PaleGoldenrod
                pnlyellow4.Show()
                pnlyellow5.BackColor = Color.PeachPuff
                pnlyellow5.Show()
                pnlyellow6.BackColor = Color.Moccasin
                pnlyellow6.Show()
                pnlyellow7.BackColor = Color.PapayaWhip
                pnlyellow7.Show()
                pnlyellow8.BackColor = Color.LightGoldenrodYellow
                pnlyellow8.Show()
                pnlyellow9.BackColor = Color.LemonChiffon
                pnlyellow9.Show()
                pnlyellow10.BackColor = Color.LightYellow
                pnlyellow10.Show()
                pnlyellow11.BackColor = Color.White
                pnlyellow11.Show()
                pnlyellow12.BackColor = Color.White
                pnlyellow12.Show()
                pnlyellow13.BackColor = Color.White
                pnlyellow13.Show()
                pnlyellow14.BackColor = Color.White
                pnlyellow14.Show()
                pnlyellow15.BackColor = Color.White
                pnlyellow15.Show()
                pnlyellow16.BackColor = Color.White
                pnlyellow16.Show()
                pnlyellowcustomcolour.Show()
                pnlyellowoptions.Show()
        End Select

        Select Case orangelevel
            Case 1
                lblorangelevel.Text = "Level 1"
                pnlorange1.BackColor = Color.DarkOrange
                pnlorange1.Show()
            Case 2
                lblorangelevel.Text = "Level 2"
                pnlorange1.BackColor = Color.OrangeRed
                pnlorange1.Show()
                pnlorange2.BackColor = Color.DarkOrange
                pnlorange2.Show()
                pnlorange3.BackColor = Color.Orange
                pnlorange3.Show()
            Case 3
                lblorangelevel.Text = "Level 3"
                pnlorange1.BackColor = Color.OrangeRed
                pnlorange1.Show()
                pnlorange2.BackColor = Color.Tomato
                pnlorange2.Show()
                pnlorange3.BackColor = Color.Coral
                pnlorange3.Show()
                pnlorange4.BackColor = Color.DarkOrange
                pnlorange4.Show()
                pnlorange5.BackColor = Color.Orange
                pnlorange5.Show()
                pnlorange6.BackColor = Color.Gold
                pnlorange6.Show()
            Case 4
                lblorangelevel.Text = "Level 4"
                pnlorange1.BackColor = Color.OrangeRed
                pnlorange1.Show()
                pnlorange2.BackColor = Color.Tomato
                pnlorange2.Show()
                pnlorange3.BackColor = Color.Coral
                pnlorange3.Show()
                pnlorange4.BackColor = Color.DarkOrange
                pnlorange4.Show()
                pnlorange5.BackColor = Color.Orange
                pnlorange5.Show()
                pnlorange6.BackColor = Color.Gold
                pnlorange6.Show()
                pnlorange7.BackColor = Color.White
                pnlorange7.Show()
                pnlorange8.BackColor = Color.White
                pnlorange8.Show()
                pnlorange9.BackColor = Color.White
                pnlorange9.Show()
                pnlorange10.BackColor = Color.White
                pnlorange10.Show()
                pnlorange11.BackColor = Color.White
                pnlorange11.Show()
                pnlorange12.BackColor = Color.White
                pnlorange12.Show()
                pnlorange13.BackColor = Color.White
                pnlorange13.Show()
                pnlorange14.BackColor = Color.White
                pnlorange14.Show()
                pnlorange15.BackColor = Color.White
                pnlorange15.Show()
                pnlorange16.BackColor = Color.White
                pnlorange16.Show()
                pnlorangecustomcolour.Show()
                pnlorangeoptions.Show()
        End Select

        Select Case brownlevel
            Case 1
                lblbrownlevel.Text = "Level 1"
                pnlbrown1.BackColor = Color.Sienna
                pnlbrown1.Show()
            Case 2
                lblbrownlevel.Text = "Level 2"
                pnlbrown1.BackColor = Color.SaddleBrown
                pnlbrown1.Show()
                pnlbrown2.BackColor = Color.Sienna
                pnlbrown2.Show()
                pnlbrown3.BackColor = Color.BurlyWood
                pnlbrown3.Show()
            Case 3
                lblbrownlevel.Text = "Level 3"
                pnlbrown1.BackColor = Color.Maroon
                pnlbrown1.Show()
                pnlbrown2.BackColor = Color.Brown
                pnlbrown2.Show()
                pnlbrown3.BackColor = Color.Sienna
                pnlbrown3.Show()
                pnlbrown4.BackColor = Color.SaddleBrown
                pnlbrown4.Show()
                pnlbrown5.BackColor = Color.Chocolate
                pnlbrown5.Show()
                pnlbrown6.BackColor = Color.Peru
                pnlbrown6.Show()
                pnlbrown7.BackColor = Color.DarkGoldenrod
                pnlbrown7.Show()
                pnlbrown8.BackColor = Color.Goldenrod
                pnlbrown8.Show()
                pnlbrown9.BackColor = Color.SandyBrown
                pnlbrown9.Show()
                pnlbrown10.BackColor = Color.RosyBrown
                pnlbrown10.Show()
                pnlbrown11.BackColor = Color.Tan
                pnlbrown11.Show()
                pnlbrown12.BackColor = Color.BurlyWood
                pnlbrown12.Show()
                pnlbrown13.BackColor = Color.Wheat
                pnlbrown13.Show()
                pnlbrown14.BackColor = Color.NavajoWhite
                pnlbrown14.Show()
                pnlbrown15.BackColor = Color.Bisque
                pnlbrown15.Show()
                pnlbrown16.BackColor = Color.BlanchedAlmond
                pnlbrown16.Show()
            Case 4
                lblbrownlevel.Text = "Level 4"
                pnlbrown1.BackColor = Color.Maroon
                pnlbrown1.Show()
                pnlbrown2.BackColor = Color.Brown
                pnlbrown2.Show()
                pnlbrown3.BackColor = Color.Sienna
                pnlbrown3.Show()
                pnlbrown4.BackColor = Color.SaddleBrown
                pnlbrown4.Show()
                pnlbrown5.BackColor = Color.Chocolate
                pnlbrown5.Show()
                pnlbrown6.BackColor = Color.Peru
                pnlbrown6.Show()
                pnlbrown7.BackColor = Color.DarkGoldenrod
                pnlbrown7.Show()
                pnlbrown8.BackColor = Color.Goldenrod
                pnlbrown8.Show()
                pnlbrown9.BackColor = Color.SandyBrown
                pnlbrown9.Show()
                pnlbrown10.BackColor = Color.RosyBrown
                pnlbrown10.Show()
                pnlbrown11.BackColor = Color.Tan
                pnlbrown11.Show()
                pnlbrown12.BackColor = Color.BurlyWood
                pnlbrown12.Show()
                pnlbrown13.BackColor = Color.Wheat
                pnlbrown13.Show()
                pnlbrown14.BackColor = Color.NavajoWhite
                pnlbrown14.Show()
                pnlbrown15.BackColor = Color.Bisque
                pnlbrown15.Show()
                pnlbrown16.BackColor = Color.BlanchedAlmond
                pnlbrown16.Show()
                pnlbrowncustomcolour.Show()
                pnlbrownoptions.Show()
        End Select

        Select Case redlevel
            Case 1
                lblredlevel.Text = "Level 1"
                pnlred1.BackColor = Color.Red
                pnlred1.Show()
            Case 2
                lblredlevel.Text = "Level 2"
                pnlred1.BackColor = Color.DarkRed
                pnlred1.Show()
                pnlred2.BackColor = Color.Red
                pnlred2.Show()
                pnlred3.BackColor = Color.Salmon
                pnlred3.Show()
            Case 3
                lblredlevel.Text = "Level 3"
                pnlred1.BackColor = Color.DarkRed
                pnlred1.Show()
                pnlred2.BackColor = Color.Red
                pnlred2.Show()
                pnlred3.BackColor = Color.Firebrick
                pnlred3.Show()
                pnlred4.BackColor = Color.Crimson
                pnlred4.Show()
                pnlred5.BackColor = Color.IndianRed
                pnlred5.Show()
                pnlred6.BackColor = Color.LightCoral
                pnlred6.Show()
                pnlred7.BackColor = Color.DarkSalmon
                pnlred7.Show()
                pnlred8.BackColor = Color.Salmon
                pnlred8.Show()
                pnlred9.BackColor = Color.LightSalmon
                pnlred9.Show()
            Case 4
                lblredlevel.Text = "Level 4"
                pnlred1.BackColor = Color.DarkRed
                pnlred1.Show()
                pnlred2.BackColor = Color.Red
                pnlred2.Show()
                pnlred3.BackColor = Color.Firebrick
                pnlred3.Show()
                pnlred4.BackColor = Color.Crimson
                pnlred4.Show()
                pnlred5.BackColor = Color.IndianRed
                pnlred5.Show()
                pnlred6.BackColor = Color.LightCoral
                pnlred6.Show()
                pnlred7.BackColor = Color.DarkSalmon
                pnlred7.Show()
                pnlred8.BackColor = Color.Salmon
                pnlred8.Show()
                pnlred9.BackColor = Color.LightSalmon
                pnlred9.Show()
                pnlred10.BackColor = Color.White
                pnlred10.Show()
                pnlred11.BackColor = Color.White
                pnlred11.Show()
                pnlred12.BackColor = Color.White
                pnlred12.Show()
                pnlred13.BackColor = Color.White
                pnlred13.Show()
                pnlred14.BackColor = Color.White
                pnlred14.Show()
                pnlred15.BackColor = Color.White
                pnlred15.Show()
                pnlred16.BackColor = Color.White
                pnlred16.Show()
                pnlredcustomcolour.Show()
                pnlredoptions.Show()
        End Select

        Select Case pinklevel
            Case 1
                lblpinklevel.Text = "Level 1"
                pnlpink1.BackColor = Color.HotPink
                pnlpink1.Show()
            Case 2
                lblpinklevel.Text = "Level 2"
                pnlpink1.BackColor = Color.DeepPink
                pnlpink1.Show()
                pnlpink2.BackColor = Color.HotPink
                pnlpink2.Show()
                pnlpink3.BackColor = Color.LightPink
                pnlpink3.Show()
            Case 3
                lblpinklevel.Text = "Level 3"
                pnlpink1.BackColor = Color.MediumVioletRed
                pnlpink1.Show()
                pnlpink2.BackColor = Color.PaleVioletRed
                pnlpink2.Show()
                pnlpink3.BackColor = Color.DeepPink
                pnlpink3.Show()
                pnlpink4.BackColor = Color.HotPink
                pnlpink4.Show()
                pnlpink5.BackColor = Color.LightPink
                pnlpink5.Show()
                pnlpink6.BackColor = Color.Pink
                pnlpink6.Show()
            Case 4
                lblpinklevel.Text = "Level 4"
                pnlpink1.BackColor = Color.MediumVioletRed
                pnlpink1.Show()
                pnlpink2.BackColor = Color.PaleVioletRed
                pnlpink2.Show()
                pnlpink3.BackColor = Color.DeepPink
                pnlpink3.Show()
                pnlpink4.BackColor = Color.HotPink
                pnlpink4.Show()
                pnlpink5.BackColor = Color.LightPink
                pnlpink5.Show()
                pnlpink6.BackColor = Color.Pink
                pnlpink6.Show()
                pnlpink7.BackColor = Color.White
                pnlpink7.Show()
                pnlpink8.BackColor = Color.White
                pnlpink8.Show()
                pnlpink9.BackColor = Color.White
                pnlpink9.Show()
                pnlpink10.BackColor = Color.White
                pnlpink10.Show()
                pnlpink11.BackColor = Color.White
                pnlpink11.Show()
                pnlpink12.BackColor = Color.White
                pnlpink12.Show()
                pnlpink13.BackColor = Color.White
                pnlpink13.Show()
                pnlpink14.BackColor = Color.White
                pnlpink14.Show()
                pnlpink15.BackColor = Color.White
                pnlpink15.Show()
                pnlpink16.BackColor = Color.White
                pnlpink16.Show()
                pnlpinkcustomcolour.Show()
                pnlpinkoptions.Show()
        End Select

        Select Case anylevel
            Case 1
                lblanylevel.Text = "Level 1"
                pnlany1.BackColor = Color.White
                pnlany1.Show()
                pnlanycustomcolour.Show()
                pnlanyoptions.Show()
            Case 2
                lblanylevel.Text = "Level 2"
                pnlany1.BackColor = Color.White
                pnlany1.Show()
                pnlany2.BackColor = Color.White
                pnlany2.Show()
                pnlany3.BackColor = Color.White
                pnlany3.Show()
                pnlany4.BackColor = Color.White
                pnlany4.Show()
                pnlanycustomcolour.Show()
                pnlanyoptions.Show()
            Case 3
                lblanylevel.Text = "Level 3"
                pnlany1.BackColor = Color.White
                pnlany1.Show()
                pnlany2.BackColor = Color.White
                pnlany2.Show()
                pnlany3.BackColor = Color.White
                pnlany3.Show()
                pnlany4.BackColor = Color.White
                pnlany4.Show()
                pnlany5.BackColor = Color.White
                pnlany5.Show()
                pnlany6.BackColor = Color.White
                pnlany6.Show()
                pnlany7.BackColor = Color.White
                pnlany7.Show()
                pnlany8.BackColor = Color.White
                pnlany8.Show()
                pnlanycustomcolour.Show()
                pnlanyoptions.Show()
            Case 4
                lblanylevel.Text = "Level 4"
                pnlany1.BackColor = Color.White
                pnlany1.Show()
                pnlany2.BackColor = Color.White
                pnlany2.Show()
                pnlany3.BackColor = Color.White
                pnlany3.Show()
                pnlany4.BackColor = Color.White
                pnlany4.Show()
                pnlany5.BackColor = Color.White
                pnlany5.Show()
                pnlany6.BackColor = Color.White
                pnlany6.Show()
                pnlany7.BackColor = Color.White
                pnlany7.Show()
                pnlany8.BackColor = Color.White
                pnlany8.Show()
                pnlany9.BackColor = Color.White
                pnlany9.Show()
                pnlany10.BackColor = Color.White
                pnlany10.Show()
                pnlany11.BackColor = Color.White
                pnlany11.Show()
                pnlany12.BackColor = Color.White
                pnlany12.Show()
                pnlany13.BackColor = Color.White
                pnlany13.Show()
                pnlany14.BackColor = Color.White
                pnlany14.Show()
                pnlany15.BackColor = Color.White
                pnlany15.Show()
                pnlany16.BackColor = Color.White
                pnlany16.Show()
                pnlanycustomcolour.Show()
                pnlanyoptions.Show()
        End Select
    End Sub

    Private Sub pnloldcolour_Click(sender As Object, e As EventArgs) Handles pnloldcolour.Click
        Me.Close()
    End Sub

    Private Sub pnlnewcolour_Click(sender As Object, e As EventArgs) Handles pnlnewcolour.Click
        If sendToMod = True Then
            If Not My.Computer.FileSystem.DirectoryExists(NewAPI.modOutputPath) Then My.Computer.FileSystem.CreateDirectory(NewAPI.modOutputPath)
            Dim sw As System.IO.StreamWriter = New IO.StreamWriter(NewAPI.modOutputPath & "\givecolour.srip") ' ShiftOS Request/Receive* Information Protocol (SRIP) *Depends on the direction
            sw.WriteLine(pnlnewcolour.BackColor.ToArgb())
            sw.Close()
        End If
        Select Case colourtochange
            Case "Username Text Color"
                Shifter.usernametextcolor = pnlnewcolour.BackColor
            Case "Desktop Icon Text Color"
                Shifter.icontextcolor = pnlnewcolour.BackColor

            Case "Title Bar Colour"
                Shifter.titlebarcolour = pnlnewcolour.BackColor
                If Shifter.shifterskintitlebar(0) Is Nothing Then  Else Shifter.shifterskintitlebar(0).Dispose()
                If Shifter.shifterskintitlebar(1) Is Nothing Then  Else Shifter.shifterskintitlebar(1).Dispose()
                If Shifter.shifterskintitlebar(2) Is Nothing Then  Else Shifter.shifterskintitlebar(2).Dispose()
                Shifter.shifterskintitlebar(0) = Nothing
                Shifter.shifterskintitlebar(1) = Nothing
                Shifter.shifterskintitlebar(2) = Nothing
                Shifter.shifterskinimages(3) = ""
                Shifter.shifterskinimages(4) = ""
                Shifter.shifterskinimages(5) = ""
            Case "Window Border Colour"
                Shifter.windowbordercolour = pnlnewcolour.BackColor
                Shifter.windowborderleftcolour = pnlnewcolour.BackColor
                Shifter.windowborderrightcolour = pnlnewcolour.BackColor
                Shifter.windowborderbottomcolour = pnlnewcolour.BackColor
                Shifter.windowborderbottomrightcolour = pnlnewcolour.BackColor
                Shifter.windowborderbottomleftcolour = pnlnewcolour.BackColor
                If Shifter.skinwindowborderleft(0) Is Nothing Then  Else Shifter.skinwindowborderleft(0).Dispose()
                If Shifter.skinwindowborderleft(1) Is Nothing Then  Else Shifter.skinwindowborderleft(1).Dispose()
                If Shifter.skinwindowborderleft(2) Is Nothing Then  Else Shifter.skinwindowborderleft(2).Dispose()
                Shifter.skinwindowborderleft(0) = Nothing
                Shifter.skinwindowborderleft(1) = Nothing
                Shifter.skinwindowborderleft(2) = Nothing
                Shifter.shifterskinimages(27) = ""
                Shifter.shifterskinimages(28) = ""
                Shifter.shifterskinimages(29) = ""
                If Shifter.skinwindowborderright(0) Is Nothing Then  Else Shifter.skinwindowborderright(0).Dispose()
                If Shifter.skinwindowborderright(1) Is Nothing Then  Else Shifter.skinwindowborderright(1).Dispose()
                If Shifter.skinwindowborderright(2) Is Nothing Then  Else Shifter.skinwindowborderright(2).Dispose()
                Shifter.skinwindowborderright(0) = Nothing
                Shifter.skinwindowborderright(1) = Nothing
                Shifter.skinwindowborderright(2) = Nothing
                Shifter.shifterskinimages(30) = ""
                Shifter.shifterskinimages(31) = ""
                Shifter.shifterskinimages(32) = ""
                If Shifter.skinwindowborderbottom(0) Is Nothing Then  Else Shifter.skinwindowborderbottom(0).Dispose()
                If Shifter.skinwindowborderbottom(1) Is Nothing Then  Else Shifter.skinwindowborderbottom(1).Dispose()
                If Shifter.skinwindowborderbottom(2) Is Nothing Then  Else Shifter.skinwindowborderbottom(2).Dispose()
                Shifter.skinwindowborderbottom(0) = Nothing
                Shifter.skinwindowborderbottom(1) = Nothing
                Shifter.skinwindowborderbottom(2) = Nothing
                Shifter.shifterskinimages(33) = ""
                Shifter.shifterskinimages(34) = ""
                Shifter.shifterskinimages(35) = ""
                If Shifter.skinwindowborderbottomleft(0) Is Nothing Then  Else Shifter.skinwindowborderbottomleft(0).Dispose()
                If Shifter.skinwindowborderbottomleft(1) Is Nothing Then  Else Shifter.skinwindowborderbottomleft(1).Dispose()
                If Shifter.skinwindowborderbottomleft(2) Is Nothing Then  Else Shifter.skinwindowborderbottomleft(2).Dispose()
                Shifter.skinwindowborderbottomleft(0) = Nothing
                Shifter.skinwindowborderbottomleft(1) = Nothing
                Shifter.skinwindowborderbottomleft(2) = Nothing
                Shifter.shifterskinimages(39) = ""
                Shifter.shifterskinimages(40) = ""
                Shifter.shifterskinimages(41) = ""
                If Shifter.skinwindowborderbottomright(0) Is Nothing Then  Else Shifter.skinwindowborderbottomright(0).Dispose()
                If Shifter.skinwindowborderbottomright(1) Is Nothing Then  Else Shifter.skinwindowborderbottomright(1).Dispose()
                If Shifter.skinwindowborderbottomright(2) Is Nothing Then  Else Shifter.skinwindowborderbottomright(2).Dispose()
                Shifter.skinwindowborderbottomright(0) = Nothing
                Shifter.skinwindowborderbottomright(1) = Nothing
                Shifter.skinwindowborderbottomright(2) = Nothing
                Shifter.shifterskinimages(36) = ""
                Shifter.shifterskinimages(37) = ""
                Shifter.shifterskinimages(38) = ""
            Case "Close Button Colour"
                Shifter.closebuttoncolour = pnlnewcolour.BackColor
                If Shifter.skinclosebutton(0) Is Nothing Then  Else Shifter.skinclosebutton(0).Dispose()
                If Shifter.skinclosebutton(1) Is Nothing Then  Else Shifter.skinclosebutton(1).Dispose()
                If Shifter.skinclosebutton(2) Is Nothing Then  Else Shifter.skinclosebutton(2).Dispose()
                Shifter.skinclosebutton(0) = Nothing
                Shifter.skinclosebutton(1) = Nothing
                Shifter.skinclosebutton(2) = Nothing
                Shifter.shifterskinimages(0) = ""
                Shifter.shifterskinimages(1) = ""
                Shifter.shifterskinimages(2) = ""
            Case "Title Text Colour"
                Shifter.titletextcolour = pnlnewcolour.BackColor
            Case "Desktop Panel Colour"
                Shifter.desktoppanelcolour = pnlnewcolour.BackColor
                If Shifter.skindesktoppanel(0) Is Nothing Then  Else Shifter.skindesktoppanel(0).Dispose()
                If Shifter.skindesktoppanel(1) Is Nothing Then  Else Shifter.skindesktoppanel(1).Dispose()
                If Shifter.skindesktoppanel(2) Is Nothing Then  Else Shifter.skindesktoppanel(2).Dispose()
                Shifter.skindesktoppanel(0) = Nothing
                Shifter.skindesktoppanel(1) = Nothing
                Shifter.skindesktoppanel(2) = Nothing
                Shifter.shifterskinimages(18) = ""
                Shifter.shifterskinimages(19) = ""
                Shifter.shifterskinimages(20) = ""
            Case "Clock Text Colour"
                Shifter.clocktextcolour = pnlnewcolour.BackColor
            Case "Clock Background Colour"
                Shifter.clockbackgroundcolor = pnlnewcolour.BackColor
                If Shifter.skindesktoppaneltime(0) Is Nothing Then  Else Shifter.skindesktoppaneltime(0).Dispose()
                If Shifter.skindesktoppaneltime(1) Is Nothing Then  Else Shifter.skindesktoppaneltime(1).Dispose()
                If Shifter.skindesktoppaneltime(2) Is Nothing Then  Else Shifter.skindesktoppaneltime(2).Dispose()
                Shifter.skindesktoppaneltime(0) = Nothing
                Shifter.skindesktoppaneltime(1) = Nothing
                Shifter.skindesktoppaneltime(2) = Nothing
                Shifter.shifterskinimages(21) = ""
                Shifter.shifterskinimages(22) = ""
                Shifter.shifterskinimages(23) = ""
            Case "Desktop Background Colour"
                Shifter.desktopbackgroundcolour = pnlnewcolour.BackColor
                If Shifter.skindesktopbackground(0) Is Nothing Then  Else Shifter.skindesktopbackground(0).Dispose()
                If Shifter.skindesktopbackground(1) Is Nothing Then  Else Shifter.skindesktopbackground(1).Dispose()
                If Shifter.skindesktopbackground(2) Is Nothing Then  Else Shifter.skindesktopbackground(2).Dispose()
                Shifter.skindesktopbackground(0) = Nothing
                Shifter.skindesktopbackground(1) = Nothing
                Shifter.skindesktopbackground(2) = Nothing
                Shifter.shifterskinimages(6) = ""
                Shifter.shifterskinimages(7) = ""
                Shifter.shifterskinimages(8) = ""
            Case "Username Panel Background"
                Shifter.usernamebgcolor = pnlnewcolour.BackColor
            Case "Shutdown Button Background"
                Shifter.powerpanelbgcolor = pnlnewcolour.BackColor
            Case "App Launcher Button Colour"
                Shifter.applauncherbuttoncolour = pnlnewcolour.BackColor
                If Shifter.skinapplauncherbutton(0) Is Nothing Then  Else Shifter.skinapplauncherbutton(0).Dispose()
                If Shifter.skinapplauncherbutton(1) Is Nothing Then  Else Shifter.skinapplauncherbutton(1).Dispose()
                If Shifter.skinapplauncherbutton(2) Is Nothing Then  Else Shifter.skinapplauncherbutton(2).Dispose()
                Shifter.skinapplauncherbutton(0) = Nothing
                Shifter.skinapplauncherbutton(1) = Nothing
                Shifter.skinapplauncherbutton(2) = Nothing
                Shifter.shifterskinimages(24) = ""
                Shifter.shifterskinimages(25) = ""
                Shifter.shifterskinimages(26) = ""
            Case "App Launcher Button Clicked Colour"
                Shifter.applauncherbuttonclickedcolour = pnlnewcolour.BackColor
            Case "App Launcher Mouse Over Colour"
                Shifter.applaunchermouseovercolour = pnlnewcolour.BackColor
            Case "Roll Up Button Colour"
                Shifter.rollupbuttoncolour = pnlnewcolour.BackColor
                If Shifter.skinrollupbutton(0) Is Nothing Then  Else Shifter.skinrollupbutton(0).Dispose()
                If Shifter.skinrollupbutton(1) Is Nothing Then  Else Shifter.skinrollupbutton(1).Dispose()
                If Shifter.skinrollupbutton(2) Is Nothing Then  Else Shifter.skinrollupbutton(2).Dispose()
                Shifter.skinrollupbutton(0) = Nothing
                Shifter.skinrollupbutton(1) = Nothing
                Shifter.skinrollupbutton(2) = Nothing
                Shifter.shifterskinimages(9) = ""
                Shifter.shifterskinimages(10) = ""
                Shifter.shifterskinimages(11) = ""
            Case "App Launcher Button Text Colour"
                Shifter.applicationsbuttontextcolour = pnlnewcolour.BackColor
            Case "App Launcher Items Background Colour"
                Shifter.applauncherbackgroundcolour = pnlnewcolour.BackColor
            Case "Title Bar Left Corner Colour"
                Shifter.titlebarleftcornercolour = pnlnewcolour.BackColor
                If Shifter.skintitlebarleftcorner(0) Is Nothing Then  Else Shifter.skintitlebarleftcorner(0).Dispose()
                If Shifter.skintitlebarleftcorner(1) Is Nothing Then  Else Shifter.skintitlebarleftcorner(1).Dispose()
                If Shifter.skintitlebarleftcorner(2) Is Nothing Then  Else Shifter.skintitlebarleftcorner(2).Dispose()
                Shifter.skintitlebarleftcorner(0) = Nothing
                Shifter.skintitlebarleftcorner(1) = Nothing
                Shifter.skintitlebarleftcorner(2) = Nothing
                Shifter.shifterskinimages(15) = ""
                Shifter.shifterskinimages(16) = ""
                Shifter.shifterskinimages(17) = ""
            Case "Title Bar Right Corner Colour"
                Shifter.titlebarrightcornercolour = pnlnewcolour.BackColor
                If Shifter.skintitlebarrightcorner(0) Is Nothing Then  Else Shifter.skintitlebarrightcorner(0).Dispose()
                If Shifter.skintitlebarrightcorner(1) Is Nothing Then  Else Shifter.skintitlebarrightcorner(1).Dispose()
                If Shifter.skintitlebarrightcorner(2) Is Nothing Then  Else Shifter.skintitlebarrightcorner(2).Dispose()
                Shifter.skintitlebarrightcorner(0) = Nothing
                Shifter.skintitlebarrightcorner(1) = Nothing
                Shifter.skintitlebarrightcorner(2) = Nothing
                Shifter.shifterskinimages(12) = ""
                Shifter.shifterskinimages(13) = ""
                Shifter.shifterskinimages(14) = ""
            Case "Border Right Colour"
                Shifter.windowborderrightcolour = pnlnewcolour.BackColor
                If Shifter.skinwindowborderright(0) Is Nothing Then  Else Shifter.skinwindowborderright(0).Dispose()
                If Shifter.skinwindowborderright(1) Is Nothing Then  Else Shifter.skinwindowborderright(1).Dispose()
                If Shifter.skinwindowborderright(2) Is Nothing Then  Else Shifter.skinwindowborderright(2).Dispose()
                Shifter.skinwindowborderright(0) = Nothing
                Shifter.skinwindowborderright(1) = Nothing
                Shifter.skinwindowborderright(2) = Nothing
                Shifter.shifterskinimages(30) = ""
                Shifter.shifterskinimages(31) = ""
                Shifter.shifterskinimages(32) = ""
            Case "Border Left Colour"
                Shifter.windowborderleftcolour = pnlnewcolour.BackColor
                If Shifter.skinwindowborderleft(0) Is Nothing Then  Else Shifter.skinwindowborderleft(0).Dispose()
                If Shifter.skinwindowborderleft(1) Is Nothing Then  Else Shifter.skinwindowborderleft(1).Dispose()
                If Shifter.skinwindowborderleft(2) Is Nothing Then  Else Shifter.skinwindowborderleft(2).Dispose()
                Shifter.skinwindowborderleft(0) = Nothing
                Shifter.skinwindowborderleft(1) = Nothing
                Shifter.skinwindowborderleft(2) = Nothing
                Shifter.shifterskinimages(27) = ""
                Shifter.shifterskinimages(28) = ""
                Shifter.shifterskinimages(29) = ""
            Case "Border Bottom Colour"
                Shifter.windowborderbottomcolour = pnlnewcolour.BackColor
                If Shifter.skinwindowborderbottom(0) Is Nothing Then  Else Shifter.skinwindowborderbottom(0).Dispose()
                If Shifter.skinwindowborderbottom(1) Is Nothing Then  Else Shifter.skinwindowborderbottom(1).Dispose()
                If Shifter.skinwindowborderbottom(2) Is Nothing Then  Else Shifter.skinwindowborderbottom(2).Dispose()
                Shifter.skinwindowborderbottom(0) = Nothing
                Shifter.skinwindowborderbottom(1) = Nothing
                Shifter.skinwindowborderbottom(2) = Nothing
                Shifter.shifterskinimages(33) = ""
                Shifter.shifterskinimages(34) = ""
                Shifter.shifterskinimages(35) = ""
            Case "Border Bottom Left Colour"
                Shifter.windowborderbottomleftcolour = pnlnewcolour.BackColor
                If Shifter.skinwindowborderbottomleft(0) Is Nothing Then  Else Shifter.skinwindowborderbottomleft(0).Dispose()
                If Shifter.skinwindowborderbottomleft(1) Is Nothing Then  Else Shifter.skinwindowborderbottomleft(1).Dispose()
                If Shifter.skinwindowborderbottomleft(2) Is Nothing Then  Else Shifter.skinwindowborderbottomleft(2).Dispose()
                Shifter.skinwindowborderbottomleft(0) = Nothing
                Shifter.skinwindowborderbottomleft(1) = Nothing
                Shifter.skinwindowborderbottomleft(2) = Nothing
                Shifter.shifterskinimages(39) = ""
                Shifter.shifterskinimages(40) = ""
                Shifter.shifterskinimages(41) = ""
            Case "Border Bottom Right Colour"
                Shifter.windowborderbottomrightcolour = pnlnewcolour.BackColor
                If Shifter.skinwindowborderbottomright(0) Is Nothing Then  Else Shifter.skinwindowborderbottomright(0).Dispose()
                If Shifter.skinwindowborderbottomright(1) Is Nothing Then  Else Shifter.skinwindowborderbottomright(1).Dispose()
                If Shifter.skinwindowborderbottomright(2) Is Nothing Then  Else Shifter.skinwindowborderbottomright(2).Dispose()
                Shifter.skinwindowborderbottomright(0) = Nothing
                Shifter.skinwindowborderbottomright(1) = Nothing
                Shifter.skinwindowborderbottomright(2) = Nothing
                Shifter.shifterskinimages(36) = ""
                Shifter.shifterskinimages(37) = ""
                Shifter.shifterskinimages(38) = ""
            Case "Minimize Button Colour"
                Shifter.minimizebuttoncolour = pnlnewcolour.BackColor
                If Shifter.skinminimizebutton(0) Is Nothing Then  Else Shifter.skinminimizebutton(0).Dispose()
                If Shifter.skinminimizebutton(1) Is Nothing Then  Else Shifter.skinminimizebutton(1).Dispose()
                If Shifter.skinminimizebutton(2) Is Nothing Then  Else Shifter.skinminimizebutton(2).Dispose()
                Shifter.skinminimizebutton(0) = Nothing
                Shifter.skinminimizebutton(1) = Nothing
                Shifter.skinminimizebutton(2) = Nothing
                Shifter.shifterskinimages(42) = ""
                Shifter.shifterskinimages(43) = ""
                Shifter.shifterskinimages(44) = ""
            Case "Panel Button Colour"
                Shifter.panelbuttoncolour = pnlnewcolour.BackColor
                If Shifter.skinpanelbutton(0) Is Nothing Then  Else Shifter.skinpanelbutton(0).Dispose()
                If Shifter.skinpanelbutton(1) Is Nothing Then  Else Shifter.skinpanelbutton(1).Dispose()
                If Shifter.skinpanelbutton(2) Is Nothing Then  Else Shifter.skinpanelbutton(2).Dispose()
                Shifter.skinpanelbutton(0) = Nothing
                Shifter.skinpanelbutton(1) = Nothing
                Shifter.skinpanelbutton(2) = Nothing
                Shifter.shifterskinimages(45) = ""
                Shifter.shifterskinimages(46) = ""
                Shifter.shifterskinimages(47) = ""
            Case "Panel Button Text Colour"
                Shifter.panelbuttontextcolour = pnlnewcolour.BackColor
            Case "OrcWrite text colour dono"
                OrcWrite.Button6.BackColor = pnlnewcolour.BackColor
                OrcWrite.RichTextBox1.SelectionColor = pnlnewcolour.BackColor
            Case "OrcWrite highlight text colour dono"
                OrcWrite.Button7.BackColor = pnlnewcolour.BackColor
                OrcWrite.RichTextBox1.SelectionBackColor = pnlnewcolour.BackColor
            Case "artpallet1" : ArtPad.colourpallet1.BackColor = pnlnewcolour.BackColor
            Case "artpallet2" : ArtPad.colourpallet2.BackColor = pnlnewcolour.BackColor
            Case "artpallet3" : ArtPad.colourpallet3.BackColor = pnlnewcolour.BackColor
            Case "artpallet4" : ArtPad.colourpallet4.BackColor = pnlnewcolour.BackColor
            Case "artpallet5" : ArtPad.colourpallet5.BackColor = pnlnewcolour.BackColor
            Case "artpallet6" : ArtPad.colourpallet6.BackColor = pnlnewcolour.BackColor
            Case "artpallet7" : ArtPad.colourpallet7.BackColor = pnlnewcolour.BackColor
            Case "artpallet8" : ArtPad.colourpallet8.BackColor = pnlnewcolour.BackColor
            Case "artpallet9" : ArtPad.colourpallet9.BackColor = pnlnewcolour.BackColor
            Case "artpallet10" : ArtPad.colourpallet10.BackColor = pnlnewcolour.BackColor
            Case "artpallet11" : ArtPad.colourpallet11.BackColor = pnlnewcolour.BackColor
            Case "artpallet12" : ArtPad.colourpallet12.BackColor = pnlnewcolour.BackColor
            Case "artpallet13" : ArtPad.colourpallet13.BackColor = pnlnewcolour.BackColor
            Case "artpallet14" : ArtPad.colourpallet14.BackColor = pnlnewcolour.BackColor
            Case "artpallet15" : ArtPad.colourpallet15.BackColor = pnlnewcolour.BackColor
            Case "artpallet16" : ArtPad.colourpallet16.BackColor = pnlnewcolour.BackColor
            Case "artpallet17" : ArtPad.colourpallet17.BackColor = pnlnewcolour.BackColor
            Case "artpallet18" : ArtPad.colourpallet18.BackColor = pnlnewcolour.BackColor
            Case "artpallet19" : ArtPad.colourpallet19.BackColor = pnlnewcolour.BackColor
            Case "artpallet20" : ArtPad.colourpallet20.BackColor = pnlnewcolour.BackColor
            Case "artpallet21" : ArtPad.colourpallet21.BackColor = pnlnewcolour.BackColor
            Case "artpallet22" : ArtPad.colourpallet22.BackColor = pnlnewcolour.BackColor
            Case "artpallet23" : ArtPad.colourpallet23.BackColor = pnlnewcolour.BackColor
            Case "artpallet24" : ArtPad.colourpallet24.BackColor = pnlnewcolour.BackColor
            Case "artpallet25" : ArtPad.colourpallet25.BackColor = pnlnewcolour.BackColor
            Case "artpallet26" : ArtPad.colourpallet26.BackColor = pnlnewcolour.BackColor
            Case "artpallet27" : ArtPad.colourpallet27.BackColor = pnlnewcolour.BackColor
            Case "artpallet28" : ArtPad.colourpallet28.BackColor = pnlnewcolour.BackColor
            Case "artpallet29" : ArtPad.colourpallet29.BackColor = pnlnewcolour.BackColor
            Case "artpallet30" : ArtPad.colourpallet30.BackColor = pnlnewcolour.BackColor
            Case "artpallet31" : ArtPad.colourpallet31.BackColor = pnlnewcolour.BackColor
            Case "artpallet32" : ArtPad.colourpallet32.BackColor = pnlnewcolour.BackColor
            Case "artpallet33" : ArtPad.colourpallet33.BackColor = pnlnewcolour.BackColor
            Case "artpallet34" : ArtPad.colourpallet34.BackColor = pnlnewcolour.BackColor
            Case "artpallet35" : ArtPad.colourpallet35.BackColor = pnlnewcolour.BackColor
            Case "artpallet36" : ArtPad.colourpallet36.BackColor = pnlnewcolour.BackColor
            Case "artpallet37" : ArtPad.colourpallet37.BackColor = pnlnewcolour.BackColor
            Case "artpallet38" : ArtPad.colourpallet38.BackColor = pnlnewcolour.BackColor
            Case "artpallet39" : ArtPad.colourpallet39.BackColor = pnlnewcolour.BackColor
            Case "artpallet40" : ArtPad.colourpallet40.BackColor = pnlnewcolour.BackColor
            Case "artpallet41" : ArtPad.colourpallet41.BackColor = pnlnewcolour.BackColor
            Case "artpallet42" : ArtPad.colourpallet42.BackColor = pnlnewcolour.BackColor
            Case "artpallet43" : ArtPad.colourpallet43.BackColor = pnlnewcolour.BackColor
            Case "artpallet44" : ArtPad.colourpallet44.BackColor = pnlnewcolour.BackColor
            Case "artpallet45" : ArtPad.colourpallet45.BackColor = pnlnewcolour.BackColor
            Case "artpallet46" : ArtPad.colourpallet46.BackColor = pnlnewcolour.BackColor
            Case "artpallet47" : ArtPad.colourpallet47.BackColor = pnlnewcolour.BackColor
            Case "artpallet48" : ArtPad.colourpallet48.BackColor = pnlnewcolour.BackColor
            Case "artpallet49" : ArtPad.colourpallet49.BackColor = pnlnewcolour.BackColor
            Case "artpallet50" : ArtPad.colourpallet50.BackColor = pnlnewcolour.BackColor
            Case "artpallet51" : ArtPad.colourpallet51.BackColor = pnlnewcolour.BackColor
            Case "artpallet52" : ArtPad.colourpallet52.BackColor = pnlnewcolour.BackColor
            Case "artpallet53" : ArtPad.colourpallet53.BackColor = pnlnewcolour.BackColor
            Case "artpallet54" : ArtPad.colourpallet54.BackColor = pnlnewcolour.BackColor
            Case "artpallet55" : ArtPad.colourpallet55.BackColor = pnlnewcolour.BackColor
            Case "artpallet56" : ArtPad.colourpallet56.BackColor = pnlnewcolour.BackColor
            Case "artpallet57" : ArtPad.colourpallet57.BackColor = pnlnewcolour.BackColor
            Case "artpallet58" : ArtPad.colourpallet58.BackColor = pnlnewcolour.BackColor
            Case "artpallet59" : ArtPad.colourpallet59.BackColor = pnlnewcolour.BackColor
            Case "artpallet60" : ArtPad.colourpallet60.BackColor = pnlnewcolour.BackColor
            Case "artpallet61" : ArtPad.colourpallet61.BackColor = pnlnewcolour.BackColor
            Case "artpallet62" : ArtPad.colourpallet62.BackColor = pnlnewcolour.BackColor
            Case "artpallet63" : ArtPad.colourpallet63.BackColor = pnlnewcolour.BackColor
            Case "artpallet64" : ArtPad.colourpallet64.BackColor = pnlnewcolour.BackColor
            Case "artpallet65" : ArtPad.colourpallet65.BackColor = pnlnewcolour.BackColor
            Case "artpallet66" : ArtPad.colourpallet66.BackColor = pnlnewcolour.BackColor
            Case "artpallet67" : ArtPad.colourpallet67.BackColor = pnlnewcolour.BackColor
            Case "artpallet68" : ArtPad.colourpallet68.BackColor = pnlnewcolour.BackColor
            Case "artpallet69" : ArtPad.colourpallet69.BackColor = pnlnewcolour.BackColor
            Case "artpallet70" : ArtPad.colourpallet70.BackColor = pnlnewcolour.BackColor
            Case "artpallet71" : ArtPad.colourpallet71.BackColor = pnlnewcolour.BackColor
            Case "artpallet72" : ArtPad.colourpallet72.BackColor = pnlnewcolour.BackColor
            Case "artpallet73" : ArtPad.colourpallet73.BackColor = pnlnewcolour.BackColor
            Case "artpallet74" : ArtPad.colourpallet74.BackColor = pnlnewcolour.BackColor
            Case "artpallet75" : ArtPad.colourpallet75.BackColor = pnlnewcolour.BackColor
            Case "artpallet76" : ArtPad.colourpallet76.BackColor = pnlnewcolour.BackColor
            Case "artpallet77" : ArtPad.colourpallet77.BackColor = pnlnewcolour.BackColor
            Case "artpallet78" : ArtPad.colourpallet78.BackColor = pnlnewcolour.BackColor
            Case "artpallet79" : ArtPad.colourpallet79.BackColor = pnlnewcolour.BackColor
            Case "artpallet80" : ArtPad.colourpallet80.BackColor = pnlnewcolour.BackColor
            Case "artpallet81" : ArtPad.colourpallet81.BackColor = pnlnewcolour.BackColor
            Case "artpallet82" : ArtPad.colourpallet82.BackColor = pnlnewcolour.BackColor
            Case "artpallet83" : ArtPad.colourpallet83.BackColor = pnlnewcolour.BackColor
            Case "artpallet84" : ArtPad.colourpallet84.BackColor = pnlnewcolour.BackColor
            Case "artpallet85" : ArtPad.colourpallet85.BackColor = pnlnewcolour.BackColor
            Case "artpallet86" : ArtPad.colourpallet86.BackColor = pnlnewcolour.BackColor
            Case "artpallet87" : ArtPad.colourpallet87.BackColor = pnlnewcolour.BackColor
            Case "artpallet88" : ArtPad.colourpallet88.BackColor = pnlnewcolour.BackColor
            Case "artpallet89" : ArtPad.colourpallet89.BackColor = pnlnewcolour.BackColor
            Case "artpallet90" : ArtPad.colourpallet90.BackColor = pnlnewcolour.BackColor
            Case "artpallet91" : ArtPad.colourpallet91.BackColor = pnlnewcolour.BackColor
            Case "artpallet92" : ArtPad.colourpallet92.BackColor = pnlnewcolour.BackColor
            Case "artpallet93" : ArtPad.colourpallet93.BackColor = pnlnewcolour.BackColor
            Case "artpallet94" : ArtPad.colourpallet94.BackColor = pnlnewcolour.BackColor
            Case "artpallet95" : ArtPad.colourpallet95.BackColor = pnlnewcolour.BackColor
            Case "artpallet96" : ArtPad.colourpallet96.BackColor = pnlnewcolour.BackColor
            Case "artpallet97" : ArtPad.colourpallet97.BackColor = pnlnewcolour.BackColor
            Case "artpallet98" : ArtPad.colourpallet98.BackColor = pnlnewcolour.BackColor
            Case "artpallet99" : ArtPad.colourpallet99.BackColor = pnlnewcolour.BackColor
            Case "artpallet100" : ArtPad.colourpallet100.BackColor = pnlnewcolour.BackColor
            Case "artpallet101" : ArtPad.colourpallet101.BackColor = pnlnewcolour.BackColor
            Case "artpallet102" : ArtPad.colourpallet102.BackColor = pnlnewcolour.BackColor
            Case "artpallet103" : ArtPad.colourpallet103.BackColor = pnlnewcolour.BackColor
            Case "artpallet104" : ArtPad.colourpallet104.BackColor = pnlnewcolour.BackColor
            Case "artpallet105" : ArtPad.colourpallet105.BackColor = pnlnewcolour.BackColor
            Case "artpallet106" : ArtPad.colourpallet106.BackColor = pnlnewcolour.BackColor
            Case "artpallet107" : ArtPad.colourpallet107.BackColor = pnlnewcolour.BackColor
            Case "artpallet108" : ArtPad.colourpallet108.BackColor = pnlnewcolour.BackColor
            Case "artpallet109" : ArtPad.colourpallet109.BackColor = pnlnewcolour.BackColor
            Case "artpallet110" : ArtPad.colourpallet110.BackColor = pnlnewcolour.BackColor
            Case "artpallet111" : ArtPad.colourpallet111.BackColor = pnlnewcolour.BackColor
            Case "artpallet112" : ArtPad.colourpallet112.BackColor = pnlnewcolour.BackColor
            Case "artpallet113" : ArtPad.colourpallet113.BackColor = pnlnewcolour.BackColor
            Case "artpallet114" : ArtPad.colourpallet114.BackColor = pnlnewcolour.BackColor
            Case "artpallet115" : ArtPad.colourpallet115.BackColor = pnlnewcolour.BackColor
            Case "artpallet116" : ArtPad.colourpallet116.BackColor = pnlnewcolour.BackColor
            Case "artpallet117" : ArtPad.colourpallet117.BackColor = pnlnewcolour.BackColor
            Case "artpallet118" : ArtPad.colourpallet118.BackColor = pnlnewcolour.BackColor
            Case "artpallet119" : ArtPad.colourpallet119.BackColor = pnlnewcolour.BackColor
            Case "artpallet120" : ArtPad.colourpallet120.BackColor = pnlnewcolour.BackColor
            Case "artpallet121" : ArtPad.colourpallet121.BackColor = pnlnewcolour.BackColor
            Case "artpallet122" : ArtPad.colourpallet122.BackColor = pnlnewcolour.BackColor
            Case "artpallet123" : ArtPad.colourpallet123.BackColor = pnlnewcolour.BackColor
            Case "artpallet124" : ArtPad.colourpallet124.BackColor = pnlnewcolour.BackColor
            Case "artpallet125" : ArtPad.colourpallet125.BackColor = pnlnewcolour.BackColor
            Case "artpallet126" : ArtPad.colourpallet126.BackColor = pnlnewcolour.BackColor
            Case "artpallet127" : ArtPad.colourpallet127.BackColor = pnlnewcolour.BackColor
            Case "artpallet128" : ArtPad.colourpallet128.BackColor = pnlnewcolour.BackColor
            Case "launcher items text colour" : Shifter.launcheritemtxtcolour.BackColor = pnlnewcolour.BackColor

        End Select

        If colourtochange.Contains("artpallet") Then
            ArtPad.drawingcolour = pnlnewcolour.BackColor
            ArtPad.setuppreview()
            ArtPad.settoolcolours()
        ElseIf colourtochange.Contains("dono") Then
            'Use "dono" tag to stop it setting up the the shifter preview
            ShiftOSDesktop.lastcolourpick = pnlnewcolour.BackColor
        Else
            ShiftOSDesktop.lastcolourpick = pnlnewcolour.BackColor
            Shifter.setuppreshifterstuff()
        End If

        Me.Close()
    End Sub

    Private Sub pnloldcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnloldcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnloldcolour.ClientRectangle)
    End Sub

    Private Sub pnlanycolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlanycolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlanycolours.ClientRectangle)
    End Sub

    Private Sub pnlgraycolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlgraycolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlgraycolours.ClientRectangle)
    End Sub

    Private Sub pnlpurplecolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlpurplecolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlpurplecolours.ClientRectangle)
    End Sub

    Private Sub pnlbluecolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlbluecolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlbluecolours.ClientRectangle)
    End Sub

    Private Sub pnlgreencolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlgreencolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlgreencolours.ClientRectangle)
    End Sub

    Private Sub pnlyellowcolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlyellowcolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlyellowcolours.ClientRectangle)
    End Sub

    Private Sub pnlorangecolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlorangecolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlorangecolours.ClientRectangle)
    End Sub

    Private Sub pnlbrowncolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlbrowncolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlbrowncolours.ClientRectangle)
    End Sub

    Private Sub pnlredcolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlredcolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlredcolours.ClientRectangle)
    End Sub

    Private Sub pnlpinkcolours_Paint(sender As Object, e As PaintEventArgs) Handles pnlpinkcolours.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), pnlpinkcolours.ClientRectangle)
    End Sub

    Private Sub pnlnewcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlnewcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlnewcolour.ClientRectangle)
    End Sub

    Private Sub colourselctiongray(sender As Object, e As MouseEventArgs) Handles pnlgray1.Click, pnlgray2.Click, pnlgray3.Click, pnlgray4.Click, pnlgray5.Click, pnlgray6.Click, pnlgray7.Click, pnlgray8.Click, pnlgray9.Click, pnlgray10.Click, pnlgray11.Click, pnlgray12.Click, pnlgray13.Click, pnlgray14.Click, pnlgray15.Click, pnlgray16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlgraycustomcolour.BackColor
            savegraymemory()
        End If
    End Sub

    Private Sub colourselctionpurple(sender As Object, e As MouseEventArgs) Handles pnlpurple1.Click, pnlpurple2.Click, pnlpurple3.Click, pnlpurple4.Click, pnlpurple5.Click, pnlpurple6.Click, pnlpurple7.Click, pnlpurple8.Click, pnlpurple9.Click, pnlpurple10.Click, pnlpurple11.Click, pnlpurple12.Click, pnlpurple13.Click, pnlpurple14.Click, pnlpurple15.Click, pnlpurple16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlpurplecustomcolour.BackColor
            savepurplememory()
        End If
    End Sub

    Private Sub colourselctionblue(sender As Object, e As MouseEventArgs) Handles pnlblue1.Click, pnlblue2.Click, pnlblue3.Click, pnlblue4.Click, pnlblue5.Click, pnlblue6.Click, pnlblue7.Click, pnlblue8.Click, pnlblue9.Click, pnlblue10.Click, pnlblue11.Click, pnlblue12.Click, pnlblue13.Click, pnlblue14.Click, pnlblue15.Click, pnlblue16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlbluecustomcolour.BackColor
            savebluememory()
        End If
    End Sub

    Private Sub colourselctiongreen(sender As Object, e As MouseEventArgs) Handles pnlgreen1.Click, pnlgreen2.Click, pnlgreen3.Click, pnlgreen4.Click, pnlgreen5.Click, pnlgreen6.Click, pnlgreen7.Click, pnlgreen8.Click, pnlgreen9.Click, pnlgreen10.Click, pnlgreen11.Click, pnlgreen12.Click, pnlgreen13.Click, pnlgreen14.Click, pnlgreen15.Click, pnlgreen16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlgreencustomcolour.BackColor
            savegreenmemory()
        End If
    End Sub

    Private Sub colourselctionyellow(sender As Object, e As MouseEventArgs) Handles pnlyellow1.Click, pnlyellow2.Click, pnlyellow3.Click, pnlyellow4.Click, pnlyellow5.Click, pnlyellow6.Click, pnlyellow7.Click, pnlyellow8.Click, pnlyellow9.Click, pnlyellow10.Click, pnlyellow11.Click, pnlyellow12.Click, pnlyellow13.Click, pnlyellow14.Click, pnlyellow15.Click, pnlyellow16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlyellowcustomcolour.BackColor
            saveyellowmemory()
        End If
    End Sub

    Private Sub colourselctionorange(sender As Object, e As MouseEventArgs) Handles pnlorange1.Click, pnlorange2.Click, pnlorange3.Click, pnlorange4.Click, pnlorange5.Click, pnlorange6.Click, pnlorange7.Click, pnlorange8.Click, pnlorange9.Click, pnlorange10.Click, pnlorange11.Click, pnlorange12.Click, pnlorange13.Click, pnlorange14.Click, pnlorange15.Click, pnlorange16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlorangecustomcolour.BackColor
            saveorangememory()
        End If
    End Sub

    Private Sub colourselctionbrown(sender As Object, e As MouseEventArgs) Handles pnlbrown1.Click, pnlbrown2.Click, pnlbrown3.Click, pnlbrown4.Click, pnlbrown5.Click, pnlbrown6.Click, pnlbrown7.Click, pnlbrown8.Click, pnlbrown9.Click, pnlbrown10.Click, pnlbrown11.Click, pnlbrown12.Click, pnlbrown13.Click, pnlbrown14.Click, pnlbrown15.Click, pnlbrown16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlbrowncustomcolour.BackColor
            savebrownmemory()
        End If
    End Sub

    Private Sub colourselctionred(sender As Object, e As MouseEventArgs) Handles pnlred1.Click, pnlred2.Click, pnlred3.Click, pnlred4.Click, pnlred5.Click, pnlred6.Click, pnlred7.Click, pnlred8.Click, pnlred9.Click, pnlred10.Click, pnlred11.Click, pnlred12.Click, pnlred13.Click, pnlred14.Click, pnlred15.Click, pnlred16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlredcustomcolour.BackColor
            saveredmemory()
        End If
    End Sub

    Private Sub colourselctionpink(sender As Object, e As MouseEventArgs) Handles pnlpink1.Click, pnlpink2.Click, pnlpink3.Click, pnlpink4.Click, pnlpink5.Click, pnlpink6.Click, pnlpink7.Click, pnlpink8.Click, pnlpink9.Click, pnlpink10.Click, pnlpink11.Click, pnlpink12.Click, pnlpink13.Click, pnlpink14.Click, pnlpink15.Click, pnlpink16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlpinkcustomcolour.BackColor
            savepinkmemory()
        End If
    End Sub

    Private Sub colourselctionany(sender As Object, e As MouseEventArgs) Handles pnlany1.Click, pnlany2.Click, pnlany3.Click, pnlany4.Click, pnlany5.Click, pnlany6.Click, pnlany7.Click, pnlany8.Click, pnlany9.Click, pnlany10.Click, pnlany11.Click, pnlany12.Click, pnlany13.Click, pnlany14.Click, pnlany15.Click, pnlany16.Click
        If e.Button = MouseButtons.Left Then
            pnlnewcolour.BackColor = sender.backcolor
            If pnlnewcolour.BackColor.IsNamedColor Then
                If pnlnewcolour.BackColor.Name.Length > 12 Then
                    lblnewcolourname.Text = pnlnewcolour.BackColor.Name
                Else
                    lblnewcolourname.Text = "Name: " & pnlnewcolour.BackColor.Name
                End If
            Else
                lblnewcolourname.Text = "Name: Custom"
            End If
            lblnewcolourrgb.Text = "RGB: " & pnlnewcolour.BackColor.R & ", " & pnlnewcolour.BackColor.G & ", " & pnlnewcolour.BackColor.B
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            sender.backcolor = pnlanycustomcolour.BackColor
            saveanymemory()
        End If
    End Sub

    Private Sub txtcustomgrayshade_TextChanged(sender As Object, e As EventArgs) Handles txtcustomgrayshade.TextChanged
        If txtcustomgrayshade.Text = "" Then
            txtcustomgrayshade.Text = "0"
        Else
            If Convert.ToInt32(txtcustomgrayshade.Text) > 255 Then
                txtcustomgrayshade.Text = "255"
            Else
                pnlgraycustomcolour.BackColor = Color.FromArgb(txtcustomgrayshade.Text, txtcustomgrayshade.Text, txtcustomgrayshade.Text)
            End If
        End If
    End Sub

    Private Sub CheckForNumber(sender As Object, e As KeyPressEventArgs) Handles txtcustomgrayshade.KeyPress, txtpurplesblue.KeyPress, txtpurplesgreen.KeyPress, txtpurplesred.KeyPress, txtbluesblue.KeyPress, txtbluesgreen.KeyPress, txtbluesred.KeyPress, txtgreensblue.KeyPress, txtgreensgreen.KeyPress, txtgreensred.KeyPress, txtyellowsblue.KeyPress, txtyellowsgreen.KeyPress, txtyellowsred.KeyPress, txtorangesblue.KeyPress, txtorangesgreen.KeyPress, txtorangesred.KeyPress, txtbrownsblue.KeyPress, txtbrownsgreen.KeyPress, txtbrownsred.KeyPress, txtredsblue.KeyPress, txtredsgreen.KeyPress, txtredsred.KeyPress, txtpinksblue.KeyPress, txtpinksgreen.KeyPress, txtpinksred.KeyPress, txtanysblue.KeyPress, txtanysgreen.KeyPress, txtanysred.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub customcolourfailsafe()
        If txtcustomgrayshade.Text = "" Then txtcustomgrayshade.Text = "0"

        If txtanysblue.Text = "" Then txtanysblue.Text = "0"
        If txtanysred.Text = "" Then txtanysred.Text = "0"
        If txtanysgreen.Text = "" Then txtanysgreen.Text = "0"

        If txtpurplesblue.Text = "" Then txtpurplesblue.Text = "255"
        If txtpurplesred.Text = "" Then txtpurplesred.Text = "150"
        If txtpurplesgreen.Text = "" Then txtpurplesgreen.Text = "0"

        If txtbluesblue.Text = "" Then txtbluesblue.Text = "255"
        If txtbluesred.Text = "" Then txtbluesred.Text = "0"
        If txtbluesgreen.Text = "" Then txtbluesgreen.Text = "0"

        If txtgreensblue.Text = "" Then txtgreensblue.Text = "0"
        If txtgreensred.Text = "" Then txtgreensred.Text = "0"
        If txtgreensgreen.Text = "" Then txtgreensgreen.Text = "255"

        If txtyellowsblue.Text = "" Then txtyellowsblue.Text = "0"
        If txtyellowsred.Text = "" Then txtyellowsred.Text = "255"
        If txtyellowsgreen.Text = "" Then txtyellowsgreen.Text = "255"

        If txtorangesblue.Text = "" Then txtorangesblue.Text = "0"
        If txtorangesred.Text = "" Then txtorangesred.Text = "255"
        If txtorangesgreen.Text = "" Then txtorangesgreen.Text = "60"

        If txtbrownsblue.Text = "" Then txtbrownsblue.Text = "0"
        If txtbrownsred.Text = "" Then txtbrownsred.Text = "140"
        If txtbrownsgreen.Text = "" Then txtbrownsgreen.Text = "60"

        If txtredsblue.Text = "" Then txtredsblue.Text = "0"
        If txtredsred.Text = "" Then txtredsred.Text = "255"
        If txtredsgreen.Text = "" Then txtredsgreen.Text = "0"

        If txtpinksblue.Text = "" Then txtpinksblue.Text = "150"
        If txtpinksred.Text = "" Then txtpinksred.Text = "250"
        If txtpinksgreen.Text = "" Then txtpinksgreen.Text = "0"
    End Sub

    Private Sub txtpurplesgreen_TextChanged(sender As Object, e As EventArgs) Handles txtpurplesgreen.TextChanged, txtpurplesblue.TextChanged, txtpurplesred.TextChanged
        On Error Resume Next
        pnlpurplecustomcolour.BackColor = Color.FromArgb(txtpurplesred.Text, txtpurplesgreen.Text, txtpurplesblue.Text)
    End Sub

    Private Sub pnlpurpleoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlpurpleoptions.MouseLeave, pnlpurpleoptions.MouseEnter, pnlpurplecolours.MouseEnter, pnlpurplecolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtpurplesblue.Text) > 255 Then
            txtpurplesblue.Text = "255"
        End If
        If Convert.ToInt32(txtpurplesred.Text) > Convert.ToInt32(txtpurplesblue.Text) Then
            txtpurplesred.Text = txtpurplesblue.Text
        End If
        If Convert.ToInt32(txtpurplesgreen.Text) > Convert.ToInt32(txtpurplesblue.Text) Then
            txtpurplesgreen.Text = txtpurplesred.Text
        End If
        If Convert.ToInt32(txtpurplesgreen.Text) > Convert.ToInt32(txtpurplesred.Text) Then
            txtpurplesgreen.Text = txtpurplesred.Text
        End If
        pnlpurplecustomcolour.BackColor = Color.FromArgb(txtpurplesred.Text, txtpurplesgreen.Text, txtpurplesblue.Text)
    End Sub

    Private Sub txtbluesgreen_TextChanged(sender As Object, e As EventArgs) Handles txtbluesgreen.TextChanged, txtbluesblue.TextChanged, txtbluesred.TextChanged
        On Error Resume Next
        pnlbluecustomcolour.BackColor = Color.FromArgb(txtbluesred.Text, txtbluesgreen.Text, txtbluesblue.Text)
    End Sub

    Private Sub pnlblueoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlblueoptions.MouseLeave, pnlblueoptions.MouseEnter, pnlbluecolours.MouseEnter, pnlbluecolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtbluesblue.Text) > 255 Then
            txtbluesblue.Text = "255"
        End If
        If Convert.ToInt32(txtbluesgreen.Text) > Convert.ToInt32(txtbluesblue.Text) Then
            txtbluesgreen.Text = txtbluesblue.Text
        End If
        If Convert.ToInt32(txtbluesred.Text) > Convert.ToInt32(txtbluesblue.Text) Then
            txtbluesred.Text = txtbluesgreen.Text
        End If
        If Convert.ToInt32(txtbluesred.Text) > Convert.ToInt32(txtbluesgreen.Text) Then
            txtbluesred.Text = txtbluesgreen.Text
        End If
        pnlbluecustomcolour.BackColor = Color.FromArgb(txtbluesred.Text, txtbluesgreen.Text, txtbluesblue.Text)
    End Sub

    Private Sub txtgreensgreen_TextChanged(sender As Object, e As EventArgs) Handles txtgreensgreen.TextChanged, txtgreensblue.TextChanged, txtgreensred.TextChanged
        On Error Resume Next
        pnlgreencustomcolour.BackColor = Color.FromArgb(txtgreensred.Text, txtgreensgreen.Text, txtgreensblue.Text)
    End Sub

    Private Sub pnlgreenoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlgreenoptions.MouseLeave, pnlgreenoptions.MouseEnter, pnlgreencolours.MouseEnter, pnlgreencolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtgreensgreen.Text) > 255 Then
            txtgreensgreen.Text = "255"
        End If
        If Convert.ToInt32(txtgreensblue.Text) > Convert.ToInt32(txtgreensgreen.Text) Then
            txtgreensblue.Text = txtgreensgreen.Text
        End If
        If Convert.ToInt32(txtgreensred.Text) > Convert.ToInt32(txtgreensgreen.Text) Then
            txtgreensred.Text = txtgreensgreen.Text
        End If
        If Convert.ToInt32(txtgreensblue.Text) > Convert.ToInt32(txtgreensred.Text + 150) Then
            txtgreensblue.Text = Convert.ToInt32(txtgreensred.Text + 150)
        End If
        If Convert.ToInt32(txtgreensred.Text) > Convert.ToInt32(txtgreensblue.Text + 150) Then
            txtgreensred.Text = Convert.ToInt32(txtgreensblue.Text + 150)
        End If
        pnlgreencustomcolour.BackColor = Color.FromArgb(txtgreensred.Text, txtgreensgreen.Text, txtgreensblue.Text)
    End Sub

    Private Sub txtyellowsred_TextChanged(sender As Object, e As EventArgs) Handles txtyellowsred.TextChanged, txtyellowsblue.TextChanged, txtyellowsgreen.TextChanged
        On Error Resume Next
        pnlyellowcustomcolour.BackColor = Color.FromArgb(txtyellowsred.Text, txtyellowsgreen.Text, txtyellowsblue.Text)
    End Sub

    Private Sub pnlyellowoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlyellowoptions.MouseLeave, pnlyellowoptions.MouseEnter, pnlyellowcolours.MouseEnter, pnlyellowcolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtyellowsred.Text) > 255 Then
            txtyellowsred.Text = "255"
        End If
        If Convert.ToInt32(txtyellowsred.Text) < 180 Then
            txtyellowsred.Text = "180"
        End If
        If Convert.ToInt32(txtyellowsgreen.Text) > Convert.ToInt32(txtyellowsred.Text) Then
            txtyellowsgreen.Text = txtyellowsred.Text
        End If
        If Convert.ToInt32(txtyellowsgreen.Text) < Convert.ToInt32(txtyellowsred.Text - 30) Then
            txtyellowsgreen.Text = Convert.ToInt32(txtyellowsred.Text - 30)
        End If
        If Convert.ToInt32(txtyellowsblue.Text) > Convert.ToInt32(txtyellowsgreen.Text) Then
            txtyellowsblue.Text = txtyellowsgreen.Text
        End If
        pnlyellowcustomcolour.BackColor = Color.FromArgb(txtyellowsred.Text, txtyellowsgreen.Text, txtyellowsblue.Text)
    End Sub

    Private Sub txtorangesred_TextChanged(sender As Object, e As EventArgs) Handles txtorangesred.TextChanged, txtorangesblue.TextChanged, txtorangesgreen.TextChanged
        On Error Resume Next
        pnlorangecustomcolour.BackColor = Color.FromArgb(txtorangesred.Text, txtorangesgreen.Text, txtorangesblue.Text)
    End Sub

    Private Sub pnlorangeoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlorangeoptions.MouseLeave, pnlorangeoptions.MouseEnter, pnlorangecolours.MouseEnter, pnlyellowcolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtorangesred.Text) > 255 Then
            txtorangesred.Text = "255"
        End If
        If Convert.ToInt32(txtorangesred.Text) < 255 Then
            txtorangesred.Text = "255"
        End If
        If Convert.ToInt32(txtorangesgreen.Text) > Convert.ToInt32(txtorangesred.Text - 100) Then
            txtorangesgreen.Text = Convert.ToInt32(txtorangesred.Text - 100)
        End If
        If Convert.ToInt32(txtorangesgreen.Text) < 30 Then
            txtorangesgreen.Text = "30"
        End If
        If Convert.ToInt32(txtorangesblue.Text) > Convert.ToInt32(txtorangesgreen.Text - 30) Then
            txtorangesblue.Text = Convert.ToInt32(txtorangesgreen.Text - 30)
        End If
        pnlorangecustomcolour.BackColor = Color.FromArgb(txtorangesred.Text, txtorangesgreen.Text, txtorangesblue.Text)
    End Sub

    Private Sub txtbrownsred_TextChanged(sender As Object, e As EventArgs) Handles txtbrownsred.TextChanged, txtbrownsblue.TextChanged, txtbrownsgreen.TextChanged
        On Error Resume Next
        pnlbrowncustomcolour.BackColor = Color.FromArgb(txtbrownsred.Text, txtbrownsgreen.Text, txtbrownsblue.Text)
    End Sub

    Private Sub pnlbrownoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlbrownoptions.MouseLeave, pnlbrownoptions.MouseEnter, pnlbrowncolours.MouseEnter, pnlbrowncolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtbrownsred.Text) > 255 Then
            txtbrownsred.Text = "255"
        End If
        If Convert.ToInt32(txtbrownsred.Text) < 90 Then
            txtbrownsred.Text = "90"
        End If
        If Convert.ToInt32(txtbrownsgreen.Text) > Convert.ToInt32(txtbrownsred.Text - 30) Then
            txtbrownsgreen.Text = Convert.ToInt32(txtbrownsred.Text - 30)
        End If
        If Convert.ToInt32(txtbrownsgreen.Text) < Convert.ToInt32(txtbrownsred.Text - 128) Then
            txtbrownsgreen.Text = Convert.ToInt32(txtbrownsred.Text - 128)
        End If
        If Convert.ToInt32(txtbrownsgreen.Text) < 60 Then
            txtbrownsgreen.Text = "60"
        End If
        If Convert.ToInt32(txtbrownsblue.Text) > Convert.ToInt32(txtbrownsgreen.Text - 60) Then
            txtbrownsblue.Text = Convert.ToInt32(txtbrownsgreen.Text - 60)
        End If
        pnlbrowncustomcolour.BackColor = Color.FromArgb(txtbrownsred.Text, txtbrownsgreen.Text, txtbrownsblue.Text)
    End Sub

    Private Sub txtsred_TextChanged(sender As Object, e As EventArgs) Handles txtredsred.TextChanged, txtredsblue.TextChanged, txtredsgreen.TextChanged
        On Error Resume Next
        pnlredcustomcolour.BackColor = Color.FromArgb(txtredsred.Text, txtredsgreen.Text, txtredsblue.Text)
    End Sub

    Private Sub pnlredoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlredoptions.MouseLeave, pnlredoptions.MouseEnter, pnlredcolours.MouseEnter, pnlbrowncolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtredsred.Text) > 255 Then
            txtredsred.Text = "255"
        End If
        If Convert.ToInt32(txtredsblue.Text) > Convert.ToInt32(txtredsred.Text - 80) Then
            txtredsblue.Text = Convert.ToInt32(txtredsred.Text - 80)
        End If
        If Convert.ToInt32(txtredsgreen.Text) > Convert.ToInt32(txtredsred.Text - 80) Then
            txtredsgreen.Text = Convert.ToInt32(txtredsred.Text - 80)
        End If
        If Convert.ToInt32(txtredsgreen.Text) > Convert.ToInt32(txtredsblue.Text + 50) Then
            txtredsgreen.Text = Convert.ToInt32(txtredsblue.Text + 50)
        End If
        If Convert.ToInt32(txtredsblue.Text) > Convert.ToInt32(txtredsgreen.Text + 50) Then
            txtredsblue.Text = Convert.ToInt32(txtredsgreen.Text + 50)
        End If
        pnlredcustomcolour.BackColor = Color.FromArgb(txtredsred.Text, txtredsgreen.Text, txtredsblue.Text)
    End Sub

    Private Sub txtpinksred_TextChanged(sender As Object, e As EventArgs) Handles txtpinksred.TextChanged, txtpinksblue.TextChanged, txtpinksgreen.TextChanged
        On Error Resume Next
        pnlpinkcustomcolour.BackColor = Color.FromArgb(txtpinksred.Text, txtpinksgreen.Text, txtpinksblue.Text)
    End Sub

    Private Sub pnlpinkoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlpinkoptions.MouseLeave, pnlpinkoptions.MouseEnter, pnlpinkcolours.MouseEnter, pnlpinkcolours.MouseLeave
        customcolourfailsafe()
        If Convert.ToInt32(txtpinksred.Text) > 255 Then
            txtpinksred.Text = "255"
        End If
        If Convert.ToInt32(txtpinksblue.Text) > Convert.ToInt32(txtpinksred.Text - 50) Then
            txtpinksblue.Text = Convert.ToInt32(txtpinksred.Text - 50)
        End If
        If Convert.ToInt32(txtpinksgreen.Text) > Convert.ToInt32(txtpinksblue.Text) Then
            txtpinksgreen.Text = Convert.ToInt32(txtpinksblue.Text)
        End If
        pnlpinkcustomcolour.BackColor = Color.FromArgb(txtpinksred.Text, txtpinksgreen.Text, txtpinksblue.Text)
    End Sub

    Private Sub txtanysred_TextChanged(sender As Object, e As EventArgs) Handles txtanysred.TextChanged, txtanysblue.TextChanged, txtanysgreen.TextChanged
        On Error Resume Next
        pnlanycustomcolour.BackColor = Color.FromArgb(txtanysred.Text, txtanysgreen.Text, txtanysblue.Text)
    End Sub

    Private Sub pnlanyoptions_MouseLeave(sender As Object, e As EventArgs) Handles pnlanyoptions.MouseLeave, pnlanyoptions.MouseEnter, pnlanycolours.MouseEnter, pnlanycolours.MouseLeave
        customcolourfailsafe()
        Select Case anylevel
            Case 1
                If Convert.ToInt32(txtanysred.Text) > 150 Then
                    txtanysred.Text = "150"
                End If
                If Convert.ToInt32(txtanysred.Text) < 100 Then
                    txtanysred.Text = "100"
                End If
                If Convert.ToInt32(txtanysblue.Text) > 150 Then
                    txtanysblue.Text = "150"
                End If
                If Convert.ToInt32(txtanysblue.Text) < 100 Then
                    txtanysblue.Text = "100"
                End If
                If Convert.ToInt32(txtanysgreen.Text) > 150 Then
                    txtanysgreen.Text = "150"
                End If
                If Convert.ToInt32(txtanysgreen.Text) < 100 Then
                    txtanysgreen.Text = "100"
                End If
            Case 2
                If Convert.ToInt32(txtanysred.Text) > 200 Then
                    txtanysred.Text = "200"
                End If
                If Convert.ToInt32(txtanysred.Text) < 100 Then
                    txtanysred.Text = "100"
                End If
                If Convert.ToInt32(txtanysblue.Text) > 200 Then
                    txtanysblue.Text = "200"
                End If
                If Convert.ToInt32(txtanysblue.Text) < 100 Then
                    txtanysblue.Text = "100"
                End If
                If Convert.ToInt32(txtanysgreen.Text) > 200 Then
                    txtanysgreen.Text = "200"
                End If
                If Convert.ToInt32(txtanysgreen.Text) < 100 Then
                    txtanysgreen.Text = "100"
                End If
            Case 3
                If Convert.ToInt32(txtanysred.Text) > 225 Then
                    txtanysred.Text = "225"
                End If
                If Convert.ToInt32(txtanysred.Text) < 75 Then
                    txtanysred.Text = "75"
                End If
                If Convert.ToInt32(txtanysblue.Text) > 225 Then
                    txtanysblue.Text = "225"
                End If
                If Convert.ToInt32(txtanysblue.Text) < 75 Then
                    txtanysblue.Text = "75"
                End If
                If Convert.ToInt32(txtanysgreen.Text) > 225 Then
                    txtanysgreen.Text = "225"
                End If
                If Convert.ToInt32(txtanysgreen.Text) < 75 Then
                    txtanysgreen.Text = "75"
                End If
            Case 4
                If Convert.ToInt32(txtanysred.Text) > 255 Then
                    txtanysred.Text = "255"
                End If
                If Convert.ToInt32(txtanysred.Text) < 0 Then
                    txtanysred.Text = "0"
                End If
                If Convert.ToInt32(txtanysblue.Text) > 255 Then
                    txtanysblue.Text = "255"
                End If
                If Convert.ToInt32(txtanysblue.Text) < 0 Then
                    txtanysblue.Text = "0"
                End If
                If Convert.ToInt32(txtanysgreen.Text) > 255 Then
                    txtanysgreen.Text = "255"
                End If
                If Convert.ToInt32(txtanysgreen.Text) < 0 Then
                    txtanysgreen.Text = "0"
                End If
        End Select
        pnlanycustomcolour.BackColor = Color.FromArgb(txtanysred.Text, txtanysgreen.Text, txtanysblue.Text)
    End Sub

    Private Sub pnlgraycustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlgraycustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Gray Rules"
            infobox.textinfo = "You must input a value between 0 (black) and 255 (white) to form a shade of gray." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Gray Memory Wiped"
            infobox.textinfo = "All your custom shades of Gray have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.graymemory, 0, ShiftOSDesktop.graymemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlpurplecustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlpurplecustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Purple Rules"
            infobox.textinfo = "Blue must have the highest value followed by red. Green must then have the lowest value." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Purple Memory Wiped"
            infobox.textinfo = "All your custom shades of Purple have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.purplememory, 0, ShiftOSDesktop.purplememory.Length)
            setupboughtcolours()
            loadmemory()
        End If

    End Sub

    Private Sub pnlbluecustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlbluecustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Blue Rules"
            infobox.textinfo = "Blue must have the highest value followed by green. Red must then have the lowest value." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Blue Memory Wiped"
            infobox.textinfo = "All your custom shades of Blue have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.bluememory, 0, ShiftOSDesktop.bluememory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlgreencustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlgreencustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Green Rules"
            infobox.textinfo = "Green must have the highest value. Red and Blue need to have values within 150 of eachother." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Green Memory Wiped"
            infobox.textinfo = "All your custom shades of Green have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.greenmemory, 0, ShiftOSDesktop.greenmemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlyellowcustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlyellowcustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Yellow Rules"
            infobox.textinfo = "Red must have the highest value and be over 180. Green must be within 30 values of red. Blue must be the lowest value." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Yellow Memory Wiped"
            infobox.textinfo = "All your custom shades of Yellow have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.yellowmemory, 0, ShiftOSDesktop.yellowmemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlorangecustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlorangecustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Orange Rules"
            infobox.textinfo = "Red must have a value of 255. Green must be 100 or more values less than red. Blue must be 30 or more values less than green." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Orange Memory Wiped"
            infobox.textinfo = "All your custom shades of Orange have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.orangememory, 0, ShiftOSDesktop.orangememory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlbrowncustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlbrowncustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Brown Rules"
            infobox.textinfo = "Red must have the highest value. Green must be 30 - 128 values lower than red. Blue must be 60 or more values less than green." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Brown Memory Wiped"
            infobox.textinfo = "All your custom shades of Brown have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.brownmemory, 0, ShiftOSDesktop.brownmemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlredcustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlredcustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Red Rules"
            infobox.textinfo = "Red must have the highest value. Green and blue must be 80 or more values less than red but within 50 values of eachother." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Red Memory Wiped"
            infobox.textinfo = "All your custom shades of Red have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.redmemory, 0, ShiftOSDesktop.redmemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlpinkcustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlpinkcustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            infobox.title = "Pink Rules"
            infobox.textinfo = "Red must have the highest value. Blue must be 50 or more values less than red. Green must have the lowest value." & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
            infobox.Show()
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Pink Memory Wiped"
            infobox.textinfo = "All your custom shades of Pink have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.pinkmemory, 0, ShiftOSDesktop.pinkmemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub pnlanycustomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlanycustomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Select Case anylevel
                Case 1
                    infobox.title = "Custom Rules"
                    infobox.textinfo = "Red, Green and Blue may be set to any value between 100 and 150" & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
                    infobox.Show()
                Case 2
                    infobox.title = "Custom Rules"
                    infobox.textinfo = "Red, Green and Blue may be set to any value between 100 and 200" & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
                    infobox.Show()
                Case 3
                    infobox.title = "Custom Rules"
                    infobox.textinfo = "Red, Green and Blue may be set to any value between 75 and 225" & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
                    infobox.Show()
                Case 4
                    infobox.title = "Custom Rules"
                    infobox.textinfo = "Red, Green and Blue may be set to any value between 0 and 255" & Environment.NewLine & Environment.NewLine & "Right click a box on the left to use this colour."
                    infobox.Show()
            End Select
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            infobox.title = "Custom Colour Memory Wiped"
            infobox.textinfo = "All your custom colour shades of have been wiped from memory." & Environment.NewLine & Environment.NewLine & "You can set custom colours but right clicking any of the boxes on the left."
            infobox.Show()
            Array.Clear(ShiftOSDesktop.anymemory, 0, ShiftOSDesktop.anymemory.Length)
            setupboughtcolours()
            loadmemory()
        End If
    End Sub

    Private Sub rollupbutton_MouseEnter(sender As Object, e As MouseEventArgs) Handles rollupbutton.MouseUp

    End Sub

    Private Sub rollupbutton_MouseDown(sender As Object, e As MouseEventArgs) Handles rollupbutton.MouseDown

    End Sub
End Class