def ShowLocStat(LOCstat):
    global sumTotal
    global sumLOC

    filename, total, loc = LOCstat
    sumTotal += total
    sumLOC += loc
    print filename + " " + str(total) + " " + str(loc)

def ShowTotal():
    print ""
    print "Total"
    print "  Lines: " + str(sumTotal)
    print "  LOC:   " + str(sumLOC)

sumTotal = 0
sumLOC = 0