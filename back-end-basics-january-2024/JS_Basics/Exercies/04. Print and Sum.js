function solve(start,end){
    let sum=0;
    let numbers="";
    for(let i=start;i<=end;i++){
        sum=sum+i;
        numbers+=i+ " ";
    }
    console.log(numbers);
    console.log(`Sum: ${sum}`)

}
solve(5,10)