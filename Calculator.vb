Public Class Calculator
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Public dNumber As Double
    Public sOperation As String
    Public bHasFirstNumber, bHasSecondNumber, bHasOperation As Boolean

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

        dNumber = 0
        bHasFirstNumber = False
        bHasOperation = False
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            Me.Size = New Size(261, 278) 'put the default size of your window here
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
            lbtitletext.Text = ShiftOSDesktop.calculatorname
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
            pnlicon.Image = ShiftOSDesktop.calculatoricontitlebar 'Replace with the correct icon for the program.
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

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
        Me.Hide()
        ShiftOSDesktop.setuppanelbuttons()
    End Sub

    'end of general setup

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 1
                    bHasSecondNumber = True
                    Exit Sub
                End If
                Me.lbldispla.Text &= 1
                Exit Sub
            End If
            Me.lbldispla.Text &= 1
        Else
            Me.lbldispla.Text = 1
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 2
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 2
                Exit Sub
            End If
            Me.lbldispla.Text &= 2
        Else
            Me.lbldispla.Text = 2
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 3
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 3
                Exit Sub
            End If
            Me.lbldispla.Text &= 3
        Else
            Me.lbldispla.Text = 3
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 4
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 4
                Exit Sub
            End If
            Me.lbldispla.Text &= 4
        Else
            Me.lbldispla.Text = 4
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 5
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 5
                Exit Sub
            End If
            Me.lbldispla.Text &= 5
        Else
            Me.lbldispla.Text = 5
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 6
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 6
                Exit Sub
            End If
            Me.lbldispla.Text &= 6
        Else
            Me.lbldispla.Text = 6
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 7
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 7
                Exit Sub
            End If
            Me.lbldispla.Text &= 7
        Else
            Me.lbldispla.Text = 7
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 8
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 8
                Exit Sub
            End If
            Me.lbldispla.Text &= 8
        Else
            Me.lbldispla.Text = 8
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn9.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text = 0 Then
                    Me.lbldispla.Text = 9
                    bHasSecondNumber = True

                    Exit Sub
                End If

                Me.lbldispla.Text &= 9
                Exit Sub
            End If
            Me.lbldispla.Text &= 9
        Else
            Me.lbldispla.Text = 9
            bHasFirstNumber = True
            bHasOperation = False
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        If bHasFirstNumber Then
            If dNumber <> 0 Then
                If Me.lbldispla.Text <> 0 Then
                    Me.lbldispla.Text &= 0
                End If
                Exit Sub
            End If
            Me.lbldispla.Text &= 0
        Else
            Me.lbldispla.Text = 0
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnequals.Click
        If bHasFirstNumber And bHasSecondNumber Then

            If (sOperation = "+") Then
                Me.lbldispla.Text = Val(Me.lbldispla.Text) + dNumber
            ElseIf (sOperation = "-") Then
                Me.lbldispla.Text = dNumber - Val(Me.lbldispla.Text)
            ElseIf (sOperation = "*") Then
                Me.lbldispla.Text = Val(Me.lbldispla.Text) * dNumber
            ElseIf (sOperation = "/") Then
                Me.lbldispla.Text = dNumber / Val(Me.lbldispla.Text)
            Else
                Exit Sub
            End If

            dNumber = Val(Me.lbldispla.Text)
            bHasFirstNumber = False
            bHasSecondNumber = False
            bHasOperation = True
            sOperation = ""
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnplus.Click

        If bHasSecondNumber Then

            If bHasOperation Then
                If (sOperation = "+") Then
                    dNumber = Val(Me.lbldispla.Text) + dNumber
                ElseIf (sOperation = "-") Then
                    dNumber = dNumber - Val(Me.lbldispla.Text)
                ElseIf (sOperation = "*") Then
                    dNumber = Val(Me.lbldispla.Text) * dNumber
                ElseIf (sOperation = "/") Then
                    dNumber = dNumber / Val(Me.lbldispla.Text)
                Else
                    Exit Sub
                End If

                sOperation = "+"
                bHasSecondNumber = False
                Me.lbldispla.Text = 0

                Exit Sub
            Else
                sOperation = "+"
                dNumber = Val(Me.lbldispla.Text) + dNumber
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            End If
        End If

        If bHasFirstNumber Or bHasOperation Then
            If bHasOperation Then
                bHasFirstNumber = True
            End If
            sOperation = "+"
            bHasOperation = True
            dNumber = Val(Me.lbldispla.Text)
            Me.lbldispla.Text = 0
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnminus.Click
        If bHasSecondNumber Then
            If bHasOperation Then
                If (sOperation = "+") Then
                    dNumber = Val(Me.lbldispla.Text) + dNumber
                ElseIf (sOperation = "-") Then
                    dNumber = dNumber - Val(Me.lbldispla.Text)
                ElseIf (sOperation = "*") Then
                    dNumber = Val(Me.lbldispla.Text) * dNumber
                ElseIf (sOperation = "/") Then
                    dNumber = dNumber / Val(Me.lbldispla.Text)
                Else
                    Exit Sub
                End If
                sOperation = "-"
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            Else
                sOperation = "-"
                dNumber = dNumber - Val(Me.lbldispla.Text)
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            End If
        End If
        If bHasFirstNumber Or bHasOperation Then
            If bHasOperation Then
                bHasFirstNumber = True
            End If
            sOperation = "-"
            dNumber = Val(Me.lbldispla.Text)
            Me.lbldispla.Text = 0
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntimes.Click
        If bHasSecondNumber Then
            If bHasOperation Then
                If (sOperation = "+") Then
                    dNumber = Val(Me.lbldispla.Text) + dNumber
                ElseIf (sOperation = "-") Then
                    dNumber = dNumber - Val(Me.lbldispla.Text)
                ElseIf (sOperation = "*") Then
                    dNumber = Val(Me.lbldispla.Text) * dNumber
                ElseIf (sOperation = "/") Then
                    dNumber = dNumber / Val(Me.lbldispla.Text)
                Else
                    Exit Sub
                End If
                sOperation = "*"
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            Else
                sOperation = "*"
                dNumber = Val(Me.lbldispla.Text) * dNumber
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            End If
        End If
        If bHasFirstNumber Or bHasOperation Then
            If bHasOperation Then
                bHasFirstNumber = True
            End If
            sOperation = "*"
            dNumber = Val(Me.lbldispla.Text)
            Me.lbldispla.Text = 0
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndividedby.Click
        If bHasSecondNumber Then
            If bHasOperation Then
                If (sOperation = "+") Then
                    dNumber = Val(Me.lbldispla.Text) + dNumber
                ElseIf (sOperation = "-") Then
                    dNumber = dNumber - Val(Me.lbldispla.Text)
                ElseIf (sOperation = "*") Then
                    dNumber = Val(Me.lbldispla.Text) * dNumber
                ElseIf (sOperation = "/") Then
                    dNumber = dNumber / Val(Me.lbldispla.Text)
                Else
                    Exit Sub
                End If
                sOperation = "/"
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            Else
                sOperation = "/"
                dNumber = dNumber / Val(Me.lbldispla.Text)
                bHasSecondNumber = False
                Me.lbldispla.Text = 0
                Exit Sub
            End If
        End If
        If bHasFirstNumber Or bHasOperation Then
            If bHasOperation Then
                bHasFirstNumber = True
            End If
            sOperation = "/"
            dNumber = Val(Me.lbldispla.Text)
            Me.lbldispla.Text = 0
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclearall.Click
        Me.lbldispla.Text = 0
        dNumber = 0
        bHasFirstNumber = False
        bHasSecondNumber = False
        bHasOperation = False
        sOperation = ""
    End Sub
End Class