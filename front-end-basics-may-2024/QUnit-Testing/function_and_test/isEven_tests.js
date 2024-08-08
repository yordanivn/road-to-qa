const {isEven}=require("./test_functions.js")

QUnit.module('isEven tests',()=>{
    QUnit.test('Even number as input, return true',function(assert){
        assert.ok(isEven(2),"Indetifiying even number: 2")
    })
    QUnit.test("Odd number", function(assert){
        assert.notOk(isEven(3),"Identifying odd number: 3")
    })
    QUnit.test('Zero number',function(assert){
        assert.ok(isEven(0),"Identifying even number: 0")
    })
})