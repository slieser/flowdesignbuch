from filenameprovider import findSourcefiles
from fileprovider import ReadFile
from linesofcode import CreateLOCstat

def start(onLocStat):
    findSourcefiles(".", lambda filename: onFile(filename, onLocStat))

def onFile(filename, onLocStat):
    lines = ReadFile(filename)
    locstat = CreateLOCstat(filename, lines)
    onLocStat(locstat)
