function personInfo(){
    let person={};
    person.firstName=firstName;
    person.lastName=lastName;
    person.age=age;
    return person;
}
let person=personInfo(firstName,lastName,age)
console.log(person)