Public Class Figure

    'Main fields
    Public Property position As Point   ' Position On board.
    Public Property name As String       ' Name Of figure.
    Public Property idPlayer As Integer     ' Id Of player.
    Public Property image As Image  ' Image Of figure.
    Public Property idImage As Integer  ' Id Of image from sprite.
    Public Property isMain As Boolean   ' Main figure?
    Public Property isFirst As Boolean  ' First move?
    Public Property isFixed As Boolean  ' Fixed moves?
    Public Property isSimetrical As Boolean  ' Simetrical moves?
    Public Property isChanging As Boolean   ' Changing moves after first?
    Public Property isSame As Boolean   ' Cut same With moves?
    Public Property moveRadius1 As Integer   ' Radius For first move.
    Public Property moveRadius2 As Integer   ' Radius For another moves.
    Public Property moves As Integer()()  ' Map Of moves.
    Public Property cuts As Integer()()   ' Map Of cuts.

    ' File fields
    Shared figuresPath As String = "res/figures.txt" ' Path To file With figures descriptions.
    Shared spritePath As String = "res\Sprite_figures.png" ' Path To file With figures images.

    ' Sprite fields
    Private spriteFigures As Image = New Bitmap(spritePath) ' Sprite With all figures images.
    Private spriteSize As Size = New Size(100, 100) ' Size Of image For figures.

    ''' <summary>
    ''' Сreating an empty figure.
    ''' </summary>
    Public Sub New()
        name = "none"
        idPlayer = 0
    End Sub

    ''' <summary>
    ''' Initializes a New figure. The image for figures gets from file using name.
    ''' </summary>
    ''' <param name="name">The name of figure.</param>
    ''' <param name="idPlayer">The id of player.</param>
    Public Sub New(name As String, idPlayer As Integer, position As Point)
        Me.name = name
        Me.idPlayer = idPlayer
        Me.position = position
        isFirst = True

        Using streamReader As System.IO.StreamReader = New System.IO.StreamReader(figuresPath)
            Dim line As String
            Dim isFound As Boolean = False
            line = streamReader.ReadLine()
            While Not line Is Nothing
                If (line = name) Then
                    isFound = True
                    Exit While
                End If
                line = streamReader.ReadLine()
            End While

            If Not isFound Then
                Me.name = "none"
                Me.idPlayer = 0

            Else
                idImage = Integer.Parse(streamReader.ReadLine())
                isMain = streamReader.ReadLine() = "main"
                isFixed = streamReader.ReadLine() = "fixed"
                isSimetrical = streamReader.ReadLine() = "simetrical"
                isChanging = streamReader.ReadLine() = "changing"
                moveRadius1 = Integer.Parse(streamReader.ReadLine().Split("=")(1))
                If (isChanging) Then
                    moveRadius2 = Integer.Parse(streamReader.ReadLine().Split("=")(1))
                Else moveRadius2 = moveRadius1
                End If

                If (isFixed) Then
                    moves = MapReadFromSR(streamReader, moveRadius1 * 2 + 1)
                Else moves = MapReadFromSR(streamReader, 3)
                End If
                isSame = streamReader.ReadLine() = "same"
                If (Not isSame) Then
                    cuts = If(isFixed, MapReadFromSR(streamReader, moveRadius2 * 2 + 1), MapReadFromSR(streamReader, 3))
                Else cuts = moves
                End If
                If (Not isSimetrical And idPlayer = 1) Then
                    moves = FlipYMap(moves, If(isFixed, moveRadius1 * 2 + 1, 3))
                    cuts = FlipYMap(cuts, If(isFixed, moveRadius2 * 2 + 1, 3))
                End If

                image = New Bitmap(100, 100)
                Dim g As Graphics = Graphics.FromImage(image)
                Dim spritePoint As Point = New Point(0, 0)
                spritePoint.X = 100 * idImage
                If (idPlayer = 2) Then spritePoint.Y = 100
                g.DrawImage(spriteFigures, New Rectangle(0, 0, spriteSize.Width, spriteSize.Height), spritePoint.X, spritePoint.Y, spriteSize.Width, spriteSize.Height, GraphicsUnit.Pixel)
            End If
        End Using
        Me.position = position
    End Sub

    ''' <summary>
    ''' Reads a 2d array from the curent stream.
    ''' </summary>
    ''' <param name="streamReader">The curent stream.</param>
    ''' <param name="sideSize">The side length of 2d array.</param>
    ''' <returns>Map from stream.</returns>
    Public Shared Function MapReadFromSR(streamReader As System.IO.StreamReader, sideSize As Integer) As Integer()()
        Dim map As Integer()() = New Integer(sideSize - 1)() {}
        For i = 0 To sideSize - 1
            map(i) = New Integer(sideSize - 1) {}
        Next
        For y = 0 To sideSize - 1
            Dim line As String = streamReader.ReadLine()
            For x = 0 To sideSize - 1
                map(x)(y) = If(line(x) = "1"c, 1, 0)
            Next
        Next
        Return map
    End Function

    ''' <summary>
    ''' Vertical flip array.
    ''' </summary>
    ''' <param name="map">2d array for flipping.</param>
    ''' <param name="sideSize">Side length of 2d array.</param>
    ''' <returns>Fliped map.</returns>
    Public Shared Function FlipYMap(map As Integer()(), sideSize As Integer) As Integer()()
        Dim newMap As Integer()() = New Integer(sideSize - 1)() {}
        For i = 0 To sideSize - 1
            newMap(i) = New Integer(sideSize - 1) {}
        Next
        For x = 0 To sideSize - 1
            For y = 0 To sideSize - 1
                newMap(x)(y) = map(x)(sideSize - y - 1)
            Next
        Next
        Return newMap
    End Function
End Class
