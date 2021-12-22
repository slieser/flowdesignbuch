class ConsoleUi:
    sum_total = 0
    sum_loc = 0

    def show_loc(self, locstat):
        filename, total, loc = locstat
        self.sum_total += total
        self.sum_loc += loc
        print(filename + " " + str(total) + " " + str(loc))

    def show_sum(self):
        print("")
        print("Total")
        print("  Lines: " + str(self.sum_total))
        print("  LOC:   " + str(self.sum_loc))
