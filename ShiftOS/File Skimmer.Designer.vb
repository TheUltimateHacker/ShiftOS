<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class File_Skimmer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(File_Skimmer))
        Me.pgcontents = New System.Windows.Forms.Panel()
        Me.lvfiles = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlbreak = New System.Windows.Forms.Panel()
        Me.pnloptions = New System.Windows.Forms.Panel()
        Me.btndeletefile = New System.Windows.Forms.Button()
        Me.btnnewfolder = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbllocation = New System.Windows.Forms.Label()
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
        Me.fileactions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pullbs = New System.Windows.Forms.Timer(Me.components)
        Me.pullbottom = New System.Windows.Forms.Timer(Me.components)
        Me.pullside = New System.Windows.Forms.Timer(Me.components)
        Me.pgcontents.SuspendLayout()
        Me.pnloptions.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.pgright.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fileactions.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgcontents
        '
        Me.pgcontents.Controls.Add(Me.lvfiles)
        Me.pgcontents.Controls.Add(Me.pnlbreak)
        Me.pgcontents.Controls.Add(Me.pnloptions)
        Me.pgcontents.Controls.Add(Me.Panel2)
        Me.pgcontents.Controls.Add(Me.Panel1)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(596, 345)
        Me.pgcontents.TabIndex = 20
        '
        'lvfiles
        '
        Me.lvfiles.BackColor = System.Drawing.Color.White
        Me.lvfiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvfiles.LargeImageList = Me.ImageList1
        Me.lvfiles.Location = New System.Drawing.Point(0, 33)
        Me.lvfiles.Name = "lvfiles"
        Me.lvfiles.Size = New System.Drawing.Size(596, 259)
        Me.lvfiles.TabIndex = 3
        Me.lvfiles.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder.png")
        Me.ImageList1.Images.SetKeyName(1, "unknown.png")
        Me.ImageList1.Images.SetKeyName(2, "textfile.png")
        Me.ImageList1.Images.SetKeyName(3, "imagefile.png")
        Me.ImageList1.Images.SetKeyName(4, "videofile.png")
        Me.ImageList1.Images.SetKeyName(5, "folderup.png")
        Me.ImageList1.Images.SetKeyName(6, "philips dll.png")
        Me.ImageList1.Images.SetKeyName(7, "philips exe.png")
        Me.ImageList1.Images.SetKeyName(8, "config.png")
        Me.ImageList1.Images.SetKeyName(9, "driver.png")
        Me.ImageList1.Images.SetKeyName(10, "skinfile.png")
        Me.ImageList1.Images.SetKeyName(11, "namelistfile.png")
        Me.ImageList1.Images.SetKeyName(12, "iconpackfile.png")
        Me.ImageList1.Images.SetKeyName(13, "iconins.png")
        Me.ImageList1.Images.SetKeyName(14, "icontrm.png")
        Me.ImageList1.Images.SetKeyName(15, "iconsaa 2.png")
        Me.ImageList1.Images.SetKeyName(16, "iconflood.png")
        Me.ImageList1.Images.SetKeyName(17, "iconurl.png")
        Me.ImageList1.Images.SetKeyName(18, "iconurls.png")
        Me.ImageList1.Images.SetKeyName(19, "iconsaag.png")
        '
        'pnlbreak
        '
        Me.pnlbreak.BackColor = System.Drawing.Color.White
        Me.pnlbreak.BackgroundImage = Global.ShiftOS.My.Resources.Resources.uparrow
        Me.pnlbreak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlbreak.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlbreak.ForeColor = System.Drawing.Color.Black
        Me.pnlbreak.Location = New System.Drawing.Point(0, 292)
        Me.pnlbreak.Name = "pnlbreak"
        Me.pnlbreak.Size = New System.Drawing.Size(596, 15)
        Me.pnlbreak.TabIndex = 7
        '
        'pnloptions
        '
        Me.pnloptions.Controls.Add(Me.btndeletefile)
        Me.pnloptions.Controls.Add(Me.btnnewfolder)
        Me.pnloptions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnloptions.Location = New System.Drawing.Point(0, 307)
        Me.pnloptions.Name = "pnloptions"
        Me.pnloptions.Size = New System.Drawing.Size(596, 38)
        Me.pnloptions.TabIndex = 6
        Me.pnloptions.Visible = False
        '
        'btndeletefile
        '
        Me.btndeletefile.BackColor = System.Drawing.Color.White
        Me.btndeletefile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndeletefile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndeletefile.Image = Global.ShiftOS.My.Resources.Resources.deletefolder
        Me.btndeletefile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndeletefile.Location = New System.Drawing.Point(129, 4)
        Me.btndeletefile.Name = "btndeletefile"
        Me.btndeletefile.Size = New System.Drawing.Size(130, 31)
        Me.btndeletefile.TabIndex = 4
        Me.btndeletefile.Text = "Delete Folder"
        Me.btndeletefile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btndeletefile.UseVisualStyleBackColor = False
        '
        'btnnewfolder
        '
        Me.btnnewfolder.BackColor = System.Drawing.Color.White
        Me.btnnewfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnewfolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnewfolder.Image = Global.ShiftOS.My.Resources.Resources.newfolder
        Me.btnnewfolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnewfolder.Location = New System.Drawing.Point(6, 4)
        Me.btnnewfolder.Name = "btnnewfolder"
        Me.btnnewfolder.Size = New System.Drawing.Size(117, 31)
        Me.btnnewfolder.TabIndex = 3
        Me.btnnewfolder.Text = "New Folder"
        Me.btnnewfolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnnewfolder.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(596, 2)
        Me.Panel2.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lbllocation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 31)
        Me.Panel1.TabIndex = 4
        '
        'lbllocation
        '
        Me.lbllocation.BackColor = System.Drawing.Color.White
        Me.lbllocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbllocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocation.ForeColor = System.Drawing.Color.Black
        Me.lbllocation.Location = New System.Drawing.Point(0, 0)
        Me.lbllocation.Name = "lbllocation"
        Me.lbllocation.Size = New System.Drawing.Size(596, 31)
        Me.lbllocation.TabIndex = 0
        Me.lbllocation.Text = "C:/ShiftOS/"
        Me.lbllocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 347)
        Me.pgleft.TabIndex = 21
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 345)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(598, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 347)
        Me.pgright.TabIndex = 22
        '
        'pgbottomrcorner
        '
        Me.pgbottomrcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomrcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 345)
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
        Me.titlebar.Size = New System.Drawing.Size(600, 30)
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
        Me.pnlicon.BackColor = System.Drawing.Color.Transparent
        Me.pnlicon.Image = Global.ShiftOS.My.Resources.Resources.iconFileSkimmer
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
        Me.lbtitletext.Size = New System.Drawing.Size(107, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "File Skimmer"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(598, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottom
        '
        Me.pgbottom.BackColor = System.Drawing.Color.Gray
        Me.pgbottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottom.Location = New System.Drawing.Point(2, 375)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(596, 2)
        Me.pgbottom.TabIndex = 23
        '
        'fileactions
        '
        Me.fileactions.BackColor = System.Drawing.Color.Black
        Me.fileactions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.fileactions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.fileactions.Name = "fileactions"
        Me.fileactions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.fileactions.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.DeleteToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'pullbs
        '
        Me.pullbs.Interval = 1
        '
        'pullbottom
        '
        Me.pullbottom.Interval = 1
        '
        'pullside
        '
        Me.pullside.Interval = 1
        '
        'File_Skimmer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 377)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(400, 177)
        Me.Name = "File_Skimmer"
        Me.Text = "File_Skimmer"
        Me.TopMost = True
        Me.pgcontents.ResumeLayout(False)
        Me.pnloptions.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pgleft.ResumeLayout(False)
        Me.pgright.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fileactions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgcontents As System.Windows.Forms.Panel
    Friend WithEvents pgleft As System.Windows.Forms.Panel
    Friend WithEvents pgbottomlcorner As System.Windows.Forms.Panel
    Friend WithEvents pgright As System.Windows.Forms.Panel
    Friend WithEvents pgbottomrcorner As System.Windows.Forms.Panel
    Friend WithEvents titlebar As System.Windows.Forms.Panel
    Friend WithEvents rollupbutton As System.Windows.Forms.Panel
    Friend WithEvents closebutton As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents pgtoplcorner As System.Windows.Forms.Panel
    Friend WithEvents pgtoprcorner As System.Windows.Forms.Panel
    Friend WithEvents pgbottom As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lvfiles As System.Windows.Forms.ListView
    Friend WithEvents fileactions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbllocation As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnloptions As System.Windows.Forms.Panel
    Friend WithEvents btnnewfolder As System.Windows.Forms.Button
    Friend WithEvents pnlbreak As System.Windows.Forms.Panel
    Friend WithEvents btndeletefile As System.Windows.Forms.Button
    Friend WithEvents pnlicon As System.Windows.Forms.PictureBox
    Friend WithEvents minimizebutton As System.Windows.Forms.Panel
    Friend WithEvents pullbs As System.Windows.Forms.Timer
    Friend WithEvents pullbottom As System.Windows.Forms.Timer
    Friend WithEvents pullside As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
