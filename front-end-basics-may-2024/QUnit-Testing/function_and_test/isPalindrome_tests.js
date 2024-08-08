const {isPalindrome}=require("./test_functions.js")

QUnit.module("isPalindrome function testing",()=>{
    QUnit.test("Single word palindrome",function(assert){
        assert.ok(isPalindrome("racecar"),"racecar","Shoud return true")
    })
    QUnit.test("Multi word palindrome",function(assert){
        assert.ok(isPalindrome("A man, a plan, a canal, Panama!"),"A man, a plan, a canal, Panama!","Should return true")
    })

    QUnit.test("Non palindrome word",function(assert){
        assert.notOk(isPalindrome("hello"),"hello","Should return false")
    })

    QUnit.test("Testing with empty string",function(assert){
        assert.ok(isPalindrome(""),"","Should return false")
    })
})