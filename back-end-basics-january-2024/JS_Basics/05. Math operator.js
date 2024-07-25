function solve(num1,num2,operand){
    switch(operand){
        case '+': console.log(num1+num2)
        break
        case '-': console.log(num1-num2)
        break
        case '*': console.log(num1*num2)
        break
        case '/': console.log(num1/num2)
        break
        case '%': console.log(num1%num2)
        break
        case '**': console.log(num1**num2)
        break
        default:console.log('Error!')
    }
}