Public Class Skin_Loader
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Public skinloaded As Boolean = False

    Public savelines(200) As String
    Public loadlines(200) As String

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
    Public applaunchermenuholderwidth As Integer
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

    'skins
    Public skinloaderskinimages(100) As String
    Public skinloaderskinclosebutton(2) As Image
    Public skinclosebuttonstyle As ImageLayout
    Public skinloaderskintitlebar(2) As Image
    Public skintitlebarstyle As ImageLayout
    Public skinloaderskindesktopbackground(2) As Image
    Public skindesktopbackgroundstyle As ImageLayout
    Public skinloaderskinrollupbutton(2) As Image
    Public skinrollupbuttonstyle As ImageLayout
    Public skinloaderskintitlebarrightcorner(2) As Image
    Public skintitlebarrightcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskintitlebarleftcorner(2) As Image
    Public skintitlebarleftcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskindesktoppanel(2) As Image
    Public skindesktoppanelstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskindesktoppaneltime(2) As Image
    Public skindesktoppaneltimestyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinapplauncherbutton(2) As Image
    Public skinapplauncherbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinwindowborderleft(2) As Image
    Public skinwindowborderleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinwindowborderright(2) As Image
    Public skinwindowborderrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinwindowborderbottom(2) As Image
    Public skinwindowborderbottomstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinwindowborderbottomright(2) As Image
    Public skinwindowborderbottomrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinwindowborderbottomleft(2) As Image
    Public skinwindowborderbottomleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinpanelbutton(2) As Image
    Public skinpanelbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinloaderskinminimizebutton(2) As Image
    Public skinminimizebuttonstyle As ImageLayout = ImageLayout.Stretch

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        determinevisibleobjects()
        setskin()

        ShiftOSDesktop.pnlpanelbuttonskinloader.SendToBack()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonskinloader, ShiftOSDesktop.tbskinloadericon, ShiftOSDesktop.tbskinloadertext, True)
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        initialsetup()
        setpreviewtocurrentskin()
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
            Me.Size = New Size(476, 462) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.skinloadername
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
            pnlicon.Image = ShiftOSDesktop.skinloadericontitlebar 'Replace with the correct icon for the program.
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

    Private Sub initialsetup()
        titlebarcolour = ShiftOSDesktop.titlebarcolour
        windowbordercolour = ShiftOSDesktop.windowbordercolour
        windowbordersize = ShiftOSDesktop.windowbordersize
        titlebarheight = ShiftOSDesktop.titlebarheight
        closebuttoncolour = ShiftOSDesktop.closebuttoncolour
        closebuttonheight = ShiftOSDesktop.closebuttonheight
        closebuttonwidth = ShiftOSDesktop.closebuttonwidth
        closebuttontop = ShiftOSDesktop.closebuttontop
        closebuttonside = ShiftOSDesktop.closebuttonside
        titletextcolour = ShiftOSDesktop.titletextcolour
        titletexttop = ShiftOSDesktop.titletexttop
        titletextside = ShiftOSDesktop.titletextside
        titletextsize = ShiftOSDesktop.titletextsize
        titletextfont = ShiftOSDesktop.titletextfont
        titletextstyle = ShiftOSDesktop.titletextstyle
        desktoppanelcolour = ShiftOSDesktop.desktoppanelcolour
        desktopbackgroundcolour = ShiftOSDesktop.desktopbackgroundcolour
        desktoppanelheight = ShiftOSDesktop.desktoppanelheight
        desktoppanelposition = ShiftOSDesktop.desktoppanelposition
        clocktextcolour = ShiftOSDesktop.clocktextcolour
        clockbackgroundcolor = ShiftOSDesktop.clockbackgroundcolor
        panelclocktexttop = ShiftOSDesktop.panelclocktexttop
        panelclocktextsize = ShiftOSDesktop.panelclocktextsize
        panelclocktextfont = ShiftOSDesktop.panelclocktextfont
        panelclocktextstyle = ShiftOSDesktop.panelclocktextstyle
        applauncherbuttoncolour = ShiftOSDesktop.applauncherbuttoncolour
        applauncherbuttonclickedcolour = ShiftOSDesktop.applauncherbuttonclickedcolour
        applauncherbackgroundcolour = ShiftOSDesktop.applauncherbackgroundcolour
        applaunchermouseovercolour = ShiftOSDesktop.applaunchermouseovercolour
        applicationsbuttontextcolour = ShiftOSDesktop.applicationsbuttontextcolour
        applicationbuttonheight = ShiftOSDesktop.applicationbuttonheight
        applicationbuttontextsize = ShiftOSDesktop.applicationbuttontextsize
        applicationbuttontextfont = ShiftOSDesktop.applicationbuttontextfont
        applicationbuttontextstyle = ShiftOSDesktop.applicationbuttontextstyle
        applicationlaunchername = ShiftOSDesktop.applicationlaunchername
        titletextposition = ShiftOSDesktop.titletextposition
        rollupbuttoncolour = ShiftOSDesktop.rollupbuttoncolour
        rollupbuttonheight = ShiftOSDesktop.rollupbuttonheight
        rollupbuttonwidth = ShiftOSDesktop.rollupbuttonwidth
        rollupbuttonside = ShiftOSDesktop.rollupbuttonside
        rollupbuttontop = ShiftOSDesktop.rollupbuttontop
        titlebariconside = ShiftOSDesktop.titlebariconside
        titlebaricontop = ShiftOSDesktop.titlebaricontop
        titlebarcornerwidth = ShiftOSDesktop.titlebarcornerwidth
        titlebarrightcornercolour = ShiftOSDesktop.titlebarrightcornercolour
        titlebarleftcornercolour = ShiftOSDesktop.titlebarleftcornercolour
        showwindowcorners = ShiftOSDesktop.showwindowcorners
        applaunchermenuholderwidth = ShiftOSDesktop.applaunchermenuholderwidth
        windowborderleftcolour = ShiftOSDesktop.windowborderleftcolour
        windowborderrightcolour = ShiftOSDesktop.windowborderrightcolour
        windowborderbottomcolour = ShiftOSDesktop.windowborderbottomcolour
        windowborderbottomrightcolour = ShiftOSDesktop.windowborderbottomrightcolour
        windowborderbottomleftcolour = ShiftOSDesktop.windowborderbottomleftcolour
        panelbuttonicontop = ShiftOSDesktop.panelbuttonicontop
        panelbuttoniconside = ShiftOSDesktop.panelbuttoniconside
        panelbuttoniconsize = ShiftOSDesktop.panelbuttoniconsize
        panelbuttoniconsize = ShiftOSDesktop.panelbuttoniconsize
        panelbuttonheight = ShiftOSDesktop.panelbuttonheight
        panelbuttonwidth = ShiftOSDesktop.panelbuttonwidth
        panelbuttoncolour = ShiftOSDesktop.panelbuttoncolour
        panelbuttontextcolour = ShiftOSDesktop.panelbuttontextcolour
        panelbuttontextsize = ShiftOSDesktop.panelbuttontextsize
        panelbuttontextfont = ShiftOSDesktop.panelbuttontextfont
        panelbuttontextstyle = ShiftOSDesktop.panelbuttontextstyle
        panelbuttontextside = ShiftOSDesktop.panelbuttontextside
        panelbuttontexttop = ShiftOSDesktop.panelbuttontexttop
        panelbuttongap = ShiftOSDesktop.panelbuttongap
        panelbuttonfromtop = ShiftOSDesktop.panelbuttonfromtop
        panelbuttoninitialgap = ShiftOSDesktop.panelbuttoninitialgap
        minimizebuttoncolour = ShiftOSDesktop.minimizebuttoncolour
        minimizebuttonheight = ShiftOSDesktop.minimizebuttonheight
        minimizebuttonwidth = ShiftOSDesktop.minimizebuttonwidth
        minimizebuttonside = ShiftOSDesktop.minimizebuttonside
        minimizebuttontop = ShiftOSDesktop.minimizebuttontop

        'skins
        Array.Copy(ShiftOSDesktop.skinimages, skinloaderskinimages, skinloaderskinimages.Length)

        If ShiftOSDesktop.skinclosebutton(0) Is Nothing Then  Else skinloaderskinclosebutton(0) = ShiftOSDesktop.skinclosebutton(0).Clone
        If ShiftOSDesktop.skinclosebutton(1) Is Nothing Then  Else skinloaderskinclosebutton(1) = ShiftOSDesktop.skinclosebutton(1).Clone
        If ShiftOSDesktop.skinclosebutton(2) Is Nothing Then  Else skinloaderskinclosebutton(2) = ShiftOSDesktop.skinclosebutton(2).Clone
        skinclosebuttonstyle = ShiftOSDesktop.skinclosebuttonstyle

        If ShiftOSDesktop.skintitlebar(0) Is Nothing Then  Else skinloaderskintitlebar(0) = ShiftOSDesktop.skintitlebar(0).Clone
        If ShiftOSDesktop.skintitlebar(1) Is Nothing Then  Else skinloaderskintitlebar(1) = ShiftOSDesktop.skintitlebar(1).Clone
        If ShiftOSDesktop.skintitlebar(2) Is Nothing Then  Else skinloaderskintitlebar(2) = ShiftOSDesktop.skintitlebar(2).Clone
        skintitlebarstyle = ShiftOSDesktop.skintitlebarstyle

        If ShiftOSDesktop.skindesktopbackground(0) Is Nothing Then  Else skinloaderskindesktopbackground(0) = ShiftOSDesktop.skindesktopbackground(0).Clone
        If ShiftOSDesktop.skindesktopbackground(1) Is Nothing Then  Else skinloaderskindesktopbackground(1) = ShiftOSDesktop.skindesktopbackground(1).Clone
        If ShiftOSDesktop.skindesktopbackground(2) Is Nothing Then  Else skinloaderskindesktopbackground(2) = ShiftOSDesktop.skindesktopbackground(2).Clone
        skindesktopbackgroundstyle = ShiftOSDesktop.skindesktopbackgroundstyle

        If ShiftOSDesktop.skinrollupbutton(0) Is Nothing Then  Else skinloaderskinrollupbutton(0) = ShiftOSDesktop.skinrollupbutton(0).Clone
        If ShiftOSDesktop.skinrollupbutton(1) Is Nothing Then  Else skinloaderskinrollupbutton(1) = ShiftOSDesktop.skinrollupbutton(1).Clone
        If ShiftOSDesktop.skinrollupbutton(2) Is Nothing Then  Else skinloaderskinrollupbutton(2) = ShiftOSDesktop.skinrollupbutton(2).Clone
        skinrollupbuttonstyle = ShiftOSDesktop.skinrollupbuttonstyle

        If ShiftOSDesktop.skintitlebarrightcorner(0) Is Nothing Then  Else skinloaderskintitlebarrightcorner(0) = ShiftOSDesktop.skintitlebarrightcorner(0).Clone
        If ShiftOSDesktop.skintitlebarrightcorner(1) Is Nothing Then  Else skinloaderskintitlebarrightcorner(1) = ShiftOSDesktop.skintitlebarrightcorner(1).Clone
        If ShiftOSDesktop.skintitlebarrightcorner(2) Is Nothing Then  Else skinloaderskintitlebarrightcorner(2) = ShiftOSDesktop.skintitlebarrightcorner(2).Clone
        skintitlebarrightcornerstyle = ShiftOSDesktop.skintitlebarrightcornerstyle

        If ShiftOSDesktop.skintitlebarleftcorner(0) Is Nothing Then  Else skinloaderskintitlebarleftcorner(0) = ShiftOSDesktop.skintitlebarleftcorner(0).Clone
        If ShiftOSDesktop.skintitlebarleftcorner(1) Is Nothing Then  Else skinloaderskintitlebarleftcorner(1) = ShiftOSDesktop.skintitlebarleftcorner(1).Clone
        If ShiftOSDesktop.skintitlebarleftcorner(2) Is Nothing Then  Else skinloaderskintitlebarleftcorner(2) = ShiftOSDesktop.skintitlebarleftcorner(2).Clone
        skintitlebarleftcornerstyle = ShiftOSDesktop.skintitlebarleftcornerstyle

        If ShiftOSDesktop.skindesktoppanel(0) Is Nothing Then  Else skinloaderskindesktoppanel(0) = ShiftOSDesktop.skindesktoppanel(0).Clone
        If ShiftOSDesktop.skindesktoppanel(1) Is Nothing Then  Else skinloaderskindesktoppanel(1) = ShiftOSDesktop.skindesktoppanel(1).Clone
        If ShiftOSDesktop.skindesktoppanel(2) Is Nothing Then  Else skinloaderskindesktoppanel(2) = ShiftOSDesktop.skindesktoppanel(2).Clone
        skindesktoppanelstyle = ShiftOSDesktop.skindesktoppanelstyle

        If ShiftOSDesktop.skindesktoppaneltime(0) Is Nothing Then  Else skinloaderskindesktoppaneltime(0) = ShiftOSDesktop.skindesktoppaneltime(0).Clone
        If ShiftOSDesktop.skindesktoppaneltime(1) Is Nothing Then  Else skinloaderskindesktoppaneltime(1) = ShiftOSDesktop.skindesktoppaneltime(1).Clone
        If ShiftOSDesktop.skindesktoppaneltime(2) Is Nothing Then  Else skinloaderskindesktoppaneltime(2) = ShiftOSDesktop.skindesktoppaneltime(2).Clone
        skindesktoppaneltimestyle = ShiftOSDesktop.skindesktoppaneltimestyle

        If ShiftOSDesktop.skinapplauncherbutton(0) Is Nothing Then  Else skinloaderskinapplauncherbutton(0) = ShiftOSDesktop.skinapplauncherbutton(0).Clone
        If ShiftOSDesktop.skinapplauncherbutton(1) Is Nothing Then  Else skinloaderskinapplauncherbutton(1) = ShiftOSDesktop.skinapplauncherbutton(1).Clone
        If ShiftOSDesktop.skinapplauncherbutton(2) Is Nothing Then  Else skinloaderskinapplauncherbutton(2) = ShiftOSDesktop.skinapplauncherbutton(2).Clone
        skinapplauncherbuttonstyle = ShiftOSDesktop.skinapplauncherbuttonstyle

        If ShiftOSDesktop.skinwindowborderleft(0) Is Nothing Then  Else skinloaderskinwindowborderleft(0) = ShiftOSDesktop.skinwindowborderleft(0).Clone
        If ShiftOSDesktop.skinwindowborderleft(1) Is Nothing Then  Else skinloaderskinwindowborderleft(1) = ShiftOSDesktop.skinwindowborderleft(1).Clone
        If ShiftOSDesktop.skinwindowborderleft(2) Is Nothing Then  Else skinloaderskinwindowborderleft(2) = ShiftOSDesktop.skinwindowborderleft(2).Clone
        skinwindowborderleftstyle = ShiftOSDesktop.skinwindowborderleftstyle

        If ShiftOSDesktop.skinwindowborderright(0) Is Nothing Then  Else skinloaderskinwindowborderright(0) = ShiftOSDesktop.skinwindowborderright(0).Clone
        If ShiftOSDesktop.skinwindowborderright(1) Is Nothing Then  Else skinloaderskinwindowborderright(1) = ShiftOSDesktop.skinwindowborderright(1).Clone
        If ShiftOSDesktop.skinwindowborderright(2) Is Nothing Then  Else skinloaderskinwindowborderright(2) = ShiftOSDesktop.skinwindowborderright(2).Clone
        skinwindowborderrightstyle = ShiftOSDesktop.skinwindowborderrightstyle

        If ShiftOSDesktop.skinwindowborderbottom(0) Is Nothing Then  Else skinloaderskinwindowborderbottom(0) = ShiftOSDesktop.skinwindowborderbottom(0).Clone
        If ShiftOSDesktop.skinwindowborderbottom(1) Is Nothing Then  Else skinloaderskinwindowborderbottom(1) = ShiftOSDesktop.skinwindowborderbottom(1).Clone
        If ShiftOSDesktop.skinwindowborderbottom(2) Is Nothing Then  Else skinloaderskinwindowborderbottom(2) = ShiftOSDesktop.skinwindowborderbottom(2).Clone
        skinwindowborderbottomstyle = ShiftOSDesktop.skinwindowborderbottomstyle

        If ShiftOSDesktop.skinwindowborderbottomright(0) Is Nothing Then  Else skinloaderskinwindowborderbottomright(0) = ShiftOSDesktop.skinwindowborderbottomright(0).Clone
        If ShiftOSDesktop.skinwindowborderbottomright(1) Is Nothing Then  Else skinloaderskinwindowborderbottomright(1) = ShiftOSDesktop.skinwindowborderbottomright(1).Clone
        If ShiftOSDesktop.skinwindowborderbottomright(2) Is Nothing Then  Else skinloaderskinwindowborderbottomright(2) = ShiftOSDesktop.skinwindowborderbottomright(2).Clone
        skinwindowborderbottomrightstyle = ShiftOSDesktop.skinwindowborderbottomrightstyle

        If ShiftOSDesktop.skinwindowborderbottomleft(0) Is Nothing Then  Else skinloaderskinwindowborderbottomleft(0) = ShiftOSDesktop.skinwindowborderbottomleft(0).Clone
        If ShiftOSDesktop.skinwindowborderbottomleft(1) Is Nothing Then  Else skinloaderskinwindowborderbottomleft(1) = ShiftOSDesktop.skinwindowborderbottomleft(1).Clone
        If ShiftOSDesktop.skinwindowborderbottomleft(2) Is Nothing Then  Else skinloaderskinwindowborderbottomleft(2) = ShiftOSDesktop.skinwindowborderbottomleft(2).Clone
        skinwindowborderbottomleftstyle = ShiftOSDesktop.skinwindowborderbottomleftstyle

        If ShiftOSDesktop.skinpanelbutton(0) Is Nothing Then  Else skinloaderskinpanelbutton(0) = ShiftOSDesktop.skinpanelbutton(0).Clone
        If ShiftOSDesktop.skinpanelbutton(1) Is Nothing Then  Else skinloaderskinpanelbutton(1) = ShiftOSDesktop.skinpanelbutton(1).Clone
        If ShiftOSDesktop.skinpanelbutton(2) Is Nothing Then  Else skinloaderskinpanelbutton(2) = ShiftOSDesktop.skinpanelbutton(2).Clone
        skinpanelbuttonstyle = ShiftOSDesktop.skinpanelbuttonstyle

        If ShiftOSDesktop.skinminimizebutton(0) Is Nothing Then  Else skinloaderskinminimizebutton(0) = ShiftOSDesktop.skinminimizebutton(0).Clone
        If ShiftOSDesktop.skinminimizebutton(1) Is Nothing Then  Else skinloaderskinminimizebutton(1) = ShiftOSDesktop.skinminimizebutton(1).Clone
        If ShiftOSDesktop.skinminimizebutton(2) Is Nothing Then  Else skinloaderskinminimizebutton(2) = ShiftOSDesktop.skinminimizebutton(2).Clone
        skinminimizebuttonstyle = ShiftOSDesktop.skinminimizebuttonstyle
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

    Public Sub setpreviewtocurrentskin()
        ShiftOSDesktop.loadskinfiles()

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
        ApplicationsToolStripMenuItem.BackColor = applauncherbuttoncolour
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
        If skinloaderskinpanelbutton(0) Is Nothing Then  Else prepnlpanelbutton.BackgroundImage = skinloaderskinpanelbutton(0)
        prepnlpanelbutton.BackgroundImageLayout = skinpanelbuttonstyle
        pretbctext.ForeColor = panelbuttontextcolour
        pretbctext.Font = New Font(panelbuttontextfont, panelbuttontextsize, panelbuttontextstyle)
        pretbctext.Location = New Point(panelbuttontextside, panelbuttontexttop)
        prepnlpanelbuttonholder.Padding = New Padding(panelbuttoninitialgap, 0, 0, 0)
        prepnlpanelbutton.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
        If skinloaderskinpanelbutton(0) Is Nothing Then  Else prepnlpanelbutton.BackColor = Color.Transparent

        Select Case desktoppanelposition
            Case "Top"
                predesktoppanel.Dock = DockStyle.Top
                predesktopappmenu.Dock = DockStyle.Top
            Case "Bottom"
                predesktoppanel.Dock = DockStyle.Bottom
                predesktopappmenu.Dock = DockStyle.Bottom
        End Select

        If skinloaderskindesktoppanel(0) Is Nothing Then
            predesktoppanel.BackColor = desktoppanelcolour
            predesktoppanel.BackgroundImage = Nothing
            prepnlpanelbuttonholder.BackgroundImage = Nothing
        Else
            predesktoppanel.BackgroundImage = skinloaderskindesktoppanel(0)
            prepnlpanelbuttonholder.BackgroundImage = skinloaderskindesktoppanel(0)
            predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
            predesktoppanel.BackColor = Color.Transparent
        End If

        If ShiftOSDesktop.boughtdesktoppanelclock = True Then
            setclocktime()
            prepaneltimetext.ForeColor = clocktextcolour
            If skinloaderskindesktoppaneltime(0) Is Nothing Then
                pretimepanel.BackColor = clockbackgroundcolor
            Else
                pretimepanel.BackColor = Color.Transparent
                pretimepanel.BackgroundImage = skinloaderskindesktoppanel(0)
                pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
            End If
            prepaneltimetext.Font = New Font(panelclocktextfont, panelclocktextsize, panelclocktextstyle)
            pretimepanel.Size = New Size(prepaneltimetext.Width + 3, pretimepanel.Height)
            prepaneltimetext.Location = New Point(0, panelclocktexttop)
            pretimepanel.Show()
        Else
            pretimepanel.Hide()
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

        If showwindowcorners = True Then
            prepgtoplcorner.Show()
            prepgtoprcorner.Show()
        Else
            prepgtoplcorner.Hide()
            prepgtoprcorner.Hide()
        End If

        preapplaunchermenuholder.Width = applaunchermenuholderwidth
        predesktopappmenu.Width = applaunchermenuholderwidth
        ApplicationsToolStripMenuItem.Width = applaunchermenuholderwidth

        If skinloaderskinapplauncherbutton(0) Is Nothing Then
        Else
            ApplicationsToolStripMenuItem.BackColor = Color.Transparent
            predesktopappmenu.BackColor = Color.Transparent
            ApplicationsToolStripMenuItem.BackgroundImage = skinloaderskinapplauncherbutton(0)
            ApplicationsToolStripMenuItem.Text = ""
        End If

        'skins
        If skinloaderskinimages(0) = "" Then  Else preclosebutton.BackgroundImage = GetImage(skinloaderskinimages(0))
        preclosebutton.BackgroundImageLayout = skinclosebuttonstyle
        If skinloaderskinimages(3) = "" Then  Else pretitlebar.BackgroundImage = GetImage(skinloaderskinimages(3))
        pretitlebar.BackgroundImageLayout = skintitlebarstyle
        If skinloaderskinimages(6) = "" Then  Else pnldesktoppreview.BackgroundImage = GetImage(skinloaderskinimages(6))
        pnldesktoppreview.BackgroundImageLayout = skindesktopbackgroundstyle
        If skinloaderskinimages(9) = "" Then  Else prerollupbutton.BackgroundImage = GetImage(skinloaderskinimages(9))
        prerollupbutton.BackgroundImageLayout = skinrollupbuttonstyle
        If skinloaderskinimages(12) = "" Then  Else prepgtoprcorner.BackgroundImage = GetImage(skinloaderskinimages(12))
        prepgtoprcorner.BackgroundImageLayout = skintitlebarrightcornerstyle
        If skinloaderskinimages(15) = "" Then  Else prepgtoplcorner.BackgroundImage = GetImage(skinloaderskinimages(15))
        prepgtoplcorner.BackgroundImageLayout = skintitlebarleftcornerstyle
        If skinloaderskinimages(18) = "" Then  Else predesktoppanel.BackgroundImage = GetImage(skinloaderskinimages(18))
        If skinloaderskinimages(18) = "" Then  Else prepnlpanelbuttonholder.BackgroundImage = GetImage(skinloaderskinimages(18))
        predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
        prepnlpanelbuttonholder.BackgroundImageLayout = skindesktoppanelstyle
        If skinloaderskinimages(21) = "" Then  Else pretimepanel.BackgroundImage = GetImage(skinloaderskinimages(21))
        pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
        If skinloaderskinimages(24) = "" Then  Else ApplicationsToolStripMenuItem.BackgroundImage = GetImage(skinloaderskinimages(24))
        ApplicationsToolStripMenuItem.BackgroundImageLayout = skinapplauncherbuttonstyle
        If skinloaderskinimages(27) = "" Then  Else prepgleft.BackgroundImage = GetImage(skinloaderskinimages(27))
        prepgleft.BackgroundImageLayout = skinwindowborderleftstyle
        If skinloaderskinimages(30) = "" Then  Else prepgright.BackgroundImage = GetImage(skinloaderskinimages(30))
        prepgright.BackgroundImageLayout = skinwindowborderrightstyle
        If skinloaderskinimages(33) = "" Then  Else prepgbottom.BackgroundImage = GetImage(skinloaderskinimages(33))
        prepgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
        If skinloaderskinimages(36) = "" Then  Else prepgbottomrcorner.BackgroundImage = GetImage(skinloaderskinimages(36))
        prepgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
        If skinloaderskinimages(39) = "" Then  Else prepgbottomlcorner.BackgroundImage = GetImage(skinloaderskinimages(39))
        prepgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
        prepgbottomlcorner.Height = windowbordersize
        prepgbottomrcorner.Height = windowbordersize
        If skinloaderskinimages(42) = "" Then  Else preminimizebutton.BackgroundImage = GetImage(skinloaderskinimages(42))
        preminimizebutton.BackgroundImageLayout = skinminimizebuttonstyle
        If skinloaderskinimages(45) = "" Then  Else prepnlpanelbutton.BackgroundImage = GetImage(skinloaderskinimages(45))
        prepnlpanelbutton.BackgroundImageLayout = skinpanelbuttonstyle

        'invisible backgrounds
        If preclosebutton.BackgroundImage Is Nothing Then  Else preclosebutton.BackColor = Color.Transparent
        If pretitlebar.BackgroundImage Is Nothing Then  Else pretitlebar.BackColor = Color.Transparent
        If prerollupbutton.BackgroundImage Is Nothing Then  Else prerollupbutton.BackColor = Color.Transparent
        If prepgtoplcorner.BackgroundImage Is Nothing Then  Else prepgtoplcorner.BackColor = Color.Transparent
        If prepgtoprcorner.BackgroundImage Is Nothing Then  Else prepgtoprcorner.BackColor = Color.Transparent



        ShiftOSDesktop.loadskinfiles()
        ShiftOSDesktop.setupdesktop()
        ShiftOSDesktop.setupskins()

        Me.Invalidate()
    End Sub

    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        Return ret
    End Function

    Private Sub saveskintofile()
        File_Saver.savingprogram = "skinloader"
        File_Saver.saveextention = ".skn"
        File_Saver.Show()
    End Sub

    Public Sub loadskintopreview()
        ReDim Preserve loadlines(200)
        titlebarcolour = Color.FromArgb(loadlines(0))
        windowbordercolour = Color.FromArgb(loadlines(1))
        windowbordersize = loadlines(2)
        titlebarheight = loadlines(3)
        closebuttoncolour = Color.FromArgb(loadlines(4))
        closebuttonheight = loadlines(5)
        closebuttonwidth = loadlines(6)
        closebuttonside = loadlines(7)
        closebuttontop = loadlines(8)
        titletextcolour = Color.FromArgb(loadlines(9))
        titletexttop = loadlines(10)
        titletextside = loadlines(11)
        titletextsize = loadlines(12)
        titletextfont = loadlines(13)
        titletextstyle = loadlines(14)
        desktoppanelcolour = Color.FromArgb(loadlines(15))
        desktopbackgroundcolour = Color.FromArgb(loadlines(16))
        desktoppanelheight = loadlines(17)
        desktoppanelposition = loadlines(18)
        clocktextcolour = Color.FromArgb(loadlines(19))
        clockbackgroundcolor = Color.FromArgb(loadlines(20))
        panelclocktexttop = loadlines(21)
        panelclocktextsize = loadlines(22)
        panelclocktextfont = loadlines(23)
        panelclocktextstyle = loadlines(24)
        applauncherbuttoncolour = Color.FromArgb(loadlines(25))
        applauncherbuttonclickedcolour = Color.FromArgb(loadlines(26))
        applauncherbackgroundcolour = Color.FromArgb(loadlines(27))
        applaunchermouseovercolour = Color.FromArgb(loadlines(28))
        applicationsbuttontextcolour = Color.FromArgb(loadlines(29))
        applicationbuttonheight = loadlines(30)
        applicationbuttontextsize = loadlines(31)
        applicationbuttontextfont = loadlines(32)
        applicationbuttontextstyle = loadlines(33)
        applicationlaunchername = loadlines(34)
        titletextposition = loadlines(35)
        rollupbuttoncolour = Color.FromArgb(loadlines(36))
        If loadlines(37) = "" Then  Else rollupbuttonheight = loadlines(37)
        If loadlines(38) = "" Then  Else rollupbuttonwidth = loadlines(38)
        If loadlines(39) = "" Then  Else rollupbuttonside = loadlines(39)
        If loadlines(40) = "" Then  Else rollupbuttontop = loadlines(40)
        If loadlines(41) = "" Then  Else titlebariconside = loadlines(41)
        If loadlines(42) = "" Then  Else titlebaricontop = loadlines(42)
        If loadlines(43) = "" Then  Else showwindowcorners = loadlines(43)
        If loadlines(44) = "" Then  Else titlebarcornerwidth = loadlines(44)
        If loadlines(45) = "" Then  Else titlebarrightcornercolour = Color.FromArgb(loadlines(45))
        If loadlines(46) = "" Then  Else titlebarleftcornercolour = Color.FromArgb(loadlines(46))
        If loadlines(47) = "" Then  Else applaunchermenuholderwidth = loadlines(47)
        If loadlines(48) = "" Then  Else windowborderleftcolour = Color.FromArgb(loadlines(48))
        If loadlines(49) = "" Then  Else windowborderrightcolour = Color.FromArgb(loadlines(49))
        If loadlines(50) = "" Then  Else windowborderbottomcolour = Color.FromArgb(loadlines(50))
        If loadlines(51) = "" Then  Else windowborderbottomrightcolour = Color.FromArgb(loadlines(51))
        If loadlines(52) = "" Then  Else windowborderbottomleftcolour = Color.FromArgb(loadlines(52))
        If loadlines(53) = "" Then  Else panelbuttonicontop = loadlines(53)
        If loadlines(54) = "" Then  Else panelbuttoniconside = loadlines(54)
        If loadlines(55) = "" Then  Else panelbuttoniconsize = loadlines(55)
        If loadlines(56) = "" Then  Else panelbuttoniconsize = loadlines(56)
        If loadlines(57) = "" Then  Else panelbuttonheight = loadlines(57)
        If loadlines(58) = "" Then  Else panelbuttonwidth = loadlines(58)
        If loadlines(59) = "" Then  Else panelbuttoncolour = Color.FromArgb(loadlines(59))
        If loadlines(60) = "" Then  Else panelbuttontextcolour = Color.FromArgb(loadlines(60))
        If loadlines(61) = "" Then  Else panelbuttontextsize = loadlines(61)
        If loadlines(62) = "" Then  Else panelbuttontextfont = loadlines(62)
        If loadlines(63) = "" Then  Else panelbuttontextstyle = loadlines(63)
        If loadlines(64) = "" Then  Else panelbuttontextside = loadlines(64)
        If loadlines(65) = "" Then  Else panelbuttontexttop = loadlines(65)
        If loadlines(66) = "" Then  Else panelbuttongap = loadlines(66)
        If loadlines(67) = "" Then  Else panelbuttonfromtop = loadlines(67)
        If loadlines(68) = "" Then  Else panelbuttoninitialgap = loadlines(68)
        If loadlines(69) = "" Then  Else minimizebuttoncolour = Color.FromArgb(loadlines(69))
        If loadlines(70) = "" Then  Else minimizebuttonheight = loadlines(70)
        If loadlines(71) = "" Then  Else minimizebuttonwidth = loadlines(71)
        If loadlines(72) = "" Then  Else minimizebuttonside = loadlines(72)
        If loadlines(73) = "" Then  Else minimizebuttontop = loadlines(73)

        skinloaderskinimages(0) = loadlines(100)
        skinloaderskinimages(1) = loadlines(101)
        skinloaderskinimages(2) = loadlines(102)
        skinloaderskinimages(3) = loadlines(103)
        skinloaderskinimages(4) = loadlines(104)
        skinloaderskinimages(5) = loadlines(105)
        skinloaderskinimages(6) = loadlines(106)
        skinloaderskinimages(7) = loadlines(107)
        skinloaderskinimages(8) = loadlines(108)
        skinloaderskinimages(9) = loadlines(109)
        skinloaderskinimages(10) = loadlines(110)
        skinloaderskinimages(11) = loadlines(111)
        skinloaderskinimages(12) = loadlines(112)
        skinloaderskinimages(13) = loadlines(113)
        skinloaderskinimages(14) = loadlines(114)
        skinloaderskinimages(15) = loadlines(115)
        skinloaderskinimages(16) = loadlines(116)
        skinloaderskinimages(17) = loadlines(117)
        skinloaderskinimages(18) = loadlines(118)
        skinloaderskinimages(19) = loadlines(119)
        skinloaderskinimages(20) = loadlines(120)
        skinloaderskinimages(21) = loadlines(121)
        skinloaderskinimages(22) = loadlines(122)
        skinloaderskinimages(23) = loadlines(123)
        skinloaderskinimages(24) = loadlines(124)
        skinloaderskinimages(25) = loadlines(125)
        skinloaderskinimages(26) = loadlines(126)
        skinloaderskinimages(27) = loadlines(127)
        skinloaderskinimages(28) = loadlines(128)
        skinloaderskinimages(29) = loadlines(129)
        skinloaderskinimages(30) = loadlines(130)
        skinloaderskinimages(31) = loadlines(131)
        skinloaderskinimages(32) = loadlines(132)
        skinloaderskinimages(33) = loadlines(133)
        skinloaderskinimages(34) = loadlines(134)
        skinloaderskinimages(35) = loadlines(135)
        skinloaderskinimages(36) = loadlines(136)
        skinloaderskinimages(37) = loadlines(137)
        skinloaderskinimages(38) = loadlines(138)
        skinloaderskinimages(39) = loadlines(139)
        skinloaderskinimages(40) = loadlines(140)
        skinloaderskinimages(41) = loadlines(141)
        skinloaderskinimages(42) = loadlines(142)
        skinloaderskinimages(43) = loadlines(143)
        skinloaderskinimages(44) = loadlines(144)
        skinloaderskinimages(45) = loadlines(145)
        skinloaderskinimages(46) = loadlines(146)
        skinloaderskinimages(47) = loadlines(147)
        skinloaderskinimages(48) = loadlines(148)
        skinloaderskinimages(49) = loadlines(149)
        skinloaderskinimages(50) = loadlines(150)

        setpreviewtocurrentskin()
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

    Private Sub btnsaveskin_Click(sender As Object, e As EventArgs) Handles btnsaveskin.Click
        saveskintofile()
    End Sub

    Private Sub btnloadskin_Click(sender As Object, e As EventArgs) Handles btnloadskin.Click
        File_Opener.Show()
        File_Opener.openingprogram = "skinloader"
        File_Opener.openextention = ".skn"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnapplyskin_Click(sender As Object, e As EventArgs) Handles btnapplyskin.Click
        If Shifter.Visible = True Then
            infobox.title = "Skin Loader - Error"
            infobox.textinfo = "It appears that the Shifter application is currently open." & Environment.NewLine & Environment.NewLine & "Due to system stability issues you must close it before applying the skin!"
            infobox.Show()
        Else
            If skinloaded = True Then
                If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\CurrentCopy\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\CurrentCopy\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                ShiftOSDesktop.disposeoldskindata("skinloaderapplyskin")
                ShiftOSDesktop.loadcurrentskin()
                ShiftOSDesktop.loadskinfiles()
                ShiftOSDesktop.setupalltitlebars()
                ShiftOSDesktop.setcolours()
                ShiftOSDesktop.setupdesktop()
                ShiftOSDesktop.setupskins()
                ShiftOSDesktop.Invalidate()
                skinloaded = False
            Else
                infobox.title = "Skin Loader - No Skin!"
                infobox.textinfo = "It appears you havn't loaded a new skin." & Environment.NewLine & Environment.NewLine & "Please click load skin and choose an existing .skn file to load it in the preview and press apply to apply it to your system."
                infobox.Show()
            End If
        End If
    End Sub



    'required to fix flashing applauncher button problem
    Public Sub ApplicationsToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles ApplicationsToolStripMenuItem.Paint
        If ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then
        Else
            e.Graphics.DrawImage(ApplicationsToolStripMenuItem.BackgroundImage, 0, 0, ApplicationsToolStripMenuItem.BackgroundImage.Width, ApplicationsToolStripMenuItem.BackgroundImage.Height)
        End If
    End Sub
End Class