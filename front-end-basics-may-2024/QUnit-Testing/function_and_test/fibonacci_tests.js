const {fibonacci}=require("./test_functions.js")

QUnit.module("Fibonacci function testing",()=>{
    QUnit.test("Zero input return empty array",function(assert){
        assert.deepEqual(fibonacci(0),[],"Zero input return empty array")
    })

    QUnit.test("1 as input return array with one element",function(assert){
        assert.deepEqual(fibonacci(1),[0],"1 as input return array with one element- zero")
    })

    QUnit.test("5 as input return correct array",function(assert){
        assert.deepEqual(fibonacci(5),[0,1,1,2,3],"Fibonacci sequance of 5")
    })
    
    QUnit.test("10 as input return correct array",function(assert){
        assert.deepEqual(fibonacci(10),[0,1,1,2,3,5,8,13,21,34],"Fibonacci sequance of 10")
    })
})