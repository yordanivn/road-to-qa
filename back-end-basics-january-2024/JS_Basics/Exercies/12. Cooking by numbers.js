function solve(rawNumber,firstOp,secOp,thirdOp,forthOp,fifthOp){
    const operations=[firstOp,secOp,thirdOp,forthOp,fifthOp];

    function executeOperation(currentNumber,currentOperation){
        if(currentOperation==='chop'){
            return currentNumber/2;
        }
        else if(currentOperation==='dice'){
            return Math.sqrt(currentNumber);
        }
        else if(currentOperation==='spice'){
            return currentNumber+1;
        }
        else if(currentOperation==='bake'){
            return currentNumber*3;
        }
        else if(currentOperation==='fillet'){
            return currentNumber*0.8;
        }
        else return currentNumber;
    }
    let number=parseInt(rawNumber,10);
    for (const operation of operations) {
        number=executeOperation(number,operation)
        console.log(number)
    }
}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')