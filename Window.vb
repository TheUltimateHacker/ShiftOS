Public Class Window

#Region "NATIVE"
    Private Enum GW
        NONE = -1
        HWNDFIRST = 0
        HWNDLAST = 1
        HWNDNEXT = 2
        HWNDPREV = 3
        OWNER = 4
        CHILD = 5
        ENABLEDPOPUP = 6
    End Enum
    Private Declare Function GetWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal uCmd As GW) As IntPtr
    Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As IntPtr) As Integer
    Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    Private Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As String) As Boolean
    Private Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Integer, ByVal lpClassName As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer
    Private Declare Function GetParent Lib "user32" (ByVal hWnd As IntPtr) As IntPtr
    Private Declare Function SetParent Lib "user32" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Private Declare Function GetWindowRect Lib "user32" (ByVal hWnd As System.Runtime.InteropServices.HandleRef, ByRef lpRect As API.WRECT) As Boolean
    Private Declare Function GetClientRect Lib "user32" (ByVal hWnd As System.Runtime.InteropServices.HandleRef, ByRef lpRect As API.WRECT) As Boolean
    Private Enum SWP As UInteger
        ''' <summary>If the calling thread and the thread that owns the window are attached to different input queues,
        ''' the system posts the request to the thread that owns the window. This prevents the calling thread from
        ''' blocking its execution while other threads process the request.</summary>
        ''' <remarks>SWP_ASYNCWINDOWPOS</remarks>
        SynchronousWindowPosition = &H4000
        ''' <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
        ''' <remarks>SWP_DEFERERASE</remarks>
        DeferErase = &H2000
        ''' <summary>Draws a frame (defined in the window's class description) around the window.</summary>
        ''' <remarks>SWP_DRAWFRAME</remarks>
        DrawFrame = &H20
        ''' <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
        ''' the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
        ''' is sent only when the window's size is being changed.</summary>
        ''' <remarks>SWP_FRAMECHANGED</remarks>
        FrameChanged = &H20
        ''' <summary>Hides the window.</summary>
        ''' <remarks>SWP_HIDEWINDOW</remarks>
        HideWindow = &H80
        ''' <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
        ''' top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
        ''' parameter).</summary>
        ''' <remarks>SWP_NOACTIVATE</remarks>
        DoNotActivate = &H10
        ''' <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
        ''' contents of the client area are saved and copied back into the client area after the window is sized or
        ''' repositioned.</summary>
        ''' <remarks>SWP_NOCOPYBITS</remarks>
        DoNotCopyBits = &H100
        ''' <summary>Retains the current position (ignores X and Y parameters).</summary>
        ''' <remarks>SWP_NOMOVE</remarks>
        IgnoreMove = &H2
        ''' <summary>Does not change the owner window's position in the Z order.</summary>
        ''' <remarks>SWP_NOOWNERZORDER</remarks>
        DoNotChangeOwnerZOrder = &H200
        ''' <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
        ''' the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
        ''' window uncovered as a result of the window being moved. When this flag is set, the application must
        ''' explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
        ''' <remarks>SWP_NOREDRAW</remarks>
        DoNotRedraw = &H8
        ''' <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
        ''' <remarks>SWP_NOREPOSITION</remarks>
        DoNotReposition = &H200
        ''' <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
        ''' <remarks>SWP_NOSENDCHANGING</remarks>
        DoNotSendChangingEvent = &H400
        ''' <summary>Retains the current size (ignores the cx and cy parameters).</summary>
        ''' <remarks>SWP_NOSIZE</remarks>
        IgnoreResize = &H1
        ''' <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
        ''' <remarks>SWP_NOZORDER</remarks>
        IgnoreZOrder = &H4
        ''' <summary>Displays the window.</summary>
        ''' <remarks>SWP_SHOWWINDOW</remarks>
        ShowWindow = &H40
    End Enum
    Private Enum HWNDafter As Integer
        BOTTOM = 1
        NOTOPMOST = -2
        TOP = 0
        TOPMOST = -1
    End Enum
    Private Declare Function SetWindowPos Lib "user32" (ByVal hWnd As IntPtr, ByVal hWndInsertAfter As HWNDafter, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As SWP) As Boolean

    Private Declare Function IsWindow Lib "user32" (ByVal hWnd As IntPtr) As Boolean
    Private Declare Function IsWindowVisible Lib "user32" (ByVal hWnd As IntPtr) As Boolean
    Private Declare Function AnimateWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal time As Integer, ByVal flags As AnimateFlags) As Boolean
    Private Declare Function RedrawWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal lprcUpdate As IntPtr, ByVal hrgnUpdate As IntPtr, ByVal flags As RedrawFlags) As Boolean
    Private Declare Function FlashWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal bInvert As Boolean) As Boolean
    Private Declare Function PrintWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal hDC As IntPtr, ByVal nFlags As UInteger) As Boolean
    Private Declare Function GetDC Lib "user32" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Function GetWindowDC Lib "user32" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Function ScreenToClient Lib "user32" (ByVal hWnd As IntPtr, ByRef lpPoint As Point) As Boolean
    Private Declare Function ClientToScreen Lib "user32" (ByVal hWnd As IntPtr, ByRef lpPoint As Point) As Boolean
    Private Declare Function SetCapture Lib "user32" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Function ReleaseCapture Lib "user32" () As IntPtr
    Private Declare Function GetCapture Lib "user32" () As IntPtr

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal className As String, ByVal windowTitle As IntPtr) As IntPtr
    Private Declare Function WindowFromPoint Lib "user32" (ByVal Point As API.WPOINT) As IntPtr
    Private Declare Function ChildWindowFromPoint Lib "user32" (ByVal hWndParent As IntPtr, ByVal point As API.WPOINT) As IntPtr
    Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Boolean
    Private Declare Function GetDesktopWindow Lib "user32" () As IntPtr
    Private Declare Function GetTopWindow Lib "user32" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Function GetFocus Lib "user32" () As IntPtr
    Private Declare Function GetActiveWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hwnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
    Private Declare Function GetMenu Lib "user32" (ByVal hWnd As IntPtr) As IntPtr
    Private Declare Function GetSubMenu Lib "user32" (ByVal hMenu As IntPtr, ByVal nPos As Integer) As IntPtr

    Private Enum GWL As Integer
        WNDPROC = -4
        HINSTANCE = -6
        HWNDPARENT = -8
        STYLE = -16
        EXSTYLE = -20
        USERDATA = -21
        ID = -12
    End Enum
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As IntPtr, ByVal nIndex As GWL, ByVal dwNewLong As Long) As Integer
    <Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="GetWindowLong")> _
    Private Shared Function GetWindowLongPtr32(ByVal hWnd As Runtime.InteropServices.HandleRef, ByVal nIndex As Integer) As Long
    End Function
    <Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="GetWindowLongPtr")> _
    Private Shared Function GetWindowLongPtr64(ByVal hWnd As Runtime.InteropServices.HandleRef, ByVal nIndex As Integer) As Long
    End Function
    Private Shared Function GetWindowLong(ByVal hwnd As Runtime.InteropServices.HandleRef, ByVal nIndex As GWL) As Long
        If IntPtr.Size = 8 Then
            Return GetWindowLongPtr64(hwnd, nIndex)
        Else
            Return GetWindowLongPtr32(hwnd, nIndex)
        End If
    End Function

    Private Structure LayeredWindowAttributes
        Private Declare Function SetLayeredWindowAttributes Lib "user32" (ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal alpha As Byte, ByVal dwFlags As LWA) As Boolean
        Private Declare Function GetLayeredWindowAttributes Lib "user32" (ByVal hWnd As IntPtr, ByRef crKey As Integer, ByRef alpha As Byte, ByRef dwFlags As LWA) As Boolean
        Public Sub New(ByVal hwnd As IntPtr)
            Me.hwnd = hwnd
            GetLayeredWindowAttributes(Me.hwnd, Me.crKey, Me.alpha, Me.dwFlags)
        End Sub
        Private hwnd As IntPtr
        Public crKey As Integer
        Public alpha As Byte
        Private dwFlags As LWA
        Private Enum LWA As Integer
            ColorKey = &H1
            Alpha = &H2
        End Enum
        Public Property UseColorKey() As Boolean
            Get
                Return (Me.dwFlags And LWA.ColorKey) = LWA.ColorKey
            End Get
            Set(ByVal value As Boolean)
                If (Me.dwFlags And LWA.ColorKey) = LWA.ColorKey <> value Then
                    If value = True Then Me.dwFlags += LWA.ColorKey Else Me.dwFlags -= LWA.ColorKey
                End If
            End Set
        End Property
        Public Property UseAlpha() As Boolean
            Get
                Return (Me.dwFlags And LWA.Alpha) = LWA.Alpha
            End Get
            Set(ByVal value As Boolean)
                If (Me.dwFlags And LWA.Alpha) = LWA.Alpha <> value Then
                    If value = True Then Me.dwFlags += LWA.Alpha Else Me.dwFlags -= LWA.Alpha
                End If
            End Set
        End Property
        Public Function Apply() As Boolean
            Return SetLayeredWindowAttributes(Me.hwnd, Me.crKey, Me.alpha, Me.dwFlags)
        End Function
    End Structure

    Private Structure WindowPlacement
        Private Declare Function SetWindowPlacement Lib "user32" (ByVal hWnd As IntPtr, ByRef lpwndpl As WindowPlacement) As Boolean
        Private Declare Function GetWindowPlacement Lib "user32" (ByVal hWnd As IntPtr, ByRef lpwndpl As WindowPlacement) As Boolean
        Sub New(ByVal hWnd As IntPtr)
            Me.length = System.Runtime.InteropServices.Marshal.SizeOf(Me)
            GetWindowPlacement(hWnd, Me)
        End Sub
        Public Function Send(ByVal hWnd As IntPtr) As Boolean
            Return SetWindowPlacement(hWnd, Me)
        End Function
        Public length As Integer
        Public flags As WPF
        Public showCmd As State
        Public minimizedPosition As API.WPOINT
        Public maximizedPosition As API.WPOINT
        Public normalPosition As API.WRECT
        Public Enum WPF As Integer
            ASyncWindowPlacement = 4
            RestoreToMaximized = 2
            SetMinimizedPosition = 1
        End Enum
    End Structure
    Private Class Enumerator
        Private Delegate Function EnumCallBackDelegate(ByVal hwnd As Integer, ByVal lParam As Integer) As Integer
        Private Declare Function EnumWindows Lib "user32" (ByVal lpEnumFunc As EnumCallBackDelegate, ByVal lParam As Integer) As Integer
        Private Declare Function EnumChildWindows Lib "user32" (ByVal hWndParent As Integer, ByVal lpEnumFunc As EnumCallBackDelegate, ByVal lParam As Integer) As Integer
        Private Declare Function EnumThreadWindows Lib "user32" (ByVal dwThreadId As UInteger, ByVal lpfn As EnumCallBackDelegate, ByVal lParam As Integer) As Boolean
        Private Declare Function EnumDesktopWindows Lib "user32" (ByVal hDesktop As IntPtr, ByVal lpfn As EnumCallBackDelegate, ByVal lparam As Integer) As Boolean

        Private Function EnumProc(ByVal hwnd As Int32, ByVal lParam As Int32) As Int32
            If lParam = 1 AndAlso GetParent(hwnd) = 0 AndAlso IsWindowVisible(hwnd) Then _list.Add(hwnd) 'toplevel
            If lParam = 2 Then _list.Add(hwnd) 'childwindows
            If lParam = 3 Then _list.Add(hwnd) 'threadwindows
            If lParam = 4 Then _list.Add(hwnd) 'desktopwindows
            Return 1
        End Function

        Private _list As List(Of IntPtr)
        Public Function GetTopLevelWindows() As List(Of IntPtr)
            _list = New List(Of IntPtr)
            EnumWindows(AddressOf EnumProc, 1)
            Return _list
        End Function
        Public Function GetChildWindows(ByVal hwnd As Int32) As List(Of IntPtr)
            _list = New List(Of IntPtr)
            EnumChildWindows(hwnd, AddressOf EnumProc, 2)
            Return _list
        End Function
        Public Function GetThreadWindows(ByVal threadID As Integer) As List(Of IntPtr)
            _list = New List(Of IntPtr)
            EnumThreadWindows(threadID, AddressOf EnumProc, 3)
            Return _list
        End Function
        Public Function GetDesktopWindows(ByVal desktop As IntPtr) As List(Of IntPtr)
            _list = New List(Of IntPtr)
            EnumDesktopWindows(desktop, AddressOf EnumProc, 4)
            Return _list
        End Function
    End Class

    Public Structure KeyCommand
        Sub New(ByVal Key As Keys, ByVal EventType As KeyEvent)
            Dim Up As Boolean = EventType = KeyEvent.Up
            Dim Alt As Boolean = (Key And Keys.Alt) = Keys.Alt
            Dim F10 As Boolean = (Key And Keys.F10) = Keys.F10
            If Alt Or F10 Then EventType += 4 'offset to sys_

            Me.Key = Key
            Me.EventType = EventType
            Me.Flags = EventFlag.None
            If Up Then Me.Flags = EventFlag.PrevWasDown
            If Up And Not Alt And Not F10 Then Me.Flags += EventFlag.Transition
            If Alt And Not Up Then Me.Flags += EventFlag.AltKeyDown

            Dim extended As Boolean = False
            If Key = Keys.LControlKey Or Key = Keys.RControlKey Then extended = True
            If Key = Keys.LShiftKey Or Key = Keys.RShiftKey Then extended = True
            If Key = Keys.LMenu Or Key = Keys.RMenu Then extended = True
            If extended Then Me.Flags += EventFlag.ExtendedKey
            Me.RepeatCount = 0
            Me.scancode = 0
        End Sub
        Sub New(ByVal Character As Char)
            Me.Key = Asc(Character)
            Me.EventType = KeyEvent.CharPress
            Me.Flags = EventFlag.None
        End Sub
        Public EventType As KeyEvent
        Public Key As Keys
        Public RepeatCount As UShort
        Public scancode As Byte
        Public Flags As Byte
        Public Enum EventFlag As Byte
            None = 0
            ExtendedKey = 1
            AltKeyDown = 32
            PrevWasDown = 64
            Transition = 128
        End Enum
        Public Function Post(ByVal hwnd As IntPtr) As Boolean
            Return API.PostMessage(hwnd, EventType, Key, API.DWORD.FromSBB(Me.RepeatCount, Me.scancode, Me.Flags))
        End Function
    End Structure
    Public Structure MouseCommand
        Sub New(ByVal X As UShort, ByVal Y As UShort, Optional ByVal Button As MouseButtons = MouseButtons.None, Optional ByVal EventType As MouseEvent = MouseEvent.Move)
            Me.EventType = EventType
            Me.Button = Button
            Me.Modifier = MK.NONE
            Me.x = X
            Me.y = Y
        End Sub
        Sub New(ByVal Location As Point, Optional ByVal Button As MouseButtons = MouseButtons.None, Optional ByVal EventType As MouseEvent = MouseEvent.Move)
            Me.EventType = EventType
            Me.Button = Button
            Me.Modifier = MK.NONE
            Me.x = Location.X
            Me.y = Location.Y
        End Sub
        Public EventType As MouseEvent
        Public Button As MouseButtons
        Public x As UShort
        Public y As UShort
        Public Modifier As MK
        Public Function Post(ByVal hwnd As IntPtr) As Boolean
            Dim msg1 As msg = 0
            Dim msg2 As msg = 0
            Dim add As Boolean = EventType >= 0 And EventType <= 2
            Select Case Button
                Case MouseButtons.Left
                    msg1 = msg.LBUTTONDOWN
                Case MouseButtons.Middle
                    msg1 = msg.MBUTTONDOWN
                Case MouseButtons.Right
                    msg1 = msg.RBUTTONDOWN
                Case Else
                    add = False
                    msg1 = msg.MOUSEMOVE
            End Select
            If EventType = MouseEvent.DoubleClick Then
                msg2 = msg1 + MouseEvent.Up
                msg1 = msg1 + MouseEvent.DoubleClick
            ElseIf EventType = MouseEvent.Click Then
                msg2 = msg1 + MouseEvent.Up
                msg1 = msg1 + MouseEvent.Down
            ElseIf add Then
                msg1 += EventType
            End If

            Dim success As Boolean = True
            If msg1 <> 0 AndAlso Not API.PostMessage(hwnd, msg1, Modifier, New API.DWORD(Me.x, Me.y)) Then success = False
            If msg2 <> 0 AndAlso Not API.PostMessage(hwnd, msg2, Modifier, New API.DWORD(Me.x, Me.y)) Then success = False
            Return success
        End Function
        Public Enum MK As Integer
            'No keys are down
            NONE = &H0
            'The CTRL key is down.
            CONTROL = &H8
            'The left mouse button is down.
            LBUTTON = &H1
            'The middle mouse button is down.
            MBUTTON = &H10
            'The right mouse button is down.
            RBUTTON = &H2
            'The SHIFT key is down.
            SHIFT = &H4
            'The first X button is down.
            XBUTTON1 = &H20
            'The second X button is down.
            XBUTTON2 = &H40
        End Enum

        Private Enum msg As UInteger
            MOUSEACTIVATE = &H21
            MOUSEMOVE = &H200
            LBUTTONDOWN = 513
            LBUTTONUP = 514
            LBUTTONDBLCLK = 515
            RBUTTONDOWN = 516
            RBUTTONUP = 517
            RBUTTONDBLCLK = 518
            MBUTTONDOWN = 519
            MBUTTONUP = 520
            MBUTTONDBLCLK = 521
        End Enum
    End Structure
#End Region

    Public Enum KeyEvent
        Down = &H100
        Up = &H101
        CharPress = &H102
    End Enum
    Public Enum MouseEvent
        Down = 0
        Up = 1
        DoubleClick = 2
        Click = 3
        Move = 4
    End Enum
    Public Enum RedrawFlags As UInteger
        ''' <summary>
        ''' Invalidates the rectangle or region that you specify in lprcUpdate or hrgnUpdate.
        ''' You can set only one of these parameters to a non-NULL value. If both are NULL, RDW_INVALIDATE invalidates the entire window.
        ''' </summary>
        Invalidate = &H1
        ''' <summary>Causes the OS to post a WM_PAINT message to the window regardless of whether a portion of the window is invalid.</summary>
        InternalPaint = &H2
        ''' <summary>
        ''' Causes the window to receive a WM_ERASEBKGND message when the window is repainted.
        ''' Specify this value in combination with the RDW_INVALIDATE value; otherwise, RDW_ERASE has no effect.
        ''' </summary>
        [Erase] = &H4
        ''' <summary>
        ''' Validates the rectangle or region that you specify in lprcUpdate or hrgnUpdate.
        ''' You can set only one of these parameters to a non-NULL value. If both are NULL, RDW_VALIDATE validates the entire window.
        ''' This value does not affect internal WM_PAINT messages.
        ''' </summary>
        Validate = &H8
        NoInternalPaint = &H10
        ''' <summary>Suppresses any pending WM_ERASEBKGND messages.</summary>
        NoErase = &H20
        ''' <summary>Excludes child windows, if any, from the repainting operation.</summary>
        NoChildren = &H40
        ''' <summary>Includes child windows, if any, in the repainting operation.</summary>
        AllChildren = &H80
        ''' <summary>Causes the affected windows, which you specify by setting the RDW_ALLCHILDREN and RDW_NOCHILDREN values, to receive WM_ERASEBKGND and WM_PAINT messages before the RedrawWindow returns, if necessary.</summary>
        UpdateNow = &H100
        ''' <summary>
        ''' Causes the affected windows, which you specify by setting the RDW_ALLCHILDREN and RDW_NOCHILDREN values, to receive WM_ERASEBKGND messages before RedrawWindow returns, if necessary.
        ''' The affected windows receive WM_PAINT messages at the ordinary time.
        ''' </summary>
        EraseNow = &H200
        Frame = &H400
        NoFrame = &H800
    End Enum
    Public Enum AnimateFlags
        HOR_POSITIVE = &H1
        HOR_NEGATIVE = &H2
        VER_POSITIVE = &H4
        VER_NEGATIVE = &H8
        CENTER = &H10
        HIDE = &H10000
        ACTIVATE = &H20000
        SLIDE = &H40000
        BLEND = &H80000
    End Enum
    Public Enum State
        Hidden = 0
        Normal = 1
        Minimized = 2
        Maximized = 3
        Shown = 5
    End Enum
    Public Enum Styles As Long
        ControlBox = &H80000L
        MinimizeBox = &H20000L
        MaximizeBox = &H10000L
        Sizable = ThickFrame
        Border = &H800000L
        Caption = &HC00000L
        Visible = &H10000000L
        Disabled = &H8000000L
        Child = &H40000000L
        VScrollBar = &H200000L
        HScrollBar = &H100000L
        TabStop = &H10000L
        Group = &H20000L
        ClipSiblings = &H4000000L
        ClipChildren = &H2000000L
        ThickFrame = &H40000L
        DialogFrame = &H400000L

        'initial start state
        Minimize = &H20000000L
        Maximize = &H1000000L

        Overlapped = &H0L
        Tiled = Overlapped
        OverlappedWindow = (Overlapped Or Caption Or Styles.ControlBox Or ThickFrame Or MinimizeBox Or MaximizeBox)
        TiledWindow = OverlappedWindow

        PopUp = &H80000000L
        PopUpWindow = (PopUp Or Border Or Styles.ControlBox)
    End Enum
    Public Enum ExStyles As Long
        AllowDrop = &H10L
        TopMost = &H8L
        Layered = &H80000
        Composited = &H2000000L
        NoActivate = &H8000000L
        NoInheritLayout = &H100000L
        NoParentNotify = &H4L
        ToolWindow = &H80L
        MDIChild = &H40L
        Transparent = &H20L
        WindowEdge = &H100L
        ClientEdge = &H200L
        HelpButton = &H400L
        RightToLeft = &H400000L
        DialogModalFrame = &H1L
    End Enum

    Public Enum CMD
        Close = 0
        Destroy = 1
        BringToFront = 2
        SendToBack = 3
        Show = 4
        Hide = 5
        Flash = 6
        Focus = 7
        Clear = 8
        Undo = 9
        Copy = 10
        Paste = 11
        Cut = 12
    End Enum

    Private hwnd As IntPtr
    Sub New()
        Me.hwnd = IntPtr.Zero
    End Sub
    Sub New(ByVal hWnd As IntPtr)
        Me.hwnd = hWnd
    End Sub
    Sub New(ByVal c As Control)
        Me.hwnd = c.Handle
    End Sub
    Sub New(ByVal WindowName As String, Optional ByVal ClassName As String = Nothing)
        Me.hwnd = FindWindow(ClassName, WindowName)
    End Sub
    Sub New(ByVal p As Process, Optional ByVal UseMainHandle As Boolean = True)
        If UseMainHandle Then Me.hwnd = p.MainWindowHandle Else Me.hwnd = p.Handle
    End Sub

    Public Property Handle() As IntPtr
        Get
            Return Me.hwnd
        End Get
        Set(ByVal value As IntPtr)
            Me.hwnd = value
        End Set
    End Property
    Public Property HandleRef() As Runtime.InteropServices.HandleRef
        Get
            Return New Runtime.InteropServices.HandleRef(Me, Me.hwnd)
        End Get
        Set(ByVal value As Runtime.InteropServices.HandleRef)
            Me.hwnd = value.Handle
        End Set
    End Property

    Public Function GetDC() As API.DC
        Return New API.DC(Me.hwnd, GetDC(Me.hwnd))
    End Function
    Public Function GetWindowDC() As API.DC
        Return New API.DC(Me.hwnd, GetWindowDC(Me.hwnd))
    End Function

    Public Property Text() As String
        Get
            Return API.WM.TEXT(Me.hwnd)
        End Get
        Set(ByVal value As String)
            API.WM.TEXT(Me.hwnd) = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Dim length As Integer = GetWindowTextLength(Me.hwnd) + 1
            Dim s As New System.Text.StringBuilder(length)
            GetWindowText(Me.hwnd, s, s.Capacity)
            Return s.ToString
        End Get
        Set(ByVal value As String)
            SetWindowText(Me.hwnd, value)
        End Set
    End Property
    Public Property Bounds() As Rectangle
        Get
            Dim r As API.WRECT
            If (GetWindowRect(Me.HandleRef, r)) Then
                Return r.Value
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Rectangle)
            SetWindowPos(Me.hwnd, -2, value.X, value.Y, value.Width, value.Height, SWP.IgnoreZOrder)
        End Set
    End Property
    Public ReadOnly Property ClientSize() As Size
        Get
            Dim r As API.WRECT
            GetClientRect(Me.HandleRef, r)
            Return r.Value.Size
        End Get
    End Property
    Public ReadOnly Property ClientRectangle() As Rectangle
        Get
            Return New Rectangle(ClientToScreen(New Point(0, 0)), ClientSize)
        End Get
    End Property
    Public Property Location() As Point
        Get
            Return Bounds.Location
        End Get
        Set(ByVal value As Point)
            SetWindowPos(Me.hwnd, -2, value.X, value.Y, 0, 0, SWP.IgnoreResize Or SWP.IgnoreZOrder)
        End Set
    End Property
    Public Property Size() As Size
        Get
            Return Bounds.Size
        End Get
        Set(ByVal value As Size)
            SetWindowPos(Me.hwnd, -2, 0, 0, value.Width, value.Height, SWP.IgnoreMove Or SWP.IgnoreZOrder)
        End Set
    End Property
    Public Property WindowState() As State
        Get
            Return New WindowPlacement(Me.hwnd).showCmd
        End Get
        Set(ByVal value As State)
            Dim d As New WindowPlacement(Me.hwnd)
            d.showCmd = value
            d.Send(Me.hwnd)
        End Set
    End Property
    Public ReadOnly Property Exists()
        Get
            Return IsWindow(Me.hwnd)
        End Get
    End Property
    Public Property Visible() As Boolean
        Get
            Return IsWindowVisible(Me.hwnd)
        End Get
        Set(ByVal value As Boolean)
            If value = False Then Command(CMD.Hide)
            If value = True Then Command(CMD.Show)
        End Set
    End Property
    Public Property Font() As Font
        Get
            Return API.WM.FONT(Me.hwnd)
        End Get
        Set(ByVal value As Font)
            API.WM.FONT(Me.hwnd) = value
        End Set
    End Property
    Public Property Enabled() As Boolean
        Get
            Return Me.Style(Styles.Disabled) = False
        End Get
        Set(ByVal value As Boolean)
            Me.Style(Styles.Disabled) = value = False
        End Set
    End Property
    Public Property Focused() As Boolean
        Get
            Return GetFocus = Me.hwnd
        End Get
        Set(ByVal value As Boolean)
            If value Then
                API.WM.SETFOCUS(Me.hwnd)
            Else
                API.WM.KILLFOCUS(Me.hwnd)
            End If
        End Set
    End Property
    Public Property Captured() As Boolean
        Get
            Return GetCapture() = Me.hwnd
        End Get
        Set(ByVal value As Boolean)
            If value Then
                SetCapture(Me.hwnd)
            ElseIf Me.Captured Then
                ReleaseCapture()
            End If
        End Set
    End Property

    Public Function ScreenToClient(ByVal p As Point) As Point
        ScreenToClient(Me.hwnd, p)
        Return p
    End Function
    Public Function ScreenToClient(ByVal r As Rectangle) As Rectangle
        Return New Rectangle(ScreenToClient(r.Location), r.Size)
    End Function
    Public Function ClientToScreen(ByVal p As Point) As Point
        ClientToScreen(Me.hwnd, p)
        Return p
    End Function
    Public Function ClientToScreen(ByVal r As Rectangle) As Rectangle
        Return New Rectangle(ClientToScreen(r.Location), r.Size)
    End Function

    Public Sub Animate(ByVal flags As AnimateFlags, Optional ByVal Time As Integer = 1000)
        AnimateWindow(Me.hwnd, Time, flags)
    End Sub
    Public Sub Invalidate()
        Redraw(RedrawFlags.Invalidate Or RedrawFlags.UpdateNow)
    End Sub
    Public Sub Redraw(ByVal flags As RedrawFlags)
        RedrawWindow(Me.hwnd, Nothing, Nothing, flags)
    End Sub
    Public Function CreateGraphics() As Graphics
        Return Graphics.FromHwnd(Me.hwnd)
    End Function

    Public Sub CaptureClient(ByVal g As Graphics, ByVal srcrect As Rectangle, Optional ByVal DestX As Integer = 0, Optional ByVal DestY As Integer = 0)
        Dim gdc As New API.DC(g)
        Dim hdc As API.DC = Me.GetDC
        hdc.CopyTo(gdc)
        gdc.Dispose()
        hdc.Dispose()
    End Sub
    Public Function CaptureClient() As Image
        Return CaptureClient(New Rectangle(New Point(), Me.ClientSize))
    End Function
    Public Function CaptureClient(ByVal rect As Rectangle) As Image
        If rect.Width < 1 Or rect.Height < 1 Then Return Nothing
        Dim img As New Bitmap(rect.Width, rect.Height)
        Dim g As Graphics = Graphics.FromImage(img)
        CaptureClient(g, rect)
        g.Dispose()
        Return img
    End Function
    Public Sub CaptureWindow(ByVal g As Graphics)
        'Dim Hdc As IntPtr = g.GetHdc()
        'PrintWindow(Me.hwnd, Hdc, 0)
        'g.ReleaseHdc(Hdc)

        Dim gdc As New API.DC(g)
        Dim hdc As API.DC = Me.GetWindowDC
        hdc.CopyTo(gdc)
        gdc.Dispose()
        hdc.Dispose()
    End Sub
    Public Function CaptureWindow() As Image
        Dim s As Size = Me.Size
        If s.Width < 1 Or s.Height < 1 Then Return Nothing
        Dim img As New Bitmap(s.Width, s.Height)
        Dim g As Graphics = Graphics.FromImage(img)
        CaptureWindow(g)
        g.Dispose()
        Return img
    End Function

    Public Property Opacity(Optional ByVal SetLayered As Boolean = True) As Byte
        Get
            If SetLayered Then Me.ExStyle(ExStyles.Layered) = True
            Dim lwa As New LayeredWindowAttributes(Me.hwnd)
            If lwa.UseAlpha = False Then Return 255
            Return lwa.alpha
        End Get
        Set(ByVal value As Byte)
            If SetLayered Then Me.ExStyle(ExStyles.Layered) = True
            Dim lwa As New LayeredWindowAttributes(Me.hwnd)
            If value = 255 Then
                lwa.UseAlpha = False
            Else
                lwa.UseAlpha = True
                lwa.alpha = value
            End If
            lwa.Apply()
        End Set
    End Property
    Public Property TransparencyKey(Optional ByVal SetLayered As Boolean = True) As Color
        Get
            If SetLayered Then Me.ExStyle(ExStyles.Layered) = True
            Return ColorTranslator.FromOle(New LayeredWindowAttributes(Me.hwnd).crKey)
        End Get
        Set(ByVal value As Color)
            If SetLayered Then Me.ExStyle(ExStyles.Layered) = True
            Dim lwa As New LayeredWindowAttributes(Me.hwnd)
            If IsNothing(value) Then
                lwa.UseColorKey = False
            Else
                lwa.UseColorKey = True
                lwa.crKey = value.ToArgb
            End If
            lwa.Apply()
        End Set
    End Property

    Public Property ExStyle(ByVal ex As ExStyles) As Boolean
        Get
            Return (Me.ExStyle And ex) = ex
        End Get
        Set(ByVal value As Boolean)
            Dim exs As ExStyles = Me.ExStyle
            If (exs And ex) = ex <> value Then
                If value = True Then exs += ex Else exs -= ex
                Me.ExStyle = exs
            End If
        End Set
    End Property
    Public Property ExStyle() As ExStyles
        Get
            Return GetWindowLong(Me.HandleRef, GWL.EXSTYLE)
        End Get
        Set(ByVal value As ExStyles)
            SetWindowLong(Me.hwnd, GWL.EXSTYLE, value)
        End Set
    End Property
    Public Property Style(ByVal st As Styles) As Boolean
        Get
            Return (Me.Style And st) = st
        End Get
        Set(ByVal value As Boolean)
            Dim sty As Styles = Me.Style
            If (sty And st) = st <> value Then
                If value = True Then sty += st Else sty -= st
                Me.Style = sty
            End If
        End Set
    End Property
    Public Property Style() As Styles
        Get
            Return GetWindowLong(Me.HandleRef, GWL.STYLE)
        End Get
        Set(ByVal value As Styles)
            SetWindowLong(Me.hwnd, GWL.STYLE, value)
        End Set
    End Property

    Public Property AllowDrop() As Boolean
        Get
            Return ExStyle(ExStyles.AllowDrop)
        End Get
        Set(ByVal value As Boolean)
            ExStyle(ExStyles.AllowDrop) = value
        End Set
    End Property
    Public Property TopMost() As Boolean
        Get
            Return ExStyle(ExStyles.TopMost)
        End Get
        Set(ByVal value As Boolean)
            ExStyle(ExStyles.TopMost) = value
        End Set
    End Property
    Public Property TabStop() As Boolean
        Get
            Return Style(Styles.TabStop)
        End Get
        Set(ByVal value As Boolean)
            Style(Styles.TabStop) = value
        End Set
    End Property

    Public Function SendKey(ByVal Key As Keys, ByVal EventType As KeyEvent)
        Dim k As New KeyCommand(Key, EventType)
        k.RepeatCount = 0
        Return SendKey(k)
    End Function
    Public Function SendPressedKey(ByVal key As Keys, Optional ByVal SendCount As Integer = 1)
        Dim success As Boolean = True
        Dim k_down As New KeyCommand(key, KeyEvent.Down)
        Dim k_up As New KeyCommand(key, KeyEvent.Up)
        For i As Integer = 1 To SendCount
            If SendKey(k_down) = False Then success = False
            If SendKey(k_up) = False Then success = False
        Next
        Return success
    End Function
    Public Function SendKey(ByVal k As KeyCommand)
        Return k.Post(Me.hwnd)
    End Function
    Public Function SendChar(ByVal character As Char, Optional ByVal SendCount As Integer = 1) As Boolean
        Dim k As New KeyCommand(character)
        k.RepeatCount = SendCount - 1
        Return SendKey(k)
    End Function
    Public Function SendChars(ByVal text() As Char)
        Dim success As Boolean = True
        For Each character As Char In text
            If SendChar(character) = False Then success = False
        Next
        Return success
    End Function
    Public Function SendMouse(ByVal Location As Point, Optional ByVal Buttons As MouseButtons = MouseButtons.None, Optional ByVal EventType As MouseEvent = MouseEvent.Move)
        Return SendMouse(New MouseCommand(Location, Buttons, EventType))
    End Function
    Public Function SendMouse(ByVal X As Integer, ByVal Y As Integer, Optional ByVal Buttons As MouseButtons = MouseButtons.None, Optional ByVal EventType As MouseEvent = MouseEvent.Move)
        Return SendMouse(New MouseCommand(X, Y, Buttons, EventType))
    End Function
    Public Function SendMouse(ByVal m As MouseCommand) As Boolean
        Return m.Post(Me.hwnd)
    End Function

    Public Sub Command(ByVal command As CMD)
        Select Case command
            Case CMD.Close
                API.WM.CLOSE(Me.hwnd)
            Case CMD.Destroy
                API.WM.DESTROY(Me.hwnd)
            Case CMD.BringToFront
                SetWindowPos(Me.hwnd, HWNDafter.BOTTOM, 0, 0, 0, 0, SWP.IgnoreResize Or SWP.IgnoreMove)
            Case CMD.SendToBack
                SetWindowPos(Me.hwnd, HWNDafter.BOTTOM, 0, 0, 0, 0, SWP.IgnoreResize Or SWP.IgnoreMove Or SWP.DoNotActivate)
            Case CMD.Show
                Dim d As New WindowPlacement(Me.hwnd)
                d.showCmd = 5
                d.Send(Me.hwnd)
            Case CMD.Flash
                FlashWindow(Me.hwnd, True)
            Case CMD.Hide
                Dim d As New WindowPlacement(Me.hwnd)
                d.showCmd = 0
                d.Send(Me.hwnd)
            Case CMD.Focus
                Me.Focused = True
            Case CMD.Clear
                API.WM.CLEAR(Me.hwnd)
            Case CMD.Undo
                API.WM.UNDO(Me.hwnd)
            Case CMD.Copy
                API.WM.Copy(Me.hwnd)
            Case CMD.Paste
                API.WM.PASTE(Me.hwnd)
            Case CMD.Cut
                API.WM.CUT(Me.hwnd)
        End Select
    End Sub

    '-------------not sure if these work--------------
    Public ReadOnly Property SystemMenu() As Window
        Get
            Return New Window(GetSystemMenu(Me.hwnd, False))
        End Get
    End Property
    Public ReadOnly Property Menu() As Window
        Get
            Return New Window(GetMenu(Me.hwnd))
        End Get
    End Property
    Public ReadOnly Property SubMenus(ByVal index As Integer) As Window
        Get
            Return New Window(GetSubMenu(Me.hwnd, index))
        End Get
    End Property
    Public ReadOnly Property SubMenus() As Window()
        Get
            Dim menus As New List(Of IntPtr)
            Dim currm As IntPtr = 0
            For i As Integer = 0 To Integer.MaxValue
                currm = GetSubMenu(Me.hwnd, i)
                If currm = 0 Then
                    Exit For
                Else
                    menus.Add(currm)
                End If
            Next
            Return All(menus)
        End Get
    End Property
    '-------------------------------------------------

    Public ReadOnly Property Process() As Process
        Get
            Try
                Dim ID As UInteger
                GetWindowThreadProcessId(Me.hwnd, ID)
                Return Process.GetProcessById(ID)
            Catch
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property ClassName(Optional ByVal length As Integer = 64) As String
        Get
            Dim s As New System.Text.StringBuilder(length)
            GetClassName(Me.hwnd, s, s.Capacity)
            Return s.ToString()
        End Get
    End Property
    Public Property Parent() As Window
        Get
            Dim Phwnd As IntPtr = GetParent(Me.hwnd)
            If Phwnd = 0 Then Return Nothing
            Return New Window(Phwnd)
        End Get
        Set(ByVal value As Window)
            SetParent(Me.hwnd, value.Handle)
        End Set
    End Property
    Public ReadOnly Property Children() As Window()
        Get
            Return Window.All(New Enumerator().GetChildWindows(Me.hwnd))
        End Get
    End Property
    Public ReadOnly Property Children(ByVal index As Integer) As Window
        Get
            Return New Window(New Enumerator().GetChildWindows(Me.hwnd)(index))
        End Get
    End Property
    Public ReadOnly Property Children(ByVal name As String) As Window
        Get
            Dim hwnd As IntPtr = FindWindowEx(Me.hwnd, 0, name, vbNullString)
            If hwnd = 0 Then
                For Each c As Window In Me.Children
                    If c.Name = name Then Return c
                Next
                Return Nothing
            End If
            Return New Window(hwnd)
        End Get
    End Property
    Public ReadOnly Property Children(ByVal Location As Point) As Window
        Get
            Return New Window(ChildWindowFromPoint(Me.hwnd, New API.WPOINT(Location.X, Location.Y)))
        End Get
    End Property
    Public ReadOnly Property ChildIndex(ByVal name As String) As Integer
        Get
            Dim w() As Window = Me.Children
            For i As Integer = 0 To w.Count - 1
                If w(i).Name = name Then Return i
            Next
            Return -1
        End Get
    End Property
    Public ReadOnly Property TopSibling() As Window
        Get
            Return New Window(GetWindow(Me.hwnd, GW.HWNDFIRST))
        End Get
    End Property
    Public ReadOnly Property BottomSibling() As Window
        Get
            Return New Window(GetWindow(Me.hwnd, GW.HWNDLAST))
        End Get
    End Property
    Public ReadOnly Property PreviousSibling() As Window
        Get
            Return New Window(GetWindow(Me.hwnd, GW.HWNDPREV))
        End Get
    End Property
    Public ReadOnly Property NextSibling() As Window
        Get
            Return New Window(GetWindow(Me.hwnd, GW.HWNDNEXT))
        End Get
    End Property
    Public Function FindChild(ByVal name As String, Optional ByVal matchcase As Boolean = False) As Window
        If matchcase = False Then name = name.ToLower
        For Each w As Window In Me.Children
            Dim wn As String = w.Name
            If matchcase = False Then wn = wn.ToLower
            If wn.Contains(name) Then Return w
        Next
        Return Nothing
    End Function
    Public Property FocusedWindow() As Window
        Get
            Me.AttachInput()
            FocusedWindow = New Window(GetFocus)
            Me.DetachInput()
        End Get
        Set(ByVal value As Window)
            value.Command(CMD.Focus)
        End Set
    End Property

    Public Function AttachInput(Optional ByVal attach As Boolean = True) As Boolean
        Return CBool(API.AttachThreadInput(GetWindowThreadProcessId(Me.hwnd, 0), API.GetCurrentThreadId(), CInt(attach)))
    End Function
    Public Function DetachInput() As Boolean
        Return AttachInput(False)
    End Function

    Public Shared Function All(ByVal p() As Process) As Window()
        Dim w As New List(Of Window)
        For Each proc As Process In p
            If proc.MainWindowHandle <> 0 Then w.Add(New Window(proc.MainWindowHandle))
        Next
        Return w.ToArray
    End Function
    Public Shared Function All() As Window()
        Return New Window(IntPtr.Zero).Children
    End Function
    Public Shared Function All(ByVal ParamArray hwnd() As IntPtr) As Window()
        Dim w(hwnd.Count - 1) As Window
        For i As Integer = 0 To w.Count - 1
            w(i) = New Window(hwnd(i))
        Next
        Return w
    End Function
    Public Shared Function All(ByVal hwnd As List(Of IntPtr)) As Window()
        Dim w(hwnd.Count - 1) As Window
        For i As Integer = 0 To w.Count - 1
            w(i) = New Window(hwnd(i))
        Next
        Return w
    End Function
    Public Shared Function All(ByVal p As Process) As Window()
        Return All(New Enumerator().GetThreadWindows(p.Id))
    End Function
    Public Shared Function AllFromDesktop(ByVal desktophwnd As IntPtr) As Window()
        Return All(New Enumerator().GetDesktopWindows(desktophwnd))
    End Function
    Public Shared Function AllFromDesktop() As Window()
        Return AllFromDesktop(Nothing)
    End Function
    Public Shared Function AllFromProcessList() As Window()
        Return All(Process.GetProcesses)
    End Function
    Public Shared Function FromControl(ByVal c As Control) As Window
        Return New Window(c.Handle)
    End Function
    Public Shared Function FromPoint(ByVal p As Point) As Window
        Return New Window(WindowFromPoint(New API.WPOINT(p.X, p.Y)))
    End Function
    Public Shared Function FromHandle(ByVal hwnd As IntPtr) As Window
        Return New Window(hwnd)
    End Function
    Public Shared Function Find(ByVal name As String, Optional ByVal matchcase As Boolean = False) As Window
        Return New Window(IntPtr.Zero).FindChild(name, matchcase)
    End Function
    Public Shared Function GetActive() As Window
        Return New Window(GetForegroundWindow)
    End Function
    Public Shared Function GetDesktop() As Window
        Return New Window(GetDesktopWindow())
    End Function
    Public Shared Function GetTop(ByVal parent As Window) As Window
        Return New Window(GetTopWindow(parent.hwnd))
    End Function
    Public Shared Function GetTop() As Window
        Return New Window(GetTopWindow(Nothing))
    End Function
    Public Shared Function GetForeground() As Window
        Return New Window(GetForegroundWindow())
    End Function
    Public Shared Function GetFocused() As Window
        Return GetForeground.FocusedWindow
    End Function
End Class