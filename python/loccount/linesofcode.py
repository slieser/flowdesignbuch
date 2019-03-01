def CreateLOCstat(filename, lines):
    total = len(lines)
    loc = len([line for line in lines if isLoc(line)])
    result = (filename, total, loc)
    return result

def isLoc(line):
    return (line.lstrip() != "") & (not line.lstrip().startswith("#"))
