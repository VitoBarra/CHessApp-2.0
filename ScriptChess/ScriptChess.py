import copy
import time
# import numpy as np
from GenericFunction import *


def StrigaStrana(a):
    stringa = ""
    for x in a:
        for b in x:
            if b > -1:
                stringa += "+"
                stringa += str(b)
            else:
                stringa += str(b)
    return stringa


class chessboard():
    def __init__(self):
        # a = pawn
        # b = bishop  --> B
        # k = knight ---> N
        # r = rook -----> R
        # q = queen ----> Q
        # p = king -----> K
        self.matrix = [["r1", "k1", "b1", "p1", "q1", "b1", "k1", "r1"],
                       ["a1", "a1", "a1", "a1", "a1", "a1", "a1", "a1"], ["", "", "", "", "", "", "", ""],
                       ["", "", "", "", "", "", "", ""], ["", "", "", "", "", "", "", ""],
                       ["", "", "", "", "", "", "", ""], ["a2", "a2", "a2", "a2", "a2", "a2", "a2", "a2"],
                       ["r2", "k2", "b2", "p2", "q2", "b2", "k2", "r2"]]
        self.depth = 0
        self.searchfield = 5
        self.movehistoryw = []
        self.movehistoryb = []
        self.castle = [True, True, True, True]  # white kingside - queenside, black kingside queenside
        self.moveswhite = []
        self.movesblack = []
        self.debug = 0
        self.alfa = 1000000
        self.beta = -1000000
        self.moverem = ""
        self.matrix_with_numbers = []

        try:

            for xnxx in range(8):
                self.matrix_with_numbers.append([0, 0, 0, 0, 0, 0, 0, 0])
        except:
            print "okay non va qui"


    def exportposition(self):
        print self.matrix

    def set_depth(self, dep):
        self.depth = dep

    def frompng_to_numbers(self, stringa):
        for q1 in range(8):
            for q2 in range(8):
                for q3 in range(8):
                    for q4 in range(8):
                        if str(q1) + str(q2) != str(q3) + str(q4):
                            zeta = str(q1) + str(q2) + str(q3) + str(q4)
                            if self.trasformazionepernotazione(zeta) == stringa:
                                return zeta
        return 0

    def set_field(self, field):
        self.searchfield = field

    def create_string_of_all_moves(self):
        jj = ""
        if len(self.movehistoryb) == len(self.movehistoryw): kek = 0
        else: kek = 1
        for k in range(len(self.movehistoryw) - kek):
            j1 = self.movehistoryb[k]
            j2 = self.movehistoryw[k]
            if len(j1) == 4:
                jj += j1 + "a"
            else:
                jj += j1
            if len(j2) == 4:
                jj += j2 + "a"
            else:
                jj += j2
        if kek:
            j1 = self.movehistoryw[len(self.movehistoryw)]
            if len(j1) == 4:
                jj += j1 + "a"
            else:
                jj += j1
        return jj



    def setposition(self, matr):
        self.matrix = copy.deepcopy(matr)

    def trasformforpgn(self, mossa):
        mossa = str(mossa)
        move = ""
        if self.matrix[int(mossa[0])][int(mossa[1])] != "":
            if self.matrix[int(mossa[0])][int(mossa[1])][0] == "a":
                if mossa[0] == "1" and mossa[1] == "4":
                    kasdjosad = 0
                move += transform_from_number(mossa[1])
                if mossa[1] == mossa[3]:
                    move += str(int(mossa[2]) + 1)
                else:
                    move += "x"
                    move += transform_from_number(mossa[3])
                    move += str(int(mossa[2]) + 1)
                return move

        if self.matrix[int(mossa[2])][int(mossa[3])] == "":
            return exchangeforpgn(self.matrix[int(mossa[0])][int(mossa[1])][0]) + transform_from_number(mossa[1]) + str(
                int(mossa[0]) + 1) + transform_from_number(mossa[3]) + str(int(mossa[2]) + 1)
        else:
            return exchangeforpgn(self.matrix[int(mossa[0])][int(mossa[1])][0]) + transform_from_number(mossa[1]) + str(
                int(mossa[0]) + 1) + "x" + transform_from_number(mossa[3]) + str(int(mossa[2]) + 1)

    def make_move_string(self, move):
        z = move.split(' ')
        c1a, c2a = cord(z[0])
        c1b, c2b = cord(z[1])
        print(c1a, c2a, c1b, c2b)

        self.matrix[c1b][c2b] = copy.deepcopy(self.matrix[c1a][c2a])
        self.matrix[c1a][c2a] = ''

    def make_move_number(self, number):
        if self.matrix[int(number[0])][int(number[1])][1] == "1":
            self.movehistoryw += [number]
        else:
            self.movehistoryb += [number]
        if len(number) == 5:
            if self.matrix[int(number[0])][int(number[1])][1] == "1":
                self.matrix[int(number[2])][int(number[3])] = number[4] + "1"
            else:
                self.matrix[int(number[2])][int(number[3])] = number[4] + "2"
            self.matrix[int(number[0])][int(number[1])] = ''
            return 0
        self.matrix[int(number[2])][int(number[3])] = copy.deepcopy(self.matrix[int(number[0])][int(number[1])])
        self.matrix[int(number[0])][int(number[1])] = ''



        if number[0] == 0 and number[1] == 0:
            self.castle[0] = False
        elif number[0] == 0 and number[1] == 7:
            self.castle[1] = False
        elif number[0] == 7 and number[1] == 0:
            self.castle[2] = False
        elif number[0] == 7 and number[1] == 7:
            self.castle[3] = False

    def backtracking(self):
        total_moves = []
        for h in range(len(self.movehistoryw)):
            total_moves += self.movehistoryw[h]
            if h < len(self.movehistoryb): total_moves += self.movehistoryb[h]
        nuovo_temp = chessboard()
        for j in range(len(total_moves) - 1):
            nuovo_temp.make_move_number(total_moves[j])
        nuovo_temp.update_number_matrix()
        return nuovo_temp.matrix_with_numbers


    def pawnmoves(self, coord1, coord2):
        moves = []
        try:
            if self.matrix[coord1 + 1][coord2] == "":
                xissadodj = 0
        except:
            pene = 0
            return []
        if self.matrix[coord1 + 1][coord2] == "":
            moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2)]
            if coord1 == 1 and self.matrix[coord1 + 2][coord2] == "":
                moves += [str(coord1) + str(coord2) + str(coord1 + 2) + str(coord2)]
        if coord1 == 6 and self.matrix[coord1 + 1][coord2] == "":
            moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2) + "q"]
            moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2) + "k"]
        if coord2 != 0:
            if self.matrix[coord1 + 1][coord2 - 1] != "":
                if self.matrix[coord1 + 1][coord2 - 1][1] == "2":
                    if coord1 == 6:
                        moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 - 1) + "q"]
                        moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 - 1) + "k"]
                    else:
                        moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 - 1)]
        if coord2 != 7:
            if self.matrix[coord1 + 1][coord2 + 1] != "":
                if self.matrix[coord1 + 1][coord2 + 1][1] == "2":
                    if coord1 == 6:
                        moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 + 1) + "q"]
                        moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 + 1) + "k"]
                    else:
                        moves += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 + 1)]
        return moves

    def knightmoves(self, coord1, coord2):
        moves = []
        movi = []
        movi += [str(coord1) + str(coord2) + str(coord1 + 2) + str(coord2 + 1)]
        movi += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 + 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 2) + str(coord2 - 1)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 - 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 - 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 + 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 2) + str(coord2 + 1)]
        movi += [str(coord1) + str(coord2) + str(coord1 + 2) + str(coord2 - 1)]
        for z in movi:
            if "-" not in z and "8" not in z and "9" not in z:
                if self.matrix[int(z[2])][int(z[3])] == "":
                    moves.append(z)
                elif self.matrix[int(z[2])][int(z[3])][1] == "2":
                    moves.append(z)
        return moves

    def bishopmoves(self, coord1, coord2):
        moves = []
        # up right
        z1 = coord1 + 1
        z2 = coord2 + 1
        while z1 < 8 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 += 1
                z2 += 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = 100
            else:
                z1 = 100

        # up left
        z1 = coord1 + 1
        z2 = coord2 - 1
        while z1 < 8 and z2 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 += 1
                z2 -= 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = 100
            else:
                z1 = 100

        # down right
        z1 = coord1 - 1
        z2 = coord2 + 1
        while z1 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 -= 1
                z2 += 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = -100
            else:
                z1 = -100

        # down left
        z1 = coord1 - 1
        z2 = coord2 - 1
        while z1 > -1 and z2 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 -= 1
                z2 -= 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = -100
            else:
                z1 = -100
        return moves

    def rookmoves(self, coord1, coord2):
        moves = []
        # right
        z2 = coord2 + 1
        z1 = coord1
        while z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 += 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 = 100
            else:
                z2 = 100

        # left
        z1 = coord1
        z2 = coord2 - 1
        while z2 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 -= 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 = -100
            else:
                z2 = -100

        # up
        z1 = coord1 + 1
        z2 = coord2
        while z1 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 += 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = 100
            else:
                z1 = 100

        # down
        z1 = coord1 - 1
        z2 = coord2
        while z1 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 -= 1
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = -100
            else:
                z1 = -100
        return moves

    def kingmoves(self, coord1, coord2):
        moves = []
        z1 = coord1 + 1
        z2 = coord2 + 1
        if z1 > -1 and z1 < 8 and -1 < z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 + 1
        z2 = coord2 - 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 - 1
        z2 = coord2 + 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 - 1
        z2 = coord2 - 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1
        z2 = coord2 + 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1
        z2 = coord2 - 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 + 1
        z2 = coord2
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 - 1
        z2 = coord2
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "2":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        return moves

    def pawnmovesb(self, coord1, coord2):
        moves = []
        if self.matrix[coord1 - 1][coord2] == "":
            moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2)]
        if coord1 == 6 and self.matrix[coord1 - 1][coord2] == "" and self.matrix[coord1 - 2][coord2] == "":
            moves += [str(coord1) + str(coord2) + str(coord1 - 2) + str(coord2)]
        if coord1 == 1 and self.matrix[coord1 - 1][coord2] == "":
            moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2) + "q"]
            moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2) + "k"]
        if coord2 != 0:
            if self.matrix[coord1 - 1][coord2 - 1] != "":
                if self.matrix[coord1 - 1][coord2 - 1][1] == "1":
                    if coord1 == 1:
                        moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 - 1) + "q"]
                        moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 - 1) + "k"]
                    else:
                        moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 - 1)]
        if coord2 != 7:
            if self.matrix[coord1 - 1][coord2 + 1] != "":
                if self.matrix[coord1 - 1][coord2 + 1][1] == "1":
                    if coord1 == 1:
                        moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 + 1) + "q"]
                        moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 + 1) + "k"]
                    else:
                        moves += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 + 1)]
        return moves

    def knightmovesb(self, coord1, coord2):
        moves = []
        movi = []
        movi += [str(coord1) + str(coord2) + str(coord1 + 2) + str(coord2 + 1)]
        movi += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 + 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 2) + str(coord2 - 1)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 - 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 + 1) + str(coord2 - 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 1) + str(coord2 + 2)]
        movi += [str(coord1) + str(coord2) + str(coord1 - 2) + str(coord2 + 1)]
        movi += [str(coord1) + str(coord2) + str(coord1 + 2) + str(coord2 - 1)]
        for z in movi:
            if "-" not in z and "8" not in z and "9" not in z:
                if self.matrix[int(z[2])][int(z[3])] == "":
                    moves.append(z)
                elif self.matrix[int(z[2])][int(z[3])][1] == "1":
                    moves.append(z)
        return moves

    def bishopmovesb(self, coord1, coord2):
        moves = []
        # up right
        z1 = coord1 + 1
        z2 = coord2 + 1
        while z1 < 8 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 += 1
                z2 += 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = 100
            else:
                z1 = 100

        # up left
        z1 = coord1 + 1
        z2 = coord2 - 1
        while z1 < 8 and z2 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 += 1
                z2 -= 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = 100
            else:
                z1 = 100

        # down right
        z1 = coord1 - 1
        z2 = coord2 + 1
        while z1 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 -= 1
                z2 += 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = -100
            else:
                z1 = -100

        # down left
        z1 = coord1 - 1
        z2 = coord2 - 1
        while z1 > -1 and z2 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 -= 1
                z2 -= 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = -100
            else:
                z1 = -100
        return moves

    def rookmovesb(self, coord1, coord2):
        moves = []
        # right
        z2 = coord2 + 1
        z1 = coord1
        while z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 += 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 = 100
            else:
                z2 = 100

        # left
        z1 = coord1
        z2 = coord2 - 1
        while z2 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 -= 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z2 = -100
            else:
                z2 = -100

        # up
        z1 = coord1 + 1
        z2 = coord2
        while z1 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 += 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = 100
            else:
                z1 = 100

        # down
        z1 = coord1 - 1
        z2 = coord2
        while z1 > -1:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 -= 1
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
                z1 = -100
            else:
                z1 = -100
        return moves

    def kingmovesb(self, coord1, coord2):
        moves = []
        z1 = coord1 + 1
        z2 = coord2 + 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 + 1
        z2 = coord2 - 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 - 1
        z2 = coord2 + 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 - 1
        z2 = coord2 - 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1
        z2 = coord2 + 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1
        z2 = coord2 - 1
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 + 1
        z2 = coord2
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        z1 = coord1 - 1
        z2 = coord2
        if z1 > -1 and z1 < 8 and z2 > -1 and z2 < 8:
            if self.matrix[z1][z2] == "":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]
            elif self.matrix[z1][z2][1] == "1":
                moves += [str(coord1) + str(coord2) + str(z1) + str(z2)]

        return moves

    def generate_for_white(self):
        self.moveswhite = []
        for j1 in range(8):
            for j2 in range(8):
                pointer = self.matrix[j1][j2]
                if pointer != "":
                    if pointer[1] == "1":
                        if pointer[0] == "a":
                            self.moveswhite += self.pawnmoves(j1, j2)
                        if pointer[0] == "k":
                            self.moveswhite += self.knightmoves(j1, j2)
                        if pointer[0] == "b":
                            self.moveswhite += self.bishopmoves(j1, j2)
                        if pointer[0] == "r":
                            self.moveswhite += self.rookmoves(j1, j2)
                        if pointer[0] == "q":
                            self.moveswhite += self.bishopmoves(j1, j2)
                            self.moveswhite += self.rookmoves(j1, j2)
                        if pointer[0] == "p":
                            self.moveswhite += self.kingmoves(j1, j2)

    def generate_for_black(self):
        self.movesblack = []
        for j1 in range(8):
            for j2 in range(8):
                pointer = self.matrix[j1][j2]
                if pointer != "":
                    if pointer[1] == "2":
                        if pointer[0] == "a":
                            self.movesblack += self.pawnmovesb(j1, j2)
                        if pointer[0] == "k":
                            self.movesblack += self.knightmovesb(j1, j2)
                        if pointer[0] == "b":
                            self.movesblack += self.bishopmovesb(j1, j2)
                        if pointer[0] == "r":
                            self.movesblack += self.rookmovesb(j1, j2)
                        if pointer[0] == "q":
                            self.movesblack += self.bishopmovesb(j1, j2)
                            self.movesblack += self.rookmovesb(j1, j2)
                        if pointer[0] == "p":
                            self.movesblack += self.kingmovesb(j1, j2)
        if self.castle[2] == True:
            self.moveswhite += ["bO-O"]
        if self.castle[3] == True:
            self.moveswhite += ["bO-O-O"]

    def check_if_white_is_in_check(self):
        for j1 in range(8):
            for j2 in range(8):
                if self.matrix[j1][j2] != "":
                    if self.matrix[j1][j2] == "p1":
                        if self.checkif_attacked_whitepiece(str(j1), str(j2)):
                            return 1
        return 0

    def check_if_black_is_in_check(self):
        for j1 in range(8):
            for j2 in range(8):
                if self.matrix[j1][j2] != "":
                    if self.matrix[j1][j2] == "p2":
                        if self.checkif_attacked_blackpiece(str(j1), str(j2)):
                            return 1
        return 0

    def checkif_attacked_whitepiece(self, c1, c2):
        for h in self.movesblack:
            if h[2] == c1 and h[3] == c2:
                return 1
        return 0

    def checkif_attacked_blackpiece(self, c1, c2):
        for h in self.moveswhite:
            if h[2] == c1 and h[3] == c2:
                return 1
        return 0

    def checkcastle_white(self):
        return 0
        if self.castle[0] == True:
            if self.matrix[0][1] == "" and self.matrix[0][2] == "":
                if not self.check_if_white_is_in_check() and self.checkif_attacked_whitepiece("0",
                                                                                              "1") and self.checkif_attacked_whitepiece(
                    "0", "2"):
                    self.moveswhite += ["wO-O"]
        if self.castle[1] == True:
            if self.matrix[0][4] == "" and self.matrix[0][5] == "" and self.matrix[0][6] == "":
                if not self.check_if_white_is_in_check() and self.checkif_attacked_whitepiece("0",
                                                                                              "4") and self.checkif_attacked_whitepiece(
                    "0", "5") and self.checkif_attacked_whitepiece("0", "6"):
                    self.moveswhite += ["wO-O-O"]

    def checkcastle_black(self):
        return 0
        if self.castle[2] == True:
            if self.matrix[7][1] == "" and self.matrix[7][2] == "":
                if not self.check_if_black_is_in_check() and self.checkif_attacked_blackpiece("7",
                                                                                              "1") and self.checkif_attacked_blackpiece(
                    "7", "2"):
                    self.moveswhite += ["bO-O"]
        if self.castle[3] == True:
            if self.matrix[7][4] == "" and self.matrix[7][5] == "" and self.matrix[7][6] == "":
                if not self.check_if_black_is_in_check() and self.checkif_attacked_blackpiece("7",
                                                                                              "4") and self.checkif_attacked_blackpiece(
                    "7", "5") and self.checkif_attacked_blackpiece("7", "6"):
                    self.moveswhite += ["bO-O-O"]

    def evaluate(self):
        # make evaluation
        zeta = 0
        for j1 in range(8):
            for j2 in range(8):
                kk = self.matrix[j1][j2]
                if kk != "":
                    if kk[1] == "1":

                        # white
                        if kk[0] == "a":
                            zeta += 100 + pawn_table[(7 - j1) * 8 + j2]
                        elif kk[0] == "b":
                            zeta += 300 + bishop_table[(7 - j1) * 8 + j2]
                        elif kk[0] == "k":
                            zeta += 300 + knight_table[(7 - j1) * 8 + j2]
                        elif kk[0] == "r":
                            zeta += 500 + rook_table[(7 - j1) * 8 + j2]
                        elif kk[0] == "q":
                            zeta += 900 + queen_table[(7 - j1) * 8 + j2]
                        elif kk[0] == "p":
                            zeta += 20000
                    else:

                        if kk[0] == "a":
                            zeta -= 100 + pawn_table[8 * j1 + j2]
                        elif kk[0] == "b":
                            zeta -= 300 + bishop_table[8 * j1 + j2]
                        elif kk[0] == "k":
                            zeta -= 300 + knight_table[8 * j1 + j2]
                        elif kk[0] == "r":
                            zeta -= 500 + rook_table[8 * j1 + j2]
                        elif kk[0] == "q":
                            zeta -= 900 + queen_table[8 * j1 + j2]
                        elif kk[0] == "p":
                            zeta -= 20000

        return zeta

    def check_whiteking(self):
        for j1 in range(8):
            for j2 in range(8):
                kk = self.matrix[j1][j2]
                if kk != "":
                    if kk == "p1":
                        return 1
        return 0

    def check_blackking(self):
        for j1 in range(8):
            for j2 in range(8):
                kk = self.matrix[j1][j2]
                if kk != "":
                    if kk == "p2":
                        return 1
        return 0

    def repetitiondraw(self):
        try:
            if self.movehistoryw[-1] == self.movehistoryw[-3] and self.movehistoryw[-1] == self.movehistoryw[-5] and self.movehistoryb[-1] == self.movehistoryb[-3] and self.movehistoryb[-1] == self.movehistoryb[-5]:
                if self.movehistoryw[-2] == self.movehistoryw[-4] and self.movehistoryw[-2] == self.movehistoryw[-6] and self.movehistoryb[-2] == self.movehistoryb[-4] and self.movehistoryb[-2] == self.movehistoryb[-6]:
                    return 1
        except:
            return 0
        return 0

    def minmaxtreeevaluationai(self):
        if self.depth == self.searchfield:
            return self.evaluate()
        if self.repetitiondraw():
            return 0
        if not self.check_whiteking():
            if self.depth == 0:
                print("Checkmate")
                print("black win")
                return 1000000
            else:
                return -1000000
        if not self.check_blackking():
            if self.depth == 0:
                print("Checkmate")
                print("White win")
                return 1000000
            else:
                return 1000000
        if self.depth % 2 == 0:
            self.generate_for_white()
            self.checkcastle_white()
            k = self.moveswhite
            enn = []

            for move in k:
                new = chessboard()
                new.setposition(self.matrix)
                new.make_move_number(move)
                new.set_field(self.searchfield)
                new.set_depth(self.depth + 1)
                # new.movehistoryw += [move]
                new.movehistoryb = copy.deepcopy(self.movehistoryb)
                new.movehistoryw = copy.deepcopy(self.movehistoryw)
                enn += [new.minmaxtreeevaluationai()]

            varmax = -50000
            rem = 0
            for j in range(len(enn)):
                if int(enn[j]) > varmax:
                    varmax = enn[j]
                    rem = j
            if self.depth == 0:
                #    print("Evaluation:  ", enn[rem])
                #      print("best move:   ", k[rem])
                return enn[rem], k[rem]
            else:
                return enn[rem]

        else:
            self.generate_for_black()
            self.checkcastle_black()
            k = self.movesblack
            enn = []
            for move in k:
                new = chessboard()
                new.setposition(self.matrix)
                new.make_move_number(move)
                new.set_field(self.searchfield)
                new.set_depth(self.depth + 1)
                new.movehistoryb = copy.deepcopy(self.movehistoryb)
                new.movehistoryw = copy.deepcopy(self.movehistoryw)
                enn += [new.minmaxtreeevaluationai()]

            varmax = 50000
            rem = 0
            for j in range(len(enn)):
                if enn[j] < varmax:
                    varmax = enn[j]
                    rem = j

            return enn[rem]

    def blackminmax(self):
        if self.depth == self.searchfield:
            return self.evaluate()
        if not self.check_whiteking():
            if self.depth == 0:
                return -1000000
        if not self.check_blackking():
            if self.depth == 0:
                return -1000000
        if self.depth % 2 == 0:
            self.generate_for_black()
            self.checkcastle_black()
            k = self.movesblack
            enn = []

            for move in k:
                new = chessboard()
                new.setposition(self.matrix)
                new.make_move_number(move)
                new.set_field(self.searchfield)
                new.set_depth(self.depth + 1)
                new.movehistoryb = copy.deepcopy(self.movehistoryb)
                new.movehistoryw = copy.deepcopy(self.movehistoryw)
                enn += [new.blackminmax()]

            varmax = 50000
            rem = 0
            for j in range(len(enn)):
                if int(enn[j]) < varmax:
                    varmax = enn[j]
                    rem = j
            if self.depth == 0:
                return enn[rem], k[rem]
            else:
                return enn[rem]

        else:
            self.generate_for_white()
            self.checkcastle_white()
            k = self.moveswhite
            enn = []
            for move in k:
                new = chessboard()
                new.setposition(self.matrix)
                new.make_move_number(move)
                new.set_field(self.searchfield)
                new.set_depth(self.depth + 1)
                new.movehistoryb = copy.deepcopy(self.movehistoryb)
                new.movehistoryw = copy.deepcopy(self.movehistoryw)
                enn += [new.blackminmax()]

            varmax = -50000
            rem = 0
            for j in range(len(enn)):
                if enn[j] > varmax:
                    varmax = enn[j]
                    rem = j

            return enn[rem]

    def check_king(self):
        zeta = 0
        for j1 in range(8):
            for j2 in range(8):
                kk = self.matrix[j1][j2]
                if kk != "":
                    if kk[0] == "p":
                        zeta += 1
        return zeta

    def check_if_checkmate_is_imminent(self, color=0):
        
        #return 0 for no checkmate, 1 for checkmate by black, 2 for checkmate by white


        if color:  # se color == 1 allora ha appena mosso il bianco e deve generare il nero per vedere se c'e' un matto
            self.generate_for_black()
            temporal = [0] * len(self.movesblack)
            count = 0
            for j1 in self.movesblack:
                newchessboard = chessboard()
                newchessboard.setposition(self.matrix)
                newchessboard.make_move_number(j1)
                newchessboard.generate_for_white()
                for j2 in newchessboard.moveswhite:
                    newchessboard2 = chessboard()
                    newchessboard2.setposition(newchessboard.matrix)
                    newchessboard2.make_move_number(j2)
                    if not newchessboard2.check_blackking():
                        temporal[count] = 1
                count += 1
            if 0 not in temporal:
                return 1
        else:    # color == 0  
            self.generate_for_white()
            temporal = [0] * len(self.moveswhite)
            count = 0
            for j1 in self.moveswhite:
                newchessboard = chessboard()
                newchessboard.setposition(self.matrix)
                newchessboard.make_move_number(j1)
                newchessboard.generate_for_black()
                for j2 in newchessboard.movesblack:
                    newchessboard2 = chessboard()
                    newchessboard2.setposition(newchessboard.matrix)
                    newchessboard2.make_move_number(j2)
                    if not newchessboard2.check_whiteking():
                        temporal[count] = 1
                count += 1
            if 0 not in temporal:
                PythonPass.CheckMate("Black")
                return 1
        print 'nessun matto', color
        return 0

        

    def update_number_matrix(self):
        for j1 in range(8):
            for j2 in range(8):
                tester = self.matrix[j1][j2]
                if tester == "":
                    self.matrix_with_numbers[j1][j2] = 0
                if tester == "a1":
                    self.matrix_with_numbers[j1][j2] = 1
                if tester == "a2":
                    self.matrix_with_numbers[j1][j2] = -1
                if tester == "b1":
                    self.matrix_with_numbers[j1][j2] = 2
                if tester == "b2":
                    self.matrix_with_numbers[j1][j2] = -2
                if tester == "k1":
                    self.matrix_with_numbers[j1][j2] = 3
                if tester == "k2":
                    self.matrix_with_numbers[j1][j2] = -3
                if tester == "r1":
                    self.matrix_with_numbers[j1][j2] = 4
                if tester == "r2":
                    self.matrix_with_numbers[j1][j2] = -4
                if tester == "q1":
                    self.matrix_with_numbers[j1][j2] = 5
                if tester == "q2":
                    self.matrix_with_numbers[j1][j2] = -5
                if tester == "p1":
                    self.matrix_with_numbers[j1][j2] = 6
                if tester == "p2":
                    self.matrix_with_numbers[j1][j2] = -6

    #def Play_whitWhite(self):
    #    pygamemossacoordinateperboard = ""
    #    PythonPass.BildPiceOnBoard(StrigaStrana(self.matrix_with_numbers))
    #    for x in range(50):



    #        if self.check_if_checkmate_is_imminent():
    #            PythonPass.BildPiceOnBoard(StrigaStrana(self.matrix_with_numbers))
    #            break
            
    #        if self.repetitiondraw():
    #            PythonPass.DrawByRepetition()
    #            break



    #        t = time.time()
    #        evW, movW = self.minmaxtreeevaluationai()
    #        print time.time() - t
    #        self.make_move_number(movW)
    #        self.update_number_matrix()
    #        PythonPass.BildPiceOnBoard(StrigaStrana(self.matrix_with_numbers))
    #        k = 0
    #        if self.check_if_checkmate_is_imminent(color=1):
    #            PythonPass.BildPiceOnBoard(StrigaStrana(self.matrix_with_numbers))
    #            break
    #        while k == 0:
    #            zorrotto = PythonPass.Mossa()
    #            if len(zorrotto) == 2:
    #                #print zorrotto
    #                if self.matrix[int(zorrotto[0])][int(zorrotto[1])] == "" and len(
    #                        pygamemossacoordinateperboard) == 0:
    #                    pass
    #                else:
    #                    pygamemossacoordinateperboard += zorrotto
    #                if len(pygamemossacoordinateperboard) == 4:
    #                    try:
    #                        self.generate_for_black()
    #                        if pygamemossacoordinateperboard in self.movesblack:
    #                            self.make_move_number(pygamemossacoordinateperboard)
    #                            k = 1
    #                    except:
    #                        pass
    #                    pygamemossacoordinateperboard = ""
    #            trackBack = PythonPass.TrackBackValue()
    #            #if trackBack:
    #            #    for 

    #        PythonPass.BildPiceOnBoard(StrigaStrana(self.matrix_with_numbers))




#ch = chessboard()
#ch.setposition([["","","","","","","",""],
#["","","","","","","",""],
#["","","","","","","",""],
#["","","","","","","",""],
#["","","","","","","q2",""],
#["","","","","","","",""],
#["","","","","","","",""],
#["","","","","","p2","","p1"]])


