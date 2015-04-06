Imports System.IO
Public Class File_Skimmer
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 400
    Public minimumsizeheight As Integer = 177
    Public ShiftOSPath As String = ShiftOSDesktop.ShiftOSPath

    Dim itemsdeleted As Integer
    Dim filetype As Integer

#Region "Template Code"

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setupall()
        If ShiftOSDesktop.FileSkimmerCorrupted Then Me.Close() : infobox.showinfo("The Plague.", Me.Name & "has been corrupted by The Plague.")

        ShiftOSDesktop.pnlpanelbuttonfileskimmer.SendToBack() 'CHANGE NAME
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonfileskimmer, ShiftOSDesktop.tbfileskimmericon, ShiftOSDesktop.tbfileskimmertext, True) 'modify to proper name
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
        ShiftOSDesktop.refreshIcons()
        Me.Close()
    End Sub

    Private Sub Me_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        ShiftOSDesktop.refreshIcons()
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
            Me.Size = New Size(600, 377) 'put the default size of your window here
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
                lbtitletext.Text = ShiftOSDesktop.fileskimmername 'Remember to change to name of program!!!!
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
        If ShiftOSDesktop.boughtfileskimmericon = True Then ' Change to program's icon
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.dodgeicontitlebar  'Replace with the correct icon for the program.
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showcontents()
    End Sub

    Public Function getExType(fileex As String)

        Dim filetype As Integer
        Dim program As String

        Select Case fileex
            Case ".txt"
                filetype = 2
                program = "Text Document"
            Case ".doc"
                filetype = 2
                program = "Word Document"
            Case ".docx"
                filetype = 2
                program = "Word Document"
            Case ".lst"
                filetype = 2
                program = "Spreadsheet"
            Case ".png"
                filetype = 3
                program = "Picture"
            Case ".jpg"
                filetype = 3
                program = "Picture"
            Case ".jpeg"
                filetype = 3
                program = "Picture"
            Case ".bmp"
                filetype = 3
                program = "Bitmap"
            Case ".gif"
                filetype = 3
                program = "Animated Picture"
            Case ".avi"
                filetype = 4
                program = "Video Clip"
            Case ".m4v"
                filetype = 4
                program = "MPEG-4 Video"
            Case ".mp4"
                filetype = 4
                program = "MPEG-4 Video"
            Case ".wmv"
                filetype = 4
                program = "Windows Media Video"
            Case ".mp3"
                filetype = 4
                program = "MPEG-3 Song"
            Case ".dll"
                filetype = 6
                program = "System File"
            Case ".exe"
                filetype = 7
                program = "MS-DOS Executable"
            Case ".sft"
                filetype = 8
                program = "System File"
            Case ".dri"
                filetype = 9
                program = "System File"
            Case ".pic"
                filetype = 3
                If ShiftOSDesktop.boughtartpad Then program = "Artpad Document" Else program = ".pic File"
            Case ".skn"
                filetype = 10
                If ShiftOSDesktop.boughtskinloader Then program = "Skin" Else program = ".skn file"
            Case ".nls"
                filetype = 11
                program = "Font File"
            Case ".icp"
                filetype = 12
                If ShiftOSDesktop.boughticonmanager Then program = "Icon Manager File" Else program = ".icp file"
            Case ".stp"
                filetype = 13
                program = "Setup File"
            Case ".trm"
                filetype = 14
                program = "Terminal Script File"
            Case ".owd"
                filetype = 2
                If ShiftOSDesktop.boughtorcwrite Then program = "OrcWrite Document" Else program = ".owd file"
            Case ".sh"
                filetype = 14
                program = "BASH Script"
            Case ".bat"
                filetype = 14
                program = "MS-DOS Batch File"
            Case ".command"
                filetype = 14
                program = ".command file"
            Case ".saa"
                If ShiftOSDesktop.boughtgray Then filetype = 15 Else filetype = 19
                program = "Stand Alone Application"
            Case ".flood"
                filetype = 16
                If ShiftOSDesktop.boughtfloodgate Then program = "FloodGate File" Else program = ".flood file"
            Case ".url"
                filetype = 17
                program = "Shortcut"
            Case ".urls"
                filetype = 18
                program = "Shiftnet Link"
            Case Else
                filetype = 1
                program = "Unknown File Type"
        End Select

        Dim array() As String = {CStr(filetype), program}

        Return (array)

    End Function

    Private Sub showcontents()
        Me.Show()

        lvfiles.Items.Clear()

        lvfiles.Items.Add("Exit Folder", 5)

        Dim dir As New DirectoryInfo(lbllocation.Text)
        Dim files As FileInfo() = dir.GetFiles()
        Dim file As FileInfo
        Dim folders As DirectoryInfo() = dir.GetDirectories()
        Dim folder As DirectoryInfo

        For Each folder In folders
            Dim foldername As String = folder.Name
            lvfiles.Items.Add(foldername, 0)
        Next

        For Each file In files
            Dim filename As String = file.Name
            Dim fileex As String = file.Extension

            filetype = getExType(fileex)(0)

            lvfiles.Items.Add(filename, filetype)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showcontents()
    End Sub

    Private Sub lbfiles_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvfiles.MouseDoubleClick

        If lvfiles.SelectedItems(0).Text = "Exit Folder" Then

            If lbllocation.Text = "C:/ShiftOS" Or lbllocation.Text = "C:/ShiftOS/" Then
                infobox.title = "File Skimmer - Warning!"
                infobox.textinfo = "Unable to move into a higher directory due to error reading the requested folder on the drive." & Environment.NewLine & Environment.NewLine & "You can only enter directories formatted in the ShiftOS file system (ShiftFS)"
                infobox.Show()
            Else
                Dim directoryInfo As System.IO.DirectoryInfo
                directoryInfo = System.IO.Directory.GetParent(lbllocation.Text)
                If (directoryInfo.FullName = "C:\") Then Dim errerror As String = "an error" Else lbllocation.Text = directoryInfo.FullName

                'Dim endloop As Boolean = False
                'lbllocation.Text = lbllocation.Text.Substring(0, lbllocation.Text.Length - 1)

                'While endloop = False
                '    Try
                '        If lbllocation.Text.Substring(lbllocation.Text.Length - 1) = "/" Then
                '            endloop = True
                '        Else
                '            lbllocation.Text = lbllocation.Text.Substring(0, lbllocation.Text.Length - 1)
                '        End If
                '    Catch
                '        infobox.title = "File Skimmer - Error!"
                '        infobox.textinfo = "Unable to move into a higher directory due to error reading the requested folder on the drive." & Environment.NewLine & Environment.NewLine & "An error occured going up"
                '        infobox.Show()
                '    End Try
                'End While


                showcontents()
            End If
        Else
            'Check if selected item is a file or folder. It it's a folder check its extension
            If lbllocation.Text Like "*/" Then
            Else
                lbllocation.Text = lbllocation.Text + "/"
            End If
            OpenFile(lbllocation.Text + lvfiles.SelectedItems(0).Text)
        End If

    End Sub
    Public Sub OpenFile(path As String)
        'Check if selected item is a file or folder. It it's a folder check its extension

        If path Like "*.owd" Then
            If ShiftOSDesktop.boughtorcwrite = True Then
                Dim sr As New IO.StreamReader(Path)
                OrcWrite.RichTextBox1.Rtf = sr.ReadToEnd()
                sr.Close()
                OrcWrite.Show()
                OrcWrite.TopMost = True
            Else
                infobox.showinfo("Application Not Found", "ShiftOS could not find an application able the open .owd files.")
            End If
        ElseIf path Like "*.txt" Then
            If TextPad.needtosave = False Then
                TextPad.Show()
                TextPad.txtuserinput.Text = My.Computer.FileSystem.ReadAllText(path)
                TextPad.needtosave = False
            Else
                infobox.title = "Textpad - Save?"
                infobox.textinfo = "It appears that your text document currently contains unsaved changes." & Environment.NewLine & Environment.NewLine & "Are you sure you want to load a file without saving the changes?"
                infobox.Show()
                infobox.showyesno()
                infobox.sendyesno = "fileskimmertextpad"
            End If

        ElseIf path Like "*.pic" Then
            If ArtPad.needtosave = False Then
                ArtPad.Show()
                ArtPad.savelocation = (path)
                ArtPad.openpic()
                ArtPad.needtosave = False
            Else
                infobox.title = "Artpad - Save?"
                infobox.textinfo = "It appears that your canvas currently contains unsaved changes." & Environment.NewLine & Environment.NewLine & "Are you sure you want to open a different canvas without saving the changes?"
                infobox.Show()
                infobox.showyesno()
                infobox.sendyesno = "fileskimmerartpad"
            End If

        ElseIf path Like "*.sft" Then
            infobox.title = "File Skimmer - Warning!"
            infobox.textinfo = "This file appears to be encrypted or may be critical for stable system operation." & Environment.NewLine & Environment.NewLine & "Access to this file has been blocked to protect the system from potential damage."
            infobox.Show()

        ElseIf path Like "*.lst" Then
            infobox.title = "File Skimmer - Warning!"
            infobox.textinfo = "This file appears to be encrypted or may be critical for stable system operation." & Environment.NewLine & Environment.NewLine & "Access to this file has been blocked to protect the system from potential damage."
            infobox.Show()
        ElseIf path Like "*.dri" Then
            infobox.title = "File Skimmer - Warning!"
            infobox.textinfo = "This file appears to be encrypted or may be critical for stable system operation." & Environment.NewLine & Environment.NewLine & "Access to this file has been blocked to protect the system from potential damage."
            infobox.Show()

        ElseIf path Like "*.lang" Then
            infobox.title = "File Skimmer - Warning!"
            infobox.textinfo = "This file appears to be encrypted or may be critical for stable system operation." & Environment.NewLine & Environment.NewLine & "Access to this file has been blocked to protect the system from potential damage."
            infobox.Show()

        ElseIf path Like "*.skn" Then
            If ShiftOSDesktop.boughtskinning Then
                Skin_Loader.Show()
                Skin_Loader.loadingsknversion = ""
                If My.Computer.FileSystem.DirectoryExists(ShiftOSPath + "Shiftum42\Skins\Preview\") Then My.Computer.FileSystem.DeleteDirectory(ShiftOSPath + "Shiftum42\Skins\Preview\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                System.IO.Compression.ZipFile.ExtractToDirectory(path, ShiftOSPath + "Shiftum42\Skins\Preview\")
                If File.Exists(ShiftOSPath + "Shiftum42\Skins\Preview\SKN-version") Then
                    Dim sr As StreamReader = New StreamReader(ShiftOSPath + "Shiftum42\Skins\Preview\SKN-version")
                    Dim i As String = sr.ReadLine
                    Skin_Loader.loadingsknversion = sr.ReadLine
                    sr.Close()
                End If
                If Skin_Loader.loadingsknversion = "2.0 disposal-free skinning" Then
                    Skin_Loader.setuppreview2_0()
                    Skin_Loader.skinloaded = True
                Else
                    My.Computer.FileSystem.WriteAllText(ShiftOSPath + "Shiftum42\Skins\Preview\skindata.dat", My.Computer.FileSystem.ReadAllText(ShiftOSPath + "Shiftum42\Skins\Preview\skindata.dat").Replace("\Current", "\Preview"), False)
                    Skin_Loader.loadlines = IO.File.ReadAllLines(ShiftOSPath + "Shiftum42\Skins\Preview\skindata.dat")
                    Skin_Loader.loadskintopreview()
                    Skin_Loader.skinloaded = True
                End If
            Else
                infobox.showinfo("Application Not Found", "ShiftOS could not find an application able the open skin files.")
            End If

        ElseIf path Like "*.mp3" Then
            If ShiftOSDesktop.installedaudioplayer Then
                Audio_Player.lbmusiclist.Items.Add(path)
                Audio_Player.lblintro.Hide()
                Audio_Player.Show()
            Else
                infobox.showinfo("Application Not Found", "ShiftOS could not find an application able the open audio files.")
            End If

        ElseIf path Like "*.saa" Then
            File_Crypt.DecryptFile(path & "\" & path, ShiftOSDesktop.ShiftOSPath + "Shiftum42\Drivers\HDD.dri", ShiftOSDesktop.sSecretKey)
            Dim sr As StreamReader = New StreamReader(ShiftOSDesktop.ShiftOSPath + "Shiftum42\Drivers\HDD.dri")
            Dim apptoopen As String = sr.ReadLine()
            sr.Close()
            Select Case apptoopen.ToLower
                'Case "program name"
                '   Check requirements and open program
                Case "dodge"
                    Dodge.Show()
                Case "web browser"
                    If ShiftOSDesktop.boughtanycolour4 = True Then Web_Browser.Show() Else infobox.showinfo("Error", "The requirements for " & path & " are not meet. Please buy limitless colours.")
                Case "b1n0t3 h4ck"
                    Randomize()
                    Dim VirusChoice As Integer = CInt(Math.Ceiling(Rnd() * 4))
                    If VirusChoice = 1 Then
                        Viruses.zerogravity = True
                        Viruses.zerogravitythreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                        Viruses.setupzerovirus()
                    ElseIf VirusChoice = 2 Then
                        Viruses.beeper = True
                        Viruses.beeperthreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                        Viruses.setupbeepervirus()
                    ElseIf VirusChoice = 3 Then
                        Viruses.mousetrap = True
                        Viruses.mousetrapthreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                        Viruses.setupmousetrapvirus()
                    ElseIf VirusChoice = 4 Then
                        Viruses.ThePlague = True
                        Viruses.theplaguethreatlevel = CInt(Math.Floor((4) * Rnd())) + 1
                        Viruses.setuptheplague()
                    End If
                    infobox.title = "B1N0T3 H4CK3R - Error"
                    infobox.textinfo = "L0L Y0U JUST G0T R3KT #D341W1TH1T" & Environment.NewLine & Environment.NewLine & "(Enjoy your new virus)"
                    infobox.Show()
                Case "virus scanner"
                    If ShiftOSDesktop.boughtgray Then VirusScanner.Show() Else infobox.showinfo("Error", "The requirements for " & path & " are not meet. Please buy Gray.")
                Case "labyrinth"
                    If ShiftOSDesktop.boughtgray Then Labyrinth.Show() Else infobox.showinfo("Error", "The requirements for " & path & " are not meet. Please buy Gray.")
                Case "calculator"
                    Calculator.Show()
                Case "audio player"
                    Audio_Player.Show()
                Case "video player"
                    If ShiftOSDesktop.boughtanycolour4 Then Video_Player.Show() Else infobox.showinfo("Error", "The requirements for " & path & " are not meet. Please buy limitless colours.")
                    Video_Player.Show()
                Case "dock"
                    ShiftDock.Show()
                Case "virus grade 1 removal unlocker"
                    If ShiftOSDesktop.installedvirusscanner Then
                        If Math.Ceiling(Rnd() * 2) = 1 Then
                            infobox.showinfo("Virus Removal Unlocked", "Removal of grade 1 viruses has been unlocked in the Virus Scanner.")
                            If ShiftOSDesktop.virusscannergrade < 1 Then ShiftOSDesktop.virusscannergrade = 1
                        Else
                            infobox.showinfo("Lolz", "Haha, I just don't feel like doing anything today. Try me again some time and I MIGHT Lock it. For now, I'm hang out for the lolz!")
                        End If
                    End If
                Case "virus grade 2 removal unlocker"
                    If ShiftOSDesktop.installedvirusscanner Then
                        If Math.Ceiling(Rnd() * 2) = 1 Then
                            infobox.showinfo("Virus Removal Unlocked", "Removal of grade 2 viruses has been unlocked in the Virus Scanner.")
                            If ShiftOSDesktop.virusscannergrade < 2 Then ShiftOSDesktop.virusscannergrade = 2
                        Else
                            infobox.showinfo("Lolz", "Haha, I just don't feel like doing anything today. Try me again some time and I MIGHT Lock it. For now, I'm hang out for the lolz!")
                        End If
                    End If
                Case "virus grade 3 removal unlocker"
                    If ShiftOSDesktop.installedvirusscanner Then
                        If Math.Ceiling(Rnd() * 2) = 1 Then
                            infobox.showinfo("Virus Removal Unlocked", "Removal of grade 3 viruses has been unlocked in the Virus Scanner.")
                            If ShiftOSDesktop.virusscannergrade < 3 Then ShiftOSDesktop.virusscannergrade = 3
                        Else
                            infobox.showinfo("Lolz", "Haha, I just don't feel like doing anything today. Try me again some time and I MIGHT Lock it. For now, I'm hang out for the lolz!")
                        End If
                    End If
                Case "virus grade 4 removal unlocker"
                    If ShiftOSDesktop.installedvirusscanner Then
                        If Math.Ceiling(Rnd() * 2) = 1 Then
                            infobox.showinfo("Virus Removal Unlocked", "Removal of grade 4 viruses has been unlocked in the Virus Scanner.")
                            If ShiftOSDesktop.virusscannergrade < 4 Then ShiftOSDesktop.virusscannergrade = 4
                        Else
                            infobox.showinfo("Lolz", "Haha, I just don't feel like doing anything today. Try me again some time and I MIGHT Lock it. For now, I'm hang out for the lolz!")
                        End If
                    End If
                Case Else
                    infobox.title = "Corrupt file"
                    infobox.textinfo = "The stand alone application '" & path & "' seems to be corrupt and is unable to run properly."
                    infobox.Show()
            End Select
        ElseIf path Like "*.stp" Then
            Installer.Show()
            Installer.txtfilepath.Text = (path)
        ElseIf path Like "*.smf" Then
            NewAPI.OpenModFile(path)
        ElseIf path Like "*.trm" Then
            Terminal.Show()
            Terminal.runterminalfile(path)
        ElseIf path Like "*.sct" Then
            Dim sr As New IO.StreamReader(Path)
            Dim relayPath As String = sr.ReadToEnd()
            sr.Close()
            OpenFile(relayPath)
        ElseIf path Like "*.bat" Then
            If (ShiftOSDesktop.unitymode) Then
                Shell(path)
            Else
                If (ShiftOSDesktop.boughtunitymode) Then
                    infobox.title = "File Skimmer - Unity Mode:"
                    infobox.textinfo = "You do not have unity mode enabled. Enable unity mode to run shell scripts"
                    infobox.Show()
                Else
                    infobox.title = "File Skimmer - Unity Mode:"
                    infobox.textinfo = "You do not have unity mode"
                    infobox.Show()
                End If
            End If
        Else
            If My.Computer.FileSystem.DirectoryExists(path) Then
                lbllocation.Text = path
                showcontents()
            Else
                infobox.title = "Could not run file"
                infobox.textinfo = "Error running file"
                infobox.Show()
            End If

        End If

    End Sub
    Private Sub lbfiles_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvfiles.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            fileactions.Show(MousePosition)
        Else
            If lvfiles.SelectedItems(0).Text Like "*.*" Then
                btndeletefile.Text = "Delete File"
                btndeletefile.Image = My.Resources.deletefile
                btndeletefile.Size = New Size(117, 31)
            Else
                btndeletefile.Text = "Delete Folder"
                btndeletefile.Image = My.Resources.deletefolder
                btndeletefile.Size = New Size(130, 31)
            End If
        End If
    End Sub

    Private Sub pnlbreak_MouseEnter(sender As Object, e As EventArgs) Handles pnlbreak.Click
        If pnloptions.Visible = False Then
            pnlbreak.BackgroundImage = My.Resources.downarrow
            pnloptions.Show()
        Else
            pnlbreak.BackgroundImage = My.Resources.uparrow
            pnloptions.Hide()
        End If
    End Sub

    Private Sub btndeletefile_Click() Handles btndeletefile.Click
        If lvfiles.SelectedItems.Count > 0 Then
            If lvfiles.SelectedItems(0).Text Like "*.*" Then
                If lvfiles.SelectedItems(0).Text Like "*.dri*" Then
                    infobox.title = "File Skimmer - Warning!"
                    infobox.textinfo = "This system file is protected and cannot be deleted." & Environment.NewLine & Environment.NewLine & "Permission to delete this file has been blocked to protect the system from potential damage."
                    infobox.Show()
                ElseIf lvfiles.SelectedItems(0).Text Like "*.sft*" Then
                    infobox.title = "File Skimmer - Warning!"
                    infobox.textinfo = "This system file is protected and cannot be deleted." & Environment.NewLine & Environment.NewLine & "Permission to delete this file has been blocked to protect the system from potential damage."
                    infobox.Show()
                ElseIf lvfiles.SelectedItems(0).Text Like "*.lst*" Then
                    infobox.title = "File Skimmer - Warning!"
                    infobox.textinfo = "This system file is protected and cannot be deleted." & Environment.NewLine & Environment.NewLine & "Permission to delete this file has been blocked to protect the system from potential damage."
                    infobox.Show()
                ElseIf lvfiles.SelectedItems(0).Text Like "*.lang*" Then
                    infobox.title = "File Skimmer - Warning!"
                    infobox.textinfo = "This system file is protected and cannot be deleted." & Environment.NewLine & Environment.NewLine & "Permission to delete this file has been blocked to protect the system from potential damage."
                    infobox.Show()
                ElseIf lvfiles.SelectedItems(0).Text Like "Exit Folder" Then
                    infobox.title = "File Skimmer - Warning!"
                    infobox.textinfo = "You cannot delete this folder."
                    infobox.Show()
                Else
                    My.Computer.FileSystem.DeleteFile(lbllocation.Text & "/" & lvfiles.SelectedItems(0).Text)
                    My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                    showcontents()
                End If
            Else
                Select Case lvfiles.SelectedItems(0).Text
                    Case "Shiftum42", "SoftwareData", "Drivers", "Languages", "KnowledgeInput"
                        infobox.title = "File Skimmer - Warning!"
                        infobox.textinfo = "This system folder is protected and cannot be deleted." & Environment.NewLine & Environment.NewLine & "Permission to delete this folder has been blocked to protect the system from potential damage."
                        infobox.Show()
                    Case Else
                        Try
                            My.Computer.FileSystem.DeleteDirectory(lbllocation.Text & "/" & lvfiles.SelectedItems(0).Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
                            My.Computer.Audio.Play(My.Resources.writesound, AudioPlayMode.Background)
                            showcontents()
                        Catch ex As Exception
                            infobox.title = "File Skimmer - Error!"
                            infobox.textinfo = "Failed to delete the folder / file(s)."
                            infobox.Show()
                        End Try
                End Select
            End If
        End If
    End Sub

    Private Sub btnnewfolder_Click(sender As Object, e As EventArgs) Handles btnnewfolder.Click
        infobox.lblintructtext.Text = "Please enter a name for your new folder:"
        infobox.txtuserinput.Text = ""
        infobox.lblintructtext.Show()
        infobox.txtuserinput.Show()
        infobox.title = "New Folder"
        infobox.Show()
        infobox.state = "makingfolder"
    End Sub

    Public Sub makefolder()
        My.Computer.FileSystem.CreateDirectory(lbllocation.Text & "/" & infobox.txtuserinput.Text)
        showcontents()
        infobox.Close()
    End Sub

    Private Sub setupoptions()
        If ShiftOSDesktop.boughtfileskimmernewfolder = True Then btnnewfolder.Show() Else btnnewfolder.Hide()
        If ShiftOSDesktop.boughtfileskimmerdelete = True Then btndeletefile.Show() Else btndeletefile.Hide()
        If ShiftOSDesktop.boughtfileskimmernewfolder = False AndAlso ShiftOSDesktop.boughtfileskimmerdelete = False Then pnlbreak.Hide()
    End Sub

    Private Sub lvfiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvfiles.SelectedIndexChanged

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        btndeletefile_Click()
    End Sub


End Class