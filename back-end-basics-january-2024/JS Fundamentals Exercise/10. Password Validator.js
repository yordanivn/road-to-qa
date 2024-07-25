function solve(password){
    const onlyLettersAndDigitsRegex=/^[a-zA-Z0-9]+$/;
    
    const errors=[];
    const countDigitInString=(word)=>{
        let counter=0;
        for(const char of word){
            if(!isNaN(parseInt(char))){
                counter++
            }
        }
        return counter
    }
    const numbersInDigitInString=countDigitInString(password);
    if(!password.match(onlyLettersAndDigitsRegex)){
        errors.push('Password must consist only of letters and digits')
    }
    if(password.length<6 || password.length>10){
        errors.push('Password must be between 6 and 10 characters')
    }
    if(numbersInDigitInString<2){
        errors.push('Password must have at least 2 digits')
    }
    if(errors.length===0){
        console.log('Password is valid')
    }
    else {
        errors.forEach((error)=>console.log(error))
    }
}
solve('logIn')