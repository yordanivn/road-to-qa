function solve(input){
    const typeOfParam=typeof input;
    if(typeOfParam==='number'){
        let result=Math.pow(input,2)*Math.PI;
        console.log(result.toFixed(2));

    }
    else{
        console.log(`We can not calculate the circle area, because we received a ${typeOfParam}.`)
    }
}
solve(5)