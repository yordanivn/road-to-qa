function solve(inputArray,rotation){
    for(let i=0;i<rotation;i++){
        let firstElm=inputArray.shift();
        inputArray.push(firstElm);
    }
    console.log(inputArray.join(' ')); 
}