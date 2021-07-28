from interactors import start
from ui import get_text, show_count

if __name__ == '__main__':
    text = get_text()
    count = start(text)
    show_count(count)
