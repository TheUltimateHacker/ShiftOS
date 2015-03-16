Public Class Shifter
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0
    Public ShiftOSPath As String = "C:\ShiftOS"

    Public skinlines(200) As String

    Public titlebarcolour As Color
    Public windowbordercolour As Color
    Public windowbordersize As Integer
    Public titlebarheight As Integer
    Public closebuttoncolour As Color
    Public closebuttonheight As Integer
    Public closebuttonwidth As Integer
    Public closebuttonside As Integer
    Public closebuttontop As Integer
    Public titletextcolour As Color
    Public titletexttop As Integer
    Public titletextside As Integer
    Public titletextsize As Integer
    Public titletextfont As String
    Public titletextstyle As FontStyle
    Public desktoppanelcolour As Color
    Public desktopbackgroundcolour As Color
    Public desktoppanelheight As Integer
    Public desktoppanelposition As String
    Public clocktextcolour As Color
    Public clockbackgroundcolor As Color
    Public panelclocktexttop As Integer
    Public panelclocktextsize As Integer
    Public panelclocktextfont As String
    Public panelclocktextstyle As FontStyle
    Public applauncherbuttoncolour As Color
    Public applauncherbuttonclickedcolour As Color
    Public applauncherbackgroundcolour As Color
    Public applaunchermouseovercolour As Color
    Public applicationsbuttontextcolour As Color
    Public applicationbuttonheight As Integer
    Public applicationbuttontextsize As Integer
    Public applicationbuttontextfont As String
    Public applicationbuttontextstyle As FontStyle
    Public applicationlaunchername As String
    Public titletextposition As String
    Public rollupbuttoncolour As Color
    Public rollupbuttonheight As Integer
    Public rollupbuttonwidth As Integer
    Public rollupbuttonside As Integer
    Public rollupbuttontop As Integer
    Public titlebariconside As Integer
    Public titlebaricontop As Integer
    Public showwindowcorners As Boolean
    Public titlebarcornerwidth As Integer
    Public titlebarrightcornercolour As Color
    Public titlebarleftcornercolour As Color
    Public applaunchermenuholderwidth As Integer = 100
    Public windowborderleftcolour As Color
    Public windowborderrightcolour As Color
    Public windowborderbottomcolour As Color
    Public windowborderbottomrightcolour As Color
    Public windowborderbottomleftcolour As Color
    Public panelbuttonicontop As Integer
    Public panelbuttoniconside As Integer
    Public panelbuttoniconsize As Integer
    Public panelbuttonheight As Integer
    Public panelbuttonwidth As Integer
    Public panelbuttoncolour As Color
    Public panelbuttontextcolour As Color
    Public panelbuttontextsize As Integer
    Public panelbuttontextfont As String
    Public panelbuttontextstyle As FontStyle
    Public panelbuttontextside As Integer
    Public panelbuttontexttop As Integer
    Public panelbuttongap As Integer
    Public panelbuttonfromtop As Integer
    Public panelbuttoninitialgap As Integer
    Public minimizebuttoncolour As Color
    Public minimizebuttonheight As Integer
    Public minimizebuttonwidth As Integer
    Public minimizebuttonside As Integer
    Public minimizebuttontop As Integer
    Public icontextcolor As Color

    'skins
    Public shifterskinimages(100) As String
    Public skinclosebutton(2) As Image
    Public skinclosebuttonstyle As ImageLayout
    Public shifterskintitlebar(2) As Image
    Public skintitlebarstyle As ImageLayout
    Public skindesktopbackground(2) As Image
    Public skindesktopbackgroundstyle As ImageLayout
    Public skinrollupbutton(2) As Image
    Public skinrollupbuttonstyle As ImageLayout
    Public skintitlebarrightcorner(2) As Image
    Public skintitlebarrightcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skintitlebarleftcorner(2) As Image
    Public skintitlebarleftcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktoppanel(2) As Image
    Public skindesktoppanelstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktoppaneltime(2) As Image
    Public skindesktoppaneltimestyle As ImageLayout = ImageLayout.Stretch
    Public skinapplauncherbutton(2) As Image
    Public skinapplauncherbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderleft(2) As Image
    Public skinwindowborderleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderright(2) As Image
    Public skinwindowborderrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottom(2) As Image
    Public skinwindowborderbottomstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottomright(2) As Image
    Public skinwindowborderbottomrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottomleft(2) As Image
    Public skinwindowborderbottomleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinpanelbutton(2) As Image
    Public skinpanelbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinminimizebutton(2) As Image
    Public skinminimizebuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinuserpanel(2) As Image
    Public skinshutdownbutton(2) As Image

    Public customizationtimepoints As Integer
    Public customizationsdone As Integer
    Public customizationpointsearned As Integer
    Dim bmp As Bitmap

    'DevX's ADV. App Launcher

    Public startWidth As Integer = Skins.startWidth
    Public startHeight As Integer = Skins.startHeight
    Public usernametextcolor As Color = Skins.usernametextcolor
    Public shutdowntextcolor As Color = Skins.shutdownTextColor
    Public usernamebgcolor As Color = Skins.userNamePanelBackgroundColor
    Public powerpanelbgcolor As Color = Skins.powerPanelBackgroundColor
    Public powerpanelbgimage As Image = Skins.powerPanelBackgroundImage
    Public usernamebgimage As Image = Skins.userNamePanelBackground
    Public usernamefont As String = Skins.usernamefont
    Public usernamefontsize As Integer = Skins.usernamefontsize
    Public usernamefontstyle As FontStyle = Skins.usernamefontstyle
    Public ShutDownString As String = Skins.shutdownstring
    Public powerpanelfont As String = Skins.shutdownTextFont
    Public powerpanelfontsize As Integer = Skins.shutdownTextSize
    Public powerpanelfontstyle As FontStyle = Skins.shutdownTextStyle
    Public usrbglayout As ImageLayout = Skins.usrPanelBackgroundLayout
    Public pwrbglayout As ImageLayout = Skins.pwrPanelBackgroundLayout




