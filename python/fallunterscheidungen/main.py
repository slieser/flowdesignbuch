import unittest
from typing import Callable


def f(x: int, on_y: Callable[[str], None], on_z: Callable[[int], None]) -> None:
    if x < 0:
        on_y('negativ')
    else:
        on_z(x)


class Demo(unittest.TestCase):
    def test_f(self):
        f(-1, print, print)
        result1 = None
        result2 = None

        def store_result_1(x):
            nonlocal result1
            result1 = x

        f(1, store_result_1, (lambda x: (result2 := x)))
        self.assertEqual(result1, None)
        self.assertEqual(result2, 1)
