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