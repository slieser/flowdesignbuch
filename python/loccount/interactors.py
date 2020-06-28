from commandline import GetPath
from filenameprovider import FindSourcefiles
from fileprovider import ReadFile
from linesofcode import CreateLOCstat

def start(args, onLocStat, onFinished):
    path = GetPath(args)
    FindSourcefiles(path, lambda filename: onFile(filename, onLocStat), onFinished)

def onFile(filename, onLocStat):
    lines = ReadFile(filename)
    locstat = CreateLOCstat(filename, lines)
    onLocStat(locstat)
