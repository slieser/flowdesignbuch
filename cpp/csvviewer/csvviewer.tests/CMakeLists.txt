include(FetchContent)
FetchContent_Declare(
  googletest
  DOWNLOAD_EXTRACT_TIMESTAMP True
  URL https://github.com/google/googletest/archive/refs/tags/release-1.12.0.tar.gz
)
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
set(INSTALL_GTEST OFF CACHE BOOL "")
FetchContent_MakeAvailable(googletest)
include(GoogleTest)
file(COPY ${CMAKE_CURRENT_SOURCE_DIR}/persons.csv DESTINATION ${CMAKE_BINARY_DIR}/Tests) 

add_executable(csvviewer.tests ui.tests.cpp interactors.tests.cpp)
target_link_libraries(csvviewer.tests PRIVATE gmock_main csvviewer.lib)
set_target_properties(csvviewer.tests PROPERTIES RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/Tests)
gtest_discover_tests(csvviewer.tests)