function solve(number,groupType,dayOfWeek){
    let result;
    if(groupType==='Students'){
        if(dayOfWeek==='Friday'){
            result=number*8.45;
        }
        else if(dayOfWeek==='Saturday'){
            result=number*9.80;
        }
        else if(dayOfWeek==='Sunday'){
            result=number*10.46;
        }
        if(number>=30){
            result=result*0.85;
        }
    }
    else if(groupType==='Business'){
        if(number>=100){
            number=number-10;
        }
        if(dayOfWeek==='Friday'){
            result=number*10.90;
        }
        else if(dayOfWeek==='Saturday'){
            result=number*15.60;
        }
        else if(dayOfWeek==='Sunday'){
            result=number*16;
        }
    }
    else if(groupType==='Regular'){
        if(dayOfWeek==='Friday'){
            result=number*15;
        }
        else if(dayOfWeek==='Saturday'){
            result=number*20;
        }
        else if(dayOfWeek==='Sunday'){
            result=number*22.50;
        }
        if(number>=10 && number<=20){
            result=result*0.95;
        }
    }
    console.log(`Total price: ${result.toFixed(2)}`)
}
solve(40,'Regular','Saturday')