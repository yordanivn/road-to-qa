function phoneBook(input){
    let uniqueNames={};
    input.forEach(element => {
        let keyValuePair=element.split(" ");
        let name=keyValuePair[0];
        let phoneNumber=keyValuePair[1];
        uniqueNames[name]=phoneNumber;
    });

    for(let key in uniqueNames){
        console.log(`${key} -> ${uniqueNames[key]}`);
    }
}