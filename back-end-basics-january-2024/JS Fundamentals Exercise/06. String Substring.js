function solve(findWord,text){
    let textTolower=text.toLowerCase();
    textTolower=textTolower.split(' ');
    // for(const word of textTolower){
    //     if(word===findWord){
    //         console.log(word);
    //         break;
    //     }
    // }
    if(textTolower.includes(findWord)){
        console.log(findWord)
    }
    else {
        console.log(`${findWord} not found!`)
    }
    
}
solve('javascript', 'JavaScript is the best programming language')