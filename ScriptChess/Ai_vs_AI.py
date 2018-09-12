from ScriptChess import *

match = chessboard()
k1,k2 = PythonPass.Difficulty()
match.set_field(k1)  # base value, va aggiunta una funzione in c#


#match.setposition([["0","0","0","0","0","0","0","p1"],
#                   ["0","0","0","0","0","0","0","0"],
#                   ["0","0","0","0","0","0","0","0"],
#                   ["0","0","0","0","0","0","0","0"],
#                   ["0","0","0","0","0","0","0","0"],
#                   ["0","0","0","0","0","0","0","0"],
#                   ["0","0","0","0","0","0","0","0"],
#                   ["r2","0","0","p2","0","0","0","0"]])


#match.update_number_matrix()
#PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))

#print "qua va bello"
#match.generate_for_black()
#print match.movesblack

##testVar = raw_input("Ask user for something.")


while True:
    match.set_field(k1)
    evW, movW = match.minmaxtreeevaluationai()
    PythonPass.WhiteMove(match.trasformforpgn(movW))
    match.make_move_number(movW)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))

    if evW == 1000000:
        PythonPass.checkmate("white")
        PythonPass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    elif evW == -1000000:
        PythonPass.checkmate("black")
        PythonPass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break



    match.set_field(k2)
    evB, movB = match.blackminmax()
    PythonPass.BlackMove(match.trasformforpgn(movB))
    match.make_move_number(movB)
    match.update_number_matrix()
    PythonPass.BildPiceOnBoard(StrigaStrana(match.matrix_with_numbers))


    if evB == 1000000:
        PythonPass.checkmate("white")
        PythonPass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    elif evB == -1000000:
        PythonPass.checkmate("black")
        PythonPass.bildpiceonboard(strigastrana(match.matrix_with_numbers))
        break
    if match.repetitiondraw():
        PythonPass.DrawByRepetition()
        break
    