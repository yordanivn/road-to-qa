// function solve(wordToReplace,text){
//     const separetedWords=wordToReplace.split(', ');
//     const templateWords=text.split(' ');
//     let result='';
//     for(const templateWord of templateWords){
//         if(templateWord[0]==='*'){
//             const corespondigWord=separetedWords.find(x=>x.length===templateWord.length)
//             result+= `${corespondigWord} `
//         }
//         else {
//             result+= `${templateWord} `;
//         }
//     }
//     console.log(result)
// }
function solve(words,template){
    const separetedWords=words.split(', ');
    for(const separetedWord of separetedWords){
        template=template.replace('*'.repeat(separetedWord.length),separetedWord)
    }
    console.log(template)
}
solve('great, learning', 'softuni is ***** place for ******** new programming languages' )