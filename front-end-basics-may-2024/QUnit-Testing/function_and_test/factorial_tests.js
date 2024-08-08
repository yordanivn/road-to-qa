const {factorial}=require("./test_functions.js")

QUnit.module("Factorial fuction testing",()=>{
    QUnit.test("Calculation factorial with positive input",function(assert){
        assert.equal(factorial(5),120,"5 factorial is 120")
    })

    QUnit.test("Calculation 0 factorial",function(assert){
        assert.equal(factorial(0),1,"0 Factorial is 1")
    })

    QUnit.test("Callucation factorial with negative input",function(assert){
        assert.equal(factorial(-3),1,"-1 factorial is 1")
    })
})