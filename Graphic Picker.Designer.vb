<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Graphic_Picker
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
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnreset = New System.Windows.Forms.Button()
        Me.btnapply = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnmousedownbrowse = New System.Windows.Forms.Button()
        Me.txtmousedownfile = New System.Windows.Forms.TextBox()
        Me.picmousedown = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnmouseoverbrowse = New System.Windows.Forms.Button()
        Me.txtmouseoverfile = New System.Windows.Forms.TextBox()
        Me.picmouseover = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnidlebrowse = New System.Windows.Forms.Button()
        Me.txtidlefile = New System.Windows.Forms.TextBox()
        Me.picidle = New System.Windows.Forms.PictureBox()
        Me.btnzoom = New System.Windows.Forms.Button()
        Me.btnstretch = New System.Windows.Forms.Button()
        Me.btncentre = New System.Windows.Forms.Button()
        Me.btntile = New System.Windows.Forms.Button()
        Me.pnlgraphicholder = New System.Windows.Forms.Panel()
        Me.picgraphic = New System.Windows.Forms.PictureBox()
        Me.lblobjecttoskin = New System.Windows.Forms.Label()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.pgbottomlcorner = New System.Windows.Forms.Panel()
        Me.pgright = New System.Windows.Forms.Panel()
        Me.pgbottomrcorner = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.minimizebutton = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.rollupbutton = New System.Windows.Forms.Panel()
        Me.closebutton = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pgtoplcorner = New System.Windows.Forms.Panel()
        Me.pgtoprcorner = New System.Windows.Forms.Panel()
        Me.pgbottom = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pgcontents.SuspendLayout()
        CType(Me.picmousedown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picmouseover, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picidle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlgraphicholder.SuspendLayout()
        CType(Me.picgraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgleft.SuspendLayout()
        Me.pgright.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgcontents
        '
        Me.pgcontents.BackColor = System.Drawing.Color.White
        Me.pgcontents.Controls.Add(Me.btncancel)
        Me.pgcontents.Controls.Add(Me.btnreset)
        Me.pgcontents.Controls.Add(Me.btnapply)
        Me.pgcontents.Controls.Add(Me.Label4)
        Me.pgcontents.Controls.Add(Me.btnmousedownbrowse)
        Me.pgcontents.Controls.Add(Me.txtmousedownfile)
        Me.pgcontents.Controls.Add(Me.picmousedown)
        Me.pgcontents.Controls.Add(Me.Label3)
        Me.pgcontents.Controls.Add(Me.btnmouseoverbrowse)
        Me.pgcontents.Controls.Add(Me.txtmouseoverfile)
        Me.pgcontents.Controls.Add(Me.picmouseover)
        Me.pgcontents.Controls.Add(Me.Label2)
        Me.pgcontents.Controls.Add(Me.Label1)
        Me.pgcontents.Controls.Add(Me.btnidlebrowse)
        Me.pgcontents.Controls.Add(Me.txtidlefile)
        Me.pgcontents.Controls.Add(Me.picidle)
        Me.pgcontents.Controls.Add(Me.btnzoom)
        Me.pgcontents.Controls.Add(Me.btnstretch)
        Me.pgcontents.Controls.Add(Me.btncentre)
        Me.pgcontents.Controls.Add(Me.btntile)
        Me.pgcontents.Controls.Add(Me.pnlgraphicholder)
        Me.pgcontents.Controls.Add(Me.lblobjecttoskin)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(386, 540)
        Me.pgcontents.TabIndex = 20
        '
        'btncancel
        '
        Me.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Location = New System.Drawing.Point(19, 492)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(109, 32)
        Me.btncancel.TabIndex = 23
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnreset
        '
        Me.btnreset.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreset.Location = New System.Drawing.Point(134, 492)
        Me.btnreset.Name = "btnreset"
        Me.btnreset.Size = New System.Drawing.Size(109, 32)
        Me.btnreset.TabIndex = 22
        Me.btnreset.Text = "Reset"
        Me.btnreset.UseVisualStyleBackColor = True
        '
        'btnapply
        '
        Me.btnapply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnapply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnapply.Location = New System.Drawing.Point(249, 492)
        Me.btnapply.Name = "btnapply"
        Me.btnapply.Size = New System.Drawing.Size(118, 32)
        Me.btnapply.TabIndex = 21
        Me.btnapply.Text = "Apply"
        Me.btnapply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(125, 411)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 28)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Mouse Down"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnmousedownbrowse
        '
        Me.btnmousedownbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmousedownbrowse.Location = New System.Drawing.Point(295, 411)
        Me.btnmousedownbrowse.Name = "btnmousedownbrowse"
        Me.btnmousedownbrowse.Size = New System.Drawing.Size(73, 60)
        Me.btnmousedownbrowse.TabIndex = 19
        Me.btnmousedownbrowse.Text = "Browse"
        Me.btnmousedownbrowse.UseVisualStyleBackColor = True
        '
        'txtmousedownfile
        '
        Me.txtmousedownfile.BackColor = System.Drawing.Color.White
        Me.txtmousedownfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmousedownfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtmousedownfile.Location = New System.Drawing.Point(125, 442)
        Me.txtmousedownfile.Multiline = True
        Me.txtmousedownfile.Name = "txtmousedownfile"
        Me.txtmousedownfile.Size = New System.Drawing.Size(163, 29)
        Me.txtmousedownfile.TabIndex = 18
        Me.txtmousedownfile.Text = "None"
        Me.txtmousedownfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picmousedown
        '
        Me.picmousedown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picmousedown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picmousedown.Location = New System.Drawing.Point(19, 411)
        Me.picmousedown.Name = "picmousedown"
        Me.picmousedown.Size = New System.Drawing.Size(100, 60)
        Me.picmousedown.TabIndex = 17
        Me.picmousedown.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(125, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 28)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Mouse Over"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnmouseoverbrowse
        '
        Me.btnmouseoverbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmouseoverbrowse.Location = New System.Drawing.Point(295, 336)
        Me.btnmouseoverbrowse.Name = "btnmouseoverbrowse"
        Me.btnmouseoverbrowse.Size = New System.Drawing.Size(73, 60)
        Me.btnmouseoverbrowse.TabIndex = 15
        Me.btnmouseoverbrowse.Text = "Browse"
        Me.btnmouseoverbrowse.UseVisualStyleBackColor = True
        '
        'txtmouseoverfile
        '
        Me.txtmouseoverfile.BackColor = System.Drawing.Color.White
        Me.txtmouseoverfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmouseoverfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtmouseoverfile.Location = New System.Drawing.Point(125, 367)
        Me.txtmouseoverfile.Multiline = True
        Me.txtmouseoverfile.Name = "txtmouseoverfile"
        Me.txtmouseoverfile.Size = New System.Drawing.Size(163, 29)
        Me.txtmouseoverfile.TabIndex = 14
        Me.txtmouseoverfile.Text = "None"
        Me.txtmouseoverfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picmouseover
        '
        Me.picmouseover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picmouseover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picmouseover.Location = New System.Drawing.Point(19, 336)
        Me.picmouseover.Name = "picmouseover"
        Me.picmouseover.Size = New System.Drawing.Size(100, 60)
        Me.picmouseover.TabIndex = 13
        Me.picmouseover.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 260)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 28)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Idle"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bookman Old Style", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 228)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 23)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "States"
        '
        'btnidlebrowse
        '
        Me.btnidlebrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnidlebrowse.Location = New System.Drawing.Point(295, 260)
        Me.btnidlebrowse.Name = "btnidlebrowse"
        Me.btnidlebrowse.Size = New System.Drawing.Size(73, 60)
        Me.btnidlebrowse.TabIndex = 10
        Me.btnidlebrowse.Text = "Browse"
        Me.btnidlebrowse.UseVisualStyleBackColor = True
        '
        'txtidlefile
        '
        Me.txtidlefile.BackColor = System.Drawing.Color.White
        Me.txtidlefile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidlefile.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidlefile.Location = New System.Drawing.Point(125, 291)
        Me.txtidlefile.Multiline = True
        Me.txtidlefile.Name = "txtidlefile"
        Me.txtidlefile.Size = New System.Drawing.Size(163, 29)
        Me.txtidlefile.TabIndex = 9
        Me.txtidlefile.Text = "None"
        Me.txtidlefile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picidle
        '
        Me.picidle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picidle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picidle.Location = New System.Drawing.Point(19, 260)
        Me.picidle.Name = "picidle"
        Me.picidle.Size = New System.Drawing.Size(100, 60)
        Me.picidle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picidle.TabIndex = 8
        Me.picidle.TabStop = False
        '
        'btnzoom
        '
        Me.btnzoom.BackgroundImage = Global.ShiftOS.My.Resources.Resources.zoombutton
        Me.btnzoom.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnzoom.FlatAppearance.BorderSize = 0
        Me.btnzoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnzoom.Location = New System.Drawing.Point(286, 144)
        Me.btnzoom.Name = "btnzoom"
        Me.btnzoom.Size = New System.Drawing.Size(82, 65)
        Me.btnzoom.TabIndex = 7
        Me.btnzoom.UseVisualStyleBackColor = True
        '
        'btnstretch
        '
        Me.btnstretch.BackgroundImage = Global.ShiftOS.My.Resources.Resources.stretchbutton
        Me.btnstretch.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnstretch.FlatAppearance.BorderSize = 0
        Me.btnstretch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnstretch.Location = New System.Drawing.Point(197, 144)
        Me.btnstretch.Name = "btnstretch"
        Me.btnstretch.Size = New System.Drawing.Size(82, 65)
        Me.btnstretch.TabIndex = 6
        Me.btnstretch.UseVisualStyleBackColor = True
        '
        'btncentre
        '
        Me.btncentre.BackgroundImage = Global.ShiftOS.My.Resources.Resources.centrebutton
        Me.btncentre.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btncentre.FlatAppearance.BorderSize = 0
        Me.btncentre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncentre.Location = New System.Drawing.Point(108, 144)
        Me.btncentre.Name = "btncentre"
        Me.btncentre.Size = New System.Drawing.Size(82, 65)
        Me.btncentre.TabIndex = 5
        Me.btncentre.UseVisualStyleBackColor = True
        '
        'btntile
        '
        Me.btntile.BackgroundImage = Global.ShiftOS.My.Resources.Resources.tilebutton
        Me.btntile.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btntile.FlatAppearance.BorderSize = 0
        Me.btntile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntile.Location = New System.Drawing.Point(19, 144)
        Me.btntile.Name = "btntile"
        Me.btntile.Size = New System.Drawing.Size(82, 65)
        Me.btntile.TabIndex = 4
        Me.btntile.UseVisualStyleBackColor = True
        '
        'pnlgraphicholder
        '
        Me.pnlgraphicholder.Controls.Add(Me.picgraphic)
        Me.pnlgraphicholder.Location = New System.Drawing.Point(19, 38)
        Me.pnlgraphicholder.Name = "pnlgraphicholder"
        Me.pnlgraphicholder.Size = New System.Drawing.Size(350, 100)
        Me.pnlgraphicholder.TabIndex = 3
        '
        'picgraphic
        '
        Me.picgraphic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picgraphic.Location = New System.Drawing.Point(0, 0)
        Me.picgraphic.Name = "picgraphic"
        Me.picgraphic.Size = New System.Drawing.Size(350, 100)
        Me.picgraphic.TabIndex = 0
        Me.picgraphic.TabStop = False
        '
        'lblobjecttoskin
        '
        Me.lblobjecttoskin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblobjecttoskin.Location = New System.Drawing.Point(19, 9)
        Me.lblobjecttoskin.Name = "lblobjecttoskin"
        Me.lblobjecttoskin.Size = New System.Drawing.Size(350, 23)
        Me.lblobjecttoskin.TabIndex = 2
        Me.lblobjecttoskin.Text = "Close Button"
        Me.lblobjecttoskin.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 540)
        Me.pgleft.TabIndex = 21
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 538)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(388, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 540)
        Me.pgright.TabIndex = 22
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 538)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
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
        Me.titlebar.Size = New System.Drawing.Size(390, 30)
        Me.titlebar.TabIndex = 19
        '
        'minimizebutton
        '
        Me.minimizebutton.BackColor = System.Drawing.Color.Black
        Me.minimizebutton.Location = New System.Drawing.Point(246, 3)
        Me.minimizebutton.Name = "minimizebutton"
        Me.minimizebutton.Size = New System.Drawing.Size(22, 22)
        Me.minimizebutton.TabIndex = 24
        '
        'pnlicon
        '
        Me.pnlicon.BackgroundImage = Global.ShiftOS.My.Resources.Resources.iconGraphicPicker
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
        Me.lbtitletext.Font = New System.Drawing.Font("Felix Titling", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitletext.Location = New System.Drawing.Point(26, 7)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(150, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Graphic Picker"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(388, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 568)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(386, 2)
        Me.pgbottom.TabIndex = 23
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Graphic_Picker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 570)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Graphic_Picker"
        Me.Text = "Graphic_Picker"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pgcontents.PerformLayout()
        CType(Me.picmousedown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picmouseover, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picidle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlgraphicholder.ResumeLayout(False)
        CType(Me.picgraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgleft.ResumeLayout(False)
        Me.pgright.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnreset As System.Windows.Forms.Button
    Friend WithEvents btnapply As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnmousedownbrowse As System.Windows.Forms.Button
    Friend WithEvents txtmousedownfile As System.Windows.Forms.TextBox
    Friend WithEvents picmousedown As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnmouseoverbrowse As System.Windows.Forms.Button
    Friend WithEvents txtmouseoverfile As System.Windows.Forms.TextBox
    Friend WithEvents picmouseover As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnidlebrowse As System.Windows.Forms.Button
    Friend WithEvents txtidlefile As System.Windows.Forms.TextBox
    Friend WithEvents picidle As System.Windows.Forms.PictureBox
    Friend WithEvents btnzoom As System.Windows.Forms.Button
    Friend WithEvents btnstretch As System.Windows.Forms.Button
    Friend WithEvents btncentre As System.Windows.Forms.Button
    Friend WithEvents btntile As System.Windows.Forms.Button
    Friend WithEvents pnlgraphicholder As System.Windows.Forms.Panel
    Friend WithEvents picgraphic As System.Windows.Forms.PictureBox
    Friend WithEvents lblobjecttoskin As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
End Class
