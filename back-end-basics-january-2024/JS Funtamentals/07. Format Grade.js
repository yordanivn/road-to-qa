function solve(grade){
    if(grade<3.00) {
        console.log(`Fail (${Math.floor(grade.toFixed(2))})`)
    }
    else if(grade>=3 && grade<3.50){
        console.log(`Poor (${grade.toFixed(2)})`)
    }
    else if(grade>=3.50 && grade<4.50){
        console.log(`Good (${grade.toFixed(2)})`)
    }
    else if(grade>=4.50 && grade<5.0){
        console.log(`Very good (${grade.toFixed(2)})`)
    }
    else if(grade>=5.0){
        console.log(`Excellent (${grade.toFixed(2)})`)
    }
    
}
solve(3.33)