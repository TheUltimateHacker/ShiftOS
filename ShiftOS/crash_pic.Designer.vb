<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crash_pic
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
        Me.pnl_holdtogether = New System.Windows.Forms.Panel()
        Me.killme = New System.Windows.Forms.Timer(Me.components)
        Me.pic_crash = New System.Windows.Forms.PictureBox()
        Me.pnl_holdtogether.SuspendLayout()
        CType(Me.pic_crash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_holdtogether
        '
        Me.pnl_holdtogether.Controls.Add(Me.pic_crash)
        Me.pnl_holdtogether.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_holdtogether.Location = New System.Drawing.Point(0, 0)
        Me.pnl_holdtogether.Name = "pnl_holdtogether"
        Me.pnl_holdtogether.Size = New System.Drawing.Size(728, 422)
        Me.pnl_holdtogether.TabIndex = 1
        '
        'killme
        '
        Me.killme.Interval = 10000
        '
        'pic_crash
        '
        Me.pic_crash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pic_crash.Image = Global.ShiftOS.My.Resources.Resources.crash_cheat
        Me.pic_crash.Location = New System.Drawing.Point(0, 0)
        Me.pic_crash.Name = "pic_crash"
        Me.pic_crash.Size = New System.Drawing.Size(728, 422)
        Me.pic_crash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_crash.TabIndex = 0
        Me.pic_crash.TabStop = False
        '
        'crash_pic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ShiftOS.My.Resources.Resources.crash_cheat
        Me.ClientSize = New System.Drawing.Size(728, 422)
        Me.Controls.Add(Me.pnl_holdtogether)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "crash_pic"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "crash_pic"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_holdtogether.ResumeLayout(False)
        CType(Me.pic_crash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_holdtogether As System.Windows.Forms.Panel
    Friend WithEvents killme As System.Windows.Forms.Timer
    Friend WithEvents pic_crash As System.Windows.Forms.PictureBox
End Class
