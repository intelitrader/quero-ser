"""This module is the entry point of the application"""
from classes.system import System

def main():
    app = System(input_data_folder="input",output_data_folder="output")
    app.start()


if __name__ == "__main__":
    main()
