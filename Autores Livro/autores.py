

def autores(name):
    inherited_names = ['filho', 'filha', 'neto', 'neta', 'sobrinho', 'sobrinha']
    
    if len(name) == 0:
        return ''

    parts = name.split(' ')

    if len(parts) == 1:
        return parts[0].upper()

    if inherited_names.count(parts[len(parts)-1:len(parts)][0].lower()) and len(parts) >= 3:
        first_names = parts[0:len(parts)-2]
        last_two_names = parts[len(parts)-2:len(parts)]
        names = first_names
        names.append(' '.join(last_two_names))
        parts = names

    return parts[len(parts) - 1].upper() + ',' + first_capital_letter(' '.join(parts[0:len(parts) - 1]))
def first_capital_letter(string):
    prepositions = ['da', 'de', 'do', 'das', 'dos']

    new_string = ''

    parts = string.split(' ')

    for part in parts:
        if prepositions.count(part.lower()) == 1:
            new_string = new_string + ' ' + part.lower()
        else:
            new_string = new_string + ' ' + part[0].upper() + part[1:len(part)].lower()

    return new_string