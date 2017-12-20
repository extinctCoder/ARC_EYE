board = []
size = 8


def danger(row, col):
    print "looking for place in row : " + str(row) + ", col : " + str(col)
    for i, j in board:
        if row == i:
            print "danger! " + "row : " + str(row) + " == " + "i : " + str(i)
            return True
        if col == j:
            print "danger! " + "col : " + str(col) + " == " + "j : " + str(j)
            return True
        if abs(row - i) == abs(col - j):
            print "danger! " + "(" + str(row) + " - " + str(i) + ") == abs(" + str(col) + " - " + str(j) + ")"
            return True
    print "row : " + str(row) + ", col : " + str(col) + " place is safe ..."
    return False


def placeQueen(row):
    if row > size:
        print "solved queen placement is : "
        print board
        print "............................"
    else:
        for col in range(1, size + 1):
            if not danger(row, col):
                print "safe!! queen placeing queen in row : " + str(row) + ", col : " + str(col)
                board.append((row, col))
                print "searching queen position in row : " + str(row) + ", col : " + str(col + 1)
                placeQueen(row + 1)
                print "danger! queen removing queen from row : " + str(row) + ", col : " + str(col)
                board.remove((row, col))

if __name__ == "__main__":
    placeQueen(1)
