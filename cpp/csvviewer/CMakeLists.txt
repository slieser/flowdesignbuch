cmake_minimum_required(VERSION 3.20)
project(csvviewer CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

add_subdirectory(csvviewer)
add_subdirectory(csvviewer.tests)
