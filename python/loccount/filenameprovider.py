import os


def find_source_filenames(path, on_sourcefile, on_finished):
    path = os.path.abspath(path)
    _find_source_filenames(path, on_sourcefile)
    on_finished()


def _find_source_filenames(path, on_sourcefile):
    for root, dirs, files in os.walk(path):
        if root.endswith("venv"):
            return
        for name in files:
            if name.endswith(".py"):
                qualified_name = os.path.join(root, name)
                on_sourcefile(qualified_name)
        for dir in dirs:
            _find_source_filenames(dir, on_sourcefile)
