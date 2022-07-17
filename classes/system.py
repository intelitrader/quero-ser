"""This module encopassing the class that represents the cicle of the application"""
from classes.sales import Sale
from classes.products import Product
from classes.sales_channel import SalesChannel, instantiate_sales_channels
from utils.manage_files import read_csv_file, plot_table_to_txt_file, plot_data_as_log
from utils.generate_table import create_table
from utils.manage_divergences import generate_divergences_data


class System:
    def __init__(self, input_data_folder, output_data_folder):
        self.input_folder = input_data_folder
        self.output_folder = output_data_folder
    
    def start(self):
        instantiate_sales_channels() # create the avaiable sales channels in memory

        products_data = read_csv_file(f"{self.input_folder}/PRODUCTS.txt") # loads the product_data from the file
        products = [Product(*product) for product in products_data] # structure the products data

        sales_data = read_csv_file(f"{self.input_folder}/SALES.txt") # loads the sales data from the file
        sales = [Sale(*sale) for sale in sales_data] # struncture the sales data
        
        #----------

        # trasnfer report build starts here
        transfer_data = []

        for product in products:
            product.set_sales_product(sales)
            transfer_data.append(product.generate_transfer_data_to_build_report())
        
        transfer_table_col_names = ["Produto", "QtCO","QtMin", "QtVendas", "Estq. após Vendas", "Necess.", "Transf. de Arm p/ CO"]
        transfer_table = create_table(transfer_table_col_names,transfer_data)
        
        plot_table_to_txt_file(file_path=f"{self.output_folder}/TRASFER.txt", table=transfer_table)

        # divergences report build starts here

        products_codes = [product.code for product in products]
        divergences = generate_divergences_data(products_codes, sales)
        plot_data_as_log(file_path=f"{self.output_folder}/DIVERGENCES.txt",data=divergences)

        # sale channels report start here
        sale_channels = [channel for channel in SalesChannel.channels]
        sales_channel_table_col_names = ["Canal", "QtVendas"]
        sales_channel_data_structured = [[f"{channel.code} - {channel.name}", channel.get_sales_made()] for channel in sale_channels]
        sale_channel_table = create_table(sales_channel_table_col_names, sales_channel_data_structured)
        plot_table_to_txt_file(file_path=f"{self.output_folder}/TOTCHANNEL.txt", table=sale_channel_table)