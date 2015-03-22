<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Audio_Player
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Audio_Player))
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.lblintro = New System.Windows.Forms.Label()
        Me.lbmusiclist = New System.Windows.Forms.ListBox()
        Me.pnlcontrols = New System.Windows.Forms.Panel()
        Me.picsongtrack = New System.Windows.Forms.PictureBox()
        Me.btnplay = New System.Windows.Forms.Button()
        Me.lbltotallength = New System.Windows.Forms.Label()
        Me.btnload = New System.Windows.Forms.Button()
        Me.lblcurrenttime = New System.Windows.Forms.Label()
        Me.btnstop = New System.Windows.Forms.Button()
        Me.btnprevious = New System.Windows.Forms.Button()
        Me.btnnext = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pullside = New System.Windows.Forms.Timer(Me.components)
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.pullbs = New System.Windows.Forms.Timer(Me.components)
        Me.tmrnextsonggap = New System.Windows.Forms.Timer(Me.components)
        Me.tmrsongtrack = New System.Windows.Forms.Timer(Me.components)
        Me.tmrnextcooldown = New System.Windows.Forms.Timer(Me.components)
        Me.pgcontents.SuspendLayout()
        Me.pnlcontrols.SuspendLayout()
        CType(Me.picsongtrack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgright.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.lblintro)
        Me.pgcontents.Controls.Add(Me.lbmusiclist)
        Me.pgcontents.Controls.Add(Me.pnlcontrols)
        Me.pgcontents.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(467, 234)
        Me.pgcontents.TabIndex = 20
        '
        'lblintro
        '
        Me.lblintro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblintro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblintro.Location = New System.Drawing.Point(27, 25)
        Me.lblintro.Name = "lblintro"
        Me.lblintro.Size = New System.Drawing.Size(414, 160)
        Me.lblintro.TabIndex = 11
        Me.lblintro.Text = "Your Playlist is Currently Empty" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click the folder icon in the bottom right corne" & _
    "r to add some songs"
        Me.lblintro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbmusiclist
        '
        Me.lbmusiclist.BackColor = System.Drawing.Color.White
        Me.lbmusiclist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbmusiclist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbmusiclist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbmusiclist.FormattingEnabled = True
        Me.lbmusiclist.Location = New System.Drawing.Point(0, 0)
        Me.lbmusiclist.Name = "lbmusiclist"
        Me.lbmusiclist.Size = New System.Drawing.Size(467, 208)
        Me.lbmusiclist.TabIndex = 1
        '
        'pnlcontrols
        '
        Me.pnlcontrols.BackColor = System.Drawing.Color.White
        Me.pnlcontrols.Controls.Add(Me.picsongtrack)
        Me.pnlcontrols.Controls.Add(Me.btnplay)
        Me.pnlcontrols.Controls.Add(Me.lbltotallength)
        Me.pnlcontrols.Controls.Add(Me.btnload)
        Me.pnlcontrols.Controls.Add(Me.lblcurrenttime)
        Me.pnlcontrols.Controls.Add(Me.btnstop)
        Me.pnlcontrols.Controls.Add(Me.btnprevious)
        Me.pnlcontrols.Controls.Add(Me.btnnext)
        Me.pnlcontrols.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlcontrols.Location = New System.Drawing.Point(0, 208)
        Me.pnlcontrols.Name = "pnlcontrols"
        Me.pnlcontrols.Size = New System.Drawing.Size(467, 26)
        Me.pnlcontrols.TabIndex = 10
        '
        'picsongtrack
        '
        Me.picsongtrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picsongtrack.Location = New System.Drawing.Point(113, 2)
        Me.picsongtrack.Name = "picsongtrack"
        Me.picsongtrack.Size = New System.Drawing.Size(304, 21)
        Me.picsongtrack.TabIndex = 9
        Me.picsongtrack.TabStop = False
        '
        'btnplay
        '
        Me.btnplay.BackgroundImage = Global.ShiftOS.My.Resources.Resources.playbutton
        Me.btnplay.FlatAppearance.BorderSize = 0
        Me.btnplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnplay.Location = New System.Drawing.Point(26, 2)
        Me.btnplay.Name = "btnplay"
        Me.btnplay.Size = New System.Drawing.Size(22, 22)
        Me.btnplay.TabIndex = 2
        Me.btnplay.UseVisualStyleBackColor = True
        '
        'lbltotallength
        '
        Me.lbltotallength.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotallength.BackColor = System.Drawing.Color.Transparent
        Me.lbltotallength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotallength.Location = New System.Drawing.Point(377, 1)
        Me.lbltotallength.Name = "lbltotallength"
        Me.lbltotallength.Size = New System.Drawing.Size(40, 24)
        Me.lbltotallength.TabIndex = 8
        Me.lbltotallength.Text = "0:00"
        Me.lbltotallength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnload
        '
        Me.btnload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnload.BackgroundImage = Global.ShiftOS.My.Resources.Resources.loadbutton
        Me.btnload.FlatAppearance.BorderSize = 0
        Me.btnload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnload.Location = New System.Drawing.Point(443, 2)
        Me.btnload.Name = "btnload"
        Me.btnload.Size = New System.Drawing.Size(22, 22)
        Me.btnload.TabIndex = 3
        Me.btnload.UseVisualStyleBackColor = True
        '
        'lblcurrenttime
        '
        Me.lblcurrenttime.BackColor = System.Drawing.Color.Transparent
        Me.lblcurrenttime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcurrenttime.Location = New System.Drawing.Point(74, 1)
        Me.lblcurrenttime.Name = "lblcurrenttime"
        Me.lblcurrenttime.Size = New System.Drawing.Size(40, 24)
        Me.lblcurrenttime.TabIndex = 7
        Me.lblcurrenttime.Text = "0:00"
        Me.lblcurrenttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnstop
        '
        Me.btnstop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnstop.BackgroundImage = Global.ShiftOS.My.Resources.Resources.stopbutton
        Me.btnstop.FlatAppearance.BorderSize = 0
        Me.btnstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnstop.Location = New System.Drawing.Point(419, 2)
        Me.btnstop.Name = "btnstop"
        Me.btnstop.Size = New System.Drawing.Size(22, 22)
        Me.btnstop.TabIndex = 4
        Me.btnstop.UseVisualStyleBackColor = True
        '
        'btnprevious
        '
        Me.btnprevious.BackgroundImage = Global.ShiftOS.My.Resources.Resources.previousbutton
        Me.btnprevious.FlatAppearance.BorderSize = 0
        Me.btnprevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnprevious.Location = New System.Drawing.Point(2, 2)
        Me.btnprevious.Name = "btnprevious"
        Me.btnprevious.Size = New System.Drawing.Size(22, 22)
        Me.btnprevious.TabIndex = 6
        Me.btnprevious.UseVisualStyleBackColor = True
        '
        'btnnext
        '
        Me.btnnext.BackgroundImage = Global.ShiftOS.My.Resources.Resources.nextbutton
        Me.btnnext.FlatAppearance.BorderSize = 0
        Me.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnext.Location = New System.Drawing.Point(50, 2)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(22, 22)
        Me.btnnext.TabIndex = 5
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(300, 55)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(31, 29)
        Me.AxWindowsMediaPlayer1.TabIndex = 0
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 264)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(467, 2)
        Me.pgbottom.TabIndex = 23
        '
        'titlebar
        '
        Me.titlebar.BackColor = System.Drawing.Color.Gray
        Me.titlebar.Controls.Add(Me.minimizebutton)
        Me.titlebar.Controls.Add(Me.pnlicon)
        Me.titlebar.Controls.Add(Me.rollupbutton)
        Me.titlebar.Controls.Add(Me.closebutton)
        Me.titlebar.Controls.Add(Me.lbtitletext)
        Me.titlebar.Controls.Add(Me.pgtoplcorner)
        Me.titlebar.Controls.Add(Me.pgtoprcorner)
        Me.titlebar.Dock = System.Windows.Forms.DockStyle.Top
        Me.titlebar.ForeColor = System.Drawing.Color.White
        Me.titlebar.Location = New System.Drawing.Point(0, 0)
        Me.titlebar.Name = "titlebar"
        Me.titlebar.Size = New System.Drawing.Size(471, 30)
        Me.titlebar.TabIndex = 19
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(246, 5)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconAudioPlayer
        Me.pnlicon.Location = New System.Drawing.Point(8, 8)
        Me.pnlicon.Name = "pnlicon"
        Me.pnlicon.Size = New System.Drawing.Size(16, 16)
        Me.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlicon.TabIndex = 24
        Me.pnlicon.TabStop = False
        Me.pnlicon.Visible = False
        '
        'rollupbutton
        '
        Me.rollupbutton.BackColor = System.Drawing.Color.Black
        Me.rollupbutton.Location = New System.Drawing.Point(274, 3)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'closebutton
        '
        Me.closebutton.BackColor = System.Drawing.Color.Black
        Me.closebutton.Location = New System.Drawing.Point(302, 3)
        Me.closebutton.Name = "closebutton"
        Me.closebutton.Size = New System.Drawing.Size(22, 22)
        Me.closebutton.TabIndex = 20
        '
        'lbtitletext
        '
        Me.lbtitletext.AutoSize = True
        Me.lbtitletext.BackColor = System.Drawing.Color.Transparent
        Me.lbtitletext.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(102, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Audio Player"
        '
        'pgtoplcorner
        '
        Me.pgtoplcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoplcorner.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgtoplcorner.Location = New System.Drawing.Point(0, 0)
        Me.pgtoplcorner.Name = "pgtoplcorner"
        Me.pgtoplcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoplcorner.TabIndex = 17
        '
        'pgtoprcorner
        '
        Me.pgtoprcorner.BackColor = System.Drawing.Color.Red
        Me.pgtoprcorner.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgtoprcorner.Location = New System.Drawing.Point(469, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 234)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(469, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 236)
        Me.pgright.TabIndex = 22
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 236)
        Me.pgleft.TabIndex = 21
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 234)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pullside
        '
        Me.pullside.Interval = 1
        '
        'pullbottom
        '
        Me.pullbottom.Interval = 1
        '
        'pullbs
        '
        Me.pullbs.Interval = 1
        '
        'tmrnextsonggap
        '
        '
        'tmrsongtrack
        '
        Me.tmrsongtrack.Enabled = True
        Me.tmrsongtrack.Interval = 200
        '
        'tmrnextcooldown
        '
        Me.tmrnextcooldown.Interval = 1000
        '
        'Audio_Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 266)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(151, 125)
        Me.Name = "Audio_Player"
        Me.Text = "Audio_Player"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pnlcontrols.ResumeLayout(False)
        CType(Me.picsongtrack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgright.ResumeLayout(False)
        Me.pgleft.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents btnplay As System.Windows.Forms.Button
    Friend WithEvents lbmusiclist As System.Windows.Forms.ListBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnstop As System.Windows.Forms.Button
    Friend WithEvents btnload As System.Windows.Forms.Button
    Friend WithEvents tmrnextsonggap As System.Windows.Forms.Timer
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents btnprevious As System.Windows.Forms.Button
    Friend WithEvents lbltotallength As System.Windows.Forms.Label
    Friend WithEvents lblcurrenttime As System.Windows.Forms.Label
    Friend WithEvents tmrsongtrack As System.Windows.Forms.Timer
    Friend WithEvents picsongtrack As System.Windows.Forms.PictureBox
    Friend WithEvents tmrnextcooldown As System.Windows.Forms.Timer
    Friend WithEvents pnlcontrols As System.Windows.Forms.Panel
    Friend WithEvents lblintro As System.Windows.Forms.Label
End Class
