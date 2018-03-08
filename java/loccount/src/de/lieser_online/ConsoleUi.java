package de.lieser_online;

public class ConsoleUi {
    private LocStat sum = new LocStat();

    public void ShowLoc(LocStat locstat) {
        sum.Loc += locstat.Loc;
        sum.Total += locstat.Total;
        System.out.println(locstat.Filename + ", " + locstat.Loc + ", " + locstat.Total);
    }

    public void ShowSum() {
        System.out.println();
        System.out.println("Sum:");
        System.out.println("  LOC:   " + sum.Loc);
        System.out.println("  Total: " + sum.Total);
    }
}
