
Public Class ProgressBarEX

#Region " Properties "

    Private _Value As Integer = 0
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value >= Me.MinValue And value <= Me.MaxValue Then
                _Value = value
                Me.Invalidate()
            Else
                Throw New ArgumentOutOfRangeException("The value must be between the minimum and maximum values.")
            End If
        End Set
    End Property

    Private _Step As Integer = 10
    Public Property [Step]() As Integer
        Get
            Return _Step
        End Get
        Set(ByVal value As Integer)
            _Step = value
        End Set
    End Property

    Private _Orientation As ProgressBarOrientation
    Public Property Orientation() As ProgressBarOrientation
        Get
            Return _Orientation
        End Get
        Set(ByVal value As ProgressBarOrientation)
            _Orientation = value
        End Set
    End Property

    Private _MinValue As Integer = 0
    Public Property MinValue() As Integer
        Get
            Return _MinValue
        End Get
        Set(ByVal value As Integer)
            If value < Me.MaxValue Then
                _MinValue = value
            Else
                Throw New ArgumentOutOfRangeException("The minimum value must be less than the maximum value.")
            End If
        End Set
    End Property

    Private _MaxValue As Integer = 100
    Public Property MaxValue() As Integer
        Get
            Return _MaxValue
        End Get
        Set(ByVal value As Integer)
            If value > Me.MinValue Then
                _MaxValue = value
            Else
                Throw New ArgumentOutOfRangeException("The maximum value must be more than the minimum value.")
            End If
        End Set
    End Property

    Private _Color As Color = Color.Lime
    Public Property Color() As Color
        Get
            Return _Color
        End Get
        Set(ByVal value As Color)
            _Color = value
        End Set
    End Property

    Private _ShowValue As Boolean = True
    Public Property ShowValue() As Boolean
        Get
            Return _ShowValue
        End Get
        Set(ByVal value As Boolean)
            _ShowValue = value
        End Set
    End Property

    Private _Style As ProgressBarExStyle
    Public Property Style() As ProgressBarExStyle
        Get
            Return _Style
        End Get
        Set(ByVal value As ProgressBarExStyle)
            _Style = value
        End Set
    End Property

    Private _BlockWidth As Integer = 5
    Public Property BlockWidth() As Integer
        Get
            Return _BlockWidth
        End Get
        Set(ByVal value As Integer)
            _BlockWidth = value
        End Set
    End Property

    Private _BlockSeparation As Integer = 3
    Public Property BlockSeparation() As Integer
        Get
            Return _BlockSeparation
        End Get
        Set(ByVal value As Integer)
            _BlockSeparation = value
        End Set
    End Property

#End Region

#Region " Enums, Variables "

    Public Enum ProgressBarOrientation
        Horizontal = 0
        Vertical = 1
    End Enum

    Public Enum ProgressBarExStyle
        Blocks = 0
        Continuous = 1
        Marquee = 2
    End Enum

#End Region

#Region " Events "

    Public Event PaintBackground(ByVal sender As Object, ByVal e As PaintEventArgs)
    Public Event PaintProcess(ByVal sender As Object, ByVal e As ProgressBarProcessPaintEventArgs)

    Public Class ProgressBarProcessPaintEventArgs
        Inherits EventArgs

        Public Sub New(ByVal bounds As Rectangle, ByVal g As Graphics, Optional ByVal blocks() As Rectangle = Nothing)
            _Bounds = bounds
            _Graphics = g
            If blocks Is Nothing Then
                _Blocks = New Rectangle() {}
            Else
                _Blocks = blocks
            End If
        End Sub

        Private _Bounds As Rectangle
        Public ReadOnly Property Bounds() As Rectangle
            Get
                Return _Bounds
            End Get
        End Property

        Private _Blocks As Rectangle()
        Public ReadOnly Property Blocks() As Rectangle()
            Get
                Return _Blocks
            End Get
        End Property

        Private _Graphics As Graphics
        Public ReadOnly Property Graphics() As Graphics
            Get
                Return _Graphics
            End Get
        End Property

    End Class

#End Region

#Region " Methods "

    Public Sub PerformStep()
        If Me.Step > 0 Then
            Me.Value = Math.Min(Me.Value + Me.Step, Me.MaxValue)
        Else
            Me.Value = Math.Max(Me.Value + Me.Step, Me.MinValue)
        End If
    End Sub

    Public Sub Increment(ByVal value As Integer)
        If value > 0 Then
            Me.Value = Math.Min(Me.Value + value, Me.MaxValue)
        Else
            Me.Value = Math.Max(Me.Value + value, Me.MinValue)
        End If
    End Sub

#End Region

#Region " Process Logic "

    Private Function GetProcessRect() As Rectangle
        Dim w As Integer = Me.Width
        Dim h As Integer = Me.Height
        Dim valRel As Integer = GetRelativeValue()
        Return New Rectangle(0, 0, w * valRel \ 100, h)
    End Function

    Private Function GetBlocks() As Rectangle()
        Dim b As New List(Of Rectangle)

        Dim w As Integer = Me.BlockWidth
        Dim h As Integer = Me.Height
        Dim r As Rectangle

        Dim x As Integer = 0
        Dim stopX As Integer = CInt((GetRelativeValue() / 100) * Me.Width)
        While (x + w <= stopX)
            r = New Rectangle(x, 0, w, h)
            b.Add(r)

            x += Me.BlockWidth + Me.BlockSeparation
        End While

        Return b.ToArray
    End Function

    Private Function GetRelativeValue() As Integer
        Return CInt(100 * Me.Value / (Me.MaxValue - Me.MinValue))
    End Function

#End Region

#Region " Drawing "

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        DoPaintBackground(e.Graphics)
        DoPaintProcess(e.Graphics)
        If Me.ShowValue Then DoPaintValue(e.Graphics)
    End Sub

    Private Sub DoPaintBackground(ByVal g As Graphics)
        RaiseEvent PaintBackground(Me, New PaintEventArgs(g, Me.ClientRectangle))
    End Sub

    Private Sub DoPaintProcess(ByVal g As Graphics)
        Dim rect As Rectangle = GetProcessRect()
        Dim blocks() As Rectangle = GetBlocks()
        Using brush As New SolidBrush(Me.Color)
            If Me.Style = ProgressBarExStyle.Continuous Then
                g.FillRectangle(brush, rect)
            ElseIf Me.Style = ProgressBarExStyle.Blocks Then
                For Each b As Rectangle In blocks
                    g.FillRectangle(brush, b)
                Next
            End If
        End Using

        Dim e As New ProgressBarProcessPaintEventArgs(rect, g, blocks)
        RaiseEvent PaintProcess(Me, e)
    End Sub

    Private Sub DoPaintValue(ByVal g As Graphics)
        Dim valStr As String = GetRelativeValue.ToString & "&#37;"
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        Dim s As SizeF = g.MeasureString(valStr, Me.Font)

        g.DrawString(valStr, Me.Font, New SolidBrush(Me.ForeColor), (Me.Width - s.Width) / 2, (Me.Height - s.Height) / 2)
    End Sub

#End Region

End Class

