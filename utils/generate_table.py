from tabulate import tabulate


def create_table(col_names, data):
    return tabulate(data, headers=col_names)