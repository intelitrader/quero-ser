"""This module encopassing function to deal with files"""
import csv, os


def __convert_csv_line_to_list(csv_line):
    """Get the comma separeted string, turn it into a array"""
    return csv_line.split(";")


def read_csv_file(file_path):
    """This function open a csv file,load each line into a array and each array in a bparent array"""
    data = []

    with open(file_path, mode="r") as file:
        data_readed = csv.reader(file)
        for row in data_readed:
            data.append(__convert_csv_line_to_list(row[0]))
    
    return data


def plot_table_to_txt_file(file_path, table):
    with open(file_path, mode="w") as file:
        file.write(table)


def plot_data_as_log(file_path, data):
    with open(file_path, mode="w") as file:
        for line in data:
            file.write(f"{line}\n")
