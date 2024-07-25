function solve(inputArray){
    inputArray.sort((a,b)=>a.localeCompare(b))
    for(let index=1 ;index<=inputArray.length;index++){
        console.log(`${index}. ${inputArray[index-1]}`)
    }
}
solve (["John", "Bob", "Christina", "Ema"]) 