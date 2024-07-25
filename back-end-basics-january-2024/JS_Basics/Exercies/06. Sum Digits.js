function solve(number){
    const numberAsString=number.toString();
    let sum=0;
    
    for(const char of numberAsString){
        const charAsNumber=parseInt(char,10);
        sum+=charAsNumber
    }
    console.log(sum)
}
solve(543)
