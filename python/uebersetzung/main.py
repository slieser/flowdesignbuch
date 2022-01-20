def f():
    for x in ['1', '2']:
        yield x


def g():
    my_list = ['1', '2']

    yield '0'
    yield from my_list
    yield '3'

def main():
    for x in f():
        print(x)
    for x in g():
        print(x)


if __name__ == '__main__':
    main()