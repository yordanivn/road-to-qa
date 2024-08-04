function shop(products,args){
    let numberOfProducts=products.shift();
    let allProducts=[];
    for(let i=0;i<numberOfProducts;i++){
        allProducts.push(products.shift());
    }
    let allCommands=products;
    for(let command of allCommands){
        if(command.startsWith("Sell")){
            console.log(`${allProducts[0]} product sold!`)
            allProducts.shift();
        }
        else if(command.startsWith("Add ")){
            let productToAdd=command.slice(4);
            allProducts.push(productToAdd);
        }
        else if(command.startsWith("Swap ")){
            let swapIndexes=command.slice(5);
            let firstIndex=parseInt(swapIndexes.split(" ")[0]);
            let secondIndex=parseInt(swapIndexes.split(" ")[1]);
            [allProducts[firstIndex],allProducts[secondIndex]]=[allProducts[secondIndex],allProducts[firstIndex]];
            console.log("Swapped!")
        }
        else if(command.startsWith("End")){
            if(allProducts.length===0){
                console.log("The shop is empty")
            }
            else{
                console.log(`Products left: ${allProducts.join(", ")}`)
            }
            break;
            
        }
    }

}
shop(['3', 'Apple', 'Banana', 'Orange','Sell', 'End', 'Swap 0 1'])