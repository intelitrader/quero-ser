"""This module encopassing the class of a product"""


class Product:
    """Class that represents the product instance"""
    def __init__(self, code, quantity, min_quantity):
        self.code = code
        self.quantity = quantity
        self.min_quantity = min_quantity
        self.sales = 0


    def set_sales_product(self, sales_report):
        """This method takes a sales report and verify the sales number to the product"""
        for sale in sales_report:
            if sale.product_code == self.code:
                if sale.sale_situation == "100" or sale.sale_situation == "102":
                    self.sales += int(sale.sold_amount)

    def get_quantity_after_sales(self):
        return int(self.quantity) - int(self.sales)


    def get_sales_product(self):
        return self.sales


    def get_needs(self):
        min_quantity = int(self.min_quantity)
        quantity = self.get_quantity_after_sales()
        
        if quantity >= min_quantity:
            return 0
        
        return min_quantity - quantity
    

    def get_trasfer_quantity(self):
        needs = self.get_needs()
        if needs > 1 and needs < 10:
            return 10
        return needs
    
    def generate_transfer_data_to_build_report(self):
        storage_after_sales = self.get_quantity_after_sales()
        needs = self.get_needs()
        transefer_quantity = self.get_trasfer_quantity()
        return [self.code, self.quantity, self.min_quantity,self.sales, storage_after_sales, needs, transefer_quantity]


    def __repr__(self):
        return self.code
