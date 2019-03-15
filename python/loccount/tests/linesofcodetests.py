import unittest

from linesofcode import isLoc, CreateLOCstat


class isLoc_Tests(unittest.TestCase):
    def test_empty_line(self):
        self.assertEqual(isLoc(""), False)

    def test_blank(self):
        self.assertEqual(isLoc(" "), False)

    def test_multiple_blanks(self):
        self.assertEqual(isLoc("   "), False)

    def test_tab(self):
        self.assertEqual(isLoc("\t"), False)

    def test_multiple_tabs(self):
        self.assertEqual(isLoc("\t\t\t"), False)

    def test_whitespace(self):
        self.assertEqual(isLoc(" \t \t"), False)

    def test_comment(self):
        self.assertEqual(isLoc("#"), False)

    def test_whitespace_comment(self):
        self.assertEqual(isLoc("  \t  #"), False)

    def test_code(self):
        self.assertEqual(isLoc("a"), True)


class CreateLOCstat_Tests(unittest.TestCase):
    def test_example(self):
        (filename, total, loc) = CreateLOCstat("fn.py", ["", "a", "#"])
        self.assertEqual(filename, "fn.py")
        self.assertEqual(3, total)
        self.assertEqual(1, loc)
