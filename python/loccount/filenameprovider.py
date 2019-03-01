import os

def findSourcefiles(path, onSourcefile):
    for root, dirs, files in os.walk(path):
        for name in files:
            if name.endswith(".py"):
                qualifiedName = root + "/" + name
                onSourcefile(qualifiedName)
        for dir in dirs:
            findSourcefiles(dir, onSourcefile)