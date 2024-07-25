function solve(speed,area){
     const motorway=130;
     const interstate=90;
     const city=50;
     const residential=20;
     let status;

     if(area==='motorway'){
        let difference=speed-motorway;
            if(difference<=20) {
                status='speeding';
            }
            else if(difference>20 && difference<=40)
            {
                status='excessive speeding';
            }
            else {
                status='reckless driving';
            }
        if(speed<=130){
            console.log(`Driving ${speed} km/h in a ${motorway} zone`)
        }
        else{
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${motorway} - ${status}`)
        }

     }
     else if(area==='interstate'){
        let difference=speed-interstate;
            if(difference<=20) {
                status='speeding';
            }
            else if(difference>20 && difference<=40)
            {
                status='excessive speeding';
            }
            else {
                status='reckless driving';
            }
        if(speed<=90){
            console.log(`Driving ${speed} km/h in a ${interstate} zone`)
        }
        else{
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${interstate} - ${status}`)
        }

     }
     else if((area==='city')){
        let difference=speed-city;
            if(difference<=20) {
                status='speeding';
            }
            else if(difference>20 && difference<=40)
            {
                status='excessive speeding';
            }
            else {
                status='reckless driving';
            }
        if(speed<=50){
            console.log(`Driving ${speed} km/h in a ${city} zone`)
        }
        else{
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${city} - ${status}`)
        }

     }
     else if(area==='residential'){
        let difference=speed-residential;
            if(difference<=20) {
                status='speeding';
            }
            else if(difference>20 && difference<=40)
            {
                status='excessive speeding';
            }
            else {
                status='reckless driving';
            }
        if(speed<=20){
            console.log(`Driving ${speed} km/h in a ${residential} zone`)
        }
        else{
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${residential} - ${status}`)
        }
        
     }
     else;
     
}
solve(200,'motorway')