import fs from "node:fs";

// store total sales by channel
const quantitiesByChannel = {
    1: 0,
    2: 0,
    3: 0,
    4: 0,
}

// function to update quantities sales by channel
const updateQuantitiesBySalesChannels = (sales) => {
    sales.forEach((sale) => {
        const channel       = sale.channel;
        const sellSituation = sale.sellSituation;
        const quantities    = sale.quantities;

        if (sellSituation === 100 || sellSituation === 102){
            if (channel in quantitiesBySaleChannels){
                quantitiesBySaleChannels[channel] += quantities
            } else {
                return `Channel ${channel} not found!`
            }
        }
    })
}

// function to write quantities by channel on file
const writeTotalsByChannel = () => {
    let text = "Quantidade de vendas por canal\n\n";

    for (let channel in quantitiesBySaleChannels){
        const quantitie = quantitiesBySaleChannels[channel];
        let channelName;

        switch (parseInt(channel)){
            case 1:
                channelName = "Representantes";
                break;
            case 2:
                channelName = "Website";
                break;
            case 3:
                channelName = "App móvel Android";
                break
            case 4:
                channelName = "App móvel iPhone";
                break
            default:
                channelName = `Canal ${channel}`
        }
        text += `${channel} - ${channelName} = ${quantitie} \n\n`
    }
 
    fs.writeFileSync("TOTCANAIS.TXT", text, err => {
        if (err) throw err;
    });
}
