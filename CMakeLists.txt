#Simple CMakeLists for compiler aplicattion

cmake_minimum_required(VERSION 3.5)

project(maProc VERSION 0.1)
set(CMAKE_INCLUDE_CURRENT_DIR ON)
set(DEBUG OFF)

# flags default
set(CMAKE_CXX_FLAGS  "-O2 -static -Os")

if(DEBUG)
  set(CMAKE_CXX_FLAGS  "-O2 -DDEBUG")
endif()

add_library(Analytics STATIC 

    src/include/intelitrader.cpp
  )

add_executable( EstoqueOperacional src/main.cpp )

target_link_libraries(EstoqueOperacional Analytics)
