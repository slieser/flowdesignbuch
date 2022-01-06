#include <iostream>
#include <filesystem>

void findSourceFilenames(
        std::string directory,
        std::function<void(std::string filename)> onFilename,
        std::function<void()> onFinished) {

    std::filesystem::recursive_directory_iterator iter(directory);
    std::filesystem::recursive_directory_iterator end;

    while (iter != end)
    {
        if(iter->path().extension() == ".cpp") {
            onFilename(iter->path().string());
        }

        std::error_code ec;
        iter.increment(ec);
        if (ec) {
            std::cerr << "Error While Accessing : " << iter->path().string() << " :: " << ec.message() << '\n';
        }
    }
    onFinished();
}

int main() {
    findSourceFilenames("../",
        [](std::string filename) {
            std::cout << filename << std::endl;
        },
        []() {
            std::cout << "Finished!" << std::endl;
        });
    return 0;
}
