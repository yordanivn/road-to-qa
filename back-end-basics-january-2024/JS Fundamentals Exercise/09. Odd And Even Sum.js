function solve(input){
    let digit=[];
    let evenSum=0;
    let oddSum=0;
    while(input>0){
        let currentDigit=input%10;
        if(currentDigit%2==0){
            evenSum+=currentDigit;
        }
        else {
            oddSum+=currentDigit;
        }
        input=Math.floor(input/10);
    }
    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`
}
