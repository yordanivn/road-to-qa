function sum(a,b) {
    return a+b
}

function isEven(number){
    return number%2==0;
}

function factorial(n){
    if(n===0 || n===1 || n<0){
        return 1;
    }
    return n*factorial(n-1)
}

function isPalindrome(str){
    if(str===" "){
        return false;
    }
    const clearStr=str.toLowerCase().replace(/[\W_]/g,'');
    const reversedStr=clearStr.split('').reverse().join('');
    return clearStr===reversedStr;
}

function fibonacci(n){
    if(n===0){
        return []
    }
    if(n===1){
        return [0]
    }
    let seq=[0,1]
    for(let i=2;i<n;i++){
        seq.push(seq[i-1]+seq[i-2])
    }
    return seq;
}
function isPrime(num){
    if(num<=1) return false;
    if(num<=3) return true;
    if(num%2===0 || num%3===0) return false;
    for(let i=5;i*i<=num;i+=6){
        if(num%i===0 || num%(i+2)===0) return false;
    }
    return true
}

function nthPrime(n){
    let count=0;
    let num=2;
    while(count<n){
        if(isPrime(num)){
            count++;
        }
        num++
    }
    return num-1
}

function pascalTriangle(rows){
    let triangle=[]
    for(let i=0;i<rows;i++){
        triangle[i]=[];
        triangle[i][0]=1;
        for(let j=1;j<i;j++){
            triangle[i][j]=triangle[i-1][j-1]+triangle[i-1][j];
        }
        triangle[i][i]=1
    }
    return triangle
}

function isPefectSquare(num){
    return Math.sqrt(num)%1===0
}

module.exports={
    sum,
    isEven,
    factorial,
    isPalindrome,
    fibonacci,
    nthPrime,
    pascalTriangle,
    isPefectSquare
}