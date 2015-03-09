<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrcWrite
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
        Me.pnltextarea = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.pnlcontrols = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pgleft = New System.Windows.Forms.Panel()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.pnlicon = New System.Windows.Forms.PictureBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.pgright.SuspendLayout()
        Me.pgcontents.SuspendLayout()
        Me.pnltextarea.SuspendLayout()
        Me.pnlcontrols.SuspendLayout()
        Me.pgleft.SuspendLayout()
        Me.titlebar.SuspendLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pgbottom.Location = New System.Drawing.Point(2, 447)
        Me.pgbottom.Name = "pgbottom"
        Me.pgbottom.Size = New System.Drawing.Size(796, 2)
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
        Me.pgbottomrcorner.Location = New System.Drawing.Point(0, 417)
        Me.pgbottomrcorner.Name = "pgbottomrcorner"
        Me.pgbottomrcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomrcorner.TabIndex = 15
        '
        'pgright
        '
        Me.pgright.BackColor = System.Drawing.Color.Gray
        Me.pgright.Controls.Add(Me.pgbottomrcorner)
        Me.pgright.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgright.Location = New System.Drawing.Point(798, 30)
        Me.pgright.Name = "pgright"
        Me.pgright.Size = New System.Drawing.Size(2, 419)
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
        Me.lbtitletext.Size = New System.Drawing.Size(77, 18)
        Me.lbtitletext.TabIndex = 19
        Me.lbtitletext.Text = "Template"
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
        Me.pgtoprcorner.Location = New System.Drawing.Point(798, 0)
        Me.pgtoprcorner.Name = "pgtoprcorner"
        Me.pgtoprcorner.Size = New System.Drawing.Size(2, 30)
        Me.pgtoprcorner.TabIndex = 16
        '
        'pgbottomlcorner
        '
        Me.pgbottomlcorner.BackColor = System.Drawing.Color.Red
        Me.pgbottomlcorner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbottomlcorner.Location = New System.Drawing.Point(0, 417)
        Me.pgbottomlcorner.Name = "pgbottomlcorner"
        Me.pgbottomlcorner.Size = New System.Drawing.Size(2, 2)
        Me.pgbottomlcorner.TabIndex = 14
        '
        'pgcontents
        '
        Me.pgcontents.Controls.Add(Me.pnltextarea)
        Me.pgcontents.Controls.Add(Me.pnlcontrols)
        Me.pgcontents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgcontents.Location = New System.Drawing.Point(2, 30)
        Me.pgcontents.Name = "pgcontents"
        Me.pgcontents.Size = New System.Drawing.Size(798, 419)
        Me.pgcontents.TabIndex = 20
        '
        'pnltextarea
        '
        Me.pnltextarea.Controls.Add(Me.RichTextBox1)
        Me.pnltextarea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnltextarea.Location = New System.Drawing.Point(0, 71)
        Me.pnltextarea.Name = "pnltextarea"
        Me.pnltextarea.Size = New System.Drawing.Size(798, 348)
        Me.pnltextarea.TabIndex = 43
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.BulletIndent = 10
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Times New Roman", 11.0!)
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(798, 348)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'pnlcontrols
        '
        Me.pnlcontrols.BackColor = System.Drawing.Color.White
        Me.pnlcontrols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlcontrols.Controls.Add(Me.Label5)
        Me.pnlcontrols.Controls.Add(Me.Button7)
        Me.pnlcontrols.Controls.Add(Me.Label4)
        Me.pnlcontrols.Controls.Add(Me.Button6)
        Me.pnlcontrols.Controls.Add(Me.Label3)
        Me.pnlcontrols.Controls.Add(Me.ComboBox2)
        Me.pnlcontrols.Controls.Add(Me.TextBox1)
        Me.pnlcontrols.Controls.Add(Me.Label1)
        Me.pnlcontrols.Controls.Add(Me.Button5)
        Me.pnlcontrols.Controls.Add(Me.Button4)
        Me.pnlcontrols.Controls.Add(Me.Button3)
        Me.pnlcontrols.Controls.Add(Me.Label2)
        Me.pnlcontrols.Controls.Add(Me.Button2)
        Me.pnlcontrols.Controls.Add(Me.ComboBox1)
        Me.pnlcontrols.Controls.Add(Me.Button1)
        Me.pnlcontrols.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlcontrols.Location = New System.Drawing.Point(0, 0)
        Me.pnlcontrols.Name = "pnlcontrols"
        Me.pnlcontrols.Size = New System.Drawing.Size(798, 71)
        Me.pnlcontrols.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(549, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Highlight:"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Black
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(606, 6)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(29, 23)
        Me.Button7.TabIndex = 42
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(425, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Color:"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Black
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(470, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(29, 23)
        Me.Button6.TabIndex = 41
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Text Alignment:"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Left", "Right", "Center"})
        Me.ComboBox2.Location = New System.Drawing.Point(289, 10)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 39
        Me.ComboBox2.Text = "Left"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(470, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(29, 20)
        Me.TextBox1.TabIndex = 38
        Me.TextBox1.Text = "11"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(425, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Size:"
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(109, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(62, 23)
        Me.Button5.TabIndex = 36
        Me.Button5.Text = "Underline"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(60, 37)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(43, 23)
        Me.Button4.TabIndex = 35
        Me.Button4.Text = "Italic"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(7, 37)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(47, 23)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "Bold"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Font Style:"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(88, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(289, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 32
        Me.ComboBox1.Text = "Times New Roman"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(7, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pgleft
        '
        Me.pgleft.BackColor = System.Drawing.Color.Gray
        Me.pgleft.Controls.Add(Me.pgbottomlcorner)
        Me.pgleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgleft.Location = New System.Drawing.Point(0, 30)
        Me.pgleft.Name = "pgleft"
        Me.pgleft.Size = New System.Drawing.Size(2, 419)
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
        Me.titlebar.Size = New System.Drawing.Size(800, 30)
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BindingSource1
        '
        '
        'OrcWrite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 449)
        Me.Controls.Add(Me.pgbottom)
        Me.Controls.Add(Me.pgright)
        Me.Controls.Add(Me.pgcontents)
        Me.Controls.Add(Me.pgleft)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "OrcWrite"
        Me.Text = "OrcWrite"
        Me.TopMost = True
        Me.pgright.ResumeLayout(False)
        Me.pgcontents.ResumeLayout(False)
        Me.pnltextarea.ResumeLayout(False)
        Me.pnlcontrols.ResumeLayout(False)
        Me.pnlcontrols.PerformLayout()
        Me.pgleft.ResumeLayout(False)
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.pnlicon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlcontrols As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnltextarea As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
End Class
