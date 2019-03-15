import os

def FindSourcefiles(path, onSourcefile, onFinished):
    path = os.path.abspath(path)
    _FindSourceFiles(path, onSourcefile)
    onFinished()

def _FindSourceFiles(path, onSourcefile):
    for root, dirs, files in os.walk(path):
        if root.endswith("venv"):
            return
        for name in files:
            if name.endswith(".py"):
                qualifiedName = os.path.join(root, name)
                onSourcefile(qualifiedName)
        for dir in dirs:
            _FindSourceFiles(dir, onSourcefile)
