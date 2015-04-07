<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FullScreenLoginCustomizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FullScreenLoginCustomizer))
        Me.txtusername = New TextBox 'MichaelsMovableControlSuite.MovableTextBox()
        Me.txtpassword = New TextBox 'MichaelsMovableControlSuite.MovableTextBox()
        Me.userpic = New PictureBox ' MichaelsMovableControlSuite.MovablePictureBox()
        Me.loginbtn = New Button ' MichaelsMovableControlSuite.MovableButton()
        Me.shutdown = New Button 'MichaelsMovableControlSuite.MovableButton()
        Me.preview = New System.Windows.Forms.Panel()
        Me.pnldefault = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Titlebar = New System.Windows.Forms.Panel()
        Me.lbtitletext = New System.Windows.Forms.Label()
        Me.pnluserpicture = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.userpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.preview.SuspendLayout()
        Me.pnldefault.SuspendLayout()
        Me.Titlebar.SuspendLayout()
        Me.pnluserpicture.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtusername
        '
        Me.txtusername.BackColor = System.Drawing.Color.Black
        Me.txtusername.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtusername.Font = New System.Drawing.Font("Trebuchet MS", 12.0!)
        Me.txtusername.ForeColor = System.Drawing.Color.Gray
        Me.txtusername.Location = New System.Drawing.Point(231, 183)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.ReadOnly = True
        Me.txtusername.Size = New System.Drawing.Size(248, 26)
        Me.txtusername.TabIndex = 0
        Me.txtusername.Text = "Username"
        '
        'txtpassword
        '
        Me.txtpassword.BackColor = System.Drawing.Color.Black
        Me.txtpassword.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtpassword.Font = New System.Drawing.Font("Trebuchet MS", 12.0!)
        Me.txtpassword.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Location = New System.Drawing.Point(231, 224)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.ReadOnly = True
        Me.txtpassword.Size = New System.Drawing.Size(248, 26)
        Me.txtpassword.TabIndex = 1
        Me.txtpassword.Text = "Password"
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'userpic
        '
        Me.userpic.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.userpic.Location = New System.Drawing.Point(97, 183)
        Me.userpic.Name = "userpic"
        Me.userpic.Size = New System.Drawing.Size(128, 128)
        Me.userpic.TabIndex = 2
        Me.userpic.TabStop = False
        '
        'loginbtn
        '
        Me.loginbtn.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginbtn.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.loginbtn.ForeColor = System.Drawing.Color.White
        Me.loginbtn.Location = New System.Drawing.Point(328, 268)
        Me.loginbtn.Name = "loginbtn"
        Me.loginbtn.Size = New System.Drawing.Size(151, 43)
        Me.loginbtn.TabIndex = 3
        Me.loginbtn.Text = "Log In"
        Me.loginbtn.UseVisualStyleBackColor = True
        '
        'shutdown
        '
        Me.shutdown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.shutdown.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.shutdown.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.shutdown.ForeColor = System.Drawing.Color.White
        Me.shutdown.Location = New System.Drawing.Point(1755, 715)
        Me.shutdown.Name = "shutdown"
        Me.shutdown.Size = New System.Drawing.Size(137, 50)
        Me.shutdown.TabIndex = 4
        Me.shutdown.Text = "Shutdown"
        Me.shutdown.UseVisualStyleBackColor = True
        '
        'preview
        '
        Me.preview.Controls.Add(Me.txtusername)
        Me.preview.Controls.Add(Me.shutdown)
        Me.preview.Controls.Add(Me.txtpassword)
        Me.preview.Controls.Add(Me.loginbtn)
        Me.preview.Controls.Add(Me.userpic)
        Me.preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.preview.Location = New System.Drawing.Point(0, 30)
        Me.preview.Name = "preview"
        Me.preview.Size = New System.Drawing.Size(1904, 771)
        Me.preview.TabIndex = 5
        '
        'pnldefault
        '
        Me.pnldefault.Controls.Add(Me.Label3)
        Me.pnldefault.Controls.Add(Me.Label4)
        Me.pnldefault.Controls.Add(Me.Label2)
        Me.pnldefault.Controls.Add(Me.Label1)
        Me.pnldefault.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnldefault.ForeColor = System.Drawing.Color.White
        Me.pnldefault.Location = New System.Drawing.Point(0, 801)
        Me.pnldefault.Name = "pnldefault"
        Me.pnldefault.Size = New System.Drawing.Size(1904, 240)
        Me.pnldefault.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(352, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(293, 111)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "User Picture not in a good location? Need to move that Login Button ever-so-sligh" & _
    "tly? Moving objects around the screen is as easy as Click, Drag, Release!"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label4.Location = New System.Drawing.Point(351, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 22)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Moving Controls"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(293, 111)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 22)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Login Screen Customizer - Home"
        '
        'Titlebar
        '
        Me.Titlebar.BackColor = System.Drawing.Color.Gray
        Me.Titlebar.Controls.Add(Me.Button2)
        Me.Titlebar.Controls.Add(Me.lbtitletext)
        Me.Titlebar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titlebar.ForeColor = System.Drawing.Color.White
        Me.Titlebar.Location = New System.Drawing.Point(0, 0)
        Me.Titlebar.Name = "Titlebar"
        Me.Titlebar.Size = New System.Drawing.Size(1904, 30)
        Me.Titlebar.TabIndex = 5
        '
        'lbtitletext
        '
        Me.lbtitletext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbtitletext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbtitletext.Location = New System.Drawing.Point(0, 0)
        Me.lbtitletext.Margin = New System.Windows.Forms.Padding(3)
        Me.lbtitletext.Name = "lbtitletext"
        Me.lbtitletext.Size = New System.Drawing.Size(1904, 30)
        Me.lbtitletext.TabIndex = 0
        Me.lbtitletext.Text = "Login Screen Customizer"
        Me.lbtitletext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnluserpicture
        '
        Me.pnluserpicture.Controls.Add(Me.Button1)
        Me.pnluserpicture.Controls.Add(Me.Label7)
        Me.pnluserpicture.Controls.Add(Me.Label6)
        Me.pnluserpicture.Controls.Add(Me.Label5)
        Me.pnluserpicture.ForeColor = System.Drawing.Color.White
        Me.pnluserpicture.Location = New System.Drawing.Point(0, 801)
        Me.pnluserpicture.Name = "pnluserpicture"
        Me.pnluserpicture.Size = New System.Drawing.Size(1904, 240)
        Me.pnluserpicture.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(20, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 94)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "File for Picture:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(262, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "The picture associated to you when you're logging on."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.Label5.Location = New System.Drawing.Point(16, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "User Account Picture"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(1826, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Apply"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FullScreenLoginCustomizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.preview)
        Me.Controls.Add(Me.Titlebar)
        Me.Controls.Add(Me.pnluserpicture)
        Me.Controls.Add(Me.pnldefault)
        Me.Name = "FullScreenLoginCustomizer"
        Me.Text = "FullScreenLogin"
        CType(Me.userpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.preview.ResumeLayout(False)
        Me.preview.PerformLayout()
        Me.pnldefault.ResumeLayout(False)
        Me.pnldefault.PerformLayout()
        Me.Titlebar.ResumeLayout(False)
        Me.pnluserpicture.ResumeLayout(False)
        Me.pnluserpicture.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtusername As TextBox 'MichaelsMovableControlSuite.MovableTextBox
    Friend WithEvents txtpassword As TextBox 'MichaelsMovableControlSuite.MovableTextBox
    Friend WithEvents userpic As PictureBox 'MichaelsMovableControlSuite.MovablePictureBox
    Friend WithEvents loginbtn As Button 'MichaelsMovableControlSuite.MovableButton
    Friend WithEvents shutdown As Button ' MichaelsMovableControlSuite.MovableButton
    Friend WithEvents preview As System.Windows.Forms.Panel
    Friend WithEvents pnldefault As System.Windows.Forms.Panel
    Friend WithEvents Titlebar As System.Windows.Forms.Panel
    Friend WithEvents lbtitletext As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnluserpicture As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
