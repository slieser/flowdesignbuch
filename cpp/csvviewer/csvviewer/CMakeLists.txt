
add_library(csvviewer.lib Commandline.cpp Csv.cpp FileProvider.cpp Interactors.cpp Paging.cpp Ui.cpp)
target_include_directories(csvviewer.lib INTERFACE .)
set_target_properties(csvviewer.lib PROPERTIES RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)

add_executable(csvviewer main.cpp)
target_link_libraries(csvviewer csvviewer.lib)
set_target_properties(csvviewer PROPERTIES RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
file(COPY ${CMAKE_CURRENT_SOURCE_DIR}/persons.csv DESTINATION ${CMAKE_BINARY_DIR}/bin)
