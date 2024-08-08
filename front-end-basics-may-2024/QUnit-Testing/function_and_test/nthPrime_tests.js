const {nthPrime}=require("./test_functions.js")

QUnit.module("nthPrime function testing",()=>{
    QUnit.test("1 as input returns 2",function(assert){
        assert.equal(nthPrime(1),2,"1 as input return 2")
    })

    QUnit.test("5 as input returns 11",function(assert){
        assert.equal(nthPrime(5),11,"5 as input return 11")
    })

    QUnit.test("11 as input returns 31",function(assert){
        assert.equal(nthPrime(11),31,"11 as input return 31")
    })

})