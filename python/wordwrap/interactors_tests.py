from unittest import TestCase

from interactors import start


class InteractorTests(TestCase):
    def test_start(self):
        result = list(start(['', 'max_und_moritz.txt', 20]))
        self.assertEqual(result, [
            'Mancher gibt sich',
            'viele Müh Mit dem',
            'lieben Federvieh:',
            'Einesteils der Eier',
            'wegen, Welche diese',
            'Vögel legen,',
            'Zweitens, weil man',
            'dann und wann Einen',
            'Braten essen kann;',
            'Drittens aber nimmt',
            'man auch Ihre Federn',
            'zum Gebrauch In die',
            'Kissen und die',
            'Pfühle, Denn man',
            'liegt nicht gerne',
            'kühle.',
            '',
            '”Seht, da ist die',
            'Witwe Bolte, Die das',
            'auch nicht gerne',
            'wollte.”',
            '',
            'Seht, da ist die',
            'Witwe Bolte, Die das',
            'auch nicht gerne',
            'wollte.',
            ''
        ])