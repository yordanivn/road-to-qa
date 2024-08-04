function cinema(movies){
    let moviesNumber=movies.shift();
    let allMovies=[];
    
    for(let i=0;i<=moviesNumber-1;i++){
        allMovies.push(movies.shift());
        //console.log(allMovies[i])
    }
    for(const command of movies){
        if(command.startsWith("Add ")){
            let movieToAdd=command.slice(4);
            allMovies.push(movieToAdd);
        }
        else if(command.startsWith("Sell")){
                let firstMovie=allMovies[0];
                console.log(`${firstMovie} ticket sold!`)
                allMovies.shift();
        }
        else if (command.startsWith("Swap ")){
            let swapCommand=command.slice(5);
            let firstElement=parseInt(swapCommand.split(" ")[0]);
            let secondElement=parseInt(swapCommand.split(" ")[1]);
            [allMovies[firstElement],allMovies[secondElement]]=[allMovies[secondElement],allMovies[firstElement]];
            console.log("Swapped!");
        }
        else if(command.startsWith("End"))
        {
            if(allMovies.length===0){
                console.log("The box office is empty")
            }
            else{
                let ticketsLeft=allMovies.join(", ");
        
                console.log(`Tickets left: ${ticketsLeft}`)
            }
            break;
        }
        
    }
    
    
     }
        
cinema(['3','Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1'])
//cinema(['5', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'The Dark Knight', 'Inception', 'Add The Lord of the Rings', 'Swap 1 4', 'End'])
//cinema(['3','Star Wars','Harry Potter', 'The Hunger Games','Sell','Sell','Sell','End'])