#Region "Template Code"
    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        'ShiftOSDesktop.setcolours()
        setupbuttons()
        initialsetup()
        determinevisibleobjects()
        AddFonts()
        If ShiftOSDesktop.ShifterCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        setuppreshifterstuff()

        ShiftOSDesktop.pnlpanelbuttonshifter.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonshifter, ShiftOSDesktop.tbshiftericon, ShiftOSDesktop.tbshiftertext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        'Display the shifter intro
        pnlshifterintro.Location = New Point(133, 6)
        pnlshifterintro.Size = New Size(458, 297)
        pnlshifterintro.Show()
        pnlshifterintro.BringToFront()

        'Display window intro
        pnlwindowsintro.Show()
        pnlwindowsintro.Size = New Size(317, 134)
        pnlwindowsintro.Location = New Point(136, 159)
        pnlwindowsintro.BringToFront()

        'Display desktop intro
        pnldesktopintro.Show()
        pnldesktopintro.Size = New Size(317, 134)
        pnldesktopintro.Location = New Point(136, 159)
        pnldesktopintro.BringToFront()

    End Sub

    Public Sub setupall()
        setuptitlebar()
        setupborders()
        setskin()
    End Sub

    Public Sub loadclone()
        setuptitlebar()
        setupborders()
        'ShiftOSDesktop.setcolours()
        setskin()
        setupbuttons()
        initialsetup()
        determinevisibleobjects()
        setuppreshifterstuff()
        AddFonts()
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

    'Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
    '    If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    'End Sub

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
            Me.Size = New Size(600, 339) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.shiftername 'Remember to change to name of program!!!!
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
        If ShiftOSDesktop.boughtshiftericon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(Skins.titleiconfromside, Skins.titleiconfromtop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.shiftericontitlebar  'Replace with the correct icon for the program.
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
#End Region


    Private Sub initialsetup()
        titlebarcolour = Skins.titlebarcolour
        windowbordercolour = Skins.borderbottomcolour
        windowbordersize = Skins.borderwidth
        titlebarheight = Skins.titlebarheight
        closebuttoncolour = Skins.closebtncolour
        closebuttonheight = Skins.closebtnsize.Height
        closebuttonwidth = Skins.closebtnsize.Width
        closebuttontop = Skins.closebtnfromtop
        closebuttonside = Skins.closebtnfromside
        titletextcolour = Skins.titletextcolour
        titletexttop = Skins.titletextfromtop
        titletextside = Skins.titletextfromside
        titletextsize = Skins.titletextfontsize
        titletextfont = Skins.titletextfontfamily
        titletextstyle = Skins.titletextfontstyle
        desktoppanelcolour = Skins.desktoppanelcolour
        desktopbackgroundcolour = Skins.desktopbackgroundcolour
        desktoppanelheight = Skins.desktoppanelheight
        desktoppanelposition = Skins.desktoppanelposition
        clocktextcolour = Skins.clocktextcolour
        clockbackgroundcolor = Skins.clockbackgroundcolor
        panelclocktexttop = Skins.panelclocktexttop
        panelclocktextsize = Skins.panelclocktextsize
        panelclocktextfont = Skins.panelclocktextfont
        panelclocktextstyle = Skins.panelclocktextstyle
        applauncherbuttoncolour = Skins.applauncherbuttoncolour
        applauncherbuttonclickedcolour = Skins.applauncherbuttonclickedcolour
        applauncherbackgroundcolour = Skins.applauncherbackgroundcolour
        applaunchermouseovercolour = Skins.applaunchermouseovercolour
        applicationsbuttontextcolour = Skins.applicationsbuttontextcolour
        applicationbuttonheight = Skins.applicationbuttonheight
        applicationbuttontextsize = Skins.applicationbuttontextsize
        applicationbuttontextfont = Skins.applicationbuttontextfont
        applicationbuttontextstyle = Skins.applicationbuttontextstyle
        applicationlaunchername = Skins.applicationlaunchername
        titletextposition = Skins.titletextposition
        rollupbuttoncolour = Skins.rollbtncolour
        rollupbuttonheight = Skins.rollbtnsize.Height
        rollupbuttonwidth = Skins.rollbtnsize.Width
        rollupbuttonside = Skins.rollbtnfromside
        rollupbuttontop = Skins.rollbtnfromtop
        titlebariconside = Skins.titleiconfromside
        titlebaricontop = Skins.titleiconfromtop
        titlebarcornerwidth = Skins.titlebarcornerwidth
        titlebarrightcornercolour = Skins.rightcornercolour
        titlebarleftcornercolour = Skins.leftcornercolour
        showwindowcorners = Skins.enablecorners
        applaunchermenuholderwidth = Skins.applaunchermenuholderwidth
        windowborderleftcolour = Skins.borderleftcolour
        windowborderrightcolour = Skins.borderrightcolour
        windowborderbottomcolour = Skins.borderbottomcolour
        windowborderbottomrightcolour = Skins.bottomrightcornercolour
        windowborderbottomleftcolour = Skins.bottomleftcornercolour
        panelbuttonicontop = Skins.panelbuttonicontop
        panelbuttoniconside = Skins.panelbuttoniconside
        panelbuttoniconsize = Skins.panelbuttoniconsize
        panelbuttoniconsize = Skins.panelbuttoniconsize
        panelbuttonheight = Skins.panelbuttonheight
        panelbuttonwidth = Skins.panelbuttonwidth
        panelbuttoncolour = Skins.panelbuttoncolour
        panelbuttontextcolour = Skins.panelbuttontextcolour
        panelbuttontextsize = Skins.panelbuttontextsize
        panelbuttontextfont = Skins.panelbuttontextfont
        panelbuttontextstyle = Skins.panelbuttontextstyle
        panelbuttontextside = Skins.panelbuttontextside
        panelbuttontexttop = Skins.panelbuttontexttop
        panelbuttongap = Skins.panelbuttongap
        panelbuttonfromtop = Skins.panelbuttonfromtop
        panelbuttoninitialgap = Skins.panelbuttoninitialgap
        minimizebuttoncolour = Skins.minbtncolour
        minimizebuttonheight = Skins.minbtnsize.Height
        minimizebuttonwidth = Skins.minbtnsize.Width
        minimizebuttonside = Skins.minbtnfromside
        minimizebuttontop = Skins.minbtnfromtop
        txtlauncheritemtxtsize.Text = Skins.launcheritemsize
        launcheritemtxtcolour.BackColor = Skins.launcheritemcolour
        launcheritemfont.Text = Skins.launcheritemfont
        icontextcolor = Skins.icontextcolor

        skinuserpanel(0) = userNamePanelBackground
        skinshutdownbutton(0) = powerpanelbgimage

        'Uncomment when I (The Ultimate Hacker) have gotten the Shiftnet Download for
        'Desktop++ Done:

        'If ShiftOSDesktop.boughtdesktopicons = True Then
        '    btndeskdoubleplus.Visible = True
        'End If

        desktopiconspreview.BackColor = Skins.desktopbackgroundcolour
        If Skins.desktopbackground Is Nothing Then desktopiconspreview.BackgroundImage = Nothing Else desktopiconspreview.BackgroundImage = Skins.desktopbackground
        desktopiconspreview.BackgroundImageLayout = Skins.desktopbackgroundlayout
        desktopiconspreview.ForeColor = Skins.icontextcolor
        CheckBox1.Checked = Skins.enabledraggableicons
        refreshIcons()

        'Adv. App Launcher Setup Code

        Dim fStyleForAAL As String 'Just for simplicity, ignore.
        cmbaalusrfont.Text = usernamefont
        Select Case usernamefontstyle
            Case FontStyle.Regular
                fStyleForAAL = "Regular"
            Case FontStyle.Bold
                fStyleForAAL = "Bold"
            Case FontStyle.Italic
                fStyleForAAL = "Italic"
            Case FontStyle.Underline
                fStyleForAAL = "Underline"
            Case Else
                fStyleForAAL = "Regular"
        End Select
        cmbaalusrstyle.Text = fStyleForAAL
        nudusrsize.Value = usernamefontsize
        btnaalpwrpnlbg.BackColor = powerpanelbgcolor
        If powerpanelbgimage Is Nothing Then btnaalpwrpnlbg.BackgroundImage = Nothing Else btnaalpwrpnlbg.BackgroundImage = powerpanelbgimage
        btnaalpwrpnlbg.BackgroundImageLayout = pwrbglayout
        btnaalusrpnlbg.BackColor = usernamebgcolor
        If usernamebgimage Is Nothing Then btnaalusrpnlbg.BackgroundImage = Nothing Else btnaalusrpnlbg.BackgroundImage = usernamebgimage
        btnaalusrpnlbg.BackgroundImageLayout = usrbglayout






        'skins
        'Array.Copy(ShiftOSDesktop.skinimages, shifterskinimages, shifterskinimages.Length)

        If Skins.closebtn Is Nothing Then  Else skinclosebutton(0) = Skins.closebtn.Clone
        If Skins.closebtnhover Is Nothing Then  Else skinclosebutton(1) = Skins.closebtnhover.Clone
        If Skins.closebtnclick Is Nothing Then  Else skinclosebutton(2) = Skins.closebtnclick.Clone
        skinclosebuttonstyle = Skins.closebtnlayout

        If Skins.titlebar Is Nothing Then  Else shifterskintitlebar(0) = Skins.titlebar.Clone
        ' Are we really doing states for the titlebar?
        'If ShiftOSDesktop.skintitlebar(1) Is Nothing Then  Else shifterskintitlebar(1) = ShiftOSDesktop.skintitlebar(1).Clone
        'If ShiftOSDesktop.skintitlebar(2) Is Nothing Then  Else shifterskintitlebar(2) = ShiftOSDesktop.skintitlebar(2).Clone
        skintitlebarstyle = Skins.titlebarlayout

        If Skins.desktopbackground Is Nothing Then  Else skindesktopbackground(0) = Skins.desktopbackground.Clone
        'If ShiftOSDesktop.skindesktopbackground(1) Is Nothing Then  Else skindesktopbackground(1) = ShiftOSDesktop.skindesktopbackground(1).Clone
        'If ShiftOSDesktop.skindesktopbackground(2) Is Nothing Then  Else skindesktopbackground(2) = ShiftOSDesktop.skindesktopbackground(2).Clone
        skindesktopbackgroundstyle = Skins.desktopbackgroundlayout

        If Skins.rollbtn Is Nothing Then  Else skinrollupbutton(0) = Skins.rollbtn.Clone
        If Skins.rollbtnhover Is Nothing Then  Else skinrollupbutton(1) = rollbtnhover.Clone
        If Skins.rollbtnclick Is Nothing Then  Else skinrollupbutton(2) = rollbtnclick.Clone
        skinrollupbuttonstyle = Skins.rollbtnlayout

        If Skins.rightcorner Is Nothing Then  Else skintitlebarrightcorner(0) = Skins.rightcorner.Clone
        'If ShiftOSDesktop.skintitlebarrightcorner(1) Is Nothing Then  Else skintitlebarrightcorner(1) = ShiftOSDesktop.skintitlebarrightcorner(1).Clone
        'If ShiftOSDesktop.skintitlebarrightcorner(2) Is Nothing Then  Else skintitlebarrightcorner(2) = ShiftOSDesktop.skintitlebarrightcorner(2).Clone
        skintitlebarrightcornerstyle = Skins.rightcornerlayout

        If Skins.leftcorner Is Nothing Then  Else skintitlebarleftcorner(0) = Skins.leftcorner.Clone
        'If ShiftOSDesktop.skintitlebarleftcorner(1) Is Nothing Then  Else skintitlebarleftcorner(1) = ShiftOSDesktop.skintitlebarleftcorner(1).Clone
        'If ShiftOSDesktop.skintitlebarleftcorner(2) Is Nothing Then  Else skintitlebarleftcorner(2) = ShiftOSDesktop.skintitlebarleftcorner(2).Clone
        skintitlebarleftcornerstyle = Skins.leftcornerlayout

        If Skins.desktoppanel Is Nothing Then  Else skindesktoppanel(0) = Skins.desktoppanel.Clone
        'If ShiftOSDesktop.skindesktoppanel(1) Is Nothing Then  Else skindesktoppanel(1) = ShiftOSDesktop.skindesktoppanel(1).Clone
        'If ShiftOSDesktop.skindesktoppanel(2) Is Nothing Then  Else skindesktoppanel(2) = ShiftOSDesktop.skindesktoppanel(2).Clone
        skindesktoppanelstyle = Skins.desktoppanellayout

        If Skins.panelclock Is Nothing Then  Else skindesktoppaneltime(0) = Skins.panelclock.Clone
        'If ShiftOSDesktop.skindesktoppaneltime(1) Is Nothing Then  Else skindesktoppaneltime(1) = ShiftOSDesktop.skindesktoppaneltime(1).Clone
        'If ShiftOSDesktop.skindesktoppaneltime(2) Is Nothing Then  Else skindesktoppaneltime(2) = ShiftOSDesktop.skindesktoppaneltime(2).Clone
        skindesktoppaneltimestyle = Skins.panelclocklayout

        If Skins.applauncher Is Nothing Then  Else skinapplauncherbutton(0) = Skins.applauncher.Clone
        If Skins.applaunchermouseover Is Nothing Then  Else skinapplauncherbutton(1) = Skins.applaunchermouseover.Clone
        If Skins.applauncherclick Is Nothing Then  Else skinapplauncherbutton(2) = Skins.applauncherclick.Clone
        skinapplauncherbuttonstyle = Skins.applauncherlayout

        If Skins.borderleft Is Nothing Then  Else skinwindowborderleft(0) = Skins.borderleft.Clone
        'If ShiftOSDesktop.skinwindowborderleft(1) Is Nothing Then  Else skinwindowborderleft(1) = ShiftOSDesktop.skinwindowborderleft(1).Clone
        'If ShiftOSDesktop.skinwindowborderleft(2) Is Nothing Then  Else skinwindowborderleft(2) = ShiftOSDesktop.skinwindowborderleft(2).Clone
        skinwindowborderleftstyle = Skins.borderleftlayout

        If Skins.borderright Is Nothing Then  Else skinwindowborderright(0) = Skins.borderright.Clone
        'If ShiftOSDesktop.skinwindowborderright(1) Is Nothing Then  Else skinwindowborderright(1) = ShiftOSDesktop.skinwindowborderright(1).Clone
        'If ShiftOSDesktop.skinwindowborderright(2) Is Nothing Then  Else skinwindowborderright(2) = ShiftOSDesktop.skinwindowborderright(2).Clone
        skinwindowborderrightstyle = Skins.borderrightlayout

        If Skins.borderbottom Is Nothing Then  Else skinwindowborderbottom(0) = Skins.borderbottom.Clone
        'If ShiftOSDesktop.skinwindowborderbottom(1) Is Nothing Then  Else skinwindowborderbottom(1) = ShiftOSDesktop.skinwindowborderbottom(1).Clone
        'If ShiftOSDesktop.skinwindowborderbottom(2) Is Nothing Then  Else skinwindowborderbottom(2) = ShiftOSDesktop.skinwindowborderbottom(2).Clone
        skinwindowborderbottomstyle = Skins.borderbottomlayout

        If Skins.bottomrightcorner Is Nothing Then  Else skinwindowborderbottomright(0) = Skins.bottomrightcorner
        'If ShiftOSDesktop.skinwindowborderbottomright(1) Is Nothing Then  Else skinwindowborderbottomright(1) = ShiftOSDesktop.skinwindowborderbottomright(1).Clone
        'If ShiftOSDesktop.skinwindowborderbottomright(2) Is Nothing Then  Else skinwindowborderbottomright(2) = ShiftOSDesktop.skinwindowborderbottomright(2).Clone
        skinwindowborderbottomrightstyle = Skins.bottomrightcornerlayout

        If Skins.bottomleftcorner Is Nothing Then  Else skinwindowborderbottomleft(0) = Skins.bottomleftcorner
        'If ShiftOSDesktop.skinwindowborderbottomleft(1) Is Nothing Then  Else skinwindowborderbottomleft(1) = ShiftOSDesktop.skinwindowborderbottomleft(1).Clone
        'If ShiftOSDesktop.skinwindowborderbottomleft(2) Is Nothing Then  Else skinwindowborderbottomleft(2) = ShiftOSDesktop.skinwindowborderbottomleft(2).Clone
        skinwindowborderbottomleftstyle = Skins.bottomleftcornerlayout

        If Skins.panelbutton Is Nothing Then  Else skinpanelbutton(0) = Skins.panelbutton.Clone
        'If ShiftOSDesktop.skinpanelbutton(1) Is Nothing Then  Else skinpanelbutton(1) = ShiftOSDesktop.skinpanelbutton(1).Clone
        'If ShiftOSDesktop.skinpanelbutton(2) Is Nothing Then  Else skinpanelbutton(2) = ShiftOSDesktop.skinpanelbutton(2).Clone
        skinpanelbuttonstyle = Skins.panelbuttonlayout

        If Skins.minbtn Is Nothing Then  Else skinminimizebutton(0) = Skins.minbtn.Clone
        If Skins.minbtnhover Is Nothing Then  Else skinminimizebutton(1) = Skins.minbtnhover.Clone
        If Skins.minbtnclick Is Nothing Then  Else skinminimizebutton(2) = Skins.minbtnclick.Clone
        skinminimizebuttonstyle = Skins.minbtnlayout

        Select Case Skins.launcheritemstyle
            Case FontStyle.Bold
                launcheritemstyle.Text = "Bold"
            Case FontStyle.Italic
                launcheritemstyle.Text = "Italic"
            Case FontStyle.Regular
                launcheritemstyle.Text = "Regular"
            Case FontStyle.Strikeout
                launcheritemstyle.Text = "Strikeout"
            Case FontStyle.Underline
                launcheritemstyle.Text = "Underline"
        End Select

    End Sub

    Public Sub determinevisibleobjects()
        If ShiftOSDesktop.boughttitlebar = True Then pretitlebar.Show() Else pretitlebar.Hide()
        If ShiftOSDesktop.boughtwindowborders = True Then
            prepgright.Show()
            prepgleft.Show()
            prepgbottom.Show()
        Else
            prepgright.Hide()
            prepgleft.Hide()
            prepgbottom.Hide()
        End If
        If ShiftOSDesktop.boughtclosebutton = True Then preclosebutton.Show() Else preclosebutton.Hide()
        If ShiftOSDesktop.boughttitletext = True Then pretitletext.Show() Else pretitletext.Hide()
        If ShiftOSDesktop.boughtdesktoppanel = True Then predesktoppanel.Show() Else predesktoppanel.Hide()
        If ShiftOSDesktop.boughtdesktoppanelclock = True Then prepaneltimetext.Show() Else prepaneltimetext.Hide()
        If ShiftOSDesktop.boughtapplaunchermenu = True Then preapplaunchermenuholder.Show() Else preapplaunchermenuholder.Hide()
        If ShiftOSDesktop.boughtrollupbutton = True Then prerollupbutton.Show() Else prerollupbutton.Hide()
        If ShiftOSDesktop.boughtknowledgeinputicon = True Then prepnlicon.Show() Else prepnlicon.Hide()
        If ShiftOSDesktop.boughtpanelbuttons = True Then prepnlpanelbutton.Show() Else prepnlpanelbutton.Hide()
        If ShiftOSDesktop.boughtminimizebutton = True Then preminimizebutton.Show() Else preminimizebutton.Hide()
    End Sub

    Public Sub setupbuttons()
        If ShiftOSDesktop.boughttitlebar = True Then
            btntitlebar.Text = "Title Bar"
        Else
            btntitlebar.Text = "???"
        End If
        If ShiftOSDesktop.boughttitletext = True Then
            btntitletext.Text = "Title Text"
        Else
            btntitletext.Text = "???"
        End If
        If ShiftOSDesktop.boughtclosebutton = True OrElse ShiftOSDesktop.boughtrollupbutton = True Then
            btnbuttons.Text = "Buttons"
            combobuttonoption.Items.Clear()
            If ShiftOSDesktop.boughtclosebutton = True Then combobuttonoption.Items.Add("Close Button")
            If ShiftOSDesktop.boughtrollupbutton = True Then combobuttonoption.Items.Add("Roll Up Button")
            If ShiftOSDesktop.boughtminimizebutton = True Then combobuttonoption.Items.Add("Minimize Button")
        Else
            btnbuttons.Text = "???"
        End If
        If ShiftOSDesktop.boughtwindowborders = True Then
            btnborders.Text = "Borders"
        Else
            btnborders.Text = "???"
        End If
        If ShiftOSDesktop.boughtdesktoppanel = True Then
            btndesktoppanel.Text = "Desktop Panel"
        Else
            btndesktoppanel.Text = "???"
        End If
        If ShiftOSDesktop.boughtapplaunchermenu = True Then
            btnapplauncher.Text = "App Launcher"
        Else
            btnapplauncher.Text = "???"
        End If
        If ShiftOSDesktop.boughtdesktoppanelclock = True Then
            btnpanelclock.Text = "Panel Clock"
        Else
            btnpanelclock.Text = "???"
        End If
        If ShiftOSDesktop.boughtpanelbuttons = True Then
            btnpanelbuttons.Show()
        Else
            btnpanelbuttons.Hide()
        End If
        If ShiftOSDesktop.boughtknowledgeinputicon Then
            Label78.Show()
            Label79.Show()
            Label80.Show()
            Label81.Show()
            txticonfromside.Show()
            txticonfromtop.Show()
        Else
            Label78.Hide()
            Label79.Hide()
            Label80.Hide()
            Label81.Hide()
            txticonfromside.Hide()
            txticonfromtop.Hide()
        End If
        cbindividualbordercolours.Checked = Skins.enablebordercorners
    End Sub

    Public Sub setuppreshifterstuff()
        pretitlebar.BackColor = titlebarcolour
        prepgtoplcorner.BackColor = titlebarcolour
        prepgtoprcorner.BackColor = titlebarcolour
        prepgleft.BackColor = windowborderleftcolour
        prepgright.BackColor = windowborderrightcolour
        prepgbottom.BackColor = windowborderbottomcolour
        prepgbottomlcorner.BackColor = windowborderbottomleftcolour
        prepgbottomrcorner.BackColor = windowborderbottomrightcolour
        pretitlebar.Height = titlebarheight
        preclosebutton.BackColor = closebuttoncolour
        preclosebutton.Height = closebuttonheight
        preclosebutton.Width = closebuttonwidth
        prepgleft.Width = windowbordersize
        prepgright.Width = windowbordersize
        prepgbottom.Height = windowbordersize
        preminimizebutton.BackColor = minimizebuttoncolour
        preminimizebutton.Height = minimizebuttonheight
        preminimizebutton.Width = minimizebuttonwidth
        Select Case titletextposition
            Case "Left"
                pretitletext.Location = New Point(titletextside, titletexttop)
            Case "Centre"
                pretitletext.Location = New Point((pretitlebar.Width / 2) - pretitletext.Width / 2, titletexttop)
        End Select
        pretitletext.ForeColor = titletextcolour

        On Error Resume Next
        pretitletext.Font = New Font(titletextfont, titletextsize, titletextstyle)

        pnldesktoppreview.BackColor = desktopbackgroundcolour
        predesktoppanel.Height = desktoppanelheight
        setclocktime()
        prepaneltimetext.ForeColor = clocktextcolour
        pretimepanel.BackColor = clockbackgroundcolor
        prepaneltimetext.Font = New Font(panelclocktextfont, panelclocktextsize, panelclocktextstyle)
        prepaneltimetext.Location = New Point()
        pretimepanel.Size = New Size(prepaneltimetext.Width + 3, pretimepanel.Height)
        prepaneltimetext.Location = New Point(0, panelclocktexttop)
        ApplicationsToolStripMenuItem.Text = applicationlaunchername
        ApplicationsToolStripMenuItem.Font = New Font(applicationbuttontextfont, applicationbuttontextsize, applicationbuttontextstyle)
        preapplaunchermenuholder.Size = ApplicationsToolStripMenuItem.Size
        ToolStripManager.Renderer = New MyPreviewToolStripRenderer()
        'ShiftOSDesktop.ApplicationsToolStripMenuItem.BackColor = ShiftOSDesktop.applauncherbuttoncolour
        ApplicationsToolStripMenuItem.BackColor = Color.Transparent
        ApplicationsToolStripMenuItem.ForeColor = applicationsbuttontextcolour
        preapplaunchermenuholder.Height = applicationbuttonheight
        predesktopappmenu.Height = applicationbuttonheight
        ApplicationsToolStripMenuItem.Height = applicationbuttonheight
        prerollupbutton.BackColor = rollupbuttoncolour
        prerollupbutton.Height = rollupbuttonheight
        prerollupbutton.Width = rollupbuttonwidth
        predesktoppanel.BackColor = desktoppanelcolour
        pnldesktoppreview.BackColor = desktopbackgroundcolour
        prepnlicon.Location = New Point(titlebariconside, titlebaricontop)
        prepgtoplcorner.BackColor = titlebarleftcornercolour
        prepgtoprcorner.BackColor = titlebarrightcornercolour
        prepgtoplcorner.Width = titlebarcornerwidth
        prepgtoprcorner.Width = titlebarcornerwidth

        If ShiftOSDesktop.boughtpanelbuttons = True Then prepnlpanelbutton.Show()
        pretbicon.Location = New Point(panelbuttoniconside, panelbuttonicontop)
        pretbicon.Size = New Size(panelbuttoniconsize, panelbuttoniconsize)
        prepnlpanelbutton.Size = New Size(panelbuttonwidth, panelbuttonheight)
        prepnlpanelbutton.BackColor = panelbuttoncolour
        If skinpanelbutton(0) Is Nothing Then  Else prepnlpanelbutton.BackgroundImage = skinpanelbutton(0)
        prepnlpanelbutton.BackgroundImageLayout = skinpanelbuttonstyle
        pretbctext.ForeColor = panelbuttontextcolour
        pretbctext.Font = New Font(panelbuttontextfont, panelbuttontextsize, panelbuttontextstyle)
        pretbctext.Location = New Point(panelbuttontextside, panelbuttontexttop)
        prepnlpanelbuttonholder.Padding = New Padding(panelbuttoninitialgap, 0, 0, 0)
        prepnlpanelbutton.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
        If skinpanelbutton(0) Is Nothing Then  Else prepnlpanelbutton.BackColor = Color.Transparent

        Select Case desktoppanelposition
            Case "Top"
                predesktoppanel.Dock = DockStyle.Top
                predesktopappmenu.Dock = DockStyle.Top
            Case "Bottom"
                predesktoppanel.Dock = DockStyle.Bottom
                predesktopappmenu.Dock = DockStyle.Bottom
        End Select

        If skindesktoppanel(0) Is Nothing Then
            predesktoppanel.BackColor = desktoppanelcolour
            predesktoppanel.BackgroundImage = Nothing
        Else
            predesktoppanel.BackgroundImage = skindesktoppanel(0)
            predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
            predesktoppanel.BackColor = Color.Transparent
        End If

        If ShiftOSDesktop.boughtdesktoppanelclock = True Then
            setclocktime()
            prepaneltimetext.ForeColor = clocktextcolour
            If skindesktoppaneltime(0) Is Nothing Then
                pretimepanel.BackColor = clockbackgroundcolor
                pretimepanel.BackgroundImage = Nothing
            Else
                pretimepanel.BackColor = Color.Transparent
                If skindesktoppaneltime(0) Is Nothing Then  Else pretimepanel.BackgroundImage = skindesktoppaneltime(0)
                pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
            End If
            prepaneltimetext.Font = New Font(panelclocktextfont, panelclocktextsize, panelclocktextstyle)
            pretimepanel.Size = New Size(prepaneltimetext.Width + 3, pretimepanel.Height)
            prepaneltimetext.Location = New Point(0, panelclocktexttop)
            pretimepanel.Show()
        Else
            pretimepanel.Hide()
        End If

        If showwindowcorners = True Then
            cboxtitlebarcorners.CheckState = CheckState.Checked
        Else
            cboxtitlebarcorners.CheckState = CheckState.Unchecked
        End If

        If cboxtitlebarcorners.CheckState = CheckState.Checked Then
            prepgtoplcorner.Show()
            prepgtoprcorner.Show()
            pnltitlebarleftcornercolour.Show()
            pnltitlebarrightcornercolour.Show()
            txttitlebarcornerwidth.Show()
            lbcornerwidth.Show()
            lbcornerwidthpx.Show()
            lbleftcornercolor.Show()
            lbrightcornercolor.Show()
        Else
            prepgtoplcorner.Hide()
            prepgtoprcorner.Hide()
            pnltitlebarleftcornercolour.Hide()
            pnltitlebarrightcornercolour.Hide()
            txttitlebarcornerwidth.Hide()
            lbcornerwidth.Hide()
            lbcornerwidthpx.Hide()
            lbleftcornercolor.Hide()
            lbrightcornercolor.Hide()
        End If

        If cbindividualbordercolours.CheckState = CheckState.Checked Then
            Label73.Show()
            Label74.Show()
            Label75.Show()
            Label76.Show()
            Label77.Show()
            pnlborderleftcolour.Show()
            pnlborderrightcolour.Show()
            pnlborderbottomcolour.Show()
            pnlborderbottomrightcolour.Show()
            pnlborderbottomleftcolour.Show()
        Else
            Label73.Hide()
            Label74.Hide()
            Label75.Hide()
            Label76.Hide()
            Label77.Hide()
            pnlborderleftcolour.Hide()
            pnlborderrightcolour.Hide()
            pnlborderbottomcolour.Hide()
            pnlborderbottomrightcolour.Hide()
            pnlborderbottomleftcolour.Hide()
        End If

        If ShiftOSDesktop.boughtwindowborders = True Then
            preclosebutton.Location = New Point(pretitlebar.Size.Width - closebuttonside - preclosebutton.Size.Width, closebuttontop)
            prerollupbutton.Location = New Point(pretitlebar.Size.Width - rollupbuttonside - prerollupbutton.Size.Width, rollupbuttontop)
            preminimizebutton.Location = New Point(pretitlebar.Size.Width - minimizebuttonside - preminimizebutton.Size.Width, minimizebuttontop)
        Else
            preclosebutton.Location = New Point(pretitlebar.Size.Width - closebuttonside - prepgtoplcorner.Width - prepgtoprcorner.Width - preclosebutton.Size.Width, closebuttontop)
            prerollupbutton.Location = New Point(pretitlebar.Size.Width - rollupbuttonside - prepgtoplcorner.Width - prepgtoprcorner.Width - prerollupbutton.Size.Width, rollupbuttontop)
            preminimizebutton.Location = New Point(pretitlebar.Size.Width - minimizebuttonside - prepgtoplcorner.Width - prepgtoprcorner.Width - preminimizebutton.Size.Width, minimizebuttontop)
        End If

        preapplaunchermenuholder.Width = applaunchermenuholderwidth
        predesktopappmenu.Width = applaunchermenuholderwidth
        ApplicationsToolStripMenuItem.Width = applaunchermenuholderwidth

        If skinapplauncherbutton(0) Is Nothing Then
            ApplicationsToolStripMenuItem.BackgroundImage = Nothing
            ApplicationsToolStripMenuItem.BackColor = applauncherbuttoncolour
        Else
            ApplicationsToolStripMenuItem.BackColor = Color.Transparent
            predesktopappmenu.BackColor = Color.Transparent
            ApplicationsToolStripMenuItem.BackgroundImage = skinapplauncherbutton(0)
            ApplicationsToolStripMenuItem.Text = ""
        End If

        pnltitlebarcolour.BackColor = titlebarcolour
        pnlbordercolour.BackColor = windowbordercolour
        pnlclosebuttoncolour.BackColor = closebuttoncolour
        pnltitletextcolour.BackColor = titletextcolour
        pnldesktoppanelcolour.BackColor = desktoppanelcolour
        pnldesktopcolour.BackColor = desktopbackgroundcolour
        pnlpanelclocktextcolour.BackColor = clocktextcolour
        pnlclockbackgroundcolour.BackColor = clockbackgroundcolor
        pnlmaintextcolour.BackColor = applicationsbuttontextcolour
        pnlmainbuttoncolour.BackColor = applauncherbuttoncolour
        pnlmainbuttonactivated.BackColor = applauncherbuttonclickedcolour
        pnlmenuitemscolour.BackColor = applauncherbackgroundcolour
        pnlmenuitemsmouseover.BackColor = applaunchermouseovercolour
        pnlrollupbuttoncolour.BackColor = rollupbuttoncolour
        pnltitlebarleftcornercolour.BackColor = titlebarleftcornercolour
        pnltitlebarrightcornercolour.BackColor = titlebarrightcornercolour
        pnlborderleftcolour.BackColor = windowborderleftcolour
        pnlborderrightcolour.BackColor = windowborderrightcolour
        pnlborderbottomcolour.BackColor = windowborderbottomcolour
        pnlborderbottomrightcolour.BackColor = windowborderbottomrightcolour
        pnlborderbottomleftcolour.BackColor = windowborderbottomleftcolour
        pnlminimizebuttoncolour.BackColor = minimizebuttoncolour
        pnlpanelbuttoncolour.BackColor = panelbuttoncolour
        pnlpanelbuttontextcolour.BackColor = panelbuttontextcolour

        'skins
        preclosebutton.BackgroundImage = skinclosebutton(0)
        preclosebutton.BackgroundImageLayout = skinclosebuttonstyle
        pretitlebar.BackgroundImage = shifterskintitlebar(0)
        pretitlebar.BackgroundImageLayout = skintitlebarstyle
        pnldesktoppreview.BackgroundImage = skindesktopbackground(0)
        pnldesktoppreview.BackgroundImageLayout = skindesktopbackgroundstyle
        pnlmainbuttoncolour.BackgroundImage = skinapplauncherbutton(0)
        pnlmainbuttoncolour.BackgroundImageLayout = skinapplauncherbuttonstyle
        prerollupbutton.BackgroundImage = skinrollupbutton(0)
        prerollupbutton.BackgroundImageLayout = skinrollupbuttonstyle
        prepgtoprcorner.BackgroundImage = skintitlebarrightcorner(0)
        prepgtoprcorner.BackgroundImageLayout = skintitlebarrightcornerstyle
        prepgtoplcorner.BackgroundImage = skintitlebarleftcorner(0)
        prepgtoplcorner.BackgroundImageLayout = skintitlebarleftcornerstyle
        predesktoppanel.BackgroundImage = skindesktoppanel(0)
        predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
        pretimepanel.BackgroundImage = skindesktoppaneltime(0)
        pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
        prepgleft.BackgroundImage = skinwindowborderleft(0)
        prepgleft.BackgroundImageLayout = skinwindowborderleftstyle
        prepgright.BackgroundImage = skinwindowborderright(0)
        prepgright.BackgroundImageLayout = skinwindowborderrightstyle
        prepgbottom.BackgroundImage = skinwindowborderbottom(0)
        prepgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
        prepgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
        prepgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
        prepgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
        prepgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
        prepgbottomlcorner.Height = windowbordersize
        prepgbottomrcorner.Height = windowbordersize
        preminimizebutton.BackgroundImage = skinminimizebutton(0)
        preminimizebutton.BackgroundImageLayout = skinminimizebuttonstyle

        'invisible backgrounds
        If preclosebutton.BackgroundImage Is Nothing Then  Else preclosebutton.BackColor = Color.Transparent
        If pretitlebar.BackgroundImage Is Nothing Then  Else pretitlebar.BackColor = Color.Transparent
        If prerollupbutton.BackgroundImage Is Nothing Then  Else prerollupbutton.BackColor = Color.Transparent
        If prepgtoplcorner.BackgroundImage Is Nothing Then  Else prepgtoplcorner.BackColor = Color.Transparent
        If prepgtoprcorner.BackgroundImage Is Nothing Then  Else prepgtoprcorner.BackColor = Color.Transparent
        If prepnlpanelbutton.BackgroundImage Is Nothing Then  Else prepnlpanelbutton.BackColor = Color.Transparent
        If preminimizebutton.BackgroundImage Is Nothing Then  Else preminimizebutton.BackColor = Color.Transparent

        'pallet skins
        pnlclosebuttoncolour.BackgroundImage = skinclosebutton(0)
        pnltitlebarcolour.BackgroundImage = shifterskintitlebar(0)
        pnldesktopcolour.BackgroundImage = skindesktopbackground(0)
        pnlrollupbuttoncolour.BackgroundImage = skinrollupbutton(0)
        pnltitlebarrightcornercolour.BackgroundImage = skintitlebarrightcorner(0)
        pnltitlebarleftcornercolour.BackgroundImage = skintitlebarleftcorner(0)
        pnldesktoppanelcolour.BackgroundImage = skindesktoppanel(0)
        pnlclockbackgroundcolour.BackgroundImage = skindesktoppaneltime(0)
        pnlborderbottomcolour.BackgroundImage = skinwindowborderbottom(0)
        pnlborderleftcolour.BackgroundImage = skinwindowborderleft(0)
        pnlborderrightcolour.BackgroundImage = skinwindowborderright(0)
        pnlborderbottomrightcolour.BackgroundImage = skinwindowborderbottomright(0)
        pnlborderbottomleftcolour.BackgroundImage = skinwindowborderbottomleft(0)
        pnlminimizebuttoncolour.BackgroundImage = skinminimizebutton(0)
        pnlpanelbuttoncolour.BackgroundImage = skinpanelbutton(0)

        txttitlebarheight.Text = titlebarheight
        txtclosebuttonheight.Text = closebuttonheight
        txtclosebuttonwidth.Text = closebuttonwidth
        txtclosebuttonfromtop.Text = closebuttontop
        txtclosebuttonfromside.Text = closebuttonside
        txtbordersize.Text = windowbordersize
        txttitletexttop.Text = titletexttop
        txttitletextside.Text = titletextside
        txttitletextsize.Text = titletextsize
        combotitletextfont.Text = titletextfont
        txtdesktoppanelheight.Text = desktoppanelheight
        combodesktoppanelposition.Text = desktoppanelposition
        comboclocktextfont.Text = panelclocktextfont
        txtclocktextsize.Text = panelclocktextsize
        txtclocktextfromtop.Text = panelclocktexttop
        txtappbuttonlabel.Text = applicationlaunchername
        txtapplicationsbuttonheight.Text = applicationbuttonheight
        txtappbuttontextsize.Text = applicationbuttontextsize
        comboappbuttontextfont.Text = applicationbuttontextfont
        txtrollupbuttonheight.Text = rollupbuttonheight
        txtrollupbuttonwidth.Text = rollupbuttonwidth
        txtrollupbuttontop.Text = rollupbuttontop
        txtrollupbuttonside.Text = rollupbuttonside
        txttitlebarcornerwidth.Text = titlebarcornerwidth
        txtapplauncherwidth.Text = applaunchermenuholderwidth
        txticonfromside.Text = titlebariconside
        txticonfromtop.Text = titlebaricontop
        txtpanelbuttoninitalgap.Text = panelbuttoninitialgap
        txtpanelbuttontop.Text = panelbuttonfromtop
        txtpanelbuttonwidth.Text = panelbuttonwidth
        txtpanelbuttonheight.Text = panelbuttonheight
        txtpanelbuttongap.Text = panelbuttongap
        cbpanelbuttonfont.Text = panelbuttontextfont
        txtpaneltextbuttonsize.Text = panelbuttontextsize
        cbpanelbuttontextstyle.Text = panelbuttontextstyle
        txtpanelbuttontextside.Text = panelbuttontextside
        txtpanelbuttontexttop.Text = panelbuttontexttop
        txtpanelbuttoniconsize.Text = panelbuttoniconsize
        txtpanelbuttoniconsize.Text = panelbuttoniconsize
        txtpanelbuttoniconside.Text = panelbuttoniconside
        txtpanelbuttonicontop.Text = panelbuttonicontop

        txtminimizebuttonheight.Text = minimizebuttonheight
        txtminimizebuttonwidth.Text = minimizebuttonwidth
        txtminimizebuttontop.Text = minimizebuttontop
        txtminimizebuttonside.Text = minimizebuttonside

        Select Case titletextstyle
            Case FontStyle.Bold
                combotitletextstyle.Text = "Bold"
            Case FontStyle.Italic
                combotitletextstyle.Text = "Italic"
            Case FontStyle.Regular
                combotitletextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                combotitletextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                combotitletextstyle.Text = "Underline"
        End Select

        Select Case panelclocktextstyle
            Case FontStyle.Bold
                comboclocktextstyle.Text = "Bold"
            Case FontStyle.Italic
                comboclocktextstyle.Text = "Italic"
            Case FontStyle.Regular
                comboclocktextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                comboclocktextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                comboclocktextstyle.Text = "Underline"
        End Select

        Select Case applicationbuttontextstyle
            Case FontStyle.Bold
                comboappbuttontextstyle.Text = "Bold"
            Case FontStyle.Italic
                comboappbuttontextstyle.Text = "Italic"
            Case FontStyle.Regular
                comboappbuttontextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                comboappbuttontextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                comboappbuttontextstyle.Text = "Underline"
        End Select

        Select Case panelbuttontextstyle
            Case FontStyle.Bold
                cbpanelbuttontextstyle.Text = "Bold"
            Case FontStyle.Italic
                cbpanelbuttontextstyle.Text = "Italic"
            Case FontStyle.Regular
                cbpanelbuttontextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                cbpanelbuttontextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                cbpanelbuttontextstyle.Text = "Underline"
        End Select

        Select Case titletextposition
            Case "Left"
                combotitletextposition.Text = "Left"
            Case "Centre"
                combotitletextposition.Text = "Centre"
        End Select

        If combotitletextposition.Text = "Centre" Then
            txttitletextside.Visible = False
        Else
            txttitletextside.Visible = True
        End If

        Dim itemstyle As FontStyle = FontStyle.Regular
        Select Case launcheritemstyle.SelectedItem.ToString
            Case "Bold"
                itemstyle = FontStyle.Bold
            Case "Italic"
                itemstyle = FontStyle.Italic
            Case "Regular"
                itemstyle = FontStyle.Regular
            Case "Strikeout"
                itemstyle = FontStyle.Strikeout
            Case "Underline"
                itemstyle = FontStyle.Underline
        End Select

        Dim itemsize As Integer
        If Not txtlauncheritemtxtsize.Text = "" Then itemsize = txtlauncheritemtxtsize.Text Else itemsize = Skins.launcheritemsize

        KnowledgeInputToolStripMenuItem.Font = New Font(launcheritemfont.Text, itemsize, itemstyle)
        TerminalToolStripMenuItem.Font = New Font(launcheritemfont.Text, itemsize, itemstyle)
        ClockToolStripMenuItem.Font = New Font(launcheritemfont.Text, itemsize, itemstyle)
        ShiftoriumToolStripMenuItem.Font = New Font(launcheritemfont.Text, itemsize, itemstyle)
        ShifterToolStripMenuItem.Font = New Font(launcheritemfont.Text, itemsize, itemstyle)
        ShutdownToolStripMenuItem.Font = New Font(launcheritemfont.Text, itemsize, itemstyle)
        KnowledgeInputToolStripMenuItem.ForeColor = launcheritemtxtcolour.BackColor
        TerminalToolStripMenuItem.ForeColor = launcheritemtxtcolour.BackColor
        ClockToolStripMenuItem.ForeColor = launcheritemtxtcolour.BackColor
        ShiftoriumToolStripMenuItem.ForeColor = launcheritemtxtcolour.BackColor
        ShifterToolStripMenuItem.ForeColor = launcheritemtxtcolour.BackColor
        ShutdownToolStripMenuItem.ForeColor = launcheritemtxtcolour.BackColor

        customizationsdone = customizationsdone + 1
    End Sub

    Private Sub AddFonts()
        ' Get the installed fonts collection.
        Dim allFonts As New Drawing.Text.InstalledFontCollection

        ' Get an array of the system's font familiies.
        Dim fontFamilies() As FontFamily = allFonts.Families()

        ' Display the font families.
        For Each myFont As FontFamily In fontFamilies
            combotitletextfont.Items.Add(myFont.Name)
            comboclocktextfont.Items.Add(myFont.Name)
            comboappbuttontextfont.Items.Add(myFont.Name)
            cbpanelbuttonfont.Items.Add(myFont.Name)
            launcheritemfont.Items.Add(myFont.Name)
            cmbaalusrfont.Items.Add(myFont.Name)
        Next 'font_family
    End Sub

    Private Sub btnapply_Click(sender As Object, e As EventArgs) Handles btnapply.Click
        If Skin_Loader.Visible = True Then
            infobox.title = "Shifter - Error"
            infobox.textinfo = "It appears that the Skin Loader application is currently open." & Environment.NewLine & Environment.NewLine & "Due to system stability issues you must close it before applying your changes!"
            infobox.Show()
        Else
            ' Set skinning varibles to new values
            ' WINDOWS
            ' Image
            If Not IsNothing(pretitlebar.BackgroundImage) Then Skins.titlebar = pretitlebar.BackgroundImage Else Skins.titlebar = Nothing
            Skins.titlebarlayout = pretitlebar.BackgroundImageLayout
            If Not IsNothing(prepgleft.BackgroundImage) Then Skins.borderleft = prepgleft.BackgroundImage Else Skins.borderleft = Nothing
            Skins.borderleftlayout = prepgleft.BackgroundImageLayout
            If Not IsNothing(prepgright.BackgroundImage) Then Skins.borderright = prepgright.BackgroundImage Else Skins.borderright = Nothing
            Skins.borderrightlayout = prepgright.BackgroundImageLayout
            If Not IsNothing(prepgbottom.BackgroundImage) Then Skins.borderbottom = prepgbottom.BackgroundImage Else Skins.borderbottom = Nothing
            Skins.borderbottomlayout = prepgbottom.BackgroundImageLayout
            If Not IsNothing(preclosebutton.BackgroundImage) Then Skins.closebtn = preclosebutton.BackgroundImage Else Skins.closebtn = Nothing
            Skins.closebtnlayout = preclosebutton.BackgroundImageLayout
            If Not IsNothing(preclosebutton.BackgroundImage) Then Skins.closebtnhover = preclosebutton.BackgroundImage Else Skins.closebtnhover = Nothing
            If Not IsNothing(preclosebutton.BackgroundImage) Then Skins.closebtnclick = preclosebutton.BackgroundImage Else Skins.closebtnclick = Nothing
            If Not IsNothing(prerollupbutton.BackgroundImage) Then Skins.rollbtn = prerollupbutton.BackgroundImage Else Skins.rollbtn = Nothing
            Skins.rollbtnlayout = prerollupbutton.BackgroundImageLayout
            If Not IsNothing(prerollupbutton.BackgroundImage) Then Skins.rollbtnhover = prerollupbutton.BackgroundImage Else Skins.rollbtnhover = Nothing
            If Not IsNothing(prerollupbutton.BackgroundImage) Then Skins.rollbtnclick = prerollupbutton.BackgroundImage Else Skins.rollbtnclick = Nothing
            If Not IsNothing(preminimizebutton.BackgroundImage) Then Skins.minbtn = preminimizebutton.BackgroundImage Else Skins.minbtn = Nothing
            Skins.minbtnlayout = preminimizebutton.BackgroundImageLayout
            If Not IsNothing(preminimizebutton.BackgroundImage) Then Skins.minbtnhover = preminimizebutton.BackgroundImage Else Skins.minbtnhover = Nothing
            If Not IsNothing(preminimizebutton.BackgroundImage) Then Skins.minbtnclick = preminimizebutton.BackgroundImage Else Skins.minbtnclick = Nothing
            If Not IsNothing(prepgbottomrcorner.BackgroundImage) Then Skins.rightcorner = prepgbottomrcorner.BackgroundImage Else Skins.rightcorner = Nothing
            Skins.rightcornerlayout = prepgbottomrcorner.BackgroundImageLayout
            If Not IsNothing(prepgbottomlcorner.BackgroundImage) Then Skins.leftcorner = prepgbottomlcorner.BackgroundImage Else Skins.leftcorner = Nothing
            Skins.leftcornerlayout = prepgbottomlcorner.BackgroundImageLayout
            'Colours
            Skins.titlebarcolour = pretitlebar.BackColor
            Skins.borderleftcolour = prepgleft.BackColor
            Skins.borderrightcolour = prepgright.BackColor
            Skins.borderbottomcolour = prepgbottom.BackColor
            Skins.closebtncolour = preclosebutton.BackColor
            Skins.closebtnhovercolour = preclosebutton.BackColor
            Skins.closebtnclickcolour = preclosebutton.BackColor
            Skins.rollbtncolour = prerollupbutton.BackColor
            Skins.rollbtnhovercolour = prerollupbutton.BackColor
            Skins.rollbtnclickcolour = prerollupbutton.BackColor
            Skins.minbtncolour = preminimizebutton.BackColor
            Skins.minbtnhovercolour = preminimizebutton.BackColor
            Skins.minbtnclickcolour = preminimizebutton.BackColor
            Skins.rightcornercolour = prepgtoprcorner.BackColor
            Skins.leftcornercolour = prepgtoplcorner.BackColor
            Skins.bottomrightcornercolour = prepgbottomrcorner.BackColor
            Skins.bottomleftcornercolour = prepgbottomlcorner.BackColor
            ' Settings
            Skins.closebtnsize = preclosebutton.Size
            Skins.rollbtnsize = prerollupbutton.Size
            Skins.minbtnsize = preminimizebutton.Size
            Skins.titlebarheight = pretitlebar.Height
            Skins.closebtnfromtop = closebuttontop
            Skins.closebtnfromside = closebuttonside
            Skins.rollbtnfromtop = rollupbuttontop
            Skins.rollbtnfromside = rollupbuttonside
            Skins.minbtnfromtop = minimizebuttontop
            Skins.minbtnfromside = minimizebuttonside
            Skins.borderwidth = prepgleft.Width
            Skins.titlebarcornerwidth = prepgtoplcorner.Width
            Skins.enablecorners = showwindowcorners
            ' Text
            Skins.titletextfontfamily = pretitletext.Font.FontFamily.Name
            Skins.titletextfontsize = pretitletext.Font.Size
            Skins.titletextfontstyle = pretitletext.Font.Style
            Skins.titletextpos = titletextposition
            Skins.titletextfromtop = titletexttop
            Skins.titletextfromside = titletextside
            Skins.titletextcolour = pretitletext.ForeColor

            Skins.launcheritemcolour = launcheritemtxtcolour.BackColor
            Skins.launcheritemfont = launcheritemfont.Text
            Select Case launcheritemstyle.SelectedItem.ToString
                Case "Bold"
                    Skins.launcheritemstyle = FontStyle.Bold
                Case "Italic"
                    Skins.launcheritemstyle = FontStyle.Italic
                Case "Regular"
                    Skins.launcheritemstyle = FontStyle.Regular
                Case "Strikeout"
                    Skins.launcheritemstyle = FontStyle.Strikeout
                Case "Underline"
                    Skins.launcheritemstyle = FontStyle.Underline
            End Select
            Skins.launcheritemsize = txtlauncheritemtxtsize.Text

            ' DESKTOP
            Skins.desktoppanelcolour = desktoppanelcolour
            Skins.desktopbackgroundcolour = desktopbackgroundcolour
            Skins.desktoppanelheight = desktoppanelheight
            Skins.desktoppanelposition = desktoppanelposition
            Skins.clocktextcolour = clocktextcolour
            Skins.clockbackgroundcolor = clockbackgroundcolor
            Skins.panelclocktexttop = panelclocktexttop
            Skins.panelclocktextsize = panelclocktextsize
            Skins.panelclocktextfont = panelclocktextfont
            Skins.panelclocktextstyle = panelclocktextstyle
            Skins.applauncherbuttoncolour = applauncherbuttoncolour
            Skins.applauncherbuttonclickedcolour = applauncherbuttonclickedcolour
            Skins.applauncherbackgroundcolour = applauncherbackgroundcolour
            Skins.applaunchermouseovercolour = applaunchermouseovercolour
            Skins.applicationsbuttontextcolour = applicationsbuttontextcolour
            Skins.applicationbuttonheight = applicationbuttonheight
            Skins.applicationbuttontextsize = applicationbuttontextsize
            Skins.applicationbuttontextfont = applicationbuttontextfont
            Skins.applicationbuttontextstyle = applicationbuttontextstyle
            Skins.applicationlaunchername = applicationlaunchername
            Skins.titletextposition = titletextposition
            Skins.applaunchermenuholderwidth = applaunchermenuholderwidth
            Skins.panelbuttonicontop = panelbuttonicontop
            Skins.panelbuttoniconside = panelbuttoniconside
            Skins.panelbuttoniconsize = panelbuttoniconsize
            Skins.panelbuttonheight = panelbuttonheight
            Skins.panelbuttonwidth = panelbuttonwidth
            Skins.panelbuttoncolour = panelbuttoncolour
            Skins.panelbuttontextcolour = panelbuttontextcolour
            Skins.panelbuttontextsize = panelbuttontextsize
            Skins.panelbuttontextfont = panelbuttontextfont
            Skins.panelbuttontextstyle = panelbuttontextstyle
            Skins.panelbuttontextside = panelbuttontextside
            Skins.panelbuttontexttop = panelbuttontexttop
            Skins.panelbuttongap = panelbuttongap
            Skins.panelbuttonfromtop = panelbuttonfromtop
            Skins.panelbuttoninitialgap = panelbuttoninitialgap
            ' images
            Skins.desktoppanel = predesktoppanel.BackgroundImage
            Skins.desktoppanellayout = predesktoppanel.BackgroundImageLayout
            Skins.desktopbackground = pnldesktoppreview.BackgroundImage
            Skins.desktopbackgroundlayout = pnldesktoppreview.BackgroundImageLayout
            Skins.panelclock = pretimepanel.BackgroundImage
            Skins.panelclocklayout = pretimepanel.BackgroundImageLayout
            Skins.applaunchermouseover = skinapplauncherbutton(1)
            Skins.applauncher = skinapplauncherbutton(0)
            Skins.applauncherlayout = skinapplauncherbuttonstyle
            Skins.applauncherclick = skinapplauncherbutton(2)
            Skins.panelbutton = prepnlpanelbutton.BackgroundImage
            Skins.panelbuttonlayout = prepnlpanelbutton.BackgroundImageLayout
            Skins.leftcorner = prepgtoplcorner.BackgroundImage
            Skins.rightcorner = prepgtoprcorner.BackgroundImage

            Skins.bottomleftcorner = prepgbottomlcorner.BackgroundImage
            Skins.bottomleftcornerlayout = prepgbottomlcorner.BackgroundImageLayout
            Skins.bottomrightcorner = prepgbottomrcorner.BackgroundImage
            Skins.bottomrightcornerlayout = prepgbottomrcorner.BackgroundImageLayout
            Skins.enablebordercorners = cbindividualbordercolours.Checked
            Skins.titleiconfromside = titlebariconside
            Skins.titleiconfromtop = titlebaricontop
            Skins.enabledraggableicons = CheckBox1.Checked
            Skins.icontextcolor = icontextcolor

            'Adv App Launcher - Suggested by DevX

            Skins.usernametextcolor = usernametextcolor
            Skins.usernamefont = usernamefont
            Skins.usernamefontsize = usernamefontsize
            Skins.usernamefontstyle = usernamefontstyle
            Skins.userNamePanelBackgroundColor = usernamebgcolor
            Try
                Skins.userNamePanelBackground = skinuserpanel(0)
            Catch
                Skins.userNamePanelBackground = Nothing
            End Try
            Skins.powerPanelBackgroundColor = powerpanelbgcolor
            Try
                Skins.powerPanelBackgroundImage = skinshutdownbutton(0)
            Catch
                Skins.powerPanelBackgroundImage = Nothing
            End Try
            Skins.pwrPanelBackgroundLayout = pwrbglayout
            ' APPLY
            Skins.saveskinfiles(True)
            'windows resize fix
            ' earn code points
            customizationpointsearned = customizationtimepoints
            If customizationsdone < 0 Then customizationpointsearned = customizationpointsearned - Math.Abs(customizationsdone)
            ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + customizationpointsearned
            btnapply.Text = "Earned " & customizationpointsearned & " CP"
            btnapply.BackColor = Color.Black
            btnapply.ForeColor = Color.White
            customizationtimepoints = 0
            customizationsdone = 0
            customizationpointsearned = 0
            timerearned.Start()
        End If

    End Sub

    Dim timingissuefixer As Integer = 0
    Public Sub applysettings()
        If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Skins\CurrentCopy\") Then My.Computer.FileSystem.DeleteDirectory(ShiftOSPath + "Shiftum42\Skins\CurrentCopy\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        saveskintocurrentskin()

        'delay fixes timing issue
        tmrdelay.Start()
        If timingissuefixer > 10 Then
            tmrdelay.Stop()

            'quick fixes
            If titlebarheight > 500 Then
                titlebarheight = 500
                txttitlebarheight.Text = "500"
            End If

            If windowbordersize > 500 Then
                windowbordersize = 500
                txtbordersize.Text = "500"
            End If

            If desktoppanelheight > 500 Then
                desktoppanelheight = 500
                txtdesktoppanelheight.Text = "500"
            End If

            'ShiftOSDesktop.titlebarcolour = titlebarcolour
            'ShiftOSDesktop.windowbordercolour = windowbordercolour
            'ShiftOSDesktop.windowbordersize = windowbordersize
            'ShiftOSDesktop.titlebarheight = titlebarheight
            'ShiftOSDesktop.closebuttoncolour = closebuttoncolour
            'ShiftOSDesktop.closebuttonheight = closebuttonheight
            'ShiftOSDesktop.closebuttonwidth = closebuttonwidth
            'ShiftOSDesktop.closebuttontop = closebuttontop
            'ShiftOSDesktop.closebuttonside = closebuttonside
            'ShiftOSDesktop.titletextcolour = titletextcolour
            'ShiftOSDesktop.titletexttop = titletexttop
            'ShiftOSDesktop.titletextside = titletextside
            'ShiftOSDesktop.titletextsize = titletextsize
            'ShiftOSDesktop.titletextfont = titletextfont
            'ShiftOSDesktop.titletextstyle = titletextstyle
            'ShiftOSDesktop.desktoppanelcolour = desktoppanelcolour
            'ShiftOSDesktop.desktopbackgroundcolour = desktopbackgroundcolour
            'ShiftOSDesktop.desktoppanelheight = desktoppanelheight
            'ShiftOSDesktop.desktoppanelposition = desktoppanelposition
            'ShiftOSDesktop.clocktextcolour = clocktextcolour
            'ShiftOSDesktop.clockbackgroundcolor = clockbackgroundcolor
            'ShiftOSDesktop.panelclocktexttop = panelclocktexttop
            'ShiftOSDesktop.panelclocktextsize = panelclocktextsize
            'ShiftOSDesktop.panelclocktextfont = panelclocktextfont
            'ShiftOSDesktop.panelclocktextstyle = panelclocktextstyle
            'ShiftOSDesktop.applauncherbuttoncolour = applauncherbuttoncolour
            'ShiftOSDesktop.applauncherbuttonclickedcolour = applauncherbuttonclickedcolour
            'ShiftOSDesktop.applauncherbackgroundcolour = applauncherbackgroundcolour
            'ShiftOSDesktop.applaunchermouseovercolour = applaunchermouseovercolour
            'ShiftOSDesktop.ApplicationsToolStripMenuItem.BackColor = Color.Transparent
            'ShiftOSDesktop.applicationsbuttontextcolour = applicationsbuttontextcolour
            'ShiftOSDesktop.applicationbuttonheight = applicationbuttonheight
            'ShiftOSDesktop.applicationbuttontextsize = applicationbuttontextsize
            'ShiftOSDesktop.applicationbuttontextfont = applicationbuttontextfont
            'ShiftOSDesktop.applicationbuttontextstyle = applicationbuttontextstyle
            'ShiftOSDesktop.applicationlaunchername = applicationlaunchername
            'ShiftOSDesktop.titletextposition = titletextposition
            'ShiftOSDesktop.rollupbuttoncolour = rollupbuttoncolour
            'ShiftOSDesktop.rollupbuttonheight = rollupbuttonheight
            'ShiftOSDesktop.rollupbuttonwidth = rollupbuttonwidth
            'ShiftOSDesktop.rollupbuttonside = rollupbuttonside
            'ShiftOSDesktop.rollupbuttontop = rollupbuttontop
            'ShiftOSDesktop.titlebariconside = titlebariconside
            'ShiftOSDesktop.titlebaricontop = titlebaricontop
            'ShiftOSDesktop.showwindowcorners = showwindowcorners
            'ShiftOSDesktop.titlebarcornerwidth = titlebarcornerwidth
            'ShiftOSDesktop.titlebarrightcornercolour = titlebarrightcornercolour
            'ShiftOSDesktop.titlebarleftcornercolour = titlebarleftcornercolour
            'ShiftOSDesktop.applaunchermenuholderwidth = applaunchermenuholderwidth
            'ShiftOSDesktop.windowborderleftcolour = windowborderleftcolour
            'ShiftOSDesktop.windowborderrightcolour = windowborderrightcolour
            'ShiftOSDesktop.windowborderbottomcolour = windowborderbottomcolour
            'ShiftOSDesktop.windowborderbottomrightcolour = windowborderbottomrightcolour
            'ShiftOSDesktop.windowborderbottomleftcolour = windowborderbottomleftcolour
            'ShiftOSDesktop.panelbuttonicontop = panelbuttonicontop
            'ShiftOSDesktop.panelbuttoniconside = panelbuttoniconside
            'ShiftOSDesktop.panelbuttoniconsize = panelbuttoniconsize
            'ShiftOSDesktop.panelbuttoniconsize = panelbuttoniconsize
            'ShiftOSDesktop.panelbuttonheight = panelbuttonheight
            'ShiftOSDesktop.panelbuttonwidth = panelbuttonwidth
            'ShiftOSDesktop.panelbuttoncolour = panelbuttoncolour
            'ShiftOSDesktop.panelbuttontextcolour = panelbuttontextcolour
            'ShiftOSDesktop.panelbuttontextsize = panelbuttontextsize
            'ShiftOSDesktop.panelbuttontextfont = panelbuttontextfont
            'ShiftOSDesktop.panelbuttontextstyle = panelbuttontextstyle
            'ShiftOSDesktop.panelbuttontextside = panelbuttontextside
            'ShiftOSDesktop.panelbuttontexttop = panelbuttontexttop
            'ShiftOSDesktop.panelbuttongap = panelbuttongap
            'ShiftOSDesktop.panelbuttonfromtop = panelbuttonfromtop
            'ShiftOSDesktop.panelbuttoninitialgap = panelbuttoninitialgap
            'ShiftOSDesktop.minimizebuttoncolour = minimizebuttoncolour
            'ShiftOSDesktop.minimizebuttonheight = minimizebuttonheight
            'ShiftOSDesktop.minimizebuttonwidth = minimizebuttonwidth
            'ShiftOSDesktop.minimizebuttonside = minimizebuttonside
            'ShiftOSDesktop.minimizebuttontop = minimizebuttontop

            If shifterskinimages(0) = Nothing Then  Else skinclosebutton(0) = GetImage(shifterskinimages(0))
            If shifterskinimages(1) = Nothing Then  Else skinclosebutton(1) = GetImage(shifterskinimages(1))
            If shifterskinimages(2) = Nothing Then  Else skinclosebutton(2) = GetImage(shifterskinimages(2))
            If shifterskinimages(3) = Nothing Then  Else shifterskintitlebar(0) = GetImage(shifterskinimages(3))
            If shifterskinimages(4) = Nothing Then  Else shifterskintitlebar(1) = GetImage(shifterskinimages(4))
            If shifterskinimages(5) = Nothing Then  Else shifterskintitlebar(2) = GetImage(shifterskinimages(5))
            If shifterskinimages(6) = Nothing Then  Else skindesktopbackground(0) = GetImage(shifterskinimages(6))
            If shifterskinimages(7) = Nothing Then  Else skindesktopbackground(1) = GetImage(shifterskinimages(7))
            If shifterskinimages(8) = Nothing Then  Else skindesktopbackground(2) = GetImage(shifterskinimages(8))
            If shifterskinimages(9) = Nothing Then  Else skinrollupbutton(0) = GetImage(shifterskinimages(9))
            If shifterskinimages(10) = Nothing Then  Else skinrollupbutton(1) = GetImage(shifterskinimages(10))
            If shifterskinimages(11) = Nothing Then  Else skinrollupbutton(2) = GetImage(shifterskinimages(11))
            If shifterskinimages(12) = Nothing Then  Else skintitlebarrightcorner(0) = GetImage(shifterskinimages(12))
            If shifterskinimages(13) = Nothing Then  Else skintitlebarrightcorner(1) = GetImage(shifterskinimages(13))
            If shifterskinimages(14) = Nothing Then  Else skintitlebarrightcorner(2) = GetImage(shifterskinimages(14))
            If shifterskinimages(15) = Nothing Then  Else skintitlebarleftcorner(0) = GetImage(shifterskinimages(15))
            If shifterskinimages(16) = Nothing Then  Else skintitlebarleftcorner(1) = GetImage(shifterskinimages(16))
            If shifterskinimages(17) = Nothing Then  Else skintitlebarleftcorner(2) = GetImage(shifterskinimages(17))
            If shifterskinimages(18) = Nothing Then  Else skindesktoppanel(0) = GetImage(shifterskinimages(18))
            If shifterskinimages(19) = Nothing Then  Else skindesktoppanel(1) = GetImage(shifterskinimages(19))
            If shifterskinimages(20) = Nothing Then  Else skindesktoppanel(2) = GetImage(shifterskinimages(20))
            If shifterskinimages(21) = Nothing Then  Else skindesktoppaneltime(0) = GetImage(shifterskinimages(21))
            If shifterskinimages(22) = Nothing Then  Else skindesktoppaneltime(1) = GetImage(shifterskinimages(22))
            If shifterskinimages(23) = Nothing Then  Else skindesktoppaneltime(2) = GetImage(shifterskinimages(23))
            If shifterskinimages(24) = Nothing Then  Else skinapplauncherbutton(0) = GetImage(shifterskinimages(24))
            If shifterskinimages(25) = Nothing Then  Else skinapplauncherbutton(1) = GetImage(shifterskinimages(25))
            If shifterskinimages(26) = Nothing Then  Else skinapplauncherbutton(2) = GetImage(shifterskinimages(26))
            If shifterskinimages(27) = Nothing Then  Else skinwindowborderleft(0) = GetImage(shifterskinimages(27))
            If shifterskinimages(28) = Nothing Then  Else skinwindowborderleft(1) = GetImage(shifterskinimages(28))
            If shifterskinimages(29) = Nothing Then  Else skinwindowborderleft(2) = GetImage(shifterskinimages(29))
            If shifterskinimages(30) = Nothing Then  Else skinwindowborderright(0) = GetImage(shifterskinimages(30))
            If shifterskinimages(31) = Nothing Then  Else skinwindowborderright(1) = GetImage(shifterskinimages(31))
            If shifterskinimages(32) = Nothing Then  Else skinwindowborderright(2) = GetImage(shifterskinimages(32))
            If shifterskinimages(33) = Nothing Then  Else skinwindowborderbottom(0) = GetImage(shifterskinimages(33))
            If shifterskinimages(34) = Nothing Then  Else skinwindowborderbottom(1) = GetImage(shifterskinimages(34))
            If shifterskinimages(35) = Nothing Then  Else skinwindowborderbottom(2) = GetImage(shifterskinimages(35))
            If shifterskinimages(36) = Nothing Then  Else skinwindowborderbottomright(0) = GetImage(shifterskinimages(36))
            If shifterskinimages(37) = Nothing Then  Else skinwindowborderbottomright(1) = GetImage(shifterskinimages(37))
            If shifterskinimages(38) = Nothing Then  Else skinwindowborderbottomright(2) = GetImage(shifterskinimages(38))
            If shifterskinimages(39) = Nothing Then  Else skinwindowborderbottomleft(0) = GetImage(shifterskinimages(39))
            If shifterskinimages(40) = Nothing Then  Else skinwindowborderbottomleft(1) = GetImage(shifterskinimages(40))
            If shifterskinimages(41) = Nothing Then  Else skinwindowborderbottomleft(2) = GetImage(shifterskinimages(41))
            If shifterskinimages(42) = Nothing Then  Else skinminimizebutton(0) = GetImage(shifterskinimages(42))
            If shifterskinimages(43) = Nothing Then  Else skinminimizebutton(1) = GetImage(shifterskinimages(43))
            If shifterskinimages(44) = Nothing Then  Else skinminimizebutton(2) = GetImage(shifterskinimages(44))
            If shifterskinimages(45) = Nothing Then  Else skinpanelbutton(0) = GetImage(shifterskinimages(45))
            If shifterskinimages(46) = Nothing Then  Else skinpanelbutton(1) = GetImage(shifterskinimages(46))
            If shifterskinimages(47) = Nothing Then  Else skinpanelbutton(2) = GetImage(shifterskinimages(47))

            ''skins
            'Array.Copy(shifterskinimages, ShiftOSDesktop.skinimages, ShiftOSDesktop.skinimages.Length)

            'If skinclosebutton(0) Is Nothing Then  Else ShiftOSDesktop.skinclosebutton(0) = skinclosebutton(0).Clone
            'If skinclosebutton(1) Is Nothing Then  Else ShiftOSDesktop.skinclosebutton(1) = skinclosebutton(1).Clone
            'If skinclosebutton(2) Is Nothing Then  Else ShiftOSDesktop.skinclosebutton(2) = skinclosebutton(2).Clone
            'ShiftOSDesktop.skinclosebuttonstyle = skinclosebuttonstyle

            'If shifterskintitlebar(0) Is Nothing Then  Else ShiftOSDesktop.skintitlebar(0) = shifterskintitlebar(0).Clone
            'If shifterskintitlebar(1) Is Nothing Then  Else ShiftOSDesktop.skintitlebar(1) = shifterskintitlebar(1).Clone
            'If shifterskintitlebar(2) Is Nothing Then  Else ShiftOSDesktop.skintitlebar(2) = shifterskintitlebar(2).Clone
            'ShiftOSDesktop.skintitlebarstyle = skintitlebarstyle

            'If skindesktopbackground(0) Is Nothing Then  Else ShiftOSDesktop.skindesktopbackground(0) = skindesktopbackground(0).Clone
            'If skindesktopbackground(1) Is Nothing Then  Else ShiftOSDesktop.skindesktopbackground(1) = skindesktopbackground(1).Clone
            'If skindesktopbackground(2) Is Nothing Then  Else ShiftOSDesktop.skindesktopbackground(2) = skindesktopbackground(2).Clone
            'ShiftOSDesktop.skindesktopbackgroundstyle = skindesktopbackgroundstyle

            'If skinrollupbutton(0) Is Nothing Then  Else ShiftOSDesktop.skinrollupbutton(0) = skinrollupbutton(0).Clone
            'If skinrollupbutton(1) Is Nothing Then  Else ShiftOSDesktop.skinrollupbutton(1) = skinrollupbutton(1).Clone
            'If skinrollupbutton(2) Is Nothing Then  Else ShiftOSDesktop.skinrollupbutton(2) = skinrollupbutton(2).Clone
            'ShiftOSDesktop.skinrollupbuttonstyle = skinrollupbuttonstyle

            'If skintitlebarrightcorner(0) Is Nothing Then  Else ShiftOSDesktop.skintitlebarrightcorner(0) = skintitlebarrightcorner(0).Clone
            'If skintitlebarrightcorner(1) Is Nothing Then  Else ShiftOSDesktop.skintitlebarrightcorner(1) = skintitlebarrightcorner(1).Clone
            'If skintitlebarrightcorner(2) Is Nothing Then  Else ShiftOSDesktop.skintitlebarrightcorner(2) = skintitlebarrightcorner(2).Clone
            'ShiftOSDesktop.skintitlebarrightcornerstyle = skintitlebarrightcornerstyle

            'If skintitlebarleftcorner(0) Is Nothing Then  Else ShiftOSDesktop.skintitlebarleftcorner(0) = skintitlebarleftcorner(0).Clone
            'If skintitlebarleftcorner(1) Is Nothing Then  Else ShiftOSDesktop.skintitlebarleftcorner(1) = skintitlebarleftcorner(1).Clone
            'If skintitlebarleftcorner(2) Is Nothing Then  Else ShiftOSDesktop.skintitlebarleftcorner(2) = skintitlebarleftcorner(2).Clone
            'ShiftOSDesktop.skintitlebarleftcornerstyle = skintitlebarleftcornerstyle

            'If skindesktoppanel(0) Is Nothing Then  Else ShiftOSDesktop.skindesktoppanel(0) = skindesktoppanel(0).Clone
            'If skindesktoppanel(1) Is Nothing Then  Else ShiftOSDesktop.skindesktoppanel(1) = skindesktoppanel(1).Clone
            'If skindesktoppanel(2) Is Nothing Then  Else ShiftOSDesktop.skindesktoppanel(2) = skindesktoppanel(2).Clone
            'ShiftOSDesktop.skindesktoppanelstyle = skindesktoppanelstyle

            'If skindesktoppaneltime(0) Is Nothing Then  Else ShiftOSDesktop.skindesktoppaneltime(0) = skindesktoppaneltime(0).Clone
            'If skindesktoppaneltime(1) Is Nothing Then  Else ShiftOSDesktop.skindesktoppaneltime(1) = skindesktoppaneltime(1).Clone
            'If skindesktoppaneltime(2) Is Nothing Then  Else ShiftOSDesktop.skindesktoppaneltime(2) = skindesktoppaneltime(2).Clone
            'ShiftOSDesktop.skindesktoppaneltimestyle = skindesktoppaneltimestyle

            'If skinapplauncherbutton(0) Is Nothing Then  Else ShiftOSDesktop.skinapplauncherbutton(0) = skinapplauncherbutton(0).Clone
            'If skinapplauncherbutton(1) Is Nothing Then  Else ShiftOSDesktop.skinapplauncherbutton(1) = skinapplauncherbutton(1).Clone
            'If skinapplauncherbutton(2) Is Nothing Then  Else ShiftOSDesktop.skinapplauncherbutton(2) = skinapplauncherbutton(2).Clone
            'ShiftOSDesktop.skinapplauncherbuttonstyle = skinapplauncherbuttonstyle

            'If skinwindowborderleft(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderleft(0) = skinwindowborderleft(0).Clone
            'If skinwindowborderleft(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderleft(1) = skinwindowborderleft(1).Clone
            'If skinwindowborderleft(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderleft(2) = skinwindowborderleft(2).Clone
            'ShiftOSDesktop.skinwindowborderleftstyle = skinwindowborderleftstyle

            'If skinwindowborderright(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderright(0) = skinwindowborderright(0).Clone
            'If skinwindowborderright(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderright(1) = skinwindowborderright(1).Clone
            'If skinwindowborderright(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderright(2) = skinwindowborderright(2).Clone
            'ShiftOSDesktop.skinwindowborderrightstyle = skinwindowborderrightstyle

            'If skinwindowborderbottom(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottom(0) = skinwindowborderbottom(0).Clone
            'If skinwindowborderbottom(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottom(1) = skinwindowborderbottom(1).Clone
            'If skinwindowborderbottom(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottom(2) = skinwindowborderbottom(2).Clone
            'ShiftOSDesktop.skinwindowborderbottomstyle = skinwindowborderbottomstyle

            'If skinwindowborderbottomright(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomright(0) = skinwindowborderbottomright(0).Clone
            'If skinwindowborderbottomright(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomright(1) = skinwindowborderbottomright(1).Clone
            'If skinwindowborderbottomright(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomright(2) = skinwindowborderbottomright(2).Clone
            'ShiftOSDesktop.skinwindowborderbottomrightstyle = skinwindowborderbottomrightstyle

            'If skinwindowborderbottomleft(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomleft(0) = skinwindowborderbottomleft(0).Clone
            'If skinwindowborderbottomleft(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomleft(1) = skinwindowborderbottomleft(1).Clone
            'If skinwindowborderbottomleft(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomleft(2) = skinwindowborderbottomleft(2).Clone
            'ShiftOSDesktop.skinwindowborderbottomleftstyle = skinwindowborderbottomleftstyle

            'If skinpanelbutton(0) Is Nothing Then  Else ShiftOSDesktop.skinpanelbutton(0) = skinpanelbutton(0).Clone
            'If skinpanelbutton(1) Is Nothing Then  Else ShiftOSDesktop.skinpanelbutton(1) = skinpanelbutton(1).Clone
            'If skinpanelbutton(2) Is Nothing Then  Else ShiftOSDesktop.skinpanelbutton(2) = skinpanelbutton(2).Clone
            'ShiftOSDesktop.skinpanelbuttonstyle = skinpanelbuttonstyle

            'If skinminimizebutton(0) Is Nothing Then  Else ShiftOSDesktop.skinminimizebutton(0) = skinminimizebutton(0).Clone
            'If skinminimizebutton(1) Is Nothing Then  Else ShiftOSDesktop.skinminimizebutton(1) = skinminimizebutton(1).Clone
            'If skinminimizebutton(2) Is Nothing Then  Else ShiftOSDesktop.skinminimizebutton(2) = skinminimizebutton(2).Clone
            'ShiftOSDesktop.skinminimizebuttonstyle = skinminimizebuttonstyle

            'GC.Collect()

            'ShiftOSDesktop.setcolours()
            ShiftOSDesktop.setupdesktop()
            ShiftOSDesktop.setuppanelbuttons()
            ShiftOSDesktop.Invalidate()

            customizationpointsearned = customizationtimepoints
            If customizationsdone < 0 Then customizationpointsearned = customizationpointsearned - Math.Abs(customizationsdone)
            ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + customizationpointsearned
            btnapply.Text = "Earned " & customizationpointsearned & " CP"
            btnapply.BackColor = Color.Black
            btnapply.ForeColor = Color.White
            customizationtimepoints = 0
            customizationsdone = 0
            customizationpointsearned = 0
            timerearned.Start()

            If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Skins\CurrentCopy\") Then My.Computer.FileSystem.DeleteDirectory(ShiftOSPath + "Shiftum42\Skins\CurrentCopy\", FileIO.DeleteDirectoryOption.DeleteAllContents)
            loadclone()

            Me.Invalidate()

        End If

    End Sub

    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        Return ret
    End Function

    Public Sub saveskintocurrentskin()
        If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Skins\Current\") Then  Else My.Computer.FileSystem.CreateDirectory(ShiftOSPath + "Shiftum42\Skins\Current\")
        My.Computer.FileSystem.CopyDirectory(ShiftOSPath + "Shiftum42\Skins\Current\", ShiftOSPath + "Shiftum42\Skins\CurrentCopy\")
        'ShiftOSDesktop.disposeoldskindata("shifterapply")

        For i = 0 To 50
            If shifterskinimages(i) Is Nothing Then  Else If shifterskinimages(i).Contains(ShiftOSPath + "Shiftum42\Skins\Current\") Then shifterskinimages(i) = shifterskinimages(i).Replace("Current", "CurrentCopy")
        Next

        'My.Computer.FileSystem.CopyDirectory(ShiftOSPath + "Shiftum42\Skins\ChangeOverTempFiles", ShiftOSPath + "Shiftum42\Skins\Current\")



        skinlines(0) = titlebarcolour.ToArgb
        skinlines(1) = windowbordercolour.ToArgb
        skinlines(2) = windowbordersize
        skinlines(3) = titlebarheight
        skinlines(4) = closebuttoncolour.ToArgb
        skinlines(5) = closebuttonheight
        skinlines(6) = closebuttonwidth
        skinlines(7) = closebuttonside
        skinlines(8) = closebuttontop
        skinlines(9) = titletextcolour.ToArgb
        skinlines(10) = titletexttop
        skinlines(11) = titletextside
        skinlines(12) = titletextsize
        skinlines(13) = titletextfont
        skinlines(14) = titletextstyle
        skinlines(15) = desktoppanelcolour.ToArgb
        skinlines(16) = desktopbackgroundcolour.ToArgb
        skinlines(17) = desktoppanelheight
        skinlines(18) = desktoppanelposition
        skinlines(19) = clocktextcolour.ToArgb
        skinlines(20) = clockbackgroundcolor.ToArgb
        skinlines(21) = panelclocktexttop
        skinlines(22) = panelclocktextsize
        skinlines(23) = panelclocktextfont
        skinlines(24) = panelclocktextstyle
        skinlines(25) = applauncherbuttoncolour.ToArgb
        skinlines(26) = applauncherbuttonclickedcolour.ToArgb
        skinlines(27) = applauncherbackgroundcolour.ToArgb
        skinlines(28) = applaunchermouseovercolour.ToArgb
        skinlines(29) = applicationsbuttontextcolour.ToArgb
        skinlines(30) = applicationbuttonheight
        skinlines(31) = applicationbuttontextsize
        skinlines(32) = applicationbuttontextfont
        skinlines(33) = applicationbuttontextstyle
        skinlines(34) = applicationlaunchername
        skinlines(35) = titletextposition
        skinlines(36) = rollupbuttoncolour.ToArgb
        skinlines(37) = rollupbuttonheight
        skinlines(38) = rollupbuttonwidth
        skinlines(39) = rollupbuttonside
        skinlines(40) = rollupbuttontop
        skinlines(41) = titlebariconside
        skinlines(42) = titlebaricontop
        skinlines(43) = showwindowcorners
        skinlines(44) = titlebarcornerwidth
        skinlines(45) = titlebarrightcornercolour.ToArgb
        skinlines(46) = titlebarleftcornercolour.ToArgb
        skinlines(47) = applaunchermenuholderwidth
        skinlines(48) = windowborderleftcolour.ToArgb
        skinlines(49) = windowborderrightcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(53) = panelbuttonicontop
        skinlines(54) = panelbuttoniconside
        skinlines(55) = panelbuttoniconsize
        skinlines(56) = panelbuttoniconsize
        skinlines(57) = panelbuttonheight
        skinlines(58) = panelbuttonwidth
        skinlines(59) = panelbuttoncolour.ToArgb
        skinlines(60) = panelbuttontextcolour.ToArgb
        skinlines(61) = panelbuttontextsize
        skinlines(62) = panelbuttontextfont
        skinlines(63) = panelbuttontextstyle
        skinlines(64) = panelbuttontextside
        skinlines(65) = panelbuttontexttop
        skinlines(66) = panelbuttongap
        skinlines(67) = panelbuttonfromtop
        skinlines(68) = panelbuttoninitialgap
        skinlines(69) = minimizebuttoncolour.ToArgb
        skinlines(70) = minimizebuttonheight
        skinlines(71) = minimizebuttonwidth
        skinlines(72) = minimizebuttonside
        skinlines(73) = minimizebuttontop

        'convert real locations to currentskin folder
        Dim folderdivider As String = "\"
        For i = 0 To 50
            If shifterskinimages(i) = "" Then
            Else
                If shifterskinimages(i).Contains("\") Then folderdivider = "\" Else folderdivider = "/"
                If IO.File.Exists(shifterskinimages(i)) = True Then
                    IO.File.Copy(shifterskinimages(i), ShiftOSPath + "Shiftum42\Skins\Current\" & shifterskinimages(i).Substring(shifterskinimages(i).LastIndexOf(folderdivider)), True)
                    shifterskinimages(i) = ShiftOSPath + "Shiftum42\Skins\Current\" & shifterskinimages(i).Substring(shifterskinimages(i).LastIndexOf(folderdivider) + 1)
                Else
                    infobox.showinfo("Skinning Error", "It seems that the images used by this skin have been deleted. The file " & shifterskinimages(i) & " cannot be found.")
                End If
            End If

        Next

        skinlines(100) = shifterskinimages(0)
        skinlines(101) = shifterskinimages(1)
        skinlines(102) = shifterskinimages(2)
        skinlines(103) = shifterskinimages(3)
        skinlines(104) = shifterskinimages(4)
        skinlines(105) = shifterskinimages(5)
        skinlines(106) = shifterskinimages(6)
        skinlines(107) = shifterskinimages(7)
        skinlines(108) = shifterskinimages(8)
        skinlines(109) = shifterskinimages(9)
        skinlines(110) = shifterskinimages(10)
        skinlines(111) = shifterskinimages(11)
        skinlines(112) = shifterskinimages(12)
        skinlines(113) = shifterskinimages(13)
        skinlines(114) = shifterskinimages(14)
        skinlines(115) = shifterskinimages(15)
        skinlines(116) = shifterskinimages(16)
        skinlines(117) = shifterskinimages(17)
        skinlines(118) = shifterskinimages(18)
        skinlines(119) = shifterskinimages(19)
        skinlines(120) = shifterskinimages(20)
        skinlines(121) = shifterskinimages(21)
        skinlines(122) = shifterskinimages(22)
        skinlines(123) = shifterskinimages(23)
        skinlines(124) = shifterskinimages(24)
        skinlines(125) = shifterskinimages(25)
        skinlines(126) = shifterskinimages(26)
        skinlines(127) = shifterskinimages(27)
        skinlines(128) = shifterskinimages(28)
        skinlines(129) = shifterskinimages(29)
        skinlines(130) = shifterskinimages(30)
        skinlines(131) = shifterskinimages(31)
        skinlines(132) = shifterskinimages(32)
        skinlines(133) = shifterskinimages(33)
        skinlines(134) = shifterskinimages(34)
        skinlines(135) = shifterskinimages(35)
        skinlines(136) = shifterskinimages(36)
        skinlines(137) = shifterskinimages(37)
        skinlines(138) = shifterskinimages(38)
        skinlines(139) = shifterskinimages(39)
        skinlines(140) = shifterskinimages(40)
        skinlines(141) = shifterskinimages(41)
        skinlines(142) = shifterskinimages(42)
        skinlines(143) = shifterskinimages(43)
        skinlines(144) = shifterskinimages(44)
        skinlines(145) = shifterskinimages(45)
        skinlines(146) = shifterskinimages(46)
        skinlines(147) = shifterskinimages(47)
        skinlines(148) = shifterskinimages(48)
        skinlines(149) = shifterskinimages(49)
        skinlines(150) = shifterskinimages(50)

        IO.File.WriteAllLines(ShiftOSPath + "Shiftum42\Skins\Current\skindata.dat", skinlines)
    End Sub

    Private Sub setclocktime()
        If ShiftOSDesktop.boughtsplitsecondtime = True Then
            prepaneltimetext.Text = TimeOfDay
        Else
            If ShiftOSDesktop.boughtminuteaccuracytime = True Then
                If Date.Now.Hour < 12 Then
                    prepaneltimetext.Text = TimeOfDay.Hour & ":" & Format(TimeOfDay.Minute, "00") & " AM"
                Else
                    prepaneltimetext.Text = TimeOfDay.Hour - 12 & ":" & Format(TimeOfDay.Minute, "00") & " PM"
                End If
            Else
                If ShiftOSDesktop.boughtpmandam = True Then
                    If Date.Now.Hour < 12 Then
                        prepaneltimetext.Text = TimeOfDay.Hour & " AM"
                    Else
                        prepaneltimetext.Text = TimeOfDay.Hour - 12 & " PM"
                    End If
                Else
                    If ShiftOSDesktop.boughthourspastmidnight = True Then
                        prepaneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60 / 60)
                    Else
                        If ShiftOSDesktop.boughtminutespastmidnight = True Then
                            prepaneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60)
                        Else
                            If ShiftOSDesktop.boughtsecondspastmidnight = True Then
                                prepaneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub pnlwindowsoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlwindowsoptions.Paint
        'e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlwindowsobjects.ClientRectangle)
    End Sub

    Private Sub catholder_Paint(sender As Object, e As PaintEventArgs) Handles catholder.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), catholder.ClientRectangle)
    End Sub

    Private Sub btnwindows_Click(sender As Object, e As EventArgs) Handles btnwindows.Click
        pnlwindowsoptions.Location = New Point(133, 6)
        pnlwindowsoptions.Size = New Size(458, 297)
        pnlwindowsoptions.Show()
        pnlwindowsoptions.BringToFront()

    End Sub



    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        pnlreset.Location = New Point(133, 6)
        pnlreset.Size = New Size(458, 297)
        pnlreset.Show()
        pnlreset.BringToFront()

    End Sub

    Private Sub pnltitlebarcolour_Click(sender As Object, e As MouseEventArgs) Handles pnltitlebarcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Title Bar Colour"
            Colour_Picker.oldcolour = titlebarcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Title Bar"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlbordercolour_Click(sender As Object, e As EventArgs) Handles pnlbordercolour.Click
        Colour_Picker.colourtochange = "Window Border Colour"
        Colour_Picker.oldcolour = windowbordercolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlclosebuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlclosebuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Close Button Colour"
            Colour_Picker.oldcolour = closebuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Close Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderrightcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderrightcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Right Colour"
            Colour_Picker.oldcolour = windowborderrightcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Right"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderleftcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderleftcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Left Colour"
            Colour_Picker.oldcolour = windowborderleftcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Left"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderbottomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderbottomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Bottom Colour"
            Colour_Picker.oldcolour = windowborderbottomcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Bottom"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderbottomleftcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderbottomleftcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Bottom Left Colour"
            Colour_Picker.oldcolour = windowborderbottomleftcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Bottom Left"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderbottomrightcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderbottomrightcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Bottom Right Colour"
            Colour_Picker.oldcolour = windowborderbottomrightcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Bottom Right"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnltitletextcolour_click(sender As Object, e As EventArgs) Handles pnltitletextcolour.Click
        Colour_Picker.colourtochange = "Title Text Colour"
        Colour_Picker.oldcolour = titletextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnldesktoppanelcolour_Click(sender As Object, e As MouseEventArgs) Handles pnldesktoppanelcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Desktop Panel Colour"
            Colour_Picker.oldcolour = desktoppanelcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Desktop Panel"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlpanelclocktextcolour_Click(sender As Object, e As EventArgs) Handles pnlpanelclocktextcolour.Click
        Colour_Picker.colourtochange = "Clock Text Colour"
        Colour_Picker.oldcolour = clocktextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlclockbackgroundcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlclockbackgroundcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Clock Background Colour"
            Colour_Picker.oldcolour = clockbackgroundcolor
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Clock Background"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnldesktopcolour_Click(sender As Object, e As MouseEventArgs) Handles pnldesktopcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Desktop Background Colour"
            Colour_Picker.oldcolour = desktopbackgroundcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Desktop Background"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlmainbuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlmainbuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "App Launcher Button Colour"
            Colour_Picker.oldcolour = applauncherbuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "App Launcher Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlmainbuttonactivated_Click(sender As Object, e As EventArgs) Handles pnlmainbuttonactivated.Click
        Colour_Picker.colourtochange = "App Launcher Button Clicked Colour"
        Colour_Picker.oldcolour = applauncherbuttonclickedcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlmenuitemsmouseover_Click(sender As Object, e As EventArgs) Handles pnlmenuitemsmouseover.Click
        Colour_Picker.colourtochange = "App Launcher Mouse Over Colour"
        Colour_Picker.oldcolour = applaunchermouseovercolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlrollupbuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlrollupbuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Roll Up Button Colour"
            Colour_Picker.oldcolour = rollupbuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Roll Up Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlmaintextcolour_Click(sender As Object, e As EventArgs) Handles pnlmaintextcolour.Click
        Colour_Picker.colourtochange = "App Launcher Button Text Colour"
        Colour_Picker.oldcolour = applicationsbuttontextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlpanelbuttontextcolour_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttontextcolour.Click
        Colour_Picker.colourtochange = "Panel Button Text Colour"
        Colour_Picker.oldcolour = panelbuttontextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlmenuitemscolour_Click(sender As Object, e As EventArgs) Handles pnlmenuitemscolour.Click
        Colour_Picker.colourtochange = "App Launcher Items Background Colour"
        Colour_Picker.oldcolour = applauncherbackgroundcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnltitlebarleftcornercolour_Click(sender As Object, e As MouseEventArgs) Handles pnltitlebarleftcornercolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Title Bar Left Corner Colour"
            Colour_Picker.oldcolour = titlebarleftcornercolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Title Bar Left Corner"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnltitlebarrightcornercolour_Click(sender As Object, e As MouseEventArgs) Handles pnltitlebarrightcornercolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Title Bar Right Corner Colour"
            Colour_Picker.oldcolour = titlebarrightcornercolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Title Bar Right Corner"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlminimizebuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlminimizebuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Minimize Button Colour"
            Colour_Picker.oldcolour = minimizebuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Minimize Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlpanelbuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlpanelbuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Panel Button Colour"
            Colour_Picker.oldcolour = panelbuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Panel Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnltitlebarcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebarcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebarcolour.ClientRectangle)
    End Sub

    Private Sub pnltitlebaroptions_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebaroptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebaroptions.ClientRectangle)
    End Sub

    Private Sub pnlbordercolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlbordercolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlbordercolour.ClientRectangle)
    End Sub

    Private Sub pnlborderoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderoptions.ClientRectangle)
    End Sub

    Private Sub btntitlebar_Click(sender As Object, e As EventArgs) Handles btntitlebar.Click
        If ShiftOSDesktop.boughtshifttitlebar Then
            pnltitlebaroptions.Show()
            pnltitlebaroptions.Size = New Size(317, 134)
            pnltitlebaroptions.Location = New Point(136, 159)
            pnltitlebaroptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub btnborders_Click(sender As Object, e As EventArgs) Handles btnborders.Click
        If ShiftOSDesktop.boughtshiftborders Then
            pnlborderoptions.Show()
            pnlborderoptions.Size = New Size(317, 134)
            pnlborderoptions.Location = New Point(136, 159)
            pnlborderoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub txttitlebarheight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttitlebarheight.KeyPress, txtclosebuttonheight.KeyPress, txtclosebuttonwidth.KeyPress, txtclosebuttonfromtop.KeyPress, txtclosebuttonfromside.KeyPress, txtbordersize.KeyPress, txttitletexttop.KeyPress, txttitletextside.KeyPress, txttitletextsize.KeyPress, txtdesktoppanelheight.KeyPress, txtclocktextsize.KeyPress, txtclocktextfromtop.KeyPress, txtapplicationsbuttonheight.KeyPress, txtappbuttontextsize.KeyPress, txtrollupbuttonheight.KeyPress, txtrollupbuttonwidth.KeyPress, txtrollupbuttontop.KeyPress, txtrollupbuttonside.KeyPress, txttitlebarcornerwidth.KeyPress, txtapplauncherwidth.KeyPress, txticonfromside.KeyPress, txticonfromtop.KeyPress, txtminimizebuttonheight.KeyPress, txtminimizebuttonwidth.KeyPress, txtminimizebuttonside.KeyPress, txtminimizebuttontop.KeyPress, txtpanelbuttoninitalgap.KeyPress, txtpanelbuttontop.KeyPress, txtpanelbuttonwidth.KeyPress, txtpanelbuttonheight.KeyPress, txtpanelbuttongap.KeyPress, txtpaneltextbuttonsize.KeyPress, txtpanelbuttontextside.KeyPress, txtpanelbuttontexttop.KeyPress, txtpanelbuttoniconsize.KeyPress, txtpanelbuttoniconsize.KeyPress, txtpanelbuttoniconside.KeyPress, txtpanelbuttonicontop.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txttitlebarheight_TextChanged(sender As Object, e As EventArgs) Handles txttitlebarheight.TextChanged
        If txttitlebarheight.Text = "" Then
        Else
            titlebarheight = txttitlebarheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub btnclosebutton_Click(sender As Object, e As EventArgs) Handles btnbuttons.Click
        If ShiftOSDesktop.boughtshifttitlebuttons Then
            pnlbuttonoptions.Show()
            pnlbuttonoptions.Size = New Size(317, 134)
            pnlbuttonoptions.Location = New Point(136, 159)
            pnlbuttonoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub pnlclosebuttonoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlbuttonoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlbuttonoptions.ClientRectangle)
    End Sub

    Private Sub pnlclosebuttoncolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlclosebuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlclosebuttoncolour.ClientRectangle)
    End Sub

    Private Sub txtclosebuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonheight.TextChanged
        If txtclosebuttonheight.Text = "" Then
        Else
            closebuttonheight = txtclosebuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclosebuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonwidth.TextChanged
        If txtclosebuttonwidth.Text = "" Then
        Else
            closebuttonwidth = txtclosebuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclosebuttonfromtop_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonfromtop.TextChanged
        If txtclosebuttonfromtop.Text = "" Then
        Else
            closebuttontop = txtclosebuttonfromtop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclosebuttonfromside_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonfromside.TextChanged
        If txtclosebuttonfromside.Text = "" Then
        Else
            closebuttonside = txtclosebuttonfromside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtbordersize_TextChanged(sender As Object, e As EventArgs) Handles txtbordersize.TextChanged
        If txtbordersize.Text = "" Then
        Else
            windowbordersize = txtbordersize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub btntitletext_Click(sender As Object, e As EventArgs) Handles btntitletext.Click
        If ShiftOSDesktop.boughtshifttitletext Then
            pnltitletextoptions.Show()
            pnltitletextoptions.Size = New Size(317, 134)
            pnltitletextoptions.Location = New Point(136, 159)
            pnltitletextoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub txttitletexttop_TextChanged(sender As Object, e As EventArgs) Handles txttitletexttop.TextChanged
        If txttitletexttop.Text = "" Then
        Else
            titletexttop = txttitletexttop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txttitletextside_TextChanged(sender As Object, e As EventArgs) Handles txttitletextside.TextChanged
        If txttitletextside.Text = "" Then
        Else
            titletextside = txttitletextside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub pnltitletextcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitletextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitletextcolour.ClientRectangle)
    End Sub

    Private Sub combotitletextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotitletextfont.SelectedIndexChanged
        If combotitletextfont.Text = "" Then
        Else
            titletextfont = combotitletextfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub cbpanelbuttonfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpanelbuttonfont.SelectedIndexChanged
        If cbpanelbuttonfont.Text = "" Then
        Else
            panelbuttontextfont = cbpanelbuttonfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub pnltitletextoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnltitletextoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitletextoptions.ClientRectangle)
    End Sub

    Private Sub txttitletextsize_TextChanged(sender As Object, e As EventArgs) Handles txttitletextsize.TextChanged
        If txttitletextsize.Text = "" OrElse txttitletextsize.Text = "0" Then
        Else
            titletextsize = txttitletextsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub combotitletextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotitletextstyle.SelectedIndexChanged
        Select Case combotitletextstyle.Text
            Case "Bold"
                titletextstyle = FontStyle.Bold
            Case "Italic"
                titletextstyle = FontStyle.Italic
            Case "Regular"
                titletextstyle = FontStyle.Regular
            Case "Strikeout"
                titletextstyle = FontStyle.Strikeout
            Case "Underline"
                titletextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()

    End Sub

    Private Sub btndesktop_Click(sender As Object, e As EventArgs) Handles btndesktop.Click
        pnldesktopoptions.Location = New Point(133, 6)
        pnldesktopoptions.Size = New Size(458, 297)
        pnldesktopoptions.Show()
        pnldesktopoptions.BringToFront()
    End Sub

    Private Sub btndesktoppanel_Click(sender As Object, e As EventArgs) Handles btndesktoppanel.Click
        If ShiftOSDesktop.boughtshiftdesktoppanel Then
            Try
                pnldesktoppaneloptions.Show()
                pnldesktoppaneloptions.Size = New Size(317, 134)
                pnldesktoppaneloptions.Location = New Point(136, 159)
                pnldesktoppaneloptions.BringToFront()
            Catch ex As OutOfMemoryException
                infobox.showinfo("Memory Error", "There has been a memory error while accessing the desktop settings. Operation aborted.")
            End Try
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub btnpanelbuttons_Click(sender As Object, e As EventArgs) Handles btnpanelbuttons.Click
        If ShiftOSDesktop.boughtshiftpanelbuttons Then
            pnlpanelbuttonsoptions.Show()
            pnlpanelbuttonsoptions.Size = New Size(317, 134)
            pnlpanelbuttonsoptions.Location = New Point(136, 159)
            pnlpanelbuttonsoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub pnldesktoppanelcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktoppanelcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktoppanelcolour.ClientRectangle)
    End Sub

    Private Sub pnldesktoppaneloptions_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktoppaneloptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktoppaneloptions.ClientRectangle)
    End Sub

    Private Sub pnldesktopbackgroundoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktopbackgroundoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktopbackgroundoptions.ClientRectangle)
    End Sub

    Private Sub pnldesktopcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktopcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktopcolour.ClientRectangle)
    End Sub

    Private Sub pnlpanelclockoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelclockoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelclockoptions.ClientRectangle)
    End Sub

    Private Sub pnlpanelclockcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelclocktextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelclocktextcolour.ClientRectangle)
    End Sub

    Private Sub pnlclockbackgroundcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlclockbackgroundcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlclockbackgroundcolour.ClientRectangle)
    End Sub

    Private Sub pnltitlebarleftcornercolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebarleftcornercolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebarleftcornercolour.ClientRectangle)
    End Sub

    Private Sub pnltitlebarrightcornercolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebarrightcornercolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebarrightcornercolour.ClientRectangle)
    End Sub

    Private Sub pnlapplauncheroptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlapplauncheroptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlapplauncheroptions.ClientRectangle)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles pnlmainbuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmainbuttoncolour.ClientRectangle)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnlmainbuttonactivated.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmainbuttonactivated.ClientRectangle)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles pnlmenuitemscolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmenuitemscolour.ClientRectangle)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles pnlmenuitemsmouseover.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmenuitemsmouseover.ClientRectangle)
    End Sub

    Private Sub pnlmaintextcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlmaintextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmaintextcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderbottomcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderbottomcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderbottomcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderleftcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderleftcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderleftcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderrightcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderrightcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderrightcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderbottomleftcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderbottomleftcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderbottomleftcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderbottomrightcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderbottomrightcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderbottomrightcolour.ClientRectangle)
    End Sub

    Private Sub pnlpanelbuttonsoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelbuttonsoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelbuttonsoptions.ClientRectangle)
    End Sub

    Private Sub pnlpanelbuttoncolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelbuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelbuttoncolour.ClientRectangle)
    End Sub

    Private Sub pnlpanelbuttontextcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelbuttontextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelbuttontextcolour.ClientRectangle)
    End Sub

    Private Sub btndesktopitself_Click(sender As Object, e As EventArgs) Handles btndesktopitself.Click
        If ShiftOSDesktop.boughtshiftdesktop Then
            pnldesktopbackgroundoptions.Show()
            pnldesktopbackgroundoptions.Size = New Size(317, 134)
            pnldesktopbackgroundoptions.Location = New Point(136, 159)
            pnldesktopbackgroundoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub txtdesktoppanelheight_TextChanged(sender As Object, e As EventArgs) Handles txtdesktoppanelheight.TextChanged
        If txtdesktoppanelheight.Text = "" Then
        Else
            desktoppanelheight = txtdesktoppanelheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub combodesktoppanelposition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodesktoppanelposition.SelectedIndexChanged
        Select Case combodesktoppanelposition.Text
            Case "Top"
                desktoppanelposition = "Top"
            Case "Bottom"
                desktoppanelposition = "Bottom"
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub btnpanelclock_Click(sender As Object, e As EventArgs) Handles btnpanelclock.Click
        If ShiftOSDesktop.boughtshiftpanelclock Then
            pnlpanelclockoptions.Show()
            pnlpanelclockoptions.Size = New Size(317, 134)
            pnlpanelclockoptions.Location = New Point(136, 159)
            pnlpanelclockoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub comboclocktextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboclocktextfont.SelectedIndexChanged
        If comboclocktextfont.Text = "" Then
        Else
            panelclocktextfont = comboclocktextfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub comboclocktextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboclocktextstyle.SelectedIndexChanged
        Select Case comboclocktextstyle.Text
            Case "Bold"
                panelclocktextstyle = FontStyle.Bold
            Case "Italic"
                panelclocktextstyle = FontStyle.Italic
            Case "Regular"
                panelclocktextstyle = FontStyle.Regular
            Case "Strikeout"
                panelclocktextstyle = FontStyle.Strikeout
            Case "Underline"
                panelclocktextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub txtclocktextfromtop_TextChanged(sender As Object, e As EventArgs) Handles txtclocktextfromtop.TextChanged
        If txtclocktextfromtop.Text = "" Then
        Else
            panelclocktexttop = txtclocktextfromtop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclocktextsize_TextChanged(sender As Object, e As EventArgs) Handles txtclocktextsize.TextChanged
        If txtclocktextsize.Text = "" OrElse txtclocktextsize.Text = "0" Then
        Else
            panelclocktextsize = txtclocktextsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txttitlebarnornerwidth_TextChanged(sender As Object, e As EventArgs) Handles txttitlebarcornerwidth.TextChanged
        If txttitlebarcornerwidth.Text = "" OrElse txttitlebarcornerwidth.Text = "0" Then
        Else
            titlebarcornerwidth = txttitlebarcornerwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub btnapplauncher_Click(sender As Object, e As EventArgs) Handles btnapplauncher.Click
        If ShiftOSDesktop.boughtshiftapplauncher Then
            pnlapplauncheroptions.Show()
            pnlapplauncheroptions.Size = New Size(317, 134)
            pnlapplauncheroptions.Location = New Point(136, 159)
            pnlapplauncheroptions.BringToFront()
            pnllauncheritems.Hide()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub predesktopappmenu_MouseEnter(sender As Object, e As EventArgs) Handles predesktopappmenu.MouseEnter
        Me.Focus()
    End Sub

    Private Sub Shifter_MouseEnter(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.MouseEnter
        ToolStripManager.Renderer = New MyPreviewToolStripRenderer()
        'ShiftOSDesktop.ApplicationsToolStripMenuItem.BackColor = ShiftOSDesktop.applauncherbuttoncolour
    End Sub

    Private Sub txtapplicationsbuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtapplicationsbuttonheight.TextChanged
        If txtapplicationsbuttonheight.Text = "" Then
        Else
            If txtapplicationsbuttonheight.Text > desktoppanelheight Then
                infobox.title = "Shifter - Illegal Setting!"
                infobox.textinfo = "The height of the application menu button can not exceed the height of the desktop panel." & Environment.NewLine & Environment.NewLine & "The application menu button height has been automatically reduced."
                infobox.Show()
                txtapplicationsbuttonheight.Text = applicationbuttonheight
            Else
                applicationbuttonheight = txtapplicationsbuttonheight.Text
                setuppreshifterstuff()
            End If
        End If
    End Sub

    Private Sub txtappbuttontextsize_TextChanged(sender As Object, e As EventArgs) Handles txtappbuttontextsize.TextChanged
        If txtappbuttontextsize.Text = "" OrElse txtappbuttontextsize.Text = "0" Then
        Else
            applicationbuttontextsize = txtappbuttontextsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub comboappbuttontextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboappbuttontextstyle.SelectedIndexChanged
        Select Case comboappbuttontextstyle.Text
            Case "Bold"
                applicationbuttontextstyle = FontStyle.Bold
            Case "Italic"
                applicationbuttontextstyle = FontStyle.Italic
            Case "Regular"
                applicationbuttontextstyle = FontStyle.Regular
            Case "Strikeout"
                applicationbuttontextstyle = FontStyle.Strikeout
            Case "Underline"
                applicationbuttontextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub cbpanelbuttontextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpanelbuttontextstyle.SelectedIndexChanged
        Select Case cbpanelbuttontextstyle.Text
            Case "Bold"
                panelbuttontextstyle = FontStyle.Bold
            Case "Italic"
                panelbuttontextstyle = FontStyle.Italic
            Case "Regular"
                panelbuttontextstyle = FontStyle.Regular
            Case "Strikeout"
                panelbuttontextstyle = FontStyle.Strikeout
            Case "Underline"
                panelbuttontextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub comboappbuttontextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboappbuttontextfont.SelectedIndexChanged
        If comboappbuttontextfont.Text = "" Then
        Else
            applicationbuttontextfont = comboappbuttontextfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtappbuttonlabel_TextChanged(sender As Object, e As EventArgs) Handles txtappbuttonlabel.TextChanged
        If txtappbuttonlabel.Text = "" Then
        Else
            applicationlaunchername = txtappbuttonlabel.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub combotitletextposition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotitletextposition.SelectedIndexChanged
        Select Case combotitletextposition.Text
            Case "Left"
                titletextposition = "Left"
            Case "Centre"
                titletextposition = "Centre"
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub pnlrollupbuttoncolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlrollupbuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlrollupbuttoncolour.ClientRectangle)
    End Sub

    Private Sub combobuttonoption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combobuttonoption.SelectedIndexChanged
        Select Case combobuttonoption.Text
            Case "Close Button"
                pnlclosebuttonoptions.Show()
                pnlclosebuttonoptions.BringToFront()
                pnlclosebuttonoptions.Location = New Point(1, 27)
                pnlclosebuttonoptions.Size = New Size(315, 104)
            Case "Roll Up Button"
                pnlrollupbuttonoptions.Show()
                pnlrollupbuttonoptions.BringToFront()
                pnlrollupbuttonoptions.Location = New Point(1, 27)
                pnlrollupbuttonoptions.Size = New Size(315, 104)
            Case "Minimize Button"
                pnlminimizebuttonoptions.Show()
                pnlminimizebuttonoptions.BringToFront()
                pnlminimizebuttonoptions.Location = New Point(1, 27)
                pnlminimizebuttonoptions.Size = New Size(315, 104)
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub txtrollupbuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttonheight.TextChanged
        If txtrollupbuttonheight.Text = "" Then
        Else
            rollupbuttonheight = txtrollupbuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtrollupbuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttonwidth.TextChanged
        If txtrollupbuttonwidth.Text = "" Then
        Else
            rollupbuttonwidth = txtrollupbuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtrollupbuttontop_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttontop.TextChanged
        If txtrollupbuttontop.Text = "" Then
        Else
            rollupbuttontop = txtrollupbuttontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtrollupbuttonside_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttonside.TextChanged
        If txtrollupbuttonside.Text = "" Then
        Else
            rollupbuttonside = txtrollupbuttonside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtapplauncherwidth_TextChanged(sender As Object, e As EventArgs) Handles txtapplauncherwidth.TextChanged
        If txtapplauncherwidth.Text = "" Then
        Else
            applaunchermenuholderwidth = txtapplauncherwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txticonfromside_TextChanged(sender As Object, e As EventArgs) Handles txticonfromside.TextChanged
        If txticonfromside.Text = "" Then
        Else
            titlebariconside = txticonfromside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txticonfromtop_TextChanged(sender As Object, e As EventArgs) Handles txticonfromtop.TextChanged
        If txticonfromtop.Text = "" Then
        Else
            titlebaricontop = txticonfromtop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttonheight.TextChanged
        If txtminimizebuttonheight.Text = "" Then
        Else
            minimizebuttonheight = txtminimizebuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttonwidth.TextChanged
        If txtminimizebuttonwidth.Text = "" Then
        Else
            minimizebuttonwidth = txtminimizebuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttontop_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttontop.TextChanged
        If txtminimizebuttontop.Text = "" Then
        Else
            minimizebuttontop = txtminimizebuttontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttonside_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttonside.TextChanged
        If txtminimizebuttonside.Text = "" Then
        Else
            minimizebuttonside = txtminimizebuttonside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttoninitalgap_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttoninitalgap.TextChanged
        If txtpanelbuttoninitalgap.Text = "" Then
        Else
            panelbuttoninitialgap = txtpanelbuttoninitalgap.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttontop_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttontop.TextChanged
        If txtpanelbuttontop.Text = "" Then
        Else
            panelbuttonfromtop = txtpanelbuttontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttonwidth.TextChanged
        If txtpanelbuttonwidth.Text = "" Then
        Else
            panelbuttonwidth = txtpanelbuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttonheight.TextChanged
        If txtpanelbuttonheight.Text = "" Then
        Else
            panelbuttonheight = txtpanelbuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttongap_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttongap.TextChanged
        If txtpanelbuttongap.Text = "" Then
        Else
            panelbuttongap = txtpanelbuttongap.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpaneltextbuttonsize_TextChanged(sender As Object, e As EventArgs) Handles txtpaneltextbuttonsize.TextChanged
        If txtpaneltextbuttonsize.Text = "" Then
        Else
            panelbuttontextsize = txtpaneltextbuttonsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttontextside_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttontextside.TextChanged
        If txtpanelbuttontextside.Text = "" Then
        Else
            panelbuttontextside = txtpanelbuttontextside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttontexttop_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttontexttop.TextChanged
        If txtpanelbuttontexttop.Text = "" Then
        Else
            panelbuttontexttop = txtpanelbuttontexttop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttoniconsize_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttoniconsize.TextChanged
        If txtpanelbuttoniconsize.Text = "" Then
        Else
            panelbuttoniconsize = txtpanelbuttoniconsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttoniconside_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttoniconside.TextChanged
        If txtpanelbuttoniconside.Text = "" Then
        Else
            panelbuttoniconside = txtpanelbuttoniconside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttonicontop_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttonicontop.TextChanged
        If txtpanelbuttonicontop.Text = "" Then
        Else
            panelbuttonicontop = txtpanelbuttonicontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub customizationtime_Tick(sender As Object, e As EventArgs) Handles customizationtime.Tick
        If customizationsdone > -10 Then
            customizationtimepoints = customizationtimepoints + 1
            customizationsdone = customizationsdone - 1
        End If
    End Sub

    Private Sub timerearned_Tick(sender As Object, e As EventArgs) Handles timerearned.Tick
        btnapply.Text = "Apply Changes"
        btnapply.BackColor = Color.White
        btnapply.ForeColor = Color.Black
        timerearned.Stop()
    End Sub

    Private Sub cboxtitlebarcorners_CheckedChanged(sender As Object, e As EventArgs) Handles cboxtitlebarcorners.CheckedChanged
        If cboxtitlebarcorners.CheckState = CheckState.Checked Then
            prepgtoplcorner.Show()
            prepgtoprcorner.Show()
            pnltitlebarleftcornercolour.Show()
            pnltitlebarrightcornercolour.Show()
            txttitlebarcornerwidth.Show()
            lbcornerwidth.Show()
            lbcornerwidthpx.Show()
            lbleftcornercolor.Show()
            lbrightcornercolor.Show()
            showwindowcorners = True
        Else
            prepgtoplcorner.Hide()
            prepgtoprcorner.Hide()
            pnltitlebarleftcornercolour.Hide()
            pnltitlebarrightcornercolour.Hide()
            txttitlebarcornerwidth.Hide()
            lbcornerwidth.Hide()
            lbcornerwidthpx.Hide()
            lbleftcornercolor.Hide()
            lbrightcornercolor.Hide()
            showwindowcorners = False
        End If
    End Sub

    Private Sub cbindividualbordercolours_CheckedChanged(sender As Object, e As EventArgs) Handles cbindividualbordercolours.CheckedChanged
        If cbindividualbordercolours.CheckState = CheckState.Checked Then
            Label73.Show()
            Label74.Show()
            Label75.Show()
            Label76.Show()
            Label77.Show()
            pnlborderleftcolour.Show()
            pnlborderrightcolour.Show()
            pnlborderbottomcolour.Show()
            pnlborderbottomrightcolour.Show()
            pnlborderbottomleftcolour.Show()
        Else
            Label73.Hide()
            Label74.Hide()
            Label75.Hide()
            Label76.Hide()
            Label77.Hide()
            pnlborderleftcolour.Hide()
            pnlborderrightcolour.Hide()
            pnlborderbottomcolour.Hide()
            pnlborderbottomrightcolour.Hide()
            pnlborderbottomleftcolour.Hide()
        End If
    End Sub

    Private Sub btnresetallsettings_Click(sender As Object, e As EventArgs) Handles btnresetallsettings.Click
        Skins.setupdefaults()

        Skins.saveskinfiles(False)

        setupbuttons()
        initialsetup()
        determinevisibleobjects()
        setuppreshifterstuff()
        AddFonts()
        justopened = True
        ShiftOSDesktop.setupdesktop()

        'postsettings()
        'If ShiftOSDesktop.boughtknowledgeinputicon = True Then titletextside = titletextside + 22
        'setuppreshifterstuff()
        'applysettings()
    End Sub

    'required to fix flashing applauncher button problem
    Public Sub ApplicationsToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles ApplicationsToolStripMenuItem.Paint
        If ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then
        Else
            e.Graphics.DrawImage(ApplicationsToolStripMenuItem.BackgroundImage, 0, 0, ApplicationsToolStripMenuItem.BackgroundImage.Width, ApplicationsToolStripMenuItem.BackgroundImage.Height)
        End If
    End Sub

    Private Sub tmrfix_Tick(sender As Object, e As EventArgs) Handles tmrfix.Tick



        tmrfix.Stop()
    End Sub

    Private Sub tmrdelay_Tick(sender As Object, e As EventArgs) Handles tmrdelay.Tick
        timingissuefixer = +1
    End Sub

    Private Sub btnshowlauncheritems_Click(sender As Object, e As EventArgs) Handles btnshowlauncheritems.Click
        If ShiftOSDesktop.boughtshiftapplauncheritems Then
            pnllauncheritems.Dock = DockStyle.Fill
            pnllauncheritems.Show()
            pnllauncheritems.BringToFront()


        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Dim oldlaunchervalue As Integer = 10
    Private Sub txtlauncheritemtxtsize_TextChanged(sender As Object, e As EventArgs) Handles txtlauncheritemtxtsize.TextChanged
        If txtlauncheritemtxtsize.Text = "" Then txtlauncheritemtxtsize.Text = 1
        If Not IsNumeric(txtlauncheritemtxtsize.Text) Then txtlauncheritemtxtsize.Text = oldlaunchervalue
        If txtlauncheritemtxtsize.Text < 1 Then txtlauncheritemtxtsize.Text = 1
        If txtlauncheritemtxtsize.Text > 100 Then txtlauncheritemtxtsize.Text = 100
        oldlaunchervalue = txtlauncheritemtxtsize.Text
        setuppreshifterstuff()
    End Sub

    Private Sub launchercolourclick() Handles launcheritemtxtcolour.Click
        Colour_Picker.Show()
        Colour_Picker.colourtochange = "launcher items text colour"
    End Sub

    Private Sub launcheritemfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles launcheritemfont.SelectedIndexChanged
        setuppreshifterstuff()
    End Sub

    Private Sub launcheritemstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles launcheritemstyle.SelectedIndexChanged
        setuppreshifterstuff()
    End Sub

    Private Sub btndeskdoubleplus_Click(sender As Object, e As EventArgs) Handles btndeskdoubleplus.Click
        pnldeskdoubleplus.BringToFront()
    End Sub



    Public Sub refreshIcons()
        desktopiconspreview.Items.Clear()
        If Skins.showicons = True Then
            desktopiconspreview.LargeImageList = File_Skimmer.ImageList1
            desktopiconspreview.SmallImageList = File_Skimmer.ImageList1

            Dim dir As New IO.DirectoryInfo("C:\ShiftOS\Home\Desktop")
            Dim files As IO.FileInfo() = dir.GetFiles()
            Dim file As IO.FileInfo
            Dim folders As IO.DirectoryInfo() = dir.GetDirectories()
            Dim folder As IO.DirectoryInfo
            Dim filetype As Integer
            For Each folder In folders
                Dim Str(3) As String

                Str(0) = folder.Name
                Str(1) = folder.LastAccessTime
                Str(2) = "Directory"

                Dim folderIcon As New ListViewItem
                folderIcon.Text = Str(0)
                folderIcon.Tag = folder.FullName
                folderIcon.SubItems.Add(Str(1))
                folderIcon.SubItems.Add(Str(2))
                folderIcon.ImageIndex = 0

                desktopiconspreview.Items.Add(folderIcon)
            Next

            For Each file In files
                Dim filename As String = file.Name
                Dim fileex As String = file.Extension
                Dim program As String
                Dim item As New ListViewItem

                item.Text = filename
                item.Tag = file.FullName
                item.SubItems.Add(file.LastWriteTime)

                filetype = File_Skimmer.getExType(fileex)(0)
                program = File_Skimmer.getExType(fileex)(1)

                item.SubItems.Add(program)
                item.ImageIndex = filetype
                desktopiconspreview.Items.Add(item)
            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub btndppfunctions_Click(sender As Object, e As EventArgs) Handles btndppfunctions.Click
        pnldppfunctions.BringToFront()
    End Sub

    Private Sub btndppicons_Click(sender As Object, e As EventArgs) Handles btndppicons.Click
        pnldppicons.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Colour_Picker.colourtochange = "Desktop Icon Text Color"
        Colour_Picker.oldcolour = icontextcolor
        Colour_Picker.Show()
        Button1.BackColor = icontextcolor
        desktopiconspreview.ForeColor = icontextcolor
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnlshiftadvapplauncher.BringToFront()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnaalusrtextcolor.Click
        Colour_Picker.colourtochange = "Username Text Color"
        Colour_Picker.oldcolour = usernametextcolor
        Colour_Picker.Show()
        btnaalusrtextcolor.BackColor = usernametextcolor
    End Sub

    Private Sub cmbaalusrfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbaalusrfont.SelectedIndexChanged
        usernamefont = cmbaalusrfont.SelectedItem
    End Sub

    Private Sub nudusrsize_ValueChanged(sender As Object, e As EventArgs) Handles nudusrsize.ValueChanged
        If Not nudusrsize.Value = 0 Then
            usernamefontsize = nudusrsize.Value
        Else
            nudusrsize.Value = 1
        End If

    End Sub

    Private Sub cmbaalusrstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbaalusrstyle.SelectedIndexChanged
        Select Case cmbaalusrstyle.SelectedItem
            Case "Regular"
                usernamefontstyle = FontStyle.Regular
            Case "Bold"
                usernamefontstyle = FontStyle.Bold
            Case "Italic"
                usernamefontstyle = FontStyle.Italic
            Case "Underline"
                usernamefontstyle = FontStyle.Underline
            Case Else
                usernamefontstyle = FontStyle.Regular
        End Select
    End Sub

    
    Private Sub btnaalusrpnlbg_Click(sender As Object, e As MouseEventArgs) Handles btnaalusrpnlbg.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Graphic_Picker.graphictochange = "Username Panel Background"
            Graphic_Picker.ShowDialog()
            Try
                btnaalusrpnlbg.BackgroundImage = skinuserpanel(0)
            Catch
                btnaalusrpnlbg.BackgroundImage = Nothing
            End Try
            btnaalusrpnlbg.BackgroundImageLayout = usrbglayout
        Else
            Colour_Picker.colourtochange = "Username Panel Background"
            Colour_Picker.oldcolour = usernamebgcolor
            Colour_Picker.ShowDialog()
            btnaalusrpnlbg.BackColor = usernamebgcolor
        End If
    End Sub

    Private Sub btnaalpwrpnlbg_Click(sender As Object, e As MouseEventArgs) Handles btnaalpwrpnlbg.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Graphic_Picker.graphictochange = "Shutdown Button Background"
            Graphic_Picker.ShowDialog()
            Try
                btnaalpwrpnlbg.BackgroundImage = skinshutdownbutton(0)
            Catch
                btnaalpwrpnlbg.BackgroundImage = Nothing
            End Try
            btnaalpwrpnlbg.BackgroundImageLayout = usrbglayout
        Else
            Colour_Picker.colourtochange = "Shutdown Button Background"
            Colour_Picker.oldcolour = powerpanelbgcolor
            Colour_Picker.ShowDialog()
            btnaalpwrpnlbg.BackColor = usernamebgcolor
        End If
    End Sub
End Class