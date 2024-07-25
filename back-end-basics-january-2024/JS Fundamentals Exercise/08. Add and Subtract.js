function solve(num1,num2,num3){

        function sum(num1,num2){
        return num1+num2
        }

        function subtract(num3){
        return sum(num1,num2)-num3;
        }
    const result=subtract(num3)
    console.log(result)
}
solve(23,6,10)