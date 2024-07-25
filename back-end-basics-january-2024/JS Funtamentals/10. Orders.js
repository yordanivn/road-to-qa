function solve(product,quantity){
    let coffee = 1.50
    let water = 1.00
    let coke = 1.40
    let snacks = 2.00
    let result=0;
    switch(product){
        case'coffee': result=coffee*quantity;
        break;
        case'water': result=water*quantity;
        break;
        case'coke': result=coke*quantity;
        break;
        case'snacks': result=snacks*quantity;
        break;
    }
    console.log(result.toFixed(2))
}
solve('water',5)