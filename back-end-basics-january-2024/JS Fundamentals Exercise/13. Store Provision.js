function solve(currentStock,orderedStock){
    const storeStock={};
    for(index=0;index<currentStock.length;index+=2){
        const stockName=currentStock[index];
        const stockAmount=parseInt((currentStock[index+1]),10)

        storeStock[stockName]=stockAmount
    }
    for(index=0;index<orderedStock.length;index+=2){
        const stockName=orderedStock[index];
        const stockAmount=parseInt(orderedStock[index+1],10)

        if(storeStock[stockName!==undefined]){
            storeStock[stockName]+=stockAmount
        }
        else{
            storeStock[stockName]=stockAmount
        }
    }
    Object.keys(storeStock).forEach((item)=>console.log(`${item} -> ${storeStock[item]}`))
}
solve([ 'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2' ], [ 'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30' ])