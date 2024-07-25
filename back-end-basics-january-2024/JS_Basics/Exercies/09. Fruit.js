function solve(name,grams,perKg){
    let neededMoney=(grams/1000)*perKg;
    console.log(`I need $${neededMoney.toFixed(2)} to buy ${(grams/1000).toFixed(2)} kilograms ${name}.`)
}
solve('orange',2500,1.8)