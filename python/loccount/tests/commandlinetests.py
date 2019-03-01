import unittest

from commandline import GetPath

class commandlineTests(unittest.TestCase):
    def test_first_argument(self):
        self.assertEqual(GetPath(["_", "a", "_"]), "a")
