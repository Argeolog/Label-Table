Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.CompilerServices
Public Class MyPicturebox
    Inherits PictureBox

    Private service As TransformService = New TransformService()
    Private isMoving As Boolean = False
    Private prevPoint As Point

    Public Function TranslatePoint(ByVal actualPoint As Point) As Point
        Return service.TranslatePoint(actualPoint)
    End Function

    Public Function TranslatePoint(ByVal actualPoint As PointF) As PointF
        Return service.TranslatePoint(actualPoint)
    End Function
    Public Function GetImagePoint(ByVal actualPoint As Point) As Point
        Return TranslatePoint(actualPoint)
    End Function

    'Public Sub Pan(ByVal offsetX As Single, ByVal offsetY As Single)
    '    service.Pan(offsetX, offsetY)
    '    Invalidate()
    'End Sub

    Public Sub Zoom(ByVal scale As Single, ByVal zoomCenter As PointF)
        service.Zoom(scale, zoomCenter)

        Invalidate()
    End Sub

    Public Sub Restore()
        service.Restore()
        Invalidate()
    End Sub

    Public Sub ShowImage(ByVal image As Image, ByVal Optional remainTransform As Boolean = True)
        If Not remainTransform Then
            service.Restore()
        End If

        image = image
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        isMoving = True
        prevPoint = e.Location
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        isMoving = False
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseHover(ByVal e As EventArgs)
        MyBase.OnMouseHover(e)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

        Mousex = e.Location.X
        Mousey = e.Location.Y

        'If isMoving Then

        ' If Image IsNot Nothing Then
        '     Dim newPoint = e.Location
        '     Dim offsetX = newPoint.X - prevPoint.X
        '     Dim offsetY = newPoint.Y - prevPoint.Y
        '     prevPoint = newPoint
        ''     service.Pan(offsetX, offsetY)
        '     Invalidate()
        ' End If


        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim point = TranslatePoint(New PointF(e.Location.X, e.Location.Y))

        If Image IsNot Nothing Then

            If e.Delta > 0 Then
                service.Zoom(1.2F, point)
            Else
                service.Zoom(1.0F / 1.2F, point)
            End If

            Invalidate()
        End If

        MyBase.OnMouseWheel(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor
        service.ApplyTransform(pe.Graphics)





        MyBase.OnPaint(pe)
    End Sub
End Class



Friend Class TransformService

    Private scale_Conflict As Single
    Private matrixChanged As Boolean = False
    Private matrixInvert As New Matrix()
    Private ReadOnly matrix As New Matrix()


    Public Property ScaleMax() As Single = 1000

    Public ReadOnly Property Scale() As Single
        Get
            Return scale_Conflict
        End Get
    End Property

    Public Sub New()
        scale_Conflict = 1.0F
        scaleOffsetX = scaleOffsetY
        translateX = translateY
    End Sub

    Public Sub Pan(ByVal offsetX As Single, ByVal offsetY As Single)
        matrixChanged = True
        translateX += offsetX
        translateY += offsetY
    End Sub

    Public Sub Zoom(ByVal zoomFactor As Single, ByVal zoomCenter As PointF)
        matrixChanged = True
        Dim oldScale = scale_Conflict
        scale_Conflict = CoerceZoom(scale_Conflict * zoomFactor)

        Dim deltaScale = scale_Conflict - oldScale
        Dim deltaX As Single = -zoomCenter.X * deltaScale
        Dim deltaY As Single = -zoomCenter.Y * deltaScale

        scaleOffsetX += deltaX
        scaleOffsetY += deltaY

    End Sub

    Public Sub Restore()
        scale_Conflict = 1
        scaleOffsetX = scaleOffsetY
        translateX = translateY
        matrixChanged = True
    End Sub

    Public Sub ApplyTransform(ByVal gs As Graphics)
        EnsureMatrix()
        gs.Transform = matrix
    End Sub

    Public Function TranslatePoint(ByVal point As Point) As Point
        EnsureMatrix()
        singlePoint(0) = point
        matrixInvert.TransformPoints(singlePoint)

        Return singlePoint(0)
    End Function

    Public Sub TranslatePoints(ByVal points() As Point)
        EnsureMatrix()
        matrixInvert.TransformPoints(points)
    End Sub

    Public Function TranslatePoint(ByVal point As PointF) As PointF
        EnsureMatrix()
        singlePointF(0) = point
        matrixInvert.TransformPoints(singlePointF)
        Return singlePointF(0)
    End Function

    Public Sub TranslatePoints(ByVal points() As PointF)
        EnsureMatrix()
        matrixInvert.TransformPoints(points)
    End Sub

    Private Sub EnsureMatrix()
        If matrixChanged Then
            matrix.Reset()
            matrix.Scale(scale_Conflict, scale_Conflict, MatrixOrder.Append)
            matrix.Translate(scaleOffsetX, scaleOffsetY, MatrixOrder.Append)
            matrix.Translate(translateX, translateY, MatrixOrder.Append)

            matrixInvert = matrix.Clone()
            matrixInvert.Invert()
            matrixChanged = False
        End If
    End Sub



    Friend Function CoerceZoom(ByVal baseValue As Single) As Single
        Dim zoom = baseValue
        If zoom < 0.1F Then
            zoom = 0.1F
        End If
        If zoom > ScaleMax Then
            zoom = ScaleMax
        End If
        If zoom.IsNanOrInfinity() Then
            zoom = 1.0F
        End If
        Return zoom
    End Function



End Class


Friend Module TransformExtensions
    <System.Runtime.CompilerServices.Extension>
    Public Function IsNotEqual(ByVal value1 As Single, ByVal value2 As Single) As Boolean
        Dim result = Math.Abs(value1 - value2) >= 0.000001F
        Return result
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function IsNanOrInfinity(ByVal value As Single) As Boolean
        Return Single.IsNaN(value) OrElse Single.IsInfinity(value)
    End Function

End Module

