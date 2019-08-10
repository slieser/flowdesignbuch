#include <iostream>
#include <filesystem>

void GetSourceCodeFiles(
        std::string directory,
        std::function<void(std::string filename)> onFilename,
        std::function<void()> onFinished) {

    std::filesystem::recursive_directory_iterator iter(directory);
    std::filesystem::recursive_directory_iterator end;

    while (iter != end)
    {
        onFilename(iter->path().string());

        error_code ec;
        iter.increment(ec);
        if (ec) {
            std::cerr << "Error While Accessing : " << iter->path().string() << " :: " << ec.message() << '\n';
        }
    }
    onFinished();
}

int main() {
    GetSourceCodeFiles("./*.cpp",
            [](std::string filename) {
                std::cout << filename << std::endl;
            },
            [](){
                std::cout << "Finished!" << std::endl;
            });
    return 0;
}
