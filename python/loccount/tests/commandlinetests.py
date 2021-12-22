import unittest

from commandline import get_path


class CommandlineTests(unittest.TestCase):
    def test_first_argument(self):
        self.assertEqual(get_path(["_", "a", "_"]), "a")
