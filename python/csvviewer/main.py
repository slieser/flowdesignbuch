from console_ui import show, run
from interactors import start

if __name__ == '__main__':
    records = start()
    show(records)

    run()
