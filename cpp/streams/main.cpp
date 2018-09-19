#include <iostream>

void GetSourceCodeFiles(
        std::string directory,
        std::function<void(std::string filename)> onFilename,
        std::function<void()> onFinished) {
    onFilename("datei1.txt");
    onFilename("datei2.txt");
    onFilename("datei3.txt");
    onFinished();
}

int main() {
    GetSourceCodeFiles("./",
            [](std::string filename) {
                std::cout << filename << std::endl;
            },
            [](){
                std::cout << "Finished!" << std::endl;
            });
    return 0;
}
