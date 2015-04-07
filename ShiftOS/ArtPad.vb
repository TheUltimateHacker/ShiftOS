Public Class ArtPad
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 502
    Public minimumsizeheight As Integer = 398

    Public codepointsearned As Integer
    Public codepointscooldown As Boolean = False
    Public needtosave As Boolean = False

    Dim canvaswidth As Integer = 150
    Dim canvasheight As Integer = 100
    Public canvasbitmap As New Drawing.Bitmap(canvaswidth, canvasheight)
    Dim canvascolor As Color = Color.White

    Dim previewcanvasbitmap As New Drawing.Bitmap(canvaswidth, canvasheight)

    Dim magnificationlevel As Integer = 1
    Dim magnifyRect As New Rectangle(0, 0, canvaswidth, canvasheight)
    Dim graphicsbitmap As Graphics = Graphics.FromImage(canvasbitmap)
    Public drawingcolour As Color = Color.Black
    Dim selectedtool As String = "Pixel Setter"
    Dim pixalplacermovable As Boolean = False
    Public savelocation As String
    Dim mousePath As New System.Drawing.Drawing2D.GraphicsPath()
    Dim pencilwidth As Integer = 1
    Dim undo As New undo
    Dim backmap As New Drawing.Bitmap(canvaswidth, canvasheight)
    Dim thisPoint As Point

    Dim eracerwidth As Integer = 15
    Dim eracertype As String = "square"

    Dim paintbrushwidth As Integer = 15
    Dim paintbrushtype As String = "circle"

    Dim rectanglestartpointx As Single
    Dim rectanglestartpointy As Single
    Dim currentlydrawingsquare As Boolean
    Dim squarewidth As Integer = 1
    Dim squarefillon As Boolean = False
    Dim fillsquarecolor As Color = Color.Black

    Dim ovalstartpointx As Single
    Dim ovalstartpointy As Single
    Dim currentlydrawingoval As Boolean
    Dim ovalwidth As Integer = 2
    Dim ovalfillon As Boolean = False
    Dim fillovalcolor As Color = Color.Black

    Dim linestartpointx As Single
    Dim linestartpointy As Single
    Dim currentlydrawingline As Boolean
    Dim linewidth As Integer = 2

    Dim currentlydrawingtext As Boolean
    Dim drawtextfont As New System.Drawing.Font("Microsoft Sans Serif", 16)
    Dim drawtextsize As Integer
    Dim drawtextfontname As String
    Dim drawtextfontstyle As FontStyle

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        setuppreview()
        settoolcolours()
        loadcolors()
        AddFonts()
        setuptoolbox()
        determinevisiblepallets()
        setuppallets()

        If ShiftOSDesktop.ArtpadCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")
        ShiftOSDesktop.pnlpanelbuttonartpad.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonartpad, ShiftOSDesktop.tbartpadicon, ShiftOSDesktop.tbartpadtext, True) 'modify to proper name
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

        'Fix growing window bug
        'If justopened = False Then
        '    Me.Size = New Size(Me.Size.Width, Me.Size.Height - Skins.titlebarheight)
        'End If

        If justopened = True Then
            Me.Size = New Size(800, 600) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
            Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
            oldbordersize = Skins.borderwidth
            oldtitlebarheight = Skins.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                Me.Hide()
                Me.Size = New Size(Me.Width, Me.Height - oldtitlebarheight + 30)
                Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize)
                oldbordersize = Skins.borderwidth
                oldtitlebarheight = Skins.titlebarheight
                Me.Size = New Size(Me.Width, Me.Height + Skins.titlebarheight - 30)
                Me.Size = New Size(Me.Width + Skins.borderwidth + Skins.borderwidth, Me.Height + Skins.borderwidth)
                rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                Me.Show()
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
            lbtitletext.Text = ShiftOSDesktop.artpadname 'Remember to change to name of program!!!!
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

        If ShiftOSDesktop.boughtartpadicon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.artpadicontitlebar  'Replace with the correct icon for the program.
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

    Public Sub setupcanvas()
        canvasbitmap = New Drawing.Bitmap(canvaswidth, canvasheight)
        previewcanvasbitmap = New Drawing.Bitmap(canvaswidth, canvasheight)
        picdrawingdisplay.Size = New Size(canvaswidth, canvasheight)
        picdrawingdisplay.Location = New Point((pnldrawingbackground.Width - canvaswidth) / 2, (pnldrawingbackground.Height - canvasheight) / 2)
        graphicsbitmap = Graphics.FromImage(canvasbitmap)
        Dim canvasbrush As New SolidBrush(canvascolor)
        graphicsbitmap.FillRectangle(canvasbrush, 0, 0, canvaswidth, canvasheight)
        magnificationlevel = 1
        lblzoomlevel.Text = magnificationlevel & "X"
        setuppreview()
        needtosave = False
    End Sub

    Public Sub setuptoolbox()
        btnpixelplacer.Hide()
        btnpencil.Hide()
        btnfloodfill.Hide()
        btnoval.Hide()
        btnsquare.Hide()
        btnlinetool.Hide()
        btnpaintbrush.Hide()
        btntexttool.Hide()
        btneracer.Hide()
        btnnew.Hide()
        btnopen.Hide()
        btnsave.Hide()
        btnundo.Hide()
        btnredo.Hide()
        btnpixelplacermovementmode.Hide()

        If ShiftOSDesktop.boughtartpadpixelplacer = True Then btnpixelplacer.Show()
        If ShiftOSDesktop.boughtartpadpencil = True Then btnpencil.Show()
        If ShiftOSDesktop.boughtartpadfilltool = True Then btnfloodfill.Show()
        If ShiftOSDesktop.boughtartpadovaltool = True Then btnoval.Show()
        If ShiftOSDesktop.boughtartpadrectangletool = True Then btnsquare.Show()
        If ShiftOSDesktop.boughtartpadlinetool = True Then btnlinetool.Show()
        If ShiftOSDesktop.boughtartpadpaintbrush = True Then btnpaintbrush.Show()
        If ShiftOSDesktop.boughtartpadtexttool = True Then btntexttool.Show()
        If ShiftOSDesktop.boughtartpaderaser = True Then btneracer.Show()
        If ShiftOSDesktop.boughtartpadnew = True Then btnnew.Show()
        If ShiftOSDesktop.boughtartpadload = True Then btnopen.Show()
        If ShiftOSDesktop.boughtartpadsave = True Then btnsave.Show()
        If ShiftOSDesktop.boughtartpadundo = True Then btnundo.Show()
        If ShiftOSDesktop.boughtartpadredo = True Then btnredo.Show()
        If ShiftOSDesktop.boughtartpadpixelplacermovementmode = True Then btnpixelplacermovementmode.Show()

    End Sub

    Private Sub AddFonts()
        ' Get the installed fonts collection.
        Dim allFonts As New Drawing.Text.InstalledFontCollection

        ' Get an array of the system's font familiies.
        Dim fontFamilies() As FontFamily = allFonts.Families()

        ' Display the font families.
        For Each myFont As FontFamily In fontFamilies
            combodrawtextfont.Items.Add(myFont.Name)
        Next 'font_family

        combodrawtextfont.SelectedItem = combodrawtextfont.Items(1)
        combofontstyle.Text = "Regular"
        txtdrawtextsize.Text = 16
    End Sub

    Private Sub btnpixelsetter_Click(sender As Object, e As EventArgs) Handles btnpixelsetter.Click
        selectedtool = "Pixel Setter"
        gettoolsettings(pnlpixelsettersettings)
    End Sub

    Private Sub gettoolsettings(ByVal toolpanel As Panel)
        'hide all properties panels
        pnlpixelsettersettings.Hide()
        pnlmagnifiersettings.Hide()

        'show chosen panel
        toolpanel.Dock = DockStyle.Fill
        toolpanel.BringToFront()
        toolpanel.Show()

        setuppreview()
    End Sub

    Private Sub btnpixelsettersetpixel_Click(sender As Object, e As EventArgs) Handles btnpixelsettersetpixel.Click
        Try
            undo.undoStack.Push(canvasbitmap.Clone)
            undo.redoStack.Clear()
            canvasbitmap.SetPixel(txtpixelsetterxcoordinate.Text, txtpixelsetterycoordinate.Text, drawingcolour)
            picdrawingdisplay.Invalidate()
        Catch ex As Exception
            infobox.title = "ArtPad - Placement Error!"
            infobox.textinfo = "You have specified invalid coordinates for the pixel setter." & Environment.NewLine & Environment.NewLine & "Remember that the top left pixel has the coordinates 0, 0"
            infobox.Show()
        End Try
    End Sub

    Private Sub btnmagnify_Click(sender As Object, e As EventArgs) Handles btnmagnify.Click
        selectedtool = "Magnifier"
        gettoolsettings(pnlmagnifiersettings)
    End Sub

    Private Sub picdrawingdisplay_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles picdrawingdisplay.Paint
        e.Graphics.FillRectangle(Brushes.White, 0, 0, canvaswidth * magnificationlevel, canvasheight * magnificationlevel)
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half
        e.Graphics.ScaleTransform(magnificationlevel, magnificationlevel)

        If currentlydrawingsquare = True Then
            GC.Collect()
            Dim g As Graphics = Graphics.FromImage(previewcanvasbitmap)
            previewcanvasbitmap = New Bitmap(canvasbitmap.Width, canvasbitmap.Height)
            g = Graphics.FromImage(previewcanvasbitmap)
            Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), squarewidth)
            Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, fillsquarecolor))
            Dim rectdraw As New RectangleF(rectanglestartpointx, rectanglestartpointy, thisPoint.X - rectanglestartpointx, thisPoint.Y - rectanglestartpointy)
            Dim heightamount, widthamount As Integer
            If rectdraw.Height < 0 Then heightamount = Math.Abs(rectdraw.Height) Else heightamount = 0
            If rectdraw.Width < 0 Then widthamount = Math.Abs(rectdraw.Width) Else widthamount = 0
            If squarewidth > 0 Then
                g.DrawRectangle(CurrentPen, rectdraw.X - widthamount, rectdraw.Y - heightamount, Math.Abs(rectdraw.Width), Math.Abs(rectdraw.Height))
            End If
            If squarefillon = True Then
                Dim correctionamount As Single = squarewidth / 2
                Dim addfillamount As Integer
                If squarewidth > 0 Then addfillamount = squarewidth Else addfillamount = -1
                g.FillRectangle(CurrentBrush, (rectdraw.X - widthamount) + correctionamount, (rectdraw.Y - heightamount) + correctionamount, Math.Abs(rectdraw.Width) - addfillamount, Math.Abs(rectdraw.Height) - addfillamount)
            End If
        End If

        If currentlydrawingoval = True Then
            GC.Collect()
            Dim g As Graphics = Graphics.FromImage(previewcanvasbitmap)
            previewcanvasbitmap = New Bitmap(canvasbitmap.Width, canvasbitmap.Height)
            g = Graphics.FromImage(previewcanvasbitmap)
            Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), ovalwidth)
            Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, fillovalcolor))
            Dim ovaldraw As New RectangleF(ovalstartpointx, ovalstartpointy, thisPoint.X - ovalstartpointx, thisPoint.Y - ovalstartpointy)
            Dim heightamount, widthamount As Integer
            If ovaldraw.Height < 0 Then heightamount = Math.Abs(ovaldraw.Height) Else heightamount = 0
            If ovaldraw.Width < 0 Then widthamount = Math.Abs(ovaldraw.Width) Else widthamount = 0
            If ovalwidth > 0 Then
                g.DrawEllipse(CurrentPen, ovaldraw.X - widthamount, ovaldraw.Y - heightamount, Math.Abs(ovaldraw.Width), Math.Abs(ovaldraw.Height))
            End If
            If ovalfillon = True Then
                g.FillEllipse(CurrentBrush, (ovaldraw.X - widthamount), (ovaldraw.Y - heightamount), Math.Abs(ovaldraw.Width), Math.Abs(ovaldraw.Height))
            End If
        End If

        If currentlydrawingline = True Then
            GC.Collect()
            Dim g As Graphics = Graphics.FromImage(previewcanvasbitmap)
            previewcanvasbitmap = New Bitmap(canvasbitmap.Width, canvasbitmap.Height)
            g = Graphics.FromImage(previewcanvasbitmap)
            Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), linewidth)
            g.DrawLine(CurrentPen, linestartpointx, linestartpointy, thisPoint.X, thisPoint.Y)
        End If

        If currentlydrawingtext = True Then
            GC.Collect()
            Dim g As Graphics = Graphics.FromImage(previewcanvasbitmap)
            previewcanvasbitmap = New Bitmap(canvasbitmap.Width, canvasbitmap.Height)
            g = Graphics.FromImage(previewcanvasbitmap)
            Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, drawingcolour))
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
            drawtextfont = New System.Drawing.Font(drawtextfontname, drawtextsize, drawtextfontstyle)
            g.DrawString(txtdrawstringtext.Text, drawtextfont, CurrentBrush, thisPoint.X, thisPoint.Y)
        End If
        Try
            e.Graphics.DrawImage(canvasbitmap, 0, 0)
            e.Graphics.DrawImage(previewcanvasbitmap, 0, 0)
        Catch ex As System.OutOfMemoryException
            OutOfMemory()
        End Try
    End Sub


    Private Sub picdrawingdisplay_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picdrawingdisplay.MouseDown

        undo.undoStack.Push(canvasbitmap.Clone)
        undo.redoStack.Clear()


        thisPoint.X = CInt((e.Location.X - (magnificationlevel / 2)) / magnificationlevel)
        thisPoint.Y = CInt((e.Location.Y - (magnificationlevel / 2)) / magnificationlevel)

        If selectedtool = "Pixel Placer" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If thisPoint.X < canvasbitmap.Width AndAlso thisPoint.X > -1 Then
                    If thisPoint.Y < canvasbitmap.Height AndAlso thisPoint.Y > -1 Then
                        canvasbitmap.SetPixel(thisPoint.X, thisPoint.Y, drawingcolour) 'set the pixel on the canvas
                        picdrawingdisplay.Invalidate()                              'refresh the picture from the canvas
                    End If
                End If
            End If
        End If

        If selectedtool = "Pencil" Then
            If e.Button = MouseButtons.Left Then
                mousePath.StartFigure()
                picdrawingdisplay.Invalidate()
            End If
        End If

        If selectedtool = "Flood Fill" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If thisPoint.X < canvasbitmap.Width AndAlso thisPoint.X > -1 Then
                    If thisPoint.Y < canvasbitmap.Height AndAlso thisPoint.Y > -1 Then
                        SafeFloodFill(canvasbitmap, thisPoint.X, thisPoint.Y, drawingcolour)
                        graphicsbitmap = Graphics.FromImage(canvasbitmap)
                        picdrawingdisplay.Invalidate()
                    End If
                End If
            End If
        End If

        If selectedtool = "Square Tool" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                rectanglestartpointx = thisPoint.X
                rectanglestartpointy = thisPoint.Y
                currentlydrawingsquare = True
                picdrawingdisplay.Invalidate()
            End If
        End If

        If selectedtool = "Oval Tool" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ovalstartpointx = thisPoint.X
                ovalstartpointy = thisPoint.Y
                currentlydrawingoval = True
                picdrawingdisplay.Invalidate()
            End If
        End If

        If selectedtool = "Line Tool" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                linestartpointx = thisPoint.X
                linestartpointy = thisPoint.Y
                currentlydrawingline = True
                picdrawingdisplay.Invalidate()
            End If
        End If

        If selectedtool = "Text Tool" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                currentlydrawingtext = True
                picdrawingdisplay.Invalidate()
            End If
        End If

        If selectedtool = "Eracer" Then
            Dim CurrentPen = New Pen(Color.FromArgb(255, canvascolor), eracerwidth)
            Dim halfsize As Single = eracerwidth / 2
            If eracertype = "circle" Then
                graphicsbitmap.DrawEllipse(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth)
            Else
                graphicsbitmap.DrawRectangle(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth)
            End If
            picdrawingdisplay.Invalidate()
        End If

        If selectedtool = "Paint Brush" Then
            Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, drawingcolour))
            Dim halfsize As Single = paintbrushwidth / 2
            If paintbrushtype = "circle" Then
                graphicsbitmap.FillEllipse(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth)
            Else
                graphicsbitmap.FillRectangle(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth)
            End If
            picdrawingdisplay.Invalidate()
            CurrentBrush.Dispose()
        End If
        preparecooldown()
    End Sub

    Private Sub picdrawingdisplay_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picdrawingdisplay.MouseMove
        Static lastpoint As Point

        thisPoint.X = CInt((e.Location.X - (magnificationlevel / 2)) / magnificationlevel)
        thisPoint.Y = CInt((e.Location.Y - (magnificationlevel / 2)) / magnificationlevel)


        If e.Button = Windows.Forms.MouseButtons.Left Then
            undo.redoStack.Clear()
            lastpoint = thisPoint
            preparecooldown()

            If selectedtool = "Pixel Placer" AndAlso pixalplacermovable = True Then
                If thisPoint.X < canvasbitmap.Width AndAlso thisPoint.X > -1 Then
                    If thisPoint.Y < canvasbitmap.Height AndAlso thisPoint.Y > -1 Then
                        canvasbitmap.SetPixel(thisPoint.X, thisPoint.Y, drawingcolour) 'set the pixel on the canvas
                        picdrawingdisplay.Invalidate()                              'refresh the picture from the canvas
                    End If
                End If
            End If

            If selectedtool = "Pencil" Then
                mousePath.AddLine(thisPoint.X, thisPoint.Y, thisPoint.X, thisPoint.Y)
                Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), pencilwidth)
                graphicsbitmap.DrawPath(CurrentPen, mousePath)
                picdrawingdisplay.Invalidate()
            End If

            If selectedtool = "Square Tool" Then
                picdrawingdisplay.Invalidate()
            End If

            If selectedtool = "Oval Tool" Then
                picdrawingdisplay.Invalidate()
            End If

            If selectedtool = "Line Tool" Then
                picdrawingdisplay.Invalidate()
            End If

            If selectedtool = "Text Tool" Then
                picdrawingdisplay.Invalidate()
            End If

            If selectedtool = "Eracer" Then
                Dim CurrentPen = New Pen(Color.FromArgb(255, canvascolor), eracerwidth)
                Dim halfsize As Single = eracerwidth / 2
                If eracertype = "circle" Then
                    graphicsbitmap.DrawEllipse(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth)
                Else
                    graphicsbitmap.DrawRectangle(CurrentPen, thisPoint.X - halfsize, thisPoint.Y - halfsize, eracerwidth, eracerwidth)
                End If
                picdrawingdisplay.Invalidate()
            End If

            If selectedtool = "Paint Brush" Then
                Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, drawingcolour))
                Dim halfsize As Single = paintbrushwidth / 2
                If paintbrushtype = "circle" Then
                    graphicsbitmap.FillEllipse(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth)
                Else
                    graphicsbitmap.FillRectangle(CurrentBrush, thisPoint.X - halfsize, thisPoint.Y - halfsize, paintbrushwidth, paintbrushwidth)
                End If
                picdrawingdisplay.Invalidate()
            End If
        End If

    End Sub

    Private Sub picdrawingdisplay_MouseUp(sender As Object, e As MouseEventArgs) Handles picdrawingdisplay.MouseUp

        thisPoint.X = CInt((e.Location.X - (magnificationlevel / 2)) / magnificationlevel)
        thisPoint.Y = CInt((e.Location.Y - (magnificationlevel / 2)) / magnificationlevel)

        If selectedtool = "Pencil" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                mousePath.Reset()
            End If
        End If

        If selectedtool = "Square Tool" Then
            picdrawingdisplay.Invalidate()
            currentlydrawingsquare = False
        End If

        If selectedtool = "Oval Tool" Then
            picdrawingdisplay.Invalidate()
            currentlydrawingoval = False
        End If


        If selectedtool = "Line Tool" Then
            picdrawingdisplay.Invalidate()
            currentlydrawingline = False
        End If

        If selectedtool = "Text Tool" Then
            picdrawingdisplay.Invalidate()
            currentlydrawingtext = False
        End If

        Using g As Graphics = Graphics.FromImage(canvasbitmap)
            g.DrawImage(previewcanvasbitmap, 0, 0)
        End Using
        previewcanvasbitmap = New Bitmap(canvasbitmap.Width, canvasbitmap.Height)
        picdrawingdisplay.Invalidate()
        preparecooldown()

    End Sub

    Private Sub colourpallet1_Paint(sender As Object, e As MouseEventArgs) Handles colourpallet1.Click, colourpallet2.Click, colourpallet3.Click, colourpallet4.Click, colourpallet5.Click, colourpallet6.Click, colourpallet7.Click, colourpallet8.Click, colourpallet9.Click, colourpallet10.Click, colourpallet11.Click, colourpallet12.Click, colourpallet13.Click, colourpallet14.Click, colourpallet15.Click, colourpallet16.Click, colourpallet17.Click, colourpallet18.Click, colourpallet19.Click, colourpallet20.Click, colourpallet21.Click, colourpallet22.Click, colourpallet23.Click, colourpallet24.Click, colourpallet25.Click, colourpallet26.Click, colourpallet27.Click, colourpallet28.Click, colourpallet29.Click, colourpallet30.Click, colourpallet31.Click, colourpallet32.Click, colourpallet33.Click, colourpallet34.Click, colourpallet35.Click, colourpallet36.Click, colourpallet37.Click, colourpallet38.Click, colourpallet39.Click, colourpallet40.Click, colourpallet41.Click, colourpallet42.Click, colourpallet43.Click, colourpallet44.Click, colourpallet45.Click, colourpallet46.Click, colourpallet47.Click, colourpallet48.Click, colourpallet49.Click, colourpallet50.Click, colourpallet51.Click, colourpallet52.Click, colourpallet53.Click, colourpallet54.Click, colourpallet55.Click, colourpallet56.Click, colourpallet57.Click, colourpallet58.Click, colourpallet59.Click, colourpallet60.Click, colourpallet61.Click, colourpallet62.Click, colourpallet63.Click, colourpallet64.Click, colourpallet65.Click, colourpallet66.Click, colourpallet67.Click, colourpallet68.Click, colourpallet69.Click, colourpallet70.Click, colourpallet71.Click, colourpallet72.Click, colourpallet73.Click, colourpallet74.Click, colourpallet75.Click, colourpallet76.Click, colourpallet77.Click, colourpallet78.Click, colourpallet79.Click, colourpallet80.Click, colourpallet81.Click, colourpallet82.Click, colourpallet83.Click, colourpallet84.Click, colourpallet85.Click, colourpallet86.Click, colourpallet87.Click, colourpallet88.Click, colourpallet89.Click, colourpallet90.Click, colourpallet91.Click, colourpallet92.Click, colourpallet93.Click, colourpallet94.Click, colourpallet95.Click, colourpallet96.Click, colourpallet97.Click, colourpallet98.Click, colourpallet99.Click, colourpallet100.Click, colourpallet101.Click, colourpallet102.Click, colourpallet103.Click, colourpallet104.Click, colourpallet105.Click, colourpallet106.Click, colourpallet107.Click, colourpallet108.Click, colourpallet109.Click, colourpallet110.Click, colourpallet111.Click, colourpallet112.Click, colourpallet113.Click, colourpallet114.Click, colourpallet115.Click, colourpallet116.Click, colourpallet117.Click, colourpallet118.Click, colourpallet119.Click, colourpallet120.Click, colourpallet121.Click, colourpallet122.Click, colourpallet123.Click, colourpallet124.Click, colourpallet125.Click, colourpallet126.Click, colourpallet127.Click, colourpallet128.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            drawingcolour = sender.backcolor
            setuppreview()
            settoolcolours()
        ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
            If ShiftOSDesktop.boughtartpadcustompallets = True Then
                pnlpalletsize.Show()
                txtcolorpalletheight.Text = colourpallet1.Height
                txtcolorpalletwidth.Text = colourpallet1.Width
                txtsidespace.Text = colourpallet1.Margin.Left
                txttopspace.Text = colourpallet1.Margin.Bottom
            End If
        Else
            Select Case sender.name.ToString
                Case "colourpallet1" : Colour_Picker.colourtochange = "artpallet1" : Colour_Picker.oldcolour = colourpallet1.BackColor
                Case "colourpallet2" : Colour_Picker.colourtochange = "artpallet2" : Colour_Picker.oldcolour = colourpallet2.BackColor
                Case "colourpallet3" : Colour_Picker.colourtochange = "artpallet3" : Colour_Picker.oldcolour = colourpallet3.BackColor
                Case "colourpallet4" : Colour_Picker.colourtochange = "artpallet4" : Colour_Picker.oldcolour = colourpallet4.BackColor
                Case "colourpallet5" : Colour_Picker.colourtochange = "artpallet5" : Colour_Picker.oldcolour = colourpallet5.BackColor
                Case "colourpallet6" : Colour_Picker.colourtochange = "artpallet6" : Colour_Picker.oldcolour = colourpallet6.BackColor
                Case "colourpallet7" : Colour_Picker.colourtochange = "artpallet7" : Colour_Picker.oldcolour = colourpallet7.BackColor
                Case "colourpallet8" : Colour_Picker.colourtochange = "artpallet8" : Colour_Picker.oldcolour = colourpallet8.BackColor
                Case "colourpallet9" : Colour_Picker.colourtochange = "artpallet9" : Colour_Picker.oldcolour = colourpallet9.BackColor
                Case "colourpallet10" : Colour_Picker.colourtochange = "artpallet10" : Colour_Picker.oldcolour = colourpallet10.BackColor
                Case "colourpallet11" : Colour_Picker.colourtochange = "artpallet11" : Colour_Picker.oldcolour = colourpallet11.BackColor
                Case "colourpallet12" : Colour_Picker.colourtochange = "artpallet12" : Colour_Picker.oldcolour = colourpallet12.BackColor
                Case "colourpallet13" : Colour_Picker.colourtochange = "artpallet13" : Colour_Picker.oldcolour = colourpallet13.BackColor
                Case "colourpallet14" : Colour_Picker.colourtochange = "artpallet14" : Colour_Picker.oldcolour = colourpallet14.BackColor
                Case "colourpallet15" : Colour_Picker.colourtochange = "artpallet15" : Colour_Picker.oldcolour = colourpallet15.BackColor
                Case "colourpallet16" : Colour_Picker.colourtochange = "artpallet16" : Colour_Picker.oldcolour = colourpallet16.BackColor
                Case "colourpallet17" : Colour_Picker.colourtochange = "artpallet17" : Colour_Picker.oldcolour = colourpallet17.BackColor
                Case "colourpallet18" : Colour_Picker.colourtochange = "artpallet18" : Colour_Picker.oldcolour = colourpallet18.BackColor
                Case "colourpallet19" : Colour_Picker.colourtochange = "artpallet19" : Colour_Picker.oldcolour = colourpallet19.BackColor
                Case "colourpallet20" : Colour_Picker.colourtochange = "artpallet20" : Colour_Picker.oldcolour = colourpallet20.BackColor
                Case "colourpallet21" : Colour_Picker.colourtochange = "artpallet21" : Colour_Picker.oldcolour = colourpallet21.BackColor
                Case "colourpallet22" : Colour_Picker.colourtochange = "artpallet22" : Colour_Picker.oldcolour = colourpallet22.BackColor
                Case "colourpallet23" : Colour_Picker.colourtochange = "artpallet23" : Colour_Picker.oldcolour = colourpallet23.BackColor
                Case "colourpallet24" : Colour_Picker.colourtochange = "artpallet24" : Colour_Picker.oldcolour = colourpallet24.BackColor
                Case "colourpallet25" : Colour_Picker.colourtochange = "artpallet25" : Colour_Picker.oldcolour = colourpallet25.BackColor
                Case "colourpallet26" : Colour_Picker.colourtochange = "artpallet26" : Colour_Picker.oldcolour = colourpallet26.BackColor
                Case "colourpallet27" : Colour_Picker.colourtochange = "artpallet27" : Colour_Picker.oldcolour = colourpallet27.BackColor
                Case "colourpallet28" : Colour_Picker.colourtochange = "artpallet28" : Colour_Picker.oldcolour = colourpallet28.BackColor
                Case "colourpallet29" : Colour_Picker.colourtochange = "artpallet29" : Colour_Picker.oldcolour = colourpallet29.BackColor
                Case "colourpallet30" : Colour_Picker.colourtochange = "artpallet30" : Colour_Picker.oldcolour = colourpallet30.BackColor
                Case "colourpallet31" : Colour_Picker.colourtochange = "artpallet31" : Colour_Picker.oldcolour = colourpallet31.BackColor
                Case "colourpallet32" : Colour_Picker.colourtochange = "artpallet32" : Colour_Picker.oldcolour = colourpallet32.BackColor
                Case "colourpallet33" : Colour_Picker.colourtochange = "artpallet33" : Colour_Picker.oldcolour = colourpallet33.BackColor
                Case "colourpallet34" : Colour_Picker.colourtochange = "artpallet34" : Colour_Picker.oldcolour = colourpallet34.BackColor
                Case "colourpallet35" : Colour_Picker.colourtochange = "artpallet35" : Colour_Picker.oldcolour = colourpallet35.BackColor
                Case "colourpallet36" : Colour_Picker.colourtochange = "artpallet36" : Colour_Picker.oldcolour = colourpallet36.BackColor
                Case "colourpallet37" : Colour_Picker.colourtochange = "artpallet37" : Colour_Picker.oldcolour = colourpallet37.BackColor
                Case "colourpallet38" : Colour_Picker.colourtochange = "artpallet38" : Colour_Picker.oldcolour = colourpallet38.BackColor
                Case "colourpallet39" : Colour_Picker.colourtochange = "artpallet39" : Colour_Picker.oldcolour = colourpallet39.BackColor
                Case "colourpallet40" : Colour_Picker.colourtochange = "artpallet40" : Colour_Picker.oldcolour = colourpallet40.BackColor
                Case "colourpallet41" : Colour_Picker.colourtochange = "artpallet41" : Colour_Picker.oldcolour = colourpallet41.BackColor
                Case "colourpallet42" : Colour_Picker.colourtochange = "artpallet42" : Colour_Picker.oldcolour = colourpallet42.BackColor
                Case "colourpallet43" : Colour_Picker.colourtochange = "artpallet43" : Colour_Picker.oldcolour = colourpallet43.BackColor
                Case "colourpallet44" : Colour_Picker.colourtochange = "artpallet44" : Colour_Picker.oldcolour = colourpallet44.BackColor
                Case "colourpallet45" : Colour_Picker.colourtochange = "artpallet45" : Colour_Picker.oldcolour = colourpallet45.BackColor
                Case "colourpallet46" : Colour_Picker.colourtochange = "artpallet46" : Colour_Picker.oldcolour = colourpallet46.BackColor
                Case "colourpallet47" : Colour_Picker.colourtochange = "artpallet47" : Colour_Picker.oldcolour = colourpallet47.BackColor
                Case "colourpallet48" : Colour_Picker.colourtochange = "artpallet48" : Colour_Picker.oldcolour = colourpallet48.BackColor
                Case "colourpallet49" : Colour_Picker.colourtochange = "artpallet49" : Colour_Picker.oldcolour = colourpallet49.BackColor
                Case "colourpallet50" : Colour_Picker.colourtochange = "artpallet50" : Colour_Picker.oldcolour = colourpallet50.BackColor
                Case "colourpallet51" : Colour_Picker.colourtochange = "artpallet51" : Colour_Picker.oldcolour = colourpallet51.BackColor
                Case "colourpallet52" : Colour_Picker.colourtochange = "artpallet52" : Colour_Picker.oldcolour = colourpallet52.BackColor
                Case "colourpallet53" : Colour_Picker.colourtochange = "artpallet53" : Colour_Picker.oldcolour = colourpallet53.BackColor
                Case "colourpallet54" : Colour_Picker.colourtochange = "artpallet54" : Colour_Picker.oldcolour = colourpallet54.BackColor
                Case "colourpallet55" : Colour_Picker.colourtochange = "artpallet55" : Colour_Picker.oldcolour = colourpallet55.BackColor
                Case "colourpallet56" : Colour_Picker.colourtochange = "artpallet56" : Colour_Picker.oldcolour = colourpallet56.BackColor
                Case "colourpallet57" : Colour_Picker.colourtochange = "artpallet57" : Colour_Picker.oldcolour = colourpallet57.BackColor
                Case "colourpallet58" : Colour_Picker.colourtochange = "artpallet58" : Colour_Picker.oldcolour = colourpallet58.BackColor
                Case "colourpallet59" : Colour_Picker.colourtochange = "artpallet59" : Colour_Picker.oldcolour = colourpallet59.BackColor
                Case "colourpallet60" : Colour_Picker.colourtochange = "artpallet60" : Colour_Picker.oldcolour = colourpallet60.BackColor
                Case "colourpallet61" : Colour_Picker.colourtochange = "artpallet61" : Colour_Picker.oldcolour = colourpallet61.BackColor
                Case "colourpallet62" : Colour_Picker.colourtochange = "artpallet62" : Colour_Picker.oldcolour = colourpallet62.BackColor
                Case "colourpallet63" : Colour_Picker.colourtochange = "artpallet63" : Colour_Picker.oldcolour = colourpallet63.BackColor
                Case "colourpallet64" : Colour_Picker.colourtochange = "artpallet64" : Colour_Picker.oldcolour = colourpallet64.BackColor
                Case "colourpallet65" : Colour_Picker.colourtochange = "artpallet65" : Colour_Picker.oldcolour = colourpallet65.BackColor
                Case "colourpallet66" : Colour_Picker.colourtochange = "artpallet66" : Colour_Picker.oldcolour = colourpallet66.BackColor
                Case "colourpallet67" : Colour_Picker.colourtochange = "artpallet67" : Colour_Picker.oldcolour = colourpallet67.BackColor
                Case "colourpallet68" : Colour_Picker.colourtochange = "artpallet68" : Colour_Picker.oldcolour = colourpallet68.BackColor
                Case "colourpallet69" : Colour_Picker.colourtochange = "artpallet69" : Colour_Picker.oldcolour = colourpallet69.BackColor
                Case "colourpallet70" : Colour_Picker.colourtochange = "artpallet70" : Colour_Picker.oldcolour = colourpallet70.BackColor
                Case "colourpallet71" : Colour_Picker.colourtochange = "artpallet71" : Colour_Picker.oldcolour = colourpallet71.BackColor
                Case "colourpallet72" : Colour_Picker.colourtochange = "artpallet72" : Colour_Picker.oldcolour = colourpallet72.BackColor
                Case "colourpallet73" : Colour_Picker.colourtochange = "artpallet73" : Colour_Picker.oldcolour = colourpallet73.BackColor
                Case "colourpallet74" : Colour_Picker.colourtochange = "artpallet74" : Colour_Picker.oldcolour = colourpallet74.BackColor
                Case "colourpallet75" : Colour_Picker.colourtochange = "artpallet75" : Colour_Picker.oldcolour = colourpallet75.BackColor
                Case "colourpallet76" : Colour_Picker.colourtochange = "artpallet76" : Colour_Picker.oldcolour = colourpallet76.BackColor
                Case "colourpallet77" : Colour_Picker.colourtochange = "artpallet77" : Colour_Picker.oldcolour = colourpallet77.BackColor
                Case "colourpallet78" : Colour_Picker.colourtochange = "artpallet78" : Colour_Picker.oldcolour = colourpallet78.BackColor
                Case "colourpallet79" : Colour_Picker.colourtochange = "artpallet79" : Colour_Picker.oldcolour = colourpallet79.BackColor
                Case "colourpallet80" : Colour_Picker.colourtochange = "artpallet80" : Colour_Picker.oldcolour = colourpallet80.BackColor
                Case "colourpallet81" : Colour_Picker.colourtochange = "artpallet81" : Colour_Picker.oldcolour = colourpallet81.BackColor
                Case "colourpallet82" : Colour_Picker.colourtochange = "artpallet82" : Colour_Picker.oldcolour = colourpallet82.BackColor
                Case "colourpallet83" : Colour_Picker.colourtochange = "artpallet83" : Colour_Picker.oldcolour = colourpallet83.BackColor
                Case "colourpallet84" : Colour_Picker.colourtochange = "artpallet84" : Colour_Picker.oldcolour = colourpallet84.BackColor
                Case "colourpallet85" : Colour_Picker.colourtochange = "artpallet85" : Colour_Picker.oldcolour = colourpallet85.BackColor
                Case "colourpallet86" : Colour_Picker.colourtochange = "artpallet86" : Colour_Picker.oldcolour = colourpallet86.BackColor
                Case "colourpallet87" : Colour_Picker.colourtochange = "artpallet87" : Colour_Picker.oldcolour = colourpallet87.BackColor
                Case "colourpallet88" : Colour_Picker.colourtochange = "artpallet88" : Colour_Picker.oldcolour = colourpallet88.BackColor
                Case "colourpallet89" : Colour_Picker.colourtochange = "artpallet89" : Colour_Picker.oldcolour = colourpallet89.BackColor
                Case "colourpallet90" : Colour_Picker.colourtochange = "artpallet90" : Colour_Picker.oldcolour = colourpallet90.BackColor
                Case "colourpallet91" : Colour_Picker.colourtochange = "artpallet91" : Colour_Picker.oldcolour = colourpallet91.BackColor
                Case "colourpallet92" : Colour_Picker.colourtochange = "artpallet92" : Colour_Picker.oldcolour = colourpallet92.BackColor
                Case "colourpallet93" : Colour_Picker.colourtochange = "artpallet93" : Colour_Picker.oldcolour = colourpallet93.BackColor
                Case "colourpallet94" : Colour_Picker.colourtochange = "artpallet94" : Colour_Picker.oldcolour = colourpallet94.BackColor
                Case "colourpallet95" : Colour_Picker.colourtochange = "artpallet95" : Colour_Picker.oldcolour = colourpallet95.BackColor
                Case "colourpallet96" : Colour_Picker.colourtochange = "artpallet96" : Colour_Picker.oldcolour = colourpallet96.BackColor
                Case "colourpallet97" : Colour_Picker.colourtochange = "artpallet97" : Colour_Picker.oldcolour = colourpallet97.BackColor
                Case "colourpallet98" : Colour_Picker.colourtochange = "artpallet98" : Colour_Picker.oldcolour = colourpallet98.BackColor
                Case "colourpallet99" : Colour_Picker.colourtochange = "artpallet99" : Colour_Picker.oldcolour = colourpallet99.BackColor
                Case "colourpallet100" : Colour_Picker.colourtochange = "artpallet100" : Colour_Picker.oldcolour = colourpallet100.BackColor
                Case "colourpallet101" : Colour_Picker.colourtochange = "artpallet101" : Colour_Picker.oldcolour = colourpallet101.BackColor
                Case "colourpallet102" : Colour_Picker.colourtochange = "artpallet102" : Colour_Picker.oldcolour = colourpallet102.BackColor
                Case "colourpallet103" : Colour_Picker.colourtochange = "artpallet103" : Colour_Picker.oldcolour = colourpallet103.BackColor
                Case "colourpallet104" : Colour_Picker.colourtochange = "artpallet104" : Colour_Picker.oldcolour = colourpallet104.BackColor
                Case "colourpallet105" : Colour_Picker.colourtochange = "artpallet105" : Colour_Picker.oldcolour = colourpallet105.BackColor
                Case "colourpallet106" : Colour_Picker.colourtochange = "artpallet106" : Colour_Picker.oldcolour = colourpallet106.BackColor
                Case "colourpallet107" : Colour_Picker.colourtochange = "artpallet107" : Colour_Picker.oldcolour = colourpallet107.BackColor
                Case "colourpallet108" : Colour_Picker.colourtochange = "artpallet108" : Colour_Picker.oldcolour = colourpallet108.BackColor
                Case "colourpallet109" : Colour_Picker.colourtochange = "artpallet109" : Colour_Picker.oldcolour = colourpallet109.BackColor
                Case "colourpallet110" : Colour_Picker.colourtochange = "artpallet110" : Colour_Picker.oldcolour = colourpallet110.BackColor
                Case "colourpallet111" : Colour_Picker.colourtochange = "artpallet111" : Colour_Picker.oldcolour = colourpallet111.BackColor
                Case "colourpallet112" : Colour_Picker.colourtochange = "artpallet112" : Colour_Picker.oldcolour = colourpallet112.BackColor
                Case "colourpallet113" : Colour_Picker.colourtochange = "artpallet113" : Colour_Picker.oldcolour = colourpallet113.BackColor
                Case "colourpallet114" : Colour_Picker.colourtochange = "artpallet114" : Colour_Picker.oldcolour = colourpallet114.BackColor
                Case "colourpallet115" : Colour_Picker.colourtochange = "artpallet115" : Colour_Picker.oldcolour = colourpallet115.BackColor
                Case "colourpallet116" : Colour_Picker.colourtochange = "artpallet116" : Colour_Picker.oldcolour = colourpallet116.BackColor
                Case "colourpallet117" : Colour_Picker.colourtochange = "artpallet117" : Colour_Picker.oldcolour = colourpallet117.BackColor
                Case "colourpallet118" : Colour_Picker.colourtochange = "artpallet118" : Colour_Picker.oldcolour = colourpallet118.BackColor
                Case "colourpallet119" : Colour_Picker.colourtochange = "artpallet119" : Colour_Picker.oldcolour = colourpallet119.BackColor
                Case "colourpallet120" : Colour_Picker.colourtochange = "artpallet120" : Colour_Picker.oldcolour = colourpallet120.BackColor
                Case "colourpallet121" : Colour_Picker.colourtochange = "artpallet121" : Colour_Picker.oldcolour = colourpallet121.BackColor
                Case "colourpallet122" : Colour_Picker.colourtochange = "artpallet122" : Colour_Picker.oldcolour = colourpallet122.BackColor
                Case "colourpallet123" : Colour_Picker.colourtochange = "artpallet123" : Colour_Picker.oldcolour = colourpallet123.BackColor
                Case "colourpallet124" : Colour_Picker.colourtochange = "artpallet124" : Colour_Picker.oldcolour = colourpallet124.BackColor
                Case "colourpallet125" : Colour_Picker.colourtochange = "artpallet125" : Colour_Picker.oldcolour = colourpallet125.BackColor
                Case "colourpallet126" : Colour_Picker.colourtochange = "artpallet126" : Colour_Picker.oldcolour = colourpallet126.BackColor
                Case "colourpallet127" : Colour_Picker.colourtochange = "artpallet127" : Colour_Picker.oldcolour = colourpallet127.BackColor
                Case "colourpallet128" : Colour_Picker.colourtochange = "artpallet128" : Colour_Picker.oldcolour = colourpallet128.BackColor

            End Select
            Colour_Picker.Show()
        End If
    End Sub

    Public Sub loadcolors()
        Dim allwhite As Boolean = True
        For i = 0 To 127
            If ShiftOSDesktop.artpadcolourpallets(i) = Nothing Then
            Else
                allwhite = False
            End If
        Next
        If allwhite = True Then
            For i = 0 To 127
                ShiftOSDesktop.artpadcolourpallets(i) = Color.Black
            Next
        End If
        colourpallet1.BackColor = ShiftOSDesktop.artpadcolourpallets(0)
        colourpallet2.BackColor = ShiftOSDesktop.artpadcolourpallets(1)
        colourpallet3.BackColor = ShiftOSDesktop.artpadcolourpallets(2)
        colourpallet4.BackColor = ShiftOSDesktop.artpadcolourpallets(3)
        colourpallet5.BackColor = ShiftOSDesktop.artpadcolourpallets(4)
        colourpallet6.BackColor = ShiftOSDesktop.artpadcolourpallets(5)
        colourpallet7.BackColor = ShiftOSDesktop.artpadcolourpallets(6)
        colourpallet8.BackColor = ShiftOSDesktop.artpadcolourpallets(7)
        colourpallet9.BackColor = ShiftOSDesktop.artpadcolourpallets(8)
        colourpallet10.BackColor = ShiftOSDesktop.artpadcolourpallets(9)
        colourpallet11.BackColor = ShiftOSDesktop.artpadcolourpallets(10)
        colourpallet12.BackColor = ShiftOSDesktop.artpadcolourpallets(11)
        colourpallet13.BackColor = ShiftOSDesktop.artpadcolourpallets(12)
        colourpallet14.BackColor = ShiftOSDesktop.artpadcolourpallets(13)
        colourpallet15.BackColor = ShiftOSDesktop.artpadcolourpallets(14)
        colourpallet16.BackColor = ShiftOSDesktop.artpadcolourpallets(15)
        colourpallet17.BackColor = ShiftOSDesktop.artpadcolourpallets(16)
        colourpallet18.BackColor = ShiftOSDesktop.artpadcolourpallets(17)
        colourpallet19.BackColor = ShiftOSDesktop.artpadcolourpallets(18)
        colourpallet20.BackColor = ShiftOSDesktop.artpadcolourpallets(19)
        colourpallet21.BackColor = ShiftOSDesktop.artpadcolourpallets(20)
        colourpallet22.BackColor = ShiftOSDesktop.artpadcolourpallets(21)
        colourpallet23.BackColor = ShiftOSDesktop.artpadcolourpallets(22)
        colourpallet24.BackColor = ShiftOSDesktop.artpadcolourpallets(23)
        colourpallet25.BackColor = ShiftOSDesktop.artpadcolourpallets(24)
        colourpallet26.BackColor = ShiftOSDesktop.artpadcolourpallets(25)
        colourpallet27.BackColor = ShiftOSDesktop.artpadcolourpallets(26)
        colourpallet28.BackColor = ShiftOSDesktop.artpadcolourpallets(27)
        colourpallet29.BackColor = ShiftOSDesktop.artpadcolourpallets(28)
        colourpallet30.BackColor = ShiftOSDesktop.artpadcolourpallets(29)
        colourpallet31.BackColor = ShiftOSDesktop.artpadcolourpallets(30)
        colourpallet32.BackColor = ShiftOSDesktop.artpadcolourpallets(31)
        colourpallet33.BackColor = ShiftOSDesktop.artpadcolourpallets(32)
        colourpallet34.BackColor = ShiftOSDesktop.artpadcolourpallets(33)
        colourpallet35.BackColor = ShiftOSDesktop.artpadcolourpallets(34)
        colourpallet36.BackColor = ShiftOSDesktop.artpadcolourpallets(35)
        colourpallet37.BackColor = ShiftOSDesktop.artpadcolourpallets(36)
        colourpallet38.BackColor = ShiftOSDesktop.artpadcolourpallets(37)
        colourpallet39.BackColor = ShiftOSDesktop.artpadcolourpallets(38)
        colourpallet40.BackColor = ShiftOSDesktop.artpadcolourpallets(39)
        colourpallet41.BackColor = ShiftOSDesktop.artpadcolourpallets(40)
        colourpallet42.BackColor = ShiftOSDesktop.artpadcolourpallets(41)
        colourpallet43.BackColor = ShiftOSDesktop.artpadcolourpallets(42)
        colourpallet44.BackColor = ShiftOSDesktop.artpadcolourpallets(43)
        colourpallet45.BackColor = ShiftOSDesktop.artpadcolourpallets(44)
        colourpallet46.BackColor = ShiftOSDesktop.artpadcolourpallets(45)
        colourpallet47.BackColor = ShiftOSDesktop.artpadcolourpallets(46)
        colourpallet48.BackColor = ShiftOSDesktop.artpadcolourpallets(47)
        colourpallet49.BackColor = ShiftOSDesktop.artpadcolourpallets(48)
        colourpallet50.BackColor = ShiftOSDesktop.artpadcolourpallets(49)
        colourpallet51.BackColor = ShiftOSDesktop.artpadcolourpallets(50)
        colourpallet52.BackColor = ShiftOSDesktop.artpadcolourpallets(51)
        colourpallet53.BackColor = ShiftOSDesktop.artpadcolourpallets(52)
        colourpallet54.BackColor = ShiftOSDesktop.artpadcolourpallets(53)
        colourpallet55.BackColor = ShiftOSDesktop.artpadcolourpallets(54)
        colourpallet56.BackColor = ShiftOSDesktop.artpadcolourpallets(55)
        colourpallet57.BackColor = ShiftOSDesktop.artpadcolourpallets(56)
        colourpallet58.BackColor = ShiftOSDesktop.artpadcolourpallets(57)
        colourpallet59.BackColor = ShiftOSDesktop.artpadcolourpallets(58)
        colourpallet60.BackColor = ShiftOSDesktop.artpadcolourpallets(59)
        colourpallet61.BackColor = ShiftOSDesktop.artpadcolourpallets(60)
        colourpallet62.BackColor = ShiftOSDesktop.artpadcolourpallets(61)
        colourpallet63.BackColor = ShiftOSDesktop.artpadcolourpallets(62)
        colourpallet64.BackColor = ShiftOSDesktop.artpadcolourpallets(63)
        colourpallet65.BackColor = ShiftOSDesktop.artpadcolourpallets(64)
        colourpallet66.BackColor = ShiftOSDesktop.artpadcolourpallets(65)
        colourpallet67.BackColor = ShiftOSDesktop.artpadcolourpallets(66)
        colourpallet68.BackColor = ShiftOSDesktop.artpadcolourpallets(67)
        colourpallet69.BackColor = ShiftOSDesktop.artpadcolourpallets(68)
        colourpallet70.BackColor = ShiftOSDesktop.artpadcolourpallets(69)
        colourpallet71.BackColor = ShiftOSDesktop.artpadcolourpallets(70)
        colourpallet72.BackColor = ShiftOSDesktop.artpadcolourpallets(71)
        colourpallet73.BackColor = ShiftOSDesktop.artpadcolourpallets(72)
        colourpallet74.BackColor = ShiftOSDesktop.artpadcolourpallets(73)
        colourpallet75.BackColor = ShiftOSDesktop.artpadcolourpallets(74)
        colourpallet76.BackColor = ShiftOSDesktop.artpadcolourpallets(75)
        colourpallet77.BackColor = ShiftOSDesktop.artpadcolourpallets(76)
        colourpallet78.BackColor = ShiftOSDesktop.artpadcolourpallets(77)
        colourpallet79.BackColor = ShiftOSDesktop.artpadcolourpallets(78)
        colourpallet80.BackColor = ShiftOSDesktop.artpadcolourpallets(79)
        colourpallet81.BackColor = ShiftOSDesktop.artpadcolourpallets(80)
        colourpallet82.BackColor = ShiftOSDesktop.artpadcolourpallets(81)
        colourpallet83.BackColor = ShiftOSDesktop.artpadcolourpallets(82)
        colourpallet84.BackColor = ShiftOSDesktop.artpadcolourpallets(83)
        colourpallet85.BackColor = ShiftOSDesktop.artpadcolourpallets(84)
        colourpallet86.BackColor = ShiftOSDesktop.artpadcolourpallets(85)
        colourpallet87.BackColor = ShiftOSDesktop.artpadcolourpallets(86)
        colourpallet88.BackColor = ShiftOSDesktop.artpadcolourpallets(87)
        colourpallet89.BackColor = ShiftOSDesktop.artpadcolourpallets(88)
        colourpallet90.BackColor = ShiftOSDesktop.artpadcolourpallets(89)
        colourpallet91.BackColor = ShiftOSDesktop.artpadcolourpallets(90)
        colourpallet92.BackColor = ShiftOSDesktop.artpadcolourpallets(91)
        colourpallet93.BackColor = ShiftOSDesktop.artpadcolourpallets(92)
        colourpallet94.BackColor = ShiftOSDesktop.artpadcolourpallets(93)
        colourpallet95.BackColor = ShiftOSDesktop.artpadcolourpallets(94)
        colourpallet96.BackColor = ShiftOSDesktop.artpadcolourpallets(95)
        colourpallet97.BackColor = ShiftOSDesktop.artpadcolourpallets(96)
        colourpallet98.BackColor = ShiftOSDesktop.artpadcolourpallets(97)
        colourpallet99.BackColor = ShiftOSDesktop.artpadcolourpallets(98)
        colourpallet100.BackColor = ShiftOSDesktop.artpadcolourpallets(99)
        colourpallet101.BackColor = ShiftOSDesktop.artpadcolourpallets(100)
        colourpallet102.BackColor = ShiftOSDesktop.artpadcolourpallets(101)
        colourpallet103.BackColor = ShiftOSDesktop.artpadcolourpallets(102)
        colourpallet104.BackColor = ShiftOSDesktop.artpadcolourpallets(103)
        colourpallet105.BackColor = ShiftOSDesktop.artpadcolourpallets(104)
        colourpallet106.BackColor = ShiftOSDesktop.artpadcolourpallets(105)
        colourpallet107.BackColor = ShiftOSDesktop.artpadcolourpallets(106)
        colourpallet108.BackColor = ShiftOSDesktop.artpadcolourpallets(107)
        colourpallet109.BackColor = ShiftOSDesktop.artpadcolourpallets(108)
        colourpallet110.BackColor = ShiftOSDesktop.artpadcolourpallets(109)
        colourpallet111.BackColor = ShiftOSDesktop.artpadcolourpallets(110)
        colourpallet112.BackColor = ShiftOSDesktop.artpadcolourpallets(111)
        colourpallet113.BackColor = ShiftOSDesktop.artpadcolourpallets(112)
        colourpallet114.BackColor = ShiftOSDesktop.artpadcolourpallets(113)
        colourpallet115.BackColor = ShiftOSDesktop.artpadcolourpallets(114)
        colourpallet116.BackColor = ShiftOSDesktop.artpadcolourpallets(115)
        colourpallet117.BackColor = ShiftOSDesktop.artpadcolourpallets(116)
        colourpallet118.BackColor = ShiftOSDesktop.artpadcolourpallets(117)
        colourpallet119.BackColor = ShiftOSDesktop.artpadcolourpallets(118)
        colourpallet120.BackColor = ShiftOSDesktop.artpadcolourpallets(119)
        colourpallet121.BackColor = ShiftOSDesktop.artpadcolourpallets(120)
        colourpallet122.BackColor = ShiftOSDesktop.artpadcolourpallets(121)
        colourpallet123.BackColor = ShiftOSDesktop.artpadcolourpallets(122)
        colourpallet124.BackColor = ShiftOSDesktop.artpadcolourpallets(123)
        colourpallet125.BackColor = ShiftOSDesktop.artpadcolourpallets(124)
        colourpallet126.BackColor = ShiftOSDesktop.artpadcolourpallets(125)
        colourpallet127.BackColor = ShiftOSDesktop.artpadcolourpallets(126)
        colourpallet128.BackColor = ShiftOSDesktop.artpadcolourpallets(127)
    End Sub

    Public Sub savecolors()
        ShiftOSDesktop.artpadcolourpallets(0) = colourpallet1.BackColor
        ShiftOSDesktop.artpadcolourpallets(1) = colourpallet2.BackColor
        ShiftOSDesktop.artpadcolourpallets(2) = colourpallet3.BackColor
        ShiftOSDesktop.artpadcolourpallets(3) = colourpallet4.BackColor
        ShiftOSDesktop.artpadcolourpallets(4) = colourpallet5.BackColor
        ShiftOSDesktop.artpadcolourpallets(5) = colourpallet6.BackColor
        ShiftOSDesktop.artpadcolourpallets(6) = colourpallet7.BackColor
        ShiftOSDesktop.artpadcolourpallets(7) = colourpallet8.BackColor
        ShiftOSDesktop.artpadcolourpallets(8) = colourpallet9.BackColor
        ShiftOSDesktop.artpadcolourpallets(9) = colourpallet10.BackColor
        ShiftOSDesktop.artpadcolourpallets(10) = colourpallet11.BackColor
        ShiftOSDesktop.artpadcolourpallets(11) = colourpallet12.BackColor
        ShiftOSDesktop.artpadcolourpallets(12) = colourpallet13.BackColor
        ShiftOSDesktop.artpadcolourpallets(13) = colourpallet14.BackColor
        ShiftOSDesktop.artpadcolourpallets(14) = colourpallet15.BackColor
        ShiftOSDesktop.artpadcolourpallets(15) = colourpallet16.BackColor
        ShiftOSDesktop.artpadcolourpallets(16) = colourpallet17.BackColor
        ShiftOSDesktop.artpadcolourpallets(17) = colourpallet18.BackColor
        ShiftOSDesktop.artpadcolourpallets(18) = colourpallet19.BackColor
        ShiftOSDesktop.artpadcolourpallets(19) = colourpallet20.BackColor
        ShiftOSDesktop.artpadcolourpallets(20) = colourpallet21.BackColor
        ShiftOSDesktop.artpadcolourpallets(21) = colourpallet22.BackColor
        ShiftOSDesktop.artpadcolourpallets(22) = colourpallet23.BackColor
        ShiftOSDesktop.artpadcolourpallets(23) = colourpallet24.BackColor
        ShiftOSDesktop.artpadcolourpallets(24) = colourpallet25.BackColor
        ShiftOSDesktop.artpadcolourpallets(25) = colourpallet26.BackColor
        ShiftOSDesktop.artpadcolourpallets(26) = colourpallet27.BackColor
        ShiftOSDesktop.artpadcolourpallets(27) = colourpallet28.BackColor
        ShiftOSDesktop.artpadcolourpallets(28) = colourpallet29.BackColor
        ShiftOSDesktop.artpadcolourpallets(29) = colourpallet30.BackColor
        ShiftOSDesktop.artpadcolourpallets(30) = colourpallet31.BackColor
        ShiftOSDesktop.artpadcolourpallets(31) = colourpallet32.BackColor
        ShiftOSDesktop.artpadcolourpallets(32) = colourpallet33.BackColor
        ShiftOSDesktop.artpadcolourpallets(33) = colourpallet34.BackColor
        ShiftOSDesktop.artpadcolourpallets(34) = colourpallet35.BackColor
        ShiftOSDesktop.artpadcolourpallets(35) = colourpallet36.BackColor
        ShiftOSDesktop.artpadcolourpallets(36) = colourpallet37.BackColor
        ShiftOSDesktop.artpadcolourpallets(37) = colourpallet38.BackColor
        ShiftOSDesktop.artpadcolourpallets(38) = colourpallet39.BackColor
        ShiftOSDesktop.artpadcolourpallets(39) = colourpallet40.BackColor
        ShiftOSDesktop.artpadcolourpallets(40) = colourpallet41.BackColor
        ShiftOSDesktop.artpadcolourpallets(41) = colourpallet42.BackColor
        ShiftOSDesktop.artpadcolourpallets(42) = colourpallet43.BackColor
        ShiftOSDesktop.artpadcolourpallets(43) = colourpallet44.BackColor
        ShiftOSDesktop.artpadcolourpallets(44) = colourpallet45.BackColor
        ShiftOSDesktop.artpadcolourpallets(45) = colourpallet46.BackColor
        ShiftOSDesktop.artpadcolourpallets(46) = colourpallet47.BackColor
        ShiftOSDesktop.artpadcolourpallets(47) = colourpallet48.BackColor
        ShiftOSDesktop.artpadcolourpallets(48) = colourpallet49.BackColor
        ShiftOSDesktop.artpadcolourpallets(49) = colourpallet50.BackColor
        ShiftOSDesktop.artpadcolourpallets(50) = colourpallet51.BackColor
        ShiftOSDesktop.artpadcolourpallets(51) = colourpallet52.BackColor
        ShiftOSDesktop.artpadcolourpallets(52) = colourpallet53.BackColor
        ShiftOSDesktop.artpadcolourpallets(53) = colourpallet54.BackColor
        ShiftOSDesktop.artpadcolourpallets(54) = colourpallet55.BackColor
        ShiftOSDesktop.artpadcolourpallets(55) = colourpallet56.BackColor
        ShiftOSDesktop.artpadcolourpallets(56) = colourpallet57.BackColor
        ShiftOSDesktop.artpadcolourpallets(57) = colourpallet58.BackColor
        ShiftOSDesktop.artpadcolourpallets(58) = colourpallet59.BackColor
        ShiftOSDesktop.artpadcolourpallets(59) = colourpallet60.BackColor
        ShiftOSDesktop.artpadcolourpallets(60) = colourpallet61.BackColor
        ShiftOSDesktop.artpadcolourpallets(61) = colourpallet62.BackColor
        ShiftOSDesktop.artpadcolourpallets(62) = colourpallet63.BackColor
        ShiftOSDesktop.artpadcolourpallets(63) = colourpallet64.BackColor
        ShiftOSDesktop.artpadcolourpallets(64) = colourpallet65.BackColor
        ShiftOSDesktop.artpadcolourpallets(65) = colourpallet66.BackColor
        ShiftOSDesktop.artpadcolourpallets(66) = colourpallet67.BackColor
        ShiftOSDesktop.artpadcolourpallets(67) = colourpallet68.BackColor
        ShiftOSDesktop.artpadcolourpallets(68) = colourpallet69.BackColor
        ShiftOSDesktop.artpadcolourpallets(69) = colourpallet70.BackColor
        ShiftOSDesktop.artpadcolourpallets(70) = colourpallet71.BackColor
        ShiftOSDesktop.artpadcolourpallets(71) = colourpallet72.BackColor
        ShiftOSDesktop.artpadcolourpallets(72) = colourpallet73.BackColor
        ShiftOSDesktop.artpadcolourpallets(73) = colourpallet74.BackColor
        ShiftOSDesktop.artpadcolourpallets(74) = colourpallet75.BackColor
        ShiftOSDesktop.artpadcolourpallets(75) = colourpallet76.BackColor
        ShiftOSDesktop.artpadcolourpallets(76) = colourpallet77.BackColor
        ShiftOSDesktop.artpadcolourpallets(77) = colourpallet78.BackColor
        ShiftOSDesktop.artpadcolourpallets(78) = colourpallet79.BackColor
        ShiftOSDesktop.artpadcolourpallets(79) = colourpallet80.BackColor
        ShiftOSDesktop.artpadcolourpallets(80) = colourpallet81.BackColor
        ShiftOSDesktop.artpadcolourpallets(81) = colourpallet82.BackColor
        ShiftOSDesktop.artpadcolourpallets(82) = colourpallet83.BackColor
        ShiftOSDesktop.artpadcolourpallets(83) = colourpallet84.BackColor
        ShiftOSDesktop.artpadcolourpallets(84) = colourpallet85.BackColor
        ShiftOSDesktop.artpadcolourpallets(85) = colourpallet86.BackColor
        ShiftOSDesktop.artpadcolourpallets(86) = colourpallet87.BackColor
        ShiftOSDesktop.artpadcolourpallets(87) = colourpallet88.BackColor
        ShiftOSDesktop.artpadcolourpallets(88) = colourpallet89.BackColor
        ShiftOSDesktop.artpadcolourpallets(89) = colourpallet90.BackColor
        ShiftOSDesktop.artpadcolourpallets(90) = colourpallet91.BackColor
        ShiftOSDesktop.artpadcolourpallets(91) = colourpallet92.BackColor
        ShiftOSDesktop.artpadcolourpallets(92) = colourpallet93.BackColor
        ShiftOSDesktop.artpadcolourpallets(93) = colourpallet94.BackColor
        ShiftOSDesktop.artpadcolourpallets(94) = colourpallet95.BackColor
        ShiftOSDesktop.artpadcolourpallets(95) = colourpallet96.BackColor
        ShiftOSDesktop.artpadcolourpallets(96) = colourpallet97.BackColor
        ShiftOSDesktop.artpadcolourpallets(97) = colourpallet98.BackColor
        ShiftOSDesktop.artpadcolourpallets(98) = colourpallet99.BackColor
        ShiftOSDesktop.artpadcolourpallets(99) = colourpallet100.BackColor
        ShiftOSDesktop.artpadcolourpallets(100) = colourpallet101.BackColor
        ShiftOSDesktop.artpadcolourpallets(101) = colourpallet102.BackColor
        ShiftOSDesktop.artpadcolourpallets(102) = colourpallet103.BackColor
        ShiftOSDesktop.artpadcolourpallets(103) = colourpallet104.BackColor
        ShiftOSDesktop.artpadcolourpallets(104) = colourpallet105.BackColor
        ShiftOSDesktop.artpadcolourpallets(105) = colourpallet106.BackColor
        ShiftOSDesktop.artpadcolourpallets(106) = colourpallet107.BackColor
        ShiftOSDesktop.artpadcolourpallets(107) = colourpallet108.BackColor
        ShiftOSDesktop.artpadcolourpallets(108) = colourpallet109.BackColor
        ShiftOSDesktop.artpadcolourpallets(109) = colourpallet110.BackColor
        ShiftOSDesktop.artpadcolourpallets(110) = colourpallet111.BackColor
        ShiftOSDesktop.artpadcolourpallets(111) = colourpallet112.BackColor
        ShiftOSDesktop.artpadcolourpallets(112) = colourpallet113.BackColor
        ShiftOSDesktop.artpadcolourpallets(113) = colourpallet114.BackColor
        ShiftOSDesktop.artpadcolourpallets(114) = colourpallet115.BackColor
        ShiftOSDesktop.artpadcolourpallets(115) = colourpallet116.BackColor
        ShiftOSDesktop.artpadcolourpallets(116) = colourpallet117.BackColor
        ShiftOSDesktop.artpadcolourpallets(117) = colourpallet118.BackColor
        ShiftOSDesktop.artpadcolourpallets(118) = colourpallet119.BackColor
        ShiftOSDesktop.artpadcolourpallets(119) = colourpallet120.BackColor
        ShiftOSDesktop.artpadcolourpallets(120) = colourpallet121.BackColor
        ShiftOSDesktop.artpadcolourpallets(121) = colourpallet122.BackColor
        ShiftOSDesktop.artpadcolourpallets(122) = colourpallet123.BackColor
        ShiftOSDesktop.artpadcolourpallets(123) = colourpallet124.BackColor
        ShiftOSDesktop.artpadcolourpallets(124) = colourpallet125.BackColor
        ShiftOSDesktop.artpadcolourpallets(125) = colourpallet126.BackColor
        ShiftOSDesktop.artpadcolourpallets(126) = colourpallet127.BackColor
        ShiftOSDesktop.artpadcolourpallets(127) = colourpallet128.BackColor
    End Sub

    Public Sub settoolcolours()
        btnpixelsetter.BackColor = drawingcolour
        btnpixelplacer.BackColor = drawingcolour
        btnpencil.BackColor = drawingcolour
        btnfloodfill.BackColor = drawingcolour
        btnsquare.BackColor = drawingcolour
        btnoval.BackColor = drawingcolour
        btnlinetool.BackColor = drawingcolour
        btnpaintbrush.BackColor = drawingcolour
        btntexttool.BackColor = drawingcolour
    End Sub

    Private Sub btnzoomin_Click(sender As Object, e As EventArgs) Handles btnzoomin.Click
        If magnificationlevel < 256 Then
            magnificationlevel *= 2
        Else
            infobox.title = "ArtPad - Magnification Error!"
            infobox.textinfo = "You are unable to increase the magnification level any further." & Environment.NewLine & Environment.NewLine & "256x is the highest level of magnification supported by ArtPad!"
            infobox.Show()
        End If
        setmagnification()
    End Sub

    Private Sub btnzoomout_Click(sender As Object, e As EventArgs) Handles btnzoomout.Click
        If magnificationlevel > 1 Then
            magnificationlevel /= 2
            pnldrawingbackground.AutoScrollPosition = New Point(0, 0)
        Else
            infobox.title = "ArtPad - Magnification Error!"
            infobox.textinfo = "You are unable to decrease the magnification level any further." & Environment.NewLine & Environment.NewLine & "Artpad is unable to scale pixels at a level smaller than their actual size!"
            infobox.Show()
        End If
        setmagnification()
    End Sub

    Private Sub setmagnification()
        magnifyRect.Width = CInt(canvaswidth / magnificationlevel)
        magnifyRect.Height = CInt(canvasheight / magnificationlevel)
        picdrawingdisplay.Size = New Size(canvaswidth * magnificationlevel, canvasheight * magnificationlevel)
        If picdrawingdisplay.Height > 468 AndAlso picdrawingdisplay.Width > 676 Then
            picdrawingdisplay.Location = New Point(0, 0)
        Else
            picdrawingdisplay.Location = New Point((pnldrawingbackground.Width - canvaswidth * magnificationlevel) / 2, (pnldrawingbackground.Height - canvasheight * magnificationlevel) / 2)
        End If
        picdrawingdisplay.Invalidate()
        lblzoomlevel.Text = magnificationlevel & "X"
    End Sub

    Private Sub pnlpixelplacer_Click(sender As Object, e As EventArgs) Handles btnpixelplacer.Click
        selectedtool = "Pixel Placer"
        gettoolsettings(pnlpixelplacersettings)
    End Sub

    Private Sub btnpixelplacermovementmode_Click(sender As Object, e As EventArgs) Handles btnpixelplacermovementmode.Click
        If pixalplacermovable = False Then
            pixalplacermovable = True
            btnpixelplacermovementmode.ForeColor = Color.White
            btnpixelplacermovementmode.BackColor = Color.Black
            btnpixelplacermovementmode.Text = "Deactivate Movement Mode"
            lblpixelplacerhelp.Text = "Movement mode is enabled. Click and drag on the canvas to place pixels as you move the mouse. Please use 4x magnification or greater and move the mouse very slowly."
        Else
            pixalplacermovable = False
            btnpixelplacermovementmode.ForeColor = Color.Black
            btnpixelplacermovementmode.BackColor = Color.White
            btnpixelplacermovementmode.Text = "Activate Movement Mode"
            lblpixelplacerhelp.Text = "This tool does not contain any alterable settings. Simply click on the canvas and a pixel will be placed in the spot you click."
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        showsavedialog()
    End Sub

    Public Sub showsavedialog()
        File_Saver.savingprogram = "artpad"
        File_Saver.saveextention = ".pic"
        File_Saver.Show()
    End Sub

    Public Sub saveimage()
        canvasbitmap.Save(savelocation, Imaging.ImageFormat.Bmp)
    End Sub

    Private Sub txtnewcanvaswidth_TextChanged(sender As Object, e As EventArgs) Handles txtnewcanvaswidth.TextChanged, txtnewcanvasheight.TextChanged
        If txtnewcanvaswidth.Text = "" Or txtnewcanvasheight.Text = "" Then
        Else
            lbltotalpixels.Text = (Convert.ToInt32(txtnewcanvaswidth.Text) * Convert.ToInt32(txtnewcanvasheight.Text))
            If ShiftOSDesktop.boughtartpadlimitlesspixels = True Then
                lbltotalpixels.ForeColor = Color.Black
            Else
                If (Convert.ToInt32(txtnewcanvaswidth.Text) * Convert.ToInt32(txtnewcanvasheight.Text)) > ShiftOSDesktop.artpadpixellimit Then
                    lbltotalpixels.ForeColor = Color.Red
                Else
                    lbltotalpixels.ForeColor = Color.Black
                End If
            End If
        End If

    End Sub

    Private Sub btncreate_Click(sender As Object, e As EventArgs) Handles btncreate.Click
        If lbltotalpixels.ForeColor = Color.Red Then
            infobox.title = "ArtPad - Pixel Limit!"
            infobox.textinfo = "You are unable to use this many pixels in your canvas due to it exceeding your current pixel limit." & Environment.NewLine & Environment.NewLine & "Your pixel limit is currently " & ShiftOSDesktop.artpadpixellimit & " Pixels!"
            infobox.Show()
        Else
            If lbltotalpixels.Text = "0" Then
            Else
                canvaswidth = txtnewcanvaswidth.Text
                canvasheight = txtnewcanvasheight.Text
                picdrawingdisplay.Show()
                setupcanvas()
                pnlinitialcanvassettings.Hide()
            End If
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        pnlinitialcanvassettings.Hide()
        picdrawingdisplay.Show()
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        pnlinitialcanvassettings.Show()
        picdrawingdisplay.Hide()
    End Sub

    Public Sub setuppreview()
        lbltoolselected.Text = selectedtool
        picpreview.CreateGraphics.FillRectangle(Brushes.White, 0, 0, 70, 50)
        Select Case selectedtool
            Case "Square Tool"
                Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), squarewidth)
                Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, fillsquarecolor))
                Dim rectdraw As New RectangleF(0, 0, picpreview.Width, picpreview.Height)
                Dim correctionamount As Single = squarewidth / 2
                If squarewidth > 0 Then
                    picpreview.CreateGraphics.DrawRectangle(CurrentPen, rectdraw.X + correctionamount, rectdraw.Y + correctionamount, rectdraw.Width - squarewidth, rectdraw.Height - squarewidth)
                End If
                If squarefillon = True Then
                    picpreview.CreateGraphics.FillRectangle(CurrentBrush, rectdraw.X + squarewidth, rectdraw.Y + squarewidth, rectdraw.Width - squarewidth - squarewidth, rectdraw.Height - squarewidth - squarewidth)
                End If
            Case "Oval Tool"
                Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), ovalwidth)
                Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, fillovalcolor))
                Dim rectdraw As New RectangleF(0, 0, picpreview.Width, picpreview.Height)
                Dim correctionamount As Single = ovalwidth / 2
                If ovalwidth > 0 Then
                    picpreview.CreateGraphics.DrawEllipse(CurrentPen, rectdraw.X + correctionamount, rectdraw.Y + correctionamount, rectdraw.Width - ovalwidth, rectdraw.Height - ovalwidth)
                End If
                If ovalfillon = True Then
                    Dim fixer As Single = ovalwidth / 2
                    picpreview.CreateGraphics.FillEllipse(CurrentBrush, (rectdraw.X + fixer), (rectdraw.Y + fixer), rectdraw.Width - fixer - fixer, rectdraw.Height - fixer - fixer)
                End If
            Case "Text Tool"
                Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, drawingcolour))
                drawtextfont = New System.Drawing.Font(drawtextfontname, 20, drawtextfontstyle)
                picpreview.CreateGraphics.DrawString("A", drawtextfont, CurrentBrush, 20, 0)
            Case "Line Tool"
                Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), linewidth)
                picpreview.CreateGraphics.DrawLine(CurrentPen, 0, 0, picpreview.Width, picpreview.Height)
            Case "Pencil"
                Dim CurrentPen = New Pen(Color.FromArgb(255, drawingcolour), pencilwidth)
                picpreview.CreateGraphics.DrawLine(CurrentPen, 0, 25, picpreview.Width, 25)
            Case "Paint Brush"
                Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, drawingcolour))
                Dim halfsize As Single = paintbrushwidth / 2
                Dim halfwidth As Single = picdrawingdisplay.Width / 2
                Dim halfheight As Single = picdrawingdisplay.Height / 2
                If paintbrushtype = "circle" Then
                    picpreview.CreateGraphics.FillEllipse(CurrentBrush, halfwidth - 15 - halfsize, halfheight - 1 - halfsize, paintbrushwidth, paintbrushwidth)
                Else
                    picpreview.CreateGraphics.FillRectangle(CurrentBrush, halfwidth - 15 - halfsize, halfheight - 1 - halfsize, paintbrushwidth, paintbrushwidth)
                End If
            Case "Eracer"
                Dim drawbrush As New System.Drawing.SolidBrush(drawingcolour)
                picpreview.CreateGraphics.FillRectangle(drawbrush, 0, 0, picpreview.Width, picpreview.Height)
                Dim CurrentBrush = New SolidBrush(Color.FromArgb(255, Color.White))
                Dim halfsize As Single = eracerwidth / 2
                Dim halfwidth As Single = picdrawingdisplay.Width / 2
                Dim halfheight As Single = picdrawingdisplay.Height / 2
                If eracertype = "circle" Then
                    picpreview.CreateGraphics.FillEllipse(CurrentBrush, halfwidth - 15 - halfsize, halfheight - halfsize, eracerwidth, eracerwidth)
                Else
                    picpreview.CreateGraphics.FillRectangle(CurrentBrush, halfwidth - 15 - halfsize, halfheight - halfsize, eracerwidth, eracerwidth)
                End If
            Case Else
                Dim drawbrush As New System.Drawing.SolidBrush(drawingcolour)
                picpreview.CreateGraphics.FillRectangle(drawbrush, 0, 0, picpreview.Width, picpreview.Height)
                drawbrush.Dispose()
        End Select
    End Sub

    Private Sub limittonumbers(sender As Object, e As KeyPressEventArgs) Handles txtnewcanvasheight.KeyPress, txtnewcanvaswidth.KeyPress, txtpixelsetterxcoordinate.KeyPress, txtpixelsetterycoordinate.KeyPress, txtsquareborderwidth.KeyPress, txtovalborderwidth.KeyPress, txtnewcanvasheight.KeyPress, txteracersize.KeyPress, txtlinewidth.KeyPress, txtdrawtextsize.KeyPress, txtpaintbrushsize.KeyPress, txtcolorpalletheight.KeyPress, txtcolorpalletwidth.KeyPress, txtsidespace.KeyPress, txttopspace.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnpencil_Click(sender As Object, e As EventArgs) Handles btnpencil.Click
        selectedtool = "Pencil"
        gettoolsettings(pnlpencilsettings)
    End Sub

    Private Sub ChangePencilSize(sender As Object, e As EventArgs) Handles btnpencilsize1.Click, btnpencilsize2.Click, btnpencilsize3.Click
        Select Case sender.name.ToString
            Case "btnpencilsize1"
                pencilwidth = 1
            Case "btnpencilsize2"
                pencilwidth = 2
            Case "btnpencilsize3"
                pencilwidth = 3
        End Select
        setuppreview()
    End Sub

    Private Sub btnundo_Click(sender As Object, e As EventArgs) Handles btnundo.Click
        Try
            undo.redoStack.Push(canvasbitmap.Clone)
            canvasbitmap = undo.undoStack.Pop()
            graphicsbitmap = Graphics.FromImage(canvasbitmap)
            picdrawingdisplay.Invalidate()
        Catch ex As Exception
            infobox.title = "ArtPad - Undo Error!"
            infobox.textinfo = "There doesn't appear to be any more actions to undo." & Environment.NewLine & Environment.NewLine & "One more step back would undo the creation of the canvas. If this is your goal just click new."
            infobox.Show()
        End Try
    End Sub

    Private Sub btnredo_Click(sender As Object, e As EventArgs) Handles btnredo.Click
        Try
            undo.undoStack.Push(canvasbitmap.Clone)
            canvasbitmap = undo.redoStack.Pop()
            graphicsbitmap = Graphics.FromImage(canvasbitmap)
            picdrawingdisplay.Invalidate()
        Catch ex As Exception
            infobox.title = "ArtPad - Redo Error!"
            infobox.textinfo = "There doesn't appear to be any more actions to redo." & Environment.NewLine & Environment.NewLine & "If you have drawn on the canvas recently all future history would have been wiped!"
            infobox.Show()
        End Try
    End Sub

    Private Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        File_Opener.Show()
        File_Opener.openingprogram = "artpad"
        File_Opener.openextention = ".pic"
        File_Opener.lbextention.Text = File_Opener.openextention
        File_Opener.showcontents()
    End Sub

    Public Sub openpic()
        pnlinitialcanvassettings.Hide()
        picdrawingdisplay.Show()
        magnificationlevel = 1
        setmagnification()
        canvasbitmap = Image.FromFile(savelocation)
        canvasheight = canvasbitmap.Height
        canvaswidth = canvasbitmap.Width
        picdrawingdisplay.Size = New Size(canvaswidth, canvasheight)
        picdrawingdisplay.Location = New Point((pnldrawingbackground.Width - canvaswidth) / 2, (pnldrawingbackground.Height - canvasheight) / 2)
        graphicsbitmap = Graphics.FromImage(canvasbitmap)
        picdrawingdisplay.Invalidate()
    End Sub

    ' Flood fill the point.
    Public Sub SafeFloodFill(ByVal bm As Bitmap, ByVal x As _
        Integer, ByVal y As Integer, ByVal new_color As Color)
        ' Get the old and new colors.
        Dim old_color As Color = bm.GetPixel(x, y)

        ' The following "If Then" test was added by Reuben
        ' Jollif
        ' to protect the code in case the start pixel
        ' has the same color as the fill color.
        If old_color.ToArgb <> new_color.ToArgb Then
            ' Start with the original point in the stack.
            Dim pts As New Stack(1000)
            pts.Push(New Point(x, y))
            bm.SetPixel(x, y, new_color)

            ' While the stack is not empty, process a point.
            Do While pts.Count > 0
                Dim pt As Point = DirectCast(pts.Pop(), Point)
                If pt.X > 0 Then SafeCheckPoint(bm, pts, pt.X - _
                    1, pt.Y, old_color, new_color)
                If pt.Y > 0 Then SafeCheckPoint(bm, pts, pt.X, _
                    pt.Y - 1, old_color, new_color)
                If pt.X < bm.Width - 1 Then SafeCheckPoint(bm, _
                    pts, pt.X + 1, pt.Y, old_color, new_color)
                If pt.Y < bm.Height - 1 Then SafeCheckPoint(bm, _
                    pts, pt.X, pt.Y + 1, old_color, new_color)
            Loop
        End If
    End Sub

    ' See if this point should be added to the stack.
    Private Sub SafeCheckPoint(ByVal bm As Bitmap, ByVal pts As  _
        Stack, ByVal x As Integer, ByVal y As Integer, ByVal _
        old_color As Color, ByVal new_color As Color)
        Dim clr As Color = bm.GetPixel(x, y)
        If clr.Equals(old_color) Then
            pts.Push(New Point(x, y))
            bm.SetPixel(x, y, new_color)
        End If
    End Sub

    Private Sub btnfill_Click(sender As Object, e As EventArgs) Handles btnfloodfill.Click
        selectedtool = "Flood Fill"
        gettoolsettings(pnlfloodfillsettings)
    End Sub

    Private Sub btnsquare_Click(sender As Object, e As EventArgs) Handles btnsquare.Click
        selectedtool = "Square Tool"
        gettoolsettings(pnlsquaretoolsettings)
        txtsquareborderwidth.Text = squarewidth
    End Sub

    Private Sub txtsquareborderwidth_TextChanged(sender As Object, e As EventArgs) Handles txtsquareborderwidth.TextChanged
        If txtsquareborderwidth.Text = "" Then
        Else
            squarewidth = (Convert.ToInt32(txtsquareborderwidth.Text))
            setuppreview()
        End If
    End Sub

    Private Sub pnlsquarefillcolour_Click(sender As Object, e As EventArgs) Handles pnlsquarefillcolour.Click
        pnlsquarefillcolour.BackColor = drawingcolour
        fillsquarecolor = drawingcolour
        setuppreview()
    End Sub

    Private Sub btnsquarefillonoff_Click(sender As Object, e As EventArgs) Handles btnsquarefillonoff.Click
        If squarefillon = True Then
            btnsquarefillonoff.Text = "Fill OFF"
            btnsquarefillonoff.BackColor = Color.White
            btnsquarefillonoff.ForeColor = Color.Black
            squarefillon = False
        Else
            btnsquarefillonoff.Text = "Fill ON"
            btnsquarefillonoff.BackColor = Color.Black
            btnsquarefillonoff.ForeColor = Color.White
            squarefillon = True
        End If
        txtsquareborderwidth.Text = squarewidth
        setuppreview()
    End Sub

    Private Sub btnoval_Click(sender As Object, e As EventArgs) Handles btnoval.Click
        selectedtool = "Oval Tool"
        gettoolsettings(pnlovaltoolsettings)
        txtovalborderwidth.Text = ovalwidth
    End Sub

    Private Sub txtovalborderwidth_TextChanged(sender As Object, e As EventArgs) Handles txtovalborderwidth.TextChanged
        If txtovalborderwidth.Text = "" Then
        Else
            ovalwidth = (Convert.ToInt32(txtovalborderwidth.Text))
            setuppreview()
        End If
    End Sub

    Private Sub pnlovalfillcolour_Click(sender As Object, e As EventArgs) Handles pnlovalfillcolour.Click
        pnlovalfillcolour.BackColor = drawingcolour
        fillovalcolor = drawingcolour
        setuppreview()
    End Sub

    Private Sub btnovalfillonoff_Click(sender As Object, e As EventArgs) Handles btnovalfillonoff.Click
        If ovalfillon = True Then
            btnovalfillonoff.Text = "Fill OFF"
            btnovalfillonoff.BackColor = Color.White
            btnovalfillonoff.ForeColor = Color.Black
            ovalfillon = False
        Else
            btnovalfillonoff.Text = "Fill ON"
            btnovalfillonoff.BackColor = Color.Black
            btnovalfillonoff.ForeColor = Color.White
            ovalfillon = True
        End If
        txtovalborderwidth.Text = ovalwidth
        setuppreview()
    End Sub

    Private Sub btneracer_Click(sender As Object, e As EventArgs) Handles btneracer.Click
        selectedtool = "Eracer"
        gettoolsettings(pnleracertoolsettings)
        txteracersize.Text = eracerwidth
        setuppreview()
    End Sub

    Private Sub txteracersize_TextChanged(sender As Object, e As EventArgs) Handles txteracersize.TextChanged
        If txteracersize.Text = "" Then
        Else
            eracerwidth = (Convert.ToInt32(txteracersize.Text))
        End If
        setuppreview()
    End Sub

    Private Sub btneracercircle_Click(sender As Object, e As EventArgs) Handles btneracercircle.Click
        eracertype = "circle"
        btneracercircle.BackgroundImage = My.Resources.ArtPadcirclerubberselected
        btneracersquare.BackgroundImage = My.Resources.ArtPadsquarerubber
        setuppreview()
    End Sub

    Private Sub btneracersquare_Click(sender As Object, e As EventArgs) Handles btneracersquare.Click
        eracertype = "square"
        btneracercircle.BackgroundImage = My.Resources.ArtPadcirclerubber
        btneracersquare.BackgroundImage = My.Resources.ArtPadsquarerubberselected
        setuppreview()
    End Sub

    Private Sub btnlinetool_Click(sender As Object, e As EventArgs) Handles btnlinetool.Click
        selectedtool = "Line Tool"
        gettoolsettings(pnllinetoolsettings)
        txtlinewidth.Text = linewidth
    End Sub

    Private Sub txtlinewidth_TextChanged(sender As Object, e As EventArgs) Handles txtlinewidth.TextChanged
        If txtlinewidth.Text = "" Then
        Else
            linewidth = (Convert.ToInt32(txtlinewidth.Text))
        End If
        setuppreview()
    End Sub

    Private Sub btntexttool_Click(sender As Object, e As EventArgs) Handles btntexttool.Click
        selectedtool = "Text Tool"
        gettoolsettings(pnltexttoolsettings)
    End Sub

    Private Sub txtdrawtextsize_TextChanged(sender As Object, e As EventArgs) Handles txtdrawtextsize.TextChanged
        If txtdrawtextsize.Text = "" Then
        Else
            drawtextsize = txtdrawtextsize.Text
        End If
        setuppreview()
    End Sub

    Private Sub combodrawtextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodrawtextfont.SelectedIndexChanged
        drawtextfontname = combodrawtextfont.Text
        txtdrawstringtext.Focus()
        setuppreview()
    End Sub

    Private Sub combofontstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combofontstyle.SelectedIndexChanged
        Select Case combofontstyle.Text
            Case "Bold"
                drawtextfontstyle = FontStyle.Bold
            Case "Italic"
                drawtextfontstyle = FontStyle.Italic
            Case "Regular"
                drawtextfontstyle = FontStyle.Regular
            Case "Strikeout"
                drawtextfontstyle = FontStyle.Strikeout
            Case "Underline"
                drawtextfontstyle = FontStyle.Underline
        End Select
        txtdrawstringtext.Focus()
        setuppreview()
    End Sub

    Private Sub txtpaintbrushsize_TextChanged(sender As Object, e As EventArgs) Handles txtpaintbrushsize.TextChanged
        If txtpaintbrushsize.Text = "" Then
        Else
            paintbrushwidth = (Convert.ToInt32(txtpaintbrushsize.Text))
        End If
        setuppreview()
    End Sub

    Private Sub btnpaintsquareshape_Click(sender As Object, e As EventArgs) Handles btnpaintsquareshape.Click
        paintbrushtype = "square"
        btnpaintcircleshape.BackgroundImage = My.Resources.ArtPadcirclerubber
        btnpaintsquareshape.BackgroundImage = My.Resources.ArtPadsquarerubberselected
        setuppreview()
    End Sub

    Private Sub btnpaintcircleshape_Click(sender As Object, e As EventArgs) Handles btnpaintcircleshape.Click
        paintbrushtype = "circle"
        btnpaintcircleshape.BackgroundImage = My.Resources.ArtPadcirclerubberselected
        btnpaintsquareshape.BackgroundImage = My.Resources.ArtPadsquarerubber
        setuppreview()
    End Sub

    Private Sub btnpaintbrush_Click(sender As Object, e As EventArgs) Handles btnpaintbrush.Click
        selectedtool = "Paint Brush"
        gettoolsettings(pnlpaintbrushtoolsettings)
        txtpaintbrushsize.Text = paintbrushwidth
        setuppreview()
    End Sub

    Private Sub preparecooldown()
        needtosave = True
        If codepointscooldown = True Then
        Else
            codepointsearned = codepointsearned + 1
            codepointscooldown = True
            tmrcodepointcooldown.Start()
        End If
    End Sub

    Private Sub tmrcodepointcooldown_Tick(sender As Object, e As EventArgs) Handles tmrcodepointcooldown.Tick
        codepointscooldown = False
        tmrcodepointcooldown.Stop()
    End Sub

    Private Sub tmrshowearnedcodepoints_Tick(sender As Object, e As EventArgs) Handles tmrshowearnedcodepoints.Tick
        lbtitletext.Text = "Artpad"
        Me.setuptitlebar()
        tmrshowearnedcodepoints.Stop()
    End Sub

    Private Sub btnsetsize_Click(sender As Object, e As EventArgs) Handles btnsetsize.Click
        setpalletsize()
    End Sub

    Private Sub setpalletsize()
        ShiftOSDesktop.artpadcolorpalletwidth = txtcolorpalletwidth.Text
        ShiftOSDesktop.artpadcolorpalletheight = txtcolorpalletheight.Text

        ShiftOSDesktop.artpadcolorpallettopgap = txttopspace.Text
        ShiftOSDesktop.artpadcolorpalletsidegap = txtsidespace.Text

        setuppallets()
    End Sub

    Public Sub setuppallets()
        colourpallet1.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet2.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet3.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet4.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet5.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet6.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet7.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet8.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet9.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet10.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet11.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet12.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet13.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet14.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet15.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet16.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet17.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet18.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet19.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet20.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet21.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet22.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet23.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet24.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet25.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet26.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet27.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet28.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet29.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet30.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet31.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet32.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet33.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet34.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet35.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet36.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet37.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet38.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet39.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet40.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet41.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet42.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet43.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet44.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet45.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet46.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet47.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet48.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet49.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet50.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet51.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet52.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet53.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet54.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet55.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet56.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet57.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet58.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet59.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet60.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet61.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet62.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet63.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet64.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet65.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet66.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet67.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet68.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet69.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet70.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet71.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet72.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet73.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet74.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet75.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet76.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet77.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet78.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet79.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet80.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet81.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet82.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet83.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet84.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet85.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet86.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet87.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet88.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet89.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet90.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet91.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet92.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet93.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet94.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet95.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet96.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet97.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet98.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet99.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet100.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet101.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet102.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet103.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet104.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet105.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet106.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet107.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet108.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet109.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet110.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet111.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet112.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet113.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet114.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet115.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet116.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet117.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet118.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet119.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet120.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet121.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet122.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet123.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet124.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet125.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet126.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet127.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)
        colourpallet128.Margin = New Padding(ShiftOSDesktop.artpadcolorpalletsidegap, 0, 0, ShiftOSDesktop.artpadcolorpallettopgap)

        colourpallet1.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet2.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet3.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet4.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet5.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet6.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet7.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet8.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet9.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet10.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet11.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet12.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet13.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet14.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet15.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet16.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet17.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet18.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet19.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet20.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet21.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet22.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet23.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet24.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet25.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet26.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet27.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet28.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet29.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet30.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet31.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet32.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet33.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet34.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet35.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet36.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet37.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet38.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet39.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet40.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet41.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet42.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet43.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet44.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet45.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet46.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet47.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet48.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet49.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet50.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet51.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet52.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet53.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet54.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet55.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet56.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet57.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet58.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet59.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet60.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet61.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet62.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet63.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet64.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet65.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet66.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet67.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet68.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet69.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet70.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet71.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet72.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet73.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet74.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet75.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet76.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet77.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet78.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet79.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet80.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet81.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet82.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet83.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet84.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet85.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet86.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet87.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet88.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet89.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet90.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet91.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet92.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet93.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet94.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet95.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet96.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet97.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet98.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet99.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet100.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet101.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet102.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet103.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet104.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet105.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet106.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet107.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet108.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet109.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet110.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet111.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet112.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet113.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet114.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet115.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet116.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet117.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet118.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet119.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet120.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet121.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet122.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet123.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet124.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet125.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet126.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet127.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
        colourpallet128.Size = New Size(ShiftOSDesktop.artpadcolorpalletwidth, ShiftOSDesktop.artpadcolorpalletheight)
    End Sub

    Public Sub determinevisiblepallets()
        Select Case ShiftOSDesktop.artpadvisiblepallets
            Case "2"
                colourpallet1.Show()
                colourpallet2.Show()
            Case "4"
                colourpallet1.Show()
                colourpallet2.Show()
                colourpallet3.Show()
                colourpallet4.Show()
            Case "8"
                colourpallet1.Show()
                colourpallet2.Show()
                colourpallet3.Show()
                colourpallet4.Show()
                colourpallet5.Show()
                colourpallet6.Show()
                colourpallet7.Show()
                colourpallet8.Show()
            Case "16"
                colourpallet1.Show()
                colourpallet2.Show()
                colourpallet3.Show()
                colourpallet4.Show()
                colourpallet5.Show()
                colourpallet6.Show()
                colourpallet7.Show()
                colourpallet8.Show()
                colourpallet9.Show()
                colourpallet10.Show()
                colourpallet11.Show()
                colourpallet12.Show()
                colourpallet13.Show()
                colourpallet14.Show()
                colourpallet15.Show()
                colourpallet16.Show()
            Case "32"
                colourpallet1.Show()
                colourpallet2.Show()
                colourpallet3.Show()
                colourpallet4.Show()
                colourpallet5.Show()
                colourpallet6.Show()
                colourpallet7.Show()
                colourpallet8.Show()
                colourpallet9.Show()
                colourpallet10.Show()
                colourpallet11.Show()
                colourpallet12.Show()
                colourpallet13.Show()
                colourpallet14.Show()
                colourpallet15.Show()
                colourpallet16.Show()
                colourpallet17.Show()
                colourpallet18.Show()
                colourpallet19.Show()
                colourpallet20.Show()
                colourpallet21.Show()
                colourpallet22.Show()
                colourpallet23.Show()
                colourpallet24.Show()
                colourpallet25.Show()
                colourpallet26.Show()
                colourpallet27.Show()
                colourpallet28.Show()
                colourpallet29.Show()
                colourpallet30.Show()
                colourpallet31.Show()
                colourpallet32.Show()
            Case "64"
                colourpallet1.Show()
                colourpallet2.Show()
                colourpallet3.Show()
                colourpallet4.Show()
                colourpallet5.Show()
                colourpallet6.Show()
                colourpallet7.Show()
                colourpallet8.Show()
                colourpallet9.Show()
                colourpallet10.Show()
                colourpallet11.Show()
                colourpallet12.Show()
                colourpallet13.Show()
                colourpallet14.Show()
                colourpallet15.Show()
                colourpallet16.Show()
                colourpallet17.Show()
                colourpallet18.Show()
                colourpallet19.Show()
                colourpallet20.Show()
                colourpallet21.Show()
                colourpallet22.Show()
                colourpallet23.Show()
                colourpallet24.Show()
                colourpallet25.Show()
                colourpallet26.Show()
                colourpallet27.Show()
                colourpallet28.Show()
                colourpallet29.Show()
                colourpallet30.Show()
                colourpallet31.Show()
                colourpallet32.Show()
                colourpallet33.Show()
                colourpallet34.Show()
                colourpallet35.Show()
                colourpallet36.Show()
                colourpallet37.Show()
                colourpallet38.Show()
                colourpallet39.Show()
                colourpallet40.Show()
                colourpallet41.Show()
                colourpallet42.Show()
                colourpallet43.Show()
                colourpallet44.Show()
                colourpallet45.Show()
                colourpallet46.Show()
                colourpallet47.Show()
                colourpallet48.Show()
                colourpallet49.Show()
                colourpallet50.Show()
                colourpallet51.Show()
                colourpallet52.Show()
                colourpallet53.Show()
                colourpallet54.Show()
                colourpallet55.Show()
                colourpallet56.Show()
                colourpallet57.Show()
                colourpallet58.Show()
                colourpallet59.Show()
                colourpallet60.Show()
                colourpallet61.Show()
                colourpallet62.Show()
                colourpallet63.Show()
                colourpallet64.Show()
            Case "128"
                colourpallet1.Show()
                colourpallet2.Show()
                colourpallet3.Show()
                colourpallet4.Show()
                colourpallet5.Show()
                colourpallet6.Show()
                colourpallet7.Show()
                colourpallet8.Show()
                colourpallet9.Show()
                colourpallet10.Show()
                colourpallet11.Show()
                colourpallet12.Show()
                colourpallet13.Show()
                colourpallet14.Show()
                colourpallet15.Show()
                colourpallet16.Show()
                colourpallet17.Show()
                colourpallet18.Show()
                colourpallet19.Show()
                colourpallet20.Show()
                colourpallet21.Show()
                colourpallet22.Show()
                colourpallet23.Show()
                colourpallet24.Show()
                colourpallet25.Show()
                colourpallet26.Show()
                colourpallet27.Show()
                colourpallet28.Show()
                colourpallet29.Show()
                colourpallet30.Show()
                colourpallet31.Show()
                colourpallet32.Show()
                colourpallet33.Show()
                colourpallet34.Show()
                colourpallet35.Show()
                colourpallet36.Show()
                colourpallet37.Show()
                colourpallet38.Show()
                colourpallet39.Show()
                colourpallet40.Show()
                colourpallet41.Show()
                colourpallet42.Show()
                colourpallet43.Show()
                colourpallet44.Show()
                colourpallet45.Show()
                colourpallet46.Show()
                colourpallet47.Show()
                colourpallet48.Show()
                colourpallet49.Show()
                colourpallet50.Show()
                colourpallet51.Show()
                colourpallet52.Show()
                colourpallet53.Show()
                colourpallet54.Show()
                colourpallet55.Show()
                colourpallet56.Show()
                colourpallet57.Show()
                colourpallet58.Show()
                colourpallet59.Show()
                colourpallet60.Show()
                colourpallet61.Show()
                colourpallet62.Show()
                colourpallet63.Show()
                colourpallet64.Show()
                colourpallet65.Show()
                colourpallet66.Show()
                colourpallet67.Show()
                colourpallet68.Show()
                colourpallet69.Show()
                colourpallet70.Show()
                colourpallet71.Show()
                colourpallet72.Show()
                colourpallet73.Show()
                colourpallet74.Show()
                colourpallet75.Show()
                colourpallet76.Show()
                colourpallet77.Show()
                colourpallet78.Show()
                colourpallet79.Show()
                colourpallet80.Show()
                colourpallet81.Show()
                colourpallet82.Show()
                colourpallet83.Show()
                colourpallet84.Show()
                colourpallet85.Show()
                colourpallet86.Show()
                colourpallet87.Show()
                colourpallet88.Show()
                colourpallet89.Show()
                colourpallet90.Show()
                colourpallet91.Show()
                colourpallet92.Show()
                colourpallet93.Show()
                colourpallet94.Show()
                colourpallet95.Show()
                colourpallet96.Show()
                colourpallet97.Show()
                colourpallet98.Show()
                colourpallet99.Show()
                colourpallet100.Show()
                colourpallet101.Show()
                colourpallet102.Show()
                colourpallet103.Show()
                colourpallet104.Show()
                colourpallet105.Show()
                colourpallet106.Show()
                colourpallet107.Show()
                colourpallet108.Show()
                colourpallet109.Show()
                colourpallet110.Show()
                colourpallet111.Show()
                colourpallet112.Show()
                colourpallet113.Show()
                colourpallet114.Show()
                colourpallet115.Show()
                colourpallet116.Show()
                colourpallet117.Show()
                colourpallet118.Show()
                colourpallet119.Show()
                colourpallet120.Show()
                colourpallet121.Show()
                colourpallet122.Show()
                colourpallet123.Show()
                colourpallet124.Show()
                colourpallet125.Show()
                colourpallet126.Show()
                colourpallet127.Show()
                colourpallet128.Show()
        End Select
    End Sub

    Private Sub btnchangesizecancel_Click(sender As Object, e As EventArgs) Handles btnchangesizecancel.Click
        pnlpalletsize.Hide()
    End Sub

    Private Sub txtdrawstringtext_TextChanged(sender As Object, e As EventArgs) Handles txtdrawstringtext.TextChanged
        setuppreview()
    End Sub

    Private Sub titlebar_Paint(sender As Object, e As PaintEventArgs) Handles titlebar.Paint

    End Sub
End Class
