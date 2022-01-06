from filenameprovider import find_source_filenames


def main():
    find_source_filenames('../../',
        lambda filename: print(filename),
        lambda: print('Finished!'))

main()
