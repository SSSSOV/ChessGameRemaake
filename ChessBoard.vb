Public Class ChessBoard

    Private board As Figure()()

    Public figuresPlayer1 As Figure()
    Private allPossibleCuts1 As Integer()() = New Integer(7)() {}
    Public figuresPlayer2 As Figure()
    Private allPossibleCuts2 As Integer()() = New Integer(7)() {}

    ''' <summary>
    ''' Constructor of board.
    ''' </summary>
    ''' <param name="path">Path from file with level.</param>
    Public Sub New(Optional path As String = "Default")
        ArrangeFigures(path)
    End Sub

    ''' <summary>
    ''' Check Is the point on the board.
    ''' </summary>
    ''' <returns>
    ''' True - the point Is locate on the board.
    ''' False - the point Is Not locate.
    ''' </returns>
    Private Shared Function OnBoard(point As Point) As Boolean
        If (point.X < 0 Or point.X > 7) Then
            Return False
        End If
        If (point.Y < 0 Or point.Y > 7) Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' This method remove figure from array with figures.
    ''' </summary>
    ''' <param name="figures">Array with figures.</param>
    ''' <param name="removeFigure">Figure to be removed.</param>
    ''' <returns>Array whithout figure.</returns>
    Private Shared Function ArrayRemove(figures As Figure(), removeFigure As Figure) As Figure()
        Dim isContain As Boolean = False
        For Each f As Figure In figures
            If (f.Equals(removeFigure)) Then
                isContain = True
                Exit For
            End If
        Next

        If (Not isContain) Then Return figures

        Dim k As Integer = 0
        Dim newFigures As Figure() = New Figure(figures.Length - 2) {}
        For Each f As Figure In figures
            If (Not f.Equals(removeFigure)) Then
                newFigures(k) = f
                k += 1
            End If
        Next
        Return newFigures
    End Function

    ''' <summary>
    ''' This method add figure to array with figures.
    ''' </summary>
    ''' <param name="figures">Array with figures.</param>
    ''' <param name="addFigure">Figure to be added.</param>
    ''' <returns>Array whith figure.</returns>
    Private Shared Function ArrayAdd(figures As Figure(), addFigure As Figure) As Figure()
        Dim isContain As Boolean = False
        For Each f As Figure In figures
            If (f.Equals(addFigure)) Then
                isContain = True
                Exit For
            End If
        Next
        If (isContain) Then Return figures

        Dim k As Integer = 0
        Dim newFigures As Figure() = New Figure(figures.Length) {}
        For Each f As Figure In figures
            newFigures(k) = f
            k += 1
        Next
        newFigures(k) = addFigure

        Return newFigures
    End Function

    ''' <summary>
    ''' Arrange the figures in their starting positions.
    ''' </summary>
    ''' <param name="path">Path to file with starting positions.</param>
    Public Sub ArrangeFigures(Optional path As String = "Default")
        If (path = "Default") Then
            figuresPlayer1 = New Figure() {
                    New Figure("rook", 1, New Point(0, 0)),
                    New Figure("knight", 1, New Point(1, 0)),
                    New Figure("bishop", 1, New Point(2, 0)),
                    New Figure("queen", 1, New Point(3, 0)),
                    New Figure("king", 1, New Point(4, 0)),
                    New Figure("bishop", 1, New Point(5, 0)),
                    New Figure("knight", 1, New Point(6, 0)),
                    New Figure("rook", 1, New Point(7, 0)),
                    New Figure("pawn", 1, New Point(0, 1)),
                    New Figure("pawn", 1, New Point(1, 1)),
                    New Figure("pawn", 1, New Point(2, 1)),
                    New Figure("pawn", 1, New Point(3, 1)),
                    New Figure("pawn", 1, New Point(4, 1)),
                    New Figure("pawn", 1, New Point(5, 1)),
                    New Figure("pawn", 1, New Point(6, 1)),
                    New Figure("pawn", 1, New Point(7, 1))
                    }
            figuresPlayer2 = New Figure() {
                New Figure("rook", 2, New Point(0, 7)),
                New Figure("knight", 2, New Point(1, 7)),
                New Figure("bishop", 2, New Point(2, 7)),
                New Figure("queen", 2, New Point(3, 7)),
                New Figure("king", 2, New Point(4, 7)),
                New Figure("bishop", 2, New Point(5, 7)),
                New Figure("knight", 2, New Point(6, 7)),
                New Figure("rook", 2, New Point(7, 7)),
                New Figure("pawn", 2, New Point(0, 6)),
                New Figure("pawn", 2, New Point(1, 6)),
                New Figure("pawn", 2, New Point(2, 6)),
                New Figure("pawn", 2, New Point(3, 6)),
                New Figure("pawn", 2, New Point(4, 6)),
                New Figure("pawn", 2, New Point(5, 6)),
                New Figure("pawn", 2, New Point(6, 6)),
                New Figure("pawn", 2, New Point(7, 6))
                }

        Else
            Using streamReader As System.IO.StreamReader = New System.IO.StreamReader(path)
                Dim line As String = streamReader.ReadLine()
                If (line = Nothing) Then
                    MessageBox.Show("Incorrect level fileNot ", "ErrorNot ")
                    Return
                End If
                figuresPlayer1 = New Figure() {}
                figuresPlayer2 = New Figure() {}
                While (line <> Nothing)
                    Dim lineFigure As String() = line.Split(" ")
                    If (Integer.Parse(lineFigure(0)) = 1) Then
                        figuresPlayer1 = ArrayAdd(figuresPlayer1, New Figure(lineFigure(1), 1, New Point(Integer.Parse(lineFigure(3)), Integer.Parse(lineFigure(2)))))
                    ElseIf (Integer.Parse(lineFigure(0)) = 2) Then
                        figuresPlayer2 = ArrayAdd(figuresPlayer2, New Figure(lineFigure(1), 2, New Point(Integer.Parse(lineFigure(3)), Integer.Parse(lineFigure(2)))))
                    End If
                    line = streamReader.ReadLine()
                End While
            End Using
        End If

        board = New Figure(7)() {}
        For i = 0 To 7
            board(i) = New Figure(7) {}
        Next

        For Each f As Figure In figuresPlayer1
            board(f.position.X)(f.position.Y) = f
        Next
        For Each f As Figure In figuresPlayer2
            board(f.position.X)(f.position.Y) = f
        Next
        For x = 0 To 7
            For y = 0 To 7
                If IsNothing(board(x)(y)) Then
                    board(x)(y) = New Figure()
                End If
            Next
        Next

        For Each i As Integer() In allPossibleCuts1
            i = New Integer(7) {}
        Next
        For Each i As Integer() In allPossibleCuts2
            i = New Integer(7) {}
        Next
        allPossibleCuts1 = GetPossibleAllCutsMap(1)
        allPossibleCuts2 = GetPossibleAllCutsMap(2)
    End Sub

    ''' <summary>
    ''' Get map with possible cuts all figures of player.
    ''' </summary>
    ''' <param name="id">Id of player.</param>
    ''' <returns>Map with possible cuts.</returns>
    Public Function GetPossibleAllCutsMap(id As Integer) As Integer()()
        Dim cutsMap As Integer()() = New Integer(7)() {}
        For i = 0 To 7
            cutsMap(i) = New Integer(7) {}
        Next

        Dim possibleCuts As Integer()() = New Integer(7)() {}
        For i = 0 To 7
            possibleCuts(i) = New Integer(7) {}
        Next
        Dim figures As Figure()

        If (id = 1) Then
            figures = figuresPlayer1
        ElseIf (id = 2) Then
            figures = figuresPlayer2
        Else
            Return cutsMap
        End If
        For Each f In figures
            possibleCuts = getPossibleCuts(f.position)
            If (IsNothing(possibleCuts)) Then Continue For
            cutsMap = AdditionTwoCutsMaps(cutsMap, possibleCuts)
        Next
        Return cutsMap
    End Function

    ''' <summary>
    ''' Addition two cuts maps
    ''' </summary>
    ''' <param name="map1">First cuts map.</param>
    ''' <param name="map2">Second cuts map.</param>
    ''' <returns>Map after addition.</returns>
    Public Shared Function AdditionTwoCutsMaps(map1 As Integer()(), map2 As Integer()()) As Integer()()
        For x = 0 To 7
            For y = 0 To 7
                If map2(x)(y) > 0 Or map1(x)(y) > 1 Then
                    map1(x)(y) = 1
                End If
            Next
        Next

        Return map1
    End Function

    ''' <summary>
    ''' Remove cuts map from moves map.
    ''' </summary>
    ''' <param name="moves">Moves map.</param>
    ''' <param name="cuts">Cuts map.</param>
    ''' <returns>Moves map after subtraction.</returns>
    Public Shared Function RemoveCutsFromMoves(moves As Integer()(), cuts As Integer()()) As Integer()()
        For x = 0 To 7
            For y = 0 To 7
                If (cuts(x)(y) > 0) Then
                    moves(x)(y) = 0
                End If
            Next
        Next

        Return moves
    End Function

    ''' <summary>
    ''' Add cuts map to moves map.
    ''' </summary>
    ''' <param name="moves">Moves map.</param>
    ''' <param name="cuts">Cuts map.</param>
    ''' <returns>Moves map after addition.</returns>
    Public Shared Function AdditionMovesCutsMaps(moves As Integer()(), cuts As Integer()()) As Integer()()
        For x = 0 To 7
            For y = 0 To 7
                If (cuts(x)(y) > 1 And moves(x)(y) = 0) Then
                    moves(x)(y) = cuts(x)(y)
                End If
            Next
        Next

        Return moves
    End Function

    ''' <summary>
    ''' Checks if the map Is empty.
    ''' </summary>
    ''' <param name="map">Checked map.</param>
    ''' <returns>
    ''' True - if map Is empty.
    ''' False - if map Is Not empty.
    ''' </returns>
    Public Shared Function IsEmptyMap(map As Integer()()) As Boolean
        For x = 0 To 7
            For y = 0 To 7
                If (map(x)(y) = 1 Or map(x)(y) = 2) Then
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    ''' <summary>
    ''' Get possible moves for figure what stand in figurePoint on chess board.
    ''' 1 - Can move.
    ''' </summary>
    ''' <param name="figurePoint">Position figure on chess board.</param>
    ''' <returns>Map possible moves.</returns>
    Public Function getPossibleMoves(figurePoint As Point) As Integer()()
        Dim resultMap As Integer()() = New Integer(7)() {}
        For i = 0 To 7
            resultMap(i) = New Integer(7) {}
        Next

        Dim figure As Figure = getFigure(figurePoint)
        Dim movesMap As Integer()() = figure.moves
        Dim moveRadius As Integer
        Dim point As Point

        If (figure.isChanging) Then
            moveRadius = If(figure.isFirst, figure.moveRadius1, figure.moveRadius2)
        Else
            moveRadius = figure.moveRadius1
        End If

        If (figure.isFixed) Then
            Dim movesMapSize As Integer = moveRadius * 2 + 1

            For x = 0 To movesMapSize - 1
                point = New Point(figurePoint.X - moveRadius + x, 0)
                If (Not OnBoard(point)) Then Continue For
                For y = 0 To movesMapSize - 1
                    point.Y = figurePoint.Y - moveRadius + y
                    If (Not OnBoard(point)) Then Continue For
                    If (movesMap(x)(y) = 1 And getFigure(point).name = "none") Then resultMap(point.X)(point.Y) = 1
                Next
            Next
        Else
            Dim radius As Integer

            If (movesMap(0)(0) = 1) Then
                point = New Point(figurePoint.X - 1, figurePoint.Y - 1)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.X -= 1
                    point.Y -= 1
                    radius += 1
                End While
            End If

            If (movesMap(1)(0) = 1) Then
                point = New Point(figurePoint.X, figurePoint.Y - 1)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.Y -= 1
                    radius += 1
                End While
            End If

            If (movesMap(2)(0) = 1) Then
                point = New Point(figurePoint.X + 1, figurePoint.Y - 1)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.X += 1
                    point.Y -= 1
                    radius += 1
                End While
            End If

            If (movesMap(2)(1) = 1) Then
                point = New Point(figurePoint.X + 1, figurePoint.Y)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.X += 1
                    radius += 1
                End While
            End If

            If (movesMap(2)(2) = 1) Then
                point = New Point(figurePoint.X + 1, figurePoint.Y + 1)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.X += 1
                    point.Y += 1
                    radius += 1
                End While
            End If

            If (movesMap(1)(2) = 1) Then
                point = New Point(figurePoint.X, figurePoint.Y + 1)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.Y += 1
                    radius += 1
                End While
            End If

            If (movesMap(0)(2) = 1) Then
                point = New Point(figurePoint.X - 1, figurePoint.Y + 1)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.X -= 1
                    point.Y += 1
                    radius += 1
                End While
            End If

            If (movesMap(0)(1) = 1) Then
                point = New Point(figurePoint.X - 1, figurePoint.Y)
                radius = 1
                While OnBoard(point) And radius <= moveRadius
                    If (getFigure(point).name = "none") Then
                        resultMap(point.X)(point.Y) = 1
                    Else Exit While
                    End If
                    point.X -= 1
                    radius += 1
                End While
            End If
        End If

        Return resultMap
    End Function

    ''' <summary>
    ''' Get possible cuts for figure what stand in figurePoint on chess board.
    ''' 2 - Can cut.
    ''' 3 - Can cut, but figurePoint Is empty.
    ''' 4 - Can cut, but figurePoint Is busy.
    ''' </summary>
    ''' <param name="figurePoint">Position figure on chess board.</param>
    ''' <returns>Map possible cuts.</returns>
    Public Function getPossibleCuts(figurePoint As Point) As Integer()()
        Dim resultMap As Integer()() = New Integer(7)() {}
        For i = 0 To 7
            resultMap(i) = New Integer(7) {}
        Next
        Dim figure As Figure = getFigure(figurePoint)
        Dim cutsMap As Integer()() = figure.cuts
        Dim cutRadius As Integer
        Dim point As Point

        cutRadius = figure.moveRadius2

        If (figure.isFixed) Then
            Dim cutsMapSize As Integer = cutRadius * 2 + 1

            For x = 0 To cutsMapSize - 1
                point = New Point(figurePoint.X - cutRadius + x, 0)
                If (Not OnBoard(point)) Then Continue For

                For y = 0 To cutsMapSize - 1
                    point.Y = figurePoint.Y - cutRadius + y
                    If (Not OnBoard(point)) Then Continue For

                    If (cutsMap(x)(y) = 1) Then
                        If (getFigure(point).name = "none") Then
                            resultMap(point.X)(point.Y) = 3
                        ElseIf (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        Else
                            resultMap(point.X)(point.Y) = 4
                        End If
                    End If
                Next
            Next
        Else
            Dim radius As Integer
            If (cutsMap(0)(0) = 1) Then
                point = New Point(figurePoint.X - 1, figurePoint.Y - 1)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.X -= 1
                    point.Y -= 1
                    radius += 1
                End While
            End If

            If (cutsMap(1)(0) = 1) Then
                point = New Point(figurePoint.X, figurePoint.Y - 1)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.Y -= 1
                    radius += 1
                End While
            End If

            If (cutsMap(2)(0) = 1) Then
                point = New Point(figurePoint.X + 1, figurePoint.Y - 1)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.X += 1
                    point.Y -= 1
                    radius += 1
                End While
            End If

            If (cutsMap(2)(1) = 1) Then
                point = New Point(figurePoint.X + 1, figurePoint.Y)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.X += 1
                    radius += 1
                End While
            End If

            If (cutsMap(2)(2) = 1) Then
                point = New Point(figurePoint.X + 1, figurePoint.Y + 1)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.X += 1
                    point.Y += 1
                    radius += 1
                End While
            End If

            If (cutsMap(1)(2) = 1) Then
                point = New Point(figurePoint.X, figurePoint.Y + 1)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.Y += 1
                    radius += 1
                End While
            End If

            If (cutsMap(0)(2) = 1) Then
                point = New Point(figurePoint.X - 1, figurePoint.Y + 1)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.X -= 1
                    point.Y += 1
                    radius += 1
                End While
            End If

            If (cutsMap(0)(1) = 1) Then
                point = New Point(figurePoint.X - 1, figurePoint.Y)
                radius = 1
                While OnBoard(point) And radius <= cutRadius

                    If getFigure(point).name = "none" Then
                        resultMap(point.X)(point.Y) = 3
                    Else
                        If (getFigure(point).idPlayer <> figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 2
                        ElseIf (getFigure(point).idPlayer = figure.idPlayer) Then
                            resultMap(point.X)(point.Y) = 4
                        End If
                        Exit While
                    End If

                    point.X -= 1
                    radius += 1
                End While
            End If
        End If

        Return resultMap
    End Function

    ''' <summary>
    ''' Get possible actions for figure what stand in figurePoint on chess board.
    ''' 1 - Can move.
    ''' 2 - Can cut.
    ''' 3 - Can cut, but figurePoint Is empty.
    ''' 4 - Can cut, but figurePoint Is busy.
    ''' If the figure Is the main, then all possible cuts of the other player are subtracted from its move map.
    ''' </summary>
    ''' <param name="figurePoint">Position figure on chess board.</param>
    ''' <returns>Map possible cuts.</returns>
    Public Function getPossibleActions(figurePoint As Point) As Integer()()
        Dim resultMap As Integer()() = New Integer(7)() {}
        For Each i In resultMap
            i = New Integer(7) {}
        Next
        resultMap = AdditionMovesCutsMaps(getPossibleMoves(figurePoint), getPossibleCuts(figurePoint))
        If (getFigure(figurePoint).isMain) Then
            If (getFigure(figurePoint).idPlayer = 1) Then resultMap = RemoveCutsFromMoves(resultMap, allPossibleCuts2)
            If (getFigure(figurePoint).idPlayer = 2) Then resultMap = RemoveCutsFromMoves(resultMap, allPossibleCuts1)
        End If
        Return resultMap
    End Function

    ''' <summary>
    ''' Get figure from point on the board.
    ''' </summary>
    ''' <param name="point">Point on the board.</param>
    ''' <returns>Figure from point</returns>
    Public Function getFigure(point As Point) As Figure
        If (OnBoard(point)) Then Return board(point.X)(point.Y)
        Return New Figure()
    End Function

    ''' <summary>
    ''' Move figure on the board from old point to New point.
    ''' </summary>
    ''' <param name="oldPoint">Old point of figure on the board.</param>
    ''' <param name="newPoint">New point of figure on the board.</param>
    Public Sub MoveFigure(oldPoint As Point, newPoint As Point)
        If (board(oldPoint.X)(oldPoint.Y).idPlayer = 1) Then
            For Each f In figuresPlayer1
                If (f.position = oldPoint) Then f.position = newPoint
            Next
        End If
        If (board(oldPoint.X)(oldPoint.Y).idPlayer = 2) Then
            For Each f In figuresPlayer2
                If (f.position = oldPoint) Then f.position = newPoint
            Next
        End If

        board(newPoint.X)(newPoint.Y) = board(oldPoint.X)(oldPoint.Y)
        board(newPoint.X)(newPoint.Y).isFirst = False
        board(oldPoint.X)(oldPoint.Y) = New Figure()

        allPossibleCuts1 = GetPossibleAllCutsMap(1)
        allPossibleCuts2 = GetPossibleAllCutsMap(2)
    End Sub

    ''' <summary>
    ''' Cut figure on the board from New point by figure from old point.
    ''' </summary>
    ''' <param name="oldPoint">Old point of figure on the board.</param>
    ''' <param name="newPoint">New point of figure on the board.</param>
    Public Sub CutFigure(oldPoint As Point, newPoint As Point)
        If (board(oldPoint.X)(oldPoint.Y).idPlayer = 1) Then
            For Each f In figuresPlayer1
                If (f.position = oldPoint) Then f.position = newPoint
            Next
            For Each f In figuresPlayer2
                If (f.position = newPoint) Then figuresPlayer2 = ArrayRemove(figuresPlayer2, f)
            Next
        End If
        If (board(oldPoint.X)(oldPoint.Y).idPlayer = 2) Then
            For Each f In figuresPlayer2
                If (f.position = oldPoint) Then f.position = newPoint
            Next
            For Each f In figuresPlayer1
                If (f.position = newPoint) Then figuresPlayer1 = ArrayRemove(figuresPlayer1, f)
            Next
        End If
        board(newPoint.X)(newPoint.Y) = board(oldPoint.X)(oldPoint.Y)
        board(newPoint.X)(newPoint.Y).isFirst = False
        board(oldPoint.X)(oldPoint.Y) = New Figure()

        allPossibleCuts1 = GetPossibleAllCutsMap(1)
        allPossibleCuts2 = GetPossibleAllCutsMap(2)
    End Sub

    ''' <summary>
    ''' Checks if the game Is over.
    ''' </summary>
    ''' <returns>A line with a possible end of the game.</returns>
    Public Function GameOver() As String
        Dim message As String = ""
        If (figuresPlayer1.Length = 0) Then
            message = "Player 2 won!"
        ElseIf (figuresPlayer2.Length = 0) Then
            message = "Player 1 won!"
        Else
            For Each f In figuresPlayer1
                If (Not f.isMain) Then Continue For
                If (IsEmptyMap(getPossibleActions(f.position)) And allPossibleCuts2(f.position.X)(f.position.Y) <> 0) Then
                    message = "Checkmate for 1 player"
                    Exit For
                End If
            Next
            For Each f In figuresPlayer2
                If (Not f.isMain) Then Continue For
                If (IsEmptyMap(getPossibleActions(f.position)) And allPossibleCuts1(f.position.X)(f.position.Y) <> 0) Then
                    message = "Checkmate for 2 player"
                    Exit For
                End If
            Next
        End If

        If (message <> "") Then
            MessageBox.Show(message, "GameOver!")
        Else
            For Each f In figuresPlayer1
                If (Not f.isMain) Then Continue For
                If (allPossibleCuts2(f.position.X)(f.position.Y) <> 0) Then
                    message = "Check for 1 player"
                    Exit For
                End If
            Next
            For Each f In figuresPlayer2
                If (Not f.isMain) Then Continue For
                If (allPossibleCuts1(f.position.X)(f.position.Y) <> 0) Then
                    message = "Check for 2 player"
                    Exit For
                End If
            Next
        End If
        Return message
    End Function
End Class
