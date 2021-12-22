import unittest

from linesofcode import is_loc, create_locstat


class IslocTests(unittest.TestCase):
    def test_empty_line(self):
        self.assertEqual(is_loc(""), False)

    def test_blank(self):
        self.assertEqual(is_loc(" "), False)

    def test_multiple_blanks(self):
        self.assertEqual(is_loc("   "), False)

    def test_tab(self):
        self.assertEqual(is_loc("\t"), False)

    def test_multiple_tabs(self):
        self.assertEqual(is_loc("\t\t\t"), False)

    def test_whitespace(self):
        self.assertEqual(is_loc(" \t \t"), False)

    def test_comment(self):
        self.assertEqual(is_loc("#"), False)

    def test_whitespace_comment(self):
        self.assertEqual(is_loc("  \t  #"), False)

    def test_code(self):
        self.assertEqual(is_loc("a"), True)


class CreateLocStatTests(unittest.TestCase):
    def test_example(self):
        (filename, total, loc) = create_locstat("fn.py", ["", "a", "#"])
        self.assertEqual(filename, "fn.py")
        self.assertEqual(3, total)
        self.assertEqual(1, loc)
