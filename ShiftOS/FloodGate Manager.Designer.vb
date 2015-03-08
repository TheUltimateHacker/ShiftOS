<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FloodGate_Manager
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
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.pnlPackages = New System.Windows.Forms.Panel()
        Me.pkgprogress = New ShiftOS.ProgressBarEX()
        Me.lbfirstlaunchmsg = New System.Windows.Forms.Label()
        Me.lbpkgdnload = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlstatus = New System.Windows.Forms.Panel()
        Me.progress = New ShiftOS.ProgressBarEX()
        Me.lblstatusinfo = New System.Windows.Forms.Label()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.dnlBox = New System.Windows.Forms.ListView()
        Me.pnlsearchheader = New System.Windows.Forms.Panel()
        Me.urlBox = New System.Windows.Forms.TextBox()
        Me.lblfeaturedfloods = New System.Windows.Forms.Label()
        Me.pnlDownload = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.progDesc = New System.Windows.Forms.Label()
        Me.progLabel = New System.Windows.Forms.Label()
        Me.progDownload = New System.Windows.Forms.Button()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.shouldnotneedtoexist = New System.Windows.Forms.Timer(Me.components)
        Me.dnloadtimer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrdwnld = New System.Windows.Forms.Timer(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.pgcontents.SuspendLayout()
        Me.pnlPackages.SuspendLayout()
        Me.pnlstatus.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlsearchheader.SuspendLayout()
        Me.pnlDownload.SuspendLayout()
        Me.pgright.SuspendLayout()
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
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.pnlPackages)
        Me.pgcontents.Controls.Add(Me.pnlstatus)
        Me.pgcontents.Controls.Add(Me.pnlSearch)
        Me.pgcontents.Controls.Add(Me.pnlDownload)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(847, 436)
        Me.pgcontents.TabIndex = 20
        '
        'pnlPackages
        '
        Me.pnlPackages.Controls.Add(Me.pkgprogress)
        Me.pnlPackages.Controls.Add(Me.lbfirstlaunchmsg)
        Me.pnlPackages.Controls.Add(Me.lbpkgdnload)
        Me.pnlPackages.Controls.Add(Me.Button3)
        Me.pnlPackages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPackages.Location = New System.Drawing.Point(0, 0)
        Me.pnlPackages.Name = "pnlPackages"
        Me.pnlPackages.Size = New System.Drawing.Size(847, 402)
        Me.pnlPackages.TabIndex = 5
        '
        'pkgprogress
        '
        Me.pkgprogress.BlockSeparation = 3
        Me.pkgprogress.BlockWidth = 5
        Me.pkgprogress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pkgprogress.Color = System.Drawing.Color.Gray
        Me.pkgprogress.Location = New System.Drawing.Point(49, 123)
        Me.pkgprogress.MaxValue = 100
        Me.pkgprogress.MinValue = 0
        Me.pkgprogress.Name = "pkgprogress"
        Me.pkgprogress.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal
        Me.pkgprogress.ShowValue = False
        Me.pkgprogress.Size = New System.Drawing.Size(722, 45)
        Me.pkgprogress.Step = 10
        Me.pkgprogress.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous
        Me.pkgprogress.TabIndex = 3
        Me.pkgprogress.Value = 0
        '
        'lbfirstlaunchmsg
        '
        Me.lbfirstlaunchmsg.AutoSize = True
        Me.lbfirstlaunchmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfirstlaunchmsg.Location = New System.Drawing.Point(42, 28)
        Me.lbfirstlaunchmsg.Name = "lbfirstlaunchmsg"
        Me.lbfirstlaunchmsg.Size = New System.Drawing.Size(395, 37)
        Me.lbfirstlaunchmsg.TabIndex = 2
        Me.lbfirstlaunchmsg.Text = "Downloading Package List"
        '
        'lbpkgdnload
        '
        Me.lbpkgdnload.AutoSize = True
        Me.lbpkgdnload.Location = New System.Drawing.Point(76, 80)
        Me.lbpkgdnload.Name = "lbpkgdnload"
        Me.lbpkgdnload.Size = New System.Drawing.Size(171, 13)
        Me.lbpkgdnload.TabIndex = 1
        Me.lbpkgdnload.Text = "(You will only have to do this once)"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(1237, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Download"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'pnlstatus
        '
        Me.pnlstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlstatus.Controls.Add(Me.progress)
        Me.pnlstatus.Controls.Add(Me.lblstatusinfo)
        Me.pnlstatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlstatus.Location = New System.Drawing.Point(0, 402)
        Me.pnlstatus.Name = "pnlstatus"
        Me.pnlstatus.Size = New System.Drawing.Size(847, 34)
        Me.pnlstatus.TabIndex = 4
        '
        'progress
        '
        Me.progress.BlockSeparation = 3
        Me.progress.BlockWidth = 5
        Me.progress.Color = System.Drawing.Color.Gray
        Me.progress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progress.Location = New System.Drawing.Point(0, 22)
        Me.progress.MaxValue = 100
        Me.progress.MinValue = 0
        Me.progress.Name = "progress"
        Me.progress.Orientation = ShiftOS.ProgressBarEX.ProgressBarOrientation.Horizontal
        Me.progress.ShowValue = False
        Me.progress.Size = New System.Drawing.Size(845, 10)
        Me.progress.Step = 10
        Me.progress.Style = ShiftOS.ProgressBarEX.ProgressBarExStyle.Continuous
        Me.progress.TabIndex = 1
        Me.progress.Value = 0
        '
        'lblstatusinfo
        '
        Me.lblstatusinfo.AutoSize = True
        Me.lblstatusinfo.Location = New System.Drawing.Point(9, 6)
        Me.lblstatusinfo.Name = "lblstatusinfo"
        Me.lblstatusinfo.Size = New System.Drawing.Size(38, 13)
        Me.lblstatusinfo.TabIndex = 0
        Me.lblstatusinfo.Text = "Ready"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.Controls.Add(Me.dnlBox)
        Me.pnlSearch.Controls.Add(Me.pnlsearchheader)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(847, 436)
        Me.pnlSearch.TabIndex = 3
        '
        'dnlBox
        '
        Me.dnlBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dnlBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dnlBox.Location = New System.Drawing.Point(0, 54)
        Me.dnlBox.Name = "dnlBox"
        Me.dnlBox.Size = New System.Drawing.Size(847, 382)
        Me.dnlBox.TabIndex = 4
        Me.dnlBox.UseCompatibleStateImageBehavior = False
        '
        'pnlsearchheader
        '
        Me.pnlsearchheader.Controls.Add(Me.urlBox)
        Me.pnlsearchheader.Controls.Add(Me.lblfeaturedfloods)
        Me.pnlsearchheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlsearchheader.Location = New System.Drawing.Point(0, 0)
        Me.pnlsearchheader.Name = "pnlsearchheader"
        Me.pnlsearchheader.Size = New System.Drawing.Size(847, 54)
        Me.pnlsearchheader.TabIndex = 3
        '
        'urlBox
        '
        Me.urlBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.urlBox.Location = New System.Drawing.Point(0, 0)
        Me.urlBox.Name = "urlBox"
        Me.urlBox.Size = New System.Drawing.Size(847, 20)
        Me.urlBox.TabIndex = 2
        '
        'lblfeaturedfloods
        '
        Me.lblfeaturedfloods.AutoSize = True
        Me.lblfeaturedfloods.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfeaturedfloods.Location = New System.Drawing.Point(45, 20)
        Me.lblfeaturedfloods.Name = "lblfeaturedfloods"
        Me.lblfeaturedfloods.Size = New System.Drawing.Size(170, 24)
        Me.lblfeaturedfloods.TabIndex = 3
        Me.lblfeaturedfloods.Text = "Featured Floods:"
        '
        'pnlDownload
        '
        Me.pnlDownload.Controls.Add(Me.Button1)
        Me.pnlDownload.Controls.Add(Me.progDesc)
        Me.pnlDownload.Controls.Add(Me.progLabel)
        Me.pnlDownload.Controls.Add(Me.progDownload)
        Me.pnlDownload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDownload.Location = New System.Drawing.Point(0, 0)
        Me.pnlDownload.Name = "pnlDownload"
        Me.pnlDownload.Size = New System.Drawing.Size(847, 436)
        Me.pnlDownload.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(10, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'progDesc
        '
        Me.progDesc.AutoSize = True
        Me.progDesc.Location = New System.Drawing.Point(10, 46)
        Me.progDesc.Name = "progDesc"
        Me.progDesc.Size = New System.Drawing.Size(41, 13)
        Me.progDesc.TabIndex = 2
        Me.progDesc.Text = "Desc..."
        '
        'progLabel
        '
        Me.progLabel.AutoSize = True
        Me.progLabel.Location = New System.Drawing.Point(10, 33)
        Me.progLabel.Name = "progLabel"
        Me.progLabel.Size = New System.Drawing.Size(35, 13)
        Me.progLabel.TabIndex = 1
        Me.progLabel.Text = "Name"
        '
        'progDownload
        '
        Me.progDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.progDownload.Location = New System.Drawing.Point(644, 6)
        Me.progDownload.Name = "progDownload"
        Me.progDownload.Size = New System.Drawing.Size(193, 23)
        Me.progDownload.TabIndex = 0
        Me.progDownload.Text = "Download"
        Me.progDownload.UseVisualStyleBackColor = True
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 466)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(847, 2)
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
        Me.lbtitletext.Size = New System.Drawing.Size(157, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "FloodGate Manager"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(849, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 436)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(849, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 438)
        Me.pgright.TabIndex = 22
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 436)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 438)
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
        Me.titlebar.Size = New System.Drawing.Size(851, 30)
        Me.titlebar.TabIndex = 19
        '
        'pnlicon
        '
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Location = New System.Drawing.Point(8, 8)
        Me.pnlicon.Name = "pnlicon"
        Me.pnlicon.Size = New System.Drawing.Size(16, 16)
        Me.pnlicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlicon.TabIndex = 24
        Me.pnlicon.TabStop = False
        Me.pnlicon.Visible = False
        '
        'shouldnotneedtoexist
        '
        '
        'dnloadtimer
        '
        '
        'tmrdwnld
        '
        Me.tmrdwnld.Interval = 1000
        '
        'FloodGate_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(851, 468)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FloodGate_Manager"
        Me.Text = "FloodGate Manager"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pnlPackages.ResumeLayout(False)
        Me.pnlPackages.PerformLayout()
        Me.pnlstatus.ResumeLayout(False)
        Me.pnlstatus.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlsearchheader.ResumeLayout(False)
        Me.pnlsearchheader.PerformLayout()
        Me.pnlDownload.ResumeLayout(False)
        Me.pnlDownload.PerformLayout()
        Me.pgright.ResumeLayout(False)
        Me.pgleft.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents shouldnotneedtoexist As System.Windows.Forms.Timer
    Friend WithEvents pnlDownload As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents progDesc As System.Windows.Forms.Label
    Friend WithEvents progLabel As System.Windows.Forms.Label
    Friend WithEvents progDownload As System.Windows.Forms.Button
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents dnlBox As System.Windows.Forms.ListView
    Friend WithEvents pnlsearchheader As System.Windows.Forms.Panel
    Friend WithEvents lblfeaturedfloods As System.Windows.Forms.Label
    Friend WithEvents urlBox As System.Windows.Forms.TextBox
    Friend WithEvents pnlstatus As System.Windows.Forms.Panel
    Friend WithEvents lblstatusinfo As System.Windows.Forms.Label
    Friend WithEvents pnlPackages As System.Windows.Forms.Panel
    Friend WithEvents lbfirstlaunchmsg As System.Windows.Forms.Label
    Friend WithEvents lbpkgdnload As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dnloadtimer As System.Windows.Forms.Timer
    Friend WithEvents tmrdwnld As System.Windows.Forms.Timer
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents progress As ShiftOS.ProgressBarEX
    Friend WithEvents pkgprogress As ShiftOS.ProgressBarEX
End Class
