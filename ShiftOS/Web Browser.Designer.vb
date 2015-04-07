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
        Me.tabs = New TabControl 'ShiftOS.ShiftOSTabs()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnhome = New System.Windows.Forms.Button()
        Me.txtlocation = New System.Windows.Forms.TextBox()
        Me.btnforward = New System.Windows.Forms.Button()
        Me.btnback = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnloptions = New System.Windows.Forms.Panel()
        Me.btnRemTab = New System.Windows.Forms.Button()
        Me.btnAddTab = New System.Windows.Forms.Button()
        Me.siteloadprogress = New ShiftOS.ProgressBarEX()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.TabText = New System.Windows.Forms.Timer(Me.components)
        Me.UrlText = New System.Windows.Forms.Timer(Me.components)
        Me.Progress = New System.Windows.Forms.Timer(Me.components)
        Me.BrowserProgress = New ShiftOS.ProgressBarEX()
        Me.pgright.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        Me.pnlwebtabholder.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnloptions.SuspendLayout()
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
        Me.pnlwebtabholder.Controls.Add(Me.tabs)
        Me.pnlwebtabholder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlwebtabholder.Location = New System.Drawing.Point(0, 36)
        Me.pnlwebtabholder.Name = "pnlwebtabholder"
        Me.pnlwebtabholder.Size = New System.Drawing.Size(1054, 487)
        Me.pnlwebtabholder.TabIndex = 6
        '
        'tabs
        '
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.ItemSize = New System.Drawing.Size(120, 30)
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(1054, 487)
        Me.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabs.TabIndex = 0
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
        Me.pnloptions.Controls.Add(Me.BrowserProgress)
        Me.pnloptions.Controls.Add(Me.btnRemTab)
        Me.pnloptions.Controls.Add(Me.btnAddTab)
        Me.pnloptions.Controls.Add(Me.siteloadprogress)
        Me.pnloptions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnloptions.Location = New System.Drawing.Point(0, 523)
        Me.pnloptions.Name = "pnloptions"
        Me.pnloptions.Size = New System.Drawing.Size(1054, 45)
        Me.pnloptions.TabIndex = 5
        '
        'btnRemTab
        '
        Me.btnRemTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemTab.Location = New System.Drawing.Point(93, 16)
        Me.btnRemTab.Name = "btnRemTab"
        Me.btnRemTab.Size = New System.Drawing.Size(81, 23)
        Me.btnRemTab.TabIndex = 22
        Me.btnRemTab.Text = "Remove Tab"
        Me.btnRemTab.UseVisualStyleBackColor = True
        '
        'btnAddTab
        '
        Me.btnAddTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddTab.Location = New System.Drawing.Point(6, 16)
        Me.btnAddTab.Name = "btnAddTab"
        Me.btnAddTab.Size = New System.Drawing.Size(81, 23)
        Me.btnAddTab.TabIndex = 21
        Me.btnAddTab.Text = "Add Tab"
        Me.btnAddTab.UseVisualStyleBackColor = True
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
        'TabText
        '
        Me.TabText.Enabled = True
        '
        'UrlText
        '
        Me.UrlText.Enabled = True
        '
        'Progress
        '
        '
        'BrowserProgress
        '
        Me.BrowserProgress.BackColor = System.Drawing.Color.Black
        Me.BrowserProgress.BlockSeparation = 3
        Me.BrowserProgress.BlockWidth = 5
        Me.BrowserProgress.Color = System.Drawing.Color.Lime
        Me.BrowserProgress.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.BrowserProgress.Location = New System.Drawing.Point(894, 16)
        Me.BrowserProgress.MaxValue = 100
        Me.BrowserProgress.MinValue = 0
        Me.BrowserProgress.Name = "BrowserProgress"
        Me.BrowserProgress.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal
        Me.BrowserProgress.ShowValue = True
        Me.BrowserProgress.Size = New System.Drawing.Size(150, 23)
        Me.BrowserProgress.Step = 10
        Me.BrowserProgress.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Blocks
        Me.BrowserProgress.TabIndex = 23
        Me.BrowserProgress.Value = 0
        Me.BrowserProgress.Visible = False
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
    Friend WithEvents pnlwebtabholder As System.Windows.Forms.Panel
    Friend WithEvents siteloadprogress As ShiftOS.ProgressBarEX
    Friend WithEvents tabs As TabControl 'ShiftOS.ShiftOSTabs
    Friend WithEvents btnAddTab As System.Windows.Forms.Button
    Friend WithEvents btnRemTab As System.Windows.Forms.Button
    Friend WithEvents TabText As System.Windows.Forms.Timer
    Friend WithEvents UrlText As System.Windows.Forms.Timer
    Friend WithEvents BrowserProgress As ShiftOS.ProgressBarEX
    Friend WithEvents Progress As System.Windows.Forms.Timer
End Class
