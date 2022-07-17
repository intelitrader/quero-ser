"""This module encopassing the class of a sale"""
from classes.sales_channel import SalesChannel

class Sale:
    """This class represents the sale entity"""
    def __init__(self, product_code, sold_amount, sale_situation, sales_channel_code):
        self.product_code = product_code
        self.sold_amount = sold_amount
        self.sale_situation = sale_situation
        self.sales_channel = SalesChannel.get_instance_by_channel_code(sales_channel_code)

        # increment the sales for a channel
        self.sales_channel.set_sales_made(self.sale_situation, self.sold_amount)


    def __repr__(self):
        return self.product_code