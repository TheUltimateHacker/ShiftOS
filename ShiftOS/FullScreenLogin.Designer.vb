<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FullScreenLogin
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
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.userpic = New System.Windows.Forms.PictureBox()
        Me.loginbtn = New System.Windows.Forms.Button()
        Me.shutdown = New System.Windows.Forms.Button()
        CType(Me.userpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtusername
        '
        Me.txtusername.BackColor = System.Drawing.Color.Black
        Me.txtusername.Font = New System.Drawing.Font("Trebuchet MS", 12.0!)
        Me.txtusername.ForeColor = System.Drawing.Color.Gray
        Me.txtusername.Location = New System.Drawing.Point(171, 202)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(248, 26)
        Me.txtusername.TabIndex = 0
        Me.txtusername.Text = "Username"
        '
        'txtpassword
        '
        Me.txtpassword.BackColor = System.Drawing.Color.Black
        Me.txtpassword.Font = New System.Drawing.Font("Trebuchet MS", 12.0!)
        Me.txtpassword.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Location = New System.Drawing.Point(171, 243)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(248, 26)
        Me.txtpassword.TabIndex = 1
        Me.txtpassword.Text = "Password"
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'userpic
        '
        Me.userpic.Location = New System.Drawing.Point(36, 202)
        Me.userpic.Name = "userpic"
        Me.userpic.Size = New System.Drawing.Size(128, 128)
        Me.userpic.TabIndex = 2
        Me.userpic.TabStop = False
        '
        'loginbtn
        '
        Me.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginbtn.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.loginbtn.ForeColor = System.Drawing.Color.White
        Me.loginbtn.Location = New System.Drawing.Point(268, 286)
        Me.loginbtn.Name = "loginbtn"
        Me.loginbtn.Size = New System.Drawing.Size(151, 43)
        Me.loginbtn.TabIndex = 3
        Me.loginbtn.Text = "Log In"
        Me.loginbtn.UseVisualStyleBackColor = True
        '
        'shutdown
        '
        Me.shutdown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.shutdown.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic)
        Me.shutdown.ForeColor = System.Drawing.Color.White
        Me.shutdown.Location = New System.Drawing.Point(1755, 979)
        Me.shutdown.Name = "shutdown"
        Me.shutdown.Size = New System.Drawing.Size(137, 50)
        Me.shutdown.TabIndex = 4
        Me.shutdown.Text = "Shutdown"
        Me.shutdown.UseVisualStyleBackColor = True
        '
        'FullScreenLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.shutdown)
        Me.Controls.Add(Me.loginbtn)
        Me.Controls.Add(Me.userpic)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.Name = "FullScreenLogin"
        Me.Text = "FullScreenLogin"
        CType(Me.userpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents userpic As System.Windows.Forms.PictureBox
    Friend WithEvents loginbtn As System.Windows.Forms.Button
    Friend WithEvents shutdown As System.Windows.Forms.Button
End Class
