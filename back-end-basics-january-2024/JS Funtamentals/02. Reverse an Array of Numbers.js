function reversedArr(number,array){
    let newArr=[];
    for(let i=0;i<number;i++){
        newArr.unshift(array[i])
    }
    console.log(newArr.join(" "))
}
reversedArr(3, [10, 20, 30, 40, 50])
