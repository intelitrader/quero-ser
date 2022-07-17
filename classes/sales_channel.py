"""This module encopassing the sales chanel class"""

# dict to map the chanel code to it's name
sales_channel_names = {
    "1": "Representantes",
    "2": "Website",
    "3": "App móvel Android",
    "4": "App móvel iPhone"
}


# Hellper function
def instantiate_sales_channels():
    for chanell in sales_channel_names:
        SalesChannel(chanell)


class SalesChannel:
    channels = []

    def __init__(self, code):
        self.code = code
        self.name = sales_channel_names.get(self.code)
        self.sales_made = 0
        
        if self not in SalesChannel.channels:
            SalesChannel.channels.append(self)

    def set_sales_made(self, sale_situation, sold_amount):
        if sale_situation == "100" or sale_situation == "102":
            self.sales_made += int(sold_amount)
    
    def get_sales_made(self):
        return self.sales_made
    

    def get_instance_by_channel_code(code):
        for channel in SalesChannel.channels:
            if code == channel.code:
                return channel
        return "Invalid code"

    def __repr__(self):
        return self.name


