Imports System.IO

Public Class Skin_Loader
    ' Variables
    Public rolldownsize As Integer ' Roll down size
    Public oldbordersize As Integer ' Old border size
    Public oldtitlebarheight As Integer ' Old title bar height
    Public justopened As Boolean = False ' Just opened?
    Public needtorollback As Boolean = False ' Need to roll back?
    Public minimumsizewidth As Integer = 0 ' Minimum size width
    Public minimumsizeheight As Integer = 0 ' Minimum size height
    Public ShiftOSPath As String = "C:\ShiftOS\"
    Dim firstload As Boolean = True

    Public oldpreheight As Integer = 40

    ' Has a skin been loaded?
    Public skinloaded As Boolean = False

    Public savelines(200) As String
    Public loadlines(200) As String

    Dim titlebarcolour As Color ' Title bar colour
    Dim windowbordercolour As Color ' Window border colour
    Dim windowbordersize As Integer ' Window border size
    Dim titlebarheight As Integer ' Title bar height
    Dim closebuttoncolour As Color ' Close button colour
    Dim closebuttonheight As Integer ' Close button height
    Dim closebuttonwidth As Integer ' Close button width
    Dim closebuttonside As Integer '  How many pixels away the close button is from the side of the window border edge
    Dim closebuttontop As Integer ' How many pixels away the close button is from the top of the window bordeer
    Dim titletextcolour As Color ' Title bar text colour
    Dim titletexttop As Integer ' How many pixels away the title bar text is from the top of the window border
    Dim titletextside As Integer ' How many pixels away the title bar text is from the side of the window border
    Dim titletextsize As Integer ' The font size of the title bar text
    Dim titletextfont As String ' The font of the title bar
    Dim titletextstyle As FontStyle ' The title bar text's font style
    Dim desktoppanelcolour As Color ' The desktop panel colour
    Dim desktopbackgroundcolour As Color ' The desktop background colour
    Dim desktoppanelheight As Integer ' The desktop panel's height
    Dim desktoppanelposition As String ' The desktop panel's position (top, bottom)
    Dim clocktextcolour As Color ' The clock's text colour
    Dim clockbackgroundcolor As Color ' The clock background colour.
    Dim panelclocktexttop As Integer ' How many pixels away the panel clock text is from the top of the desktop panel
    Dim panelclocktextsize As Integer ' Font size of the panel clock
    Dim panelclocktextfont As String ' The panel clock's font (Wingdings/Webdings = fun clock)
    Dim panelclocktextstyle As FontStyle ' The panel clock's font style
    Dim applauncherbuttoncolour As Color ' The button colour in the Application Launcher
    Dim applauncherbuttonclickedcolour As Color ' The colour that the button in the App Launcher will be when clicked
    Dim applauncherbackgroundcolour As Color ' Application Launcher background colour
    Dim applaunchermouseovercolour As Color ' When the mouse is over the App Launcher, it's colour will be this
    Dim applicationsbuttontextcolour As Color ' The "Applications" button's text colour
    Dim applicationbuttonheight As Integer ' The height of the "Applications" button
    Dim applicationbuttontextsize As Integer ' The font size of the "Applications" button
    Dim applicationbuttontextfont As String ' The font used by the "Applications" button
    Dim applicationbuttontextstyle As FontStyle ' The font style used by the "Applications" button
    Dim applicationlaunchername As String ' The name of the application launcher
    Dim titletextposition As String ' A window's title bar text position (string)
    Dim rollupbuttoncolour As Color ' The colour of the roll-up button
    Dim rollupbuttonheight As Integer ' The height of the roll-up button
    Dim rollupbuttonwidth As Integer ' The width of the roll-up button
    Dim rollupbuttonside As Integer ' How far away the roll-up button is from the side of the title bar (in pixels)
    Dim rollupbuttontop As Integer ' How far away the roll-up button is from the top of the title bar (in pixels)
    Dim titlebariconside As Integer ' How far away the title bar icon is from the side of the title bar (in pixels)
    Dim titlebaricontop As Integer ' How far away the title bar icon is from the top of the title bar (in pixels)
    Dim showwindowcorners As Boolean ' Show window corners?
    Dim titlebarcornerwidth As Integer ' The width of the title bar corner
    Dim titlebarrightcornercolour As Color ' The right corner of the title bar's colour
    Dim titlebarleftcornercolour As Color ' The left corner of the title bar's colour 
    Dim applaunchermenuholderwidth As Integer ' The application launcher's holder's width
    Dim windowborderleftcolour As Color ' The left side of the window border's colour
    Dim windowborderrightcolour As Color ' The right side of the window border's colour
    Dim windowborderbottomcolour As Color ' The bottom portion of the window border's colour
    Dim windowborderbottomrightcolour As Color ' The bottom right corner of the window border's colour
    Dim windowborderbottomleftcolour As Color ' The bottom left corner of the window border's colour

    Dim panelbuttonicontop As Integer ' How far the panel button icon is from the top of the panel (in pixels)
    Dim panelbuttoniconside As Integer ' How far the panel button is from the sides of the panel (in pixels)
    Dim panelbuttoniconsize As Integer ' The size of the panel button's icon
    Dim panelbuttonheight As Integer ' The panel button's height
    Dim panelbuttonwidth As Integer ' The panel button's width
    Dim panelbuttoncolour As Color ' The panel button's colour
    Dim panelbuttontextcolour As Color ' The panel button's text colour
    Dim panelbuttontextsize As Integer ' The panel button's text size
    Dim panelbuttontextfont As String ' The panel button's text font
    Dim panelbuttontextstyle As FontStyle ' The panel button's font style
    Dim panelbuttontextside As Integer ' How many pixels away the panel button text is from the side
    Dim panelbuttontexttop As Integer ' How many pixels away the panel button text is from the top
    Dim panelbuttongap As Integer ' The panel button gap
    Dim panelbuttonfromtop As Integer ' How far away the panel button is from the top (in pixels)
    Dim panelbuttoninitialgap As Integer ' Initial panel button gap
    Dim minimizebuttoncolour As Color ' Minimize button colour
    Dim minimizebuttonheight As Integer ' Minimize button height
    Dim minimizebuttonwidth As Integer ' Minimize button width
    Dim minimizebuttonside As Integer ' How far away the minimize button is from the side of the window border (pixels)
    Dim minimizebuttontop As Integer ' How far away the minimize button is from the top of the window border (pixels)

    'skins
    Dim skinloaderskinimages(100) As String
    Dim skinloaderskinclosebutton(2) As Image
    Dim skinclosebuttonstyle As ImageLayout
    Dim skinloaderskintitlebar(2) As Image
    Dim skintitlebarstyle As ImageLayout
    Dim skinloaderskindesktopbackground(2) As Image
    Dim skindesktopbackgroundstyle As ImageLayout
    Dim skinloaderskinrollupbutton(2) As Image
    Dim skinrollupbuttonstyle As ImageLayout
    Dim skinloaderskintitlebarrightcorner(2) As Image
    Dim skintitlebarrightcornerstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskintitlebarleftcorner(2) As Image
    Dim skintitlebarleftcornerstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskindesktoppanel(2) As Image
    Dim skindesktoppanelstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskindesktoppaneltime(2) As Image
    Dim skindesktoppaneltimestyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinapplauncherbutton(2) As Image
    Dim skinapplauncherbuttonstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinwindowborderleft(2) As Image
    Dim skinwindowborderleftstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinwindowborderright(2) As Image
    Dim skinwindowborderrightstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinwindowborderbottom(2) As Image
    Dim skinwindowborderbottomstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinwindowborderbottomright(2) As Image
    Dim skinwindowborderbottomrightstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinwindowborderbottomleft(2) As Image
    Dim skinwindowborderbottomleftstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinpanelbutton(2) As Image
    Dim skinpanelbuttonstyle As ImageLayout = ImageLayout.Stretch
    Dim skinloaderskinminimizebutton(2) As Image
    Dim skinminimizebuttonstyle As ImageLayout = ImageLayout.Stretch

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.SkinLoaderCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttonskinloader.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonskinloader, ShiftOSDesktop.tbskinloadericon, ShiftOSDesktop.tbskinloadertext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        initialsetup()
        setpreviewtocurrentskin()
        determinevisibleobjects()
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
        Try

            setupborders()

            If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
            pgleft.Width = Skins.borderwidth
            pgright.Width = Skins.borderwidth
            pgbottom.Height = Skins.borderwidth
            titlebar.Height = Skins.titlebarheight


            If justopened = True Then
                Me.Size = New Size(476, 462) 'put the default size of your window here
                Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
                Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
                oldbordersize = Skins.borderwidth
                oldtitlebarheight = Skins.titlebarheight
                justopened = False
            Else
                If Me.Visible = True Then
                    Me.Size = New Size(Me.Width - (2 * oldbordersize) + (2 * Skins.borderwidth), ((Me.Height - oldtitlebarheight - oldbordersize) + Skins.titlebarheight + Skins.borderwidth) + (pretitlebar.Size.Height + predesktoppanel.Size.Height - oldpreheight))
                    oldbordersize = Skins.borderwidth
                    oldtitlebarheight = Skins.titlebarheight
                    rolldownsize = Me.Height
                    If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
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
                lbtitletext.Text = ShiftOSDesktop.skinloadername 'Remember to change to name of program!!!!
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
            If ShiftOSDesktop.boughtskinning = True Then ' Change to program's icon
                pnlicon.Visible = True
                pnlicon.Location = New Point(Skins.titleiconfromside, Skins.titleiconfromtop)
                pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
                pnlicon.Image = ShiftOSDesktop.skinloadericontitlebar  'Replace with the correct icon for the program.
            End If

        Catch ex As Exception
        End Try

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

    Private Sub initialsetup()
        titlebarcolour = Skins.titlebarcolour
        windowbordercolour = Skins.borderleftcolour
        windowbordersize = Skins.borderwidth
        titlebarheight = Skins.titlebarheight
        closebuttoncolour = Skins.closebtncolour
        closebuttonheight = Skins.closebtnsize.Height
        closebuttonwidth = Skins.closebtnsize.Width
        closebuttontop = Skins.closebtnfromtop
        closebuttonside = Skins.closebtnfromside
        titletextcolour = Skins.closebtncolour
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
        titletextposition = Skins.titletextpos
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

        'skins
        'Array.Copy(ShiftOSDesktop.skinimages, skinloaderskinimages, skinloaderskinimages.Length)

        If Skins.closebtn Is Nothing Then  Else skinloaderskinclosebutton(0) = Skins.closebtn.Clone
        If Skins.closebtnhover Is Nothing Then  Else skinloaderskinclosebutton(1) = Skins.closebtnhover.Clone
        If Skins.closebtnclick Is Nothing Then  Else skinloaderskinclosebutton(2) = Skins.closebtnclick.Clone
        skinclosebuttonstyle = Skins.closebtnlayout

        If Skins.titlebar Is Nothing Then  Else skinloaderskintitlebar(0) = Skins.titlebar.Clone
        'If ShiftOSDesktop.skintitlebar(1) Is Nothing Then  Else skinloaderskintitlebar(1) = ShiftOSDesktop.skintitlebar(1).Clone
        'If ShiftOSDesktop.skintitlebar(2) Is Nothing Then  Else skinloaderskintitlebar(2) = ShiftOSDesktop.skintitlebar(2).Clone
        skintitlebarstyle = Skins.titlebarlayout

        If Skins.desktopbackground Is Nothing Then  Else skinloaderskindesktopbackground(0) = Skins.desktopbackground.Clone
        'If ShiftOSDesktop.skindesktopbackground(1) Is Nothing Then  Else skinloaderskindesktopbackground(1) = ShiftOSDesktop.skindesktopbackground(1).Clone
        'If ShiftOSDesktop.skindesktopbackground(2) Is Nothing Then  Else skinloaderskindesktopbackground(2) = ShiftOSDesktop.skindesktopbackground(2).Clone
        skindesktopbackgroundstyle = Skins.desktopbackgroundlayout

        If Skins.rollbtn Is Nothing Then  Else skinloaderskinrollupbutton(0) = Skins.rollbtn.Clone
        If Skins.rollbtnhover Is Nothing Then  Else skinloaderskinrollupbutton(1) = Skins.rollbtnhover.Clone
        If Skins.rollbtnclick Is Nothing Then  Else skinloaderskinrollupbutton(2) = Skins.rollbtnclick.Clone
        skinrollupbuttonstyle = Skins.rollbtnlayout

        If Skins.rightcorner Is Nothing Then  Else skinloaderskintitlebarrightcorner(0) = Skins.rightcorner.Clone
        'If ShiftOSDesktop.skintitlebarrightcorner(1) Is Nothing Then  Else skinloaderskintitlebarrightcorner(1) = ShiftOSDesktop.skintitlebarrightcorner(1).Clone
        'If ShiftOSDesktop.skintitlebarrightcorner(2) Is Nothing Then  Else skinloaderskintitlebarrightcorner(2) = ShiftOSDesktop.skintitlebarrightcorner(2).Clone
        skintitlebarrightcornerstyle = Skins.rightcornerlayout

        If Skins.leftcorner Is Nothing Then  Else skinloaderskintitlebarleftcorner(0) = Skins.leftcorner.Clone
        'If ShiftOSDesktop.skintitlebarleftcorner(1) Is Nothing Then  Else skinloaderskintitlebarleftcorner(1) = ShiftOSDesktop.skintitlebarleftcorner(1).Clone
        'If ShiftOSDesktop.skintitlebarleftcorner(2) Is Nothing Then  Else skinloaderskintitlebarleftcorner(2) = ShiftOSDesktop.skintitlebarleftcorner(2).Clone
        skintitlebarleftcornerstyle = Skins.leftcornerlayout

        If Skins.desktoppanel Is Nothing Then  Else skinloaderskindesktoppanel(0) = Skins.desktoppanel.Clone
        'If ShiftOSDesktop.skindesktoppanel(1) Is Nothing Then  Else skinloaderskindesktoppanel(1) = ShiftOSDesktop.skindesktoppanel(1).Clone
        'If ShiftOSDesktop.skindesktoppanel(2) Is Nothing Then  Else skinloaderskindesktoppanel(2) = ShiftOSDesktop.skindesktoppanel(2).Clone
        skindesktoppanelstyle = Skins.desktoppanellayout

        If Skins.panelclock Is Nothing Then  Else skinloaderskindesktoppaneltime(0) = Skins.panelclock.Clone
        'If ShiftOSDesktop.skindesktoppaneltime(1) Is Nothing Then  Else skinloaderskindesktoppaneltime(1) = ShiftOSDesktop.skindesktoppaneltime(1).Clone
        'If ShiftOSDesktop.skindesktoppaneltime(2) Is Nothing Then  Else skinloaderskindesktoppaneltime(2) = ShiftOSDesktop.skindesktoppaneltime(2).Clone
        skindesktoppaneltimestyle = Skins.panelclocklayout

        If Skins.applauncher Is Nothing Then  Else skinloaderskinapplauncherbutton(0) = Skins.applauncher.Clone
        If Skins.applaunchermouseover Is Nothing Then  Else skinloaderskinapplauncherbutton(1) = Skins.applaunchermouseover.Clone
        If Skins.applauncherclick Is Nothing Then  Else skinloaderskinapplauncherbutton(2) = Skins.applauncherclick.Clone
        skinapplauncherbuttonstyle = Skins.applauncherlayout

        If Skins.borderleft Is Nothing Then  Else skinloaderskinwindowborderleft(0) = Skins.borderleft.Clone
        'If ShiftOSDesktop.skinwindowborderleft(1) Is Nothing Then  Else skinloaderskinwindowborderleft(1) = ShiftOSDesktop.skinwindowborderleft(1).Clone
        'If ShiftOSDesktop.skinwindowborderleft(2) Is Nothing Then  Else skinloaderskinwindowborderleft(2) = ShiftOSDesktop.skinwindowborderleft(2).Clone
        skinwindowborderleftstyle = Skins.borderleftlayout

        If Skins.borderleft Is Nothing Then  Else skinloaderskinwindowborderright(0) = Skins.borderleft.Clone
        'If ShiftOSDesktop.skinwindowborderright(1) Is Nothing Then  Else skinloaderskinwindowborderright(1) = ShiftOSDesktop.skinwindowborderright(1).Clone
        'If ShiftOSDesktop.skinwindowborderright(2) Is Nothing Then  Else skinloaderskinwindowborderright(2) = ShiftOSDesktop.skinwindowborderright(2).Clone
        skinwindowborderrightstyle = Skins.borderrightlayout

        If Skins.borderbottom Is Nothing Then  Else skinloaderskinwindowborderbottom(0) = Skins.borderbottom.Clone
        'If ShiftOSDesktop.skinwindowborderbottom(1) Is Nothing Then  Else skinloaderskinwindowborderbottom(1) = ShiftOSDesktop.skinwindowborderbottom(1).Clone
        'If ShiftOSDesktop.skinwindowborderbottom(2) Is Nothing Then  Else skinloaderskinwindowborderbottom(2) = ShiftOSDesktop.skinwindowborderbottom(2).Clone
        skinwindowborderbottomstyle = Skins.borderbottomlayout

        If Skins.bottomrightcorner Is Nothing Then  Else skinloaderskinwindowborderbottomright(0) = Skins.bottomrightcorner.Clone
        'If ShiftOSDesktop.skinwindowborderbottomright(1) Is Nothing Then  Else skinloaderskinwindowborderbottomright(1) = ShiftOSDesktop.skinwindowborderbottomright(1).Clone
        'If ShiftOSDesktop.skinwindowborderbottomright(2) Is Nothing Then  Else skinloaderskinwindowborderbottomright(2) = ShiftOSDesktop.skinwindowborderbottomright(2).Clone
        skinwindowborderbottomrightstyle = Skins.bottomrightcornerlayout

        If Skins.bottomleftcorner Is Nothing Then  Else skinloaderskinwindowborderbottomleft(0) = Skins.bottomleftcorner.Clone
        'If ShiftOSDesktop.skinwindowborderbottomleft(1) Is Nothing Then  Else skinloaderskinwindowborderbottomleft(1) = ShiftOSDesktop.skinwindowborderbottomleft(1).Clone
        'If ShiftOSDesktop.skinwindowborderbottomleft(2) Is Nothing Then  Else skinloaderskinwindowborderbottomleft(2) = ShiftOSDesktop.skinwindowborderbottomleft(2).Clone
        skinwindowborderbottomleftstyle = Skins.bottomleftcornerlayout

        If Skins.panelbutton Is Nothing Then  Else skinloaderskinpanelbutton(0) = Skins.panelbutton.Clone
        'If ShiftOSDesktop.skinpanelbutton(1) Is Nothing Then  Else skinloaderskinpanelbutton(1) = ShiftOSDesktop.skinpanelbutton(1).Clone
        'If ShiftOSDesktop.skinpanelbutton(2) Is Nothing Then  Else skinloaderskinpanelbutton(2) = ShiftOSDesktop.skinpanelbutton(2).Clone
        skinpanelbuttonstyle = Skins.panelbuttonlayout

        If Skins.minbtn Is Nothing Then  Else skinloaderskinminimizebutton(0) = Skins.minbtn.Clone
        If Skins.minbtnhover Is Nothing Then  Else skinloaderskinminimizebutton(1) = Skins.minbtnhover.Clone
        If Skins.minbtnclick Is Nothing Then  Else skinloaderskinminimizebutton(2) = Skins.minbtnclick.Clone
        skinminimizebuttonstyle = Skins.minbtnlayout

        If Skins.closebtn Is Nothing Then preclosebutton.BackColor = Skins.closebtncolour Else preclosebutton.BackgroundImage = Skins.closebtn
        preclosebutton.BackgroundImageLayout = Skins.closebtnlayout
        If Skins.titlebar Is Nothing Then pretitlebar.BackColor = Skins.titlebarcolour Else pretitlebar.BackgroundImage = Skins.titlebar
        pretitlebar.BackgroundImageLayout = Skins.titlebarlayout
        If Skins.rollbtn Is Nothing Then prerollupbutton.BackColor = Skins.rollbtncolour Else prerollupbutton.BackgroundImage = Skins.rollbtn
        prerollupbutton.BackgroundImageLayout = Skins.rollbtnlayout
        If Skins.leftcorner Is Nothing Then prepgtoplcorner.BackColor = Skins.leftcornercolour Else prepgtoplcorner.BackgroundImage = Skins.leftcorner
        prepgtoplcorner.BackgroundImageLayout = Skins.leftcornerlayout
        If Skins.rightcorner Is Nothing Then prepgtoprcorner.BackColor = Skins.rightcornercolour Else prepgtoprcorner.BackgroundImage = Skins.rightcorner
        prepgtoprcorner.BackgroundImageLayout = Skins.rightcornerlayout
        If Skins.minbtn Is Nothing Then preminimizebutton.BackColor = Skins.minbtncolour Else preminimizebutton.BackgroundImage = Skins.minbtn
        preminimizebutton.BackgroundImageLayout = Skins.minbtnlayout
        If Skins.borderleft Is Nothing Then prepgleft.BackColor = Skins.borderleftcolour Else prepgleft.BackgroundImage = Skins.borderleft
        prepgleft.BackgroundImageLayout = Skins.borderleftlayout
        If Skins.borderright Is Nothing Then prepgright.BackColor = Skins.borderrightcolour Else prepgright.BackgroundImage = Skins.borderright
        prepgleft.BackgroundImageLayout = Skins.borderrightlayout
        If Skins.borderbottom Is Nothing Then prepgbottom.BackColor = Skins.borderbottomcolour Else prepgbottom.BackgroundImage = Skins.borderbottom
        prepgbottom.BackgroundImageLayout = Skins.borderbottomlayout
        If enablebordercorners = True Then
            If Skins.bottomleftcorner Is Nothing Then prepgbottomlcorner.BackColor = Skins.bottomleftcornercolour Else prepgbottomlcorner.BackgroundImage = Skins.bottomleftcorner
            prepgbottomlcorner.BackgroundImageLayout = Skins.bottomleftcornerlayout
            If Skins.bottomrightcorner Is Nothing Then prepgbottomrcorner.BackColor = Skins.bottomrightcornercolour Else prepgbottomrcorner.BackgroundImage = Skins.bottomrightcorner
            prepgbottomrcorner.BackgroundImageLayout = Skins.bottomrightcornerlayout
        Else
            prepgbottomlcorner.BackColor = Skins.borderrightcolour
            prepgbottomrcorner.BackColor = Skins.borderrightcolour
            prepgbottomlcorner.BackgroundImage = Nothing
            prepgbottomrcorner.BackgroundImage = Nothing
        End If

        'set bottom border corner size
        pgbottomlcorner.Size = New Size(Skins.borderwidth, Skins.borderwidth)
        pgbottomrcorner.Size = New Size(Skins.borderwidth, Skins.borderwidth)
        pgbottomlcorner.Location = New Point(0, Me.Height - Skins.borderwidth)
        pgbottomrcorner.Location = New Point(Me.Width, Me.Height - Skins.borderwidth)

        pnldesktoppreview.BackgroundImage = Skins.desktopbackground
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
        'ShiftOSDesktop.loadskinfiles()

        Try

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
            prepgbottomlcorner.BackgroundImage = Skins.bottomleftcorner
            prepgbottomrcorner.BackgroundImage = Skins.bottomrightcorner

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
            If firstload = False Then
                If loadingsknversion = "2.0 disposal-free skinning" Then
                    If IsNothing(skinloaderskinclosebutton(0)) Then preclosebutton.BackgroundImage = Nothing Else preclosebutton.BackgroundImage = skinloaderskinclosebutton(0)
                    preclosebutton.BackgroundImageLayout = skinclosebuttonstyle
                    If IsNothing(skinloaderskintitlebar(0)) Then pretitlebar.BackgroundImage = Nothing Else pretitlebar.BackgroundImage = skinloaderskintitlebar(0)
                    pretitlebar.BackgroundImageLayout = skintitlebarstyle
                    If IsNothing(skinloaderskindesktopbackground(0)) Then pnldesktoppreview.BackgroundImage = Nothing Else pnldesktoppreview.BackgroundImage = skinloaderskindesktopbackground(0)
                    pnldesktoppreview.BackgroundImageLayout = skindesktopbackgroundstyle
                    If IsNothing(skinloaderskinrollupbutton(0)) Then prerollupbutton.BackgroundImage = Nothing Else prerollupbutton.BackgroundImage = skinloaderskinrollupbutton(0)
                    prerollupbutton.BackgroundImageLayout = skinrollupbuttonstyle
                    If IsNothing(skinloaderskintitlebarrightcorner(0)) Then prepgtoprcorner.BackgroundImage = Nothing Else prepgtoprcorner.BackgroundImage = skinloaderskintitlebarrightcorner(0)
                    prepgtoprcorner.BackgroundImageLayout = skintitlebarrightcornerstyle
                    If IsNothing(skinloaderskintitlebarleftcorner(0)) Then prepgtoplcorner.BackgroundImage = Nothing Else prepgtoplcorner.BackgroundImage = skinloaderskintitlebarleftcorner(0)
                    prepgtoplcorner.BackgroundImageLayout = skintitlebarleftcornerstyle
                    If IsNothing(skinloaderskindesktoppanel(0)) Then predesktoppanel.BackgroundImage = Nothing Else predesktoppanel.BackgroundImage = skinloaderskindesktoppanel(0)
                    If IsNothing(skinloaderskindesktoppanel(0)) Then prepnlpanelbuttonholder.BackgroundImage = Nothing Else prepnlpanelbuttonholder.BackgroundImage = skinloaderskindesktoppanel(0)
                    predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
                    prepnlpanelbuttonholder.BackgroundImageLayout = skindesktoppanelstyle
                    If IsNothing(skinloaderskindesktoppaneltime(0)) Then pretimepanel.BackgroundImage = Nothing Else pretimepanel.BackgroundImage = skinloaderskindesktoppaneltime(0)
                    pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
                    If IsNothing(skinloaderskinapplauncherbutton(0)) Then ApplicationsToolStripMenuItem.BackgroundImage = Nothing Else ApplicationsToolStripMenuItem.BackgroundImage = skinloaderskinapplauncherbutton(0)
                    ApplicationsToolStripMenuItem.BackgroundImageLayout = skinapplauncherbuttonstyle
                    If IsNothing(skinloaderskinwindowborderleft(0)) Then prepgleft.BackgroundImage = Nothing Else prepgleft.BackgroundImage = skinloaderskinwindowborderleft(0)
                    prepgleft.BackgroundImageLayout = skinwindowborderleftstyle
                    If IsNothing(skinloaderskinwindowborderright(0)) Then prepgright.BackgroundImage = Nothing Else prepgright.BackgroundImage = skinloaderskinwindowborderright(0)
                    prepgright.BackgroundImageLayout = skinwindowborderrightstyle
                    If IsNothing(skinloaderskinwindowborderbottom(0)) Then prepgbottom.BackgroundImage = Nothing Else prepgbottom.BackgroundImage = skinloaderskinwindowborderbottom(0)
                    prepgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
                    If IsNothing(skinloaderskinwindowborderbottomright(0)) Then prepgbottomrcorner.BackgroundImage = Nothing Else prepgbottomrcorner.BackgroundImage = skinloaderskinwindowborderbottomright(0)
                    prepgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
                    If IsNothing(skinloaderskinwindowborderbottomleft(0)) Then prepgbottomlcorner.BackgroundImage = Nothing Else prepgbottomlcorner.BackgroundImage = skinloaderskinwindowborderbottomleft(0)
                    prepgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
                    prepgbottomlcorner.Height = windowbordersize
                    prepgbottomrcorner.Height = windowbordersize
                    If IsNothing(skinloaderskinminimizebutton(0)) Then preminimizebutton.BackgroundImage = Nothing Else preminimizebutton.BackgroundImage = skinloaderskinminimizebutton(0)
                    preminimizebutton.BackgroundImageLayout = skinminimizebuttonstyle
                    If IsNothing(skinloaderskinpanelbutton(0)) Then prepnlpanelbutton.BackgroundImage = Nothing Else prepnlpanelbutton.BackgroundImage = skinloaderskinpanelbutton(0)
                    prepnlpanelbutton.BackgroundImageLayout = skinpanelbuttonstyle
                Else
                    If skinloaderskinimages(0) = "" Then preclosebutton.BackgroundImage = Nothing Else preclosebutton.BackgroundImage = GetImage(skinloaderskinimages(0))
                    preclosebutton.BackgroundImageLayout = skinclosebuttonstyle
                    If skinloaderskinimages(3) = "" Then pretitlebar.BackgroundImage = Nothing Else pretitlebar.BackgroundImage = GetImage(skinloaderskinimages(3))
                    pretitlebar.BackgroundImageLayout = skintitlebarstyle
                    If skinloaderskinimages(6) = "" Then pnldesktoppreview.BackgroundImage = Nothing Else pnldesktoppreview.BackgroundImage = GetImage(skinloaderskinimages(6))
                    pnldesktoppreview.BackgroundImageLayout = skindesktopbackgroundstyle
                    If skinloaderskinimages(9) = "" Then prerollupbutton.BackgroundImage = Nothing Else prerollupbutton.BackgroundImage = GetImage(skinloaderskinimages(9))
                    prerollupbutton.BackgroundImageLayout = skinrollupbuttonstyle
                    If skinloaderskinimages(12) = "" Then prepgtoprcorner.BackgroundImage = Nothing Else prepgtoprcorner.BackgroundImage = GetImage(skinloaderskinimages(12))
                    prepgtoprcorner.BackgroundImageLayout = skintitlebarrightcornerstyle
                    If skinloaderskinimages(15) = "" Then prepgtoplcorner.BackgroundImage = Nothing Else prepgtoplcorner.BackgroundImage = GetImage(skinloaderskinimages(15))
                    prepgtoplcorner.BackgroundImageLayout = skintitlebarleftcornerstyle
                    If skinloaderskinimages(18) = "" Then predesktoppanel.BackgroundImage = Nothing Else predesktoppanel.BackgroundImage = GetImage(skinloaderskinimages(18))
                    If skinloaderskinimages(18) = "" Then prepnlpanelbuttonholder.BackgroundImage = Nothing Else prepnlpanelbuttonholder.BackgroundImage = GetImage(skinloaderskinimages(18))
                    predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
                    prepnlpanelbuttonholder.BackgroundImageLayout = skindesktoppanelstyle
                    If skinloaderskinimages(21) = "" Then pretimepanel.BackgroundImage = Nothing Else pretimepanel.BackgroundImage = GetImage(skinloaderskinimages(21))
                    pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
                    If skinloaderskinimages(24) = "" Then ApplicationsToolStripMenuItem.BackgroundImage = Nothing Else ApplicationsToolStripMenuItem.BackgroundImage = GetImage(skinloaderskinimages(24))
                    ApplicationsToolStripMenuItem.BackgroundImageLayout = skinapplauncherbuttonstyle
                    If skinloaderskinimages(27) = "" Then prepgleft.BackgroundImage = Nothing Else prepgleft.BackgroundImage = GetImage(skinloaderskinimages(27))
                    prepgleft.BackgroundImageLayout = skinwindowborderleftstyle
                    If skinloaderskinimages(30) = "" Then prepgright.BackgroundImage = Nothing Else prepgright.BackgroundImage = GetImage(skinloaderskinimages(30))
                    prepgright.BackgroundImageLayout = skinwindowborderrightstyle
                    If skinloaderskinimages(33) = "" Then prepgbottom.BackgroundImage = Nothing Else prepgbottom.BackgroundImage = GetImage(skinloaderskinimages(33))
                    prepgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
                    If skinloaderskinimages(36) = "" Then prepgbottomrcorner.BackgroundImage = Nothing Else prepgbottomrcorner.BackgroundImage = GetImage(skinloaderskinimages(36))
                    prepgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
                    If skinloaderskinimages(39) = "" Then prepgbottomlcorner.BackgroundImage = Nothing Else prepgbottomlcorner.BackgroundImage = GetImage(skinloaderskinimages(39))
                    prepgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
                    prepgbottomlcorner.Height = windowbordersize
                    prepgbottomrcorner.Height = windowbordersize
                    If skinloaderskinimages(42) = "" Then preminimizebutton.BackgroundImage = Nothing Else preminimizebutton.BackgroundImage = GetImage(skinloaderskinimages(42))
                    preminimizebutton.BackgroundImageLayout = skinminimizebuttonstyle
                    If skinloaderskinimages(45) = "" Then prepnlpanelbutton.BackgroundImage = Nothing Else prepnlpanelbutton.BackgroundImage = GetImage(skinloaderskinimages(45))
                    prepnlpanelbutton.BackgroundImageLayout = skinpanelbuttonstyle
                End If
            Else
                firstload = False
            End If

            If Me.Visible = True Then
                Me.Size = New Size(Me.Width - (2 * oldbordersize) + (2 * Skins.borderwidth), ((Me.Height - oldtitlebarheight - oldbordersize) + Skins.titlebarheight + Skins.borderwidth) + (Me.pretitlebar.Size.Height + Me.predesktoppanel.Size.Height - Me.oldpreheight))
                Me.oldbordersize = Skins.borderwidth
                Me.oldtitlebarheight = Skins.titlebarheight
                Me.rolldownsize = Me.Height
                Me.oldpreheight = Me.pretitlebar.Height + Me.prepnlpanelbuttonholder.Height + Me.prepgbottom.Height
                If Me.needtorollback = True Then Me.Height = Me.titlebar.Height : Me.pgleft.Hide() : Me.pgbottom.Hide() : Me.pgright.Hide()
            End If

            ShiftOSDesktop.loadskinfiles()
            ShiftOSDesktop.setupdesktop()

            Me.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

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
        File_Saver.saveextention = ".skn"
        File_Saver.savingprogram = "skinloader"
        File_Saver.Show()
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

    Public loadingskinpath As String
    Public loadingsknversion As String
    Private Sub btnapplyskin_Click(sender As Object, e As EventArgs) Handles btnapplyskin.Click
        If skinloaded = True Then
            If loadingsknversion = "2.0 disposal-free skinning" Then
                If Directory.Exists(Paths.loadedskin) Then My.Computer.FileSystem.DeleteDirectory(Paths.loadedskin, FileIO.DeleteDirectoryOption.DeleteAllContents)



                Directory.CreateDirectory(ShiftOSPath + "Shiftum42\Skins\Loaded")
                My.Computer.FileSystem.CopyDirectory(ShiftOSPath + "Shiftum42\Skins\Preview", ShiftOSPath + "Shiftum42\Skins\Loaded")
                Skins.loadimages()
                skinloaded = False

            Else
                apply1_0skin()
                skinloaded = False
            End If
        Else
            infobox.title = "Skin Loader - No Skin!"
            infobox.textinfo = "It appears you havn't loaded a new skin." & Environment.NewLine & Environment.NewLine & "Please click load skin and choose an existing .skn file to load it in the preview and press apply to apply it to your system."
            infobox.Show()
        End If
    End Sub



    'required to fix flashing applauncher button problem
    Public Sub ApplicationsToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles ApplicationsToolStripMenuItem.Paint
        If ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then
        Else
            e.Graphics.DrawImage(ApplicationsToolStripMenuItem.BackgroundImage, 0, 0, ApplicationsToolStripMenuItem.BackgroundImage.Width, ApplicationsToolStripMenuItem.BackgroundImage.Height)
        End If
    End Sub

    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        Return ret
    End Function

    Public Sub setuppreview2_0()

        Dim savepath As String = "C:\ShiftOS\"
        'dispose of old skin
        skinloaderskintitlebar(0) = Nothing
        skinloaderskinwindowborderleft(0) = Nothing
        skinloaderskinwindowborderright(0) = Nothing
        skinloaderskinwindowborderbottom(0) = Nothing
        skinloaderskinrollupbutton(1) = Nothing
        skinloaderskinrollupbutton(2) = Nothing
        skinloaderskinrollupbutton(0) = Nothing
        skinloaderskinminimizebutton(0) = Nothing
        skinloaderskinminimizebutton(1) = Nothing
        skinloaderskinminimizebutton(2) = Nothing
        skinloaderskintitlebarrightcorner(0) = Nothing
        skinloaderskintitlebarleftcorner(0) = Nothing
        skinloaderskindesktoppanel(0) = Nothing
        skinloaderskindesktopbackground(0) = Nothing
        skinloaderskinpanelbutton(0) = Nothing
        skinloaderskinapplauncherbutton(0) = Nothing
        skinloaderskindesktoppaneltime(0) = Nothing
        skinloaderskinwindowborderbottomleft(0) = Nothing
        skinloaderskinwindowborderbottomright(0) = Nothing
        skinloaderskinclosebutton(0) = Nothing
        skinloaderskinclosebutton(1) = Nothing
        skinloaderskinclosebutton(2) = Nothing

        If File.Exists(savepath + "Shiftum42\Skins\Preview\titlebar") Then
            skinloaderskintitlebar(0) = GetImage(savepath + "Shiftum42\Skins\Preview\titlebar".Clone)
        Else : skinloaderskintitlebar(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\borderleft") Then
            skinloaderskinwindowborderleft(0) = GetImage(savepath + "Shiftum42\Skins\Preview\borderleft".Clone)
        Else : skinloaderskinwindowborderleft(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\borderright") Then
            skinloaderskinwindowborderright(0) = GetImage(savepath + "Shiftum42\Skins\Preview\borderright".Clone)
        Else : skinloaderskinwindowborderright(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\borderbottom") Then
            skinloaderskinwindowborderbottom(0) = GetImage(savepath + "Shiftum42\Skins\Preview\borderbottom".Clone)
        Else : skinloaderskinwindowborderbottom(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\closebtn") Then
            skinloaderskinclosebutton(0) = GetImage(savepath + "Shiftum42\Skins\Preview\closebtn".Clone)
        Else : skinloaderskinclosebutton(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\closebtnhover") Then
            skinloaderskinclosebutton(1) = GetImage(savepath + "Shiftum42\Skins\Preview\closebtnhover".Clone)
        Else : skinloaderskinclosebutton(1) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\closebtnclick") Then
            skinloaderskinclosebutton(2) = GetImage(savepath + "Shiftum42\Skins\Preview\closebtnclick".Clone)
        Else : skinloaderskinclosebutton(2) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\rollbtn") Then
            skinloaderskinrollupbutton(0) = GetImage(savepath + "Shiftum42\Skins\Preview\rollbtn".Clone)
        Else : skinloaderskinrollupbutton(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\rollbtnhover") Then
            skinloaderskinrollupbutton(1) = GetImage(savepath + "Shiftum42\Skins\Preview\rollbtnhover".Clone)
        Else : skinloaderskinrollupbutton(1) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\rollbtnclick") Then
            skinloaderskinrollupbutton(2) = GetImage(savepath + "Shiftum42\Skins\Preview\rollbtnclick".Clone)
        Else : skinloaderskinrollupbutton(2) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\minbtn") Then
            skinloaderskinminimizebutton(0) = GetImage(savepath + "Shiftum42\Skins\Preview\minbtn".Clone)
        Else : skinloaderskinminimizebutton(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\minbtnhover") Then
            skinloaderskinminimizebutton(1) = GetImage(savepath + "Shiftum42\Skins\Preview\minbtnhover".Clone)
        Else : skinloaderskinminimizebutton(1) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\minbtnclick") Then
            skinloaderskinminimizebutton(2) = GetImage(savepath + "Shiftum42\Skins\Preview\minbtnclick".Clone)
        Else : skinloaderskinminimizebutton(2) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\rightcorner") Then
            skinloaderskintitlebarrightcorner(0) = GetImage(savepath + "Shiftum42\Skins\Preview\rightcorner".Clone)
        Else : skinloaderskintitlebarrightcorner(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\leftcorner") Then
            skinloaderskintitlebarleftcorner(0) = GetImage(savepath + "Shiftum42\Skins\Preview\leftcorner".Clone)
        Else : skinloaderskintitlebarleftcorner(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\desktoppanel") Then
            skinloaderskindesktoppanel(0) = GetImage(savepath + "Shiftum42\Skins\Preview\desktoppanel".Clone)
        Else : skinloaderskindesktoppanel(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\desktopbackground") Then
            skinloaderskindesktopbackground(0) = GetImage(savepath + "Shiftum42\Skins\Preview\desktopbackground".Clone)
        Else : skinloaderskindesktopbackground(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\panelbutton") Then
            skinloaderskinpanelbutton(0) = GetImage(savepath + "Shiftum42\Skins\Preview\panelbutton".Clone)
        Else : skinloaderskinpanelbutton(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\applaunchermouseover") Then
            skinloaderskinapplauncherbutton(1) = GetImage(savepath + "Shiftum42\Skins\Preview\applaunchermouseover".Clone)
        Else : skinloaderskinapplauncherbutton(1) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\applauncher") Then
            skinloaderskinapplauncherbutton(0) = GetImage(savepath + "Shiftum42\Skins\Preview\applauncher".Clone)
        Else : skinloaderskinapplauncherbutton(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\applauncherclick") Then
            skinloaderskinapplauncherbutton(2) = GetImage(savepath + "Shiftum42\Skins\Preview\applauncherclick".Clone)
        Else : skinloaderskinapplauncherbutton(2) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\panelclock") Then
            skinloaderskindesktoppaneltime(0) = GetImage(savepath + "Shiftum42\Skins\Preview\panelclock".Clone)
        Else : skinloaderskindesktoppaneltime(0) = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\bottomleftcorner") Then
            bottomleftcorner = GetImage(savepath + "Shiftum42\Skins\Preview\bottomleftcorner".Clone)
        Else : bottomleftcorner = Nothing
        End If
        If File.Exists(savepath + "Shiftum42\Skins\Preview\bottomrightcorner") Then
            skinloaderskinwindowborderbottomleft(0) = GetImage(savepath + "Shiftum42\Skins\Preview\bottomrightcorner".Clone)
        Else : skinloaderskinwindowborderbottomleft(0) = Nothing
        End If

        'load settings
        Dim loaddata(200) As String
        If File.Exists("C:\ShiftOS\Shiftum42\Skins\Preview\data.dat") Then
            Dim sr As StreamReader = New StreamReader(ShiftOSPath + "Shiftum42\Skins\Preview\data.dat")

            For i As Integer = 0 To 200 Step 1
                loaddata(i) = sr.ReadLine
                If i = 200 Then
                    sr.Close()
                    Exit For
                End If
            Next
            ' settings
            closebuttonheight = loaddata(2)
            closebuttonwidth = loaddata(1)
            rollupbuttonheight = loaddata(4)
            rollupbuttonwidth = loaddata(3)
            minimizebuttonheight = loaddata(6)
            minimizebuttonwidth = loaddata(5)
            titlebarheight = loaddata(7)
            closebuttontop = loaddata(8)
            closebuttonside = loaddata(9)
            rollupbuttontop = loaddata(10)
            rollupbuttonside = loaddata(11)
            minimizebuttontop = loaddata(12)
            minimizebuttonside = loaddata(13)
            windowbordersize = loaddata(14)
            showwindowcorners = loaddata(15)
            titlebarcornerwidth = loaddata(16)
            titlebariconside = loaddata(17)
            titlebaricontop = loaddata(18)
            titletextcolour = Color.FromArgb(loaddata(19))
            windowborderleftcolour = Color.FromArgb(loaddata(20))
            windowborderrightcolour = Color.FromArgb(loaddata(21))
            windowbordercolour = Color.FromArgb(loaddata(20))
            windowborderbottomcolour = Color.FromArgb(loaddata(22))
            closebuttoncolour = Color.FromArgb(loaddata(23))
            closebuttoncolour = Color.FromArgb(loaddata(24))
            closebuttoncolour = Color.FromArgb(loaddata(25))
            rollupbuttoncolour = Color.FromArgb(loaddata(26))
            rollupbuttoncolour = Color.FromArgb(loaddata(27))
            rollupbuttoncolour = Color.FromArgb(loaddata(28))
            minimizebuttoncolour = Color.FromArgb(loaddata(29))
            minimizebuttoncolour = Color.FromArgb(loaddata(30))
            minimizebuttoncolour = Color.FromArgb(loaddata(31))
            titlebarrightcornercolour = Color.FromArgb(loaddata(32))
            titlebarleftcornercolour = Color.FromArgb(loaddata(33))
            windowborderbottomrightcolour = Color.FromArgb(loaddata(34))
            windowborderbottomleftcolour = Color.FromArgb(loaddata(35))
            titletextfont = loaddata(36)
            titletextsize = loaddata(37)
            titletextstyle = loaddata(38)
            titletextpos = loaddata(39)
            titletexttop = loaddata(40)
            titletextside = loaddata(41)
            titletextcolour = Color.FromArgb(loaddata(42))
            desktoppanelcolour = Color.FromArgb(loaddata(43))
            desktopbackgroundcolour = Color.FromArgb(loaddata(44))
            desktoppanelheight = loaddata(45)
            desktoppanelposition = loaddata(46)
            clocktextcolour = Color.FromArgb(loaddata(47))
            clockbackgroundcolor = Color.FromArgb(loaddata(48))
            panelclocktexttop = loaddata(49)
            panelclocktextsize = loaddata(50)
            panelclocktextfont = loaddata(51)
            panelclocktextstyle = loaddata(52)
            applauncherbuttoncolour = Color.FromArgb(loaddata(53))
            applauncherbuttonclickedcolour = Color.FromArgb(loaddata(54))
            applauncherbackgroundcolour = Color.FromArgb(loaddata(55))
            applaunchermouseovercolour = Color.FromArgb(loaddata(56))
            applicationsbuttontextcolour = Color.FromArgb(loaddata(57))
            applicationbuttonheight = loaddata(58)
            applicationbuttontextsize = loaddata(59)
            applicationbuttontextfont = loaddata(60)
            applicationbuttontextstyle = loaddata(61)
            applicationlaunchername = loaddata(62)
            titletextposition = loaddata(63)
            applaunchermenuholderwidth = loaddata(64)
            panelbuttonicontop = loaddata(65)
            panelbuttoniconside = loaddata(66)
            panelbuttoniconsize = loaddata(67)
            panelbuttoncolour = Color.FromArgb(loaddata(70))
            panelbuttonheight = loaddata(68)
            panelbuttonwidth = loaddata(69)
            panelbuttontextcolour = Color.FromArgb(loaddata(71))
            panelbuttontextsize = loaddata(72)
            panelbuttontextfont = loaddata(73)
            panelbuttontextstyle = loaddata(74)
            panelbuttontextside = loaddata(75)
            panelbuttontexttop = loaddata(76)
            panelbuttongap = loaddata(77)
            panelbuttonfromtop = loaddata(78)
            panelbuttoninitialgap = loaddata(79)

            'layout stuff
            skintitlebarstyle = loaddata(89)
            skinwindowborderleftstyle = loaddata(90)
            skinwindowborderrightstyle = loaddata(91)
            skinwindowborderbottomstyle = loaddata(92)
            skinclosebuttonstyle = loaddata(93)
            skinrollupbuttonstyle = loaddata(94)
            skinminimizebuttonstyle = loaddata(95)
            skintitlebarrightcornerstyle = loaddata(96)
            skintitlebarleftcornerstyle = loaddata(97)
            skindesktoppanelstyle = loaddata(98)
            skindesktopbackgroundstyle = loaddata(99)
            skindesktoppaneltimestyle = loaddata(100)
            skinapplauncherbuttonstyle = loaddata(101)
            skinpanelbuttonstyle = loaddata(102)
            skinwindowborderbottomleftstyle = loaddata(103)
            skinwindowborderbottomrightstyle = loaddata(104)
        Else
            infobox.showinfo("Incomplete Skin File", "The settings part of the skin file (data.dat) could not be found, images will be loaded with the current settings and sizes.")
        End If
        setpreviewtocurrentskin()
    End Sub
    Private Sub apply1_0skin()
        ' Set skinning varibles to new values
        ' WINDOWS
        ' Image
        Skins.titlebar = pretitlebar.BackgroundImage
        Skins.titlebarlayout = pretitlebar.BackgroundImageLayout
        Skins.borderleft = prepgleft.BackgroundImage
        Skins.borderleftlayout = prepgleft.BackgroundImageLayout
        Skins.borderright = prepgright.BackgroundImage
        Skins.borderrightlayout = prepgright.BackgroundImageLayout
        Skins.borderbottom = prepgbottom.BackgroundImage
        Skins.borderbottomlayout = prepgbottom.BackgroundImageLayout
        Skins.closebtn = preclosebutton.BackgroundImage
        Skins.closebtnlayout = preclosebutton.BackgroundImageLayout
        Skins.closebtnhover = preclosebutton.BackgroundImage
        Skins.closebtnclick = preclosebutton.BackgroundImage
        Skins.rollbtn = prerollupbutton.BackgroundImage
        Skins.rollbtnlayout = prerollupbutton.BackgroundImageLayout
        Skins.rollbtnhover = prerollupbutton.BackgroundImage
        Skins.rollbtnclick = prerollupbutton.BackgroundImage
        Skins.minbtn = preminimizebutton.BackgroundImage
        Skins.minbtnlayout = preminimizebutton.BackgroundImageLayout
        Skins.minbtnhover = preminimizebutton.BackgroundImage
        Skins.minbtnclick = preminimizebutton.BackgroundImage
        Skins.bottomrightcorner = prepgbottomrcorner.BackgroundImage
        Skins.rightcornerlayout = prepgbottomrcorner.BackgroundImageLayout
        Skins.bottomleftcorner = prepgbottomlcorner.BackgroundImage
        Skins.leftcorner = prepgtoplcorner.BackgroundImage
        Skins.leftcornerlayout = prepgtoplcorner.BackgroundImageLayout
        Skins.rightcorner = prepgtoprcorner.BackgroundImage
        Skins.leftcornerlayout = prepgtoprcorner.BackgroundImageLayout
        'Colour
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
        Skins.bottomrightcornercolour = prepgbottomlcorner.BackColor
        Skins.bottomleftcornercolour = prepgbottomrcorner.BackColor
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
        Skins.applaunchermouseovercolour = applauncherbuttonclickedcolour 'test
        Skins.applicationsbuttontextcolour = applicationsbuttontextcolour
        Skins.applicationbuttonheight = applicationbuttonheight
        Skins.applicationbuttontextsize = applicationbuttontextsize
        Skins.applicationbuttontextfont = applicationbuttontextfont
        Skins.applicationbuttontextstyle = applicationbuttontextstyle
        Skins.applicationlaunchername = applicationlaunchername
        Skins.titletextpos = titletextposition
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
        Skins.desktoppanellayout = 3
        Skins.desktopbackground = pnldesktoppreview.BackgroundImage
        Skins.desktopbackgroundlayout = pnldesktoppreview.BackgroundImageLayout
        Skins.panelclock = pretimepanel.BackgroundImage
        Skins.panelclocklayout = pretimepanel.BackgroundImageLayout
        Skins.applaunchermouseover = ApplicationsToolStripMenuItem.BackgroundImage
        Skins.applauncher = ApplicationsToolStripMenuItem.BackgroundImage
        Skins.applauncherlayout = skinapplauncherbuttonstyle
        Skins.applauncherclick = ApplicationsToolStripMenuItem.BackgroundImage
        Skins.panelbutton = prepnlpanelbutton.BackgroundImage
        Skins.panelbuttonlayout = prepnlpanelbutton.BackgroundImageLayout
        Skins.bottomleftcorner = pgbottomlcorner.BackgroundImage
        Skins.bottomleftcornerlayout = pgbottomlcorner.BackgroundImageLayout
        Skins.bottomrightcorner = pgbottomrcorner.BackgroundImage
        Skins.bottomrightcornerlayout = pgbottomrcorner.BackgroundImageLayout

        ' APPLY
        Skins.saveskinfiles(True)
    End Sub
End Class
