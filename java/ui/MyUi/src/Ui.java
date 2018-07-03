import java.util.function.BiConsumer;
import java.util.function.Consumer;

public class Ui {
    private final Consumer<String> onNewBook;
    private final BiConsumer<Integer, String> onLend;
    private final Consumer<Integer> onBack;
    private final Consumer<Integer> onDelete;

    public Ui(
            Consumer<String> onNewBook,
            BiConsumer<Integer, String> onLend,
            Consumer<Integer> onBack,
            Consumer<Integer> onDelete) {
        this.onNewBook = onNewBook;
        this.onLend = onLend;
        this.onBack = onBack;
        this.onDelete = onDelete;
    }

    public void OnNewBook() {
        String title = "...";  // Comes from text input
        onNewBook.accept(title);
    }
}
