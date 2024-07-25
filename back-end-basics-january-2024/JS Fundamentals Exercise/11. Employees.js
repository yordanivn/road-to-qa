function solve(arrayOfEmpoyee){
    const employeeData=[];

    for(const rawData of arrayOfEmpoyee){
        employeeData.push({
            name:rawData,
            personalNumber:rawData.length
        })
    }
    employeeData.forEach((employeeData)=>console.log(`Name: ${employeeData.name} -- Personal Number: ${employeeData.personalNumber}`))
}
solve([ 'Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal' ])