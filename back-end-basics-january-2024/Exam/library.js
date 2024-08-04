function library(books){
    let booksNumber=books.shift();
    let allBooks=[];
    for(let i=0;i<booksNumber;i++){
        allBooks.push(books.shift());
    }
    let allCommands=books;
    for(commad of allCommands){
        if(commad.startsWith("Lend")){
            console.log(`${allBooks[0]} book lent!`);
            allBooks.shift();
        }
        if(commad.startsWith("Return ")){
            let bookToAdd=commad.slice(7);
            allBooks.unshift(bookToAdd);
        }
        if(commad.startsWith("Exchange ")){
            let exchangeIndexes=commad.slice(9);
            let startIndex=parseInt(exchangeIndexes.split(" ")[0]);
            let endIndex=parseInt(exchangeIndexes.split(" ")[1]);
            [allBooks[startIndex],allBooks[endIndex]]=[allBooks[endIndex],allBooks[startIndex]];
            console.log("Exchanged!");
        }
        if(commad.startsWith("Stop")){
            if(allBooks<=0){
                console.log("The library is empty");
            }
            else {
                console.log(`Books left: ${allBooks.join(", ")}`)
            }
            break;
        }
    }
}

//library(['3', 'Harry Potter', 'The Lord of the Rings', 'The Hunger Games', 'Lend', 'Stop', 'Exchange 0 1'])
//library(['5', 'The Catcher in the Rye', 'To Kill a Mockingbird', 'The Great Gatsby', '1984', 'Animal Farm', 'Return Brave New World', 'Exchange 1 4', 'Stop'])
library(['3', 'The Da Vinci Code', 'The Girl with the Dragon Tattoo', 'The Kite Runner', 'Lend', 'Lend', 'Lend', 'Stop']) 