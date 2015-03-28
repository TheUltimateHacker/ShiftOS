<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Web_Browser
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
        Me.pullside = New System.Windows.Forms.Timer(Me.components)
        Me.pullbs = New System.Windows.Forms.Timer(Me.components)
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.pnlwebtabholder = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnhome = New System.Windows.Forms.Button()
        Me.txtlocation = New System.Windows.Forms.TextBox()
        Me.btnforward = New System.Windows.Forms.Button()
        Me.btnback = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnloptions = New System.Windows.Forms.Panel()
        Me.siteloadprogress = New ShiftOS.ProgressBarEX()
        Me.pnltab4 = New System.Windows.Forms.Panel()
        Me.lbltab4 = New System.Windows.Forms.Label()
        Me.pnltab3 = New System.Windows.Forms.Panel()
        Me.lbltab3 = New System.Windows.Forms.Label()
        Me.pnltab2 = New System.Windows.Forms.Panel()
        Me.lbltab2 = New System.Windows.Forms.Label()
        Me.pnltab1 = New System.Windows.Forms.Panel()
        Me.lbltab1 = New System.Windows.Forms.Label()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.webwindowt1 = New Skybound.Gecko.GeckoWebBrowser()
        Me.webwindowt2 = New Skybound.Gecko.GeckoWebBrowser()
        Me.webwindowt3 = New Skybound.Gecko.GeckoWebBrowser()
        Me.webwindowt4 = New Skybound.Gecko.GeckoWebBrowser()
        Me.pgright.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        Me.pnlwebtabholder.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnloptions.SuspendLayout()
        Me.pnltab4.SuspendLayout()
        Me.pnltab3.SuspendLayout()
        Me.pnltab2.SuspendLayout()
        Me.pnltab1.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pullside
        '
        Me.pullside.Interval = 1
        '
        'pullbs
        '
        Me.pullbs.Interval = 1
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 598)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(1054, 2)
        Me.pgbottom.TabIndex = 23
        '
        'pullbottom
        '
        Me.pullbottom.Interval = 1
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(246, 5)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'rollupbutton
        '
        Me.rollupbutton.BackColor = System.Drawing.Color.Black
        Me.rollupbutton.Location = New System.Drawing.Point(274, 3)
        Me.rollupbutton.Name = "rollupbutton"
        Me.rollupbutton.Size = New System.Drawing.Size(22, 22)
        Me.rollupbutton.TabIndex = 22
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 568)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(1056, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 570)
        Me.pgright.TabIndex = 22
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
        Me.lbtitletext.Size = New System.Drawing.Size(110, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Web Browser"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(1056, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 568)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.pnlwebtabholder)
        Me.pgcontents.Controls.Add(Me.Panel1)
        Me.pgcontents.Controls.Add(Me.pnloptions)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(1054, 568)
        Me.pgcontents.TabIndex = 20
        '
        'pnlwebtabholder
        '
        Me.pnlwebtabholder.Controls.Add(Me.webwindowt4)
        Me.pnlwebtabholder.Controls.Add(Me.webwindowt3)
        Me.pnlwebtabholder.Controls.Add(Me.webwindowt2)
        Me.pnlwebtabholder.Controls.Add(Me.webwindowt1)
        Me.pnlwebtabholder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlwebtabholder.Location = New System.Drawing.Point(0, 36)
        Me.pnlwebtabholder.Name = "pnlwebtabholder"
        Me.pnlwebtabholder.Size = New System.Drawing.Size(1054, 487)
        Me.pnlwebtabholder.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnhome)
        Me.Panel1.Controls.Add(Me.txtlocation)
        Me.Panel1.Controls.Add(Me.btnforward)
        Me.Panel1.Controls.Add(Me.btnback)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1054, 36)
        Me.Panel1.TabIndex = 0
        '
        'btnhome
        '
        Me.btnhome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnhome.BackColor = System.Drawing.Color.White
        Me.btnhome.BackgroundImage = Global.ShiftOS.My.Resources.Resources.webhome
        Me.btnhome.FlatAppearance.BorderSize = 0
        Me.btnhome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnhome.Location = New System.Drawing.Point(1019, 5)
        Me.btnhome.Name = "btnhome"
        Me.btnhome.Size = New System.Drawing.Size(30, 25)
        Me.btnhome.TabIndex = 10
        Me.btnhome.UseVisualStyleBackColor = False
        '
        'txtlocation
        '
        Me.txtlocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtlocation.BackColor = System.Drawing.Color.White
        Me.txtlocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlocation.Location = New System.Drawing.Point(73, 5)
        Me.txtlocation.Multiline = True
        Me.txtlocation.Name = "txtlocation"
        Me.txtlocation.Size = New System.Drawing.Size(942, 25)
        Me.txtlocation.TabIndex = 9
        Me.txtlocation.Text = "Search or Enter an address"
        '
        'btnforward
        '
        Me.btnforward.BackColor = System.Drawing.Color.White
        Me.btnforward.BackgroundImage = Global.ShiftOS.My.Resources.Resources.webforward
        Me.btnforward.FlatAppearance.BorderSize = 0
        Me.btnforward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnforward.Location = New System.Drawing.Point(39, 5)
        Me.btnforward.Name = "btnforward"
        Me.btnforward.Size = New System.Drawing.Size(30, 25)
        Me.btnforward.TabIndex = 8
        Me.btnforward.UseVisualStyleBackColor = False
        '
        'btnback
        '
        Me.btnback.BackColor = System.Drawing.Color.White
        Me.btnback.BackgroundImage = Global.ShiftOS.My.Resources.Resources.webback
        Me.btnback.FlatAppearance.BorderSize = 0
        Me.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnback.Location = New System.Drawing.Point(5, 5)
        Me.btnback.Name = "btnback"
        Me.btnback.Size = New System.Drawing.Size(30, 25)
        Me.btnback.TabIndex = 7
        Me.btnback.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 35)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1054, 1)
        Me.Panel2.TabIndex = 6
        '
        'pnloptions
        '
        Me.pnloptions.Controls.Add(Me.siteloadprogress)
        Me.pnloptions.Controls.Add(Me.pnltab4)
        Me.pnloptions.Controls.Add(Me.pnltab3)
        Me.pnloptions.Controls.Add(Me.pnltab2)
        Me.pnloptions.Controls.Add(Me.pnltab1)
        Me.pnloptions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnloptions.Location = New System.Drawing.Point(0, 523)
        Me.pnloptions.Name = "pnloptions"
        Me.pnloptions.Size = New System.Drawing.Size(1054, 45)
        Me.pnloptions.TabIndex = 5
        '
        'siteloadprogress
        '
        Me.siteloadprogress.BackColor = System.Drawing.Color.White
        Me.siteloadprogress.BlockSeparation = 3
        Me.siteloadprogress.BlockWidth = 5
        Me.siteloadprogress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.siteloadprogress.Color = System.Drawing.Color.Gray
        Me.siteloadprogress.Dock = System.Windows.Forms.DockStyle.Top
        Me.siteloadprogress.Location = New System.Drawing.Point(0, 0)
        Me.siteloadprogress.MaxValue = 100
        Me.siteloadprogress.MinValue = 0
        Me.siteloadprogress.Name = "siteloadprogress"
        Me.siteloadprogress.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal
        Me.siteloadprogress.ShowValue = False
        Me.siteloadprogress.Size = New System.Drawing.Size(1054, 10)
        Me.siteloadprogress.Step = 10
        Me.siteloadprogress.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous
        Me.siteloadprogress.TabIndex = 20
        Me.siteloadprogress.Value = 0
        '
        'pnltab4
        '
        Me.pnltab4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnltab4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnltab4.Controls.Add(Me.lbltab4)
        Me.pnltab4.Location = New System.Drawing.Point(513, 15)
        Me.pnltab4.Name = "pnltab4"
        Me.pnltab4.Size = New System.Drawing.Size(170, 26)
        Me.pnltab4.TabIndex = 19
        '
        'lbltab4
        '
        Me.lbltab4.AutoSize = True
        Me.lbltab4.BackColor = System.Drawing.Color.Transparent
        Me.lbltab4.Location = New System.Drawing.Point(5, 7)
        Me.lbltab4.Name = "lbltab4"
        Me.lbltab4.Size = New System.Drawing.Size(56, 13)
        Me.lbltab4.TabIndex = 1
        Me.lbltab4.Text = "Blank Tab"
        '
        'pnltab3
        '
        Me.pnltab3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnltab3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnltab3.Controls.Add(Me.lbltab3)
        Me.pnltab3.Location = New System.Drawing.Point(344, 15)
        Me.pnltab3.Name = "pnltab3"
        Me.pnltab3.Size = New System.Drawing.Size(170, 26)
        Me.pnltab3.TabIndex = 18
        '
        'lbltab3
        '
        Me.lbltab3.AutoSize = True
        Me.lbltab3.BackColor = System.Drawing.Color.Transparent
        Me.lbltab3.Location = New System.Drawing.Point(4, 7)
        Me.lbltab3.Name = "lbltab3"
        Me.lbltab3.Size = New System.Drawing.Size(56, 13)
        Me.lbltab3.TabIndex = 1
        Me.lbltab3.Text = "Blank Tab"
        '
        'pnltab2
        '
        Me.pnltab2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnltab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnltab2.Controls.Add(Me.lbltab2)
        Me.pnltab2.Location = New System.Drawing.Point(175, 15)
        Me.pnltab2.Name = "pnltab2"
        Me.pnltab2.Size = New System.Drawing.Size(170, 26)
        Me.pnltab2.TabIndex = 17
        '
        'lbltab2
        '
        Me.lbltab2.AutoSize = True
        Me.lbltab2.BackColor = System.Drawing.Color.Transparent
        Me.lbltab2.Location = New System.Drawing.Point(3, 7)
        Me.lbltab2.Name = "lbltab2"
        Me.lbltab2.Size = New System.Drawing.Size(56, 13)
        Me.lbltab2.TabIndex = 1
        Me.lbltab2.Text = "Blank Tab"
        '
        'pnltab1
        '
        Me.pnltab1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnltab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnltab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnltab1.Controls.Add(Me.lbltab1)
        Me.pnltab1.Location = New System.Drawing.Point(6, 15)
        Me.pnltab1.Name = "pnltab1"
        Me.pnltab1.Size = New System.Drawing.Size(170, 26)
        Me.pnltab1.TabIndex = 16
        '
        'lbltab1
        '
        Me.lbltab1.AutoSize = True
        Me.lbltab1.BackColor = System.Drawing.Color.Transparent
        Me.lbltab1.Location = New System.Drawing.Point(3, 7)
        Me.lbltab1.Name = "lbltab1"
        Me.lbltab1.Size = New System.Drawing.Size(56, 13)
        Me.lbltab1.TabIndex = 0
        Me.lbltab1.Text = "Blank Tab"
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 570)
        Me.pgleft.TabIndex = 21
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
        Me.titlebar.Size = New System.Drawing.Size(1058, 30)
        Me.titlebar.TabIndex = 19
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconWebBrowser
        Me.pnlicon.Location = New System.Drawing.Point(8, 8)
        Me.pnlicon.Name = "pnlicon"
        Me.pnlicon.Size = New System.Drawing.Size(16, 16)
        Me.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlicon.TabIndex = 24
        Me.pnlicon.TabStop = False
        Me.pnlicon.Visible = False
        '
        'webwindowt1
        '
        Me.webwindowt1.Location = New System.Drawing.Point(100, 62)
        Me.webwindowt1.Name = "webwindowt1"
        Me.webwindowt1.Size = New System.Drawing.Size(135, 84)
        Me.webwindowt1.TabIndex = 0
        '
        'webwindowt2
        '
        Me.webwindowt2.Location = New System.Drawing.Point(352, 122)
        Me.webwindowt2.Name = "webwindowt2"
        Me.webwindowt2.Size = New System.Drawing.Size(75, 23)
        Me.webwindowt2.TabIndex = 1
        '
        'webwindowt3
        '
        Me.webwindowt3.Location = New System.Drawing.Point(476, 122)
        Me.webwindowt3.Name = "webwindowt3"
        Me.webwindowt3.Size = New System.Drawing.Size(75, 23)
        Me.webwindowt3.TabIndex = 2
        '
        'webwindowt4
        '
        Me.webwindowt4.Location = New System.Drawing.Point(218, 175)
        Me.webwindowt4.Name = "webwindowt4"
        Me.webwindowt4.Size = New System.Drawing.Size(75, 23)
        Me.webwindowt4.TabIndex = 3
        '
        'Web_Browser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 600)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "Web_Browser"
        Me.Text = "Web_Browser"
        Me.TopMost = True
        Me.pgright.ResumeLayout(False)
        Me.pgcontents.ResumeLayout(False)
        Me.pnlwebtabholder.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnloptions.ResumeLayout(False)
        Me.pnltab4.ResumeLayout(False)
        Me.pnltab4.PerformLayout()
        Me.pnltab3.ResumeLayout(False)
        Me.pnltab3.PerformLayout()
        Me.pnltab2.ResumeLayout(False)
        Me.pnltab2.PerformLayout()
        Me.pnltab1.ResumeLayout(False)
        Me.pnltab1.PerformLayout()
        Me.pgleft.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnhome As System.Windows.Forms.Button
    Friend WithEvents txtlocation As System.Windows.Forms.TextBox
    Friend WithEvents btnforward As System.Windows.Forms.Button
    Friend WithEvents btnback As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnloptions As System.Windows.Forms.Panel
    Friend WithEvents pnltab4 As System.Windows.Forms.Panel
    Friend WithEvents lbltab4 As System.Windows.Forms.Label
    Friend WithEvents pnltab3 As System.Windows.Forms.Panel
    Friend WithEvents lbltab3 As System.Windows.Forms.Label
    Friend WithEvents pnltab2 As System.Windows.Forms.Panel
    Friend WithEvents lbltab2 As System.Windows.Forms.Label
    Friend WithEvents pnltab1 As System.Windows.Forms.Panel
    Friend WithEvents lbltab1 As System.Windows.Forms.Label
    Friend WithEvents pnlwebtabholder As System.Windows.Forms.Panel
    Friend WithEvents siteloadprogress As ShiftOS.ProgressBarEX
    Friend WithEvents webwindowt4 As Skybound.Gecko.GeckoWebBrowser
    Friend WithEvents webwindowt3 As Skybound.Gecko.GeckoWebBrowser
    Friend WithEvents webwindowt2 As Skybound.Gecko.GeckoWebBrowser
    Friend WithEvents webwindowt1 As Skybound.Gecko.GeckoWebBrowser
End Class
