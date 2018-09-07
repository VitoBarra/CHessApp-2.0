from ScriptChess import *

match = chessboard()

match.set_field(2)  # base value, va aggiunta una funzione in c#




while True:
    evW, movW = match.minmaxtreeevaluationai()
    match.make_move_number(movW)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
    if match.check_if_checkmate_is_imminent(color=1):
        PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break
    evB, movB = match.blackminmax()
    match.make_move_number(movB)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))


    if match.check_if_checkmate_is_imminent(color=0):
        PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break
