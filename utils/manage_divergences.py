"""This module is responsible to generate the divergences report based on the products and sales"""


def product_nonexistent(line, product_code):
    return f"Linha {line} - Código de Produto não encontrado {product_code}"

def sale_canceled(line):
    return f"Linha {line} - Venda cancelada"

def sale_not_finished(line):
    return f"Linha {line} - Venda não finalizada"

def unknown_error(line): 
    return f"Linha {line} - Erro desconhecido. Acionar a equipe de TI"

def generate_divergences_data(products, sales):
    divergences_data = []

    for i, sale in enumerate(sales):
        line = i + 1
        
        if sale.sale_situation == "135":
            divergences_data.append(sale_canceled(line))
        
        elif sale.sale_situation == "190":
            divergences_data.append(sale_not_finished(line))
        
        elif sale.sale_situation == "999":
            divergences_data.append(unknown_error(line))

        elif sale.product_code not in products:
            divergences_data.append(product_nonexistent(line, sale.product_code))
    
    return divergences_data
