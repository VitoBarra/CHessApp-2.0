from ScriptChess import *
import copy


match = chessboard()


match.update_number_matrix()
PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))


def catch_the_move(board, turn=0):  # 0 for white to move, 1 for black to move
    k = 0
    if turn == 0: print "white to move"
    else: print "black to move"
    pygamemossacoordinateperboard = ""
    while k == 0:
        if PythonPass.TrackBackValue(): PythonPass.BildPieceOnBoard(StringaStrana(board.matrix_with_numbers))
        zorrotto = PythonPass.Mossa()
        #print zorrotto
        if len(zorrotto) == 2:
            #print zorrotto
            if board.matrix[int(zorrotto[0])][int(zorrotto[1])] == "" and len(
                    pygamemossacoordinateperboard) == 0:
                pass
            else:
                pygamemossacoordinateperboard += zorrotto
            if len(pygamemossacoordinateperboard) == 4:
                try:
                    board.generate_for_white()
                    board.generate_for_black()
                    if turn == 0:
                        if pygamemossacoordinateperboard in board.moveswhite:
                            if board.check_if_white_is_in_check():
                                board.make_move_number(pygamemossacoordinateperboard)
                                board.generate_for_white()
                                board.generate_for_black()
                                if not board.check_if_white_is_in_check():
                                    return pygamemossacoordinateperboard
                            else:
                                board.make_move_number(pygamemossacoordinateperboard)
                                board.generate_for_white()
                                board.generate_for_black()
                                if not board.check_if_white_is_in_check():
                                    return pygamemossacoordinateperboard
                    else:
                        if pygamemossacoordinateperboard in board.movesblack:
                            if board.check_if_black_is_in_check():
                                board.make_move_number(pygamemossacoordinateperboard)
                                board.generate_for_white()
                                board.generate_for_black()
                                if not board.check_if_black_is_in_check():
                                    return pygamemossacoordinateperboard
                            else:
                                board.make_move_number(pygamemossacoordinateperboard)
                                board.generate_for_white()
                                board.generate_for_black()
                                if not board.check_if_black_is_in_check():
                                    return pygamemossacoordinateperboard

           
                except:
                    pass
                pygamemossacoordinateperboard = ""

# capisci compilatore di merda
pass


while True:
    temporary = copy.deepcopy(match)
    move = catch_the_move(temporary, turn=0)
    match.make_move_number(move)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
    PythonPass.WhiteMove(move)
    kek = match.check_if_checkmate_is_imminent(color=1)
    if kek == 1:
        PythonPass.CheckMate("Black")
        PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
        break
    elif kek == 2:
        PythonPass.CheckMate("White")
        PythonPass.BildPieOnBoard(StrigaStrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break
    temporary = copy.deepcopy(match)
    move = catch_the_move(temporary, turn=1)
    match.make_move_number(move)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
    PythonPass.BlackMove(move)
    kek = match.check_if_checkmate_is_imminent(color=0)
    if kek == 1:
        PythonPass.CheckMate("Black")
        PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
        break
    elif kek == 2:
        PythonPass.CheckMate("White")
        PythonPass.BildPieOnBoard(StrigaStrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break