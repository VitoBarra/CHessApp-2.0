from ScriptChess import *

match = chessboard()
k1,k2 = PythonPass.Difficulty()
k1-= 48
k2 -= 48
match.set_field(2)  # base value, va aggiunta una funzione in c#




while True:
    match.set_field(k1)
    evW, movW = match.minmaxtreeevaluationai()
    match.make_move_number(movW)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))

    if evW == 1000000:
        pythonpass.checkmate("white")
        pythonpass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    elif evW == -1000000:
        pythonpass.checkmate("black")
        pythonpass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break



    match.set_field(k2)
    evB, movB = match.blackminmax()
    match.make_move_number(movB)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))


    if evB == 1000000:
        pythonpass.checkmate("white")
        pythonpass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    elif evB == -1000000:
        pythonpass.checkmate("black")
        pythonpass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break
